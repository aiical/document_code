namespace UFIDA.Retail.VIPCardControl
{
    partial class FrmNoSalesSubmit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNoSalesSubmit));
            this.txtNoSaleDate = new UFIDA.Retail.Components.ExDatePicker();
            this.btnCancel = new UFIDA.Retail.VIPCardControl.ButtonNormal();
            this.btnOK = new UFIDA.Retail.VIPCardControl.ButtonNormal();
            this.lblLine = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNoSaleDate
            // 
            this.txtNoSaleDate.AutoCaptionWidth = false;
            this.txtNoSaleDate.AutoTitleWidth = "False";
            this.txtNoSaleDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNoSaleDate.Caption = "选择0销售日期";
            this.txtNoSaleDate.Checked = "True";
            this.txtNoSaleDate.ColSpan = 1;
            this.txtNoSaleDate.ControlValue = "2008-10-31 0:00:00";
            this.txtNoSaleDate.DateFormat = "";
            this.txtNoSaleDate.EnableControl = "True";
            this.txtNoSaleDate.Format = "";
            this.txtNoSaleDate.Location = new System.Drawing.Point(20, 14);
            this.txtNoSaleDate.Name = "txtNoSaleDate";
            this.txtNoSaleDate.QueryValue = "2008-10-31 0:00:00";
            this.txtNoSaleDate.ReturnValueFormat = "";
            this.txtNoSaleDate.ShowCheckBox = "False";
            this.txtNoSaleDate.Size = new System.Drawing.Size(253, 21);
            this.txtNoSaleDate.TabIndex = 26;
            this.txtNoSaleDate.TextMaxLen = "";
            this.txtNoSaleDate.ToolTips = "销售日期";
            // 
            // btnCancel
            // 
            this.btnCancel.AntiAlias = true;
            this.btnCancel.Checked = false;
            this.btnCancel.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnCancel.DefaultEndColor = System.Drawing.Color.AliceBlue;
            this.btnCancel.DefaultStartColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("SimSun", 9F);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(155, 59);
            this.btnCancel.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnCancel.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnCancel.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnCancel.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnCancel.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowFocusRectangle = true;
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.VKCode = ((short)(0));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AntiAlias = true;
            this.btnOK.Checked = false;
            this.btnOK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.btnOK.DefaultEndColor = System.Drawing.Color.AliceBlue;
            this.btnOK.DefaultStartColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("SimSun", 9F);
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(67, 59);
            this.btnOK.MouseDownEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(131)))));
            this.btnOK.MouseDownStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(151)))), ((int)(((byte)(84)))));
            this.btnOK.MouseEnterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnOK.MouseEnterEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(152)))));
            this.btnOK.MouseEnterStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(197)))));
            this.btnOK.Name = "btnOK";
            this.btnOK.ShowFocusRectangle = true;
            this.btnOK.Size = new System.Drawing.Size(80, 28);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "确认(&O)";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.VKCode = ((short)(0));
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Location = new System.Drawing.Point(1, 49);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(300, 2);
            this.lblLine.TabIndex = 25;
            // 
            // FrmNoSalesSubmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 100);
            this.Controls.Add(this.txtNoSaleDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblLine);
            this.Name = "FrmNoSalesSubmit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门店0销售确认";
            this.Load += new System.EventHandler(this.FrmNoSalesSubmit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.Retail.Components.ExDatePicker txtNoSaleDate;
        private ButtonNormal btnCancel;
        private ButtonNormal btnOK;
        private System.Windows.Forms.Label lblLine;
    }
}