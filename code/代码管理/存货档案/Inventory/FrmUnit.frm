VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Begin VB.Form FrmUnit 
   Caption         =   "Form1"
   ClientHeight    =   5310
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   7875
   LinkTopic       =   "Form1"
   ScaleHeight     =   5310
   ScaleWidth      =   7875
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin UFStatusBar.UFStatusBarCtl Stb 
      Align           =   2  'Align Bottom
      Height          =   330
      Left            =   0
      TabIndex        =   9
      Top             =   4980
      Width           =   7875
      _ExtentX        =   13891
      _ExtentY        =   582
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   1
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
   End
   Begin UFFrames.UFFrame Frame1 
      Height          =   3285
      Left            =   0
      TabIndex        =   7
      Top             =   720
      Width           =   3212
      Begin UFTREEVIEWLib.UFTreeView Trv 
         Height          =   2415
         Left            =   600
         TabIndex        =   8
         Top             =   600
         Width           =   2295
         _ExtentX        =   4048
         _ExtentY        =   4260
         _Version        =   393217
         Indentation     =   529
         LineStyle       =   1
         Style           =   7
         Appearance      =   1
      End
   End
   Begin UFFrames.UFFrame Frame2 
      Height          =   3885
      Left            =   3360
      TabIndex        =   4
      Top             =   720
      Width           =   4005
      Begin UFFrames.UFFrame Frame3 
         BorderStyle     =   0  'None
         Height          =   1815
         Left            =   120
         TabIndex        =   15
         Top             =   1800
         Width           =   3795
         Begin UFCHECKBOXLib.UFCheckBox ChkbMainUnit 
            Caption         =   "bMainUnit"
            Height          =   255
            Left            =   120
            TabIndex        =   20
            Top             =   60
            Width           =   3375
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbPU 
            Caption         =   "bPU"
            Height          =   255
            Left            =   120
            TabIndex        =   19
            Top             =   420
            Width           =   2955
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbSA 
            Caption         =   "bSA"
            Height          =   195
            Left            =   120
            TabIndex        =   18
            Top             =   810
            Width           =   2955
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbST 
            Caption         =   "bST"
            Height          =   195
            Left            =   120
            TabIndex        =   17
            Top             =   1125
            Width           =   2955
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbCA 
            Caption         =   "bCA"
            Height          =   255
            Left            =   120
            TabIndex        =   16
            Top             =   1440
            Width           =   3015
         End
      End
      Begin EDITLib.Edit EdtiChangExch 
         Height          =   300
         Left            =   1320
         TabIndex        =   2
         Top             =   1125
         Width           =   2325
         _Version        =   65536
         _ExtentX        =   4101
         _ExtentY        =   529
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
         Property        =   4
         NumPoint        =   4
         MaxLength       =   16
         BadStr          =   "`~!@#$^&():|<>?'""\/--"
      End
      Begin EDITLib.Edit EdtCComunitCode 
         Height          =   300
         Left            =   1320
         TabIndex        =   0
         Top             =   360
         Width           =   2325
         _Version        =   65536
         _ExtentX        =   4101
         _ExtentY        =   529
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
         BadStr          =   "`~!@#$^&():|<>?'""\/"
      End
      Begin EDITLib.Edit EdtCComUnitName 
         Height          =   300
         Left            =   1320
         TabIndex        =   1
         Top             =   735
         Width           =   2325
         _Version        =   65536
         _ExtentX        =   4101
         _ExtentY        =   529
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
         BadStr          =   "`~!@#$^&():|<>?'""\/"
      End
      Begin EDITLib.Edit EdtCbarCode 
         Height          =   300
         Left            =   1320
         TabIndex        =   3
         Top             =   1500
         Width           =   2325
         _Version        =   65536
         _ExtentX        =   4101
         _ExtentY        =   529
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
         Property        =   1
         BadStr          =   "`~!@#$^&():|<>?'""\/"
      End
      Begin UFLABELLib.UFLabel Lbl 
         AutoSize        =   -1  'True
         Caption         =   "���������"
         Height          =   195
         Index           =   3
         Left            =   240
         TabIndex        =   14
         Top             =   1530
         Width           =   900
      End
      Begin UFLABELLib.UFLabel Lbl 
         AutoSize        =   -1  'True
         Caption         =   "������"
         Height          =   195
         Index           =   2
         Left            =   240
         TabIndex        =   13
         Top             =   1140
         Width           =   540
      End
      Begin UFLABELLib.UFLabel Lbl 
         AutoSize        =   -1  'True
         Caption         =   "������λ����"
         Height          =   195
         Index           =   1
         Left            =   240
         TabIndex        =   12
         Top             =   765
         Width           =   1080
      End
      Begin UFLABELLib.UFLabel Lbl 
         AutoSize        =   -1  'True
         Caption         =   "������λ����"
         Height          =   195
         Index           =   0
         Left            =   240
         TabIndex        =   11
         Top             =   375
         Width           =   1080
      End
      Begin UFLABELLib.UFLabel Lab2 
         AutoSize        =   -1  'True
         Caption         =   "Label2"
         Height          =   195
         Left            =   1560
         TabIndex        =   6
         Top             =   3645
         Width           =   480
      End
      Begin UFLABELLib.UFLabel Lab1 
         AutoSize        =   -1  'True
         Caption         =   "�������"
         Height          =   195
         Left            =   240
         TabIndex        =   5
         Top             =   3660
         Width           =   900
      End
   End
   Begin MSComctlLib.Toolbar Tlb 
      Align           =   1  'Align Top
      Height          =   570
      Left            =   0
      TabIndex        =   10
      Top             =   0
      Width           =   7875
      _ExtentX        =   13891
      _ExtentY        =   1005
      ButtonWidth     =   609
      ButtonHeight    =   953
      AllowCustomize  =   0   'False
      Appearance      =   1
      Style           =   1
      _Version        =   393216
      Begin MSComctlLib.ImageList Img 
         Left            =   5400
         Top             =   120
         _ExtentX        =   1005
         _ExtentY        =   1005
         BackColor       =   -2147483643
         MaskColor       =   12632256
         _Version        =   393216
      End
   End
   Begin VB.Menu mReport 
      Caption         =   "����(&R)"
      Begin VB.Menu mSetUp 
         Caption         =   "����(&U)"
      End
      Begin VB.Menu mPrint 
         Caption         =   "��ӡ(&P)"
      End
      Begin VB.Menu mPreview 
         Caption         =   "Ԥ��(&V)"
      End
      Begin VB.Menu s1 
         Caption         =   "-"
      End
      Begin VB.Menu mSaveFile 
         Caption         =   "���(&S)"
      End
      Begin VB.Menu s2 
         Caption         =   "-"
      End
      Begin VB.Menu mExit 
         Caption         =   "�˳�(&X)"
         Shortcut        =   ^Q
      End
   End
   Begin VB.Menu mOpt 
      Caption         =   "����(&O)"
      Begin VB.Menu mAdd 
         Caption         =   "����(&A)"
         Shortcut        =   ^A
      End
      Begin VB.Menu mModify 
         Caption         =   "�޸�(&M)"
         Shortcut        =   ^M
      End
      Begin VB.Menu mDelete 
         Caption         =   "ɾ��(&D)"
         Shortcut        =   ^D
      End
      Begin VB.Menu s3 
         Caption         =   "-"
      End
      Begin VB.Menu mBack 
         Caption         =   "�ָ�(&B)"
      End
      Begin VB.Menu mSaveRs 
         Caption         =   "����(&S)"
      End
      Begin VB.Menu s4 
         Caption         =   "-"
      End
      Begin VB.Menu mRefresh 
         Caption         =   "ˢ��(&R)"
      End
   End
   Begin VB.Menu mH 
      Caption         =   "����(&H)"
      Begin VB.Menu mHelp 
         Caption         =   "����"
         Shortcut        =   {F1}
      End
      Begin VB.Menu mAbout 
         Caption         =   "����...(&A)"
      End
   End
End
Attribute VB_Name = "FrmUnit"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'============================================================
'������ƣ�U8�������
'�������ߣ�Visual Basic6.0
'��Ȩ�� �����������
'�������ͣ�ActiveDll
'ģ�鹦�ܣ�������λ������Ϣά��
'����ӿڣ�
'============================================================

Dim g_iExchRateDecDgt As Integer '������С��λ����


Dim sEdtChange(9) As Variant '�ж��Ƿ��޸�
Dim Opt As Integer ' �������ͣ�1����ӣ�2���޸ģ��������޲���

Private Sub ChkbCA_Click()
'    If Opt = 2 And Me.ChkbMainUnit.Value = 1 Then
'        ShowMsg "�����޸ģ��ü�����λΪ��������λ��"
'        Me.ChkbCA.Value = 0
'        Exit Sub
'    End If
    Tlb.Buttons("SaveRs").Enabled = True
    If Me.ChkbCA.Enabled = True Then Call ChkUnique(Me.ChkbCA)
End Sub

Private Sub ChkbMainUnit_Click()
'    If Opt = 2 And sEdtChange(4) = 1 Then
'        Me.ChkbMainUnit.Value = 1
'        ShowMsg "�����޸ģ�����ֱ�����ñ���" + vbCrLf + "����������λΪ��������λ��"
'        Exit Sub
'    End If
    Tlb.Buttons("SaveRs").Enabled = True
    If Me.ChkbMainUnit.Enabled = True Then Call ChkUnique(Me.ChkbMainUnit)
End Sub
'---------------------------------------
'���ܣ�һ����ѡ��
'������con ��Ӧ��CheckBox��
'---------------------------------------
Private Sub ChkUnique(Con As Control)
    Me.ChkbMainUnit.Enabled = False
    Me.ChkbPU.Enabled = False
    Me.ChkbCA.Enabled = False
    Me.ChkbSA.Enabled = False
    Me.ChkbST.Enabled = False
    
    
    If Con.Name = "ChkbMainUnit" Then
        Me.ChkbPU.Value = 0
        Me.ChkbCA.Value = 0
        Me.ChkbSA.Value = 0
        Me.ChkbST.Value = 0
    Else
        Me.ChkbMainUnit.Value = 0
    End If
    
    Me.ChkbMainUnit.Enabled = True
    Me.ChkbPU.Enabled = True
    Me.ChkbCA.Enabled = True
    Me.ChkbSA.Enabled = True
    Me.ChkbST.Enabled = True
End Sub

Private Sub ChkbMainUnit_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        ChkbPU.SetFocus
    End If
End Sub

Private Sub ChkbPU_Click()
'    If Opt = 2 And Me.ChkbMainUnit.Value = 1 Then
'        ShowMsg "�����޸ģ��ü�����λΪ��������λ��"
'        Me.ChkbPU.Value = 0
'        Exit Sub
'    End If
    Tlb.Buttons("SaveRs").Enabled = True
    If Me.ChkbPU.Enabled = True Then Call ChkUnique(Me.ChkbPU)
End Sub

Private Sub ChkbPU_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        ChkbSA.SetFocus
    End If
End Sub

Private Sub ChkbSA_Click()
'    If Opt = 2 And Me.ChkbMainUnit.Value = 1 Then
'        ShowMsg "�����޸ģ��ü�����λΪ��������λ��"
'        Me.ChkbSA.Value = 0
'        Exit Sub
'    End If
    Tlb.Buttons("SaveRs").Enabled = True
    If Me.ChkbSA.Enabled = True Then Call ChkUnique(Me.ChkbSA)
End Sub

Private Sub ChkbSA_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        ChkbST.SetFocus
    End If
End Sub

Private Sub ChkbST_Click()
'    If Opt = 2 And Me.ChkbMainUnit.Value = 1 Then
'        ShowMsg "�����޸ģ��ü�����λΪ��������λ��"
'        Me.ChkbST.Value = 0
'        Exit Sub
'    End If
    Tlb.Buttons("SaveRs").Enabled = True
    If Me.ChkbST.Enabled = True Then Call ChkUnique(Me.ChkbST)
End Sub

Private Sub ChkbST_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        ChkbCA.SetFocus
    End If
End Sub

Private Sub EdtCbarCode_Change()
    Tlb.Buttons("SaveRs").Enabled = True
End Sub

Private Sub EdtCbarCode_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        ChkbMainUnit.SetFocus
    End If
End Sub


'---------------------------------------
'���ܣ��������ַ�����ĺϷ���
'---------------------------------------
Private Sub EdtCComunitCode_Change()
    Dim i As Integer
    For i = 1 To Len(Me.EdtCComunitCode)
        If InStr(1, "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", Mid(Me.EdtCComunitCode, i, 1)) = 0 Then
            ShowMsg "���ܴ��ڷǷ����ַ���"
            Me.EdtCComunitCode = ""
            Exit Sub
        End If
    Next i
    Tlb.Buttons("SaveRs").Enabled = True
    If LenB(Me.EdtCComunitCode) / LenB("a") = Me.EdtCComunitCode.MaxLength Then
        Frame3.Visible = True
    Else
        Frame3.Visible = False
    End If
End Sub


Private Sub EdtCComunitCode_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        EdtCComUnitName.SetFocus
    End If
End Sub

Private Sub EdtCComUnitName_Change()
    Tlb.Buttons("SaveRs").Enabled = True
End Sub

Private Sub EdtCComUnitName_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        EdtiChangExch.SetFocus
    End If
End Sub

Private Sub EdtiChangExch_Change()
    Tlb.Buttons("SaveRs").Enabled = True
End Sub

Private Sub EdtiChangExch_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        EdtCbarCode.SetFocus
    End If
End Sub

'---------------------------------------------
'���ܣ����弤��ʱ���ؼ�����
'---------------------------------------------
Private Sub Form_Activate()
    '����״̬�����
    With Stb
         .Panels(1).Width = .Width * 2 / 3
         .Panels(1).Alignment = sbrLeft
         .Panels(1).Text = LoadResString(3001)
         .Panels(2).Width = (Stb.Width - .Panels(1).Width) / 2
         .Panels(3).Width = (Stb.Width - .Panels(1).Width) / 2
    End With
    With Stb.Panels
         .Item(3).Style = sbrDate
    End With
    Me.KeyPreview = True
End Sub

'---------------------------------------
'���ܣ����ô����ݼ�
'---------------------------------------
Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)

    If KeyCode = vbKeyF5 Then
        Call Operating("Add")
    End If
    If KeyCode = vbKeyDelete Then
        If Frame2.Enabled = True Then Exit Sub
        Call Operating("Delete")
    End If
    If KeyCode = vbKeyF6 Then
        Call Operating("SaveRs")
    End If
    If KeyCode = vbKeyF7 Then
        Call Operating("Modify")
    End If
    If KeyCode = vbKeyP Then
        If Shift = 2 Then
            Call Operating("Print")
        End If
    End If
    If KeyCode = vbKeyF4 Then
        If Shift = 4 Then
            Call Operating("Exit")
        End If
    End If
    If KeyCode = vbKeyF1 Then
        Call Operating("Help")
    End If
    If KeyCode = vbKeyF9 Then
        Call Operating("Refresh")
    End If
End Sub

Private Sub Form_Load()
'    On Error Resume Next
    Call InitImageList
    Call InitToolBar
    Call InitInterface
    InitData
    Tlb.Buttons("SaveRs").Enabled = False
End Sub


'---------------------------------
'���̹��ܣ����ͼ���ʼ���Ĺ���
'---------------------------------
Private Sub InitImageList()
    On Error GoTo Err_info:
    Img.ListImages.Add 1, "Add", LoadResPicture(119, 0)
    Img.ListImages.Add 2, "Delete", LoadResPicture(102, 0)
    Img.ListImages.Add 3, "Modify", LoadResPicture(129, 0)
    Img.ListImages.Add 4, "Back", LoadResPicture(137, 0)
    Img.ListImages.Add 5, "SaveRs", LoadResPicture(111, 0)
    Img.ListImages.Add 6, "Seek", LoadResPicture(117, 0)
    Img.ListImages.Add 7, "Exit", LoadResPicture(120, 0)
    Img.ListImages.Add 8, "Help", LoadResPicture(103, 0)
    Img.ListImages.Add 9, "Refresh", LoadResPicture(124, 0)
    Img.ListImages.Add 10, "Print", LoadResPicture(105, 0)
    Img.ListImages.Add 11, "Preview", LoadResPicture(123, 0)
    Img.ListImages.Add 12, "SaveFile", LoadResPicture(125, 0)
    Img.ListImages.Add 13, "SetUp", LoadResPicture(119, 0)
    
    Exit Sub
Err_info:
    Debug.Print "FrmUnit_InitImageList_Error"
End Sub

'---------------------------------
'���̹��ܣ���ɹ�������ʼ���Ĺ���
'---------------------------------
Private Sub InitToolBar()
    On Error GoTo Err_info:
    Tlb.ImageList = Img
    With Tlb.Buttons
        .Add 1, "SetUp", , tbrDefault, "SetUp"
        .Add 2, "Print", , tbrDefault, "Print"
        .Add 3, "Preview", , tbrDefault, "Preview"
        .Add 4, "SaveFile", , tbrDefault, "SaveFile"
        .Add 5, "btnSep1", , tbrSeparator
        .Add 6, "Add", , tbrDefault, "Add"
        .Add 7, "Modify", , tbrDefault, "Modify"
        .Add 8, "Delete", , tbrDefault, "Delete"
        .Add 9, "btnSep2", , tbrSeparator
        .Add 10, "Back", , tbrDefault, "Back"
        .Add 11, "SaveRs", , tbrDefault, "SaveRs"
        .Add 12, "btnSep3", , tbrSeparator
        .Add 13, "Seek", , tbrDefault, "Seek"
        .Add 14, "Refresh", , tbrDefault, "Refresh"
        .Add 15, "btnSep4", , tbrSeparator
        .Add 16, "Help", "����", tbrDefault, "Help"
        .Add 17, "Exit", , tbrDefault, "Exit"
    End With
    Tlb.Buttons("SetUp").Caption = LoadResString(3201)
    Tlb.Buttons("SetUp").ToolTipText = LoadResString(3202)
    
    Tlb.Buttons("Print").ToolTipText = LoadResString(3204) + "(Ctrl + P)"
    Tlb.Buttons("Print").Caption = LoadResString(3203)
    Tlb.Buttons("Preview").ToolTipText = LoadResString(3206)
    Tlb.Buttons("Preview").Caption = LoadResString(3205)
    Tlb.Buttons("SaveFile").ToolTipText = LoadResString(3208)
    Tlb.Buttons("SaveFile").Caption = LoadResString(3207)
    Tlb.Buttons("Add").ToolTipText = LoadResString(3210) + "(F5)"
    Tlb.Buttons("Add").Caption = LoadResString(3209)
    Tlb.Buttons("Delete").ToolTipText = LoadResString(3214) + "(Del)"
    Tlb.Buttons("Delete").Caption = LoadResString(3213)
    Tlb.Buttons("Modify").ToolTipText = LoadResString(3212) + "(F7)"
    Tlb.Buttons("Modify").Caption = LoadResString(3211)
    Tlb.Buttons("Back").Caption = LoadResString(3215)
    Tlb.Buttons("Back").ToolTipText = LoadResString(3216)
    Tlb.Buttons("SaveRs").ToolTipText = LoadResString(3218) + "(F6)"
    Tlb.Buttons("SaveRs").Caption = LoadResString(3217)
    Tlb.Buttons("Seek").Visible = False
    Tlb.Buttons("Refresh").ToolTipText = LoadResString(3220) + "(F9)"
    Tlb.Buttons("Refresh").Caption = LoadResString(3219)
    
    Tlb.Buttons("Exit").Caption = LoadResString(3221)
    Tlb.Buttons("Exit").ToolTipText = LoadResString(3222)
    Tlb.Buttons("Help").Caption = LoadResString(3223)
    Tlb.Buttons("Help").ToolTipText = LoadResString(3224) + "(F1)"
    
    Tlb.Buttons("Back").Enabled = False
    Tlb.Buttons("SaveRs").Enabled = False
    Exit Sub
Err_info:
    Debug.Print "FrmUnit_InitToolBar_Error"
End Sub

'---------------------------------------------
'���ܣ�������Դװ�أ���ʽ��һЩ�ؼ�
'---------------------------------------------
Private Sub InitInterface()
    On Error GoTo Err_info:
    Me.Icon = LoadResPicture(101, vbResIcon)
    Me.Caption = LoadResString(3001)
    
    Dim i As Integer
    
    For i = 0 To Lbl.UBound
        Lbl(i).Caption = LoadResString(3101 + i)
    Next i
    ChkbMainUnit.Caption = LoadResString(3105)
    ChkbPU.Caption = LoadResString(3106)
    ChkbSA.Caption = LoadResString(3107)
    ChkbST.Caption = LoadResString(3108)
    ChkbCA.Caption = LoadResString(3109)
    
    Dim RstGradeDef As ADODB.Recordset '��������¼��
    Dim strSql As String
    strSql = "select * from gradedef where Keyword='ComputationUnit'"
    Set RstGradeDef = SrvDB.OpenX(strSql)
    If RstGradeDef.RecordCount = 0 Then
        ShowMsg "���ݿ�ϵͳû���趨������λ�������" + vbCrLf + "�����趨!"
    End If
    
    Dim sRule$
    Dim j%, iGrade%, Sum%, AllSum%
    sRule = RstGradeDef!CODINGRULE
    iGrade = Len(sRule) '���뼶��
    Lab2.Caption = ""
    Lab2.FontSize = 14
    Lab2.FontBold = False
    AllSum = 0
    For i = 1 To iGrade
        Sum = CInt(Mid(sRule, i, 1))
        AllSum = AllSum + Sum
        For j = 0 To Sum - 1
            Lab2.Caption = Lab2.Caption + "*"
        Next j
            Lab2.Caption = Lab2.Caption + " "
    Next i
    Dim Rs As ADODB.Recordset
    strSql = "select * from ComputationUnit where 1=2"
    Set Rs = SrvDB.OpenX(strSql)
    Me.EdtCComunitCode.MaxLength = AllSum
    Me.EdtCComUnitName.MaxLength = Rs.Fields("CComUnitName").DefinedSize
    Me.EdtCbarCode.MaxLength = Rs.Fields("CbarCode").DefinedSize
    
    Dim RsAcc As ADODB.Recordset '���ײ�����
    Dim RsTemp As ADODB.Recordset
    Set RsAcc = SrvDB.OpenX("select * from AccInformation where cSysID='AA'")
    '���¹�������ID���Բ���
    Set RsTemp = FilterField(RsAcc, " cID='43' and cName='iExchRateDecDgt'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iExchRateDecDgt = 2
        Else
            g_iExchRateDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iExchRateDecDgt = 2
    End If
    EdtiChangExch.Numpoint = g_iExchRateDecDgt
    EdtiChangExch = Format(EdtiChangExch, "0." & String(g_iExchRateDecDgt, "0"))
    Frame2.Enabled = False
    Frame3.Visible = False
    Tlb.Buttons("SaveRs").Enabled = False '��д��ʱ�����ť��������������
    
        '����״̬��
    For i = 1 To 2
         Stb.Panels.Add
    Next i
    
    Exit Sub
Err_info:
    Debug.Print "FrmUnit_InitInterface_error"
End Sub

'---------------------------------------------
'���ܣ��������Edit��CheckBox�����ݣ� Me.EdtCComunitCode����
'---------------------------------------------
Private Sub EdtClear()
    Dim sCode$
    sCode = Me.EdtCComunitCode
    Dim Con As Control
    For Each Con In Controls
        If TypeOf Con Is Edit Then Con.Text = ""
        If TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then Con.Value = 0
    Next Con
    Me.EdtCComunitCode = sCode
End Sub

'-------------------------------------------
'�������ܣ�Edt��ֵ������¼����ֵ���Ա��ж��Ƿ��޸�
'-----------------------------------------------
Private Sub EdtSetVal(Rs As ADODB.Recordset)
    On Error GoTo Err_info:
    Me.EdtCComunitCode.Text = TxtValue(Rs!cComunitCode)
    Me.EdtCComUnitName.Text = TxtValue(Rs!CComUnitName)
    Me.EdtiChangExch.Text = Format(TxtValue(Rs!iChangExch), "0." & String(g_iExchRateDecDgt, "0"))
    Me.EdtCbarCode.Text = TxtValue(Rs!CbarCode)
    
    Me.ChkbMainUnit.Value = ChkVal(Rs!bMainUnit)
    Me.ChkbPU.Value = ChkVal(Rs!bPU)
    Me.ChkbSA.Value = ChkVal(Rs!bsa)
    Me.ChkbST.Value = ChkVal(Rs!bSt)
    Me.ChkbCA.Value = ChkVal(Rs!bCA)
    
    Call MemEdt

    Exit Sub
Err_info:
    Debug.Print "FrmPos_EdtSetVal_Error"
End Sub

Private Sub MemEdt()
    sEdtChange(0) = Me.EdtCComunitCode.Text
    sEdtChange(1) = Me.EdtCComUnitName.Text
    sEdtChange(2) = Me.EdtiChangExch.Text
    sEdtChange(3) = Me.EdtCbarCode.Text
    sEdtChange(4) = Me.ChkbMainUnit.Value
    sEdtChange(5) = Me.ChkbPU.Value
    sEdtChange(6) = Me.ChkbSA.Value
    sEdtChange(7) = Me.ChkbST.Value
    sEdtChange(8) = Me.ChkbCA.Value
End Sub

'---------------------------------------
'���ܣ�����NULL������bitλtrueת��λ1��falseת��Ϊ0
'����������������
'---------------------------------------
Private Function TxtValue(var As Variant) As Variant
    TxtValue = IIf(IsNull(var), "", var)
End Function
'---------------------------------------
'���ܣ�����bitλtrueת��λ1��falseת��Ϊ0
'����������������
'---------------------------------------
Private Function ChkVal(var As Variant) As Integer
    ChkVal = IIf(LCase(var) = "true", 1, 0)
End Function
'---------------------------------------
'���ܣ��ж��Ƿ��޸�
'---------------------------------------
Private Function bEdtChange() As Boolean
    bEdtChange = True
    
    If sEdtChange(0) <> Me.EdtCComunitCode.Text Then Exit Function
    If sEdtChange(1) <> Me.EdtCComUnitName.Text Then Exit Function
    If sEdtChange(2) <> Me.EdtiChangExch.Text Then Exit Function
    If sEdtChange(3) <> Me.EdtCbarCode.Text Then Exit Function
    If sEdtChange(4) <> Me.ChkbMainUnit.Value Then Exit Function
    If sEdtChange(5) <> Me.ChkbPU.Value Then Exit Function
    If sEdtChange(6) <> Me.ChkbSA.Value Then Exit Function
    If sEdtChange(7) <> Me.ChkbST.Value Then Exit Function
    If sEdtChange(8) <> Me.ChkbCA.Value Then Exit Function
    
    bEdtChange = False
End Function
'------------------------------------
'���ܣ���ȡ������λ���ݼ�
'------------------------------------
Private Sub InitData()
    Dim strSql As String
    Dim RstGradeDef As ADODB.Recordset '��������¼��
    Dim RstUnit As ADODB.Recordset
    strSql = "select * from gradedef where Keyword='ComputationUnit'"
    Set RstGradeDef = SrvDB.OpenX(strSql)
    strSql = "select * from ComputationUnit order by cComunitCode Asc"
    Set RstUnit = SrvDB.OpenX(strSql)
    Stb.Panels(2).Text = "���� " + CStr(RstUnit.RecordCount) + " ��������λ����"
    Call CreateTree(RstGradeDef, RstUnit)
End Sub

'------------------------------------
'���ܣ��������ͽṹ
'������RstGradeDef��������λ�������
'      RstUnit��������λ���ݼ�
'------------------------------------
Private Sub CreateTree(RstGradeDef As ADODB.Recordset, RstUnit As ADODB.Recordset)
    Static bFlag As Boolean

    Dim i As Integer
    Dim sCodeRule As Variant '�������
    Dim iGrade As Integer
    sCodeRule = Trim(RstGradeDef!CODINGRULE)
    
    Call SetVirGroup(sCodeRule, bFlag)
    
    iGrade = Len(sCodeRule) '���뼶��
    Trv.LineStyle = tvwRootLines
    Dim NodX As UFTREEVIEWLib.INode
    Trv.Nodes.Clear
    Trv.LabelEdit = tvwManual
    Set NodX = Trv.Nodes.Add(, , "r", "������λ����")
    Dim sRelative As String
    Dim Sum As Integer
    Dim sCode As String
    If RstUnit.RecordCount = 0 Then Exit Sub
    RstUnit.MoveFirst
    While Not RstUnit.EOF
        sRelative = ""
        Sum = 0
        sCode = Trim(RstUnit!cComunitCode)
        For i = 1 To iGrade
            sRelative = Mid(sCode, 1, Sum)
            Sum = Sum + CInt(Mid(sCodeRule, i, 1))
            If Trim(Mid(sCode, Sum + 1, Len(sCode))) = "" Then Exit For
        Next i
        sRelative = "r" + sRelative
        Set NodX = Trv.Nodes.Add(sRelative, tvwChild, "r" + sCode, "(" + sCode + ") " + RstUnit!CComUnitName)
        RstUnit.MoveNext
    Wend
    NodX.Selected = True
    RstUnit.MoveFirst
    NodX.ExpandedImage = 0
    For i = 1 To Trv.Nodes.count
        'չ��ȫ���ڵ㡣
        Trv.Nodes(i).Expanded = True
   Next i
   ShowNode
   Set RstUnit = Nothing
End Sub
'------------------------------
'���̹��ܣ�����������
'������sCodeRule���������
'      bFlag:��ʾ�Ƿ�������
'------------------------------
Private Sub SetVirGroup(ByVal sCodeRule As String, ByRef bFlag As Boolean)
    If bFlag = True Then Exit Sub
    sCodeRule = Left(sCodeRule, 1)
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    Dim sXml As String
    Dim sMsg As String
    strSql = "select * from ComputationUnit where CComunitCode='" + String(CInt(sCodeRule), "0") + "'"
    Set Rs = SrvDB.OpenX(strSql)
    If Rs.RecordCount = 0 Then
        sXml = "<ComputationUnit>"
        sXml = sXml + "<CComunitCode>" + String(CInt(sCodeRule), "0") + "</CComunitCode>"
        sXml = sXml + "<CComUnitName>" + "����������λ��" + "</CComUnitName>"
        sXml = sXml + "</ComputationUnit>"
        If SrvDB.Add(sXml, "ComputationUnit", sMsg) = False Then
            ShowMsg "Ԥ�����������λ��ʧ�ܣ�"
            Exit Sub
        End If
        bFlag = True
    ElseIf Rs.RecordCount = 1 Then
        bFlag = True
    End If
End Sub

'------------------------------
'���̹��ܣ����ڵ���Ϣ�ֽ⵽�ı�����ʾ
'------------------------------
Private Sub ShowNode()
    Dim sCode$, sName$
    sCode = Trv.SelectedItem.key
    sCode = Trim(Right(sCode, Len(sCode) - 1)) 'ȥ����ĸ��r��
    sName = Trv.SelectedItem.Text
    sName = Right(sName, Len(sName) - Len(sCode) - 3) 'ȥ����(���͡�) ��
    If sCode = "" Then  '�����
        EdtClear
        Me.EdtCComunitCode = ""
    Else
        Dim Rs As ADODB.Recordset
        Set Rs = SrvDB.OpenX("select * from ComputationUnit where CComunitCode='" + sCode + "'")
        EdtSetVal Rs
        Frame3.Enabled = True
    End If
End Sub

'---------------------------------------
'���ܣ��������ݼ�
'������rstTemp����Ҫ���˵����ݼ�
'     strFilter����������
'---------------------------------------
Public Function FilterField(ByVal rstTemp As ADODB.Recordset, strFilter As String) As ADODB.Recordset
    rstTemp.Filter = strFilter
    Set FilterField = rstTemp
End Function

'---------------------------------------------------
'���ܣ������С�仯����
'---------------------------------------------------
Private Sub Form_Resize()
    If Me.WindowState = 1 Then Exit Sub
    If Me.Width < 8000 Then Me.Width = 8000
    If Me.Height < 6000 Then Me.Height = 6000
    Frame1.Top = Tlb.Top + Tlb.Height + 2
    Frame2.Top = Frame1.Top
    Frame1.Width = (Me.Width - 400) * 2 / 5
    Frame2.Width = Frame1.Width * 3 / 2
    Frame1.Left = 100
    Frame2.Left = 200 + Frame1.Width
    Frame1.Height = Me.Height - Tlb.Height - Stb.Height - 760
    Frame2.Height = Frame1.Height
    Trv.Left = 100
    Trv.Top = 200
    Trv.Width = Frame1.Width - 200
    Trv.Height = Frame1.Height - 300
End Sub


'---------------------------------------------------
'���ܣ��������Ͳ˵���ť��Ӧ�Ĳ���
'---------------------------------------------------
Private Sub Operating(ByVal key As String)
'    Me.EdtCComunitCode.Enabled = True
    Select Case LCase(key)
        Case LCase("SetUp")
        Case LCase("Print")
        Case LCase("Preview")
        Case LCase("SaveFile")
        Case LCase("Add")
            Frame2.Enabled = True
            Call EdtClear
            Tlb.Buttons("Back").Enabled = True
            Me.EdtCComunitCode.Enabled = True
            Me.EdtCComunitCode.SetFocus
            Opt = 1
        Case LCase("Modify")
            Frame2.Enabled = True
            ShowNode
            Me.EdtCComunitCode.Enabled = False
            Tlb.Buttons("Back").Enabled = True
            Me.EdtCComUnitName.SetFocus
            If Me.ChkbMainUnit.Value = 1 Then Frame3.Enabled = False
            Opt = 2
        Case LCase("Delete")
                If Trv.SelectedItem.Parent.key <> "r" Then
                    ShowMsg "ֻ������ĵ�λɾ������ѡ����!"
                    Exit Sub
                End If
            If MsgBox("ȷ��ɾ������Ϊ'" + Me.EdtCComunitCode + "'�ļ�����λ�鵵����", vbYesNo + vbExclamation, "������Ϣ") = vbYes Then
                If Common.DeleteUnitRs = True Then
                    InitData
                    Tlb.Buttons("SaveRs").Enabled = False
                End If
            End If
        Case LCase("Back")
            ShowNode
            Frame2.Enabled = False
            Tlb.Buttons("Back").Enabled = False
            Tlb.Buttons("SaveRs").Enabled = False
            Opt = 0
        Case LCase("SaveRs")
            Tlb.Buttons("SaveRs").Enabled = False
            If Common.SaveUnitRs(Opt) = False Then Exit Sub
            Frame2.Enabled = False
            Tlb.Buttons("Back").Enabled = False
            Me.EdtCComunitCode.Enabled = True
            InitData
            Call MemEdt
        Case LCase("Refresh")
            InitData
            Tlb.Buttons("SaveRs").Enabled = False
        Case LCase("Help")
        Case LCase("Exit")
            Unload Me
        Case Else
            Debug.Print "Frmcuscls_Tlb_ButtonClick_No button to match"
    End Select
End Sub

Private Sub mAbout_Click()
    Operating "About"
End Sub

Private Sub mAdd_Click()
    Operating "Add"
End Sub

Private Sub mBack_Click()
    Operating "Back"
End Sub

Private Sub mDelete_Click()
    Operating "Delete"
End Sub

Private Sub mExit_Click()
    Operating "Exit"
End Sub

Private Sub mHelp_Click()
    Operating "Help"
End Sub

Private Sub mModify_Click()
    Operating "Modify"
End Sub

Private Sub mPreview_Click()
    Operating "Preview"
End Sub

Private Sub mPrint_Click()
    Operating "Print"
End Sub

Private Sub mRefresh_Click()
    Operating "Refresh"
End Sub

Private Sub mSaveFile_Click()
    Operating "SaveFile"
End Sub

Private Sub mSaveRs_Click()
    Operating "SaveRs"
End Sub

Private Sub mSetUp_Click()
    Operating "SetUp"
End Sub

'---------------------------------------
'���ܣ�����״̬�����ı���ʾģʽ
'---------------------------------------
Private Sub Stb_Click()
    Static bFlag As Boolean
    bFlag = Not bFlag
    With Stb
      If (.Style = sbrNormal) And (bFlag) Then
         .SimpleText = Time   '��ʾʱ�䡣
         .Style = sbrSimple   'Simple ��ʽ
      Else
         .Style = sbrNormal   'Normal ��ʽ
      End If
   End With
End Sub


Private Sub Tlb_ButtonClick(ByVal Button As MSComctlLib.Button)
    Operating Button.key
End Sub


'---------------------------------------------------
'���ܣ��������Ϳؼ�������ʾ
'---------------------------------------------------
Private Sub Trv_NodeClick(ByVal Node As UFTREEVIEWLib.INode)
    If Opt = 2 And bEdtChange = True Then
        If MsgBox("�����Ƿ�����޸ģ�", vbYesNo + vbQuestion, "��ʾ��Ϣ") = vbYes Then
        Else
            Exit Sub
        End If
    End If
    Opt = 0
    Frame2.Enabled = False
    Me.EdtCComunitCode.Enabled = True
    Tlb.Buttons("Back").Enabled = False
    ShowNode
    Tlb.Buttons("SaveRs").Enabled = False
End Sub

