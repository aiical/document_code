namespace Finance
{
    partial class frmFDetailReport
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
            this.cbEnd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbBegin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.spYear = new DevExpress.XtraEditors.SpinEdit();
            this.sbSelItem = new DevExpress.XtraEditors.SimpleButton();
            this.edSubject = new myControl.EditControl();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnd.Properties)).BeginInit();
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
            this.cbEnd.Visible = false;
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
            this.spRefresh.Location = new System.Drawing.Point(450, 37);
            this.spRefresh.Name = "spRefresh";
            this.spRefresh.Size = new System.Drawing.Size(61, 23);
            this.spRefresh.TabIndex = 37;
            this.spRefresh.Text = "ˢ��(&R)";
            this.spRefresh.Click += new System.EventHandler(this.spRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "��";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "����ڼ�:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "������:";
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
            // sbSelItem
            // 
            this.sbSelItem.Location = new System.Drawing.Point(708, 37);
            this.sbSelItem.Name = "sbSelItem";
            this.sbSelItem.Size = new System.Drawing.Size(28, 23);
            this.sbSelItem.TabIndex = 40;
            this.sbSelItem.Text = "...";
            this.sbSelItem.Click += new System.EventHandler(this.sbSelItem_Click);
            // 
            // edSubject
            // 
            this.edSubject.BackColor = System.Drawing.Color.Transparent;
            this.edSubject.DataField = null;
            this.edSubject.DataSource = null;
            this.edSubject.EditLabel = "��Ŀ:";
            this.edSubject.Enabled = false;
            this.edSubject.Location = new System.Drawing.Point(547, 39);
            this.edSubject.Name = "edSubject";
            this.edSubject.Request = false;
            this.edSubject.Size = new System.Drawing.Size(155, 21);
            this.edSubject.TabIndex = 41;
            // 
            // frmFDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(748, 501);
            this.Controls.Add(this.edSubject);
            this.Controls.Add(this.sbSelItem);
            this.Controls.Add(this.spRefresh);
            this.Controls.Add(this.cbEnd);
            this.Controls.Add(this.cbBegin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spYear);
            this.Name = "frmFDetailReport";
            this.Text = "��ϸ������";
            this.Load += new System.EventHandler(this.frmFDetailReport_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.spYear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cbBegin, 0);
            this.Controls.SetChildIndex(this.cbEnd, 0);
            this.Controls.SetChildIndex(this.spRefresh, 0);
            this.Controls.SetChildIndex(this.sbSelItem, 0);
            this.Controls.SetChildIndex(this.edSubject, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private DevExpress.XtraEditors.SimpleButton sbSelItem;
        private myControl.EditControl edSubject;
    }
}
