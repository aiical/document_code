using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmKQRule : BaseClass.frmBase
    {
        public frmKQRule()
        {
            InitializeComponent();
            GridClass.AutoGenerateColumns = false;
            SetLinkEvent();
            BindData();
        }

        private void SetLinkEvent()
        {
            foreach (ToolStripItem tsItem in toolStrip.Items)
            {
                if (tsItem is ToolStripButton)
                {
                    (tsItem as ToolStripButton).Click += new EventHandler(ButtonClick);
                }
            }

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                switch ((sender as ToolStripButton).Text)
                {
                    case "增加":
                        New();
                        break;
                    case "保存":
                        Save();
                        break;
                    case "删除":
                        Del();
                        break;
                    case "刷新":
                        BindData();
                        break;
                    case "预览":
                        //PrintReport(0);
                        break;
                    case "打印":
                        //Print();
                        break;
                    case "引出":
                        //ExportData();
                        break;
                    case "关闭":
                        Close();
                        break;

                }
            }
        }

        private void New()
        {
            DataRow dr = ((DataRowView)binData.AddNew()).Row;

            dr["F_Day1"] = false;
            dr["F_Day2"] = false;
            dr["F_Day3"] = false;
            dr["F_Day4"] = false;
            dr["F_Day5"] = false;
            dr["F_Day6"] = false;
            dr["F_Day7"] = false;

            dr["F_Set1"] = false;
            dr["F_Set2"] = false;
            dr["F_Set3"] = false;

            dr["F_N2"] = 0;
            dr.EndEdit();
        }

        private void Save()
        {
            binData.EndEdit();

            if (txtID.Text == "")
            {
                MessageBox.Show(this, "规则编码不能为空!", "提示");
                txtID.Focus();
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show(this, "规则名称不能为空!", "提示");
                txtName.Focus();
                return;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(((DataTable)binData.DataSource).DataSet, "select * from t_KQRule") == 0)
            {
                MessageBox.Show(this, "数据保存成功!", "提示");
                BindData();
            }
        }

        private void Del()
        {
            if (GridClass.CurrentRow.Index < 0) return;
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataGridViewRow dr= GridClass.CurrentRow;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_KQRule where F_ID = '" + dr.Cells["F_ID"].Value.ToString() + "'") == 0)
                GridClass.Rows.Remove(GridClass.CurrentRow);
        }

        private void BindData()
        {
            string strSQL = "select * from t_KQRule";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0];
            GridClass.DataSource = binData;
            BindControl();
        }

        private void BindControl()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text",binData,"F_ID");
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text",binData,"F_Name");


            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", binData, "F1");
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("Text", binData, "F2");
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("Text", binData, "F3");
            textBox6.DataBindings.Clear();
            textBox6.DataBindings.Add("Text", binData, "F4");

            textBox7.DataBindings.Clear();
            textBox7.DataBindings.Add("Text", binData, "F5");
            textBox8.DataBindings.Clear();
            textBox8.DataBindings.Add("Text", binData, "F6");
            textBox9.DataBindings.Clear();
            textBox9.DataBindings.Add("Text", binData, "F7");
            textBox10.DataBindings.Clear();
            textBox10.DataBindings.Add("Text", binData, "F8");

            textBox11.DataBindings.Clear();
            textBox11.DataBindings.Add("Text", binData, "F9");
            textBox12.DataBindings.Clear();
            textBox12.DataBindings.Add("Text", binData, "F10");
            textBox13.DataBindings.Clear();
            textBox13.DataBindings.Add("Text", binData, "F11");

            checkBox5.DataBindings.Clear();
            checkBox5.DataBindings.Add("Checked", binData, "F_Day1");
            checkBox6.DataBindings.Clear();
            checkBox6.DataBindings.Add("Checked", binData, "F_Day2");
            checkBox7.DataBindings.Clear();
            checkBox7.DataBindings.Add("Checked", binData, "F_Day3");
            checkBox8.DataBindings.Clear();
            checkBox8.DataBindings.Add("Checked", binData, "F_Day4");
            checkBox9.DataBindings.Clear();
            checkBox9.DataBindings.Add("Checked", binData, "F_Day5");
            checkBox10.DataBindings.Clear();
            checkBox10.DataBindings.Add("Checked", binData, "F_Day7");
            checkBox11.DataBindings.Clear();
            checkBox11.DataBindings.Add("Checked", binData, "F_Day7");

            checkBox12.DataBindings.Clear();
            checkBox12.DataBindings.Add("Checked", binData, "F_Set1");
            checkBox13.DataBindings.Clear();
            checkBox13.DataBindings.Add("Checked", binData, "F_Set2");

            textBox14.DataBindings.Clear();
            textBox14.DataBindings.Add("Text", binData, "F_DaysInMonth");
            textBox15.DataBindings.Clear();
            textBox15.DataBindings.Add("Text", binData, "F_HoursInDay");


            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", binData, "F_N1");

            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("SelectedIndex", binData, "F_N2");

            checkBox1.DataBindings.Clear();
            checkBox1.DataBindings.Add("Checked", binData, "F_Set3");

        }
    }
}
