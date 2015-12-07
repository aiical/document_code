VERSION 5.00
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Object = "{4C2F9AC0-6D40-468A-8389-518BB4F8C67D}#1.0#0"; "UFComboBox.ocx"
Object = "{A98B9C82-88D8-4F94-91BB-F2289111C59C}#1.0#0"; "UFCheckBox.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Begin VB.UserControl InvPlan 
   ClientHeight    =   6105
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11295
   ScaleHeight     =   6105
   ScaleMode       =   0  'User
   ScaleWidth      =   11295
   Begin UFCHECKBOXLib.UFCheckBox ChkbROP 
      Height          =   195
      Left            =   270
      TabIndex        =   0
      Top             =   255
      Width           =   5295
      _Version        =   65536
      _ExtentX        =   9340
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "ROP件"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiPlanPolicy2 
      Height          =   315
      Left            =   1260
      TabIndex        =   10
      Top             =   6900
      Visible         =   0   'False
      Width           =   1695
      _Version        =   65536
      _ExtentX        =   2990
      _ExtentY        =   529
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiROPMethod 
      Height          =   315
      Left            =   1560
      TabIndex        =   1
      Top             =   630
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7064
      _ExtentY        =   529
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiBatchRule 
      Height          =   315
      Left            =   7020
      TabIndex        =   2
      Top             =   630
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7064
      _ExtentY        =   529
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbGetInt2 
      Height          =   315
      Left            =   3540
      TabIndex        =   12
      Top             =   6960
      Visible         =   0   'False
      Width           =   1455
      _Version        =   65536
      _ExtentX        =   2646
      _ExtentY        =   1323
      _StockProps     =   15
      Caption         =   "是否取整"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin EDITLib.Edit EdtfMaxOrder2 
      Height          =   285
      Left            =   1260
      TabIndex        =   13
      Top             =   6645
      Visible         =   0   'False
      Width           =   1695
      _Version        =   65536
      _ExtentX        =   2990
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtfVagQuantity 
      Height          =   285
      Left            =   1560
      TabIndex        =   5
      Top             =   1395
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7056
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtiOrderIntervalDays2 
      Height          =   285
      Left            =   1290
      TabIndex        =   14
      Top             =   6375
      Visible         =   0   'False
      Width           =   1695
      _Version        =   65536
      _ExtentX        =   2990
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtiInvAdvance 
      Height          =   285
      Left            =   1560
      TabIndex        =   7
      Top             =   1755
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7056
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   3
      MaxLength       =   5
   End
   Begin EDITLib.Edit EdtiInvBatch 
      Height          =   285
      Left            =   7020
      TabIndex        =   6
      Top             =   1395
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7056
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   4
      NumPoint        =   6
      MaxLength       =   12
   End
   Begin EDITLib.Edit EdtIadvanceDate 
      Height          =   285
      Left            =   7020
      TabIndex        =   8
      Top             =   1755
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7056
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Enabled         =   0   'False
      Appearance      =   1
      Property        =   3
      MaxLength       =   5
      Enabled         =   0   'False
   End
   Begin EDITLib.Edit EdtfSubscribePoint 
      Height          =   285
      Left            =   7020
      TabIndex        =   4
      Top             =   1020
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7056
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtfBatchIncrement2 
      Height          =   285
      Left            =   4470
      TabIndex        =   9
      Top             =   7290
      Visible         =   0   'False
      Width           =   1695
      _Version        =   65536
      _ExtentX        =   2990
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtfMinOrder2 
      Height          =   285
      Left            =   4620
      TabIndex        =   15
      Top             =   6510
      Visible         =   0   'False
      Width           =   1695
      _Version        =   65536
      _ExtentX        =   2990
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtiAssureProvideDays 
      Height          =   285
      Left            =   1560
      TabIndex        =   3
      Top             =   1020
      Width           =   4000
      _Version        =   65536
      _ExtentX        =   7056
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliPlanPolicy 
      Height          =   195
      Left            =   180
      TabIndex        =   24
      Top             =   6945
      Visible         =   0   'False
      Width           =   720
      _Version        =   65536
      _ExtentX        =   1270
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "计划策略"
      AutoSize        =   -1  'True
   End
   Begin UFLABELLib.UFLabel LblfBatchIncrement 
      Height          =   195
      Left            =   3330
      TabIndex        =   20
      Top             =   7350
      Visible         =   0   'False
      Width           =   720
      _Version        =   65536
      _ExtentX        =   1270
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "批量增量"
      AutoSize        =   -1  'True
   End
   Begin UFLABELLib.UFLabel LbliOrderIntervalDays 
      Height          =   195
      Left            =   180
      TabIndex        =   19
      Top             =   6375
      Visible         =   0   'False
      Width           =   1080
      _Version        =   65536
      _ExtentX        =   1905
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "订货间隔天数"
      AutoSize        =   -1  'True
   End
   Begin UFLABELLib.UFLabel LblfMinOrder 
      Height          =   195
      Left            =   3540
      TabIndex        =   17
      Top             =   6525
      Visible         =   0   'False
      Width           =   900
      _Version        =   65536
      _ExtentX        =   1588
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "最小订货量"
      AutoSize        =   -1  'True
   End
   Begin UFLABELLib.UFLabel LblfMaxOrder 
      Height          =   195
      Left            =   150
      TabIndex        =   16
      Top             =   6660
      Visible         =   0   'False
      Width           =   900
      _Version        =   65536
      _ExtentX        =   1588
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "最大订货量"
      AutoSize        =   -1  'True
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   0
      Top             =   0
      _ExtentX        =   1905
      _ExtentY        =   529
      ManualAttach    =   -1  'True
   End
   Begin UFLABELLib.UFLabel LblfVagQuantity 
      Height          =   195
      Left            =   270
      TabIndex        =   18
      Top             =   1410
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "日均耗量"
   End
   Begin UFLABELLib.UFLabel LbliBatchRule 
      Height          =   195
      Left            =   5760
      TabIndex        =   21
      Top             =   660
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "ROP批量规则"
   End
   Begin UFLABELLib.UFLabel LblfSubscribePoint 
      Height          =   195
      Left            =   5760
      TabIndex        =   22
      Top             =   1020
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "再订货点"
   End
   Begin UFLABELLib.UFLabel LbliROPMethod 
      Height          =   195
      Left            =   270
      TabIndex        =   23
      Top             =   630
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "再订货点方法"
   End
   Begin UFLABELLib.UFLabel LabiInvAdvance 
      Height          =   195
      Left            =   270
      TabIndex        =   25
      Top             =   1800
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "固定提前期"
   End
   Begin UFLABELLib.UFLabel LblIadvanceDate 
      Height          =   195
      Left            =   5760
      TabIndex        =   26
      Top             =   1800
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "累计提前期"
   End
   Begin UFLABELLib.UFLabel LabiInvBatch 
      Height          =   195
      Left            =   5760
      TabIndex        =   27
      Top             =   1410
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "固定供应量"
   End
   Begin UFLABELLib.UFLabel LbliAssureProvideDays 
      Height          =   195
      Left            =   270
      TabIndex        =   11
      Top             =   1020
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "保证供应天数"
   End
End
Attribute VB_Name = "InvPlan"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'用于翻页(规定接口)
Public Event EdtKeyPress(fldName As String, KeyAscii As Integer)
'用于激活保存按钮(规定接口)
Public Event ActiveSaveBtn()

Public Event SetcPlanMethod()



Dim STR_ROP   As String
Dim strBATCHRULE(6) As String '批量规则

Dim m_Dom As New DOMDocument
Dim m_Ele As IXMLDOMElement

Dim m_SrvDB As Object

Dim m_cUserName As String '用户名

Dim m_sRFldAuthInv As String  '只读权限字段名
Dim m_sNFldAuthInv As String  '无权限字段名
Dim m_iQuanDecDgt As Integer  '存货数量小数位
Dim m_bFilling As Boolean '是否在填写数据

''Dim m_bSelfValue As Integer '是否自制属性
Dim m_ISafeNum As String '安全库存
Dim m_sRowAuthDept As String '部门档案权限字符串
Dim m_sRowAuthPerson As String  '职员档案权限字符串
Dim m_bSave As Boolean '是否可以保存

'



'--------------------------------
'功能：根据数据初始化界面(规定接口)
'参数：
'   SrvDb:      数据服务对象
'   oPub:       公共函数对象
'   sXml:       各种数据
'--------------------------------
Public Function Init(SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Init = False
    On Error GoTo Err_Info
    Set g_oPub = oPub
    Set m_SrvDB = SrvDB
    'Call g_oPub.UCtrlLayout(GetControls, "U8.AA.ARCHIVE.TABPAGES.InvPlan")
    Call UserControl_Resize
    Call g_oPub.SetLabelCaption(m_SrvDB, UserControl.Controls, "Inventory")
    Call g_oPub.SetConPosition(UserControl.Controls)
    Call g_oPub.UtoLCase(sXml)
'    If LCase(GetParaVal(sXml, "g_bFactory")) = "false" Then
'        '非工业版
'        FrameFactory.Visible = False
'    End If
    m_sRowAuthDept = GetParaVal(sXml, "g_sRowAuthDept")
    m_sRowAuthPerson = GetParaVal(sXml, "g_sRowAuthPerson")
    
    Call InitFace(CLng(GetParaVal(sXml, "HelpContextId", "0")))
    STR_ROP = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.rop") ''"ROP件"
'    CmbiPlanPolicy.Clear '计划策略
'    CmbiPlanPolicy.AddItem ""
'    CmbiPlanPolicy.AddItem "MRP件"
'    CmbiPlanPolicy.AddItem STR_ROP
'    'CmbiPlanPolicy.AddItem "虚拟件"
    
    
    CmbiROPMethod.Clear '再订货点方法
    CmbiROPMethod.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iropmethod1") '"手工"
    CmbiROPMethod.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iropmethod2") '"自动"
'    CmbiPlanPolicy.ListIndex = 1 '因赋值，导致CmbiROPMethod要选项，故CmbiROPMethod赋值在前
    CmbiROPMethod.ListIndex = -1
    
    strBATCHRULE(0) = ""
    strBATCHRULE(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule1") '"直接批量"
    strBATCHRULE(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule2") '"固定批量"
    strBATCHRULE(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule3") '"期间批量" '不可置空，通过不添加方式，以防与strBATCHRULE(0)混淆
    strBATCHRULE(4) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule4") '"补充至最高库"
    strBATCHRULE(5) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule5") '"历史消耗量"

    
    CmbiBatchRule.Clear '批量规则
    CmbiBatchRule.AddItem strBATCHRULE(4) '"补充至最高库"
    CmbiBatchRule.AddItem strBATCHRULE(2) '"固定批量"
    CmbiBatchRule.AddItem strBATCHRULE(5) '"历史消耗量"
    CmbiBatchRule.ListIndex = 0

    
    'EdtfFixedBatch.BadStr = EdtfFixedBatch.BadStr + "-" '所输数值应大于零
    'EdtfMaxOrder.BadStr = EdtfMaxOrder.BadStr + "-"
    'EdtfMinOrder.BadStr = EdtfMinOrder.BadStr + "-"
    'EdtfBatchIncrement.BadStr = EdtfBatchIncrement.BadStr + "-" '批量增量
    EdtiAssureProvideDays.BadStrEx = "-" '保证供应天数
    
    
    Init = True
    Exit Function
Err_Info:
    Init = False
End Function

'---------------------------------------------
'功能：初始化界面：字体、禁用字符
'参数：无
'---------------------------------------------
Private Sub InitFace(HelpContextId As Long)
    Dim Con As Control
    On Error Resume Next
    With UserControl
        For Each Con In .Controls
                Con.Font.Name = g_oPub.FontName ' "宋体" '"MS Sans Serif" '
                Con.Font.Size = g_oPub.FontSize '9 '小五号字
                Con.Font.Charset = g_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            
            
            If TypeOf Con Is Edit Or LCase(Left(Con.Name, 3)) = "edt" Then
                'Con.BadStr = g_oPub.BadStr
                If Con.Property = EditStr Then
                   Con.Property = EditNormal '允许输入空格
                End If
                Con.HelpContextId = HelpContextId
            ElseIf TypeOf Con Is SuperGrid Then
                'Con.SetFilterString (g_oPub.BadStr)
            End If
        Next
    End With
End Sub

Private Sub ChkbROP_Click()
    On Error Resume Next
    RaiseEvent ActiveSaveBtn
    RaiseEvent SetcPlanMethod
    CmbiBatchRule.Enabled = False
    If ChkbROP.value = 1 Then
        'If CmbiBatchRule.Visible = True Then'直接从主界面双击，则会visible＝false
            CmbiBatchRule.Enabled = True
        'End If
        'If m_iROPMethodRW = 2 Then
        'If CmbiROPMethod.Visible = True Then
            CmbiROPMethod.Enabled = True
        'End If
        CmbiROPMethod.ListIndex = 0
        'If m_fSubscribePointRW = 2 Then
        If EdtfSubscribePoint.Locked = False Then
            EdtfSubscribePoint.Enabled = True
        End If

''        '由用户手工输入。可输可不输，默认为0，如果为空，等同为0。
''        '当计划策略为ROP件时，该字段不可输入。
''        EdtiAlterAdvance.Enabled = False
''        EdtiAlterAdvance.Text = ""
''        '手工输入，可输可不输，默认为1。
''        '当计划策略为ROP件时，该字段不可输入
''        EdtfAlterBaseNum.Enabled = False
''        EdtfAlterBaseNum.Text = ""
    Else
        CmbiROPMethod.Enabled = False
        CmbiROPMethod.ListIndex = -1
        CmbiBatchRule.Enabled = False
        CmbiBatchRule.ListIndex = -1
        EdtfSubscribePoint.Enabled = False
        EdtfSubscribePoint.Text = ""
''        'If m_iChangedAdvanceRW = 2 Then
''        If EdtiAlterAdvance.Locked = False Then
''            EdtiAlterAdvance.Enabled = True
''        End If
''        'If m_fAlterBaseNumRW = 2 Then
''        If EdtfAlterBaseNum.Locked = False Then
''            EdtfAlterBaseNum.Enabled = True
''        End If

    End If
End Sub



Private Sub UserControl_GotFocus()
    On Error GoTo Err_Info
        ChkbROP.SetFocus
    Exit Sub
Err_Info:
End Sub

Private Sub UserControl_Initialize()
    UserControl.KeyPreview = False
End Sub

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
   If UserControl.Ambient.UserMode = True Then
      UFFrmKeyHook.Attach
   End If
End Sub


Private Sub UFFrmKeyHook_ContainerKeyDown(KeyCode As Integer, ByVal Shift As Integer)
    On Error Resume Next
    
    If g_oPub.ConKeyDown(UserControl.ActiveControl, KeyCode, Shift) = True Then
        RaiseEvent ActiveSaveBtn
    End If
End Sub


Private Sub UFFrmKeyHook_ContainerKeyPress(KeyAscii As Integer)
    On Error Resume Next
    
    If UserControl.ActiveControl Is Nothing Then Exit Sub
    If KeyAscii = 13 Then
        If TypeOf UserControl.ActiveControl Is Edit Or TypeOf UserControl.ActiveControl Is EDITLib.Edit Or TypeOf UserControl.ActiveControl Is UFCOMBOBOXLib.UFComboBox Or TypeOf UserControl.ActiveControl Is UFCHECKBOXLib.UFCheckBox Then
            Select Case (UserControl.ActiveControl.Name)
                Case EdtiInvAdvance.Name
                    RaiseEvent EdtKeyPress("nextpage", KeyAscii)
                    Exit Sub
                Case Else
            End Select
            SendKeys "{TAB}"
        End If
    End If
End Sub

Private Sub UserControl_Resize()
'    On Error Resume Next
'    If Not (g_oPub Is Nothing) Then
'        If LCase(g_oPub.m_LocaleID) = "en-us" Then
'            UserControl.width = g_frameWidthEn
'            UserControl.Height = g_frameHeightEn
'        End If
'    Else
'        UserControl.width = g_frameWidth
'        UserControl.Height = g_frameHeight
'    End If
End Sub

'---------------------------------------
'功能： 根据字段读写权限，控制相应的控件状态
'参数： Con：       控件对象
'       FldName：   字段名称
'返回： 0：无读写权限；1：读权限；2：写权限
'---------------------------------------
Private Function ConSet(Con As Object, ByVal fldName As String) As Integer
    ConSet = g_oPub.ConAuthSet(UserControl.Controls, Con, fldName, m_sRFldAuthInv, m_sNFldAuthInv)
End Function

'------------------------------------------------------------
'功能：设置字段读写权限(规定接口)
'参数： sRFldAuthInv：   读权限字符串
'       sNFldAuthInv:   无权限字符串
'------------------------------------------------------------
Public Sub SetConAuth(sRFldAuthInv As String, sNFldAuthInv As String)
    m_sRFldAuthInv = sRFldAuthInv
    m_sNFldAuthInv = sNFldAuthInv
    
    
'    Call ConSet(CmbiPlanPolicy, "iPlanPolicy")
    'Call ConSet(ChkbGetInt, "bGetInt")
    Call ConSet(CmbiROPMethod, "iROPMethod") 'm_iROPMethodRW =
    Call ConSet(CmbiBatchRule, "iBatchRule")
    'Call ConSet(EdtfFixSupply, "fFixSupply")
    Call ConSet(EdtiAssureProvideDays, "iAssureProvideDays") 'm_iAssureProvideDaysRW =
    Call ConSet(ChkbROP, "bROP")
    
    'Call ConSet(EdtfFixedBatch, "fFixedBatch") 'm_fFixedBatchRW =
    'Call ConSet(EdtfBatchIncrement, "fBatchIncrement") 'm_fBatchIncrementRW =
    'Call ConSet(EdtfMaxOrder, "fMaxOrder")
    'Call ConSet(EdtfMinOrder, "fMinOrder")
    'm_iOrderIntervalDaysRW = ConSet(EdtiOrderIntervalDays, "iOrderIntervalDays")
    Call ConSet(EdtiInvBatch, "iInvBatch")
    Call ConSet(EdtiInvAdvance, "iInvAdvance")
    Call ConSet(EdtIadvanceDate, "IadvanceDate")
    Call ConSet(EdtfVagQuantity, "fVagQuantity") 'm_fVagQuantityRW =
    Call ConSet(EdtfSubscribePoint, "fSubscribePoint") 'm_fSubscribePointRW =
            
End Sub

'------------------------------------------
'功能：设置字段编辑长度(规定接口)
'参数： Rs：            数据结构数据集
'       iQuanDecDgt：   数量数据精度
'------------------------------------------
Public Sub SetFldLength(Rs As ADODB.Recordset, iQuanDecDgt As Integer)
    m_iQuanDecDgt = iQuanDecDgt
    Call g_oPub.SetDblLen(EdtfSubscribePoint, , m_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtiInvBatch, , m_iQuanDecDgt)
    'Call g_oPub.SetDblLen(EdtfFixedBatch, , m_iQuanDecDgt)
    'Call g_oPub.SetDblLen(EdtfBatchIncrement, , m_iQuanDecDgt)
    'Call g_oPub.SetDblLen(EdtfMaxOrder, , m_iQuanDecDgt)
    'Call g_oPub.SetDblLen(EdtfMinOrder, , m_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtfVagQuantity, , m_iQuanDecDgt)
    
    'Call g_oPub.SetIntLen(EdtiOrderIntervalDays)
    Call g_oPub.SetIntLen(EdtiAssureProvideDays)
    Call g_oPub.SetIntLen(EdtiInvAdvance)
    'Call g_oPub.SetDblLen(EdtfFixSupply, , m_iQuanDecDgt)
End Sub

'---------------------------------------
'功能：清空编辑框和CheckBox、comboBox框等(规定接口)
'---------------------------------------
Public Sub Emptyallfields()
    Dim i As Long
    Dim Con As Control
    For Each Con In Controls
        If TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then Con.value = 0
        If TypeOf Con Is UFCOMBOBOXLib.UFComboBox Then Con.ListIndex = -1
        If TypeOf Con Is Edit Then
            Con.Text = ""
            Con.UToolTipText = ""
            Con.Tag = ""
        End If
    Next Con
'    CmbiPlanPolicy.ListIndex = 1 '因赋值，导致CmbiROPMethod要选项，故CmbiROPMethod赋值在前
    CmbiROPMethod.ListIndex = -1
    ChkbROP_Click
End Sub



'-----------------------------------------------
'功能：完成填充所有字段内容的过程(规定接口)
'传入的参数：RsCard：需求填写的数据源（数据集）
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    m_bFilling = True
    On Error Resume Next
    ChkbROP.value = ChkValue(RsCard!bROP)
    ChkbROP_Click
    
    Dim sTemp As String
'    CmbiPlanPolicy.ListIndex = TxtValue(RsCard!iPlanPolicy, -1)
    'If CmbiPlanPolicy.ListIndex = -1 Then '2003-09-04强制执行
        'Call CmbiPlanPolicy_Click
    'End If
    'ChkbGetInt.Value = ChkValue(RsCard!bGetInt)
    CmbiROPMethod.ListIndex = TxtValue(RsCard!iROPMethod, 0) - 1
    EdtfSubscribePoint = g_oPub.FormatNum(RsCard!fSubscribePoint, m_iQuanDecDgt)
    If TxtValue(RsCard!iBatchRule) = "" Or TxtValue(RsCard!iBatchRule) = 0 Then
        CmbiBatchRule.ListIndex = -1
        Call CmbiBatchRule_Click
    Else
        CmbiBatchRule.ListIndex = -1 '防止原先存储的数据现在不能读取
        CmbiBatchRule.Text = strBATCHRULE(TxtValue(RsCard!iBatchRule))
    End If
    EdtiInvBatch.Text = g_oPub.FormatNum(RsCard!iinvbatch, m_iQuanDecDgt)
    'EdtfFixedBatch.Text = g_oPub.FormatNum(RsCard!fFixedBatch, m_iQuanDecDgt)
    'EdtfBatchIncrement.Text = g_oPub.FormatNum(RsCard!fBatchIncrement, m_iQuanDecDgt)
    'EdtfMaxOrder.Text = g_oPub.FormatNum(RsCard!fMaxOrder, m_iQuanDecDgt)
    'EdtfMinOrder.Text = g_oPub.FormatNum(RsCard!fMinOrder, m_iQuanDecDgt)
    'EdtiOrderIntervalDays.Text = TxtValue(RsCard!iOrderIntervalDays)
    EdtiAssureProvideDays.Text = TxtValue(RsCard!iAssureProvideDays)
    EdtiInvAdvance.Text = TxtValue(RsCard!iInvAdvance)
    EdtIadvanceDate.Text = TxtValue(RsCard!IadvanceDate)
    'edtiAlterAdvance.Text = TxtValue(RsCard!iChangedAdvance)
    'EdtfAlterBaseNum.Text = g_oPub.FormatNum(RsCard!fAlterBaseNum, m_iQuanDecDgt)
    EdtfVagQuantity = g_oPub.FormatNum((RsCard!fVagQuantity), m_iQuanDecDgt)
    EdtfSubscribePoint.Tag = ""
    
    'EdtfFixSupply.Text = g_oPub.FormatNum(RsCard!fFixSupply, m_iQuanDecDgt)
    
        
    m_bFilling = False
End Sub


'-----------------------------------------
'功能：获得保存的字符串(规定接口)
'参数： bFlag： 是否正确
'返回： 保存的Xml字符串
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim sXml As String
    Dim i As Integer
    Call g_oPub.CheckValid(UserControl.ActiveControl)
    If Not (UserControl.ActiveControl Is Nothing) Then
        Select Case UserControl.ActiveControl.Name
            Case EdtiInvAdvance.Name, EdtfVagQuantity.Name ', EdtiSafeNum.Name
                CalculateSubscribePoint
        End Select
    End If
'    sXml = sXml + "<iPlanPolicy>" + CStr(CmbiPlanPolicy.ListIndex) + "</iPlanPolicy>"
    sXml = sXml + "<iROPMethod>" + CStr(CmbiROPMethod.ListIndex + 1) + "</iROPMethod>"
    For i = 0 To UBound(strBATCHRULE)
        If CmbiBatchRule.Text = strBATCHRULE(i) Then
            Exit For
        End If
    Next i
    If i = UBound(strBATCHRULE) + 1 Then
        i = 0 '仍为空
    End If
    sXml = sXml + "<iBatchRule>" + CStr(i) + "</iBatchRule>"
    'Call EleXML(sXml, "bGetInt", ChkbGetInt)
    Call EleXML(sXml, "fSubscribePoint", EdtfSubscribePoint)
    Call EleXML(sXml, "iinvbatch", EdtiInvBatch)
    'Call EleXML(sXml, "fFixedBatch", EdtfFixedBatch)
    'Call EleXML(sXml, "fBatchIncrement", EdtfBatchIncrement)
    'Call EleXML(sXml, "fMaxOrder", EdtfMaxOrder)
    'Call EleXML(sXml, "fMinOrder", EdtfMinOrder)
    'Call EleXML(sXml, "iOrderIntervalDays", EdtiOrderIntervalDays)
    Call EleXML(sXml, "iAssureProvideDays", EdtiAssureProvideDays)
    Call EleXML(sXml, "iinvadvance", EdtiInvAdvance)
    Call EleXML(sXml, "fVagQuantity", EdtfVagQuantity)
                                            
    'Call EleXML(sXml, "fFixSupply", EdtfFixSupply)
    Call EleXML(sXml, "bROP", ChkbROP)
    
    GetSaveXml = sXml
End Function



Private Sub CmbiBatchRule_Click()
    RaiseEvent ActiveSaveBtn
'    If CmbiBatchRule.Text = strBATCHRULE(2) Then
'        'If m_fFixedBatchRW = 2 Then
'        If EdtfFixedBatch.Locked = false Then
'            EdtfFixedBatch.Enabled = True
'        End If
'    Else
'        EdtfFixedBatch.Enabled = False
'        EdtfFixedBatch.Text = ""
'    End If
    ControlEdtfVagQuantity
End Sub

'-------------------------------------
'功能：控制【日均耗量】等活动状态
'-------------------------------------
Private Sub ControlEdtfVagQuantity()
    'If CmbiROPMethod.Text = "自动" Or CmbiBatchRule.Text = strBATCHRULE(5) Then
    If CmbiROPMethod.ListIndex = 1 Or CmbiBatchRule.Text = strBATCHRULE(5) Then
        'If m_fVagQuantityRW = 2 Then
        If EdtfVagQuantity.Locked = False Then
            EdtfVagQuantity.Enabled = True
        End If
    Else
        EdtfVagQuantity.Enabled = False
        EdtfVagQuantity.Text = ""
    End If

'''    '1．当"批量规则"为固定批量时，该字段必输，默认为1；
'''    '2．所输数值应大于零；
'''    '3．当"批量规则"为其他选项时，不可输入。
'''    '当存货为ROP件时，请控制批量增量不可以输入。2003.07.07
'''    If CmbiBatchRule.Text = strBATCHRULE(2) And CmbiPlanPolicy.ListIndex <> 2 Then
'''        'If m_fBatchIncrementRW = 2 Then
'''        If EdtfBatchIncrement.Locked = false Then
'''            EdtfBatchIncrement.Enabled = True
'''        End If
'''    Else
'''        EdtfBatchIncrement.Enabled = False
'''        EdtfBatchIncrement.Text = ""
'''    End If

'    '1．【订货间隔天数】当批量规则为【期间批量】时该字段可手工输入，必须输入，默认为1；
'    '2．所输数值应大于等于0，并且为整数；
'    '3．否则不可输入。
'    If CmbiBatchRule.Text = strBATCHRULE(3) Then
'        If m_iOrderIntervalDaysRW = 2 Then
'            EdtiOrderIntervalDays.Enabled = True
'        End If
'    Else
'        EdtiOrderIntervalDays.Enabled = False
'        EdtiOrderIntervalDays.Text = ""
'    End If

    '1．【保证供应天数】当批量规则为【历史消耗量】时该字段可手工输入，必须输入，默认为1；
    '2．所输数值应大于等于0，并且为整数；
    '3．否则不可输入。
    If CmbiBatchRule.Text = strBATCHRULE(5) Then
        'If m_iAssureProvideDaysRW = 2 Then
        If EdtiAssureProvideDays.Locked = False Then
            EdtiAssureProvideDays.Enabled = True
        End If
    Else
        EdtiAssureProvideDays.Enabled = False
        EdtiAssureProvideDays.Text = ""
    End If
End Sub

Private Sub CmbiPlanPolicy_Click()
'''    If CmbiPlanPolicy.Text = STR_ROP Then
'''        If m_bFilling = False Then '防止填写前面字段时，受后面字段控制
'''            If BSelfValue = 1 Then
'''                ShowMsg ("因“基本”页签中“自制属性”,计划策略不可选择“" + STR_ROP + "”！")
'''                CmbiPlanPolicy.ListIndex = -1
'''            End If
'''        End If
'''
'''        'If m_iROPMethodRW = 2 Then
'''        If CmbiROPMethod.Visible = True Then
'''            CmbiROPMethod.Enabled = True
'''        End If
'''        CmbiROPMethod.ListIndex = 0
'''        'If m_fSubscribePointRW = 2 Then
'''        If EdtfSubscribePoint.Locked = false Then
'''            EdtfSubscribePoint.Enabled = True
'''        End If
'''
'''        '由用户手工输入。可输可不输，默认为0，如果为空，等同为0。
'''        '当计划策略为ROP件时，该字段不可输入。
'''        EdtiAlterAdvance.Enabled = False
'''        EdtiAlterAdvance.Text = ""
'''        '手工输入，可输可不输，默认为1。
'''        '当计划策略为ROP件时，该字段不可输入
'''        EdtfAlterBaseNum.Enabled = False
'''        EdtfAlterBaseNum.Text = ""
'''    Else
'''        CmbiROPMethod.Enabled = False
'''        CmbiROPMethod.ListIndex = -1
'''
'''        EdtfSubscribePoint.Enabled = False
'''        EdtfSubscribePoint.Text = ""
'''        'If m_iChangedAdvanceRW = 2 Then
'''        If EdtiAlterAdvance.Locked = false Then
'''            EdtiAlterAdvance.Enabled = True
'''        End If
'''        'If m_fAlterBaseNumRW = 2 Then
'''        If EdtfAlterBaseNum.Locked = false Then
'''            EdtfAlterBaseNum.Enabled = True
'''        End If
'''
'''    End If
'''    CmbiBatchRule.Clear '批量规则
'''
'''    Select Case CmbiPlanPolicy.ListIndex
'''        Case 1: 'MRP件
'''            CmbiBatchRule.AddItem strBATCHRULE(1) '"直接批量"
'''            CmbiBatchRule.AddItem strBATCHRULE(2) '"固定批量"
'''            'CmbiBatchRule.AddItem strBATCHRULE(3) '"期间批量"
'''            CmbiBatchRule.ListIndex = 0
'''        Case 2: 'ROP件
'''            CmbiBatchRule.AddItem strBATCHRULE(4) '"补充至最高库"
'''            CmbiBatchRule.AddItem strBATCHRULE(2) '"固定批量"
'''            CmbiBatchRule.AddItem strBATCHRULE(5) '"历史消耗量"
'''            CmbiBatchRule.ListIndex = 0
'''        Case Else
'''
'''    End Select
'''
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub CmbiROPMethod_Click()
    RaiseEvent ActiveSaveBtn
    CalculateSubscribePoint
    ControlEdtfVagQuantity
End Sub


'-------------------------------------------------------
'功能：计算再订货点
'-------------------------------------------------------
Public Sub CalculateSubscribePoint()
    If CmbiROPMethod.ListIndex <> 1 Then '不是自动（手工或没有选择）即退出
        'EdtfSubscribePoint.Text = ""
        Exit Sub
    End If
    If EdtfSubscribePoint.Tag = "" Then Exit Sub
    Dim fVagQuantity As Double
    Dim dAll As Double
    Dim iInvAdvance As Long
    On Error GoTo Err_Info
    If Trim(EdtfVagQuantity.Text) = "" Then
        fVagQuantity = 1
    Else
        fVagQuantity = CDbl(EdtfVagQuantity.Text)
    End If
    If Trim(m_ISafeNum) = "" Then
        m_ISafeNum = 0
    Else
        m_ISafeNum = CDbl(m_ISafeNum)
    End If
    If Trim(EdtiInvAdvance.Text) = "" Then
        iInvAdvance = 1
    Else
        iInvAdvance = CLng(EdtiInvAdvance.Text)
    End If
    '按公式计算：再订货点=日均耗量*固定提前期+安全库存
    dAll = fVagQuantity * iInvAdvance + m_ISafeNum
    If dAll >= 1 * (10 ^ (EdtfSubscribePoint.MaxLength - EdtfSubscribePoint.NumPoint - 2)) Then
        ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.PLAN.561_1") 'U8.AA.U8TABPAGES.PLAN.561_1="根据公式(再订货点=日均耗量*固定提前期+安全库存)计算，得出的再订货点数值太大！"
        GoTo Err_Info
    End If
    EdtfSubscribePoint.Text = CStr(dAll)
    Call g_oPub.FormatCon(EdtfSubscribePoint)
    EdtfSubscribePoint.Tag = ""
    Exit Sub
Err_Info:
    EdtfSubscribePoint.Text = ""
End Sub



Private Sub EdtfBatchIncrement_LostFocus()
    Call g_oPub.FormatCon(EdtfBatchIncrement2)
End Sub

'Private Sub EdtfFixedBatch_LostFocus()
'    Call CheckBatch(EdtfFixedBatch, EdtfMinOrder.Text, EdtfFixedBatch.Text, EdtfMaxOrder.Text, "最小订货量", "固定批量", "最大订货量")
'    Call g_oPub.FormatCon(EdtfFixedBatch)
'End Sub

'Private Sub EdtfMaxOrder_LostFocus()
'    Call CheckBatch(EdtfMaxOrder, EdtfMinOrder.Text, EdtfFixedBatch.Text, EdtfMaxOrder.Text, "最小订货量", "固定批量", "最大订货量")
'    Call g_oPub.FormatCon(EdtfMaxOrder)
'End Sub

'Private Sub EdtfMinOrder_LostFocus()
'    Call CheckBatch(EdtfMinOrder, EdtfMinOrder.Text, EdtfFixedBatch.Text, EdtfMaxOrder.Text, "最小订货量", "固定批量", "最大订货量")
'    Call g_oPub.FormatCon(EdtfMinOrder)
'End Sub

'---------------------------------------------
'功能： 输入时，应符合"最小订货量≤固定批量≤最大订货量"
'参数： Con：   Edit控件对象
'       Low:    最低值
'       Mid：   中间值
'       Top：   最高值
'       LowCh:  最低值中文名
'       MidCh:  中间值中文名
'       TopCh： 最高值中文名
'---------------------------------------------
Private Sub CheckBatch(Con As Object, Low As String, Mid As String, Top As String, LowCh As String, MidCh As String, TopCh As String)
    ReDim g_arr(1 To 1)
    If Low <> "" Then
        If Not IsNumeric(Low) Then
            g_arr(1) = LowCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"‘" + LowCh + "’必须为数值！"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Mid <> "" Then
        If Not IsNumeric(Mid) Then
            g_arr(1) = MidCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"‘" + MidCh + "’必须为数值！"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Top <> "" Then
        If Not IsNumeric(Top) Then
            g_arr(1) = TopCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"‘" + TopCh + "’必须为数值！"
            Con.Text = ""
            Exit Sub
        End If
    End If
    
    ReDim g_arr(1 To 2)
    If Low <> "" And Mid <> "" Then
        If val(Low) > val(Mid) Then
            g_arr(1) = LowCh
            g_arr(2) = MidCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"‘" + LowCh + "’不得大于‘" + MidCh + "’"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Mid <> "" And Top <> "" Then
         If val(Mid) > val(Top) Then
            g_arr(1) = MidCh
            g_arr(2) = TopCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"‘" + MidCh + "’不得大于‘" + TopCh + "’"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Low <> "" And Top <> "" Then
         If val(Low) > val(Top) Then
            g_arr(1) = LowCh
            g_arr(2) = TopCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"‘" + LowCh + "’不得大于‘" + TopCh + "’"
            Con.Text = ""
            Exit Sub
        End If
    End If
End Sub

Private Sub EdtfSubscribePoint_LostFocus()
    Call g_oPub.FormatCon(EdtfSubscribePoint)
End Sub

Private Sub EdtfVagQuantity_Change()
    EdtfSubscribePoint.Tag = "changed"
End Sub

Private Sub EdtfVagQuantity_LostFocus()
    Call g_oPub.FormatCon(EdtfVagQuantity)
    CalculateSubscribePoint
End Sub

Private Sub EdtiInvAdvance_Change()
    EdtfSubscribePoint.Tag = "changed"
End Sub

Private Sub EdtiInvAdvance_LostFocus()
    CalculateSubscribePoint
End Sub

Private Sub EdtiInvBatch_LostFocus()
    Call g_oPub.FormatCon(EdtiInvBatch)
End Sub

''''---------------------------------------
''''功能：获得计划策略内容
''''---------------------------------------
'''Public Property Get IPlanPolicyText() As Variant
'''    IPlanPolicyText = CmbiPlanPolicy.Text
'''End Property

'--------------------------------
'属性：安全库存
'--------------------------------
Public Property Get ISafeNum() As String
    ISafeNum = m_ISafeNum
End Property

'--------------------------------
'属性：安全库存
'--------------------------------
Public Property Let ISafeNum(ByVal vNewValue As String)
    m_ISafeNum = vNewValue
End Property

''''------------------------------
''''属性：是否自制
''''------------------------------
'''Public Property Get BSelfValue() As Integer
'''    BSelfValue = m_bSelfValue
'''End Property

''''------------------------------
''''属性：是否自制
''''------------------------------
'''Public Property Let BSelfValue(ByVal vNewValue As Integer)
'''    m_bSelfValue = vNewValue
'''End Property

'------------------------------
'属性：再订货点Tag
'------------------------------
Public Property Get FSubscribePointTag() As String
    FSubscribePointTag = EdtfSubscribePoint.Tag
End Property

'------------------------------
'属性：再订货点Tag
'------------------------------
Public Property Let FSubscribePointTag(ByVal vNewValue As String)
    EdtfSubscribePoint.Tag = vNewValue
End Property



Public Sub GetNum(FixQty As String)
    'MinQty = EdtfMinSupply.Text
    'MulQty = EdtfSupplyMulti.Text
    FixQty = EdtiInvBatch.Text
End Sub

Public Function GetInvPlanData() As String
    GetInvPlanData = "<FixQty>" + EdtiInvBatch.Text + "</FixQty>"
End Function


Public Property Get ChkbROPValue() As Integer
    ChkbROPValue = ChkbROP.value
End Property

Public Property Let ChkbROPValue(ByVal vNewValue As Integer)
    On Error Resume Next
    ChkbROP.value = vNewValue
End Property

'============================================================================================================================================
'分析：
'       目前平台现有服务之所以无法满足控件内部的元素自动布局，那么我的想法就是想办法把控件内部的元素主动得到传给平台，那么问题基本也就解决了。
'结论：
'       在每个控件内部加入此函数，取出本控件内部的所有元素，并返回元素集合。
'       在调用平台布局服务的时候把已经得到的内部元素作为集合传给平台布局服务。（已经协商好，平台会针对此问题增加新的接口）
'============================================================================================================================================
Private Function GetControls() As Collection
    Dim iCount As Integer
    Dim objCollection As New Collection
    For iCount = 0 To UserControl.Controls.Count - 1
        objCollection.Add UserControl.Controls(iCount)
    Next iCount
    
    Set GetControls = objCollection
End Function
