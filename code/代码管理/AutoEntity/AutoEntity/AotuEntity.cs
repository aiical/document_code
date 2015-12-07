using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace AutoEntity
{
    public partial class AutoEntity : Form
    {
        public AutoEntity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        { 
            try
            {
                using (SqlConnection conn = new SqlConnection("server=.;database=master;uid=sa;pwd=" + this.txtpwd.Text.Trim()))
                {
                    string sql = "select * from sysdatabases where name !='master' and name!='tempdb' and name!='model' and name!='msdb'";
                        conn.Open();
                        this.txtpwd.Enabled = false;
                       
                    using (SqlDataAdapter sdr = new SqlDataAdapter(sql, conn))
                    {
                        this.cboDB.Enabled = true;
                        DataSet ds = new DataSet();
                        sdr.Fill(ds);
                        this.cboDB.DataSource = ds.Tables[0];
                        this.cboDB.DisplayMember = "name";
                        this.cboDB.ValueMember = "name";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("输入的密码有误");
            }
        }

    
        /// <summary>
        /// 下框的变换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string dbname = cboDB.SelectedValue.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection("server=.;database=" + dbname + ";uid=sa;pwd=" + this.txtpwd.Text.Trim()))
                {
                    conn.Open();
                    DataTable schema = conn.GetSchema("TABLES");
                    this.cbotable.Enabled = true;
                    this.cbotable.DataSource = schema;
                    this.cbotable.ValueMember = "TABLE_NAME";
                    this.cbotable.DisplayMember = "TABLE_NAME";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 选择表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbotable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtNameSpace.Text.Trim()=="")
            {
                MessageBox.Show("请填写命名空间名字\n");
                this.txtNameSpace.Text = "Model";
            }

            string space = this.txtNameSpace.Text.Trim();

            
            string tablename= this.cbotable.SelectedValue.ToString();
            this.btnentity.Tag = tablename;

            StringBuilder sb = new StringBuilder();

            string dbname = cboDB.SelectedValue.ToString();
          
                using (SqlConnection conn = new SqlConnection("server=.;database=" + dbname + ";uid=sa;pwd=" + this.txtpwd.Text.Trim()))
                {
                    try
                    {

                        conn.Open();
                        //定义一个SQL语句查询所有的表
                        string sql = "select * from [" + tablename + "]";

                        //获得所有的执行对像
                        SqlCommand comm = new SqlCommand(sql, conn);

                        //将对像转换成数据库对像
                        SqlDataAdapter sda = new SqlDataAdapter(comm);

                        //获得一个数据集
                        DataSet ds = new DataSet();
                        //填充数据
                        sda.FillSchema(ds, SchemaType.Mapped);

                        //创建一系统定义的类型
                        sb.Append("using System;" + Environment.NewLine + "using System.Collections.Generic;" + Environment.NewLine + "using System.Text;" + Environment.NewLine + Environment.NewLine + "namespace " + this.ChangeName(space) + "{" + Environment.NewLine + Environment.NewLine);

                        //创建类型
                        sb.Append("\tpublic class " + ChangeName(tablename) + "{" + Environment.NewLine);

                        //创建一个无参的构造函数
                        sb.Append("\t\t///<summary>" + Environment.NewLine + "\t\t/// 无参构造器" + Environment.NewLine + "\t\t/// </summary>" + Environment.NewLine + "\t\tpublic " + ChangeName(tablename) + "() { }" + Environment.NewLine + Environment.NewLine);

                        foreach (DataColumn dc in ds.Tables[0].Columns)
                        {
                            sb.Append("\t\tprivate  " + ChangeNameType(dc.DataType.Name) + " _" + dc.ColumnName + ";" + Environment.NewLine + Environment.NewLine);
                            sb.Append("\t\tpublic " + ChangeNameType(dc.DataType.Name) + " " + ChangeName(dc.ColumnName) + "{" + Environment.NewLine +
                            "\t\t\tget{return _" + dc.ColumnName + ";}" + Environment.NewLine + "\t\t\tset{ _" + dc.ColumnName + "=value;}" + Environment.NewLine + "\t\t}" + Environment.NewLine);
                        }
                        sb.Append("\t}" + Environment.NewLine + "}");

                        txtEntity.Text = sb.ToString();
                        this.btnentity.Enabled = true;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("请选择正确的文件");
                    }
                   
                }
          
        }


        /// <summary>
        /// 转换名字格式
        /// </summary>
        /// <param name="tablename">传入进来名字</param>
        /// <returns>新名字</returns>
        public string ChangeName(string info) 
        {
            return info.Substring(0, 1).ToUpper() + info.Substring(1);
        }

        /// <summary>
        /// 获得数据类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ChangeNameType(string type) 
        {
            string dinfo = "";
            switch (type.ToLower())
            {
                 case "text":
                    dinfo = "string";
                    break;
                case "int32":
                    dinfo = "int";
                    break;
                case "bigint":
                    dinfo = "Int64";
                    break;
                case "binary":
                    dinfo = "System.Byte[]";
                    break;
                case "bit":
                    dinfo = "Boolean";
                    break;
                case "char":
                    dinfo = "string";
                    break;
                case "datetime":
                    dinfo = "DateTime";
                    break;
                case "decimal":
                    dinfo = "System.Decimal";
                    break;
                case "float":
                    dinfo = "System.Double";
                    break;
                case "image":
                    dinfo = "System.Byte[]";
                    break;
                case "money":
                    dinfo = "System.Decimal";
                    break;
                case "nchar":
                    dinfo = "string";
                    break;
                case "ntext":
                    dinfo = "string";
                    break;
                case "numeric":
                    dinfo = "System.Decimal";
                    break;
                case "nvarchar":
                    dinfo = "string";
                    break;
                case "real":
                    dinfo = "System.Single";
                    break;
                case "smalldatetime":
                    dinfo = "System.DateTime";
                    break;
                case "smallint":
                    dinfo = "Int16";
                    break;
                case "smallmoney":
                    dinfo = "System.Decimal";
                    break;
                case "timestamp":
                    dinfo = "System.DateTime";
                    break;
                case "tinyint":
                    dinfo = "System.Byte";
                    break;
                case "uniqueidentifier":
                    dinfo = "System.Guid";
                    break;
                case "varbinary":
                    dinfo = "System.Byte[]";
                    break;
                case "varchar":
                    dinfo = "string";
                    break;
                case "Variant":
                    dinfo = "Object";
                    break;
                default:
                    dinfo = "string";
                    break;
            }
            return dinfo;
            }


        /// <summary>
        /// 生成实体类按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnentity_Click(object sender, EventArgs e)
        {
            this.saveFile.Title = "保存实体信息";
            this.saveFile.FileName =ChangeName(this.btnentity.Tag.ToString());
            if (this.saveFile.ShowDialog() == DialogResult.OK)
            {
                string name= this.saveFile.FileName;
                File.WriteAllText(name, this.txtEntity.Text.Trim());
            } 
        }


        private string d;

        public string D
        {
            get { return d; }
            set { d = value; }
        }
    }    
}

