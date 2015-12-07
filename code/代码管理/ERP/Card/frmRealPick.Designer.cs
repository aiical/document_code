namespace Card
{
    partial class frmRealPick
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
            this.btnPick = new System.Windows.Forms.Button();
            this.RealGrid = new System.Windows.Forms.DataGridView();
            this.F_CardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_EmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_CardTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lupDevice = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RealGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDevice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPick.Location = new System.Drawing.Point(359, 7);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 0;
            this.btnPick.Text = "开始采集";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.Pick);
            // 
            // RealGrid
            // 
            this.RealGrid.AllowUserToAddRows = false;
            this.RealGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RealGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RealGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_CardNo,
            this.F_EmpID,
            this.F_EmpName,
            this.F_Dept,
            this.F_CardTime});
            this.RealGrid.Location = new System.Drawing.Point(12, 41);
            this.RealGrid.Name = "RealGrid";
            this.RealGrid.ReadOnly = true;
            this.RealGrid.RowHeadersVisible = false;
            this.RealGrid.RowTemplate.Height = 23;
            this.RealGrid.Size = new System.Drawing.Size(604, 396);
            this.RealGrid.TabIndex = 1;
            // 
            // F_CardNo
            // 
            this.F_CardNo.DataPropertyName = "F_CardNo";
            this.F_CardNo.HeaderText = "卡号";
            this.F_CardNo.Name = "F_CardNo";
            this.F_CardNo.ReadOnly = true;
            // 
            // F_EmpID
            // 
            this.F_EmpID.DataPropertyName = "F_EmpID";
            this.F_EmpID.HeaderText = "工号";
            this.F_EmpID.Name = "F_EmpID";
            this.F_EmpID.ReadOnly = true;
            // 
            // F_EmpName
            // 
            this.F_EmpName.DataPropertyName = "F_EmpName";
            this.F_EmpName.HeaderText = "姓名";
            this.F_EmpName.Name = "F_EmpName";
            this.F_EmpName.ReadOnly = true;
            // 
            // F_Dept
            // 
            this.F_Dept.DataPropertyName = "F_Dept";
            this.F_Dept.HeaderText = "部门";
            this.F_Dept.Name = "F_Dept";
            this.F_Dept.ReadOnly = true;
            // 
            // F_CardTime
            // 
            this.F_CardTime.DataPropertyName = "F_Time";
            this.F_CardTime.HeaderText = "刷卡时间";
            this.F_CardTime.Name = "F_CardTime";
            this.F_CardTime.ReadOnly = true;
            this.F_CardTime.Width = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "刷卡数据实时采集:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(541, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lupDevice
            // 
            this.lupDevice.Location = new System.Drawing.Point(193, 7);
            this.lupDevice.Name = "lupDevice";
            this.lupDevice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupDevice.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("F_ID", "机器号", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("F_Name", "机器名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lupDevice.Properties.DisplayMember = "F_Name";
            this.lupDevice.Properties.NullText = "";
            this.lupDevice.Properties.ShowFooter = false;
            this.lupDevice.Properties.ShowHeader = false;
            this.lupDevice.Properties.ValueMember = "F_ID";
            this.lupDevice.Size = new System.Drawing.Size(119, 21);
            this.lupDevice.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "设备:";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(441, 7);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(94, 23);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "转至考勤分析";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // frmRealPick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(628, 449);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lupDevice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RealGrid);
            this.Controls.Add(this.btnPick);
            this.Name = "frmRealPick";
            this.Text = "实时采集";
            ((System.ComponentModel.ISupportInitialize)(this.RealGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDevice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.DataGridView RealGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraEditors.LookUpEdit lupDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_EmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CardTime;
        private System.Windows.Forms.Button btnChange;
    }
}
