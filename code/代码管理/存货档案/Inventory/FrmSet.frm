VERSION 5.00
Object = "{005151D4-33F6-471B-B651-222D4E411832}#4.4#0"; "UFFormPartner.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.4#0"; "UFKEYHOOK.ocx"
Object = "{FD63B21C-3120-44CC-BE26-443A969FCF33}#1.0#0"; "U8ColumnSetOcx.ocx"
Begin VB.Form FrmZSet 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "栏目设置"
   ClientHeight    =   5565
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   8730
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5565
   ScaleWidth      =   8730
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin U8ColumnSetOcx.ColSet ColSet1 
      Height          =   4830
      Left            =   -90
      TabIndex        =   0
      Top             =   270
      Width           =   8790
      _ExtentX        =   15505
      _ExtentY        =   8520
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   570
      Top             =   30
      _ExtentX        =   1905
      _ExtentY        =   529
   End
   Begin UFFormPartner.UFFrmCaption UFFrmCaptionMgr 
      Left            =   0
      Top             =   0
      _ExtentX        =   926
      _ExtentY        =   661
      Caption         =   "Form1"
      DebugFlag       =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
End
Attribute VB_Name = "FrmZSet"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit


Private Sub ColSet1_Save(ByVal Update As Boolean, sXml As Variant)
    If Update Then
        g_ColSet.Save CStr(sXml)
    End If
    g_cFormat = g_oPub.GetUnSavedColSet(CStr(sXml)) 'CStr(sXml) '
    Me.Hide
    Call FrmMain.LoadHead
    FrmMain.DataRefresh
    Unload Me
End Sub

Private Sub Form_Load()
    Call g_oPub.FormLayout(Me, "INVENTORY")
    Call g_oPub.FrmUniteFont(Me)
    '调用主窗体的总帮助
    Me.HelpContextID = FrmMain.HelpContextID
    UFFrmCaptionMgr.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.columnset") '"栏目设置"
    Me.Icon = Nothing ' LoadResPicture(101, vbResIcon)
    Me.Move (Screen.Width - Me.ScaleWidth) / 2, (Screen.Height - Me.ScaleHeight) / 2
    ColSet1.Init g_ColSet.getColInfo("Inventory")
End Sub

Private Sub Colset1_Cancel()
    Unload Me
End Sub

Private Sub Colset1_ResetDefault()
    ColSet1.Init g_ColSet.getColInfo("Inventory", 2)
End Sub



Private Sub Form_Resize()
    Call g_oPub.ColSetResize(Me, ColSet1)
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Call g_oPub.FrmUnLoad
End Sub
