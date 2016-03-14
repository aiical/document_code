using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.DataAccess;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using System.Data.SqlClient;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class ShowFreeQuantityRef : Form
    {
        public ShowFreeQuantityRef()
        {
            InitializeComponent();
        }

        frmAddItemForm FIM;
        string ICode = string.Empty;
        string sItemCode = string.Empty;
        int RIndex;
        public ShowFreeQuantityRef(string fchrItemCode,string ItemCode)
        {
            ICode = fchrItemCode;
            sItemCode = ItemCode;
            InitializeComponent();
        }

        public ShowFreeQuantityRef(string fchrItemCode, string ItemCode,frmAddItemForm frmMemo,int RowIndex)
        {
            ICode = fchrItemCode;
            sItemCode = ItemCode;
            FIM = frmMemo;
            RIndex = RowIndex;
            InitializeComponent();
        }

        int index;

        private void ShowFreeQuantityRef_Load(object sender, EventArgs e)
        {
            this.Text = "商品编码：" + " " + sItemCode;
            DataSet ds1 = new DataSet();   //获取尺码
            DataSet ds2 = new DataSet();   //获取裤袖长
            DataSet ds3 = new DataSet();   //获取现存量
            string SQL = string.Format("SELECT  Sum(flotQuantity) as flotQuantity,fchrFree1 From (SELECT fchrFree1,Sum(flotQuantity) as flotQuantity from ItemStocks Where fchrItemID='{0}'  Group by fchrFree1 ) as TempTable Group by fchrFree1 Order by flotQuantity DESC", ICode);

            StringBuilder getFree1 = new StringBuilder();  //获取尺码
            getFree1.Append("SELECT fchrcode AS 编码,fchrValue AS 值 FROM viewUserDefineDatas");
            getFree1.Append(" WHERE (fchrFieldName='fchrfree1')");
            getFree1.Append(" AND ((( NOT EXISTS (SELECT fchrItemID FROM ItemAllotAnalysis WHERE fchrFieldName='fchrFree1' AND fchrItemID='" + ICode + "') AND  fchrItemID IS NULL) OR ( EXISTS (SELECT fchrItemID FROM ItemAllotAnalysis WHERE fchrFieldName='fchrFree1' AND fchrItemID='" + ICode + "'))))  AND  fchrItemID='" + ICode + "' ORDER BY fchrCode");

            StringBuilder getFree2 = new StringBuilder(); //获取裤袖长
            getFree2.Append("SELECT fchrcode AS 编码,fchrValue AS 值 FROM viewUserDefineDatas");
            getFree2.Append(" WHERE (fchrFieldName='fchrfree2')");
            getFree2.Append(" AND ( ( ( NOT EXISTS (SELECT fchrItemID FROM ItemAllotAnalysis WHERE fchrFieldName='fchrFree2' AND fchrItemID='" + ICode + "') AND  fchrItemID IS NULL) OR ( EXISTS (SELECT fchrItemID FROM ItemAllotAnalysis WHERE fchrFieldName='fchrFree2' AND fchrItemID='" + ICode + "')) )) AND  fchrItemID='" + ICode + "' ORDER BY fchrCode");

            ds1 = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, getFree1.ToString());
            ds2 = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, getFree2.ToString());

            StringBuilder sb = new StringBuilder();  //获取现存量
            sb.Append("SELECT  Sum(flotQuantity) as flotQuantity,fchrFree1 From (SELECT fchrFree1,Sum(flotQuantity) as flotQuantity from ItemStocks Where fchrItemID='" + ICode + "'");
            sb.Append(" Group by fchrFree1 ) as TempTable");
            sb.Append(" Group by fchrFree1 Order by flotQuantity DESC");

            ds3 = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sb.ToString());

            DataGridViewTextBoxColumn tbColumnFQ = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn tbColumnQuantity = new DataGridViewTextBoxColumn();

            dgvFQ.RowHeadersWidth = 150;
            dgvQuantity.RowHeadersWidth = 150;

            if (ds1.Tables[0].Rows.Count > 0 && ds2.Tables[0].Rows.Count == 0)
            {
                tbColumnFQ.Name = "Quantity";
                tbColumnFQ.HeaderText = "数量";
                dgvFQ.Columns.Add(tbColumnFQ);

                tbColumnQuantity.Name = "CurrentQuantiy";
                tbColumnQuantity.HeaderText = "现存量";
                dgvQuantity.Columns.Add(tbColumnQuantity);

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    dgvFQ.Rows.Add();
                    dgvQuantity.Rows.Add();
                    dgvQuantity.Rows[i].Cells["CurrentQuantiy"].ReadOnly = true;
                    dgvFQ.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                    dgvQuantity.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;

                    dgvFQ.Rows[i].HeaderCell.Value = ds1.Tables[0].Rows[i][1].ToString();
                    dgvQuantity.Rows[i].HeaderCell.Value = ds1.Tables[0].Rows[i][1].ToString();
                    dgvFQ.Rows[i].Cells[0].Value = 0;
                    dgvQuantity.Rows[i].Cells[0].Value = 0;

                    for (int k = 0; k < ds3.Tables[0].Rows.Count; k++)
                    {
                        if (dgvQuantity.Rows[i].HeaderCell.Value.ToString() == ds3.Tables[0].Rows[k]["fchrFree1"].ToString())
                        {
                            dgvQuantity.Rows[i].Cells[0].Value = Convert.ToInt32(ds3.Tables[0].Rows[k]["flotQuantity"]).ToString();
                        }
                    }

                    //if (Convert.ToInt32(dgvQuantity.Rows[i].Cells[0].Value.ToString()) > 0)
                    //{
                    //    dgvQuantity.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                    //}
                }

                //if (FIM.dgvItemList.Rows[RIndex].Cells[3].Value != null)
                //{
                //    for (int r = 0; r < dgvFQ.Rows.Count; r++)
                //    {
                //        if (dgvFQ.Rows[r].HeaderCell.Value.ToString() == FIM.dgvItemList.Rows[RIndex].Cells[3].Value.ToString())
                //        {
                //            dgvFQ.Rows[r].Cells[0].Value = FIM.dgvItemList.Rows[RIndex].Cells["flotQuantity"].Value.ToString();
                //            dgvFQ.CurrentCell = dgvFQ[0, r];
                //            dgvQuantity.CurrentCell = dgvQuantity[0, r];
                //        }
                //    }
                //}
            }

            if (ds1.Tables[0].Rows.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                tbColumnFQ.Name = "TotalQuantity";
                tbColumnFQ.HeaderText = "合计";
                dgvFQ.Columns.Add("Free2", ds2.Tables[0].Rows[0][1].ToString());
                dgvFQ.Columns.Add(tbColumnFQ);

                tbColumnQuantity.Name = "Free2";
                tbColumnQuantity.HeaderText = ds2.Tables[0].Rows[0][1].ToString();
                dgvQuantity.Columns.Add(tbColumnQuantity);
                dgvQuantity.Columns.Add("CurrentQuantity","合计");

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    dgvFQ.Rows.Add();
                    dgvQuantity.Rows.Add();
                    dgvFQ.Rows[i].Cells["TotalQuantity"].ReadOnly = true;
                    dgvQuantity.Rows[i].Cells["CurrentQuantity"].ReadOnly = true;
                    dgvFQ.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                    dgvFQ.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                    dgvQuantity.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                    dgvQuantity.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.BottomRight;

                    dgvFQ.Rows[i].HeaderCell.Value = ds1.Tables[0].Rows[i][1].ToString();
                    dgvFQ.Rows[i].Cells[0].Value = 0;
                    dgvFQ.Rows[i].Cells[1].Value = 0;
                    dgvQuantity.Rows[i].HeaderCell.Value = ds1.Tables[0].Rows[i][1].ToString();
                    dgvQuantity.Rows[i].Cells[0].Value = 0;
                    dgvQuantity.Rows[i].Cells[1].Value = 0;

                    for (int k = 0; k < ds3.Tables[0].Rows.Count; k++)
                    {
                        if (dgvQuantity.Rows[i].HeaderCell.Value.ToString() == ds3.Tables[0].Rows[k]["fchrFree1"].ToString())
                        {
                            dgvQuantity.Rows[i].Cells[1].Value = Convert.ToInt32(ds3.Tables[0].Rows[k]["flotQuantity"]).ToString();
                            dgvQuantity.Rows[i].Cells[0].Value = Convert.ToInt32(ds3.Tables[0].Rows[k]["flotQuantity"]).ToString();
                        }
                    }

                    //if (Convert.ToInt32(dgvQuantity.Rows[i].Cells[1].Value.ToString()) > 0)
                    //{
                    //    dgvQuantity.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                    //    dgvQuantity.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    //}
                }

                //if (FIM.dgvItemList.Rows[RIndex].Cells[3].Value != null)
                //{
                //    for (int r = 0; r < dgvFQ.Rows.Count; r++)
                //    {
                //        if (dgvFQ.Rows[r].HeaderCell.Value.ToString() == FIM.dgvItemList.Rows[RIndex].Cells[3].Value.ToString())
                //        {
                //            dgvFQ.Rows[r].Cells[0].Value = FIM.dgvItemList.Rows[RIndex].Cells["flotQuantity"].Value.ToString();
                //            dgvFQ.Rows[r].Cells[1].Value = FIM.dgvItemList.Rows[RIndex].Cells["flotQuantity"].Value.ToString();
                //            dgvFQ.CurrentCell = dgvFQ[0, r];
                //            dgvQuantity.CurrentCell = dgvQuantity[0, r];
                //        }
                //    }
                //}
            }

            //将数量列设为只读且不允许列排序
            dgvQuantity.Columns[0].ReadOnly = true;
            dgvQuantity.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            if (dgvQuantity.Columns.Count > 1)
            {
                dgvQuantity.Columns[1].ReadOnly = true;
                dgvQuantity.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvFQ.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            if (dgvFQ.Columns.Count > 1)
            {
                dgvFQ.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        
        private void dgvFQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvQuantity.CurrentCell = dgvQuantity[0, e.RowIndex];
            }
        }

        private void dgvFQ_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0)
            //{
            //    dgvQuantity[0, index].Style.BackColor = Color.White;
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dgvQuantity.Visible = false;
                btnOK.Location =new Point(263,295);
                btnCancle.Location = new Point(344,295);
                checkBox1.Location = new Point(12, 295);
                this.Size = new Size(449, 350);
            }
            else
            {
                dgvQuantity.Visible = true;
                btnOK.Location = new Point(263, 561);
                btnCancle.Location = new Point(344, 561);
                checkBox1.Location = new Point(12, 567);
                this.Size = new Size(449, 619);
            }
        }

        private void dgvFQ_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < dgvFQ.Rows.Count; i++)
            {
                Sum += Convert.ToInt32(dgvFQ.Rows[i].Cells[0].Value);
            }
            lblTotal.Text = Sum.ToString();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else if (e.KeyChar == ' ')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvFQ_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Control ctrl = e.Control;
            ctrl.KeyPress += new KeyPressEventHandler(dgvFQ_KeyPress);
        }
    }
}
