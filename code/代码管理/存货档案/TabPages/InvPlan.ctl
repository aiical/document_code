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
      Caption         =   "ROP��"
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
      Caption         =   "�Ƿ�ȡ��"
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
      Caption         =   "�ƻ�����"
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
      Caption         =   "��������"
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
      Caption         =   "�����������"
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
      Caption         =   "��С������"
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
      Caption         =   "��󶩻���"
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
      Caption         =   "�վ�����"
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
      Caption         =   "ROP��������"
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
      Caption         =   "�ٶ�����"
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
      Caption         =   "�ٶ����㷽��"
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
      Caption         =   "�̶���ǰ��"
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
      Caption         =   "�ۼ���ǰ��"
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
      Caption         =   "�̶���Ӧ��"
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
      Caption         =   "��֤��Ӧ����"
   End
End
Attribute VB_Name = "InvPlan"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'���ڷ�ҳ(�涨�ӿ�)
Public Event EdtKeyPress(fldName As String, KeyAscii As Integer)
'���ڼ���水ť(�涨�ӿ�)
Public Event ActiveSaveBtn()

Public Event SetcPlanMethod()



Dim STR_ROP   As String
Dim strBATCHRULE(6) As String '��������

Dim m_Dom As New DOMDocument
Dim m_Ele As IXMLDOMElement

Dim m_SrvDB As Object

Dim m_cUserName As String '�û���

Dim m_sRFldAuthInv As String  'ֻ��Ȩ���ֶ���
Dim m_sNFldAuthInv As String  '��Ȩ���ֶ���
Dim m_iQuanDecDgt As Integer  '�������С��λ
Dim m_bFilling As Boolean '�Ƿ�����д����

''Dim m_bSelfValue As Integer '�Ƿ���������
Dim m_ISafeNum As String '��ȫ���
Dim m_sRowAuthDept As String '���ŵ���Ȩ���ַ���
Dim m_sRowAuthPerson As String  'ְԱ����Ȩ���ַ���
Dim m_bSave As Boolean '�Ƿ���Ա���

'



'--------------------------------
'���ܣ��������ݳ�ʼ������(�涨�ӿ�)
'������
'   SrvDb:      ���ݷ������
'   oPub:       ������������
'   sXml:       ��������
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
'        '�ǹ�ҵ��
'        FrameFactory.Visible = False
'    End If
    m_sRowAuthDept = GetParaVal(sXml, "g_sRowAuthDept")
    m_sRowAuthPerson = GetParaVal(sXml, "g_sRowAuthPerson")
    
    Call InitFace(CLng(GetParaVal(sXml, "HelpContextId", "0")))
    STR_ROP = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.rop") ''"ROP��"
'    CmbiPlanPolicy.Clear '�ƻ�����
'    CmbiPlanPolicy.AddItem ""
'    CmbiPlanPolicy.AddItem "MRP��"
'    CmbiPlanPolicy.AddItem STR_ROP
'    'CmbiPlanPolicy.AddItem "�����"
    
    
    CmbiROPMethod.Clear '�ٶ����㷽��
    CmbiROPMethod.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iropmethod1") '"�ֹ�"
    CmbiROPMethod.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iropmethod2") '"�Զ�"
'    CmbiPlanPolicy.ListIndex = 1 '��ֵ������CmbiROPMethodҪѡ���CmbiROPMethod��ֵ��ǰ
    CmbiROPMethod.ListIndex = -1
    
    strBATCHRULE(0) = ""
    strBATCHRULE(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule1") '"ֱ������"
    strBATCHRULE(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule2") '"�̶�����"
    strBATCHRULE(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule3") '"�ڼ�����" '�����ÿգ�ͨ������ӷ�ʽ���Է���strBATCHRULE(0)����
    strBATCHRULE(4) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule4") '"��������߿�"
    strBATCHRULE(5) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule5") '"��ʷ������"

    
    CmbiBatchRule.Clear '��������
    CmbiBatchRule.AddItem strBATCHRULE(4) '"��������߿�"
    CmbiBatchRule.AddItem strBATCHRULE(2) '"�̶�����"
    CmbiBatchRule.AddItem strBATCHRULE(5) '"��ʷ������"
    CmbiBatchRule.ListIndex = 0

    
    'EdtfFixedBatch.BadStr = EdtfFixedBatch.BadStr + "-" '������ֵӦ������
    'EdtfMaxOrder.BadStr = EdtfMaxOrder.BadStr + "-"
    'EdtfMinOrder.BadStr = EdtfMinOrder.BadStr + "-"
    'EdtfBatchIncrement.BadStr = EdtfBatchIncrement.BadStr + "-" '��������
    EdtiAssureProvideDays.BadStrEx = "-" '��֤��Ӧ����
    
    
    Init = True
    Exit Function
Err_Info:
    Init = False
End Function

'---------------------------------------------
'���ܣ���ʼ�����棺���塢�����ַ�
'��������
'---------------------------------------------
Private Sub InitFace(HelpContextId As Long)
    Dim Con As Control
    On Error Resume Next
    With UserControl
        For Each Con In .Controls
                Con.Font.Name = g_oPub.FontName ' "����" '"MS Sans Serif" '
                Con.Font.Size = g_oPub.FontSize '9 'С�����
                Con.Font.Charset = g_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            
            
            If TypeOf Con Is Edit Or LCase(Left(Con.Name, 3)) = "edt" Then
                'Con.BadStr = g_oPub.BadStr
                If Con.Property = EditStr Then
                   Con.Property = EditNormal '��������ո�
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
        'If CmbiBatchRule.Visible = True Then'ֱ�Ӵ�������˫�������visible��false
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

''        '���û��ֹ����롣����ɲ��䣬Ĭ��Ϊ0�����Ϊ�գ���ͬΪ0��
''        '���ƻ�����ΪROP��ʱ�����ֶβ������롣
''        EdtiAlterAdvance.Enabled = False
''        EdtiAlterAdvance.Text = ""
''        '�ֹ����룬����ɲ��䣬Ĭ��Ϊ1��
''        '���ƻ�����ΪROP��ʱ�����ֶβ�������
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
'���ܣ� �����ֶζ�дȨ�ޣ�������Ӧ�Ŀؼ�״̬
'������ Con��       �ؼ�����
'       FldName��   �ֶ�����
'���أ� 0���޶�дȨ�ޣ�1����Ȩ�ޣ�2��дȨ��
'---------------------------------------
Private Function ConSet(Con As Object, ByVal fldName As String) As Integer
    ConSet = g_oPub.ConAuthSet(UserControl.Controls, Con, fldName, m_sRFldAuthInv, m_sNFldAuthInv)
End Function

'------------------------------------------------------------
'���ܣ������ֶζ�дȨ��(�涨�ӿ�)
'������ sRFldAuthInv��   ��Ȩ���ַ���
'       sNFldAuthInv:   ��Ȩ���ַ���
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
'���ܣ������ֶα༭����(�涨�ӿ�)
'������ Rs��            ���ݽṹ���ݼ�
'       iQuanDecDgt��   �������ݾ���
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
'���ܣ���ձ༭���CheckBox��comboBox���(�涨�ӿ�)
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
'    CmbiPlanPolicy.ListIndex = 1 '��ֵ������CmbiROPMethodҪѡ���CmbiROPMethod��ֵ��ǰ
    CmbiROPMethod.ListIndex = -1
    ChkbROP_Click
End Sub



'-----------------------------------------------
'���ܣ������������ֶ����ݵĹ���(�涨�ӿ�)
'����Ĳ�����RsCard��������д������Դ�����ݼ���
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    m_bFilling = True
    On Error Resume Next
    ChkbROP.value = ChkValue(RsCard!bROP)
    ChkbROP_Click
    
    Dim sTemp As String
'    CmbiPlanPolicy.ListIndex = TxtValue(RsCard!iPlanPolicy, -1)
    'If CmbiPlanPolicy.ListIndex = -1 Then '2003-09-04ǿ��ִ��
        'Call CmbiPlanPolicy_Click
    'End If
    'ChkbGetInt.Value = ChkValue(RsCard!bGetInt)
    CmbiROPMethod.ListIndex = TxtValue(RsCard!iROPMethod, 0) - 1
    EdtfSubscribePoint = g_oPub.FormatNum(RsCard!fSubscribePoint, m_iQuanDecDgt)
    If TxtValue(RsCard!iBatchRule) = "" Or TxtValue(RsCard!iBatchRule) = 0 Then
        CmbiBatchRule.ListIndex = -1
        Call CmbiBatchRule_Click
    Else
        CmbiBatchRule.ListIndex = -1 '��ֹԭ�ȴ洢���������ڲ��ܶ�ȡ
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
'���ܣ���ñ�����ַ���(�涨�ӿ�)
'������ bFlag�� �Ƿ���ȷ
'���أ� �����Xml�ַ���
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
        i = 0 '��Ϊ��
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
'���ܣ����ơ��վ��������Ȼ״̬
'-------------------------------------
Private Sub ControlEdtfVagQuantity()
    'If CmbiROPMethod.Text = "�Զ�" Or CmbiBatchRule.Text = strBATCHRULE(5) Then
    If CmbiROPMethod.ListIndex = 1 Or CmbiBatchRule.Text = strBATCHRULE(5) Then
        'If m_fVagQuantityRW = 2 Then
        If EdtfVagQuantity.Locked = False Then
            EdtfVagQuantity.Enabled = True
        End If
    Else
        EdtfVagQuantity.Enabled = False
        EdtfVagQuantity.Text = ""
    End If

'''    '1����"��������"Ϊ�̶�����ʱ�����ֶα��䣬Ĭ��Ϊ1��
'''    '2��������ֵӦ�����㣻
'''    '3����"��������"Ϊ����ѡ��ʱ���������롣
'''    '�����ΪROP��ʱ������������������������롣2003.07.07
'''    If CmbiBatchRule.Text = strBATCHRULE(2) And CmbiPlanPolicy.ListIndex <> 2 Then
'''        'If m_fBatchIncrementRW = 2 Then
'''        If EdtfBatchIncrement.Locked = false Then
'''            EdtfBatchIncrement.Enabled = True
'''        End If
'''    Else
'''        EdtfBatchIncrement.Enabled = False
'''        EdtfBatchIncrement.Text = ""
'''    End If

'    '1���������������������������Ϊ���ڼ�������ʱ���ֶο��ֹ����룬�������룬Ĭ��Ϊ1��
'    '2��������ֵӦ���ڵ���0������Ϊ������
'    '3�����򲻿����롣
'    If CmbiBatchRule.Text = strBATCHRULE(3) Then
'        If m_iOrderIntervalDaysRW = 2 Then
'            EdtiOrderIntervalDays.Enabled = True
'        End If
'    Else
'        EdtiOrderIntervalDays.Enabled = False
'        EdtiOrderIntervalDays.Text = ""
'    End If

    '1������֤��Ӧ����������������Ϊ����ʷ��������ʱ���ֶο��ֹ����룬�������룬Ĭ��Ϊ1��
    '2��������ֵӦ���ڵ���0������Ϊ������
    '3�����򲻿����롣
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
'''        If m_bFilling = False Then '��ֹ��дǰ���ֶ�ʱ���ܺ����ֶο���
'''            If BSelfValue = 1 Then
'''                ShowMsg ("�򡰻�����ҳǩ�С��������ԡ�,�ƻ����Բ���ѡ��" + STR_ROP + "����")
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
'''        '���û��ֹ����롣����ɲ��䣬Ĭ��Ϊ0�����Ϊ�գ���ͬΪ0��
'''        '���ƻ�����ΪROP��ʱ�����ֶβ������롣
'''        EdtiAlterAdvance.Enabled = False
'''        EdtiAlterAdvance.Text = ""
'''        '�ֹ����룬����ɲ��䣬Ĭ��Ϊ1��
'''        '���ƻ�����ΪROP��ʱ�����ֶβ�������
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
'''    CmbiBatchRule.Clear '��������
'''
'''    Select Case CmbiPlanPolicy.ListIndex
'''        Case 1: 'MRP��
'''            CmbiBatchRule.AddItem strBATCHRULE(1) '"ֱ������"
'''            CmbiBatchRule.AddItem strBATCHRULE(2) '"�̶�����"
'''            'CmbiBatchRule.AddItem strBATCHRULE(3) '"�ڼ�����"
'''            CmbiBatchRule.ListIndex = 0
'''        Case 2: 'ROP��
'''            CmbiBatchRule.AddItem strBATCHRULE(4) '"��������߿�"
'''            CmbiBatchRule.AddItem strBATCHRULE(2) '"�̶�����"
'''            CmbiBatchRule.AddItem strBATCHRULE(5) '"��ʷ������"
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
'���ܣ������ٶ�����
'-------------------------------------------------------
Public Sub CalculateSubscribePoint()
    If CmbiROPMethod.ListIndex <> 1 Then '�����Զ����ֹ���û��ѡ�񣩼��˳�
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
    '����ʽ���㣺�ٶ�����=�վ�����*�̶���ǰ��+��ȫ���
    dAll = fVagQuantity * iInvAdvance + m_ISafeNum
    If dAll >= 1 * (10 ^ (EdtfSubscribePoint.MaxLength - EdtfSubscribePoint.NumPoint - 2)) Then
        ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.PLAN.561_1") 'U8.AA.U8TABPAGES.PLAN.561_1="���ݹ�ʽ(�ٶ�����=�վ�����*�̶���ǰ��+��ȫ���)���㣬�ó����ٶ�������ֵ̫��"
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
'    Call CheckBatch(EdtfFixedBatch, EdtfMinOrder.Text, EdtfFixedBatch.Text, EdtfMaxOrder.Text, "��С������", "�̶�����", "��󶩻���")
'    Call g_oPub.FormatCon(EdtfFixedBatch)
'End Sub

'Private Sub EdtfMaxOrder_LostFocus()
'    Call CheckBatch(EdtfMaxOrder, EdtfMinOrder.Text, EdtfFixedBatch.Text, EdtfMaxOrder.Text, "��С������", "�̶�����", "��󶩻���")
'    Call g_oPub.FormatCon(EdtfMaxOrder)
'End Sub

'Private Sub EdtfMinOrder_LostFocus()
'    Call CheckBatch(EdtfMinOrder, EdtfMinOrder.Text, EdtfFixedBatch.Text, EdtfMaxOrder.Text, "��С������", "�̶�����", "��󶩻���")
'    Call g_oPub.FormatCon(EdtfMinOrder)
'End Sub

'---------------------------------------------
'���ܣ� ����ʱ��Ӧ����"��С�������̶ܹ���������󶩻���"
'������ Con��   Edit�ؼ�����
'       Low:    ���ֵ
'       Mid��   �м�ֵ
'       Top��   ���ֵ
'       LowCh:  ���ֵ������
'       MidCh:  �м�ֵ������
'       TopCh�� ���ֵ������
'---------------------------------------------
Private Sub CheckBatch(Con As Object, Low As String, Mid As String, Top As String, LowCh As String, MidCh As String, TopCh As String)
    ReDim g_arr(1 To 1)
    If Low <> "" Then
        If Not IsNumeric(Low) Then
            g_arr(1) = LowCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"��" + LowCh + "������Ϊ��ֵ��"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Mid <> "" Then
        If Not IsNumeric(Mid) Then
            g_arr(1) = MidCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"��" + MidCh + "������Ϊ��ֵ��"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Top <> "" Then
        If Not IsNumeric(Top) Then
            g_arr(1) = TopCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"��" + TopCh + "������Ϊ��ֵ��"
            Con.Text = ""
            Exit Sub
        End If
    End If
    
    ReDim g_arr(1 To 2)
    If Low <> "" And Mid <> "" Then
        If val(Low) > val(Mid) Then
            g_arr(1) = LowCh
            g_arr(2) = MidCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"��" + LowCh + "�����ô��ڡ�" + MidCh + "��"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Mid <> "" And Top <> "" Then
         If val(Mid) > val(Top) Then
            g_arr(1) = MidCh
            g_arr(2) = TopCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"��" + MidCh + "�����ô��ڡ�" + TopCh + "��"
            Con.Text = ""
            Exit Sub
        End If
    End If
    If Low <> "" And Top <> "" Then
         If val(Low) > val(Top) Then
            g_arr(1) = LowCh
            g_arr(2) = TopCh
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"��" + LowCh + "�����ô��ڡ�" + TopCh + "��"
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
''''���ܣ���üƻ���������
''''---------------------------------------
'''Public Property Get IPlanPolicyText() As Variant
'''    IPlanPolicyText = CmbiPlanPolicy.Text
'''End Property

'--------------------------------
'���ԣ���ȫ���
'--------------------------------
Public Property Get ISafeNum() As String
    ISafeNum = m_ISafeNum
End Property

'--------------------------------
'���ԣ���ȫ���
'--------------------------------
Public Property Let ISafeNum(ByVal vNewValue As String)
    m_ISafeNum = vNewValue
End Property

''''------------------------------
''''���ԣ��Ƿ�����
''''------------------------------
'''Public Property Get BSelfValue() As Integer
'''    BSelfValue = m_bSelfValue
'''End Property

''''------------------------------
''''���ԣ��Ƿ�����
''''------------------------------
'''Public Property Let BSelfValue(ByVal vNewValue As Integer)
'''    m_bSelfValue = vNewValue
'''End Property

'------------------------------
'���ԣ��ٶ�����Tag
'------------------------------
Public Property Get FSubscribePointTag() As String
    FSubscribePointTag = EdtfSubscribePoint.Tag
End Property

'------------------------------
'���ԣ��ٶ�����Tag
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
'������
'       Ŀǰƽ̨���з���֮�����޷�����ؼ��ڲ���Ԫ���Զ����֣���ô�ҵ��뷨������취�ѿؼ��ڲ���Ԫ�������õ�����ƽ̨����ô�������Ҳ�ͽ���ˡ�
'���ۣ�
'       ��ÿ���ؼ��ڲ�����˺�����ȡ�����ؼ��ڲ�������Ԫ�أ�������Ԫ�ؼ��ϡ�
'       �ڵ���ƽ̨���ַ����ʱ����Ѿ��õ����ڲ�Ԫ����Ϊ���ϴ���ƽ̨���ַ��񡣣��Ѿ�Э�̺ã�ƽ̨����Դ����������µĽӿڣ�
'============================================================================================================================================
Private Function GetControls() As Collection
    Dim iCount As Integer
    Dim objCollection As New Collection
    For iCount = 0 To UserControl.Controls.Count - 1
        objCollection.Add UserControl.Controls(iCount)
    Next iCount
    
    Set GetControls = objCollection
End Function
