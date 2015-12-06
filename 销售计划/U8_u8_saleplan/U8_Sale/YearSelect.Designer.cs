namespace U8_Sale
{
    partial class YearSelect
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
            this.dteiYear = new DevExpress.XtraEditors.DateEdit();
            this.btnsure = new DevExpress.XtraEditors.SimpleButton();
            this.btncancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dteiYear.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteiYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dteiYear
            // 
            this.dteiYear.EditValue = null;
            this.dteiYear.Location = new System.Drawing.Point(56, 54);
            this.dteiYear.Name = "dteiYear";
            this.dteiYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteiYear.Properties.DisplayFormat.FormatString = "yyyy";
            this.dteiYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteiYear.Properties.Mask.EditMask = "yyyy";
            this.dteiYear.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteiYear.Size = new System.Drawing.Size(212, 21);
            this.dteiYear.TabIndex = 0;
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(35, 128);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(94, 23);
            this.btnsure.TabIndex = 9;
            this.btnsure.Text = "确定";
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(183, 128);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(94, 23);
            this.btncancel.TabIndex = 10;
            this.btncancel.Text = "退出";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // YearSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 183);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.dteiYear);
            this.Name = "YearSelect";
            this.Text = "计划年份选择";
            ((System.ComponentModel.ISupportInitialize)(this.dteiYear.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteiYear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dteiYear;
        private DevExpress.XtraEditors.SimpleButton btnsure;
        private DevExpress.XtraEditors.SimpleButton btncancel;

    }
}