namespace Finance
{
    partial class frmFSubjectTotalReport
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
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rgOption
            // 
            this.rgOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgOption.Properties.Appearance.Options.UseBackColor = true;
            this.rgOption.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(101, 24);
            this.lbTitle.Text = "frmBase";
            // 
            // frmFSubjectTotalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(748, 501);
            this.Name = "frmFSubjectTotalReport";
            this.Text = "科目汇总表";
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
