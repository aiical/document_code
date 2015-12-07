namespace CommonData
{
    partial class frmSetField
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
            this.sbRemove = new DevExpress.XtraEditors.SimpleButton();
            this.sbAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lbDes = new DevExpress.XtraEditors.ListBoxControl();
            this.lbRight = new DevExpress.XtraEditors.ListBoxControl();
            this.lbLeft = new DevExpress.XtraEditors.ListBoxControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.lbDes1 = new DevExpress.XtraEditors.ListBoxControl();
            this.lbRight1 = new DevExpress.XtraEditors.ListBoxControl();
            this.lbLeft1 = new DevExpress.XtraEditors.ListBoxControl();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbDes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLeft)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbDes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLeft1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(8, 5);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(297, 351);
            this.xtraTabControl1.TabIndex = 7;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.sbRemove);
            this.xtraTabPage1.Controls.Add(this.sbAdd);
            this.xtraTabPage1.Controls.Add(this.lbDes);
            this.xtraTabPage1.Controls.Add(this.lbRight);
            this.xtraTabPage1.Controls.Add(this.lbLeft);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(291, 324);
            this.xtraTabPage1.Text = "主表";
            // 
            // sbRemove
            // 
            this.sbRemove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbRemove.Appearance.Options.UseFont = true;
            this.sbRemove.Location = new System.Drawing.Point(240, 148);
            this.sbRemove.Name = "sbRemove";
            this.sbRemove.Size = new System.Drawing.Size(44, 23);
            this.sbRemove.TabIndex = 11;
            this.sbRemove.Text = "移除";
            this.sbRemove.Click += new System.EventHandler(this.sbRemove_Click);
            // 
            // sbAdd
            // 
            this.sbAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAdd.Appearance.Options.UseFont = true;
            this.sbAdd.Location = new System.Drawing.Point(190, 148);
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(44, 23);
            this.sbAdd.TabIndex = 10;
            this.sbAdd.Text = "加入";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // lbDes
            // 
            this.lbDes.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDes.Appearance.Options.UseFont = true;
            this.lbDes.Location = new System.Drawing.Point(8, 177);
            this.lbDes.Name = "lbDes";
            this.lbDes.Size = new System.Drawing.Size(278, 134);
            this.lbDes.TabIndex = 9;
            // 
            // lbRight
            // 
            this.lbRight.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight.Appearance.Options.UseFont = true;
            this.lbRight.Location = new System.Drawing.Point(147, 5);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(138, 137);
            this.lbRight.TabIndex = 8;
            // 
            // lbLeft
            // 
            this.lbLeft.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft.Appearance.Options.UseFont = true;
            this.lbLeft.Location = new System.Drawing.Point(8, 5);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(133, 137);
            this.lbLeft.TabIndex = 7;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.simpleButton1);
            this.xtraTabPage2.Controls.Add(this.simpleButton2);
            this.xtraTabPage2.Controls.Add(this.lbDes1);
            this.xtraTabPage2.Controls.Add(this.lbRight1);
            this.xtraTabPage2.Controls.Add(this.lbLeft1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(291, 324);
            this.xtraTabPage2.Text = "从表";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(238, 152);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(44, 23);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "移除";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(188, 152);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(44, 23);
            this.simpleButton2.TabIndex = 15;
            this.simpleButton2.Text = "加入";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // lbDes1
            // 
            this.lbDes1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDes1.Appearance.Options.UseFont = true;
            this.lbDes1.Location = new System.Drawing.Point(6, 181);
            this.lbDes1.Name = "lbDes1";
            this.lbDes1.Size = new System.Drawing.Size(278, 134);
            this.lbDes1.TabIndex = 14;
            // 
            // lbRight1
            // 
            this.lbRight1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight1.Appearance.Options.UseFont = true;
            this.lbRight1.Location = new System.Drawing.Point(145, 9);
            this.lbRight1.Name = "lbRight1";
            this.lbRight1.Size = new System.Drawing.Size(138, 137);
            this.lbRight1.TabIndex = 13;
            // 
            // lbLeft1
            // 
            this.lbLeft1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft1.Appearance.Options.UseFont = true;
            this.lbLeft1.Location = new System.Drawing.Point(6, 9);
            this.lbLeft1.Name = "lbLeft1";
            this.lbLeft1.Size = new System.Drawing.Size(133, 137);
            this.lbLeft1.TabIndex = 12;
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(244, 362);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(57, 23);
            this.sbCancel.TabIndex = 15;
            this.sbCancel.Text = "取消(&C)";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click_1);
            // 
            // sbOK
            // 
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(181, 362);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(57, 23);
            this.sbOK.TabIndex = 14;
            this.sbOK.Text = "确定(&O)";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // frmSetField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(312, 390);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetField";
            this.Text = "字段设置";
            this.Load += new System.EventHandler(this.frmSetField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbDes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLeft)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbDes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLeft1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton sbRemove;
        private DevExpress.XtraEditors.SimpleButton sbAdd;
        private DevExpress.XtraEditors.ListBoxControl lbDes;
        private DevExpress.XtraEditors.ListBoxControl lbRight;
        private DevExpress.XtraEditors.ListBoxControl lbLeft;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.ListBoxControl lbDes1;
        private DevExpress.XtraEditors.ListBoxControl lbRight1;
        private DevExpress.XtraEditors.ListBoxControl lbLeft1;
    }
}
