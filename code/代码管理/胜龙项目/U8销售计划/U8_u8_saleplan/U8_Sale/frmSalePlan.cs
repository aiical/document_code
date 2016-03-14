using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace U8_Sale
{
    public partial class frmSalePlan : UserControl
    {
        public frmSalePlan()
        {
            InitializeComponent();
            DataBind();
            string StrSQL = "select  SD.cDepCode,D.cDepName FROM SL_P_DeptRef SD LEFT JOIN Department D ON SD.cDepCode=D.cDepCode";
            DataSet dschem = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            //lueDepartment.Properties.DataSource = dschem.Tables[0];
            gdView.OptionsBehavior.Editable = false;

        }

        # region 获得数据源

        private void DataBind()
        {

            string StrSQL = @"SELECT s1.cSalePlanId,s.cDepCode,s1.cMemo,s1.cRefs1 AS cRefs11 ,s1.cRefs2 AS cRefs21,s1.nAmount AS nAmount1 ,s2.cRefs1 AS cRefs12,s2.cRefs2 AS cRefs22,s2.nAmount nAmount2,s3.cRefs1 AS cRefs13,s3.cRefs2 AS cRefs23,s3.nAmount AS nAmount3,s4.cRefs1 AS cRefs14,s4.cRefs2 AS cRefs24,s4.nAmount AS nAmount4,s5.cRefs1 AS cRefs15,s5.cRefs2 AS cRefs25,s5.nAmount AS nAmount5,s6.cRefs1 AS cRefs16,s6.cRefs2 AS cRefs26,s6.nAmount AS nAmount6,s7.cRefs1 AS cRefs17,s7.cRefs2 cRefs27,s7.nAmount AS nAmount7,s8.cRefs1 AS cRefs18,s8.cRefs2 AS cRefs28,s8.nAmount AS nAmount8,s9.cRefs1 AS cRefs19,s9.cRefs2 AS cRefs29,s9.nAmount AS nAmount9,s10.cRefs1 AS cRefs110,s10.cRefs2 AS cRefs210,s10.nAmount AS nAmount10,s11.cRefs1 AS cRefs111,s11.cRefs2 AS cRefs211,s11.nAmount AS nAmount11,s12.cRefs1 AS cRefs112,s12.cRefs2 AS cRefs212,s12.nAmount AS nAmount12 FROM SL_P_SalePlan s LEFT JOIN  (SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='1') s1 ON s1.cSalePlanId = s.cSalePlanId LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='2') s2
ON s2.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='3') s3
ON s3.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='4') s4
ON s4.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='5') s5
ON s5.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='6') s6
ON s6.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='7') s7
ON s7.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='8') s8
ON s8.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='9') s9
ON s9.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='10') s10
ON s10.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='11') s11
ON s11.cSalePlanId = s.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Month WHERE iMonth='12') s12
ON s12.cSalePlanId = s.cSalePlanId";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            gdList.DataSource = ds.Tables[0];


        }


        # endregion



        private void tsbModify_Click(object sender, EventArgs e)
        {
            if (gdView.FocusedRowHandle < 0) return;
            DataRow dr = gdView.GetDataRow(gdView.FocusedRowHandle);
            frmSale_Plans frm = new frmSale_Plans();
            frm.SalePlanId = gdView.GetRowCellValue(gdView.FocusedRowHandle, "cSalePlanId").ToString();
            frm.bFlag = false;
            frm.ShowDialog();
            frm.Dispose();
            DataBind();
        }



        private void tsbNewVoucher_Click(object sender, EventArgs e)
        {

            frmSale_Plans frm = new frmSale_Plans();
            frm.bFlag = true;
            frm.ShowDialog();
            frm.Dispose();
            DataBind();

        }
    }
}
