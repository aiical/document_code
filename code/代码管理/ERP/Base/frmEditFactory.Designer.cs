namespace Base
{
    partial class frmEditFactory
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
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.editControl3 = new myControl.EditControl();
            this.editControl4 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(266, 174);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(347, 174);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl4);
            this.gbox.Controls.Add(this.editControl3);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Size = new System.Drawing.Size(409, 155);
            // 
            // ckCopy
            // 
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.EditLabel = "�������:";
            this.editControl1.Location = new System.Drawing.Point(7, 21);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(158, 27);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.EditLabel = "��������:";
            this.editControl2.Location = new System.Drawing.Point(193, 20);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(204, 27);
            this.editControl2.TabIndex = 1;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_LinkMan";
            this.editControl3.EditLabel = "��ϵ��:";
            this.editControl3.Location = new System.Drawing.Point(18, 66);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(147, 27);
            this.editControl3.TabIndex = 3;
            // 
            // editControl4
            // 
            this.editControl4.BackColor = System.Drawing.Color.Transparent;
            this.editControl4.DataField = "F_Tel";
            this.editControl4.EditLabel = "��ϵ�绰:";
            this.editControl4.Location = new System.Drawing.Point(193, 66);
            this.editControl4.Name = "editControl4";
            this.editControl4.Request = false;
            this.editControl4.Size = new System.Drawing.Size(204, 27);
            this.editControl4.TabIndex = 4;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Adr";
            this.editControl9.EditLabel = "��ַ:";
            this.editControl9.Location = new System.Drawing.Point(30, 111);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(367, 27);
            this.editControl9.TabIndex = 9;
            // 
            // frmEditFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(434, 210);
            this.Name = "frmEditFactory";
            this.Text = "��������-�༭";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl1;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl4;
        private myControl.EditControl editControl3;
        private myControl.EditControl editControl9;

    }
}
