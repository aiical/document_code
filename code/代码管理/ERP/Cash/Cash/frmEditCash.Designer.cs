namespace Cash
{
    partial class frmEditCash
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
            this.components = new System.ComponentModel.Container();
            this.binEdit = new System.Windows.Forms.BindingSource(this.components);
            this.dateControl1 = new myControl.DateControl();
            this.spinControl1 = new myControl.SpinControl();
            this.spinControl3 = new myControl.SpinControl();
            this.spinControl4 = new myControl.SpinControl();
            this.spinControl5 = new myControl.SpinControl();
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelMemo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.binEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Date";
            this.dateControl1.EditLabel = "��    ��:";
            this.dateControl1.Location = new System.Drawing.Point(11, 26);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(155, 21);
            this.dateControl1.TabIndex = 1;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_DayOrder";
            this.spinControl1.EditLabel = "�������:";
            this.spinControl1.Location = new System.Drawing.Point(267, 26);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(155, 21);
            this.spinControl1.TabIndex = 2;
            // 
            // spinControl3
            // 
            this.spinControl3.BackColor = System.Drawing.Color.Transparent;
            this.spinControl3.DataField = "F_Debit";
            this.spinControl3.EditLabel = "�跽���:";
            this.spinControl3.Location = new System.Drawing.Point(12, 66);
            this.spinControl3.Name = "spinControl3";
            this.spinControl3.Size = new System.Drawing.Size(155, 21);
            this.spinControl3.TabIndex = 4;
            // 
            // spinControl4
            // 
            this.spinControl4.BackColor = System.Drawing.Color.Transparent;
            this.spinControl4.DataField = "F_Credit";
            this.spinControl4.EditLabel = "�������:";
            this.spinControl4.Location = new System.Drawing.Point(267, 66);
            this.spinControl4.Name = "spinControl4";
            this.spinControl4.Size = new System.Drawing.Size(156, 21);
            this.spinControl4.TabIndex = 5;
            // 
            // spinControl5
            // 
            this.spinControl5.BackColor = System.Drawing.Color.Transparent;
            this.spinControl5.DataField = null;
            this.spinControl5.EditLabel = "��    ��:";
            this.spinControl5.Location = new System.Drawing.Point(12, 103);
            this.spinControl5.Name = "spinControl5";
            this.spinControl5.Size = new System.Drawing.Size(174, 21);
            this.spinControl5.TabIndex = 6;
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_Opertor";
            this.editControl1.EditLabel = "�� �� ��:";
            this.editControl1.Location = new System.Drawing.Point(11, 142);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(180, 21);
            this.editControl1.TabIndex = 7;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Remark";
            this.editControl2.EditLabel = "ժ    Ҫ:";
            this.editControl2.Location = new System.Drawing.Point(12, 183);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(394, 21);
            this.editControl2.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(282, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "����";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(363, 240);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "�ر�";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelMemo
            // 
            this.btnSelMemo.Location = new System.Drawing.Point(408, 183);
            this.btnSelMemo.Name = "btnSelMemo";
            this.btnSelMemo.Size = new System.Drawing.Size(30, 23);
            this.btnSelMemo.TabIndex = 11;
            this.btnSelMemo.Text = "...";
            this.btnSelMemo.UseVisualStyleBackColor = true;
            this.btnSelMemo.Click += new System.EventHandler(this.btnSelMemo_Click);
            // 
            // frmEditCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(450, 285);
            this.Controls.Add(this.btnSelMemo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.editControl2);
            this.Controls.Add(this.editControl1);
            this.Controls.Add(this.spinControl5);
            this.Controls.Add(this.spinControl4);
            this.Controls.Add(this.spinControl3);
            this.Controls.Add(this.spinControl1);
            this.Controls.Add(this.dateControl1);
            this.Name = "frmEditCash";
            this.Text = "�ֽ��ռ���";
            this.Load += new System.EventHandler(this.frmEditCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.binEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.DateControl dateControl1;
        private myControl.SpinControl spinControl1;
        private myControl.SpinControl spinControl3;
        private myControl.SpinControl spinControl4;
        private myControl.SpinControl spinControl5;
        private myControl.EditControl editControl1;
        private myControl.EditControl editControl2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelMemo;
        private System.Windows.Forms.BindingSource binEdit;

    }
}
