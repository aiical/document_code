namespace UFIDA.Retail.VIPCardControl
{
    partial class frmVipInfoApllyDetail
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
            this.ucContainer = new UFIDA.Retail.Components.UCValueControlContainer();
            this.rTxtRemark = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucContainer
            // 
            this.ucContainer.ColumnCount = 2;
            this.ucContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucContainer.Location = new System.Drawing.Point(0, 0);
            this.ucContainer.Name = "ucContainer";
            this.ucContainer.Size = new System.Drawing.Size(592, 95);
            this.ucContainer.TabIndex = 1;
            // 
            // rTxtRemark
            // 
            this.rTxtRemark.BackColor = System.Drawing.SystemColors.Control;
            this.rTxtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTxtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtRemark.Location = new System.Drawing.Point(3, 17);
            this.rTxtRemark.Name = "rTxtRemark";
            this.rTxtRemark.Size = new System.Drawing.Size(586, 240);
            this.rTxtRemark.TabIndex = 2;
            this.rTxtRemark.Text = "";
            this.rTxtRemark.WordWrap = false;
            this.rTxtRemark.Leave += new System.EventHandler(this.rTxtRemark_Leave);
            this.rTxtRemark.Enter += new System.EventHandler(this.rTxtRemark_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rTxtRemark);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "申请信息内容";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(505, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "退出(&Q)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(414, 363);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "完成(&F)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmVipInfoApllyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 393);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVipInfoApllyDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VIP客户信息变更申请单";
            this.Load += new System.EventHandler(this.frmVipInfoApllyDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.Retail.Components.UCValueControlContainer ucContainer;
        private System.Windows.Forms.RichTextBox rTxtRemark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}