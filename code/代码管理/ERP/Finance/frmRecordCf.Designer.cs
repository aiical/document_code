namespace Finance
{
    partial class frmRecordCf
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
            this.cbRecord = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbUnRecord = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRecord
            // 
            this.cbRecord.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRecord.Appearance.Options.UseFont = true;
            this.cbRecord.Location = new System.Drawing.Point(32, 174);
            this.cbRecord.Name = "cbRecord";
            this.cbRecord.Size = new System.Drawing.Size(75, 23);
            this.cbRecord.TabIndex = 4;
            this.cbRecord.Text = "����";
            this.cbRecord.Click += new System.EventHandler(this.cbRecord_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(255, 174);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 5;
            this.sbCancel.Text = "�ر�";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbUnRecord
            // 
            this.sbUnRecord.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbUnRecord.Appearance.Options.UseFont = true;
            this.sbUnRecord.Location = new System.Drawing.Point(139, 174);
            this.sbUnRecord.Name = "sbUnRecord";
            this.sbUnRecord.Size = new System.Drawing.Size(75, 23);
            this.sbUnRecord.TabIndex = 6;
            this.sbUnRecord.Text = "������";
            this.sbUnRecord.Click += new System.EventHandler(this.sbUnRecord_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 134);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "��ǰ����·�:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "��ǰ������:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "��ʾ:���ε��ʽ��ѵ�ǰ����ڼ�����δ����ƾ֤һ���Ե����ܷ����ʻ�����ϸ�����ʻ����Ա��ڲ�ѯ�ʱ����������\r\n\r\n";
            // 
            // frmRecordCf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(356, 226);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sbUnRecord);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.cbRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecordCf";
            this.Text = "ƾ֤����";
            this.Load += new System.EventHandler(this.frmRecordCf_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cbRecord;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbUnRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
