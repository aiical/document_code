VERSION 5.00
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Begin VB.UserControl ShowKeyInfo 
   ClientHeight    =   330
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   7665
   LockControls    =   -1  'True
   ScaleHeight     =   330
   ScaleWidth      =   7665
   Begin UFLABELLib.UFLabel LblCode 
      Height          =   195
      Left            =   120
      TabIndex        =   0
      Tag             =   "1"
      Top             =   90
      Width           =   855
      _Version        =   65536
      _ExtentX        =   1508
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "       编码："
      ForeColor       =   13382451
      AutoSize        =   -1  'True
   End
   Begin UFLABELLib.UFLabel LblName 
      Height          =   195
      Left            =   3900
      TabIndex        =   1
      Tag             =   "1"
      Top             =   90
      Width           =   945
      _Version        =   65536
      _ExtentX        =   1667
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "         名称："
      ForeColor       =   13382451
      AutoSize        =   -1  'True
   End
   Begin UFLABELLib.UFLabel lblCodeVal 
      Height          =   195
      Left            =   1110
      TabIndex        =   2
      Tag             =   "1"
      Top             =   90
      Width           =   1215
      _Version        =   65536
      _ExtentX        =   2143
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "                           "
      AutoSize        =   -1  'True
   End
   Begin UFLABELLib.UFLabel LblNameVal 
      Height          =   195
      Left            =   4830
      TabIndex        =   3
      Tag             =   "1"
      Top             =   90
      Width           =   990
      _Version        =   65536
      _ExtentX        =   1746
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "                      "
      AutoSize        =   -1  'True
   End
End
Attribute VB_Name = "ShowKeyInfo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Private Sub UserControl_Initialize()
    On Error Resume Next
    LblCode.Top = 3 * Screen.TwipsPerPixelY
    lblCodeVal.Top = 3 * Screen.TwipsPerPixelY
    LblName.Top = 3 * Screen.TwipsPerPixelY
    LblNameVal.Top = 3 * Screen.TwipsPerPixelY
    If Ambient.UserMode = True Then
        If Not g_oPub Is Nothing Then
            Call SetUnitFont(g_oPub)
        Else
            Dim obj As Object
            Set obj = CreateObject("U8Pub.IPub")
            Call SetUnitFont(obj)
            Set obj = Nothing
        End If
    End If
End Sub

'---------------------------------------------
'功能：初始化界面：字体、禁用字符
'参数：无
'---------------------------------------------
Private Sub SetUnitFont(oPub As Object)
    Dim Con As Control
    On Error Resume Next
    With UserControl
        For Each Con In .Controls
            If Not (TypeOf Con Is Line) Then
                Con.Font.Name = oPub.FontName ' "宋体" '"MS Sans Serif" '
                Con.Font.Size = oPub.FontSize ' 9 '小五号字
                Con.Font.Charset = oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            End If
        Next
    End With
End Sub

Private Sub UserControl_Resize()
    On Error Resume Next
    LblCode.Left = 5 * Screen.TwipsPerPixelX
    lblCodeVal.Left = LblCode.Left + LblCode.width + 2 * Screen.TwipsPerPixelX
    
    LblName.Left = UserControl.ScaleWidth / 2
    LblNameVal.Left = LblName.Left + LblName.width
    
    UserControl.Height = 22 * Screen.TwipsPerPixelY
End Sub


Public Property Let CodeCaption(ByVal vNewValue As String)
    On Error Resume Next
    LblCode.Caption = vNewValue
    lblCodeVal.Left = LblCode.Left + LblCode.width + Screen.TwipsPerPixelX * 4
End Property

Public Property Let NameCaption(ByVal vNewValue As String)
    On Error Resume Next
    LblName.Caption = vNewValue
    LblNameVal.Left = LblName.Left + LblName.width + Screen.TwipsPerPixelX * 4
End Property


Public Sub SetValue(ByVal codeCon As Object, nameCon As Object)
    On Error GoTo Err_Info
    lblCodeVal.Caption = GetValue(codeCon)
    LblNameVal.Caption = GetValue(nameCon)
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

Private Function GetValue(Con As Object) As String
    If Len(Con.PasswordChar) > 0 Then
        GetValue = String(Len(Con.Text), Con.PasswordChar)
    Else
        GetValue = Con.Text
    End If
End Function



