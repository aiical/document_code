namespace Base
{
    partial class frmAssist
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
            this.cbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcAssist = new DevExpress.XtraGrid.GridControl();
            this.gvAssist = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.sbAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sbEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAssist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssist)).BeginInit();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.EditValue = "计量单位";
            this.cbType.Location = new System.Drawing.Point(12, 19);
            this.cbType.Name = "cbType";
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbType.Properties.Items.AddRange(new object[] {
            "计量单位",
            "收付款方式",
            "颜色",
            "送货方式"});
            this.cbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbType.Size = new System.Drawing.Size(276, 21);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // gcAssist
            // 
            this.gcAssist.EmbeddedNavigator.Name = "";
            this.gcAssist.Location = new System.Drawing.Point(12, 46);
            this.gcAssist.MainView = this.gvAssist;
            this.gcAssist.Name = "gcAssist";
            this.gcAssist.Size = new System.Drawing.Size(276, 260);
            this.gcAssist.TabIndex = 1;
            this.gcAssist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAssist});
            // 
            // gvAssist
            // 
            this.gvAssist.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1});
            this.gvAssist.GridControl = this.gcAssist;
            this.gvAssist.Name = "gvAssist";
            this.gvAssist.OptionsBehavior.Editable = false;
            this.gvAssist.OptionsCustomization.AllowFilter = false;
            this.gvAssist.OptionsView.ColumnAutoWidth = false;
            this.gvAssist.OptionsView.ShowGroupPanel = false;
            this.gvAssist.DoubleClick += new System.EventHandler(this.gvAssist_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "编码";
            this.gridColumn2.FieldName = "F_ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 79;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "名称";
            this.gridColumn1.FieldName = "F_Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "类别:";
            // 
            // sbAdd
            // 
            this.sbAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAdd.Appearance.Options.UseFont = true;
            this.sbAdd.Location = new System.Drawing.Point(317, 46);
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(75, 23);
            this.sbAdd.TabIndex = 3;
            this.sbAdd.Text = "增加(&A)";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // sbEdit
            // 
            this.sbEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbEdit.Appearance.Options.UseFont = true;
            this.sbEdit.Location = new System.Drawing.Point(317, 75);
            this.sbEdit.Name = "sbEdit";
            this.sbEdit.Size = new System.Drawing.Size(75, 23);
            this.sbEdit.TabIndex = 4;
            this.sbEdit.Text = "修改(&E)";
            this.sbEdit.Click += new System.EventHandler(this.sbEdit_Click);
            // 
            // sbDel
            // 
            this.sbDel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDel.Appearance.Options.UseFont = true;
            this.sbDel.Location = new System.Drawing.Point(317, 104);
            this.sbDel.Name = "sbDel";
            this.sbDel.Size = new System.Drawing.Size(75, 23);
            this.sbDel.TabIndex = 5;
            this.sbDel.Text = "删除(&D)";
            this.sbDel.Click += new System.EventHandler(this.sbDel_Click);
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Location = new System.Drawing.Point(317, 271);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(75, 23);
            this.sbClose.TabIndex = 6;
            this.sbClose.Text = "关闭(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // frmAssist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(425, 318);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbDel);
            this.Controls.Add(this.sbEdit);
            this.Controls.Add(this.sbAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gcAssist);
            this.Controls.Add(this.cbType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssist";
            this.Text = "辅助资料";
            this.Load += new System.EventHandler(this.frmAssist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAssist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbType;
        private DevExpress.XtraGrid.GridControl gcAssist;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAssist;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton sbAdd;
        private DevExpress.XtraEditors.SimpleButton sbEdit;
        private DevExpress.XtraEditors.SimpleButton sbDel;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
