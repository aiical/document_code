Public Class FormWait

    Private m_Index As Integer = 0

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.BackColor = Drawing.Color.White
        Me.Label1.BackColor = Drawing.Color.White
        ' Me.Label1.Width = Me.Width
        Me.Label1.TextAlign = Drawing.ContentAlignment.MiddleCenter

        'Timer1.Enabled = True

        'Timer1_Tick(Timer1, System.EventArgs.Empty)
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If (Me.Label1.Width >= 168) Then
        '    Me.Label1.Width = 18
        'End If
        'Me.Label1.Width = Me.Label1.Width + 10
        m_Index = m_Index + 1

        Me.Label1.Text = "正在打印中，用时" + m_Index.ToString() + "秒"

        Me.Refresh()
    End Sub
End Class