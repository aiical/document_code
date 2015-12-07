Attribute VB_Name = "Const"
Option Explicit
'Public ArrField() As String '���ݿ��ֶ�����
'Public ArrCHField() As String '�ֶ���������
'Public ArrRefField() As String '��Ҫʵ�ֲ��ձ�־

'Public ArrMField() As String '���ݿ��ֶ�����,��Ҫ�޸�
'Public ArrMCHField() As String '�ֶ��������ƣ���Ҫ�޸�
'Public ArrMRefField() As String '��Ҫʵ�ֲ��ձ�־����Ҫ�޸�

Public ciDTLevelItems() As String '����ˮƽѡ��
Public iCheckATPItems() As String
Public cAQLItems() As String 'AQLѡ��
Public iEndDTStyleItems() As String '����Ʒ�����ϸ��ѡ��
Public iTestRuleItems() As String '�������
Public iSupplyTypeItems() As String '��Ӧ����ѡ��
'Public g_BitFlds As String '����bitλ�ֶ���
Public cMassUnitItems() As String '�����ڵ�λ
Public FreeItems() As String '�������Ƿ�����
Public iGroupTypeItems() As String '������λ������
Public iRecipeBatchItems() As String '����ҩ����
Public iPlanPolicyItems() As String '�ƻ�����
Public iROPMethodItems() As String '�ٶ����㷽��
Public iBatchRuleItems() As String '��������
Public iTestStyleItems() As String '���鷽ʽ
Public iDTMethodItems() As String '��췽��
Public iDTStyleItems() As String '��췽ʽ
Public boolItems() As String '�ǡ���
Public weekDay() As String '
Public cFrequencyItems() As String '�̵����ڵ�λ
Public cFrequencyDB() As String '�̵����ڵ�λ,���ݿ�洢����
Public cValueTypeItems() As String '�Ƽ۷�ʽ
Public cValueTypeDB() As String '�Ƽ۷�ʽ,���ݿ�洢����
Public iSurenessType() As String '��ȫ��淽��
Public iDateType() As String '�ڼ�����
Public iDynamicSurenessType() As String
Public iRequireTrackStyleItems() As String '������ٷ�ʽ
Public iBOMExpandUnitTypeItems() As String 'BOMչ����λ
Public iExpiratDateCalcuItems() As String '��Ч�����㷽ʽ
Public iWarrantyUnitItems() As String '�����ڵ�λ
Public g_sXMLMulModify As String '����XML��
'
Public bTrackSaleBill As Boolean '�Ƿ�������۸���ѡ��


'---------------------------------------
'���ܣ������ʼ��
'---------------------------------------
Public Sub ConstInit()
    Dim sTemp As String
    Dim arrTemp() As String
    ReDim boolItems(0 To 1)
    boolItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no")
    boolItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.yes")

    ReDim weekDay(1 To 7)
    weekDay(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.week1") '"������"
    weekDay(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.week2") ' "����һ"
    weekDay(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.week3") ' "���ڶ�"
    weekDay(4) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.week4") ' "������"
    weekDay(5) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.week5") ' "������"
    weekDay(6) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.week6") ' "������"
    weekDay(7) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.week7") ' "������"
    
    ReDim cFrequencyItems(0 To 2)
    cFrequencyItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cdrequency_day") ' "��"
    cFrequencyItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cdrequency_week") ' "��"
    cFrequencyItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cdrequency_month") ' "��"
    
    'ѡ�����϶�Ӧ
    ReDim cFrequencyDB(0 To 2)
    cFrequencyDB(0) = "��"
    cFrequencyDB(1) = "��"
    cFrequencyDB(2) = "��"
    
    
    '2006-10-8 �����»���ƶȵ�Ӱ�죬�ڴ�������Ͳֿ⵵�������üƼ۷�ʽʱ��Ҫ�����մ��еĺ���ȳ����������мƼ۷�ʽ������档
    ReDim cValueTypeItems(0 To 6)
    cValueTypeItems(0) = ""
    If g_bFactory = False Then ' "��ҵ"
        cValueTypeItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cvaluetype1_busi") ' "�ۼ۷�"
    Else '��ҵ
        cValueTypeItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cvaluetype1") ' "�ƻ��۷�"
    End If
    cValueTypeItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cvaluetype2") ' "ȫ��ƽ����"
    cValueTypeItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cvaluetype3") ' "�ƶ�ƽ����"
    cValueTypeItems(4) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cvaluetype4") ' "�Ƚ��ȳ���"
    cValueTypeItems(6) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cvaluetype5") ' "����ȳ���"
    cValueTypeItems(5) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cvaluetype6") ' "����Ƽ۷�"
    
    'ѡ�����϶�Ӧ
    ReDim cValueTypeDB(0 To 6)
    cValueTypeDB(0) = ""
    If g_bFactory = False Then ' "��ҵ"
        cValueTypeDB(1) = "�ۼ۷�"
    Else '��ҵ
        cValueTypeDB(1) = "�ƻ��۷�"
    End If
    cValueTypeDB(2) = "ȫ��ƽ����"
    cValueTypeDB(3) = "�ƶ�ƽ����"
    cValueTypeDB(4) = "�Ƚ��ȳ���"
    cValueTypeDB(6) = "����ȳ���"
    cValueTypeDB(5) = "����Ƽ۷�"
    
    
    ReDim FreeItems(0 To 1)
    FreeItems(0) = ""
    FreeItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.free1") ' "����"
    
    ReDim iGroupTypeItems(0 To 2)
    iGroupTypeItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.igrouptype0") ' "�޻�����"
    iGroupTypeItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.igrouptype1") ' "�̶�������"
    iGroupTypeItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.igrouptype2") ' "����������"
    
    ReDim iRecipeBatchItems(0 To 3)
    iRecipeBatchItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch0") ' "������"
    iRecipeBatchItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch1") ' "����ҩ"
    iRecipeBatchItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch2_861") ' "����Ǵ���ҩ"
    iRecipeBatchItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch3") ' "����Ǵ���ҩ"
    
    ReDim iPlanPolicyItems(0 To 3)
    iPlanPolicyItems(0) = ""
    iPlanPolicyItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iplanpolicy1") ' "MRP��"
    iPlanPolicyItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iplanpolicy2") ' "ROP��"
    iPlanPolicyItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iplanpolicy3") ' "�����"
    
    ReDim iROPMethodItems(0 To 2)
    iROPMethodItems(0) = ""
    iROPMethodItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iropmethod1") ' "�ֹ�"
    iROPMethodItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iropmethod2") ' "�Զ�"
    
    ReDim iBatchRuleItems(0 To 5)
    iBatchRuleItems(0) = ""
    iBatchRuleItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule1") ' "ֱ������"
    iBatchRuleItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule2") ' "�̶�����"
    iBatchRuleItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule3") ' "�ڼ�����"
    iBatchRuleItems(4) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule4") ' "��������߿�"
    iBatchRuleItems(5) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibatchrule5") ' "��ʷ������"
    
    ReDim iTestStyleItems(0 To 3)
    iTestStyleItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iteststyle0") ' "ȫ��"
    iTestStyleItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iteststyle1") ' "���"
    iTestStyleItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iteststyle2") ' "�ƻ��Գ��"
    iTestStyleItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.iteststyle3") ' "���ƻ��Գ��"
    
    ReDim iDTMethodItems(0 To 3)
    iDTMethodItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtmethod0") ' "���������"
    iDTMethodItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtmethod1") ' "�������"
    iDTMethodItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtmethod2") ' "��������"
    iDTMethodItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtmethod3") ' "����������"
    
    ReDim iDTStyleItems(0 To 2)
    iDTStyleItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtstyle0") ' "����"
    iDTStyleItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtstyle1") ' "����"
    iDTStyleItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtstyle2") ' "�ſ�"
    
    ReDim ciDTLevelItems(0 To 9)
    
    ciDTLevelItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel0") ' "һ��I"
    ciDTLevelItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel1") ' "һ��II"
    ciDTLevelItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel2") ' "һ��III"
    ciDTLevelItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel3") ' "����S-1"
    ciDTLevelItems(4) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel4") ' "����S-2"
    ciDTLevelItems(5) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel5") ' "����S-3"
    ciDTLevelItems(6) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel6") ' "����S-4"
    ciDTLevelItems(7) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel7") ' "�Զ���U-1"
    ciDTLevelItems(8) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel8") ' "�Զ���U-2"
    ciDTLevelItems(9) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idtlevel9") ' "�Զ���U -3"
    ReDim cAQLItems(0 To 25)
    cAQLItems(0) = "0.010"
    cAQLItems(1) = "0.015"
    cAQLItems(2) = "0.025"
    cAQLItems(3) = "0.040"
    cAQLItems(4) = "0.065"
    cAQLItems(5) = "0.10"
    cAQLItems(6) = "0.15"
    cAQLItems(7) = "0.25"
    cAQLItems(8) = "0.40"
    cAQLItems(9) = "0.65"
    cAQLItems(10) = "1.0"
    cAQLItems(11) = "1.5"
    cAQLItems(12) = "2.5"
    cAQLItems(13) = "4.0"
    cAQLItems(14) = "6.5"
    cAQLItems(15) = "10"
    cAQLItems(16) = "15"
    cAQLItems(17) = "25"
    cAQLItems(18) = "40"
    cAQLItems(19) = "65"
    cAQLItems(20) = "100"
    cAQLItems(21) = "150"
    cAQLItems(22) = "250"
    cAQLItems(23) = "400"
    cAQLItems(24) = "650"
    cAQLItems(25) = "1000"
    
    ReDim iEndDTStyleItems(0 To 2)
    iEndDTStyleItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ienddtstyle0") ' "����"
    iEndDTStyleItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ienddtstyle1") ' "����"
    iEndDTStyleItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ienddtstyle2") ' "�ſ�"
    
    ReDim iTestRuleItems(0 To 1)
    iTestRuleItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.itestrule0") ' "���������"
    iTestRuleItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.itestrule1") ' "��ָ�����"
    
    ReDim iSupplyTypeItems(0 To 4)
    iSupplyTypeItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype0") ' "����"
    iSupplyTypeItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype1") ' "��⵹��"
    iSupplyTypeItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype2") ' "���򵹳�"
    iSupplyTypeItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype3") ' "�����"
    iSupplyTypeItems(4) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype4") ' "ֱ�ӹ�Ӧ"
    
    ReDim cMassUnitItems(0 To 3)
    cMassUnitItems(0) = ""
    cMassUnitItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cmassunit1") ' "��"
    cMassUnitItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cmassunit2") ' "��"
    cMassUnitItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cmassunit3") ' "��"
    
    ReDim iExpiratDateCalcuItems(0 To 2)
    iExpiratDateCalcuItems(0) = ""
    iExpiratDateCalcuItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bydate_month") ' "����"
    iExpiratDateCalcuItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bydate_day") ' "����"
    
    ReDim iCheckATPItems(0 To 1)
    iCheckATPItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.icheckatp0") '"�����"
    iCheckATPItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.icheckatp1") '"�������"
    
    ReDim iSurenessType(1 To 2)
    iSurenessType(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") '"��̬"
    iSurenessType(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") '"��̬"
    
    ReDim iDateType(1 To 3)
    iDateType(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0") '"��"
    iDateType(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1") '"��"
    iDateType(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2") '"��"
    
    ReDim iDynamicSurenessType(1 To 2)
    iDynamicSurenessType(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") '"��������"
    iDynamicSurenessType(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1") '"�ٷֱ�"
    
    ReDim iRequireTrackStyleItems(0 To 3)
    iRequireTrackStyleItems(0) = ""
    iRequireTrackStyleItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irequiretrackstyle1") '������
    iRequireTrackStyleItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irequiretrackstyle2") '�����к�
    iRequireTrackStyleItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irequiretrackstyle3") '����������
    
    ReDim iBOMExpandUnitTypeItems(1 To 2)
    iBOMExpandUnitTypeItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibomexpandunittype1") '��������λ
    iBOMExpandUnitTypeItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibomexpandunittype2") '��������λ
    
    ReDim iWarrantyUnitItems(0 To 3)
    iWarrantyUnitItems(0) = ""
    iWarrantyUnitItems(1) = cMassUnitItems(1) '��
    iWarrantyUnitItems(2) = cMassUnitItems(2) '��
    iWarrantyUnitItems(3) = cMassUnitItems(3) '��
    
    
    Dim strSql As String
    Dim i As Integer
'    Dim RstType As ADODB.Recordset
    Const nFldCount = 300 '��ȥ�Զ��������������ֶ�����
'    strSql = "select  * from Inventory where 1=2"
'    Set RstType = SrvDB.OpenX(strSql)

    Dim NoAuthFlds  As String
    If Len(g_sNFldAuthInv) > 0 And Len(g_sRFldAuthInv) > 0 Then
        NoAuthFlds = g_sNFldAuthInv + "," + g_sRFldAuthInv
    ElseIf Len(g_sNFldAuthInv) > 0 Then
        NoAuthFlds = g_sNFldAuthInv
    Else
        NoAuthFlds = g_sRFldAuthInv
    End If

    Dim Rs As New ADODB.Recordset
    strSql = "select * from UFMeta_" + GetAccId + "..aa_columndic where ckey='inventory'"
    Set Rs = SrvDB.OpenX(strSql)
    
    Dim buf As Object
    Set buf = CreateObject("U8Pub.StringBuilder")
    NoAuthFlds = Replace(LCase(NoAuthFlds), "atpcode", "iinvatpid")
    buf.Append ("<Inventory bWeb='" + IIf(g_bIsWeb = True, "1", "0") + "' url='" + g_URL + "' noauthflds='" + NoAuthFlds + "'>")
    buf.Append ("<cInvCode showfldname='" + g_oPub.GetFldCaption(Rs, "cInvCode") + "'  reftype='ref' cRefID='Inventory_AA' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<cInvAddCode showfldname='" + g_oPub.GetFldCaption(Rs, "cInvAddCode") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<cInvName showfldname='" + g_oPub.GetFldCaption(Rs, "cInvName") + "'  reftype='ref' cRefID='Inventory_AA'  cRetFld='cInvName' cShowFld='cInvName'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<cInvStd showfldname='" + g_oPub.GetFldCaption(Rs, "cInvStd") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.dSDate showfldname='" + g_oPub.GetFldCaption(Rs, "dSDate") + "'  reftype='date' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.CCreatePerson showfldname='" + g_oPub.GetFldCaption(Rs, "CCreatePerson") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cModifyPerson showfldname='" + g_oPub.GetFldCaption(Rs, "cModifyPerson") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.DModifyDate showfldname='" + g_oPub.GetFldCaption(Rs, "DModifyDate") + "'  reftype='date' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cFrequency showfldname='" + g_oPub.GetFldCaption(Rs, "cFrequency") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.iFrequency showfldname='" + g_oPub.GetFldCaption(Rs, "iFrequency") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cDefWareHouse showfldname='" + g_oPub.GetFldCaption(Rs, "cDefWareHouse") + "'  reftype='ref' cRefID='Warehouse_AA' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.dLastDate showfldname='" + g_oPub.GetFldCaption(Rs, "dLastDate") + "'  reftype='date' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.iId showfldname='" + g_oPub.GetFldCaption(Rs, "iId") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    
    buf.Append ("<Inventory.cValueType showfldname='" + g_oPub.GetFldCaption(Rs, "cValueType") + "'  reftype='enum' cRefID='" + GetArrEnumString(cValueTypeDB, cValueTypeItems) + "' bmulmodify='1' bBadStrException='0'/>")
    If CS2 = True Then
        buf.Append ("<bInvBatch showfldname='" + g_oPub.GetFldCaption(Rs, "bInvBatch") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    If g_bInvSysStart = True Then
        buf.Append ("<Inventory.bTrack showfldname='" + g_oPub.GetFldCaption(Rs, "bTrack") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    'zhaoyin3 ���������ֶΣ����������ݼ��������/bReceiptByDT,֧������ţ�201111020100
    If g_bQM = True Then
        buf.Append ("<Inventory.bReceiptByDT showfldname='" + g_oPub.GetFldCaption(rs, "bReceiptByDT") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    If g_bSerialEnabled = True Then
        buf.Append ("<Inventory.bSerial showfldname='" + g_oPub.GetFldCaption(Rs, "bSerial") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    If CS3 = True Then
        If g_bGSP = True Then
            sTemp = g_oPub.GetResString("U8.AA.INVENTORY.binvquality_gsp") ' ' "�Ƿ���Ч�ڹ���"
        Else
            sTemp = g_oPub.GetResString("U8.AA.INVENTORY.binvquality") ' ' "�Ƿ����ڹ���" '"bInvQuality"   bit 1   ��
        End If
        buf.Append ("<bInvQuality showfldname='" + g_oPub.GetFldCaption(Rs, "bInvQuality") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    
    'buf.Append ("<Inventory.iHighPrice showfldname='" + g_oPub.GetFldCaption(Rs, "iHighPrice") + "'  reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "' bmulmodify='0' bBadStrException='0'/>")
    If CS1 = True Then
        buf.Append ("<bInvEntrust showfldname='" + g_oPub.GetFldCaption(Rs, "bInvEntrust") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    End If
    buf.Append ("<Inventory.iGroupType showfldname='" + g_oPub.GetFldCaption(Rs, "iGroupType") + "'  reftype='enum' cRefID='" + GetEnumString("0,1,2", iGroupTypeItems) + "' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cGroupCode showfldname='" + g_oPub.GetFldCaption(Rs, "cGroupCode") + "'  reftype='ref' cRefID='ComputationGroup_AA' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cComunitCode showfldname='" + g_oPub.GetFldCaption(Rs, "cComunitCode") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<cPUComunitCode showfldname='" + g_oPub.GetFldCaption(Rs, "cPUComunitCode") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<cSAComunitCode showfldname='" + g_oPub.GetFldCaption(Rs, "cSAComunitCode") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<cSTComunitCode showfldname='" + g_oPub.GetFldCaption(Rs, "cSTComunitCode") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<cCAComunitCode showfldname='" + g_oPub.GetFldCaption(Rs, "cCAComunitCode") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cProductUnit showfldname='" + g_oPub.GetFldCaption(Rs, "cProductUnit") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cWGroupCode showfldname='" + g_oPub.GetFldCaption(Rs, "cWGroupCode") + "'  reftype='ref' cRefID='ComputationGroup_AA' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cWUnit showfldname='" + g_oPub.GetFldCaption(Rs, "cWUnit") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cVGroupCode showfldname='" + g_oPub.GetFldCaption(Rs, "cVGroupCode") + "'  reftype='ref' cRefID='ComputationGroup_AA' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cVUnit showfldname='" + g_oPub.GetFldCaption(Rs, "cVUnit") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    If g_bQM = True Then
        buf.Append ("<Inventory.cDTUnit showfldname='" + g_oPub.GetFldCaption(Rs, "cDTUnit") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    End If
    buf.Append ("<Inventory.cShopUnit showfldname='" + g_oPub.GetFldCaption(Rs, "cShopUnit") + "'  reftype='' cRefID='' bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.cInvCCode showfldname='" + g_oPub.GetFldCaption(Rs, "cInvCCode") + "'  reftype='ref' cRefID='InventoryClass_AA' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.cCIQCode showfldname='" + g_oPub.GetFldCaption(Rs, "cCIQCode") + "'  reftype='ref' cRefID='EX_REFER_CIQCODE_EX' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fInvCIQExch showfldname='" + g_oPub.GetFldCaption(Rs, "fInvCIQExch") + "'  reftype='decdgt'  decdgt='" + CStr(g_iRateDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.cVenCode showfldname='" + g_oPub.GetFldCaption(Rs, "cVenCode") + "'  reftype='ref' cRefID='Vendor_AA' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.cReplaceItem showfldname='" + g_oPub.GetFldCaption(Rs, "cReplaceItem") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.cPosition showfldname='" + g_oPub.GetFldCaption(Rs, "cPosition") + "'  reftype='ref' cRefID='Position_AA' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bSale showfldname='" + g_oPub.GetFldCaption(Rs, "bSale") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bExpSale showfldname='" + g_oPub.GetFldCaption(Rs, "bExpSale") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bPurchase showfldname='" + g_oPub.GetFldCaption(Rs, "bPurchase") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bSelf showfldname='" + g_oPub.GetFldCaption(Rs, "bSelf") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bComsume showfldname='" + g_oPub.GetFldCaption(Rs, "bComsume") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bProducing showfldname='" + g_oPub.GetFldCaption(Rs, "bProducing") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bService showfldname='" + g_oPub.GetFldCaption(Rs, "bService") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bPiece showfldname='" + g_oPub.GetFldCaption(Rs, "bPiece") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    If CS4 = True Then
        buf.Append ("<bAccessary showfldname='" + g_oPub.GetFldCaption(Rs, "bAccessary") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    buf.Append ("<bKCCutMantissa showfldname='" + g_oPub.GetFldCaption(Rs, "bKCCutMantissa") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bBondedInv showfldname='" + g_oPub.GetFldCaption(Rs, "bBondedInv") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iTaxRate showfldname='" + g_oPub.GetFldCaption(Rs, "iTaxRate") + "'  reftype='decdgt'  decdgt='" + CStr(g_iRateDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iImpTaxRate showfldname='" + g_oPub.GetFldCaption(Rs, "iImpTaxRate") + "'  reftype='decdgt'  decdgt='" + CStr(g_iRateDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.iExpTaxRate showfldname='" + g_oPub.GetFldCaption(Rs, "iExpTaxRate") + "'  reftype='decdgt'  decdgt='" + CStr(g_iRateDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvWeight showfldname='" + g_oPub.GetFldCaption(Rs, "iInvWeight") + "'  reftype='decdgt'  decdgt='" + CStr(g_iQuanDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iVolume showfldname='" + g_oPub.GetFldCaption(Rs, "iVolume") + "'  reftype='decdgt'  decdgt='" + CStr(g_iQuanDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    '��ƻ���/�ۼۼ���ƽ��ֵ���ã��޷�����
    buf.Append ("<Inventory.iInvRCost showfldname='" + g_oPub.GetFldCaption(Rs, "iInvRCost") + "'  reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='0' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvSPrice showfldname='" + g_oPub.GetFldCaption(Rs, "iInvSPrice") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fCurLLaborCost showfldname='" + g_oPub.GetFldCaption(Rs, "fCurLLaborCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fCurLVarManuCost showfldname='" + g_oPub.GetFldCaption(Rs, "fCurLVarManuCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fCurLFixManuCost showfldname='" + g_oPub.GetFldCaption(Rs, "fCurLFixManuCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fCurLOMCost showfldname='" + g_oPub.GetFldCaption(Rs, "fCurLOMCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fNextLLaborCost showfldname='" + g_oPub.GetFldCaption(Rs, "fNextLLaborCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fNextLVarManuCost showfldname='" + g_oPub.GetFldCaption(Rs, "fNextLVarManuCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fNextLFixManuCost showfldname='" + g_oPub.GetFldCaption(Rs, "fNextLFixManuCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fNextLOMCost showfldname='" + g_oPub.GetFldCaption(Rs, "fNextLOMCost") + "' reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvSCost showfldname='" + g_oPub.GetFldCaption(Rs, "iInvSCost") + "'  reftype='decdgt'  decdgt='" + CStr(g_iBillPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvLSCost showfldname='" + g_oPub.GetFldCaption(Rs, "iInvLSCost") + "'  reftype='decdgt'  decdgt='" + CStr(g_iBillPriceDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvNCost showfldname='" + g_oPub.GetFldCaption(Rs, "iInvNCost") + "'  reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvAdvance showfldname='" + g_oPub.GetFldCaption(Rs, "iInvAdvance") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvBatch showfldname='" + g_oPub.GetFldCaption(Rs, "iInvBatch") + "'  reftype='decdgt'  decdgt='" + CStr(g_iQuanDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iSafeNum showfldname='" + g_oPub.GetFldCaption(Rs, "iSafeNum") + "'  reftype='decdgt'  decdgt='" + CStr(g_iQuanDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iTopSum showfldname='" + g_oPub.GetFldCaption(Rs, "iTopSum") + "'  reftype='decdgt'  decdgt='" + CStr(g_iQuanDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iLowSum showfldname='" + g_oPub.GetFldCaption(Rs, "iLowSum") + "'  reftype='decdgt'  decdgt='" + CStr(g_iQuanDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iOverStock showfldname='" + g_oPub.GetFldCaption(Rs, "iOverStock") + "'  reftype='decdgt'  decdgt='" + CStr(g_iQuanDecDgt) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.cInvABC showfldname='" + g_oPub.GetFldCaption(Rs, "cInvABC") + "'  reftype='enum' cRefID='" + GetStrEnumstring("A,B,C", "A,B,C") + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bInvOverStock showfldname='" + g_oPub.GetFldCaption(Rs, "bInvOverStock") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.dEDate showfldname='" + g_oPub.GetFldCaption(Rs, "dEDate") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bInvType showfldname='" + g_oPub.GetFldCaption(Rs, "bInvType") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iInvMPCost showfldname='" + g_oPub.GetFldCaption(Rs, "iInvMPCost") + "'  reftype='decdgt'  decdgt='" + CStr(g_iPriceDecDgt) + "'  bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.cQuality showfldname='" + g_oPub.GetFldCaption(Rs, "cQuality") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.fSubscribePoint showfldname='" + g_oPub.GetFldCaption(Rs, "fSubscribePoint") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fVagQuantity showfldname='" + g_oPub.GetFldCaption(Rs, "fVagQuantity") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fOutExcess showfldname='" + g_oPub.GetFldCaption(Rs, "fOutExcess") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fInvOutUpLimit showfldname='" + g_oPub.GetFldCaption(Rs, "fInvOutUpLimit") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fBuyExcess showfldname='" + g_oPub.GetFldCaption(Rs, "fBuyExcess") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<fPrjMatLimit showfldname='" + g_oPub.GetFldCaption(Rs, "fPrjMatLimit") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fInExcess showfldname='" + g_oPub.GetFldCaption(Rs, "fInExcess") + "' reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    If CS3 = True Then
        If g_bGSP = False Then
            sTemp = g_oPub.GetResString("U8.AA.INVENTORY.imassdate") ' "������" '"iMassDate" smallint    4
        Else
            sTemp = g_oPub.GetResString("U8.AA.INVENTORY.imassdate_gsp") ' "��Ч��" '"iMassDate" smallint    4
        End If
        buf.Append ("<Inventory.iMassDate showfldname='" + sTemp + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        If g_bGSP = False Then
            sTemp = g_oPub.GetResString("U8.AA.INVENTORY.iwarndays") ' "Ԥ������" '"iWarnDays" smallInt    4������Ԥ������
        Else
            sTemp = g_oPub.GetResString("U8.AA.INVENTORY.iwarndays_gsp") ' "��Ч��" '"iWarnDays" smallInt    4������Ԥ������
        End If
        buf.Append ("<Inventory.iWarnDays showfldname='" + sTemp + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<iExpiratDateCalcu showfldname='" + g_oPub.GetFldCaption(Rs, "iExpiratDateCalcu") + "'  reftype='enum' cRefID='" + GetEnumString("0,1,2", iExpiratDateCalcuItems) + "' bmulmodify='1' bBadStrException='0'/>")
    End If
    buf.Append ("<bInvROHS showfldname='" + g_oPub.GetFldCaption(Rs, "bInvROHS") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    If g_bGSP = True Or g_bQM = True Then
        buf.Append ("<Inventory.bPropertyCheck showfldname='" + g_oPub.GetFldCaption(Rs, "bPropertyCheck") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    buf.Append ("<Inventory.fExpensesExch showfldname='" + g_oPub.GetFldCaption(Rs, "fExpensesExch") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    If g_bInvSysStart = True Then
        buf.Append ("<Inventory.bBarCode showfldname='" + g_oPub.GetFldCaption(Rs, "bBarCode") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        ReDim arrTemp(0 To 1)
        arrTemp(0) = ""
        arrTemp(1) = g_oPub.GetResString("U8.AA.INVENTORY.FRMMULMODIFY.81_1") 'U8.AA.INVENTORY.FRMMULMODIFY.81_1="��Ӧ�������"
        buf.Append ("<Inventory.cBarCode showfldname='" + g_oPub.GetFldCaption(Rs, "cBarCode") + "'  reftype='enum' cRefID='" + GetArrEnumString(arrTemp, arrTemp) + "' bmulmodify='1' bBadStrException='0'/>")
    End If
    buf.Append ("<Inventory.iWastage showfldname='" + g_oPub.GetFldCaption(Rs, "iWastage") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iDrawBatch showfldname='" + g_oPub.GetFldCaption(Rs, "iDrawBatch") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fMinSplit showfldname='" + g_oPub.GetFldCaption(Rs, "fMinSplit") + "'  reftype='decdgt'  decdgt='" + CStr(g_iDecDgt6) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bSolitude showfldname='" + g_oPub.GetFldCaption(Rs, "bSolitude") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'If g_BShowMedicineTab = True Then
        buf.Append ("<Inventory.CEnterprise showfldname='" + g_oPub.GetFldCaption(Rs, "CEnterprise") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cAddress showfldname='" + g_oPub.GetFldCaption(Rs, "cAddress") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cFile showfldname='" + g_oPub.GetFldCaption(Rs, "cFile") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cLabel showfldname='" + g_oPub.GetFldCaption(Rs, "cLabel") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cCheckOut showfldname='" + g_oPub.GetFldCaption(Rs, "cCheckOut") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cLicence showfldname='" + g_oPub.GetFldCaption(Rs, "cLicence") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        
        buf.Append ("<Inventory.iExpSaleRate showfldname='" + g_oPub.GetFldCaption(Rs, "iExpSaleRate") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        'buf.Append ("<Inventory.cOfferGrade showfldname='" + g_oPub.GetFldCaption(Rs, "cOfferGrade") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        'buf.Append ("<Inventory.iOfferRate showfldname='" + g_oPub.GetFldCaption(Rs, "iOfferRate") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        'buf.Append ("<Inventory.cPriceGroup showfldname='" + g_oPub.GetFldCaption(Rs, "cPriceGroup") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.CcurrencyName showfldname='" + g_oPub.GetFldCaption(Rs, "CcurrencyName") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cProduceAddress showfldname='" + g_oPub.GetFldCaption(Rs, "cProduceAddress") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.CproduceNation showfldname='" + g_oPub.GetFldCaption(Rs, "CproduceNation") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        
        buf.Append ("<Inventory.CEnterNo showfldname='" + g_oPub.GetFldCaption(Rs, "CEnterNo") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.CPackingType showfldname='" + g_oPub.GetFldCaption(Rs, "CPackingType") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.CEnglishName showfldname='" + g_oPub.GetFldCaption(Rs, "CEnglishName") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        'buf.Append ("<Inventory.BPropertyCheck showfldname='" + g_oPub.GetFldCaption(Rs, "BPropertyCheck") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        
        buf.Append ("<Inventory.CCommodity showfldname='" + g_oPub.GetFldCaption(Rs, "CCommodity") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        
        buf.Append ("<Inventory.CNotPatentName showfldname='" + g_oPub.GetFldCaption(Rs, "CNotPatentName") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bCheckBSATP showfldname='" + g_oPub.GetFldCaption(Rs, "bCheckBSATP") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cInvProjectCode showfldname='" + g_oPub.GetFldCaption(Rs, "cInvProjectCode") + "'  reftype='' cRefID='PA_REF_ATP_PA' bmulmodify='1' bBadStrException='0'/>")
    'End If
    'buf.Append ("<Inventory.bPromotSales showfldname='" + g_oPub.GetFldCaption(Rs, "bPromotSales") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.iPlanPolicy showfldname='" + g_oPub.GetFldCaption(Rs, "iPlanPolicy") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    ''�޸���Ҫ������������ֶ����ݣ������޸� 2005-03-11 GetFldCaption(Rs, "bROP") ' ROP��  bit 1  False"
    buf.Append ("<Inventory.bROP showfldname='" + g_oPub.GetFldCaption(Rs, "bROP") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iROPMethod showfldname='" + g_oPub.GetFldCaption(Rs, "iROPMethod") + "'  reftype='enum' cRefID='" + GetEnumString("0,1,2", iROPMethodItems) + "' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iBatchRule showfldname='" + g_oPub.GetFldCaption(Rs, "iBatchRule") + "'  reftype='enum' cRefID='" + GetEnumString("0,1,2,3,4,5", iBatchRuleItems) + "' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.fBatchIncrement showfldname='" + g_oPub.GetFldCaption(Rs, "fBatchIncrement") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.iAssureProvideDays showfldname='" + g_oPub.GetFldCaption(Rs, "iAssureProvideDays") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    '�޸���Ҫ������������ֶ����ݣ������޸� 2005-03-11
    'buf.Append ("<Inventory.iTestStyle showfldname='" + g_oPub.GetFldCaption(Rs, "iTestStyle") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.iDTMethod showfldname='" + g_oPub.GetFldCaption(Rs, "iDTMethod") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.fDTRate showfldname='" + g_oPub.GetFldCaption(Rs, "fDTRate") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.fDTNum showfldname='" + g_oPub.GetFldCaption(Rs, "fDTNum") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.iDTStyle showfldname='" + g_oPub.GetFldCaption(Rs, "iDTStyle") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    'buf.Append ("<Inventory.iQTMethod showfldname='" + g_oPub.GetFldCaption(Rs, "iQTMethod") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bPlanInv showfldname='" + g_oPub.GetFldCaption(Rs, "bPlanInv") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bProxyForeign showfldname='" + g_oPub.GetFldCaption(Rs, "bProxyForeign") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bATOModel showfldname='" + g_oPub.GetFldCaption(Rs, "bATOModel") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bCheckItem showfldname='" + g_oPub.GetFldCaption(Rs, "bCheckItem") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bPTOModel showfldname='" + g_oPub.GetFldCaption(Rs, "bPTOModel") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bEquipment showfldname='" + g_oPub.GetFldCaption(Rs, "bEquipment") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.bInvModel showfldname='" + g_oPub.GetFldCaption(Rs, "bInvModel") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bPrjMat showfldname='" + g_oPub.GetFldCaption(Rs, "bPrjMat") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bInvAsset showfldname='" + g_oPub.GetFldCaption(Rs, "bInvAsset") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    '�޸���Ҫ������������ֶ����ݣ������޸� 2005-03-11 GetFldCaption(Rs, "cMassUnit") ' �����ڵ�λ  smallint 2  True"
    'buf.Append ("<Inventory.cMassUnit showfldname='" + g_oPub.GetFldCaption(Rs, "cMassUnit") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fRetailPrice showfldname='" + g_oPub.GetFldCaption(Rs, "fRetailPrice") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    If g_bFactory = True Then
        buf.Append ("<Inventory.cInvDepCode showfldname='" + g_oPub.GetFldCaption(Rs, "cInvDepCode") + "'  reftype='ref' cRefID='Department_AA' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.iAlterAdvance showfldname='" + g_oPub.GetFldCaption(Rs, "iAlterAdvance") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.fAlterBaseNum showfldname='" + g_oPub.GetFldCaption(Rs, "fAlterBaseNum") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cPlanMethod showfldname='" + g_oPub.GetFldCaption(Rs, "cPlanMethod") + "'  reftype='enum' cRefID='R{#}N{##}R{#}N' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bMPS showfldname='" + g_oPub.GetFldCaption(Rs, "bMPS") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bBOMMain showfldname='" + g_oPub.GetFldCaption(Rs, "bBOMMain") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bBOMSub showfldname='" + g_oPub.GetFldCaption(Rs, "bBOMSub") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bProductBill showfldname='" + g_oPub.GetFldCaption(Rs, "bProductBill") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.iPlanTfDay showfldname='" + g_oPub.GetFldCaption(Rs, "iPlanTfDay") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.iOverlapDay showfldname='" + g_oPub.GetFldCaption(Rs, "iOverlapDay") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.fMaxSupply showfldname='" + g_oPub.GetFldCaption(Rs, "fMaxSupply") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.iCheckATP showfldname='" + g_oPub.GetFldCaption(Rs, "iCheckATP") + "'  reftype='enum' cRefID='" + GetEnumString("0,1", iCheckATPItems) + "' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.iinvatpid showfldname='" + g_oPub.GetFldCaption(Rs, "ATPCode") + "'  reftype='ref' cRefID='ATPRule_MM' cRetFld='ATPId' cShowFld='Description' bmulmodify='1' bBadStrException='0'/>")
    End If
    If g_bFactory = True Then
        buf.Append ("<Inventory.bRePlan showfldname='" + g_oPub.GetFldCaption(Rs, "bRePlan") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cSRPolicy showfldname='" + g_oPub.GetFldCaption(Rs, "cSRPolicy") + "'  reftype='enum' cRefID='PE{#}LP{##}PE{#}LP' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bBillUnite showfldname='" + g_oPub.GetFldCaption(Rs, "bBillUnite") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.iSupplyDay showfldname='" + g_oPub.GetFldCaption(Rs, "iSupplyDay") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<iRequireTrackStyle showfldname='" + g_oPub.GetFldCaption(Rs, "iRequireTrackStyle") + "'  reftype='enum' cRefID='" + GetEnumString("0,1,2,3", iRequireTrackStyleItems) + "' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<iBOMExpandUnitType showfldname='" + g_oPub.GetFldCaption(Rs, "iBOMExpandUnitType") + "'  reftype='enum' cRefID='" + GetEnumString("1,2", iBOMExpandUnitTypeItems) + "' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<iAcceptEarlyDays showfldname='" + g_oPub.GetFldCaption(Rs, "iAcceptEarlyDays") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<iAcceptDelayDays showfldname='" + g_oPub.GetFldCaption(Rs, "iAcceptDelayDays") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.fSupplyMulti showfldname='" + g_oPub.GetFldCaption(Rs, "fSupplyMulti") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.fMinSupply showfldname='" + g_oPub.GetFldCaption(Rs, "fMinSupply") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bCutMantissa showfldname='" + g_oPub.GetFldCaption(Rs, "bCutMantissa") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        '�������۸�����ר��
        If bTrackSaleBill = True Then
        buf.Append ("<Inventory.bTrackSaleBill showfldname='" + g_oPub.GetFldCaption(Rs, "bTrackSaleBill") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        End If
        buf.Append ("<bInvKeyPart showfldname='" + g_oPub.GetFldCaption(Rs, "bInvKeyPart") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    buf.Append ("<Inventory.fOrderUpLimit showfldname='" + g_oPub.GetFldCaption(Rs, "fOrderUpLimit") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    If g_bFactory = True Then
        buf.Append ("<Inventory.cInvPersonCode showfldname='" + g_oPub.GetFldCaption(Rs, "cInvPersonCode") + "'  reftype='ref' cRefID='Person_AA' bmulmodify='1' bBadStrException='0'/>")
        '�������ݱ���ID���������� GetFldCaption(Rs, "iInvTfId") ' ʱդ����  int 4  True"
        'buf.Append ("<Inventory.iInvTfId showfldname='" + g_oPub.GetFldCaption(Rs, "iInvTfId") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cEngineerFigNo showfldname='" + g_oPub.GetFldCaption(Rs, "cEngineerFigNo") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bInTotalCost showfldname='" + g_oPub.GetFldCaption(Rs, "bInTotalCost") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.iSupplyType showfldname='" + g_oPub.GetFldCaption(Rs, "iSupplyType") + "'  reftype='enum' cRefID='" + GetEnumString("0,1,2,3,4", iSupplyTypeItems) + "' bmulmodify='1' bBadStrException='0'/>")
    End If
    
'    buf.Append ("<Inventory.iDTLevel showfldname='" + g_oPub.GetFldCaption(Rs, "iDTLevel") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.cDTAQL AQL showfldname='" + g_oPub.GetFldCaption(Rs, "cDTAQL AQL") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.bPeriodDT showfldname='" + g_oPub.GetFldCaption(Rs, "bPeriodDT") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.cDTPeriod showfldname='" + g_oPub.GetFldCaption(Rs, "cDTPeriod") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.bOutInvDT showfldname='" + g_oPub.GetFldCaption(Rs, "bOutInvDT") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.bBackInvDT showfldname='" + g_oPub.GetFldCaption(Rs, "bBackInvDT") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.iEndDTStyle showfldname='" + g_oPub.GetFldCaption(Rs, "iEndDTStyle") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.bDTWarnInv showfldname='" + g_oPub.GetFldCaption(Rs, "bDTWarnInv") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
'    buf.Append ("<Inventory.fBackTaxRate showfldname='" + g_oPub.GetFldCaption(Rs, "fBackTaxRate") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fGrossW showfldname='" + g_oPub.GetFldCaption(Rs, "fGrossW") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fLength showfldname='" + g_oPub.GetFldCaption(Rs, "fLength") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fWidth showfldname='" + g_oPub.GetFldCaption(Rs, "fWidth") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.fHeight showfldname='" + g_oPub.GetFldCaption(Rs, "fHeight") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<Inventory.cPurPersonCode showfldname='" + g_oPub.GetFldCaption(Rs, "cPurPersonCode") + "'  reftype='ref' cRefID='Person_AA' bmulmodify='1' bBadStrException='0'/>")
    buf.Append ("<bPUQuota showfldname='" + g_oPub.GetFldCaption(Rs, "bPUQuota") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    If g_BShowMedicineTab870 = True Then
        buf.Append ("<Inventory.cPreparationType showfldname='" + g_oPub.GetFldCaption(Rs, "cPreparationType") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.CRegisterNo showfldname='" + g_oPub.GetFldCaption(Rs, "CRegisterNo") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bImportMedicine showfldname='" + g_oPub.GetFldCaption(Rs, "bImportMedicine") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bFirstBusiMedicine showfldname='" + g_oPub.GetFldCaption(Rs, "bFirstBusiMedicine") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.bSpecialties showfldname='" + g_oPub.GetFldCaption(Rs, "bSpecialties") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.IRecipeBatch showfldname='" + g_oPub.GetFldCaption(Rs, "IRecipeBatch") + "'  reftype='enum' cRefID='" + GetEnumString("0,1,2,3", iRecipeBatchItems) + "' bmulmodify='1' bBadStrException='0'/>")
    End If
    If g_bFactory = True Then
        buf.Append ("<Inventory.bForeExpland showfldname='" + g_oPub.GetFldCaption(Rs, "bForeExpland") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.cInvPlanCode showfldname='" + g_oPub.GetFldCaption(Rs, "cInvPlanCode") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.fConvertRate showfldname='" + g_oPub.GetFldCaption(Rs, "fConvertRate") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
        buf.Append ("<Inventory.dReplaceDate showfldname='" + g_oPub.GetFldCaption(Rs, "dReplaceDate") + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    End If
    Dim tRs As New ADODB.Recordset
    strSql = "select * from userdef where cClass='���'"
    Set Rs = SrvDB.OpenX(strSql)
    Dim cId As String
    For i = 1 To 16
        Set tRs = RsFilter(Rs, "CItem='�Զ�����" + CStr(i) + "'")
        sTemp = TxtValue(tRs!cItemName)
        If Len(sTemp) > 0 Then
            Select Case i
                Case 1 To 10
                    cId = TxtValue(tRs!cId)
                    buf.Append ("<cInvDefine" + CStr(i) + " showfldname='" + sTemp + "'  reftype='ref' cRefID='" + cId + "'  IsUserDefArch='1' bmulmodify='1' bBadStrException='0'/>")
                Case 11 To 12
                    buf.Append ("<cInvDefine" + CStr(i) + " showfldname='" + sTemp + "'  reftype='' cRefID='' cRetFld='' cShowFld='' bmulmodify='1' bBadStrException='0'/>")
                Case 13
                    g_CInvDefine13Dec = CInt(Val(TxtValue(tRs!iDecimalDigits)))
                    buf.Append ("<cInvDefine" + CStr(i) + " showfldname='" + sTemp + "'  reftype='decdgt'  decdgt='" + CStr(g_CInvDefine13Dec) + "' bmulmodify='1' bBadStrException='0'/>")
                Case 14
                    g_CInvDefine14Dec = CInt(Val(TxtValue(tRs!iDecimalDigits)))
                    buf.Append ("<cInvDefine" + CStr(i) + " showfldname='" + sTemp + "'  reftype='decdgt'  decdgt='" + CStr(g_CInvDefine14Dec) + "' bmulmodify='1' bBadStrException='0'/>")
                Case 15, 16
                    buf.Append ("<cInvDefine" + CStr(i) + " showfldname='" + sTemp + "'  reftype='date' cRefID='' cRetFld='' cShowFld='' bmulmodify='1' bBadStrException='0'/>")
            End Select
        End If
    Next i
    
    For i = 1 To 10
        Set tRs = RsFilter(Rs, "CItem='������" + CStr(i) + "'")
        sTemp = TxtValue(tRs!cItemName)
        buf.Append ("<bFree" + CStr(i) + " showfldname='" + sTemp + "'  reftype='' cRefID='' bmulmodify='1' bBadStrException='0'/>")
    Next i
    
    buf.Append ("</Inventory>")
    g_sXMLMulModify = buf.ToString()
    Set buf = Nothing

End Sub

'------------------------------------------------------------------
'���ܣ�������Ŀ�����ֵ��ȡ��Ŀ�ֶ���
'������RS����ȡ��Ŀ�����ݼ�
'       fldName���ֶ�����
'------------------------------------------------------------------
Private Function GetFldCaption(Rs As ADODB.Recordset, FldName As String) As String
    On Error GoTo Err_Info:
    Rs.Filter = "cFld='" + FldName + "'"
    GetFldCaption = Rs.Fields("cCaption").Value
    Exit Function
Err_Info:
    ShowMsg "û���ҵ��ֶ�����" + FldName
End Function

'-------------------------------------------
'���ܣ���ȡö�ٸ�ʽ��
'-------------------------------------------
Private Function GetStrEnumstring(DBVals As String, Captions As String) As String
    On Error GoTo Err_Info
    Dim arrFld() As String
    Dim arrCaption() As String
    arrFld = Split(DBVals, ",")
    arrCaption = Split(Captions, ",")
    GetStrEnumstring = GetArrEnumString(arrFld, arrCaption)
    Exit Function
Err_Info:
    ShowMsg Err.Description
End Function

'-------------------------------------------
'���ܣ���ȡö�ٸ�ʽ��
'-------------------------------------------
Private Function GetEnumString(DBVals As String, arrCaption() As String) As String
    On Error GoTo Err_Info
    Dim arrFld() As String
    arrFld = Split(DBVals, ",")
    If UBound(arrCaption) = LBound(arrCaption) Then
        arrCaption = arrFld
    End If
    GetEnumString = GetArrEnumString(arrFld, arrCaption)
    Exit Function
Err_Info:
    ShowMsg Err.Description
End Function

'-------------------------------------------
'���ܣ���ȡö�ٸ�ʽ��
'-------------------------------------------
Private Function GetArrEnumString(arrFld() As String, arrCaption() As String) As String
    On Error GoTo Err_Info
    Dim strDB As String
    Dim strCap As String
    Dim i As Integer
    Dim k As Integer
    k = LBound(arrFld)
    For i = LBound(arrCaption) To UBound(arrCaption)
        strDB = strDB + arrFld(k) + "{#}"
        strCap = strCap + arrCaption(i) + "{#}"
        k = k + 1
    Next i
    GetArrEnumString = Left(strDB, Len(strDB) - 3) + "{##}" + Left(strCap, Len(strCap) - 3)
    Exit Function
Err_Info:
    ShowMsg "database field count is not match display field"
End Function

'---------------------------------------
'���ܣ����˿��ַ���
'������Var�����˱���
'---------------------------------------
Private Function TxtValue(var As Variant) As String
    On Error GoTo Err_Info
    TxtValue = IIf(IsNull(var), "", var)
    Exit Function
Err_Info:
    TxtValue = "" '���ڿ���û�����ݵĿ��ƣ�����Rst!Name��Rstû������
End Function

'---------------------------------------
'���ܣ��������ݼ�
'������Rs����Ҫ���˵����ݼ�
'     sFilter����������
'---------------------------------------
Private Function RsFilter(ByVal Rs As ADODB.Recordset, sFilter As String) As ADODB.Recordset
    Rs.Filter = sFilter
    Set RsFilter = Rs
End Function
