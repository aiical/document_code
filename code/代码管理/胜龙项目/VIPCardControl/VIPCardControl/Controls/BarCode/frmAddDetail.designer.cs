namespace UFIDA.Retail.VIPCardControl
{
    partial class frmAddDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.条码 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFinsh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOutTxt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvErrorBarCode = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBarCode
            // 
            this.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode.Location = new System.Drawing.Point(88, 16);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(323, 21);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress);
            // 
            // 条码
            // 
            this.条码.AutoSize = true;
            this.条码.Location = new System.Drawing.Point(12, 18);
            this.条码.Name = "条码";
            this.条码.Size = new System.Drawing.Size(41, 12);
            this.条码.TabIndex = 19;
            this.条码.Text = "条码：";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(353, 79);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 24);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "    退 出(&Q)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFinsh
            // 
            this.btnFinsh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinsh.Image = ((System.Drawing.Image)(resources.GetObject("btnFinsh.Image")));
            this.btnFinsh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinsh.Location = new System.Drawing.Point(13, 80);
            this.btnFinsh.Name = "btnFinsh";
            this.btnFinsh.Size = new System.Drawing.Size(88, 24);
            this.btnFinsh.TabIndex = 2;
            this.btnFinsh.Text = "    完 成(&F)";
            this.btnFinsh.UseVisualStyleBackColor = true;
            this.btnFinsh.Visible = false;
            this.btnFinsh.Click += new System.EventHandler(this.btnFinsh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 4);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnOutTxt);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnFinsh);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.条码);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 110);
            this.panel1.TabIndex = 21;
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(165, 79);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(88, 24);
            this.btnImport.TabIndex = 20;
            this.btnImport.Text = "    导 入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOutTxt
            // 
            this.btnOutTxt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOutTxt.Image = ((System.Drawing.Image)(resources.GetObject("btnOutTxt.Image")));
            this.btnOutTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutTxt.Location = new System.Drawing.Point(259, 79);
            this.btnOutTxt.Name = "btnOutTxt";
            this.btnOutTxt.Size = new System.Drawing.Size(88, 24);
            this.btnOutTxt.TabIndex = 20;
            this.btnOutTxt.Text = "    导 出(&O)";
            this.btnOutTxt.UseVisualStyleBackColor = true;
            this.btnOutTxt.Click += new System.EventHandler(this.btnOutTxt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(13, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 4);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvErrorBarCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 174);
            this.panel2.TabIndex = 22;
            // 
            // dgvErrorBarCode
            // 
            this.dgvErrorBarCode.AllowUserToAddRows = false;
            this.dgvErrorBarCode.AllowUserToDeleteRows = false;
            this.dgvErrorBarCode.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrorBarCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvErrorBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorBarCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3});
            this.dgvErrorBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrorBarCode.Location = new System.Drawing.Point(0, 0);
            this.dgvErrorBarCode.Name = "dgvErrorBarCode";
            this.dgvErrorBarCode.ReadOnly = true;
            this.dgvErrorBarCode.RowTemplate.Height = 23;
            this.dgvErrorBarCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrorBarCode.Size = new System.Drawing.Size(453, 174);
            this.dgvErrorBarCode.TabIndex = 0;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "以下条码解析失败";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "失败原因";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(413, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAddDetail
            // 
            this.AcceptButton = this.btnFinsh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(453, 284);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条码扫描";
            this.Load += new System.EventHandler(this.frmAddDetail_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddDetail_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorBarCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label 条码;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFinsh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvErrorBarCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOutTxt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button button1;
    }
}