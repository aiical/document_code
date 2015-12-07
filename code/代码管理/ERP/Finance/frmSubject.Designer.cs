namespace Finance
{
    partial class frmSubject
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.tvAsset = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.tvDebt = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.tvRights = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.tvCost = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.tvLoss = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.tvOut = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.sbAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sbCloe = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sbEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbDel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvAsset)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvDebt)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvRights)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvCost)).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvLoss)).BeginInit();
            this.xtraTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvOut)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(478, 344);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.tvAsset);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(472, 317);
            this.xtraTabPage1.Text = "资产类";
            // 
            // tvAsset
            // 
            this.tvAsset.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.tvAsset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAsset.KeyFieldName = "F_ID";
            this.tvAsset.Location = new System.Drawing.Point(0, 0);
            this.tvAsset.Name = "tvAsset";
            this.tvAsset.OptionsBehavior.Editable = false;
            this.tvAsset.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tvAsset.OptionsView.ShowColumns = false;
            this.tvAsset.OptionsView.ShowHorzLines = false;
            this.tvAsset.OptionsView.ShowIndicator = false;
            this.tvAsset.OptionsView.ShowVertLines = false;
            this.tvAsset.ParentFieldName = "F_UPID";
            this.tvAsset.PreviewFieldName = "F_Name";
            this.tvAsset.PreviewLineCount = 2;
            this.tvAsset.Size = new System.Drawing.Size(472, 317);
            this.tvAsset.TabIndex = 0;
            this.tvAsset.DoubleClick += new System.EventHandler(this.tvAsset_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "F_ID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "F_Name";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.tvDebt);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(472, 317);
            this.xtraTabPage2.Text = "负债类";
            // 
            // tvDebt
            // 
            this.tvDebt.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn4});
            this.tvDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDebt.KeyFieldName = "F_ID";
            this.tvDebt.Location = new System.Drawing.Point(0, 0);
            this.tvDebt.Name = "tvDebt";
            this.tvDebt.OptionsBehavior.Editable = false;
            this.tvDebt.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tvDebt.OptionsView.ShowColumns = false;
            this.tvDebt.OptionsView.ShowHorzLines = false;
            this.tvDebt.OptionsView.ShowIndicator = false;
            this.tvDebt.OptionsView.ShowVertLines = false;
            this.tvDebt.ParentFieldName = "F_UPID";
            this.tvDebt.PreviewFieldName = "F_Name";
            this.tvDebt.PreviewLineCount = 2;
            this.tvDebt.Size = new System.Drawing.Size(472, 317);
            this.tvDebt.TabIndex = 1;
            this.tvDebt.DoubleClick += new System.EventHandler(this.tvAsset_DoubleClick);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn1";
            this.treeListColumn3.FieldName = "F_ID";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.VisibleIndex = 0;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "treeListColumn2";
            this.treeListColumn4.FieldName = "F_Name";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.VisibleIndex = 1;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.tvRights);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(472, 317);
            this.xtraTabPage3.Text = "权益类";
            // 
            // tvRights
            // 
            this.tvRights.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn5,
            this.treeListColumn6});
            this.tvRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRights.KeyFieldName = "F_ID";
            this.tvRights.Location = new System.Drawing.Point(0, 0);
            this.tvRights.Name = "tvRights";
            this.tvRights.OptionsBehavior.Editable = false;
            this.tvRights.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tvRights.OptionsView.ShowColumns = false;
            this.tvRights.OptionsView.ShowHorzLines = false;
            this.tvRights.OptionsView.ShowIndicator = false;
            this.tvRights.OptionsView.ShowVertLines = false;
            this.tvRights.ParentFieldName = "F_UPID";
            this.tvRights.PreviewFieldName = "F_Name";
            this.tvRights.PreviewLineCount = 2;
            this.tvRights.Size = new System.Drawing.Size(472, 317);
            this.tvRights.TabIndex = 1;
            this.tvRights.DoubleClick += new System.EventHandler(this.tvAsset_DoubleClick);
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "treeListColumn1";
            this.treeListColumn5.FieldName = "F_ID";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.VisibleIndex = 0;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "treeListColumn2";
            this.treeListColumn6.FieldName = "F_Name";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.VisibleIndex = 1;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.tvCost);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(472, 317);
            this.xtraTabPage4.Text = "成本类";
            // 
            // tvCost
            // 
            this.tvCost.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn7,
            this.treeListColumn8});
            this.tvCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCost.KeyFieldName = "F_ID";
            this.tvCost.Location = new System.Drawing.Point(0, 0);
            this.tvCost.Name = "tvCost";
            this.tvCost.OptionsBehavior.Editable = false;
            this.tvCost.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tvCost.OptionsView.ShowColumns = false;
            this.tvCost.OptionsView.ShowHorzLines = false;
            this.tvCost.OptionsView.ShowIndicator = false;
            this.tvCost.OptionsView.ShowVertLines = false;
            this.tvCost.ParentFieldName = "F_UPID";
            this.tvCost.PreviewFieldName = "F_Name";
            this.tvCost.PreviewLineCount = 2;
            this.tvCost.Size = new System.Drawing.Size(472, 317);
            this.tvCost.TabIndex = 1;
            this.tvCost.DoubleClick += new System.EventHandler(this.tvAsset_DoubleClick);
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "treeListColumn1";
            this.treeListColumn7.FieldName = "F_ID";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.VisibleIndex = 0;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "treeListColumn2";
            this.treeListColumn8.FieldName = "F_Name";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.VisibleIndex = 1;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.tvLoss);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(472, 317);
            this.xtraTabPage5.Text = "损益类";
            // 
            // tvLoss
            // 
            this.tvLoss.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn9,
            this.treeListColumn10});
            this.tvLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLoss.KeyFieldName = "F_ID";
            this.tvLoss.Location = new System.Drawing.Point(0, 0);
            this.tvLoss.Name = "tvLoss";
            this.tvLoss.OptionsBehavior.Editable = false;
            this.tvLoss.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tvLoss.OptionsView.ShowColumns = false;
            this.tvLoss.OptionsView.ShowHorzLines = false;
            this.tvLoss.OptionsView.ShowIndicator = false;
            this.tvLoss.OptionsView.ShowVertLines = false;
            this.tvLoss.ParentFieldName = "F_UPID";
            this.tvLoss.PreviewFieldName = "F_Name";
            this.tvLoss.PreviewLineCount = 2;
            this.tvLoss.Size = new System.Drawing.Size(472, 317);
            this.tvLoss.TabIndex = 1;
            this.tvLoss.DoubleClick += new System.EventHandler(this.tvAsset_DoubleClick);
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.Caption = "treeListColumn1";
            this.treeListColumn9.FieldName = "F_ID";
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.VisibleIndex = 0;
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.Caption = "treeListColumn2";
            this.treeListColumn10.FieldName = "F_Name";
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.VisibleIndex = 1;
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.tvOut);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(472, 317);
            this.xtraTabPage6.Text = "表外";
            // 
            // tvOut
            // 
            this.tvOut.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn11,
            this.treeListColumn12});
            this.tvOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOut.KeyFieldName = "F_ID";
            this.tvOut.Location = new System.Drawing.Point(0, 0);
            this.tvOut.Name = "tvOut";
            this.tvOut.OptionsBehavior.Editable = false;
            this.tvOut.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tvOut.OptionsView.ShowColumns = false;
            this.tvOut.OptionsView.ShowHorzLines = false;
            this.tvOut.OptionsView.ShowIndicator = false;
            this.tvOut.OptionsView.ShowVertLines = false;
            this.tvOut.ParentFieldName = "F_UPID";
            this.tvOut.PreviewFieldName = "F_Name";
            this.tvOut.PreviewLineCount = 2;
            this.tvOut.Size = new System.Drawing.Size(472, 317);
            this.tvOut.TabIndex = 2;
            this.tvOut.DoubleClick += new System.EventHandler(this.tvAsset_DoubleClick);
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.Caption = "treeListColumn1";
            this.treeListColumn11.FieldName = "F_ID";
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.VisibleIndex = 0;
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.Caption = "treeListColumn2";
            this.treeListColumn12.FieldName = "F_Name";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.VisibleIndex = 1;
            // 
            // sbAdd
            // 
            this.sbAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAdd.Appearance.Options.UseFont = true;
            this.sbAdd.Location = new System.Drawing.Point(508, 33);
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(101, 23);
            this.sbAdd.TabIndex = 1;
            this.sbAdd.Text = "增加同级科目...";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // sbCloe
            // 
            this.sbCloe.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCloe.Appearance.Options.UseFont = true;
            this.sbCloe.Location = new System.Drawing.Point(508, 329);
            this.sbCloe.Name = "sbCloe";
            this.sbCloe.Size = new System.Drawing.Size(101, 23);
            this.sbCloe.TabIndex = 2;
            this.sbCloe.Text = "关闭(&C)";
            this.sbCloe.Click += new System.EventHandler(this.sbCloe_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(508, 62);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(101, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "增加下级科目...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // sbEdit
            // 
            this.sbEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbEdit.Appearance.Options.UseFont = true;
            this.sbEdit.Location = new System.Drawing.Point(508, 101);
            this.sbEdit.Name = "sbEdit";
            this.sbEdit.Size = new System.Drawing.Size(101, 23);
            this.sbEdit.TabIndex = 4;
            this.sbEdit.Text = "修改";
            this.sbEdit.Click += new System.EventHandler(this.sbEdit_Click);
            // 
            // sbDel
            // 
            this.sbDel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDel.Appearance.Options.UseFont = true;
            this.sbDel.Location = new System.Drawing.Point(508, 130);
            this.sbDel.Name = "sbDel";
            this.sbDel.Size = new System.Drawing.Size(101, 23);
            this.sbDel.TabIndex = 5;
            this.sbDel.Text = "删除";
            this.sbDel.Click += new System.EventHandler(this.sbDel_Click);
            // 
            // frmSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(631, 368);
            this.Controls.Add(this.sbDel);
            this.Controls.Add(this.sbEdit);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.sbCloe);
            this.Controls.Add(this.sbAdd);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubject";
            this.Text = "会计科目";
            this.Shown += new System.EventHandler(this.frmSubject_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvAsset)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvDebt)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvRights)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvCost)).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvLoss)).EndInit();
            this.xtraTabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraEditors.SimpleButton sbAdd;
        private DevExpress.XtraEditors.SimpleButton sbCloe;
        private DevExpress.XtraTreeList.TreeList tvAsset;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.TreeList tvDebt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.TreeList tvRights;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.TreeList tvCost;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.TreeList tvLoss;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton sbEdit;
        private DevExpress.XtraEditors.SimpleButton sbDel;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private DevExpress.XtraTreeList.TreeList tvOut;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn12;
    }
}
