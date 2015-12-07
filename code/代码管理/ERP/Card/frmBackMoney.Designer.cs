namespace Card
{
    partial class frmBackMoney
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lupDevice = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.F_CardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_BackMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RealGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDevice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPick.Location = new System.Drawing.Point(467, 7);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 0;
            this.btnPick.Text = "退款";
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
            this.F_ID,
            this.F_EmpName,
            this.F_Dept,
            this.F_BackMoney,
            this.F_Date});
            this.RealGrid.Location = new System.Drawing.Point(12, 41);
            this.RealGrid.Name = "RealGrid";
            this.RealGrid.ReadOnly = true;
            this.RealGrid.RowHeadersVisible = false;
            this.RealGrid.RowTemplate.Height = 23;
            this.RealGrid.Size = new System.Drawing.Size(692, 447);
            this.RealGrid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "员工退款资料列表:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(629, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lupDevice
            // 
            this.lupDevice.Location = new System.Drawing.Point(225, 7);
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
            this.lupDevice.Size = new System.Drawing.Size(146, 21);
            this.lupDevice.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "设备:";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(548, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "删除(&D)";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // F_CardNo
            // 
            this.F_CardNo.DataPropertyName = "F_CardNo";
            this.F_CardNo.HeaderText = "卡号";
            this.F_CardNo.Name = "F_CardNo";
            this.F_CardNo.ReadOnly = true;
            // 
            // F_ID
            // 
            this.F_ID.DataPropertyName = "F_ID";
            this.F_ID.HeaderText = "工号";
            this.F_ID.Name = "F_ID";
            this.F_ID.ReadOnly = true;
            this.F_ID.Width = 70;
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
            // F_BackMoney
            // 
            this.F_BackMoney.DataPropertyName = "F_BackMoney";
            this.F_BackMoney.HeaderText = "退款金额";
            this.F_BackMoney.Name = "F_BackMoney";
            this.F_BackMoney.ReadOnly = true;
            // 
            // F_Date
            // 
            this.F_Date.DataPropertyName = "F_Date";
            this.F_Date.HeaderText = "退款时间";
            this.F_Date.Name = "F_Date";
            this.F_Date.ReadOnly = true;
            // 
            // frmBackMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(716, 500);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lupDevice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RealGrid);
            this.Controls.Add(this.btnPick);
            this.Name = "frmBackMoney";
            this.Text = "退款列表";
            this.Load += new System.EventHandler(this.frmBackCard_Load);
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
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_BackMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_Date;
    }
}
