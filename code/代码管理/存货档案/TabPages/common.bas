Attribute VB_Name = "common"
Option Explicit
Public Declare Sub OutputDebugString Lib "kernel32" Alias "OutputDebugStringA" (ByVal lpOutputString As String)

Public Cal As New CalendarAPP.ICaleCom '�������ڿؼ�����
Public g_oPub As Object
Public Const g_frameWidth = 11300 'Frame���
Public Const g_frameHeight = 6100 'Frame�߶�
Public Const g_frameWidthEn = 11300   'Frame���
Public Const g_frameHeightEn = 6100 'Frame�߶�
Public g_arr() As Variant '���ڴ�����Դ����
Public STypeItem() As String
Public DTypeItem() As String
Public DSTypeItem() As String

'Public boolItems() As String
'Public index As Integer

Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (lpvDest As Any, lpvSource As Any, ByVal cbCopy As Long)

Public Const CSIDL_INTERNET_CACHE As Long = &H20&
Public Declare Function SHGetPathFromIDList Lib "shell32.dll" Alias "SHGetPathFromIDListA" (ByVal pidl As Long, ByVal pszPath As String) As Long
Public Declare Function SHGetSpecialFolderLocation Lib "shell32.dll" (ByVal hwndOwner As Long, ByVal nFolder As Long, pidl As Long) As Long
Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long

'���ݲ���

'---------------------------------------
'���ܣ�������Ϣ�ӿ�
'������sMsg��������Ϣ
'---------------------------------------
Public Sub ShowMsg(ByVal sMsg As String)
    On Error Resume Next
    g_oPub.MsgBox sMsg, vbOKOnly + vbInformation, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.information")
End Sub


Public Sub Calendar(Con As Object, HwndObj As Object)
    On Error Resume Next
    Cal.Left = Con.Left
    Cal.Top = Con.Top + Con.Height + 100
    If Cal.Top + Cal.Height + 1000 > HwndObj.Height Then
        Cal.Top = Con.Top - Cal.Height
    End If
    Cal.DateDivideChar = "-"
    Con.Text = Cal.Calendar(HwndObj.hwnd)
End Sub

'---------------------------------------
'˵������û�нڵ㷵�ؿմ�
'ȡ��ָ�����Խڵ��ֵ
'������Ele xml �ڵ�
'      NodeName ��������
'���أ�����ֵ
'---------------------------------------
Public Function GetNodeText(ByVal ele As IXMLDOMElement, ByVal NodeName As String, Optional ByVal vDefault As String = "") As String
    If ele Is Nothing Or NodeName = "" Then
        GetNodeText = vDefault
        Exit Function
    End If
    NodeName = LCase(NodeName)
    Dim Nd As IXMLDOMNode
    Set Nd = ele.selectSingleNode(NodeName)
    If Nd Is Nothing Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.noxmlnode") '+NodeName'"û�нڵ�:"
        GetNodeText = vDefault
    Else
        GetNodeText = Nd.Text
    End If
End Function

'---------------------------------------------
'���ܣ�ͨ���ַ���������ֲ�������ֹ����ֵ����Xml�����ַ����硰<>���ȣ��ڲ�ѯ�������
'������ sParent��    ����
'       sPara:      ��������
'       vDefault:   Ĭ��ֵ
'---------------------------------------------
Public Function GetParaVal(ByVal sParent As String, ByVal sPara As String, Optional ByVal vDefault As String = "") As String
    On Error GoTo Err_Info
    If Len(sParent) = 0 Or Len(sPara) = 0 Then
        GetParaVal = vDefault
        Exit Function
    End If
    sPara = LCase(sPara)
    Dim Pos1 As Integer
    Dim Pos2 As Integer
    Dim sFlagA As String
    Dim sFlagB As String
    sFlagA = "<" + sPara + ">"
    sFlagB = "</" + sPara + ">"
    Pos1 = InStr(1, sParent, sFlagA)
    Pos2 = InStr(1, sParent, sFlagB)
    If Pos1 = 0 Or Pos2 = 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.noparam") + sPara '"û�д������:"
        GetParaVal = vDefault
    Else
        GetParaVal = Mid(sParent, Pos1 + Len(sFlagA), Pos2 - Pos1 - Len(sFlagA))
    End If
    Exit Function
Err_Info:
    ShowMsg Err.Description
End Function

'---------------------------------------
'����:ȡ��Element������ֵ
'ele Element  sAttr:������
'---------------------------------------
Public Function GetNodeAttrVal(ByVal ele As IXMLDOMElement, ByVal sAttr As String, Optional vDefault As Variant = "") As String
    Dim attr As IXMLDOMAttribute
    sAttr = LCase(sAttr)
    Set attr = ele.Attributes.getNamedItem(sAttr)
    If attr Is Nothing Then
        GetNodeAttrVal = vDefault
        Exit Function
    End If
    GetNodeAttrVal = Trim(attr.Text)
End Function

'---------------------------------------
'���ܣ����˱������ֶ�ֵ��ΪNull
'������var����Ҫ���˵ı���
'���أ���Ӧ�ı���
'---------------------------------------
Public Function TxtValue(var As Variant, Optional ByVal vDefault As Variant = "") As Variant
    On Error GoTo Err_Info
    TxtValue = IIf(IsNull(var), vDefault, var)
    Exit Function
Err_Info:
    TxtValue = vDefault
End Function

'---------------------------------------
'���ܣ���bool�͵�ֵת��Ϊ����
'������var������
'���أ���var��true������1�����򷵻�0
'---------------------------------------
Public Function ChkValue(var As Variant, Optional ByVal iDefault As Integer = 0) As Integer
    On Error GoTo Err_Info
    ChkValue = IIf(LCase(var) = True, 1, 0)
    Exit Function
Err_Info:
    ChkValue = IIf(iDefault = 1, iDefault, 0)
End Function

'---------------------------------------
'���ܣ���CheckBox,Edit���дXML
'������sXML:�ַ�������
'      Con:CheckBox,Edit��ؼ�
'---------------------------------------
Public Sub EleXML(ByRef sXml As String, sAttr As String, Con As Control)
    Dim sText As String
    'If (Con.Visible = True) Then '(Con.Enabled = True) And
        If TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then
            sText = CStr(Con.Value)
        ElseIf (Left(LCase(Con.name), 3) = "edt") Or (TypeOf Con Is UFCOMBOBOXLib.UFComboBox) Then ' Or (TypeOf Con Is MaskEdBox)
            sText = Con.Text
        Else
            ShowMsg Con.name + " can't get the Text"
        End If
        sXml = sXml + "<" + sAttr + ">" + sText + "</" + sAttr + ">"
    'End If
End Sub
'---------------------------------------
'���ܣ���CheckBox,Edit���дXML
'������sXML:�ַ�������
'      Con:CheckBox,Edit��ؼ�
'---------------------------------------
Public Sub EleXML2(ByRef sXml As Object, sAttr As String, Con As Control)
    Dim sText As String
    
    'If (Con.Visible = True) Then '(Con.Enabled = True) And
        If TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then
            sText = CStr(Con.Value)
        ElseIf (Left(LCase(Con.name), 3) = "edt") Or (TypeOf Con Is UFCOMBOBOXLib.UFComboBox) Then ' Or (TypeOf Con Is MaskEdBox)
            sText = Con.Text
        Else
            ShowMsg Con.name + " can't get the Text"
        End If
        Call sXml.Append("<" + sAttr + ">" + sText + "</" + sAttr + ">")
    'End If
End Sub
'---------------------------------------
'���ܣ��������ݼ�
'������rstTemp����Ҫ���˵����ݼ�
'     strFilter����������
'---------------------------------------
Public Function Filter(ByVal rstTemp As ADODB.Recordset, strFilter As String) As ADODB.Recordset
    rstTemp.Filter = strFilter
    Set Filter = rstTemp
End Function

'---------------------------------------
'���ܣ�Edt���յĸ�ֵ
'������Con:ָEdit �ؼ�
'      sCode������
'      sName������
'---------------------------------------
Public Sub SetRefEdtValue(ByRef Con As Control, ByVal sCode As String, ByVal sName As String)
    Con.Text = sName
    Con.Tag = sCode
    Con.UToolTipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + sCode
End Sub

'---------------------------------
'���ܣ�ɾ���ؼ����������Ϣ
'������Con����Ҫɾ����Ϣ�Ŀؼ�
'---------------------------------
Public Sub ClearAll(Con As Control)
    On Error Resume Next
    Con.Text = ""
    Con.Tag = ""
    Con.UToolTipText = ""
End Sub

''---------------------------------
''���ܣ�ɾ���ؼ���ز�����ʾ��Ϣ
''������Con����Ҫɾ����Ϣ�Ŀؼ�
''---------------------------------
'Public Sub ClearTip(Con As Control)
'    On Error Resume Next
'    Con.Tag = ""
'    Con.UToolTipText = ""
'End Sub

'------------------------------------------------
'���ܣ����ݼ�����λ�������д�������
'������     Srv��       �������ݿ����
'           ConGroup��  ��ؼ�
'           sGroupCode: �����
'------------------------------------------------
Public Sub WriteGroup(srv As Object, ConGroup As Object, sGroupCode As String)
    Dim Rs As ADODB.Recordset
    Dim strSql As String
    If Len(sGroupCode) > 0 Then
        strSql = "select top 1 * from ComputationGroup where cGroupCode='" + sGroupCode + "' "
        Set Rs = srv.OpenX(strSql)
        If Rs.RecordCount = 1 Then
            ConGroup.Text = TxtValue(Rs!cGroupName)
            ConGroup.Tag = sGroupCode
            ConGroup.UToolTipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + sGroupCode
        End If
    End If
End Sub

'------------------------------------------------
'���ܣ����ݼ�����λ������д�������
'������     Srv��       �������ݿ����
'           ConGroup��  ������λ�ؼ�
'           sGroupCode: ������λ����
'------------------------------------------------
Public Sub WriteUnit(srv As Object, ConUnit As Object, sUnitCode As String)
    Dim Rs As ADODB.Recordset
    Dim strSql As String
    If Len(sUnitCode) > 0 Then
        strSql = "select top 1 * from computationUnit where cComunitCode='" + sUnitCode + "'"
        Set Rs = srv.OpenX(strSql)
        If Rs.RecordCount = 1 Then
            ConUnit.Text = TxtValue(Rs!cComunitName)
            ConUnit.Tag = sUnitCode
            ConUnit.UToolTipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + sUnitCode
        End If
    End If
End Sub

'-------------------------------------------
'���ܣ���д�����Ϣ
'������ Srv��       �������ݿ����
'       Con:        ��Ҫ��д�Ŀؼ�
'       Rs��        ����Դ
'       TableName:  ����
'       fldCode��   �����ֶ���
'       fldName��   �����ֶ���
'-------------------------------------------
Public Sub WriteName(srv As Object, Con As Object, Rs As ADODB.Recordset, refFldCode As String, TableName As String, fldCode As String, fldName As String)
    Dim strSql As String
    Dim RsTemp As ADODB.Recordset
    Dim sCode As String
    sCode = TxtValue(Rs.fields(refFldCode).Value)
    If Len(sCode) > 0 Then
        strSql = "select top 1 " + fldCode + "," + fldName + " from " + TableName + " where " + fldCode + "='" + sCode + "'"
        Set RsTemp = srv.OpenX(strSql)
        If RsTemp.RecordCount = 1 Then
            Con.Text = CStr(TxtValue(RsTemp.fields(fldName).Value))
            Con.Tag = sCode
            Con.UToolTipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + sCode
        Else
            Call ClearAll(Con)
        End If
    Else
        Call ClearAll(Con)
    End If
End Sub

'---------------------------------------
'���ܣ���д����ʹ�ò��գ���ȴ�����뷽ʽ������������Ƿ�Ϸ���
'������sCode����Ӧ�Ĵ�������ֵ�����磺����
'      strSql :��ѯ�ַ���
'      con����Ӧ���յĿؼ�
'---------------------------------------
Public Function IfExist(srv As Object, oPub As Object, ByVal sCode As String, ByVal sName As String, strSql As String, ByRef Con As Control, Optional ByVal bmUnit As Boolean = False, Optional Rs As ADODB.Recordset) As Boolean
    Dim tRs As ADODB.Recordset
    On Error GoTo Err_Info
    Set tRs = srv.OpenX(strSql)
    Set Rs = tRs.Clone
    If Rs.RecordCount = 0 Then
        IfExist = False
        Con.Tag = ""
        Con.UToolTipText = ""
    Else
        If oPub.FindMatch(Rs, sCode, sName, Con.Text) = True Then
            IfExist = True
            Con.Text = TxtValue(Rs.fields(sName).Value)
            Con.Tag = TxtValue(Rs.fields(sCode).Value)
            Con.UToolTipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + TxtValue(Rs.fields(sCode).Value)
        End If
    End If
    Exit Function
Err_Info:
    ShowMsg Err.Description
End Function

'bRetOption  �Ƿ񷵻�Optional����
Public Function InitGrid(oPub As Object, Grid As Object, sXml As String, ArrFlds() As String, ArrAuthFlds() As String, sFlds As String, Optional bRetOption As Boolean = False, Optional EleAll As IXMLDOMElement, Optional EleStyle As IXMLDOMElement) As Boolean
   Call oPub.UtoLCase(sXml)
    Dim dom As New DOMDocument
    Dim ele As IXMLDOMElement
    Dim eleNd As IXMLDOMElement
    Dim i As Long
    Dim ColPoint As String
    Dim QryFld As String
    Dim DecDgtStyleXML As String
    Dim Width As String, sTemp As String
    If Not dom.loadXML(sXml) Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.xmlloaderror")  'XML���ش���
        Exit Function
    End If
    Set ele = dom.documentElement
    Grid.Rows = 1
    Grid.cols = ele.childNodes.length + 1
    ReDim ArrFlds(0 To ele.childNodes.length - 1)
    ReDim ArrAuthFlds(0 To ele.childNodes.length - 1)
    sFlds = ""
    With Grid
        For i = 0 To ele.childNodes.length - 1
            Set eleNd = ele.childNodes.Item(i)
            ArrFlds(i) = eleNd.NodeName
            QryFld = GetNodeAttrVal(eleNd, "QryFld")
            If Len(QryFld) > 0 Then
                sFlds = sFlds + QryFld + " as " + ArrFlds(i) + ","
            Else
                sFlds = sFlds + ArrFlds(i) + ","
            End If
            ArrAuthFlds(i) = GetNodeAttrVal(eleNd, "AuthFld")
            .TextMatrix(0, i) = GetNodeAttrVal(eleNd, "ChName")
            If bRetOption = True Then
                ColPoint = GetNodeAttrVal(eleNd, "ColPoint")
                If Len(ColPoint) > 0 Then
                    DecDgtStyleXML = DecDgtStyleXML + "<" + LCase(ArrFlds(i)) + ">" + ColPoint + "</" + LCase(ArrFlds(i)) + ">"
                End If
            End If
            
            Width = GetNodeAttrVal(eleNd, "Width")
            If Len(Width) = 0 Then
                Width = 1500
            End If
            
            .ColWidth(i) = CStr(Width)
            If Width = "0" Then
                .Col = i
                .CellForeColor = .CellBackColor
            End If
            
            '���ܶ�̬�ı��п�
            If GetNodeAttrVal(eleNd, "MustInput") = "1" Then
                .Col = i
                .CellForeColor = oPub.MustInputColor
            End If
            
            If Width = "0" Then
                .FixedAlignment(i) = 1 '��ֹMicrosoft Grid������ʾ
            Else
                .FixedAlignment(i) = 4
            End If
            
            
            .ColOpenStr(i) = GetNodeAttrVal(eleNd, "BadStrException")
            
            sTemp = GetNodeAttrVal(eleNd, "ColDataType")
            Select Case sTemp
                Case "1"
                    .ColDataType(i) = EditDbl
                    .ColTextWidth(i) = CInt(GetNodeAttrVal(eleNd, "ColTextWidth", "16"))
                    .ColPoint(i) = CInt(GetNodeAttrVal(eleNd, "ColPoint"))
                    .ColAlignment(i) = 7
                Case "2"
                    .ColDataType(i) = EditLng
                    .ColTextWidth(i) = CInt(GetNodeAttrVal(eleNd, "ColTextWidth", "16"))
                    .ColAlignment(i) = 7
                Case Else
                    Select Case GetNodeAttrVal(eleNd, "bRef")
                        Case "1"
                            .SetColProperty i, , UserBrowButton, EditNormal
                        Case "2"
                            .SetColProperty i, , BrowCom, EditNormal
                        Case Else
                            .SetColProperty i, , BrowNull, EditNormal
                    End Select
                    .ColTextWidth(i) = CInt(GetNodeAttrVal(eleNd, "ColTextWidth"))
                    .ColAlignment(i) = 1
            End Select
        Next i
        .TextMatrix(0, Grid.cols - 1) = "״̬"
        .ColWidth(Grid.cols - 1) = 0
'        .ColIsVisible(Grid.cols - 1) = False
    End With
    sFlds = Left(sFlds, Len(sFlds) - 1)
    If bRetOption = True Then
        Set EleAll = dom.documentElement
        If Len(DecDgtStyleXML) > 0 Then
            DecDgtStyleXML = "<decdgtstyle>" + DecDgtStyleXML + "</decdgtstyle>"
            Dim domStyle As New DOMDocument
            If domStyle.loadXML(DecDgtStyleXML) = False Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.xmlloaderror")  'XML���ش���
            Else
                Set EleStyle = domStyle.documentElement
            End If
            Set domStyle = Nothing
        End If
    End If
End Function

Public Property Get ObjectFromPtr(ByVal lPtr As Long) As Object
    On Error GoTo Err_Info
    Dim objT As Object
    If Not (lPtr = 0) Then
    'OutputDebugString "1.1.1.1"
      ' Turn the pointer into an illegal, uncounted interface
      CopyMemory objT, lPtr, 4
      ' Do NOT hit the End button here! You will crash!
      ' Assign to legal reference
      Set ObjectFromPtr = objT
      ' Still do NOT hit the End button here! You will still crash!
      ' Destroy the illegal reference
      CopyMemory objT, 0&, 4
      'OutputDebugString "1.1.1.2"
      'Set objT = Nothing
   End If
   Exit Sub
Err_Info:
   ShowMsg Err.Description
End Property


Public Function pbVerify(lPtr As Long, ByRef ctlThis As Object) As Boolean
   If Not (lPtr = 0) Then
      'OutputDebugString "1.1.1"
      Set ctlThis = ObjectFromPtr(lPtr)
      'OutputDebugString "1.1.2"
      pbVerify = True
      Exit Function
   End If
   pbVerify = False
End Function

Public Function GetFrmMain(lPtr As Long) As Object
    Dim ref As Object
    'OutputDebugString "1.1"
    If pbVerify(lPtr, ref) = False Then Exit Function
    'OutputDebugString "1.2"
    Set GetFrmMain = ref
End Function

'Public Function InitAcc() As Boolean
'    On Error GoTo Err_Info
'
'    If index = 0 Then
'        ReDim boolItems(0 To 1)
'        boolItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") '��̬
'        boolItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") '��̬
'    ElseIf index = 1 Then
'        ReDim boolItems(0 To 2)
'        boolItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0") '��
'        boolItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1") '��
'        boolItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2") '��
'    Else
'        ReDim boolItems(0 To 1)
'        boolItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") '��������
'        boolItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1") '�ٷֱ�
'    End If
'
'    InitAcc = True
'    Exit Function
'Err_Info:
'    ShowMsg Err.Description
'End Function
    
Public Function GetSpecialPath(hwnd As Long, CSIDL As Long) As String
    Dim lr As Long, pidl As Long
    Dim path As String
    
    lr = SHGetSpecialFolderLocation(hwnd, CSIDL, pidl)
    If lr = 0 Then
        path = Space(512)
        lr = SHGetPathFromIDList(ByVal pidl, ByVal path)
        GetSpecialPath = Left(path, InStr(path, Chr(0)) - 1)
        Exit Function
    End If
    GetSpecialPath = ""
End Function

Public Function CreateNode(ByVal parent As IXMLDOMNode, _
ByVal node_name As String, _
ByVal node_value As String) As IXMLDOMNode
Dim new_node As IXMLDOMNode
Set new_node = parent.ownerDocument.createElement(node_name)
new_node.Text = node_value
parent.appendChild new_node
Set CreateNode = new_node
End Function

Public Function CreateAttribute(ByRef node As IXMLDOMElement, _
name As String, _
Value As String) As Boolean
Dim attr As IXMLDOMAttribute
On Error GoTo err1
If node Is Nothing Or name = "" Then
    CreateAttribute = False
End If
Set attr = node.ownerDocument.CreateAttribute(name)
attr.Text = Value
Call node.Attributes.setNamedItem(attr)
CreateAttribute = True
Exit Function
err1:
CreateAttribute = False
End Function
Public Function GetAttributeValue(node As IXMLDOMNode, name As String) As String
'��ȡĳ��Node������ֵ
    Dim nod     As IXMLDOMNode
    Dim str     As String
    If node Is Nothing Then
        GetAttributeValue = ""
        Exit Function
    End If
    Set nod = node.selectSingleNode("@" + name)
    If nod Is Nothing Then
        str = ""
    Else
        str = nod.Text
    End If
    GetAttributeValue = str
End Function
'--------------------------------------------------------
'���ܣ�������(����)������ҵ��,����ɾ�������Ҳ����޸�������ֵ
'����
'������
'      PartID��
'       Opt��1�����ӣ�2���޸ģ�3��ɾ��
'--------------------------------------------------------
Public Function CheckRefBasPart(Icom As Object, PartId As String, opt As Integer, Optional ByRef reMsg As String = "") As Boolean
    CheckRefBasPart = False
    Dim PrmVal(1) As Variant
    Dim vRetVal As Variant
    Dim RetMsg As String
    Dim Msg As String
    PrmVal(0) = PartId
    If ExecPROC(Icom, "Usp_IsPartReferenced", PrmVal, vRetVal, 1) = False Then
        If CStr(vRetVal) <> "" Then
            Select Case opt
                Case 2:
                    reMsg = g_oPub.GetResString("U8.AA.SRVTRANS.COMMONFUN.941_1") 'U8.AA.SRVTRANS.COMMONFUN.941_1="���Ϸ�����ҵ��,�����޸�������ֵ��"
                Case 3:
                    reMsg = g_oPub.GetResString("U8.AA.SRVTRANS.COMMONFUN.943_1") 'U8.AA.SRVTRANS.COMMONFUN.943_1="���Ϸ�����ҵ��,����ɾ����"
                Case 4:
                    reMsg = g_oPub.GetResString("U8.AA.SRVTRANS.COMMONFUN.945_1") 'U8.AA.SRVTRANS.COMMONFUN.945_1="���Ϸ�����ҵ��,����ȡ���ṹ�������"
                Case Else
                    reMsg = g_oPub.GetResString("U8.AA.SRVTRANS.COMMONFUN.947_1") 'U8.AA.SRVTRANS.COMMONFUN.947_1="û���ṩ���ϴ���"
            End Select
        End If
        Exit Function
    End If
    If opt = 3 Then
        If Icom.CheckArchRefed(Icom.m_cnnstring, PartId, "bas_part", g_oPub.GetResString("U8.AA.ARCHIVE.bas_partarch"), RetMsg) = False Then '"���������"
        reMsg = RetMsg + g_oPub.GetResString("U8.AA.SRVTRANS.cannotdelete") ' "����ɾ����"
        Exit Function
        End If
    End If
    CheckRefBasPart = True
End Function


'------------------------------------------
'���ܣ�ProcName���洢��������,�ô洢���̵�����NT4.0������֧�ַ������Ĵ�
'������PrmVal���洢���̲�������
'       vRetVal�����ز�����Ϣ
'       iRetErr:���󷵻ر�־��0ΪĬ�ϴ��󷵻ر�־
'       ˵�������в�����1Ϊ���󷵻ر�־
'���أ�true������������false������ʧ��
'------------------------------------------
Public Function ExecPROC(SrvDB As Object, ByVal PROCName As String, PrmVal() As Variant, ByRef vRetVal As Variant, Optional ByVal iRetErr As Integer = 0) As Boolean
    ExecPROC = False
    Dim cn As New ADODB.Connection
    Dim cmd As New ADODB.Command
    Dim prmRet As New ADODB.Parameter
    Dim i As Integer
    Dim iInPrmCount As Integer '��Ҫ����Ĳ�������
    Dim sRetName As String '��������
    Dim Msg As String
    On Error GoTo Err_Info

    cn.ConnectionString = SrvDB.m_cnnstring
    If cn.State <> 1 Then
        cn.Open
    End If
    Set cmd.ActiveConnection = cn
    cmd.CommandText = PROCName
    cmd.CommandType = adCmdStoredProc
    cmd.CommandTimeout = 0
    iInPrmCount = 0
'    If cmd.Parameters.Count = 0 Then
'        Msg = "���ݿ�û�ж��� '" + PROCName + "' �洢���̣�" + vbCrLf + "���������ݿ⣡"
'        vRetVal = ""
'        Exit Function
'    End If
    For i = 0 To cmd.Parameters.Count - 1
        If cmd(i).Direction = adParamInput Then 'Or cmd(i).Direction = adParamInputOutput
            iInPrmCount = iInPrmCount + 1
        End If
    Next i

    If iInPrmCount <> UBound(PrmVal) Then
        ReDim g_arr(1 To 2)
        g_arr(1) = CStr(cmd.Parameters.Count - 1)
        g_arr(2) = CStr(UBound(PrmVal))
        Msg = g_oPub.GetResFormatString("U8.AA.SRVTRANS.CLSCOMMON.2860_1", g_arr) 'U8.AA.SRVTRANS.CLSCOMMON.2860_1="�����ṩ�洢����{0}��洢���̲���{1}��ƥ�䣡"
        vRetVal = ""
        Exit Function
    End If
    For i = 1 To iInPrmCount
        'parameter 0 contains a return value from the SQL Server stored procedure.
        cmd(i) = PrmVal(i - 1)
    Next i
    cmd.Execute

    If cmd(0) = iRetErr Then
        If cmd(cmd.Parameters.Count - 1).Direction <> adParamInput And cmd.Parameters.Count > 1 Then
            vRetVal = TxtValue(cmd(cmd.Parameters.Count - 1))
        End If
        Msg = g_oPub.GetResString("U8.AA.SRVTRANS.have_ref") 'U8.AA.SRVTRANS.have_ref="�������ã�" '������ɾ�� '�洢���̿��ܲ�����
        Exit Function '���ɹ�
    End If
    vRetVal = ""
    ExecPROC = True
    Set cn = Nothing
    Set cmd = Nothing
    
    Exit Function
Err_Info:
    Set cn = Nothing
    Set cmd = Nothing
    Msg = Err.Description
'    Call WriteErrorLog("IClsCommon", "ExecPROC", Err.Number, Err.Description)
End Function
