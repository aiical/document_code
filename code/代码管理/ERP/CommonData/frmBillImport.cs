using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonData
{
    public partial class frmBillImport : BaseClass.frmBase
    {
        public DataTable dtMaster,dtSlaver;  //目标数据表
        private DataSet dsTmp = new DataSet(); //存放临时数据集
        private string strMasterSQL, strSlaverSQL;
        public string strBillType, strValue; //单据类别

        public frmBillImport()
        {
            InitializeComponent();
        }

        private void spClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DataLib.JxcService.SqlParameter[] GetParm()
        {
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Bill";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            DataRow dr = gvMaster.GetDataRow(gvMaster.FocusedRowHandle);
            parm[0].Value = dr["F_BillID"].ToString();

            return parm;
        }

        private DataLib.JxcService.SqlParameter[] GetParm2()
        {
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Start";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = ucDate.dtStart;

            parm[1].ParameterName = "@End";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = ucDate.dtEnd;

            return parm;
        }

        private DataLib.JxcService.SqlParameter[] GetParm3()
        {
            DataLib.JxcService.SqlParameter[] parm =
                    {      
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter(),
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Start";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = ucDate.dtStart;

            parm[1].ParameterName = "@End";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = ucDate.dtEnd;

            parm[2].ParameterName = "@Value";
            parm[2].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            parm[2].Value = strValue;

            return parm;
        }

        /// <summary>
        /// 提取相关单据
        /// </summary>
        /// <param name="strType"></param>
        public void GetBill(string strType)
        {
            this.strBillType = strType;
            string strSQL = "select * from t_BillImport where F_Type = '" + strType + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            dsTmp = myHelper.GetDs(strSQL);
            foreach (DataRow dr in dsTmp.Tables[0].Rows)
            {
                cbBill.Properties.Items.Add(dr["F_Class"].ToString());
            }
            if (dsTmp.Tables[0].Rows.Count > 0)
            {
                cbBill.SelectedIndex = 0;
                cbBill_SelectedIndexChanged(null, null);
            }
        }

        private void cbBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBill.Text.Length == 0) return;
            
            DataRow[] dr = dsTmp.Tables[0].Select("F_Class = '" + cbBill.Text + "'");
            if (dr.Length == 0) return;
            strMasterSQL = dr[0]["F_MasterSQL"].ToString();
            strSlaverSQL = dr[0]["F_SlaverSQL"].ToString();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (strMasterSQL.Length > 0)
            {
                DataSet dsMaster;
                if (strValue == "")
                    dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm2());
                else
                    dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm3());

                gcMaster.DataSource = dsMaster.Tables[0].DefaultView;
            }
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            cbBill_SelectedIndexChanged(null, null);
        }

        private void gvMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            RefreshSlaver();
        }

        /// <summary>
        /// 刷新相关单据
        /// </summary>
        private void RefreshSlaver()
        {
            if (strSlaverSQL.Length > 0)
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet dsSlaver = myHelper.GetOtherDs(strSlaverSQL, GetParm());
                gcSlaver.DataSource = dsSlaver.Tables[0].DefaultView;
            }
        }

        private void frmBillImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.F11)
            {
                frmSetField mySetField = new frmSetField();
                mySetField.dtSource = ((DataView)gcMaster.DataSource).Table;
                mySetField.dtSource1 = ((DataView)gcSlaver.DataSource).Table;
                mySetField.dtDes = dtMaster;
                mySetField.dtDes1 = dtSlaver;
                mySetField.strType = strBillType;
                mySetField.strClass = cbBill.Text;
                mySetField.ShowDialog();
                mySetField.Dispose();
            }

            if (e.KeyCode == Keys.F7)
            {
                //frmSetGrid myGrid = new frmSetGrid();
                //myGrid.gvSource = gvBase;
                //myGrid.ShowDialog();
                //myGrid.Dispose();
            }
        }

        /// <summary>
        /// 导入到单据 
        /// </summary>
        private void ImportBill()
        {
            string strTmp = "", strLeft, strRight;
            int intPos;
            string strSQL = "select F_MasterField,F_SlaverField from t_BillImport where F_Type = '"+strBillType+"' and F_Class = '"+cbBill.Text+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0) return;
            string strDes = ds.Tables[0].Rows[0]["F_MasterField"].ToString();
            string strDes1 = ds.Tables[0].Rows[0]["F_SlaverField"].ToString();
            string[] strMaster = strDes.Split(',');
            string[] strSlaver = strDes1.Split(',');
            for (int i = 0; i < strMaster.Length - 1; i++)
            {
                 strTmp = strMaster[i];
                 intPos = strTmp.IndexOf("->");
                 strLeft = strTmp.Substring(0, intPos);
                 strRight = strTmp.Substring(intPos+2);
                 
                 DataRow drSource = gvMaster.GetDataRow(gvMaster.FocusedRowHandle);
                 DataRow drDes = dtMaster.Rows[0];
                 drDes[strRight] = drSource[strLeft];
            }

            if (gvSlaver.RowCount > 0)
            {
                for (int j = 0; j < gvSlaver.RowCount; j++)
                {
                    DataRow drDes = dtSlaver.NewRow();
                    for (int i = 0; i < strSlaver.Length - 1; i++)
                    {
                        strTmp = strSlaver[i];
                        intPos = strTmp.IndexOf("->");
                        strLeft = strTmp.Substring(0, intPos);
                        strRight = strTmp.Substring(intPos + 2);
                        DataRow drSource = gvSlaver.GetDataRow(j);
                        drDes[strRight] = drSource[strLeft];
                    }
                    dtSlaver.Rows.Add(drDes);
                }
            }
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            ImportBill();
        }
    }
}

