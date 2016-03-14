namespace UFIDA.Retail.VIPCardControl
{
    partial class frmZTReturnQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZTReturnQuery));
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.txtZTCustomer = new Lixtech.UserControls.UCTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaleType = new Lixtech.UserControls.UCTextBox();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(181, 240);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(88, 24);
            this.btnFinish.TabIndex = 66;
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
            this.btnExit.Location = new System.Drawing.Point(292, 240);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 24);
            this.btnExit.TabIndex = 67;
            this.btnExit.Text = "    退 出(&Q)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(237, 15);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(143, 21);
            this.dtpEndDate.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "-";
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(71, 16);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.ShowCheckBox = true;
            this.dtpBeginDate.Size = new System.Drawing.Size(143, 21);
            this.dtpBeginDate.TabIndex = 61;
            // 
            // txtZTCustomer
            // 
            this.txtZTCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.txtZTCustomer.btnEnabled = true;
            this.txtZTCustomer.btnVisible = true;
            this.txtZTCustomer.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtZTCustomer.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZTCustomer.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtZTCustomer.lblText = "展厅客户";
            this.txtZTCustomer.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtZTCustomer.Location = new System.Drawing.Point(15, 69);
            this.txtZTCustomer.Name = "txtZTCustomer";
            this.txtZTCustomer.Size = new System.Drawing.Size(365, 18);
            this.txtZTCustomer.TabIndex = 60;
            this.txtZTCustomer.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtZTCustomer.txtEnabled = true;
            this.txtZTCustomer.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZTCustomer.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtZTCustomer.txtPasswrod = '\0';
            this.txtZTCustomer.txtReadOnly = false;
            this.txtZTCustomer.txtTag = null;
            this.txtZTCustomer.txtText = "";
            this.txtZTCustomer.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtZTCustomer.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtZTCustomer_Button_Click);
            this.txtZTCustomer.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtZTCustomer_TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 59;
            this.label1.Text = "单据日期";
            // 
            // txtSaleType
            // 
            this.txtSaleType.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaleType.btnEnabled = true;
            this.txtSaleType.btnVisible = true;
            this.txtSaleType.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtSaleType.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSaleType.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtSaleType.lblText = "销售类型";
            this.txtSaleType.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSaleType.Location = new System.Drawing.Point(15, 45);
            this.txtSaleType.Name = "txtSaleType";
            this.txtSaleType.Size = new System.Drawing.Size(365, 18);
            this.txtSaleType.TabIndex = 58;
            this.txtSaleType.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtSaleType.txtEnabled = true;
            this.txtSaleType.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSaleType.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSaleType.txtPasswrod = '\0';
            this.txtSaleType.txtReadOnly = false;
            this.txtSaleType.txtTag = null;
            this.txtSaleType.txtText = "";
            this.txtSaleType.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSaleType.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtSaleType_Button_Click);
            this.txtSaleType.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtSaleType_TextBox_KeyPress);
            // 
            // frmZTReturnQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(385, 279);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpBeginDate);
            this.Controls.Add(this.txtZTCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaleType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmZTReturnQuery";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条件查询";
            this.Load += new System.EventHandler(this.frmZTReturnQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private Lixtech.UserControls.UCTextBox txtZTCustomer;
        private System.Windows.Forms.Label label1;
        private Lixtech.UserControls.UCTextBox txtSaleType;
    }
}