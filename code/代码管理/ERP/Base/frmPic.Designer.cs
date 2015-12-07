namespace Base
{
    partial class frmPic
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
            this.pePic = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pePic.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pePic
            // 
            this.pePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pePic.Location = new System.Drawing.Point(0, 0);
            this.pePic.Name = "pePic";
            this.pePic.Properties.NullText = " ";
            this.pePic.Size = new System.Drawing.Size(518, 385);
            this.pePic.TabIndex = 0;
            // 
            // frmPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(518, 385);
            this.Controls.Add(this.pePic);
            this.Name = "frmPic";
            this.Text = "图片";
            ((System.ComponentModel.ISupportInitialize)(this.pePic.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PictureEdit pePic;

    }
}
