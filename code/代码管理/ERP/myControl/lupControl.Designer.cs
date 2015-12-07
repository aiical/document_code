namespace myControl
{
    partial class lupControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lupEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lbLabel = new System.Windows.Forms.Label();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lupEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lupEdit
            // 
            this.lupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lupEdit.EnterMoveNextControl = true;
            this.lupEdit.Location = new System.Drawing.Point(51, 0);
            this.lupEdit.Name = "lupEdit";
            this.lupEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lupEdit.Properties.AutoSearchColumnIndex = 1;
            this.lupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupEdit.Properties.DropDownRows = 10;
            this.lupEdit.Properties.ImmediatePopup = true;
            this.lupEdit.Properties.NullText = "";
            this.lupEdit.Properties.ShowFooter = false;
            this.lupEdit.Properties.ShowHeader = false;
            this.lupEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lupEdit.Size = new System.Drawing.Size(105, 21);
            this.lupEdit.TabIndex = 0;
            this.lupEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lupEdit_KeyDown);
            // 
            // lbLabel
            // 
            this.lbLabel.AutoSize = true;
            this.lbLabel.Location = new System.Drawing.Point(4, 5);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(41, 12);
            this.lbLabel.TabIndex = 1;
            this.lbLabel.Text = "label1";
            // 
            // sbSelect
            // 
            this.sbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbSelect.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelect.Appearance.Options.UseFont = true;
            this.sbSelect.Location = new System.Drawing.Point(157, 0);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(20, 22);
            this.sbSelect.TabIndex = 2;
            this.sbSelect.TabStop = false;
            this.sbSelect.Text = "...";
            this.sbSelect.Click += new System.EventHandler(this.sbSelect_Click);
            // 
            // lupControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.sbSelect);
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.lupEdit);
            this.Name = "lupControl";
            this.Size = new System.Drawing.Size(177, 22);
            ((System.ComponentModel.ISupportInitialize)(this.lupEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLabel;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        public DevExpress.XtraEditors.LookUpEdit lupEdit;
    }
}
