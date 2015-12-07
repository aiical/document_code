namespace Base
{
    partial class frmDeviceRepair
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
            this.cbType.Location = new System.Drawing.Point(746, 13);
            this.cbType.Visible = false;
            // 
            // cbCheck
            // 
            this.cbCheck.Visible = false;
            // 
            // cbFinish
            // 
            this.cbFinish.Location = new System.Drawing.Point(628, 13);
            this.cbFinish.Visible = false;
            // 
            // cbCutOff
            // 
            this.cbCutOff.Location = new System.Drawing.Point(510, 13);
            this.cbCutOff.Visible = false;
            // 
            // lbType
            // 
            this.lbType.Location = new System.Drawing.Point(711, 18);
            this.lbType.Visible = false;
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(587, 18);
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(469, 18);
            this.label3.Visible = false;
            // 
            // frmDeviceRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(809, 526);
            this.Name = "frmDeviceRepair";
            this.Text = "设备维护";
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCutOff.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
