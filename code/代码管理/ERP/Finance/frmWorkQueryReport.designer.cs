namespace Finance
{
    partial class frmWorkQueryReport
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
            this.cbEnd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbBegin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.spYear = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDate
            // 
            this.ucDate.Visible = false;
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
            // cbEnd
            // 
            this.cbEnd.Location = new System.Drawing.Point(473, 39);
            this.cbEnd.Name = "cbEnd";
            this.cbEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEnd.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbEnd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbEnd.Size = new System.Drawing.Size(68, 21);
            this.cbEnd.TabIndex = 39;
            // 
            // cbBegin
            // 
            this.cbBegin.Location = new System.Drawing.Point(376, 39);
            this.cbBegin.Name = "cbBegin";
            this.cbBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBegin.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbBegin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBegin.Size = new System.Drawing.Size(68, 21);
            this.cbBegin.TabIndex = 38;
            // 
            // spRefresh
            // 
            this.spRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spRefresh.Appearance.Options.UseFont = true;
            this.spRefresh.Location = new System.Drawing.Point(547, 37);
            this.spRefresh.Name = "spRefresh";
            this.spRefresh.Size = new System.Drawing.Size(61, 23);
            this.spRefresh.TabIndex = 37;
            this.spRefresh.Text = "刷新(&R)";
            this.spRefresh.Click += new System.EventHandler(this.spRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "至";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "会计期间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "会计年度:";
            // 
            // spYear
            // 
            this.spYear.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spYear.Location = new System.Drawing.Point(211, 39);
            this.spYear.Name = "spYear";
            this.spYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spYear.Properties.IsFloatValue = false;
            this.spYear.Properties.Mask.EditMask = "N00";
            this.spYear.Size = new System.Drawing.Size(68, 21);
            this.spYear.TabIndex = 34;
            // 
            // frmWorkQueryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(748, 501);
            this.Controls.Add(this.cbEnd);
            this.Controls.Add(this.cbBegin);
            this.Controls.Add(this.spRefresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spYear);
            this.Name = "frmWorkQueryReport";
            this.Text = "累计工作量查询";
            this.Load += new System.EventHandler(this.frmFDetailReport_Load);
            this.Controls.SetChildIndex(this.spYear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.spRefresh, 0);
            this.Controls.SetChildIndex(this.cbBegin, 0);
            this.Controls.SetChildIndex(this.cbEnd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbEnd;
        private DevExpress.XtraEditors.ComboBoxEdit cbBegin;
        private DevExpress.XtraEditors.SimpleButton spRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SpinEdit spYear;
    }
}
