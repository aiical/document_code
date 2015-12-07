using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmDialog : BaseClass.frmBase
    {
        protected string strSaveSlaverSQL;
        protected bool blnNew = false;  //�Ƿ񱣴������
        protected bool blnBind = false; //���ݰ󶨱�־
        protected string strNoCopyField;  //�����Ƶ��ֶ�
        protected bool blnIsNew = false; //�Ƿ�������־

        public frmDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ȡ������ϱ��
        /// </summary>
        /// <param name="strTag"></param>
        /// <returns></returns>
        protected string GetMaxCode(string strTag,string strTable)
        {
            DataLib.sysClass myClass = new DataLib.sysClass();
            return myClass.GetMaxCode(strTag, "F_ID", strTable);
        }

        /// <summary>
        /// ����ǰһ��¼
        /// </summary>
        protected virtual void CopyRecord()
        {
            DataRow DrSource = ((DataRowView)binData.Current).Row;
            New();
            DataRow DrDes = ((DataRowView)binData.Current).Row;

            DrDes.BeginEdit();
            DataTable dt = DrDes.Table;
            foreach(DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == strNoCopyField) continue;
                DrDes[dc.ColumnName] = DrSource[dc.ColumnName];
            }
            DrDes.EndEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (blnNew == true)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        protected virtual void SaveData()
        {
             if (binData.DataSource != null)
            {
                if (Save() == true)
                {
                    if (blnNew == true)
                    {
                        //New();
                        if (ckCopy.Checked == true)
                        {
                            CopyRecord();
                        }
                        else
                            New();
                    }
                    else
                        this.DialogResult = DialogResult.OK;
                }
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
           SaveData();
        }

        /// <summary>
        /// �ؼ����ݰ�
        /// </summary>
        protected virtual void BindData()
        {
            if (DataLib.SysVar.strUID != "" && this.DesignMode == false && DataLib.SysVar.blnDesignForm == false)
            {
                LoadLayout r = new LoadLayout(this, this.Name);
                r.SetLayout();
            }

            //DataTable  dtBase = ((DataView)binData.DataSource).Table;
            //DataLib.sysClass myClass = new DataLib.sysClass();
            //myClass.SetColumnInfo(strMTable, ds.Tables[0]);

            BindClass.BindControl(gbox, binData);
            /*
            foreach (Control uCon in gbox.Controls)
            {
                if (uCon is myControl.EditControl)
                    (uCon as myControl.EditControl).BindData();

                if (uCon is myControl.lupControl)
                    (uCon as myControl.lupControl).BindData();

                if (uCon is myControl.cbControl)
                    (uCon as myControl.cbControl).BindData();

                if (uCon is myControl.DateControl)
                    (uCon as myControl.DateControl).BindData();

                if (uCon is myControl.SpinControl)
                    (uCon as myControl.SpinControl).BindData();

                if (uCon is myControl.ckControl)
                    (uCon as myControl.ckControl).BindData();
            }
             */ 
            blnBind = true;
        }

        /// <summary>
        /// ����ǰ���
        /// </summary>
        protected virtual bool SavePre()
        {
            foreach (Control uCon in gbox.Controls)
            {
                if (uCon is myControl.EditControl)
                {
                    if ((uCon as myControl.EditControl).Request == true)
                    {
                        if ((uCon as myControl.EditControl).GetValue() == DBNull.Value)
                        {
                            MessageBox.Show((uCon as myControl.EditControl).EditLabel + "����Ϊ��!!", "��ʾ");
                            (uCon as myControl.EditControl).Focus();
                            return false;
                        }
                        else
                        {
                            if ((uCon as myControl.EditControl).GetValue().ToString().Length == 0)
                            {
                                MessageBox.Show((uCon as myControl.EditControl).EditLabel + "����Ϊ��!!", "��ʾ");
                                (uCon as myControl.EditControl).Focus();
                                return false;
                            }
                        }
                    }
                }

                if (uCon is myControl.lupControl)
                {
                    if ((uCon as myControl.lupControl).Request == true)
                    {
                        if ((uCon as myControl.lupControl).GetValue() == DBNull.Value)
                        {
                            MessageBox.Show((uCon as myControl.lupControl).EditLabel + "����Ϊ��!!", "��ʾ");
                            (uCon as myControl.lupControl).Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ��������
        /// </summary>
        protected virtual bool Save()
        {
            binData.EndEdit();
            if (SavePre() == false) return false;
            DataSet ds = ((DataView)binData.DataSource).Table.DataSet;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, strSaveSlaverSQL) == 0)
            {
                ds.AcceptChanges();
                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// ����
        /// </summary>
        public virtual void New()
        {
            blnIsNew = true;
        }

        /// <summary>
        /// �༭
        /// </summary>
        public virtual void Edit(string strID)
        {

        }

        private void frmDialog_Load(object sender, EventArgs e)
        {
           
        }

        private void frmDialog_Shown(object sender, EventArgs e)
        {
           
        }
    }
}

