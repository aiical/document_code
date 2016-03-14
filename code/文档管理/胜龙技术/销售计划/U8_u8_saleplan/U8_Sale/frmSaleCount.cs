using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace U8_Sale
{
    public partial class frmSaleCount : UserControl
    {
        public frmSaleCount()
        {
            InitializeComponent();
            DataBind();
           
            gdView.OptionsBehavior.Editable = false;
        }
        # region 获得数据源

        private void DataBind()
        {
            lueDepName.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cDepCode,cDepName FROM Department")).Tables[0];
            luecDepCode.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cDepCode,cDepName FROM Department")).Tables[0];
            luecShopCode.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cDepCode AS cShopCode,cDepName FROM  Department")).Tables[0];
            string StrSQL = string.Format(@"select ca.*,sp.iYear,spm.cRefs1,spm.cRefs2,spm.nAmount,convert(decimal(18,2),isum/spm.nAmount)  AS fRate
FROM {0}..SL_P_SalePlan_Month spm LEFT JOIN {1}..SL_P_SalePlan sp ON spm.cSalePlanId = sp.cSalePlanId   LEFT JOIN  
(select h.cDepcode,h.iMonth,SUM(h.isum) AS isum
  from (SELECT ss.cDepcode,iYear,sm.iMonth,t.isum
  FROM {2}..SL_P_SalePlan ss LEFT JOIN {3}..SL_P_SalePlan_Month sm ON sm.cSalePlanId = ss.cSalePlanId LEFT JOIN 
  (SELECT d.cDepCode,d.dDate,isnull(sum(isnull(iSum,0)),0) AS isum FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  GROUP BY d.cDepCode,d.dDate) t
  ON LEFT(t.cDepCode,4) = ss.cDepCode WHERE MONTH(t.dDate)=sm.iMonth AND YEAR(t.dDate)=iYear) h  GROUP BY h.cDepcode,h.iMonth) ca 
   ON sp.cDepcode = ca.cDepcode WHERE ca.iMonth=spm.iMonth ORDER BY ca.iMonth asc", DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB);
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            gcList.DataSource = ds.Tables[0];

            
                gdList.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format(string.Format(@"select ca.*,sp.iYear,sps.cRefs1,sps.cRefs2,sps.nAmount,convert(decimal(18,2),isum/sps.nAmount)  AS fRate
FROM {0}..SL_P_SalePlan_Shop sps LEFT JOIN {1}..SL_P_SalePlan sp ON sps.cSalePlanId = sp.cSalePlanId   LEFT JOIN  
(select h.cDepcode,h.iMonth,SUM(h.isum) AS isum
  from (SELECT t.cDepcode,iYear,sm.iMonth,t.isum
  FROM {2}..SL_P_SalePlan ss LEFT JOIN {3}..SL_P_SalePlan_Shop sm ON sm.cSalePlanId = ss.cSalePlanId LEFT JOIN 
  (SELECT d.cDepCode,d.dDate,isnull(sum(isnull(iSum,0)),0) AS isum FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  GROUP BY d.cDepCode,d.dDate) t
  ON left(t.cDepCode,4) = ss.cDepCode WHERE MONTH(t.dDate)=sm.iMonth AND YEAR(t.dDate)=iYear) h  GROUP BY h.cDepcode,h.iMonth) ca 
   ON sps.cShopCode = ca.cDepcode WHERE ca.iMonth=sps.iMonth ORDER BY ca.iMonth,ca.cDepcode ASC", DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB))).Tables[0];
            

        }


        # endregion
    }
}
