namespace Card
{
    partial class frmArrangeClass
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckControl2 = new myControl.ckControl();
            this.ckControl1 = new myControl.ckControl();
            this.mkMonth = new System.Windows.Forms.DateTimePicker();
            this.lupClass = new myControl.lupControl();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridEmp = new DevExpress.XtraGrid.GridControl();
            this.viewEmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.arrayGrid = new DevExpress.XtraGrid.GridControl();
            this.arrayView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEmp)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrayGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrayView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.ckControl2);
            this.panel1.Controls.Add(this.ckControl1);
            this.panel1.Controls.Add(this.mkMonth);
            this.panel1.Controls.Add(this.lupClass);
            this.panel1.Controls.Add(this.btnGen);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 47);
            this.panel1.TabIndex = 0;
            // 
            // ckControl2
            // 
            this.ckControl2.BackColor = System.Drawing.Color.Transparent;
            this.ckControl2.DataField = null;
            this.ckControl2.DataSource = null;
            this.ckControl2.EditLabel = "节假日不排班";
            this.ckControl2.Location = new System.Drawing.Point(455, 25);
            this.ckControl2.Name = "ckControl2";
            this.ckControl2.Size = new System.Drawing.Size(96, 19);
            this.ckControl2.TabIndex = 9;
            // 
            // ckControl1
            // 
            this.ckControl1.BackColor = System.Drawing.Color.Transparent;
            this.ckControl1.DataField = null;
            this.ckControl1.DataSource = null;
            this.ckControl1.EditLabel = "周六日不排班";
            this.ckControl1.Location = new System.Drawing.Point(455, 3);
            this.ckControl1.Name = "ckControl1";
            this.ckControl1.Size = new System.Drawing.Size(96, 19);
            this.ckControl1.TabIndex = 8;
            // 
            // mkMonth
            // 
            this.mkMonth.CustomFormat = "yyyy年MM月";
            this.mkMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mkMonth.Location = new System.Drawing.Point(68, 12);
            this.mkMonth.Name = "mkMonth";
            this.mkMonth.Size = new System.Drawing.Size(82, 21);
            this.mkMonth.TabIndex = 7;
            // 
            // lupClass
            // 
            this.lupClass.BackColor = System.Drawing.Color.Transparent;
            this.lupClass.DataField = null;
            this.lupClass.DataSource = null;
            this.lupClass.DisplayCaption = "";
            this.lupClass.DropSQL = "";
            this.lupClass.EditLabel = "班次:";
            this.lupClass.InvokeClass = "";
            this.lupClass.LinkFields = null;
            this.lupClass.Location = new System.Drawing.Point(263, 12);
            this.lupClass.LookUpDataSource = null;
            this.lupClass.LookUpDisplayField = null;
            this.lupClass.LookUpKeyField = null;
            this.lupClass.Name = "lupClass";
            this.lupClass.PopWidth = 150;
            this.lupClass.Request = false;
            this.lupClass.Size = new System.Drawing.Size(177, 22);
            this.lupClass.TabIndex = 6;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(157, 12);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 5;
            this.btnGen.Text = "生成排班";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(716, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "排班月份:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridEmp);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.arrayGrid);
            this.splitContainer1.Size = new System.Drawing.Size(794, 487);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 3;
            // 
            // gridEmp
            // 
            this.gridEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmp.EmbeddedNavigator.Name = "";
            this.gridEmp.Location = new System.Drawing.Point(0, 37);
            this.gridEmp.MainView = this.viewEmp;
            this.gridEmp.Name = "gridEmp";
            this.gridEmp.Size = new System.Drawing.Size(263, 450);
            this.gridEmp.TabIndex = 3;
            this.gridEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewEmp});
            // 
            // viewEmp
            // 
            this.viewEmp.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.viewEmp.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewEmp.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.viewEmp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.viewEmp.GridControl = this.gridEmp;
            this.viewEmp.Name = "viewEmp";
            this.viewEmp.OptionsBehavior.Editable = false;
            this.viewEmp.OptionsView.ColumnAutoWidth = false;
            this.viewEmp.OptionsView.ShowGroupPanel = false;
            this.viewEmp.OptionsView.ShowIndicator = false;
            this.viewEmp.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewEmp_FocusedRowChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "员工编码";
            this.gridColumn3.FieldName = "F_ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 67;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "员工姓名";
            this.gridColumn4.FieldName = "F_Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "部门";
            this.gridColumn5.FieldName = "F_Dept";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 37);
            this.panel2.TabIndex = 4;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(68, 7);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(5, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // arrayGrid
            // 
            this.arrayGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arrayGrid.EmbeddedNavigator.Name = "";
            this.arrayGrid.Location = new System.Drawing.Point(0, 0);
            this.arrayGrid.MainView = this.arrayView;
            this.arrayGrid.Name = "arrayGrid";
            this.arrayGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.arrayGrid.Size = new System.Drawing.Size(527, 487);
            this.arrayGrid.TabIndex = 2;
            this.arrayGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.arrayView});
            // 
            // arrayView
            // 
            this.arrayView.CardWidth = 100;
            this.arrayView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.arrayView.FocusedCardTopFieldIndex = 0;
            this.arrayView.GridControl = this.arrayGrid;
            this.arrayView.Name = "arrayView";
            this.arrayView.OptionsView.ShowCardCaption = false;
            this.arrayView.OptionsView.ShowFieldCaptions = false;
            this.arrayView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "日期";
            this.gridColumn1.FieldName = "F_Day";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "班次";
            this.gridColumn2.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn2.FieldName = "F_Class";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(635, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmArrangeClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(794, 534);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmArrangeClass";
            this.Text = "排班";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEmp)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arrayGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrayView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private System.Windows.Forms.Button btnGen;
        private myControl.lupControl lupClass;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView viewEmp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private DevExpress.XtraGrid.GridControl arrayGrid;
        private DevExpress.XtraGrid.Views.Card.CardView arrayView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.DateTimePicker mkMonth;
        private myControl.ckControl ckControl1;
        private myControl.ckControl ckControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.Button btnSave;
    }
}
