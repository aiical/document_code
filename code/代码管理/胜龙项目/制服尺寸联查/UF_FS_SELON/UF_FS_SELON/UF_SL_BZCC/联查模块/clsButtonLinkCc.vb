Imports System.Data
Imports System.Data.SqlClient


Public Class clsButtonLinkCc
    Public Function RunCommand(ByVal objLogin As Object, ByVal objForm As Object, ByVal objVoucher As Object, ByVal sKey As String, ByVal VarentValue As Object, ByVal other As String) As Boolean

        If (objLogin Is Nothing) Then
            Windows.Forms.MessageBox.Show("未正常登录，不能联查！", "销售订单联查提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            Exit Function
        Else
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
        Dim currDB As String
        currDB = GetCurrentDB(objLogin.ufdbname.ToString())

        Dim mSelectstr As String = "select cPID,cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + mCCode + "'  order by iRowNo "

        Select Case sKey
            Case "_CUSTDEFUNSelect"    '销售订单  主表名 SO_SOMain  订单号 cSOCode 

                If (JudgeCodeExit(objVoucher.headerText("cSOCode").ToString(), True, objVoucher) = True) Then
                    mCCode = objVoucher.headerText("cSOCode").ToString()
                    'mSelectstr = "select cPID,cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + mCCode + "'  order by iRowNo "
                    mSelectstr = "select cPID,cDepName,cName,isex,a.*,b.cAlias from selonuinform.dbo.v_Tailordetail a left join " + currDB + ".dbo.userdefine b on a.cdfname = b.cValue where sacode='" + mCCode + "'  order by iRowNo "
                    mMaintab = GetSizemainTab(mCCode, mCnn, CommandType.Text, mSelectstr)
                    mSetGridTab = GetSizemainTab(mCCode, mCnn, CommandType.StoredProcedure, "")
                Else
                    Exit Function
                End If

            Case "_CUSTDEFUN0411Select"   ' 产成品入库单子表视图  recordinsq         销售订单订单号 iordercode

                If (JudgeCodeExit("iordercode", False, objVoucher)) Then
                    mCCode = objVoucher.bodyText(1, "iordercode")
                    'mSelectstr = "select cPID,cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + mCCode + "'  order by iRowNo "
                    mSelectstr = "select cPID,cDepName,cName,isex,a.*,b.cAlias from selonuinform.dbo.v_Tailordetail a left join " + currDB + ".dbo.userdefine b on a.cdfname = b.cValue where sacode='" + mCCode + "'  order by iRowNo "
                    mMaintab = GetSizemainTab(mCCode, mCnn, CommandType.Text, mSelectstr)
                    mSetGridTab = GetSizemainTab(mCCode, mCnn, CommandType.StoredProcedure, "")
                Else
                    Exit Function
                End If

            Case "_CUSTDEFUNMO21Select"    '  生产订单 子表 mom_orderdetail  销售订单订单号 DOrderCode

                If (JudgeCodeExit("DOrderCode", False, objVoucher)) Then
                    mCCode = objVoucher.bodyText(1, "DOrderCode")
                    'mSelectstr = "select cPID,cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + mCCode + "' order by iRowNo "
                    mSelectstr = "select cPID,cDepName,cName,isex,a.*,b.cAlias from selonuinform.dbo.v_Tailordetail a left join " + currDB + ".dbo.userdefine b on a.cdfname = b.cValue where sacode='" + mCCode + "'  order by ccode "
                    'mMaintab = GetSizemainTab(mCCode, mCnn, CommandType.Text, mSelectstr) 'GetMarkmainTab
                    mMaintab = GetMarkmainTab(mCCode, mCnn, CommandType.Text, mSelectstr)
                    mSetGridTab = GetSizemainTab(mCCode, mCnn, CommandType.StoredProcedure, "")
                Else
                    Exit Function
                End If

        End Select

        For Each rr As DataRow In mSetGridTab.Rows
            For Each r As DataRow In mMaintab.Select("sid='" + rr("sid").ToString() + "'")
                r("ccode") = rr("ccode")
                mMaintab.AcceptChanges()
            Next
        Next




        Dim mFrmSelonGrid = New FrmSelonGrid(mMaintab, mSetGridTab, mCCode, currDB)

        If (sKey = "_CUSTDEFUNMO21Select") Then

            mFrmSelonGrid.GroupBox1.Visible = True
            mFrmSelonGrid.BtPrint.Visible = True
            mFrmSelonGrid.BtPrint.Tag = objVoucher.headerText("MoCode").ToString()


        End If

        '设置表头列序号
        SetDataGrid(mFrmSelonGrid.m_SetGridDataTab, mFrmSelonGrid.C1FlexGrid1, mSetGridTab)

        mFrmSelonGrid.Text = "单号： " + mCCode + " 之 " + mFrmSelonGrid.Text + " 联查"

        mFrmSelonGrid.ShowDialog()

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