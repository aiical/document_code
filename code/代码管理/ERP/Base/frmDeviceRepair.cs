using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Base
{
    public partial class frmDeviceRepair : Common.frmBillList
    {
        public frmDeviceRepair()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 提取查询参数
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm3()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);

            return parm;
        }


        /// <summary>
        /// 新增
        /// </summary>
        protected override void New()
        {
            frmEditDeviceRepair myEditDeviceRepair = new frmEditDeviceRepair();
            myEditDeviceRepair.New();
            if (myEditDeviceRepair.ShowDialog() == DialogResult.OK)
                BindData();
            myEditDeviceRepair.Dispose();
            base.New();

        }

        /// <summary>
        /// 编辑　　
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;

            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditDeviceRepair myEditDeviceRepair = new frmEditDeviceRepair();
            myEditDeviceRepair.Edit(dr["Aid"].ToString());
            if (myEditDeviceRepair.ShowDialog() == DialogResult.OK)
                BindData();
            myEditDeviceRepair.Dispose();
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected override void Del()
        {
            if (gvList.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_DeviceRepair where Aid = '" + dr["Aid"].ToString() + "'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

            base.Del();
        }
    }
}
