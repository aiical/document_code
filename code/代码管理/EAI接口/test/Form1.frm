VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3120
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5565
   LinkTopic       =   "Form1"
   ScaleHeight     =   3120
   ScaleWidth      =   5565
   StartUpPosition =   3  '´°¿ÚÈ±Ê¡
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   735
      Left            =   720
      TabIndex        =   0
      Top             =   1080
      Width           =   2025
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Dim sStr As String
    Dim oLogin As New U8Login.clsLogin
    Dim oEai As New EaiStoreInOut.clsInOut
    Dim oDom As New DOMDocument
    oDom.Load App.Path & "\storeinout.xml"
    If oLogin.Login("ST") Then
        oEai.Transact oDom.xml, oLogin
    Else
        MsgBox oLogin.ShareString
    End If
End Sub
