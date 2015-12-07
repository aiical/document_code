namespace Common
{
    partial class frmSetGrid
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.PopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsLoadFormDict = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveToDict = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.CheckBox();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.cbGroup = new System.Windows.Forms.CheckBox();
            this.cbSum = new System.Windows.Forms.CheckBox();
            this.ckMerge = new System.Windows.Forms.CheckBox();
            this.F_ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_ColumnCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Visible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.F_Merge = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.F_Format = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_SumType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.F_FootFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_GroupType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.F_GroupFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Edit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.PopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToResizeRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_ColumnName,
            this.F_ColumnCaption,
            this.F_Visible,
            this.F_Merge,
            this.F_Format,
            this.F_SumType,
            this.F_FootFormat,
            this.F_GroupType,
            this.F_GroupFormat,
            this.F_Edit});
            this.Grid.ContextMenuStrip = this.PopMenu;
            this.Grid.Location = new System.Drawing.Point(12, 12);
            this.Grid.Name = "Grid";
            this.Grid.RowHeadersVisible = false;
            this.Grid.RowHeadersWidth = 15;
            this.Grid.RowTemplate.Height = 23;
            this.Grid.Size = new System.Drawing.Size(656, 401);
            this.Grid.TabIndex = 0;
            // 
            // PopMenu
            // 
            this.PopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLoadFormDict,
            this.tsSaveToDict});
            this.PopMenu.Name = "PopMenu";
            this.PopMenu.Size = new System.Drawing.Size(155, 48);
            // 
            // tsLoadFormDict
            // 
            this.tsLoadFormDict.Name = "tsLoadFormDict";
            this.tsLoadFormDict.Size = new System.Drawing.Size(154, 22);
            this.tsLoadFormDict.Text = "从数据字典加载";
            this.tsLoadFormDict.Click += new System.EventHandler(this.tsLoadFormDict_Click);
            // 
            // tsSaveToDict
            // 
            this.tsSaveToDict.Name = "tsSaveToDict";
            this.tsSaveToDict.Size = new System.Drawing.Size(154, 22);
            this.tsSaveToDict.Text = "保存到数据字典";
            this.tsSaveToDict.Click += new System.EventHandler(this.tsSaveToDict_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定(&O)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.AutoSize = true;
            this.cbFilter.Location = new System.Drawing.Point(12, 423);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(48, 16);
            this.cbFilter.TabIndex = 3;
            this.cbFilter.Text = "过滤";
            this.cbFilter.UseVisualStyleBackColor = true;
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(66, 423);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(72, 16);
            this.cbAuto.TabIndex = 4;
            this.cbAuto.Text = "自动列宽";
            this.cbAuto.UseVisualStyleBackColor = true;
            // 
            // cbGroup
            // 
            this.cbGroup.AutoSize = true;
            this.cbGroup.Location = new System.Drawing.Point(144, 423);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(72, 16);
            this.cbGroup.TabIndex = 5;
            this.cbGroup.Text = "分组面板";
            this.cbGroup.UseVisualStyleBackColor = true;
            // 
            // cbSum
            // 
            this.cbSum.AutoSize = true;
            this.cbSum.Location = new System.Drawing.Point(222, 423);
            this.cbSum.Name = "cbSum";
            this.cbSum.Size = new System.Drawing.Size(72, 16);
            this.cbSum.TabIndex = 6;
            this.cbSum.Text = "合计面板";
            this.cbSum.UseVisualStyleBackColor = true;
            // 
            // ckMerge
            // 
            this.ckMerge.AutoSize = true;
            this.ckMerge.Location = new System.Drawing.Point(295, 423);
            this.ckMerge.Name = "ckMerge";
            this.ckMerge.Size = new System.Drawing.Size(72, 16);
            this.ckMerge.TabIndex = 7;
            this.ckMerge.Text = "允许合并";
            this.ckMerge.UseVisualStyleBackColor = true;
            // 
            // F_ColumnName
            // 
            this.F_ColumnName.HeaderText = "列名";
            this.F_ColumnName.Name = "F_ColumnName";
            this.F_ColumnName.ReadOnly = true;
            this.F_ColumnName.Width = 70;
            // 
            // F_ColumnCaption
            // 
            this.F_ColumnCaption.HeaderText = "列标题";
            this.F_ColumnCaption.Name = "F_ColumnCaption";
            this.F_ColumnCaption.Width = 80;
            // 
            // F_Visible
            // 
            this.F_Visible.HeaderText = "可见";
            this.F_Visible.Name = "F_Visible";
            this.F_Visible.Width = 40;
            // 
            // F_Merge
            // 
            this.F_Merge.HeaderText = "合并";
            this.F_Merge.Name = "F_Merge";
            this.F_Merge.Width = 35;
            // 
            // F_Format
            // 
            this.F_Format.HeaderText = "格式";
            this.F_Format.Name = "F_Format";
            this.F_Format.Width = 60;
            // 
            // F_SumType
            // 
            this.F_SumType.HeaderText = "合计类型";
            this.F_SumType.Items.AddRange(new object[] {
            "合计",
            "统计",
            "平均",
            "最大值",
            "最小值",
            "自定义",
            "(无)"});
            this.F_SumType.Name = "F_SumType";
            this.F_SumType.Width = 75;
            // 
            // F_FootFormat
            // 
            this.F_FootFormat.HeaderText = "合计格式";
            this.F_FootFormat.Name = "F_FootFormat";
            this.F_FootFormat.Width = 75;
            // 
            // F_GroupType
            // 
            this.F_GroupType.HeaderText = "分组合计类型";
            this.F_GroupType.Items.AddRange(new object[] {
            "合计",
            "统计",
            "平均",
            "最大值",
            "最小值",
            "自定义",
            "(无)"});
            this.F_GroupType.Name = "F_GroupType";
            this.F_GroupType.Width = 60;
            // 
            // F_GroupFormat
            // 
            this.F_GroupFormat.HeaderText = "分组格式";
            this.F_GroupFormat.Name = "F_GroupFormat";
            this.F_GroupFormat.Width = 70;
            // 
            // F_Edit
            // 
            this.F_Edit.HeaderText = "可编辑";
            this.F_Edit.Name = "F_Edit";
            this.F_Edit.Width = 60;
            // 
            // frmSetGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(678, 454);
            this.Controls.Add(this.cbSum);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ckMerge);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.cbAuto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbFilter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetGrid";
            this.Text = "表格格式设置";
            this.Load += new System.EventHandler(this.frmSetGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.PopMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbFilter;
        private System.Windows.Forms.CheckBox cbAuto;
        private System.Windows.Forms.CheckBox cbGroup;
        private System.Windows.Forms.CheckBox cbSum;
        private System.Windows.Forms.CheckBox ckMerge;
        private System.Windows.Forms.ContextMenuStrip PopMenu;
        private System.Windows.Forms.ToolStripMenuItem tsLoadFormDict;
        private System.Windows.Forms.ToolStripMenuItem tsSaveToDict;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_ColumnCaption;
        private System.Windows.Forms.DataGridViewCheckBoxColumn F_Visible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn F_Merge;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_Format;
        private System.Windows.Forms.DataGridViewComboBoxColumn F_SumType;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_FootFormat;
        private System.Windows.Forms.DataGridViewComboBoxColumn F_GroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_GroupFormat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn F_Edit;
    }
}
