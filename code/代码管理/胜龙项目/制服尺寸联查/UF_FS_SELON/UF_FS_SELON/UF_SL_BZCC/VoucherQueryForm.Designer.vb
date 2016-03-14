<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VoucherQueryForm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cDepName = New System.Windows.Forms.TextBox
        Me.BtcDepName = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtcName = New System.Windows.Forms.Button
        Me.cName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BtcInvCode = New System.Windows.Forms.Button
        Me.cInvCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BtBxMc = New System.Windows.Forms.Button
        Me.BxMc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.cDfName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.BtcDfName = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "部门"
        '
        'cDepName
        '
        Me.cDepName.BackColor = System.Drawing.SystemColors.Window
        Me.cDepName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cDepName.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.cDepName.Location = New System.Drawing.Point(71, 16)
        Me.cDepName.Name = "cDepName"
        Me.cDepName.Size = New System.Drawing.Size(138, 16)
        Me.cDepName.TabIndex = 11
        '
        'BtcDepName
        '
        Me.BtcDepName.Location = New System.Drawing.Point(209, 11)
        Me.BtcDepName.Name = "BtcDepName"
        Me.BtcDepName.Size = New System.Drawing.Size(24, 24)
        Me.BtcDepName.TabIndex = 0
        Me.BtcDepName.Tag = "部门"
        Me.BtcDepName.Text = "…"
        Me.BtcDepName.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Font = New System.Drawing.Font("宋体", 1.0!)
        Me.Panel1.Location = New System.Drawing.Point(71, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 1)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Font = New System.Drawing.Font("宋体", 1.0!)
        Me.Panel2.Location = New System.Drawing.Point(302, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(157, 1)
        Me.Panel2.TabIndex = 7
        '
        'BtcName
        '
        Me.BtcName.Location = New System.Drawing.Point(441, 11)
        Me.BtcName.Name = "BtcName"
        Me.BtcName.Size = New System.Drawing.Size(24, 24)
        Me.BtcName.TabIndex = 1
        Me.BtcName.Tag = "员工姓名"
        Me.BtcName.Text = "…"
        Me.BtcName.UseVisualStyleBackColor = True
        '
        'cName
        '
        Me.cName.BackColor = System.Drawing.SystemColors.Window
        Me.cName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cName.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.cName.Location = New System.Drawing.Point(302, 16)
        Me.cName.Name = "cName"
        Me.cName.Size = New System.Drawing.Size(138, 16)
        Me.cName.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(265, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "员工"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Font = New System.Drawing.Font("宋体", 1.0!)
        Me.Panel3.Location = New System.Drawing.Point(71, 72)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(157, 1)
        Me.Panel3.TabIndex = 11
        '
        'BtcInvCode
        '
        Me.BtcInvCode.Location = New System.Drawing.Point(209, 49)
        Me.BtcInvCode.Name = "BtcInvCode"
        Me.BtcInvCode.Size = New System.Drawing.Size(24, 24)
        Me.BtcInvCode.TabIndex = 2
        Me.BtcInvCode.Tag = "存货编码"
        Me.BtcInvCode.Text = "…"
        Me.BtcInvCode.UseVisualStyleBackColor = True
        '
        'cInvCode
        '
        Me.cInvCode.BackColor = System.Drawing.SystemColors.Window
        Me.cInvCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cInvCode.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.cInvCode.Location = New System.Drawing.Point(71, 55)
        Me.cInvCode.Name = "cInvCode"
        Me.cInvCode.Size = New System.Drawing.Size(138, 16)
        Me.cInvCode.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "存货编码"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Font = New System.Drawing.Font("宋体", 1.0!)
        Me.Panel4.Location = New System.Drawing.Point(302, 72)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(157, 1)
        Me.Panel4.TabIndex = 15
        '
        'BtBxMc
        '
        Me.BtBxMc.Location = New System.Drawing.Point(441, 49)
        Me.BtBxMc.Name = "BtBxMc"
        Me.BtBxMc.Size = New System.Drawing.Size(24, 24)
        Me.BtBxMc.TabIndex = 3
        Me.BtBxMc.Tag = "制服版型"
        Me.BtBxMc.Text = "…"
        Me.BtBxMc.UseVisualStyleBackColor = True
        '
        'BxMc
        '
        Me.BxMc.BackColor = System.Drawing.SystemColors.Window
        Me.BxMc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BxMc.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.BxMc.Location = New System.Drawing.Point(302, 54)
        Me.BxMc.Name = "BxMc"
        Me.BxMc.Size = New System.Drawing.Size(138, 16)
        Me.BxMc.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "版型"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Font = New System.Drawing.Font("宋体", 1.0!)
        Me.Panel5.Location = New System.Drawing.Point(302, 110)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(157, 1)
        Me.Panel5.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "性别"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Font = New System.Drawing.Font("宋体", 1.0!)
        Me.Panel6.Location = New System.Drawing.Point(71, 110)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(157, 1)
        Me.Panel6.TabIndex = 19
        '
        'cDfName
        '
        Me.cDfName.BackColor = System.Drawing.SystemColors.Window
        Me.cDfName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cDfName.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.cDfName.Location = New System.Drawing.Point(71, 91)
        Me.cDfName.Name = "cDfName"
        Me.cDfName.Size = New System.Drawing.Size(138, 16)
        Me.cDfName.TabIndex = 51
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "尺码"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(151, 144)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(79, 24)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "确定"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(266, 144)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(79, 24)
        Me.Button6.TabIndex = 25
        Me.Button6.Text = "取消"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'BtcDfName
        '
        Me.BtcDfName.Location = New System.Drawing.Point(209, 87)
        Me.BtcDfName.Name = "BtcDfName"
        Me.BtcDfName.Size = New System.Drawing.Size(24, 24)
        Me.BtcDfName.TabIndex = 4
        Me.BtcDfName.Tag = "尺码"
        Me.BtcDfName.Text = "…"
        Me.BtcDfName.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"全部", "男", "女"})
        Me.ComboBox1.Location = New System.Drawing.Point(302, 87)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(157, 20)
        Me.ComboBox1.TabIndex = 5
        '
        'VoucherQueryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BtcDfName)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.cDfName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.BtBxMc)
        Me.Controls.Add(Me.BxMc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.BtcInvCode)
        Me.Controls.Add(Me.cInvCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtcName)
        Me.Controls.Add(Me.cName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtcDepName)
        Me.Controls.Add(Me.cDepName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "VoucherQueryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "自设查询条件"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cDepName As System.Windows.Forms.TextBox
    Friend WithEvents BtcDepName As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtcName As System.Windows.Forms.Button
    Friend WithEvents cName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtcInvCode As System.Windows.Forms.Button
    Friend WithEvents cInvCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtBxMc As System.Windows.Forms.Button
    Friend WithEvents BxMc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cDfName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents BtcDfName As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
