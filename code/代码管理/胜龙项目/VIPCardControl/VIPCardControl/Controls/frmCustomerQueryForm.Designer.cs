namespace UFIDA.Retail.VIPCardControl
{
    partial class frmCustomerQueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerQueryForm));
            this.cmbTransferRM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCusCode = new Lixtech.UserControls.UCTextBox();
            this.txtCusName = new Lixtech.UserControls.UCTextBox();
            this.txtMobileNum = new Lixtech.UserControls.UCTextBox();
            this.txtWorkPlace = new Lixtech.UserControls.UCTextBox();
            this.SuspendLayout();
            // 
            // cmbTransferRM
            // 
            this.cmbTransferRM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferRM.FormattingEnabled = true;
            this.cmbTransferRM.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.cmbTransferRM.Location = new System.Drawing.Point(71, 174);
            this.cmbTransferRM.Name = "cmbTransferRM";
            this.cmbTransferRM.Size = new System.Drawing.Size(134, 20);
            this.cmbTransferRM.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(17, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "是否上传";
            // 
            // btnFinish
            // 
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(181, 238);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(88, 24);
            this.btnFinish.TabIndex = 50;
            this.btnFinish.Text = "    完 成(&F)";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(292, 238);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 24);
            this.btnExit.TabIndex = 51;
            this.btnExit.Text = "    退 出(&Q)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(237, 73);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(134, 21);
            this.dtpEndDate.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "-";
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(71, 74);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.ShowCheckBox = true;
            this.dtpBeginDate.Size = new System.Drawing.Size(134, 21);
            this.dtpBeginDate.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(17, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "创建日期";
            // 
            // txtCusCode
            // 
            this.txtCusCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtCusCode.btnEnabled = true;
            this.txtCusCode.btnVisible = false;
            this.txtCusCode.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtCusCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCusCode.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtCusCode.lblText = "客户编码";
            this.txtCusCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCusCode.Location = new System.Drawing.Point(17, 12);
            this.txtCusCode.Name = "txtCusCode";
            this.txtCusCode.Size = new System.Drawing.Size(354, 18);
            this.txtCusCode.TabIndex = 56;
            this.txtCusCode.txtBackColor = System.Drawing.Color.White;
            this.txtCusCode.txtEnabled = true;
            this.txtCusCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCusCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCusCode.txtPasswrod = '\0';
            this.txtCusCode.txtReadOnly = false;
            this.txtCusCode.txtTag = null;
            this.txtCusCode.txtText = "";
            this.txtCusCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtCusName
            // 
            this.txtCusName.BackColor = System.Drawing.SystemColors.Control;
            this.txtCusName.btnEnabled = true;
            this.txtCusName.btnVisible = false;
            this.txtCusName.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtCusName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCusName.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtCusName.lblText = "客户名称";
            this.txtCusName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCusName.Location = new System.Drawing.Point(17, 43);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(354, 18);
            this.txtCusName.TabIndex = 57;
            this.txtCusName.txtBackColor = System.Drawing.Color.White;
            this.txtCusName.txtEnabled = true;
            this.txtCusName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCusName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCusName.txtPasswrod = '\0';
            this.txtCusName.txtReadOnly = false;
            this.txtCusName.txtTag = null;
            this.txtCusName.txtText = "";
            this.txtCusName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtMobileNum
            // 
            this.txtMobileNum.BackColor = System.Drawing.SystemColors.Control;
            this.txtMobileNum.btnEnabled = true;
            this.txtMobileNum.btnVisible = false;
            this.txtMobileNum.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtMobileNum.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMobileNum.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtMobileNum.lblText = "联系电话";
            this.txtMobileNum.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtMobileNum.Location = new System.Drawing.Point(12, 110);
            this.txtMobileNum.Name = "txtMobileNum";
            this.txtMobileNum.Size = new System.Drawing.Size(354, 18);
            this.txtMobileNum.TabIndex = 58;
            this.txtMobileNum.txtBackColor = System.Drawing.Color.White;
            this.txtMobileNum.txtEnabled = true;
            this.txtMobileNum.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMobileNum.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMobileNum.txtPasswrod = '\0';
            this.txtMobileNum.txtReadOnly = false;
            this.txtMobileNum.txtTag = null;
            this.txtMobileNum.txtText = "";
            this.txtMobileNum.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtWorkPlace
            // 
            this.txtWorkPlace.BackColor = System.Drawing.SystemColors.Control;
            this.txtWorkPlace.btnEnabled = true;
            this.txtWorkPlace.btnVisible = false;
            this.txtWorkPlace.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtWorkPlace.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWorkPlace.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtWorkPlace.lblText = "工作单位";
            this.txtWorkPlace.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtWorkPlace.Location = new System.Drawing.Point(12, 143);
            this.txtWorkPlace.Name = "txtWorkPlace";
            this.txtWorkPlace.Size = new System.Drawing.Size(354, 18);
            this.txtWorkPlace.TabIndex = 59;
            this.txtWorkPlace.txtBackColor = System.Drawing.Color.White;
            this.txtWorkPlace.txtEnabled = true;
            this.txtWorkPlace.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWorkPlace.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorkPlace.txtPasswrod = '\0';
            this.txtWorkPlace.txtReadOnly = false;
            this.txtWorkPlace.txtTag = null;
            this.txtWorkPlace.txtText = "";
            this.txtWorkPlace.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // frmCustomerQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(385, 279);
            this.Controls.Add(this.txtWorkPlace);
            this.Controls.Add(this.txtMobileNum);
            this.Controls.Add(this.txtCusName);
            this.Controls.Add(this.txtCusCode);
            this.Controls.Add(this.cmbTransferRM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpBeginDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerQueryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "展厅客户查询";
            this.Load += new System.EventHandler(this.frmCustomerQueryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTransferRM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private Lixtech.UserControls.UCTextBox txtCusCode;
        private Lixtech.UserControls.UCTextBox txtCusName;
        private Lixtech.UserControls.UCTextBox txtMobileNum;
        private Lixtech.UserControls.UCTextBox txtWorkPlace;
    }
}