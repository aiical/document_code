namespace Product
{
    partial class frmProductInList
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
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCutOff.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.Size = new System.Drawing.Size(60, 23);
            // 
            // cbCheck
            // 
            this.cbCheck.Size = new System.Drawing.Size(61, 23);
            // 
            // cbFinish
            // 
            this.cbFinish.Size = new System.Drawing.Size(61, 23);
            this.cbFinish.Visible = false;
            // 
            // cbCutOff
            // 
            this.cbCutOff.Size = new System.Drawing.Size(61, 23);
            this.cbCutOff.Visible = false;
            // 
            // label2
            // 
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Visible = false;
            // 
            // frmProductInList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(809, 526);
            this.Name = "frmProductInList";
            this.Text = "生产完工单列表";
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCutOff.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
