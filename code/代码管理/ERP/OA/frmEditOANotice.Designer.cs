namespace OA
{
    partial class frmEditOANotice
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
            this.dateControl1 = new myControl.DateControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.binEmp = new System.Windows.Forms.BindingSource(this.components);
            this.gvEmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbSel = new DevExpress.XtraEditors.SimpleButton();
            this.sbRemove = new DevExpress.XtraEditors.SimpleButton();
            this.editControl1 = new myControl.EditControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(474, 377);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(555, 377);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Controls.Add(this.sbRemove);
            this.gbox.Controls.Add(this.sbSel);
            this.gbox.Controls.Add(this.gridControl1);
            this.gbox.Controls.Add(this.label2);
            this.gbox.Controls.Add(this.label1);
            this.gbox.Controls.Add(this.memoEdit1);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Size = new System.Drawing.Size(617, 358);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(11, 381);
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_ExeDate";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "生效日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(181, 35);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(199, 21);
            this.dateControl1.TabIndex = 2;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(12, 59);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(368, 293);
            this.memoEdit1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "通知内容:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "通知人员:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.binEmp;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(386, 35);
            this.gridControl1.MainView = this.gvEmp;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(225, 317);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmp});
            // 
            // gvEmp
            // 
            this.gvEmp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvEmp.GridControl = this.gridControl1;
            this.gvEmp.Name = "gvEmp";
            this.gvEmp.OptionsBehavior.Editable = false;
            this.gvEmp.OptionsView.ColumnAutoWidth = false;
            this.gvEmp.OptionsView.ShowGroupPanel = false;
            this.gvEmp.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "员工";
            this.gridColumn1.FieldName = "F_EmpName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 186;
            // 
            // sbSel
            // 
            this.sbSel.Location = new System.Drawing.Point(559, 11);
            this.sbSel.Name = "sbSel";
            this.sbSel.Size = new System.Drawing.Size(52, 23);
            this.sbSel.TabIndex = 6;
            this.sbSel.Text = "选择";
            this.sbSel.Click += new System.EventHandler(this.sbSel_Click);
            // 
            // sbRemove
            // 
            this.sbRemove.Location = new System.Drawing.Point(505, 11);
            this.sbRemove.Name = "sbRemove";
            this.sbRemove.Size = new System.Drawing.Size(48, 23);
            this.sbRemove.TabIndex = 7;
            this.sbRemove.Text = "移除";
            this.sbRemove.Click += new System.EventHandler(this.sbRemove_Click);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_Title";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "标题:";
            this.editControl1.Location = new System.Drawing.Point(6, 10);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(372, 21);
            this.editControl1.TabIndex = 1;
            // 
            // frmEditOANotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(638, 412);
            this.Name = "frmEditOANotice";
            this.Text = "通知--编辑";
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.DateControl dateControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmp;
        private DevExpress.XtraEditors.SimpleButton sbSel;
        private System.Windows.Forms.BindingSource binEmp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton sbRemove;
        private myControl.EditControl editControl1;
    }
}
