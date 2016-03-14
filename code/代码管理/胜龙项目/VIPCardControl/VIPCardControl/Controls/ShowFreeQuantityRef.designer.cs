namespace UFIDA.Retail.VIPCardControl
{
    partial class ShowFreeQuantityRef
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
            this.dgvFQ = new System.Windows.Forms.DataGridView();
            this.dgvQuantity = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFQ
            // 
            this.dgvFQ.AllowUserToAddRows = false;
            this.dgvFQ.AllowUserToDeleteRows = false;
            this.dgvFQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFQ.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFQ.Location = new System.Drawing.Point(-2, 0);
            this.dgvFQ.Name = "dgvFQ";
            this.dgvFQ.RowTemplate.Height = 23;
            this.dgvFQ.Size = new System.Drawing.Size(444, 260);
            this.dgvFQ.TabIndex = 0;
            this.dgvFQ.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFQ_CellLeave);
            this.dgvFQ.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFQ_CellEndEdit);
            this.dgvFQ.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFQ_CellClick);
            this.dgvFQ.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFQ_EditingControlShowing);
            this.dgvFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvFQ_KeyPress);
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.AllowUserToAddRows = false;
            this.dgvQuantity.AllowUserToDeleteRows = false;
            this.dgvQuantity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuantity.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuantity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuantity.Location = new System.Drawing.Point(-2, 288);
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.RowTemplate.Height = 23;
            this.dgvQuantity.Size = new System.Drawing.Size(444, 260);
            this.dgvQuantity.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "合计数量:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.Location = new System.Drawing.Point(68, 268);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(11, 12);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "只能输入正整数或零,否则光标不能离开输入框";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 564);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "可用量";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(263, 561);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(344, 561);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // ShowFreeQuantityRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(441, 592);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvQuantity);
            this.Controls.Add(this.dgvFQ);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShowFreeQuantityRef";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ShowFreeQuantityRef_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        public System.Windows.Forms.DataGridView dgvFQ;
    }
}

