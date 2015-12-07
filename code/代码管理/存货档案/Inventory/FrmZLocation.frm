VERSION 5.00
Begin VB.Form FrmZLocation 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "定位条件"
   ClientHeight    =   1755
   ClientLeft      =   45
   ClientTop       =   270
   ClientWidth     =   2910
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1755
   ScaleWidth      =   2910
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin EDITLib.Edit Edt1 
      Height          =   315
      Left            =   0
      TabIndex        =   2
      Top             =   1020
      Width           =   2895
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton Cmd1 
      Height          =   315
      Left            =   1395
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   1380
      Width           =   1140
   End
   Begin UFFrames.UFFrame Frame1 
      Height          =   1020
      Left            =   15
      TabIndex        =   0
      Top             =   -45
      Width           =   2880
      Begin UFRADIOLib.UFRadio Opt1 
         Caption         =   "按存货编码定位"
         Height          =   270
         Left            =   480
         TabIndex        =   5
         Top             =   120
         Value           =   -1  'True
         Width           =   2250
      End
      Begin UFRADIOLib.UFRadio Opt2 
         Caption         =   "按存货代码定位"
         Height          =   300
         Left            =   480
         TabIndex        =   4
         Top             =   400
         Width           =   2295
      End
      Begin UFRADIOLib.UFRadio Opt3 
         Caption         =   "按存货名称定位"
         Height          =   270
         Left            =   480
         TabIndex        =   3
         Top             =   720
         Width           =   2295
      End
   End
End
Attribute VB_Name = "FrmZLocation"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public StrLoc As String
Public ColLoc As Integer

Private Sub Cmd1_Click()
    If Opt1.Value = True Then ColLoc = 1
    If Opt2.Value = True Then ColLoc = 2
    If Opt3.Value = True Then ColLoc = 3
    StrLoc = Trim(Edt1)
    Unload Me
End Sub

Private Sub Edt1_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = 13 Then
        Cmd1_Click
    End If
End Sub

Private Sub Form_Load()
    'Me.HelpContextID = 31100004

    Me.Caption = LoadResString(109)
    Me.Opt1.Caption = LoadResString(2201)
    Me.Opt2.Caption = LoadResString(2202)
    Me.Opt3.Caption = LoadResString(2203)
    Me.Cmd1.Picture = LoadResPicture(115, 0)
End Sub


