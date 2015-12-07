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
        protected int intImport = 0;  //�����־

        public frmBaseList()
        {
            InitializeComponent();
            gvBase.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(FocusedRowChange);
        }

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        /// <returns></returns>
        protected bool TestRight(string strName)
        {
            if (DataLib.SysVar.strUGroup == "�����û�") return true;
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + this.Name + "' and F_Name = '" + strName + "' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("�Բ�������Ȩ��!!", "��ʾ");
                return false;
            }
            else
                return true;
        }


        protected virtual void ImportExcel()
        {

            System.Data.DataTable dt = DataLib.sysClass.ImportExcel("Sheet1");
            if (dt == null) return;

            if (MessageBox.Show(this, "����Excel������Ҫһ��ʱ�䣬���б�������?", "ѯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

             BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
             myFlag.label1.Text = "�����������ݣ����Դ�......";
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
        /// ����Bom����������
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
                        MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'��BOM����,���������Excel�ļ�!", "��ʾ");
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
                MessageBox.Show(this, E.Message, "����");
            }
        }

          /// <summary>
        /// ����Bom����������
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
                        MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'��BOM����,���������Excel�ļ�!", "��ʾ");
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
                MessageBox.Show(this, E.Message, "����");
            }
        }

        
        /// <summary>
        /// ���빩Ӧ������
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
                    strID = dr["��Ӧ�̱���"].ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'�Ĺ�Ӧ��,���������Excel�ļ�!", "��ʾ");
                        break;
                    }
                    DataRow drNew = dsEmp.Tables[0].NewRow();
                    drNew["F_ID"] = dr["��Ӧ�̱���"].ToString();
                    drNew["F_Name"] = dr["��Ӧ������"].ToString();
                    drNew["F_Type"] = dr["������"].ToString();
                    drNew["F_LinkMan"] = dr["��ϵ��"].ToString();
                    drNew["F_Tel"] = dr["��ϵ�绰"].ToString();
                    drNew["F_OtherTel"] = dr["�����绰"].ToString();
                    drNew["F_Bank"] = dr["��������"].ToString();
                    drNew["F_BankNo"] = dr["�����ʺ�"].ToString();
                    drNew["F_PostCode"] = dr["�ʱ�"].ToString();
                    drNew["F_Adr"] = dr["��ַ"].ToString();
                    drNew["F_Remark"] = dr["��ע"].ToString();
                    drNew["F_Use"] = true;

                    if (dr["�ڳ����"] == DBNull.Value)
                        drNew["F_QcMoney"] = 0;
                    else
                        drNew["F_QcMoney"] = Convert.ToDecimal(dr["�ڳ����"]);

                    if (dr["Ԥ�����"] == DBNull.Value)
                        drNew["F_PreMoney"] = 0;
                    else
                        drNew["F_PreMoney"] = Convert.ToDecimal(dr["Ԥ�����"]);

                    dsEmp.Tables[0].Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Supplier");
            }
            catch (Exception E)
            {
                MessageBox.Show(this,E.Message, "����");
            }
        }

        /// <summary>
        /// ����ͻ�����
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
                    strID = dr["�ͻ�����"].ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'�Ŀͻ�,���������Excel�ļ�!", "��ʾ");
                        break;
                    }
                    DataRow drNew = dsEmp.Tables[0].NewRow();
                    drNew["F_ID"] = dr["�ͻ�����"].ToString();
                    drNew["F_Name"] = dr["�ͻ�����"].ToString();
                    drNew["F_Type"] = dr["������"].ToString();
                    drNew["F_Opertor"] = dr["ҵ��Ա����"].ToString();
                    drNew["F_LinkMan"] = dr["��ϵ��1"].ToString();
                    drNew["F_Tel"] = dr["��ϵ�绰1"].ToString();

                    drNew["F_LinkMan1"] = dr["��ϵ��2"].ToString();
                    drNew["F_Tel1"] = dr["��ϵ�绰2"].ToString();
                    drNew["F_LinkMan2"] = dr["��ϵ��3"].ToString();
                    drNew["F_Tel2"] = dr["��ϵ�绰3"].ToString();

                    drNew["F_Fax"] = dr["����"].ToString();
                    drNew["F_Bank"] = dr["��������"].ToString();
                    drNew["F_BankNo"] = dr["�����ʺ�"].ToString();
                    drNew["F_Adr"] = dr["��ַ"].ToString();
                    drNew["F_PostCode"] = dr["�ʱ�"].ToString();
                    drNew["F_Legal"] = dr["���˴���"].ToString();
                    drNew["F_QQ"] = dr["QQ"].ToString();
                    drNew["F_Email"] = dr["EMail"].ToString();
                    drNew["F_Source"] = dr["�ͻ���Դ"].ToString();
                    drNew["F_CarryCompany"] = dr["���˹�˾����"].ToString();
                    drNew["F_Remark"] = dr["��ע"].ToString();

                    drNew["F_Use"] = true;

                    if (dr["���ö�"] == DBNull.Value)
                        drNew["F_ClientXinyong"] = 0;
                    else
                        drNew["F_ClientXinyong"] = Convert.ToDecimal(dr["���ö�"]);

                    if (dr["�ڳ����"] == DBNull.Value)
                        drNew["F_QcMoney"] = 0;
                    else
                        drNew["F_QcMoney"] = Convert.ToDecimal(dr["�ڳ����"]);

                    if (dr["�ڳ�����"] == DBNull.Value)
                        drNew["F_QcHasMoney"] = 0;
                    else
                        drNew["F_QcHasMoney"] = Convert.ToDecimal(dr["�ڳ�����"]);

                    if (dr["Ԥ�տ�"] == DBNull.Value)
                        drNew["F_PreMoney"] = 0;
                    else
                        drNew["F_PreMoney"] = Convert.ToDecimal(dr["Ԥ�տ�"]);

                    if (dr["Ƿ��"] == DBNull.Value)
                        drNew["F_NeedMoney"] = 0;
                    else
                        drNew["F_NeedMoney"] = Convert.ToDecimal(dr["Ƿ��"]);

                    if (dr["���տ�"] == DBNull.Value)
                        drNew["F_HasMoney"] = 0;
                    else
                        drNew["F_HasMoney"] = Convert.ToDecimal(dr["���տ�"]);

                    drNew["F_Builder"] = DataLib.SysVar.strUName;
                    drNew["F_BuildDate"] = DataLib.SysVar.GetDate();

                    dsEmp.Tables[0].Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Client");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "����");
            }
        }


        /// <summary>
        /// ����ְԱ����
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
                    strID = dr["����"].ToString();
                    if (strID.Length == 0) continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'��Ա��,���������Excel�ļ�!", "��ʾ");
                        break;
                    }
                    DataRow drNew = dt.NewRow();
                    drNew["F_ID"] = dr["����"];
                    drNew["F_Name"] = dr["����"];
                    drNew["F_Sex"] = dr["�Ա�"];
                    drNew["F_Type"] = dr["���ű���"];
                    if (dr["��������"] == DBNull.Value)
                        drNew["F_BornDate"] = Convert.ToDateTime("1900-1-1");
                    else
                        drNew["F_BornDate"] = dr["��������"];

                    drNew["F_Knowlege"] = dr["ѧ��"];
                    drNew["F_Tel"] = dr["��ϵ�绰"];
                    drNew["F_OtherTel"] = dr["�����绰"];

                    drNew["F_Wage"] = dr["��������"];

                    drNew["F_IDCard"] = dr["���֤��"];
                    drNew["F_Adr"] = dr["סַ"];
                    drNew["F_Remark"] = dr["��ע"];
                    if (dr["ҵ��Ա��־"] == DBNull.Value)
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
                MessageBox.Show(this,E.Message,"����");
            }
        }


        /// <summary>
        /// ����ԭ��������
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
                    strID = dr["���ϱ���"].ToString();
                    if (strID == "") continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'������,���������Excel�ļ�!", "��ʾ");
                        break;
                    }
                    DataRow drNew = dt.NewRow();
                    drNew["F_ID"] = dr["���ϱ���"];
                    drNew["F_Name"] = dr["��������"];
                    drNew["F_Spec"] = dr["���"];
                    drNew["F_Brand"] = dr["Ʒ��"];
                    drNew["F_Type"] =dr["������"];
                    drNew["F_Kind"] = dr["����"];
                    DataRow drUnit = dsUnit.Tables[0].NewRow();
                    drUnit["F_ItemID"] = dr["���ϱ���"];
                    drUnit["F_Name"] = dr["��λ"];
                    drUnit["F_Rate"] = 1;
                    drUnit["F_Main"] = true;
                    dsUnit.Tables[0].Rows.Add(drUnit);
                    drNew["F_Grade"] = dr["�ȼ�"];
                    drNew["F_Color"] = dr["��ɫ"];
                    drNew["F_StorageID"] = dr["Ĭ�ϲֿ����"];

                    drNew["F_StockPrice"] = dr["Ĭ�Ͻ�����"];
                    drNew["F_StockPrice1"] = dr["����1"];
                    drNew["F_StockPrice2"] = dr["����2"];
                    drNew["F_StockPrice3"] = dr["����3"];
                    drNew["F_StockPrice4"] = dr["����4"];
                    drNew["F_UpLimit"] = dr["�������"];
                    drNew["F_DownLimit"] = dr["�������"];
                    drNew["F_SafeQty"] = dr["��ȫ���"];
                    drNew["F_Remark"] = dr["��ע"];


                    drNew["F_Material"] = dr["����"];

                    drNew["F_Attrib"] = "ԭ����";

                    drNew["F_CalStorage"] = true;

                    dt.Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Item");
                myHelper.SaveData(dsUnit, "select * from t_Unit");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "����");
            }
        }


        /// <summary>
        /// �����Ʒ����
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
                    strID = dr["��Ʒ����"].ToString();
                    if (strID == "") continue;
                    if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                    {
                        MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'�Ĳ�Ʒ,���������Excel�ļ�!", "��ʾ");
                        break;
                    }
                    DataRow drNew = dt.NewRow();
                    drNew["F_ID"] = dr["��Ʒ����"];
                    drNew["F_Name"] = dr["��Ʒ����"];
                    drNew["F_Spec"] = dr["���"];
                    drNew["F_Brand"] = dr["Ʒ��"];
                    drNew["F_Type"] =dr["������"];
                    drNew["F_Kind"] = dr["����"];
                    DataRow drUnit = dsUnit.Tables[0].NewRow();
                    drUnit["F_ItemID"] = dr["��Ʒ����"];
                    drUnit["F_Name"] = dr["��λ"];
                    drUnit["F_Rate"] = 1;
                    drUnit["F_Main"] = true;
                    dsUnit.Tables[0].Rows.Add(drUnit);
                    drNew["F_Grade"] = dr["�ȼ�"];
                    drNew["F_Color"] = dr["��ɫ"];
                    drNew["F_StorageID"] = dr["Ĭ�ϲֿ����"];

                    drNew["F_StockPrice"] = dr["Ĭ���ۼ�"];
                    drNew["F_StockPrice1"] = dr["�ۼ�1"];
                    drNew["F_StockPrice2"] = dr["�ۼ�2"];
                    drNew["F_StockPrice3"] = dr["�ۼ�3"];
                    drNew["F_StockPrice4"] = dr["�ۼ�4"];
                    drNew["F_UpLimit"] = dr["�������"];
                    drNew["F_DownLimit"] = dr["�������"];
                    drNew["F_SafeQty"] = dr["��ȫ���"];
                    drNew["F_Remark"] = dr["��ע"];


                    drNew["F_Material"] = dr["����"];

                    drNew["F_Attrib"] = "��Ʒ";

                    drNew["F_CalStorage"] = true;

                    dt.Rows.Add(drNew);
                }

                myHelper.SaveData(dsEmp, "select * from t_Item");
                myHelper.SaveData(dsUnit, "select * from t_Unit");
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, "����");
            }
        }

        /// <summary>
        /// ������ӹ���������
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
                strID = dr["���̱���"].ToString();
                if (strID == "") continue;
                if (dt.Select("F_ID = '" + strID + "'").Length > 0)
                {
                    MessageBox.Show(this, "���ݿ��Ѵ��ڱ���Ϊ'" + strID + "'����ӹ�����,���������Excel�ļ�!", "��ʾ");
                    break;
                }

                DataRow drNew = dt.NewRow();
                drNew["F_ID"] = strID;
                drNew["F_Name"] = dr["��������"];
                drNew["F_Type"] = dr["������"];
                drNew["F_LinkMan"] = dr["��ϵ��"];
                drNew["F_Tel"] = dr["�绰"];
                drNew["F_OtherTel"] = dr["�����绰"];
                drNew["F_Bank"] = dr["����"];
                drNew["F_BankNo"] = dr["�����ʺ�"];
                drNew["F_PostCode"] = dr["�ʱ�"];
                drNew["F_Adr"] = dr["��ַ"];
                drNew["F_Remark"] = dr["��ע"];
                drNew["F_Use"] = true;

                drNew["F_QcMoney"] = dr["�ڳ�"];
                drNew["F_PreMoney"] = dr["Ԥ��"];

                dt.Rows.Add(drNew);
            }

            myHelper.SaveData(dsEmp, "select * from t_OutSupplier");

        }


        /// <summary>
        /// ��˳��ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FocusedRowChange(object Sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        /// <summary>
        /// ��������
        /// </summary>
        protected virtual void CopyData()
        {

        }

        /// <summary>
        /// ˢ��
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
        /// ȡ�÷�����
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
        /// ���õ�����ϸ�ֶ�
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
        /// �����ֶθ�ʽ
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
        /// �������
        /// </summary>
        protected void FillTv(string strType, TreeNode ParentNode)
        {

            TreeNode Node = null, cNode = null;
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (ParentNode == null)
            {
                strTVType = strType;
                ParentNode = tvType.Nodes.Add("", "�������", 0);
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
        /// �������
        /// </summary>
        protected void FillTv(string strType,TreeNode ParentNode,string strFactory)
        {
            
            TreeNode Node = null,cNode = null;
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (ParentNode == null)
            {
                strTVType = strType;
                ParentNode = tvType.Nodes.Add("", "�������", 0);
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
        /// ���ݰ�
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
        /// ����
        /// </summary>
        protected virtual void New()
        {
        }

        /// <summary>
        /// �༭
        /// </summary>
        protected virtual void Edit()
        {
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        protected virtual void Del()
        {

        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        protected virtual void Print()
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// Ԥ��
        /// </summary>
        protected virtual void Preview()
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// ����
        /// </summary>
        protected virtual void Export()
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel �ļ�", "Excel �ļ�|*.Xls");
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
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "�����û�")
            {
                frmSetGrid myGrid = new frmSetGrid();
                myGrid.gvSource = gvBase;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "�����û�")
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
            if (MessageBox.Show(this, "���Ҫɾ��������?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (tvType.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show(this, "���������¼�������ɾ��!!", "��ʾ");
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

