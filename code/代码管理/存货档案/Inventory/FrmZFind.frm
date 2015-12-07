VERSION 5.00
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Begin VB.Form FrmZFind 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "过滤条件"
   ClientHeight    =   4965
   ClientLeft      =   45
   ClientTop       =   270
   ClientWidth     =   5400
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4965
   ScaleWidth      =   5400
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDate 
      Height          =   210
      Index           =   3
      Left            =   4215
      Style           =   1  'Graphical
      TabIndex        =   37
      Top             =   4305
      Width           =   255
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDate 
      Height          =   210
      Index           =   2
      Left            =   2460
      Style           =   1  'Graphical
      TabIndex        =   36
      Top             =   4305
      Width           =   255
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDate 
      Height          =   210
      Index           =   1
      Left            =   4215
      Style           =   1  'Graphical
      TabIndex        =   35
      Top             =   3945
      Width           =   255
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDate 
      Height          =   210
      Index           =   0
      Left            =   2460
      Style           =   1  'Graphical
      TabIndex        =   34
      Top             =   3945
      Width           =   255
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk1 
      Caption         =   "是否受托代销"
      Height          =   180
      Left            =   630
      TabIndex        =   22
      Top             =   1980
      Width           =   1800
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk2 
      Caption         =   "是否成套件"
      Height          =   255
      Left            =   2670
      TabIndex        =   21
      Top             =   1950
      Width           =   2025
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk3 
      Caption         =   "是否保质期管理"
      Height          =   300
      Left            =   630
      TabIndex        =   19
      Top             =   2685
      Width           =   2925
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk4 
      Caption         =   "是否批次管理"
      Height          =   270
      Left            =   630
      TabIndex        =   18
      Top             =   3090
      Width           =   2880
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk5 
      Caption         =   "是否呆滞积压"
      Height          =   210
      Left            =   630
      TabIndex        =   17
      Top             =   3525
      Width           =   2880
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk6 
      Caption         =   "销售"
      Height          =   180
      Left            =   630
      TabIndex        =   16
      Top             =   1155
      Width           =   915
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk7 
      Caption         =   "外购"
      Height          =   240
      Left            =   2055
      TabIndex        =   15
      Top             =   1140
      Width           =   870
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk8 
      Caption         =   "生产耗用"
      Height          =   225
      Left            =   3240
      TabIndex        =   14
      Top             =   1125
      Width           =   1050
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk9 
      Caption         =   "自制"
      Height          =   195
      Left            =   630
      TabIndex        =   13
      Top             =   1530
      Width           =   1020
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk10 
      Caption         =   "在制"
      Height          =   195
      Left            =   2055
      TabIndex        =   12
      Top             =   1530
      Width           =   855
   End
   Begin UFCHECKBOXLib.UFCheckBox Chk11 
      Caption         =   "应税劳务"
      Height          =   255
      Left            =   3240
      TabIndex        =   11
      Top             =   1500
      Width           =   1110
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdCancel 
      Cancel          =   -1  'True
      Height          =   315
      Left            =   2580
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   4600
      Width           =   1095
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdEnter 
      Default         =   -1  'True
      Height          =   315
      Left            =   1275
      Style           =   1  'Graphical
      TabIndex        =   9
      Top             =   4600
      Width           =   1095
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton Command1 
      Height          =   255
      Left            =   4080
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   2325
      Width           =   270
   End
   Begin EDITLib.Edit ttMC 
      Height          =   270
      Left            =   1395
      TabIndex        =   7
      Top             =   840
      Width           =   1440
   End
   Begin EDITLib.Edit txtDM 
      Height          =   270
      Left            =   1410
      TabIndex        =   6
      Top             =   480
      Width           =   1440
   End
   Begin EDITLib.Edit txtDM1 
      Height          =   270
      Left            =   3225
      TabIndex        =   3
      Top             =   480
      Width           =   1440
   End
   Begin EDITLib.Edit ttMC1 
      Height          =   270
      Left            =   3225
      TabIndex        =   2
      Top             =   840
      Width           =   1440
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton Command5 
      Height          =   210
      Left            =   2535
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   150
      Width           =   255
   End
   Begin UFFrames.UFFrame Frame1 
      Height          =   35
      Left            =   120
      TabIndex        =   0
      Top             =   4530
      Width           =   6015
   End
   Begin EDITLib.Edit Edt2 
      Height          =   255
      Left            =   2280
      TabIndex        =   20
      Top             =   2325
      Width           =   2100
      _Version        =   65536
      _ExtentX        =   3704
      _ExtentY        =   450
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      BadStr          =   "`~!@#$^&():|<>?"
   End
   Begin EDITLib.Edit txtBM 
      Height          =   270
      Left            =   1395
      TabIndex        =   5
      Top             =   120
      Width           =   1440
   End
   Begin EDITLib.Edit txtBM1 
      Height          =   270
      Left            =   3225
      TabIndex        =   4
      Top             =   120
      Width           =   1440
   End
   Begin EDITLib.Edit EdtDate 
      Height          =   255
      Index           =   0
      Left            =   1380
      TabIndex        =   38
      Top             =   3900
      Width           =   1380
      _Version        =   65536
      _ExtentX        =   2434
      _ExtentY        =   450
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   5
      MaxLength       =   10
   End
   Begin EDITLib.Edit EdtDate 
      Height          =   255
      Index           =   1
      Left            =   3135
      TabIndex        =   39
      Top             =   3900
      Width           =   1380
      _Version        =   65536
      _ExtentX        =   2434
      _ExtentY        =   450
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   5
      MaxLength       =   10
   End
   Begin EDITLib.Edit EdtDate 
      Height          =   255
      Index           =   2
      Left            =   1380
      TabIndex        =   40
      Top             =   4260
      Width           =   1380
      _Version        =   65536
      _ExtentX        =   2434
      _ExtentY        =   450
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   5
      MaxLength       =   10
   End
   Begin EDITLib.Edit EdtDate 
      Height          =   255
      Index           =   3
      Left            =   3135
      TabIndex        =   41
      Top             =   4260
      Width           =   1380
      _Version        =   65536
      _ExtentX        =   2434
      _ExtentY        =   450
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   5
      MaxLength       =   10
   End
   Begin UFLABELLib.UFLabel Lab2 
      AutoSize        =   -1  'True
      Caption         =   "主要供货单位编码"
      Height          =   180
      Left            =   600
      TabIndex        =   33
      Top             =   2355
      Width           =   1440
   End
   Begin UFLABELLib.UFLabel Lab3 
      AutoSize        =   -1  'True
      Caption         =   "启用日期"
      Height          =   180
      Left            =   630
      TabIndex        =   32
      Top             =   3930
      Width           =   720
   End
   Begin UFLABELLib.UFLabel Lab4 
      AutoSize        =   -1  'True
      Caption         =   "停用日期"
      Height          =   180
      Left            =   630
      TabIndex        =   31
      Top             =   4305
      Width           =   720
   End
   Begin UFLABELLib.UFLabel Label1 
      Caption         =   "至"
      Height          =   285
      Left            =   2790
      TabIndex        =   30
      Top             =   3930
      Width           =   165
   End
   Begin UFLABELLib.UFLabel Label2 
      Caption         =   "至"
      Height          =   240
      Left            =   2805
      TabIndex        =   29
      Top             =   4290
      Width           =   165
   End
   Begin UFLABELLib.UFLabel Label6 
      AutoSize        =   -1  'True
      Caption         =   "存货名称"
      Height          =   180
      Left            =   615
      TabIndex        =   28
      Top             =   855
      Width           =   720
   End
   Begin UFLABELLib.UFLabel Label5 
      AutoSize        =   -1  'True
      Caption         =   "存货代码"
      Height          =   180
      Left            =   615
      TabIndex        =   27
      Top             =   495
      Width           =   720
   End
   Begin UFLABELLib.UFLabel Label4 
      AutoSize        =   -1  'True
      Caption         =   "存货编码"
      Height          =   180
      Left            =   615
      TabIndex        =   26
      Top             =   135
      Width           =   720
   End
   Begin UFLABELLib.UFLabel Label7 
      Caption         =   "至"
      Height          =   285
      Left            =   2940
      TabIndex        =   25
      Top             =   210
      Width           =   165
   End
   Begin UFLABELLib.UFLabel Label8 
      Caption         =   "至"
      Height          =   285
      Left            =   2940
      TabIndex        =   24
      Top             =   540
      Width           =   165
   End
   Begin UFLABELLib.UFLabel Label9 
      Caption         =   "至"
      Height          =   210
      Left            =   2925
      TabIndex        =   23
      Top             =   855
      Width           =   165
   End
End
Attribute VB_Name = "FrmZFind"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim sClass  As String '存货分类

Public Sub Init(ByVal sNodeSel As String)
    sClass = sNodeSel
End Sub

Private Sub CmdCancel_Click()
    Unload Me
End Sub


'---------------------------------------
'功能：对应日期参照
'---------------------------------------
Private Sub CmdDate_Click(Index As Integer)
    Cal.Left = EdtDate(Index).Left
    Cal.Top = EdtDate(Index).Top + EdtDate(Index).Height + 100
    If Cal.Top + Cal.Height + 1000 > Me.Height Then
        Cal.Top = EdtDate(Index).Top - Cal.Height
    End If
    Cal.DateDivideChar = "-"
    EdtDate(Index).Text = Cal.Calendar(Me.hWnd)
    CmdDate(Index).Visible = False
End Sub

'---------------------------------------
'功能：执行查询功能
'---------------------------------------
Private Sub CmdEnter_Click()
    Dim sXML As String
    Dim sMsg As String
    Dim TableName(1) As String
    TableName(0) = "Inventory"
    WriteFindXML sXML, sClass
    Dim RsFind As ADODB.Recordset
    Set RsFind = SrvDB.Find(sXML, TableName, TableName, sMsg)
    If sMsg <> "" Then
        ShowMsg sMsg
        Exit Sub
    End If
    If RsFind Is Nothing Then
        ShowMsg "查询条件出错！"
        Exit Sub
    End If
    If RsFind.RecordCount = 0 Then
        ShowMsg "没有符合条件的存货！"
    End If
    Unload Me
    FrmMain.FillGrid RsFind
End Sub

Private Sub EdtDate_GotFocus(Index As Integer)
     CmdDate(Index).Visible = True
End Sub

Private Sub Form_Activate()
    Me.txtBM.SetFocus
End Sub

Private Sub Form_Load()
    On Error GoTo Err_info
    'Me.HelpContextID = 31100007
    Me.Caption = LoadResString(2008)
    Me.CmdEnter.Picture = LoadResPicture(115, 0)
    Me.CmdCancel.Picture = LoadResPicture(116, 0)
    Me.Chk1.Caption = LoadResString(2221)
    Me.Chk2.Caption = LoadResString(2222)
    Me.Chk3.Caption = LoadResString(2224)
    Me.Chk4.Caption = LoadResString(2225)
    Me.Chk5.Caption = LoadResString(2226)
    Me.Chk6.Caption = LoadResString(2215)
    Me.Chk7.Caption = LoadResString(2216)
    Me.Chk8.Caption = LoadResString(2217)
    Me.Chk9.Caption = LoadResString(2218)
    Me.Chk10.Caption = LoadResString(2219)
    Me.Chk11.Caption = LoadResString(2220)
    Me.Label1.Caption = LoadResString(2211)
    Me.Label2.Caption = LoadResString(2211)
    Label7.Caption = LoadResString(2211)
    Label8.Caption = LoadResString(2211)
    Label9.Caption = LoadResString(2211)
    Me.Lab2.Caption = LoadResString(2223)
    Me.Lab3.Caption = LoadResString(2227)
    Me.Lab4.Caption = LoadResString(2228)
    Me.Command1.Picture = LoadResPicture(118, 0)
    Me.Command5.Picture = LoadResPicture(118, 0)
    
    Dim i%
    For i = 0 To CmdDate.UBound
        CmdDate(i).Picture = LoadResPicture(108, 0)
        CmdDate(i).Visible = False
    Next i
    
    Exit Sub
Err_info:
    Debug.Print "FrmZFind_FormLoad_Error"
End Sub

