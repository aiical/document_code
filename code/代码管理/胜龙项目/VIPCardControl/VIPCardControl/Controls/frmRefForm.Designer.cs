namespace UFIDA.Retail.VIPCardControl
{
    partial class frmRefForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtRef = new Lixtech.UserControls.UCTextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(201, 61);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(104, 61);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtRef
            // 
            this.txtRef.BackColor = System.Drawing.SystemColors.Control;
            this.txtRef.btnEnabled = true;
            this.txtRef.btnVisible = true;
            this.txtRef.lblBackColor = System.Drawing.SystemColors.Control;
            this.txtRef.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRef.lblForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtRef.lblText = "销售类别";
            this.txtRef.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtRef.Location = new System.Drawing.Point(23, 21);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(241, 18);
            this.txtRef.TabIndex = 25;
            this.txtRef.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtRef.txtEnabled = true;
            this.txtRef.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRef.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRef.txtPasswrod = '\0';
            this.txtRef.txtReadOnly = false;
            this.txtRef.txtTag = null;
            this.txtRef.txtText = "";
            this.txtRef.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRef.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtRef_Button_Click);
            this.txtRef.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtRef_TextBox_KeyPress);
            // 
            // frmRefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(292, 92);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "销售类别";
            this.Load += new System.EventHandler(this.frmRefForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private Lixtech.UserControls.UCTextBox txtRef;
    }
}