VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsSaleOutEai"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

'处理库存模块销售出库单的EAI导出

Option Explicit

Dim mLogin As U8Login.clsLogin
Dim m_conn As ADODB.Connection
Dim oVoucherCo As USERPCO.VoucherCO
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


'Public Sub AddProc(ByVal EleLst As IXMLDOMNodeList, ByRef sRetXml As String, ByVal sRoot As String)
'    On Error GoTo Err_log
'    Dim TmpEle As IXMLDOMElement
'
'    For Each TmpEle In EleLst
'        Call AddSingle(TmpEle, sRoot)
'    Next
'    sRetXml = m_errDom.xml
'    Exit Sub
'Err_log:
'    Call ErrDomAppendChild(m_errDom, "", 999, Err.Description)
'    sRetXml = m_errDom.xml
'End Sub
'
''**********************
'Private Function AddSingle(ByVal ele As IXMLDOMElement, ByVal sRoot As String) As Boolean
'
'    Dim rsHeader As New ADODB.Recordset
'    Dim rsBody As New ADODB.Recordset
'    Dim eleHeader As IXMLDOMElement
'    Dim eleBody As IXMLDOMElement
'    Dim sSOCode As String
'    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
'    Dim sRet As String
'    Dim nd As IXMLDOMElement
'
'    Dim num As Double
'    Dim quantity As Double
'    Dim price As Double
'    Dim cost As Double
'    Dim ddate As String
'
'    Dim attr As IXMLDOMAttribute
'    Dim bBegin As Boolean
'    bBegin = False
'    'csl-------------------------
'
'    Set eleHeader = ele.selectSingleNode("header")
'    If eleHeader Is Nothing Then
'
'        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00007")
'        GoTo csl
'    End If
'
'    sSOCode = GetElementValue(eleHeader, "tvcode")
'    Set eleBody = ele.selectSingleNode("body")
'    If eleBody Is Nothing Then
''Result:Row=230 Col=14  Content="没有body节点"  ID=37648d46-7b24-4561-9480-5a8e300c40cf
'        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00008")
'        GoTo csl
'    End If
'
'
'    Dim sQueryH As String
'    Dim sQueryB As String
'
'    sQueryH = "transrequestm"
'    sQueryB = "transrequestd"
'
'    rsHeader.CursorLocation = adUseClient
'    rsBody.CursorLocation = adUseClient
'
'    rsHeader.Open "Select * ,1 as beai from " & sQueryH & " where 1=2 ", m_conn, adOpenStatic, adLockOptimistic
'
'    rsBody.Open "Select * From " & sQueryB & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
'
'    Dim oDomH As DOMDocument
'    Dim oDomB As DOMDocument
'    Set oDomH = New DOMDocument
'    Set oDomB = New DOMDocument
'    rsHeader.save oDomH, adPersistXML
'    rsBody.save oDomB, adPersistXML
'
'    Call EXmlToRs.XmlToDomHeader(ele.xml, sRootTag, oDomH, rsHeader, "STTransAppVouchXmlRs.Xml")
'    Call EXmlToRs.XmlToDomBody(ele.xml, sRootTag, oDomB, rsBody, "STTransAppVouchXmlRs.Xml")
'
'    Set rsHeader = Nothing
'    Set rsBody = Nothing
'    Set oDomH = RecordSetToDom(DomToRecordSet(oDomH))
'    Set oDomB = RecordSetToDom(DomToRecordSet(oDomB))
'    '调用CO接口：INSERT导入单据
'    'Dim oVoucher As USERPCO.VoucherCO
'
'    'Set oVoucher = New USERPCO.VoucherCO
'    Dim eleTmp As IXMLDOMElement
'    Set eleTmp = oDomH.selectSingleNode("//z:row")
'    '清除审核人和审核日期
'    eleTmp.setAttribute "cverifyperson", ""
'    eleTmp.setAttribute "dverifydate", ""
'    eleTmp.setAttribute "vt_id", GetDefaultVtId("62")
'    eleTmp.setAttribute "cmaker", mLogin.cUserId
'    eleTmp.setAttribute "ccloser", ""
'   '取默认出入库类别
'    eleTmp.setAttribute "cirdcode", oDefSet.getDefData("incode1", m_conn, "ST")
'    eleTmp.setAttribute "cordcode", oDefSet.getDefData("ordcode1", m_conn, "ST")
'    eleTmp.setAttribute "beai", 1
'    eleTmp.setAttribute "ctvcode", SetBillSerial(oVoucherCo.login, TypeToSys("62"), oDomH, False)
'
'    eleTmp.setAttribute "csource", "1" '库存
'    eleTmp.setAttribute "id", 0
'
'
''    If Not oVoucher.IniLogin(mLogin, sRet) Then
''        GoTo csl
''    End If
'
'
''    For Each nd In oDomH.selectNodes("//z:row")
''        Set attr = nd.selectSingleNode("@dtvdate")
''        If Not attr Is Nothing Then
''            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'''Result:Row=490 Col=29  Content="的单据日期不是合法的日期！"    ID=231f94af-09e2-4a41-bdec-e5bbfc54d930
''                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00019", Array(sRet))
''                GoTo csl
''            End If
''        Else
'''Result:Row=495 Col=25  Content="的单据日期dDate节点不存在！"   ID=66d28d92-620d-4a90-b4ea-ce5b5f0e6053
''            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00020", Array(sRet))
''            GoTo csl
''        End If
''    Next
'
'    For Each nd In oDomB.selectNodes("//z:row")
'
'
'        nd.setAttribute "itvchkquantity", ""
'        nd.setAttribute "itvchknum", ""
'        nd.setAttribute "itvsumquantity", ""
'        nd.setAttribute "itvsumnum", ""
'        nd.setAttribute "cbvencode", ""
'        nd.setAttribute "cinvouchcode", ""
'        nd.setAttribute "cbcloser", ""
'        nd.setAttribute "id", 0
'        nd.setAttribute "autoid", 0
'
''        Set attr = nd.selectSingleNode("@dmadedate")
''        If Not attr Is Nothing Then
''            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'''Result:Row=895 Col=29  Content="的生产日期不是合法的日期！"    ID=1281666a-7b18-45ca-8f6e-212471d250dd
''                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00084", Array(sRet))
''                GoTo csl
''            End If
''        End If
''
''        Set attr = nd.selectSingleNode("@ddisdate")
''        If Not attr Is Nothing Then
''            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'''Result:Row=904 Col=29  Content="的失效日期不是合法的日期！"    ID=8434a7c7-fc5a-4419-b238-8f242dbd301c
''                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00085", Array(sRet))
''                GoTo csl
''            End If
''        End If
'        '-----------------------------------------------------------
'    Next
'
'    sRet = ""
'    m_conn.BeginTrans
'    bBegin = True
'    Dim oDomMsg As DOMDocument
'    Set oDomMsg = New DOMDocument
'    Call oVoucherCo.Insert("62", oDomH, oDomB, Nothing, sRet, m_conn, , oDomMsg, , False)
'    If sRet = "" Then
'        sRet = GetRetString(oDomMsg)
'    End If
'    If Not oDomH Is Nothing Then Set oDomH = Nothing
'    If Not oDomB Is Nothing Then Set oDomB = Nothing
'    If Not EXmlToRs Is Nothing Then Set EXmlToRs = Nothing
'csl:
'    If sRet = "" Then
'        If bBegin Then
'            m_conn.CommitTrans
'        End If
'        Call ErrDomAppendChild(m_errDom, sSOCode, 0, "ok")
'        Exit Function
'    Else
'        If bBegin Then
'            m_conn.RollbackTrans
'        End If
'        Call ErrDomAppendChild(m_errDom, sSOCode, 101, sRet)
'        Exit Function
'    End If
'    AddSingle = True
''Call TraceOut(PROC_SIG)
'ExitFunction:
'  Exit Function
'Error_General_Handler:
'  AddSingle = False
'  GoTo ExitFunction
'End Function

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

'Private Function GetRetString(dom As DOMDocument) As String
'    Dim el As IXMLDOMElement
'    Dim nd As IXMLDOMElement
'    Dim sRet As String
'
'    Set el = dom.selectSingleNode("//zeroout")
'    If Not el Is Nothing Then
'        For Each nd In el.selectNodes("z:row")
''Result:Row=958 Col=25  Content="存货"  ID=b6b870a3-1148-4975-8465-411412ad24ef
''Result:Row=959 Col=62  Content="现存量不足;"   ID=5f1a06dc-c714-45bf-acc8-f4bd447d9c46
'            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00086", Array(sRet, nd.getAttribute("cinvcode")))
'        Next
'    End If
'
'    Set el = dom.selectSingleNode("//itemcheck")
'    If Not el Is Nothing Then
'        For Each nd In el.selectNodes("z:row")
''Result:Row=967 Col=25  Content="存货[" ID=8d0118f3-b7ea-4362-aaf6-4f797926fc4a
''Result:Row=968 Col=63  Content="]项目预算检查失败;"    ID=7ff821ba-80b4-4a0a-af9f-c6ec8daa3eea
'            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00088", Array(sRet, nd.getAttribute("cinvcode")))
'        Next
'    End If
'
'    GetRetString = sRet
'End Function


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
    
    
    sql = " select * from KCSaleOutH  " & GetQueryCondition(eleList, m_conn)
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
        Call EXmlToRs.RStoXmlHead(el, "STSaleOutVouchXmlRs.Xml", rs)
        sql = "select * ,(case when (i.igrouptype=0 or isnull(i.cshopunit,N'')=N'') then kc.iquantity " & _
              "                when i.igrouptype=1 then (kc.iquantity/unit.ichangrate) " & _
              "                when i.igrouptype=2 then ( case when i.ccomunitcode=isnull(i.cshopunit,N'') then kc.iquantity  else kc.inum end) " & _
              "           end) as lsqty  from  KCSaleOutB kc inner join inventory i on kc.cinvcode = i.cinvcode left outer join ComputationUnit unit on i.cshopunit=unit.ccomunitcode where id= " & rs("id")
              
        rsDetail.Open sql, m_conn, adOpenStatic, adLockBatchOptimistic
        If rsDetail.RecordCount > 0 Then
           rsDetail.MoveFirst
           While Not rsDetail.EOF
                rsDetail.fields("iquantity") = rsDetail.fields("lsqty")
                rsDetail.MoveNext
           Wend
           rsDetail.MoveFirst
        End If
        
        Call EXmlToRs.RStoXmlBody(el, "STSaleOutVouchXmlRs.Xml", rsDetail)
        rsDetail.Close
        dom.documentElement.appendChild el
        
        '****************************
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
    rs.Open "select * from KCSaleOutH where 1>1", conn, adOpenForwardOnly, adLockReadOnly
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
    
    GetQueryCondition = GetQueryCondition & " and (" & "isnull(chandler,'')<>'' and isnull(bIsLsQuery,0)=0" & ")"
    
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




