VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsOtherInEai"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

'处理库存模块调拨生成的其他入库单的EAI导出

Option Explicit

Dim mLogin As U8Login.clsLogin
Dim m_conn As ADODB.Connection
Dim oVoucherCo As USERPCO.VoucherCO
Dim oInvObj As USERPCO.InventoryCO
Dim m_errDom As DOMDocument
Dim sRootTag As String
Dim oDefSet  As Object

Public gObjRef As Object

Public Function Init(oLogin As Object, conn As ADODB.Connection, errDom As DOMDocument, ByVal sTag As String, sErr As String) As Boolean
  On Error GoTo errhandle
  Dim errMsg As String
  Init = True
  Set mLogin = oLogin
  If oVoucherCo Is Nothing Then
     Set oVoucherCo = New USERPCO.VoucherCO
     oVoucherCo.IniLogin oLogin, errMsg
  End If
  If errMsg <> "" Then
      Err.Raise vbObjectError + 100, , errMsg & vbCrLf
  End If
  If oInvObj Is Nothing Then
      Set oInvObj = New USERPCO.InventoryCO
      oInvObj.IniLogin oLogin, errMsg
  End If
  If errMsg <> "" Then
     Err.Raise vbObjectError + 100, , errMsg & vbCrLf
  End If
  sRootTag = sTag
  Set m_conn = conn
  Set m_errDom = errDom
  Exit Function
errhandle:
  Init = False
  sErr = Err.Description
  
End Function


Public Sub AddProc(ByVal EleLst As IXMLDOMNodeList, ByRef sRetXml As String, ByVal sRoot As String)
    On Error GoTo Err_log
    Dim TmpEle As IXMLDOMElement

    For Each TmpEle In EleLst
        Call AddSingle(TmpEle, sRoot)
    Next
    sRetXml = m_errDom.xml
    Exit Sub
Err_log:
    Call ErrDomAppendChild(m_errDom, "", 999, Err.Description)
    sRetXml = m_errDom.xml
End Sub

'**********************
'**********************
Private Function AddSingle(ByVal ele As IXMLDOMElement, ByVal sRoot As String) As Boolean

    Dim rsHeader As New ADODB.Recordset
    Dim rsBody As New ADODB.Recordset
    Dim eleHeader As IXMLDOMElement
    Dim eleBody As IXMLDOMElement
    Dim sSOCode As String
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    Dim sRet As String
    Dim nd As IXMLDOMElement

    Dim num As Double
    Dim quantity As Double
    Dim price As Double
    Dim cost As Double
    Dim ddate As String

    Dim attr As IXMLDOMAttribute
    Dim bBegin As Boolean
    
    Dim bBodyChange As Boolean
    
    bBodyChange = False
    
    bBegin = False
    'csl-------------------------

    Set eleHeader = ele.selectSingleNode("header")
    If eleHeader Is Nothing Then

        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00007")
        GoTo csl
    End If
    
    Dim svouchtype As String
    
    svouchtype = GetNodeValue(eleHeader.selectSingleNode("vouchtype"))
    
    'sVouchtype = GetElementValue(eleHeader, "vouchtype")
    
    '处理零售上传销售出库单
    If svouchtype = "32" Then
       handleSaleOut ele, sRet
       GoTo csl
    End If
    
    
    
    sSOCode = GetElementValue(eleHeader, "code")
    
    
    Set eleBody = ele.selectSingleNode("body")
    If eleBody Is Nothing Then
'Result:Row=230 Col=14  Content="没有body节点"  ID=37648d46-7b24-4561-9480-5a8e300c40cf
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00008")
        GoTo csl
    End If


    Dim entry As IXMLDOMElement
    For Each entry In ele.selectNodes("body/entry")
        
        
        For Each nd In entry.selectNodes("materialfee")
            entry.removeChild nd
        Next
        
        For Each nd In entry.selectNodes("processcost")
           entry.removeChild nd
        Next
        
        For Each nd In entry.selectNodes("processfee")
            entry.removeChild nd
        Next
        
       '*************************
     
    Next
    

    Dim sQueryH As String
    Dim sQueryB As String

    sQueryH = "kcotherinh"
    sQueryB = "kcotherinb"

    rsHeader.CursorLocation = adUseClient
    rsBody.CursorLocation = adUseClient

    rsHeader.Open "Select * ,1 as beai,'M' as editprop from " & sQueryH & " where 1=2 ", m_conn, adOpenStatic, adLockOptimistic

    rsBody.Open "Select *,'M' as editprop From " & sQueryB & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    

    Dim oDomH As DOMDocument
    Dim oDomB As DOMDocument
    Set oDomH = New DOMDocument
    Set oDomB = New DOMDocument
    rsHeader.save oDomH, adPersistXML
    rsBody.save oDomB, adPersistXML

    Call EXmlToRs.XmlToDomHeader(ele.xml, sRootTag, oDomH, rsHeader, "StoreInXmlRs.Xml")
    Call EXmlToRs.XmlToDomBody(ele.xml, sRootTag, oDomB, rsBody, "StoreInXmlRs.Xml")

    Set rsHeader = Nothing
    Set rsBody = Nothing
    Set oDomH = RecordSetToDom(DomToRecordSet(oDomH))
    Set oDomB = RecordSetToDom(DomToRecordSet(oDomB))
    '调用CO接口：INSERT导入单据
    'Dim oVoucher As USERPCO.VoucherCO

    'Set oVoucher = New USERPCO.VoucherCO
    Dim eleTmp As IXMLDOMElement
    Set eleTmp = oDomH.selectSingleNode("//z:row")
'    '清除审核人和审核日期
'    eleTmp.setAttribute "cverifyperson", ""
'    eleTmp.setAttribute "dverifydate", ""
'    eleTmp.setAttribute "vt_id", GetDefaultVtId("08")
'    eleTmp.setAttribute "cmaker", mLogin.cUserId
'    eleTmp.setAttribute "ccloser", ""
'   '取默认出入库类别
'    eleTmp.setAttribute "cirdcode", oDefSet.getDefData("incode1", m_conn, "ST")
'    eleTmp.setAttribute "cordcode", oDefSet.getDefData("ordcode1", m_conn, "ST")
    eleTmp.setAttribute "beai", 1
    eleTmp.setAttribute "editprop", "M"
'    eleTmp.setAttribute "ctvcode", SetBillSerial(oVoucherCo.Login, TypeToSys("08"), oDomH, False)
'
'    eleTmp.setAttribute "csource", "1" '库存
'    eleTmp.setAttribute "id", 0


'    If Not oVoucher.IniLogin(mLogin, sRet) Then
'        GoTo csl
'    End If


'    For Each nd In oDomH.selectNodes("//z:row")
'        Set attr = nd.selectSingleNode("@dtvdate")
'        If Not attr Is Nothing Then
'            If Not (IsDate(attr.Value) Or attr.Value = "") Then
''Result:Row=490 Col=29  Content="的单据日期不是合法的日期！"    ID=231f94af-09e2-4a41-bdec-e5bbfc54d930
'                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00019", Array(sRet))
'                GoTo csl
'            End If
'        Else
''Result:Row=495 Col=25  Content="的单据日期dDate节点不存在！"   ID=66d28d92-620d-4a90-b4ea-ce5b5f0e6053
'            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00020", Array(sRet))
'            GoTo csl
'        End If
'    Next
    
    Dim ndOriginal As IXMLDOMElement
    Dim oOriginalDomH As DOMDocument
    Dim oOriginalDomB As DOMDocument
    Dim oOriginalDomP As DOMDocument
    oVoucherCo.Load "08", "id=" & eleTmp.getAttribute("id"), oOriginalDomH, oOriginalDomB, oOriginalDomP, sRet
    If sRet <> "" Then
        GoTo csl
    End If
    
    
    Dim oDic As New Dictionary '记录合计修改数量，autoid
    Dim sSql As String '创建临时表记录autoid,iquantity,cposition，用于批量回写货位
    Dim fNum As Double
    Dim sPosCode As String
    Dim sAutoid As String
    
    sSql = "if exists(select 1  where isnull(object_id(N'tempdb..#lseditpos'),0)<>0 ) drop table #lseditpos " & vbCrLf
    sSql = sSql + " select autoid,inum,cposition into #lseditpos from rdrecords with (nolock) where 1=2 "
    m_conn.Execute sSql
    
    Dim bPos As Boolean
    bPos = False
    
    
    For Each nd In oDomB.selectNodes("//z:row")
        sAutoid = nd.getAttribute("autoid")
        If Not IsNull(nd.getAttribute("iquantity")) Then
            fNum = Val(nd.getAttribute("iquantity"))
        Else
            fNum = 0
        End If
        If Not IsNull(nd.getAttribute("cposition")) Then
            sPosCode = nd.getAttribute("cposition")
            
        Else
            sPosCode = ""
        End If
        If oDic.Exists(sAutoid) Then
           oDic.Item(sAutoid) = Val(oDic.Item(sAutoid)) + fNum
        Else
            oDic.Add sAutoid, fNum
        End If
        
        '插入货位临时表
        If sPosCode <> "" Then
            bPos = True
            sSql = "insert into #lseditpos(autoid,inum,cposition) values (" & sAutoid & "," & fNum & ",N'" & sPosCode & "') "
            m_conn.Execute sSql
        End If
        
        '-----------------------------------------------------------
        For Each ndOriginal In oOriginalDomB.selectNodes("//z:row[@autoid=" & nd.getAttribute("autoid") & "]")
            ndOriginal.setAttribute "editprop", "M"
            'ndOriginal.setAttribute "iquantity", nd.getAttribute("iquantity")
            If Not IsNull(nd.getAttribute("cdefine33")) Then
                ndOriginal.setAttribute "cdefine33", nd.getAttribute("cdefine33")
            Else
                ndOriginal.setAttribute "cdefine33", ""
            End If
        Next
    Next

      Dim iRow As Long
      Dim eleRow As IXMLDOMElement
      Dim tmpDomBody As DOMDocument
      Dim oInvVo As Object
      Dim errMsg As String
      iRow = 0
      Dim eleTmpBody As IXMLDOMElement
      For Each eleRow In oOriginalDomB.selectNodes("//z:row")
         iRow = iRow + 1
         sAutoid = eleRow.getAttribute("autoid")
         If oDic.Exists(sAutoid) Then
                Set tmpDomBody = GetLineDom(oOriginalDomB, iRow)
                If Not oVoucherCo.CheckBody("08", nUpdate, 1, "cinvcode", tmpDomBody, errMsg, oOriginalDomH) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                End If
                Set oInvVo = CreateObject("userpvo.Inventory")
                Set eleTmpBody = tmpDomBody.selectSingleNode("//z:row")
                If oInvObj.Load(eleTmpBody.getAttribute("cinvcode"), oInvVo, errMsg) Then
                      fNum = CDbl(oDic.Item(sAutoid))
                      If oInvVo.GroupType = 0 Then '0:无计量;1:固定
                         eleTmpBody.setAttribute "iquantity", fNum
                         If Not oVoucherCo.CheckBody("08", nUpdate, 1, "iquantity", tmpDomBody, errMsg, oOriginalDomH) Then
                             Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                         End If
                      Else 'If oInvVo.GroupType = 1 Then
                         eleTmpBody.setAttribute "cassunit", GetLSUnit(eleTmpBody.getAttribute("cinvcode")) 'eleRow.getAttribute("cassunit")
                         If Not oVoucherCo.CheckBody("08", nUpdate, 1, "cassunit", tmpDomBody, errMsg, oOriginalDomH) Then
                             Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                         End If
                         Set eleTmpBody = tmpDomBody.selectSingleNode("//z:row")
                         eleTmpBody.setAttribute "inum", fNum
                         If Not oVoucherCo.CheckBody("08", nUpdate, 1, "inum", tmpDomBody, errMsg, oOriginalDomH) Then
                             Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                         End If
                      End If
                Else
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                End If
                Set ndOriginal = oOriginalDomB.selectNodes("//z:row").Item(iRow - 1)
                setNodeValue tmpDomBody.selectSingleNode("//z:row"), ndOriginal
         End If
      Next
   
      
    Set oDomH = oOriginalDomH
    Set oDomB = oOriginalDomB
    
    bBodyChange = checkQuantityChange(oDomB)

    sRet = ""
    m_conn.BeginTrans
    bBegin = True
    Dim oDomMsg As DOMDocument
    Set oDomMsg = New DOMDocument
    
    If bBodyChange Then
        Call oVoucherCo.Update("08", oDomH, oDomB, Nothing, sRet, m_conn, oDomMsg, , False)
        If sRet = "" Then
            sRet = GetRetString(oDomMsg)
        End If
    End If
    
'    '用于u890,直接加入invposition中
    If bPos Then
       sSql = "delete invposition where rdsid in (select autoid from #lseditpos  ) and isnull(csource,'') =N'' "
       sSql = sSql & "insert into invposition(rdsid,rdid,cwhcode,cposcode,cinvcode,cbatch,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,"
       sSql = sSql & "cfree8,cfree9,cfree10,iquantity,inum,chandler,ddate,brdflag,csource,cassunit,cbvencode,itrackid,dmadedate,dvdate,imassdate,cmassunit,"
       sSql = sSql & "cvmivencode,iExpiratDateCalcu ,cExpirationdate,dExpirationdate) "
       sSql = sSql & "select b.autoid,h.id,h.cwhcode,a.cposition,b.cinvcode,b.cbatch,b.cfree1,b.cfree2,b.cfree3,b.cfree4,b.cfree5,b.cfree6,"
       sSql = sSql & "b.cfree7,b.cfree8,b.cfree9,b.cfree10,case when i.igrouptype=0 then a.inum else a.inum * com.ichangrate end,"
       sSql = sSql & "case when i.igrouptype=0 then null else a.inum end, N'" & mLogin.cUserId & "',N'" & mLogin.CurDate & "',1,null,I.cshopunit,"
       sSql = sSql & "b.cbvencode,case when isnull(i.btrack,0)=1 then b.autoid else null end,b.dMadeDate,b.dvdate,b.imassdate,b.cmassunit,b.cvmivencode,"
       sSql = sSql & " iExpiratDateCalcu ,cExpirationdate,dExpirationdate "
       sSql = sSql & " from #lseditpos a inner join rdrecords b with (nolock)  on a.autoid = b.autoid  "
       sSql = sSql & "      inner join rdrecord h with (nolock) on h.id = b.id  left join inventory i  with (nolock) on b.cinvcode = i.cinvcode "
       sSql = sSql & "      left join ComputationUnit com  with (nolock) on i.cshopunit = com.ccomunitcode "
       sSql = sSql & "      left join position with (nolock) on position.cposcode=a.cposition "

       sSql = sSql & "where h.cwhcode =position.cwhcode and isnull(position.bposend,0) =1 "

       sSql = sSql & " update b set b.cposition =case when isnull(a.count,0) =1 then a.cposition else '' end  from rdrecords b  "
       sSql = sSql & " inner join (select autoid,max(cposition) as cposition,count(autoid) as count from #lseditpos group by autoid ) a "
       sSql = sSql & " on b.autoid = a.autoid "
        m_conn.Execute sSql

    End If
    
    
    sSql = "if exists(select 1  where isnull(object_id(N'tempdb..#lseditpos'),0)<>0 ) drop table #lseditpos " & vbCrLf
    
    m_conn.Execute sSql
    
    If sRet = "" Then
        
        If IsNull(eleTmp.getAttribute("ddate")) Then
            oVoucherCo.Login.AddOtherInfoAttr "LsVerifyDate", oVoucherCo.Login.LoginDate
        Else
            oVoucherCo.Login.AddOtherInfoAttr "LsVerifyDate", eleTmp.getAttribute("ddate")
        End If
        If oVoucherCo.Verify("08", eleTmp.getAttribute("id"), sRet, m_conn, , oDomMsg, , False, True) = True Then
            sRet = ""
        End If
        oVoucherCo.Login.RemoveOtherInfoItem "LsVerifyDate"
        
    End If

    If Not oDomH Is Nothing Then Set oDomH = Nothing
    If Not oDomB Is Nothing Then Set oDomB = Nothing
    If Not EXmlToRs Is Nothing Then Set EXmlToRs = Nothing
csl:
    If sRet = "" Then
        If bBegin Then
            m_conn.CommitTrans
        End If
        Call ErrDomAppendChild(m_errDom, sSOCode, 0, "ok")
        Exit Function
    Else
        If bBegin Then
            m_conn.RollbackTrans
        End If
        Call ErrDomAppendChild(m_errDom, sSOCode, 101, sRet)
        Exit Function
    End If
    AddSingle = True
'Call TraceOut(PROC_SIG)
ExitFunction:
  Exit Function
Error_General_Handler:
  AddSingle = False
  GoTo ExitFunction
End Function

Private Sub Class_Initialize()
  Set oDefSet = CreateObject("U8SCMImpDefValSet.clsSCMImpDefValSet")
End Sub

Private Sub Class_Terminate()
    If Not (oDefSet Is Nothing) Then
     Set oDefSet = Nothing
  End If
End Sub
'Private Function GetDefaultVtId(svouchtype As String) As String
'   Dim rs As New ADODB.Recordset
'   rs.CursorLocation = adUseClient
'   Dim sRet As String
'   On Error GoTo errhandle
'   If oVoucherCo.GetVT_ID(svouchtype, rs, sRet, 0) Then
'      If rs.EOF And rs.BOF Then
'         'Result:Row=461 Col=29  Content="的取缺省模板时失败！"  ID=0a23b92e-6c08-4c5f-836a-06ac66bb97f5
'         sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00016", Array(sRet))
'         Err.Raise vbObjectError + 100, , sRet & vbCrLf
'      Else
'         GetDefaultVtId = rs("vt_id")
'      End If
'   End If
'   Exit Function
'errhandle:
'   GetDefaultVtId = "0"
'End Function

Private Function GetRetString(dom As DOMDocument) As String
    Dim el As IXMLDOMElement
    Dim nd As IXMLDOMElement
    Dim sRet As String

    Set el = dom.selectSingleNode("//zeroout")
    If Not el Is Nothing Then
        For Each nd In el.selectNodes("z:row")
'Result:Row=958 Col=25  Content="存货"  ID=b6b870a3-1148-4975-8465-411412ad24ef
'Result:Row=959 Col=62  Content="现存量不足;"   ID=5f1a06dc-c714-45bf-acc8-f4bd447d9c46
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00086", Array(sRet, nd.getAttribute("cinvcode")))
        Next
    End If

    Set el = dom.selectSingleNode("//itemcheck")
    If Not el Is Nothing Then
        For Each nd In el.selectNodes("z:row")
'Result:Row=967 Col=25  Content="存货[" ID=8d0118f3-b7ea-4362-aaf6-4f797926fc4a
'Result:Row=968 Col=63  Content="]项目预算检查失败;"    ID=7ff821ba-80b4-4a0a-af9f-c6ec8daa3eea
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00088", Array(sRet, nd.getAttribute("cinvcode")))
        Next
    End If

    GetRetString = sRet
End Function


'*****************************
Public Function QueryProc(ByVal eleList As IXMLDOMNodeList, ByRef sRetXml As String) As Boolean
    Dim rs As New Recordset
    Dim rsDetail As New Recordset
    Dim dom As New DOMDocument
    Dim sql As String
    Dim el As IXMLDOMElement
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    Dim sExchRate As String
    dom.loadXML sRetXml
    
    Dim bUnModifyFlag As Boolean ' 是否更新标识
    
    bUnModifyFlag = False
    
    Dim oFlagEle As IXMLDOMElement
    
    Set oFlagEle = dom.selectSingleNode("//" & dom.documentElement.getAttribute("roottag"))
    If Not oFlagEle Is Nothing Then
        If Not IsNull(oFlagEle.getAttribute("unmodify")) Then
           bUnModifyFlag = IIf(LCase(GetAttrValue(oFlagEle, "unmodify")) = "y", True, False)
        End If
    End If
    
    
    dom.documentElement.Text = ""
    
    '临时保存DOM用
    Dim tempDom As New DOMDocument
    tempDom.loadXML sRetXml
    tempDom.documentElement.Text = ""
    '首先判断是否需要分页
    Dim paginate As Long
    Dim counter As Long '计数器
    Dim lIndex As Long  '导出第几页
    Dim sumCount As Long '记录的总数
    
    paginate = CLng(GetAttrValue(dom.documentElement, "paginate"))
    
    
    sql = " select 0 as bomfirst,0 as bpufirst,ID,bRdFlag,cVouchType,cBusType,cSource,cBusCode,cwhcode_ as cWhCode,dDate,cCode,cRdCode,cDepCode,cPersonCode,cVenCode,iMQuantity,"
    sql = sql & "dARVDate,cChkCode,dChkDate,cChkPerson,VT_ID,cHandler,cMemo,cMaker,chandler,cDefine1,cDefine2,cDefine3,cDefine4,cDefine5,cDefine6,cDefine7,"
    sql = sql & "cDefine8,cDefine9,cDefine10,cDefine11,cDefine12,cDefine13,cDefine14,cDefine15,cDefine16,dVeriDate,null as cptcode,null as cstcode,"
    sql = sql & "null as ccuscode,null as cordercode,null as carvcode,null as cbillcode,null as cdlcode,null as cprobatch,null as itaxrate,null as cexch_name,"
    sql = sql & "null as iexchrate,null as idiscounttaxtype,null as ccusperson,null as ccusphone,null as ccushand,null as ccusaddress,null as contactphone,"
    sql = sql & "null as contactmobile,null as cdeliverunit,null as ccontactname,null as cofficephone,null as cmobilephone,null as cpsnophone,null as cpsnmobilephone,"
    sql = sql & "null as cshipaddress,null as caddcode,null as cvenpuomprotocol,null as dcreditstart,null as icreditperiod,null as dgatheringdate, 0 as bcredit ,csourcels,csourcecodels  from KCOtherInH inner join (select cwhcode as cwhcode_,cbuscode as cbuscode_,chandler as chandler_ from rdrecord where brdflag=0 "
    sql = sql & "and cvouchtype='09' and cbustype='调拨出库' ) o on kcotherinh.cbuscode=o.cbuscode_  "
    sql = sql & GetQueryCondition(eleList, m_conn)
    rs.CursorLocation = adUseClient
    rsDetail.CursorLocation = adUseClient
    rs.Open sql, m_conn, adOpenStatic, adLockReadOnly
    
    If rs.RecordCount > 0 Then
        If paginate > 0 Then
            '取得页的总数
            Dim sumSql As String
            Dim lPageCount As Long
           
            If Not rs.EOF Then
               sumCount = rs.RecordCount
            End If
            If sumCount Mod paginate = 0 Then
                lPageCount = sumCount / paginate
            Else
                 lPageCount = Int(sumCount / paginate) + 1
            End If
            '定义计数器
            counter = 1
            lIndex = 1
            rs.MoveFirst
        End If
    End If
    
    
    While Not rs.EOF
        Set el = dom.createElement(dom.documentElement.getAttribute("roottag"))
        Call EXmlToRs.RStoXmlHead(el, "StoreInXmlRs.Xml", rs)
        
        sql = "select null as iSBsID,null as iPOsID,null as iDLsID,null as iEnsID,null as iOriTaxCost,null as iOriCost,null as iOriMoney,null as iOriTaxPrice,null as iOriSum,null as iTaxRate,null as iTaxPrice,null as iSum," & _
              " null as imaterialfee,null as  iprocesscost,null as  iprocessfee,null as dmsdate,* ,(case when (i.igrouptype=0 or isnull(i.cshopunit,N'')=N'') then kc.iquantity " & _
              "                when i.igrouptype=1 then (kc.iquantity/unit.ichangrate) " & _
              "                when i.igrouptype=2 then ( case when i.ccomunitcode=isnull(i.cshopunit,N'') then kc.iquantity  else kc.inum end) " & _
              "           end) as lsqty  from  KCOtherInB kc inner join inventory i on kc.cinvcode = i.cinvcode left outer join ComputationUnit unit on i.cshopunit=unit.ccomunitcode where id= " & rs("id")
        rsDetail.Open sql, m_conn, adOpenStatic, adLockBatchOptimistic
        If rsDetail.RecordCount > 0 Then
           rsDetail.MoveFirst
           While Not rsDetail.EOF
                rsDetail.fields("iquantity") = rsDetail.fields("lsqty")
                rsDetail.MoveNext
           Wend
           rsDetail.MoveFirst
        End If
        'rsDetail.save "c:\st" & Format(Now, "yyyymmddhhmmss") & rs("id") & ".xml", adPersistXML
        Call EXmlToRs.RStoXmlBody(el, "StoreInXmlRs.Xml", rsDetail)
        rsDetail.Close
        dom.documentElement.appendChild el
        
        '处理多页导出
        If paginate > 0 Then
            If counter = paginate Then
                gObjRef.ProcessExport dom.xml, lIndex, lPageCount
                '清空Dom
                Set dom = Nothing
                Set dom = New DOMDocument
                dom.loadXML tempDom.xml
                
                lIndex = lIndex + 1
                counter = 0
            Else
                If (lIndex = lPageCount) And (counter = sumCount Mod paginate) Then
                    gObjRef.ProcessExport dom.xml, lIndex, lPageCount
                End If
            End If
            counter = counter + 1
        End If
        '*****************************
        If bUnModifyFlag = False Then
            m_conn.Execute "update Rdrecord set bIsLsQuery=1 where id= " & rs("id")
        End If

        rs.MoveNext
    Wend
    rs.Close
    Set rs = Nothing
    Set rsDetail = Nothing
    
    Dim oTagEle As IXMLDOMElement
    For Each oTagEle In dom.selectNodes("//" & dom.documentElement.getAttribute("roottag"))
        oTagEle.setAttribute "unmodify", "y"
    Next
    
    sRetXml = dom.xml
End Function

Private Function GetQueryCondition(eleList As IXMLDOMNodeList, ByRef conn As Connection) As String
'================================================================================
On Error GoTo Error_General_Handler:
Const PROC_SIG As String = "clsInOut:GetQueryCondition"
'Call TraceIn(PROC_SIG)
    Dim rs As New Recordset
    Dim ele As IXMLDOMElement
    Dim fld As ADODB.Field
    Dim where As String
    rs.Open "select * from KCOtherInH where 1>1", conn, adOpenForwardOnly, adLockReadOnly
    where = ""
    Dim i As Integer
    i = 1
    Dim sUftsWhere As String
    sUftsWhere = ""
    Dim j As Integer
    Dim lEleLen As Long
    j = 1
    lEleLen = 0
    For Each ele In eleList
        Set fld = rs(GetAttrValue(ele, "name"))
        If UCase(fld.Name) = "UFTS" Then
            lEleLen = lEleLen + 1
        End If
    Next
    
    For Each ele In eleList
        Set fld = rs(GetAttrValue(ele, "name"))
        If Not IsNull(fld) Then
            '单据的EAI后台服务在拼条件时需要针对时间戳(平台后台默认设置的条件)条件特殊处理——和其他条件用括号分离开，形式为：（时间戳条件） and（界面设置的其他条件）。
            If UCase(fld.Name) <> "UFTS" Then
                where = where & fld.Name & GetAttrValue(ele, "operation")
                Select Case fld.Type
                    Case adBSTR, adDate, adDBDate, adDBTime, adDBTimeStamp, adLongVarChar, adLongVarBinary, adBSTR, adLongVarChar, adVarChar, adVarWChar, adWChar
                        where = where & "N'" & GetAttrValue(ele, "value") & "'"
                    Case Else
                        where = where & GetAttrValue(ele, "value")
                End Select
                If i < eleList.length Then
                    where = where & " " & GetAttrValue(ele, "logic") & " "
                End If
                i = i + 1
            Else
                where = where & fld.Name & GetAttrValue(ele, "operation") & " convert(Char, convert(Money, " & GetAttrValue(ele, "value") & "), 2)"
                If i < eleList.length Then
                    where = where & " " & GetAttrValue(ele, "logic") & " "
                End If
                i = i + 1

            End If
        End If
    Next
    Set rs = Nothing
  
    GetQueryCondition = " where " & IIf(where <> "", " (" & where & ")", "1=1")
    
    GetQueryCondition = GetQueryCondition & " and (" & "cbustype = N'调拨入库' and isnull(bIsLsQuery,0)=0 and isnull(cHandler,N'')=N'' and " & IIf(oVoucherCo.Login.Account.OtherInCheck, " isnull(chandler_ ,'')<>'' ", "1>1") & ")"
    
    '单据的EAI后台服务在拼条件时需要针对时间戳条件特殊处理——和其他条件用括号分离开，形式为：（时间戳条件） and（界面设置的其他条件）。
    If sUftsWhere <> "" Then
        GetQueryCondition = GetQueryCondition & " and (" & sUftsWhere & ")"
    End If
    
    Exit Function
'Call TraceOut(PROC_SIG)
ExitFunction:
  Exit Function
Error_General_Handler:
  GetQueryCondition = ""
  GoTo ExitFunction
End Function

Private Function GetLSUnit(ByVal sInvcode As String) As String
   Dim sSql As String
   Dim recd As New ADODB.Recordset
   recd.CursorLocation = adUseClient
   sSql = " select cshopunit from inventory where cinvcode=N'" & sInvcode & "'"
   recd.Open sSql, m_conn, adOpenDynamic, adLockOptimistic
   If Not recd.EOF And Not recd.BOF Then
      GetLSUnit = recd.fields("cshopunit")
   Else
      GetLSUnit = ""
   End If
End Function


Private Function GetNodeValue(oEle As IXMLDOMNode) As String
    On Error Resume Next
    Dim v As Variant
    
     
    If oEle Is Nothing Then
        v = ""
    Else
        v = oEle.Text
        If IsNull(v) Then
           v = ""
        End If
    End If
    
    GetNodeValue = CStr(v)
End Function


Private Function checkQuantityChange(oDomB As DOMDocument) As Boolean
    Dim eleTmp As IXMLDOMElement
        
    DropTable m_conn, "#steaitmpForLs"
    
    Dim sSql As String
    
    m_conn.Execute "select autoid,iquantity into #steaitmpForLs from rdrecords with (nolock) where 1=2 "
    
    For Each eleTmp In oDomB.selectNodes("//z:row")
        sSql = " insert into #steaitmpForLs (autoid,iquantity) values (" & CStr(eleTmp.getAttribute("autoid")) & "," & CStr(eleTmp.getAttribute("iquantity")) & ")"
        m_conn.Execute sSql
    Next
    
    Dim oRd As New ADODB.Recordset
    oRd.CursorLocation = adUseClient
    
    sSql = " select * from #steaitmpForLs a inner join rdrecords b with (nolock) on a.autoid = b.autoid where abs(convert(decimal(38,6),isnull(a.iquantity,0) - isnull(b.iquantity,0)))>0.000001"
    oRd.Open sSql, m_conn, adOpenDynamic, adLockOptimistic
    If oRd.RecordCount > 0 Then
        checkQuantityChange = True
    Else
        checkQuantityChange = False
    End If
    
    Set oRd = Nothing
    
    DropTable m_conn, "#steaitmpForLs"
End Function



Private Sub handleSaleOut(oEle As IXMLDOMElement, ByRef sMsgErr As String)
    
    
    On Error GoTo errhandle
    sMsgErr = ""
    
    
    Dim oDefSet  As Object 'U8SCMImpDefValSet.clsSCMImpDefValSet
    Set oDefSet = CreateObject("U8SCMImpDefValSet.clsSCMImpDefValSet")
    
    Dim sDefineName As String
    sDefineName = LCase(oDefSet.getDefData("kcsaleoutqtydefine", m_conn, "ST"))
    If sDefineName = "" Then
       sDefineName = "cdefine22"
    End If
    Set oDefSet = Nothing
    
    Dim entry As IXMLDOMElement
    Dim oNode As IXMLDOMNode
    
    Dim sAutoid As String
    Dim sQty As String
    Dim sSql As String
    
    For Each entry In oEle.selectNodes("body/entry")
        Set oNode = entry.selectSingleNode("autoid")
        sAutoid = Val(GetNodeValue(oNode))
        Set oNode = entry.selectSingleNode("quantity")
        sQty = Val(GetNodeValue(oNode))
        If sAutoid = "0" Then
           sMsgErr = "销售出库单子表autoid不合法!"
           Exit Sub
        End If
        If sSql = "" Then
            sSql = "update a set " & sDefineName & " =case when isnull(i.igrouptype,0)=0 then " & sQty & " else  a.iinvexchrate * " & sQty & " end  from rdrecords a left join inventory i on a.cinvcode =i.cinvcode where a.autoid =" & sAutoid & " " & vbCrLf
        Else
            sSql = sSql & "update a set " & sDefineName & " =case when isnull(i.igrouptype,0)=0 then " & sQty & " else  a.iinvexchrate * " & sQty & " end  from rdrecords a left join inventory i on a.cinvcode =i.cinvcode where a.autoid =" & sAutoid & " " & vbCrLf
        End If
    Next
    
    If sSql <> "" Then
        m_conn.Execute sSql
    End If
    
    Exit Sub
    
errhandle:
   sMsgErr = VBA.Err.Description & vbCrLf & "零售修改销售出库单失败!"
   
End Sub

