namespace Base
{
    partial class frmEditClient
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
            this.lupControl1 = new myControl.lupControl();
            this.editControl3 = new myControl.EditControl();
            this.editControl4 = new myControl.EditControl();
            this.editControl5 = new myControl.EditControl();
            this.editControl6 = new myControl.EditControl();
            this.editControl7 = new myControl.EditControl();
            this.editControl8 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.editControl10 = new myControl.EditControl();
            this.editControl11 = new myControl.EditControl();
            this.editControl12 = new myControl.EditControl();
            this.editControl13 = new myControl.EditControl();
            this.editControl14 = new myControl.EditControl();
            this.editControl15 = new myControl.EditControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.Page1 = new DevExpress.XtraTab.XtraTabPage();
            this.Page2 = new DevExpress.XtraTab.XtraTabPage();
            this.picClient = new DevExpress.XtraEditors.PictureEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sbLoad = new DevExpress.XtraEditors.SimpleButton();
            this.spinControl1 = new myControl.SpinControl();
            this.editControl16 = new myControl.EditControl();
            this.editControl17 = new myControl.EditControl();
            this.editControl18 = new myControl.EditControl();
            this.spinControl2 = new myControl.SpinControl();
            this.sbHistory = new DevExpress.XtraEditors.SimpleButton();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.Page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClient.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(473, 427);
            this.BtnOK.Text = "保存(&S)";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(554, 427);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.spinControl2);
            this.gbox.Controls.Add(this.editControl18);
            this.gbox.Controls.Add(this.editControl17);
            this.gbox.Controls.Add(this.editControl16);
            this.gbox.Controls.Add(this.spinControl1);
            this.gbox.Controls.Add(this.editControl15);
            this.gbox.Controls.Add(this.editControl14);
            this.gbox.Controls.Add(this.editControl13);
            this.gbox.Controls.Add(this.editControl12);
            this.gbox.Controls.Add(this.editControl11);
            this.gbox.Controls.Add(this.editControl10);
            this.gbox.Controls.Add(this.lupControl3);
            this.gbox.Controls.Add(this.lupControl2);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl8);
            this.gbox.Controls.Add(this.editControl7);
            this.gbox.Controls.Add(this.editControl6);
            this.gbox.Controls.Add(this.editControl5);
            this.gbox.Controls.Add(this.editControl4);
            this.gbox.Controls.Add(this.editControl3);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Location = new System.Drawing.Point(13, -14);
            this.gbox.Size = new System.Drawing.Size(602, 389);
            // 
            // ckCopy
            // 
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "客户代码:";
            this.editControl1.Location = new System.Drawing.Point(14, 21);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(216, 21);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "客户名称:";
            this.editControl2.Location = new System.Drawing.Point(294, 21);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(270, 21);
            this.editControl2.TabIndex = 1;
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_Type";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "所属区域:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(14, 52);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(216, 22);
            this.lupControl1.TabIndex = 2;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_LinkMan";
            this.editControl3.DataSource = null;
            this.editControl3.EditLabel = "联 系 人1:";
            this.editControl3.Location = new System.Drawing.Point(14, 82);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(216, 21);
            this.editControl3.TabIndex = 3;
            // 
            // editControl4
            // 
            this.editControl4.BackColor = System.Drawing.Color.Transparent;
            this.editControl4.DataField = "F_Tel";
            this.editControl4.DataSource = null;
            this.editControl4.EditLabel = "联系电话1:";
            this.editControl4.Location = new System.Drawing.Point(294, 82);
            this.editControl4.Name = "editControl4";
            this.editControl4.Request = false;
            this.editControl4.Size = new System.Drawing.Size(270, 21);
            this.editControl4.TabIndex = 4;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Bank";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "开户银行:";
            this.editControl5.Location = new System.Drawing.Point(19, 168);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(207, 21);
            this.editControl5.TabIndex = 7;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_BankNo";
            this.editControl6.DataSource = null;
            this.editControl6.EditLabel = "银行帐号:";
            this.editControl6.Location = new System.Drawing.Point(294, 168);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(270, 21);
            this.editControl6.TabIndex = 8;
            // 
            // editControl7
            // 
            this.editControl7.BackColor = System.Drawing.Color.Transparent;
            this.editControl7.DataField = "F_PostCode";
            this.editControl7.DataSource = null;
            this.editControl7.EditLabel = "邮    编:";
            this.editControl7.Location = new System.Drawing.Point(321, 199);
            this.editControl7.Name = "editControl7";
            this.editControl7.Request = false;
            this.editControl7.Size = new System.Drawing.Size(243, 21);
            this.editControl7.TabIndex = 10;
            // 
            // editControl8
            // 
            this.editControl8.BackColor = System.Drawing.Color.Transparent;
            this.editControl8.DataField = "F_Adr";
            this.editControl8.DataSource = null;
            this.editControl8.EditLabel = "地    址:";
            this.editControl8.Location = new System.Drawing.Point(19, 227);
            this.editControl8.Name = "editControl8";
            this.editControl8.Request = false;
            this.editControl8.Size = new System.Drawing.Size(545, 21);
            this.editControl8.TabIndex = 11;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Remark";
            this.editControl9.DataSource = null;
            this.editControl9.EditLabel = "备    注:";
            this.editControl9.Location = new System.Drawing.Point(19, 309);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(550, 25);
            this.editControl9.TabIndex = 10;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_CarryCompany";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.DropSQL = "";
            this.lupControl2.EditLabel = "货运公司:";
            this.lupControl2.InvokeClass = "";
            this.lupControl2.LinkFields = null;
            this.lupControl2.Location = new System.Drawing.Point(294, 52);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = false;
            this.lupControl2.Size = new System.Drawing.Size(270, 22);
            this.lupControl2.TabIndex = 10;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_Opertor";
            this.lupControl3.DataSource = null;
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.DropSQL = "";
            this.lupControl3.EditLabel = "业 务 员:";
            this.lupControl3.InvokeClass = "";
            this.lupControl3.LinkFields = null;
            this.lupControl3.Location = new System.Drawing.Point(321, 280);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.PopWidth = 150;
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(248, 22);
            this.lupControl3.TabIndex = 11;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(13, 427);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "保存后新增";
            this.ckOption.Size = new System.Drawing.Size(101, 19);
            this.ckOption.TabIndex = 2;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
            // 
            // editControl10
            // 
            this.editControl10.BackColor = System.Drawing.Color.Transparent;
            this.editControl10.DataField = "F_Fax";
            this.editControl10.DataSource = null;
            this.editControl10.EditLabel = "传    真:";
            this.editControl10.Location = new System.Drawing.Point(19, 199);
            this.editControl10.Name = "editControl10";
            this.editControl10.Request = false;
            this.editControl10.Size = new System.Drawing.Size(207, 21);
            this.editControl10.TabIndex = 9;
            // 
            // editControl11
            // 
            this.editControl11.BackColor = System.Drawing.Color.Transparent;
            this.editControl11.DataField = "F_Legal";
            this.editControl11.DataSource = null;
            this.editControl11.EditLabel = "法人代表:";
            this.editControl11.Location = new System.Drawing.Point(19, 254);
            this.editControl11.Name = "editControl11";
            this.editControl11.Request = false;
            this.editControl11.Size = new System.Drawing.Size(216, 21);
            this.editControl11.TabIndex = 12;
            // 
            // editControl12
            // 
            this.editControl12.BackColor = System.Drawing.Color.Transparent;
            this.editControl12.DataField = "F_QQ";
            this.editControl12.DataSource = null;
            this.editControl12.EditLabel = "QQ号:";
            this.editControl12.Location = new System.Drawing.Point(348, 253);
            this.editControl12.Name = "editControl12";
            this.editControl12.Request = false;
            this.editControl12.Size = new System.Drawing.Size(216, 21);
            this.editControl12.TabIndex = 13;
            // 
            // editControl13
            // 
            this.editControl13.BackColor = System.Drawing.Color.Transparent;
            this.editControl13.DataField = "F_Source";
            this.editControl13.DataSource = null;
            this.editControl13.EditLabel = "客户来源:";
            this.editControl13.Location = new System.Drawing.Point(321, 340);
            this.editControl13.Name = "editControl13";
            this.editControl13.Request = false;
            this.editControl13.Size = new System.Drawing.Size(216, 21);
            this.editControl13.TabIndex = 14;
            // 
            // editControl14
            // 
            this.editControl14.BackColor = System.Drawing.Color.Transparent;
            this.editControl14.DataField = "F_Tel1";
            this.editControl14.DataSource = null;
            this.editControl14.EditLabel = "联系电话2:";
            this.editControl14.Location = new System.Drawing.Point(294, 109);
            this.editControl14.Name = "editControl14";
            this.editControl14.Request = false;
            this.editControl14.Size = new System.Drawing.Size(270, 21);
            this.editControl14.TabIndex = 5;
            // 
            // editControl15
            // 
            this.editControl15.BackColor = System.Drawing.Color.Transparent;
            this.editControl15.DataField = "F_Tel2";
            this.editControl15.DataSource = null;
            this.editControl15.EditLabel = "联系电话3:";
            this.editControl15.Location = new System.Drawing.Point(294, 136);
            this.editControl15.Name = "editControl15";
            this.editControl15.Request = false;
            this.editControl15.Size = new System.Drawing.Size(270, 21);
            this.editControl15.TabIndex = 6;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.Page1;
            this.xtraTabControl1.Size = new System.Drawing.Size(617, 418);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.Page1,
            this.Page2});
            // 
            // Page1
            // 
            this.Page1.Name = "Page1";
            this.Page1.Size = new System.Drawing.Size(608, 387);
            this.Page1.Text = "基本资料";
            // 
            // Page2
            // 
            this.Page2.Controls.Add(this.picClient);
            this.Page2.Controls.Add(this.panel1);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(608, 387);
            this.Page2.Text = "图片";
            // 
            // picClient
            // 
            this.picClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picClient.Location = new System.Drawing.Point(0, 0);
            this.picClient.Name = "picClient";
            this.picClient.Size = new System.Drawing.Size(608, 353);
            this.picClient.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.sbLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 34);
            this.panel1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(85, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(66, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "清除(&C)";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // sbLoad
            // 
            this.sbLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbLoad.Appearance.Options.UseFont = true;
            this.sbLoad.Location = new System.Drawing.Point(13, 4);
            this.sbLoad.Name = "sbLoad";
            this.sbLoad.Size = new System.Drawing.Size(66, 23);
            this.sbLoad.TabIndex = 0;
            this.sbLoad.Text = "加载(&L)";
            this.sbLoad.Click += new System.EventHandler(this.sbLoad_Click);
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_ClientXinyong";
            this.spinControl1.DataSource = null;
            this.spinControl1.EditLabel = "信用度:";
            this.spinControl1.Location = new System.Drawing.Point(33, 340);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(155, 21);
            this.spinControl1.TabIndex = 15;
            // 
            // editControl16
            // 
            this.editControl16.BackColor = System.Drawing.Color.Transparent;
            this.editControl16.DataField = "F_LinkMan1";
            this.editControl16.DataSource = null;
            this.editControl16.EditLabel = "联 系 人2:";
            this.editControl16.Location = new System.Drawing.Point(14, 109);
            this.editControl16.Name = "editControl16";
            this.editControl16.Request = false;
            this.editControl16.Size = new System.Drawing.Size(216, 21);
            this.editControl16.TabIndex = 16;
            // 
            // editControl17
            // 
            this.editControl17.BackColor = System.Drawing.Color.Transparent;
            this.editControl17.DataField = "F_LinkMan2";
            this.editControl17.DataSource = null;
            this.editControl17.EditLabel = "联 系 人3:";
            this.editControl17.Location = new System.Drawing.Point(14, 136);
            this.editControl17.Name = "editControl17";
            this.editControl17.Request = false;
            this.editControl17.Size = new System.Drawing.Size(216, 21);
            this.editControl17.TabIndex = 17;
            // 
            // editControl18
            // 
            this.editControl18.BackColor = System.Drawing.Color.Transparent;
            this.editControl18.DataField = "F_Email";
            this.editControl18.DataSource = null;
            this.editControl18.EditLabel = "EMail:";
            this.editControl18.Location = new System.Drawing.Point(33, 282);
            this.editControl18.Name = "editControl18";
            this.editControl18.Request = false;
            this.editControl18.Size = new System.Drawing.Size(216, 21);
            this.editControl18.TabIndex = 18;
            // 
            // spinControl2
            // 
            this.spinControl2.BackColor = System.Drawing.Color.Transparent;
            this.spinControl2.DataField = "F_QCMoney";
            this.spinControl2.DataSource = null;
            this.spinControl2.EditLabel = "期初:";
            this.spinControl2.Location = new System.Drawing.Point(44, 362);
            this.spinControl2.Name = "spinControl2";
            this.spinControl2.Size = new System.Drawing.Size(144, 21);
            this.spinControl2.TabIndex = 19;
            // 
            // sbHistory
            // 
            this.sbHistory.Location = new System.Drawing.Point(121, 428);
            this.sbHistory.Name = "sbHistory";
            this.sbHistory.Size = new System.Drawing.Size(92, 23);
            this.sbHistory.TabIndex = 8;
            this.sbHistory.Text = "客户成交历史";
            this.sbHistory.Visible = false;
            // 
            // frmEditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(641, 461);
            this.Controls.Add(this.sbHistory);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.ckOption);
            this.Name = "frmEditClient";
            this.Text = "客户资料--编辑";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.ckOption, 0);
            this.Controls.SetChildIndex(this.ckCopy, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            this.Controls.SetChildIndex(this.sbHistory, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.Page2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClient.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage Page1;
        private DevExpress.XtraTab.XtraTabPage Page2;
        private System.Windows.Forms.Panel panel1;
        public myControl.EditControl editControl1;
        public myControl.EditControl editControl2;
        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl4;
        public myControl.EditControl editControl3;
        public myControl.EditControl editControl9;
        public myControl.EditControl editControl8;
        public myControl.EditControl editControl7;
        public myControl.EditControl editControl6;
        public myControl.EditControl editControl5;
        public myControl.lupControl lupControl2;
        public myControl.lupControl lupControl3;
        public myControl.EditControl editControl10;
        public myControl.EditControl editControl13;
        public myControl.EditControl editControl12;
        public myControl.EditControl editControl11;
        public myControl.EditControl editControl15;
        public myControl.EditControl editControl14;
        public myControl.SpinControl spinControl1;
        public myControl.EditControl editControl17;
        public myControl.EditControl editControl16;
        public myControl.EditControl editControl18;
        public myControl.SpinControl spinControl2;
        public DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        public DevExpress.XtraEditors.CheckEdit ckOption;
        public DevExpress.XtraEditors.PictureEdit picClient;
        public DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.SimpleButton sbLoad;
        public DevExpress.XtraEditors.SimpleButton sbHistory;

    }
}
