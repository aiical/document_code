namespace UFIDA.Retail.VIPCardControl
{
    partial class frmVIPConsumerPromotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVIPConsumerPromotion));
            this.txtVIPCardCode = new Lixtech.UserControls.UCTextBox();
            this.flexMain = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtProCardClass = new Lixtech.UserControls.UCTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbPromote = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStoreName = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerName = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerCode = new Lixtech.UserControls.UCTextBox();
            this.txtVIPCardClass = new Lixtech.UserControls.UCTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flexMain)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.txtVIPCardCode.Location = new System.Drawing.Point(616, 13);
            this.txtVIPCardCode.Name = "txtVIPCardCode";
            this.txtVIPCardCode.Size = new System.Drawing.Size(259, 18);
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
            // flexMain
            // 
            this.flexMain.AllowEditing = false;
            this.flexMain.BackColor = System.Drawing.SystemColors.Window;
            this.flexMain.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.flexMain.ColumnInfo = resources.GetString("flexMain.ColumnInfo");
            this.flexMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flexMain.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flexMain.Location = new System.Drawing.Point(0, 130);
            this.flexMain.Name = "flexMain";
            this.flexMain.Rows.Count = 1;
            this.flexMain.ShowCursor = true;
            this.flexMain.Size = new System.Drawing.Size(1014, 349);
            this.flexMain.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("flexMain.Styles"));
            this.flexMain.TabIndex = 97;
            // 
            // txtProCardClass
            // 
            this.txtProCardClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtProCardClass.btnEnabled = true;
            this.txtProCardClass.btnVisible = true;
            this.txtProCardClass.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtProCardClass.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProCardClass.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtProCardClass.lblText = "可晋升级别";
            this.txtProCardClass.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtProCardClass.Location = new System.Drawing.Point(317, 37);
            this.txtProCardClass.Name = "txtProCardClass";
            this.txtProCardClass.Size = new System.Drawing.Size(259, 18);
            this.txtProCardClass.TabIndex = 3;
            this.txtProCardClass.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtProCardClass.txtEnabled = true;
            this.txtProCardClass.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProCardClass.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProCardClass.txtPasswrod = '\0';
            this.txtProCardClass.txtReadOnly = false;
            this.txtProCardClass.txtTag = null;
            this.txtProCardClass.txtText = "";
            this.txtProCardClass.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtProCardClass.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtProCardClass_Button_Click);
            this.txtProCardClass.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtProCardClass_TextBox_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbPromote});
            this.toolStrip1.Location = new System.Drawing.Point(0, 105);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 99;
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
            // tsbPromote
            // 
            this.tsbPromote.Image = ((System.Drawing.Image)(resources.GetObject("tsbPromote.Image")));
            this.tsbPromote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPromote.Name = "tsbPromote";
            this.tsbPromote.Size = new System.Drawing.Size(73, 22);
            this.tsbPromote.Text = "晋级换卡";
            this.tsbPromote.Click += new System.EventHandler(this.tsbPromote_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.txtStoreName);
            this.panel2.Controls.Add(this.txtConsumerName);
            this.panel2.Controls.Add(this.txtConsumerCode);
            this.panel2.Controls.Add(this.txtVIPCardCode);
            this.panel2.Controls.Add(this.txtProCardClass);
            this.panel2.Controls.Add(this.txtVIPCardClass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 70);
            this.panel2.TabIndex = 96;
            // 
            // txtStoreName
            // 
            this.txtStoreName.BackColor = System.Drawing.SystemColors.Window;
            this.txtStoreName.btnEnabled = true;
            this.txtStoreName.btnVisible = false;
            this.txtStoreName.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtStoreName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStoreName.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtStoreName.lblText = "归属门店";
            this.txtStoreName.lblTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtStoreName.Location = new System.Drawing.Point(616, 37);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(259, 18);
            this.txtStoreName.TabIndex = 19;
            this.txtStoreName.txtBackColor = System.Drawing.Color.White;
            this.txtStoreName.txtEnabled = true;
            this.txtStoreName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStoreName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStoreName.txtPasswrod = '\0';
            this.txtStoreName.txtReadOnly = false;
            this.txtStoreName.txtTag = null;
            this.txtStoreName.txtText = "";
            this.txtStoreName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.txtConsumerName.Location = new System.Drawing.Point(317, 13);
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
            this.txtConsumerCode.Location = new System.Drawing.Point(12, 13);
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
            // 
            // txtVIPCardClass
            // 
            this.txtVIPCardClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPCardClass.btnEnabled = true;
            this.txtVIPCardClass.btnVisible = true;
            this.txtVIPCardClass.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtVIPCardClass.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVIPCardClass.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVIPCardClass.lblText = "当前客户级别";
            this.txtVIPCardClass.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtVIPCardClass.Location = new System.Drawing.Point(12, 37);
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
            this.label1.TabIndex = 95;
            this.label1.Text = "在线VIP客户晋级";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmVIPConsumerPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 479);
            this.Controls.Add(this.flexMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Name = "frmVIPConsumerPromotion";
            this.ShowIcon = false;
            this.Text = "VIP客户晋级";
            this.Load += new System.EventHandler(this.frmVIPConsumerPromotion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flexMain)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lixtech.UserControls.UCTextBox txtVIPCardCode;
        private C1.Win.C1FlexGrid.C1FlexGrid flexMain;
        private Lixtech.UserControls.UCTextBox txtProCardClass;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.Panel panel2;
        private Lixtech.UserControls.UCTextBox txtVIPCardClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbPromote;
        private Lixtech.UserControls.UCTextBox txtConsumerCode;
        private Lixtech.UserControls.UCTextBox txtConsumerName;
        private Lixtech.UserControls.UCTextBox txtStoreName;

    }
}