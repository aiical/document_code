namespace Card
{
    partial class frmEditUserCard
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
            this.dateControl1 = new myControl.DateControl();
            this.dateControl2 = new myControl.DateControl();
            this.dateControl3 = new myControl.DateControl();
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
            this.BtnOK.Location = new System.Drawing.Point(316, 257);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(396, 257);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.lupControl2);
            this.gbox.Controls.Add(this.dateControl3);
            this.gbox.Controls.Add(this.dateControl2);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Size = new System.Drawing.Size(458, 229);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(17, 255);
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
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_Class";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.DropSQL = "select F_ID,F_Name from t_SetClass";
            this.lupControl2.EditLabel = "班次:";
            this.lupControl2.InvokeClass = "";
            this.lupControl2.LinkFields = null;
            this.lupControl2.Location = new System.Drawing.Point(31, 81);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = "F_Name";
            this.lupControl2.LookUpKeyField = "F_ID";
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = false;
            this.lupControl2.Size = new System.Drawing.Size(193, 22);
            this.lupControl2.TabIndex = 7;
            // 
            // frmEditUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(483, 293);
            this.Name = "frmEditUserCard";
            this.Text = "手工补卡登记";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.lupControl lupControl1;
        private myControl.DateControl dateControl2;
        private myControl.DateControl dateControl1;
        private myControl.DateControl dateControl3;
        private myControl.lupControl lupControl2;

    }
}
