namespace myControl
{
    partial class uLookUp
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.pContent = new DevExpress.XtraEditors.PopupContainerControl();
            this.gridQuery = new DevExpress.XtraGrid.GridControl();
            this.viewQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lbLabel = new System.Windows.Forms.Label();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pContent)).BeginInit();
            this.pContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // pEdit
            // 
            this.pEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pEdit.EnterMoveNextControl = true;
            this.pEdit.Location = new System.Drawing.Point(45, 0);
            this.pEdit.Name = "pEdit";
            this.pEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pEdit.Properties.CloseOnLostFocus = false;
            this.pEdit.Properties.PopupControl = this.pContent;
            this.pEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.pEdit.Size = new System.Drawing.Size(154, 21);
            this.pEdit.TabIndex = 3;
            this.pEdit.EditValueChanged += new System.EventHandler(this.pEdit_EditValueChanged);
            this.pEdit.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.pEdit_QueryResultValue);
            this.pEdit.QueryDisplayText += new DevExpress.XtraEditors.Controls.QueryDisplayTextEventHandler(this.pEdit_QueryDisplayText);
            this.pEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pEdit_KeyDown);
            this.pEdit.Popup += new System.EventHandler(this.pEdit_Popup);
            // 
            // pContent
            // 
            this.pContent.Controls.Add(this.gridQuery);
            this.pContent.Location = new System.Drawing.Point(3, 56);
            this.pContent.Name = "pContent";
            this.pContent.Size = new System.Drawing.Size(330, 186);
            this.pContent.TabIndex = 4;
            // 
            // gridQuery
            // 
            this.gridQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQuery.EmbeddedNavigator.Name = "";
            this.gridQuery.Location = new System.Drawing.Point(0, 0);
            this.gridQuery.MainView = this.viewQuery;
            this.gridQuery.Name = "gridQuery";
            this.gridQuery.Size = new System.Drawing.Size(330, 186);
            this.gridQuery.TabIndex = 0;
            this.gridQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewQuery});
            // 
            // viewQuery
            // 
            this.viewQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.viewQuery.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.viewQuery.GridControl = this.gridQuery;
            this.viewQuery.Name = "viewQuery";
            this.viewQuery.OptionsBehavior.Editable = false;
            this.viewQuery.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewQuery.OptionsView.ShowColumnHeaders = false;
            this.viewQuery.OptionsView.ShowGroupPanel = false;
            this.viewQuery.OptionsView.ShowHorzLines = false;
            this.viewQuery.OptionsView.ShowIndicator = false;
            this.viewQuery.Click += new System.EventHandler(this.viewQuery_Click);
            this.viewQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewQuery_KeyDown);
            // 
            // lbLabel
            // 
            this.lbLabel.AutoSize = true;
            this.lbLabel.Location = new System.Drawing.Point(0, 6);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(41, 12);
            this.lbLabel.TabIndex = 5;
            this.lbLabel.Text = "label1";
            // 
            // sbSelect
            // 
            this.sbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbSelect.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelect.Appearance.Options.UseFont = true;
            this.sbSelect.Location = new System.Drawing.Point(200, 0);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(20, 22);
            this.sbSelect.TabIndex = 6;
            this.sbSelect.TabStop = false;
            this.sbSelect.Text = "...";
            this.sbSelect.Click += new System.EventHandler(this.sbSelect_Click);
            // 
            // uLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.sbSelect);
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.pContent);
            this.Controls.Add(this.pEdit);
            this.Name = "uLookUp";
            this.Size = new System.Drawing.Size(222, 21);
            this.Resize += new System.EventHandler(this.uLookUp_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pContent)).EndInit();
            this.pContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerControl pContent;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        private System.Windows.Forms.Label lbLabel;
        public DevExpress.XtraEditors.PopupContainerEdit pEdit;
        public DevExpress.XtraGrid.GridControl gridQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewQuery;
    }
}
