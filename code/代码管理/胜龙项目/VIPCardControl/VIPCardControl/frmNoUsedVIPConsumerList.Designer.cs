namespace UFIDA.Retail.VIPCardControl
{
    partial class frmNoUsedVIPConsumerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoUsedVIPConsumerList));
            this.dgv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsumerName = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerCode = new Lixtech.UserControls.UCTextBox();
            this.txtVIPCardClass = new Lixtech.UserControls.UCTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVIPCardCode = new Lixtech.UserControls.UCTextBox();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.dgv.TabIndex = 107;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 105);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 106;
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1014, 35);
            this.label1.TabIndex = 104;
            this.label1.Text = "已失效VIP客户列表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtConsumerName.Location = new System.Drawing.Point(12, 12);
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
            this.txtConsumerCode.Location = new System.Drawing.Point(575, 39);
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
            // txtVIPCardClass
            // 
            this.txtVIPCardClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPCardClass.btnEnabled = true;
            this.txtVIPCardClass.btnVisible = true;
            this.txtVIPCardClass.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPCardClass.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPCardClass.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVIPCardClass.lblText = "VIP卡级别";
            this.txtVIPCardClass.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVIPCardClass.Location = new System.Drawing.Point(574, 12);
            this.txtVIPCardClass.Name = "txtVIPCardClass";
            this.txtVIPCardClass.Size = new System.Drawing.Size(259, 18);
            this.txtVIPCardClass.TabIndex = 2;
            this.txtVIPCardClass.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPCardClass.txtEnabled = true;
            this.txtVIPCardClass.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPCardClass.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVIPCardClass.txtPasswrod = '\0';
            this.txtVIPCardClass.txtReadOnly = false;
            this.txtVIPCardClass.txtTag = null;
            this.txtVIPCardClass.txtText = "";
            this.txtVIPCardClass.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVIPCardClass.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtVIPCardClass_Button_Click);
            this.txtVIPCardClass.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtVIPCardClass_TextBox_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpBegin);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtConsumerName);
            this.panel2.Controls.Add(this.txtConsumerCode);
            this.panel2.Controls.Add(this.txtVIPCardCode);
            this.panel2.Controls.Add(this.txtVIPCardClass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 70);
            this.panel2.TabIndex = 105;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(382, 36);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(187, 21);
            this.dtpEnd.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "失效日期结束";
            // 
            // dtpBegin
            // 
            this.dtpBegin.Checked = false;
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(97, 36);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowCheckBox = true;
            this.dtpBegin.Size = new System.Drawing.Size(187, 21);
            this.dtpBegin.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "失效日期开始";
            // 
            // txtVIPCardCode
            // 
            this.txtVIPCardCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPCardCode.btnEnabled = true;
            this.txtVIPCardCode.btnVisible = false;
            this.txtVIPCardCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPCardCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPCardCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVIPCardCode.lblText = "VIP卡号";
            this.txtVIPCardCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVIPCardCode.Location = new System.Drawing.Point(308, 12);
            this.txtVIPCardCode.Name = "txtVIPCardCode";
            this.txtVIPCardCode.Size = new System.Drawing.Size(245, 18);
            this.txtVIPCardCode.TabIndex = 4;
            this.txtVIPCardCode.txtBackColor = System.Drawing.Color.White;
            this.txtVIPCardCode.txtEnabled = true;
            this.txtVIPCardCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPCardCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVIPCardCode.txtPasswrod = '\0';
            this.txtVIPCardCode.txtReadOnly = false;
            this.txtVIPCardCode.txtTag = null;
            this.txtVIPCardCode.txtText = "";
            this.txtVIPCardCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            // frmNoUsedVIPConsumerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 479);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "frmNoUsedVIPConsumerList";
            this.ShowIcon = false;
            this.Text = "已失效VIP客户列表";
            this.Load += new System.EventHandler(this.frmNoUsedVIPConsumerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid dgv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.Label label1;
        private Lixtech.UserControls.UCTextBox txtConsumerName;
        private Lixtech.UserControls.UCTextBox txtConsumerCode;
        private Lixtech.UserControls.UCTextBox txtVIPCardClass;
        private System.Windows.Forms.Panel panel2;
        private Lixtech.UserControls.UCTextBox txtVIPCardCode;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton tsbExport;
    }
}