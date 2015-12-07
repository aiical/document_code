VERSION 5.00
Object = "{9ADF72AD-DDA9-11D1-9D4B-000021006D51}#1.29#0"; "UFSpGrid.ocx"
Object = "{BF022F1C-E440-4790-987F-252926B9B602}#5.1#0"; "UFFrames.ocx"
Object = "{8C7C777D-4D83-4DE8-947E-098E2343A400}#1.0#0"; "CommandButton.ocx"
Begin VB.UserControl GridPage 
   ClientHeight    =   7020
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11415
   LockControls    =   -1  'True
   ScaleHeight     =   7020
   ScaleWidth      =   11415
   Begin UFFrames.UFFrame UFFrameTlb2 
      Height          =   495
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   11385
      _ExtentX        =   20082
      _ExtentY        =   873
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Begin UFCOMMANDBUTTONLib.UFCommandButton CmdBack 
         Height          =   345
         Left            =   930
         TabIndex        =   1
         Top             =   90
         Width           =   825
         _Version        =   65536
         _ExtentX        =   1455
         _ExtentY        =   609
         _StockProps     =   41
         Caption         =   "还原"
         UToolTipText    =   ""
         Cursor          =   30464
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Flat            =   0   'False
         Enabled         =   -1  'True
         Style           =   0   'False
         Value           =   0   'False
      End
      Begin UFCOMMANDBUTTONLib.UFCommandButton CmdAdd 
         Height          =   345
         Left            =   1755
         TabIndex        =   2
         Top             =   90
         Width           =   825
         _Version        =   65536
         _ExtentX        =   1455
         _ExtentY        =   609
         _StockProps     =   41
         Caption         =   "增行"
         UToolTipText    =   ""
         Cursor          =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Flat            =   0   'False
         Enabled         =   -1  'True
         Style           =   0   'False
         Value           =   0   'False
      End
      Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDel 
         Height          =   345
         Left            =   2580
         TabIndex        =   3
         Top             =   90
         Width           =   825
         _Version        =   65536
         _ExtentX        =   1455
         _ExtentY        =   609
         _StockProps     =   41
         Caption         =   "删行"
         UToolTipText    =   ""
         Cursor          =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Flat            =   0   'False
         Enabled         =   -1  'True
         Style           =   0   'False
         Value           =   0   'False
      End
      Begin UFCOMMANDBUTTONLib.UFCommandButton CmdPos 
         Height          =   345
         Left            =   90
         TabIndex        =   4
         Top             =   90
         Width           =   825
         _Version        =   65536
         _ExtentX        =   1455
         _ExtentY        =   609
         _StockProps     =   41
         Caption         =   "定位"
         UToolTipText    =   ""
         Cursor          =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Flat            =   0   'False
         Enabled         =   -1  'True
         Style           =   0   'False
         Value           =   0   'False
      End
   End
   Begin MsSuperGrid.SuperGrid Grid 
      Height          =   5085
      Left            =   0
      TabIndex        =   5
      Top             =   510
      Width           =   11385
      _ExtentX        =   20082
      _ExtentY        =   8969
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      EditBorderStyle =   0
      Redraw          =   1
      MouseIcon       =   "GridPage.ctx":0000
      ForeColorSel    =   -2147483634
      ForeColorFixed  =   -2147483630
      FixedCols       =   0
      BackColorSel    =   -2147483635
      BackColorFixed  =   -2147483633
      AllowUserResizing=   1
      AllowBigSelection=   0   'False
   End
End
Attribute VB_Name = "GridPage"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'用于翻页(规定接口)
Public Event EdtKeyPress(fldName As String, KeyAscii As Integer)
'用于激活保存按钮(规定接口)
Public Event ActiveSaveBtn()

Dim WithEvents GridEvent As VBControlExtender
Attribute GridEvent.VB_VarHelpID = -1
Dim m_bFilling As Boolean       '是否正在填充数据
Dim m_opt As Integer            '操作类型
Dim m_objRef As U8RefService.IService
Dim m_arrFlds() As String
Dim m_arrAuthFlds() As String
Dim m_TableName As String
Dim m_sFlds As String
Dim m_KeyFldName As String
Dim m_KeyFldValue As String
Dim m_JoinSql As String
Dim m_EleAll As IXMLDOMElement
Dim m_EleStyle As IXMLDOMElement
Dim m_RefValue As String           '参照返回内容


Dim m_SrvDB As Object
Dim m_oLogin  As Object
Dim m_oPub As Object

'--------------------------------
'功能：根据数据初始化界面(规定接口)
'参数：
'   SrvDb:      数据服务对象
'   oPub:       公共函数对象
'   sXml:       各种数据
'--------------------------------
Public Function Init(TableName As String, SrvDB As Object, oPub As Object, oLogin As Object, sXml As String) As Boolean
    On Error GoTo Err_Info
    Set m_oPub = oPub
    Set g_oPub = oPub
    Set m_SrvDB = SrvDB
    Set m_oLogin = oLogin
    Call oPub.UtoLCase(sXml)
    m_TableName = TableName
    
    InitFace
    Call InitSelf(sXml)  '必须放到InitFace之后
    
    CmdBack.Caption = oPub.GetResString("U8.AA.ARCHIVE.BUTTON.undo") '
    CmdAdd.Caption = oPub.GetResString("U8.AA.ARCHIVE.BUTTON.addrow") '
    CmdDel.Caption = oPub.GetResString("U8.AA.ARCHIVE.BUTTON.delrow") '
    CmdPos.Caption = m_oPub.GetResString("U8.AA.ARCHIVE.TOOLBAR.pos") '

    Init = True
    Exit Function
Err_Info:
    Init = False
End Function

'-----------------------------------------
'功能：自身初始化
'
'-----------------------------------------
Private Function InitSelf(sXml As String) As Boolean
    InitSelf = False
    On Error GoTo Err_Info
    Dim i As Integer
    Call InitGrid(m_oPub, Grid, sXml, m_arrFlds, m_arrAuthFlds, m_sFlds, True, m_EleAll, m_EleStyle)
    m_sFlds = Right(m_sFlds, Len(m_sFlds) - 4) '去掉序号iNO，
    Grid.AddDisColor m_oPub.UnEditedColor
    Grid.FixedCols = 1
    
    Set GridEvent = Grid.GetGridBody
    GridEvent.ExplorerBar = 5 'flexExSortShow
    
    InitSelf = True
    Exit Function
Err_Info:
    InitSelf = False
    ShowMsg Err.Description
End Function

'---------------------------------------------
'功能：初始化界面：字体、禁用字符
'参数：无
'---------------------------------------------
Private Sub InitFace()
    Dim Con As Control
    On Error Resume Next
    With UserControl
        For Each Con In .Controls
            If Not (TypeOf Con Is Line) Then
                Con.Font.Name = m_oPub.FontName ' "宋体" '"MS Sans Serif" '
                Con.Font.Size = m_oPub.FontSize ' 9 '小五号字
                Con.Font.Charset = m_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            End If
        Next
    End With
End Sub

Private Sub CmdAdd_Click()
    Dim i As Integer
    Dim R As Long
    With Grid
        .Rows = Grid.Rows + 1
        .Row = Grid.Rows - 1
        Grid.TextMatrix(Grid.Rows - 1, 0) = CStr(Grid.Rows - 1)
        For i = 0 To Grid.Cols - 1
            If Grid.ColWidth(i) > 0 Then
                .Col = i
                .LeftCol = 0 'i
                Exit For
            End If
        Next i
        If (.Rows + 1) * .RowHeight(0) >= .Height Then
            .TopRow = 2 + .Rows - (.Height \ .RowHeight(0))
        End If
        R = .Row
    End With
    Call SetGridColReadOnly(R)
End Sub

Private Sub CmdBack_Click()
     If Len(m_KeyFldValue) = 0 Then
        If Grid.Rows > 1 Then
            If m_oPub.MsgBox(m_oPub.GetResString("U8.AA.U8TABPAGES.FREE.191_1"), vbYesNo + vbQuestion, m_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then 'U8.AA.U8TABPAGES.FREE.191_1="请问是否删除的所有行数据？"
                Grid.Rows = 1
            End If
        End If
    Else
        Call FillAllGrid
    End If
End Sub

Private Sub CmdDel_Click()
    If Grid.Row > 0 Then
        ReDim g_arr(1 To 1)
        g_arr(1) = CStr(Grid.Row)
        If m_oPub.MsgBox(m_oPub.GetResFormatString("U8.AA.U8TABPAGES.FREE.174_1", g_arr), vbYesNo + vbExclamation, m_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then 'U8.AA.U8TABPAGES.FREE.174_1="删除第{0}行？"
            Call Grid.RemoveItem(Grid.Row)
            RaiseEvent ActiveSaveBtn
        End If
    End If
    Call WriteGrid
End Sub

Private Sub CmdPos_Click()
    Call m_oPub.FindPos(Me, Grid)
End Sub


Private Sub grid_OnEdit(Editing As Boolean)
    RaiseEvent ActiveSaveBtn
    m_RefValue = ""
End Sub

Private Sub grid_BrowUser(RetValue As String, ByVal R As Long, ByVal C As Long)
    On Error GoTo Err_Info
    Call InitRef(0, RetValue, R, C)
    Exit Sub
Err_Info:
End Sub

Private Sub grid_CellDataCheck(RetValue As String, RetState As MsSuperGrid.OpType, ByVal R As Long, ByVal C As Long)
    Call GridCellDataCheck(Grid, RetValue, RetState, R, C)
End Sub

Private Sub GridCellDataCheck(Grid As SuperGrid, RetValue As String, RetState As MsSuperGrid.OpType, ByVal R As Long, ByVal C As Long)
    Dim RstGrid As ADODB.Recordset
    If Grid.ColButton(C) = UserBrowButton Then
        RetValue = Trim(RetValue)
        If Len(RetValue) > 0 And m_RefValue <> RetValue Then
            Call InitRef(1, RetValue, R, C, RstGrid)
            If (RstGrid Is Nothing) Then
                
                ReDim g_arr(1 To 1)
                g_arr(1) = Grid.TextMatrix(0, C)
                Call ShowMsg(m_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.no_xx_or_no_auth", g_arr))
                RetState = dbRetry
            End If
        End If
    End If
    With Grid
        If .ColDataType(C) = EditDbl Then
            RetValue = g_oPub.FormatNum(.TextMatrix(R, C), Grid.ColPoint(C))
            '.TextMatrix(R, C) = RetValue
        End If
    End With
    '特殊处理
    Select Case LCase(m_TableName)
        Case LCase("ProxyVenWh")
            If CheckNum(Grid.TextMatrix(Grid.Row, Grid.Cols - 1), Grid.TextMatrix(Grid.Row, Grid.Cols - 2), Grid.TextMatrix(Grid.Row, Grid.Cols - 3)) = False Then
                RetState = dbRetry
            End If
        Case Else
        
    End Select
End Sub

Private Function CheckNum(ByVal ILowSum As String, ByVal iSafeNum As String, ByVal ITopSum As String) As Boolean
    CheckNum = False
    ReDim g_arr(1 To 1)
    If ILowSum <> "" Then
        If Not IsNumeric(ILowSum) Then
            g_arr(1) = Grid.TextMatrix(0, Grid.Cols - 1)
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"‘最低库存’必须为数值！"
            Exit Function
        End If
    End If
    If iSafeNum <> "" Then
        If Not IsNumeric(iSafeNum) Then
            g_arr(1) = Grid.TextMatrix(0, Grid.Cols - 2)
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"‘安全库存’必须为数值！"
            Exit Function
        End If
    End If
    If ITopSum <> "" Then
        If Not IsNumeric(ITopSum) Then
            g_arr(1) = Grid.TextMatrix(0, Grid.Cols - 3)
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"‘最高库存’必须为数值！"
            Exit Function
        End If
    End If
    
    ReDim g_arr(1 To 2)
    If ILowSum <> "" And iSafeNum <> "" Then
        If val(ILowSum) > val(iSafeNum) Then
            g_arr(1) = Grid.TextMatrix(0, Grid.Cols - 1)
            g_arr(2) = Grid.TextMatrix(0, Grid.Cols - 2)
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"‘最低库存’不得大于‘安全库存’"
            Exit Function
        End If
    End If
    If iSafeNum <> "" And ITopSum <> "" Then
         If val(iSafeNum) > val(ITopSum) Then
            g_arr(1) = Grid.TextMatrix(0, Grid.Cols - 2)
            g_arr(2) = Grid.TextMatrix(0, Grid.Cols - 3)
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"‘安全库存’不得大于‘最高库存’"
            Exit Function
        End If
    End If
    If ILowSum <> "" And ITopSum <> "" Then
         If val(ILowSum) > val(ITopSum) Then
            g_arr(1) = Grid.TextMatrix(0, Grid.Cols - 1)
            g_arr(2) = Grid.TextMatrix(0, Grid.Cols - 3)
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"‘最低库存’不得大于‘最高库存’"
            Exit Function
        End If
    End If
    CheckNum = True
End Function

'设置Grid只读权限列
Private Sub SetGridColReadOnly(lStartRow As Long)
    On Error GoTo Err_Info
    Dim i As Long
    Dim j As Integer
    Dim eleNd As IXMLDOMNode
    Dim ReadOnly As String
    For j = 1 To Grid.Cols - 1
        Set eleNd = m_EleAll.childNodes.Item(j)
        ReadOnly = GetNodeAttrVal(eleNd, "ReadOnly")
        If ReadOnly = "1" Then
            Grid.Col = j
            For i = lStartRow To Grid.Rows - 1
                Grid.Row = i
                Grid.CellBackColor = m_oPub.UnEditedColor
            Next i
        End If
    Next j
    If Grid.Rows > 1 Then
        Grid.Row = Grid.Rows - 1
    End If
    Grid.Col = 1
    Exit Sub
Err_Info:
End Sub

'--------------------------------------------------------------
'功能：初始化参照
'参数:iMode:0：点击参照Btn的Click事件；1：填写的的数据，然后看看是否唯一；
'--------------------------------------------------------------
Private Sub InitRef(iMode As Integer, RetValue As String, ByVal R As Long, ByVal C As Long, Optional RstGrid As ADODB.Recordset)
    On Error GoTo Err_Info
    Dim sCode As String
    Dim sName As String
    Dim bReturn As Boolean
    Dim strClass As String
    Dim strGrid As String
    Dim RstClass As ADODB.Recordset
    Dim sField As ADODB.Field
    Dim eleNd As IXMLDOMNode
    Dim cRefID As String, cRetFld As String, ShowUnionFlds As String
    Set eleNd = m_EleAll.childNodes.Item(C)
    If Not (eleNd Is Nothing) Then
        cRefID = GetNodeAttrVal(eleNd, "cRefID")
        cRetFld = GetNodeAttrVal(eleNd, "cRetFld")
        ShowUnionFlds = GetNodeAttrVal(eleNd, "ShowUnionFlds")
    Else
        Exit Sub
    End If
    
    If m_objRef Is Nothing Then
        Set m_objRef = New U8RefService.IService
    End If
    
    Dim sXml As String
    
    Dim sErrMsg As String

    m_objRef.RefID = cRefID
    m_objRef.Mode = iMode
    m_objRef.FillText = Grid.TextMatrix(R, C)
    If m_objRef.ShowRef(m_oLogin, RstClass, RstGrid, sErrMsg) = False Then
        If iMode = 0 Then
            ShowMsg sErrMsg
        End If
    Else
        If Not (RstGrid Is Nothing) Then
            If RstGrid.RecordCount > 0 Then
                RetValue = TxtValue(RstGrid.fields(cRetFld).value)
                m_RefValue = RetValue
                If Len(ShowUnionFlds) > 0 Then
                    On Error Resume Next
                    Grid.TextMatrix(R, C + 1) = TxtValue(RstGrid.fields(ShowUnionFlds).value)
                End If
            End If
        End If
    End If
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub


'-----------------------------------------
'功能：获得保存的字符串(规定接口)
'参数： bFlag： 是否正确
'返回： 保存的Xml字符串
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim i As Long
    Dim j As Integer
    Dim k As Integer
    Dim lCount As Long
    Dim sLast As String
    Dim sXml As String
    If Grid.ProtectUnload = dbRetry Then
        bFlag = False
        Exit Function
    End If
    With Grid
        lCount = .Rows - 1
        For k = 1 To Grid.Cols - 1
            sLast = sLast + .TextMatrix(lCount, k)
        Next k
        If Len(Trim(sLast)) = 0 Then '空行，不作处理
            lCount = lCount - 1
        End If
        For i = 1 To lCount
            sXml = sXml + "<" + m_TableName + ">"
            For j = 1 To .Cols - 1
                sXml = sXml + "<" + m_arrFlds(j) + ">" + .TextMatrix(i, j) + "</" + m_arrFlds(j) + ">"
            Next j
            sXml = sXml + "</" + m_TableName + ">"
        Next i
    End With
    sXml = "<" + m_TableName + "All>" + sXml + "</" + m_TableName + "All>"
    GetSaveXml = sXml
    bFlag = True
End Function


Private Sub UserControl_Resize()
    On Error Resume Next
    UFFrameTlb2.Top = 0
    Grid.Top = UFFrameTlb2.Top + UFFrameTlb2.Height + Screen.TwipsPerPixelY
    
    Grid.Height = UserControl.ScaleHeight - Grid.Top - 2 * Screen.TwipsPerPixelY
    
    UFFrameTlb2.width = UserControl.ScaleWidth - 2 * Screen.TwipsPerPixelX
    Grid.width = UFFrameTlb2.width
End Sub

Private Sub GridEvent_ObjectEvent(Info As EventInfo)
    On Error GoTo Err_Info
    Select Case Info.Name
        Case "AfterSort"
            Call WriteGrid
    End Select
    Exit Sub
Err_Info:
    '不作处理
End Sub

'-------------------------------------
'功能：重写序号
'-------------------------------------
Private Sub WriteGrid()
    Grid.Redraw = False
    Dim i As Long
    For i = 1 To Grid.Rows - 1 '写序号
        Grid.TextMatrix(i, 0) = CStr(i)
    Next i
    Grid.Redraw = True
End Sub

'-----------------------------------------------
'功能：完成填充所有字段内容的过程(规定接口)
'传入的参数：RsCard：需求填写的数据源（数据集）
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset, keyFldName As String, KeyFldVal As String, JoinSql)
    On Error Resume Next
    m_bFilling = True
    Dim i As Long
    m_KeyFldName = keyFldName
    m_KeyFldValue = KeyFldVal
    m_JoinSql = JoinSql
    m_opt = 2
    Call FillAllGrid
    m_bFilling = False
    Call SetGridColReadOnly(1)
End Sub


Private Sub FillAllGrid()
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    strSql = "select " + m_sFlds + " from " + m_TableName + " " + m_JoinSql + " where " + m_KeyFldName + " ='" + m_KeyFldValue + "'"
    'strSql = "select ProxyVenWh.cvencode,cvenname,itopsum,isafenum,ilowsum from ProxyVenWh inner join Vendor on ProxyVenWh.cVenCode=Vendor.cVenCode where cWhCode+'@@@'+cInvCode ='001@@@001' "
    Set Rs = m_SrvDB.OpenX(strSql)
    Call FillGrid(Rs)
End Sub



'---------------------------------------------------
'功能：对Grid控件加载数据
'---------------------------------------------------
Private Sub FillGrid(Rs As ADODB.Recordset)
    Dim i As Long
    Dim j As Integer
    Dim nFldCount  As Integer
    Dim sValue As String
    
    Grid.Redraw = False  ' 消除抖动。
    Grid.Rows = 1 '先清空上次数据
    If Rs.RecordCount > 0 Then
        Grid.Rows = Rs.RecordCount + 1
        Grid.FixedRows = 1
        Rs.MoveFirst
        nFldCount = Rs.fields.Count
        For i = 1 To Rs.RecordCount '填充数据
            For j = 0 To nFldCount - 1
                Grid.TextMatrix(i, j + 1) = m_oPub.FormatGridTxt(Rs.fields(j).value, Rs.fields(j).Name, m_EleStyle)
            Next j
            Rs.MoveNext
            If i Mod 200 = 0 Then
                Grid.Redraw = True
                DoEvents ' 如果循环已完成了200条记录，将执行让给操作系统
                Grid.Redraw = False
            End If
        Next i
        Grid.Col = 0
        Grid.Row = 1
    Else
        Grid.Rows = 1
    End If
    Call WriteGrid
    Grid.Redraw = True
End Sub

Private Sub UserControl_Terminate()
    On Error Resume Next
    Set m_objRef = Nothing
End Sub

'---------------------------------------
'功能：清空编辑框和CheckBox、comboBox框等(规定接口)
'---------------------------------------
Public Sub EmptyAllFields()
    On Error Resume Next
    Grid.Rows = 1
End Sub
