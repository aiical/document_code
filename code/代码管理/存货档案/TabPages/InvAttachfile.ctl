VERSION 5.00
Object = "{8C7C777D-4D83-4DE8-947E-098E2343A400}#1.0#0"; "CommandButton.ocx"
Object = "{18277A1C-A353-4E93-879A-E45DC95E7397}#2.4#0"; "UFFlexGrid.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Begin VB.UserControl InvAttachfile 
   ClientHeight    =   6750
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11295
   LockControls    =   -1  'True
   ScaleHeight     =   6750
   ScaleWidth      =   11295
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdAddFile 
      Height          =   345
      Left            =   5460
      TabIndex        =   1
      Top             =   6240
      Width           =   1305
      _Version        =   65536
      _ExtentX        =   2302
      _ExtentY        =   609
      _StockProps     =   41
      Caption         =   "��Ӹ���"
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
   Begin UFFlexGrid.UFFlexGridCtl Grid 
      Height          =   6045
      Left            =   30
      TabIndex        =   0
      Top             =   30
      Width           =   11205
      _ExtentX        =   19764
      _ExtentY        =   10663
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
      AllowUserResizing=   1
      BackColorBkg    =   -2147483638
      Cols            =   2
      SelectionMode   =   1
      Ellipsis        =   1
   End
   Begin MSComDlg.CommonDialog CommonDialog 
      Left            =   4890
      Top             =   4260
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDownLoadFile 
      Height          =   345
      Left            =   9840
      TabIndex        =   4
      Top             =   6240
      Width           =   1305
      _Version        =   65536
      _ExtentX        =   2302
      _ExtentY        =   609
      _StockProps     =   41
      Caption         =   "���ظ���"
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
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDeleteFile 
      Height          =   345
      Left            =   6930
      TabIndex        =   2
      Top             =   6240
      Width           =   1305
      _Version        =   65536
      _ExtentX        =   2302
      _ExtentY        =   609
      _StockProps     =   41
      Caption         =   "ɾ������"
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
   Begin UFCOMMANDBUTTONLib.UFCommandButton CmdOpen 
      Height          =   345
      Left            =   8400
      TabIndex        =   3
      Top             =   6240
      Width           =   1305
      _Version        =   65536
      _ExtentX        =   2302
      _ExtentY        =   609
      _StockProps     =   41
      Caption         =   "��"
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
End
Attribute VB_Name = "InvAttachfile"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Dim g_oClient As Object 'New U8FileManagerClient.U8FileManageClient
Dim sBaspartFlds As String

Dim m_sCode As String '�������
Dim m_SrvDB As Object
'���ڼ���水ť(�涨�ӿ�)
Public Event ActiveSaveBtn()
'��¼��ӵĸ���
Dim sGUIDCount() As String
Dim iCount As Integer
'��¼ɾ���ĸ���
Dim sGUIDDelCount() As String
Dim iDelCount As Integer
Dim m_cInvCode As String

Private Function InitAttachfile() As Boolean
    On Error GoTo Err_Info
    Dim sXml As String
    
    sXml = "<Attachfile>"
    sXml = sXml + "<id  Width='700' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.serialnumber") + "' ColDataType='2' ColTextWidth='16' ColPoint='' bRef='0'/>"
    sXml = sXml + "<AttachFileGUID  Width='0' Value='' ChName='GUID' ColDataType='2' ColTextWidth='16' ColPoint='' bRef='0'/>"
    sXml = sXml + "<cFileName  Width='6000' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.filename") + "' ColDataType='2' ColTextWidth='16' ColPoint='' bRef='0'/>"
    sXml = sXml + "</Attachfile>"
    Call g_oPub.UtoLCase(sXml)
    Call InitAttachfileGrid(g_oPub, Grid, sXml, sBaspartFlds)
    CmdAddFile.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.add_accessories")
    CmdDeleteFile.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.del_accessories")
    CmdDownLoadFile.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.down_accessories")
    CmdOpen.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.open")
    If LCase(g_oPub.m_LocaleID) = "en-us" Then
        CmdAddFile.UToolTipText = CmdAddFile.Caption
        CmdDeleteFile.UToolTipText = CmdDeleteFile.Caption
        CmdDownLoadFile.UToolTipText = CmdDownLoadFile.Caption
    End If
    Grid.BackColorSel = &H9F6646
    InitAttachfile = True
    Exit Function
Err_Info:
    InitAttachfile = False
    ShowMsg Err.Description

End Function

Private Sub CmdAddFile_Click()
    Dim remoteFileName As String
    Dim R As Long
    Dim strTemp As String
    Dim i As Integer
    Dim j As Integer
    CommonDialog.FileName = ""
    CommonDialog.Filter = "All Files(*.*)|*.*"
    CommonDialog.DefaultExt = "All Files(*.*)|*.*"
    CommonDialog.ShowOpen
    If (Len(CommonDialog.FileName) <> 0) Then
    
        'ȡ�ļ���
        strTemp = StrReverse(CommonDialog.FileName)    '���ִ�����
        i = InStr(1, strTemp, "\")       'ȡ��һ��б�˵�λ��
        strTemp = Mid(strTemp, 1, i - 1) '����һ��б�˵�λ��ȡ�������ļ���
        strTemp = StrReverse(strTemp)    '�ٽ��ִ����������Ϊ�����ļ���
        For j = 1 To Grid.Rows - 1
            If strTemp = Grid.TextMatrix(j, 2) Then
                ShowMsg g_oPub.GetResString("U8.AA.Archive.common.invattachfile_string") '"������ͬ������"
                Exit Sub
            End If
        Next j
        
        remoteFileName = g_oClient.AddFile(CommonDialog.FileName, True)
        'MsgBox remoteFileName
        If Len(remoteFileName) <> 0 Then
            With Grid
                            
                .Rows = .Rows + 1
                .Row = .Rows - 1
                For i = 0 To .Cols - 1
                    If .ColWidth(i) > 0 Then
                        .Col = i
                        .LeftCol = i
                        Exit For
                    End If
                Next i
                If (.Rows + 1) * .RowHeight(0) >= .Height Then
                    .TopRow = 2 + .Rows - (.Height \ .RowHeight(0))
                End If
                R = .Row
                
                .TextMatrix(R, 0) = R
                .TextMatrix(R, 1) = Left(remoteFileName, Len(remoteFileName) - 4)
                .TextMatrix(R, 2) = strTemp
                
                ReDim Preserve sGUIDCount(iCount) As String
                sGUIDCount(iCount) = Left(remoteFileName, Len(remoteFileName) - 4)
                iCount = iCount + 1
                'Me.FileList.AddItem remoteFileName
            End With
        RaiseEvent ActiveSaveBtn
        End If
    End If
    
End Sub

Private Sub CmdDeleteFile_Click()
    With Grid
        If Grid.Row > 0 Then
            ReDim Preserve sGUIDDelCount(iDelCount) As String
            sGUIDDelCount(iDelCount) = Grid.TextMatrix(Grid.Row, 1)
            iDelCount = iDelCount + 1
            Call Grid.RemoveItem(Grid.Row)
            WriteNo
            RaiseEvent ActiveSaveBtn
        End If
    End With
End Sub

Private Sub WriteNo()
    Dim i As Long
    For i = 1 To Grid.Rows - 1
        Grid.TextMatrix(i, 0) = CStr(i)
    Next i
End Sub


Private Sub Grid_Click()
    'Grid.ReadOnly = True
End Sub

'Private Sub GridAttachfile_DblClick()
'    Dim i As Integer
'    If GridAttachfile.Row > 0 Then
'        If GridAttachfile.TextMatrix(GridAttachfile.Row, 1) = "Y" Then
'            GridAttachfile.TextMatrix(GridAttachfile.Row, 1) = ""
'        Else
'            For i = 1 To GridAttachfile.Rows - 1
'                If GridAttachfile.TextMatrix(i, 1) = "Y" Then
'                    If GridAttachfile.TextMatrix(i, 4) = GridAttachfile.TextMatrix(GridAttachfile.Row, 4) Then
'                        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.invattachfile_sameness") '"������������ͬ���Ƶĸ�����"
'                        Exit Sub
'                    End If
'                End If
'            Next i
'            GridAttachfile.TextMatrix(GridAttachfile.Row, 1) = "Y"
'        End If
'
'    End If
'End Sub

Private Sub CmdDownLoadFile_Click()
    On Error GoTo Err_Info
    Dim strTemp As String
    Dim remoteFileName As String
    Dim sName As String
    Dim srcFileName As String
    If Grid.Row > 0 Then
        
        'ȡ�ļ���
        Dim bNoSuffix As Boolean 'û���ļ���׺
        srcFileName = Grid.TextMatrix(Grid.Row, 2)
        strTemp = StrReverse(srcFileName)    '���ִ�����
        CommonDialog.FileName = srcFileName
        i = InStr(1, strTemp, ".")       'ȡ��һ��б�˵�λ��
        If i > 0 Then '��ֹû�е�
            strTemp = Mid(strTemp, 1, i - 1) '����һ��б�˵�λ��ȡ�������ļ���
            bNoSuffix = False
        Else
            bNoSuffix = True
        End If
        strTemp = StrReverse(strTemp)    '�ٽ��ִ����������Ϊ�����ļ���
        If bNoSuffix = False Then
            sName = strTemp + "File(*." + strTemp + ")"
            CommonDialog.Filter = sName + "|*." + strTemp + "|All Files(*.*)|*.*"
            CommonDialog.DefaultExt = sName + "|." + strTemp
        Else
            sName = strTemp
            CommonDialog.Filter = ""
            CommonDialog.DefaultExt = ""
        End If
        CommonDialog.ShowSave
        
        If (srcFileName <> CommonDialog.FileName) Then '�ļ�����һ�£���ʾȡ����
            If Dir(CommonDialog.FileName) <> "" Then
                '"�ļ��Ѵ��ڣ������Ƿ񸲸ǣ�")
                If g_oPub.MsgBox(g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.file_exist_overwrite"), vbYesNo + vbExclamation, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbNo Then
                    Exit Sub
                End If
            End If
            Call g_oClient.ReadFile(Grid.TextMatrix(Grid.Row, 1) + ".txt", CommonDialog.FileName)
        'MsgBox g_oClient.ReadFile("e03ad446-e262-4b71-9b7a-c085bf237590.txt", CommonDialog.FileName)
        End If
    End If
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

Private Sub CmdOpen_Click()
    Dim lRet As Long
    Dim tempPath As String, tempFile As String
    Dim strMsg As String
    Dim fso As New FileSystemObject
    
    If Grid.Row <= 0 Then Exit Sub
    
    On Error GoTo errTrap
    
    tempPath = GetSpecialPath(0, CSIDL_INTERNET_CACHE) & "\"
    If Trim(tempPath) = "" Then
        ShowMsg "�޷���ȡ��ʱ·��"
        Exit Sub
    End If
        
    tempFile = tempPath + Grid.TextMatrix(Grid.Row, 2)
    On Error Resume Next
    If fso.FileExists(tempFile) Then fso.DeleteFile tempFile
    
    On Error GoTo errTrap
    Call g_oClient.ReadFile(Grid.TextMatrix(Grid.Row, 1) + ".txt", tempFile)
    If Not fso.FileExists(tempFile) Then
        ShowMsg "��������ʧ��"
        Exit Sub
    End If
    
    lRet = ShellExecute(0, "open", tempFile, vbNullString, vbNullString, vbNormalFocus)
    If lRet < 32 Then
        Select Case lRet
            Case 0:
                strMsg = "�ڴ治��"
            Case 31:
                strMsg = "û������ļ��������Ӧ�ó���"
        End Select
        If strMsg <> "" Then
            ShowMsg strMsg
        Else
            ShowMsg "��ʧ��"
        End If
    End If
    
    Set fso = Nothing
    Exit Sub
errTrap:
    ShowMsg Err.Description
End Sub

Private Sub UserControl_Initialize()
    UserControl.KeyPreview = False
End Sub


Public Function InitAttachfileGrid(oPub As Object, Grid As Object, sXml As String, sFlds As String) As Boolean
    'Call oPub.UtoLCase(sXml)
    Dim dom As New DOMDocument
    Dim ele As IXMLDOMElement
    Dim eleNd As IXMLDOMElement
    Dim i As Integer
    Dim width As String, sTemp As String
    If Not dom.loadXML(sXml) Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.xmlloaderror")  'XML���ش���
        Exit Function
    End If
    Set ele = dom.documentElement
    Grid.Rows = 1
    Grid.Cols = ele.childNodes.length
    ReDim ArrFlds(Grid.Cols)

    sFlds = ""
    With Grid
        For i = 0 To ele.childNodes.length - 1
            Set eleNd = ele.childNodes.Item(i)
            ArrFlds(i) = eleNd.NodeName
            sFlds = sFlds + ArrFlds(i) + ","
            .TextMatrix(0, i) = GetNodeAttrVal(eleNd, "ChName")

            width = GetNodeAttrVal(eleNd, "Width")
            If Len(width) = 0 Then
                width = 1500
            End If

            .ColWidth(i) = CStr(width)
            If width = "0" Then
                .Col = i
                .CellForeColor = .CellBackColor
            End If

            '���ܶ�̬�ı��п�
            If GetNodeAttrVal(eleNd, "MustInput") = "1" Then
                .Col = i
                .CellForeColor = oPub.MustInputColor
            End If

            If width = "0" Then
                .FixedAlignment(i) = 1 '��ֹMicrosoft Grid������ʾ
            Else
                .FixedAlignment(i) = 4
            End If
        Next i
    End With
    sFlds = Left(sFlds, Len(sFlds) - 1)
End Function

'--------------------------------
'���ܣ��������ݳ�ʼ������(�涨�ӿ�)
'������
'   SrvDb:      ���ݷ������
'   oPub:       ������������
'   sXml:       ��������
'--------------------------------
Public Function Init(oClient As Object, SrvDB As Object, oPub As Object, scInvCode As String) As Boolean
    On Error GoTo Err_Info
    'Set g_oLogin = oLogin
    Set g_oClient = oClient
    Set m_SrvDB = SrvDB
    Set g_oPub = oPub
    m_cInvCode = scInvCode
    InitAttachfile
    Call InitFace
'    InitgridAttach
    
'    FillAllGrid
    
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
End Sub

'-----------------------------------------
'���ܣ���ñ�����ַ���(�涨�ӿ�)
'������ bFlag�� �Ƿ���ȷ
'���أ� �����Xml�ַ���
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim i As Integer
    Dim sXml As String
    
    If Grid.Rows > 1 Then
        sXml = "<bIsAttachFile>1</bIsAttachFile>"
    Else
        sXml = "<bIsAttachFile>0</bIsAttachFile>"
    End If
    
    sXml = sXml + "<AttachfileAll>"
    For i = 1 To Grid.Rows - 1
         sXml = sXml + "<Attachfile>"
         sXml = sXml + "<AttachFileGUID>" + Grid.TextMatrix(i, 1) + "</AttachFileGUID>"
         sXml = sXml + "<cFileName>" + Grid.TextMatrix(i, 2) + "</cFileName>"
         sXml = sXml + "</Attachfile>"
    Next i
    sXml = sXml + "</AttachfileAll>"

    sXml = sXml + GetGridXml
    GetSaveXml = sXml
    iCount = 0
    
End Function

Private Sub FillAllGrid(Optional ByVal conName As String)
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    
    strSql = "select * from Attachfile where cInvCode ='" + m_sCode + "'"
    Set Rs = m_SrvDB.OpenX(strSql)
    Call FillGridCon(Grid, Rs)
    
End Sub

'---------------------------------------------------
'���ܣ���Grid�ؼ���������
'---------------------------------------------------
Private Sub FillGridCon(GridCon As UFFlexGridCtl, Rs As ADODB.Recordset)
    Dim i As Long
    Dim j As Integer
    Dim nFldCount  As Integer
    Dim sValue As String
    Dim cfilename As String
    
    Grid.Redraw = False  ' ����������
    If Rs.RecordCount > 0 Then
        Grid.Rows = Rs.RecordCount + 1
        Grid.FixedRows = 1
        Rs.MoveFirst
        nFldCount = Rs.fields.Count
        For i = 1 To Rs.RecordCount '�������
            Grid.TextMatrix(i, 0) = i
            cfilename = Left(Rs.fields(0).value, Len(Rs.fields(0).value) - 1)
            Grid.TextMatrix(i, 1) = Right(cfilename, Len(cfilename) - 1)
            Grid.TextMatrix(i, 2) = Rs.fields(2).value
            
            

            Rs.MoveNext
            If i Mod 200 = 0 Then
                Grid.Redraw = True
                DoEvents ' ���ѭ���������200����¼����ִ���ø�����ϵͳ
                Grid.Redraw = False
            End If
        Next i
        Grid.Col = 0
        Grid.Row = 1
    Else
        Grid.Rows = 1
    End If
    Grid.Redraw = True
End Sub

'-----------------------------------------------
'���ܣ������������ֶ����ݵĹ���(�涨�ӿ�)
'����Ĳ�����RsCard��������д������Դ�����ݼ���
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    On Error Resume Next
    m_sCode = TxtValue(RsCard!cinvcode)
    
    Call FillAllGrid
End Sub

Public Sub DeleteAddFile()
    If iCount = 0 Then
        Exit Sub
    End If
    Dim i As Integer
    For i = 0 To iCount - 1
        Call g_oClient.DeleteFile(sGUIDCount(i) + ".txt")
    Next i
    iCount = 0
End Sub

Public Sub DeleteFile(cinvcode As String)
    If iDelCount = 0 Then
        Exit Sub
    End If
    Dim i As Integer
    For i = 0 To iDelCount - 1
        Call g_oClient.DeleteFile(sGUIDDelCount(i) + ".txt")
    Next i
    iDelCount = 0
End Sub

'---------------------------------------
'���ܣ���ձ༭���CheckBox��comboBox���(�涨�ӿ�)
'---------------------------------------
Public Sub EmptyAllFields()
    Dim Con As Control
    For Each Con In Controls
        If TypeOf Con Is UFFlexGridCtl Then Con.Rows = 1
    Next Con
    
    m_sCode = ""
End Sub

Public Function CheckStd(SrvDB As Object, cinvcode As String) As Boolean
    Set m_SrvDB = SrvDB
    Dim strSql As String
    Dim i As Integer
    Dim Rs As New Recordset
    
    For i = 1 To Grid.Rows - 1
        strSql = "select top 1 * from Attachfile where cinvcode='" + cinvcode + "' and cfilename='" + Grid.TextMatrix(i, 2) + "'"
        Set Rs = SrvDB.OpenX(strSql)
        If Rs.RecordCount > 0 Then
            ShowMsg g_oPub.GetResString("U8.AA.Archive.common.invattachfile_string") '"��"
            CheckStd = False
            Exit Function
        End If
    Next i
    CheckStd = True
End Function

'-------------------------------------------
'���ܣ�����Ȩ��
'-------------------------------------------
Public Sub SetRW(RW As Integer)
    If RW = 0 Then '��Ȩ��
        CmdAddFile.Enabled = False
        CmdDeleteFile.Enabled = False
        CmdDownLoadFile.Enabled = False
        Dim i As Long
        For i = 1 To Grid.Rows - 1
            Grid.RowHeight(0) = 0
        Next i
    ElseIf RW = 1 Then 'ֻ��Ȩ��
        CmdAddFile.Enabled = False
        CmdDeleteFile.Enabled = False
    End If
End Sub

'��Ȩ������ʹ��
Public Property Get Enabled() As Boolean
    Enabled = True
End Property

Public Property Let Enabled(ByVal vNewValue As Boolean)
    
End Property

