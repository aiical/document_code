namespace Product
{
    partial class frmProductStatus
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl5 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.dateControl2 = new myControl.DateControl();
            this.cbControl1 = new myControl.cbControl();
            this.sbFetch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(94, 21);
            this.lbTitle.Text = "frmBase";
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(607, 36);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(607, 8);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.sbFetch);
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.dateControl2);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(814, 126);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbFetch, 0);
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(37, 91);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(596, 27);
            this.editControl5.TabIndex = 4;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_TaskID";
            this.lupControl2.DisplayCaption = "单号,开单日期,开单人,审核人,审核日期";
            this.lupControl2.EditLabel = "任务单号:";
            this.lupControl2.Location = new System.Drawing.Point(12, 63);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = true;
            this.lupControl2.Size = new System.Drawing.Size(245, 22);
            this.lupControl2.TabIndex = 7;
            // 
            // dateControl2
            // 
            this.dateControl2.BackColor = System.Drawing.Color.Transparent;
            this.dateControl2.DataField = "F_FinishDate";
            this.dateControl2.EditLabel = "完工日期:";
            this.dateControl2.Location = new System.Drawing.Point(280, 63);
            this.dateControl2.Name = "dateControl2";
            this.dateControl2.Request = true;
            this.dateControl2.Size = new System.Drawing.Size(185, 21);
            this.dateControl2.TabIndex = 8;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "正常单";
            comboBoxItem2.Value = "返工单";
            comboBoxItem3.Value = "其它";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.EditLabel = "单据类别:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(471, 63);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.Size = new System.Drawing.Size(162, 21);
            this.cbControl1.TabIndex = 9;
            // 
            // sbFetch
            // 
            this.sbFetch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbFetch.Appearance.Options.UseFont = true;
            this.sbFetch.Location = new System.Drawing.Point(639, 91);
            this.sbFetch.Name = "sbFetch";
            this.sbFetch.Size = new System.Drawing.Size(68, 23);
            this.sbFetch.TabIndex = 10;
            this.sbFetch.Text = "取出明细";
            this.sbFetch.Click += new System.EventHandler(this.sbFetch_Click);
            // 
            // frmProductStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(814, 525);
            this.Name = "frmProductStatus";
            this.Text = "生产状况表";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmProductStatus_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public myControl.EditControl editControl5;
        public myControl.lupControl lupControl2;
        public myControl.DateControl dateControl2;
        public myControl.cbControl cbControl1;
        public DevExpress.XtraEditors.SimpleButton sbFetch;

    }
}
