namespace OutProduct
{
    partial class frmOutPay
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
            this.lupControl1 = new myControl.lupControl();
            this.editControl5 = new myControl.EditControl();
            this.spinControl1 = new myControl.SpinControl();
            this.cbControl2 = new myControl.cbControl();
            this.sbAuto = new DevExpress.XtraEditors.SimpleButton();
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
            this.dateControl1.Location = new System.Drawing.Point(616, 34);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(616, 6);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.sbAuto);
            this.panelControl1.Controls.Add(this.cbControl2);
            this.panelControl1.Controls.Add(this.spinControl1);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(819, 126);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.spinControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbAuto, 0);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_OutSupplierID";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "厂商:";
            this.lupControl1.Location = new System.Drawing.Point(37, 61);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(258, 22);
            this.lupControl1.TabIndex = 3;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(37, 91);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(560, 27);
            this.editControl5.TabIndex = 4;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Money";
            this.spinControl1.EditLabel = "付款金额:";
            this.spinControl1.Location = new System.Drawing.Point(341, 61);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(162, 21);
            this.spinControl1.TabIndex = 7;
            // 
            // cbControl2
            // 
            this.cbControl2.BackColor = System.Drawing.Color.Transparent;
            this.cbControl2.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[0];
            this.cbControl2.DataField = "F_PayMode";
            this.cbControl2.EditLabel = "付款方式:";
            this.cbControl2.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl2.Location = new System.Drawing.Point(341, 34);
            this.cbControl2.Name = "cbControl2";
            this.cbControl2.Request = false;
            this.cbControl2.Size = new System.Drawing.Size(162, 21);
            this.cbControl2.TabIndex = 8;
            // 
            // sbAuto
            // 
            this.sbAuto.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAuto.Appearance.Options.UseFont = true;
            this.sbAuto.Location = new System.Drawing.Point(624, 91);
            this.sbAuto.Name = "sbAuto";
            this.sbAuto.Size = new System.Drawing.Size(68, 23);
            this.sbAuto.TabIndex = 9;
            this.sbAuto.Text = "自动分配";
            this.sbAuto.Click += new System.EventHandler(this.sbAuto_Click);
            // 
            // frmOutPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(819, 531);
            this.Name = "frmOutPay";
            this.Text = "外加工付款单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmOutPay_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl5;
        public myControl.SpinControl spinControl1;
        public myControl.cbControl cbControl2;
        public DevExpress.XtraEditors.SimpleButton sbAuto;

    }
}
