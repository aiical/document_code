namespace Finance
{
    partial class frmEditSubject
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem5 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem6 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem7 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem8 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.cbControl1 = new myControl.cbControl();
            this.cbControl2 = new myControl.cbControl();
            this.cbControl3 = new myControl.cbControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(209, 194);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(290, 194);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.cbControl3);
            this.gbox.Controls.Add(this.cbControl2);
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Size = new System.Drawing.Size(352, 169);
            // 
            // ckCopy
            // 
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "科目代码:";
            this.editControl1.Location = new System.Drawing.Point(15, 20);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(174, 21);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "科目名称:";
            this.editControl2.Location = new System.Drawing.Point(15, 52);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(322, 21);
            this.editControl2.TabIndex = 1;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem5.Value = "借方";
            comboBoxItem6.Value = "贷方";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem5,
        comboBoxItem6};
            this.cbControl1.DataField = "F_Direction";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "余额方向:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(15, 86);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(150, 21);
            this.cbControl1.TabIndex = 2;
            // 
            // cbControl2
            // 
            this.cbControl2.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem7.Value = "不核算外币";
            comboBoxItem8.Value = "核算单一外币";
            this.cbControl2.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem7,
        comboBoxItem8};
            this.cbControl2.DataField = "F_Currency";
            this.cbControl2.DataSource = null;
            this.cbControl2.EditLabel = "核算外币:";
            this.cbControl2.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl2.Location = new System.Drawing.Point(15, 122);
            this.cbControl2.Name = "cbControl2";
            this.cbControl2.Request = false;
            this.cbControl2.SelectedIndex = -1;
            this.cbControl2.Size = new System.Drawing.Size(196, 21);
            this.cbControl2.TabIndex = 3;
            this.cbControl2.SelectIndexChange += new myControl.SelectIndexChangeEventHandler(this.cbControl2_SelectIndexChange);
            // 
            // cbControl3
            // 
            this.cbControl3.BackColor = System.Drawing.Color.Transparent;
            this.cbControl3.cbItem = null;
            this.cbControl3.DataField = "F_Tag";
            this.cbControl3.DataSource = null;
            this.cbControl3.EditLabel = "币别:";
            this.cbControl3.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbControl3.Enabled = false;
            this.cbControl3.Location = new System.Drawing.Point(217, 122);
            this.cbControl3.Name = "cbControl3";
            this.cbControl3.Request = false;
            this.cbControl3.SelectedIndex = -1;
            this.cbControl3.Size = new System.Drawing.Size(120, 21);
            this.cbControl3.TabIndex = 4;
            // 
            // frmEditSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(378, 229);
            this.Name = "frmEditSubject";
            this.Text = "会计科目--编辑";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl1;
        private myControl.EditControl editControl2;
        private myControl.cbControl cbControl1;
        private myControl.cbControl cbControl3;
        private myControl.cbControl cbControl2;
    }
}
