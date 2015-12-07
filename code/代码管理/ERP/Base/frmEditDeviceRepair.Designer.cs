namespace Base
{
    partial class frmEditDeviceRepair
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
            this.editControl1 = new myControl.EditControl();
            this.dateControl1 = new myControl.DateControl();
            this.editControl2 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(238, 235);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(319, 235);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.lupControl2);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Size = new System.Drawing.Size(381, 216);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(100, 239);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_DeviceID";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "设备:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(37, 50);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(263, 22);
            this.lupControl1.TabIndex = 0;
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_Remark";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "备注:";
            this.editControl1.Location = new System.Drawing.Point(37, 172);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(299, 21);
            this.editControl1.TabIndex = 1;
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Date";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(37, 12);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(177, 21);
            this.dateControl1.TabIndex = 4;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Result";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "维护结果:";
            this.editControl2.Location = new System.Drawing.Point(15, 133);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(321, 21);
            this.editControl2.TabIndex = 5;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_EmpID";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.DropSQL = "";
            this.lupControl2.EditLabel = "维护人员:";
            this.lupControl2.InvokeClass = "";
            this.lupControl2.LinkFields = null;
            this.lupControl2.Location = new System.Drawing.Point(15, 92);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = true;
            this.lupControl2.Size = new System.Drawing.Size(285, 22);
            this.lupControl2.TabIndex = 6;
            // 
            // frmEditDeviceRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(406, 270);
            this.Name = "frmEditDeviceRepair";
            this.Text = "客户费用";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl1;
        public myControl.DateControl dateControl1;
        public myControl.EditControl editControl2;
        public myControl.lupControl lupControl2;

    }
}
