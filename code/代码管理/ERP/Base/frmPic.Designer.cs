namespace Base
{
    partial class frmPic
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
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
            this.Text = "ͼƬ";
            ((System.ComponentModel.ISupportInitialize)(this.pePic.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PictureEdit pePic;

    }
}
