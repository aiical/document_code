/**********************************************
 * 功能：对SL_T_BanXing表进行维护管理(版型档案)
 * 日期：2013-10-9
 * *******************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Donlim.Common;
using Donlim.Controls;
using Donlim.Data;
using Donlim.Forms.CommonForm;
using System.Data.SqlClient;
using UFIDA.U8.UAP.Common;

namespace SL_U8Framework
{
    public partial class FrmBanXing :UserControl//Form 
    {
        private DataAccess ado = new DataAccess();
        private StringBuilder sql = new StringBuilder();
        private string Action = "";

        public FrmBanXing()
        {
            InitializeComponent();
            Donlim.Common.Function.initControlPersonSeting(this);
            EditToolBar.tsbtn_Flow.Visible = false;
            EditToolBar.tsbtn_Add.Visible = false;
            EditToolBar.tsbtn_Del.Visible = false;
            EditToolBar.tsbtn_Help.Visible = false;
            EditToolBar.tsbtn_Print.Visible = false;
            EditToolBar.tsbtn_ReSubmit.Visible = false;
            EditToolBar.tsbtn_rowEdit.Visible = false;
            EditToolBar.tsbtn_Submit.Visible = false;
            EditToolBar.tsbtn_Exit.Visible = false;
            EditToolBar.tsbtn_Edit.Enabled = true;
            EditToolBar.tsbtn_rowAdd.Visible = false;
            EditToolBar.tsbtn_rowDel.Visible = false;
            EditToolBar.toolStripSeparator1.Visible = false;
            EditToolBar.toolStripSeparator2.Visible = false;
            EditToolBar.toolStripSeparator3.Visible = false;
        }


        //菜单事件
        private void EditToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString())
            {
                ///编辑
                case "Edit":
                    {
                        this.Action = "Edit";
                        SetControls();
                        break;
                    }
                ///行新增
                case "rowAdd":
                    {
                        //DataRow dr = ((DataTable)dbGrid_Detail.DataSource).NewRow();
                        //((DataTable)dbGrid_Detail.DataSource).Rows.Add(dr);
                        //dbGrid_Detail.FirstDisplayedScrollingRowIndex = dbGrid_Detail.RowCount - 1;
                        break;
                    }
                ///行删除
                case "rowdel":
                    {
                        //if (MessageBox.Show("确定删除选择的行吗。。。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        //{
                        //    for (int i = dbGrid_Detail.SelectedRows.Count - 1; i >= 0; i--)
                        //    {
                        //        dbGrid_Detail.Rows.RemoveAt(dbGrid_Detail.SelectedRows[i].Index);
                        //    }
                        //}
                        break;
                    }
                ///保存
                case "Save":
                    {
                        dbGrid_Detail.EndEdit();
                        dbGrid_Detail.CurrentCell = null;
                        this.Cursor = Cursors.WaitCursor;
                        sql.Remove(0, sql.Length);
                        ado.BeginTrans();
                        try
                        {
                            //保存单身
                            string updtstr = GenDetailSql("update");
                            string insdtstr = GenDetailSql("insert");
                            List<SqlParameter> ilistStr = new List<SqlParameter>();
                            foreach (DataRow _Row in ((DataTable)dbGrid_Detail.DataSource).Rows)
                            {
                                StringBuilder _SQL = new StringBuilder();
                                if (_Row.RowState == DataRowState.Deleted)
                                {
                                    ado.ExeSql("delete SL_t_BanXing where isnull(U8cAlias,'')='" + _Row["U8cAlias", DataRowVersion.Original].ToString() + "' and isnull(U8cValue,'')='" + _Row["U8cValue", DataRowVersion.Original].ToString() + "' and isnull(NewBx,'')='" + _Row["NewBx", DataRowVersion.Original].ToString() + "'");
                                }
                                else if (_Row.RowState == DataRowState.Added | _Row.RowState == DataRowState.Modified)
                                {
                                    for (int i = 0; i < dbGrid_Detail.ColumnCount; i++)
                                    {
                                        if (dbGrid_Detail.Columns[i].ToolTipText != "")
                                        {
                                            ilistStr.Add(new SqlParameter("@" + dbGrid_Detail.Columns[i].DataPropertyName,  _Row[dbGrid_Detail.Columns[i].DataPropertyName]));
                                        }
                                    }
                                    SqlParameter[] param = ilistStr.ToArray();
                                    switch (_Row.RowState)
                                    {
                                        case DataRowState.Added:
                                            {
                                                ado.ExeSql(insdtstr, param);
                                                break;
                                            }
                                        case DataRowState.Modified:
                                            {


                                                ado.ExeSql(updtstr + " where isnull(U8cAlias,'')='" + _Row["U8cAlias", DataRowVersion.Original].ToString() + "' and isnull(U8cValue,'')='" + _Row["U8cValue", DataRowVersion.Original].ToString() + "' and isnull(NewBx,'')='" + _Row["NewBx", DataRowVersion.Original].ToString() + "'", param);
                                                break;
                                            }
                                    }
                                    ilistStr.Clear();
                                }
                            }
                            ado.Commit();
                            this.Action = "Save";
                            SetControls();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("保存失败：" + ex.Message);
                            ado.Rollback();
                        }
                        this.Cursor = Cursors.Default;
                        break;
                    }
                ///撤销
                case "Cancel":
                    {
                        this.Action = "Cancel";
                        SetControls();
                        dbGrid_Detail.InitDataGrid("SELECT * FROM SL_t_BanXing");
                        Donlim.Common.Function.SetPersonConfig(dbGrid_Detail);
                        break;
                    }
                    //刷新
                case "Refresh":
                    {
                        dbGrid_Detail.InitDataGrid("SELECT * FROM SL_t_BanXing");
                        Donlim.Common.Function.SetPersonConfig(dbGrid_Detail);
                        break;
                    }
                default:
                    break;

            }
        }

        //各种状态控制
        private void SetControls()
        {

            if (Action == "Edit")
            {
                dbGrid_Detail.ReadOnly = false;
                EditToolBar.tsbtn_Edit.Enabled = false;
                EditToolBar.tsbtn_Cancel.Enabled = true;
                //EditToolBar.tsbtn_rowAdd.Enabled = true;
                //EditToolBar.tsbtn_rowDel.Enabled = true;
                EditToolBar.tsbtn_Save.Enabled = true;
                EditToolBar.tsbtn_Refresh.Enabled = false;

            }
            if (Action == "Save" | Action == "Cancel")
            {
                dbGrid_Detail.ReadOnly = true;
                EditToolBar.tsbtn_Edit.Enabled = true;
                EditToolBar.tsbtn_Cancel.Enabled = false;
                //EditToolBar.tsbtn_rowAdd.Enabled = false;
                //EditToolBar.tsbtn_rowDel.Enabled = false;
                EditToolBar.tsbtn_Save.Enabled = false;
                EditToolBar.tsbtn_Refresh.Enabled = true;
                Action = "";
            }

        }


        //动态获取相关SQL语句
        private string GenDetailSql(string flag)
        {
            sql.Remove(0, sql.Length);
            string temp = "";
            for (int i = 0; i < dbGrid_Detail.ColumnCount; i++)
            {
                if (dbGrid_Detail.Columns[i].ToolTipText != "")
                {

                    if (flag.ToLower() == "update")
                    {
                        sql.Append(dbGrid_Detail.Columns[i].DataPropertyName + "=@" + dbGrid_Detail.Columns[i].DataPropertyName + ",");

                    }
                    else
                    {
                        sql.Append(dbGrid_Detail.Columns[i].DataPropertyName + ",");

                        temp = temp + "@" + dbGrid_Detail.Columns[i].DataPropertyName + ",";
                    }
                }
            }
            if (flag.ToLower() == "update")
            {
                sql.Remove(sql.Length - 1, 1);
                sql.Append(" ");
                return "update SL_t_BanXing set " + sql.ToString();
            }
            else
            {
                sql.Remove(sql.Length - 1, 1);
                sql.Append(") values(");
                temp = temp.Remove(temp.Length - 1, 1) + ")";
                return "insert into SL_t_BanXing(" + sql.ToString() + temp;
            }
        }

        private void FrmBanXing_Load(object sender, EventArgs e)
        {
            dbGrid_Detail.InitDataGrid("SELECT * FROM SL_t_BanXing");
            Donlim.Common.Function.SetPersonConfig(dbGrid_Detail);
        }

        private void dbGrid_Detail_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (dbGrid_Detail.ReadOnly==false)
            {
                dbGrid_Detail.Columns["CU8cAlias"].ReadOnly = true;
                dbGrid_Detail.Columns["CU8cValue"].ReadOnly = true;
                dbGrid_Detail.Columns["CTimestamp"].ReadOnly = true;
            }
        }

    }
}
