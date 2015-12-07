namespace Card
{
    partial class frmEditLeave
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem4 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.lupControl1 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
            this.dateControl1 = new myControl.DateControl();
            this.dateControl2 = new myControl.DateControl();
            this.spinControl1 = new myControl.SpinControl();
            this.label1 = new System.Windows.Forms.Label();
            this.dateControl3 = new myControl.DateControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(315, 290);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(396, 290);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.dateControl3);
            this.gbox.Controls.Add(this.label1);
            this.gbox.Controls.Add(this.spinControl1);
            this.gbox.Controls.Add(this.dateControl2);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Size = new System.Drawing.Size(458, 271);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(12, 290);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_ID";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "员工:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(244, 29);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = false;
            this.lupControl1.Size = new System.Drawing.Size(197, 21);
            this.lupControl1.TabIndex = 0;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem3.Value = "事假";
            comboBoxItem4.Value = "病假";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem3,
        comboBoxItem4};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "请假类型:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(7, 80);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.Size = new System.Drawing.Size(196, 21);
            this.cbControl1.TabIndex = 1;
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Begin";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "g";
            this.dateControl1.EditLabel = "开始时间:";
            this.dateControl1.EditMask = "g";
            this.dateControl1.Location = new System.Drawing.Point(7, 139);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(207, 21);
            this.dateControl1.TabIndex = 2;
            // 
            // dateControl2
            // 
            this.dateControl2.BackColor = System.Drawing.Color.Transparent;
            this.dateControl2.DataField = "F_End";
            this.dateControl2.DataSource = null;
            this.dateControl2.DisplayFormat = "g";
            this.dateControl2.EditLabel = "结束时间:";
            this.dateControl2.EditMask = "g";
            this.dateControl2.Location = new System.Drawing.Point(244, 139);
            this.dateControl2.Name = "dateControl2";
            this.dateControl2.Request = false;
            this.dateControl2.Size = new System.Drawing.Size(197, 21);
            this.dateControl2.TabIndex = 3;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Time";
            this.spinControl1.DataSource = null;
            this.spinControl1.EditLabel = "估计时间:";
            this.spinControl1.Location = new System.Drawing.Point(7, 195);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(155, 21);
            this.spinControl1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "天";
            // 
            // dateControl3
            // 
            this.dateControl3.BackColor = System.Drawing.Color.Transparent;
            this.dateControl3.DataField = "F_Date";
            this.dateControl3.DataSource = null;
            this.dateControl3.DisplayFormat = "d";
            this.dateControl3.EditLabel = "登记日期:";
            this.dateControl3.EditMask = "d";
            this.dateControl3.Location = new System.Drawing.Point(6, 29);
            this.dateControl3.Name = "dateControl3";
            this.dateControl3.Request = false;
            this.dateControl3.Size = new System.Drawing.Size(196, 21);
            this.dateControl3.TabIndex = 6;
            // 
            // frmEditLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(483, 327);
            this.Name = "frmEditLeave";
            this.Text = "员工请假登记";
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.cbControl cbControl1;
        private myControl.lupControl lupControl1;
        private myControl.DateControl dateControl2;
        private myControl.DateControl dateControl1;
        private System.Windows.Forms.Label label1;
        private myControl.SpinControl spinControl1;
        private myControl.DateControl dateControl3;

    }
}
