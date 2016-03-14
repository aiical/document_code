namespace UFIDA.Retail.VIPCardControl
{
    partial class frmPromotionForm
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
            this.txtNewCardCode = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerCode = new Lixtech.UserControls.UCTextBox();
            this.txtConsumerName = new Lixtech.UserControls.UCTextBox();
            this.txtOldCardCode = new Lixtech.UserControls.UCTextBox();
            this.txtOldCardClass = new Lixtech.UserControls.UCTextBox();
            this.txtProCardClass = new Lixtech.UserControls.UCTextBox();
            this.txtTwoYearPoint = new Lixtech.UserControls.UCTextBox();
            this.txtProPoint = new Lixtech.UserControls.UCTextBox();
            this.txtRemainPoint = new Lixtech.UserControls.UCTextBox();
            this.txtMaxMoney = new Lixtech.UserControls.UCTextBox();
            this.txtOneYearPoint = new Lixtech.UserControls.UCTextBox();
            this.txtConsumeDays = new Lixtech.UserControls.UCTextBox();
            this.txtStoreName = new Lixtech.UserControls.UCTextBox();
            this.btnPromote = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewCardCode
            // 
            this.txtNewCardCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewCardCode.btnEnabled = true;
            this.txtNewCardCode.btnVisible = true;
            this.txtNewCardCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtNewCardCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewCardCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNewCardCode.lblText = "新VIP卡号";
            this.txtNewCardCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtNewCardCode.Location = new System.Drawing.Point(12, 105);
            this.txtNewCardCode.Name = "txtNewCardCode";
            this.txtNewCardCode.Size = new System.Drawing.Size(169, 18);
            this.txtNewCardCode.TabIndex = 1;
            this.txtNewCardCode.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtNewCardCode.txtEnabled = true;
            this.txtNewCardCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewCardCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNewCardCode.txtPasswrod = '\0';
            this.txtNewCardCode.txtReadOnly = false;
            this.txtNewCardCode.txtTag = null;
            this.txtNewCardCode.txtText = "";
            this.txtNewCardCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewCardCode.Button_Click += new Lixtech.UserControls.UCTextBox.ButtonClick(this.txtNewCardCode_Button_Click);
            this.txtNewCardCode.TextBox_KeyPress += new Lixtech.UserControls.UCTextBox.TextBoxKeyPress(this.txtNewCardCode_TextBox_KeyPress);
            // 
            // txtConsumerCode
            // 
            this.txtConsumerCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerCode.btnEnabled = true;
            this.txtConsumerCode.btnVisible = false;
            this.txtConsumerCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsumerCode.lblText = "客户编码";
            this.txtConsumerCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtConsumerCode.Location = new System.Drawing.Point(12, 28);
            this.txtConsumerCode.Name = "txtConsumerCode";
            this.txtConsumerCode.Size = new System.Drawing.Size(169, 18);
            this.txtConsumerCode.TabIndex = 5;
            this.txtConsumerCode.txtBackColor = System.Drawing.Color.White;
            this.txtConsumerCode.txtEnabled = false;
            this.txtConsumerCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConsumerCode.txtPasswrod = '\0';
            this.txtConsumerCode.txtReadOnly = true;
            this.txtConsumerCode.txtTag = null;
            this.txtConsumerCode.txtText = "";
            this.txtConsumerCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerName.btnEnabled = true;
            this.txtConsumerName.btnVisible = false;
            this.txtConsumerName.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtConsumerName.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerName.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsumerName.lblText = "客户名称";
            this.txtConsumerName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtConsumerName.Location = new System.Drawing.Point(255, 28);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(180, 18);
            this.txtConsumerName.TabIndex = 6;
            this.txtConsumerName.txtBackColor = System.Drawing.Color.White;
            this.txtConsumerName.txtEnabled = false;
            this.txtConsumerName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumerName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConsumerName.txtPasswrod = '\0';
            this.txtConsumerName.txtReadOnly = true;
            this.txtConsumerName.txtTag = null;
            this.txtConsumerName.txtText = "";
            this.txtConsumerName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtOldCardCode
            // 
            this.txtOldCardCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldCardCode.btnEnabled = true;
            this.txtOldCardCode.btnVisible = false;
            this.txtOldCardCode.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtOldCardCode.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldCardCode.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldCardCode.lblText = "原VIP卡号";
            this.txtOldCardCode.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtOldCardCode.Location = new System.Drawing.Point(12, 65);
            this.txtOldCardCode.Name = "txtOldCardCode";
            this.txtOldCardCode.Size = new System.Drawing.Size(169, 18);
            this.txtOldCardCode.TabIndex = 7;
            this.txtOldCardCode.txtBackColor = System.Drawing.Color.White;
            this.txtOldCardCode.txtEnabled = false;
            this.txtOldCardCode.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldCardCode.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOldCardCode.txtPasswrod = '\0';
            this.txtOldCardCode.txtReadOnly = true;
            this.txtOldCardCode.txtTag = null;
            this.txtOldCardCode.txtText = "";
            this.txtOldCardCode.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtOldCardClass
            // 
            this.txtOldCardClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldCardClass.btnEnabled = true;
            this.txtOldCardClass.btnVisible = false;
            this.txtOldCardClass.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtOldCardClass.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldCardClass.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldCardClass.lblText = "当前卡级别";
            this.txtOldCardClass.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtOldCardClass.Location = new System.Drawing.Point(255, 65);
            this.txtOldCardClass.Name = "txtOldCardClass";
            this.txtOldCardClass.Size = new System.Drawing.Size(180, 18);
            this.txtOldCardClass.TabIndex = 8;
            this.txtOldCardClass.txtBackColor = System.Drawing.Color.White;
            this.txtOldCardClass.txtEnabled = false;
            this.txtOldCardClass.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldCardClass.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOldCardClass.txtPasswrod = '\0';
            this.txtOldCardClass.txtReadOnly = true;
            this.txtOldCardClass.txtTag = null;
            this.txtOldCardClass.txtText = "";
            this.txtOldCardClass.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.txtProCardClass.Location = new System.Drawing.Point(255, 105);
            this.txtProCardClass.Name = "txtProCardClass";
            this.txtProCardClass.Size = new System.Drawing.Size(180, 18);
            this.txtProCardClass.TabIndex = 9;
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
            // txtTwoYearPoint
            // 
            this.txtTwoYearPoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtTwoYearPoint.btnEnabled = true;
            this.txtTwoYearPoint.btnVisible = false;
            this.txtTwoYearPoint.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtTwoYearPoint.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTwoYearPoint.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTwoYearPoint.lblText = "两年内积分余额";
            this.txtTwoYearPoint.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtTwoYearPoint.Location = new System.Drawing.Point(12, 230);
            this.txtTwoYearPoint.Name = "txtTwoYearPoint";
            this.txtTwoYearPoint.Size = new System.Drawing.Size(169, 18);
            this.txtTwoYearPoint.TabIndex = 10;
            this.txtTwoYearPoint.txtBackColor = System.Drawing.Color.White;
            this.txtTwoYearPoint.txtEnabled = false;
            this.txtTwoYearPoint.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTwoYearPoint.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTwoYearPoint.txtPasswrod = '\0';
            this.txtTwoYearPoint.txtReadOnly = true;
            this.txtTwoYearPoint.txtTag = null;
            this.txtTwoYearPoint.txtText = "";
            this.txtTwoYearPoint.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtProPoint
            // 
            this.txtProPoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtProPoint.btnEnabled = true;
            this.txtProPoint.btnVisible = false;
            this.txtProPoint.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtProPoint.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProPoint.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtProPoint.lblText = "晋级所需积分";
            this.txtProPoint.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtProPoint.Location = new System.Drawing.Point(12, 148);
            this.txtProPoint.Name = "txtProPoint";
            this.txtProPoint.Size = new System.Drawing.Size(169, 18);
            this.txtProPoint.TabIndex = 11;
            this.txtProPoint.txtBackColor = System.Drawing.Color.White;
            this.txtProPoint.txtEnabled = false;
            this.txtProPoint.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProPoint.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProPoint.txtPasswrod = '\0';
            this.txtProPoint.txtReadOnly = true;
            this.txtProPoint.txtTag = null;
            this.txtProPoint.txtText = "";
            this.txtProPoint.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtRemainPoint
            // 
            this.txtRemainPoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemainPoint.btnEnabled = true;
            this.txtRemainPoint.btnVisible = false;
            this.txtRemainPoint.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtRemainPoint.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemainPoint.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRemainPoint.lblText = "剩余积分";
            this.txtRemainPoint.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtRemainPoint.Location = new System.Drawing.Point(255, 149);
            this.txtRemainPoint.Name = "txtRemainPoint";
            this.txtRemainPoint.Size = new System.Drawing.Size(180, 17);
            this.txtRemainPoint.TabIndex = 12;
            this.txtRemainPoint.txtBackColor = System.Drawing.Color.White;
            this.txtRemainPoint.txtEnabled = false;
            this.txtRemainPoint.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemainPoint.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRemainPoint.txtPasswrod = '\0';
            this.txtRemainPoint.txtReadOnly = true;
            this.txtRemainPoint.txtTag = null;
            this.txtRemainPoint.txtText = "";
            this.txtRemainPoint.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtMaxMoney
            // 
            this.txtMaxMoney.BackColor = System.Drawing.SystemColors.Window;
            this.txtMaxMoney.btnEnabled = true;
            this.txtMaxMoney.btnVisible = false;
            this.txtMaxMoney.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtMaxMoney.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaxMoney.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMaxMoney.lblText = "一次性消费金额";
            this.txtMaxMoney.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtMaxMoney.Location = new System.Drawing.Point(12, 187);
            this.txtMaxMoney.Name = "txtMaxMoney";
            this.txtMaxMoney.Size = new System.Drawing.Size(169, 18);
            this.txtMaxMoney.TabIndex = 13;
            this.txtMaxMoney.txtBackColor = System.Drawing.Color.White;
            this.txtMaxMoney.txtEnabled = false;
            this.txtMaxMoney.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaxMoney.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMaxMoney.txtPasswrod = '\0';
            this.txtMaxMoney.txtReadOnly = true;
            this.txtMaxMoney.txtTag = null;
            this.txtMaxMoney.txtText = "";
            this.txtMaxMoney.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtOneYearPoint
            // 
            this.txtOneYearPoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtOneYearPoint.btnEnabled = true;
            this.txtOneYearPoint.btnVisible = false;
            this.txtOneYearPoint.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtOneYearPoint.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOneYearPoint.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOneYearPoint.lblText = "一年内积分余额";
            this.txtOneYearPoint.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtOneYearPoint.Location = new System.Drawing.Point(255, 187);
            this.txtOneYearPoint.Name = "txtOneYearPoint";
            this.txtOneYearPoint.Size = new System.Drawing.Size(180, 18);
            this.txtOneYearPoint.TabIndex = 14;
            this.txtOneYearPoint.txtBackColor = System.Drawing.Color.White;
            this.txtOneYearPoint.txtEnabled = false;
            this.txtOneYearPoint.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOneYearPoint.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOneYearPoint.txtPasswrod = '\0';
            this.txtOneYearPoint.txtReadOnly = false;
            this.txtOneYearPoint.txtTag = null;
            this.txtOneYearPoint.txtText = "";
            this.txtOneYearPoint.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtConsumeDays
            // 
            this.txtConsumeDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumeDays.btnEnabled = true;
            this.txtConsumeDays.btnVisible = false;
            this.txtConsumeDays.lblBackColor = System.Drawing.SystemColors.Window;
            this.txtConsumeDays.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumeDays.lblForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsumeDays.lblText = "距最近消费天数";
            this.txtConsumeDays.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtConsumeDays.Location = new System.Drawing.Point(255, 230);
            this.txtConsumeDays.Name = "txtConsumeDays";
            this.txtConsumeDays.Size = new System.Drawing.Size(180, 18);
            this.txtConsumeDays.TabIndex = 15;
            this.txtConsumeDays.txtBackColor = System.Drawing.Color.White;
            this.txtConsumeDays.txtEnabled = false;
            this.txtConsumeDays.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumeDays.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConsumeDays.txtPasswrod = '\0';
            this.txtConsumeDays.txtReadOnly = true;
            this.txtConsumeDays.txtTag = null;
            this.txtConsumeDays.txtText = "";
            this.txtConsumeDays.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.txtStoreName.lblTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtStoreName.Location = new System.Drawing.Point(12, 265);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(169, 18);
            this.txtStoreName.TabIndex = 16;
            this.txtStoreName.txtBackColor = System.Drawing.Color.White;
            this.txtStoreName.txtEnabled = false;
            this.txtStoreName.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStoreName.txtForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStoreName.txtPasswrod = '\0';
            this.txtStoreName.txtReadOnly = true;
            this.txtStoreName.txtTag = null;
            this.txtStoreName.txtText = "";
            this.txtStoreName.txtTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnPromote
            // 
            this.btnPromote.Location = new System.Drawing.Point(275, 325);
            this.btnPromote.Name = "btnPromote";
            this.btnPromote.Size = new System.Drawing.Size(55, 23);
            this.btnPromote.TabIndex = 17;
            this.btnPromote.Text = "晋级";
            this.btnPromote.UseVisualStyleBackColor = true;
            this.btnPromote.Click += new System.EventHandler(this.btnPromote_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(360, 325);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(468, 360);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPromote);
            this.Controls.Add(this.txtStoreName);
            this.Controls.Add(this.txtConsumeDays);
            this.Controls.Add(this.txtOneYearPoint);
            this.Controls.Add(this.txtMaxMoney);
            this.Controls.Add(this.txtRemainPoint);
            this.Controls.Add(this.txtProPoint);
            this.Controls.Add(this.txtTwoYearPoint);
            this.Controls.Add(this.txtProCardClass);
            this.Controls.Add(this.txtOldCardClass);
            this.Controls.Add(this.txtOldCardCode);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.txtConsumerCode);
            this.Controls.Add(this.txtNewCardCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPromotionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户晋级";
            this.Load += new System.EventHandler(this.frmPromotionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lixtech.UserControls.UCTextBox txtNewCardCode;
        private Lixtech.UserControls.UCTextBox txtConsumerCode;
        private Lixtech.UserControls.UCTextBox txtConsumerName;
        private Lixtech.UserControls.UCTextBox txtOldCardCode;
        private Lixtech.UserControls.UCTextBox txtOldCardClass;
        private Lixtech.UserControls.UCTextBox txtProCardClass;
        private Lixtech.UserControls.UCTextBox txtTwoYearPoint;
        private Lixtech.UserControls.UCTextBox txtProPoint;
        private Lixtech.UserControls.UCTextBox txtRemainPoint;
        private Lixtech.UserControls.UCTextBox txtMaxMoney;
        private Lixtech.UserControls.UCTextBox txtOneYearPoint;
        private Lixtech.UserControls.UCTextBox txtConsumeDays;
        private Lixtech.UserControls.UCTextBox txtStoreName;
        private System.Windows.Forms.Button btnPromote;
        private System.Windows.Forms.Button btnCancel;
    }
}