namespace Base
{
    partial class frmEditCast
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
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lupDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lupProcess = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.sbAddRow = new DevExpress.XtraEditors.SimpleButton();
            this.sbDelRow = new DevExpress.XtraEditors.SimpleButton();
            this.dateControl1 = new myControl.DateControl();
            this.dateControl2 = new myControl.DateControl();
            this.editControl3 = new myControl.EditControl();
            this.sbLoadFile = new DevExpress.XtraEditors.SimpleButton();
            this.sbViewFile = new DevExpress.XtraEditors.SimpleButton();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
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
            this.BtnOK.Location = new System.Drawing.Point(526, 431);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(603, 431);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.sbViewFile);
            this.gbox.Controls.Add(this.sbLoadFile);
            this.gbox.Controls.Add(this.editControl3);
            this.gbox.Controls.Add(this.dateControl2);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Size = new System.Drawing.Size(665, 117);
            // 
            // ckCopy
            // 
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "证书编码:";
            this.editControl1.Location = new System.Drawing.Point(7, 21);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(181, 27);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "证书名称:";
            this.editControl2.Location = new System.Drawing.Point(205, 21);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(204, 27);
            this.editControl2.TabIndex = 1;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Remark";
            this.editControl9.DataSource = null;
            this.editControl9.EditLabel = "备注:";
            this.editControl9.Location = new System.Drawing.Point(30, 84);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(629, 27);
            this.editControl9.TabIndex = 9;
            // 
            // gcDetail
            // 
            this.gcDetail.EmbeddedNavigator.Name = "";
            this.gcDetail.Location = new System.Drawing.Point(13, 136);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lupDept,
            this.lupProcess});
            this.gcDetail.Size = new System.Drawing.Size(665, 276);
            this.gcDetail.TabIndex = 2;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsBehavior.Editable = false;
            this.gvDetail.OptionsCustomization.AllowFilter = false;
            this.gvDetail.OptionsView.ColumnAutoWidth = false;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            this.gvDetail.OptionsView.ShowIndicator = false;
            this.gvDetail.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvDetail_InitNewRow);
            this.gvDetail.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvDetail_CustomDrawCell);
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
            this.gridColumn1.Width = 44;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "产品编码";
            this.gridColumn2.FieldName = "F_ItemID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 79;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "产品名称";
            this.gridColumn4.FieldName = "F_ItemName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 142;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "规格";
            this.gridColumn3.FieldName = "F_Spec";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 126;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "颜色";
            this.gridColumn5.FieldName = "F_Color";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "品牌";
            this.gridColumn6.FieldName = "F_Brand";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "材质";
            this.gridColumn7.FieldName = "F_Material";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
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
            // sbAddRow
            // 
            this.sbAddRow.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAddRow.Appearance.Options.UseFont = true;
            this.sbAddRow.Location = new System.Drawing.Point(8, 431);
            this.sbAddRow.Name = "sbAddRow";
            this.sbAddRow.Size = new System.Drawing.Size(57, 23);
            this.sbAddRow.TabIndex = 3;
            this.sbAddRow.Text = "添加";
            this.sbAddRow.Click += new System.EventHandler(this.sbAddRow_Click);
            // 
            // sbDelRow
            // 
            this.sbDelRow.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDelRow.Appearance.Options.UseFont = true;
            this.sbDelRow.Location = new System.Drawing.Point(71, 431);
            this.sbDelRow.Name = "sbDelRow";
            this.sbDelRow.Size = new System.Drawing.Size(57, 23);
            this.sbDelRow.TabIndex = 4;
            this.sbDelRow.Text = "移除";
            this.sbDelRow.Click += new System.EventHandler(this.sbDelRow_Click);
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Begin";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "生效日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(4, 54);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(184, 21);
            this.dateControl1.TabIndex = 10;
            // 
            // dateControl2
            // 
            this.dateControl2.BackColor = System.Drawing.Color.Transparent;
            this.dateControl2.DataField = "F_End";
            this.dateControl2.DataSource = null;
            this.dateControl2.DisplayFormat = "d";
            this.dateControl2.EditLabel = "失效日期:";
            this.dateControl2.EditMask = "d";
            this.dateControl2.Location = new System.Drawing.Point(205, 54);
            this.dateControl2.Name = "dateControl2";
            this.dateControl2.Request = false;
            this.dateControl2.Size = new System.Drawing.Size(204, 21);
            this.dateControl2.TabIndex = 11;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_Comp";
            this.editControl3.DataSource = null;
            this.editControl3.EditLabel = "认证公司:";
            this.editControl3.Location = new System.Drawing.Point(434, 51);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(225, 27);
            this.editControl3.TabIndex = 12;
            // 
            // sbLoadFile
            // 
            this.sbLoadFile.Location = new System.Drawing.Point(503, 20);
            this.sbLoadFile.Name = "sbLoadFile";
            this.sbLoadFile.Size = new System.Drawing.Size(75, 23);
            this.sbLoadFile.TabIndex = 13;
            this.sbLoadFile.Text = "加载附件";
            this.sbLoadFile.Click += new System.EventHandler(this.sbLoadFile_Click);
            // 
            // sbViewFile
            // 
            this.sbViewFile.Location = new System.Drawing.Point(584, 20);
            this.sbViewFile.Name = "sbViewFile";
            this.sbViewFile.Size = new System.Drawing.Size(75, 23);
            this.sbViewFile.TabIndex = 14;
            this.sbViewFile.Text = "查看附件";
            this.sbViewFile.Click += new System.EventHandler(this.sbViewFile_Click);
            // 
            // frmEditCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(690, 466);
            this.Controls.Add(this.sbDelRow);
            this.Controls.Add(this.sbAddRow);
            this.Controls.Add(this.gcDetail);
            this.Name = "frmEditCast";
            this.Text = "产品证书--编辑";
            this.Controls.SetChildIndex(this.ckCopy, 0);
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gcDetail, 0);
            this.Controls.SetChildIndex(this.sbAddRow, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.Controls.SetChildIndex(this.sbDelRow, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton sbAddRow;
        private DevExpress.XtraEditors.SimpleButton sbDelRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupDept;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupProcess;
        private myControl.DateControl dateControl2;
        private myControl.DateControl dateControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private myControl.EditControl editControl3;
        private DevExpress.XtraEditors.SimpleButton sbViewFile;
        private DevExpress.XtraEditors.SimpleButton sbLoadFile;

    }
}
