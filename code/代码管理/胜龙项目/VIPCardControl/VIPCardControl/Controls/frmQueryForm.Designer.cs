namespace UFIDA.Retail.VIPCardControl
{
    partial class frmQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryForm));
            this.txtItemName = new Lixtech.UserControls.UCTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new Lixtech.UserControls.UCTextBox();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTmpSave = new System.Windows.Forms.ComboBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbTransferU8 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTransferRM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVoucherCode = new Lixtech.UserControls.UCTextBox();
            this.SuspendLayout();
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.Control;
            this.txtItemName.btnEnabled = true;
            this.txtItemName.btnVisible = true;
            this.txtItemName.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtItemName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemName.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtItemName.lblText = "商品名称";
            this.txtItemName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtItemName.Location = new System.Drawing.Point(12, 50);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(365, 18);
            this.txtItemName.TabIndex = 5;
            this.txtItemName.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtItemName.txtEnabled = true;
            this.txtItemName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtItemName.txtPasswrod = '\0';
            this.txtItemName.txtReadOnly = false;
            this.txtItemName.txtTag = null;
            this.txtItemName.txtText = "";
            this.txtItemName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemName.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtItemName_Button_Click);
            this.txtItemName.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtItemName_TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "单据日期";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmployeeName.btnEnabled = true;
            this.txtEmployeeName.btnVisible = true;
            this.txtEmployeeName.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtEmployeeName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEmployeeName.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtEmployeeName.lblText = "营业员";
            this.txtEmployeeName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtEmployeeName.Location = new System.Drawing.Point(23, 106);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(354, 18);
            this.txtEmployeeName.TabIndex = 8;
            this.txtEmployeeName.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtEmployeeName.txtEnabled = true;
            this.txtEmployeeName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEmployeeName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEmployeeName.txtPasswrod = '\0';
            this.txtEmployeeName.txtReadOnly = false;
            this.txtEmployeeName.txtTag = null;
            this.txtEmployeeName.txtText = "";
            this.txtEmployeeName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmployeeName.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtEmployeeName_Button_Click);
            this.txtEmployeeName.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtEmployeeName_TextBox_KeyPress);
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(68, 18);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.ShowCheckBox = true;
            this.dtpBeginDate.Size = new System.Drawing.Size(143, 21);
            this.dtpBeginDate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "-";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(234, 17);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(143, 21);
            this.dtpEndDate.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(14, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "是否暂存";
            // 
            // cmbTmpSave
            // 
            this.cmbTmpSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTmpSave.FormattingEnabled = true;
            this.cmbTmpSave.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.cmbTmpSave.Location = new System.Drawing.Point(68, 137);
            this.cmbTmpSave.Name = "cmbTmpSave";
            this.cmbTmpSave.Size = new System.Drawing.Size(143, 20);
            this.cmbTmpSave.TabIndex = 13;
            // 
            // btnFinish
            // 
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(178, 242);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(88, 24);
            this.btnFinish.TabIndex = 35;
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
            this.btnExit.Location = new System.Drawing.Point(289, 242);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 24);
            this.btnExit.TabIndex = 36;
            this.btnExit.Text = "    退 出(&Q)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbTransferU8
            // 
            this.cmbTransferU8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferU8.FormattingEnabled = true;
            this.cmbTransferU8.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.cmbTransferU8.Location = new System.Drawing.Point(68, 167);
            this.cmbTransferU8.Name = "cmbTransferU8";
            this.cmbTransferU8.Size = new System.Drawing.Size(143, 20);
            this.cmbTransferU8.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(2, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "是否上传U8";
            // 
            // cmbTransferRM
            // 
            this.cmbTransferRM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferRM.FormattingEnabled = true;
            this.cmbTransferRM.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.cmbTransferRM.Location = new System.Drawing.Point(68, 197);
            this.cmbTransferRM.Name = "cmbTransferRM";
            this.cmbTransferRM.Size = new System.Drawing.Size(143, 20);
            this.cmbTransferRM.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(2, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "是否上传RM";
            // 
            // txtVoucherCode
            // 
            this.txtVoucherCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtVoucherCode.btnEnabled = true;
            this.txtVoucherCode.btnVisible = false;
            this.txtVoucherCode.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtVoucherCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVoucherCode.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtVoucherCode.lblText = "单据编号";
            this.txtVoucherCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVoucherCode.Location = new System.Drawing.Point(12, 79);
            this.txtVoucherCode.Name = "txtVoucherCode";
            this.txtVoucherCode.Size = new System.Drawing.Size(363, 18);
            this.txtVoucherCode.TabIndex = 57;
            this.txtVoucherCode.txtBackColor = System.Drawing.Color.White;
            this.txtVoucherCode.txtEnabled = true;
            this.txtVoucherCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVoucherCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVoucherCode.txtPasswrod = '\0';
            this.txtVoucherCode.txtReadOnly = false;
            this.txtVoucherCode.txtTag = null;
            this.txtVoucherCode.txtText = "";
            this.txtVoucherCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // frmQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(387, 281);
            this.Controls.Add(this.txtVoucherCode);
            this.Controls.Add(this.cmbTransferRM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTransferU8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbTmpSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpBeginDate);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "单据查询";
            this.Load += new System.EventHandler(this.frmQueryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lixtech.UserControls.UCTextBox txtItemName;
        private System.Windows.Forms.Label label1;
        private Lixtech.UserControls.UCTextBox txtEmployeeName;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTmpSave;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbTransferU8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTransferRM;
        private System.Windows.Forms.Label label5;
        private Lixtech.UserControls.UCTextBox txtVoucherCode;
    }
}