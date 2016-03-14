namespace UFIDA.Retail.VIPCardControl
{
    partial class frmVIPChangeCardRecordList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVIPChangeCardRecordList));
            this.txtConsumerName = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerCode = new Lixtech.UserControls.UCTextBox();
            this.txtVIPNewCardClass = new Lixtech.UserControls.UCTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIsAudit = new System.Windows.Forms.CheckBox();
            this.txtVIPOldCardCode = new Lixtech.UserControls.UCTextBox();
            this.txtVIPNewCardCode = new Lixtech.UserControls.UCTextBox();
            this.txtVIPOldCardClass = new Lixtech.UserControls.UCTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerName.btnEnabled = true;
            this.txtConsumerName.btnVisible = false;
            this.txtConsumerName.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerName.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsumerName.lblText = "VIP客户名称";
            this.txtConsumerName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtConsumerName.Location = new System.Drawing.Point(12, 13);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(259, 18);
            this.txtConsumerName.TabIndex = 16;
            this.txtConsumerName.txtBackColor = System.Drawing.Color.White;
            this.txtConsumerName.txtEnabled = true;
            this.txtConsumerName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConsumerName.txtPasswrod = '\0';
            this.txtConsumerName.txtReadOnly = false;
            this.txtConsumerName.txtTag = null;
            this.txtConsumerName.txtText = "";
            this.txtConsumerName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtConsumerCode
            // 
            this.txtConsumerCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerCode.btnEnabled = true;
            this.txtConsumerCode.btnVisible = false;
            this.txtConsumerCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsumerCode.lblText = "VIP客户编码";
            this.txtConsumerCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtConsumerCode.Location = new System.Drawing.Point(682, 11);
            this.txtConsumerCode.Name = "txtConsumerCode";
            this.txtConsumerCode.Size = new System.Drawing.Size(259, 18);
            this.txtConsumerCode.TabIndex = 15;
            this.txtConsumerCode.txtBackColor = System.Drawing.Color.White;
            this.txtConsumerCode.txtEnabled = true;
            this.txtConsumerCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConsumerCode.txtPasswrod = '\0';
            this.txtConsumerCode.txtReadOnly = false;
            this.txtConsumerCode.txtTag = null;
            this.txtConsumerCode.txtText = "";
            this.txtConsumerCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtConsumerCode.Visible = false;
            // 
            // txtVIPNewCardClass
            // 
            this.txtVIPNewCardClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPNewCardClass.btnEnabled = true;
            this.txtVIPNewCardClass.btnVisible = true;
            this.txtVIPNewCardClass.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPNewCardClass.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPNewCardClass.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVIPNewCardClass.lblText = "新卡级别";
            this.txtVIPNewCardClass.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVIPNewCardClass.Location = new System.Drawing.Point(12, 37);
            this.txtVIPNewCardClass.Name = "txtVIPNewCardClass";
            this.txtVIPNewCardClass.Size = new System.Drawing.Size(259, 18);
            this.txtVIPNewCardClass.TabIndex = 2;
            this.txtVIPNewCardClass.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPNewCardClass.txtEnabled = true;
            this.txtVIPNewCardClass.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPNewCardClass.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVIPNewCardClass.txtPasswrod = '\0';
            this.txtVIPNewCardClass.txtReadOnly = false;
            this.txtVIPNewCardClass.txtTag = null;
            this.txtVIPNewCardClass.txtText = "";
            this.txtVIPNewCardClass.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVIPNewCardClass.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtVIPNewCardClass_Button_Click);
            this.txtVIPNewCardClass.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtVIPNewCardClass_TextBox_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpBegin);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chkIsAudit);
            this.panel2.Controls.Add(this.txtVIPOldCardCode);
            this.panel2.Controls.Add(this.txtConsumerName);
            this.panel2.Controls.Add(this.txtVIPNewCardCode);
            this.panel2.Controls.Add(this.txtVIPOldCardClass);
            this.panel2.Controls.Add(this.txtVIPNewCardClass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 70);
            this.panel2.TabIndex = 101;
            // 
            // chkIsAudit
            // 
            this.chkIsAudit.AutoSize = true;
            this.chkIsAudit.Location = new System.Drawing.Point(907, 15);
            this.chkIsAudit.Name = "chkIsAudit";
            this.chkIsAudit.Size = new System.Drawing.Size(72, 16);
            this.chkIsAudit.TabIndex = 18;
            this.chkIsAudit.Text = "是否审核";
            this.chkIsAudit.UseVisualStyleBackColor = true;
            // 
            // txtVIPOldCardCode
            // 
            this.txtVIPOldCardCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPOldCardCode.btnEnabled = true;
            this.txtVIPOldCardCode.btnVisible = false;
            this.txtVIPOldCardCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPOldCardCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPOldCardCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVIPOldCardCode.lblText = "VIP旧卡卡号";
            this.txtVIPOldCardCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVIPOldCardCode.Location = new System.Drawing.Point(613, 13);
            this.txtVIPOldCardCode.Name = "txtVIPOldCardCode";
            this.txtVIPOldCardCode.Size = new System.Drawing.Size(259, 18);
            this.txtVIPOldCardCode.TabIndex = 17;
            this.txtVIPOldCardCode.txtBackColor = System.Drawing.Color.White;
            this.txtVIPOldCardCode.txtEnabled = true;
            this.txtVIPOldCardCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPOldCardCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVIPOldCardCode.txtPasswrod = '\0';
            this.txtVIPOldCardCode.txtReadOnly = false;
            this.txtVIPOldCardCode.txtTag = null;
            this.txtVIPOldCardCode.txtText = "";
            this.txtVIPOldCardCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtVIPNewCardCode
            // 
            this.txtVIPNewCardCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPNewCardCode.btnEnabled = true;
            this.txtVIPNewCardCode.btnVisible = false;
            this.txtVIPNewCardCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPNewCardCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPNewCardCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVIPNewCardCode.lblText = "VIP新卡卡号";
            this.txtVIPNewCardCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVIPNewCardCode.Location = new System.Drawing.Point(311, 13);
            this.txtVIPNewCardCode.Name = "txtVIPNewCardCode";
            this.txtVIPNewCardCode.Size = new System.Drawing.Size(259, 18);
            this.txtVIPNewCardCode.TabIndex = 4;
            this.txtVIPNewCardCode.txtBackColor = System.Drawing.Color.White;
            this.txtVIPNewCardCode.txtEnabled = true;
            this.txtVIPNewCardCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPNewCardCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVIPNewCardCode.txtPasswrod = '\0';
            this.txtVIPNewCardCode.txtReadOnly = false;
            this.txtVIPNewCardCode.txtTag = null;
            this.txtVIPNewCardCode.txtText = "";
            this.txtVIPNewCardCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtVIPOldCardClass
            // 
            this.txtVIPOldCardClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPOldCardClass.btnEnabled = true;
            this.txtVIPOldCardClass.btnVisible = true;
            this.txtVIPOldCardClass.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPOldCardClass.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPOldCardClass.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVIPOldCardClass.lblText = "旧卡级别";
            this.txtVIPOldCardClass.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVIPOldCardClass.Location = new System.Drawing.Point(311, 37);
            this.txtVIPOldCardClass.Name = "txtVIPOldCardClass";
            this.txtVIPOldCardClass.Size = new System.Drawing.Size(259, 18);
            this.txtVIPOldCardClass.TabIndex = 3;
            this.txtVIPOldCardClass.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPOldCardClass.txtEnabled = true;
            this.txtVIPOldCardClass.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPOldCardClass.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVIPOldCardClass.txtPasswrod = '\0';
            this.txtVIPOldCardClass.txtReadOnly = false;
            this.txtVIPOldCardClass.txtTag = null;
            this.txtVIPOldCardClass.txtText = "";
            this.txtVIPOldCardClass.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVIPOldCardClass.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtVIPOldCardClass_Button_Click);
            this.txtVIPOldCardClass.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtVIPOldCardClass_TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1014, 35);
            this.label1.TabIndex = 100;
            this.label1.Text = "在线VIP客户换卡记录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 105);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 102;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(49, 22);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // dgv
            // 
            this.dgv.AllowEditing = false;
            this.dgv.BackColor = System.Drawing.SystemColors.Window;
            this.dgv.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.dgv.ColumnInfo = "1,1,0,0,0,75,Columns:0{Width:13;}\t";
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.Location = new System.Drawing.Point(0, 130);
            this.dgv.Name = "dgv";
            this.dgv.Rows.Count = 1;
            this.dgv.ShowCursor = true;
            this.dgv.Size = new System.Drawing.Size(1014, 349);
            this.dgv.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgv.Styles"));
            this.dgv.TabIndex = 103;
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(49, 22);
            this.tsbExport.Text = "输出";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(907, 37);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(104, 21);
            this.dtpEnd.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(824, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "换卡结束日期";
            // 
            // dtpBegin
            // 
            this.dtpBegin.Checked = false;
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(694, 37);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowCheckBox = true;
            this.dtpBegin.Size = new System.Drawing.Size(123, 21);
            this.dtpBegin.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "换卡开始日期";
            // 
            // frmVIPChangeCardRecordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 479);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtConsumerCode);
            this.Controls.Add(this.label1);
            this.Name = "frmVIPChangeCardRecordList";
            this.ShowIcon = false;
            this.Text = "VIP客户换卡记录";
            this.Load += new System.EventHandler(this.frmVIPChangeCardRecordList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lixtech.UserControls.UCTextBox txtConsumerName;
        private Lixtech.UserControls.UCTextBox txtConsumerCode;
        private Lixtech.UserControls.UCTextBox txtVIPNewCardClass;
        private System.Windows.Forms.Panel panel2;
        private Lixtech.UserControls.UCTextBox txtVIPNewCardCode;
        private Lixtech.UserControls.UCTextBox txtVIPOldCardClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private C1.Win.C1FlexGrid.C1FlexGrid dgv;
        private Lixtech.UserControls.UCTextBox txtVIPOldCardCode;
        private System.Windows.Forms.CheckBox chkIsAudit;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label2;
    }
}