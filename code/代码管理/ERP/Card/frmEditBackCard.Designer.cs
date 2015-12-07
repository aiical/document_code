namespace Card
{
    partial class frmEditBackCard
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
            this.spinControl1 = new myControl.SpinControl();
            this.spinControl2 = new myControl.SpinControl();
            this.sbReadCard = new DevExpress.XtraEditors.SimpleButton();
            this.editControl4 = new myControl.EditControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(215, 284);
            this.BtnOK.Text = "退卡(&B)";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(299, 284);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl4);
            this.gbox.Controls.Add(this.sbReadCard);
            this.gbox.Controls.Add(this.spinControl2);
            this.gbox.Controls.Add(this.spinControl1);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Size = new System.Drawing.Size(361, 256);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(108, 288);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_CardNo";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "卡号:";
            this.editControl1.Enabled = false;
            this.editControl1.Location = new System.Drawing.Point(80, 136);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(174, 21);
            this.editControl1.TabIndex = 3;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "姓名:";
            this.editControl2.Enabled = false;
            this.editControl2.Location = new System.Drawing.Point(80, 101);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(174, 21);
            this.editControl2.TabIndex = 2;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Rest";
            this.spinControl1.DataSource = null;
            this.spinControl1.EditLabel = "卡上金额:";
            this.spinControl1.Enabled = false;
            this.spinControl1.Location = new System.Drawing.Point(55, 171);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(199, 21);
            this.spinControl1.TabIndex = 4;
            // 
            // spinControl2
            // 
            this.spinControl2.BackColor = System.Drawing.Color.Transparent;
            this.spinControl2.DataField = "F_Cost";
            this.spinControl2.DataSource = null;
            this.spinControl2.EditLabel = "退还成本:";
            this.spinControl2.Location = new System.Drawing.Point(55, 206);
            this.spinControl2.Name = "spinControl2";
            this.spinControl2.Size = new System.Drawing.Size(199, 21);
            this.spinControl2.TabIndex = 5;
            // 
            // sbReadCard
            // 
            this.sbReadCard.Location = new System.Drawing.Point(139, 20);
            this.sbReadCard.Name = "sbReadCard";
            this.sbReadCard.Size = new System.Drawing.Size(75, 23);
            this.sbReadCard.TabIndex = 7;
            this.sbReadCard.Text = "读卡";
            this.sbReadCard.Click += new System.EventHandler(this.sbReadCard_Click);
            // 
            // editControl4
            // 
            this.editControl4.BackColor = System.Drawing.Color.Transparent;
            this.editControl4.DataField = "F_ID";
            this.editControl4.DataSource = null;
            this.editControl4.EditLabel = "工号:";
            this.editControl4.Enabled = false;
            this.editControl4.Location = new System.Drawing.Point(80, 65);
            this.editControl4.Name = "editControl4";
            this.editControl4.Request = false;
            this.editControl4.Size = new System.Drawing.Size(174, 21);
            this.editControl4.TabIndex = 8;
            // 
            // frmEditBackCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(386, 319);
            this.Name = "frmEditBackCard";
            this.Text = "退卡";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.SpinControl spinControl1;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl1;
        private myControl.SpinControl spinControl2;
        private DevExpress.XtraEditors.SimpleButton sbReadCard;
        private myControl.EditControl editControl4;

    }
}
