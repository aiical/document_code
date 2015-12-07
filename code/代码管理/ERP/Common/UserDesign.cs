using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Common
{
    public partial class UserDesign : BaseClass.frmBase
    {
        public UserDesign()
        {
            InitializeComponent();
            lbTitle.BackColor = System.Drawing.Color.Transparent;
            lbTitle.Parent = pcTitle;
            Point Pos = new Point(2, 8);
            lbTitle.Location = Pos;
            lbTitle.Text = this.Text;
            SetLinkEvent();
        }

        private void SetLinkEvent()
        {
            foreach (ToolStripItem tsItem in toolStrip.Items)
            {
                if (tsItem is ToolStripButton)
                {
                    (tsItem as ToolStripButton).Click += new EventHandler(ButtonClick);
                }
            }

            this.Shown += new EventHandler((FormShown));
            tvParent.AfterSelect += new TreeViewEventHandler(NodeSelect);

        }

        private void FormShown(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                FillParent();
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                switch ((sender as ToolStripButton).Text)
                {
                    case "新增":
                        New();
                        break;
                    case "编辑":
                        Edit();
                        break;
                    case "删除":
                        Del();
                        break;
                    case "关闭":
                        Close();
                        break;
                }
            }
        }

        private void New()
        {
            LoadDllForm myDllForm = new LoadDllForm();
            myDllForm.ShowDialog();
            myDllForm.Dispose();
        }


        private void Edit()
        {
            if (lvModule.SelectedItems.Count == 0) return;
            LoadDllForm myDllForm = new LoadDllForm();
            myDllForm.ShowDialog();
            myDllForm.Dispose();
        }


        private void Del()
        {
            if (lvModule.SelectedItems.Count == 0) return;
            if (MessageBox.Show(this, "真的要删选定模块吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_UserModule where F_Parent = '"+tvParent.SelectedNode.Text +"' and F_ModuleName = '"+lvModule.SelectedItems[0].Text+"'") != -1)
               lvModule.SelectedItems[0].Remove();
            
        }


        private void FillParent()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Parent from t_UserModule");
            tvParent.Nodes.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode Node = new TreeNode();
                Node.Text = dr["F_Parent"].ToString();
                Node.ImageIndex = 0;
                tvParent.Nodes.Add(Node);
            }
            ds.Dispose();
        }

        private void FillModule(string sParent)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_ModuleName from t_UserModule where F_Parent = '" + sParent + "'");
            lvModule.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = dr["F_ModuleName"].ToString();
                Item.ImageIndex = 0;
                lvModule.Items.Add(Item);
            }
            ds.Dispose();
        }

        private void NodeSelect(object sender, TreeViewEventArgs e)
        {
            FillModule(e.Node.Text);
        }

        private void RunModule()
        {
            if (lvModule.SelectedItems.Count == 0) return;

            string sParent = tvParent.SelectedNode.Text;
            string sModuleName = lvModule.SelectedItems[0].Text;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_UserModule where F_Parent = '" + sParent + "' and F_ModuleName = '" + sModuleName + "'");
            if (ds.Tables[0].Rows.Count == 0) return;

            string sClass = ds.Tables[0].Rows[0]["F_Class"].ToString();
            string sForm = ds.Tables[0].Rows[0]["F_FormName"].ToString();
            bool bMdi = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_MDI"]);

            LoadForm(sClass,sForm,this,bMdi);

        }

        /// <summary>
        /// 根据窗体名加载窗体
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sFormName"></param>
        public BaseClass.frmBase LoadForm(string sFile, string sFormName, Form fParent, bool bMdi)
        {
            try
            {
                Assembly _Assembly = Assembly.LoadFile(sFile);
                Type _FormType = _Assembly.GetType(sFormName, true, true);
                object _LoadForm = Activator.CreateInstance(_FormType, null);

                BaseClass.frmBase frm = _LoadForm as BaseClass.frmBase;
                //frm.SysParm = parm;

                if (frm != null)
                {
                    if (bMdi == false)
                    {
                        frm.ShowDialog(fParent);
                        //frm.Dispose();
                    }
                    else
                    {
                        frm.MdiParent = this.MdiParent;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Show();
                    }

                }
                return frm;
            }
            catch (Exception E)
            {
                MessageBox.Show(this,E.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        private void lvModule_DoubleClick(object sender, EventArgs e)
        {
            RunModule();
        }
    }
}
