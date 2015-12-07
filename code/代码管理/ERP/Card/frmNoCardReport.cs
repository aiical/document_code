using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmNoCardReport : Card.frmKQReport
    {
        public frmNoCardReport()
        {
            InitializeComponent();
        }

        protected override void DataBind(string strType)
        {
            base.DataBind(strType);
            string strSQL = @"select a.*,b.F_Name as F_DeptName,c.F_Name as F_GroupName from t_Emp a
                                left join t_Class b
                                on a.F_Type = b.F_ID 
                                left join t_WorkGroup c
                                on a.F_Group = c.F_ID
                                where (a.F_Type = '" + strType + "' or '" + strType + @"' = '')
                                and a.F_ID
                                not in(
                                select F_ID from t_CardRecord
                                where F_Date >= '" + ucDate1.dtStart.ToString() + @"'
                                and F_Date <= '" + ucDate1.dtEnd.ToString() + "')";

                               
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridQuery.DataSource = ds.Tables[0];
        }
    }
}
