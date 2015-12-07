namespace Common
{
    partial class frmSQL
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.spCancel = new DevExpress.XtraEditors.SimpleButton();
            this.spOK = new DevExpress.XtraEditors.SimpleButton();
            this.MeSQL = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeSQL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.spCancel);
            this.panelControl1.Controls.Add(this.spOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 374);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(596, 37);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Text = "panelControl1";
            // 
            // spCancel
            // 
            this.spCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spCancel.Appearance.Options.UseFont = true;
            this.spCancel.Location = new System.Drawing.Point(514, 6);
            this.spCancel.Name = "spCancel";
            this.spCancel.Size = new System.Drawing.Size(75, 23);
            this.spCancel.TabIndex = 1;
            this.spCancel.Text = "取消(&C)";
            this.spCancel.Click += new System.EventHandler(this.spCancel_Click);
            // 
            // spOK
            // 
            this.spOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spOK.Appearance.Options.UseFont = true;
            this.spOK.Location = new System.Drawing.Point(433, 7);
            this.spOK.Name = "spOK";
            this.spOK.Size = new System.Drawing.Size(75, 23);
            this.spOK.TabIndex = 0;
            this.spOK.Text = "确定(&O)";
            this.spOK.Click += new System.EventHandler(this.spOK_Click);
            // 
            // MeSQL
            // 
            this.MeSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MeSQL.Location = new System.Drawing.Point(0, 0);
            this.MeSQL.Name = "MeSQL";
            this.MeSQL.Size = new System.Drawing.Size(596, 374);
            this.MeSQL.TabIndex = 0;
            // 
            // frmSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(596, 411);
            this.Controls.Add(this.MeSQL);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmSQL";
            this.Text = "设置SQL语句";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MeSQL.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton spCancel;
        private DevExpress.XtraEditors.SimpleButton spOK;
        public DevExpress.XtraEditors.MemoEdit MeSQL;
    }
}
