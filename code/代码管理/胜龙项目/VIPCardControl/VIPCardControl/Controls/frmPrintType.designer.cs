namespace UFIDA.Retail.VIPCardControl
{
    partial class frmPrintType {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPageHeight = new System.Windows.Forms.TextBox();
            this.txtPageWidth = new System.Windows.Forms.TextBox();
            this.txtBottomMargin = new System.Windows.Forms.TextBox();
            this.txtTopMargin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRightMargin = new System.Windows.Forms.TextBox();
            this.txtLeftMargin = new System.Windows.Forms.TextBox();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.txtRowHeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "12cm×29.7cm纸张",
            "24cm×29.7cm纸张"});
            this.comboBox1.Location = new System.Drawing.Point(59, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(81, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "模板 ";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(63, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(177, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPageHeight
            // 
            this.txtPageHeight.Location = new System.Drawing.Point(57, 49);
            this.txtPageHeight.Name = "txtPageHeight";
            this.txtPageHeight.Size = new System.Drawing.Size(81, 21);
            this.txtPageHeight.TabIndex = 2;
            this.txtPageHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // txtPageWidth
            // 
            this.txtPageWidth.Location = new System.Drawing.Point(213, 49);
            this.txtPageWidth.Name = "txtPageWidth";
            this.txtPageWidth.Size = new System.Drawing.Size(77, 21);
            this.txtPageWidth.TabIndex = 3;
            this.txtPageWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // txtBottomMargin
            // 
            this.txtBottomMargin.Location = new System.Drawing.Point(213, 80);
            this.txtBottomMargin.Name = "txtBottomMargin";
            this.txtBottomMargin.Size = new System.Drawing.Size(77, 21);
            this.txtBottomMargin.TabIndex = 5;
            this.txtBottomMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // txtTopMargin
            // 
            this.txtTopMargin.Location = new System.Drawing.Point(57, 80);
            this.txtTopMargin.Name = "txtTopMargin";
            this.txtTopMargin.Size = new System.Drawing.Size(81, 21);
            this.txtTopMargin.TabIndex = 4;
            this.txtTopMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "高";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "宽";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "上空隙";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "下空隙";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "右空隙";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "左空隙";
            // 
            // txtRightMargin
            // 
            this.txtRightMargin.Location = new System.Drawing.Point(213, 110);
            this.txtRightMargin.Name = "txtRightMargin";
            this.txtRightMargin.Size = new System.Drawing.Size(77, 21);
            this.txtRightMargin.TabIndex = 7;
            this.txtRightMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // txtLeftMargin
            // 
            this.txtLeftMargin.Location = new System.Drawing.Point(57, 110);
            this.txtLeftMargin.Name = "txtLeftMargin";
            this.txtLeftMargin.Size = new System.Drawing.Size(81, 21);
            this.txtLeftMargin.TabIndex = 6;
            this.txtLeftMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(57, 137);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(81, 21);
            this.txtPageSize.TabIndex = 8;
            this.txtPageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // txtRowHeight
            // 
            this.txtRowHeight.Location = new System.Drawing.Point(213, 137);
            this.txtRowHeight.Name = "txtRowHeight";
            this.txtRowHeight.Size = new System.Drawing.Size(77, 21);
            this.txtRowHeight.TabIndex = 9;
            this.txtRowHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageHeight_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "页大小";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "行高距";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "打印类型";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "细体",
            "粗体"});
            this.comboBox2.Location = new System.Drawing.Point(213, 21);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(77, 20);
            this.comboBox2.TabIndex = 1;
            // 
            // frmPrintType
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(305, 234);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRowHeight);
            this.Controls.Add(this.txtRightMargin);
            this.Controls.Add(this.txtPageSize);
            this.Controls.Add(this.txtLeftMargin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBottomMargin);
            this.Controls.Add(this.txtTopMargin);
            this.Controls.Add(this.txtPageWidth);
            this.Controls.Add(this.txtPageHeight);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintType";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印纸张模板";
            this.Load += new System.EventHandler(this.frmPrintType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPageHeight;
        private System.Windows.Forms.TextBox txtPageWidth;
        private System.Windows.Forms.TextBox txtBottomMargin;
        private System.Windows.Forms.TextBox txtTopMargin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRightMargin;
        private System.Windows.Forms.TextBox txtLeftMargin;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.TextBox txtRowHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}