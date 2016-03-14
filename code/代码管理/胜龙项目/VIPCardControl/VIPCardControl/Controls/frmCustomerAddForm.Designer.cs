namespace UFIDA.Retail.VIPCardControl
{
    partial class frmCustomerAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerAddForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtFaxCode = new Lixtech.UserControls.UCTextBox();
            this.txtPhoneNum = new Lixtech.UserControls.UCTextBox();
            this.txtWorkPlace = new Lixtech.UserControls.UCTextBox();
            this.txtAddr = new Lixtech.UserControls.UCTextBox();
            this.txtMobileNum = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerName = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerCode = new Lixtech.UserControls.UCTextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(352, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(255, 302);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtFaxCode
            // 
            this.txtFaxCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtFaxCode.btnEnabled = true;
            this.txtFaxCode.btnVisible = false;
            this.txtFaxCode.clearBtnName = "btnClear";
            this.txtFaxCode.lableName = "lblName";
            this.txtFaxCode.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtFaxCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFaxCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFaxCode.lblText = "传真号码";
            this.txtFaxCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtFaxCode.Location = new System.Drawing.Point(12, 86);
            this.txtFaxCode.Name = "txtFaxCode";
            this.txtFaxCode.selectBtnName = "btn";
            this.txtFaxCode.Size = new System.Drawing.Size(169, 18);
            this.txtFaxCode.TabIndex = 5;
            this.txtFaxCode.textName = "txtName";
            this.txtFaxCode.txtBackColor = System.Drawing.Color.White;
            this.txtFaxCode.txtEnabled = true;
            this.txtFaxCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFaxCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFaxCode.txtPasswrod = '\0';
            this.txtFaxCode.txtReadOnly = false;
            this.txtFaxCode.txtTag = null;
            this.txtFaxCode.txtText = "";
            this.txtFaxCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.BackColor = System.Drawing.SystemColors.Control;
            this.txtPhoneNum.btnEnabled = true;
            this.txtPhoneNum.btnVisible = false;
            this.txtPhoneNum.clearBtnName = "btnClear";
            this.txtPhoneNum.lableName = "lblName";
            this.txtPhoneNum.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtPhoneNum.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhoneNum.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPhoneNum.lblText = "固定电话";
            this.txtPhoneNum.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtPhoneNum.Location = new System.Drawing.Point(258, 49);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.selectBtnName = "btn";
            this.txtPhoneNum.Size = new System.Drawing.Size(177, 18);
            this.txtPhoneNum.TabIndex = 4;
            this.txtPhoneNum.textName = "txtName";
            this.txtPhoneNum.txtBackColor = System.Drawing.Color.White;
            this.txtPhoneNum.txtEnabled = true;
            this.txtPhoneNum.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhoneNum.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPhoneNum.txtPasswrod = '\0';
            this.txtPhoneNum.txtReadOnly = false;
            this.txtPhoneNum.txtTag = null;
            this.txtPhoneNum.txtText = "";
            this.txtPhoneNum.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtWorkPlace
            // 
            this.txtWorkPlace.BackColor = System.Drawing.SystemColors.Control;
            this.txtWorkPlace.btnEnabled = true;
            this.txtWorkPlace.btnVisible = false;
            this.txtWorkPlace.clearBtnName = "btnClear";
            this.txtWorkPlace.lableName = "lblName";
            this.txtWorkPlace.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtWorkPlace.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWorkPlace.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtWorkPlace.lblText = "工作单位";
            this.txtWorkPlace.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtWorkPlace.Location = new System.Drawing.Point(258, 86);
            this.txtWorkPlace.Name = "txtWorkPlace";
            this.txtWorkPlace.selectBtnName = "btn";
            this.txtWorkPlace.Size = new System.Drawing.Size(177, 18);
            this.txtWorkPlace.TabIndex = 6;
            this.txtWorkPlace.textName = "txtName";
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
            // txtAddr
            // 
            this.txtAddr.BackColor = System.Drawing.SystemColors.Control;
            this.txtAddr.btnEnabled = true;
            this.txtAddr.btnVisible = false;
            this.txtAddr.clearBtnName = "btnClear";
            this.txtAddr.lableName = "lblName";
            this.txtAddr.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtAddr.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddr.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddr.lblText = "联系地址";
            this.txtAddr.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtAddr.Location = new System.Drawing.Point(12, 123);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.selectBtnName = "btn";
            this.txtAddr.Size = new System.Drawing.Size(426, 18);
            this.txtAddr.TabIndex = 7;
            this.txtAddr.textName = "txtName";
            this.txtAddr.txtBackColor = System.Drawing.Color.White;
            this.txtAddr.txtEnabled = true;
            this.txtAddr.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddr.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddr.txtPasswrod = '\0';
            this.txtAddr.txtReadOnly = false;
            this.txtAddr.txtTag = null;
            this.txtAddr.txtText = "";
            this.txtAddr.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtMobileNum
            // 
            this.txtMobileNum.BackColor = System.Drawing.SystemColors.Control;
            this.txtMobileNum.btnEnabled = true;
            this.txtMobileNum.btnVisible = false;
            this.txtMobileNum.clearBtnName = "btnClear";
            this.txtMobileNum.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMobileNum.lableName = "lblName";
            this.txtMobileNum.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtMobileNum.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMobileNum.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMobileNum.lblText = "手机号码";
            this.txtMobileNum.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtMobileNum.Location = new System.Drawing.Point(12, 49);
            this.txtMobileNum.Name = "txtMobileNum";
            this.txtMobileNum.selectBtnName = "btn";
            this.txtMobileNum.Size = new System.Drawing.Size(169, 18);
            this.txtMobileNum.TabIndex = 3;
            this.txtMobileNum.textName = "txtName";
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
            // txtConsumerName
            // 
            this.txtConsumerName.BackColor = System.Drawing.SystemColors.Control;
            this.txtConsumerName.btnEnabled = true;
            this.txtConsumerName.btnVisible = false;
            this.txtConsumerName.clearBtnName = "btnClear";
            this.txtConsumerName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtConsumerName.lableName = "lblName";
            this.txtConsumerName.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtConsumerName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerName.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsumerName.lblText = "客户名称";
            this.txtConsumerName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtConsumerName.Location = new System.Drawing.Point(255, 12);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.selectBtnName = "btn";
            this.txtConsumerName.Size = new System.Drawing.Size(180, 18);
            this.txtConsumerName.TabIndex = 2;
            this.txtConsumerName.textName = "txtName";
            this.txtConsumerName.txtBackColor = System.Drawing.Color.White;
            this.txtConsumerName.txtEnabled = true;
            this.txtConsumerName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConsumerName.txtPasswrod = '\0';
            this.txtConsumerName.txtReadOnly = false;
            this.txtConsumerName.txtTag = null;
            this.txtConsumerName.txtText = "";
            this.txtConsumerName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtConsumerCode
            // 
            this.txtConsumerCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtConsumerCode.btnEnabled = true;
            this.txtConsumerCode.btnVisible = false;
            this.txtConsumerCode.clearBtnName = "btnClear";
            this.txtConsumerCode.lableName = "lblName";
            this.txtConsumerCode.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtConsumerCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsumerCode.lblText = "客户编码";
            this.txtConsumerCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtConsumerCode.Location = new System.Drawing.Point(12, 12);
            this.txtConsumerCode.Name = "txtConsumerCode";
            this.txtConsumerCode.selectBtnName = "btn";
            this.txtConsumerCode.Size = new System.Drawing.Size(169, 18);
            this.txtConsumerCode.TabIndex = 1;
            this.txtConsumerCode.textName = "txtName";
            this.txtConsumerCode.txtBackColor = System.Drawing.Color.White;
            this.txtConsumerCode.txtEnabled = true;
            this.txtConsumerCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConsumerCode.txtPasswrod = '\0';
            this.txtConsumerCode.txtReadOnly = false;
            this.txtConsumerCode.txtTag = null;
            this.txtConsumerCode.txtText = "POS";
            this.txtConsumerCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtConsumerCode.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtConsumerCode_TextBox_KeyPress);
            this.txtConsumerCode.textBox_TextChanged += new Lixtech.UserControls.UCTextBox.TextBoxEnter(this.txtConsumerCode_textBox_TextChanged);
            // 
            // frmCustomerAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(454, 337);
            this.Controls.Add(this.txtFaxCode);
            this.Controls.Add(this.txtPhoneNum);
            this.Controls.Add(this.txtWorkPlace);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.txtMobileNum);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.txtConsumerCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerAddForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "展厅客户添加";
            this.Load += new System.EventHandler(this.frmCustomerAddForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private Lixtech.UserControls.UCTextBox txtAddr;
        private Lixtech.UserControls.UCTextBox txtMobileNum;
        private Lixtech.UserControls.UCTextBox txtConsumerName;
        private Lixtech.UserControls.UCTextBox txtConsumerCode;
        private Lixtech.UserControls.UCTextBox txtWorkPlace;
        private Lixtech.UserControls.UCTextBox txtPhoneNum;
        private Lixtech.UserControls.UCTextBox txtFaxCode;
    }
}