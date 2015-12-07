namespace Common
{
    partial class frmGraphi
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
            DevExpress.XtraCharts.Bar3DSeriesLabel bar3DSeriesLabel1 = new DevExpress.XtraCharts.Bar3DSeriesLabel();
            this.Chart = new DevExpress.XtraCharts.ChartControl();
            this.sbPrint = new DevExpress.XtraEditors.SimpleButton();
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart
            // 
            this.Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart.Location = new System.Drawing.Point(12, 50);
            this.Chart.Name = "Chart";
            this.Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            bar3DSeriesLabel1.HiddenSerializableString = "to be serialized";
            bar3DSeriesLabel1.Visible = true;
            this.Chart.SeriesTemplate.Label = bar3DSeriesLabel1;
            this.Chart.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.Chart.Size = new System.Drawing.Size(672, 423);
            this.Chart.TabIndex = 0;
            // 
            // sbPrint
            // 
            this.sbPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbPrint.Location = new System.Drawing.Point(442, 12);
            this.sbPrint.Name = "sbPrint";
            this.sbPrint.Size = new System.Drawing.Size(75, 23);
            this.sbPrint.TabIndex = 1;
            this.sbPrint.Text = "打印(&P)";
            this.sbPrint.Click += new System.EventHandler(this.sbPrint_Click);
            // 
            // sbExport
            // 
            this.sbExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbExport.Location = new System.Drawing.Point(523, 12);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(75, 23);
            this.sbExport.TabIndex = 2;
            this.sbExport.Text = "引出(&E)";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // sbClose
            // 
            this.sbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbClose.Location = new System.Drawing.Point(609, 12);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(75, 23);
            this.sbClose.TabIndex = 3;
            this.sbClose.Text = "关闭(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // frmGraphi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(696, 485);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbExport);
            this.Controls.Add(this.sbPrint);
            this.Controls.Add(this.Chart);
            this.Name = "frmGraphi";
            this.Text = "图表专家";
            this.Load += new System.EventHandler(this.frmGraphi_Load);
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl Chart;
        private DevExpress.XtraEditors.SimpleButton sbPrint;
        private DevExpress.XtraEditors.SimpleButton sbExport;
        private DevExpress.XtraEditors.SimpleButton sbClose;
    }
}
