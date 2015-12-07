using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmKQTotalReport : Card.frmKQReport
    {
        public frmKQTotalReport()
        {
            InitializeComponent();
        }

        protected override void DataBind(string strType)
        {
            base.DataBind(strType);
            string strSQL = @"select b.F_ID,b.F_Name,b.F_InDate,COUNT(*) as F_Days,
                               sum(isnull(DATEDIFF(HH,F_Begin1,F_End1),0) + isnull(DATEDIFF(HH,F_Begin2,F_End2),0) +
                               isnull(DATEDIFF(HH,F_Begin3,F_End3),0) + isnull(DATEDIFF(HH,F_Begin4,F_End4),0) +
                               isnull(DATEDIFF(HH,F_Begin5,F_End5),0)) as F_Hours
                                from t_CardRecord a
                                left join t_Emp b
                                on a.F_ID = b.F_ID
                                where a.F_Date >= '" +ucDate1.dtStart.ToString()+@"' 
                                and a.F_Date <= '" + ucDate1.dtEnd.ToString()+ @"'
                                and (b.F_Type = '" + strType + "' or '"+strType+@"' = '')
                                group by b.F_ID,b.F_Name,b.F_InDate";
                               
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridQuery.DataSource = ds.Tables[0];
        }
    }
}
