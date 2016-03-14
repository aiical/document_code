Imports System.Text

Public Class VoucherQueryForm

    Public m_ReturnStrquery As String
    Private m_Datatab As DataTable
    Private m_SetDatatab As DataTable

    Public m_SetGridDatatab As New DataTable()
    Private m_FilterStr(5) As String


    Public Sub New(ByVal mData As DataTable, ByVal mSetData As DataTable)

        m_Datatab = mData
        m_SetDatatab = mSetData
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        AddHandler Me.BtBxMc.Click, AddressOf Button1_Click
        AddHandler Me.BtcInvCode.Click, AddressOf Button1_Click
        AddHandler Me.BtcName.Click, AddressOf Button1_Click
        AddHandler Me.BtcDfName.Click, AddressOf Button1_Click

        cDepName.Focus()

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        For Each mFilstr As String In m_FilterStr
            If (Not mFilstr Is Nothing) Then
                m_ReturnStrquery += IIf(String.IsNullOrEmpty(m_ReturnStrquery), mFilstr, " and " + mFilstr)
            End If
        Next


        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtcDepName.Click

        Dim mButton As System.Windows.Forms.Button
        mButton = sender

        Dim mDataV = New DataTable()

        Select Case mButton.Name.Substring(2)
            Case "BxMc"
                If (Not m_SetDatatab Is Nothing) Then
                    mDataV = m_SetDatatab.DefaultView.ToTable(True, mButton.Name.Substring(2))
                End If
            Case Else
                If (Not m_Datatab Is Nothing) Then
                    mDataV = m_Datatab.DefaultView.ToTable(True, mButton.Name.Substring(2))
                End If
        End Select

        Dim mtextbox As System.Windows.Forms.TextBox
        mtextbox = CType(Me.Controls.Find(mButton.Name.Substring(2), True)(0), System.Windows.Forms.TextBox)

        Dim mRetForm = New ReturnSelectStr(mDataV, mButton.Name.Substring(2), mButton.Tag.ToString(), m_SetDatatab, mtextbox)

        mRetForm.ShowDialog()

        If (mRetForm.DialogResult = Windows.Forms.DialogResult.OK And Not mRetForm.m_FilterStr Is Nothing) Then
            m_FilterStr.SetValue(mRetForm.m_FilterStr, mButton.TabIndex)
            If (mRetForm.m_SetGridTab.Rows.Count > 0) Then
                m_SetGridDatatab = mRetForm.m_SetGridTab
            End If
        End If


    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted

        Select Case ComboBox1.SelectedItem
            Case "全部"
                m_FilterStr.SetValue(" 1=1 ", 5)
            Case "男"
                m_FilterStr.SetValue("iSex='男'", 5)
            Case "女"
                m_FilterStr.SetValue("iSex='女'", 5)
        End Select

    End Sub
End Class