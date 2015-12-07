namespace SL_U8Framework
{
    partial class FrmBanXing
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBanXing));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EditToolBar = new Donlim.Controls.EditToolStrip(this.components);
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.dbGrid_Detail = new Donlim.Controls.DBGrid();
            this.CU8cAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CU8cValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNewBx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTimestamp = new Donlim.Controls.DBGrid.DataGridViewDateTimeColumn();
            this.EditToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Detail)).BeginInit();
            this.SuspendLayout();
            // 
            // EditToolBar
            // 
            this.EditToolBar.AuditState = Donlim.Controls.EditToolStripAuditState.Draft;
            this.EditToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator});
            this.EditToolBar.Location = new System.Drawing.Point(0, 0);
            this.EditToolBar.Name = "EditToolBar";
            this.EditToolBar.Size = new System.Drawing.Size(780, 35);
            this.EditToolBar.State = Donlim.Controls.EditToolStripState.DefaultState;
            this.EditToolBar.TabIndex = 5;
            this.EditToolBar.Text = "editToolStrip1";
            this.EditToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.EditToolBar_ItemClicked);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // dbGrid_Detail
            // 
            this.dbGrid_Detail.AllowUserToAddRows = false;
            this.dbGrid_Detail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGrid_Detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbGrid_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid_Detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CU8cAlias,
            this.CU8cValue,
            this.CNewBx,
            this.CTimestamp});
            this.dbGrid_Detail.Conn = null;
            this.dbGrid_Detail.DataSet = null;
            this.dbGrid_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbGrid_Detail.Is_CnHeaderText = false;
            this.dbGrid_Detail.Location = new System.Drawing.Point(0, 35);
            this.dbGrid_Detail.Name = "dbGrid_Detail";
            this.dbGrid_Detail.ReadOnly = true;
            this.dbGrid_Detail.RowTemplate.Height = 23;
            this.dbGrid_Detail.ShowLineNumber = true;
            this.dbGrid_Detail.Size = new System.Drawing.Size(780, 253);
            this.dbGrid_Detail.SQL = null;
            this.dbGrid_Detail.SuperVirtualMode = false;
            this.dbGrid_Detail.TabIndex = 6;
            this.dbGrid_Detail.ReadOnlyChanged += new System.EventHandler(this.dbGrid_Detail_ReadOnlyChanged);
            // 
            // CU8cAlias
            // 
            this.CU8cAlias.DataPropertyName = "U8cAlias";
            this.CU8cAlias.HeaderText = "U8代码";
            this.CU8cAlias.Name = "CU8cAlias";
            this.CU8cAlias.ReadOnly = true;
            this.CU8cAlias.ToolTipText = "U8cAlias";
            // 
            // CU8cValue
            // 
            this.CU8cValue.DataPropertyName = "U8cValue";
            this.CU8cValue.HeaderText = "U8自定义值";
            this.CU8cValue.Name = "CU8cValue";
            this.CU8cValue.ReadOnly = true;
            this.CU8cValue.ToolTipText = "U8cValue";
            // 
            // CNewBx
            // 
            this.CNewBx.DataPropertyName = "NewBx";
            this.CNewBx.HeaderText = "新版型";
            this.CNewBx.Name = "CNewBx";
            this.CNewBx.ReadOnly = true;
            this.CNewBx.ToolTipText = "NewBx";
            this.CNewBx.Width = 130;
            // 
            // CTimestamp
            // 
            this.CTimestamp.DataPropertyName = "Timestamp";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.CTimestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.CTimestamp.HeaderText = "时间戳";
            this.CTimestamp.Name = "CTimestamp";
            this.CTimestamp.ReadOnly = true;
            this.CTimestamp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CTimestamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CTimestamp.Width = 150;
            // 
            // FrmBanXing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 288);
            this.Controls.Add(this.dbGrid_Detail);
            this.Controls.Add(this.EditToolBar);
            this.Name = "FrmBanXing";
            this.Load += new System.EventHandler(this.FrmBanXing_Load);
            this.EditToolBar.ResumeLayout(false);
            this.EditToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Donlim.Controls.EditToolStrip EditToolBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private Donlim.Controls.DBGrid dbGrid_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CU8cAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn CU8cValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNewBx;
        private Donlim.Controls.DBGrid.DataGridViewDateTimeColumn CTimestamp;
    }
}

