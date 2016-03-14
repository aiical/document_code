Imports System.Data
Imports System.Data.SqlClient


Public Class ReturnSelectStr

    Public m_FilterStr As String
    Public m_mColumnNam As String
    Public m_SetGridTab As New System.Data.DataTable()
    Public m_MidSetGridTab As New DataTable()
    Private m_TextBox As System.Windows.Forms.TextBox



    Public Sub New(ByVal mTab As DataTable, ByVal mColumnNam As String, ByVal mColumnCaption As String, ByVal mSetDatatab As DataTable, ByRef mText As System.Windows.Forms.TextBox)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        m_SetGridTab = mSetDatatab.Copy()

        m_MidSetGridTab = mSetDatatab.Copy()

        m_SetGridTab.Rows.Clear()

        m_TextBox = mText

        m_mColumnNam = mColumnNam

        Dim mcol = New DataColumn
        mcol.Caption = "选择"
        mcol.ColumnName = "SeleCol"


        mcol.DataType = System.Type.GetType("System.Boolean")
        mTab.Columns.Add(mcol)



        DataGridView1.Columns.Clear()

        Dim mSelectcolum = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        mSelectcolum.DataPropertyName = "SeleCol"
        mSelectcolum.HeaderText = ""
        mSelectcolum.Width = 50

        DataGridView1.Columns.Add(mSelectcolum)



        Dim mSelectcolum1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        mSelectcolum1.DataPropertyName = mColumnNam
        mSelectcolum1.HeaderText = mColumnCaption
        mSelectcolum1.Width = 350
        DataGridView1.Columns.Add(mSelectcolum1)

        DataGridView1.RowHeadersVisible = False


        Me.DataGridView1.DataSource = mTab
        mTab.DefaultView.AllowNew = False


    End Sub


    Private Sub reurnFilstr()

        Dim mTab = New DataTable()
        mTab = DataGridView1.DataSource
        Dim mStrSb = New System.Text.StringBuilder()

        For Each mrow As DataRow In mTab.Rows
            If (mrow("SeleCol").ToString().ToUpper().Equals("TRUE")) Then
                mStrSb.Append(IIf(mStrSb.Length > 0, ",'" + mrow(m_mColumnNam).ToString() + "'", "'" + mrow(m_mColumnNam).ToString() + "'"))
                If (m_mColumnNam = "BxMc") Then
                    If (Not m_SetGridTab.Select("BxMc='" + mrow(m_mColumnNam).ToString() + "'").Length > 0) Then
                        If (m_MidSetGridTab.Select("BxMc='" + mrow(m_mColumnNam).ToString() + "'").Length > 0) Then
                            Dim mRrow As DataRow = m_SetGridTab.NewRow()
                            For Each mCN As DataColumn In m_SetGridTab.Columns
                                mRrow(mCN.ColumnName) = m_MidSetGridTab.Select("BxMc='" + mrow(m_mColumnNam).ToString() + "'")(0)(mCN.ColumnName)
                            Next
                            m_SetGridTab.Rows.Add(mRrow)
                            m_SetGridTab.AcceptChanges()
                        End If
                    End If
                End If

            End If
        Next


        If (m_mColumnNam = "BxMc") Then
            m_mColumnNam = "dName+'('+iName+')'"
        End If

        If (mStrSb.Length > 0) Then

            m_TextBox.Text = mStrSb.ToString().Replace("'", "")

            If (mTab.Select("SeleCol").Length > 1) Then
                m_FilterStr = m_mColumnNam + " in (" + mStrSb.ToString() + ")"
            Else
                m_FilterStr = m_mColumnNam + " = " + mStrSb.ToString()
            End If
        End If

        'm_FilterStr = IIf(mStrSb Is Nothing, Nothing, mStrSb.ToString())

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        reurnFilstr()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Close()
    End Sub

End Class