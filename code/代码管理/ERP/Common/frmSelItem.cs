using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmSelItem : BaseClass.frmBase
    {
        public frmBill myBill;
        public int intTag = 0;   //物料属性(0为原材料，1为产品)  
        public frmSelItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定物料基本资料
        /// </summary>
        private void BindData()
        {
            bool bFlag = false;

            string strSQL = "";
            strSQL = "select a.*,(select F_Name from t_Class where F_ID = a.F_Type) as F_TypeName,b.F_Name as F_Storage,c.F_Name as F_Unit ";
            strSQL = strSQL + "from t_Item a ";
            strSQL = strSQL + "left join t_Storage b ";
            strSQL = strSQL + "on a.F_StorageID = b.F_ID ";
            strSQL = strSQL + "left join t_Unit c ";
            strSQL = strSQL + "on a.F_ID = c.F_ItemID ";
            strSQL = strSQL + "and c.F_Main = 1 ";
            if (cbKind.Text != "全部")
               strSQL = strSQL + "where a.F_Kind = '" + cbKind.Text + "' ";

           
            if (lupType.GetValue() != null)
            {
                if (lupType.GetValue().ToString().Length > 0)
                {
                    if (cbKind.Text != "全部")
                        strSQL = strSQL + "and a.F_Type like '" + lupType.GetValue().ToString() + "%'";
                    else
                    {
                        strSQL = strSQL + "where a.F_Type like '" + lupType.GetValue().ToString() + "%'";
                        bFlag = true;
                    }
                }
            }

            if (txtValue.Text.Length > 0)
            {
                if (cbKind.Text != "全部")
                    strSQL = strSQL + "and ((a.F_ID = '" + txtValue.Text + "') or (a.F_Name like '%" + txtValue.Text + "%') or (a.F_Spec like '%" + txtValue.Text + "%'))";
                else
                {
                    if (bFlag == true)
                    {
                        strSQL = strSQL + " and ((a.F_ID = '" + txtValue.Text + "') or (a.F_Name like '%" + txtValue.Text + "%') or (a.F_Spec like '%" + txtValue.Text + "%'))";
                    }
                    else
                    {
                        strSQL = strSQL + "where ((a.F_ID = '" + txtValue.Text + "') or (a.F_Name like '%" + txtValue.Text + "%') or (a.F_Spec like '%" + txtValue.Text + "%'))";
                    }
                }
            }


            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcMain.DataSource = ds.Tables[0].DefaultView;
            DataLib.sysClass.LoadFormatFromDB(gvMain, this.Name, 0);
            gcMain.Focus();
            
        }

        /// <summary>
        /// 绑定物料库存资料
        /// </summary>
        private void BindStore()
        {
            string strSQL = "";
            strSQL = "select a.F_StorageID,b.F_Name as F_Storage,c.F_ID,c.F_Name,c.F_Spec,c.F_SupplierID,";
            strSQL = strSQL + "a.F_Unit,a.F_BatchNo,a.F_Grade,a.F_Color,a.F_Qty,c.F_Brand,c.F_Material,(select F_Name from t_Class where F_ID = c.F_Type) as F_TypeName,c.F_Price,c.F_StockPrice,c.F_SellPrice ";
            strSQL = strSQL + "from t_StorageQty a,t_Storage b,t_Item c ";
            strSQL = strSQL + "where a.F_StorageID = b.F_ID ";
            strSQL = strSQL + "and a.F_ItemID = c.F_ID ";
            if (cbKind.Text != "全部")
                strSQL = strSQL + "and c.F_Kind = '" + cbKind.Text + "' ";

            if (lupType.GetValue() != null)
            {
                if (lupType.GetValue().ToString().Length > 0)
                {
                    strSQL = strSQL + "and c.F_Type like '" + lupType.GetValue().ToString() + "%'";
                }
            }
            
            if (txtValue.Text.Length > 0)
            {
                strSQL = strSQL + "and ((c.F_ID = '" + txtValue.Text + "') or (c.F_Name like '%" + txtValue.Text + "%') or (c.F_Spec like '%" + txtValue.Text + "%'))";
                  
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcStore.DataSource = ds.Tables[0].DefaultView;
            DataLib.sysClass.LoadFormatFromDB(gvStore, this.Name, 1);
            gcStore.Focus();
            
        }

        private void frmSelItem_Load(object sender, EventArgs e)
        {
            string strSQL = "";
            cbKind.Properties.Items.Clear();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsType = myHelper.GetDs("select F_Type1,F_Type2,F_Type3 from t_Parm");
            if (intTag == 0)   //intTag 物料类别标志
            {
                cbKind.Properties.Items.Add("原材料");
                cbKind.Properties.Items.Add("产成品");
                cbKind.Properties.Items.Add("半成品");
                cbKind.Properties.Items.Add("其它");
                cbKind.Properties.Items.Add("全部");
                if (dsType.Tables[0].Rows[0]["F_Type1"] != DBNull.Value)
                    cbKind.Text = dsType.Tables[0].Rows[0]["F_Type1"].ToString();
                strSQL = "select F_ID,F_Name from t_Class where left(F_ID,2) = '04'";
            }
            if (intTag == 1)
            {
                cbKind.Properties.Items.Add("原材料");
                cbKind.Properties.Items.Add("产成品");
                cbKind.Properties.Items.Add("半成品");
                cbKind.Properties.Items.Add("其它");
                cbKind.Properties.Items.Add("全部");
                if (dsType.Tables[0].Rows[0]["F_Type2"] != DBNull.Value)
                    cbKind.Text = dsType.Tables[0].Rows[0]["F_Type2"].ToString();
                strSQL = "select F_ID,F_Name from t_Class where left(F_ID,2) = '11'";
            }
            if (intTag == 2)
            {
                cbKind.Properties.Items.Add("原材料");
                cbKind.Properties.Items.Add("产成品");
                cbKind.Properties.Items.Add("半成品");
                cbKind.Properties.Items.Add("其它");
                cbKind.Properties.Items.Add("全部");
                cbKind.Text = "全部";
                strSQL = "select F_ID,F_Name from t_Class where left(F_ID,2) = '04' or left(F_ID,2) = '11'";
            }

            if (intTag == 3)
            {
                cbKind.Properties.Items.Add("原材料");
                cbKind.Properties.Items.Add("产成品");
                cbKind.Properties.Items.Add("半成品");
                cbKind.Properties.Items.Add("其它");
                cbKind.Properties.Items.Add("全部");
                cbKind.Text = "全部";
                strSQL = "select F_ID,F_Name from t_Class where left(F_ID,2) = '04' or left(F_ID,2) = '11'";
            }

            if (intTag == 4)
            {
                cbKind.Properties.Items.Add("原材料");
                cbKind.Properties.Items.Add("产成品");
                cbKind.Properties.Items.Add("半成品");
                cbKind.Properties.Items.Add("其它");
                cbKind.Properties.Items.Add("全部");
                if (dsType.Tables[0].Rows[0]["F_Type3"] != DBNull.Value)
                    cbKind.Text = dsType.Tables[0].Rows[0]["F_Type3"].ToString();
                strSQL = "select F_ID,F_Name from t_Class where left(F_ID,2) = '04' or left(F_ID,2) = '11'";
            }

            if (myBill == null) sbAdd.Visible = false;

            //DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupType.LookUpDataSource = ds.Tables[0].DefaultView;
            lupType.LookUpDisplayField = "F_Name";
            lupType.LookUpKeyField = "F_ID";

            //BindData();
            //BindStore();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (this.TabControl.SelectedTabPageIndex == 0 )
               if (gvMain.FocusedRowHandle < 0) return;

            if (this.TabControl.SelectedTabPageIndex == 1 )
                if (gvStore.FocusedRowHandle < 0) return;
            

            this.DialogResult = DialogResult.OK;
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            if (myBill != null)
            {
                DataRow dr;
                if (this.TabControl.SelectedTabPageIndex == 0)
                {
                    int[] intRow = gvMain.GetSelectedRows();
                    if (intRow.Length <= 0) return;
                    for (int i = 0; i < intRow.Length; i++)
                    {
                        dr = gvMain.GetDataRow(intRow[i]);
                        myBill.SetItem(dr, 1);
                    }
                }
                else
                {
                    int[] intRow = gvStore.GetSelectedRows();
                    if (intRow.Length <= 0) return;
                    for (int i = 0; i < intRow.Length; i++)
                    {
                        dr = gvStore.GetDataRow(intRow[i]);
                        myBill.SetStore(dr, 1);
                    }
                }
            }
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            sbOK_Click(null, null);
        }

        private void TabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTabPageIndex == 0)
                BindData();
            else
                BindStore();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            TabControl_TabIndexChanged(null, null);
        }

        private void gvStore_DoubleClick(object sender, EventArgs e)
        {
            sbOK_Click(null, null);
        }

        private void TabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (TabControl.SelectedTabPageIndex == 1)
            {
                sbDel.Enabled = false;
            }
            else
            {
                sbDel.Enabled = true;
            }
        }

        private void sbNew_Click(object sender, EventArgs e)
        {
            string strMethod = "";
            Assembly pAsm = Assembly.LoadFile(Application.StartupPath + "\\Base.dll");
            Type pType = pAsm.GetType("Base.CallBase");
            if (intTag == 0)
                strMethod = "ShowItemNew";
            else
                strMethod = "ShowProductNew";
            MethodInfo pmethod = pType.GetMethod(strMethod);
            object obj = pAsm.CreateInstance("Base.CallBase");
            
            pmethod.Invoke(obj, null);

        }

        private void sbEdit_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0) return;
            string strMethod = "";
            Assembly pAsm = Assembly.LoadFile(Application.StartupPath+"\\Base.dll");
            Type pType = pAsm.GetType("Base.CallBase");
            if (intTag == 0)
                strMethod = "ShowItemEdit";
            else
                strMethod = "ShowProductEdit";
            MethodInfo pmethod = pType.GetMethod(strMethod);
            object obj = pAsm.CreateInstance("Base.CallBase");
            DataRow dr = null;
            if (this.TabControl.SelectedTabPageIndex == 0 )
                dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            else
                dr = gvStore.GetDataRow(gvStore.FocusedRowHandle);
            
            pmethod.Invoke(obj, new string[]{dr["F_ID"].ToString()});
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除选定资料吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Item where F_ID = '" + dr["F_ID"].ToString() + "'") == 0)
                gvMain.DeleteRow(gvMain.FocusedRowHandle);
        }

        private void ckMut_CheckedChanged(object sender, EventArgs e)
        {
            gvMain.OptionsSelection.MultiSelect = ckMut.Checked;
            gvStore.OptionsSelection.MultiSelect = ckMut.Checked;
        }

        private void frmSelItem_Shown(object sender, EventArgs e)
        {
            txtValue.Focus();
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sbRefresh_Click(null,null);
            }
        }

        private void gvMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sbOK_Click(null, null);
        }

        private void gvStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sbOK_Click(null, null);
        }

        private void cbKind_EditValueChanged(object sender, EventArgs e)
        {
            sbRefresh_Click(null,null);
        }

        private void lupType_ValueChanged(object sender, EventArgs e)
        {
            sbRefresh_Click(null, null);
        }

        private void frmSelItem_KeyDown(object sender, KeyEventArgs e)
        {
            //保存表格格式
            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                if (this.TabControl.SelectedTabPageIndex == 0)
                   DataLib.sysClass.SaveGridToDB(gvMain, this.Name, 0);
                else
                   DataLib.sysClass.SaveGridToDB(gvStore, this.Name, 1);
            }
        }
       
    }
}

