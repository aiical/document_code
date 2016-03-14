<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelonGrid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelonGrid))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.ChkCombinePrint = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RbDispDif = New System.Windows.Forms.RadioButton
        Me.RbDispAll = New System.Windows.Forms.RadioButton
        Me.RbDispReal = New System.Windows.Forms.RadioButton
        Me.BtPrint = New System.Windows.Forms.Button
        Me.RdBtWomen = New System.Windows.Forms.RadioButton
        Me.RdBtMen = New System.Windows.Forms.RadioButton
        Me.RdBtAll = New System.Windows.Forms.RadioButton
        Me.BTTypeChange = New System.Windows.Forms.Button
        Me.txtcCusName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CKTypeList = New System.Windows.Forms.CheckedListBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.C1FlexGrid1)
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1025, 455)
        Me.Panel1.TabIndex = 0
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.BackColor = System.Drawing.SystemColors.Window
        Me.C1FlexGrid1.ColumnInfo = "10,1,0,0,0,90,Columns:"
        Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexGrid1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Size = New System.Drawing.Size(1025, 455)
        Me.C1FlexGrid1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("C1FlexGrid1.Styles"))
        Me.C1FlexGrid1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnPreview)
        Me.Panel2.Controls.Add(Me.ChkCombinePrint)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.BtPrint)
        Me.Panel2.Controls.Add(Me.RdBtWomen)
        Me.Panel2.Controls.Add(Me.RdBtMen)
        Me.Panel2.Controls.Add(Me.RdBtAll)
        Me.Panel2.Controls.Add(Me.BTTypeChange)
        Me.Panel2.Controls.Add(Me.txtcCusName)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1028, 44)
        Me.Panel2.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(889, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "导出Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(960, 10)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(65, 24)
        Me.btnPreview.TabIndex = 24
        Me.btnPreview.Text = "打印预览"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'ChkCombinePrint
        '
        Me.ChkCombinePrint.AutoSize = True
        Me.ChkCombinePrint.Checked = True
        Me.ChkCombinePrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCombinePrint.Location = New System.Drawing.Point(458, 10)
        Me.ChkCombinePrint.Name = "ChkCombinePrint"
        Me.ChkCombinePrint.Size = New System.Drawing.Size(96, 16)
        Me.ChkCombinePrint.TabIndex = 23
        Me.ChkCombinePrint.Text = "是否合并打印"
        Me.ChkCombinePrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbDispDif)
        Me.GroupBox1.Controls.Add(Me.RbDispAll)
        Me.GroupBox1.Controls.Add(Me.RbDispReal)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(560, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 42)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "打印选项"
        Me.GroupBox1.Visible = False
        '
        'RbDispDif
        '
        Me.RbDispDif.AutoSize = True
        Me.RbDispDif.Location = New System.Drawing.Point(190, 18)
        Me.RbDispDif.Name = "RbDispDif"
        Me.RbDispDif.Size = New System.Drawing.Size(71, 16)
        Me.RbDispDif.TabIndex = 21
        Me.RbDispDif.TabStop = True
        Me.RbDispDif.Text = "差异尺寸"
        Me.RbDispDif.UseVisualStyleBackColor = True
        '
        'RbDispAll
        '
        Me.RbDispAll.AutoSize = True
        Me.RbDispAll.Location = New System.Drawing.Point(7, 16)
        Me.RbDispAll.Name = "RbDispAll"
        Me.RbDispAll.Size = New System.Drawing.Size(83, 16)
        Me.RbDispAll.TabIndex = 19
        Me.RbDispAll.TabStop = True
        Me.RbDispAll.Text = "实际和差异"
        Me.RbDispAll.UseVisualStyleBackColor = True
        '
        'RbDispReal
        '
        Me.RbDispReal.AutoSize = True
        Me.RbDispReal.Location = New System.Drawing.Point(101, 18)
        Me.RbDispReal.Name = "RbDispReal"
        Me.RbDispReal.Size = New System.Drawing.Size(71, 16)
        Me.RbDispReal.TabIndex = 20
        Me.RbDispReal.TabStop = True
        Me.RbDispReal.Text = "实际尺寸"
        Me.RbDispReal.UseVisualStyleBackColor = True
        '
        'BtPrint
        '
        Me.BtPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtPrint.Location = New System.Drawing.Point(823, 11)
        Me.BtPrint.Name = "BtPrint"
        Me.BtPrint.Size = New System.Drawing.Size(62, 24)
        Me.BtPrint.TabIndex = 17
        Me.BtPrint.Text = "打印报表"
        Me.BtPrint.UseVisualStyleBackColor = True
        Me.BtPrint.Visible = False
        '
        'RdBtWomen
        '
        Me.RdBtWomen.AutoSize = True
        Me.RdBtWomen.Location = New System.Drawing.Point(326, 16)
        Me.RdBtWomen.Name = "RdBtWomen"
        Me.RdBtWomen.Size = New System.Drawing.Size(47, 16)
        Me.RdBtWomen.TabIndex = 15
        Me.RdBtWomen.TabStop = True
        Me.RdBtWomen.Text = "女装"
        Me.RdBtWomen.UseVisualStyleBackColor = True
        '
        'RdBtMen
        '
        Me.RdBtMen.AutoSize = True
        Me.RdBtMen.Location = New System.Drawing.Point(279, 16)
        Me.RdBtMen.Name = "RdBtMen"
        Me.RdBtMen.Size = New System.Drawing.Size(47, 16)
        Me.RdBtMen.TabIndex = 14
        Me.RdBtMen.TabStop = True
        Me.RdBtMen.Text = "男装"
        Me.RdBtMen.UseVisualStyleBackColor = True
        '
        'RdBtAll
        '
        Me.RdBtAll.AutoSize = True
        Me.RdBtAll.Location = New System.Drawing.Point(232, 16)
        Me.RdBtAll.Name = "RdBtAll"
        Me.RdBtAll.Size = New System.Drawing.Size(47, 16)
        Me.RdBtAll.TabIndex = 13
        Me.RdBtAll.TabStop = True
        Me.RdBtAll.Text = "全部"
        Me.RdBtAll.UseVisualStyleBackColor = True
        '
        'BTTypeChange
        '
        Me.BTTypeChange.Location = New System.Drawing.Point(379, 10)
        Me.BTTypeChange.Name = "BTTypeChange"
        Me.BTTypeChange.Size = New System.Drawing.Size(67, 27)
        Me.BTTypeChange.TabIndex = 12
        Me.BTTypeChange.Text = "版型选择"
        Me.BTTypeChange.UseVisualStyleBackColor = True
        '
        'txtcCusName
        '
        Me.txtcCusName.Enabled = False
        Me.txtcCusName.Location = New System.Drawing.Point(65, 14)
        Me.txtcCusName.Name = "txtcCusName"
        Me.txtcCusName.Size = New System.Drawing.Size(105, 21)
        Me.txtcCusName.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "客户名称"
        '
        'CKTypeList
        '
        Me.CKTypeList.CheckOnClick = True
        Me.CKTypeList.FormattingEnabled = True
        Me.CKTypeList.Location = New System.Drawing.Point(931, 37)
        Me.CKTypeList.Name = "CKTypeList"
        Me.CKTypeList.Size = New System.Drawing.Size(153, 20)
        Me.CKTypeList.TabIndex = 16
        Me.CKTypeList.Visible = False
        '
        'Button3
        '
        Me.Button3.Image = Global.UF_FS_SELON.My.Resources.Resources.query_to_voucher
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(176, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(51, 23)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "查询"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmSelonGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 511)
        Me.Controls.Add(Me.CKTypeList)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelonGrid"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "制服尺寸表"
        Me.Panel1.ResumeLayout(False)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtcCusName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTTypeChange As System.Windows.Forms.Button
    Friend WithEvents RdBtWomen As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtMen As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtAll As System.Windows.Forms.RadioButton
    Friend WithEvents CKTypeList As System.Windows.Forms.CheckedListBox
    Friend WithEvents BtPrint As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbDispDif As System.Windows.Forms.RadioButton
    Friend WithEvents RbDispAll As System.Windows.Forms.RadioButton
    Friend WithEvents RbDispReal As System.Windows.Forms.RadioButton
    Friend WithEvents ChkCombinePrint As System.Windows.Forms.CheckBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
