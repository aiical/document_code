namespace Common
{
    partial class frmDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gbox = new System.Windows.Forms.GroupBox();
            this.binData = new System.Windows.Forms.BindingSource(this.components);
            this.ckCopy = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(238, 253);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "确定(&O)";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(319, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbox
            // 
            this.gbox.Location = new System.Drawing.Point(13, 13);
            this.gbox.Name = "gbox";
            this.gbox.Size = new System.Drawing.Size(381, 234);
            this.gbox.TabIndex = 0;
            this.gbox.TabStop = false;
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(100, 257);
            this.ckCopy.Name = "ckCopy";
            this.ckCopy.Properties.Caption = "复制前一记录";
            this.ckCopy.Size = new System.Drawing.Size(101, 19);
            this.ckCopy.TabIndex = 7;
            this.ckCopy.Visible = false;
            // 
            // frmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(406, 288);
            this.Controls.Add(this.ckCopy);
            this.Controls.Add(this.gbox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialog";
            this.Load += new System.EventHandler(this.frmDialog_Load);
            this.Shown += new System.EventHandler(this.frmDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected internal DevExpress.XtraEditors.SimpleButton BtnOK;
        protected internal DevExpress.XtraEditors.SimpleButton btnCancel;
        protected internal System.Windows.Forms.GroupBox gbox;
        public System.Windows.Forms.BindingSource binData;
        public DevExpress.XtraEditors.CheckEdit ckCopy;

    }
}
