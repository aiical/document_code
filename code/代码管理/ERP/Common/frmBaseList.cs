using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization;

namespace Common
{
    public partial class frmBaseList : BaseClass.frmBase
    {
        protected string strQuerySQL = "";
        protected string strTable, strKey;
        private string strTVType;
        protected int intImport = 0;  //导入标志

        public frmBaseList()
        {
            InitializeComponent();
            gvBase.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(FocusedRowChange);
        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        protected bool TestRight(string strName)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + this.Name + "' and F_Name = '" + strName + "' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("对不起，你无权限!!", "提示");
                return false;
            }
            else
                return true;
        }


        protected virtual void ImportExcel()
        {

            System.Data.DataTable dt = DataLib.sysClass.ImportExcel("Sheet1");
            if (dt == null) return;

            if (MessageBox.Show(this, "引入Excel资料需要一定时间，进行本操作吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

             BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
             myFlag.label1.Text = "正在引入数据，请稍待......";
             myFlag.Show();
             myFlag.Update();
             try
             {
                 switch (intImport)
                 {
                     case 1:
                         ImportSupplier(dt);
                         break;
                     case 2:
                         ImportClient(dt);
                         break;
                     case 3:
                         ImportEmp(dt);
                         break;
                     case 4:
                         ImportItem(dt);
                         break;
                     case 5:
                         ImportProduct(dt);
                         break;
                     case 6:
                         ImportOutSupplier(dt);
                         break;
                     case 7:
                         //ImportBom(values);
                         //ImportBomDetail(values1);
                         break;
                 }

             }
             finally
             {
                 myFlag.Dispose();
             }
        }


        
        
        /// <summary>
        /// 导入Bom单主表资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportBom(System.Array values)
        {
            int len1 = values.GetLength(0);
            int len2 = values.GetLength(1);

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsBom = myHelper.GetDs("select * from t_Bom");

            System.Data.DataTable dt = dsBom.Tables[0];
            System.Data.DataTable dtTmp = dt.Copy();
            dt.Columns["F_BillID"].Unique = true;

            string strID;

            try
            {
                for (int i = 1; i < len1; i++)
                {
                    strID = values.GetValue(i, 1).ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_BillID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的BOM单号,请检查待导入Excel文件!", "提示");
                        break;
                    }
                    DataRow drNew = dsBom.Tables[0].NewRow();
                    drNew["F_BillID"] = values.GetValue(i, 1).ToString();
                    if (values.GetValue(i, 2).ToString().Length == 0)
                        drNew["F_Date"] = "1900-1-1";
                    else
                        drNew["F_Date"] = values.GetValue(i, 2).ToString();
                    drNew["F_ItemID"] = values.GetValue(i, 3).ToString();
                    drNew["F_Remark"] = values.GetValue(i, 4).ToString();

                    dsBom.Tables[0].Rows.Add(drNew);
                }

                myHelper.SaveData(dsBom, "select * from t_Bom");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "错误");
            }
        }

          /// <summary>
        /// 导入Bom单主表资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportBomDetail(System.Array values)
        {
            int len1 = values.GetLength(0);
            int len2 = values.GetLength(1);

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsBom = myHelper.GetDs("select * from t_BomDetail");

            System.Data.DataTable dt = dsBom.Tables[0];
            System.Data.DataTable dtTmp = dt.Copy();
            //dt.Columns["F_BillID"].Unique = true;

            string strID;

            try
            {
                for (int i = 1; i < len1; i++)
                {
                    strID = values.GetValue(i, 1).ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_BillID = '" + strID + "' and ").Length > 0)
                    {
                        MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的BOM单号,请检查待导入Excel文件!", "提示");
                        break;
                    }
                    DataRow drNew = dsBom.Tables[0].NewRow();
                    drNew["F_BillID"] = values.GetValue(i, 1).ToString();
                    drNew["AID"] = values.GetValue(i, 2).ToString();
                    drNew["F_ItemID"] = values.GetValue(i, 3).ToString();
                    drNew["F_Qty"] = values.GetValue(i, 4).ToString();
                    drNew["F_Waste"] = values.GetValue(i, 5).ToString();
                    drNew["F_DeptID"] = values.GetValue(i, 6).ToString();
                    drNew["F_ProcessID"] = values.GetValue(i, 6).ToString();

                    dsBom.Tables[0].Rows.Add(drNew);
                }

                myHelper.SaveData(dsBom, "select * from t_BomDetail");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "错误");
            }
        }

        
        /// <summary>
        /// 导入供应商资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportSupplier(System.Data.DataTable values)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs("select * from t_Supplier");

            System.Data.DataTable dt = dsEmp.Tables[0];
            System.Data.DataTable dtTmp = dt.Copy();
            dt.Columns["F_ID"].Unique = true;

            string strID;

            try
            {
                foreach(DataRow dr in values.Rows)
                {
                    strID = dr["供应商编码"].ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的供应商,请检查待导入Excel文件!", "提示");
                        break;
                    }
                    DataRow drNew = dsEmp.Tables[0].NewRow();
                    drNew["F_ID"] = dr["供应商编码"].ToString();
                    drNew["F_Name"] = dr["供应商名称"].ToString();
                    drNew["F_Type"] = dr["类别编码"].ToString();
                    drNew["F_LinkMan"] = dr["联系人"].ToString();
                    drNew["F_Tel"] = dr["联系电话"].ToString();
                    drNew["F_OtherTel"] = dr["其它电话"].ToString();
                    drNew["F_Bank"] = dr["开户银行"].ToString();
                    drNew["F_BankNo"] = dr["银行帐号"].ToString();
                    drNew["F_PostCode"] = dr["邮编"].ToString();
                    drNew["F_Adr"] = dr["地址"].ToString();
                    drNew["F_Remark"] = dr["备注"].ToString();
                    drNew["F_Use"] = true;

                    if (dr["期初金额"] == DBNull.Value)
                        drNew["F_QcMoney"] = 0;
                    else
                        drNew["F_QcMoney"] = Convert.ToDecimal(dr["期初金额"]);

                    if (dr["预付金额"] == DBNull.Value)
                        drNew["F_PreMoney"] = 0;
                    else
                        drNew["F_PreMoney"] = Convert.ToDecimal(dr["预付金额"]);

                    dsEmp.Tables[0].Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Supplier");
            }
            catch (Exception E)
            {
                MessageBox.Show(this,E.Message, "错误");
            }
        }

        /// <summary>
        /// 导入客户资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportClient(System.Data.DataTable values)
        {

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs("select * from t_Client");

            System.Data.DataTable dt = dsEmp.Tables[0];
            System.Data.DataTable dtTmp = dt.Copy();
            dt.Columns["F_ID"].Unique = true;

            string strID;

            try
            {
                foreach (DataRow dr in values.Rows)
                {
                    strID = dr["客户编码"].ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的客户,请检查待导入Excel文件!", "提示");
                        break;
                    }
                    DataRow drNew = dsEmp.Tables[0].NewRow();
                    drNew["F_ID"] = dr["客户编码"].ToString();
                    drNew["F_Name"] = dr["客户名称"].ToString();
                    drNew["F_Type"] = dr["类别编码"].ToString();
                    drNew["F_Opertor"] = dr["业务员编码"].ToString();
                    drNew["F_LinkMan"] = dr["联系人1"].ToString();
                    drNew["F_Tel"] = dr["联系电话1"].ToString();

                    drNew["F_LinkMan1"] = dr["联系人2"].ToString();
                    drNew["F_Tel1"] = dr["联系电话2"].ToString();
                    drNew["F_LinkMan2"] = dr["联系人3"].ToString();
                    drNew["F_Tel2"] = dr["联系电话3"].ToString();

                    drNew["F_Fax"] = dr["传真"].ToString();
                    drNew["F_Bank"] = dr["开户银行"].ToString();
                    drNew["F_BankNo"] = dr["银行帐号"].ToString();
                    drNew["F_Adr"] = dr["地址"].ToString();
                    drNew["F_PostCode"] = dr["邮编"].ToString();
                    drNew["F_Legal"] = dr["法人代表"].ToString();
                    drNew["F_QQ"] = dr["QQ"].ToString();
                    drNew["F_Email"] = dr["EMail"].ToString();
                    drNew["F_Source"] = dr["客户来源"].ToString();
                    drNew["F_CarryCompany"] = dr["货运公司编码"].ToString();
                    drNew["F_Remark"] = dr["备注"].ToString();

                    drNew["F_Use"] = true;

                    if (dr["信用额"] == DBNull.Value)
                        drNew["F_ClientXinyong"] = 0;
                    else
                        drNew["F_ClientXinyong"] = Convert.ToDecimal(dr["信用额"]);

                    if (dr["期初余额"] == DBNull.Value)
                        drNew["F_QcMoney"] = 0;
                    else
                        drNew["F_QcMoney"] = Convert.ToDecimal(dr["期初余额"]);

                    if (dr["期初已收"] == DBNull.Value)
                        drNew["F_QcHasMoney"] = 0;
                    else
                        drNew["F_QcHasMoney"] = Convert.ToDecimal(dr["期初已收"]);

                    if (dr["预收款"] == DBNull.Value)
                        drNew["F_PreMoney"] = 0;
                    else
                        drNew["F_PreMoney"] = Convert.ToDecimal(dr["预收款"]);

                    if (dr["欠款"] == DBNull.Value)
                        drNew["F_NeedMoney"] = 0;
                    else
                        drNew["F_NeedMoney"] = Convert.ToDecimal(dr["欠款"]);

                    if (dr["已收款"] == DBNull.Value)
                        drNew["F_HasMoney"] = 0;
                    else
                        drNew["F_HasMoney"] = Convert.ToDecimal(dr["已收款"]);

                    drNew["F_Builder"] = DataLib.SysVar.strUName;
                    drNew["F_BuildDate"] = DataLib.SysVar.GetDate();

                    dsEmp.Tables[0].Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Client");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "错误");
            }
        }


        /// <summary>
        /// 导入职员资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportEmp(System.Data.DataTable values)
        {

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs("select * from t_Emp");

            System.Data.DataTable dt = dsEmp.Tables[0];
            System.Data.DataTable dtTmp = dt.Copy();
            dt.Columns["F_ID"].Unique = true;

            string strID;

            try
            {
                foreach (DataRow dr in values.Rows)
                {
                    strID = dr["编码"].ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的员工,请检查待导入Excel文件!", "提示");
                        break;
                    }
                    DataRow drNew = dt.NewRow();
                    drNew["F_ID"] = dr["编码"];
                    drNew["F_Name"] = dr["姓名"];
                    drNew["F_Sex"] = dr["性别"];
                    drNew["F_Type"] = dr["部门编码"];
                    if (dr["出生日期"] == DBNull.Value)
                        drNew["F_BornDate"] = Convert.ToDateTime("1900-1-1");
                    else
                        drNew["F_BornDate"] = dr["出生日期"];

                    drNew["F_Knowlege"] = dr["学历"];
                    drNew["F_Tel"] = dr["联系电话"];
                    drNew["F_OtherTel"] = dr["其它电话"];

                    drNew["F_Wage"] = dr["基本工资"];

                    drNew["F_IDCard"] = dr["身份证号"];
                    drNew["F_Adr"] = dr["住址"];
                    drNew["F_Remark"] = dr["备注"];
                    if (dr["业务员标志"] == DBNull.Value)
                        drNew["F_Opertor"] = false;
                    else
                        drNew["F_Opertor"] = true;
                    drNew["F_Email"] = dr["Email"];
                    dt.Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Emp");
            }
            catch (Exception E)
            {
                MessageBox.Show(this,E.Message,"错误");
            }
        }


        /// <summary>
        /// 导入原材料资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportItem(System.Data.DataTable values)
        {

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs("select * from t_Item");
            DataSet dsUnit = myHelper.GetDs("select * from t_Unit");

            System.Data.DataTable dt = dsEmp.Tables[0];
            System.Data.DataTable dtTmp = dt.Copy();
            dt.Columns["F_ID"].Unique = true;

            string strID;

            try
            {
                foreach (DataRow dr in values.Rows)
                {
                    strID = dr["材料编码"].ToString();
                    if (strID == "") continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的物料,请检查待导入Excel文件!", "提示");
                        break;
                    }
                    DataRow drNew = dt.NewRow();
                    drNew["F_ID"] = dr["材料编码"];
                    drNew["F_Name"] = dr["材料名称"];
                    drNew["F_Spec"] = dr["规格"];
                    drNew["F_Brand"] = dr["品牌"];
                    drNew["F_Type"] =dr["类别编码"];
                    drNew["F_Kind"] = dr["属性"];
                    DataRow drUnit = dsUnit.Tables[0].NewRow();
                    drUnit["F_ItemID"] = dr["材料编码"];
                    drUnit["F_Name"] = dr["单位"];
                    drUnit["F_Rate"] = 1;
                    drUnit["F_Main"] = true;
                    dsUnit.Tables[0].Rows.Add(drUnit);
                    drNew["F_Grade"] = dr["等级"];
                    drNew["F_Color"] = dr["颜色"];
                    drNew["F_StorageID"] = dr["默认仓库编码"];

                    drNew["F_StockPrice"] = dr["默认进货价"];
                    drNew["F_StockPrice1"] = dr["进价1"];
                    drNew["F_StockPrice2"] = dr["进价2"];
                    drNew["F_StockPrice3"] = dr["进价3"];
                    drNew["F_StockPrice4"] = dr["进价4"];
                    drNew["F_UpLimit"] = dr["库存上限"];
                    drNew["F_DownLimit"] = dr["库存下限"];
                    drNew["F_SafeQty"] = dr["安全库存"];
                    drNew["F_Remark"] = dr["备注"];


                    drNew["F_Material"] = dr["材质"];

                    drNew["F_Attrib"] = "原材料";

                    drNew["F_CalStorage"] = true;

                    dt.Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Item");
                myHelper.SaveData(dsUnit, "select * from t_Unit");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "错误");
            }
        }


        /// <summary>
        /// 导入产品资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportProduct(System.Data.DataTable values)
        {
           DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs("select * from t_Item");
            DataSet dsUnit = myHelper.GetDs("select * from t_Unit");

            System.Data.DataTable dt = dsEmp.Tables[0];
            System.Data.DataTable dtTmp = dt.Copy();
            dt.Columns["F_ID"].Unique = true;

            string strID;

            try
            {
                foreach (DataRow dr in values.Rows)
                {
                    strID = dr["产品编码"].ToString();
                    if (strID == "") continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的产品,请检查待导入Excel文件!", "提示");
                        break;
                    }
                    DataRow drNew = dt.NewRow();
                    drNew["F_ID"] = dr["产品编码"];
                    drNew["F_Name"] = dr["产品名称"];
                    drNew["F_Spec"] = dr["规格"];
                    drNew["F_Brand"] = dr["品牌"];
                    drNew["F_Type"] =dr["类别编码"];
                    drNew["F_Kind"] = dr["属性"];
                    DataRow drUnit = dsUnit.Tables[0].NewRow();
                    drUnit["F_ItemID"] = dr["产品编码"];
                    drUnit["F_Name"] = dr["单位"];
                    drUnit["F_Rate"] = 1;
                    drUnit["F_Main"] = true;
                    dsUnit.Tables[0].Rows.Add(drUnit);
                    drNew["F_Grade"] = dr["等级"];
                    drNew["F_Color"] = dr["颜色"];
                    drNew["F_StorageID"] = dr["默认仓库编码"];

                    drNew["F_StockPrice"] = dr["默认售价"];
                    drNew["F_StockPrice1"] = dr["售价1"];
                    drNew["F_StockPrice2"] = dr["售价2"];
                    drNew["F_StockPrice3"] = dr["售价3"];
                    drNew["F_StockPrice4"] = dr["售价4"];
                    drNew["F_UpLimit"] = dr["库存上限"];
                    drNew["F_DownLimit"] = dr["库存下限"];
                    drNew["F_SafeQty"] = dr["安全库存"];
                    drNew["F_Remark"] = dr["备注"];


                    drNew["F_Material"] = dr["材质"];

                    drNew["F_Attrib"] = "成品";

                    drNew["F_CalStorage"] = true;

                    dt.Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Item");
                myHelper.SaveData(dsUnit, "select * from t_Unit");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "错误");
            }
        }

        /// <summary>
        /// 导入外加工厂商资料
        /// </summary>
        /// <param name="values"></param>
        private void ImportOutSupplier(System.Data.DataTable values)
        {
           
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs("select * from t_OutSupplier");
            System.Data.DataTable dt = dsEmp.Tables[0];
            dt.Columns["F_ID"].Unique = true;

            string strID = "";
            foreach (DataRow dr in values.Rows)
            {
                strID = dr["厂商编码"].ToString();
                if (strID == "") continue;
                if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                {
                    MessageBox.Show(this, "数据库已存在编码为'" + strID + "'的外加工厂商,请检查待导入Excel文件!", "提示");
                    break;
                }

                DataRow drNew = dt.NewRow();
                drNew["F_ID"] = strID;
                drNew["F_Name"] = dr["厂商名称"];
                drNew["F_Type"] = dr["类别编码"];
                drNew["F_LinkMan"] = dr["联系人"];
                drNew["F_Tel"] = dr["电话"];
                drNew["F_OtherTel"] = dr["其它电话"];
                drNew["F_Bank"] = dr["银行"];
                drNew["F_BankNo"] = dr["银行帐号"];
                drNew["F_PostCode"] = dr["邮编"];
                drNew["F_Adr"] = dr["地址"];
                drNew["F_Remark"] = dr["备注"];
                drNew["F_Use"] = true;

                drNew["F_QcMoney"] = dr["期初"];
                drNew["F_PreMoney"] = dr["预付"];

                dt.Rows.Add(drNew);
            }

            myHelper.SaveData(dsEmp, "select * from t_OutSupplier");

        }


        /// <summary>
        /// 行顺序改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FocusedRowChange(object Sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        /// <summary>
        /// 复制资料
        /// </summary>
        protected virtual void CopyData()
        {

        }

        /// <summary>
        /// 刷新
        /// </summary>
        protected virtual void refresh()
        {
            tvType.Nodes.Clear();
            FillTv(strTVType, null);
            tvType.SelectedNode = tvType.TopNode;
            tvType.TopNode.Expand();
        }


        private Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            if (tvType.SelectedNode.Level == 0)
                parm.Add("@Value", "");
            else
                parm.Add("@Value", tvType.SelectedNode.Tag + "%");

            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Value";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            if (tvType.SelectedNode.Parent == null)
                parm[0].Value = "";
            else
                parm[0].Value = tvType.SelectedNode.Tag;
            */
            return parm;
        }

        /// <summary>
        /// 取得分组数
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        private GridGroupSummaryItem GetGroupType(string strField)
        {
            GridGroupSummaryItem GiResult = null;
            foreach (GridGroupSummaryItem Gi in gvBase.GroupSummary)
            {
                if (Gi.FieldName == strField)
                {
                    GiResult = Gi;
                    break;
                }
            }
            return GiResult;
        }

        /// <summary>
        /// 设置单据明细字段
        /// </summary>
        private void AssignField()
        {
            
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsGrid = myHelper.GetDs("select * from t_GridFormat where F_Class = '" + this.Name + "' and F_Tag = '0'");
            if (dsGrid.Tables[0].Rows.Count > 0)
            {
                gvBase.OptionsCustomization.AllowFilter = Convert.ToBoolean(dsGrid.Tables[0].Rows[0]["F_AllowFilter"]);
                gvBase.OptionsView.AllowCellMerge = Convert.ToBoolean(dsGrid.Tables[0].Rows[0]["F_AllowMerge"]);
                gvBase.OptionsView.ShowFooter = Convert.ToBoolean(dsGrid.Tables[0].Rows[0]["F_AllowSum"]);
                gvBase.OptionsView.ShowGroupPanel = Convert.ToBoolean(dsGrid.Tables[0].Rows[0]["F_AllowPanel"]);
                gvBase.OptionsView.ColumnAutoWidth = Convert.ToBoolean(dsGrid.Tables[0].Rows[0]["F_AutoWidth"]);
            }
            dsGrid.Dispose();
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + this.Name + "' and F_Tag = '0' order by F_Order");
            if (ds.Tables[0].Rows.Count == 0) return;
            gvBase.GroupSummary.Clear();
            gvBase.Columns.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GridColumn gc = gvBase.Columns.AddField(dr["F_Field"].ToString());
                gc.Caption = dr["F_Caption"].ToString();
                gc.Width = Convert.ToInt32(dr["F_Width"]);
                gc.Visible = Convert.ToBoolean(dr["F_Visible"]);

                switch (dr["F_SumType"].ToString())
                {
                    case "sum":
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        break;
                    case "avg":
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                        break;
                    case "count":
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        break;
                    case "max":
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                        break;
                    case "min":
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;
                        break;

                }

                if (Convert.ToBoolean(dr["F_Edit"]) == false)
                {
                    //gc.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                    gc.OptionsColumn.AllowFocus = false;
                    gc.OptionsColumn.AllowEdit = false;
                }

                if (Convert.ToBoolean(dr["F_Merge"]) == true)
                    gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                else
                    gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                

                gc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                if (gc.FieldName == "Aid")
                {
                    gc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                if (dr["F_GroupType"].ToString().Length > 0)
                {
                    GridGroupSummaryItem Gi = new GridGroupSummaryItem();
                    switch (dr["F_GroupType"].ToString())
                    {
                        case "sum":
                            Gi.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            break;
                        case "avg":
                            Gi.SummaryType = DevExpress.Data.SummaryItemType.Average;
                            break;
                        case "count":
                            Gi.SummaryType = DevExpress.Data.SummaryItemType.Count;
                            break;
                        case "max":
                            Gi.SummaryType = DevExpress.Data.SummaryItemType.Max;
                            break;
                        case "min":
                            Gi.SummaryType = DevExpress.Data.SummaryItemType.Min;
                            break;
                    }
                   
                    Gi.FieldName = dr["F_Field"].ToString();
                    Gi.ShowInGroupColumnFooterName = dr["F_Field"].ToString();
                    Gi.DisplayFormat = dr["F_GroupFormat"].ToString();
                    //Gi.ShowInGroupColumnFooter = gc;
                    gvBase.GroupSummary.Add(Gi);
                }

                
            }
        }



        /// <summary>
        /// 保存字段格式
        /// </summary>
        private void SaveFieldFormat()
        {
            string strSumType = "";
            DataRow drColumn;
            bool blnFlag = false, blnTag = false;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + this.Name + "' and F_Tag = '0' order by F_Order");

            if (ds.Tables[0].Rows.Count == 0)
                blnTag = false;
            else
                blnTag = true;

            foreach (GridColumn gc in gvBase.Columns)
            {
                string strField = gc.FieldName;
                string strCapiton = gc.Caption;
                int intWith = gc.Width;
                bool blnVisible = gc.Visible;
                if (blnTag == false)
                {
                    drColumn = ds.Tables[0].NewRow();
                    blnFlag = true;
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select("F_Field = '" + strField + "'");
                    drColumn = dr[0];
                }
                drColumn["F_Class"] = this.Name;
                drColumn["F_Tag"] = "0";
                drColumn["F_Field"] = gc.FieldName;
                drColumn["F_Caption"] = strCapiton;
                drColumn["F_Width"] = intWith;
                drColumn["F_Visible"] = blnVisible;
                drColumn["F_Edit"] = 0;
                drColumn["F_Format"] = "";
                drColumn["F_FootFormat"] = "";
                drColumn["F_Order"] = gc.VisibleIndex;
                if (gc.OptionsColumn.AllowMerge == DevExpress.Utils.DefaultBoolean.True)
                    drColumn["F_Merge"] = true;
                else
                    drColumn["F_Merge"] = false;
                strSumType = "";
                switch (gc.SummaryItem.SummaryType)
                {
                    case DevExpress.Data.SummaryItemType.Sum:
                        strSumType = "sum";
                        break;
                    case DevExpress.Data.SummaryItemType.Average:
                        strSumType = "avg";
                        break;
                    case DevExpress.Data.SummaryItemType.Count:
                        strSumType = "count";
                        break;
                    case DevExpress.Data.SummaryItemType.Max:
                        strSumType = "max";
                        break;
                    case DevExpress.Data.SummaryItemType.Min:
                        strSumType = "min";
                        break;
                }
                drColumn["F_SumType"] = strSumType;

                GridGroupSummaryItem Gi = GetGroupType(strField);
                if (Gi != null)
                {
                    strSumType = "";
                    switch (Gi.SummaryType)
                    {
                        case DevExpress.Data.SummaryItemType.Sum:
                            strSumType = "sum";
                            break;
                        case DevExpress.Data.SummaryItemType.Average:
                            strSumType = "avg";
                            break;
                        case DevExpress.Data.SummaryItemType.Count:
                            strSumType = "count";
                            break;
                        case DevExpress.Data.SummaryItemType.Max:
                            strSumType = "max";
                            break;
                        case DevExpress.Data.SummaryItemType.Min:
                            strSumType = "min";
                            break;
                    }
                    drColumn["F_GroupType"] = strSumType;
                    drColumn["F_GroupFormat"] = Gi.DisplayFormat;
                }
                if (blnFlag == false)
                    drColumn.EndEdit();
                else
                    ds.Tables[0].Rows.Add(drColumn);
            }

            myHelper.SaveData(ds, "select * from t_ReportField where F_Class = '" + this.Name + "' and F_Tag = '0'");

            DataSet dsGrid = myHelper.GetDs("select * from t_GridFormat where F_Class = '" + this.Name + "' and F_Tag = '0'");
            DataRow drGrid = null;
            if (dsGrid.Tables[0].Rows.Count == 0)
            {
                blnFlag = true;
                drGrid = dsGrid.Tables[0].NewRow();
            }
            else
            {
                blnFlag = false;
                drGrid = dsGrid.Tables[0].Rows[0];
                drGrid.BeginEdit();
            }

            drGrid["F_Class"] = this.Name;
            drGrid["F_Tag"] = "0";
            drGrid["F_AllowMerge"] = gvBase.OptionsView.AllowCellMerge;
            drGrid["F_AllowFilter"] = gvBase.OptionsCustomization.AllowFilter;
            drGrid["F_AllowPanel"] = gvBase.OptionsView.ShowGroupPanel;
            drGrid["F_AllowSum"] = gvBase.OptionsView.ShowFooter;
            drGrid["F_AutoWidth"] = gvBase.OptionsView.ColumnAutoWidth;

            if (blnFlag == true)
                dsGrid.Tables[0].Rows.Add(drGrid);
            else
                drGrid.EndEdit();

            myHelper.SaveData(dsGrid, "select * from t_GridFormat where F_Class = '" + this.Name + "' and F_Tag = '0'");
        }

        /// <summary>
        /// 填充树型
        /// </summary>
        protected void FillTv(string strType, TreeNode ParentNode)
        {

            TreeNode Node = null, cNode = null;
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (ParentNode == null)
            {
                strTVType = strType;
                ParentNode = tvType.Nodes.Add("", "所有类别", 0);
                ParentNode.Tag = strType;
                FillTv(strType, ParentNode);
            }
            else
            {
                strSQL = "select F_ID,F_Name from t_Class where F_UPID = '" + strType + "'";

                DataSet ds = myHelper.GetDs(strSQL);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    cNode = ParentNode.Nodes.Add(dr["F_ID"].ToString(), dr["F_ID"].ToString() + " (" + dr["F_Name"].ToString() + ")", 0);
                   
                    cNode.Tag = dr["F_ID"].ToString();
                    FillTv(dr["F_ID"].ToString(), cNode);
                }
            }
        }

        /*
        /// <summary>
        /// 填充树型
        /// </summary>
        protected void FillTv(string strType,TreeNode ParentNode,string strFactory)
        {
            
            TreeNode Node = null,cNode = null;
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (ParentNode == null)
            {
                strTVType = strType;
                ParentNode = tvType.Nodes.Add("", "所有类别", 0);
                ParentNode.Tag = strType;

                if (strType != "04" && strType != "11")
                {
                    strSQL = "select f_id,f_name from t_Factory";
                    DataSet dsFactory = myHelper.GetDs(strSQL);
                    foreach (DataRow drFactory in dsFactory.Tables[0].Rows)
                    {
                        Node = ParentNode.Nodes.Add(drFactory["F_ID"].ToString(), drFactory["F_ID"].ToString() + " (" + drFactory["F_Name"].ToString() + ")", 0);
                        Node.Tag = drFactory["F_ID"].ToString();
                        FillTv(strType, Node, drFactory["F_ID"].ToString());
                    }
                }
            }
            else
            {
                strSQL = "select F_ID,F_Name from t_Class where F_UPID = '" + strType + "' and F_Factory = '" + strFactory + "'";

                DataSet ds = myHelper.GetDs(strSQL);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Node == null)
                    {
                        cNode = ParentNode.Nodes.Add(dr["F_ID"].ToString(), dr["F_ID"].ToString() + " (" + dr["F_Name"].ToString() + ")", 0);
                    }
                    else
                    {
                        cNode = Node.Nodes.Add(dr["F_ID"].ToString(), dr["F_ID"].ToString() + " (" + dr["F_Name"].ToString() + ")", 0);
                    }
                    cNode.Tag = dr["F_ID"].ToString();
                    FillTv(dr["F_ID"].ToString(), cNode,strFactory);
                }
            }
        }
        */

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmBaseList_Shown(object sender, EventArgs e)
        {
            lbTitle.Text = this.Text;

            if (this.DesignMode == false)
            {
                if (tvType.Visible == true)
                {
                    if (tvType.TopNode != null)
                    {
                        tvType.TopNode.Expand();
                        tvType.SelectedNode = tvType.TopNode;
                    }
                }
                else
                {
                    BindData();
                }
                DataLib.sysClass.LoadFormatFromDB(gvBase, this.Name, 0);
                //AssignField();
            }
             
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected virtual void BindData()
        {
            if (strQuerySQL.Length == 0) return;
            BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
            myFlag.Show();
            myFlag.Update();
            try
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds;
                if (tvType.Visible == true)
                {
                    ds = myHelper.GetOtherDs(strQuerySQL, GetParm());
                }
                else
                {
                    ds = myHelper.GetDs(strQuerySQL);
                }
                if (ds == null) return;
                int intRow = gvBase.FocusedRowHandle;
                gcBase.DataSource = ds.Tables[0].DefaultView;
                DataLib.SysVar.TestColumnRight(gvBase, this.Name);
                if (intRow <= gvBase.RowCount)
                    gvBase.FocusedRowHandle = intRow;
            }
            finally
            {
                myFlag.Dispose();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected virtual void New()
        {
        }

        /// <summary>
        /// 编辑
        /// </summary>
        protected virtual void Edit()
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected virtual void Del()
        {

        }

        /// <summary>
        /// 打印
        /// </summary>
        protected virtual void Print()
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// 预览
        /// </summary>
        protected virtual void Preview()
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// 引出
        /// </summary>
        protected virtual void Export()
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvBase.ExportToExcelOld(strFile);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Edit();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Del();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print();
        }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Preview();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export();
        }

        private void gvBase_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (gvBase.FocusedValue == null)
                return;
            Clipboard.SetText(gvBase.FocusedValue.ToString());
        }

        private void frmBaseList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                frmSetGrid myGrid = new frmSetGrid();
                myGrid.gvSource = gvBase;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(gvBase,this.Name,0);
                //SaveFieldFormat();
            }
        }

        private void tvType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
            BindData();
        }

        private TreeNode GetFactory(TreeNode Node)
        {
            if (Node.Parent.Level == 1)
                return Node;
            else
                return GetFactory(Node.Parent);
        }

        private void tmAdd_Click(object sender, EventArgs e)
        {
            //TreeNode Node = GetFactory(tvType.SelectedNode);

            frmTypeEdit myTypeEdit = new frmTypeEdit();
            //myTypeEdit.strFactory = Node.Tag.ToString();
            myTypeEdit.strPID = tvType.SelectedNode.Tag.ToString();
            myTypeEdit.strTable = strTable;
            myTypeEdit.strKey = strKey;
            myTypeEdit.ShowDialog();
            myTypeEdit.Dispose();
        }

        private void tmEdit_Click(object sender, EventArgs e)
        {
            if (tvType.SelectedNode.Parent == null) return;
            string strSQL = "select * from t_Class where F_ID = '"+tvType.SelectedNode.Tag.ToString()+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0) return;
            //TreeNode Node = GetFactory(tvType.SelectedNode);
            frmTypeEdit myTypeEdit = new frmTypeEdit();
            //myTypeEdit.strFactory = Node.Tag.ToString();
            myTypeEdit.strPID = tvType.SelectedNode.Parent.Tag.ToString();
            myTypeEdit.strCID = tvType.SelectedNode.Tag.ToString();
            myTypeEdit.textEdit3.Text = ds.Tables[0].Rows[0]["F_Name"].ToString();
            ds.Dispose();
            myTypeEdit.ShowDialog();
            myTypeEdit.Dispose();
        }

        private void tmDel_Click(object sender, EventArgs e)
        {
            if (tvType.SelectedNode.Parent == null) return;
            if (MessageBox.Show(this, "真的要删除本级吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (tvType.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show(this, "本级存在下级，不能删除!!", "提示");
                return;
            }
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Class where F_ID = '"+tvType.SelectedNode.Tag.ToString()+"'") == 0)
                tvType.SelectedNode.Remove();

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh();
        }

        private void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CopyData();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImportExcel();
        }
    }
}

