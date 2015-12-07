using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace Common
{
    public partial class frmBillImport : BaseClass.frmBase
    {
        public DataTable dtMaster,dtSlaver;  //目标数据表
        private DataSet dsTmp = new DataSet(); //存放临时数据集
        private string strMasterSQL, strSlaverSQL;
        public string strBillType, strValue; //单据类别
        private string _BillTag = "";
        public bool blnFlag = false; //从表参数标志
        public int iIndex = 0; //单据类型

        public frmBillImport()
        {
            InitializeComponent();
        }

        private void spClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// 单据标志
        /// </summary>
        protected string BillTag
        {
            get
            {
                if (_BillTag == "")
                    _BillTag = strBillType + cbBill.Text;
                return _BillTag;
            }
            set
            {
                _BillTag = value;
            }
        }

        /// <summary>
        /// 取单号参数
        /// </summary>
        /// <returns></returns>
        private Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            if (gvMaster.FocusedRowHandle < 0)
                parm.Add("@Bill", "");
            else
            {
                DataRow dr = gvMaster.GetDataRow(gvMaster.FocusedRowHandle);
                parm.Add("@Bill", dr["F_BillID"].ToString());
            }
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Bill";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            if (gvMaster.FocusedRowHandle < 0)
            {
                parm[0].Value = "";
            }
            else
            {
                DataRow dr = gvMaster.GetDataRow(gvMaster.FocusedRowHandle);
                parm[0].Value = dr["F_BillID"].ToString();
            }
            */
            return parm;
        }

        /// <summary>
        /// 取单号参数1
        /// </summary>
        /// <returns></returns>
        private Hashtable GetParmOther()
        {
            Hashtable parm = new Hashtable();
            if (gvMaster.FocusedRowHandle < 0)
            {
                parm.Add("@Bill", "");
                parm.Add("@Value", "");
            }
            else
            {
                DataRow dr = gvMaster.GetDataRow(gvMaster.FocusedRowHandle);
                parm.Add("@Bill", dr["F_BillID"].ToString());
                parm.Add("@Value", strValue);
            }

            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                        new   DataLib.JxcService.SqlParameter(),
                        new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Bill";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            if (gvMaster.FocusedRowHandle < 0)
            {
                parm[0].Value = "";
            }
            else
            {
                DataRow dr = gvMaster.GetDataRow(gvMaster.FocusedRowHandle);
                parm[0].Value = dr["F_BillID"].ToString();
            }

            parm[1].ParameterName = "@Value";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            parm[1].Value = strValue;
             */ 
            return parm;
        }


        private Hashtable GetParm2()
        {

            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            
            /*
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
            */
            return parm;
        }

        private Hashtable GetParm3()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Value", strValue);
            return parm;
        }

        /// <summary>
        /// 提取相关单据
        /// </summary>
        /// <param name="strType"></param>
        public void GetBill(string strType)
        {
            this.strBillType = strType;
            string strSQL = "select * from t_BillImport where F_Type = '" + strType + "' and isnull(F_Stop,0) = 0 Order by F_Order";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            dsTmp = myHelper.GetDs(strSQL);
            foreach (DataRow dr in dsTmp.Tables[0].Rows)
            {
                cbBill.Properties.Items.Add(dr["F_Class"].ToString());
            }
            if (dsTmp.Tables[0].Rows.Count > 0)
            {
                cbBill.SelectedIndex = iIndex;
                cbBill_SelectedIndexChanged(null, null);
            }
        }

        private void cbBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBill.Text.Length == 0) return;
            BillTag = strBillType + cbBill.Text;
            DataRow[] dr = dsTmp.Tables[0].Select("F_Class = '" + cbBill.Text + "'");
            if (dr.Length == 0) return;
            strMasterSQL = dr[0]["F_MasterSQL"].ToString();
            strSlaverSQL = dr[0]["F_SlaverSQL"].ToString();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (strMasterSQL.Length > 0)
            {
                DataSet dsMaster;
                if (strValue != "")
                {
                    dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm3());
                }
                else
                {
                    if (blnFlag == true)
                        dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm2());
                    else
                        dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm3());
                }

                //if ( blnFlag == false)
                //    dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm2());
                //else
                //{
                //    if (blnFlag == true)
                //        dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm2());
                //    else
                //        dsMaster = myHelper.GetOtherDs(strMasterSQL, GetParm3());
                //}

                gvMaster.Columns.Clear();

                gcMaster.DataSource = dsMaster.Tables[0].DefaultView;

                //if (dsMaster.Tables[0].Rows.Count > 0)
                //{
                    RefreshSlaver();
                //}

                DataLib.sysClass.LoadFormatFromDB(gvMaster, BillTag, 0);
                DataLib.sysClass.LoadFormatFromDB(gvSlaver, BillTag, 1);

                DataTable dtSlaver = ((DataView)gcSlaver.DataSource).Table;
                if (dtSlaver.Columns.Contains("F_Select") == true)
                {
                    gvSlaver.Columns["F_Select"].OptionsColumn.AllowFocus = true;
                    gvSlaver.Columns["F_Select"].OptionsColumn.AllowEdit = true;
                }
                
                //AssignField();
                //AssignField1();
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
                DataSet dsSlaver;
                if (blnFlag == false)
                   dsSlaver = myHelper.GetOtherDs(strSlaverSQL, GetParm());
                else
                   dsSlaver = myHelper.GetOtherDs(strSlaverSQL, GetParmOther());

                gvSlaver.Columns.Clear();
                gcSlaver.DataSource = dsSlaver.Tables[0].DefaultView;
                DataLib.sysClass.LoadFormatFromDB(gvSlaver, BillTag, 1);
              
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
                frmSetGrid myGrid = new frmSetGrid();
                if (gcMaster.Focused == true)
                    myGrid.gvSource = gvMaster;
                else
                    myGrid.gvSource = gvSlaver;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5)
            {
                DataLib.sysClass.SaveGridToDB(gvMaster, BillTag, 0);
                DataLib.sysClass.SaveGridToDB(gvSlaver, BillTag, 1);
                //SaveFieldFormat();
                //SaveFieldFormat1();
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
            if (strMaster.Length > 0)
            {
                for (int i = 0; i < strMaster.Length - 1; i++)
                {
                    strTmp = strMaster[i];
                    intPos = strTmp.IndexOf("->");
                    strLeft = strTmp.Substring(0, intPos);
                    strRight = strTmp.Substring(intPos + 2);

                    DataRow drSource = gvMaster.GetDataRow(gvMaster.FocusedRowHandle);
                    DataRow drDes = dtMaster.Rows[0];
                    drDes[strRight] = drSource[strLeft];
                }
            }

            if (ckAddImport.Checked == false) dtSlaver.Rows.Clear();
            if (gvSlaver.RowCount > 0)
            {
                for (int j = 0; j < gvSlaver.RowCount; j++)
                {
                    if (Convert.ToBoolean(gvSlaver.GetRowCellValue(j, "F_Select")) == false) continue;
                    DataRow drSlaver = gvSlaver.GetDataRow(j);
                    DataRow[] drTmp = dtSlaver.Select("F_LinkBill = '" + drSlaver["F_BillID"].ToString() + "' and PAid = " + drSlaver["Aid"].ToString());
                    if (drTmp.Length > 0) continue;
                    DataRow drDes = dtSlaver.NewRow();
                    //drDes["AID"] = j + 1;
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
            if (gvMaster.FocusedRowHandle >= 0) 
               ImportBill();
           Close();
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            int intCnt = gvSlaver.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                gvSlaver.SetRowCellValue(i, "F_Select", ckAll.Checked);
            }
        }
    }
}

