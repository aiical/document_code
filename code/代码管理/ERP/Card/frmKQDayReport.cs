using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmKQDayReport : Card.frmKQReport
    {
        public frmKQDayReport()
        {
            InitializeComponent();
        }

        protected override void DataBind(string strType)
        {
            base.DataBind(strType);
            string strSQL = @"select a.*,b.F_Name as F_EmpName,b.F_Duty,c.F_Name,c.F_zgs as F_ClassName,
                               datediff(hh,F_Begin1,F_End1) + datediff(hh,F_Begin2,F_End2) + datediff(hh,F_Begin3,F_End3) +
                               datediff(hh,F_Begin4,F_End4) +datediff(hh,F_Begin5,F_End5) as F_WorkHours,
                               datediff(MI,a.F_Begin1,c.F_sb1) + datediff(MI,a.F_Begin2,c.F_sb2) + datediff(MI,a.F_Begin3,c.F_sb3) +
                               + datediff(MI,a.F_Begin4,c.F_sb4) + + datediff(MI,a.F_Begin5,c.F_sb5) as F_Delay,
                                datediff(MI,a.F_End1,c.F_xb1) + datediff(MI,a.F_End2,c.F_xb2) + datediff(MI,a.F_End3,c.F_xb3) +
                               + datediff(MI,a.F_End4,c.F_xb4) + + datediff(MI,a.F_End5,c.F_xb5) as F_PreGo
                        from t_CardRecord a
                        left join t_Emp b
                        on a.F_ID = b.F_ID
                        left join t_SetClass c
                        on b.F_KQClass = c.F_ID
                        left join t_KQRule d
                        on b.F_KQRule = d.F_ID
                            where a.F_Date >= '" + ucDate1.dtStart.ToString() + @"' 
                            and a.F_Date <= '" + ucDate1.dtEnd.ToString() + @"'
                            and (b.F_Type = '" + strType + "' or '" + strType + "' = '')";
                               
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridQuery.DataSource = ds.Tables[0];
        }
    }
}
