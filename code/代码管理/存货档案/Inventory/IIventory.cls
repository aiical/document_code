VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "IIventory"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Option Explicit
'修改1 实现接口
Implements UFPortalProxyInterface.ILoginable

'查询数据集
Public Event EventOpenX(ByVal strSql As String, ByRef Rst As Variant, ByRef sMsg As Variant)
'查询分页数据集
Public Event EventOpenPage(ByVal strSql As String, iPageSize As Long, ByRef lCurPage As Long, ByRef lMaxPageCount As Long, ByRef RsRef As Variant, ByRef sMsg As String, ByRef bFlag As Boolean)
'获得加锁
Public Event EventGetFunAuth(ByVal oLogin As Variant, ByVal sArch As String, ByVal bIsLock As Integer, ByRef sErr As String, ByVal OptId As Integer, ByVal sAuth_Id As String, ByVal iYear As Integer, ByRef bFlag As Boolean)
'添加档案
Public Event EventAdd(ByVal sXML As String, ByVal tableName As String, ByRef sMsg As Variant, ByRef bErr As Variant)
'修改档案
Public Event EventModify(ByVal sXML As String, ByVal tableName As String, ByRef sMsg As Variant, ByRef bErr As Variant)
'删除档案
Public Event EventDelete(ByVal ID As Variant, ByVal IDName As String, ByVal tableName As String, ByRef sMsg As Variant, ByVal cUserId As String, ByRef bErr As Variant)
'过滤数据集
Public Event EventFind(ByVal sXML As String, FindTableName() As String, ShowTableName() As String, ByRef sMsg As Variant, ByRef Rst As Variant)
'命令行
Public Event EventExecuteX(ByVal strSql As String, ByRef bFlag As Variant)
'返回当前栏目设置的XML字符串
Public Event EventGetColInfo(ByVal cKey As String, ByVal iReturnMode As Byte, ByRef sXML As Variant)
'返回当前栏目设置的记录级
Public Event EventGetColSet(ByVal cKey As String, ByVal iReturnMode As Byte, ByRef Rs As Variant)
'保存栏目设置
Public Event EventSave(sXML As String, ByRef bFlag As Variant)
'返回拚好的Select 串
Public Event EventGetSqlString(ByVal sXML As String, ByRef strSql As Variant)
'返回拚好的排序字符串
Public Event EventGetOrderString(ByVal sXML As String, ByRef str As String)
'返回列数
Public Event EventiCols(ByRef col As Variant)
'返回固定列数
Public Event EventGetFixedCols(ByRef fixCol As Variant)
'获得权限
Public Event EventGetAuthString(ByVal tableName As String, ByRef sId As Variant)

Public bTimeOut As Boolean 'Web是否超时
Dim m_oBusiness As Object
Dim m_bFirstCreateObj As Boolean
Dim m_objLog As Object '日志传入的参数对象


'修改2 实现Business属性
Public Property Get Business() As Object
    Set Business = m_oBusiness
End Property

Public Property Set Business(ByRef bBus As Object)
    Set m_oBusiness = bBus
End Property

Public Sub ShowModeless(ByVal cMenuId As String, ByVal cMenuName As String, ByVal cAuthId As String, ByVal cCmdLine As String)
    Call Init(m_oBusiness.GetVBclsLogin())
    If CreateObj(0, g_oLogin.cUserId, g_oLogin.cUserName, g_oLogin.UfDbName, False) = False Then Exit Sub
    Call m_oBusiness.ShowForm(FrmMain, "AA", "FrmInv_key", True, False)
    Call ReleaseObj
End Sub



'修改4 转发相关调用
Private Function ILoginable_CallFunction(ByVal cMenuId As String, ByVal cMenuName As String, ByVal cAuthId As String, ByVal cCmdLine As String) As Object
    Call ShowModeless(cMenuId, cMenuName, cAuthId, cCmdLine)
End Function

Public Function Login(oLogin As Object) As Boolean
    Login = True
End Function

Public Function LogOff() As Boolean
    LogOff = True
End Function

Private Function ILoginable_Login() As Boolean
    ILoginable_Login = True
End Function

Private Function ILoginable_LogOff() As Boolean
    ILoginable_LogOff = True
End Function
'---------------------------------------
'服务对象：限C/S调用
Public Sub ShowByCS(oLogin As Object)
    Call Init(oLogin)
    Call Show(0, oLogin.cUserId, oLogin.cUserName, oLogin.UfDbName, False)
End Sub
'---------------------------------------

'---------------------------------------
'服务对象：限C/S调用
'功能：初始化对象
'参数：oLogin：U8Login.clsLogin对象
'---------------------------------------
Public Sub Init(oLogin As Object)
    On Error GoTo Err_Info
    Set g_oLogin = oLogin
    g_CurDate = CStr(oLogin.CurDate)
    g_URL = ""
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

'---------------------------------------
'服务对象：限B/S调用
'功能：初始化对象
'参数：sXml:    各种参数的Xml串
'---------------------------------------
Public Sub InitWeb(sXML As String)
    On Error GoTo Err_Info
    If g_oPub Is Nothing Then
        Set g_oPub = CreateObject("U8Pub.IPub")
    End If
    Call g_oPub.UtoLCase(sXML)
    Dim Dom As New DOMDocument
    Dim Ele As IXMLDOMElement
    If Not Dom.loadXML(sXML) Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.xmlloaderror") '
        Exit Sub
    End If
    Set Ele = Dom.documentElement
    g_CurDate = g_oPub.geteleval(Ele, "curdate")
    g_URL = g_oPub.geteleval(Ele, "url") + "?refid="
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

'---------------------------------------
'服务对象：web、C/S公用用
'功能: DLL对外接口
'参数: hWndParent: 窗口句柄
'cUserId:     用户ID
'cUserName:      用户名称
'cDBName:      数据库连接串
'     bIsWeb:是否为Web调用：true：Web调用；False：C/S调用（默认）
'---------------------------------------
Public Sub Show(ByVal hWndParent As Long, ByVal cUserId As String, ByVal cUserName As String, ByVal cDBName As String, Optional bIsWeb As Boolean = False)
    If CreateObj(hWndParent, cUserId, cUserName, cDBName, bIsWeb) = False Then Exit Sub
    FrmMain.Show vbModal
    Call ReleaseObj
End Sub

Public Function CreateObj(ByVal hWndParent As Long, ByVal cUserId As String, ByVal cUserName As String, ByVal cDBName As String, Optional bIsWeb As Boolean = False) As Boolean
    On Error Resume Next '目的捕获对象是否正确创建
    bTimeOut = False
    Set FrmMain = New FrmInv
    g_bIsWeb = bIsWeb
    g_bPage = True
    g_cUserId = cUserId
    g_cUserName = cUserName
    g_UfDbName = cDBName
    
    If bIsWeb = True Then
        g_CallType = enuWebCall
    Else
        g_CallType = enuCSCall
    End If
    
    
    Set FrmMain.m_cls = Me
    
    If g_oPub Is Nothing Then
        Set g_oPub = CreateObject("U8Pub.IPub")
        m_bFirstCreateObj = True
    Else
        m_bFirstCreateObj = False
    End If
    If g_oPub Is Nothing Then
        MsgBox "not find u8pub.dll", vbOKOnly + vbInformation, "Information"
        Exit Function
    End If
    If bIsWeb = True Then
        Set g_oLogin = Nothing
        g_hWndParent = hWndParent
        MAXPAGESIZE = 200
        Set SrvDB = Me
        If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 1) = True Then
            Exit Function
        End If
        Set g_ColSet = Me
        Set g_rowAuth = Me
    Else
        'g_bIsWeb = True ' testing  for Web
        If CreateCSObject = False Then Exit Function
        MAXPAGESIZE = 1000000000
    End If
    
    Call InitColAuthSet
    Call g_oPub.InitArchEditParam(SrvDB, "Inventory", g_PermitAddInventory, g_PermitModifyInventory)
    g_DbSrvDate = g_oPub.GetSrvTime(SrvDB)
    CreateObj = True
End Function


'--------------------------------------------------------
'功能：创建CS调用的公用对象
'--------------------------------------------------------
Private Function CreateCSObject() As Boolean
    On Error Resume Next
    If m_bFirstCreateObj = False Then
        CreateCSObject = True
        Exit Function
    End If
    CreateCSObject = False
    Set SrvDB = CreateObject("U8SrvTrans.IClsCommon")
    If SrvDB Is Nothing Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.loadsrvdbfail") '"创建数据库连接对象失败！"
        Exit Function
    End If
    'Call SrvDB.InitNew(g_oLogin)
    Call SrvDB.Init(g_UfDbName)
    If SrvDB.Status = False Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.dbconnectfail") '"数据库连接失败！"
        Exit Function
    End If
    If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 1) = True Then
        Call ReleaseObj '可能一些操作员没有权限，故强制释放
        Exit Function
    End If
    Set g_ColSet = CreateObject("U8ColumnSetSvr.clsColsetsvr")
    If g_ColSet Is Nothing Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.loadcolsetsvrfail") '"创建栏目设置对象失败！"
        Exit Function
    End If
    g_ColSet.Init g_UfDbName, g_cUserId
    
    Set g_rowAuth = g_oLogin.RowAuth
    Set g_colAuth = g_oLogin.ColAuth
    CreateCSObject = True
End Function

'------------------------------------------
'功能：供应商档案增加操作
'参数： oLogin：    Login对象
'       sXmlData    保存的数据
'       bSaved      是否正确保存
'       opt：       操作类型：1：增加；2：修改；－1删除;3查看；
'------------------------------------------
Public Sub Operating(oLogin As Object, ByRef sXmlData As String, Optional ByRef bSaved As Boolean, Optional ByRef opt As Integer = 1)
    
    Select Case opt
        Case 1
            g_CallType = enuAddCall
        Case 3
            g_CallType = enuBrowse
        Case 4
            g_CallType = enuBrowseLog
        Case Else
            MsgBox "only provide add function now!" '"目前只实现增加或查询功能!"
            Exit Sub
    End Select
    On Error Resume Next
    
    Call Init(oLogin)
    g_cUserId = oLogin.cUserId
    g_cUserName = oLogin.cUserName
    g_UfDbName = oLogin.UfDbName
    
    
    Set FrmMain = New FrmInv
    If opt = 1 Then
        FrmMain.m_bEdit = True
    End If
    Set FrmMain.m_cls = Me
        
        
    If g_oPub Is Nothing Then
        Set g_oPub = CreateObject("U8Pub.IPub")
        m_bFirstCreateObj = True
    Else
        m_bFirstCreateObj = False
    End If
    If g_oPub Is Nothing Then
        MsgBox "not find u8pub.dll", vbOKOnly + vbInformation, "Information"
        Exit Sub
    End If
    Call g_oPub.Init(oLogin) '目的初始化元数据库名m_MetaDBNameDot
    If CreateCSObject = False Then Exit Sub
    
    MAXPAGESIZE = 10000
        
    InitColAuthSet
    g_DbSrvDate = g_oPub.GetSrvTime(SrvDB)
'    If (g_sRFldAuthInv = "1=2") Or (g_sRFldAuthInv = "(1=2)") Then
'        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.IIVENTORY.162_1") 'U8.AA.INVENTORY.IIVENTORY.162_1="你没有被分配任何存货档案字段权限，不可使用存货档案!"
'        Call ReleaseObj
'        Exit Sub
'    End If
    If opt = 4 Then
        '
    Else
        Dim Dom As New DOMDocument
        Call g_oPub.UtoLCase(sXmlData)
        If Dom.loadXML(sXmlData) = False Then
            ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.xmlloaderror") '"提供的数据格式不正确！"
            Exit Sub
        End If
    End If
    If opt <> 3 And opt <> 4 Then
        If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 2) = True Then
            Exit Sub
        End If
        Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
    End If
    g_bSaved = False
    Dim Frm As New FrmZAM
    If opt = 4 Then
        If Frm.Init(10 + opt, Nothing, m_objLog) = False Then Exit Sub
    Else
        If Frm.Init(10 + opt, Dom.documentElement.selectSingleNode("inventory")) = False Then Exit Sub
    End If
    Frm.Show vbModal
    sXmlData = Frm.m_SaveXML
    bSaved = g_bSaved
    Call ReleaseObj
End Sub

'---------------------------------------------------
'功能：显示删除日志
'---------------------------------------------------
Public Sub ShowDelLog(objLog As Object)
    Set m_objLog = objLog
    Call Operating(objLog.Login, "", False, 4)
End Sub

Private Sub ReleaseObj()
    On Error Resume Next
    If m_bFirstCreateObj = True Then
        Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -1)
        g_cFormat = ""
        Set g_oPub = Nothing
        Set g_ColSet = Nothing
        Set g_rowAuth = Nothing
        Set g_colAuth = Nothing
        Set g_oLogin = Nothing
        Set SrvDB = Nothing
        Set FrmMain = Nothing
    End If
End Sub


'----------------------------------
'功能：对于Web登录操作超时，关闭所有窗口
'----------------------------------
Private Sub DestroyFrm()
    If g_bIsWeb = True And bTimeOut = True Then
        On Error Resume Next
        Do While Not (Screen.ActiveForm Is Nothing)
            Unload Screen.ActiveForm
        Loop
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.logintimeout") '"操作超时，请重新登录！"
    End If
End Sub

'---------------------------------------------------
' 功能：获取功能权限
'参数：oLogin：U8Login.clsLogin对象
'       sArch:档案名称（数据库表名）
'       bIsLock：是否锁定（－1：添加、修改、删除用；0：释放功能权限）
'       OptId:操作Id（查询1、编辑2、并户3、审核4）
'       sErr:错误信息
'返回：申请成功：true；申请不成功：false
'---------------------------------------------------
Public Function GetFunAuth(ByVal oLogin As Variant, ByVal sArch As String, ByVal bIsLock As Integer, Optional ByRef sErr As String = "", Optional ByVal OptId As Integer, Optional ByVal sAuth_Id As String, Optional ByVal iYear As Integer) As Boolean
    Dim bFlag As Boolean
    RaiseEvent EventGetFunAuth(Nothing, sArch, bIsLock, sErr, OptId, sAuth_Id, iYear, bFlag)
    GetFunAuth = bFlag
End Function


 
'---------------------------------------
'功能：Sql查询
'参数：StrSql：查询语句
'---------------------------------------
Public Function OpenX(strSql As String) As ADODB.Recordset
    Screen.MousePointer = vbHourglass
    Dim sMsg As String
    Dim Rs As New ADODB.Recordset
    RaiseEvent EventOpenX(strSql, Rs, sMsg)
    Set OpenX = Rs
    Screen.MousePointer = vbDefault
    DestroyFrm
End Function

'---------------------------------------
'功能：分页查询
'参数：StrSql：查询语句
'---------------------------------------
Public Sub OpenPage(ByVal strSql As String, lPageSize As Long, ByRef lCurPage As Long, ByRef lMaxPageCount As Long, ByRef RsRef As ADODB.Recordset, Optional ByRef sMsg As String, Optional ByRef bFlag As Boolean = False, Optional bRef As Boolean = False)
    Screen.MousePointer = vbHourglass
    FrmMain.Stb.Panels(1).Text = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.loadingdata") ' "正在加载数据，请稍等......"
    'If g_bPage = True Then
    If g_bIsWeb = True Then
        If SrvDB Is Me Then
            RaiseEvent EventOpenPage(strSql, lPageSize, lCurPage, lMaxPageCount, RsRef, sMsg, bFlag)
        Else
            Call SrvDB.OpenPage(strSql, lPageSize, lCurPage, lMaxPageCount, RsRef, sMsg, bFlag)
        End If
        If bRef = False Then
            FrmMain.EdtiCurPage = CStr(lCurPage)
            MaxPageCount = lMaxPageCount
            FrmMain.UpDown2.Max = MaxPageCount
            ReDim g_arr(1 To 1)
            g_arr(1) = CStr(lMaxPageCount)
            FrmMain.EdtiCurPage.UTooltipText = g_oPub.GetResFormatString("U8.AA.ARCHIVE.BUTTON.sumpages", g_arr) '"共 '" + CStr(lMaxPageCount) + "' 页"
            FrmMain.LblTotalPage = g_oPub.GetResFormatString("U8.AA.ARCHIVE.BUTTON.sumpages", g_arr) '"共 '" + CStr(lMaxPageCount) + "' 页"
            FrmMain.EdtiCurPage = CStr(lCurPage)
            If MaxPageCount <= 1 Then
                Call FrmMain.LblPageEnabled(False, False)
            Else
                Call FrmMain.LblPageEnabled(True, True)
            End If
        End If
    Else
        Set RsRef = SrvDB.OpenX(strSql)
    End If
    'FrmMain.Stb.Panels(2).Text = "当前记录数：" + CStr(RsRef.RecordCount) + " 条"
    FrmMain.Stb.Panels(1).Text = FrmMain.Stb.Panels(1).Tag
    Screen.MousePointer = vbDefault
    DestroyFrm
End Sub

'---------------------------------------
'功能：添加档案
'参数：sXML：符合XML格式字符串，包含添加信息
'       TableName:操作对象（表名称）
'       sMsg:添加时出现不符合要求的信息（操作错误提示！）
'返回：true：操作成功；false：操作失败
'---------------------------------------
Public Function Add(ByVal sXML As String, ByVal tableName As String, ByRef sMsg As String) As Boolean
    Dim bFlag As Boolean
    Call g_oPub.ConvertValidStr(sXML) '特殊处理
    RaiseEvent EventAdd(sXML, tableName, sMsg, bFlag)
    Add = bFlag
    DestroyFrm
End Function

'---------------------------------------
'功能：修改档案
'参数：sXML：符合XML格式字符串，包含添加信息
'       TableName:操作对象（表名称）
'       sMsg:添加时出现不符合要求的信息（操作错误提示！）
'返回：true：操作成功；false：操作失败
'---------------------------------------
Public Function Modify(ByVal sXML As String, ByVal tableName As String, ByRef sMsg As String) As Boolean
    Dim bFlag As Boolean
    Call g_oPub.ConvertValidStr(sXML) '特殊处理
    RaiseEvent EventModify(sXML, tableName, sMsg, bFlag)
    Modify = bFlag
    DestroyFrm
End Function


'---------------------------------------
'功能：删除档案
'参数：Id：修改的ID值（通常是编码）
'       IDName：修改ID字段数据库名
'       TableName:操作对象（表名称）
'       sMsg:添加时出现不符合要求的信息（操作错误提示！）
'返回：true：操作成功；false：操作失败
'---------------------------------------
Public Function Delete(ByVal ID As Variant, ByVal IDName As String, ByVal tableName As String, ByRef sMsg As String, Optional cUserId As String) As Boolean
    Dim bFlag As Boolean
    RaiseEvent EventDelete(ID, IDName, tableName, sMsg, cUserId, bFlag)
    Delete = bFlag
    DestroyFrm
End Function


'---------------------------------------
'功能：查询档案
'参数：sXML：XML格式字符流
'     TableName():操作的对象名称（表名）（数组）
'     ShowTables():显示表对象（数组）
'     sMsg:操作出现的各种信息，提供返回消息
'     Find:返回查询的数据集
'---------------------------------------
Public Function Find(ByVal sXML As String, FindTable() As String, ShowTable() As String, ByRef sMsg As String) As ADODB.Recordset
    Dim Rst As ADODB.Recordset
    RaiseEvent EventFind(sXML, FindTable, ShowTable, sMsg, Rst)
    Set Find = Rst
    DestroyFrm
End Function

'---------------------------------------
'功能：命令行执行
'参数：StrExec：命令行
'返回：true：成功操作；false：操作失败
'---------------------------------------
Public Function ExecuteX(ByVal strSql As String) As Boolean
    Dim bFlag As Boolean
    RaiseEvent EventExecuteX(strSql, bFlag)
    ExecuteX = bFlag
    DestroyFrm
End Function


'=============================================================
'说明：
'  以下部分为栏目设置
'=============================================================



'----------------------------------------
'返回当前栏目设置的XML字符串
'参数:cKey 表关键字
'    iReturnMode返回模式,可选 , 默认0
'    0返回所有列
'    1返回所有列+选择列
'    2只返回显示列
'    3返回默认列
'-----------------------------------------
Public Function getColInfo(ByVal cKey As String, Optional ByVal iReturnMode As Byte = 0) As String
    Dim sXML As String
    RaiseEvent EventGetColInfo(cKey, iReturnMode, sXML)
    getColInfo = sXML
    DestroyFrm
End Function
'-----------------------------------------------
'返回当前栏目设置的记录级
'参数:cKey 表关键字
'     iReturnMode可选 , 默认0
'    0返回所有列
'    1返回所有列(含选择列)
'    2只返回显示列
'    3返回默认列
'-----------------------------------------------
Public Function getColSet(ByVal cKey As String, Optional ByVal iReturnMode As Byte = 0) As ADODB.Recordset
    Dim Rs As ADODB.Recordset
    RaiseEvent EventGetColSet(cKey, iReturnMode, Rs)
    Set getColSet = Rs
    DestroyFrm
End Function

'----------------------------------------------
'保存栏目设置
'参数: sXml 栏目设置的XML字符串
'-----------------------------------------------
Public Function Save(sXML As String) As Boolean
    Dim bFlag As Boolean
    RaiseEvent EventSave(sXML, bFlag)
    Save = bFlag
    DestroyFrm
End Function

'---------------------------------------------
'返回拚好的Select 串
'参数:无
'---------------------------------------------
Public Function GetSqlString(ByVal sXML As String) As String
    Dim strSql As String
    RaiseEvent EventGetSqlString(sXML, strSql)
    GetSqlString = strSql
    DestroyFrm
End Function

'---------------------------------------------
'返回拚好的排序字符串
'参数:sXML:格式字符串
'---------------------------------------------
Public Function GetOrderString(ByVal sXML As String) As String
    Dim str As String
    RaiseEvent EventGetOrderString(sXML, str)
    GetOrderString = str
    DestroyFrm
End Function

'----------------------------------------------
'返回列数
'----------------------------------------------
Public Function iCols() As Long
    Dim lCols As Long
    RaiseEvent EventiCols(lCols)
    iCols = lCols
    DestroyFrm
End Function

'----------------------------------------------
'返回固定列数
'----------------------------------------------
Public Function GetFixedCols() As Long
    Dim lFixCols As Long
    RaiseEvent EventGetFixedCols(lFixCols)
    GetFixedCols = lFixCols
    DestroyFrm
End Function

'---------------------------------------
'功能：获得各表的记录权限
'参数：TableName：使用的表名
'返回：返回权限的条件字符串
'---------------------------------------
Public Function GetAuthString(ByVal tableName As String) As String
    Dim sTemp As String
    RaiseEvent EventGetAuthString(tableName, sTemp)
    GetAuthString = sTemp
    DestroyFrm
End Function

'---------------------------------------
'功能：获得各表的记录权限(返回编码)
'参数：TableName：使用的表名
'返回：返回权限的条件字符串
'---------------------------------------
Public Function GetAuthStringCode(cBusObId As String, Optional cClassCode, Optional cFuncID As String, Optional bIsUserCode As Boolean) As String
    GetAuthStringCode = g_oPub.GetAuthStringCodeWeb(cBusObId, SrvDB, g_cUserId, cClassCode, cFuncID, bIsUserCode)
    DestroyFrm
End Function

Private Sub Class_Initialize()
    '防止Web没有调用InitWeb(sXML As String)
    g_CurDate = Date
    g_cusVer = CustomerVersions.enuCommon
    g_PermitAddInventory = True
    g_PermitModifyInventory = True
    'g_cusVer = CustomerVersions.enuRefFreeMulti
End Sub
