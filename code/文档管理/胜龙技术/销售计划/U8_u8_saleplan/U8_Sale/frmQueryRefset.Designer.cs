namespace U8_Sale
{
    partial class frmQueryRefset
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lueDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.luecRef = new DevExpress.XtraEditors.LookUpEdit();
            this.txtiYear = new DevExpress.XtraEditors.TextEdit();
            this.cboiMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnsure = new DevExpress.XtraEditors.SimpleButton();
            this.btncancel = new DevExpress.XtraEditors.SimpleButton();
            this.cboEndiMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtiYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndiMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "部门：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "参考值：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 134);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "年份：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 187);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "月份：";
            // 
            // lueDepartment
            // 
            this.lueDepartment.Location = new System.Drawing.Point(67, 22);
            this.lueDepartment.Name = "lueDepartment";
            this.lueDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lueDepartment.Properties.DisplayMember = "cDepName";
            this.lueDepartment.Properties.ValueMember = "cDepCode";
            this.lueDepartment.Size = new System.Drawing.Size(202, 21);
            this.lueDepartment.TabIndex = 4;
            // 
            // luecRef
            // 
            this.luecRef.Location = new System.Drawing.Point(67, 77);
            this.luecRef.Name = "luecRef";
            this.luecRef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecRef.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRefType", "参考值", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecRef.Properties.DisplayMember = "cRefType";
            this.luecRef.Properties.ValueMember = "cRefType";
            this.luecRef.Size = new System.Drawing.Size(202, 21);
            this.luecRef.TabIndex = 5;
            // 
            // txtiYear
            // 
            this.txtiYear.Location = new System.Drawing.Point(67, 134);
            this.txtiYear.Name = "txtiYear";
            this.txtiYear.Size = new System.Drawing.Size(202, 21);
            this.txtiYear.TabIndex = 6;
            // 
            // cboiMonth
            // 
            this.cboiMonth.Location = new System.Drawing.Point(67, 180);
            this.cboiMonth.Name = "cboiMonth";
            this.cboiMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboiMonth.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboiMonth.Size = new System.Drawing.Size(72, 21);
            this.cboiMonth.TabIndex = 7;
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(45, 256);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(94, 23);
            this.btnsure.TabIndex = 8;
            this.btnsure.Text = "确定";
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(203, 256);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(94, 23);
            this.btncancel.TabIndex = 9;
            this.btncancel.Text = "退出";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // cboEndiMonth
            // 
            this.cboEndiMonth.Location = new System.Drawing.Point(203, 180);
            this.cboEndiMonth.Name = "cboEndiMonth";
            this.cboEndiMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEndiMonth.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboEndiMonth.Size = new System.Drawing.Size(66, 21);
            this.cboEndiMonth.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "到";
            // 
            // frmQueryRefset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEndiMonth);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.cboiMonth);
            this.Controls.Add(this.txtiYear);
            this.Controls.Add(this.luecRef);
            this.Controls.Add(this.lueDepartment);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmQueryRefset";
            this.Text = "系统参数设置查询";
            this.Load += new System.EventHandler(this.frmQueryRefset_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecRef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtiYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndiMonth.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lueDepartment;
        private DevExpress.XtraEditors.LookUpEdit luecRef;
        private DevExpress.XtraEditors.TextEdit txtiYear;
        private DevExpress.XtraEditors.ComboBoxEdit cboiMonth;
        private DevExpress.XtraEditors.SimpleButton btnsure;
        private DevExpress.XtraEditors.SimpleButton btncancel;
        private DevExpress.XtraEditors.ComboBoxEdit cboEndiMonth;
        private System.Windows.Forms.Label label1;
    }
}