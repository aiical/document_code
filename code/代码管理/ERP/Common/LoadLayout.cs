using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.ComponentModel.Design;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using System.Data;

namespace Common
{
    class LoadLayout
    {
        private Control host = null;
        private string FormTag;

        public LoadLayout(Control c, string formTag)
        {
            host = c;
            FormTag = formTag;
        }

        #region DeSerialize - Load


        public MemoryStream LoadFormDB(string formTag)
        {
            string SQL = "select * from t_FormFormat where F_FormName = '" + formTag + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["F_Stream"] == DBNull.Value) return null;
                MemoryStream stream = new MemoryStream((byte[])ds.Tables[0].Rows[0]["F_Stream"]);
                return stream;

            }
            return null;
        }


        /// <summary>
        /// This method is used to parse the given file.  Before calling this 
        /// method the host member variable must be setup.  This method will
        /// create a data set, read the data set from the XML stored in the
        /// file, and then walk through the data set and create components
        /// stored within it.  The data set is stored in the persistedData
        /// member variable upon return.
        /// </summary>
        public string SetLayout()
        {
            string baseClass = null;

            // Anything unexpected is a fatal error.
            //
            try
            {
                // The main form and items in the component tray will be at the
                // same level, so we have to create a higher super-root in order
                // to construct our XmlDocument.
                MemoryStream s = LoadFormDB(FormTag);
                if (s == null) return "";
                StreamReader sr = new StreamReader(s);
                string cleandown = sr.ReadToEnd();

                cleandown = "<DOCUMENT_ELEMENT>" + cleandown + "</DOCUMENT_ELEMENT>";

                XmlDocument doc = new XmlDocument();

                doc.LoadXml(cleandown);

                // Now, walk through the document's elements.
                //

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node.Name.Equals("Component"))
                    {
                        ReadComponent(node);
                    }
                }

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (baseClass == null)
                    {
                        baseClass = node.Attributes["name"].Value;
                    }

                    if (node.Name.Equals("Object"))
                    {
                        ReadObject(node);
                    }
                    else
                    {
                       // MessageBox.Show(string.Format("Node type {0} is not allowed here.", node.Name));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误1");
            }
            return baseClass;
        }

        private Control FindControl(Control f, string contrlname)
        {
            if (f.Name == contrlname) return f;
            foreach (Control c in f.Controls)
            {
                if (c.Name == contrlname) return c;
                if (c.HasChildren == true)
                {
                    foreach (Control m in c.Controls)
                    {
                        if (m.Name == contrlname) return m;

                        if (m.HasChildren == true)
                        {
                            foreach (Control n in m.Controls)
                            {
                                if (n.Name == contrlname) return n;
                                if (n.HasChildren == true)
                                {
                                    foreach (Control p in n.Controls)
                                    {
                                        if (p.Name == contrlname) return p;

                                        if (p.HasChildren == true)
                                        {
                                            foreach (Control q in p.Controls)
                                            {
                                                if (q.Name == contrlname) return q;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                
            }
            return null;
        }

       
        private object ReadInstanceDescriptor(XmlNode node)
        {
            // First, need to deserialize the member
            //
            XmlAttribute memberAttr = node.Attributes["member"];

            if (memberAttr == null)
            {
                MessageBox.Show("No member attribute on instance descriptor","错误2");
                return null;
            }

            byte[] data = Convert.FromBase64String(memberAttr.Value);
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(data);
            MemberInfo mi = (MemberInfo)formatter.Deserialize(stream);
            object[] args = null;

            // Check to see if this member needs arguments.  If so, gather
            // them from the XML.
            if (mi is MethodBase)
            {
                ParameterInfo[] paramInfos = ((MethodBase)mi).GetParameters();

                args = new object[paramInfos.Length];

                int idx = 0;

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name.Equals("Argument"))
                    {
                        object value;

                        if (!ReadValue(child, TypeDescriptor.GetConverter(paramInfos[idx].ParameterType), out value))
                        {
                            return null;
                        }

                        args[idx++] = value;
                    }
                }

                if (idx != paramInfos.Length)
                {
                    MessageBox.Show(string.Format("Member {0} requires {1} arguments, not {2}.", mi.Name, args.Length, idx),"错误3");
                    return null;
                }
            }

            InstanceDescriptor id = new InstanceDescriptor(mi, args);
            object instance = id.Invoke();

            // Ok, we have our object.  Now, check to see if there are any properties, and if there are, 
            // set them.
            //
            foreach (XmlNode prop in node.ChildNodes)
            {
                if (prop.Name.Equals("Property"))
                {
                    ReadProperty(prop, instance);
                }
            }

            return instance;
        }

        private object ReadComponent(XmlNode node)
        {
            XmlAttribute typeAttr = node.Attributes["type"];

            if (typeAttr == null)
            {
                MessageBox.Show("<Object> tag is missing required type attribute", "错误4");
                return null;
            }

            Type type = Type.GetType(typeAttr.Value);

            if (type == null)
            {
                MessageBox.Show(string.Format("Type {0} could not be loaded.", typeAttr.Value), "错误5");
                return null;
            }

            // This can be null if there is no name for the object.
            //
            XmlAttribute nameAttr = node.Attributes["name"];

            IComponent n = (IComponent)Activator.CreateInstance(type);


            // Now, walk the rest of the tags under this element.
            //
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name.Equals("Property"))
                {
                    // A property.  Ask the property to parse itself.
                    //
                    ReadProperty(childNode, n);
                }
                else if (childNode.Name.Equals("Event"))
                {
                    // An event.  Ask the event to parse itself.
                    //
                    //ReadEvent(childNode, instance, errors);
                }
            }

            ((BaseClass.frmBase)host).components.Add(n, nameAttr.Value);
            return null;
        }


        /// Reads the "Object" tags. This returns an instance of the
        /// newly created object. Returns null if there was an error.
        private object ReadObject(XmlNode node)
        {
            XmlAttribute typeAttr = node.Attributes["type"];

            
            if (typeAttr == null)
            {
               MessageBox.Show("<Object> tag is missing required type attribute","错误4");
                return null;
            }

            Type type = Type.GetType(typeAttr.Value);

            if (type == null)
            {
                MessageBox.Show(string.Format("Type {0} could not be loaded.", typeAttr.Value),"错误5");
                return null;
            }

            // This can be null if there is no name for the object.
            //
            XmlAttribute nameAttr = node.Attributes["name"];

            object instance = null;
            bool bExist = false;

            instance = FindControl(host, nameAttr.Value);
            
            if (instance != null)
            {
                bExist = true;
            }

            if (bExist == false)
            {
                if (type.Name == "BindingSource") return null;
                if (type.Name == "BarManager") return null;
                if (type.Name == "Bar") return null;
                if (type.Name == "BarButtonItem") return null;
                if (type.Name == "BarStaticItem") return null;
                if (type.Name == "BarSubItem") return null;
                if (type.Name == "GridView") return null;
                if (type.Name == "RepositoryItemButtonEdit") return null;
                if (type.Name == "GridColumn") return null;

                instance = (Control)Activator.CreateInstance(type);

                ((Control)instance).Name = nameAttr.Value;
                host.Controls.Add(((Control)instance));

            }
            
            // Got an object, now we must process it.  Check to see if this tag
            // offers a child collection for us to add children to.
            //
            XmlAttribute childAttr = node.Attributes["children"];
            IList childList = null;

            if (childAttr != null)
            {
                PropertyDescriptor childProp = TypeDescriptor.GetProperties(instance)[childAttr.Value];

                if (childProp == null)
                {
                    MessageBox.Show(string.Format("The children attribute lists {0} as the child collection but this is not a property on {1}", childAttr.Value, instance.GetType().FullName),"错误6");
                }
                else
                {
                    childList = childProp.GetValue(instance) as IList;
                    if (childList == null)
                    {
                        MessageBox.Show(string.Format("The property {0} was found but did not return a valid IList", childProp.Name),"错误7");
                    }
                }
            }

            // Now, walk the rest of the tags under this element.
            //
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name.Equals("Object"))
                {
                    // Another object.  In this case, create the object, and
                    // parent it to ours using the children property.  If there
                    // is no children property, bail out now.
                    if (childAttr == null)
                    {
                        MessageBox.Show("Child object found but there is no children attribute","错误8");
                        continue;
                    }

                    // no sense doing this if there was an error getting the property.  We've already reported the
                    // error above.
                    if (childList != null)
                    {
                        object childInstance = ReadObject(childNode);

                        childList.Add(childInstance);
                    }
                }
                else if (childNode.Name.Equals("Property"))
                {
                    // A property.  Ask the property to parse itself.
                    //
                    ReadProperty(childNode, instance);
                }
                else if (childNode.Name.Equals("Event"))
                {
                    // An event.  Ask the event to parse itself.
                    //
                    //ReadEvent(childNode, instance, errors);
                }
            }

            return instance;
        }



        /// Parses the given XML node and sets the resulting property value.
        private void ReadProperty(XmlNode node, object instance)
        {
            XmlAttribute nameAttr = node.Attributes["name"];
            if (nameAttr == null)
            {
                MessageBox.Show("Property has no name", "错误9");
                return;
            }

            PropertyDescriptor prop = TypeDescriptor.GetProperties(instance)[nameAttr.Value];

            if (prop == null)
            {
                MessageBox.Show(string.Format("Property {0} does not exist on {1}", nameAttr.Value, instance.GetType().FullName), "错误10");
                return;
            }

            // Get the type of this property.  We have three options:
            // 1.  A normal read/write property.
            // 2.  A "Content" property.
            // 3.  A collection.
            //
            bool isContent = prop.Attributes.Contains(DesignerSerializationVisibilityAttribute.Content);

            if (isContent)
            {
                object value = prop.GetValue(instance);

                // Handle the case of a content property that is a collection.
                //
                if (value is IList)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.Equals("Item"))
                        {
                            object item;
                            XmlAttribute typeAttr = child.Attributes["type"];

                            if (typeAttr == null)
                            {
                                MessageBox.Show("Item has no type attribute", "错误11");
                                continue;
                            }

                            Type type = Type.GetType(typeAttr.Value);

                            if (type == null)
                            {
                                MessageBox.Show(string.Format("Item type {0} could not be found.", typeAttr.Value), "错误12");
                                continue;
                            }

                            if (ReadValue(child, TypeDescriptor.GetConverter(type), out item))
                            {
                                //if (type.Name == "RepositoryItemButtonEdit") continue;

                                try
                                {
                                    ((IList)value).Add(item);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message, "错误13");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Only Item elements are allowed in collections, not {0} elements.", child.Name), "错误14");
                        }
                    }
                }
                else
                {
                    // Handle the case of a content property that consists of child properties.
                    //
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.Equals("Property"))
                        {
                            ReadProperty(child, value);
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Only Property elements are allowed in content properties, not {0} elements.", child.Name), "错误15");
                        }
                    }
                }
            }
            else
            {
                object value;

                if (ReadValue(node, prop.Converter, out value))
                {

                    // ReadValue succeeded.  Fill in the property value.
                    //

                    if (value == null) return;

                    try
                    {
                        prop.SetValue(instance, value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误16");
                    }
                }
            }
        }

        private bool FindComponent(string CName, out object value)
        {
            foreach (IComponent c in ((BaseClass.frmBase)host).components.Components)
            {
                if (c.Site.Name == CName)
                {
                    value = c;

                    return true;
                }
            }
            value = null;
            return false;
        }

        /// Generic function to read an object value.  Returns true if the read
        /// succeeded.
        private bool ReadValue(XmlNode node, TypeConverter converter, out object value)
        {
            try
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.NodeType == XmlNodeType.Text)
                    {
                        value = converter.ConvertFromInvariantString(node.InnerText);
                        return true;
                    }
                    else if (child.Name.Equals("Binary"))
                    {
                        byte[] data = Convert.FromBase64String(child.InnerText);

                        
                        // Binary blob.  Now, check to see if the type converter
                        // can convert it.  If not, use serialization.
                        //
                        if (GetConversionSupported(converter, typeof(byte[])))
                        {
                            value = converter.ConvertFrom(null, CultureInfo.InvariantCulture, data);
                            
                            return true;
                        }
                        else
                        {
                            
                            BinaryFormatter formatter = new BinaryFormatter();
                            MemoryStream stream = new MemoryStream(data);
                            
                            value = formatter.Deserialize(stream);
                            return true;
                        }
                    }
                    else if (child.Name.Equals("InstanceDescriptor"))
                    {
                        value = ReadInstanceDescriptor(child);
                        return (value != null);
                    }
                    else if (child.Name.Equals("Reference"))
                    {
                        XmlAttribute memberAttr = child.Attributes["name"];
 
                        return FindComponent(memberAttr.Value, out value);
                    }
                    else
                    {
                        //MessageBox.Show(string.Format("Unexpected element type {0}", child.Name),"错误17");
                        value = null;
                        return false;
                    }
                }

                // If we get here, it is because there were no nodes.  No nodes and no inner
                // text is how we signify null.
                //
                value = null;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误18");
                value = null;
                return false;
            }
        }

        private bool GetConversionSupported(TypeConverter converter, Type type)
        {
            return (converter.CanConvertFrom(type) && converter.CanConvertTo(type));
            //throw new NotImplementedException();
        }

        #endregion
    }
}
