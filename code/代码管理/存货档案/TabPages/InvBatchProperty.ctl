VERSION 5.00
Object = "{A98B9C82-88D8-4F94-91BB-F2289111C59C}#1.0#0"; "UFCheckBox.ocx"
Begin VB.UserControl InvBatchProperty 
   ClientHeight    =   6105
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11295
   LockControls    =   -1  'True
   ScaleHeight     =   6105
   ScaleWidth      =   11295
   Begin UFCHECKBOXLib.UFCheckBox chkbBatchCreate 
      Height          =   315
      Left            =   330
      TabIndex        =   0
      Top             =   240
      Width           =   1425
      _Version        =   65536
      _ExtentX        =   2514
      _ExtentY        =   556
      _StockProps     =   15
      Caption         =   "�������ε���"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
      Picture         =   "InvBatchProperty.ctx":0000
      DownPicture     =   "InvBatchProperty.ctx":001C
      DisabledPicture =   "InvBatchProperty.ctx":0038
   End
   Begin VB.Frame FramBatchCreate 
      Height          =   5715
      Left            =   30
      TabIndex        =   11
      Top             =   300
      Width           =   11205
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   9
         Left            =   360
         TabIndex        =   10
         Top             =   3360
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   8
         Left            =   360
         TabIndex        =   9
         Top             =   3045
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   -1
         BorderStyle     =   -1
         ReadyState      =   -1
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   7
         Left            =   360
         TabIndex        =   8
         Top             =   2745
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   24920
         BorderStyle     =   19472
         ReadyState      =   6230
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   6
         Left            =   360
         TabIndex        =   7
         Top             =   2430
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   5
         Left            =   360
         TabIndex        =   6
         Top             =   2115
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   -65536
         BorderStyle     =   18120
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   4
         Left            =   360
         TabIndex        =   5
         Top             =   1815
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   400
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   3
         Left            =   360
         TabIndex        =   4
         Top             =   1500
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   1996595444
         BorderStyle     =   0
         ReadyState      =   1996536096
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   2
         Left            =   360
         TabIndex        =   3
         Top             =   1185
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   1
         Left            =   360
         TabIndex        =   2
         Top             =   885
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   352
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBatchProperty 
         Height          =   195
         Index           =   0
         Left            =   360
         TabIndex        =   1
         Top             =   540
         Width           =   1905
         _Version        =   65536
         _ExtentX        =   3351
         _ExtentY        =   344
         _StockProps     =   15
         ForeColor       =   0
         ForeColor       =   1996595444
         BorderStyle     =   0
         ReadyState      =   1996536096
      End
   End
End
Attribute VB_Name = "InvBatchProperty"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'���ڷ�ҳ(�涨�ӿ�)
Public Event EdtKeyPress(fldName As String, KeyAscii As Integer)
'���ڼ���水ť(�涨�ӿ�)
Public Event ActiveSaveBtn()
Dim m_bShow As Boolean '�Ƿ���ʾ��ҳǩ
Dim m_SrvDB As Object
Dim m_sRFldAuthInv As String  'ֻ��Ȩ���ֶ���
Dim m_sNFldAuthInv As String  '��Ȩ���ֶ���
Dim m_bFilling As Boolean       '�Ƿ������������

'--------------------------------
'���ܣ��������ݳ�ʼ������(�涨�ӿ�)
'������
'   SrvDb:      ���ݷ������
'   oPub:       ������������
'   sXml:       ��������
'--------------------------------
Public Function Init(SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Init = False
    Dim i As Integer
    
    On Error GoTo Err_Info
    FramBatchCreate.Enabled = False
    Set m_SrvDB = SrvDB
    InitFace
    
    chkbBatchCreate.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.create_batch_arch") '
    
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
            If TypeOf Con Is Edit Or LCase(Left(Con.Name, 3)) = "edt" Then
                'Con.BadStr = g_oPub.BadStr
                If Con.Property = EditStr Then
                   Con.Property = EditNormal '��������ո�
                End If
            ElseIf TypeOf Con Is SuperGrid Then
                'Con.SetFilterString (g_oPub.BadStr)
            End If
        Next
    End With
    
    Dim strSql As String
    Dim i As Integer
    Dim j As Integer
    
    Dim Rs As ADODB.Recordset
    Dim tRs As ADODB.Recordset
    m_bShow = False
    strSql = "select * from userdef where cClass='��������'"
    Set Rs = m_SrvDB.OpenX(strSql)
        For i = 0 To chkbBatchProperty.UBound
        Set tRs = Filter(Rs, "CItem='����" + CStr(i + 1) + "'")
        If TxtValue(tRs!cItemName) <> "" Then
            chkbBatchProperty(i).Caption = TxtValue(tRs!cItemName)
            m_bShow = True
        Else
            chkbBatchProperty(i).Visible = False
            For j = chkbBatchProperty.UBound To i + 1 Step -1
                chkbBatchProperty(j).Left = chkbBatchProperty(j - 1).Left
                chkbBatchProperty(j).Top = chkbBatchProperty(j - 1).Top
                
            Next j
        End If
    Next i
    For i = 0 To chkbBatchProperty.UBound
        chkbBatchProperty(i).UToolTipText = IIf(g_oPub.GetStrLen(chkbBatchProperty(i).Caption, "", 0) > 8 * 2, chkbBatchProperty(i).Caption, "")
    Next i
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
    Dim sDef As String
    Dim i As Integer
    For i = 0 To chkbBatchProperty.UBound
        sDef = "bBatchProperty" + CStr(i + 1)
        Call ConSet(chkbBatchProperty(i), sDef)
    Next i
End Sub

'---------------------------------------
'���ܣ���ձ༭���CheckBox��comboBox���(�涨�ӿ�)
'---------------------------------------
Public Sub Emptyallfields()
    
    Dim Con As Control
    For Each Con In Controls
        If TypeOf Con Is Edit Then
            Con.Text = ""
            Con.UToolTipText = ""
            Con.Tag = ""
        ElseIf TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then
            Con.value = 0
        ElseIf TypeOf Con Is UFCOMBOBOXLib.UFComboBox Then
            Con.ListIndex = -1
        ElseIf TypeOf Con Is RefEdit Then
            Con.Clear
        End If
        If TypeOf Con Is SuperGrid Then Con.Rows = 1
    Next Con
End Sub


'-----------------------------------------------
'���ܣ������������ֶ����ݵĹ���(�涨�ӿ�)
'����Ĳ�����RsCard��������д������Դ�����ݼ���
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    On Error Resume Next
    m_bFilling = True
    
    Dim i As Long
    Dim sDef As String
    
    For i = 0 To chkbBatchProperty.UBound
        sDef = "bBatchProperty" + CStr(i + 1)
        chkbBatchProperty(i).value = ChkValue(RsCard.fields(sDef).value)
    Next i
    chkbBatchCreate.value = ChkValue(RsCard.fields("bBatchCreate").value)
    
    m_bFilling = False
End Sub

'-----------------------------------------
'���ܣ���ñ�����ַ���(�涨�ӿ�)
'������ bFlag�� �Ƿ���ȷ
'���أ� �����Xml�ַ���
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim i As Integer
    Dim sXml As String
    For i = 1 To chkbBatchProperty.UBound + 1
        Call EleXML(sXml, "bBatchProperty" + CStr(i), chkbBatchProperty(i - 1))
    Next i
    Call EleXML(sXml, "bBatchCreate", chkbBatchCreate)
    GetSaveXml = sXml
End Function

Private Sub chkbBatchCreate_Click()
    If chkbBatchCreate.value = Checked Then
        FramBatchCreate.Enabled = True
    Else
        FramBatchCreate.Enabled = False
    End If
    RaiseEvent ActiveSaveBtn
End Sub

'---------------------------------------
'���ԣ��Ƿ���ʾ
'---------------------------------------
Public Property Get BShow() As Boolean
    BShow = m_bShow
End Property

Private Sub chkbBatchProperty_Click(Index As Integer)
    RaiseEvent ActiveSaveBtn
End Sub

