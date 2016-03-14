using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using System.Net.NetworkInformation;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class FrmNoSalesSubmit : Form
    {
        public FrmNoSalesSubmit()
        {
            InitializeComponent();
        }

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        private void FrmNoSalesSubmit_Load(object sender, EventArgs e)
        {
            txtNoSaleDate.ControlValue = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要提交所选定的0销售日期吗？提交后将无法进行修改！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
                object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                {
                    return;
                }

                selCmd = "select top 1 fchrStoreDefineID from storedefine";
                string fchrStoreDefineID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd).ToString();
                DataTable NewTab = new DataTable();

                if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                {
                    MessageBox.Show("RMWebServiceURL不存在,请先日常下载!", "系统提示");
                    return;
                }
                string url = Convert.ToString(objSelStr);
                object obj = null;
                string Err = "";
                try
                {
                    NewTab = CreateNewTmpTable(fchrStoreDefineID);
                    object[] args = { fchrStoreDefineID, Convert.ToDateTime(this.txtNoSaleDate.ControlValue).ToString("yyyy-MM-dd"), NewTab, Err };
                    Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "TransmitNoSalesDateToRM", args);
                    if (string.IsNullOrEmpty(Err))
                    {
                        MessageBox.Show("0销售数据上传成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("0销售数据上传出现异常：" + Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmService'";
                    objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                    if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                    {
                        return;
                    }

                    selCmd = "select top 1 fchrStoreDefineID from storedefine";
                    fchrStoreDefineID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd).ToString();
                    NewTab = new DataTable();

                    if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                    {
                        MessageBox.Show("RMWebServiceURL不存在,请先日常下载!", "系统提示");
                        return;
                    }
                    url = Convert.ToString(objSelStr);

                    try
                    {
                        NewTab = CreateNewTmpTable(fchrStoreDefineID);
                        object[] args = { fchrStoreDefineID, Convert.ToDateTime(this.txtNoSaleDate.ControlValue).ToString("yyyy-MM-dd"), NewTab, Err };
                        Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "TransmitNoSalesDateToRM", args);
                        if (string.IsNullOrEmpty(Err))
                        {
                            MessageBox.Show("0销售数据上传成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("0销售数据上传出现异常：" + Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("远程服务器无法连接,请检查网络!", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
                return;
        }

        /// <summary>
        /// 创建新临时表
        /// </summary>
        /// <param name="fchrStoreDefineID"></param>
        private DataTable CreateNewTmpTable(string fchrStoreDefineID)
        {
            DataTable dt = new DataTable("abaTable");
            DataRow dr = null;

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("fchrStoreDefineid", typeof(string));
            dt.Columns.Add("fdtmNoSalesDate", typeof(string));
            dt.Columns.Add("cOperator", typeof(string));
            dt.Columns.Add("fdtmUploadDateTime", typeof(string));

            dr = dt.NewRow();
            dr["id"] = Guid.NewGuid().ToString();
            dr["fchrStoreDefineid"] = fchrStoreDefineID;
            dr["fdtmNoSalesDate"] = Convert.ToDateTime(this.txtNoSaleDate.ControlValue).ToString("yyyy-MM-dd");
            dr["cOperator"] = SysPara.GetSysPara("操作员名称").ToString();
            dr["fdtmUploadDateTime"] = DateTime.Now.ToString();
            dt.Rows.Add(dr);
            dt.AcceptChanges();
            return dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
