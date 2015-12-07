namespace Finance
{
    partial class frmEditAssetReduce
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem4 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem5 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl2 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.dateControl1 = new myControl.DateControl();
            this.spinControl1 = new myControl.SpinControl();
            this.cbControl1 = new myControl.cbControl();
            this.spinControl2 = new myControl.SpinControl();
            this.lupControl1 = new myControl.lupControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(348, 209);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(431, 209);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Controls.Add(this.spinControl2);
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Controls.Add(this.spinControl1);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Size = new System.Drawing.Size(493, 181);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(20, 213);
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "";
            this.editControl2.EditLabel = "固定资产名称:";
            this.editControl2.Location = new System.Drawing.Point(241, 20);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(240, 27);
            this.editControl2.TabIndex = 1;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Remark";
            this.editControl9.EditLabel = "清理原因:";
            this.editControl9.Location = new System.Drawing.Point(30, 133);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(439, 27);
            this.editControl9.TabIndex = 9;
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Date";
            this.dateControl1.EditLabel = "减小日期";
            this.dateControl1.Location = new System.Drawing.Point(35, 54);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(167, 21);
            this.dateControl1.TabIndex = 10;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_InCome";
            this.spinControl1.EditLabel = "清理收入:";
            this.spinControl1.Location = new System.Drawing.Point(265, 53);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(155, 21);
            this.spinControl1.TabIndex = 11;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "出售";
            comboBoxItem2.Value = "报废";
            comboBoxItem3.Value = "投资转出";
            comboBoxItem4.Value = "损赠";
            comboBoxItem5.Value = "盘亏";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3,
        comboBoxItem4,
        comboBoxItem5};
            this.cbControl1.DataField = "F_Way";
            this.cbControl1.EditLabel = "减小方式:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(30, 93);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.Size = new System.Drawing.Size(172, 21);
            this.cbControl1.TabIndex = 12;
            // 
            // spinControl2
            // 
            this.spinControl2.BackColor = System.Drawing.Color.Transparent;
            this.spinControl2.DataField = "F_Fee";
            this.spinControl2.EditLabel = "清理费用:";
            this.spinControl2.Location = new System.Drawing.Point(265, 93);
            this.spinControl2.Name = "spinControl2";
            this.spinControl2.Size = new System.Drawing.Size(155, 21);
            this.spinControl2.TabIndex = 13;
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_ID";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "固定资产编号:";
            this.lupControl1.Location = new System.Drawing.Point(7, 20);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(195, 22);
            this.lupControl1.TabIndex = 14;
            this.lupControl1.ValueChanged += new myControl.SelectChangeEventHandler(this.lupControl1_ValueChanged);
            // 
            // frmEditAssetReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(518, 251);
            this.Name = "frmEditAssetReduce";
            this.Text = "固定资产-编辑";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl2;
        private myControl.SpinControl spinControl1;
        private myControl.DateControl dateControl1;
        private myControl.EditControl editControl9;
        private myControl.cbControl cbControl1;
        private myControl.SpinControl spinControl2;
        private myControl.lupControl lupControl1;

    }
}
