VERSION 5.00
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Begin VB.UserControl InvPeriod 
   ClientHeight    =   675
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4800
   LockControls    =   -1  'True
   ScaleHeight     =   675
   ScaleMode       =   0  'User
   ScaleWidth      =   4800
   Begin VB.PictureBox Pic 
      BackColor       =   &H80000009&
      Height          =   525
      Left            =   0
      ScaleHeight     =   465
      ScaleMode       =   0  'User
      ScaleWidth      =   4695
      TabIndex        =   4
      Top             =   0
      Width           =   4755
      Begin EDITLib.Edit Edt 
         Height          =   225
         Index           =   3
         Left            =   2880
         TabIndex        =   3
         Top             =   90
         Width           =   285
         _Version        =   65536
         _ExtentX        =   503
         _ExtentY        =   397
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Property        =   3
         MaxLength       =   2
         Appearance      =   0
      End
      Begin EDITLib.Edit Edt 
         Height          =   225
         Index           =   2
         Left            =   2370
         TabIndex        =   2
         Top             =   90
         Width           =   285
         _Version        =   65536
         _ExtentX        =   503
         _ExtentY        =   397
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Property        =   3
         MaxLength       =   2
         Appearance      =   0
      End
      Begin EDITLib.Edit Edt 
         Height          =   225
         Index           =   1
         Left            =   1083
         TabIndex        =   1
         Top             =   90
         Width           =   285
         _Version        =   65536
         _ExtentX        =   503
         _ExtentY        =   397
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Property        =   3
         MaxLength       =   2
         Appearance      =   0
      End
      Begin EDITLib.Edit Edt 
         Height          =   225
         Index           =   0
         Left            =   586
         TabIndex        =   0
         Top             =   90
         Width           =   285
         _Version        =   65536
         _ExtentX        =   503
         _ExtentY        =   397
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Property        =   3
         MaxLength       =   2
         Appearance      =   0
      End
      Begin UFLABELLib.UFLabel lbl 
         Height          =   195
         Index           =   0
         Left            =   30
         TabIndex        =   10
         Top             =   90
         Width           =   540
         _Version        =   65536
         _ExtentX        =   952
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "������"
         BackColor       =   16777215
      End
      Begin UFLABELLib.UFLabel lbl 
         Height          =   195
         Index           =   1
         Left            =   887
         TabIndex        =   9
         Top             =   90
         Width           =   180
         _Version        =   65536
         _ExtentX        =   317
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "��"
         BackColor       =   16777215
      End
      Begin UFLABELLib.UFLabel lbl 
         Height          =   195
         Index           =   2
         Left            =   1384
         TabIndex        =   8
         Top             =   90
         Width           =   180
         _Version        =   65536
         _ExtentX        =   317
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "��"
         BackColor       =   16777215
      End
      Begin UFLABELLib.UFLabel lbl 
         Height          =   195
         Index           =   3
         Left            =   1635
         TabIndex        =   7
         Top             =   90
         Width           =   720
         _Version        =   65536
         _ExtentX        =   1270
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "�Ҳ�С��"
         BackColor       =   16777215
      End
      Begin UFLABELLib.UFLabel lbl 
         Height          =   195
         Index           =   4
         Left            =   2670
         TabIndex        =   6
         Top             =   90
         Width           =   180
         _Version        =   65536
         _ExtentX        =   317
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "��"
         BackColor       =   16777215
      End
      Begin UFLABELLib.UFLabel lbl 
         Height          =   195
         Index           =   5
         Left            =   3180
         TabIndex        =   5
         Top             =   90
         Width           =   180
         _Version        =   65536
         _ExtentX        =   317
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "��"
         BackColor       =   16777215
      End
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   0
      Top             =   630
      _ExtentX        =   1905
      _ExtentY        =   529
      ManualAttach    =   -1  'True
   End
End
Attribute VB_Name = "InvPeriod"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit
'���ڼ���水ť(�涨�ӿ�)
Public Event ActiveSaveBtn()

Public Enum AuthType
    enuNone = 0
    enuReadOnly = 1
    enuWrite = 2
End Enum
Dim m_auth As AuthType

'--------------------------------
'���ܣ��������ݳ�ʼ������(�涨�ӿ�)
'������
'   SrvDb:      ���ݷ������
'   oPub:       ������������
'   sXml:       ��������
'--------------------------------
Public Function Init(SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Init = False
    If g_oPub Is Nothing Then
        Set g_oPub = oPub
    End If
    '�ؼ����ܶ��� Call g_oPub.UCtrlLayout(GetControls, "U8.AA.ARCHIVE.TABPAGES.InvPeriod")
    InitFace
    lbl(0) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.nobigger") '"������"
    lbl(1) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.month") '"��"
    lbl(2) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.day") '"��"
    lbl(3) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.andnosmaller") '"�Ҳ�С��"
    lbl(4) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.month") '"��"
    lbl(5) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.day") '"��"
    Init = True
    Exit Function
Err_Info:
    Init = False
End Function


'---------------------------------------------
'���ܣ���ʼ�����棺���塢�����ַ�
'��������
'---------------------------------------------
Private Sub InitFace()
    Dim Con As Control
    On Error Resume Next
    With UserControl
        For Each Con In .Controls
            If Not (TypeOf Con Is Line) Then
                Con.Font.Name = g_oPub.FontName ' "����" '"MS Sans Serif" '
                Con.Font.Size = g_oPub.FontSize ' 9 'С�����
                Con.Font.Charset = g_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            End If
        Next
    End With
End Sub
Private Sub UserControl_Initialize()
    On Error Resume Next
    
    m_auth = enuWrite
    Dim i As Integer
    For i = 0 To 3
        Edt(i).BadStrEx = "-"
        Edt(i).BottomLine = True
    Next i
    
    Pic.BackColor = &HFFFFFF
    For i = 0 To lbl.UBound
        lbl(i).BackColor = &HFFFFFF
    Next i
    UserControl.KeyPreview = False
End Sub
'

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
   If UserControl.Ambient.UserMode = True Then
      UFFrmKeyHook.Attach
   End If
End Sub

Private Sub Edt_Change(Index As Integer)
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub Edt_LostFocus(Index As Integer)
    On Error GoTo Err_Info
    If (UserControl.ActiveControl Is Nothing) Or UserControl.ActiveControl Is Pic Then
        If GetEdtInt(Edt(1)) > 30 Or GetEdtInt(Edt(3)) > 30 Then
            ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.PERIOD.50_1") 'U8.AA.U8TABPAGES.PERIOD.50_1="������첻�ô���30��"
            Exit Sub
        End If
        If NoSmallVisible = True Then
            If GetEdtInt(Edt(0)) * 30 + GetEdtInt(Edt(1)) < GetEdtInt(Edt(2)) * 30 + GetEdtInt(Edt(3)) Then
                ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.PERIOD.55_1") 'U8.AA.U8TABPAGES.PERIOD.55_1="'������ʱ��'����С��'��С��ʱ��'��"
            End If
        End If
    End If
    Exit Sub
Err_Info:
    
End Sub





Private Function GetEdtInt(txt As String) As Integer
    On Error GoTo Err_Info
    If Len(txt) = 0 Then
        txt = "0"
    End If
    GetEdtInt = CInt(txt)
    Exit Function
Err_Info:
    GetEdtInt = 0
End Function

Private Sub UFFrmKeyHook_ContainerKeyPress(KeyAscii As Integer)
    On Error Resume Next
    If UserControl.ActiveControl Is Nothing Then Exit Sub
    If KeyAscii = 13 Then
        If TypeOf UserControl.ActiveControl Is Edit Or TypeOf UserControl.ActiveControl Is EDITLib.Edit Or TypeOf UserControl.ActiveControl Is UFCOMBOBOXLib.UFComboBox Or TypeOf UserControl.ActiveControl Is UFCHECKBOXLib.UFCheckBox Or TypeOf UserControl.ActiveControl Is PictureBox Then
            SendKeys "{TAB}"
        End If
    End If
    
End Sub

Private Sub UserControl_Resize()
    On Error Resume Next
    Pic.Left = 0
    Pic.Top = 0
    Pic.Height = UserControl.Height
    Pic.width = UserControl.width
    Dim i As Integer
    Dim iTop As Integer
    iTop = (Pic.Height - lbl(i).Height) / 2
    For i = 0 To lbl.UBound
        lbl(i).Top = iTop
    Next i
    For i = 0 To Edt.UBound
        Edt(i).Top = iTop
    Next i
    
End Sub


Public Property Get Text() As String
    Text = GetTxt
End Property

Private Function GetTxt() As String
    Dim txt As String
    Dim M As String
    Dim D As String
    M = GetMDVal(Edt(0).Text)
    D = GetMDVal(Edt(1).Text)
    'txt = lbl(0).Caption + M + lbl(1).Caption + D + lbl(2).Caption
    txt = "������" + M + "��" + D + "��"
    'txt = txt + "  "
    If lbl(3).Visible = True Then
        M = GetMDVal(Edt(2).Text)
        D = GetMDVal(Edt(3).Text)
        txt = txt + "�Ҳ�С��" + M + "��" + D + "��"
    End If
    GetTxt = txt
End Function

'----------------------------------------
'���ܣ������ո�Ĭ��ֵ
'������Edt���ؼ�
'
'----------------------------------------
Private Function GetMDVal(sText As String) As String
    Dim s As String
    s = sText
    If Len(s) = 0 Then
        s = "0"
    End If
    GetMDVal = s
End Function

Public Property Let Text(ByVal val As String)
    Dim i As Integer
    If Len(val) = 0 Then
        For i = 0 To Edt.UBound
            Edt(i).Text = ""
        Next i
    Else
    Dim bigM As Integer, bigD As Integer, smallM As Integer, smallD As Integer
    Call GetNum(val, bigM, bigD, smallM, smallD)
    Edt(0).Text = CStr(bigM)
    Edt(1).Text = CStr(bigD)
    Edt(2).Text = CStr(smallM)
    Edt(3).Text = CStr(smallD)
    End If
End Property

'------------------------------------------------------------
'���ܣ���ò��������պͲ�С������
'������ val��       ���ݿⱣ�����ֵ
'       bigM:       ��������
'       bigD��      ��������
'       smallM��    ��С����
'       smallD:     ��С����
'------------------------------------------------------------
Public Sub GetNum(val As String, bigM As Integer, bigD As Integer, smallM As Integer, smallD As Integer)
    Dim Pos1 As Integer
    Dim Pos2 As Integer
    Dim sNotBig As String
    Dim sNotSmall As String
    Pos1 = InStr(1, val, "��С��") ''g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.nosmaller")
    If Pos1 > 0 Then
        sNotBig = Trim(Left(val, Pos1 - 1))
        sNotSmall = Trim(Right(val, Len(val) - Pos1 + 1))
    Else
        sNotBig = Trim(val)
    End If
    Call Calculate(sNotBig, "������", bigM, bigD) 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.nobigger")
    Call Calculate(sNotSmall, "��С��", smallM, smallD) 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.nosmaller")
End Sub

'----------------------------------------------------
'���ܣ���������������
'������ Val  ��     ���ʽ
'       sFlag��     "������"��"��С��"
'       iMonths��   ����
'       iDays��     ����
'----------------------------------------------------
Private Function Calculate(val As String, sFlag As String, ByRef iMonths As Integer, ByRef iDays As Integer) As Boolean
    Calculate = False
    On Error GoTo Err_Info
    Dim Pos1 As Integer
    Dim Pos2 As Integer
    Dim ilen1 As Integer 'һ���ֳ���
    Dim iLen3 As Integer '�����ֳ���
    Dim sTemp As String
    ilen1 = Len("��") 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.month")
    iLen3 = Len("������") 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.nobigger")
    Pos1 = InStr(1, val, sFlag)
    val = Replace(val, "_", "")
    If Len(val) = 0 Or Pos1 = 0 Then
        iMonths = 0
        iDays = 0
        Calculate = True
        Exit Function
    End If
    Pos2 = InStr(Pos1, val, "��") 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.month")
    If Pos2 = 0 Then '����
        iMonths = 0
        Pos2 = InStr(Pos1, val, "��") 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.day")
        If Pos2 = 0 Then
            iDays = 0 '����
        Else
            sTemp = Mid(val, Pos1 + iLen3, Pos2 - Pos1 - iLen3)
            If Len(sTemp) = 0 Then
                iDays = 0
            Else
                iDays = CInt(sTemp)
            End If
        End If
    Else
        sTemp = Mid(val, Pos1 + iLen3, Pos2 - Pos1 - iLen3)
        If Len(sTemp) = 0 Then
            iMonths = 0
        Else
            iMonths = CInt(sTemp)
        End If
        Pos1 = Pos2
        Pos2 = InStr(Pos1, val, "��") 'g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.day")
        If Pos2 = 0 Then
            iDays = 0 '����
        Else
            sTemp = Mid(val, Pos1 + ilen1, Pos2 - Pos1 - ilen1)
            If Len(sTemp) = 0 Then
                iDays = 0
            Else
                iDays = CInt(sTemp)
            End If
        End If
    End If
    Calculate = True
    Exit Function
Err_Info:
End Function

Public Property Get NoSmallVisible() As Boolean
    NoSmallVisible = lbl(3).Visible
End Property

Public Property Let NoSmallVisible(ByVal vNewValue As Boolean)
    Dim i As Integer
    For i = 3 To lbl.UBound
        lbl(i).Visible = vNewValue
    Next i
    For i = 2 To Edt.UBound
        Edt(i).Visible = vNewValue
    Next i
End Property


Public Property Let Auth(ByVal RW As AuthType)
    Dim i As Integer
    If RW = enuNone Then '��Ȩ��
        For i = 0 To Edt.UBound
            Edt(i).Enabled = False
            Edt(i).PasswordChar = "*"
            Edt(i).Locked = True
        Next i
    ElseIf RW = enuReadOnly Then '��
        For i = 0 To Edt.UBound
            Edt(i).Enabled = False
            Edt(i).Locked = True
        Next i
    Else ''Ĭ��ȫ��
    
    End If
    
End Property

Public Property Get Enabled() As Boolean
    Enabled = Pic.Enabled
End Property

Public Property Let Enabled(ByVal vNewValue As Boolean)
    Pic.Enabled = vNewValue
    Dim i As Integer
    For i = 0 To lbl.UBound
        'lbl(i).Enabled = vNewValue 'ʹ�ø���䣬�����ַ����ϲ���ʾ��ȫ
        lbl(i).BackColor = Pic.BackColor
        lbl(i).Refresh
    Next i
    For i = 0 To Edt.UBound
        Edt(i).Enabled = vNewValue
    Next i
End Property


Public Property Get PasswordChar() As String
    PasswordChar = Edt(0).PasswordChar
End Property

Public Property Let PasswordChar(ByVal vNewValue As String)
    Dim i As Integer
    For i = 0 To Edt.UBound
        Edt(i).PasswordChar = vNewValue
    Next i
End Property

Public Property Get Locked() As Boolean
    Locked = Edt(0).Locked
End Property

Public Property Let Locked(ByVal vNewValue As Boolean)
    Dim i As Integer
    For i = 0 To Edt.UBound
        Edt(i).Locked = vNewValue
    Next i
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
