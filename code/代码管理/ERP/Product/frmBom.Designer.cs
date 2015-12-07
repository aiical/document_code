namespace Product
{
    partial class frmBom
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
            this.tvItem = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvType
            // 
            this.tvType.LineColor = System.Drawing.Color.Black;
            this.tvType.Size = new System.Drawing.Size(181, 323);
            this.tvType.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 72);
            this.splitContainer1.Size = new System.Drawing.Size(644, 323);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Size = new System.Drawing.Size(644, 46);
            // 
            // tvItem
            // 
            this.tvItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.tvItem.Location = new System.Drawing.Point(360, 72);
            this.tvItem.Name = "tvItem";
            this.tvItem.Size = new System.Drawing.Size(281, 323);
            this.tvItem.TabIndex = 15;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(641, 72);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 323);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // frmBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(644, 417);
            this.Controls.Add(this.tvItem);
            this.Controls.Add(this.splitter1);
            this.Name = "frmBom";
            this.Text = "物料清单";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.tvItem, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvItem;
        private System.Windows.Forms.Splitter splitter1;
    }
}
