namespace myControl
{
    partial class ckControl
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ckEdit = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ckEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ckEdit
            // 
            this.ckEdit.Location = new System.Drawing.Point(3, -1);
            this.ckEdit.Name = "ckEdit";
            this.ckEdit.Properties.Caption = "";
            this.ckEdit.Size = new System.Drawing.Size(43, 19);
            this.ckEdit.TabIndex = 1;
            // 
            // ckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ckEdit);
            this.Name = "ckControl";
            this.Size = new System.Drawing.Size(96, 21);
            ((System.ComponentModel.ISupportInitialize)(this.ckEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ckEdit;

    }
}
