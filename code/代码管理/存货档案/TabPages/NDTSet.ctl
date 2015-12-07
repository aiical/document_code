VERSION 5.00
Object = "{9ADF72AD-DDA9-11D1-9D4B-000021006D51}#1.29#0"; "UFSpGrid.ocx"
Object = "{BF022F1C-E440-4790-987F-252926B9B602}#5.1#0"; "UFFrames.ocx"
Object = "{8C7C777D-4D83-4DE8-947E-098E2343A400}#1.0#0"; "CommandButton.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Begin VB.UserControl NDTSet 
   ClientHeight    =   3600
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   6900
   ScaleHeight     =   3600
   ScaleWidth      =   6900
   Begin VB.PictureBox Pic 
      Appearance      =   0  'Flat
      BackColor       =   &H80000000&
      ForeColor       =   &H80000008&
      Height          =   3015
      Left            =   180
      ScaleHeight     =   2985
      ScaleWidth      =   5835
      TabIndex        =   0
      Top             =   120
      Width           =   5865
      Begin UFFrames.UFFrame FrameTlb 
         Height          =   465
         Left            =   0
         TabIndex        =   1
         Top             =   -90
         Width           =   5865
         _ExtentX        =   0
         _ExtentY        =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "宋体"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Begin UFCOMMANDBUTTONLib.UFCommandButton CmdRefresh 
            Height          =   285
            Left            =   60
            TabIndex        =   4
            Top             =   150
            Width           =   555
            _Version        =   65536
            _ExtentX        =   2646
            _ExtentY        =   1323
            _StockProps     =   41
            Caption         =   "还原"
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
         Begin UFCOMMANDBUTTONLib.UFCommandButton CmdAdd 
            Height          =   285
            Left            =   608
            TabIndex        =   3
            Top             =   150
            Width           =   555
            _Version        =   65536
            _ExtentX        =   2646
            _ExtentY        =   1323
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
            Height          =   285
            Left            =   1175
            TabIndex        =   2
            Top             =   150
            Width           =   555
            _Version        =   65536
            _ExtentX        =   2646
            _ExtentY        =   1323
            _StockProps     =   41
            Caption         =   "删行"
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
      End
      Begin MsSuperGrid.SuperGrid grid 
         Height          =   2745
         Left            =   30
         TabIndex        =   5
         Top             =   390
         Width           =   5745
         _ExtentX        =   10134
         _ExtentY        =   4842
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
         MouseIcon       =   "NDTSet.ctx":0000
         ForeColorSel    =   -2147483634
         ForeColorFixed  =   -2147483630
         FixedCols       =   0
         BackColorSel    =   -2147483635
         BackColorFixed  =   -2147483633
         AllowUserResizing=   1
         AllowBigSelection=   0   'False
      End
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   0
      Top             =   0
      _ExtentX        =   1905
      _ExtentY        =   529
      ManualAttach    =   -1  'True
   End
End
Attribute VB_Name = "NDTSet"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'N计划抽检设置
Option Explicit

'用于激活保存按钮(规定接口)
Public Event ActiveSaveBtn()


Dim m_SrvDB As Object

Dim m_Dom As New DOMDocument
Dim m_Ele As IXMLDOMElement
Dim m_EleStyle As IXMLDOMElement

Dim m_arrFlds() As String
Dim sGridFlds As String '填写Grid字段
Dim iNFormulaItems() As String '计算公式选项
Dim m_iNFormulaCol As Integer '公式列位置


Dim m_iQuanDecDgt As Integer '数量小数位
Dim m_WriteCellBackColor As Long '可写背景颜色值
Dim m_bSetGridColor As Boolean '是否在设置Grid颜色状态
Dim m_TableName As String '那个表使用
Dim m_sCode As String '编码

'--------------------------------
'功能：根据数据初始化界面(规定接口)
'参数：
'   SrvDb:      数据服务对象
'   oPub:       公共函数对象
'   sXml:       各种数据
'--------------------------------
Public Function Init(SrvDB As Object, oPub As Object, TableName As String, sXml As String) As Boolean
'    Init = False
'    Dim i As Integer
'
'    On Error GoTo Err_Info
'    Set g_oPub = oPub
'    Set m_SrvDB = SrvDB
'    Call g_oPub.UtoLCase(sXml)
'    m_iQuanDecDgt = CInt(GetParaVal(sXml, "g_iQuanDecDgt", "2"))
'    ReDim iNFormulaItems(5)
'    iNFormulaItems(0) = "全检"
'    iNFormulaItems(1) = "[根号(N)]+1"
'    iNFormulaItems(2) = "{[根号(N)]/2}+1"
'    iNFormulaItems(3) = "按比例"
'    iNFormulaItems(4) = "按数量"
'    m_TableName = TableName
'    If Len(m_TableName) = 0 Then
'        ShowMsg "N计划设置控件必须传入表名来初始化！"
'    End If
'    InitFace
'    InitSelf
'    AddLine
'    Init = True
    Exit Function
Err_Info:
    Init = False
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
                Con.Font.Name = g_oPub.FontName ' "宋体" '"MS Sans Serif" '
                Con.Font.Size = g_oPub.FontSize ' 9 '小五号字
                Con.Font.Charset = g_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            End If
            If TypeOf Con Is Edit Or LCase(Left(Con.Name, 3)) = "edt" Then
                Con.BadStr = g_oPub.BadStr
                If Con.Property = EditStr Then
                   Con.Property = EditNormal '允许输入空格
                End If
            ElseIf TypeOf Con Is SuperGrid Then
                Con.SetFilterString (g_oPub.BadStr)
            End If
        Next
    End With
End Sub

'-----------------------------------------
'功能：自身初始化
'
'-----------------------------------------
Private Function InitSelf() As Boolean
'    InitSelf = False
'    On Error GoTo Err_Info
'    Dim i As Integer
'    Dim sXml As String
'    Dim ele As IXMLDOMElement
'    Dim width As String
'    Dim sTemp As String
'
'
'    sXml = "<DecDgtStyle>"
'    sXml = sXml + "<fNDownLimit>" + CStr(m_iQuanDecDgt) + "</fNDownLimit>"
'    sXml = sXml + "<fNUpLimit>" + CStr(m_iQuanDecDgt) + "</fNUpLimit>"
'    sXml = sXml + "<fNDTNum>" + CStr(m_iQuanDecDgt) + "</fNDTNum>"
'    sXml = sXml + "<fNDTRate>2</fNDTRate>"
'    sXml = sXml + "</DecDgtStyle>"
'    Call g_oPub.UtoLCase(sXml)
'    If m_Dom.loadXML(sXml) = False Then
'        ShowMsg "格式化错误！"
'    Else
'        Set m_EleStyle = m_Dom.documentElement
'    End If
'
'    sXml = "<Inventory>"
'    'ColDataType='0' 字符串 ;1：Double;2:long
'    'bRef=0:无；1：参照；2：Combox
'    sXml = sXml + "<fNDownLimit  Width='1400' Value='' ChName='报检量下限(含)' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
'    sXml = sXml + "<fNUpLimit Width='1300' Value='' ChName='报检量上限' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
'    sXml = sXml + "<iNFormula  Width='1500' Value='' ChName='计算公式' ColDataType='0' ColTextWidth='20' ColPoint='' bRef='2'/>"
'    sXml = sXml + "<fNDTRate  Width='1100' Value='' ChName='抽检比例(%)' ColDataType='1' ColTextWidth='6' ColPoint='2' bRef='0'/>"
'    sXml = sXml + "<fNDTNum  Width='900' Value='' ChName='抽检数量' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
'    sXml = sXml + "</Inventory>"
'    Call InitGrid(g_oPub, grid, sXml, m_arrFlds, sGridFlds)
'    grid.AddDisColor (g_oPub.UnEditedColor)
'    m_iNFormulaCol = GetCol("iNFormula")
    Exit Function
Err_Info:
    ShowMsg Err.Description
End Function

'------------------------------------------
'功能：增加一行
'------------------------------------------
Private Sub AddLine()
    If grid.ProtectUnload = dbRetry Then Exit Sub
    Dim i As Integer
    Dim R As Long
    R = grid.Rows - 1
    With grid
        If R >= 1 Then
            If Len(.TextMatrix(R, m_iNFormulaCol - 1)) = 0 Then
                ShowMsg "增加新行时，【报检量上限】不可为空！"
                Exit Sub
            ElseIf InStr(1, .TextMatrix(R, m_iNFormulaCol - 1), "以上") > 0 Then
                ShowMsg "请重新填写【报检量上限】！"
                Exit Sub
            End If
            Select Case .TextMatrix(R, m_iNFormulaCol)
                Case iNFormulaItems(0), iNFormulaItems(1), iNFormulaItems(2) '全检
                    .TextMatrix(R, m_iNFormulaCol + 1) = "" '清空比例
                    .TextMatrix(R, m_iNFormulaCol + 2) = "" '清空数量
                Case iNFormulaItems(3) '按比例
                    If Len(.TextMatrix(R, m_iNFormulaCol + 1)) = 0 Then
                        ShowMsg .TextMatrix(0, m_iNFormulaCol + 1) + "不可为空！"
                        Exit Sub
                    End If
                Case iNFormulaItems(4) '按数量
                    If Len(.TextMatrix(R, m_iNFormulaCol + 2)) = 0 Then
                        ShowMsg .TextMatrix(0, m_iNFormulaCol + 2) + "不可为空！"
                        Exit Sub
                    End If
                Case ""
                    ShowMsg .TextMatrix(0, m_iNFormulaCol) + "不可为空！"
                    Exit Sub
            End Select
        End If
        m_bSetGridColor = True
        .Rows = grid.Rows + 1
        .Row = grid.Rows - 1
        .Col = 0
        .LeftCol = 0
        If (.Rows + 1) * .RowHeight(0) >= .Height Then
            .TopRow = 1 + .Rows - (.Height \ .RowHeight(0))
        End If
        R = .Row
        If R = 1 Then
            .TextMatrix(R, GetCol("fNDownLimit")) = "0"
            .TextMatrix(R, GetCol("iNFormula")) = iNFormulaItems(0)
        ElseIf R > 1 Then
            i = GetCol("fNDownLimit")
            .TextMatrix(R - 1, i + 1) = GetfNUpLimit(.TextMatrix(R - 1, i + 1))
             .TextMatrix(R, i) = .TextMatrix(R - 1, i + 1)
            .TextMatrix(R, GetCol("iNFormula")) = iNFormulaItems(0)
        End If
        .Col = 0
        .CellBackColor = g_oPub.UnEditedColor
        .Col = m_iNFormulaCol + 1
        .CellBackColor = g_oPub.UnEditedColor
        .Col = m_iNFormulaCol + 2
        .CellBackColor = g_oPub.UnEditedColor
        .Col = 0
        .TopRow = grid.Row
        .LeftCol = 0
        m_bSetGridColor = False
        RaiseEvent ActiveSaveBtn
    End With
End Sub

'---------------------------------------
'功能：删除一行
'---------------------------------------
Private Sub DelLine()
    If grid.Rows > 1 Then
'        If grid.Rows = 2 Then
'            ShowMsg "第一行不可删除！"
'        Else
            If g_oPub.MsgBox("删除最后一行？", vbYesNo + vbExclamation, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then
                Call grid.RemoveItem(grid.Rows - 1)
                RaiseEvent ActiveSaveBtn
            End If
'        End If
    End If
End Sub


Private Sub CmdAdd_Click()
    AddLine
End Sub

Private Sub CmdDel_Click()
    DelLine
End Sub

Private Sub CmdRefresh_Click()
    If Len(m_sCode) = 0 Then
        If grid.Rows > 1 Then
            If g_oPub.MsgBox("请问是否删除的所有行数据？", vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then
                grid.Rows = 1
            End If
        End If
    Else
        FillGrid
    End If
End Sub

Private Sub grid_CellDataCheck(RetValue As String, RetState As MsSuperGrid.OpType, ByVal R As Long, ByVal C As Long)
    If m_bSetGridColor = True Then Exit Sub
    On Error GoTo Err_Info
    Dim sText  As String
    Dim fNUpLimit As String
    With grid
        Select Case C
            Case 1:
                sText = .TextMatrix(R, C)
                If Len(sText) > 0 Then
                    If IsNumeric(sText) = False Then
                        ShowMsg "【" + .TextMatrix(0, C) + "】必须填写数值！"
                        RetState = dbRetry
                    ElseIf CDbl(sText) <= CDbl(.TextMatrix(R, C - 1)) Then
                        ShowMsg "【" + .TextMatrix(0, C) + "】必须大于【" + .TextMatrix(0, C - 1) + "】"
                        RetState = dbRetry
                    ElseIf R < grid.Rows - 1 Then
                        .TextMatrix(R + 1, C - 1) = g_oPub.FormatGridTxt(sText, m_arrFlds(C), m_EleStyle)
                    End If
                End If
            Case 2
                sText = .TextMatrix(R, C)
                Call SetUnEditColor(R, RetValue)
                .Col = C '还原位置
            Case 3
                sText = .TextMatrix(R, C)
                If Len(sText) = 0 Then
                    ShowMsg .TextMatrix(0, C) + "不可为空！"
                    RetState = dbRetry
                ElseIf CDbl(sText) <= 0 Then
                    ShowMsg .TextMatrix(0, C) + "不可小于等于0！"
                    RetState = dbRetry
                ElseIf CDbl(sText) >= 100 Then
                    ShowMsg .TextMatrix(0, C) + "不可大于等于100！"
                    RetState = dbRetry
                End If
            Case 4
                sText = .TextMatrix(R, C)
                If Len(sText) = 0 Then
                    ShowMsg .TextMatrix(0, C) + "不可为空！"
                    RetState = dbRetry
                ElseIf CDbl(sText) <= 0 Then
                    ShowMsg .TextMatrix(0, C) + "不可小于等于0！"
                    RetState = dbRetry
                ElseIf Len(.TextMatrix(R, 1)) > 0 Then
                    fNUpLimit = GetfNUpLimit(.TextMatrix(R, 1))
                    If Len(fNUpLimit) > 0 Then
                        If CDbl(sText) > CDbl(fNUpLimit) Then
                            ShowMsg .TextMatrix(0, C) + "不可大于【报检量上限】！"
                            .TextMatrix(R, C) = fNUpLimit
                            RetState = dbRetry
                        End If
                    End If
                End If
            Case Else
        End Select
    End With
    With grid
        If .ColDataType(C) = EditDbl Then
            RetValue = g_oPub.FormatGridTxt(.TextMatrix(R, C), m_arrFlds(C), m_EleStyle)
            .TextMatrix(R, C) = RetValue
        End If
    End With
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub



Private Sub grid_FillList(ByVal R As Long, ByVal C As Long, pCom As Object)
    Dim i As Integer
    For i = 0 To UBound(iNFormulaItems) - 1
        pCom.AddItem iNFormulaItems(i)
    Next i
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub grid_OnEdit(Editing As Boolean)
    'RaiseEvent ActiveSaveBtn
End Sub

Private Sub UserControl_Initialize()
    UserControl.KeyPreview = False
    m_WriteCellBackColor = &H80000005
    m_bSetGridColor = False
End Sub

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
   If UserControl.Ambient.UserMode = True Then
      UFFrmKeyHook.Attach
   End If
End Sub

Private Sub UFFrmKeyHook_ContainerKeyDown(KeyCode As Integer, ByVal Shift As Integer)
    On Error Resume Next
    If UserControl.ActiveControl Is Nothing Then Exit Sub
    If g_oPub.ConKeyDown(UserControl.ActiveControl, KeyCode, Shift) = True Then
        RaiseEvent ActiveSaveBtn
    End If
    If UserControl.ActiveControl Is grid Then
        If (KeyCode = vbKeyI And Shift = 2) Then  ' 不要KeyCode = vbKeyF5 Or
            AddLine
        ElseIf (KeyCode = vbKeyD And Shift = 2) Then 'KeyCode = vbKeyDelete
            DelLine
        ElseIf KeyCode = vbKeyReturn Then
            If (grid.Col = grid.Cols - 1) And grid.Row = grid.Rows - 1 Then
                AddLine
'                SendKeys "{LEFT}"
            End If
        End If
    End If
End Sub

Private Sub UserControl_Resize()
    Pic.Left = 0
    Pic.Top = 0
    Pic.width = UserControl.width
    Pic.Height = UserControl.Height
    FrameTlb.width = Pic.width
    grid.width = Pic.width - 7 * Screen.TwipsPerPixelX
    grid.Height = Pic.Height - FrameTlb.Height
End Sub

Public Property Get Enabled() As Boolean
    Enabled = Pic.Enabled
End Property

Public Property Let Enabled(ByVal vNewValue As Boolean)
    Pic.Enabled = vNewValue
End Property

'---------------------------------------
'功能：获得列序数
'参数：fldName：    字段名称
'---------------------------------------
Private Function GetCol(fldName As String) As Integer
    Dim i As Integer
    For i = 0 To UBound(m_arrFlds) - 1
        If LCase(fldName) = LCase(m_arrFlds(i)) Then
            GetCol = i
            Exit Function
        End If
    Next i
    If i = UBound(m_arrFlds) Then
        ShowMsg "查找列" + fldName + "不存在！"
    End If
End Function

'-----------------------------------------
'功能：获得保存的字符串(规定接口)
'参数： bFlag： 是否正确
'返回： 保存的Xml字符串
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim i As Integer
    Dim sXml As String
    bFlag = True
    If grid.ProtectUnload = dbRetry Then
        bFlag = False
        Exit Function
    End If
    sXml = GetGridXml
    GetSaveXml = sXml
End Function

'-----------------------------------------------
'功能：填写物料档案（存货结构性自由项组合）的保存Xml字符串
'返回：返回Xml串
'-----------------------------------------------
Private Function GetGridXml()
    Dim i As Long
    Dim j As Integer
    Dim k As Integer
    Dim lCount As Long
    Dim sLast As String
    Dim sXml As String
    With grid
        lCount = .Rows - 1
        For k = 0 To .Cols - 1
            sLast = sLast + .TextMatrix(lCount, k)
        Next k
        If Len(Trim(sLast)) = 0 Then '空行，不作处理
            lCount = lCount - 1
        End If
        For i = 1 To lCount
            sXml = sXml + "<NPlanDTSet>"
            For j = 0 To grid.Cols - 1
                If "informula" = LCase(m_arrFlds(j)) Then
                    For k = 0 To UBound(m_arrFlds) - 1
                        If .TextMatrix(i, j) = iNFormulaItems(k) Then
                            sXml = sXml + "<" + m_arrFlds(j) + ">" + CStr(k) + "</" + m_arrFlds(j) + ">"
                            Exit For
                        End If
                    Next k
                Else
                    sXml = sXml + "<" + m_arrFlds(j) + ">" + .TextMatrix(i, j) + "</" + m_arrFlds(j) + ">"
                End If
                
            Next j
            sXml = sXml + "</NPlanDTSet>"
        Next i
    End With
    GetGridXml = "<NPlanDTSetAll>" + sXml + "</NPlanDTSetAll>"
End Function


'-----------------------------------------------
'功能：完成填充所有字段内容的过程(规定接口)
'传入的参数：RsCard：需求填写的数据源（数据集）
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    On Error Resume Next
    Select Case LCase(m_TableName)
        Case "inventory"
            m_sCode = TxtValue(RsCard!cinvcode)
        Case "venandinv"
            m_sCode = TxtValue(RsCard!AutoID)
        Case "cusinvcontrapose"
            m_sCode = TxtValue(RsCard!cCIGUID)
        Case Else
            ShowMsg "传入的N计划设置的表名不存在！"
    End Select
    Call FillGrid
End Sub

Private Sub FillGrid()
    Dim i As Long
    Dim j As Integer
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    strSql = "select " + sGridFlds + " from NPlanDTSet where cNDTID ='" + m_sCode + "' and  cNTableName ='" + m_TableName + "'"
    Set Rs = m_SrvDB.OpenX(strSql)
    Dim nFldCount  As Integer
    With grid
        .Redraw = False  ' 消除抖动。
        If Rs.RecordCount > 0 Then
            .Rows = Rs.RecordCount + 1
            .FixedRows = 1
            Rs.MoveFirst
            nFldCount = Rs.fields.Count
            For i = 1 To Rs.RecordCount '填充数据
                For j = 0 To nFldCount - 1
                    .TextMatrix(i, j) = g_oPub.FormatGridTxt(Rs.fields(j).value, Rs.fields(j).Name, m_EleStyle)
                Next j
                Call SetUnEditColor(i, .TextMatrix(i, m_iNFormulaCol))
                Rs.MoveNext
                If i Mod 200 = 0 Then
                    .Redraw = True
                    DoEvents ' 如果循环已完成了200条记录，将执行让给操作系统
                    .Redraw = False
                End If
            Next i
            .Col = 0
            .Row = 1
            RepairGrid
        Else
            .Rows = 1
        End If
        .Redraw = True
    End With
End Sub

'---------------------------------------
'功能；格式化grid数据
'---------------------------------------
Private Sub RepairGrid()
    Dim i As Long
    Dim lRstCount As Long
    Dim Index As String
    On Error GoTo Err_Info
    With grid
        lRstCount = .Rows - 1
        For i = 1 To lRstCount
            Index = .TextMatrix(i, m_iNFormulaCol)
            If (IsNumeric(Index) = True) And Index <> "-1" Then
                .TextMatrix(i, m_iNFormulaCol) = iNFormulaItems(CInt(Index))
            Else
                .TextMatrix(i, m_iNFormulaCol) = ""
            End If
        Next i
        .TextMatrix(lRstCount, 1) = .TextMatrix(lRstCount, 0) + "以上"
    End With
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub


'----------------------------------------------
'功能：设置不可编辑颜色
'参数：ciNFormulaVal：      取得公司值
'----------------------------------------------
Private Sub SetUnEditColor(R As Long, ciNFormulaVal As String)
    On Error Resume Next
    m_bSetGridColor = True
    With grid
        grid.Row = R
        .Col = 0
        .CellBackColor = g_oPub.UnEditedColor
        Select Case ciNFormulaVal
            Case iNFormulaItems(3), "3"
                .Col = m_iNFormulaCol + 1
                .CellBackColor = m_WriteCellBackColor
                .Col = m_iNFormulaCol + 2
                .CellBackColor = g_oPub.UnEditedColor
                .TextMatrix(R, .Col) = ""
            Case iNFormulaItems(4), "4"
                .Col = m_iNFormulaCol + 1
                .CellBackColor = g_oPub.UnEditedColor
                .TextMatrix(R, .Col) = ""
                .Col = m_iNFormulaCol + 2
                .CellBackColor = m_WriteCellBackColor
            Case Else
                .Col = m_iNFormulaCol + 1
                .CellBackColor = g_oPub.UnEditedColor
                .TextMatrix(R, .Col) = ""
                .Col = m_iNFormulaCol + 2
                .CellBackColor = g_oPub.UnEditedColor
                .TextMatrix(R, .Col) = ""
        End Select
    End With
    m_bSetGridColor = False '该函数中不可出现“exit sub”，否则该参数无法置位
End Sub

'----------------------------------------------
'功能：去掉报检量上限的“以上”二字
'参数： val：   最初原始值
'----------------------------------------------
Private Function GetfNUpLimit(val As String) As String
    On Error GoTo Err_Info
    If Len(val) = 0 Then
        GetfNUpLimit = ""
    Else
        Dim Pos1 As Integer
        Pos1 = InStr(1, val, "以上")
        If Pos1 > 0 Then
            GetfNUpLimit = Left(val, Pos1 - 1)
        Else
            GetfNUpLimit = val
        End If
    End If
    Exit Function
Err_Info:
    GetfNUpLimit = ""
End Function

'---------------------------------------
'功能：清空编辑框等(规定接口)
'---------------------------------------
Public Sub Emptyallfields()
    grid.Rows = 1
    m_sCode = ""
End Sub
