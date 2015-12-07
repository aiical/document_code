namespace Base
{
    partial class frmStockPrice
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
            this.cbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tvType
            // 
            this.tvType.LineColor = System.Drawing.Color.Black;
            this.tvType.Size = new System.Drawing.Size(181, 329);
            this.tvType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvType_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Size = new System.Drawing.Size(644, 329);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkEdit1);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Size = new System.Drawing.Size(644, 40);
            this.panel1.Controls.SetChildIndex(this.cbType, 0);
            this.panel1.Controls.SetChildIndex(this.checkEdit1, 0);
            // 
            // cbType
            // 
            this.cbType.EditValue = "供应商对应原材料";
            this.cbType.Location = new System.Drawing.Point(229, 6);
            this.cbType.Name = "cbType";
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbType.Properties.Items.AddRange(new object[] {
            "供应商对应原材料",
            "原材料对应供应商"});
            this.cbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbType.Size = new System.Drawing.Size(134, 21);
            this.cbType.TabIndex = 15;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(414, 8);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "展开所有";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 16;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // frmStockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(644, 417);
            this.Name = "frmStockPrice";
            this.Text = "采购报价";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.Shown += new System.EventHandler(this.frmStockPrice_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbType;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}
