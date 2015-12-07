Attribute VB_Name = "Common"
Option Explicit

Public Declare Function PatBlt Lib "gdi32" (ByVal hdc As Long, ByVal X As Long, ByVal Y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal dwRop As Long) As Long
Public Const DSTINVERT = &H550009            ' (DWORD) dest = (NOT dest)
Public Const LimitLeft = 800                 'Split Bar��С��߾�
Public Const LimitRight = 1000               'Split Bar����ұ߾�

Public FrmMain As FrmInv
Public SrvDB As Object  '���ù������ݿ����������U8SrvTrans.IClsCommon
Public Cal As New ICaleCom  '�������ڿؼ�����
Public g_oPub As Object ' U8Pub.IPub '�������ģ��
Public g_oLogin As Object 'U8Login.clsLogin����
Public g_oClient As Object 'New U8FileManagerClient.U8FileManageClient

Public g_cUserId As String '�û�ID
Public g_cUserName As String '�û�����
Public g_UfDbName As String '���ݿ����Ӵ�
Public g_hWndParent As Long '���ھ��
Public g_bIsWeb As Boolean '�Ƿ�web����
Public g_bPage As Boolean '�Ƿ��ҳ
Public g_CurDate As String 'Login��½����
Public g_DbSrvDate As String '���ݿ�����
Public g_bShopSys As Boolean '����ϵͳ�Ƿ�����

Public g_ColSet As Object ' U8colsetsvr.clsColSetsvr'U8colset.clsColSet
Public g_cFormat As String '��Ŀ����XML�ַ���
Public g_cFlds As String '��Ҫ��ʾ�ĸ����ֶ������ַ�����
Dim m_sRefMatch As String '����ƥ����˴�

Public g_rowAuth As Object 'U8RowAuthsvr.clsRowAuth��¼��Ȩ��
Public g_colAuth As Object 'U8ColAuthsvr.clsColAuth��¼��Ȩ��

Public g_sRFldAuthInv As String 'ֻ��Ȩ���ֶ���
Public g_sNFldAuthInv As String '��Ȩ���ֶ���
Public g_bControlFldAuth As Boolean '�Ƿ�����ֶ�Ȩ��

Public g_sRowAuthInv As String '���Ȩ���ַ���
Public g_sRowAuthInvW As String '���дȨ���ַ���
Public g_sRowAuthVen As String '��Ӧ��Ȩ���ַ���
Public g_sRowAuthPos As String '��λ����Ȩ���ַ���
Public g_sRowAuthWare As String '�ֿ�Ȩ���ַ���
Public g_sRowAuthDept As String '���ŵ���Ȩ���ַ���
Public g_sRowAuthPerson As String 'ְԱ����Ȩ���ַ���

Public MAXPAGESIZE As Long    'ÿҳ����¼��'web:200;C/S:50000
Public Const MINPAGESIZE = 5 'ÿҳ��С��¼������������
Public MaxPageCount As Long '���ҳ��

Public g_bGSP As Boolean '�Ƿ�ΪGSP���ñ�־
Public g_bPP As Boolean '��������ƻ��Ƿ����ñ�־
Public g_bQM As Boolean '�����Ƿ����ñ�־
Public g_BShowMedicineTab As Boolean '�Ƿ���ʾҽҩҳǩ
Public g_BShowMedicineTab870 As Boolean '�Ƿ���ʾҽҩҳǩ870

Public CS1 As Boolean '�������д���
Public CS2 As Boolean '�������ι���
Public CS3 As Boolean '���ޱ����ڹ���
Public CS4 As Boolean '���޳��׼�����
Public CS5 As Boolean '���޸�������λ
Public g_AutoCreatecInvAddCode As Boolean '���á����������ݴ�����ƺ�������ĸ�Զ����ɡ�
Public g_bInvSysStart As Boolean '  ���δ����ʱ����������е��Ƿ���������⡢�Ƿ������������Ƿ����кŹ��������ã���Ӧ���û�
Public g_bSerialEnabled As Boolean '�Ƿ����кù����Ƿ�����

Public g_iPriceDecDgt As Integer '����С��λ��
Public g_iExchRateDecDgt As Integer '������С��λ��
Public g_iQuanDecDgt As Integer '�������С��λ
Public g_iNumDecDgt As Integer '����С��λ
Public g_iBillPriceDecDgt As Integer '��Ʊ����С��λ��
Public g_iRateDecDgt As Integer '˰��С��λ
Public g_iVolumeDecDgt As Integer '���С��λ
Public g_iWeightDecDgt As Integer '����С��λ

Public g_CInvDefine13Dec As Integer '�Զ�����13�����ݾ���
Public g_CInvDefine14Dec As Integer '�Զ�����14�����ݾ���
Public g_iExpTaxRateDefault As String '����˰��Ĭ��ֵ
Public g_iImpTaxRateDefault As String '����˰��Ĭ��ֵ
Public g_iTaxRateDefault As String '����˰��Ĭ��ֵ

'������%��ȡ��%��С��λ������Ϊ6λ��
'�������?��������?���������С��λ������Ϊ6λ?
Public Const g_iDecDgt6 = 6 '�̶�С��λ����λ��
Public g_arr() As Variant '���ڴ�����Դ����

Public g_bFactory As Boolean '�Ƿ�Ϊ��ҵ
Public g_bMedicine As Boolean '�Ƿ�Ϊҽҩ��ҵ

Public g_bSaved As Boolean '�Ƿ񱻱�����������棬��ˢ��
Public g_EleStyle As IXMLDOMElement '��ʽ��GridС��

Public Enum CallType
    enuCSCall = 0 'CS����
    enuWebCall = 1 'Web����
    enuAddCall = 2 'ֻ���ñ༭��Ƭ
    enuBrowse = 3 '������
    enuBrowseLog = 4 'ͨ����Ƭ���ɾ����־
End Enum

Public Enum CustomerVersions
    enuCommon = 0       'ͨ��
    enuRefFreeMulti = 1 '���ϵ������������ѡ
End Enum
Public g_cusVer As CustomerVersions

Public g_CallType As CallType '��������
Public g_URL As String
Dim Inventory_Sub_Flds As String 'Inventory_Sub��cInvCode���ֶ�
Public g_PermitAddInventory As Boolean      '�Ƿ��������Ӵ����������
Public g_PermitModifyInventory As Boolean   '�Ƿ������޸Ĵ����������


'=============================================================
'ģ��˽��
'
Dim m_sGrid As String '����ʹ�ã��б���ʾ�ַ���
Dim m_sClass As String '������ʾ��ѯ�ַ���
Dim m_sTableName As String '��ѯ�ı���
Dim m_bPage As Boolean '�Ƿ��ҳ
'=============================================================

'---------------------------------------
'���ܣ�������Ϣ�ӿ�
'������sMsg����Ҫ��ʾ����Ϣ
'---------------------------------------
Public Sub ShowMsg(ByVal sMsg As String)
    g_oPub.MsgBox sMsg, vbOKOnly + vbInformation, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.information")
End Sub


'-------------------------------------------
'���ܣ���ȡ���ף������ñ�����ֵ������ĳЩ��Ŀ�Ƿ�ɱ༭����ʽ��
'-------------------------------------------
Public Sub InitAccSet()
    Dim RsAcc As ADODB.Recordset '���ײ�����
    Dim sTemp As String
    CS1 = True
    Dim RsTemp As ADODB.Recordset
    Set RsAcc = SrvDB.OpenX("select * from AccInformation where cSysID='AA' or cSysID='ST'")
    '���¹�������ID���Բ���
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='27' and cName='bProxySell'")
    If RsTemp.RecordCount > 0 Then
        CS1 = IIf(UCase(RsTemp!cValue) = UCase("True"), True, False)
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='ST' and cID='111' and cName='bBatch'")
    If RsTemp.RecordCount > 0 Then
        CS2 = IIf(UCase(RsTemp!cValue) = UCase("True"), True, False)
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='ST' and cID='112' and cName='bQuality'")
    If RsTemp.RecordCount > 0 Then
        CS3 = IIf(UCase(RsTemp!cValue) = UCase("True"), True, False)
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='29' and cName='bAuxFitMgr'")
    If RsTemp.RecordCount > 0 Then
        CS4 = IIf(UCase(RsTemp!cValue) = UCase("True"), True, False)
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='22' and cName='bStrsAuxUnit'")
    If RsTemp.RecordCount > 0 Then
        CS5 = IIf(UCase(RsTemp!cValue) = UCase("True"), True, False)
    End If
    
    Set RsTemp = Filter(RsAcc, "cname='bEnableSNManage' and csysid='st'")
    If RsTemp.RecordCount > 0 Then
        g_bSerialEnabled = IIf(UCase(RsTemp!cValue) = UCase("True"), True, False)
    Else
        g_bSerialEnabled = False
    End If
    
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='20' and cName='iStrsPriDecDgt'")
    If RsTemp.RecordCount > 0 Then '����С��λ
        If IsNull(RsTemp!cValue) Then
            g_iPriceDecDgt = 2
        Else
            g_iPriceDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iPriceDecDgt = 2
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='43' and cName='iExchRateDecDgt'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iExchRateDecDgt = 2
        Else
            g_iExchRateDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iExchRateDecDgt = 2
    End If
                
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='19' and cName='iStrsQuanDecDgt'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iQuanDecDgt = 2
        Else
            g_iQuanDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iQuanDecDgt = 2
    End If

    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='42' and cName='iNumDecDgt'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iNumDecDgt = 2
        Else
            g_iNumDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iNumDecDgt = 2
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='21' and cName='iBillPrice'")
    If RsTemp.RecordCount > 0 Then '��ƱС��λ
        If IsNull(RsTemp!cValue) Then
            g_iBillPriceDecDgt = 2
        Else
            g_iBillPriceDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iBillPriceDecDgt = 2
    End If
    
    'g_iRateDecDgt ˰��С��λ
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cName='iRateDecDgt'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iRateDecDgt = 2
        Else
            g_iRateDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iRateDecDgt = 2
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cName='iVolumeDecDgt'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iVolumeDecDgt = 2
        Else
            g_iVolumeDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iVolumeDecDgt = 2
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cName='iWeightDecDgt'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iWeightDecDgt = 2
        Else
            g_iWeightDecDgt = Val(RsTemp!cValue)
        End If
    Else
        g_iWeightDecDgt = 2
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cID='35' and cName='cSysVersion'")
    If RsTemp.RecordCount > 0 Then
            If TxtValue(RsTemp!cValue) = "��ҵ" Then
                g_bFactory = True
            Else
                g_bFactory = False
            End If
    Else
        g_bFactory = True
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cName='iExpTaxRateDefault'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iExpTaxRateDefault = "0"
        Else
            g_iExpTaxRateDefault = RsTemp!cValue
        End If
    Else
        g_iExpTaxRateDefault = "0"
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cName='iImpTaxRateDefault'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iImpTaxRateDefault = "17"
        Else
            g_iImpTaxRateDefault = RsTemp!cValue
        End If
    Else
        g_iImpTaxRateDefault = "17"
    End If
    
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cName='iTaxRateDefault'")
    If RsTemp.RecordCount > 0 Then
        If IsNull(RsTemp!cValue) Then
            g_iTaxRateDefault = "17"
        Else
            g_iTaxRateDefault = RsTemp!cValue
        End If
    Else
        g_iTaxRateDefault = "17"
    End If
    
    g_AutoCreatecInvAddCode = False
    Set RsTemp = Filter(RsAcc, "cSysID='AA' and cName='AutoCreatecInvAddCode'")
    If RsTemp.RecordCount > 0 Then
        g_AutoCreatecInvAddCode = IIf(TxtValue(RsTemp.Fields("cValue").Value) = "1", True, False)
    End If
    
    
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    Dim tRs As ADODB.Recordset
    Dim i As Integer
    strSql = "select * from userdef where cClass='���'"
    Set Rs = SrvDB.OpenX(strSql)
    For i = 13 To 14
        Set tRs = Filter(Rs, "CItem='�Զ�����" + CStr(i) + "'")
        Select Case i
            Case 13
                g_CInvDefine13Dec = CInt(Val(TxtValue(tRs!iDecimalDigits)))
            Case 14
                g_CInvDefine14Dec = CInt(Val(TxtValue(tRs!iDecimalDigits)))
        End Select
    Next i
    
    Dim sXML As String
    Dim Dom As New DOMDocument
    sXML = "<Style>"
    sXML = sXML + "<iInvRCost>" + CStr(g_iPriceDecDgt) + "</iInvRCost>" '�ƻ��ۻ��ۼ�
    sXML = sXML + "<IInvSPrice>" + CStr(g_iPriceDecDgt) + "</IInvSPrice>" '�ο��ɱ�
    sXML = sXML + "<iInvNCost>" + CStr(g_iPriceDecDgt) + "</iInvNCost>" '���³ɱ�
    sXML = sXML + "<iInvMPCost>" + CStr(g_iPriceDecDgt) + "</iInvMPCost>" '��߽���iInvMPCost
    sXML = sXML + "<fExpensesExch>" + CStr(g_iDecDgt6) + "</fExpensesExch>"
    sXML = sXML + "<iInvSCost>" + CStr(g_iBillPriceDecDgt) + "</iInvSCost>" '�ο��ۼ�
    sXML = sXML + "<iInvLSCost>" + CStr(g_iBillPriceDecDgt) + "</iInvLSCost>" '����ۼ�
    sXML = sXML + "<iHighPrice>" + CStr(g_iPriceDecDgt) + "</iHighPrice>" '����ۼ�
    sXML = sXML + "<iExpSaleRate>" + CStr(4) + "</iExpSaleRate>" '���ۼӳ���
    sXML = sXML + "<iOfferRate>" + CStr(4) + "</iOfferRate>" '���۹�����
    sXML = sXML + "<fSubscribePoint>" + CStr(g_iQuanDecDgt) + "</fSubscribePoint>"
    sXML = sXML + "<fInExcess>" + CStr(g_iDecDgt6) + "</fInExcess>"
    sXML = sXML + "<fOutExcess>" + CStr(g_iDecDgt6) + "</fOutExcess>"
    sXML = sXML + "<fBuyExcess>" + CStr(g_iDecDgt6) + "</fBuyExcess>"
    sXML = sXML + "<fPrjMatLimit>" + CStr(g_iDecDgt6) + "</fPrjMatLimit>"
    sXML = sXML + "<iWastage>" + CStr(g_iDecDgt6) + "</iWastage>"
    sXML = sXML + "<fVagQuantity>" + CStr(g_iQuanDecDgt) + "</fVagQuantity>"
    sXML = sXML + "<iOverStock>" + CStr(g_iQuanDecDgt) + "</iOverStock>"
    sXML = sXML + "<iVolume>" + CStr(g_iVolumeDecDgt) + "</iVolume>"
    sXML = sXML + "<iInvBatch>" + CStr(g_iQuanDecDgt) + "</iInvBatch>"
    sXML = sXML + "<ILowSum>" + CStr(g_iQuanDecDgt) + "</ILowSum>"
    sXML = sXML + "<ISafeNum>" + CStr(g_iQuanDecDgt) + "</ISafeNum>"
    sXML = sXML + "<ITopSum>" + CStr(g_iQuanDecDgt) + "</ITopSum>"
    sXML = sXML + "<iDrawBatch>" + CStr(g_iQuanDecDgt) + "</iDrawBatch>"
    sXML = sXML + "<fInvCIQExch>" + CStr(g_iQuanDecDgt) + "</fInvCIQExch>"
    sXML = sXML + "<iTaxRate>" + CStr(g_iRateDecDgt) + "</iTaxRate>"
    sXML = sXML + "<iInvWeight>" + CStr(g_iWeightDecDgt) + "</iInvWeight>"
    sXML = sXML + "<fGrossW>" + CStr(g_iWeightDecDgt) + "</fGrossW>"
    sXML = sXML + "<fLength>" + CStr(g_iVolumeDecDgt) + "</fLength>"
    sXML = sXML + "<fWidth>" + CStr(g_iVolumeDecDgt) + "</fWidth>"
    sXML = sXML + "<fHeight>" + CStr(g_iVolumeDecDgt) + "</fHeight>"
    sXML = sXML + "<CInvDefine13>" + CStr(g_CInvDefine13Dec) + "</CInvDefine13>"
    sXML = sXML + "<CInvDefine14>" + CStr(g_CInvDefine14Dec) + "</CInvDefine14>"
    sXML = sXML + "<fExpPrice>" + CStr(g_iPriceDecDgt) + "</fExpPrice>"
    sXML = sXML + "<fFixedBatch>" + CStr(g_iQuanDecDgt) + "</fFixedBatch>"
    sXML = sXML + "<fBatchIncrement>" + CStr(g_iQuanDecDgt) + "</fBatchIncrement>"
    sXML = sXML + "<fMinOrder>" + CStr(g_iQuanDecDgt) + "</fMinOrder>"
    sXML = sXML + "<fMaxOrder>" + CStr(g_iQuanDecDgt) + "</fMaxOrder>"
    sXML = sXML + "<fDTRate>" + CStr(g_iDecDgt6) + "</fDTRate>"
    sXML = sXML + "<fDTNum>" + CStr(g_iQuanDecDgt) + "</fDTNum>"
        
    sXML = sXML + "<fOrderUpLimit>" + CStr(g_iDecDgt6) + "</fOrderUpLimit>"
    sXML = sXML + "<fRetailPrice>" + CStr(g_iQuanDecDgt) + "</fRetailPrice>"
    sXML = sXML + "<fAlterBaseNum>" + CStr(g_iQuanDecDgt) + "</fAlterBaseNum>"
    sXML = sXML + "<fSupplyMulti>" + CStr(g_iQuanDecDgt) + "</fSupplyMulti>"
    sXML = sXML + "<fMinSupply>" + CStr(g_iQuanDecDgt) + "</fMinSupply>"
    sXML = sXML + "</Style>"
    Call g_oPub.UtoLCase(sXML)
    If Dom.loadXML(sXML) = False Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.xmlloaderror") '
    Else
        Set g_EleStyle = Dom.documentElement
    End If
    Dim cAccId As String
    Dim Pos As Integer
    Dim sFlag As String
    sFlag = LCase("CATALOG=UFDATA_")
    Pos = InStr(1, LCase(g_UfDbName), sFlag)
    cAccId = Mid(g_UfDbName, Pos + Len(sFlag), 3)
    sXML = "<Inventory Operating ='SystemStart'>"
    sXML = sXML + "<cAcc_Id>" + cAccId + "</cAcc_Id>"
    'sXml = sXml + "</Inventory>"
    g_bInvSysStart = SrvDB.Modify(sXML + "<use>st</use>" + "</Inventory>", "Inventory", "")
    g_bGSP = SrvDB.Modify(sXML + "<use>gs</use>" + "</Inventory>", "Inventory", "")
    'g_bPP = g_oPub.GetSysStart("pp", g_UfDbName, SrvDB)
    g_bPP = g_oPub.GetSysStart("st", g_UfDbName, SrvDB) '���
    If g_bPP = False Then
        g_bPP = g_oPub.GetSysStart("BO", g_UfDbName, SrvDB) '�����嵥:
    End If
    If g_bPP = False Then
        g_bPP = g_oPub.GetSysStart("MP", g_UfDbName, SrvDB) '�������ƻ�:MP
    End If
    If g_bPP = False Then
        g_bPP = g_oPub.GetSysStart("MQ", g_UfDbName, SrvDB) '����滮:MQ
    End If
    If g_bPP = False Then
        g_bPP = g_oPub.GetSysStart("MO", g_UfDbName, SrvDB) '��������:MO
    End If
    If g_bPP = False Then
        g_bPP = g_oPub.GetSysStart("FC", g_UfDbName, SrvDB) '�������:FC
    End If
    If g_bPP = False Then
        g_bPP = g_oPub.GetSysStart("CP", g_UfDbName, SrvDB) '���ܹ���:CP
    End If
    If g_bPP = False Then
        g_bPP = g_oPub.GetSysStart("EC", g_UfDbName, SrvDB) '���̱��:EC
    End If
    
    Dim cEntType As String
    Dim cTradeKind As String
    
    g_bQM = g_oPub.GetSysStart("qm", g_UfDbName, SrvDB)
    Set RsAcc = SrvDB.OpenX("select top 1 cEntType,cTradeKind from UFSystem..ua_account where cAcc_Id='" + cAccId + "'")
    g_bMedicine = False
    If RsAcc.RecordCount = 1 Then
        cEntType = TxtValue(RsAcc!cEntType)
        cTradeKind = TxtValue(RsAcc!cTradeKind)
        If cTradeKind = "ҽԺ" Or cTradeKind = "ҽҩ" Then
            g_bMedicine = True
        End If
        
        
    End If
    
    If cEntType = "ҽҩ��ͨ" Or cTradeKind = "ҽҩ" Or cTradeKind = "ҽԺ" Or g_bGSP = True Then
        g_BShowMedicineTab870 = True
    Else
        g_BShowMedicineTab870 = False
    End If
    
    '���δ����GSP����������ϵͳ����"�Ƿ��ʼ�"ѡ���ûң��������GSP����������ϵͳ������"�Ƿ��ʼ�"Ϊ��ʱ����"GSP"ҳǩ��"����"ҳǩ�ûң�"����"ҳǩ��������Ϊ�գ�
    If g_bGSP = False And g_bQM = False Then
        g_BShowMedicineTab = False
    Else
        g_BShowMedicineTab = True
    End If
    
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


'--------------------------------------------------
'���ܣ���ò�ѯ���Ӵ�
'������cFlds����ѯ��ʾ�ֶ����ַ���
'--------------------------------------------------
Public Function GetJoinStr(ByVal cFlds As String) As String
    Dim strJoin As String
    Dim cFlds_Lcase As String
    cFlds_Lcase = LCase(cFlds)
    strJoin = ""
    
    If InStr(1, cFlds_Lcase, LCase("InventoryClass.cInvCName")) <> 0 Then
        strJoin = strJoin + " Left Join InventoryClass on Inventory.cInvCCode=InventoryClass.cInvCCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cciqname")) <> 0 Or InStr(1, cFlds_Lcase, LCase("cciqcode")) <> 0 Then
        strJoin = strJoin + " Left Join ex_ciqarchive  on Inventory.cciqcode=ex_ciqarchive.cciqcode "
    End If
    If InStr(1, cFlds_Lcase, LCase("Vendor.cVenName")) <> 0 Then
        strJoin = strJoin + " Left Join Vendor on Inventory.cVenCode=Vendor.cVenCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("Position.cPosName")) <> 0 Then
        strJoin = strJoin + " Left Join Position on Inventory.cPosition=Position.cPosCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("computationGroup.cGroupName")) <> 0 Then
        strJoin = strJoin + " Left Join computationGroup on Inventory.cGroupcode=computationGroup.cGroupCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cComUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join  ComputationUnit on Inventory.cComUnitCode=ComputationUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cPUComUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit as PUUnit on Inventory.cPUComUnitcode=PUUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cSAComUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit  as SAUnit on Inventory.cSAComUnitCode=SAUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cSTComUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit as STUnit on Inventory.cSTComUnitCode=STUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cCAComUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit as CAUnit on Inventory.cCAComUnitCode=CAUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("Warehouse.cWhName")) <> 0 Then
        strJoin = strJoin + " Left Join Warehouse on Inventory.cDefWareHouse=Warehouse.cWhCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cDTUnitName")) <> 0 Then
        strJoin = strJoin + " Left join ComputationUnit as DTUnitAliasTable on  Inventory.cDTUnit=DTUnitAliasTable.cComUnitCode "  '������ص�����
    End If
    If InStr(1, cFlds_Lcase, LCase("cWGroupName")) <> 0 Then
        strJoin = strJoin + " Left join ComputationGroup as WGroup on  Inventory.cWGroupCode=WGroup.cGroupCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cVGroupName")) <> 0 Then
        strJoin = strJoin + " Left join ComputationGroup as VGroup on  Inventory.cVGroupCode=VGroup.cGroupCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cVUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit as VUnit on Inventory.cVUnit=VUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cWUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit as WUnit on Inventory.cWUnit=WUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cProductUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit as ProductUnit on Inventory.cProductUnit=ProductUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cShopUnitName")) <> 0 Then
        strJoin = strJoin + " Left Join ComputationUnit as ShopUnit on Inventory.cShopUnit=ShopUnit.cComUnitCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cPersonName")) <> 0 Then
        strJoin = strJoin + " Left Join Person   on Inventory.cInvPersonCode=Person.cPersonCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cPurPersonName")) <> 0 Then
        strJoin = strJoin + " Left Join Person  as PurPerson on Inventory.cPurPersonCode=PurPerson.cPersonCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("cDepName")) <> 0 Then
        strJoin = strJoin + " Left Join department   on Inventory.cInvDepCode=department.cDepCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("TFCode")) <> 0 Or InStr(1, cFlds_Lcase, LCase("mps_timefence.Description")) <> 0 Then
        strJoin = strJoin + " Left Join mps_timefence  on Inventory.iInvTfId=mps_timefence.TfId  "
    End If
    If InStr(1, cFlds_Lcase, LCase("cProjectCode")) <> 0 Or InStr(1, cFlds_Lcase, LCase("cProjectName")) <> 0 Then
        strJoin = strJoin + " Left join qmCheckProject on  Inventory.iQTMethod=qmCheckProject.Id "  '������ص�����
    End If
    If InStr(1, cFlds_Lcase, LCase("cACCode")) <> 0 Or InStr(1, cFlds_Lcase, LCase("cACName")) <> 0 Then
        strJoin = strJoin + " left join AA_AuthClass on Inventory.iid=AA_AuthClass.id "  '����Ȩ����
    End If
    If InStr(1, cFlds_Lcase, LCase("cProjectExplain")) <> 0 Then
        strJoin = strJoin + " Left Join ATP_ProjectMain on Inventory.cInvProjectCode=ATP_ProjectMain.cProjectCode "
    End If
    If InStr(1, cFlds_Lcase, LCase("ATPCode")) <> 0 Or InStr(1, cFlds_Lcase, LCase("v_mps_atp_Description")) <> 0 Then
        strJoin = strJoin + " Left Join v_mps_atp  on Inventory.iInvATPId=v_mps_atp.ATPId  "
    End If
    If InStr(1, cFlds_Lcase, LCase("QMRANDORCHECK.cRuleName")) <> 0 Then
        strJoin = strJoin + " Left Join QMRANDORCHECK  on Inventory.cRuleCode=QMRANDORCHECK.cRuleCode "
    End If
    
    'strJoin = strJoin + GetJoinInventory(cFlds_Lcase)
    strJoin = strJoin + " Left Join Inventory_Sub on Inventory.cInvCode=Inventory_Sub.cInvSubCode "
    GetJoinStr = strJoin
End Function

'-----------------------------------------------------------
'���ܣ����Inventory_Sub�����Ӵ�
'-----------------------------------------------------------
Private Function GetJoinInventory(cFlds_Lcase As String) As String
    'Exit Function ' ����ʽ���󣬷ſ�����(���������ֶ�����ͬ���´���)
    Dim i As Integer
    Call SetInventorySubFld
    Dim arr() As String
    Dim strJoin As String
    arr = Split(Inventory_Sub_Flds, ",")
    For i = 0 To UBound(arr) - 1 'ȥ�����һ������
        If InStr(1, cFlds_Lcase, arr(i)) <> 0 Then
            strJoin = " Left Join Inventory_Sub on Inventory.cInvCode=Inventory_Sub.cInvSubCode "
            Exit For
        End If
    Next i
    GetJoinInventory = strJoin
End Function

Public Sub SetInventorySubFld()
    Dim i As Integer
    If Len(Inventory_Sub_Flds) > 0 Then
    Else
        Dim Rs As ADODB.Recordset
        Set Rs = SrvDB.OpenX("select top 0 * from Inventory_Sub")
        For i = 1 To Rs.Fields.count - 1 'ȥ��cInvCode�ֶ�
            Inventory_Sub_Flds = Inventory_Sub_Flds + LCase(Rs.Fields(i).Name) + ","
        Next i
    End If
End Sub


'---------------------------------------------------
'���ܣ�ȡ�ò������ݣ���Ҫ�Ǳ�������ƣ�
'������strClass:�����ַ���
'      strGrid���б��ַ���
'      sCode :���ձ���
'      sName:��������
'      TableName:�б����
'---------------------------------------------------
Public Sub showRef(ByVal strClass As String, ByVal strGrid As String, ByRef sCode As String, Optional ByRef sName As String = "", Optional ByVal tableName As String = "", Optional RsColset As ADODB.Recordset, Optional bPage As Boolean = False, Optional ByVal cOrder As String, Optional ByRef bReturn As Boolean = True, Optional ByRef sId As String = "", Optional ByRef reRst As ADODB.Recordset)
    Dim strSql As String
    Dim Ref As New UFReferC.UFReferClient  'Object
    Set Ref = FrmMain.RefClient
    Dim RsClass As ADODB.Recordset
    Dim RsGrid As ADODB.Recordset
    Dim Rst As ADODB.Recordset
    On Error GoTo Err_Info
    bReturn = True
    m_sGrid = strGrid
    m_sClass = strClass
    m_sTableName = tableName
    m_bPage = bPage
    Dim lMaxPageCount As Long
    Dim lPageSize As Long
    Dim lCurPage As Long
    Dim sMsg As String
    Dim bFlag As Boolean
    lPageSize = CLng(Val(FrmMain.EdtPageSize))
    lCurPage = 1
    strGrid = strGrid + cOrder
    If bPage = True Then
        Call FrmMain.m_cls.OpenPage(strGrid, lPageSize, lCurPage, lMaxPageCount, RsGrid, sMsg, bFlag, False)
    Else
        Set RsGrid = SrvDB.OpenX(strGrid)
    End If
    If Trim(strClass) <> "" Then
        Set RsClass = SrvDB.OpenX(strClass)
        If FrmMain.RefClient.RstRefInit(g_bIsWeb, bPage, tableName, 2, False, lPageSize, lMaxPageCount, lCurPage, RsGrid, RsColset, RsClass) = False Then
            Call SetNullString(sCode, sName, sId)
            Exit Sub
        End If
    Else
        Dim bMulti As Boolean
        If LCase(tableName) = "userdeffree" And g_cusVer = CustomerVersions.enuRefFreeMulti Then 'ר�� ���Ͻṹ���������ѡ2005-11-28
            bMulti = True
        Else
            bMulti = False
        End If
        If FrmMain.RefClient.RstRefInit(g_bIsWeb, bPage, tableName, 1, bMulti, lPageSize, lMaxPageCount, lCurPage, RsGrid, RsColset, RsClass) = False Then
            Call SetNullString(sCode, sName, sId)
            Exit Sub
        End If
    End If


    FrmMain.RefClient.Show
    Set Rst = FrmMain.RefClient.recmx
    If Rst Is Nothing Then
        Set reRst = Nothing
    Else
        Set reRst = Rst.Clone
        reRst.Filter = Rst.Filter
    End If
    If (Rst Is Nothing) Then
        Call SetNullString(sCode, sName, sId)
        bReturn = False
    Else
        If Rst.RecordCount = 0 Then
            Call SetNullString(sCode, sName, sId)
        Else
            If LCase(tableName) = "userdeffree" And g_cusVer = CustomerVersions.enuRefFreeMulti Then  'ר�� ���Ͻṹ���������ѡ2005-11-28
                Dim var As String
                Dim i As Long
                For i = 0 To Rst.RecordCount - 2
                    var = var + TxtValue(Rst.Fields(sCode).Value) + vbTab
                    Rst.MoveNext
                Next i
                sCode = var + TxtValue(Rst.Fields(sCode).Value)
            ElseIf sCode <> "" Then
                sCode = TxtValue(Rst.Fields(sCode).Value)
            End If
            If sName <> "" Then
                sName = TxtValue(Rst.Fields(sName).Value)
            End If
            If sId <> "" Then
                sId = CStr(TxtValue(Rst.Fields(sId).Value))
            End If
        End If
    End If
    Exit Sub
Err_Info:
    Call SetNullString(sCode, sName, sId)
    Debug.Print "common_showRef_Error!"
End Sub

'-----------------------------------------
'���ܣ������ÿ�
'-----------------------------------------
Private Sub SetNullString(ByRef sCode As String, ByRef sName As String, ByRef sId As String)
    sCode = ""
    sName = ""
    sId = ""
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
Public Sub ReplyRefEvent(ByVal strTablename As String, ByVal lPageSize As Long, ByVal lPageCount As Long, ByVal lCurPage As Long, ByVal strFilter As String, ByVal strMatch As String, ByVal strOrder As String)
    Dim RsRef As New ADODB.Recordset
    Dim RsClass As New ADODB.Recordset
    Dim RsColset As New ADODB.Recordset
    Dim strSql As String
    Dim iMode As Integer
    Dim cOrder As String, cFlds As String
    Call GetColSetStr(m_sTableName + "Ref", "", cFlds, cOrder, RsColset)
    Call getGridFld(m_sGrid, cFlds)
    Call g_oPub.ReCreateSQL(SrvDB, strTablename, m_sGrid, m_sRefMatch)
    If m_bPage = True Then
        Call FrmMain.m_cls.OpenPage(m_sGrid + cOrder, lPageSize, lCurPage, lPageCount, RsRef, "", True, True)
    Else
        Set RsRef = SrvDB.OpenX(m_sGrid + cOrder)
    End If
    iMode = IIf(m_sClass <> "", 2, 1)
    If m_sClass <> "" Then
        Set RsClass = SrvDB.OpenX(m_sClass)
    Else
        Set RsClass = Nothing
    End If
    Call FrmMain.RefClient.RstRefInit(g_bIsWeb, m_bPage, m_sTableName, 1, False, lPageSize, lPageCount, lCurPage, RsRef, RsColset, RsClass)
End Sub

'------------------------------------------
'���ܣ����¹������Grid��ѯ���
'������m_sGrid:Grid��ѯ��
'       cFlds����ѯ�ֶ���
'------------------------------------------
Private Sub getGridFld(ByRef m_sGrid As String, ByVal cFlds As String)
    Dim Pos As Long
    m_sGrid = Trim(m_sGrid)
    Pos = InStr(1, LCase(m_sGrid), " from")
    If Pos <> 0 Then
        m_sGrid = "Select " + cFlds + Right(m_sGrid, Len(m_sGrid) - Pos + 1)
    End If
End Sub

'---------------------------------------
'���ܣ����˿��ַ���
'������Var�����˱���
'---------------------------------------
Public Function TxtValue(var As Variant, Optional vDefault As Variant = "") As Variant
    On Error GoTo Err_Info
    TxtValue = IIf(IsNull(var), vDefault, var)
    Exit Function
Err_Info:
    TxtValue = vDefault
End Function



''---------------------------------------
''���ܣ���ȡ����
''������RefName��ѡ��������ƣ���ȡ���յ��ֶ����ƣ�
''     sCode:�����ֶΣ�һ��Ϊ����
''     sName�������ֶΣ�һ��Ϊ����
''---------------------------------------
'Public Sub GetRef(ByVal RefName As String, ByRef sCode As String, ByRef sName As String, bReturn As Boolean, ByVal Con As Control, ByVal Frm As Object, Optional ByRef sId As String = "", Optional reRst As ADODB.Recordset = Nothing)
'    Dim strClass As String, strGrid As String
'    Dim RsColset As New ADODB.Recordset
'    Dim cFormat As String, cFlds As String, cOrder As String
'    Dim bPage As Boolean
'    bPage = g_bIsWeb '����C/S���ղ��ٷ�ҳ
'    m_sRefMatch = ""
'    Select Case LCase(RefName)
'        Case LCase("cInvCode"), LCase("cInvName"), LCase("cInvPlanCode") '������롢����
'            sCode = "cInvCode"
'            sName = "cInvName"
'            Call GetColSetStr("InventoryRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStrNew(Con, SrvDB, m_sRefMatch, "Inventory") '"cInvCode,cInvName,cInvAddCode"
'            strClass = "select cInvCCode,cInvCName,cEcoCode from InventoryClass   order by cInvCCode asc"
'            strGrid = "Select  " + cFlds + "  from Inventory  where " + g_sRowAuthInv + " and " + m_sRefMatch + " and " + g_oPub.GetEndDateFilter("inventory", g_CurDate)
'            If LCase(RefName) = LCase("cInvPlanCode") Then
'                strGrid = strGrid + " and bPlanInv=1 and bForeExpland=0 "
'            End If
'            showRef strClass, strGrid, sCode, sName, "Inventory", RsColset, bPage, cOrder, bReturn, , reRst
'        Case LCase("cVenCode"), LCase("Inventory.cVenCode")          '��Ҫ������λ'��Ӧ�̱��������
'            sCode = "CVenCode"
'            sName = "CVenName"
'            Call GetColSetStr("VendorRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStrNew(Con, SrvDB, m_sRefMatch, "Vendor") '"CVenCode,CVenName,cVenAbbName"
'            strClass = "select CVCCode,CVCName from VendorClass Order by cVCCode ASC "
'            strGrid = "select " + cFlds + " from Vendor where " + g_sRowAuthVen + " and " + m_sRefMatch + " and " + g_oPub.GetEndDateFilter("vendor", g_CurDate)
'            showRef strClass, strGrid, sCode, sName, "Vendor", RsColset, bPage, cOrder, bReturn, , reRst
'        Case LCase("CEnterprise"), LCase("Inventory.CEnterprise") '������ҵ���ƺ͵�ַ
'            sCode = "CVenName"
'            sName = "CVenAddress"
'            Call GetColSetStr("VendorRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStrNew(Con, SrvDB, m_sRefMatch, "Vendor") '"CVenCode,CVenName,cVenAbbName,CVenAddress"
'            '1.  ��������ҵ�в��չ�Ӧ������ʱ�����Խ���Ӧ�̵ĵ�ַ��Ϣ�Զ������ڸ���Ŀ��
'            strClass = "select CVCCode,CVCName from VendorClass Order by cVCCode ASC"
'            strGrid = "select " + cFlds + " from Vendor where " + g_sRowAuthVen + " and " + m_sRefMatch + " and " + g_oPub.GetEndDateFilter("vendor", g_CurDate)
'            showRef strClass, strGrid, sCode, sName, "Vendor", RsColset, bPage, cOrder, bReturn, , reRst
'        Case LCase("cInvCCode"), LCase("Inventory.cInvCCode") '����������"''
'            sCode = "cInvCCode"
'            sName = "cInvCName"
'            Call GetColSetStr("InventoryClassRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "cInvCCode,cInvCName", m_sRefMatch, "InventoryClass")
'            strGrid = "select " + cFlds + " from InventoryClass where  bInvCEnd=1 " + " and " + m_sRefMatch
'            showRef "", strGrid, sCode, sName, "InventoryClass", RsColset, False, cOrder, bReturn, , reRst
'        Case LCase("cDCCode"), LCase("Inventory.cDCCode")  'Varchar    12          ����������
'            sCode = "cDCCode"
'            sName = "cDCName"
'            Call GetColSetStr("DistrictClassRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "cDCCode,cDCName", m_sRefMatch, "DistrictClass")
'            strGrid = "select " + cFlds + " from DistrictClass where bDCEnd=1 " + " and " + m_sRefMatch 'Order by cDCCode ASC"
'            showRef "", strGrid, sCode, sName, "DistrictClass", RsColset, False, cOrder, bReturn, , reRst
'        Case LCase("cDefWareHouse"), LCase("Inventory.cDefWareHouse") 'Ĭ�ϲֿ�
'            sCode = "CWhCode"
'            sName = "CWhName"
'            Call GetColSetStr("WarehouseRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "CWhCode,CWhName", m_sRefMatch, "Warehouse")
'            strGrid = "select " + cFlds + " from Warehouse where " + g_sRowAuthWare + " and " + m_sRefMatch '" Order by cWhCode  ASC"
'            showRef "", strGrid, sCode, sName, "Warehouse", RsColset, False, cOrder, bReturn, , reRst
'        Case LCase("cPosition"), LCase("Inventory.cPosition") '��λ
'            sCode = "cPosCode"
'            sName = "cPosName"
'            Call GetColSetStr("PositionRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "cPosCode,cPosName", m_sRefMatch, "Position")
'            strGrid = "select " + cFlds + " from Position where bPosEnd=1 and " + g_sRowAuthPos + " and " + m_sRefMatch '" order by cPosCode asc"
'            showRef "", strGrid, sCode, sName, "Position", RsColset, False, cOrder, bReturn, , reRst
'        Case LCase("cInvDepCode"), LCase("Inventory.cInvDepCode") '����
'            sCode = "cDepCode"
'            sName = "cDepName"
'            Call GetColSetStr("DepartmentRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "cDepCode,cDepName", m_sRefMatch, "Department")
'            strGrid = "select " + cFlds + " from Department where bDepEnd=1 and " + g_sRowAuthDept + " and " + m_sRefMatch
'            showRef "", strGrid, sCode, sName, "Department", RsColset, False, cOrder, bReturn, , reRst
'        Case "person", LCase("cInvPersonCode"), LCase("Inventory.cInvPersonCode"), LCase("cInvPersonCode"), LCase("cPurPersonCode"), LCase("Inventory.cInvPersonCode"), LCase("Inventory.cPurPersonCode") '         ר��ҵ��Ա
'            sCode = "CPersonCode"
'            sName = "CPersonName"
'            Call GetColSetStr("PersonRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "Person.CPersonCode,Person.CPersonName", m_sRefMatch, "Person")
'            strClass = "select cDepCode,cDepName from department where " & _
'                g_sRowAuthDept & " order by cDepCode ASC"
'            strGrid = "select " + cFlds + "  from Person left join Department on Department.cDepCode =Person.cDepCode where " + g_sRowAuthPerson + " and " + m_sRefMatch '+ " Order by cPersonCode ASC "
'            showRef strClass, strGrid, sCode, sName, "Person", RsColset, False, cOrder, bReturn, , reRst
'
'        Case LCase("cGroupCode"), LCase("Inventory.cGroupCode"), LCase("cWGroupCode"), LCase("cVGroupCode"), LCase("Inventory.cWGroupCode"), LCase("Inventory.cVGroupCode")
'            sCode = "cGroupCode"
'            sName = "cGroupName"
'            Call GetColSetStr("ComputationGroupRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "cGroupCode,cGroupName", m_sRefMatch, "ComputationGroup")
'            strGrid = "select " + cFlds + " from ComputationGroup" + " where " + m_sRefMatch
'            showRef "", strGrid, sCode, sName, "ComputationGroup", RsColset, False, cOrder, bReturn, , reRst
'        Case LCase("cInvDefine1"), LCase("cInvDefine2"), LCase("cInvDefine3"), LCase("cInvDefine4"), LCase("cInvDefine5"), LCase("cInvDefine6"), LCase("cInvDefine7"), _
'            LCase("cInvDefine8"), LCase("cInvDefine9"), LCase("cInvDefine10"), LCase("cInvDefine11"), LCase("cInvDefine12"), LCase("cInvDefine13"), LCase("cInvDefine14") _
'            , LCase("cInvDefine15"), LCase("cInvDefine16")
'            Call SelRef(RefName, sCode, sName, bReturn, Con, Frm, reRst)
'        Case LCase("cFree1"), LCase("cFree2"), LCase("cFree3"), LCase("cFree4"), LCase("cFree5"), LCase("cFree6"), LCase("cFree7"), _
'            LCase("cFree8"), LCase("cFree9"), LCase("cFree10"), LCase("Userdefine")
'            sCode = "Cvalue"
'            sName = "cAlias"
'            Call GetColSetStr("UserdefFreeRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "cValue,cAlias,", m_sRefMatch, "UserdefFree")
'            Dim sTemp As String
'            sTemp = "������" + CStr(Mid(RefName, Len("cFree") + 1, Len(RefName)))
'            strGrid = "Select " + cFlds + " from userdefine where cID =( select top 1 cID from userdef where cClass='���' and cItem='" + sTemp + "') and " + m_sRefMatch
'            showRef "", strGrid, sCode, sName, "UserdefFree", RsColset, False, cOrder, bReturn, , reRst
'        Case LCase("iQTmethod")
'            sCode = "cProjectCode"
'            sName = "cProjectName"
'            sId = "ID"
'            Call GetColSetStr("qmCheckProjectRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "cProjectCode,cProjectName", m_sRefMatch, "qmCheckProject")
'            strGrid = "select " + cFlds + " from qmCheckProject" + " where " + m_sRefMatch
'            showRef "", strGrid, sCode, sName, "qmCheckProject", RsColset, False, cOrder, bReturn, sId, reRst
'            Con.Tag = sId '���⴦��
'        Case LCase("iInvTfId")
'            sCode = "TfCode"
'            sName = "Description"
'            sId = "TfId"
'            Call GetColSetStr("mps_timefenceRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "TfCode,Description", m_sRefMatch, "mps_timefence")
'            strGrid = "select " + cFlds + " from mps_timefence" + " where " + m_sRefMatch
'            showRef "", strGrid, sCode, sName, "mps_timefence", RsColset, False, cOrder, bReturn, sId, reRst
'        Case Else
'            ShowMsg "û���趨���գ�"
'    End Select
'End Sub

''---------------------------------------------------
''���ܣ��Զ������
''������UserDefXX���Զ���ؼ���
''       Scode������
''       sName������
''       bReturn :�Ƿ�ȡ�ز���
''       Con����Ҫ���յĿؼ�
''---------------------------------------------------
'Private Sub SelRef(ByVal UserDefXX As String, ByRef sCode As String, ByRef sName As String, ByRef bReturn As Boolean, ByVal Con As Control, ByVal Frm As Object, Optional reRst As ADODB.Recordset)
'    Dim strSql As String
'    Dim Rs As ADODB.Recordset
'    Dim strClass As String, strGrid As String
'    Dim RsColset As New ADODB.Recordset
'    Dim sTemp As String
'    Dim cFormat As String, cFlds As String, cOrder As String
'    Dim sMatch As String '����ƥ�䴮
'    Dim iNo As Integer
'    Dim tableName As String, TableNameRef As String, TableNameJoin As String
'    sTemp = "�Զ�����" + Right(UserDefXX, Len(UserDefXX) - 10)
'    strSql = " select cRelArchive,cRElField from Userdef where cClass='���' and cITem='" + sTemp + "' and (cRelArchive<>'' and CRelArchive is not null) and (cRElField<>'' and cRelField is not null)"
'    Set Rs = SrvDB.OpenX(strSql)
'    sName = ""
'    iNo = CInt(Right(UserDefXX, Len(UserDefXX) - 10))
'    If Rs.RecordCount = 1 Then
'        tableName = TxtValue(Rs!cRelArchive)
'        TableNameRef = tableName + "Ref"
'        sCode = TxtValue(Rs!cRelField)
'        Call GetColSetStr(TableNameRef, cFormat, cFlds, cOrder, RsColset)
'        If iNo <= 14 Then
'            Call g_oPub.CreateMatchStr(Con, sCode, sMatch, tableName)
'        Else
'            sMatch = "(1=1)"
'        End If
'        TableNameJoin = g_oPub.GetJoinTableStr(tableName)
'        If iNo <= 10 Then
'            strGrid = "Select " + cFlds + " from " + TableNameJoin + " where " + sMatch + " and ( " + sCode + " is not null  and " + sCode + "<>'')"
'        Else
'            strGrid = "Select " + cFlds + " from " + TableNameJoin + " where " + sMatch + " and ( " + sCode + " is not null  )"
'        End If
'        strGrid = strGrid + " and " + g_oPub.GetEndDateFilter(tableName, g_CurDate)
'        showRef "", strGrid, sCode, sName, tableName, RsColset, False, cOrder, bReturn, , reRst
'    Else
'        sCode = "Cvalue"
'        If iNo <= 10 Then
'            Call GetColSetStr("UserdefineRef", cFormat, cFlds, cOrder, RsColset)
'            Call g_oPub.CreateMatchStr(Con, "Cvalue,cAlias", sMatch, "Userdefine")
'            sTemp = "�Զ�����" + CStr(Mid(UserDefXX, Len("cInvDefine") + 1, Len(UserDefXX)))
'            strGrid = "Select " + cFlds + " from userdefine where cID =( select top 1 cID from userdef where cClass='���' and cItem='" + sTemp + "') and " + sMatch
'            showRef "", strGrid, sCode, sName, "UserDefine", RsColset, False, cOrder, bReturn, , reRst
'        ElseIf iNo >= 11 And iNo <= 14 Then
'            Dim oCompu As Object
'            Const oCompuHeight = 2895
'            Set oCompu = CreateObject("CalculateAPP.ICalcCom")
'            Dim str As String
'            oCompu.Left = Con.Left
'            oCompu.Top = Con.Top + Con.Height + 72 * Screen.TwipsPerPixelY
'            If oCompu.Top + oCompuHeight > Frm.Height Then
'                oCompu.Top = Con.Top - oCompuHeight + 72 * Screen.TwipsPerPixelY
'            End If
'            oCompu.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.calculator") ' "������"
'            sCode = oCompu.Calculate(Frm.hWnd)
'            bReturn = True
'            Set oCompu = Nothing
'        Else
'            Cal.Left = Con.Left
'            Cal.Top = Con.Top + Con.Height + 100
'            If Cal.Top + Cal.Height + 1000 > FrmZMulModify.Height Then
'                Cal.Top = Con.Top - Cal.Height
'            End If
'            Cal.DateDivideChar = "-"
'            Con.Text = Cal.Calendar(FrmZMulModify.hWnd)
'            sCode = Con.Text
'        End If
'
'    End If
'End Sub

'-------------------------------------------
'���ܣ������Ŀ�����ַ���
'������cKey���ؼ���
'       cFormat����ʽ�ַ���
'       cFld�����ݿ��ֶ���
'       cOrder:����
'
'-------------------------------------------
Public Sub GetColSetStr(ByVal cKey As String, ByRef cFormat As String, ByRef cFlds As String, ByRef cOrder As String, Optional ByRef RsColset As ADODB.Recordset)
    cFormat = g_ColSet.getColInfo(cKey, 1)
    cFlds = Trim(g_ColSet.GetSqlString(cFormat))
    cOrder = GetOrderStr(cFormat)
    Set RsColset = g_ColSet.getColSet(cKey, 1)
End Sub

'---------------------------------------------
'���ܣ�ƴ�����ַ���
'������cFormat:XML��ʽ��
'---------------------------------------------
Public Function GetOrderStr(ByVal cFormat As String) As String
    Dim sOrder As String
    sOrder = Trim(g_ColSet.GetOrderString(cFormat))
    If sOrder = "" Then
        GetOrderStr = ""
    Else
        GetOrderStr = " Order by " + sOrder + " "
    End If
End Function



'---------------------------------------
'���ܣ� ��ʼ����Ŀ���á�Ȩ������
'---------------------------------------
Public Sub InitColAuthSet()

    If g_bIsWeb = False Then
        g_bControlFldAuth = g_oPub.NeedControlAuth(SrvDB, "Inventory")
        If g_bControlFldAuth = True Then
            g_sRFldAuthInv = LCase(g_colAuth.GetAuthString("<u8ColAuth cBusObId='Inventory' cFuncId='R'/>"))
            g_sNFldAuthInv = LCase(g_colAuth.GetAuthString("<u8ColAuth cBusObId='Inventory' cFuncId='N'/>"))
        End If
    Else
        g_sRFldAuthInv = g_oPub.GetFldAuthString("Inventory", "R", SrvDB, g_UfDbName, g_cUserId)
        g_sNFldAuthInv = g_oPub.GetFldAuthString("Inventory", "N", SrvDB, g_UfDbName, g_cUserId)
    End If
    g_sRowAuthInvW = g_oPub.GetGetAuthStringCode(g_rowAuth, "Inventory", "W")
    g_sRowAuthInv = g_oPub.GetGetAuthStringCode(g_rowAuth, "Inventory")
    
    g_sRowAuthVen = g_oPub.GetGetAuthStringCode(g_rowAuth, "Vendor")
    
    '�ֿ�Ȩ���ַ���
    g_sRowAuthWare = g_oPub.GetGetAuthStringCode(g_rowAuth, "Warehouse")
    
    g_sRowAuthPos = g_oPub.GetGetAuthStringCode(g_rowAuth, "Position")
    
    'ҵ��ԱȨ���ַ���
    g_sRowAuthPerson = g_oPub.GetGetAuthStringCode(g_rowAuth, "Person")
    
    '����Ȩ���ַ���
    g_sRowAuthDept = g_oPub.GetGetAuthStringCode(g_rowAuth, "Department")

End Sub

'---------------------------------------
'���ܣ���ȡ����ID
'---------------------------------------
Public Function GetAccId() As String
    Dim Pos As Integer
    Dim sFlag As String
    sFlag = LCase("CATALOG=UFDATA_")
    Pos = InStr(1, LCase(g_UfDbName), sFlag)
    GetAccId = Mid(g_UfDbName, Pos + Len(sFlag), 3)
End Function


Public Sub AddCmbItems(Cmb As Object, arr() As String, Optional iListIndex As Integer = -1)
    On Error GoTo Err_Info
    Cmb.Clear
    Dim i As Integer
    For i = LBound(arr) To UBound(arr)
        Cmb.AddItem arr(i)
    Next i
    Cmb.ListIndex = iListIndex
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

Public Sub InitClient()
    On Error GoTo Err_Info
    Dim fsinfo As String
    If g_oLogin Is Nothing Then
        Exit Sub
    End If
    If g_oClient Is Nothing Then
        Set g_oClient = CreateObject("U8FileManagerClient.U8FileManageClient")
    End If
    Set g_oClient.LoginObject = g_oLogin
'    Call g_oLogin.GetFileServerInfo(fsinfo)
'        If g_oLogin.GetFileServerInfo(fsinfo) = False Then
'            MsgBox g_oLogin.ShareString
'        Else
'            MsgBox fsinfo
'        End If
    Exit Sub
Err_Info:
    ShowMsg "(g_oClient)" + Err.Description
End Sub


