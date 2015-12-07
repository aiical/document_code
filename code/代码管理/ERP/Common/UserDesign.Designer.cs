namespace Common
{
    partial class UserDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDesign));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvParent = new System.Windows.Forms.TreeView();
            this.tvImage = new System.Windows.Forms.ImageList(this.components);
            this.lvModule = new System.Windows.Forms.ListView();
            this.lvImage = new System.Windows.Forms.ImageList(this.components);
            this.pcTitle = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton4});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(618, 35);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Common.Properties.Resources.btnNew_Glyph;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton1.Text = "新增";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Common.Properties.Resources.btnEdit_Glyph;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton2.Text = "编辑";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Common.Properties.Resources.btnDel_Glyph;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton3.Text = "删除";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::Common.Properties.Resources.btnClose_Glyph;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton4.Text = "关闭";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 79);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvParent);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvModule);
            this.splitContainer1.Size = new System.Drawing.Size(618, 342);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvParent
            // 
            this.tvParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvParent.HideSelection = false;
            this.tvParent.ImageIndex = 0;
            this.tvParent.ImageList = this.tvImage;
            this.tvParent.Location = new System.Drawing.Point(0, 0);
            this.tvParent.Name = "tvParent";
            this.tvParent.SelectedImageIndex = 0;
            this.tvParent.Size = new System.Drawing.Size(206, 342);
            this.tvParent.TabIndex = 0;
            // 
            // tvImage
            // 
            this.tvImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tvImage.ImageStream")));
            this.tvImage.TransparentColor = System.Drawing.Color.Transparent;
            this.tvImage.Images.SetKeyName(0, "REFBAR.ICO");
            // 
            // lvModule
            // 
            this.lvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvModule.LargeImageList = this.lvImage;
            this.lvModule.Location = new System.Drawing.Point(0, 0);
            this.lvModule.Name = "lvModule";
            this.lvModule.Size = new System.Drawing.Size(408, 342);
            this.lvModule.TabIndex = 0;
            this.lvModule.UseCompatibleStateImageBehavior = false;
            this.lvModule.DoubleClick += new System.EventHandler(this.lvModule_DoubleClick);
            // 
            // lvImage
            // 
            this.lvImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lvImage.ImageStream")));
            this.lvImage.TransparentColor = System.Drawing.Color.Transparent;
            this.lvImage.Images.SetKeyName(0, "button46.Image.bmp");
            // 
            // pcTitle
            // 
            this.pcTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcTitle.Image = global::Common.Properties.Resources.pcTitle_Image;
            this.pcTitle.Location = new System.Drawing.Point(0, 35);
            this.pcTitle.Name = "pcTitle";
            this.pcTitle.Size = new System.Drawing.Size(618, 44);
            this.pcTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcTitle.TabIndex = 3;
            this.pcTitle.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(13, 39);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(82, 21);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "label1";
            // 
            // UserDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(618, 421);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pcTitle);
            this.Controls.Add(this.toolStrip);
            this.Name = "UserDesign";
            this.Text = "二次开发模块";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvParent;
        private System.Windows.Forms.ListView lvModule;
        private System.Windows.Forms.PictureBox pcTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ImageList tvImage;
        private System.Windows.Forms.ImageList lvImage;
    }
}
