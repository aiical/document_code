VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Object = "{51388549-C886-4FD6-AE5F-8AA28C63CE94}#1.0#0"; "PrintControl.ocx"
Object = "{FE0065C0-1B7B-11CF-9D53-00AA003C9CB6}#1.1#0"; "comct232.ocx"
Object = "{D2B3369D-2E6C-45DE-A705-14481242A2BE}#1.10#0"; "UFMenu6U.ocx"
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Object = "{E6DA5562-1458-49F7-96EF-B15C298C8D7C}#1.0#0"; "UFTreeView.ocx"
Object = "{BF022F1C-E440-4790-987F-252926B9B602}#5.1#0"; "UFFrames.ocx"
Object = "{201FB79B-5556-47A4-AD9C-A46BA0C45A44}#6.26#0"; "UFToolBarCtrl.ocx"
Object = "{E08B3B98-649C-46CD-A1AD-4A10DB106D57}#1.2#0"; "UFStatusBar.ocx"
Object = "{8C7C777D-4D83-4DE8-947E-098E2343A400}#1.0#0"; "CommandButton.ocx"
Object = "{18277A1C-A353-4E93-879A-E45DC95E7397}#2.4#0"; "UFFlexGrid.ocx"
Object = "{005151D4-33F6-471B-B651-222D4E411832}#4.4#0"; "UFFormPartner.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Begin VB.Form FrmInv 
   Caption         =   "Form1"
   ClientHeight    =   5430
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   8205
   ClipControls    =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   5430
   ScaleWidth      =   8205
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin UFFlexGrid.UFFlexGridCtl Grid 
      Height          =   885
      Left            =   3360
      TabIndex        =   21
      Top             =   1950
      Width           =   2955
      _ExtentX        =   5212
      _ExtentY        =   1561
      TopRow          =   1
      ShowComboButton =   1
      SheetBorder     =   -2147483642
      RowSel          =   1
      LeftCol         =   1
      ComboIndex      =   -1
      ColSel          =   1
      Col             =   1
      Row             =   1
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BackColorBkg    =   -2147483638
      Cols            =   2
      Ellipsis        =   1
   End
   Begin UFFrames.UFFrame FrameWeb 
      Height          =   555
      Left            =   -90
      TabIndex        =   7
      Top             =   4230
      Width           =   10875
      _ExtentX        =   0
      _ExtentY        =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Begin UFCOMMANDBUTTONLib.UFCommandButton CmdRequest 
         Height          =   285
         Left            =   6585
         TabIndex        =   8
         Top             =   180
         Width           =   735
         _Version        =   65536
         _ExtentX        =   2646
         _ExtentY        =   1323
         _StockProps     =   41
         Caption         =   "�ύ"
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
      Begin ComCtl2.UpDown UpDown2 
         Height          =   330
         Left            =   6210
         TabIndex        =   9
         Top             =   135
         Width           =   240
         _ExtentX        =   423
         _ExtentY        =   582
         _Version        =   327681
         AutoBuddy       =   -1  'True
         OrigLeft        =   3600
         OrigTop         =   225
         OrigRight       =   3840
         OrigBottom      =   420
         Enabled         =   -1  'True
      End
      Begin EDITLib.Edit EdtiCurPage 
         Height          =   285
         Left            =   5445
         TabIndex        =   10
         Top             =   135
         Width           =   750
         _Version        =   65536
         _ExtentX        =   1323
         _ExtentY        =   503
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
      End
      Begin ComCtl2.UpDown UpDown1 
         Height          =   330
         Left            =   4305
         TabIndex        =   11
         Top             =   135
         Width           =   240
         _ExtentX        =   423
         _ExtentY        =   582
         _Version        =   327681
         AutoBuddy       =   -1  'True
         BuddyControl    =   "Trv"
         BuddyDispid     =   196628
         OrigLeft        =   1891
         OrigTop         =   180
         OrigRight       =   2131
         OrigBottom      =   420
         Enabled         =   -1  'True
      End
      Begin EDITLib.Edit EdtPageSize 
         Height          =   285
         Left            =   3540
         TabIndex        =   12
         Top             =   150
         Width           =   750
         _Version        =   65536
         _ExtentX        =   1323
         _ExtentY        =   503
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
      End
      Begin UFLABELLib.UFLabel Lblpagesize 
         Height          =   195
         Left            =   2910
         TabIndex        =   19
         Top             =   180
         Width           =   540
         _Version        =   65536
         _ExtentX        =   953
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "ҳ��С"
         AutoSize        =   -1  'True
      End
      Begin UFLABELLib.UFLabel Llbcurpage 
         Height          =   195
         Left            =   4815
         TabIndex        =   18
         Top             =   225
         Width           =   540
         _Version        =   65536
         _ExtentX        =   953
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "��ǰҳ"
         AutoSize        =   -1  'True
      End
      Begin UFLABELLib.UFLabel LblPage 
         Height          =   195
         Index           =   0
         Left            =   7830
         TabIndex        =   17
         Top             =   225
         Width           =   360
         _Version        =   65536
         _ExtentX        =   635
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "��ҳ"
         AutoSize        =   -1  'True
      End
      Begin UFLABELLib.UFLabel LblPage 
         Height          =   195
         Index           =   1
         Left            =   8475
         TabIndex        =   16
         Top             =   225
         Width           =   540
         _Version        =   65536
         _ExtentX        =   2646
         _ExtentY        =   1323
         _StockProps     =   111
         Caption         =   "ǰһҳ"
         AutoSize        =   -1  'True
      End
      Begin UFLABELLib.UFLabel LblPage 
         Height          =   195
         Index           =   2
         Left            =   9300
         TabIndex        =   15
         Top             =   225
         Width           =   540
         _Version        =   65536
         _ExtentX        =   2646
         _ExtentY        =   1323
         _StockProps     =   111
         Caption         =   "��һҳ"
         AutoSize        =   -1  'True
      End
      Begin UFLABELLib.UFLabel LblPage 
         Height          =   195
         Index           =   3
         Left            =   10125
         TabIndex        =   14
         Top             =   225
         Width           =   360
         _Version        =   65536
         _ExtentX        =   2646
         _ExtentY        =   1323
         _StockProps     =   111
         Caption         =   "ĩҳ"
         AutoSize        =   -1  'True
      End
      Begin UFLABELLib.UFLabel LblTotalPage 
         Height          =   195
         Left            =   360
         TabIndex        =   13
         Top             =   180
         Width           =   480
         _Version        =   65536
         _ExtentX        =   847
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "Label3"
         AutoSize        =   -1  'True
      End
   End
   Begin VB.PictureBox PicSeparate 
      BorderStyle     =   0  'None
      ClipControls    =   0   'False
      Height          =   3975
      Left            =   2790
      ScaleHeight     =   3975
      ScaleWidth      =   45
      TabIndex        =   3
      Top             =   705
      Width           =   45
   End
   Begin VB.PictureBox Pic 
      Appearance      =   0  'Flat
      BackColor       =   &H00EFEFEF&
      ForeColor       =   &H80000008&
      Height          =   465
      Left            =   1575
      ScaleHeight     =   435
      ScaleWidth      =   4290
      TabIndex        =   5
      Top             =   915
      Width           =   4320
      Begin UFLABELLib.UFLabel LblCaption 
         Height          =   195
         Left            =   1545
         TabIndex        =   6
         Top             =   90
         Width           =   810
         _Version        =   65536
         _ExtentX        =   1429
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "LabCaption"
         AutoSize        =   -1  'True
         BackStyle       =   0
      End
      Begin VB.Line LineRight 
         BorderColor     =   &H007B8E9C&
         X1              =   3165
         X2              =   4020
         Y1              =   180
         Y2              =   180
      End
      Begin VB.Line LineLeft 
         BorderColor     =   &H007B8E9C&
         X1              =   225
         X2              =   1080
         Y1              =   180
         Y2              =   180
      End
   End
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   1080
      Top             =   2400
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      MaskColor       =   12632256
      _Version        =   393216
   End
   Begin MSComctlLib.Toolbar Tlb 
      Align           =   1  'Align Top
      Height          =   555
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   8205
      _ExtentX        =   14473
      _ExtentY        =   979
      ButtonWidth     =   820
      ButtonHeight    =   926
      AllowCustomize  =   0   'False
      Appearance      =   1
      Style           =   1
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   21
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
            Key             =   "PrSet"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "��ӡ"
            Key             =   "Prn"
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "Ԥ��"
            Key             =   "Preview"
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "���"
            Key             =   "FileOut"
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
            Key             =   "Add"
         EndProperty
         BeginProperty Button7 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "�޸�"
            Key             =   "Modify"
         EndProperty
         BeginProperty Button8 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "ɾ��"
            Key             =   "Delete"
         EndProperty
         BeginProperty Button9 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button10 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
            Key             =   "Filter"
         EndProperty
         BeginProperty Button11 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "��λ"
            Key             =   "Pos"
         EndProperty
         BeginProperty Button12 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "ˢ��"
            Key             =   "Fresh"
         EndProperty
         BeginProperty Button13 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button14 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "�ֶ�"
            Key             =   "FieldSet"
         EndProperty
         BeginProperty Button15 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
            Key             =   "MulModify"
         EndProperty
         BeginProperty Button16 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button17 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "ȫѡ"
            Key             =   "AllSel"
         EndProperty
         BeginProperty Button18 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "ȫ��"
            Key             =   "AllCancel"
         EndProperty
         BeginProperty Button19 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button20 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
            Key             =   "Help"
         EndProperty
         BeginProperty Button21 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "�˳�"
            Key             =   "Exit"
         EndProperty
      EndProperty
   End
   Begin UFStatusBar.UFStatusBarCtl Stb 
      Align           =   2  'Align Bottom
      Height          =   375
      Left            =   0
      TabIndex        =   1
      Top             =   5055
      Width           =   8205
      _ExtentX        =   14473
      _ExtentY        =   661
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BackColor       =   -2147483633
   End
   Begin UFTREEVIEWLib.UFTreeView Trv 
      Height          =   2280
      Left            =   240
      TabIndex        =   2
      Top             =   2415
      Width           =   2415
      _Version        =   65536
      _ExtentX        =   4260
      _ExtentY        =   4022
      _StockProps     =   228
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BorderStyle     =   1
      Indentation     =   529
      LineStyle       =   1
      LabelEdit       =   1
   End
   Begin PRINTCONTROLLib.PrintControl Prn 
      Height          =   555
      Left            =   4860
      TabIndex        =   4
      Top             =   3870
      Visible         =   0   'False
      Width           =   780
      _Version        =   65536
      _ExtentX        =   1376
      _ExtentY        =   979
      _StockProps     =   0
      EnableSave      =   -1  'True
   End
   Begin UFToolBarCtrl.UFToolbar TLB2 
      Height          =   240
      Left            =   0
      TabIndex        =   20
      Top             =   60
      Width           =   8265
      _ExtentX        =   14579
      _ExtentY        =   423
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin cPopMenu6.PopMenu PopMenuMgr 
      Left            =   0
      Top             =   630
      _ExtentX        =   1058
      _ExtentY        =   1058
      HighlightCheckedItems=   0   'False
      TickIconIndex   =   0
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   570
      Top             =   1380
      _ExtentX        =   1905
      _ExtentY        =   529
   End
   Begin UFFormPartner.UFFrmCaption UFFrmCaptionMgr 
      Left            =   150
      Top             =   1680
      _ExtentX        =   926
      _ExtentY        =   661
      Caption         =   "Form1"
      DebugFlag       =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Menu mFile 
      Caption         =   "�ļ�(&F)"
      Begin VB.Menu mSetUp 
         Caption         =   "ҳ������(&U)..."
      End
      Begin VB.Menu mPrintNo 
         Caption         =   "��ӡ���(&N)"
      End
      Begin VB.Menu mPreview 
         Caption         =   "��ӡԤ��(&V)"
      End
      Begin VB.Menu mPrint 
         Caption         =   "��ӡ(&P)...  Ctrl+P"
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
      End
   End
   Begin VB.Menu mOperation 
      Caption         =   "����(&O)"
      Begin VB.Menu mAdd 
         Caption         =   "���(&A)   F5"
      End
      Begin VB.Menu mModify 
         Caption         =   "�޸�(&M)   F7"
      End
      Begin VB.Menu mDelete 
         Caption         =   "ɾ��(&D)   Del"
      End
      Begin VB.Menu mS3 
         Caption         =   "-"
      End
      Begin VB.Menu mFilter 
         Caption         =   "����(&F)   F3"
      End
      Begin VB.Menu mPos 
         Caption         =   "��λ(&P)"
      End
      Begin VB.Menu mRefresh 
         Caption         =   "ˢ��        F9"
      End
      Begin VB.Menu ms4 
         Caption         =   "-"
      End
      Begin VB.Menu mFieldSet 
         Caption         =   "��Ŀ����(&S)"
      End
      Begin VB.Menu mMulModify 
         Caption         =   "�����޸�(&B)"
      End
      Begin VB.Menu m23 
         Caption         =   "-"
      End
      Begin VB.Menu mFindSet 
         Caption         =   "��������(&T)"
      End
      Begin VB.Menu mOptionSet 
         Caption         =   "ѡ��(&O)..."
      End
   End
   Begin VB.Menu mWindow 
      Caption         =   "����(&W)"
      Begin VB.Menu mText 
         Caption         =   "ͼ�갴ť(&I)"
      End
      Begin VB.Menu mStb 
         Caption         =   "״̬��(&S)"
      End
   End
   Begin VB.Menu mH 
      Caption         =   "����(&H)"
      Begin VB.Menu mHelp 
         Caption         =   "����     F1"
      End
      Begin VB.Menu mAbout 
         Caption         =   "����(&A)..."
         Visible         =   0   'False
      End
   End
   Begin VB.Menu mOrder 
      Caption         =   "����"
      Visible         =   0   'False
      Begin VB.Menu mAsc 
         Caption         =   "����"
      End
      Begin VB.Menu mDesc 
         Caption         =   "����"
      End
   End
End
Attribute VB_Name = "FrmInv"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

'============================================================
'������ƣ�U850�������
'�������ߣ�Visual Basic6.0
'��Ȩ�� �����������
'�������ͣ�ActiveDll
'ģ�鹦�ܣ����������Ϣά��
'����ӿڣ�

'============================================================
Option Explicit
Public m_cls As IIventory
Public m_Login As New clsLogin
Dim m_Rst As ADODB.Recordset '����ÿ�β�ѯ�����ݼ�����
Public m_cOrder As String '��Ҫ��ĳ�ֶ�����������е��ֶ�
Public WithEvents RefClient As UFReferC.UFReferClient
Attribute RefClient.VB_VarHelpID = -1

Dim m_bLoaded As Boolean '�Ƿ������
Dim m_bFirstLoad As Boolean '�Ƿ��״μ���
Dim iKeyPos As Integer '�ؼ�����λ��
Dim m_NamePos As Integer '�����ֶ���λ��
Public m_CodeVal As String '������ӡ��޸ĵı���ֵ
Public m_bEdit As Boolean '�Ƿ���б༭����Ȩ��
Public m_ReadOnlyCaption As String
Dim m_ColWidths As String
Dim m_bSelLastNode As Boolean   '�Ƿ񱣴洰���˳�ʱ���ͽڵ��Keyֵ
Dim m_FilterCon As String       '����������
Dim m_JoinTable As String       '�����ַ���
Dim m_PicCol  As Integer
Dim m_objShow As Object

Private Sub Grid_RowColChange()
    On Error GoTo Err_Info
    If m_bLoaded = True Then
        If m_PicCol > 0 Then
            If Not (m_objShow Is Nothing) Then
                m_objShow.Release
            End If
            If Grid.TextMatrix(Grid.Row, m_PicCol) = boolItems(1) Then
                Dim Rs As ADODB.Recordset
                Set Rs = SrvDB.OpenX("select Picture from inventory left join AA_Picture on  pictureguid=cGUID where cInvcode='" + Grid.TextMatrix(Grid.Row, iKeyPos) + "'")
                If Rs.RecordCount = 1 Then
                    If m_objShow Is Nothing Then
                        Set m_objShow = CreateObject("U8FloatShow.IShow")
                    End If
                    'Call obj.LoadPicture(Rs, "Picture")
                    Call m_objShow.LoadPictureByPos(Rs, "Picture", Grid.hWnd, Grid.Width, CLng((Grid.Row - Grid.TopRow + 1) * Grid.RowHeight(0)))
                End If
            End If
        End If
    End If
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

Private Sub ClearPic()
    On Error Resume Next
    If Not (m_objShow Is Nothing) Then
        m_objShow.Release
    End If
End Sub
        

Private Sub mFilter_Click()
    Operating "Filter"
End Sub


'---------------------------------------
'���ܣ����������������
'---------------------------------------
Private Sub Form_Activate()
    If m_bFirstLoad = True Then
        Call SetTlbMnuState
        Grid.FixedRows = 0
        Grid.Rows = 1
        If LoadHead = False Then Exit Sub
        LblTotalPage.Caption = ""
        DoEvents '��ʹ����ؼ�������ϣ�Ȼ��ż�������
        DataRefresh
        Call g_oPub.SetFrameWeb(Me)
        m_bFirstLoad = False
        Call g_oPub.FrmPreCompile(SrvDB)
    End If
End Sub


Private Sub mOptionSet_Click()
    Operating "OptionSet"
End Sub

'---------------------------------------
'���ܣ����ô����ݼ�
'---------------------------------------
Private Sub UFFrmKeyHook_ContainerKeyDown(KeyCode As Integer, ByVal Shift As Integer)
    If Me.Enabled = False Then Exit Sub
    If Shift = 2 And KeyCode = vbKeyF3 Then
        Operating "Pos"
    ElseIf KeyCode = vbKeyPageUp Then
        If Shift = 4 Then
            FlipPage "First"
        Else
            FlipPage "Previous"
        End If
    ElseIf KeyCode = vbKeyPageDown Then
        If Shift = 4 Then
            FlipPage "Last"
        Else
            FlipPage "Next"
        End If
    ElseIf KeyCode = vbKeyReturn Then
        FlipPage "Enter"
    ElseIf KeyCode = vbKeyF5 Then
        Call Operating("Add")
    ElseIf KeyCode = vbKeyDelete Then
        If Me.ActiveControl Is Grid Then
            Call Operating("Delete")
        End If
    ElseIf KeyCode = vbKeyF7 Then
        Call Operating("Modify")
    ElseIf KeyCode = vbKeyF8 Then
        Call Operating("MulModify")
    ElseIf KeyCode = vbKeyF3 Then
        Call Operating("Find")
    ElseIf KeyCode = vbKeyP Then
        If Shift = 2 Then
            Call Operating("Print")
        End If
    ElseIf KeyCode = vbKeyF4 Then
        If Shift = 4 Then
            Call Operating("Exit")
        End If
    ElseIf KeyCode = vbKeyF1 Then
        Call Operating("Help")
    ElseIf KeyCode = vbKeyF9 Then
        Call Operating("Refresh")
    ElseIf KeyCode = vbKeyEscape Then
        Call ClearPic
    End If
End Sub

'---------------------------------------
'���ܣ�����������ݿ�����
'---------------------------------------
Private Sub Form_Load()
    On Error GoTo Err_Info
    'Call g_oPub.FrmUniteFont(Me)
    Call g_oPub.FormLayout(Me, "INVENTORY")
    Set RefClient = New UFReferC.UFReferClient
    'g_bGSP = True '��߲�������
    
    InitAccSet '�����г�����ʼ�����ɵ���˳��
    ConstInit
    
    Init
    LoadRes
    m_Login.cUserId = g_cUserId
    m_Login.cUserName = g_cUserName
    m_Login.UfDbName = g_UfDbName
    m_Login.CurDate = g_CurDate
    m_Login.cAcc_id = GetAccId
    m_Login.LanguageRegion = g_oPub.m_LocaleID
    
    If g_CallType = enuCSCall Then
        g_oPub.hook Me.hWnd
    Else
        Me.m23.Visible = False
        Me.mFindSet.Visible = False
    End If
    If g_bIsWeb = True Then
        mH.Visible = False
        Tlb.Buttons("Help").Visible = False
    End If
    Call g_oPub.frmloadInit(Me, g_oPub.GetResString("U8.AA.ARCHIVE.inventoryarch"), m_Login, SrvDB) '"�������"
    Call g_oPub.HelpX("Inventory", Me, g_oLogin, App, g_bIsWeb)
    InitInterface
    m_bFirstLoad = True
    Exit Sub
Err_Info:
    Debug.Print "frmMain_Form_Load_Error" + Err.Description
End Sub

'---------------------------------------
'���ܣ���ʼ��Web����
'---------------------------------------
Private Sub Init()
    On Error GoTo Err_Info
    UpDown1.Max = MAXPAGESIZE
    UpDown1.Min = MINPAGESIZE
    UpDown1.Increment = MINPAGESIZE
    UpDown2.Min = 1
    UpDown2.Increment = 1
    EdtPageSize.Property = EditLng
    EdtPageSize.MaxLength = Len(CStr(MAXPAGESIZE))
    EdtPageSize.Text = g_oPub.GetRegEdit("Inventory", "PageSize", g_bIsWeb, g_cUserId) 'CLng(MAXPAGESIZE / 2)
    EdtiCurPage.Property = EditLng
    'EdtiCurPage.MaxLength = 5
    MaxPageCount = 1 '��ʱ��ֵ
    Lblpagesize.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.pagesize") '
    Llbcurpage.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.curpage") '
    CmdRequest.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.request") '
    LblPage(0).Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.firstpage") '
    LblPage(1).Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.previouspage") '
    LblPage(2).Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.nextpage") '
    LblPage(3).Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.lastpage") '
    EdtiCurPage.Text = CStr(UpDown2.Min)
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

'---------------------------------------
'���ܣ�ͼƬ�б����ͼƬ�ͳ�ʼ��������
'---------------------------------------
Private Sub LoadRes()
    On Error GoTo Err_Info
    With ImageList1.ListImages
        '0:vbResBitmap
        '1:vbResIcon
        '2:vbResCursor
        .Add 1, "pAdd", LoadResPicture(119, 0)
    End With
    With Tlb
        .ImageList = ImageList1
        .Buttons(1).Key = "SetUp"
        .Buttons(2).Key = "Print"
        .Buttons(3).Key = "Preview"
        .Buttons(4).Key = "SaveFile"
        
        .Buttons(6).Key = "Add"
        .Buttons(7).Key = "Modify"
        .Buttons(8).Key = "Delete"
        
        .Buttons(10).Key = "Filter"
        .Buttons(11).Key = "Pos"
        .Buttons(12).Key = "Refresh"
        
        .Buttons(14).Key = "FieldSet"
        .Buttons(15).Key = "MulModify"
        
    End With
    PicSeparate.MousePointer = vbSizeWE
    FrmMain.Icon = LoadResPicture(101, vbResIcon)
    UFFrmCaptionMgr.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.inventoryarch")
    Call g_oPub.SetTlbEx(Tlb, "Inventory", g_oLogin, Me)
    Exit Sub
Err_Info:
    Debug.Print "frmMain_LoadRes_error"
End Sub

Private Sub SetTlbMnuState()
    On Error GoTo Err_Info
    Tlb.Buttons("Add").Enabled = g_PermitAddInventory
    Tlb.Buttons("Modify").Enabled = g_PermitModifyInventory
    Call g_oPub.ReRefreshUFTlb(Me)
    TLB2.Visible = False '��ֹTlb2��������ˢ��
    TLB2.Visible = True
    mAdd.Enabled = g_PermitAddInventory
    mModify.Enabled = g_PermitModifyInventory
    Exit Sub
Err_Info:
    
End Sub

'---------------------------------------
'���ܣ��������ͽڵ�ͳ�ʼ��״̬��
'---------------------------------------
Private Sub InitInterface()
    LblTotalPage.Caption = "" '���ڽ����ȵ�����Ȼ����غ���ʾ��¼��Ŀ�����Ч�ʡ� ��������
    Dim RstGradeDef As ADODB.Recordset '��������¼��
    Dim RstInvClass As ADODB.Recordset '��������¼��
    Dim strSql As String
    Dim i As Integer
    FrameWeb.Visible = g_bPage
    FrameWeb.Height = IIf(g_bPage = True, 500, 0)
    Me.KeyPreview = False
    Trv.HideSelection = False
    
    strSql = "select * from GradeDef where KeyWord='InventoryClass'"
    Set RstGradeDef = SrvDB.OpenX(strSql)
    If RstGradeDef.RecordCount = 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMMAIN.279_1") 'U8.AA.INVENTORY.FRMMAIN.279_1="���ݿ�ϵͳû���趨������������򣬽����趨!"
    End If
    strSql = "select * from InventoryClass order by cInvCCode asc"
    Set RstInvClass = SrvDB.OpenX(strSql)
    
    Dim sCodeRule As Variant '�������
    Dim iGrade As Integer
    sCodeRule = Trim(RstGradeDef!CODINGRULE)
    iGrade = Len(sCodeRule) '���뼶��
'    Trv.ImageList = ImageList1
    Trv.LineStyle = tvwRootLines
    Dim NodX As UFTREEVIEWLib.INode
    Set NodX = Trv.Nodes.Add(, , "r", g_oPub.GetResString("U8.AA.ARCHIVE.inventoryclass")) '"�������"
'    NodX.Image = 21

    
    Dim sRelative As String
    Dim Sum As Integer
    Dim sCode As String
    If RstInvClass.RecordCount = 0 Then
        NodX.Selected = True
        'DataRefresh
        Exit Sub
    End If
    RstInvClass.MoveFirst
    While Not RstInvClass.EOF
        sRelative = ""
        Sum = 0
        sCode = Trim(RstInvClass!cinvccode)
        For i = 1 To iGrade
            sRelative = Mid(sCode, 1, Sum)
            Sum = Sum + CInt(Mid(sCodeRule, i, 1))
            If Trim(Mid(sCode, Sum + 1, Len(sCode))) = "" Then Exit For
        Next i
        sRelative = "r" + sRelative
        Set NodX = Trv.Nodes.Add(sRelative, tvwChild, "r" + sCode, "(" + sCode + ") " + RstInvClass!cInvCName)
        RstInvClass.MoveNext
    Wend
'    NodX.Selected = True
    RstInvClass.MoveFirst
'    NodX.ExpandedImage = 0
    'Call g_oPub.SetTreeStyle(Trv, Me)
    Call g_oPub.SetArchOptions(m_Login, SrvDB, Me, "Inventory", m_bSelLastNode)
   Call Trv_NodeClick(NodX)
End Sub



'---------------------------------------
'���ܣ����ƴ����С�仯
'---------------------------------------
Private Sub Form_Resize()
    If FrmMain.WindowState = 1 Then Exit Sub 'Minimized
    
    Call g_oPub.frmResizeNew(Me, "inventory", "trv")
    Trv.Top = Pic.Top + Pic.Height - Screen.TwipsPerPixelX
    Trv.Height = Me.ScaleHeight - TLB2.Height - Stb.Height - 40 * Screen.TwipsPerPixelX - FrameWeb.Height 'stb.Top - Trv.Top - FrameWeb.Height
    
    FrameWeb.Top = Trv.Top + Trv.Height
    Call g_oPub.SetFrameWeb(Me)
    
    PicSeparate.Left = Trv.Left + Trv.Width
    PicSeparate.Width = 45
    PicSeparate.Top = Trv.Top
    PicSeparate.Height = Trv.Height
    
    
    Grid.Left = PicSeparate.Left + PicSeparate.Width
    Grid.Top = Trv.Top
    Grid.Width = Me.ScaleWidth - PicSeparate.Left - PicSeparate.Width 'FrmMain.Width - PicSeparate.Left - PicSeparate.Width - 200
    Grid.Height = Trv.Height
    
End Sub

Private Sub Form_Unload(Cancel As Integer)
    On Error Resume Next 'Web���û�ò������
'    Me.Hide
'    DoEvents
    Call ClearPic
    Set Cal = Nothing
    Set m_objShow = Nothing
    If g_CallType = enuCSCall Then
    g_oPub.Unhook Me.hWnd
    End If
    If m_ColWidths <> g_oPub.GetColWidthString(Grid) Then
        Call g_oPub.SaveColSet(SrvDB, Grid, "Inventory", g_cUserId)
    End If
    If m_bSelLastNode = True Then
        Call g_oPub.SaveArchOptions(m_Login, SrvDB, Me, "Inventory")
    End If
    m_Rst.Close
    Set m_Rst = Nothing
    Set m_Login = Nothing
    Set RefClient = Nothing
    Set m_cls = Nothing
    Call g_oPub.FrmUnLoad
End Sub

'---------------------------------------
'���ܣ�˫�������޸Ľ���
'---------------------------------------
Private Sub Grid_DblClick()
    If Grid.Row > 0 And Grid.Row < Grid.Rows Then
        Call Operating("Modify")
    End If
End Sub


'---------------------------------------
'���ܣ���������
'  ������nCol����Ҫ���������
'---------------------------------------
Private Sub DoSort(ByVal nCol As Integer)
    Grid.Redraw = False
    
    Grid.col = nCol
    Grid.ColSel = Grid.Cols - 1
    If mAsc.Checked = True Then
        Grid.Sort = 1 ' ��׼����
    Else
        Grid.Sort = 2 ' ��׼����
    End If
    Grid.Redraw = True
End Sub

'---------------------------------------
'���ܣ����������˵���ѡ������
'---------------------------------------
Private Sub grid_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call g_oPub.ShowPopupMenu(Me, Grid, Button, Shift, X, Y)
    Call g_oPub.SetGridSelect(Grid, 0, Button, Shift, X, Y)
End Sub

Private Sub Grid_KeyUp(KeyCode As Integer, Shift As Integer)
    Call g_oPub.SetGridSelect(Grid, 1, KeyCode, Shift, 0, 0)
End Sub

Private Sub PopMenuMgr_MenuClick(sMenuKey As String)
    Call g_oPub.GridSortNew(Me, Grid, sMenuKey)
End Sub

Private Sub mAbout_Click()
    Operating "About"
End Sub

Private Sub mAdd_Click()
    Operating "Add"
End Sub

'---------------------------------------
'���ܣ�ѡ��������
'---------------------------------------
Private Sub mAsc_Click()
    Call g_oPub.GridSort(Me, Grid, 1)
End Sub

Private Sub mDelete_Click()
    Operating "Delete"
End Sub

'---------------------------------------
'���ܣ�ѡ���н���
'---------------------------------------
Private Sub mDesc_Click()
    Call g_oPub.GridSort(Me, Grid, 2)
End Sub

Private Sub mExit_Click()
    Operating "Exit"
End Sub

Private Sub mFindSet_Click()
    Operating "FindSet"
End Sub

Private Sub mHelp_Click()
    Operating "Help"
End Sub

Private Sub mModify_Click()
    Operating "Modify"
End Sub

Private Sub mMulModify_Click()
    Operating "MulModify"
End Sub

Private Sub mPos_Click()
    Operating "Pos"
End Sub

Private Sub mPreview_Click()
    Operating "Preview"
End Sub

Private Sub mPrint_Click()
    Operating "Print"
End Sub

Private Sub mPrintNo_Click()
    Operating "mPrintNo"
End Sub

Private Sub mRefresh_Click()
    Operating "Refresh"
End Sub

Private Sub mSaveFile_Click()
    Operating "SaveFile"
End Sub

Private Sub mFieldSet_Click()
    Operating "FieldSet"
End Sub

Private Sub mSetUp_Click()
    Operating "SetUp"
End Sub



Private Sub mStb_Click()
    Operating "mStb"
End Sub

Private Sub mText_Click()
    Operating "mText"
End Sub

Private Sub PicSeparate_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call g_oPub.MouseEvent(Me, 1, Button, Shift, X, Y, "Inventory")
End Sub

'---------------------------------------
'���ܣ��϶��ָ���
'---------------------------------------
Private Sub PicSeparate_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call g_oPub.MouseEvent(Me, 2, Button, Shift, X, Y, "Inventory")
End Sub

'---------------------------------------
'���ܣ��϶��ָ��ߺ󣬴���ؼ�����
'---------------------------------------
Private Sub PicSeparate_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call g_oPub.MouseEvent(Me, 3, Button, Shift, X, Y, "Inventory")
End Sub

Private Sub Layout()
    Trv.Width = PicSeparate.Left - Trv.Left
    Grid.Left = PicSeparate.Left + PicSeparate.Width
    Grid.Width = Me.Width - Grid.Left - 200
End Sub

'---------------------------------------
'���ܣ����״̬�����ı���ʾģʽ
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
    Operating Button.Key
End Sub

Private Sub TLB2_OnCommand(ByVal enumType As UFToolBarCtrl.ENUM_MENU_OR_BUTTON, ByVal cButtonId As String, ByVal cMenuId As String)
    Operating cButtonId
End Sub

Private Sub Trv_NodeClick(ByVal Node As UFTREEVIEWLib.INode)
    If m_bLoaded = False Then Exit Sub
    UFFrmCaptionMgr.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.inventoryarch") & "-" & Node.Text
    DataRefresh
End Sub

'---------------------------------------
'���ܣ����ڹ������Ͳ˵�ѡ�����
'---------------------------------------
Public Sub Operating(ByVal Key As String)
    Call g_oPub.HelpShow(App, Key, Me, g_bIsWeb)
    Dim sMsg As String
    Dim RstInv As ADODB.Recordset
    Dim i As Long
    Dim iCol As Integer
    Select Case LCase(Key)
        Case LCase("SetUp"), LCase("Print"), LCase("Preview"), LCase("SaveFile")
            Call PrintAll(Key, Grid, Me.Prn)
        Case LCase("Add")
            If Tlb.Buttons("Add").Enabled = False Then Exit Sub
            If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 20, -1) = True Then
                'Exit Sub
                m_bEdit = False
                m_ReadOnlyCaption = g_oPub.GetResString("U8.AA.ARCHIVE.inventoryarch") + g_oPub.GetResString("U8.AA.U8DATAPRECISION.readonly") ' "[ֻ��]"
            Else
                m_bEdit = True
                m_ReadOnlyCaption = ""
            End If
            'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
            If Trv.Nodes.count = 1 And g_bIsWeb = True Then
                ReDim g_arr(1 To 1)
                g_arr(1) = g_oPub.GetResString("U8.AA.ARCHIVE.inventoryclass") '
                ShowMsg g_oPub.GetResFormatString("U8.AAARCHIVE.COMMON.no_cls_no_add", g_arr) '"û�д�����࣬������ӣ�"
                'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
                Exit Sub 'û�з���
            End If
'            If Trv.Nodes.count > 0 Then '��ֹ���ڵ㳬��32767
'                 For i = Trv.SelectedItem.Index To Trv.Nodes.count
'                    Trv.Nodes(i).Expanded = True
'                    If Trv.Nodes(i).children = 0 Then
'                        Trv.Nodes(i).Selected = True '����ĩ��ѡ��
'                        Exit For
'                    End If
'                Next i
'            End If
            If GetCodeCol(iCol) = False Then
                'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
                Exit Sub
            End If
            Dim frmAdd As New FrmZAM
            Call frmAdd.InitData(1, iCol, Grid.RowSel) '���
            g_bSaved = False
            frmAdd.Show vbModal
            Set frmAdd = Nothing
            'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
            If g_bSaved = True Then
                DataRefresh
                Call g_oPub.SetGridRow(Grid, m_CodeVal, g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode")) '"�������"
            End If
        Case LCase("Modify")
            If Tlb.Buttons("Modify").Enabled = False Then Exit Sub
            If Grid.Rows <= 1 Then Exit Sub
            If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 20, -1) = True Then
                'Exit Sub
                m_bEdit = False
                m_ReadOnlyCaption = g_oPub.GetResString("U8.AA.ARCHIVE.inventoryarch") + g_oPub.GetResString("U8.AA.U8DATAPRECISION.readonly") ' "[ֻ��]"
            Else
                m_bEdit = True
                m_ReadOnlyCaption = ""
            End If
            'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
            If GetCodeCol(iCol) = False Then
                'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
                Exit Sub
            End If
            Dim frmModify As New FrmZAM
            Call frmModify.InitData(2, iCol, Grid.RowSel)  '�޸�
            'FrmZAM.Edtcinvcode.BackColor = &H8000000F
            frmModify.Edtcinvcode.Enabled = False
'            FrmZAM.EdtdSDate.Enabled = False
'            FrmZAM.CmdDate(1).Visible = False
'            FrmZAM.Tlb.Buttons("SaveRs").Enabled = False
            g_bSaved = False
            frmModify.Show vbModal
            Set frmModify = Nothing
            'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
            If g_bSaved = True Then
                DataRefresh
                Call g_oPub.SetGridRow(Grid, m_CodeVal, iKeyPos) 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode")
            End If
        Case LCase("Delete")
            If (Grid.Rows < 2) Then Exit Sub 'Or (Grid.Row = 0)
            
            Dim Row As Long, col As Integer
            Dim ID As String, IDName As String
            For i = 1 To Grid.Rows - 1
                If Grid.TextMatrix(i, 1) = "Y" Then
                    Exit For
                End If
            Next i
            If i = Grid.Rows Then
                Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.sel_del_rst") '"��ѡ����Ҫɾ���ļ�¼!"
                Exit Sub
            End If
            IDName = "cInvCode"
            'If g_oPub.MsgBox(g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.del_all_sel_rst"), vbYesNo + vbExclamation, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then 'ȷ��ɾ����Щѡ��ļ�¼��
            If g_oPub.ShowTipMsg(Grid, iKeyPos, m_NamePos, Nothing, g_oLogin, SrvDB) = vbOK Then
                If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 2) = True Then
                    Exit Sub
                End If
                Call g_oPub.DeleteStart(Me)
                Dim bDelSuccess As Boolean '�Ƿ��гɹ�ɾ���ļ�¼
                Dim RstErrMsg As ADODB.Recordset
                Dim ShowFlds As String
                Dim arr(0 To 1) As String
                ShowFlds = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode") + "," + g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.description") '"�������,����"
                Call g_oPub.ModifyInitMsg(RstErrMsg, "cInvCode,cErrMsg", ShowFlds)
                For i = i To Grid.Rows - 1
                    If Grid.TextMatrix(i, 1) = "Y" Then
                        ID = Grid.TextMatrix(i, iKeyPos)
                        arr(0) = ID
                        If g_oPub.CheckAuthByCode(SrvDB, g_rowAuth, "Inventory", ID) = False Then
                            arr(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.readonly_not_del") ' "������¼Ϊֻ��Ȩ�ޣ�����ɾ����"
                        ElseIf SrvDB.Delete(ID, IDName, "Inventory", sMsg, g_cUserId) = False Then
                            arr(1) = sMsg
                        Else
                            arr(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.del_success") ' "ɾ���ɹ�!"
                            bDelSuccess = True
                        End If
                        Call g_oPub.ModifyAddMsg(RstErrMsg, arr)
                    End If
                Next i
                Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
                Call g_oPub.DeleteEnded(Me)
                Call g_oPub.ModifyShowMsg(Nothing, g_oLogin, SrvDB, RstErrMsg, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.information"))
                If bDelSuccess = False Then Exit Sub
            Else
                Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
                Exit Sub
            End If
            
            
            Dim lTopRow As Long
            Row = Grid.Row
            lTopRow = Grid.TopRow
            DataRefresh
            Call g_oPub.SetGridRow(Grid, "", "", Row, lTopRow)
        Case LCase("FindSet")
            'If g_bIsWeb = False Then
                Call g_oPub.FindSet(IIf(g_bIsWeb = True, m_Login, g_oLogin), g_URL + "�������", Me)
            'End If
        Case LCase("Filter"), LCase("Find")
            Dim sNode As String
            sNode = Trv.SelectedItem.Key
            sNode = Trim(Right(sNode, Len(sNode) - 1))
            'If g_bIsWeb = False Then
                
                Call g_oPub.Find(IIf(g_bIsWeb = True, m_Login, g_oLogin), g_URL + "�������", Me, m_FilterCon)
                'Call g_oPub.TransCon(sCon, "bSale,bPurchase,bSelf,bComsume,bProducing,bService,bAccessary,bInvEntrust,bInvQuality,bInvBatch,bInvOverStock,bBarCode,bTrack,bSerial,bSolitude,BPropertyCheck")
                If m_FilterCon <> vbNullString Then
                    Call DataRefresh(m_FilterCon)
                End If
            'Else
            '    FrmZFindCtl.Show vbModal
            'End If
        Case LCase("Pos")
            Call g_oPub.FindPos(Me, Grid)
        Case LCase("Refresh")
            DataRefresh '���ܱ�Ĳ���Ա�������ʱ����ͨ���˽���ˢ��
        Case LCase("FieldSet")
            'Call g_oPub.SaveColSet(SrvDB, Grid, "Inventory", g_cUserId)
            Dim frmColSet As New FrmZSet
            frmColSet.Show vbModal
            Set frmColSet = Nothing
        Case LCase("MulModify")
            If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 7) = True Then
                Exit Sub
            End If
            Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -7)
            Dim frmMulti As New FrmZMulModify
            frmMulti.Show vbModal
            Set frmMulti = Nothing
            'Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
        Case "allsel"
            For i = 1 To Grid.Rows - 1
                Grid.TextMatrix(i, 1) = "Y"
            Next i
            On Error Resume Next
            Grid.SetFocus 'Ŀ��ȫѡ�󣬿��԰�Delete��ɾ������
        Case "allcancel"
            For i = 1 To Grid.Rows - 1
                Grid.TextMatrix(i, 1) = ""
            Next i
        Case LCase("mStb")
            Call g_oPub.FrmOpt(Me, Key, "inventory", , m_Login, SrvDB)
            Form_Resize
        Case LCase("mText")
            Call g_oPub.FrmOpt(Me, Key, "inventory", , m_Login, SrvDB)
        Case LCase("mPrintNo")
            Call g_oPub.FrmOpt(Me, Key, "inventory", , m_Login, SrvDB)
        Case LCase("Help")
            If g_bIsWeb = False Then
                SendKeys "{F1}", False
            End If
        Case LCase("OptionSet")
            Dim obj As Object
            Set obj = CreateObject("U8ArchOption.IOptionSet")
            Call obj.Show(IIf(g_bIsWeb = True, m_Login, g_oLogin), g_oPub, SrvDB, "Inventory", g_bIsWeb)
            Set obj = Nothing
            Call g_oPub.InitArchEditParam(SrvDB, "Inventory", g_PermitAddInventory, g_PermitModifyInventory)
            Call SetTlbMnuState
'        Case LCase("About")
'            Dim Obj As Object
'            Set Obj = CreateObject("PAbout.IAbout")
'            Obj.Show Nothing
'            Set Obj = Nothing
        Case LCase("Exit")
            Unload Me
        Case Else
            Debug.Print "FrmVen_Tlb_ButtonClick_No Button Match!Check it Please!"
    End Select
End Sub



'---------------------------------------
'���ܣ���ñ���
'---------------------------------------
Private Function GetCodeCol(ByRef iCol As Integer) As Boolean
    GetCodeCol = False
'    Dim i As Integer
'    Dim Key As String
'    Key = LCase(g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode"))
'    For i = 0 To Grid.Cols - 1
'        If LCase(Grid.TextMatrix(0, i)) = Key Then Exit For
'    Next i
'    If i = Grid.Cols Then
'        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMMAIN.724_1") 'U8.AA.INVENTORY.FRMMAIN.724_1="����Ŀ�����У�ѡ�С�������롿��Ŀ!"
'        Exit Function
'    End If
    iCol = iKeyPos
    GetCodeCol = True
End Function

'---------------------------------------
'���ܣ�ˢ�´�����ݼ�
'---------------------------------------
Public Sub DataRefresh(Optional ByVal sCon As String = "")
    On Error GoTo Err_Info
    DoEvents
    EdtPageSize.Text = g_oPub.GetVal(EdtPageSize.Text, MINPAGESIZE, MAXPAGESIZE)
    EdtiCurPage.Text = g_oPub.GetVal(EdtiCurPage.Text, 1, MaxPageCount)
    Dim RstInv  As ADODB.Recordset '���������¼��
    Dim strSql As String
    Dim sCode As String
    Dim sWhereSql As String
    m_FilterCon = sCon
    Dim i As Integer
    If Trv.SelectedItem Is Nothing Then
        sCode = "r" '��ֹ���ڵ㳬��32767�����½���������ʱTrv.SelectedItemΪNothing
        Trv.SetFocus 'ǿ��ʹTrv.SelectedItemΪ��Nothing������count���޷��޸���
    Else
        sCode = Trv.SelectedItem.Key
    End If
    sCode = Trim(Right(sCode, Len(sCode) - 1))
    m_JoinTable = GetJoinStr(g_cFlds)
    If sCode <> "" Then
        strSql = "Select " + g_cFlds + " from Inventory   " + m_JoinTable
        sWhereSql = " where Inventory.cInvCCode like'" + sCode + "%' and " + g_sRowAuthInv
    Else
        strSql = "Select " + g_cFlds + " from Inventory   " + m_JoinTable
        sWhereSql = " where " + g_sRowAuthInv
    End If
    If sCon <> "" Then
        sWhereSql = sWhereSql + " and " + sCon
    End If
    
    strSql = strSql + sWhereSql
    If m_cOrder <> "" Then
        strSql = strSql & " Order by " & m_cOrder
    End If
    
    m_bLoaded = False
    Dim lMaxPageCount As Long
    Screen.MousePointer = vbHourglass
    Grid.MousePointer = flexHourglass
    If g_bIsWeb = True Then
        Call m_cls.OpenPage(strSql, CLng(FrmMain.EdtPageSize), CLng(FrmMain.EdtiCurPage), lMaxPageCount, RstInv, "", False, False)
    Else
        Call g_oPub.GetPageRst(Me, SrvDB, RstInv, "Inventory", "cInvCode", g_cFlds, m_JoinTable, sWhereSql, " Order by " + m_cOrder, CLng(EdtiCurPage), CLng(EdtPageSize), MaxPageCount)
    End If
    Grid.MousePointer = flexDefault
    Screen.MousePointer = vbDefault
    
    If RstInv Is Nothing Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.conditionerror") 'U8.AA.ARCHIVE.COMMON.conditionerror="��ѯ��������"
        m_bLoaded = True
        Exit Sub
    End If
    If sCon <> "" And RstInv.RecordCount = 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.findnothing") 'U8.AA.ARCHIVE.COMMON.findnothing="û�з���������¼��"
    End If
    
    Set m_Rst = RstInv.Clone
    
    Call g_oPub.BindRstToGrid(Me, RstInv)
'    If g_bIsWeb = True Then
'        Call FillGrid(RstInv)
'    Else
'        Call g_oPub.FlipPageFillGrid(Me, Grid, m_Rst, CLng(EdtPageSize), CLng(EdtiCurPage), MaxPageCount)
'    End If
    m_bLoaded = True
    Exit Sub
Err_Info:
    ShowMsg "DataRefresh:" & Err.Description
End Sub


''---------------------------------------
''�������������ӣ��޸Ĳ�ѯ
''���ܣ���ö�Ӧ����Ĵ�����ݼ�
''---------------------------------------
'Public Function GetInvRst() As ADODB.Recordset
'    Dim sCode As String
'    Dim strSql As String
'    sCode = Trv.SelectedItem.Key
'    sCode = Trim(Right(sCode, Len(sCode) - 1))
'    If sCode <> "" Then
'        strSql = "Select * from Inventory where cInvCCode like '" + sCode + "%' and " + g_sRowAuthInv
'    Else
'        strSql = "Select * from Inventory where " + g_sRowAuthInv
'    End If
'    Set GetInvRst = SrvDB.OpenX(strSql)
'End Function


'----------------------------------------------
'���̹��ܣ�����б��������ʾ�Ĺ���
'����Ĳ�����Rs :��Ҫ���б���ʾ�����ݼ�
'---------------------------------------------
Public Sub FillGrid(Rs As ADODB.Recordset)
    Dim lRstCount As Long
    Dim nFldCount As Integer
    FrmMain.Grid.MousePointer = flexHourglass
    Screen.MousePointer = vbHourglass
    lRstCount = Rs.RecordCount
    nFldCount = Rs.Fields.count
        
    ReDim g_arr(1 To 1)
    g_arr(1) = CStr(lRstCount)
    FrmMain.Stb.Panels(3).Text = g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.rstcount", g_arr)   'U8.AA.ARCHIVE.COMMON.rstcount="��ǰ��¼����" " ��"
    Dim var As Variant
    
    Grid.FillStyle = flexFillRepeat
    Grid.Redraw = False  ' ����������
    Dim i, j As Long
    Grid.Rows = lRstCount + 1
    'Grid.TextMatrix(0, 0) = "���"
    Grid.Redraw = True
    If Rs.RecordCount = 0 Then
        Stb.Panels(1).Text = Stb.Panels(1).Tag
        FrmMain.Grid.MousePointer = flexDefault
        Screen.MousePointer = vbDefault
        Exit Sub
    End If
    Grid.Redraw = False
    Grid.FixedRows = 1
    For i = 1 To lRstCount 'д���
        Grid.TextMatrix(i, 0) = CStr(i)
    Next i
    Rs.MoveFirst
    For i = 1 To lRstCount '�������
        For j = 1 To nFldCount
            var = Rs.Fields(j - 1)
            Grid.TextMatrix(i, j) = IIf(IsNull(var), "", var)
        Next j
        Rs.MoveNext
        If i Mod 200 = 0 Then
            Grid.Redraw = True
            Stb.Panels(1).Text = g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.loadingrstcount", g_arr) 'U8.AA.ARCHIVE.COMMON.loadingrstcount="�Ѽ��� '" + CStr(i) + "' ����¼......"
            DoEvents ' ���ѭ���������200����¼����ִ���ø�����ϵͳ
            Grid.Redraw = False
        End If
    Next i
    Call RepairGrid(Rs, lRstCount, nFldCount)
    Grid.col = 1
    Grid.Row = 1
    Grid.Redraw = True
    Stb.Panels(1).Text = Stb.Panels(1).Tag
    FrmMain.Grid.MousePointer = flexDefault
    Screen.MousePointer = vbDefault
End Sub


'---------------------------------------------------
'���ܣ� ��ʽ��Grid���ݸ�ʽ
'������ Rst��       ��ӵ�Grid�е����ݼ�
'       lRstCount�� ��ӵ��ܼ�¼��
'       nFldCount:  ��ӵ�����
'---------------------------------------------------
Public Sub RepairGrid(ByVal Rs As ADODB.Recordset, ByVal lRstCount As Long, ByVal nFldCount As Integer)
    Dim i As Long, j As Integer
    Dim sFldName As String
    Dim Numpoint As String
    Dim Index As String
    Dim sTemp As String
    With Grid
        For j = 1 To nFldCount
            sFldName = Rs.Fields(j - 1).Name
            Select Case LCase(sFldName)
                Case LCase("iGroupType")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        .TextMatrix(i, j) = iGroupTypeItems(CInt(Index))
                    Next i
                Case LCase("IRecipeBatch")
                    For i = 1 To lRstCount
                        Select Case .TextMatrix(i, j)
                            Case "1"
                                .TextMatrix(i, j) = iRecipeBatchItems(1) ' "����ҩ"
                            Case "2"
                                .TextMatrix(i, j) = iRecipeBatchItems(2) ' "����Ǵ���ҩ"
                            Case "3"
                                .TextMatrix(i, j) = iRecipeBatchItems(3) ' "����Ǵ���ҩ"
                            Case Else '"0"
                                .TextMatrix(i, j) = iRecipeBatchItems(0) ' "������"
                        End Select
                    Next i
                Case LCase("iPlanPolicy")
                    For i = 1 To lRstCount
                        Select Case .TextMatrix(i, j)
                            Case "1"
                                .TextMatrix(i, j) = iPlanPolicyItems(1) ' "MRP��"
                            Case "2"
                                .TextMatrix(i, j) = iPlanPolicyItems(2) ' "ROP��"
                            Case "3"
                                .TextMatrix(i, j) = iPlanPolicyItems(3) '"�����"
                            Case Else '"0"
                                .TextMatrix(i, j) = ""
                        End Select
                    Next i
                Case LCase("iROPMethod")
                    For i = 1 To lRstCount
                        Select Case .TextMatrix(i, j)
                            Case "1"
                                .TextMatrix(i, j) = iROPMethodItems(1) ' "�ֹ�"
                            Case "2"
                                .TextMatrix(i, j) = iROPMethodItems(2) ' "�Զ�"
                            Case Else
                                .TextMatrix(i, j) = ""
                        End Select
                    Next i
                Case LCase("iBatchRule")
                    For i = 1 To lRstCount
                        Select Case .TextMatrix(i, j)
                            Case "1"
                                .TextMatrix(i, j) = iBatchRuleItems(1) ' "ֱ������"
                            Case "2"
                                .TextMatrix(i, j) = iBatchRuleItems(2) ' "�̶�����"
                            Case "3"
                                .TextMatrix(i, j) = iBatchRuleItems(3) ' "�ڼ�����"
                            Case "4"
                                .TextMatrix(i, j) = iBatchRuleItems(4) ' "��������߿�"
                            Case "5"
                                .TextMatrix(i, j) = iBatchRuleItems(5) ' "��ʷ������"
                            Case Else
                                .TextMatrix(i, j) = ""
                        End Select
                    Next i
                Case LCase("iTestStyle")
                    For i = 1 To lRstCount
                        Select Case .TextMatrix(i, j)
                            Case "0"
                                .TextMatrix(i, j) = iTestStyleItems(0) '"ȫ��"
                            Case "1"
                                .TextMatrix(i, j) = iTestStyleItems(1) ' "���"
                            Case "2"
                                .TextMatrix(i, j) = iTestStyleItems(2) ' "�ƻ��Գ��"
                            Case "3"
                                .TextMatrix(i, j) = iTestStyleItems(3) ' "���ƻ��Գ��"
                            Case Else
                                .TextMatrix(i, j) = ""
                        End Select
                    Next i
                Case LCase("iDTMethod")
                    For i = 1 To lRstCount
                        Select Case .TextMatrix(i, j)
                            Case "0"
                                .TextMatrix(i, j) = iDTMethodItems(0) '"���������"
                            Case "1"
                                .TextMatrix(i, j) = iDTMethodItems(1) '"�������"
                            Case "2"
                                .TextMatrix(i, j) = iDTMethodItems(2) ' "��������"
                            Case "3"
                                .TextMatrix(i, j) = iDTMethodItems(3) '"����������"
                            Case Else
                                .TextMatrix(i, j) = ""
                        End Select
                    Next i
                Case LCase("iDTStyle")
                    For i = 1 To lRstCount
                        Select Case .TextMatrix(i, j)
                            Case "0"
                                .TextMatrix(i, j) = iDTStyleItems(0) '"����"
                            Case "1"
                                .TextMatrix(i, j) = iDTStyleItems(1) '"����"
                            Case "2"
                                .TextMatrix(i, j) = iDTStyleItems(2) '"�ſ�"
                            Case Else
                                .TextMatrix(i, j) = ""
                        End Select
                    Next i
                Case LCase("iDTLevel")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> -1 Then
                            .TextMatrix(i, j) = ciDTLevelItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iEndDTStyle")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> -1 Then
                            .TextMatrix(i, j) = iEndDTStyleItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iSupplyType")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> -1 Then
                            .TextMatrix(i, j) = iSupplyTypeItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("cMassUnit")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> -1 Then
                            .TextMatrix(i, j) = cMassUnitItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("cValueType")
                    For i = 1 To lRstCount
                        .TextMatrix(i, j) = g_oPub.GetDispTxt(.TextMatrix(i, j), cValueTypeDB, cValueTypeItems)
                    Next i
                Case LCase("cFrequency")
                    For i = 1 To lRstCount
                        .TextMatrix(i, j) = g_oPub.GetDispTxt(.TextMatrix(i, j), cFrequencyDB, cFrequencyItems)
                    Next i
                Case LCase("iCheckATP")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> -1 Then
                            .TextMatrix(i, j) = iCheckATPItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("cDTPeriod")
                    If LCase(g_oPub.m_LocaleID) <> "zh-cn" Then
                        Dim space As String
                        If LCase(g_oPub.m_LocaleID) = "en-us" Then space = " "
                        Dim month As String
                        Dim day As String
                        Dim noBigger As String
                        Dim andNoSmaller As String
                        noBigger = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.nobigger") + space '
                        month = space + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.month") + space '"��"
                        day = space + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.day")  '"��"
                        andNoSmaller = space + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.andnosmaller") + space '"�Ҳ�С��"
                        For i = 1 To lRstCount
                            sTemp = .TextMatrix(i, j)
                            If Len(sTemp) > 0 Then
                                sTemp = Replace(sTemp, "������", noBigger)
                                sTemp = Replace(sTemp, "�Ҳ�С��", andNoSmaller)
                                sTemp = Replace(sTemp, "��", month)
                                sTemp = Replace(sTemp, "��", day)
                                .TextMatrix(i, j) = sTemp
                            End If
                        Next i
                    End If
                Case "pictureguid"
                    For i = 1 To lRstCount
                        If Len(.TextMatrix(i, j)) > 0 Then
                            .TextMatrix(i, j) = boolItems(1)
                        End If
                    Next i
                Case LCase("iSurenessType")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> -1 Then
                            .TextMatrix(i, j) = iSurenessType(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iDateType")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> -1 Then
                            .TextMatrix(i, j) = iDateType(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iDynamicSurenessType")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> 0 Then
                            .TextMatrix(i, j) = iDynamicSurenessType(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iRequireTrackStyle")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) <> 0 Then
                            .TextMatrix(i, j) = iRequireTrackStyleItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iBOMExpandUnitType")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If Val(Index) = 2 Then
                            .TextMatrix(i, j) = iBOMExpandUnitTypeItems(2)
                        Else
                            .TextMatrix(i, j) = iBOMExpandUnitTypeItems(1)
                        End If
                    Next i
                 Case LCase("iExpiratDateCalcu")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) > 0 Then
                            .TextMatrix(i, j) = iExpiratDateCalcuItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iWarrantyUnit")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) > 0 Then
                            .TextMatrix(i, j) = iWarrantyUnitItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case LCase("iTestRule")
                    For i = 1 To lRstCount
                        Index = .TextMatrix(i, j)
                        If (IsNumeric(Index) = True) And Val(Index) >= 0 Then
                            .TextMatrix(i, j) = iTestRuleItems(CInt(Index))
                        Else
                            .TextMatrix(i, j) = ""
                        End If
                    Next i
                Case Else
                    Numpoint = g_oPub.geteleval(g_EleStyle, LCase(sFldName))
                    If Numpoint <> "" Then
                        For i = 1 To lRstCount
                            .TextMatrix(i, j) = g_oPub.FormatNum(.TextMatrix(i, j), CInt(Numpoint))
                        Next i
                    End If
            End Select
        Next j
    End With
End Sub

'---------------------------------------
'���ܣ������ʾ��ͷ
'������
'---------------------------------------
Public Function LoadHead() As Boolean
    LoadHead = False
    m_PicCol = 0 '��ֹ����rowchange�¼�����ʾͼƬ
    ClearPic
    Dim iCols As Integer
    Dim iFixedcols As Integer
    Dim sErr As String
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    Grid.TextMatrix(0, 0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.serialnumber") '"���"
    If Trim(g_cFormat) = "" Then
        g_cFormat = g_ColSet.getColInfo("Inventory", 1)
    End If
    If g_oPub.getColSet(g_cFormat, g_cFlds, iCols, m_cOrder, iFixedcols, Grid, sErr) = False Then
        ShowMsg g_oPub.GetResString("U8.AAARCHIVE.COMMON.initgridheaderror") 'U8.AAARCHIVE.COMMON.initgridheaderror="��ʼ���б���ִ���"
    End If
    If Len(g_cFlds) = 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.IIVENTORY.162_1") 'U8.AA.INVENTORY.IIVENTORY.162_1="��û�б������κδ�������ֶ�Ȩ�ޣ�����ʹ�ô������!"
        Unload Me
        Exit Function
    End If
    g_cFlds = " " + IIf(g_cFlds = "", "cInvCode,cInvName", g_cFlds) + " " ''û��������Ŀ,���������������ΪĬ��ֵ
    If Grid.Cols = 1 Then 'û��������Ŀ
        Grid.Cols = 3
        Grid.TextMatrix(0, 1) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode")
        Grid.ColAlignment(1) = flexAlignLeftTop
        Grid.TextMatrix(0, 2) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvname") ' "�������"
        Grid.ColAlignment(2) = flexAlignLeftTop
        Grid.FixedCols = 1
        iKeyPos = 1
        m_NamePos = 2
        Exit Function
    End If
    Dim sXML As String
    Dim arr() As String
    Dim i As Integer
    Dim bHaveCodeFld As Boolean
    arr = Split(g_cFlds, ",")
    For i = 0 To UBound(arr)
        If LCase(Trim(arr(i))) = "cinvcode" Then
            iKeyPos = i + 1
            bHaveCodeFld = True
            Exit For
        End If
    Next i
    m_PicCol = GetFldCol(g_cFlds, "PictureGUID")
    If bHaveCodeFld = False Then
        ReDim g_arr(0 To 0)
        g_arr(0) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode")
        ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.no_code_no_use", g_arr) '"��û�б������������ֶ�Ȩ�ޣ�����ʹ�øõ���!"
        Unload Me
        Exit Function
    End If
    strSql = "Select " + g_cFlds + " from Inventory   " + GetJoinStr(g_cFlds) + " where (1=2)"
    Set Rs = SrvDB.OpenX(strSql)
    Call g_oPub.FormatGrid(Grid, Rs, , "Inventory", , , sXML)
    m_NamePos = -1
    Call g_oPub.FindFldColPos(Rs, "cInvName", m_NamePos)
    If m_NamePos > 0 Then
        m_NamePos = m_NamePos + 1
    End If
    m_ColWidths = g_oPub.GetColWidthString(Grid)
    LoadHead = True
End Function

Private Function GetFldCol(flds As String, ByVal FldName As String) As Integer
    Dim arr() As String
    FldName = LCase(FldName)
    Dim i As Integer
    Dim iCol As Integer
    iCol = -1
    arr = Split(g_cFlds, ",")
    For i = 0 To UBound(arr)
        If LCase(Trim(arr(i))) = FldName Then
            iCol = i + 1
            Exit For
        End If
    Next i
    GetFldCol = iCol
End Function

'---------------------------------------
'ȡ��ָ�����Խڵ��ֵ
'������Ele xml �ڵ�
'      sAtt ��������
'���أ�����ֵ
'---------------------------------------
Public Function GetAttr(ByVal Ele As IXMLDOMElement, ByVal sAtt As String, Optional ByVal NullStyle As Byte = 0) As Variant
    Dim var As Variant
    
    If Ele Is Nothing Then Exit Function
    
    var = Ele.getAttribute(sAtt)
    GetAttr = IIf(IsNull(var) Or var = "", IIf(NullStyle = 0, "", 0), var)
End Function


'---------------------------------------
'���ܣ���ӡ�ӿ�
'������Key����Ӧ��ӡ�Ĺؼ���
'     Con��ָGrid���Ϳؼ�
'     Prn:ָĳ�������ϵĿؼ�
'---------------------------------------
Public Sub PrintAll(ByVal Key As String, ByRef Con As Control, ByRef Prn As Control)
    Prn.Visible = False
    Dim sData As String
    Dim sStyle As String
    Dim bMulTask As Boolean
    If g_oPub.GetPrintAuth(SrvDB, g_oLogin, "Inventory", Key) = False Then Exit Sub
    If Grid.Rows < 2 Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.nodata") '"û�п������ݣ�"
        Exit Sub
    End If
    Call g_oPub.HelpHide(App, Key, Me, g_bIsWeb)
    Screen.MousePointer = vbHourglass
    WriteSytle sStyle, Con
    WriteData sData, Con, Key
    If Prn.SetDataStyleXML(sData, True, sStyle, True, "Default") <> 0 Then
        Screen.MousePointer = vbDefault
        Exit Sub
    End If
    Screen.MousePointer = vbDefault
    Select Case LCase(Key)
        Case LCase("SetUp")
            If Prn.PageSetup <> -1 Then
                Call Prn.TriggerEvent(0)
            End If
        Case LCase("Print")
            Prn.DoPrint
        Case LCase("Preview")
            Prn.SetOwner (Prn.Parent.hWnd)
            Prn.PrintPreview
        Case LCase("SaveFile")
            Dim sTypeList As String
            Dim sSizeList As String
            Dim i As Long
            Dim e As Long
            i = 0
            Call GetTypeSize(sTypeList, sSizeList, Con)
            e = Prn.ExportToFile(i, sTypeList, sSizeList, "", "")
            Call g_oPub.PrintMsg("Inventory", e)
    End Select
End Sub



'---------------------------------------
'���ܣ���д��ӡ��ʽ�ַ���
'������sXML������XML��ʽ�ַ���
'     Con:Grid���͵Ŀؼ�
'---------------------------------------
Private Sub WriteSytle(ByRef sXML As String, ByRef Con As Control)
    Call g_oPub.GetPrnStyleFile(True, "", sXML, "Inventory", SrvDB, Con)
End Sub

'---------------------------------------
'���ܣ���д��ӡ����
'������sXML������XML��ʽ�ַ���
'     Con:Grid���͵Ŀؼ�
'---------------------------------------
Public Sub WriteData(ByRef sXML As String, ByRef Con As Control, ByVal Key As String)
    Dim cAccId As String
    Dim Pos As Integer
    Dim sFlag As String
    sFlag = LCase("CATALOG=UFDATA_")
    Pos = InStr(1, LCase(g_UfDbName), sFlag)
    cAccId = Mid(g_UfDbName, Pos + Len(sFlag), 3)
    Call g_oPub.GetPrnDataFile(True, sXML, "", "", g_oPub.GetResString("U8.AA.ARCHIVE.inventoryarch"), cAccId, g_cUserId, g_cUserName, Nothing, SrvDB, Con)
End Sub

'---------------------------------------
'���ܣ�����ֶ��������ͺδ�С
'������sTypeList�����������ַ���
'      sSizeList���ֶδ�С�ַ���
'      Con :Grid���Ϳؼ�
'---------------------------------------
Private Sub GetTypeSize(ByRef sTypeList As String, ByRef sSizeList As String, ByRef Con As Control)
    Dim RsType As New ADODB.Recordset
    Dim strSql As String
    Dim i As Integer
    Dim iType As Long
    Dim iSize As Integer

    strSql = "select " + g_cFlds + " from Inventory " + m_JoinTable + " where 1=2"
    Set RsType = SrvDB.OpenX(strSql)
    Call g_oPub.GetTypeSize(sTypeList, sSizeList, RsType, Con)
End Sub

'---------------------------------------
'���ܣ������ӡ����
'������varLocalSettings����ӡ���ô�
'     varModuleSettings����ʽ��
'---------------------------------------
Private Sub Prn_SettingChanged(ByVal varLocalSettings As Variant, ByVal varModuleSettings As Variant)
    Call g_oPub.SavePrnStyle(SrvDB, "Inventory", CStr(varLocalSettings) + CStr(varModuleSettings))
End Sub

'---------------------------------------
'���ܣ�ʵ�ַ�ҳ��ݼ�
'������Key���ؼ���ֵ
'---------------------------------------
Private Sub FlipPage(ByVal Key As String)
    Select Case LCase(Key)
        Case "first"
            If FrmMain.ActiveControl Is EdtPageSize Then
                EdtPageSize = UpDown1.Max
            ElseIf FrmMain.ActiveControl Is EdtiCurPage Then
                EdtiCurPage = UpDown2.Max
            End If
        Case "previous"
            If FrmMain.ActiveControl Is EdtPageSize Then
                UpDown1_UpClick
            ElseIf FrmMain.ActiveControl Is EdtiCurPage Then
                UpDown2_UpClick
            End If
        Case "next"
            If FrmMain.ActiveControl Is EdtPageSize Then
                UpDown1_DownClick
            ElseIf FrmMain.ActiveControl Is EdtiCurPage Then
                UpDown2_DownClick
            End If
        Case "last"
            If FrmMain.ActiveControl Is EdtPageSize Then
                EdtPageSize = UpDown1.Min
            ElseIf FrmMain.ActiveControl Is EdtiCurPage Then
                EdtiCurPage = 1
            End If
        Case "enter"
            If FrmMain.ActiveControl Is EdtPageSize Or FrmMain.ActiveControl Is EdtiCurPage Then
                CmdRequest_Click
            End If
    End Select
End Sub

'---------------------------------------
'���ܣ���Сҳ��С
'---------------------------------------
Private Sub UpDown1_DownClick()
    EdtPageSize = Val(EdtPageSize) - UpDown1.Increment
    If Val(EdtPageSize) < UpDown1.Min Then
        EdtPageSize = Val(EdtPageSize) + UpDown1.Increment
    End If
End Sub

'---------------------------------------
'���ܣ�����ҳ��С
'---------------------------------------
Private Sub UpDown1_UpClick()
    EdtPageSize = Val(EdtPageSize) + UpDown1.Increment
    If Val(EdtPageSize) > UpDown1.Max Then
        EdtPageSize = Val(EdtPageSize) - UpDown1.Increment
    End If
End Sub

'---------------------------------------
'���ܣ���ǰ��ҳ
'---------------------------------------
Private Sub UpDown2_DownClick()
    EdtiCurPage = Val(EdtiCurPage) - UpDown2.Increment
    If Val(EdtiCurPage) < UpDown2.Min Then
        EdtiCurPage = Val(EdtiCurPage) + UpDown2.Increment
    End If
End Sub
'---------------------------------------
'���ܣ����ҳ
'---------------------------------------
Private Sub UpDown2_UpClick()
    EdtiCurPage = Val(EdtiCurPage) + UpDown2.Increment
    If Val(EdtiCurPage) > UpDown2.Max Then
        EdtiCurPage = Val(EdtiCurPage) - UpDown2.Increment
    End If
End Sub


'---------------------------------------
'���ܣ��Է�ҳLabel�ָ�ΪĬ������
'---------------------------------------
Private Sub FrameWeb_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Dim i As Integer
    For i = 0 To LblPage.UBound
        LblPage(i).ForeColor = vbBlack
        LblPage(i).FontUnderline = False
        LblPage(i).MousePointer = vbDefault
    Next i
End Sub


'---------------------------------------
'���ܣ�����Label��ҳ��ǩ���ı䵱ǰҳ��
'������Index����ǩ�±�
'---------------------------------------
Private Sub LblPage_Click(Index As Integer)
    If m_bLoaded = False Then Exit Sub
    Select Case Index
        Case 0
            EdtiCurPage = "1"
        Case 1
            EdtiCurPage = CStr(IIf(Val(EdtiCurPage) - 1 < 1, 1, Val(EdtiCurPage) - 1))
        Case 2
            EdtiCurPage = CStr(Val(EdtiCurPage) + 1)
        Case 3
            EdtiCurPage = MaxPageCount '"0" '�ٶ�0Ϊ���һҳ
    End Select
    If g_bIsWeb = True Then
        Call DataRefresh(m_FilterCon)
    Else
        m_bLoaded = False
        Call DataRefresh(m_FilterCon)
        'Call g_oPub.FlipPageFillGrid(Me, Grid, m_Rst, CLng(EdtPageSize), CLng(EdtiCurPage), MaxPageCount)
        m_bLoaded = True
    End If
    If MaxPageCount <= 1 Then
        Call LblPageEnabled(False, False)
    ElseIf EdtiCurPage = "1" Then
        Call LblPageEnabled(False, True)
    ElseIf CStr(MaxPageCount) = EdtiCurPage.Text Then
        Call LblPageEnabled(True, False)
    Else
        Call LblPageEnabled(True, True)
    End If
End Sub

'---------------------------------------
'���ܣ����÷�ҳ��Label�״̬
'������bFore����ǰ����ҳ״̬��־
'       bBack����ĩҳ״̬��־
'---------------------------------------
Public Sub LblPageEnabled(ByVal bFore As Boolean, ByVal bBack As Boolean)
    LblPage(0).Enabled = bFore
    LblPage(1).Enabled = bFore
    LblPage(2).Enabled = bBack
    LblPage(3).Enabled = bBack
End Sub
'---------------------------------------
'���ܣ�����ҳLabel��ǩ����������ʾģʽ
'������Index����ǩ�±�
'---------------------------------------
Private Sub LblPage_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    LblPage(Index).ForeColor = vbBlue
    LblPage(Index).FontUnderline = True
    LblPage(Index).MousePointer = 99
    LblPage(Index).MouseIcon = LoadResPicture(138, 1)
End Sub

'---------------------------------------
'���ܣ�ʵ�ֲ��ջ�ȡ��Ŀ������Ϣ
'������cKey:��Ҫ������Ŀ�Ĺؼ���
'      iReturnMode:����ģʽ
'    sxml����Ŀ����XML��ʽ�ַ���
'---------------------------------------
Private Sub RefClient_EventGetColInfo(ByVal cKey As String, ByVal iReturnMode As Byte, sXML As Variant)
    sXML = g_ColSet.getColInfo(cKey, iReturnMode)
End Sub

'---------------------------------------
'���ܣ�ʵ�ֲ�����Ŀ������Ϣ
'������sxml����Ŀ����XML��ʽ�ַ���
'       bFlag�������Ƿ���ȷ
'---------------------------------------
Private Sub RefClient_EventSave(sXML As String, bFlag As Variant)
    bFlag = g_ColSet.Save(sXML)
End Sub
'---------------------------------------
'���ܣ�ʵ�ֲ��տͻ��˷�ҳ��Ϣ
'������strTableName���б���ʾ����
'   lPageSize:��ҳ��ҳ��С
'   lPageCount:�ֳɵ�ҳ��
'   lCurPage����ǰҳ��
'   strFilter����������
'   strMatch��ƥ������
'   strOrder:��������
'---------------------------------------
Private Sub RefClient_ReferRefresh(ByVal strTablename As String, ByVal lPageSize As Long, ByVal lPageCount As Long, ByVal lCurPage As Long, ByVal strFilter As String, ByVal strMatch As String, ByVal strOrder As String)
    Call ReplyRefEvent(strTablename, lPageSize, lPageCount, lCurPage, strFilter, strMatch, strOrder)
End Sub

'---------------------------------------
'���ܣ���ѡ��ķ�ҳ��С��ҳ�������ʾ
'---------------------------------------
Private Sub CmdRequest_Click()
    If m_bLoaded = False Then Exit Sub
    If g_bIsWeb = True Then
        Call DataRefresh(m_FilterCon)
    Else
        m_bLoaded = False
        Call DataRefresh(m_FilterCon)
        'Call g_oPub.FlipPageFillGrid(Me, Grid, m_Rst, CLng(EdtPageSize), CLng(EdtiCurPage), MaxPageCount)
        m_bLoaded = True
    End If
    Call g_oPub.SaveRegEdit("Inventory", "PageSize", EdtPageSize.Text, g_bIsWeb, g_cUserId)
End Sub

''---------------------------------------
''���ܣ�������ǰҳ��ѡ��
''---------------------------------------
'Private Sub EdtiCurPage_Change()
'     If Val(EdtiCurPage) > MaxPageCount Then
'        EdtiCurPage = CStr(MaxPageCount)
'     ElseIf Val(EdtiCurPage) < 1 Then
'        EdtiCurPage = "1"
'     End If
'End Sub
''---------------------------------------
''���ܣ�����ҳ��Сѡ��
''---------------------------------------
'Private Sub EdtPageSize_Change()
'    If Val(EdtPageSize) > MAXPAGESIZE Then
'        EdtPageSize = CStr(MAXPAGESIZE)
'    ElseIf Val(EdtPageSize) < MINPAGESIZE Then
'        EdtPageSize = CStr(MINPAGESIZE)
'    End If
'End Sub


