namespace Finance
{
    partial class frmFMulDetailReport
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
            this.edSubject = new myControl.EditControl();
            this.sbSelItem = new DevExpress.XtraEditors.SimpleButton();
            this.spRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.cbBegin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.spYear = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).BeginInit();
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
            // ucDate
            // 
            this.ucDate.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Size = new System.Drawing.Size(794, 45);
            // 
            // edSubject
            // 
            this.edSubject.BackColor = System.Drawing.Color.Transparent;
            this.edSubject.DataField = null;
            this.edSubject.DataSource = null;
            this.edSubject.EditLabel = "科目:";
            this.edSubject.Enabled = false;
            this.edSubject.Location = new System.Drawing.Point(605, 40);
            this.edSubject.Name = "edSubject";
            this.edSubject.Request = false;
            this.edSubject.Size = new System.Drawing.Size(155, 21);
            this.edSubject.TabIndex = 48;
            // 
            // sbSelItem
            // 
            this.sbSelItem.Location = new System.Drawing.Point(761, 40);
            this.sbSelItem.Name = "sbSelItem";
            this.sbSelItem.Size = new System.Drawing.Size(28, 23);
            this.sbSelItem.TabIndex = 47;
            this.sbSelItem.Text = "...";
            this.sbSelItem.Click += new System.EventHandler(this.sbSelItem_Click);
            // 
            // spRefresh
            // 
            this.spRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spRefresh.Appearance.Options.UseFont = true;
            this.spRefresh.Location = new System.Drawing.Point(527, 35);
            this.spRefresh.Name = "spRefresh";
            this.spRefresh.Size = new System.Drawing.Size(61, 23);
            this.spRefresh.TabIndex = 45;
            this.spRefresh.Text = "刷新(&R)";
            this.spRefresh.Click += new System.EventHandler(this.spRefresh_Click);
            // 
            // cbBegin
            // 
            this.cbBegin.Location = new System.Drawing.Point(453, 37);
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
            this.cbBegin.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "会计期间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "会计年度:";
            // 
            // spYear
            // 
            this.spYear.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spYear.Location = new System.Drawing.Point(314, 37);
            this.spYear.Name = "spYear";
            this.spYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spYear.Properties.IsFloatValue = false;
            this.spYear.Properties.Mask.EditMask = "N00";
            this.spYear.Size = new System.Drawing.Size(68, 21);
            this.spYear.TabIndex = 43;
            // 
            // frmFMulDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(794, 501);
            this.Controls.Add(this.edSubject);
            this.Controls.Add(this.sbSelItem);
            this.Controls.Add(this.spRefresh);
            this.Controls.Add(this.cbBegin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spYear);
            this.Name = "frmFMulDetailReport";
            this.Text = "多栏式明细帐";
            this.Load += new System.EventHandler(this.frmFMulDetailReport_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.spYear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbBegin, 0);
            this.Controls.SetChildIndex(this.spRefresh, 0);
            this.Controls.SetChildIndex(this.sbSelItem, 0);
            this.Controls.SetChildIndex(this.edSubject, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private myControl.EditControl edSubject;
        private DevExpress.XtraEditors.SimpleButton sbSelItem;
        private DevExpress.XtraEditors.SimpleButton spRefresh;
        private DevExpress.XtraEditors.ComboBoxEdit cbBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SpinEdit spYear;
    }
}
