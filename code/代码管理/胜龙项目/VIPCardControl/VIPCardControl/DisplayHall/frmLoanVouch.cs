using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Common;
using C1.Win.C1FlexGrid;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Business.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmLoanVouch : Form
    {
        public frmLoanVouch()
        {
            InitializeComponent();
        }

        private string _SelectedVouchCode;

        public string SelectedVouchCode
        {
            get { return _SelectedVouchCode; }
            set { _SelectedVouchCode = value; }
        }

        private string _CurrentStatus;

        public string CurrentStatus
        {
            get { return _CurrentStatus; }
            set { _CurrentStatus = value; }
        }

        public frmLoanVouch(string SelVouchCode,string CurStatus)
        {
            _SelectedVouchCode = SelVouchCode;
            _CurrentStatus = CurStatus;
            InitializeComponent();
        }

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"] != null)
            {
                dgv.Rows.Add();
            }
            ButtonStatus("btnInsertRow");
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1 && dgv.RowSel > 0)
            {
                dgv.Rows.Remove(dgv.RowSel);
            }
            ButtonStatus("btnDelRow");
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            string MainID = string.Empty;
            string ErrMsg = string.Empty;
            string AlterMsg = string.Empty;
            AlterMsg = "";

            if (dgv.Rows.Count <= 1)
            {
                RetailMessageBox.ShowWarning("表体数据为空，不允许保存！");
                return;
            }

            if (!CheckDataIsValid(ref ErrMsg))
            {
                RetailMessageBox.ShowInformation(ErrMsg);
                return;
            }

            SaveVoucher(false,ref MainID, ref ErrMsg);

            if (string.IsNullOrEmpty(ErrMsg))
            {
                RetailMessageBox.ShowInformation("单据保存成功，准备上传单据！");
                //更新现存量
                RetailCommom.UpdateCurStock(RetailCommom.GetDetailTable(dgv), "JC");
                System.Threading.Thread pthred = new System.Threading.Thread(new System.Threading.ThreadStart(Lixtech.Common.CommonClass.ShowWaitForm));
                pthred.Start();
                try
                {
                    //上传数据到零售系统
                    if (RetailCommom.UploadDataToRM(MainID, this.txtVouchCode.txtText.Trim(), "JC", ref ErrMsg))
                    {
                        AlterMsg += "【借出单】已成功上传零售系统！" + "\r\n";
                        //上传数据到U8系统
                        if (RetailCommom.UploadDataToU8(MainID, this.txtVouchCode.txtText.Trim(), "JC", ref ErrMsg))
                        {
                            AlterMsg += "【借出单】已成功上传U8系统！" + "\r\n";
                        }
                        else
                        {
                            AlterMsg += "单据上传到U8系统发生异常，原因： " + ErrMsg + "\r\n";
                        }
                    }
                    else
                    {
                        AlterMsg += "单据上传到零售系统发生异常，原因： " + ErrMsg + "\r\n";
                    }

                    if (pthred != null)
                    {
                        pthred.Abort();
                        pthred = null;
                    }
                    GC.Collect();

                    if (!string.IsNullOrEmpty(AlterMsg))
                        RetailMessageBox.ShowInformation(AlterMsg);
                }
                catch(Exception ex)
                {
                    pthred.Abort();
                    pthred = null;
                    GC.Collect();
                    RetailMessageBox.ShowInformation(ex.Message);
                }
                //finally
                //{
                //    if (pthred != null)
                //    {
                //        pthred.Abort();
                //        pthred = null;
                //    }
                //    GC.Collect();
                //}

                EmptyAllVoucherData(false);
            }
            else
            {
                RetailMessageBox.ShowInformation("单据保存失败，原因：" + "\r\n" + ErrMsg);
                return;
            }

            ButtonStatus("LoadForm");
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {
            ButtonStatus("btnInsertRow");
            frmScanBarCode ScanBarCode = new frmScanBarCode(this.dgv, "JC");
            ScanBarCode.ShowDialog();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            int printId = 0;
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(txtVouchCode.txtText.Trim()))
                {
                    string sql = string.Format("select printID from sl_PrintRight where cUserId='{0}' and cVouchType = '借出单'", SysPara.GetString("操作员ID"));
                    obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql);
                    if (obj != null)
                    {
                        printId = Convert.ToInt32(obj);
                    }
                    else
                    {
                        RetailMessageBox.ShowInformation("首次使用请先设置纸张！");
                        return;
                    }

                    frmPrint print = new frmPrint(txtVouchCode.txtText.Trim(), "借出单", SysPara.ConnectionString, printId, SysPara.GetString("操作员ID"));
                    print.ShowDialog();
                }
                else
                {
                    RetailMessageBox.ShowInformation("单据号不允许为空！");
                    return;
                }
            }
            catch (Exception ex)
            {
                RetailMessageBox.ShowWarning(ex.Message);
            }
        }

        private void frmLoanVouch_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_SelectedVouchCode))
            {
                FillVouchData(RetailCommom.GetVouchDataInfo(_SelectedVouchCode, "JC"));
            }
            else
            {
                txtVouchCode.txtText = sl_RetailCommom.GenNewVouchCode("JC", "sl_t_RdVouchMain", "fchrCode");
                txtVouchCode.txtTag = Guid.NewGuid().ToString();
                this.txtMaker.txtText = SysPara.GetSysPara("操作员名称").ToString();
            }

            ButtonStatus("LoadForm");
        }

        private void dgv_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            int RowSelIndex = 0;
            string sqlTlbName = string.Empty;
            string sql = string.Empty;
            if (dgv.Cols[dgv.Col].Caption == "商品编码")
            {
//                sql = string.Format(@"select 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价',ROW_NUMBER() over(order by fchrItemCode) as ID
//                                      from item where 1=1");
                sqlTlbName = string.Format(@"SELECT 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价' FROM  
                                             item where 1=1");

                sql = string.Format(@"SELECT Count(1) FROM item where 1=1 ");

                frmItemListRef ItemRef = new frmItemListRef(sql, sqlTlbName, dgv.Rows[dgv.Row]["fchrItemCode"] != null ? dgv.Rows[dgv.Row]["fchrItemCode"].ToString() : "", false, "商品", "", "商品编码");
                if(ItemRef.ShowDialog() == DialogResult.OK)
                {
                    dgv.Rows[dgv.Row]["fchrItemCode"] = ItemRef.ItemInfoList[0].Itemcode.ToString();
                    dgv.Rows[dgv.Row]["fchrItemName"] = ItemRef.ItemInfoList[0].Itemname.ToString();
                    dgv.Rows[dgv.Row]["fchrUnitName"] = ItemRef.ItemInfoList[0].Itemunitname.ToString();

                    //自动弹出尺码参照
//                    sql = string.Format(@"select 0 as sel, fchrCode as '代码',fchrValue as '尺码',ROW_NUMBER() over(order by fchrCode) as ID from dbo.ItemAllotAnalysis iaa
//                                      left join item i on iaa.fchritemid = i.fchritemid
//                                      where fchritemcode = '{0}' and fchrFieldName= 'fchrFree1' and 1=1", ItemRef.ItemInfoList[0].Itemcode.ToString());

                    sqlTlbName = string.Format(@"SELECT 0 as sel, fchrCode as '代码',fchrValue as '尺码' FROM  
                                          (select i.*,iaa.fchrCode,iaa.fchrValue,iaa.fchrFieldName from dbo.ItemAllotAnalysis iaa
                                          left join item i on iaa.fchritemid = i.fchritemid) as t 
                                          where fchritemcode = '{0}' and fchrFieldName= 'fchrFree1' and 1=1", ItemRef.ItemInfoList[0].Itemcode.ToString());

                    sql = string.Format(@"SELECT count(1) FROM  
                                          (select i.*,iaa.fchrCode,iaa.fchrValue,iaa.fchrFieldName from dbo.ItemAllotAnalysis iaa
                                          left join item i on iaa.fchritemid = i.fchritemid) as t 
                                          where fchritemcode = '{0}' and fchrFieldName= 'fchrFree1' and 1=1 ", ItemRef.ItemInfoList[0].Itemcode.ToString());

                    if (sl_RetailCommom.GetDatas("fbitFree1", "Item", "fchrItemCode", ItemRef.ItemInfoList[0].Itemcode.ToString()) == "True")
                    {
                        if (string.IsNullOrEmpty(ItemRef.ItemInfoList[0].Itemcode.ToString()))
                        {
                            MessageBox.Show("请先选择商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            //先清空自由项值
                            dgv.Rows[dgv.Row]["fchrFree1"] = null;
                            dgv.Rows[dgv.Row]["fchrFree2"] = null;

                            frmItemListRef Free1Ref = new frmItemListRef(sql, sqlTlbName, dgv.Rows[dgv.Row]["fchrFree1"] != null ? dgv.Rows[dgv.Row]["fchrFree1"].ToString() : "", true, "尺码", "", "代码");
                            if (Free1Ref.ShowDialog() == DialogResult.OK)
                            {
                                //自由项多选处理
                                if (Free1Ref.SelTextList.Count > 0)
                                {
                                    RowSelIndex = dgv.Row;
                                    foreach (string SelText in Free1Ref.SelTextList)
                                    {
                                        if (CheckRowIsExists(dgv.Rows[dgv.Row]["fchrItemCode"].ToString(), SelText))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            if (RowSelIndex <= dgv.Rows.Count - 1)
                                            {
                                                if (dgv.Rows[RowSelIndex]["fchrFree1"] == null && dgv.Rows[RowSelIndex]["fchrItemCode"].ToString() == dgv.Rows[dgv.Row]["fchrItemCode"].ToString())
                                                {
                                                    this.dgv.Rows[RowSelIndex]["fchrFree1"] = SelText;
                                                    this.dgv.Rows[RowSelIndex]["fchrFree2"] = sl_RetailCommom.GetDatas("fbitFree2", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()) == "True" ? "Z" : "";
                                                    if (dgv.Rows[RowSelIndex]["fchrItemCode"] != null)
                                                        SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[RowSelIndex]["fchrItemCode"].ToString()), RowSelIndex);
                                                }
                                                else
                                                {
                                                    //复制数据行
                                                    CopyDataRow(dgv.Rows[dgv.Row], SelText);
                                                    this.dgv.Rows[dgv.Row]["fchrFree2"] = sl_RetailCommom.GetDatas("fbitFree2", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()) == "True" ? "Z" : "";
                                                    if (dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"] != null)
                                                        SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"].ToString()), dgv.Rows.Count - 1);
                                                }
                                            }
                                            else
                                            {
                                                //复制数据行
                                                CopyDataRow(dgv.Rows[dgv.Row], SelText);
                                                this.dgv.Rows[dgv.Row]["fchrFree2"] = sl_RetailCommom.GetDatas("fbitFree2", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()) == "True" ? "Z" : "";
                                                if (dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"] != null)
                                                    SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"].ToString()), dgv.Rows.Count - 1);
                                            }
                                        }

                                        if (dgv.Rows.Count - 1 - RowSelIndex > 0)
                                            RowSelIndex++;
                                    }
                                }
                            }
                        }
                    }

                    //if (dgv.Rows[dgv.Row]["fchrItemCode"] != null)
                    //   SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()));
                }
            }

            if (dgv.Cols[dgv.Col].Caption == "尺码")
            {
                //string sql = string.Empty;
//                sql = string.Format(@"select 0 as sel, fchrCode as '代码',fchrValue as '尺码',ROW_NUMBER() over(order by fchrCode) as ID from dbo.ItemAllotAnalysis iaa
//                                      left join item i on iaa.fchritemid = i.fchritemid
//                                      where fchritemcode = '{0}' and fchrFieldName= 'fchrFree1' and 1=1", dgv.Rows[dgv.Row]["fchrItemCode"] != null ? dgv.Rows[dgv.Row]["fchrItemCode"].ToString() : "");

//                sql = string.Format(@"SELECT 0 as sel, fchrCode as '代码',fchrValue as '尺码',(select count(1) from (select i.*,iaa.fchrCode,iaa.fchrValue,iaa.fchrFieldName from dbo.ItemAllotAnalysis iaa
//                                          left join item i on iaa.fchritemid = i.fchritemid) as item where fchrCode <= t.fchrCode) AS ID FROM  
//                                          (select i.*,iaa.fchrCode,iaa.fchrValue,iaa.fchrFieldName from dbo.ItemAllotAnalysis iaa
//                                          left join item i on iaa.fchritemid = i.fchritemid) as t 
//                                          where fchritemcode = '{0}' and fchrFieldName= 'fchrFree1' and 1=1 ", dgv.Rows[dgv.Row]["fchrItemCode"] != null ? dgv.Rows[dgv.Row]["fchrItemCode"].ToString() : "");

                sqlTlbName = string.Format(@"SELECT 0 as sel, fchrCode as '代码',fchrValue as '尺码' FROM  
                                          (select i.*,iaa.fchrCode,iaa.fchrValue,iaa.fchrFieldName from dbo.ItemAllotAnalysis iaa
                                          left join item i on iaa.fchritemid = i.fchritemid) as t 
                                          where fchritemcode = '{0}' and fchrFieldName= 'fchrFree1' and 1=1", dgv.Rows[dgv.Row]["fchrItemCode"] != null ? dgv.Rows[dgv.Row]["fchrItemCode"].ToString() : "");

                sql = string.Format(@"SELECT count(1) FROM  
                                          (select i.*,iaa.fchrCode,iaa.fchrValue,iaa.fchrFieldName from dbo.ItemAllotAnalysis iaa
                                          left join item i on iaa.fchritemid = i.fchritemid) as t 
                                          where fchritemcode = '{0}' and fchrFieldName= 'fchrFree1' and 1=1 ", dgv.Rows[dgv.Row]["fchrItemCode"] != null ? dgv.Rows[dgv.Row]["fchrItemCode"].ToString() : "");

                if (sl_RetailCommom.GetDatas("fbitFree1", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()) == "True")
                {
                    if (dgv.Rows[dgv.Row]["fchrItemCode"] == null)
                    {
                        MessageBox.Show("请先选择商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //先清空自由项值
                        dgv.Rows[dgv.Row]["fchrFree1"] = null;
                        dgv.Rows[dgv.Row]["fchrFree2"] = null;

                        frmItemListRef Free1Ref = new frmItemListRef(sql, sqlTlbName, dgv.Rows[dgv.Row]["fchrFree1"] != null ? dgv.Rows[dgv.Row]["fchrFree1"].ToString() : "", true, "尺码", "", "代码");
                        if (Free1Ref.ShowDialog() == DialogResult.OK)
                        {
                            //自由项多选处理
                            if (Free1Ref.SelTextList.Count > 0)
                            {
                                RowSelIndex = dgv.Row;
                                foreach (string SelText in Free1Ref.SelTextList)
                                {
                                    if (CheckRowIsExists(dgv.Rows[dgv.Row]["fchrItemCode"].ToString(), SelText))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (RowSelIndex <= dgv.Rows.Count - 1)
                                        {
                                            if (dgv.Rows[RowSelIndex]["fchrFree1"] == null && dgv.Rows[RowSelIndex]["fchrItemCode"].ToString() == dgv.Rows[dgv.Row]["fchrItemCode"].ToString())
                                            {
                                                this.dgv.Rows[RowSelIndex]["fchrFree1"] = SelText;
                                                this.dgv.Rows[RowSelIndex]["fchrFree2"] = sl_RetailCommom.GetDatas("fbitFree2", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()) == "True" ? "Z" : "";
                                                if (dgv.Rows[RowSelIndex]["fchrItemCode"] != null)
                                                    SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[RowSelIndex]["fchrItemCode"].ToString()), RowSelIndex);
                                            }
                                            else
                                            {
                                                //复制数据行
                                                CopyDataRow(dgv.Rows[dgv.Row], SelText);
                                                this.dgv.Rows[dgv.Row]["fchrFree2"] = sl_RetailCommom.GetDatas("fbitFree2", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()) == "True" ? "Z" : "";
                                                if (dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"] != null)
                                                    SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"].ToString()), dgv.Rows.Count - 1);
                                            }
                                        }
                                        else
                                        {
                                            //复制数据行
                                            CopyDataRow(dgv.Rows[dgv.Row], SelText);
                                            this.dgv.Rows[dgv.Row]["fchrFree2"] = sl_RetailCommom.GetDatas("fbitFree2", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()) == "True" ? "Z" : "";
                                            if (dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"] != null)
                                                SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"].ToString()), dgv.Rows.Count - 1);
                                        }
                                    }

                                    if (dgv.Rows.Count - 1 - RowSelIndex > 0)
                                        RowSelIndex++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("该商品没有尺码，不需要选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //if (dgv.Rows[dgv.Row]["fchrItemCode"] != null)
                //    SetRowUseQuantity(sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[dgv.Row]["fchrItemCode"].ToString()));
            }

            //dgv.AutoSizeCols();
            RetailCommom.AutoSizeDgvCols(dgv, "JC");
        }

        /// <summary>
        /// 复制数据行，并自动填充自由项的值
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fchrFree1"></param>
        private void CopyDataRow(Row dr,string fchrFree1)
        {
            dgv.Rows.Add();
            for (int c = 1; c < dgv.Cols.Count; c++)
            {
                if (dr[dgv.Cols[c].Name] != null)
                {
                    if (dgv.Cols[c].Name == "fchrFree1")
                    {
                        dgv.Rows[dgv.Rows.Count - 1][dgv.Cols[c].Name] = fchrFree1;
                    }
                    else
                    {
                        if (dgv.Cols[dgv.Cols[c].Name].DataType == typeof(string))
                            dgv.Rows[dgv.Rows.Count - 1][dgv.Cols[c].Name] = dr[dgv.Cols[c].Name].ToString();
                        else if (dgv.Cols[dgv.Cols[c].Name].DataType == typeof(double))
                            dgv.Rows[dgv.Rows.Count - 1][dgv.Cols[c].Name] = Convert.ToDouble(dr[dgv.Cols[c].Name].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 检查是否存在相同存货编码及尺码的数据行存在
        /// </summary>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        private bool CheckRowIsExists(string fchrItemCode,string fchrFree1)
        {
            bool bFlag = false;
            if (dgv.Rows.Count > 1)
            {
                for (int r = 1; r < dgv.Rows.Count; r++)
                {
                    if (dgv.Rows[r]["fchrItemCode"].ToString() == fchrItemCode && (dgv.Rows[r]["fchrFree1"] != null ? dgv.Rows[r]["fchrFree1"].ToString() : "") == fchrFree1)
                    {
                        bFlag = true;
                        break;
                    }
                }
            }

            return bFlag;
        }

        private void tsbDraft_Click(object sender, EventArgs e)
        {
            string ErrMsg = string.Empty;
            string MainID = string.Empty;

            if (dgv.Rows.Count <= 1)
            {
                RetailMessageBox.ShowWarning("表体数据为空，不允许暂存！");
                return;
            }

            if (!CheckDataIsValid(ref ErrMsg))
            {
                RetailMessageBox.ShowInformation(ErrMsg);
                return;
            }

            SaveVoucher(true, ref MainID, ref ErrMsg);

            if (string.IsNullOrEmpty(ErrMsg))
            {
                RetailMessageBox.ShowInformation("单据暂存成功！");
                EmptyAllVoucherData(false);
            }
            else
            {
                RetailMessageBox.ShowInformation("单据暂存失败，原因：" + "\r\n" + ErrMsg);
                return;
            }

            ButtonStatus("LoadForm");
        }

        /// <summary>
        /// 保存单据/暂存单据
        /// </summary>
        /// <param name="fbitTempSave"></param>
        /// <param name="ErrMsg"></param>
        private void SaveVoucher(bool fbitTempSave,ref string MainID, ref string ErrMsg)
        {            
            DataRow dr;
            DataTable dtMain = new DataTable();
            DataTable dtDetail = new DataTable();
            DataTable dtTemp = new DataTable();

            //保存前处理
            //将空行先删除再进行保存
            if (dgv.Rows.Count > 1)
            {
                for (int r = dgv.Rows.Count - 1; r > 0; r--)
                {
                    if (dgv.Rows[r]["fchrItemCode"] == null)
                    {
                        dgv.Rows.Remove(r);
                    }
                }
            }

            dtMain = sl_RetailCommom.GetDateTableSchema("sl_t_RdVouchMain");
            dtDetail = sl_RetailCommom.GetDateTableSchema("sl_t_RdVouchDetail");

            MainID = string.Empty;
            //构建表头数据
            dr = dtMain.NewRow();
            MainID = Guid.NewGuid().ToString();
            dr["MainID"] = MainID;
            dr["fchrCode"] = txtVouchCode.txtText.ToString();
            dr["fchrVouchType"] = "JC";
            dr["fdtmDate"] = dtpVouchDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            dr["fchrWarehouseID"] = sl_RetailCommom.GetDatas("fchrWarehouseID", "storedefine", "fchrstoredefineid", SysPara.Parameters["StoreId"].ToString());
            dr["fchrStoreID"] = SysPara.Parameters["StoreId"].ToString();
            dr["fchrMaker"] = txtMaker.txtText.ToString();
            dr["fchrMemo"] = txtMemo.txtText.ToString();
            dr["fbitTempSave"] = fbitTempSave == true ? 1 : 0;
            dr["fdtmlastmodifytime"] = DateTime.Now;
            dtMain.Rows.Add(dr);
            dtMain.AcceptChanges();

            //构建表体数据
            dtTemp = RetailCommom.GetDetailTable(dgv).Copy();

            if (dtTemp.Rows.Count > 0)
            {
                for (int r = 0; r < dtTemp.Rows.Count; r++)
                {
                    dr = dtDetail.NewRow();
                    dr["MainID"] = MainID;
                    dr["DetailID"] = Guid.NewGuid().ToString();
                    dr["fchrItemID"] = dtTemp.Rows[r]["fchrItemID"].ToString();
                    dr["fchrItemCode"] = dtTemp.Rows[r]["fchrItemCode"].ToString();
                    dr["fchrFree1"] = dtTemp.Rows[r]["fchrFree1"].ToString();
                    dr["fchrFree2"] = dtTemp.Rows[r]["fchrFree2"].ToString();
                    dr["flotQuantity"] = dtTemp.Rows[r]["flotQuantity"].ToString();
                    dr["fchrBodyMemo"] = dtTemp.Rows[r]["fchrBodyMemo"].ToString();
                    dtDetail.Rows.Add(dr);
                    dtDetail.AcceptChanges();
                }
            }

            string TempSaveSql = string.Empty;
            if (fbitTempSave)
                TempSaveSql = string.Format(@" and isnull(fbitTempSave,0) = 1 ");
            else
                TempSaveSql = string.Format(" and 1=1 ");

                //插入前先删除数据
            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, string.Format(@"delete from sl_t_RdVouchDetail where MainID = (select top 1 MainID from sl_t_RdVouchMain where MainID = '{0}' and fchrVouchType = 'JC'{1} ) ", txtVouchCode.txtTag.ToString(), TempSaveSql));
            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, string.Format(@"delete from sl_t_RdVouchMain where MainID = '{0}' and fchrVouchType = 'JC'{1}", txtVouchCode.txtTag.ToString(), TempSaveSql));

            //数据插入处理
            sl_RetailCommom.SqlBulkCopyInsert("sl_t_RdVouchMain", dtMain, SysPara.ConnectionString, ref ErrMsg);
            sl_RetailCommom.SqlBulkCopyInsert("sl_t_RdVouchDetail", dtDetail, SysPara.ConnectionString, ref ErrMsg);

            //if (string.IsNullOrEmpty(ErrMsg))
            //{
            //    RetailMessageBox.ShowInformation("单据暂存成功！");
            //}
            //else
            //{
            //    RetailMessageBox.ShowInformation("单据暂存失败，原因：" + ErrMsg);
            //    return;
            //}
        }

        private void tsbEmpty_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
                dgv.Rows.RemoveRange(1, dgv.Rows.Count - 1);
        }

        /// <summary>
        /// 取得商品的可用量
        /// </summary>
        /// <param name="dr"></param>
        public void SetRowUseQuantity(string fchrItemID,int rowindex)
        {
            StringBuilder objWhere = new StringBuilder();
            if (string.IsNullOrEmpty(fchrItemID))
                return;

            if (dgv.Rows[rowindex]["fchrFree1"] != null)
            {
                if (!string.IsNullOrEmpty(objWhere.ToString())) objWhere.Append(" And");
                objWhere.AppendFormat(" isnull(fchrFree1,'') ='{0}' ", dgv.Rows[rowindex]["fchrFree1"].ToString());
            }

            if (dgv.Rows[dgv.Row]["fchrFree2"] != null)
            {
                if (!string.IsNullOrEmpty(objWhere.ToString())) objWhere.Append(" And");
                objWhere.AppendFormat(" isnull(fchrFree2,'') ='{0}' ", dgv.Rows[rowindex]["fchrFree2"].ToString());
            }

            dgv.Rows[rowindex]["flotCurStock"] = BusinessHelper.GetUseQuantity(fchrItemID, objWhere.ToString());
        }

        /// <summary>
        /// 检查数据是否合法
        /// </summary>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        private bool CheckDataIsValid(ref string ErrMsg)
        {
            bool bFlag = true;

            //检查单据编号是否为空
            if (string.IsNullOrEmpty(txtVouchCode.txtText))
            {
                ErrMsg = "【单据编号】不允许为空！";
                bFlag = false;
            }

            //检查明细行中的借出数量是否为空
            if (bFlag)
            {
                if (dgv.Rows.Count > 1)
                {
                    for (int r = 1; r < dgv.Rows.Count; r++)
                    {
                        if (dgv.Rows[r]["flotQuantity"] == null)
                        {
                            ErrMsg = "第" + r + "行记录借出数量不允许为空！";
                            bFlag = false;
                            break;
                        }
                    }
                }
            }

            //检查各行明细自由项是否合法
            if (bFlag)
            {
                if (dgv.Rows.Count > 1)
                {
                    for (int r = 1; r < dgv.Rows.Count; r++)
                    {
                        if (sl_RetailCommom.GetDatas("fbitFree1", "Item", "fchrItemCode", dgv.Rows[r]["fchrItemCode"].ToString()) == "True" && dgv.Rows[r]["fchrFree1"] == null)
                        {
                            ErrMsg = "第" + r + "行记录自由项不合法，尺码不能为空！";
                            bFlag = false;
                            break;
                        }

                        if (bFlag)
                        {
                            if (sl_RetailCommom.GetDatas("fbitFree2", "Item", "fchrItemCode", dgv.Rows[r]["fchrItemCode"].ToString()) == "True" && dgv.Rows[r]["fchrFree2"] == null)
                            {
                                ErrMsg = "第" + r + "行记录自由项不合法，裤袖长不能为空！";
                                bFlag = false;
                                break;
                            }
                        }
                    }
                }
            }

            //检查借出数量是否大于门店库存量
            if (bFlag)
            {
                if (dgv.Rows.Count > 1)
                {
                    for (int r = 1; r < dgv.Rows.Count; r++)
                    {
                        if (Convert.ToInt32(dgv.Rows[r]["flotQuantity"]) > Convert.ToInt32(dgv.Rows[r]["flotCurStock"]))
                        {
                            ErrMsg = "第" + r + "行数据借出数量大于【门店库存量】！";
                            //dgv.Rows[r]["flotQuantity"] = 0;
                            dgv.RowSel = r;
                            bFlag = false;
                            break;
                        }
                    }
                }
            }

            //检查明细行中的借出数量是否为0
            if (bFlag)
            {
                if (dgv.Rows.Count > 1)
                {
                    for (int r = 1; r < dgv.Rows.Count; r++)
                    {
                        if (Convert.ToInt32(dgv.Rows[r]["flotQuantity"].ToString()) == 0)
                        {
                            ErrMsg = "第" + r + "行记录归还数量不允许为0！";
                            bFlag = false;
                            break;
                        }
                    }
                }
            }

            return bFlag;
        }

        private void dgv_CellChanged(object sender, RowColEventArgs e)
        {
            //if (dgv.Row > 0 && dgv.Cols[e.Col].Name == "flotQuantity")
            //{
            //    if (Convert.ToInt32(dgv.Rows[dgv.Row]["flotQuantity"]) > Convert.ToInt32(dgv.Rows[dgv.Row]["flotCurStock"]))
            //    {
            //        RetailMessageBox.ShowWarning("借出数量不能大于【门店库存量】！");
            //        dgv.Rows[dgv.Row]["flotQuantity"] = 0;
            //        return;
            //    }
            //}
        }

        private void tsbNewVoucher_Click(object sender, EventArgs e)
        {
            //清空数据
            EmptyAllVoucherData(true);
            ButtonStatus("btnNewVoucher");
        }

        /// <summary>
        /// 按钮状态控制
        /// </summary>
        /// <param name="strButtonName"></param>
        private void ButtonStatus(string strButtonName)
        {
            switch (strButtonName)
            { 
                case "LoadForm":
                    if (!string.IsNullOrEmpty(_SelectedVouchCode))
                    {
                        if (_CurrentStatus == "Modify") //修改状态
                        {
                            tsbNewVoucher.Enabled = true;
                            tsbNew.Enabled = true;
                            tsbDel.Enabled = true;
                            tsbCopyRow.Enabled = true;
                            tsbDraft.Enabled = true;
                            tsbSave.Enabled = true;
                            tsbScan.Enabled = true;
                            tsbPrint.Enabled = false;
                            tsbSettings.Enabled = false;
                            //tsbExport.Enabled = false;
                            tsbEmpty.Enabled = false;
                            tsbCancel.Enabled = true;
                            tsbModify.Enabled = false;

                            dgv.AllowEditing = true;
                            dtpVouchDate.Enabled = true;
                            txtMemo.txtReadOnly = false;
                        }
                        else if (_CurrentStatus == "View") //查看状态
                        {
                            tsbNewVoucher.Enabled = false;
                            tsbNew.Enabled = false;
                            tsbDel.Enabled = false;
                            tsbCopyRow.Enabled = false;
                            tsbDraft.Enabled = false;
                            tsbSave.Enabled = false;
                            tsbScan.Enabled = false;
                            tsbPrint.Enabled = true;
                            tsbSettings.Enabled = true;
                            //tsbExport.Enabled = true;
                            tsbEmpty.Enabled = false;
                            tsbCancel.Enabled = false;
                            tsbModify.Enabled = false;

                            dgv.AllowEditing = false;
                            dtpVouchDate.Enabled = false;
                            txtMemo.txtReadOnly = true;
                        }
                    }
                    else //新增状态
                    {
                        tsbNewVoucher.Enabled = true;
                        tsbNew.Enabled = false;
                        tsbDel.Enabled = false;
                        tsbCopyRow.Enabled = false;
                        tsbDraft.Enabled = false;
                        tsbSave.Enabled = false;
                        tsbScan.Enabled = false;
                        tsbPrint.Enabled = false;
                        //tsbExport.Enabled = false;
                        tsbEmpty.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbSettings.Enabled = false;
                    }
                    break;
                case "btnNewVoucher":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbCopyRow.Enabled = false;
                    tsbDel.Enabled = false;
                    tsbDraft.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbScan.Enabled = true;
                    tsbPrint.Enabled = false;
                    tsbSettings.Enabled = false;
                    //tsbExport.Enabled = false;
                    tsbEmpty.Enabled = false;
                    tsbCancel.Enabled = true;
                    tsbModify.Enabled = false;

                    dgv.AllowEditing = true;
                    dtpVouchDate.Enabled = true;
                    txtMemo.txtReadOnly = false;

                    break;
                case "btnInsertRow":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbCopyRow.Enabled = true;
                    tsbDraft.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbScan.Enabled = true;
                    tsbPrint.Enabled = false;
                    tsbSettings.Enabled = false;
                    //tsbExport.Enabled = false;
                    tsbEmpty.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbModify.Enabled = false;
                    break;
                case "btnDelRow":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbCopyRow.Enabled = true;
                    tsbDraft.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbScan.Enabled = true;
                    tsbPrint.Enabled = false;
                    tsbSettings.Enabled = false;
                    //tsbExport.Enabled = false;
                    tsbCancel.Enabled = true;
                    tsbModify.Enabled = false;
                    if (dgv.Rows.Count > 1)
                    {
                        tsbEmpty.Enabled = true;
                    }
                    else
                    {
                        tsbEmpty.Enabled = false;
                    }
                    break;
                case "btnCancel":
                    if (!string.IsNullOrEmpty(_SelectedVouchCode))  //列表联查
                    {
                        if (_CurrentStatus == "Modify") //修改状态
                        {
                            tsbNewVoucher.Enabled = true;
                            tsbNew.Enabled = false;
                            tsbDel.Enabled = false;
                            tsbCopyRow.Enabled = false;
                            tsbDraft.Enabled = false;
                            tsbSave.Enabled = false;
                            tsbScan.Enabled = false;
                            tsbPrint.Enabled = true;
                            tsbSettings.Enabled = true;
                            //tsbExport.Enabled = true;
                            tsbEmpty.Enabled = false;
                            tsbCancel.Enabled = false;
                            tsbModify.Enabled = true;

                            dgv.AllowEditing = true;
                            dtpVouchDate.Enabled = true;
                            txtMemo.txtReadOnly = false;
                        }
                    }
                    else //新增状态
                    {
                        //清空数据
                        EmptyAllVoucherData(false);

                        tsbNewVoucher.Enabled = true;
                        tsbNew.Enabled = false;
                        tsbDel.Enabled = false;
                        tsbCopyRow.Enabled = false;
                        tsbDraft.Enabled = false;
                        tsbSave.Enabled = false;
                        tsbScan.Enabled = false;
                        tsbPrint.Enabled = false;
                        tsbSettings.Enabled = false;
                        //tsbExport.Enabled = false;
                        tsbEmpty.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbModify.Enabled = false;
                    }
                    break;
                case "btnModify":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbCopyRow.Enabled = true;
                    tsbDraft.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbScan.Enabled = true;
                    tsbPrint.Enabled = false;
                    tsbSettings.Enabled = false;
                    //tsbExport.Enabled = false;
                    tsbEmpty.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbModify.Enabled = false;
                    break;
                //case "btnTempSave":
                //    tsbNewVoucher.Enabled = false;
                //    tsbNew.Enabled = true;
                //    tsbDel.Enabled = true;
                //    tsbDraft.Enabled = true;
                //    tsbSave.Enabled = true;
                //    tsbScan.Enabled = true;
                //    tsbPrint.Enabled = false;
                //    tsbExport.Enabled = false;
                //    tsbEmpty.Enabled = true;
                //    break;
                //case "btnSave":
                //    tsbNewVoucher.Enabled = false;
                //    tsbNew.Enabled = true;
                //    tsbDel.Enabled = true;
                //    tsbDraft.Enabled = true;
                //    tsbSave.Enabled = true;
                //    tsbScan.Enabled = true;
                //    tsbPrint.Enabled = false;
                //    tsbExport.Enabled = false;
                //    tsbEmpty.Enabled = true;
                //    break;
            }
        }

        /// <summary>
        /// 清空所有单据数据
        /// </summary>
        public void EmptyAllVoucherData(bool bGenNewVoucher)
        {
            if (!bGenNewVoucher)  //如果非新单据
            {
                //清空表头数据
                txtVouchCode.txtText = "";
                txtVouchCode.txtTag = null;
                dtpVouchDate.Value = DateTime.Now;
                txtMemo.txtText = "";
            }
            else  //新增单据
            {
                //清空表头数据
                txtVouchCode.txtText = sl_RetailCommom.GenNewVouchCode("JC", "sl_t_RdVouchMain", "fchrCode");
                txtVouchCode.txtTag = Guid.NewGuid().ToString();
                dtpVouchDate.Value = DateTime.Now;
                txtMemo.txtText = "";
            }

            //清空表体数据
            if (dgv.Rows.Count > 1)
            {
                dgv.Rows.RemoveRange(1, dgv.Rows.Count - 1);
            }
        }

        /// <summary>
        /// 填充单据数据
        /// </summary>
        /// <param name="ds"></param>
        private void FillVouchData(DataSet ds)
        {
            DataTable dtMain = new DataTable();
            DataTable dtDetail = new DataTable();

            if (ds.Tables.Count == 2)
            {
                dtMain = ds.Tables[0];
                dtDetail = ds.Tables[1];

                //表头数据填充
                txtVouchCode.txtTag = dtMain.Rows[0]["MainID"].ToString();
                txtVouchCode.txtText = dtMain.Rows[0]["fchrCode"].ToString();
                txtMaker.txtText = dtMain.Rows[0]["fchrMaker"].ToString();
                dtpVouchDate.Value = Convert.ToDateTime(dtMain.Rows[0]["fdtmDate"].ToString());
                txtMemo.txtText = dtMain.Rows[0]["fchrMemo"].ToString();

                //表体数据填充
                if (dtDetail.Rows.Count > 0)
                {
                    for (int r = 0; r < dtDetail.Rows.Count; r++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[r + 1]["fchrItemCode"] = dtDetail.Rows[r]["fchrItemCode"].ToString();
                        dgv.Rows[r + 1]["fchrItemName"] = sl_RetailCommom.GetDatas("fchrItemName", "Item", "fchrItemID", dtDetail.Rows[r]["fchrItemID"].ToString());
                        dgv.Rows[r + 1]["fchrFree1"] = dtDetail.Rows[r]["fchrFree1"].ToString();
                        dgv.Rows[r + 1]["fchrFree2"] = dtDetail.Rows[r]["fchrFree2"].ToString();
                        SetRowUseQuantity(dtDetail.Rows[r]["fchrItemID"].ToString(), r + 1);
                        dgv.Rows[r + 1]["fchrUnitName"] = sl_RetailCommom.GetDatas("fchrUnitName", "Item", "fchrItemID", dtDetail.Rows[r]["fchrItemID"].ToString());
                        dgv.Rows[r + 1]["flotQuantity"] = dtDetail.Rows[r]["flotQuantity"].ToString();
                        dgv.Rows[r + 1]["flotReturnQty"] = RetailCommom.GetReturnQtySum(txtVouchCode.txtText.Trim(), dtDetail.Rows[r]["fchrItemCode"].ToString(), dtDetail.Rows[r]["fchrFree1"].ToString());
                        //dgv.Rows[r + 1]["flotCurStock"] = 0;
                        dgv.Rows[r + 1]["fchrBodyMemo"] = dtDetail.Rows[r]["fchrBodyMemo"].ToString();
                    }
                }

                RetailCommom.AutoSizeDgvCols(dgv, "JC");
            }
            else
            {
                RetailMessageBox.ShowInformation("单据数据加载出现异常，请检查单据数据！");
                return;
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_SelectedVouchCode)) //新增状态
            {
                //清空数据
                EmptyAllVoucherData(false);
            }

            ButtonStatus("btnCancel");
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            ButtonStatus("btnModify");
        }

        private void dgv_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 113)
            {
                if (dgv.Rows.Count > 1 && dgv.Cols[dgv.Col].Name == "fchrItemCode")
                {
                    dgv_CellButtonClick(sender, null);
                }
            }
        }

        private void tsbCopyRow_Click(object sender, EventArgs e)
        {
            if (dgv.Row > 0)
            {
                CopyDataRow(dgv.Rows[dgv.Row], null);
            }
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            frmPrintType frm = new frmPrintType(SysPara.ConnectionString, SysPara.GetString("操作员ID"), "借出单");
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RetailMessageBox.ShowInformation("打印设置成功！");
                //frmPrint frm1 = new frmPrint(cCode, cCodeType, conStr, printTemplateType, frm.PrintID, SysPara.GetString("操作员ID"));
                //frm1.ShowDialog();
            }
        }

        
    }
}
