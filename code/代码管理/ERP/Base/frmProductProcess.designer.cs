namespace Base
{
    partial class frmProductProcess
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
            this.editControl5 = new myControl.EditControl();
            this.editControl6 = new myControl.EditControl();
            this.editControl7 = new myControl.EditControl();
            this.editControl8 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.sbSelItem = new DevExpress.XtraEditors.SimpleButton();
            this.lupControl1 = new myControl.lupControl();
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
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Controls.Add(this.sbSelItem);
            this.panelControl1.Controls.Add(this.editControl9);
            this.panelControl1.Controls.Add(this.editControl8);
            this.panelControl1.Controls.Add(this.editControl7);
            this.panelControl1.Controls.Add(this.editControl6);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(797, 160);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl6, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl7, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl8, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl9, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbSelItem, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            // 
            // editControl4
            // 
            this.editControl4.Location = new System.Drawing.Point(589, 6);
            // 
            // editControl3
            // 
            this.editControl3.Location = new System.Drawing.Point(266, 6);
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(544, 33);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(544, 6);
            this.editControl1.Size = new System.Drawing.Size(175, 21);
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(32, 130);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(565, 23);
            this.editControl5.TabIndex = 4;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_ItemID";
            this.editControl6.DataSource = null;
            this.editControl6.EditLabel = "物料编码:";
            this.editControl6.Location = new System.Drawing.Point(7, 72);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(173, 21);
            this.editControl6.TabIndex = 8;
            // 
            // editControl7
            // 
            this.editControl7.BackColor = System.Drawing.Color.Transparent;
            this.editControl7.DataField = "";
            this.editControl7.DataSource = null;
            this.editControl7.EditLabel = "物料名称:";
            this.editControl7.Enabled = false;
            this.editControl7.Location = new System.Drawing.Point(252, 72);
            this.editControl7.Name = "editControl7";
            this.editControl7.Request = false;
            this.editControl7.Size = new System.Drawing.Size(345, 21);
            this.editControl7.TabIndex = 9;
            // 
            // editControl8
            // 
            this.editControl8.BackColor = System.Drawing.Color.Transparent;
            this.editControl8.DataField = "";
            this.editControl8.DataSource = null;
            this.editControl8.EditLabel = "规格:";
            this.editControl8.Enabled = false;
            this.editControl8.Location = new System.Drawing.Point(32, 102);
            this.editControl8.Name = "editControl8";
            this.editControl8.Request = false;
            this.editControl8.Size = new System.Drawing.Size(207, 21);
            this.editControl8.TabIndex = 10;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "";
            this.editControl9.DataSource = null;
            this.editControl9.EditLabel = "单位:";
            this.editControl9.Enabled = false;
            this.editControl9.Location = new System.Drawing.Point(263, 102);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(84, 21);
            this.editControl9.TabIndex = 11;
            // 
            // sbSelItem
            // 
            this.sbSelItem.Appearance.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelItem.Appearance.Options.UseFont = true;
            this.sbSelItem.Location = new System.Drawing.Point(179, 72);
            this.sbSelItem.Name = "sbSelItem";
            this.sbSelItem.Size = new System.Drawing.Size(25, 21);
            this.sbSelItem.TabIndex = 13;
            this.sbSelItem.Text = "...";
            this.sbSelItem.Click += new System.EventHandler(this.sbSelItem_Click);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_Craftwork";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "工艺流程:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(382, 102);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = false;
            this.lupControl1.Size = new System.Drawing.Size(215, 22);
            this.lupControl1.TabIndex = 14;
            // 
            // frmProductProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(797, 533);
            this.Name = "frmProductProcess";
            this.Text = "产品工序规划";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmProductProcess_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl5;
        private myControl.EditControl editControl7;
        private myControl.EditControl editControl6;
        private myControl.EditControl editControl8;
        private myControl.EditControl editControl9;
        private DevExpress.XtraEditors.SimpleButton sbSelItem;
        private myControl.lupControl lupControl1;
    }
}
