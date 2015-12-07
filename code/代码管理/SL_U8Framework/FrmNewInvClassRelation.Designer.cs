namespace SL_U8Framework
{
    partial class FrmNewInvClassRelation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewInvClassRelation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dbGrid_Master = new Donlim.Controls.DBGrid();
            this.CNewInvCCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNewInvCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbGrid_Relation = new Donlim.Controls.DBGrid();
            this.CoNewInvCCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoNewInvCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoInvCCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoInvCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbGrid_Detail = new Donlim.Controls.DBGrid();
            this.ColNewInvCCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNewInvCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPriceLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPriceSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStartPrice = new Donlim.Controls.DataGridViewNumEditColumn();
            this.ColEndPrice = new Donlim.Controls.DataGridViewNumEditColumn();
            this.EditToolBar = new Donlim.Controls.EditToolStrip(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Master)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Relation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Detail)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbGrid_Master
            // 
            this.dbGrid_Master.AllowUserToAddRows = false;
            this.dbGrid_Master.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGrid_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbGrid_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid_Master.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNewInvCCode,
            this.CNewInvCName});
            this.dbGrid_Master.Conn = null;
            this.dbGrid_Master.DataSet = null;
            this.dbGrid_Master.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbGrid_Master.Is_CnHeaderText = false;
            this.dbGrid_Master.Location = new System.Drawing.Point(0, 0);
            this.dbGrid_Master.Name = "dbGrid_Master";
            this.dbGrid_Master.ReadOnly = true;
            this.dbGrid_Master.RowTemplate.Height = 23;
            this.dbGrid_Master.ShowLineNumber = false;
            this.dbGrid_Master.Size = new System.Drawing.Size(284, 384);
            this.dbGrid_Master.SQL = null;
            this.dbGrid_Master.SuperVirtualMode = false;
            this.dbGrid_Master.TabIndex = 9;
            this.dbGrid_Master.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dbGrid_Master_CellMouseClick);
            this.dbGrid_Master.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGrid_Master_CellValidated);
            this.dbGrid_Master.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dbGrid_Relation_DataError);
            // 
            // CNewInvCCode
            // 
            this.CNewInvCCode.DataPropertyName = "NewInvCCode";
            this.CNewInvCCode.HeaderText = "新大类编码";
            this.CNewInvCCode.Name = "CNewInvCCode";
            this.CNewInvCCode.ReadOnly = true;
            this.CNewInvCCode.ToolTipText = "NewInvCCode";
            // 
            // CNewInvCName
            // 
            this.CNewInvCName.DataPropertyName = "NewInvCName";
            this.CNewInvCName.HeaderText = "新大类名称";
            this.CNewInvCName.Name = "CNewInvCName";
            this.CNewInvCName.ReadOnly = true;
            this.CNewInvCName.ToolTipText = "NewInvCName";
            this.CNewInvCName.Width = 180;
            // 
            // dbGrid_Relation
            // 
            this.dbGrid_Relation.AllowUserToAddRows = false;
            this.dbGrid_Relation.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGrid_Relation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dbGrid_Relation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid_Relation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoNewInvCCode,
            this.CoNewInvCName,
            this.CoInvCCode,
            this.CoInvCName});
            this.dbGrid_Relation.Conn = null;
            this.dbGrid_Relation.DataSet = null;
            this.dbGrid_Relation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbGrid_Relation.Is_CnHeaderText = false;
            this.dbGrid_Relation.Location = new System.Drawing.Point(0, 0);
            this.dbGrid_Relation.Name = "dbGrid_Relation";
            this.dbGrid_Relation.ReadOnly = true;
            this.dbGrid_Relation.RowTemplate.Height = 23;
            this.dbGrid_Relation.ShowLineNumber = false;
            this.dbGrid_Relation.Size = new System.Drawing.Size(564, 210);
            this.dbGrid_Relation.SQL = null;
            this.dbGrid_Relation.SuperVirtualMode = false;
            this.dbGrid_Relation.TabIndex = 10;
            this.dbGrid_Relation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dbGrid_Relation_DataError);
            // 
            // CoNewInvCCode
            // 
            this.CoNewInvCCode.DataPropertyName = "NewInvCCode";
            this.CoNewInvCCode.HeaderText = "新大类编码";
            this.CoNewInvCCode.Name = "CoNewInvCCode";
            this.CoNewInvCCode.ReadOnly = true;
            this.CoNewInvCCode.ToolTipText = "NewInvCCode";
            this.CoNewInvCCode.Visible = false;
            // 
            // CoNewInvCName
            // 
            this.CoNewInvCName.DataPropertyName = "NewInvCName";
            this.CoNewInvCName.HeaderText = "新大类名称";
            this.CoNewInvCName.Name = "CoNewInvCName";
            this.CoNewInvCName.ReadOnly = true;
            this.CoNewInvCName.ToolTipText = "NewInvCName";
            this.CoNewInvCName.Visible = false;
            // 
            // CoInvCCode
            // 
            this.CoInvCCode.DataPropertyName = "InvCCode";
            this.CoInvCCode.HeaderText = "U8大类编码";
            this.CoInvCCode.Name = "CoInvCCode";
            this.CoInvCCode.ReadOnly = true;
            this.CoInvCCode.ToolTipText = "InvCCode";
            // 
            // CoInvCName
            // 
            this.CoInvCName.DataPropertyName = "InvCName";
            this.CoInvCName.HeaderText = "U8大类名称";
            this.CoInvCName.Name = "CoInvCName";
            this.CoInvCName.ReadOnly = true;
            this.CoInvCName.ToolTipText = "InvCName";
            this.CoInvCName.Width = 150;
            // 
            // dbGrid_Detail
            // 
            this.dbGrid_Detail.AllowUserToAddRows = false;
            this.dbGrid_Detail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGrid_Detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dbGrid_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid_Detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNewInvCCode,
            this.ColNewInvCName,
            this.ColPriceLevel,
            this.ColPriceSort,
            this.ColStartPrice,
            this.ColEndPrice});
            this.dbGrid_Detail.Conn = null;
            this.dbGrid_Detail.DataSet = null;
            this.dbGrid_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbGrid_Detail.Is_CnHeaderText = false;
            this.dbGrid_Detail.Location = new System.Drawing.Point(0, 0);
            this.dbGrid_Detail.Name = "dbGrid_Detail";
            this.dbGrid_Detail.ReadOnly = true;
            this.dbGrid_Detail.RowTemplate.Height = 23;
            this.dbGrid_Detail.ShowLineNumber = false;
            this.dbGrid_Detail.Size = new System.Drawing.Size(564, 170);
            this.dbGrid_Detail.SQL = null;
            this.dbGrid_Detail.SuperVirtualMode = false;
            this.dbGrid_Detail.TabIndex = 11;
            this.dbGrid_Detail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dbGrid_Relation_DataError);
            // 
            // ColNewInvCCode
            // 
            this.ColNewInvCCode.DataPropertyName = "NewInvCCode";
            this.ColNewInvCCode.HeaderText = "新大类编码";
            this.ColNewInvCCode.Name = "ColNewInvCCode";
            this.ColNewInvCCode.ReadOnly = true;
            this.ColNewInvCCode.ToolTipText = "NewInvCCode";
            this.ColNewInvCCode.Visible = false;
            // 
            // ColNewInvCName
            // 
            this.ColNewInvCName.DataPropertyName = "NewInvCName";
            this.ColNewInvCName.HeaderText = "新大类名称";
            this.ColNewInvCName.Name = "ColNewInvCName";
            this.ColNewInvCName.ReadOnly = true;
            this.ColNewInvCName.ToolTipText = "NewInvCName";
            this.ColNewInvCName.Visible = false;
            // 
            // ColPriceLevel
            // 
            this.ColPriceLevel.DataPropertyName = "PriceLevel";
            this.ColPriceLevel.HeaderText = "PriceLevel";
            this.ColPriceLevel.Name = "ColPriceLevel";
            this.ColPriceLevel.ReadOnly = true;
            this.ColPriceLevel.ToolTipText = "PriceLevel";
            // 
            // ColPriceSort
            // 
            this.ColPriceSort.DataPropertyName = "PriceSort";
            this.ColPriceSort.HeaderText = "PriceSort";
            this.ColPriceSort.Name = "ColPriceSort";
            this.ColPriceSort.ReadOnly = true;
            this.ColPriceSort.ToolTipText = "PriceSort";
            this.ColPriceSort.Width = 60;
            // 
            // ColStartPrice
            // 
            this.ColStartPrice.DataPropertyName = "StartPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F0";
            this.ColStartPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColStartPrice.HeaderText = "StartPrice";
            this.ColStartPrice.Name = "ColStartPrice";
            this.ColStartPrice.ReadOnly = true;
            this.ColStartPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColStartPrice.ToolTipText = "StartPrice";
            // 
            // ColEndPrice
            // 
            this.ColEndPrice.DataPropertyName = "EndPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F0";
            this.ColEndPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColEndPrice.HeaderText = "EndPrice";
            this.ColEndPrice.Name = "ColEndPrice";
            this.ColEndPrice.ReadOnly = true;
            this.ColEndPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEndPrice.ToolTipText = "EndPrice";
            // 
            // EditToolBar
            // 
            this.EditToolBar.AuditState = Donlim.Controls.EditToolStripAuditState.Draft;
            this.EditToolBar.Location = new System.Drawing.Point(0, 0);
            this.EditToolBar.Name = "EditToolBar";
            this.EditToolBar.Size = new System.Drawing.Size(852, 35);
            this.EditToolBar.State = Donlim.Controls.EditToolStripState.DefaultState;
            this.EditToolBar.TabIndex = 2;
            this.EditToolBar.Text = "editToolStrip1";
            this.EditToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.EditToolBar_ItemClicked);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 35);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dbGrid_Master);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(852, 384);
            this.splitContainer3.SplitterDistance = 284;
            this.splitContainer3.TabIndex = 10;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dbGrid_Relation);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dbGrid_Detail);
            this.splitContainer4.Size = new System.Drawing.Size(564, 384);
            this.splitContainer4.SplitterDistance = 210;
            this.splitContainer4.TabIndex = 0;
            // 
            // FrmNewInvClassRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.EditToolBar);
            this.Name = "FrmNewInvClassRelation";
            this.Size = new System.Drawing.Size(852, 419);
            this.Load += new System.EventHandler(this.FrmNewInvClassRelation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Master)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Relation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid_Detail)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Donlim.Controls.DBGrid dbGrid_Master;
        private Donlim.Controls.DBGrid dbGrid_Relation;
        private Donlim.Controls.DBGrid dbGrid_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNewInvCCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNewInvCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoNewInvCCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoNewInvCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoInvCCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoInvCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewInvCCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewInvCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPriceLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPriceSort;
        private Donlim.Controls.DataGridViewNumEditColumn ColStartPrice;
        private Donlim.Controls.DataGridViewNumEditColumn ColEndPrice;
        private Donlim.Controls.EditToolStrip EditToolBar;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;

    }
}