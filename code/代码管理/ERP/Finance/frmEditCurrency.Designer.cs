namespace Finance
{
    partial class frmEditCurrency
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
            this.editControl1 = new myControl.EditControl();
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.editControl2 = new myControl.EditControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(136, 114);
            this.BtnOK.Size = new System.Drawing.Size(66, 23);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(208, 114);
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Size = new System.Drawing.Size(258, 95);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_Name";
            this.editControl1.EditLabel = "币种名称:";
            this.editControl1.Location = new System.Drawing.Point(31, 21);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(204, 27);
            this.editControl1.TabIndex = 0;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(20, 118);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "保存后新增";
            this.ckOption.Size = new System.Drawing.Size(101, 19);
            this.ckOption.TabIndex = 5;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Rate";
            this.editControl2.EditLabel = "对人民币汇率:";
            this.editControl2.Location = new System.Drawing.Point(7, 54);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(228, 21);
            this.editControl2.TabIndex = 1;
            // 
            // frmEditCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(285, 148);
            this.Controls.Add(this.ckOption);
            this.Name = "frmEditCurrency";
            this.Text = "币种资料--编辑";
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.Controls.SetChildIndex(this.ckOption, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl1;
        private DevExpress.XtraEditors.CheckEdit ckOption;
        private myControl.EditControl editControl2;

    }
}
