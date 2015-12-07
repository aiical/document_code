using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Phone
{
    /// <summary>
    /// 精简版配置信息读写类
    /// </summary>
    public class Settings
    {
        private string settingsPath = string.Empty;//文件所在的路径
        public Settings()
        {
            settingsPath = AppDomain.CurrentDomain.BaseDirectory + "\\settings.xml";
            this.Load();
        }
        public Settings(string settingsFile)
        {
            settingsPath = settingsFile;
            this.Load();
        }

        private XmlDocument settingsXml = new XmlDocument();
        public void Load()
        {
            try
            {
                settingsXml.Load(settingsPath);
            }
            catch (System.Xml.XmlException)
            {
                settingsXml.AppendChild(settingsXml.CreateElement("settings"));
            }
        }
        public void Save()
        {
            settingsXml.Save(settingsPath);
        }
        public void SetValue(string name, string value)
        {
            XmlNode node = settingsXml.SelectSingleNode(string.Format("/settings/{0}", name));
            if (node == null)
            {
                node = settingsXml.CreateElement(name);
                settingsXml.DocumentElement.AppendChild(node);
            }
            node.InnerText = value;
            Save();
        }
        public string GetValue(string name, string defaultValue)
        {
            XmlNode node = settingsXml.SelectSingleNode(string.Format("/settings/{0}", name));
            if (node != null)
            {
                return node.InnerText;
            }
            return defaultValue;
        }
        public T GetValue<T>(string name, T defaultValue)
            where T : struct
        {
            XmlNode node = settingsXml.SelectSingleNode(string.Format("/settings/{0}", name));
            if (node != null)
            {
                return (T)Convert.ChangeType(node.InnerText, typeof(T),
                   System.Globalization.CultureInfo.InvariantCulture);
            }
            return defaultValue;
        }
        public Section this[string name]
        {
            get
            {
                return new Section(name, this);
            }
        }

        public string[] SectionValues(string name)
        {
            List<string> lst = new List<string>();
            XmlNode node = settingsXml.SelectSingleNode(string.Format("/settings/{0}", name));
            if (node != null)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    lst.Add(item.InnerText);
                }
            }
            return lst.ToArray();
        }

        public class Section
        {
            public Section(string section, Settings settings)
            {
                this.sectionName = section;
                this.settings = settings;
            }
            private Settings settings = null;
            private string sectionName = string.Empty;
            public string GetValue(string name, string defaultValue)
            {
                XmlNode node = settings.settingsXml.SelectSingleNode(string.Format("/settings/{0}/{1}", sectionName, name));
                if (node != null)
                {
                    return node.InnerText;
                }
                return string.Empty;
            }
            public T GetValue<T>(string name, T defaultValue)
                where T : struct
            {
                XmlNode node = settings.settingsXml.SelectSingleNode(string.Format("/settings/{0}/{1}", sectionName, name));
                if (node != null)
                {
                    return (T)Convert.ChangeType(node.InnerText, typeof(T),
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                return defaultValue;
            }
            public void SetValue(string name, string value)
            {
                XmlNode node = settings.settingsXml.SelectSingleNode(string.Format("/settings/{0}/{1}", sectionName, name));
                if (node == null)
                {
                    XmlNode section = settings.settingsXml.SelectSingleNode(string.Format("/settings/{0}", sectionName));
                    if (section == null)
                    {
                        section = settings.settingsXml.CreateElement(sectionName);
                        settings.settingsXml.DocumentElement.AppendChild(section);
                    }
                    node = settings.settingsXml.CreateElement(name);
                    section.AppendChild(node);
                }
                node.InnerText = value;
                settings.Save();
            }
        }

        private static Settings instance = null;
        public static Settings Instance
        {
            get
            {
                if (instance == null)
                    instance = new Settings();
                return instance;
            }
        }
    }
}

