namespace AutoEntity
{
    partial class AutoEntity
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
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbotable = new System.Windows.Forms.ComboBox();
            this.lbltale = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.btntrue = new System.Windows.Forms.Button();
            this.btnentity = new System.Windows.Forms.Button();
            this.lblnamespase = new System.Windows.Forms.Label();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(89, 25);
            this.txtpwd.MaxLength = 20;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(64, 21);
            this.txtpwd.TabIndex = 0;
            this.txtpwd.Text = "laowu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库密码：";
            // 
            // cboDB
            // 
            this.cboDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDB.Enabled = false;
            this.cboDB.FormattingEnabled = true;
            this.cboDB.Items.AddRange(new object[] {
            "请选择数库"});
            this.cboDB.Location = new System.Drawing.Point(315, 20);
            this.cboDB.Name = "cboDB";
            this.cboDB.Size = new System.Drawing.Size(141, 20);
            this.cboDB.TabIndex = 3;
            this.cboDB.SelectionChangeCommitted += new System.EventHandler(this.cboDB_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "数据库名称：";
            // 
            // cbotable
            // 
            this.cbotable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotable.Enabled = false;
            this.cbotable.FormattingEnabled = true;
            this.cbotable.Location = new System.Drawing.Point(253, 60);
            this.cbotable.Name = "cbotable";
            this.cbotable.Size = new System.Drawing.Size(100, 20);
            this.cbotable.TabIndex = 4;
            this.cbotable.SelectionChangeCommitted += new System.EventHandler(this.cbotable_SelectionChangeCommitted);
            // 
            // lbltale
            // 
            this.lbltale.AutoSize = true;
            this.lbltale.Location = new System.Drawing.Point(206, 63);
            this.lbltale.Name = "lbltale";
            this.lbltale.Size = new System.Drawing.Size(41, 12);
            this.lbltale.TabIndex = 1;
            this.lbltale.Text = "表名：";
            // 
            // txtEntity
            // 
            this.txtEntity.Location = new System.Drawing.Point(10, 126);
            this.txtEntity.MaxLength = 20;
            this.txtEntity.Multiline = true;
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEntity.Size = new System.Drawing.Size(471, 280);
            this.txtEntity.TabIndex = 0;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtNameSpace);
            this.gbInfo.Controls.Add(this.btntrue);
            this.gbInfo.Controls.Add(this.cbotable);
            this.gbInfo.Controls.Add(this.cboDB);
            this.gbInfo.Controls.Add(this.txtpwd);
            this.gbInfo.Controls.Add(this.btnentity);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.lblnamespase);
            this.gbInfo.Controls.Add(this.lbltale);
            this.gbInfo.Location = new System.Drawing.Point(12, 12);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(469, 100);
            this.gbInfo.TabIndex = 5;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "填写信息";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(95, 60);
            this.txtNameSpace.MaxLength = 20;
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(105, 21);
            this.txtNameSpace.TabIndex = 6;
            this.txtNameSpace.Text = "Model";
            // 
            // btntrue
            // 
            this.btntrue.Location = new System.Drawing.Point(159, 23);
            this.btntrue.Name = "btntrue";
            this.btntrue.Size = new System.Drawing.Size(45, 23);
            this.btntrue.TabIndex = 5;
            this.btntrue.Text = "确定";
            this.btntrue.UseVisualStyleBackColor = true;
            this.btntrue.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnentity
            // 
            this.btnentity.Enabled = false;
            this.btnentity.Location = new System.Drawing.Point(374, 51);
            this.btnentity.Name = "btnentity";
            this.btnentity.Size = new System.Drawing.Size(82, 36);
            this.btnentity.TabIndex = 2;
            this.btnentity.Text = "生成实体类";
            this.btnentity.UseVisualStyleBackColor = true;
            this.btnentity.Click += new System.EventHandler(this.btnentity_Click);
            // 
            // lblnamespase
            // 
            this.lblnamespase.AutoSize = true;
            this.lblnamespase.Location = new System.Drawing.Point(7, 63);
            this.lblnamespase.Name = "lblnamespase";
            this.lblnamespase.Size = new System.Drawing.Size(89, 12);
            this.lblnamespase.TabIndex = 1;
            this.lblnamespase.Text = "命名空间名称：";
            // 
            // saveFile
            // 
            this.saveFile.DereferenceLinks = false;
            this.saveFile.Filter = "CS文档(*.cs)|*.cs";
            this.saveFile.Title = "保存实体";
            // 
            // AutoEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(497, 418);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.txtEntity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AutoEntity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自动生成实体类";
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbotable;
        private System.Windows.Forms.Label lbltale;
        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Button btnentity;
        private System.Windows.Forms.Button btntrue;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label lblnamespase;
    }
}

