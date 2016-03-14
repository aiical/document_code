<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrintSignCard
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrintSignCard))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSaCode = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmode = New System.Windows.Forms.TextBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripDropDownButton
        Me.导出ExeclToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.导出Execl部门ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton6, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton7, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(672, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmode)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtSaCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 42)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(471, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "客户"
        Me.Label2.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(518, 9)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(143, 21)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(245, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "销售单号"
        '
        'txtSaCode
        '
        Me.txtSaCode.Location = New System.Drawing.Point(313, 9)
        Me.txtSaCode.Name = "txtSaCode"
        Me.txtSaCode.Size = New System.Drawing.Size(143, 21)
        Me.txtSaCode.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(672, 383)
        Me.Panel2.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(672, 383)
        Me.DataGridView1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "生产订单号"
        '
        'cmode
        '
        Me.cmode.Location = New System.Drawing.Point(85, 7)
        Me.cmode.Name = "cmode"
        Me.cmode.Size = New System.Drawing.Size(144, 21)
        Me.cmode.TabIndex = 5
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripButton1.Text = "打印预览"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(93, 22)
        Me.ToolStripButton6.Text = "打印预览(部门)"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton2.Text = "打印标识卡"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripButton3.Text = "打印标识(部门)卡"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(81, 22)
        Me.ToolStripButton4.Text = "查询其它订单"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.导出ExeclToolStripMenuItem, Me.导出Execl部门ToolStripMenuItem})
        Me.ToolStripButton7.Image = Global.UF_FS_SELON.My.Resources.Resources.export
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripButton7.Text = "导出Excel"
        '
        '导出ExeclToolStripMenuItem
        '
        Me.导出ExeclToolStripMenuItem.Name = "导出ExeclToolStripMenuItem"
        Me.导出ExeclToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.导出ExeclToolStripMenuItem.Text = "导出Execl"
        '
        '导出Execl部门ToolStripMenuItem
        '
        Me.导出Execl部门ToolStripMenuItem.Name = "导出Execl部门ToolStripMenuItem"
        Me.导出Execl部门ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.导出Execl部门ToolStripMenuItem.Text = "导出Execl(部门)"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(33, 22)
        Me.ToolStripButton5.Text = "退出"
        '
        'FormPrintSignCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormPrintSignCard"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "标识卡打印"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSaCode As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents 导出ExeclToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导出Execl部门ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
