namespace Common
{
    partial class EditReportForm
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
            this.txtReport = new myControl.EditControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.winButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtReport
            // 
            this.txtReport.DataField = "";
            this.txtReport.EditLabel = "报表名称:";
            this.txtReport.Location = new System.Drawing.Point(27, 30);
            this.txtReport.Name = "txtReport";
            this.txtReport.Request = false;
            this.txtReport.Size = new System.Drawing.Size(235, 23);
            this.txtReport.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(106, 77);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // winButton1
            // 
            this.winButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.winButton1.Location = new System.Drawing.Point(187, 77);
            this.winButton1.Name = "winButton1";
            this.winButton1.Size = new System.Drawing.Size(75, 23);
            this.winButton1.TabIndex = 2;
            this.winButton1.Text = "取消(&C)";
            // 
            // EditReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 116);
            this.Controls.Add(this.winButton1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditReportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button winButton1;
        public myControl.EditControl txtReport;
    }
}