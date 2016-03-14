Imports System.Data
Imports System.Data.SqlClient


Public Class clsPrintSignCard

    Public Function RunCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, ByVal sKey As String, ByVal VarentValue As Object, ByVal other As String) As Boolean

        Dim mExcelPath As String

        If (objLogin Is Nothing) Then
            Windows.Forms.MessageBox.Show("未正常登录，不能正常打印！", "标识卡打印提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            Exit Function
        Else

            mExcelPath = objLogin.GetIstallPath()

            txtConSQL = Replace(objLogin.ufdbname.ToString().ToUpper(), "Provider=SQLOLEDB;".ToUpper(), "")

            mCnn = New SqlClient.SqlConnection
            mCnn.ConnectionString = txtConSQL.ToLower()

            If (Not mCnn.State = ConnectionState.Open) Then
                mCnn.Open()
            End If

        End If

        Dim mMaintab As New DataTable()
        Dim mSetGridTab As New DataTable()
        Dim mCCode As String = String.Empty
        Dim mMcode As String = String.Empty

        Dim mSelectstr As String = "select  disccPID,cDepName,cName,isnull(iquantity,0) as iquantity ,dName  from selonuinform.dbo.v_Tailordetail  where sacode='" + mCCode + "'  order by dName,cPID "

        Select Case sKey

            Case "_CUSTDEFUN0411Select"   ' 


            Case "_CUSTDEFUNMO21Sign"    '  生产订单 子表 mom_orderdetail  销售订单订单号 DOrderCode

                If (JudgeCodeExit("DOrderCode", False, objVoucher)) Then
                    mCCode = objVoucher.bodyText(1, "DOrderCode")
                    mMcode = objVoucher.headerText("mocode")
                    mSelectstr = "select  cPID,cDepName,cName,isnull(iquantity,0) as iquantity ,dName  from selonuinform.dbo.v_Tailordetail   where sacode='" + mCCode + "'   order by dName,cPID "
                    'mMaintab = GetSizemainTab(mCCode, mCnn, CommandType.Text, mSelectstr) 'GetMarkmainTab
                    mMaintab = GetMarkmainTab(mCCode, mCnn, CommandType.Text, mSelectstr)
                Else
                    Exit Function
                End If

        End Select


        Dim mFormPrintSignCard = New FormPrintSignCard(mMaintab, mExcelPath, mMcode)
        mFormPrintSignCard.txtSaCode.Text = mCCode
        mFormPrintSignCard.cmode.Text = mMcode

        'Dim mFrmSelonGrid = New FrmSelonGrid(mMaintab, mSetGridTab, mCCode, mCCode)



        'If (sKey = "_CUSTDEFUNUNMO21Sign") Then

        '    mFrmSelonGrid.GroupBox1.Visible = True
        '    mFrmSelonGrid.BtPrint.Visible = True
        '    mFrmSelonGrid.BtPrint.Tag = objVoucher.headerText("MoCode").ToString()


        'End If

        '设置数据列表的格式
        'SetDataGridFormat(mFrmSelonGrid.C1FlexGrid1)

        '设置表头列序号
        'SetDataGrid(mFrmSelonGrid.m_SetGridDataTab, mFrmSelonGrid.C1FlexGrid1, mSetGridTab)

        'mFrmSelonGrid.Text = "单号： " + mCCode + " 之 " + mFrmSelonGrid.Text + " 联查"

        mFormPrintSignCard.ShowDialog()


    End Function


    Private Function JudgeCodeExit(ByVal mCode As String, ByVal mIsOrderList As Boolean, ByVal mobjVoucher As Object) As Boolean

        If (mIsOrderList) Then
            If (String.IsNullOrEmpty(mCode)) Then
                Windows.Forms.MessageBox.Show("目前尚未有订单号，不能联查！", "订单联查提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                JudgeCodeExit = False
                Exit Function
            End If
            JudgeCodeExit = True
        Else
            If (mobjVoucher.bodyRows > 0) Then

                For RowIndex As Integer = 1 To mobjVoucher.bodyRows

                    If (RowIndex = 1 And mobjVoucher.bodyText(1, mCode) Is Nothing) Then
                        Windows.Forms.MessageBox.Show("单据数据不正常，订单号为空，不能联查！", "订单联查提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                        JudgeCodeExit = False
                        Exit Function
                    Else
                        If (mobjVoucher.bodyText(1, mCode) = mobjVoucher.bodyText(RowIndex, mCode)) Then
                            Continue For
                        Else
                            Windows.Forms.MessageBox.Show("销售订单号有多个，有重复，联查失败！", "订单联查提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                            JudgeCodeExit = False
                            Exit Function
                        End If
                    End If
                Next
                JudgeCodeExit = True
            End If
        End If

    End Function



    Public Function Init(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, ByVal msbar As Object) As Boolean


    End Function

    Public Function BeforeRunSysCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, _
                            ByVal sKey As String, ByVal VarentValue As Object, ByRef Cancel As Boolean, ByVal other As String) As Boolean

    End Function

End Class