namespace Product
{
    partial class frmRepairDrawGoods
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl5 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
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
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.lupControl3);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(803, 126);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl3, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            // 
            // editControl4
            // 
            this.editControl4.Location = new System.Drawing.Point(621, 6);
            // 
            // editControl3
            // 
            this.editControl3.Location = new System.Drawing.Point(282, 6);
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(559, 32);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(561, 7);
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "��ע:";
            this.editControl5.Location = new System.Drawing.Point(37, 91);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(560, 27);
            this.editControl5.TabIndex = 4;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_DeptID";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.DropSQL = "";
            this.lupControl2.EditLabel = "����:";
            this.lupControl2.InvokeClass = "";
            this.lupControl2.LinkFields = null;
            this.lupControl2.Location = new System.Drawing.Point(37, 63);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = true;
            this.lupControl2.Size = new System.Drawing.Size(165, 22);
            this.lupControl2.TabIndex = 7;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_DrawMan";
            this.lupControl3.DataSource = null;
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.DropSQL = "";
            this.lupControl3.EditLabel = "������:";
            this.lupControl3.InvokeClass = "";
            this.lupControl3.LinkFields = null;
            this.lupControl3.Location = new System.Drawing.Point(226, 63);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.PopWidth = 150;
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(165, 22);
            this.lupControl3.TabIndex = 8;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "��������";
            comboBoxItem2.Value = "��ӹ�����";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2};
            this.cbControl1.DataField = "F_Kind";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "�������:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(417, 59);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(180, 26);
            this.cbControl1.TabIndex = 9;
            // 
            // frmRepairDrawGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(803, 521);
            this.Name = "frmRepairDrawGoods";
            this.Text = "ά�����ϵ�";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmDrawGoods_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public myControl.EditControl editControl5;
        public myControl.lupControl lupControl3;
        public myControl.lupControl lupControl2;
        public myControl.cbControl cbControl1;

    }
}
