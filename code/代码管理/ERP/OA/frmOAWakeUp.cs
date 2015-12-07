using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OA
{
    public partial class frmOAWakeUp : BaseClass.frmBase
    {
        public frmOAWakeUp()
        {
            InitializeComponent();
            DataBind();
        }

        private void DataBind()
        {
            string strSQL = @"select '任务' as F_Type,F_Title,F_ExeDate,F_PreFinishDate,F_Task from t_OATask
                                where CONVERT(varchar(10),F_ExeDate,120) = CONVERT(varchar(10),GETDATE(),120)
                                and F_EmpID = '"+DataLib.SysVar.strUID+@"'
                                union all
                                select '通知',a.F_Title,a.F_ExeDate,'1900-1-1',a.F_Memo from t_OANotice a
                                left join t_OANoticeEmp b
                                on a.Aid = b.Aid
                                where CONVERT(varchar(10),a.F_ExeDate,120) = CONVERT(varchar(10),GETDATE(),120)
                                and b.F_EmpID = '"+DataLib.SysVar.strUID+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcList.DataSource = ds.Tables[0];
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gvList.GetDataRow(e.FocusedRowHandle);
            meMess.Text = dr["F_Task"].ToString();
        }
    }
}
