namespace Base
{
    partial class frmEditCraftwork
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
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lupDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lupProcess = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbAddRow = new DevExpress.XtraEditors.SimpleButton();
            this.sbDelRow = new DevExpress.XtraEditors.SimpleButton();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(301, 269);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(378, 269);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Size = new System.Drawing.Size(440, 86);
            // 
            // editControl1
            // 
            this.editControl1.DataField = "F_ID";
            this.editControl1.EditLabel = "工艺代码:";
            this.editControl1.Location = new System.Drawing.Point(7, 21);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(158, 27);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.DataField = "F_Name";
            this.editControl2.EditLabel = "工艺名称:";
            this.editControl2.Location = new System.Drawing.Point(193, 20);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(204, 27);
            this.editControl2.TabIndex = 1;
            // 
            // editControl9
            // 
            this.editControl9.DataField = "F_Remark";
            this.editControl9.EditLabel = "备注:";
            this.editControl9.Location = new System.Drawing.Point(30, 54);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(367, 27);
            this.editControl9.TabIndex = 9;
            // 
            // gcDetail
            // 
            this.gcDetail.EmbeddedNavigator.Name = "";
            this.gcDetail.Location = new System.Drawing.Point(13, 106);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lupDept,
            this.lupProcess});
            this.gcDetail.Size = new System.Drawing.Size(440, 157);
            this.gcDetail.TabIndex = 2;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsCustomization.AllowFilter = false;
            this.gvDetail.OptionsView.ColumnAutoWidth = false;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            this.gvDetail.OptionsView.ShowIndicator = false;
            this.gvDetail.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvDetail_CustomDrawCell);
            this.gvDetail.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvDetail_InitNewRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "序号";
            this.gridColumn1.FieldName = "Aid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 42;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "部门";
            this.gridColumn2.ColumnEdit = this.lupDept;
            this.gridColumn2.FieldName = "F_DeptID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 103;
            // 
            // lupDept
            // 
            this.lupDept.AutoHeight = false;
            this.lupDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupDept.Name = "lupDept";
            this.lupDept.NullText = "";
            this.lupDept.ShowFooter = false;
            this.lupDept.ShowHeader = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "工序";
            this.gridColumn3.ColumnEdit = this.lupProcess;
            this.gridColumn3.FieldName = "F_ProcessID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 111;
            // 
            // lupProcess
            // 
            this.lupProcess.AutoHeight = false;
            this.lupProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProcess.Name = "lupProcess";
            this.lupProcess.NullText = "";
            this.lupProcess.ShowFooter = false;
            this.lupProcess.ShowHeader = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "备注";
            this.gridColumn4.FieldName = "F_Remark";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 137;
            // 
            // sbAddRow
            // 
            this.sbAddRow.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAddRow.Appearance.Options.UseFont = true;
            this.sbAddRow.Location = new System.Drawing.Point(13, 269);
            this.sbAddRow.Name = "sbAddRow";
            this.sbAddRow.Size = new System.Drawing.Size(57, 23);
            this.sbAddRow.TabIndex = 3;
            this.sbAddRow.Text = "增行";
            this.sbAddRow.Click += new System.EventHandler(this.sbAddRow_Click);
            // 
            // sbDelRow
            // 
            this.sbDelRow.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDelRow.Appearance.Options.UseFont = true;
            this.sbDelRow.Location = new System.Drawing.Point(76, 269);
            this.sbDelRow.Name = "sbDelRow";
            this.sbDelRow.Size = new System.Drawing.Size(57, 23);
            this.sbDelRow.TabIndex = 4;
            this.sbDelRow.Text = "删行";
            this.sbDelRow.Click += new System.EventHandler(this.sbDelRow_Click);
            // 
            // frmEditCraftwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(465, 304);
            this.Controls.Add(this.sbDelRow);
            this.Controls.Add(this.sbAddRow);
            this.Controls.Add(this.gcDetail);
            this.Name = "frmEditCraftwork";
            this.Text = "工艺流程--编辑";
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gcDetail, 0);
            this.Controls.SetChildIndex(this.sbAddRow, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.Controls.SetChildIndex(this.sbDelRow, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProcess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl1;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl9;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton sbAddRow;
        private DevExpress.XtraEditors.SimpleButton sbDelRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupDept;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupProcess;

    }
}
