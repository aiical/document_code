namespace Common
{
    partial class CopyReportForm
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
            this.txtOld = new myControl.EditControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.winButton1 = new System.Windows.Forms.Button();
            this.txtNew = new myControl.EditControl();
            this.SuspendLayout();
            // 
            // txtOld
            // 
            this.txtOld.DataField = "";
            this.txtOld.Enabled = false;
            this.txtOld.EditLabel = "原报表名称:";
            this.txtOld.Location = new System.Drawing.Point(25, 21);
            this.txtOld.Name = "txtOld";
            this.txtOld.Request = false;
            this.txtOld.Size = new System.Drawing.Size(235, 23);
            this.txtOld.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(102, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // winButton1
            // 
            this.winButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.winButton1.Location = new System.Drawing.Point(183, 117);
            this.winButton1.Name = "winButton1";
            this.winButton1.Size = new System.Drawing.Size(75, 23);
            this.winButton1.TabIndex = 2;
            this.winButton1.Text = "取消(&C)";
            // 
            // txtNew
            // 
            this.txtNew.DataField = "";
            this.txtNew.EditLabel = "新报表名称:";
            this.txtNew.Location = new System.Drawing.Point(25, 64);
            this.txtNew.Name = "txtNew";
            this.txtNew.Request = false;
            this.txtNew.Size = new System.Drawing.Size(235, 23);
            this.txtNew.TabIndex = 0;
            // 
            // CopyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 157);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.winButton1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtOld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyReportForm";
            this.Text = "复制报表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button winButton1;
        public myControl.EditControl txtOld;
        public myControl.EditControl txtNew;
    }
}