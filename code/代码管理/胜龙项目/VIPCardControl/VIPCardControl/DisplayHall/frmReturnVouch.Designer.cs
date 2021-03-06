﻿namespace UFIDA.Retail.VIPCardControl
{
    partial class frmReturnVouch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnVouch));
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbScan = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtMaker = new Lixtech.UserControls.UCTextBox();
            this.dtpVouchDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewVoucher = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.tsbRef = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDraft = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbCopyRow = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEmpty = new System.Windows.Forms.ToolStripButton();
            this.txtVouchCode = new Lixtech.UserControls.UCTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSourceVouchCode = new Lixtech.UserControls.UCTextBox();
            this.txtMemo = new Lixtech.UserControls.UCTextBox();
            this.dgv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(49, 22);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbScan
            // 
            this.tsbScan.Image = ((System.Drawing.Image)(resources.GetObject("tsbScan.Image")));
            this.tsbScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScan.Name = "tsbScan";
            this.tsbScan.Size = new System.Drawing.Size(103, 22);
            this.tsbScan.Text = "条码扫描/导入";
            this.tsbScan.Click += new System.EventHandler(this.tsbScan_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(49, 22);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txtMaker
            // 
            this.txtMaker.BackColor = System.Drawing.SystemColors.Window;
            this.txtMaker.btnEnabled = true;
            this.txtMaker.btnVisible = false;
            this.txtMaker.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtMaker.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaker.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMaker.lblText = "制单人";
            this.txtMaker.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtMaker.Location = new System.Drawing.Point(567, 15);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(259, 18);
            this.txtMaker.TabIndex = 21;
            this.txtMaker.txtBackColor = System.Drawing.Color.White;
            this.txtMaker.txtEnabled = true;
            this.txtMaker.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaker.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMaker.txtPasswrod = '\0';
            this.txtMaker.txtReadOnly = true;
            this.txtMaker.txtTag = null;
            this.txtMaker.txtText = "";
            this.txtMaker.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dtpVouchDate
            // 
            this.dtpVouchDate.CustomFormat = "yyyy-MM-dd";
            this.dtpVouchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVouchDate.Location = new System.Drawing.Point(364, 11);
            this.dtpVouchDate.Name = "dtpVouchDate";
            this.dtpVouchDate.Size = new System.Drawing.Size(144, 21);
            this.dtpVouchDate.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "单据日期";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewVoucher,
            this.tsbModify,
            this.tsbRef,
            this.toolStripSeparator3,
            this.tsbDraft,
            this.tsbNew,
            this.tsbDel,
            this.tsbCopyRow,
            this.tsbSave,
            this.tsbCancel,
            this.toolStripSeparator1,
            this.tsbScan,
            this.toolStripSeparator2,
            this.tsbSettings,
            this.tsbPrint,
            this.toolStripSeparator4,
            this.tsbEmpty});
            this.toolStrip1.Location = new System.Drawing.Point(0, 70);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 113;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewVoucher
            // 
            this.tsbNewVoucher.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewVoucher.Image")));
            this.tsbNewVoucher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewVoucher.Name = "tsbNewVoucher";
            this.tsbNewVoucher.Size = new System.Drawing.Size(49, 22);
            this.tsbNewVoucher.Text = "新建";
            this.tsbNewVoucher.Click += new System.EventHandler(this.tsbNewVoucher_Click);
            // 
            // tsbModify
            // 
            this.tsbModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify.Image")));
            this.tsbModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify.Name = "tsbModify";
            this.tsbModify.Size = new System.Drawing.Size(49, 22);
            this.tsbModify.Text = "修改";
            this.tsbModify.Click += new System.EventHandler(this.tsbModify_Click);
            // 
            // tsbRef
            // 
            this.tsbRef.Image = ((System.Drawing.Image)(resources.GetObject("tsbRef.Image")));
            this.tsbRef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRef.Name = "tsbRef";
            this.tsbRef.Size = new System.Drawing.Size(85, 22);
            this.tsbRef.Text = "参照借出单";
            this.tsbRef.Click += new System.EventHandler(this.tsbRef_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDraft
            // 
            this.tsbDraft.Image = ((System.Drawing.Image)(resources.GetObject("tsbDraft.Image")));
            this.tsbDraft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDraft.Name = "tsbDraft";
            this.tsbDraft.Size = new System.Drawing.Size(73, 22);
            this.tsbDraft.Text = "暂存草稿";
            this.tsbDraft.Click += new System.EventHandler(this.tsbDraft_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(49, 22);
            this.tsbNew.Text = "增行";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(49, 22);
            this.tsbDel.Text = "删行";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbCopyRow
            // 
            this.tsbCopyRow.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopyRow.Image")));
            this.tsbCopyRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopyRow.Name = "tsbCopyRow";
            this.tsbCopyRow.Size = new System.Drawing.Size(61, 22);
            this.tsbCopyRow.Text = "复制行";
            this.tsbCopyRow.Click += new System.EventHandler(this.tsbCopyRow_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(49, 22);
            this.tsbCancel.Text = "放弃";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEmpty
            // 
            this.tsbEmpty.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmpty.Image")));
            this.tsbEmpty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmpty.Name = "tsbEmpty";
            this.tsbEmpty.Size = new System.Drawing.Size(49, 22);
            this.tsbEmpty.Text = "清空";
            this.tsbEmpty.Click += new System.EventHandler(this.tsbEmpty_Click);
            // 
            // txtVouchCode
            // 
            this.txtVouchCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtVouchCode.btnEnabled = true;
            this.txtVouchCode.btnVisible = false;
            this.txtVouchCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVouchCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVouchCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVouchCode.lblText = "单据编号";
            this.txtVouchCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVouchCode.Location = new System.Drawing.Point(12, 12);
            this.txtVouchCode.Name = "txtVouchCode";
            this.txtVouchCode.Size = new System.Drawing.Size(259, 18);
            this.txtVouchCode.TabIndex = 16;
            this.txtVouchCode.txtBackColor = System.Drawing.Color.White;
            this.txtVouchCode.txtEnabled = true;
            this.txtVouchCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVouchCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVouchCode.txtPasswrod = '\0';
            this.txtVouchCode.txtReadOnly = true;
            this.txtVouchCode.txtTag = null;
            this.txtVouchCode.txtText = "";
            this.txtVouchCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.txtSourceVouchCode);
            this.panel2.Controls.Add(this.txtMemo);
            this.panel2.Controls.Add(this.txtMaker);
            this.panel2.Controls.Add(this.dtpVouchDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtVouchCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 70);
            this.panel2.TabIndex = 112;
            // 
            // txtSourceVouchCode
            // 
            this.txtSourceVouchCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtSourceVouchCode.btnEnabled = true;
            this.txtSourceVouchCode.btnVisible = false;
            this.txtSourceVouchCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtSourceVouchCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSourceVouchCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSourceVouchCode.lblText = "借出单号";
            this.txtSourceVouchCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSourceVouchCode.Location = new System.Drawing.Point(567, 39);
            this.txtSourceVouchCode.Name = "txtSourceVouchCode";
            this.txtSourceVouchCode.Size = new System.Drawing.Size(259, 18);
            this.txtSourceVouchCode.TabIndex = 23;
            this.txtSourceVouchCode.txtBackColor = System.Drawing.Color.White;
            this.txtSourceVouchCode.txtEnabled = true;
            this.txtSourceVouchCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSourceVouchCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSourceVouchCode.txtPasswrod = '\0';
            this.txtSourceVouchCode.txtReadOnly = true;
            this.txtSourceVouchCode.txtTag = null;
            this.txtSourceVouchCode.txtText = "";
            this.txtSourceVouchCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.Window;
            this.txtMemo.btnEnabled = true;
            this.txtMemo.btnVisible = false;
            this.txtMemo.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtMemo.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMemo.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMemo.lblText = "备注";
            this.txtMemo.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtMemo.Location = new System.Drawing.Point(12, 36);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(496, 18);
            this.txtMemo.TabIndex = 22;
            this.txtMemo.txtBackColor = System.Drawing.Color.White;
            this.txtMemo.txtEnabled = true;
            this.txtMemo.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMemo.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMemo.txtPasswrod = '\0';
            this.txtMemo.txtReadOnly = false;
            this.txtMemo.txtTag = null;
            this.txtMemo.txtText = "";
            this.txtMemo.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dgv
            // 
            this.dgv.BackColor = System.Drawing.SystemColors.Window;
            this.dgv.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.dgv.ColumnInfo = resources.GetString("dgv.ColumnInfo");
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.Location = new System.Drawing.Point(0, 95);
            this.dgv.Name = "dgv";
            this.dgv.Rows.Count = 1;
            this.dgv.ShowCursor = true;
            this.dgv.Size = new System.Drawing.Size(1014, 384);
            this.dgv.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgv.Styles"));
            this.dgv.TabIndex = 114;
            this.dgv.KeyPressEdit += new C1.Win.C1FlexGrid.KeyPressEditEventHandler(this.dgv_KeyPressEdit);
            this.dgv.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.dgv_CellButtonClick);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(73, 22);
            this.tsbSettings.Text = "纸张设置";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // frmReturnVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 479);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "frmReturnVouch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "归还单";
            this.Load += new System.EventHandler(this.frmReturnVouch_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbScan;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Lixtech.UserControls.UCTextBox txtMaker;
        private System.Windows.Forms.DateTimePicker dtpVouchDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Lixtech.UserControls.UCTextBox txtVouchCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton tsbRef;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDraft;
        private Lixtech.UserControls.UCTextBox txtMemo;
        private Lixtech.UserControls.UCTextBox txtSourceVouchCode;
        private C1.Win.C1FlexGrid.C1FlexGrid dgv;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbEmpty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbNewVoucher;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbCopyRow;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbSettings;
    }
}