namespace Product
{
    partial class frmBomEdit
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
            this.editControl5 = new myControl.EditControl();
            this.editControl6 = new myControl.EditControl();
            this.editControl7 = new myControl.EditControl();
            this.editControl8 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.sbSelItem = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(94, 21);
            this.lbTitle.Text = "frmBase";
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(556, 25);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(556, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.sbSelItem);
            this.panelControl1.Controls.Add(this.editControl9);
            this.panelControl1.Controls.Add(this.editControl8);
            this.panelControl1.Controls.Add(this.editControl7);
            this.panelControl1.Controls.Add(this.editControl6);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(797, 137);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl6, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl7, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl8, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl9, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbSelItem, 0);
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.EditLabel = "��ע:";
            this.editControl5.Location = new System.Drawing.Point(37, 106);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(639, 27);
            this.editControl5.TabIndex = 4;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_ItemID";
            this.editControl6.EditLabel = "��������:";
            this.editControl6.Location = new System.Drawing.Point(12, 52);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = true;
            this.editControl6.Size = new System.Drawing.Size(179, 21);
            this.editControl6.TabIndex = 6;
            // 
            // editControl7
            // 
            this.editControl7.BackColor = System.Drawing.Color.Transparent;
            this.editControl7.DataField = "";
            this.editControl7.EditLabel = "��������:";
            this.editControl7.Enabled = false;
            this.editControl7.Location = new System.Drawing.Point(232, 52);
            this.editControl7.Name = "editControl7";
            this.editControl7.Request = false;
            this.editControl7.Size = new System.Drawing.Size(224, 21);
            this.editControl7.TabIndex = 7;
            // 
            // editControl8
            // 
            this.editControl8.BackColor = System.Drawing.Color.Transparent;
            this.editControl8.DataField = "";
            this.editControl8.EditLabel = "�������:";
            this.editControl8.Enabled = false;
            this.editControl8.Location = new System.Drawing.Point(486, 52);
            this.editControl8.Name = "editControl8";
            this.editControl8.Request = false;
            this.editControl8.Size = new System.Drawing.Size(190, 21);
            this.editControl8.TabIndex = 8;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "";
            this.editControl9.EditLabel = "��λ:";
            this.editControl9.Enabled = false;
            this.editControl9.Location = new System.Drawing.Point(37, 79);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(105, 21);
            this.editControl9.TabIndex = 9;
            // 
            // sbSelItem
            // 
            this.sbSelItem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelItem.Appearance.Options.UseFont = true;
            this.sbSelItem.Location = new System.Drawing.Point(191, 52);
            this.sbSelItem.Name = "sbSelItem";
            this.sbSelItem.Size = new System.Drawing.Size(19, 23);
            this.sbSelItem.TabIndex = 10;
            this.sbSelItem.Text = "...";
            this.sbSelItem.Click += new System.EventHandler(this.sbSelItem_Click);
            // 
            // frmBomEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(797, 509);
            this.Name = "frmBomEdit";
            this.Text = "�����嵥";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmBomEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbSelItem;
        public myControl.EditControl editControl5;
        public myControl.EditControl editControl8;
        public myControl.EditControl editControl7;
        public myControl.EditControl editControl6;
        public myControl.EditControl editControl9;
    }
}
