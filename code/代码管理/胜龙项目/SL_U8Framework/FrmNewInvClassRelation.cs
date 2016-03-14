/**********************************************
 * 功能：对SL_t_NewInventoryClass、SL_t_NewInvClassRelation、SL_t_PriceList表进行维护管理(新存货分类表、新旧存货分类对照表、价格表)
 * 日期：2014-09-08
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
using Donlim.Forms.BaseForm;
using System.Data.SqlClient;
using System.Collections;
using UFIDA.U8.UAP.Common;

namespace SL_U8Framework
{
    public partial class FrmNewInvClassRelation : UserControl // Form
    {
        private DataAccess ado = new DataAccess();
        private StringBuilder sql = new StringBuilder();
        private string Action = "";
        // public  GridSearchForm _formFind = null;
        private Hashtable chgHt = new Hashtable(); //类别中有变更的部分

        public FrmNewInvClassRelation()
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
            EditToolBar.toolStripSeparator1.Visible = false;
            EditToolBar.toolStripSeparator2.Visible = false;
            dbGrid_Master.CellValidated -= dbGrid_Master_CellValidated;


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

                        DBGrid actDBGrid = (DBGrid)PublicClass.GetActiveDBGrid(this.ActiveControl);
                        if (actDBGrid != null)
                        {
                            actDBGrid.EndEdit();
                            actDBGrid.CurrentCell = null;
                            DataRow dr = ((DataTable)actDBGrid.DataSource).NewRow();
                            switch (actDBGrid.Name)
                            {
                                case "dbGrid_Master":
                                    {
                                        break;
                                    }
                                case "dbGrid_Relation":
                                    {
                                        dr["NewInvCCode"] = dbGrid_Master.CurrentRow.Cells["CNewInvCCode"].Value.ToString();
                                        dr["NewInvCName"] = dbGrid_Master.CurrentRow.Cells["CNewInvCName"].Value.ToString();
                                        break;
                                    }
                                case "dbGrid_Detail":
                                    {
                                        dr["NewInvCCode"] = dbGrid_Master.CurrentRow.Cells["CNewInvCCode"].Value.ToString();
                                        dr["NewInvCName"] = dbGrid_Master.CurrentRow.Cells["CNewInvCName"].Value.ToString();
                                        break;
                                    }
                            }
                            ((DataTable)actDBGrid.DataSource).Rows.Add(dr);
                            FilteDate();
                            actDBGrid.FirstDisplayedScrollingRowIndex = actDBGrid.RowCount - 1;
                        }
                        else
                        {
                            MessageBox.Show("请选择指定的数据网格控件再操作。。。", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        break;
                    }
                ///行删除
                case "rowdel":
                    {

                        DBGrid actDBGrid = (DBGrid)PublicClass.GetActiveDBGrid(this.ActiveControl);
                        if (actDBGrid != null)
                        {
                            if (MessageBox.Show("确定删除选择的行吗。。。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                for (int i = actDBGrid.SelectedRows.Count - 1; i >= 0; i--)
                                {
                                    actDBGrid.Rows.RemoveAt(actDBGrid.SelectedRows[i].Index);
                                }
                                FilteDate();
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择指定的数据网格控件再操作。。。", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        break;
                    }
                ///保存
                case "Save":
                    {
                        dbGrid_Relation.EndEdit();
                        dbGrid_Relation.CurrentCell = null;
                        dbGrid_Detail.EndEdit();
                        dbGrid_Detail.CurrentCell = null;
                        dbGrid_Master.EndEdit();
                        dbGrid_Master.CurrentCell = null;
                        this.Cursor = Cursors.WaitCursor;

                        try
                        {
                            //保存单身
                            ado.BeginTrans();
                            UpdateData(dbGrid_Master);
                            UpdateData(dbGrid_Detail);
                            UpdateData(dbGrid_Relation);
                            ado.Commit();
                            this.Action = "Save";
                            SetControls();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("数据保存失败：" + ex.Message);
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
                        Action = "Init";
                        SetControls();
                        break;
                    }
                //刷新
                case "Refresh":
                    {
                        Action = "Init";
                        SetControls();

                        break;
                    }
                default:
                    break;

            }
        }

        //动态数据产生
        private void UpdateData(DBGrid curDBGrid)
        {
            string tablename = "";
            sql.Remove(0, sql.Length);
            switch (curDBGrid.Name)
            {
                case "dbGrid_Master":
                    {
                        tablename = "SL_t_NewInventoryClass";
                        break;
                    }
                case "dbGrid_Relation":
                    {
                        tablename = "SL_t_NewInvClassRelation";
                        break;
                    }
                case "dbGrid_Detail":
                    {
                        tablename = "SL_t_PriceList";
                        break;
                    }
            }
            string updtstr = GenDetailSql(curDBGrid, tablename, "update");
            string insdtstr = GenDetailSql(curDBGrid, tablename, "insert");
            List<SqlParameter> ilistStr = new List<SqlParameter>();
            foreach (DataRow _Row in ((DataTable)curDBGrid.DataSource).Rows)
            {
                StringBuilder _SQL = new StringBuilder();
                if (_Row.RowState == DataRowState.Deleted)
                {
                    switch (curDBGrid.Name)
                    {
                        case "dbGrid_Master":
                            {
                                ado.ExeSql("delete SL_t_NewInventoryClass where isnull(NewInvCCode,'')='" + _Row["NewInvCCode", DataRowVersion.Original].ToString() + "' and isnull(NewInvCName,'')='" + _Row["NewInvCName", DataRowVersion.Original].ToString() + "'");
                                break;
                            }
                        case "dbGrid_Relation":
                            {
                                ado.ExeSql("delete SL_t_NewInvClassRelation where isnull(NewInvCCode,'')='" + _Row["NewInvCCode", DataRowVersion.Original].ToString() + "' and isnull(NewInvCName,'')='" + _Row["NewInvCName", DataRowVersion.Original].ToString() + "' and isnull(InvCCode,'')='" + _Row["InvCCode", DataRowVersion.Original].ToString() + "' and isnull(InvCName,'')='" + _Row["InvCName", DataRowVersion.Original].ToString() + "'");
                                break;
                            }
                        case "dbGrid_Detail":
                            {
                                ado.ExeSql("delete SL_t_PriceList where isnull(NewInvCCode,'')='" + _Row["NewInvCCode", DataRowVersion.Original].ToString() + "' and isnull(NewInvCName,'')='" + _Row["NewInvCName", DataRowVersion.Original].ToString() + "' and isnull(PriceLevel,'')='" + _Row["PriceLevel", DataRowVersion.Original].ToString() + "' and isnull(PriceSort,'')='" + _Row["PriceSort", DataRowVersion.Original].ToString() + "'  and isnull(StartPrice,'')='" + _Row["StartPrice", DataRowVersion.Original].ToString() + "' and isnull(EndPrice,'')='" + _Row["EndPrice", DataRowVersion.Original].ToString() + "'");
                                break;
                            }
                    }

                }
                else if (_Row.RowState == DataRowState.Added | _Row.RowState == DataRowState.Modified)
                {
                    for (int i = 0; i < curDBGrid.ColumnCount; i++)
                    {
                        if (curDBGrid.Columns[i].ToolTipText != "")
                        {
                            ilistStr.Add(new SqlParameter("@" + curDBGrid.Columns[i].DataPropertyName, _Row[curDBGrid.Columns[i].DataPropertyName]));
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
                                switch (curDBGrid.Name)
                                {
                                    case "dbGrid_Master":
                                        {
                                            ado.ExeSql(updtstr + " where isnull(NewInvCCode,'')='" + _Row["NewInvCCode", DataRowVersion.Original].ToString() + "' and isnull(NewInvCName,'')='" + _Row["NewInvCName", DataRowVersion.Original].ToString() + "'", param);
                                            break;
                                        }
                                    case "dbGrid_Relation":
                                        {
                                            ado.ExeSql(updtstr + " where isnull(NewInvCCode,'')='" + _Row["NewInvCCode", DataRowVersion.Original].ToString() + "' and isnull(NewInvCName,'')='" + _Row["NewInvCName", DataRowVersion.Original].ToString() + "' and isnull(InvCCode,'')='" + _Row["InvCCode", DataRowVersion.Original].ToString() + "' and isnull(InvCName,'')='" + _Row["InvCName", DataRowVersion.Original].ToString() + "'", param);
                                            break;
                                        }
                                    case "dbGrid_Detail":
                                        {
                                            ado.ExeSql(updtstr + "  where isnull(NewInvCCode,'')='" + _Row["NewInvCCode", DataRowVersion.Original].ToString() + "' and isnull(NewInvCName,'')='" + _Row["NewInvCName", DataRowVersion.Original].ToString() + "' and isnull(PriceLevel,'')='" + _Row["PriceLevel", DataRowVersion.Original].ToString() + "' and isnull(PriceSort,'')='" + _Row["PriceSort", DataRowVersion.Original].ToString() + "'  and StartPrice " + (Convert.IsDBNull(_Row["StartPrice", DataRowVersion.Original]) ? " is null" : "=" + _Row["StartPrice", DataRowVersion.Original].ToString()) + " and EndPrice" + (Convert.IsDBNull(_Row["EndPrice", DataRowVersion.Original]) ? " is null" : "=" + _Row["EndPrice", DataRowVersion.Original].ToString()), param);
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    ilistStr.Clear();
                }
            }

        }

        //各种状态控制
        private void SetControls()
        {
            if (Action == "Init")
            {
                dbGrid_Master.InitDataGrid("SELECT * FROM SL_t_NewInventoryClass");
                Donlim.Common.Function.SetPersonConfig(dbGrid_Master);
                dbGrid_Relation.InitDataGrid("SELECT * FROM SL_t_NewInvClassRelation");
                Donlim.Common.Function.SetPersonConfig(dbGrid_Relation);
                dbGrid_Detail.InitDataGrid("SELECT * FROM SL_t_PriceList");
                Donlim.Common.Function.SetPersonConfig(dbGrid_Detail);
                FilteDate();
                Action = "";
            }
            if (Action == "Edit")
            {
                dbGrid_Master.CellValidated += dbGrid_Master_CellValidated;
                dbGrid_Master.ReadOnly = false;
                dbGrid_Detail.ReadOnly = false;
                dbGrid_Detail.Columns["ColNewInvCCode"].ReadOnly = true;
                dbGrid_Detail.Columns["ColNewInvCName"].ReadOnly = true;
                dbGrid_Relation.ReadOnly = false;
                dbGrid_Relation.Columns["CoNewInvCCode"].ReadOnly = true;
                dbGrid_Relation.Columns["CoNewInvCName"].ReadOnly = true;
                EditToolBar.tsbtn_Edit.Enabled = false;
                EditToolBar.tsbtn_Cancel.Enabled = true;
                EditToolBar.tsbtn_rowAdd.Enabled = true;
                EditToolBar.tsbtn_rowDel.Enabled = true;
                EditToolBar.tsbtn_Save.Enabled = true;
                EditToolBar.tsbtn_Refresh.Enabled = false;

            }
            if (Action == "Save" | Action == "Cancel")
            {
                dbGrid_Master.CellValidated -= dbGrid_Master_CellValidated;
                dbGrid_Master.ReadOnly = true;
                dbGrid_Detail.ReadOnly = true;
                dbGrid_Relation.ReadOnly = true;
                EditToolBar.tsbtn_Edit.Enabled = true;
                EditToolBar.tsbtn_Cancel.Enabled = false;
                EditToolBar.tsbtn_rowAdd.Enabled = false;
                EditToolBar.tsbtn_rowDel.Enabled = false;
                EditToolBar.tsbtn_Save.Enabled = false;
                EditToolBar.tsbtn_Refresh.Enabled = true;
                Action = "";
            }

        }


        //动态获取相关SQL语句
        private string GenDetailSql(DBGrid curDBGrid, string tablename, string flag)
        {
            sql.Remove(0, sql.Length);
            string temp = "";
            for (int i = 0; i < curDBGrid.ColumnCount; i++)
            {
                if (curDBGrid.Columns[i].ToolTipText != "")
                {

                    if (flag.ToLower() == "update")
                    {
                        sql.Append(curDBGrid.Columns[i].DataPropertyName + "=@" + curDBGrid.Columns[i].DataPropertyName + ",");

                    }
                    else
                    {
                        sql.Append(curDBGrid.Columns[i].DataPropertyName + ",");

                        temp = temp + "@" + curDBGrid.Columns[i].DataPropertyName + ",";
                    }
                }
            }

            if (flag.ToLower() == "update")
            {
                sql.Remove(sql.Length - 1, 1);
                sql.Append(" ");
                return "update " + tablename + " set " + sql.ToString();
            }
            else
            {
                sql.Remove(sql.Length - 1, 1);
                sql.Append(") values(");
                temp = temp.Remove(temp.Length - 1, 1) + ")";
                return "insert into " + tablename + "(" + sql.ToString() + temp;
            }
        }

        private void dbGrid_Master_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        //过滤数据
        private void FilteDate()
        {
            if (dbGrid_Master.CurrentRow != null)
            {
                CurrencyManager cm_Relation = (CurrencyManager)BindingContext[dbGrid_Relation.DataSource];
                cm_Relation.SuspendBinding(); //挂起数据绑定
                for (int i = 0; i < dbGrid_Relation.RowCount; i++)
                {
                    dbGrid_Relation.Rows[0].Visible = false;
                    if (dbGrid_Master.Rows[dbGrid_Master.CurrentRow.Index].Cells["CNewInvCCode"].Value.ToString().Trim().ToLower() == dbGrid_Relation.Rows[i].Cells["CoNewInvCCode"].Value.ToString().Trim().ToLower() && dbGrid_Master.Rows[dbGrid_Master.CurrentRow.Index].Cells["CNewInvCName"].Value.ToString().Trim().ToLower() == dbGrid_Relation.Rows[i].Cells["CoNewInvCName"].Value.ToString().Trim().ToLower())
                    {
                        dbGrid_Relation.Rows[i].Visible = true;
                    }
                    else
                    {
                        dbGrid_Relation.Rows[i].Visible = false;
                    }
                    // dgvfactoryMateriel.SelectedRows[i].Visible = false;//设置选中的某行为不可见

                }
                cm_Relation.ResumeBinding(); //恢复数据绑定

                CurrencyManager cm_Detail = (CurrencyManager)BindingContext[dbGrid_Detail.DataSource];
                cm_Detail.SuspendBinding(); //挂起数据绑定
                for (int i = 0; i < dbGrid_Detail.RowCount; i++)
                {
                    dbGrid_Detail.Rows[0].Visible = false;
                    if (dbGrid_Master.Rows[dbGrid_Master.CurrentRow.Index].Cells["CNewInvCCode"].Value.ToString().Trim().ToLower() == dbGrid_Detail.Rows[i].Cells["ColNewInvCCode"].Value.ToString().Trim().ToLower() && dbGrid_Master.Rows[dbGrid_Master.CurrentRow.Index].Cells["CNewInvCName"].Value.ToString().Trim().ToLower() == dbGrid_Detail.Rows[i].Cells["ColNewInvCName"].Value.ToString().Trim().ToLower())
                    {
                        dbGrid_Detail.Rows[i].Visible = true;
                    }
                    else
                    {
                        dbGrid_Detail.Rows[i].Visible = false;
                    }
                }
                cm_Detail.ResumeBinding(); //恢复数据绑定

            }
        }

        private void dbGrid_Relation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dbGrid_Master_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FilteDate();
        }

        private void FrmNewInvClassRelation_Load(object sender, EventArgs e)
        {
            Action = "Init";
            SetControls();
            if (dbGrid_Master.RowCount > 0)
            {
                dbGrid_Master.Rows[0].Selected = true;
                FilteDate();
            }
        }

        private void dbGrid_Master_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                for (int i = 0; i < dbGrid_Relation.Rows.Count; i++)
                {
                    if (dbGrid_Relation.Rows[i].Visible)
                    {
                        DataRow dataRow_Relation = (dbGrid_Relation.Rows[i].DataBoundItem as DataRowView).Row;
                        dataRow_Relation["NewInvCCode"] = dbGrid_Master.CurrentRow.Cells["CNewInvCCode"].Value.ToString().Trim();
                        dataRow_Relation["NewInvCName"] = dbGrid_Master.CurrentRow.Cells["CNewInvCName"].Value.ToString().Trim();
                    }

                }
                for (int j = 0; j < dbGrid_Detail.Rows.Count; j++)
                {
                    if (dbGrid_Detail.Rows[j].Visible)
                    {
                        DataRow dataRow_Detail = (dbGrid_Detail.Rows[j].DataBoundItem as DataRowView).Row;
                        dataRow_Detail["NewInvCCode"] = dbGrid_Master.CurrentRow.Cells["CNewInvCCode"].Value.ToString().Trim();
                        dataRow_Detail["NewInvCName"] = dbGrid_Master.CurrentRow.Cells["CNewInvCName"].Value.ToString().Trim();
                    }

                }
                FilteDate();
            }
        }





    }

}