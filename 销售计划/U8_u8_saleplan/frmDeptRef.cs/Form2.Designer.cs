namespace frmDeptRef.cs
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gcView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gccDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDepartment = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gciYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRefType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luecRef = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gciMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboiMonth = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcnRate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcnRate2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcnRate3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcList
            // 
            this.gcList.EmbeddedNavigator.Name = "";
            this.gcList.Location = new System.Drawing.Point(28, 35);
            this.gcList.MainView = this.gcView;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueDepartment,
            this.luecRef,
            this.cboiMonth});
            this.gcList.Size = new System.Drawing.Size(710, 335);
            this.gcList.TabIndex = 0;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gcView});
            // 
            // gcView
            // 
            this.gcView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gccDepCode,
            this.gciYear,
            this.gccRefType,
            this.gciMonth,
            this.gcnRate1,
            this.gcnRate2,
            this.gcnRate3,
            this.gcID});
            this.gcView.GridControl = this.gcList;
            this.gcView.Name = "gcView";
            this.gcView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            //this.gcView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gcView_CellValueChanged);
            // 
            // gccDepCode
            // 
            this.gccDepCode.Caption = "部门";
            this.gccDepCode.ColumnEdit = this.lueDepartment;
            this.gccDepCode.FieldName = "cDepCode";
            this.gccDepCode.Name = "gccDepCode";
            this.gccDepCode.Visible = true;
            this.gccDepCode.VisibleIndex = 0;
            this.gccDepCode.Width = 122;
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
            // gciYear
            // 
            this.gciYear.Caption = "年份";
            this.gciYear.FieldName = "iYear";
            this.gciYear.Name = "gciYear";
            this.gciYear.Visible = true;
            this.gciYear.VisibleIndex = 1;
            this.gciYear.Width = 94;
            // 
            // gccRefType
            // 
            this.gccRefType.Caption = "参考值";
            this.gccRefType.ColumnEdit = this.luecRef;
            this.gccRefType.FieldName = "cRefType";
            this.gccRefType.Name = "gccRefType";
            this.gccRefType.Visible = true;
            this.gccRefType.VisibleIndex = 2;
            this.gccRefType.Width = 94;
            // 
            // luecRef
            // 
            this.luecRef.AutoHeight = false;
            this.luecRef.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecRef.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRefType", "参考值", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecRef.DisplayMember = "cRefType";
            this.luecRef.Name = "luecRef";
            this.luecRef.ValueMember = "cRefType";
            // 
            // gciMonth
            // 
            this.gciMonth.Caption = "月份";
            this.gciMonth.ColumnEdit = this.cboiMonth;
            this.gciMonth.FieldName = "iMonth";
            this.gciMonth.Name = "gciMonth";
            this.gciMonth.Visible = true;
            this.gciMonth.VisibleIndex = 3;
            this.gciMonth.Width = 94;
            // 
            // cboiMonth
            // 
            this.cboiMonth.AutoHeight = false;
            this.cboiMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboiMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboiMonth.Name = "cboiMonth";
            // 
            // gcnRate1
            // 
            this.gcnRate1.FieldName = "nRate1";
            this.gcnRate1.Name = "gcnRate1";
            this.gcnRate1.Visible = true;
            this.gcnRate1.VisibleIndex = 4;
            this.gcnRate1.Width = 94;
            // 
            // gcnRate2
            // 
            this.gcnRate2.FieldName = "nRate2";
            this.gcnRate2.Name = "gcnRate2";
            this.gcnRate2.Visible = true;
            this.gcnRate2.VisibleIndex = 5;
            this.gcnRate2.Width = 94;
            // 
            // gcnRate3
            // 
            this.gcnRate3.FieldName = "nRate3";
            this.gcnRate3.Name = "gcnRate3";
            this.gcnRate3.Visible = true;
            this.gcnRate3.VisibleIndex = 6;
            this.gcnRate3.Width = 97;
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "cId";
            this.gcID.Name = "gcID";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbModify,
            this.toolStripSeparator4,
            this.tsbDel,
            this.toolStripSeparator2,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbNew,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1152, 25);
            this.toolStrip1.TabIndex = 113;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 479);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gcList);
            this.Name = "Form2";
            this.Text = "参考值指数录入";
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gcView;
        private DevExpress.XtraGrid.Columns.GridColumn gccDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gciYear;
        private DevExpress.XtraGrid.Columns.GridColumn gccRefType;
        private DevExpress.XtraGrid.Columns.GridColumn gciMonth;
        private DevExpress.XtraGrid.Columns.GridColumn gcnRate1;
        private DevExpress.XtraGrid.Columns.GridColumn gcnRate2;
        private DevExpress.XtraGrid.Columns.GridColumn gcnRate3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luecRef;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboiMonth;
    }
}