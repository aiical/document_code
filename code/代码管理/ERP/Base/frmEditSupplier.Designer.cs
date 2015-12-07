namespace Base
{
    partial class frmEditSupplier
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
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.editControl10 = new myControl.EditControl();
            this.editControl11 = new myControl.EditControl();
            this.editControl12 = new myControl.EditControl();
            this.editControl13 = new myControl.EditControl();
            this.editControl14 = new myControl.EditControl();
            this.editControl15 = new myControl.EditControl();
            this.editControl16 = new myControl.EditControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(373, 376);
            this.BtnOK.Text = "保存(&S)";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(454, 376);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl16);
            this.gbox.Controls.Add(this.editControl15);
            this.gbox.Controls.Add(this.editControl14);
            this.gbox.Controls.Add(this.editControl13);
            this.gbox.Controls.Add(this.editControl12);
            this.gbox.Controls.Add(this.editControl11);
            this.gbox.Controls.Add(this.editControl10);
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
            this.gbox.Size = new System.Drawing.Size(516, 343);
            // 
            // ckCopy
            // 
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.EditLabel = "供应商代码:";
            this.editControl1.Location = new System.Drawing.Point(7, 21);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(214, 27);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.EditLabel = "供应商名称:";
            this.editControl2.Location = new System.Drawing.Point(255, 21);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(255, 27);
            this.editControl2.TabIndex = 1;
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_Type";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "类    别:";
            this.lupControl1.Location = new System.Drawing.Point(18, 54);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(203, 22);
            this.lupControl1.TabIndex = 2;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_LinkMan";
            this.editControl3.EditLabel = "联系人:";
            this.editControl3.Location = new System.Drawing.Point(279, 54);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(231, 27);
            this.editControl3.TabIndex = 3;
            // 
            // editControl4
            // 
            this.editControl4.BackColor = System.Drawing.Color.Transparent;
            this.editControl4.DataField = "F_Tel";
            this.editControl4.EditLabel = "联系电话1:";
            this.editControl4.Location = new System.Drawing.Point(13, 82);
            this.editControl4.Name = "editControl4";
            this.editControl4.Request = false;
            this.editControl4.Size = new System.Drawing.Size(227, 27);
            this.editControl4.TabIndex = 4;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Bank";
            this.editControl5.EditLabel = "开户银行:";
            this.editControl5.Location = new System.Drawing.Point(18, 146);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(213, 21);
            this.editControl5.TabIndex = 7;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_BankNo";
            this.editControl6.EditLabel = "银行帐号:";
            this.editControl6.Location = new System.Drawing.Point(244, 146);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(266, 21);
            this.editControl6.TabIndex = 8;
            // 
            // editControl7
            // 
            this.editControl7.BackColor = System.Drawing.Color.Transparent;
            this.editControl7.DataField = "F_PostCode";
            this.editControl7.EditLabel = "邮编:";
            this.editControl7.Location = new System.Drawing.Point(267, 179);
            this.editControl7.Name = "editControl7";
            this.editControl7.Request = false;
            this.editControl7.Size = new System.Drawing.Size(243, 27);
            this.editControl7.TabIndex = 10;
            // 
            // editControl8
            // 
            this.editControl8.BackColor = System.Drawing.Color.Transparent;
            this.editControl8.DataField = "F_Adr";
            this.editControl8.EditLabel = "地址:";
            this.editControl8.Location = new System.Drawing.Point(40, 212);
            this.editControl8.Name = "editControl8";
            this.editControl8.Request = false;
            this.editControl8.Size = new System.Drawing.Size(470, 27);
            this.editControl8.TabIndex = 11;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Remark";
            this.editControl9.EditLabel = "备注:";
            this.editControl9.Location = new System.Drawing.Point(40, 245);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(470, 27);
            this.editControl9.TabIndex = 12;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(18, 374);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "保存后新增";
            this.ckOption.Size = new System.Drawing.Size(101, 19);
            this.ckOption.TabIndex = 3;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
            // 
            // editControl10
            // 
            this.editControl10.BackColor = System.Drawing.Color.Transparent;
            this.editControl10.DataField = "F_Fax";
            this.editControl10.EditLabel = "传真:";
            this.editControl10.Location = new System.Drawing.Point(42, 179);
            this.editControl10.Name = "editControl10";
            this.editControl10.Request = false;
            this.editControl10.Size = new System.Drawing.Size(189, 27);
            this.editControl10.TabIndex = 9;
            // 
            // editControl11
            // 
            this.editControl11.BackColor = System.Drawing.Color.Transparent;
            this.editControl11.DataField = "F_Tel1";
            this.editControl11.EditLabel = "联系电话2:";
            this.editControl11.Location = new System.Drawing.Point(261, 82);
            this.editControl11.Name = "editControl11";
            this.editControl11.Request = false;
            this.editControl11.Size = new System.Drawing.Size(248, 27);
            this.editControl11.TabIndex = 5;
            // 
            // editControl12
            // 
            this.editControl12.BackColor = System.Drawing.Color.Transparent;
            this.editControl12.DataField = "F_Tel2";
            this.editControl12.EditLabel = "联系电话3:";
            this.editControl12.Location = new System.Drawing.Point(13, 115);
            this.editControl12.Name = "editControl12";
            this.editControl12.Request = false;
            this.editControl12.Size = new System.Drawing.Size(227, 25);
            this.editControl12.TabIndex = 6;
            // 
            // editControl13
            // 
            this.editControl13.BackColor = System.Drawing.Color.Transparent;
            this.editControl13.DataField = "F_Grade2";
            this.editControl13.EditLabel = "供货质量等级:";
            this.editControl13.Location = new System.Drawing.Point(166, 278);
            this.editControl13.Name = "editControl13";
            this.editControl13.Request = false;
            this.editControl13.Size = new System.Drawing.Size(181, 27);
            this.editControl13.TabIndex = 13;
            // 
            // editControl14
            // 
            this.editControl14.BackColor = System.Drawing.Color.Transparent;
            this.editControl14.DataField = "F_Grade1";
            this.editControl14.EditLabel = "信用度:";
            this.editControl14.Location = new System.Drawing.Point(28, 278);
            this.editControl14.Name = "editControl14";
            this.editControl14.Request = false;
            this.editControl14.Size = new System.Drawing.Size(115, 27);
            this.editControl14.TabIndex = 14;
            // 
            // editControl15
            // 
            this.editControl15.BackColor = System.Drawing.Color.Transparent;
            this.editControl15.DataField = "F_Grade3";
            this.editControl15.EditLabel = "供货能力:";
            this.editControl15.Location = new System.Drawing.Point(380, 278);
            this.editControl15.Name = "editControl15";
            this.editControl15.Request = false;
            this.editControl15.Size = new System.Drawing.Size(129, 27);
            this.editControl15.TabIndex = 15;
            // 
            // editControl16
            // 
            this.editControl16.BackColor = System.Drawing.Color.Transparent;
            this.editControl16.DataField = "F_QCMoney";
            this.editControl16.EditLabel = "期初:";
            this.editControl16.Location = new System.Drawing.Point(40, 311);
            this.editControl16.Name = "editControl16";
            this.editControl16.Request = false;
            this.editControl16.Size = new System.Drawing.Size(148, 27);
            this.editControl16.TabIndex = 16;
            // 
            // frmEditSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(539, 411);
            this.Controls.Add(this.ckOption);
            this.Name = "frmEditSupplier";
            this.Text = "供应商资料--编辑";
            this.Shown += new System.EventHandler(this.frmEditSupplier_Shown);
            this.Controls.SetChildIndex(this.ckCopy, 0);
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.Controls.SetChildIndex(this.ckOption, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        public DevExpress.XtraEditors.CheckEdit ckOption;
        public myControl.EditControl editControl10;
        public myControl.EditControl editControl12;
        public myControl.EditControl editControl11;
        public myControl.EditControl editControl13;
        public myControl.EditControl editControl15;
        public myControl.EditControl editControl14;
        public myControl.EditControl editControl16;


    }
}
