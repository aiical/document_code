namespace U8_Sale
{
    partial class frmDeptRef
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeptRef));
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gcView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvcDeptRefId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDepartment = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvcRef1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luecRef1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvcRef2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luecRef2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // gcList
            // 
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.EmbeddedNavigator.Name = "";
            this.gcList.Location = new System.Drawing.Point(0, 25);
            this.gcList.MainView = this.gcView;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueDepartment,
            this.luecRef1,
            this.luecRef2});
            this.gcList.Size = new System.Drawing.Size(784, 438);
            this.gcList.TabIndex = 113;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gcView});
            // 
            // gcView
            // 
            this.gcView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcDeptRefId,
            this.gvcDepCode,
            this.gvcRef1,
            this.gvcRef2});
            this.gcView.GridControl = this.gcList;
            this.gcView.Name = "gcView";
            this.gcView.OptionsNavigation.AutoMoveRowFocus = false;
            this.gcView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gcView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // gvcDeptRefId
            // 
            this.gvcDeptRefId.Caption = "ID";
            this.gvcDeptRefId.FieldName = "cDeptRefId";
            this.gvcDeptRefId.Name = "gvcDeptRefId";
            // 
            // gvcDepCode
            // 
            this.gvcDepCode.Caption = "部门";
            this.gvcDepCode.ColumnEdit = this.lueDepartment;
            this.gvcDepCode.FieldName = "cDepCode";
            this.gvcDepCode.Name = "gvcDepCode";
            this.gvcDepCode.Visible = true;
            this.gvcDepCode.VisibleIndex = 0;
            // 
            // lueDepartment
            // 
            this.lueDepartment.AutoHeight = false;
            this.lueDepartment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepartment.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lueDepartment.DisplayMember = "cDepName";
            this.lueDepartment.Name = "lueDepartment";
            this.lueDepartment.ValueMember = "cDepCode";
            this.lueDepartment.EditValueChanged += new System.EventHandler(this.lueGrid_EditValueChanged);
            // 
            // gvcRef1
            // 
            this.gvcRef1.Caption = "参考值1";
            this.gvcRef1.ColumnEdit = this.luecRef1;
            this.gvcRef1.FieldName = "cRef1";
            this.gvcRef1.Name = "gvcRef1";
            this.gvcRef1.Visible = true;
            this.gvcRef1.VisibleIndex = 1;
            // 
            // luecRef1
            // 
            this.luecRef1.AutoHeight = false;
            this.luecRef1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecRef1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDataId", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cObjNo", "类型编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDataNo", "资料编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDataValue", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cMemo", "备注", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecRef1.DisplayMember = "cDataValue";
            this.luecRef1.Name = "luecRef1";
            this.luecRef1.SortColumnIndex = 1;
            this.luecRef1.ValueMember = "cDataValue";
            this.luecRef1.EditValueChanged += new System.EventHandler(this.lueGrid_EditValueChanged);
            // 
            // gvcRef2
            // 
            this.gvcRef2.Caption = "参考值2";
            this.gvcRef2.ColumnEdit = this.luecRef2;
            this.gvcRef2.FieldName = "cRef2";
            this.gvcRef2.Name = "gvcRef2";
            this.gvcRef2.Visible = true;
            this.gvcRef2.VisibleIndex = 2;
            // 
            // luecRef2
            // 
            this.luecRef2.AutoHeight = false;
            this.luecRef2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecRef2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDataId", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cObjNo", "类型编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDataNo", "资料编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDataValue", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cMemo", "备注", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecRef2.DisplayMember = "cDataValue";
            this.luecRef2.Name = "luecRef2";
            this.luecRef2.SortColumnIndex = 1;
            this.luecRef2.ValueMember = "cDataValue";
            this.luecRef2.EditValueChanged += new System.EventHandler(this.lueGrid_EditValueChanged);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(49, 22);
            this.tsbDel.Text = "删行";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbModify
            // 
            this.tsbModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify.Image")));
            this.tsbModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify.Name = "tsbModify";
            this.tsbModify.Size = new System.Drawing.Size(49, 22);
            this.tsbModify.Text = "修改";
            this.tsbModify.Click += new System.EventHandler(this.tsbModify_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(49, 22);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbModify,
            this.toolStripSeparator4,
            this.tsbDel,
            this.tsbSave,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.tsbNew});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 114;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(49, 22);
            this.tsbNew.Text = "增行";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // frmDeptRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcList);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDeptRef";
            this.Size = new System.Drawing.Size(784, 463);
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gcView;
        private DevExpress.XtraGrid.Columns.GridColumn gvcDeptRefId;
        private DevExpress.XtraGrid.Columns.GridColumn gvcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn gvcRef1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luecRef1;
        private DevExpress.XtraGrid.Columns.GridColumn gvcRef2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luecRef2;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbNew;


    }
}
