using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmCustomerQueryForm : Form
    {
        public frmCustomerQueryForm()
        {
            InitializeComponent();
        }

        private C1.Win.C1FlexGrid.C1FlexGrid _dgv;

        public C1.Win.C1FlexGrid.C1FlexGrid Dgv
        {
            get { return _dgv; }
            set { _dgv = value; }
        }

        public frmCustomerQueryForm(C1.Win.C1FlexGrid.C1FlexGrid dgvSouerce)
        {
            _dgv = dgvSouerce;            
            InitializeComponent();
        }

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        /// <summary>
        /// 查询条件
        /// </summary>
        private string GetRealtion
        {
            get
            {
                string relation = string.Empty;

                //开始日期
                if (dtpBeginDate.Checked)
                {
                    relation += string.Format("Convert(varchar(10),fdtmAddTime,23) >= '{0}'", dtpBeginDate.Value.ToString("yyyy-MM-dd"));
                }

                //结束日期
                if (dtpEndDate.Checked)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("Convert(varchar(10),fdtmAddTime,23) <= '{0}'", dtpEndDate.Value.ToString("yyyy-MM-dd"));
                }

                //客户编码
                if (!string.IsNullOrEmpty(txtCusCode.txtText.Trim()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrCusCode like '%{0}%'", txtCusCode.txtText.Trim());
                }

                //客户名称
                if (!string.IsNullOrEmpty(txtCusName.txtText.Trim()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrCusName like '%{0}%'", txtCusName.txtText.Trim());
                }

                //联系电话
                if (!string.IsNullOrEmpty(txtMobileNum.txtText.Trim()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrMobileNum like '%{0}%' or fchrPhoneNum like '%{0}%'", txtMobileNum.txtText.Trim());
                }

                //工作单位
                if (!string.IsNullOrEmpty(txtWorkPlace.txtText.Trim()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrWorkPlace like '%{0}%'", txtWorkPlace.txtText.Trim());
                }

                //是否上传RM
                if (cmbTransferRM.SelectedIndex == 1)  //是
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitExport,0) = 1", cmbTransferRM.SelectedItem.ToString());
                }
                else if (cmbTransferRM.SelectedIndex == 2)  //否
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitExport,0) = 0", cmbTransferRM.SelectedItem.ToString());
                }

                return relation;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            RetailCommom.DataRefresh(_dgv, GetRealtion);
            this.DialogResult = DialogResult.OK;
        }

        private void frmCustomerQueryForm_Load(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            dtpBeginDate.Value = time.AddDays(1 - time.Day);
            dtpBeginDate.Checked = true;
        }
    }
}
