namespace Base
{
    partial class frmEditAssist
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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(54, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 21);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "����:";
            // 
            // sbOK
            // 
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(107, 95);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(62, 23);
            this.sbOK.TabIndex = 2;
            this.sbOK.Text = "ȷ��(&O)";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Location = new System.Drawing.Point(176, 95);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(62, 23);
            this.sbClose.TabIndex = 3;
            this.sbClose.Text = "ȡ��(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "����:";
            // 
            // txtID
            // 
            this.txtID.EnterMoveNextControl = true;
            this.txtID.Location = new System.Drawing.Point(54, 20);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(184, 21);
            this.txtID.TabIndex = 0;
            // 
            // frmEditAssist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(262, 130);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditAssist";
            this.Text = "��������--�༭";
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        public DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.TextEdit txtID;
    }
}
