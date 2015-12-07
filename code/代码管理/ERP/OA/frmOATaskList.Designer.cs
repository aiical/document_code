namespace OA
{
    partial class frmOATaskList
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
            this.cbFlag = new myControl.cbControl();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbFlag);
            this.panel1.Size = new System.Drawing.Size(790, 43);
            this.panel1.Controls.SetChildIndex(this.cbFlag, 0);
            this.panel1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panel1.Controls.SetChildIndex(this.ucDate, 0);
            // 
            // cbFlag
            // 
            this.cbFlag.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "未完成";
            comboBoxItem2.Value = "已完成";
            comboBoxItem3.Value = "全部";
            this.cbFlag.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3};
            this.cbFlag.DataField = null;
            this.cbFlag.DataSource = null;
            this.cbFlag.EditLabel = "进度:";
            this.cbFlag.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbFlag.Location = new System.Drawing.Point(650, 11);
            this.cbFlag.Name = "cbFlag";
            this.cbFlag.Request = false;
            this.cbFlag.SelectedIndex = 0;
            this.cbFlag.Size = new System.Drawing.Size(128, 21);
            this.cbFlag.TabIndex = 2;
            this.cbFlag.SelectIndexChange += new myControl.SelectIndexChangeEventHandler(this.cbFlag_SelectIndexChange);
            // 
            // frmOATaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(790, 506);
            this.Name = "frmOATaskList";
            this.Text = "任务管理";
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private myControl.cbControl cbFlag;
    }
}
