namespace OA
{
    partial class frmEditOAFile
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
            this.dateControl1 = new myControl.DateControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.sbView = new DevExpress.XtraEditors.SimpleButton();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(224, 194);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(305, 194);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.sbView);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Controls.Add(this.simpleButton1);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Size = new System.Drawing.Size(367, 175);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(12, 194);
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Date";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "建立日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(6, 20);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(199, 21);
            this.dateControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(297, 75);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(47, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "选择";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_Des";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "文件描述:";
            this.editControl1.Location = new System.Drawing.Point(7, 48);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(337, 21);
            this.editControl1.TabIndex = 5;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_FileName";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "文件名:";
            this.editControl2.Location = new System.Drawing.Point(18, 75);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(273, 21);
            this.editControl2.TabIndex = 6;
            // 
            // sbView
            // 
            this.sbView.Location = new System.Drawing.Point(139, 126);
            this.sbView.Name = "sbView";
            this.sbView.Size = new System.Drawing.Size(75, 23);
            this.sbView.TabIndex = 7;
            this.sbView.Text = "查看文件";
            this.sbView.Click += new System.EventHandler(this.sbView_Click);
            // 
            // frmEditOAFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(393, 246);
            this.Name = "frmEditOAFile";
            this.Text = "任务--编辑";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.DateControl dateControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton sbView;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl1;
    }
}
