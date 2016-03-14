using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmPrintType : Form {
        private int printId = -1;
        private string connStr = string.Empty;
        private string cUserId = string.Empty;
        private string cType = string.Empty;
        public int PrintID {
            get { return printId; }
        }
        public frmPrintType(string _connStr, string _cUserId, string _cType) {
            InitializeComponent();
            this.connStr = _connStr;
            this.cUserId = _cUserId;
            this.cType = _cType;
        }

        private void frmPrintType_Load(object sender, EventArgs e) {

            SqlConnection con = new SqlConnection(connStr);
            try {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();
                cmd.CommandText = string.Format("select * from sl_PrintTemplate");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                    da.Fill(ds);
                }
                comboBox1.SelectedValueChanged -= new EventHandler(comboBox1_SelectedValueChanged);

                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "AutoID";
                comboBox1.SelectedIndex = 0;
                cmd.CommandText = string.Format("select printID from sl_PrintRight where cUserId='{0}' and isnull(cVouchType,'')='{1}'", cUserId, cType);
                cmd.CommandType = CommandType.Text;

                string rel = string.Empty;
                object obj = cmd.ExecuteScalar();
                if (obj != null && !string.IsNullOrEmpty(Convert.ToString(obj))) {
                    comboBox1.SelectedValue = obj;
                    comboBox1_SelectedValueChanged(null, null);
                } else {
                    rel = string.Format("Name='{0}'", comboBox1.Text);
                    DataRow[] arr = ds.Tables[0].Select(rel);
                    this.comboBox2.SelectedIndex = Convert.ToInt32(arr[0]["FontBold"]);
                    this.txtBottomMargin.Text = Convert.ToString(arr[0]["BottomMargin"]);
                    this.txtLeftMargin.Text = Convert.ToString(arr[0]["LeftMargin"]);
                    this.txtPageHeight.Text = Convert.ToString(arr[0]["PageHeight"]);
                    this.txtPageSize.Text = Convert.ToString(arr[0]["PageSize"]);
                    this.txtPageWidth.Text = Convert.ToString(arr[0]["PageWidth"]);
                    this.txtRightMargin.Text = Convert.ToString(arr[0]["RightMargin"]);
                    this.txtRowHeight.Text = Convert.ToString(arr[0]["RowHeight"]);
                    this.txtTopMargin.Text = Convert.ToString(arr[0]["TopMargin"]);
                }


                comboBox1.SelectedValueChanged += new EventHandler(comboBox1_SelectedValueChanged);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                con.Close();
                con = null;
            }


        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtBottomMargin.Text)) return;
            if (string.IsNullOrEmpty(this.txtLeftMargin.Text)) return;
            if (string.IsNullOrEmpty(this.txtPageHeight.Text)) return;
            if (string.IsNullOrEmpty(this.txtPageSize.Text)) return;
            if (string.IsNullOrEmpty(this.txtPageWidth.Text)) return;
            if (string.IsNullOrEmpty(this.txtRightMargin.Text)) return;
            if (string.IsNullOrEmpty(this.txtRowHeight.Text)) return;
            if (string.IsNullOrEmpty(this.txtTopMargin.Text)) return;
            printId = Convert.ToInt32(comboBox1.SelectedValue);
            SqlConnection con = new SqlConnection(connStr);
            try {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string selCmd = string.Format("if not exists (select 1 from sl_PrintRight where cUserId='{0}' and cVouchType='{1}') begin"
                       + " insert into sl_PrintRight(printID,cUserId,InteractiveHeight,InteractiveWidth,PageWidth,PageHeight,TopMargin,BottomMargin,LeftMargin,RightMargin,PageSize,Name,RowHeight,FontBold,cVouchType) values({2},'{0}',{3},{4},{3},{4},{5},{6},{7},{8},{9},'{10}',{11},{12},'{1}') \r\n end"
                      , cUserId, cType, printId, txtPageWidth.Text, txtPageHeight.Text, txtTopMargin.Text, txtBottomMargin.Text
                      , txtLeftMargin.Text, txtRightMargin.Text, txtPageSize.Text, comboBox1.Text, txtRowHeight.Text, comboBox2.SelectedIndex);

                selCmd += string.Format(" else begin"
                      + "\r\n update sl_PrintRight set printID={0}"
                      + ",InteractiveHeight={1},InteractiveWidth={2},PageWidth={1},PageHeight={2},TopMargin={3}"
                      + ",BottomMargin={4},LeftMargin={5},RightMargin={6},PageSize={7},Name='{8}',RowHeight={9},FontBold={10} where cUserId='{11}' and cVouchType='{12}' \r\n end"
                      , printId, txtPageWidth.Text, txtPageHeight.Text, txtTopMargin.Text, txtBottomMargin.Text
                      , txtLeftMargin.Text, txtRightMargin.Text, txtPageSize.Text, comboBox1.Text, txtRowHeight.Text, comboBox2.SelectedIndex, cUserId, cType);
                cmd.CommandText = selCmd;
                cmd.ExecuteNonQuery();
                string rootPath = System.Windows.Forms.Application.StartupPath + @"\EAI\SL\" + printId + "\\" + cUserId;
                //string rdlcPath = rootPath + "\\rpgroupRemark" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
                //rdlcPath = rootPath + "\\rpgroupRemarkFontBold" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
                //rdlcPath = rootPath + "\\rprpTranVouch" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
                //rdlcPath = rootPath + "\\rprpTranVouchFontBold" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
                //rdlcPath = rootPath + "\\rpTemplateInv" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
                //rdlcPath = rootPath + "\\rpTemplateInvFontBold" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
                //rdlcPath = rootPath + "\\rpTemplate" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
                //rdlcPath = rootPath + "\\rpTemplateFontBold" + cType + ".rdlc";
                //if (System.IO.File.Exists(rdlcPath)) {
                //    System.IO.File.Delete(rdlcPath);
                //}
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                con.Close();
                con = null;
            }
            DialogResult = DialogResult.OK;

        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(connStr);
            try {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = string.Format("  if exists( select 1 from sl_PrintRight where printID={0} and cUserId='{1}' and cVouchType='{2}') select * from sl_PrintRight where printID={0} and cUserId='{1}' and cVouchType='{2}'  else  select * from sl_PrintTemplate where AutoID={0} ", comboBox1.SelectedValue, cUserId, cType);
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {

                        this.comboBox2.SelectedIndex = Convert.ToInt32(reader["FontBold"]);
                        this.txtBottomMargin.Text = Convert.ToString(reader["BottomMargin"]);
                        this.txtLeftMargin.Text = Convert.ToString(reader["LeftMargin"]);
                        this.txtPageHeight.Text = Convert.ToString(reader["PageHeight"]);
                        this.txtPageSize.Text = Convert.ToString(reader["PageSize"]);
                        this.txtPageWidth.Text = Convert.ToString(reader["PageWidth"]);
                        this.txtRightMargin.Text = Convert.ToString(reader["RightMargin"]);
                        this.txtRowHeight.Text = Convert.ToString(reader["RowHeight"]);
                        this.txtTopMargin.Text = Convert.ToString(reader["TopMargin"]);
                    }
                }
                cmd.Dispose();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                con.Close();
                con = null;
            }
        }


        private void txtPageHeight_KeyPress(object sender, KeyPressEventArgs e) {

            if ((e.KeyChar < '0' && e.KeyChar != '.' && e.KeyChar != '-' || e.KeyChar > '9' && e.KeyChar != '.' && e.KeyChar != '-'
                || ((TextBox)(sender)).Text.IndexOf('.') >= 0 && e.KeyChar == '.')
                && e.KeyChar != (char)13 && e.KeyChar != (char)8
                ) {

                e.Handled = true;

            }
        }


    }
}
