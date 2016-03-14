Imports System.Data
Imports System.Data.SqlClient

Public Class FormPrintSignCard

    Dim mDexcelTab = New DataTable()
    Dim m_ExcelPath As String
    Dim m_mcode As String

    Public Sub New(ByVal mDataTab As DataTable, ByVal mExcelPath As String, ByVal mMcode As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        m_ExcelPath = mExcelPath

        m_mcode = mMcode

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.BackColor = Drawing.Color.FromArgb(196, 216, 240)
        Me.ToolStrip1.BackColor = Me.BackColor

        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Me.BackColor

        mDexcelTab = ChageDataTab(mDataTab)

        BindDataGrid(mDexcelTab)

    End Sub

    '退出
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.Close()
    End Sub


    '按数量设置显示数据表
    Private Function ChageDataTab(ByRef mTab As DataTable) As DataTable
        Dim mDataTab = New DataTable()
        mDataTab = mTab.Copy()

        mDataTab.Columns.Remove("iquantity")
        mDataTab.Rows.Clear()

        For Each mrow As DataRow In mTab.Rows
            If (CInt(mrow("iquantity")) > 0) Then
                For mI As Integer = 1 To CInt(mrow("iquantity"))
                    Dim mAdRow = mDataTab.NewRow
                    mAdRow("cPid") = mrow("cPid")
                    mAdRow("cDepName") = mrow("cDepName")
                    mAdRow("cName") = mrow("cName")
                    mAdRow("dName") = mrow("dName")
                    'mAdRow("isex") = mrow("isex")
                    mDataTab.Rows.Add(mAdRow)
                    mDataTab.AcceptChanges()
                Next
            End If
        Next

        ChageDataTab = mDataTab

    End Function


    '绑定数据
    Private Sub BindDataGrid(ByVal mTab As DataTable)

        DataGridView1.Columns.Clear()


        Dim mCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        mCol.DataPropertyName = "cPid"
        mCol.HeaderText = "标识编号"
        mCol.SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns.Add(mCol)


        Dim mCDeptName = New System.Windows.Forms.DataGridViewTextBoxColumn
        mCDeptName.DataPropertyName = "cDepName"
        mCDeptName.HeaderText = "部门"
        mCDeptName.SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns.Add(mCDeptName)

        Dim mcName = New System.Windows.Forms.DataGridViewTextBoxColumn
        mcName.DataPropertyName = "cName"
        mcName.HeaderText = "姓名"
        mcName.SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns.Add(mcName)

        Dim mdName = New System.Windows.Forms.DataGridViewTextBoxColumn
        mdName.DataPropertyName = "dName"
        mdName.HeaderText = "制服类型"
        mdName.SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns.Add(mdName)

        'Dim mcCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        'mcCode.DataPropertyName = "isex"
        'mcCode.HeaderText = "性别"
        'mcCode.SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns.Add(mcCode)
        'mcCode.Visible = False

        DataGridView1.ReadOnly = True

        DataGridView1.RowTemplate.Resizable = Windows.Forms.DataGridViewTriState.False

        DataGridView1.RowHeadersVisible = False

        DataGridView1.BackgroundColor = Drawing.Color.White

        DataGridView1.DataSource = mTab

        mTab.DefaultView.AllowNew = False

        'DataGridView1.Focus()

    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'TabToExcel.DataTabToExcel(mDexcelTab, m_ExcelPath, txtSaCode.Text, True, False, False)
        TabToExcel.DataTabToExcel(mDexcelTab, m_ExcelPath, m_mcode, True, False, False)
    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'DataTabToExcel(mDexcelTab, m_ExcelPath, txtSaCode.Text, True, True, False)
        DataTabToExcel(mDexcelTab, m_ExcelPath, m_mcode, True, True, False)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'DataTabToExcel(mDexcelTab, m_ExcelPath, txtSaCode.Text, False, False, False)
        DataTabToExcel(mDexcelTab, m_ExcelPath, m_mcode, False, False, False)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        'DataTabToExcel(mDexcelTab, m_ExcelPath, txtSaCode.Text, False, True, False)
        DataTabToExcel(mDexcelTab, m_ExcelPath, m_mcode, False, True, False)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        If (txtSaCode.Text.Length > 0) Then
            Dim mSelectstr = "select cCode,cPID,cDepName,cName,isnull(iquantity,0) as iquantity ,dName  from selonuinform.dbo.v_Tailordetail   where sacode='" + txtSaCode.Text + "'   order by dName,cPID "

            mDexcelTab = ChageDataTab(GetSizemainTab(txtSaCode.Text, mCnn, CommandType.Text, mSelectstr))

            BindDataGrid(mDexcelTab)
        Else
            MsgBox("当前销售单号无对应数据，请查正。", MsgBoxStyle.Information, "标识卡打印查询")
        End If

    End Sub


    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        'TabToExcel.DataTabToExcel(mDexcelTab, m_ExcelPath, txtSaCode.Text, False, False, True)
    End Sub

    Private Sub 导出ExeclToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导出ExeclToolStripMenuItem.Click
        'TabToExcel.DataTabToExcel(mDexcelTab, m_ExcelPath, txtSaCode.Text, False, False, True)
        TabToExcel.DataTabToExcel(mDexcelTab, m_ExcelPath, m_mcode, False, False, True)
    End Sub

    Private Sub 导出Execl部门ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导出Execl部门ToolStripMenuItem.Click
        'TabToExcel.DataTabToExcel(mDexcelTab, m_ExcelPath, txtSaCode.Text, False, True, True)
        TabToExcel.DataTabToExcel(mDexcelTab, m_ExcelPath, m_mcode, False, True, True)
    End Sub
End Class