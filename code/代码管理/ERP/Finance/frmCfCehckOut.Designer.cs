namespace Finance
{
    partial class frmCfCehckOut
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbUnOk = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "��ǰ������:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "��ǰ����·�:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "���ʺ����������µļ���ƾ֤������ڽ���\r\nǰ��Ӧ���ȼ�鱾�ڷ����ľ���ҵ���Ƿ��Ѿ���\r\n�Ƽ���ƾ֤�����Ǽ����ʣ��Ը��ֳɱ��������ʻ�\r\n��ҲӦ���ڽ���ǰ���б�" +
                "Ҫ�Ľ�ת�����Ǽ����ʡ�";
            // 
            // sbOK
            // 
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(23, 140);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(75, 23);
            this.sbOK.TabIndex = 3;
            this.sbOK.Text = "����";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(239, 140);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 4;
            this.sbCancel.Text = "ȡ��";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbUnOk
            // 
            this.sbUnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbUnOk.Appearance.Options.UseFont = true;
            this.sbUnOk.Location = new System.Drawing.Point(129, 140);
            this.sbUnOk.Name = "sbUnOk";
            this.sbUnOk.Size = new System.Drawing.Size(75, 23);
            this.sbUnOk.TabIndex = 5;
            this.sbUnOk.Text = "������";
            this.sbUnOk.Click += new System.EventHandler(this.sbUnOk_Click);
            // 
            // frmCfCehckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(330, 179);
            this.Controls.Add(this.sbUnOk);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCfCehckOut";
            this.Text = "��ĩ����";
            this.Load += new System.EventHandler(this.frmCfCehckOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbUnOk;
    }
}
