namespace UFIDA.Retail.VIPCardControl
{
    partial class frmAddItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddItemForm));
            this.txtItemName = new Lixtech.UserControls.UCTextBox();
            this.txtItemCode = new Lixtech.UserControls.UCTextBox();
            this.txtItemStd = new Lixtech.UserControls.UCTextBox();
            this.txtUnitName = new Lixtech.UserControls.UCTextBox();
            this.txtOutQuantity = new Lixtech.UserControls.UCTextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.txtItemName.Location = new System.Drawing.Point(12, 12);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(216, 18);
            this.txtItemName.TabIndex = 4;
            this.txtItemName.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtItemName.txtEnabled = true;
            this.txtItemName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtItemName.txtPasswrod = '\0';
            this.txtItemName.txtReadOnly = false;
            this.txtItemName.txtTag = null;
            this.txtItemName.txtText = "";
            this.txtItemName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemName.Load += new System.EventHandler(this.txtItemName_Load);
            this.txtItemName.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtItemName_Button_Click);
            this.txtItemName.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtItemName_TextBox_KeyPress);
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtItemCode.btnEnabled = true;
            this.txtItemCode.btnVisible = false;
            this.txtItemCode.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtItemCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtItemCode.lblText = "商品编码";
            this.txtItemCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtItemCode.Location = new System.Drawing.Point(253, 12);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(216, 18);
            this.txtItemCode.TabIndex = 17;
            this.txtItemCode.txtBackColor = System.Drawing.Color.White;
            this.txtItemCode.txtEnabled = true;
            this.txtItemCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtItemCode.txtPasswrod = '\0';
            this.txtItemCode.txtReadOnly = true;
            this.txtItemCode.txtTag = null;
            this.txtItemCode.txtText = "";
            this.txtItemCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtItemStd
            // 
            this.txtItemStd.BackColor = System.Drawing.SystemColors.Control;
            this.txtItemStd.btnEnabled = true;
            this.txtItemStd.btnVisible = false;
            this.txtItemStd.Enabled = false;
            this.txtItemStd.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtItemStd.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemStd.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtItemStd.lblText = "规格型号";
            this.txtItemStd.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtItemStd.Location = new System.Drawing.Point(12, 47);
            this.txtItemStd.Name = "txtItemStd";
            this.txtItemStd.Size = new System.Drawing.Size(216, 18);
            this.txtItemStd.TabIndex = 18;
            this.txtItemStd.txtBackColor = System.Drawing.Color.White;
            this.txtItemStd.txtEnabled = true;
            this.txtItemStd.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemStd.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtItemStd.txtPasswrod = '\0';
            this.txtItemStd.txtReadOnly = true;
            this.txtItemStd.txtTag = null;
            this.txtItemStd.txtText = "";
            this.txtItemStd.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtUnitName
            // 
            this.txtUnitName.BackColor = System.Drawing.SystemColors.Control;
            this.txtUnitName.btnEnabled = true;
            this.txtUnitName.btnVisible = false;
            this.txtUnitName.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtUnitName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnitName.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUnitName.lblText = "计量单位";
            this.txtUnitName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtUnitName.Location = new System.Drawing.Point(253, 47);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(216, 18);
            this.txtUnitName.TabIndex = 19;
            this.txtUnitName.txtBackColor = System.Drawing.Color.White;
            this.txtUnitName.txtEnabled = true;
            this.txtUnitName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnitName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnitName.txtPasswrod = '\0';
            this.txtUnitName.txtReadOnly = true;
            this.txtUnitName.txtTag = null;
            this.txtUnitName.txtText = "";
            this.txtUnitName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtOutQuantity
            // 
            this.txtOutQuantity.BackColor = System.Drawing.SystemColors.Control;
            this.txtOutQuantity.btnEnabled = true;
            this.txtOutQuantity.btnVisible = false;
            this.txtOutQuantity.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtOutQuantity.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutQuantity.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtOutQuantity.lblText = "借出数量";
            this.txtOutQuantity.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtOutQuantity.Location = new System.Drawing.Point(12, 86);
            this.txtOutQuantity.Name = "txtOutQuantity";
            this.txtOutQuantity.Size = new System.Drawing.Size(216, 18);
            this.txtOutQuantity.TabIndex = 20;
            this.txtOutQuantity.txtBackColor = System.Drawing.Color.White;
            this.txtOutQuantity.txtEnabled = true;
            this.txtOutQuantity.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutQuantity.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOutQuantity.txtPasswrod = '\0';
            this.txtOutQuantity.txtReadOnly = false;
            this.txtOutQuantity.txtTag = null;
            this.txtOutQuantity.txtText = "";
            this.txtOutQuantity.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnFinish
            // 
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(299, 128);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 21;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(396, 128);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-1, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 2);
            this.label1.TabIndex = 23;
            // 
            // frmAddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(481, 155);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtOutQuantity);
            this.Controls.Add(this.txtUnitName);
            this.Controls.Add(this.txtItemStd);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.txtItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAddItemForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增";
            this.ResumeLayout(false);

        }

        #endregion

        private Lixtech.UserControls.UCTextBox txtItemName;
        private Lixtech.UserControls.UCTextBox txtItemCode;
        private Lixtech.UserControls.UCTextBox txtItemStd;
        private Lixtech.UserControls.UCTextBox txtUnitName;
        private Lixtech.UserControls.UCTextBox txtOutQuantity;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}