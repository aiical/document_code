namespace Finance
{
    partial class frmEditAsset
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem4 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem5 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem6 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.editControl4 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.lupControl1 = new myControl.lupControl();
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.lupControl4 = new myControl.lupControl();
            this.spinControl1 = new myControl.SpinControl();
            this.spinControl2 = new myControl.SpinControl();
            this.spinControl3 = new myControl.SpinControl();
            this.spinControl4 = new myControl.SpinControl();
            this.spinControl5 = new myControl.SpinControl();
            this.spinControl6 = new myControl.SpinControl();
            this.spinControl7 = new myControl.SpinControl();
            this.spinControl8 = new myControl.SpinControl();
            this.spinControl9 = new myControl.SpinControl();
            this.spinControl11 = new myControl.SpinControl();
            this.lupControl6 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(427, 364);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(508, 364);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Controls.Add(this.lupControl6);
            this.gbox.Controls.Add(this.spinControl11);
            this.gbox.Controls.Add(this.spinControl9);
            this.gbox.Controls.Add(this.spinControl8);
            this.gbox.Controls.Add(this.spinControl7);
            this.gbox.Controls.Add(this.spinControl6);
            this.gbox.Controls.Add(this.spinControl5);
            this.gbox.Controls.Add(this.spinControl4);
            this.gbox.Controls.Add(this.spinControl3);
            this.gbox.Controls.Add(this.spinControl2);
            this.gbox.Controls.Add(this.spinControl1);
            this.gbox.Controls.Add(this.lupControl4);
            this.gbox.Controls.Add(this.lupControl3);
            this.gbox.Controls.Add(this.lupControl2);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl4);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Size = new System.Drawing.Size(570, 339);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(13, 368);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.EditLabel = "固定资产编号:";
            this.editControl1.Location = new System.Drawing.Point(7, 21);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(219, 27);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.EditLabel = "固定资产名称:";
            this.editControl2.Location = new System.Drawing.Point(256, 20);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(294, 27);
            this.editControl2.TabIndex = 1;
            // 
            // editControl4
            // 
            this.editControl4.BackColor = System.Drawing.Color.Transparent;
            this.editControl4.DataField = "F_Spec";
            this.editControl4.EditLabel = "规格型号:";
            this.editControl4.Location = new System.Drawing.Point(285, 53);
            this.editControl4.Name = "editControl4";
            this.editControl4.Request = false;
            this.editControl4.Size = new System.Drawing.Size(265, 27);
            this.editControl4.TabIndex = 4;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Position";
            this.editControl9.EditLabel = "存放位置:";
            this.editControl9.Location = new System.Drawing.Point(30, 302);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(520, 27);
            this.editControl9.TabIndex = 9;
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_Type";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "固定资产类别:";
            this.lupControl1.Location = new System.Drawing.Point(7, 53);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.Request = false;
            this.lupControl1.Size = new System.Drawing.Size(219, 22);
            this.lupControl1.TabIndex = 10;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_DeptID";
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.EditLabel = "所属部门:";
            this.lupControl2.Location = new System.Drawing.Point(30, 81);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.Request = false;
            this.lupControl2.Size = new System.Drawing.Size(196, 22);
            this.lupControl2.TabIndex = 11;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_CalType";
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.EditLabel = "增减方式:";
            this.lupControl3.Location = new System.Drawing.Point(283, 83);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(206, 22);
            this.lupControl3.TabIndex = 12;
            // 
            // lupControl4
            // 
            this.lupControl4.BackColor = System.Drawing.Color.Transparent;
            this.lupControl4.DataField = "F_UseInfo";
            this.lupControl4.DisplayCaption = "";
            this.lupControl4.EditLabel = "使用状况:";
            this.lupControl4.Location = new System.Drawing.Point(30, 111);
            this.lupControl4.LookUpDataSource = null;
            this.lupControl4.LookUpDisplayField = null;
            this.lupControl4.LookUpKeyField = null;
            this.lupControl4.Name = "lupControl4";
            this.lupControl4.Request = false;
            this.lupControl4.Size = new System.Drawing.Size(196, 22);
            this.lupControl4.TabIndex = 13;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_IniValue";
            this.spinControl1.EditLabel = "入帐原值:";
            this.spinControl1.Location = new System.Drawing.Point(285, 111);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(185, 21);
            this.spinControl1.TabIndex = 14;
            // 
            // spinControl2
            // 
            this.spinControl2.BackColor = System.Drawing.Color.Transparent;
            this.spinControl2.DataField = "F_Total";
            this.spinControl2.EditLabel = "累计折旧:";
            this.spinControl2.Location = new System.Drawing.Point(30, 139);
            this.spinControl2.Name = "spinControl2";
            this.spinControl2.Size = new System.Drawing.Size(170, 21);
            this.spinControl2.TabIndex = 15;
            // 
            // spinControl3
            // 
            this.spinControl3.BackColor = System.Drawing.Color.Transparent;
            this.spinControl3.DataField = "F_nValue";
            this.spinControl3.EditLabel = "净值:";
            this.spinControl3.Location = new System.Drawing.Point(304, 139);
            this.spinControl3.Name = "spinControl3";
            this.spinControl3.Size = new System.Drawing.Size(185, 21);
            this.spinControl3.TabIndex = 16;
            // 
            // spinControl4
            // 
            this.spinControl4.BackColor = System.Drawing.Color.Transparent;
            this.spinControl4.DataField = "F_Date";
            this.spinControl4.EditLabel = "入帐日期:";
            this.spinControl4.Location = new System.Drawing.Point(30, 166);
            this.spinControl4.Name = "spinControl4";
            this.spinControl4.Size = new System.Drawing.Size(170, 21);
            this.spinControl4.TabIndex = 17;
            // 
            // spinControl5
            // 
            this.spinControl5.BackColor = System.Drawing.Color.Transparent;
            this.spinControl5.DataField = "F_nRate";
            this.spinControl5.EditLabel = "预计净残值率:";
            this.spinControl5.Location = new System.Drawing.Point(256, 166);
            this.spinControl5.Name = "spinControl5";
            this.spinControl5.Size = new System.Drawing.Size(185, 21);
            this.spinControl5.TabIndex = 18;
            // 
            // spinControl6
            // 
            this.spinControl6.BackColor = System.Drawing.Color.Transparent;
            this.spinControl6.DataField = "F_nValue1";
            this.spinControl6.EditLabel = "预计净残值:";
            this.spinControl6.Location = new System.Drawing.Point(19, 193);
            this.spinControl6.Name = "spinControl6";
            this.spinControl6.Size = new System.Drawing.Size(181, 21);
            this.spinControl6.TabIndex = 19;
            // 
            // spinControl7
            // 
            this.spinControl7.BackColor = System.Drawing.Color.Transparent;
            this.spinControl7.DataField = "F_UseMonth";
            this.spinControl7.EditLabel = "预计使用月份:";
            this.spinControl7.Location = new System.Drawing.Point(7, 220);
            this.spinControl7.Name = "spinControl7";
            this.spinControl7.Size = new System.Drawing.Size(193, 21);
            this.spinControl7.TabIndex = 21;
            // 
            // spinControl8
            // 
            this.spinControl8.BackColor = System.Drawing.Color.Transparent;
            this.spinControl8.DataField = "F_HasUseMonth";
            this.spinControl8.EditLabel = "已计提月份:";
            this.spinControl8.Location = new System.Drawing.Point(269, 220);
            this.spinControl8.Name = "spinControl8";
            this.spinControl8.Size = new System.Drawing.Size(185, 21);
            this.spinControl8.TabIndex = 22;
            // 
            // spinControl9
            // 
            this.spinControl9.BackColor = System.Drawing.Color.Transparent;
            this.spinControl9.DataField = "F_MonthRate";
            this.spinControl9.EditLabel = "月折旧率:";
            this.spinControl9.Location = new System.Drawing.Point(30, 247);
            this.spinControl9.Name = "spinControl9";
            this.spinControl9.Size = new System.Drawing.Size(170, 21);
            this.spinControl9.TabIndex = 23;
            // 
            // spinControl11
            // 
            this.spinControl11.BackColor = System.Drawing.Color.Transparent;
            this.spinControl11.DataField = "F_MonthValue";
            this.spinControl11.EditLabel = "月折旧额:";
            this.spinControl11.Location = new System.Drawing.Point(283, 247);
            this.spinControl11.Name = "spinControl11";
            this.spinControl11.Size = new System.Drawing.Size(170, 21);
            this.spinControl11.TabIndex = 25;
            // 
            // lupControl6
            // 
            this.lupControl6.BackColor = System.Drawing.Color.Transparent;
            this.lupControl6.DataField = null;
            this.lupControl6.DisplayCaption = "";
            this.lupControl6.EditLabel = "对应科目:";
            this.lupControl6.Location = new System.Drawing.Point(30, 274);
            this.lupControl6.LookUpDataSource = null;
            this.lupControl6.LookUpDisplayField = null;
            this.lupControl6.LookUpKeyField = null;
            this.lupControl6.Name = "lupControl6";
            this.lupControl6.Request = false;
            this.lupControl6.Size = new System.Drawing.Size(206, 22);
            this.lupControl6.TabIndex = 27;
            this.lupControl6.ButtonClick += new myControl.ButtonClickEventHandler(this.lupControl6_ButtonClick);
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "不计提折旧";
            comboBoxItem2.Value = "平均年限法(一)";
            comboBoxItem3.Value = "平均年限法(二)";
            comboBoxItem4.Value = "工作量法";
            comboBoxItem5.Value = "双倍余额递减法";
            comboBoxItem6.Value = "年数总和法";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3,
        comboBoxItem4,
        comboBoxItem5,
        comboBoxItem6};
            this.cbControl1.DataField = "F_nWay";
            this.cbControl1.EditLabel = "折旧方法:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(283, 193);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.Size = new System.Drawing.Size(206, 21);
            this.cbControl1.TabIndex = 28;
            // 
            // frmEditAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(595, 399);
            this.Name = "frmEditAsset";
            this.Text = "固定资产-编辑";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl1;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl4;
        private myControl.EditControl editControl9;
        private myControl.lupControl lupControl1;
        private myControl.lupControl lupControl3;
        private myControl.lupControl lupControl2;
        private myControl.SpinControl spinControl1;
        private myControl.lupControl lupControl4;
        private myControl.SpinControl spinControl2;
        private myControl.SpinControl spinControl3;
        private myControl.SpinControl spinControl5;
        private myControl.SpinControl spinControl4;
        private myControl.SpinControl spinControl6;
        private myControl.SpinControl spinControl7;
        private myControl.SpinControl spinControl9;
        private myControl.SpinControl spinControl8;
        private myControl.lupControl lupControl6;
        private myControl.SpinControl spinControl11;
        private myControl.cbControl cbControl1;

    }
}
