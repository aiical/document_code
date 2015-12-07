using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmCardReport : Card.frmKQReport
    {
        public frmCardReport()
        {
            InitializeComponent();
        }

        protected override void DataBind(string strType)
        {
            base.DataBind(strType);
            string strSQL = @"select a.*,b.F_ID as F_EmpID,b.F_Name as F_EmpName,c.F_Name as F_Dept from t_RealCard a
                              left join t_Emp b
                              on a.F_CardNo = b.F_CardNo
                              left join t_Class c
                              on c.F_ID = b.F_Type
                              where a.F_Time >= '" +ucDate1.dtStart.ToString()+@"' 
                              and a.F_Time <= '" + ucDate1.dtEnd.ToString() + @"'
                              and (b.F_Type = '" + strType + "' or '"+strType+"' = '')";
                               
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridQuery.DataSource = ds.Tables[0];
        }
    }
}
