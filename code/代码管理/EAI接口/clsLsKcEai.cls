VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsLsKcEai"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'*********************************************************************************
'模块: clsLsKcEai
'文件: clsLsKcEai.cls

'说明:库存零售EAI专用接口类模块
'
'
'修改:
'
'
'*********************************************************************************
Option Explicit

'错误处理的Domdocument
Dim mLogin As U8Login.clsLogin
Dim m_conn As ADODB.Connection
Dim oVoucherCo As USERPCO.VoucherCO
Dim oInvObj As USERPCO.InventoryCO
Dim oDefSet  As Object 'U8SCMImpDefValSet.clsSCMImpDefValSet

Public gObjRef As Object

Public Function SetLogin(oLogin As Object, conn As ADODB.Connection, sErr As String) As Boolean
  On Error GoTo errhandle
  Dim errMsg As String
  SetLogin = True
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
  Set m_conn = conn
  Exit Function
errhandle:
  SetLogin = False
  sErr = Err.Description
  'Call ErrDomAppendChild(m_errDom, "", 999, Err.Description)
End Function
Public Function SetUserDefineAdd(ByVal svouchtype As String, ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, _
                                 ByRef strErr As String) As Boolean
   
   Select Case svouchtype
      Case "18" '盘点单
         SetUserDefineAdd = SetCheckVouch(domHead, domBody, strErr)
      
      Case "12" '调拨单
         SetUserDefineAdd = SetTransVouch(domHead, domBody, strErr)
      
      Case "62" '调拨申请单
         SetUserDefineAdd = SetAppTransVouch(domHead, domBody, strErr)
      Case "09" '其他出库单
         SetUserDefineAdd = SetOtherOutVouch(domHead, domBody, strErr)
      Case "11" '材料出库单
         SetUserDefineAdd = SetMaterialOutVouch(domHead, domBody, strErr)
      Case "10" '产成品入库单
         SetUserDefineAdd = SetProductInVouch(domHead, domBody, strErr)
      Case "19" '货位调拨单
         SetUserDefineAdd = SetAdjustPVouch(domHead, domBody, strErr)
   End Select
End Function
'获取系统设置条件，如是否允许0出库等
Public Function GetCheckOption(ByVal svouchtype, ByRef oCheckCol As Dictionary) As Boolean
  GetCheckOption = True
  If oCheckCol Is Nothing Then
     Set oCheckCol = New Dictionary
  End If
  
  If oCheckCol.Exists("AllowZeroOut") Then
     oCheckCol.Item("AllowZeroOut") = True
  Else
     oCheckCol.Add "AllowZeroOut", True
  End If
  
  If oCheckCol.Exists("BatchAllowZeroOut") Then
     oCheckCol.Item("BatchAllowZeroOut") = True
  Else
     oCheckCol.Add "BatchAllowZeroOut", True
  End If
  If oCheckCol.Exists("InOutCheck") Then
     oCheckCol.Item("InOutCheck") = False
  Else
     
     oCheckCol.Add "InOutCheck", False
  End If
End Function

'处理虚拟批号,零售数量等转换
Public Function SetUserDefineQuery(ByVal svouchtype, ByRef sXML As String, ByRef strErr As String) As Boolean
   On Error GoTo errhandle
   Dim tmpdom As New DOMDocument
   
   Dim ele As IXMLDOMElement
   Dim eleNode As IXMLDOMElement
   On Error GoTo errhandle
   SetUserDefineQuery = True
   If svouchtype <> "currentstock" Then
     Exit Function
   End If
   tmpdom.loadXML (sXML)
   Dim sInvcode As String
   Dim sResUnit As String
   Dim dChangRate As Double
   Dim dTaxRate As Double
   
   For Each ele In tmpdom.documentElement.selectNodes("//currentstock")
       Set eleNode = ele.selectSingleNode("batch")
       If Not (eleNode Is Nothing) Then
          If eleNode.Text = "DummyBatch" Then
             eleNode.Text = ""
          End If
       End If
       Set eleNode = ele.selectSingleNode("dvdate")
       If Not (eleNode Is Nothing) Then
          If eleNode.Text = "2222-02-03" Then
             eleNode.Text = ""
          End If
       End If
       If oDefSet.getRetailUnit(ele.selectSingleNode("invcode").Text, sResUnit, dChangRate, dTaxRate, m_conn) Then
          If sResUnit <> "" Then
             If dChangRate <> -1 Then '换算率不能为零
               ele.selectSingleNode("quantity").Text = CDbl(ele.selectSingleNode("quantity").Text) / dChangRate
             End If
          End If
       End If
   
   Next
   sXML = tmpdom.xml
   Exit Function
errhandle:
   SetUserDefineQuery = False
   strErr = Err.Description
End Function

Public Function SetUserDefineCon(ByRef strCondition As String, ByRef strErr As String) As Boolean
  SetUserDefineCon = True
End Function

Public Function SetSTUnit(ByVal svouchtype, cInvCode As String, cSTUnitCode As String, strErr As String) As Boolean
  SetSTUnit = True
End Function

Public Function SetReUnit(ByVal svouchtype, cInvCode As String, cReUnitCode As String, strErr As String) As Boolean
   SetReUnit = True
End Function

'*********************************************************************************************************************
'定义的私有函数用于处理初始化单据数据
Private Function GetDefaultVtId(svouchtype As String) As String
   Dim rs As New ADODB.Recordset
   rs.CursorLocation = adUseClient
   Dim sRet As String
   On Error GoTo errhandle
   If oVoucherCo.GetVT_ID(svouchtype, rs, sRet, 0) Then
      If rs.EOF And rs.BOF Then
         'Result:Row=461 Col=29  Content="的取缺省模板时失败！"  ID=0a23b92e-6c08-4c5f-836a-06ac66bb97f5
         sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00016", Array(sRet))
         Err.Raise vbObjectError + 100, , sRet & vbCrLf
      Else
         GetDefaultVtId = rs("vt_id")
      End If
   End If
   Exit Function
errhandle:
   GetDefaultVtId = "0"
End Function
'处理处理调拨单
Private Function SetTransVouch(ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, ByRef strErr As String) As Boolean
   Dim eleHead As IXMLDOMElement
   Dim eleBody As IXMLDOMElement
   Dim attr As IXMLDOMAttribute
   On Error GoTo errhandle
   SetTransVouch = False
   Set eleHead = domHead.selectSingleNode("//z:row")
   If eleHead Is Nothing Then
      strErr = "无表头数据"
      Exit Function
   End If
   If domBody.selectNodes("//z:row") Is Nothing Then
       strErr = "无表体数据"
       Exit Function
   End If
   
   Dim bLsVouch As Boolean
   bLsVouch = True
   
   If NullToStr(eleHead.getAttribute("csource")) <> "2" Then '非零售系统特殊处理
     bLsVouch = False
     eleHead.setAttribute "caccounter", ""
     eleHead.setAttribute "cmpocode", ""
     eleHead.setAttribute "iproorderid", ""
     eleHead.setAttribute "cverifyperson", ""
     eleHead.setAttribute "dverifydate", ""
     eleHead.setAttribute "ctranrequestcode", ""
     
     For Each eleBody In domBody.selectNodes("//z:row")
        eleBody.setAttribute "impoids", ""
        eleBody.setAttribute "itrids", ""
     Next
     SetTransVouch = True
     'Exit Function
   End If
   '设置表头数据
   '****************
   eleHead.setAttribute "vt_id", GetDefaultVtId("12")
   eleHead.setAttribute "cmaker", mLogin.cUserName
   eleHead.setAttribute "beai", 1
   
   Dim sLsDate As String
   If Not IsNull(eleHead.getAttribute("dtvdate")) Then
      sLsDate = eleHead.getAttribute("dtvdate")
      sLsDate = Format(sLsDate, "yyyy-mm-dd")
      eleHead.setAttribute "dtvdate", sLsDate
   End If
   
   
   Dim sCode As String
    If IsNull(eleHead.getAttribute("ctvcode")) Then
       sCode = ""
    Else
       sCode = eleHead.getAttribute("ctvcode")
    End If
    
    If sCode = "" Then
        eleHead.setAttribute "ctvcode", SetBillSerial(oVoucherCo.Login, TypeToSys("12"), domHead, False)
    End If
   '取默认出入库类别
'   eleHead.setAttribute "cirdcode", oDefSet.getDefData("incode1", m_conn, "ST")
'   eleHead.setAttribute "cordcode", oDefSet.getDefData("ordcode1", m_conn, "ST")
   If bLsVouch Then
        eleHead.setAttribute "cirdcode", oDefSet.getDefData("transincode", m_conn, "ST")
        eleHead.setAttribute "cordcode", oDefSet.getDefData("transoutcode", m_conn, "ST")
   End If
   eleHead.setAttribute "itransflag", "正向"
   
   '设置调入部门
   Dim sDepCode As String
   Dim sWhCode As String
   
   If bLsVouch Then
        sDepCode = IIf(IsNull(eleHead.getAttribute("cidepcode")), "", eleHead.getAttribute("cidepcode"))
        sWhCode = IIf(IsNull(eleHead.getAttribute("ciwhcode")), "", eleHead.getAttribute("ciwhcode"))
        Dim oRd As ADODB.Recordset
        If Trim(sWhCode) <> "" And Trim(sDepCode) = "" Then
           Set oRd = New ADODB.Recordset
           oRd.CursorLocation = adUseClient
           oRd.Open "select isnull(w.cdepcode,'') as cdepcode,isnull(d.cdepname,'') as cdepname  from warehouse w left join department d on w.cdepcode = d.cdepcode where w.cwhcode=N'" & sWhCode & "'", m_conn, adOpenDynamic, adLockReadOnly
           If oRd.RecordCount > 0 Then
                 oRd.MoveFirst
                 eleHead.setAttribute "cidepcode", oRd.fields("cdepcode").Value
                 eleHead.setAttribute "cdepname", oRd.fields("cdepname").Value
           End If
           Set oRd = Nothing
        End If
   End If
   
   '设置表体数据,主要调用CO服务与销售提供服务设置数据
   '***************
   Dim iRow As Long
   Dim ele As IXMLDOMElement
   Dim tmpDomBody As DOMDocument
   Dim oInvVo As Object
   Dim sBatch As String
   Dim iMassDate As String
   Dim dMadedate As String
   Dim dDisdate As String
   Dim cMassunit As String
   Dim errMsg As String
   iRow = 0
   Dim eleTmp As IXMLDOMElement
  
   
   If bLsVouch Then '零售单据处理
          For Each ele In domBody.selectNodes("//z:row")
             iRow = iRow + 1
             Set tmpDomBody = GetLineDom(domBody, iRow)
             'Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
             If Not oVoucherCo.CheckBody("12", nInsert, 1, "cinvcode", tmpDomBody, errMsg, domHead) Then
                Err.Raise vbObjectError + 100, , errMsg & vbCrLf
             End If
             Set oInvVo = CreateObject("userpvo.Inventory")
             Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
             If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) Then
                   
                   If oInvVo.GroupType = 0 Then '0:无计量;1:固定
                      eleTmp.setAttribute "cassunit", ""
                      eleTmp.setAttribute "iinvexchrate", ""
                      eleTmp.setAttribute "itvnum", ""
                      
                      eleTmp.setAttribute "itvquantity", CDbl(ele.getAttribute("itvnum"))
                      
                      ele.setAttribute "itvnum", ""
                      ele.setAttribute "cassunit", ""
                      ele.setAttribute "iinvexchrate", ""
                      
                      If Not oVoucherCo.CheckBody("12", nInsert, 1, "itvquantity", tmpDomBody, errMsg, domHead) Then
                          Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                      End If
                   ElseIf oInvVo.GroupType = 1 Then
                      eleTmp.setAttribute "cassunit", ele.getAttribute("cassunit")
                      If Not oVoucherCo.CheckBody("12", nInsert, 1, "cassunit", tmpDomBody, errMsg, domHead) Then
                          Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                      End If
                      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
                      eleTmp.setAttribute "itvnum", ele.getAttribute("itvnum")
                      If Not oVoucherCo.CheckBody("12", nInsert, 1, "itvnum", tmpDomBody, errMsg, domHead) Then
                          Err.Raise vbObjectError + 100, , errMsg & vbCrLf
                      End If
                   End If
                   
             Else
                Err.Raise vbObjectError + 100, , errMsg & vbCrLf
             
             End If
             
             '清空来源单据信息
             
             '赋自由项
             Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
             
             
             eleTmp.setAttribute "cfree1", ele.getAttribute("cfree1")
             eleTmp.setAttribute "cfree2", ele.getAttribute("cfree2")
             eleTmp.setAttribute "cfree3", ele.getAttribute("cfree3")
             eleTmp.setAttribute "cfree4", ele.getAttribute("cfree4")
             eleTmp.setAttribute "cfree5", ele.getAttribute("cfree5")
             eleTmp.setAttribute "cfree6", ele.getAttribute("cfree6")
             eleTmp.setAttribute "cfree7", ele.getAttribute("cfree7")
             eleTmp.setAttribute "cfree8", ele.getAttribute("cfree8")
             eleTmp.setAttribute "cfree9", ele.getAttribute("cfree9")
             eleTmp.setAttribute "cfree10", ele.getAttribute("cfree10")
             
             eleTmp.setAttribute "cinposcode", NullToStr(ele.getAttribute("cinposcode"))
             
             eleTmp.setAttribute "coutposcode", NullToStr(ele.getAttribute("coutposcode"))
             
             
             '计算保质期
             sBatch = CStr(ele.getAttribute("ctvbatch"))
             
                         
             If oInvVo.IsBatch Then
             
                 '此服务中没有仓库信息，不正确，待修改
                 oDefSet.getBatch NullToStr(eleHead.getAttribute("cowhcode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), _
                                  NullToStr(ele.getAttribute("cfree2")), NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), _
                                  NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), NullToStr(ele.getAttribute("cfree7")), _
                                  NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), _
                                  sBatch, cMassunit, iMassDate, dMadedate, dDisdate, m_conn
                 
                 eleTmp.setAttribute "ctvbatch", sBatch
    '             eleTmp.setAttribute "dmadedate", dMadedate
    '             eleTmp.setAttribute "ddisdate", dDisdate
                 If oInvVo.IsQuality Then
                    dMadedate = Format(dMadedate, "yyyy-mm-dd")
                    dDisdate = Format(dDisdate, "yyyy-mm-dd")
                    eleTmp.setAttribute "dmadedate", dMadedate
                    eleTmp.setAttribute "ddisdate", dDisdate
                    eleTmp.setAttribute "iexpiratdatecalcu", oInvVo.ExpiratDateCalcu
                    SetExpiratDateInfo eleTmp, dDisdate, CStr(oInvVo.ExpiratDateCalcu)
                 End If
             Else
                eleTmp.setAttribute "ctvbatch", ""
             End If
             setNodeValue eleTmp, ele
        
          Next
   Else
          For Each ele In domBody.selectNodes("//z:row")
              Set oInvVo = CreateObject("userpvo.Inventory")
              If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) = False Then
                  Err.Raise vbObjectError + 100, , errMsg & vbCrLf
              End If
           
             '计算保质期
             
             If oInvVo.IsQuality Then
                 sBatch = NullToStr(ele.getAttribute("ctvbatch"))
                 '此服务中没有仓库信息，不正确，待修改
                 oDefSet.getBatch NullToStr(eleHead.getAttribute("cowhcode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), _
                                 NullToStr(ele.getAttribute("cfree2")), NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), _
                                 NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), NullToStr(ele.getAttribute("cfree7")), _
                                 NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), _
                                 sBatch, cMassunit, iMassDate, dMadedate, dDisdate, m_conn
                 'ele.setAttribute "ctvbatch", sBatch
                 dMadedate = Format(dMadedate, "yyyy-mm-dd")
                 dDisdate = Format(dDisdate, "yyyy-mm-dd")
                 ele.setAttribute "dmadedate", dMadedate
                 ele.setAttribute "ddisdate", dDisdate
                 ele.setAttribute "imassdate", iMassDate
                 ele.setAttribute "cmassunit", cMassunit
                 ele.setAttribute "iexpiratdatecalcu", oInvVo.ExpiratDateCalcu
                 SetExpiratDateInfo ele, dDisdate, CStr(oInvVo.ExpiratDateCalcu)
                 'ExpiratDateCalcu
             End If
             Set oInvVo = Nothing
         Next
   End If
   SetTransVouch = True
   Exit Function
errhandle:
   strErr = Err.Description
End Function
'处理调拨申请单
Private Function SetAppTransVouch(ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, ByRef strErr As String) As Boolean
   Dim eleHead As IXMLDOMElement
   Dim eleBody As IXMLDOMElement
   Dim attr As IXMLDOMAttribute
   On Error GoTo errhandle
   
   Dim sQtyName As String
   Dim sJeName As String
   Dim sRqName As String
   Dim sXsQtyName As String
   Dim sXsjeName As String
   
   
   sQtyName = LCase(oDefSet.getDefData("apptrankcdefine", m_conn, "ST"))
   sJeName = LCase(oDefSet.getDefData("apptranjedefine", m_conn, "ST"))
   
   sRqName = LCase(oDefSet.getDefData("apptranrqdefine", m_conn, "ST"))
   sXsQtyName = LCase(oDefSet.getDefData("apptranxsqtydefine", m_conn, "ST"))
   sXsjeName = LCase(oDefSet.getDefData("apptranxsjedefine", m_conn, "ST"))
   
   
   
   SetAppTransVouch = False
   Set eleHead = domHead.selectSingleNode("//z:row")
   If eleHead Is Nothing Then
      strErr = "无表头数据"
      Exit Function
   End If
   If eleHead.getAttribute("csource") <> 2 Then '非零售系统不处理
     SetAppTransVouch = True
     Exit Function
   End If
   '设置表头数据
   '****************
   eleHead.setAttribute "vt_id", GetDefaultVtId("62")
   eleHead.setAttribute "cmaker", mLogin.cUserName
   '取默认出入库类别
   'eleHead.setAttribute "cirdcode", oDefSet.getDefData("incode1", m_conn, "ST")
   'eleHead.setAttribute "cordcode", oDefSet.getDefData("ordcode1", m_conn, "ST")
   eleHead.setAttribute "cirdcode", oDefSet.getDefData("transincode", m_conn, "ST")
   eleHead.setAttribute "cordcode", oDefSet.getDefData("transoutcode", m_conn, "ST")
   
   eleHead.setAttribute "beai", 1
   
   Dim sLsDate As String
   If Not IsNull(eleHead.getAttribute("dtvdate")) Then
      sLsDate = eleHead.getAttribute("dtvdate")
      sLsDate = Format(sLsDate, "yyyy-mm-dd")
      eleHead.setAttribute "dtvdate", sLsDate
   End If
   
   Dim sCode As String
    If IsNull(eleHead.getAttribute("ctvcode")) Then
       sCode = ""
    Else
       sCode = eleHead.getAttribute("ctvcode")
    End If
    If sCode = "" Then
        eleHead.setAttribute "ctvcode", SetBillSerial(oVoucherCo.Login, TypeToSys("62"), domHead, False)
    End If
    
    If sRqName <> "" Then
        If Not IsNull(eleHead.getAttribute("yhrq")) Then
           eleHead.setAttribute sRqName, eleHead.getAttribute("yhrq")
        End If
    End If
        
   '设置表体数据,主要调用CO服务与销售提供服务设置数据
   '***************
   Dim iRow As Long
   Dim ele As IXMLDOMElement
   Dim tmpDomBody As DOMDocument
   Dim oInvVo As Object
   Dim sBatch As String
   Dim iMassDate As String
   Dim dMadedate As String
   Dim dDisdate As String
   Dim cMassunit As String
   Dim errMsg As String
   Dim eleTmp As IXMLDOMElement
   
   
   
   iRow = 0
   For Each ele In domBody.selectNodes("//z:row")
      iRow = iRow + 1
      Set tmpDomBody = GetLineDom(domBody, iRow)
      
      If Not oVoucherCo.CheckBody("62", nInsert, 1, "cinvcode", tmpDomBody, errMsg, domHead) Then
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      Set oInvVo = CreateObject("userpvo.Inventory")
      If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) Then
            Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
            If oInvVo.GroupType = 0 Then '0:无计量;1:固定
               eleTmp.setAttribute "cassunit", ""
               eleTmp.setAttribute "iinvexchrate", ""
               eleTmp.setAttribute "itvnum", ""
               
               eleTmp.setAttribute "itvquantity", CDbl(ele.getAttribute("itvnum"))
               
               ele.setAttribute "cassunit", ""
               ele.setAttribute "iinvexchrate", ""
               ele.setAttribute "itvnum", ""
               
                              
               If Not oVoucherCo.CheckBody("62", nInsert, 1, "itvquantity", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            ElseIf oInvVo.GroupType = 1 Then
               eleTmp.setAttribute "cassunit", ele.getAttribute("cassunit")
               If Not oVoucherCo.CheckBody("62", nInsert, 1, "cassunit", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               eleTmp.setAttribute "itvnum", ele.getAttribute("itvnum")
               If Not oVoucherCo.CheckBody("62", nInsert, 1, "itvnum", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            End If
            
      Else
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      
      End If
      '赋自由项
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      eleTmp.setAttribute "cfree1", ele.getAttribute("cfree1")
      eleTmp.setAttribute "cfree2", ele.getAttribute("cfree2")
      eleTmp.setAttribute "cfree3", ele.getAttribute("cfree3")
      eleTmp.setAttribute "cfree4", ele.getAttribute("cfree4")
      eleTmp.setAttribute "cfree5", ele.getAttribute("cfree5")
      eleTmp.setAttribute "cfree6", ele.getAttribute("cfree6")
      eleTmp.setAttribute "cfree7", ele.getAttribute("cfree7")
      eleTmp.setAttribute "cfree8", ele.getAttribute("cfree8")
      eleTmp.setAttribute "cfree9", ele.getAttribute("cfree9")
      eleTmp.setAttribute "cfree10", ele.getAttribute("cfree10")
      
      If oInvVo.IsBatch Then
        '此服务中没有仓库信息，不正确，待修改
        sBatch = NullToStr(ele.getAttribute("ctvbatch"))
        If sBatch <> "" And NullToStr(eleHead.getAttribute("cowhcode")) <> "" Then
            oDefSet.getBatch NullToStr(eleHead.getAttribute("cowhcode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), _
                             NullToStr(ele.getAttribute("cfree2")), NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), _
                             NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), NullToStr(ele.getAttribute("cfree7")), _
                             NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), _
                             sBatch, cMassunit, iMassDate, dMadedate, dDisdate, m_conn
            eleTmp.setAttribute "ctvbatch", sBatch
            If oInvVo.IsQuality Then
               dMadedate = Format(dMadedate, "yyyy-mm-dd")
               dDisdate = Format(dDisdate, "yyyy-mm-dd")
               eleTmp.setAttribute "dmadedate", dMadedate
               eleTmp.setAttribute "ddisdate", dDisdate
               eleTmp.setAttribute "iexpiratdatecalcu", oInvVo.ExpiratDateCalcu
               SetExpiratDateInfo eleTmp, dDisdate, CStr(oInvVo.ExpiratDateCalcu)
            End If
        End If
     Else
        eleTmp.setAttribute "ctvbatch", ""
     End If
             
             
      
      If sQtyName <> "" Then
         If Not IsNull(ele.getAttribute("yhkc")) Then
            eleTmp.setAttribute sQtyName, ele.getAttribute("yhkc")
         End If
      End If
      
      If sJeName <> "" Then
         If Not IsNull(ele.getAttribute("yhje")) Then
            eleTmp.setAttribute sJeName, ele.getAttribute("yhje")
         End If
      End If
    
        
          
        If sXsQtyName <> "" Then
           If Not IsNull(ele.getAttribute("xsqty")) Then
              eleTmp.setAttribute sXsQtyName, ele.getAttribute("xsqty")
           End If
        End If
          
        If sXsjeName <> "" Then
           If Not IsNull(ele.getAttribute("xsje")) Then
              eleTmp.setAttribute sXsjeName, ele.getAttribute("xsje")
           End If
        End If
   
   
      
      setNodeValue eleTmp, ele 'tmpDomBody.selectSingleNode("//z:row"), ele
   Next
   SetAppTransVouch = True
   Exit Function
errhandle:
   strErr = Err.Description
End Function

'处理盘点单
Private Function SetCheckVouch(ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, ByRef strErr As String) As Boolean
  Dim eleHead As IXMLDOMElement
   Dim eleBody As IXMLDOMElement
   Dim attr As IXMLDOMAttribute
   On Error GoTo errhandle
   SetCheckVouch = False
   Set eleHead = domHead.selectSingleNode("//z:row")
   If eleHead Is Nothing Then
      strErr = "无表头数据"
      Exit Function
   End If
   If eleHead.getAttribute("csource") <> 2 Then '非零售系统不处理
     SetCheckVouch = True
     Exit Function
   End If
   '设置表头数据
   '****************
   eleHead.setAttribute "vt_id", GetDefaultVtId("18")
   eleHead.setAttribute "cmaker", mLogin.cUserName
   eleHead.setAttribute "beai", 1
   
   Dim sLsDate As String
   If Not IsNull(eleHead.getAttribute("dcvdate")) Then
      sLsDate = eleHead.getAttribute("dcvdate")
      sLsDate = Format(sLsDate, "yyyy-mm-dd")
      eleHead.setAttribute "dcvdate", sLsDate
   End If
   
   
   Dim sCode As String
    If IsNull(eleHead.getAttribute("ccvcode")) Then
       sCode = ""
    Else
       sCode = eleHead.getAttribute("ccvcode")
    End If
   If sCode = "" Then
        eleHead.setAttribute "ccvcode", SetBillSerial(oVoucherCo.Login, TypeToSys("18"), domHead, False)
   End If
   eleHead.setAttribute "dacdate", eleHead.getAttribute("dcvdate")
   '取零售日期
   eleHead.setAttribute "ccvtype", "普通仓库盘点"
   '取默认出入库类别
   Dim obj As VouchInOutType.VouchRdType
   Set obj = New VouchInOutType.VouchRdType
'   If obj.GetRdtype(m_conn, "18", "") Then '盘点单取默认设置
'      eleHead.setAttribute "cirdcode", NullToStr(obj.InRDCode)
'      eleHead.setAttribute "cordcode", NullToStr(obj.OutRDCode)
'   End If
   
    eleHead.setAttribute "cirdcode", oDefSet.getDefData("checkincode", m_conn, "ST") 'NullToStr(obj.InRDCode)
    eleHead.setAttribute "cordcode", oDefSet.getDefData("checkoutcode", m_conn, "ST") 'NullToStr(obj.OutRDCode)
    
   '设置表体数据,主要调用CO服务与销售提供服务设置数据
   '***************
   Dim iRow As Long
   Dim ele As IXMLDOMElement
   Dim tmpDomBody As DOMDocument
   Dim oInvVo As Object
   Dim sBatch As String
   Dim iMassDate As String
   Dim dMadedate As String
   Dim dDisdate As String
   Dim cMassunit As String
   Dim errMsg As String
   Dim eleTmp As IXMLDOMElement
   Dim dExchrate As Double
   iRow = 0
   For Each ele In domBody.selectNodes("//z:row")
      iRow = iRow + 1
      Set tmpDomBody = GetLineDom(domBody, iRow)
     
      If Not oVoucherCo.CheckBody("18", nInsert, 1, "cinvcode", tmpDomBody, errMsg, domHead) Then
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      Set oInvVo = CreateObject("userpvo.Inventory")
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      
      If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) Then
            If oInvVo.GroupType = 0 Then '0:无计量;1:固定
            '注意必须同时清空ele结点的件数，换算率，辅计量单位
               eleTmp.setAttribute "cassunit", ""
               eleTmp.setAttribute "iinvexchrate", ""
               eleTmp.setAttribute "icvnum", ""
               eleTmp.setAttribute "icvcnum", ""
               
               ele.setAttribute "cassunit", ""
               ele.setAttribute "iinvexchrate", ""
               
               eleTmp.setAttribute "icvquantity", CDbl(ele.getAttribute("icvnum"))
               ele.setAttribute "icvnum", ""
               
               If Not oVoucherCo.CheckBody("18", nInsert, 1, "icvquantity", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               eleTmp.setAttribute "icvcquantity", CDbl(ele.getAttribute("icvcnum"))
               ele.setAttribute "icvcnum", ""
               
               If Not oVoucherCo.CheckBody("18", nInsert, 1, "icvcquantity", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            ElseIf oInvVo.GroupType = 1 Then
               eleTmp.setAttribute "cassunit", ele.getAttribute("cassunit")
               If Not oVoucherCo.CheckBody("18", nInsert, 1, "cassunit", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               dExchrate = CDbl(eleTmp.getAttribute("iinvexchrate"))
               
               eleTmp.setAttribute "icvnum", ele.getAttribute("icvnum")
               eleTmp.setAttribute "icvquantity", CDbl(ele.getAttribute("icvnum")) * dExchrate
               If Not oVoucherCo.CheckBody("18", nInsert, 1, "icvnum", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               eleTmp.setAttribute "icvcnum", ele.getAttribute("icvcnum")
               If Not oVoucherCo.CheckBody("18", nInsert, 1, "icvcnum", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            End If
            
      Else
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      
      End If
      '赋自由项
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      eleTmp.setAttribute "cfree1", ele.getAttribute("cfree1")
      eleTmp.setAttribute "cfree2", ele.getAttribute("cfree2")
      eleTmp.setAttribute "cfree3", ele.getAttribute("cfree3")
      eleTmp.setAttribute "cfree4", ele.getAttribute("cfree4")
      eleTmp.setAttribute "cfree5", ele.getAttribute("cfree5")
      eleTmp.setAttribute "cfree6", ele.getAttribute("cfree6")
      eleTmp.setAttribute "cfree7", ele.getAttribute("cfree7")
      eleTmp.setAttribute "cfree8", ele.getAttribute("cfree8")
      eleTmp.setAttribute "cfree9", ele.getAttribute("cfree9")
      eleTmp.setAttribute "cfree10", ele.getAttribute("cfree10")
      
      eleTmp.setAttribute "cposition", NullToStr(ele.getAttribute("cposition"))
      
      
      '计算保质期
      sBatch = CStr(ele.getAttribute("ccvbatch"))
      
      If oInvVo.IsBatch Then
            oDefSet.getBatch NullToStr(eleHead.getAttribute("cwhcode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), NullToStr(ele.getAttribute("cfree2")), _
                             NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), _
                             NullToStr(ele.getAttribute("cfree7")), _
                             NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), sBatch, cMassunit, iMassDate, _
                             dMadedate, dDisdate, m_conn
            
            eleTmp.setAttribute "ccvbatch", sBatch
            'eleTmp.setAttribute "dmadedate", dMadedate
            'eleTmp.setAttribute "ddisdate", dDisdate
            If oInvVo.IsQuality Then
                dMadedate = Format(dMadedate, "yyyy-mm-dd")
                dDisdate = Format(dDisdate, "yyyy-mm-dd")
                eleTmp.setAttribute "dmadedate", dMadedate
                eleTmp.setAttribute "ddisdate", dDisdate
                eleTmp.setAttribute "iexpiratdatecalcu", oInvVo.ExpiratDateCalcu
                SetExpiratDateInfo eleTmp, dDisdate, CStr(oInvVo.ExpiratDateCalcu)
            End If
      Else
            eleTmp.setAttribute "ccvbatch", ""
      End If
      
      setNodeValue eleTmp, ele
      
   Next
   SetCheckVouch = True
   Exit Function
errhandle:
   strErr = Err.Description
End Function

'处理其他出库单
Private Function SetOtherOutVouch(ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, ByRef strErr As String) As Boolean
   Dim eleHead As IXMLDOMElement
   Dim eleBody As IXMLDOMElement
   Dim attr As IXMLDOMAttribute
   On Error GoTo errhandle
   SetOtherOutVouch = False
   Set eleHead = domHead.selectSingleNode("//z:row")
   If eleHead Is Nothing Then
      strErr = "无表头数据"
      Exit Function
   End If
   If domBody.selectNodes("//z:row") Is Nothing Then
       strErr = "无表体数据"
       Exit Function
   End If
   
   '设置表头数据
   '****************
   eleHead.setAttribute "vt_id", GetDefaultVtId("09")
   eleHead.setAttribute "cmaker", mLogin.cUserName
   eleHead.setAttribute "beai", 1
   eleHead.setAttribute "cvouchtype", "09"
   '取默认出入库类别
   eleHead.setAttribute "crdcode", oDefSet.getDefData("otheroutcode", m_conn, "ST")
   
   Dim sLsDate As String
   If Not IsNull(eleHead.getAttribute("ddate")) Then
      sLsDate = eleHead.getAttribute("ddate")
      sLsDate = Format(sLsDate, "yyyy-mm-dd")
      eleHead.setAttribute "ddate", sLsDate
   End If
   
   
   Dim sCode As String
    If IsNull(eleHead.getAttribute("ccode")) Then
       sCode = ""
    Else
       sCode = eleHead.getAttribute("ccode")
    End If
    If sCode = "" Then
        eleHead.setAttribute "ccode", SetBillSerial(oVoucherCo.Login, TypeToSys("09"), domHead, False)
    End If
   '来源：零售
   eleHead.setAttribute "csource", "2"
   eleHead.setAttribute "cmemo", "VIP积分兑付"
   
   
   Dim oRd As ADODB.Recordset
         
   '设置表体数据,主要调用CO服务与销售提供服务设置数据
   '***************
   Dim iRow As Long
   Dim ele As IXMLDOMElement
   Dim tmpDomBody As DOMDocument
   Dim oInvVo As Object
   Dim sBatch As String
   Dim iMassDate As String
   Dim dMadedate As String
   Dim dDisdate As String
   Dim cMassunit As String
   Dim errMsg As String
   iRow = 0
   Dim eleTmp As IXMLDOMElement
   For Each ele In domBody.selectNodes("//z:row")
      iRow = iRow + 1
      Set tmpDomBody = GetLineDom(domBody, iRow)
      'Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      If Not oVoucherCo.CheckBody("09", nInsert, 1, "cinvcode", tmpDomBody, errMsg, domHead) Then
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      Set oInvVo = CreateObject("userpvo.Inventory")
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) Then
            
            If oInvVo.GroupType = 0 Then '0:无计量;1:固定
               eleTmp.setAttribute "cassunit", ""
               eleTmp.setAttribute "iinvexchrate", ""
               eleTmp.setAttribute "inum", ""
               
               eleTmp.setAttribute "iquantity", CDbl(ele.getAttribute("inum"))
               
               ele.setAttribute "inum", ""
               ele.setAttribute "cassunit", ""
               ele.setAttribute "iinvexchrate", ""
               
               If Not oVoucherCo.CheckBody("09", nInsert, 1, "iquantity", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            ElseIf oInvVo.GroupType = 1 Then
               eleTmp.setAttribute "cassunit", ele.getAttribute("cassunit")
               If Not oVoucherCo.CheckBody("09", nInsert, 1, "cassunit", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               eleTmp.setAttribute "inum", ele.getAttribute("inum")
               If Not oVoucherCo.CheckBody("09", nInsert, 1, "inum", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            End If
            
      Else
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      
      End If
      
      '清空来源单据信息
      
      '赋自由项
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      
      
      eleTmp.setAttribute "cfree1", ele.getAttribute("cfree1")
      eleTmp.setAttribute "cfree2", ele.getAttribute("cfree2")
      eleTmp.setAttribute "cfree3", ele.getAttribute("cfree3")
      eleTmp.setAttribute "cfree4", ele.getAttribute("cfree4")
      eleTmp.setAttribute "cfree5", ele.getAttribute("cfree5")
      eleTmp.setAttribute "cfree6", ele.getAttribute("cfree6")
      eleTmp.setAttribute "cfree7", ele.getAttribute("cfree7")
      eleTmp.setAttribute "cfree8", ele.getAttribute("cfree8")
      eleTmp.setAttribute "cfree9", ele.getAttribute("cfree9")
      eleTmp.setAttribute "cfree10", ele.getAttribute("cfree10")
      eleTmp.setAttribute "cposition", NullToStr(ele.getAttribute("cposition"))
      
      '计算保质期
      sBatch = CStr(ele.getAttribute("cbatch"))
      
      If oInvVo.IsBatch Then
            '此服务中没有仓库信息，不正确，待修改
            oDefSet.getBatch NullToStr(eleHead.getAttribute("cwhCode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), _
                             NullToStr(ele.getAttribute("cfree2")), NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), _
                             NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), NullToStr(ele.getAttribute("cfree7")), _
                             NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), _
                             sBatch, cMassunit, iMassDate, dMadedate, dDisdate, m_conn
            
            eleTmp.setAttribute "cbatch", sBatch
            eleTmp.setAttribute "dmadedate", dMadedate
            eleTmp.setAttribute "dvdate", dDisdate
      Else
            eleTmp.setAttribute "cbatch", ""
      End If
      
      setNodeValue eleTmp, ele
      
 
   Next
   SetOtherOutVouch = True
   Exit Function
errhandle:
   strErr = Err.Description
End Function


'处理材料出库单
Private Function SetMaterialOutVouch(ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, ByRef strErr As String) As Boolean
   Dim eleHead As IXMLDOMElement
   Dim eleBody As IXMLDOMElement
   Dim attr As IXMLDOMAttribute
   On Error GoTo errhandle
   SetMaterialOutVouch = False
   Set eleHead = domHead.selectSingleNode("//z:row")
   If eleHead Is Nothing Then
      strErr = "无表头数据"
      Exit Function
   End If
   
   
   If eleHead.getAttribute("csource") <> "店内加工标准配方" And eleHead.getAttribute("csource") <> "店内加工补差" Then  '非零售系统不处理
     SetMaterialOutVouch = True
     Exit Function
   End If
   '设置表头数据
   '****************
   eleHead.setAttribute "vt_id", GetDefaultVtId("11")
   
   eleHead.setAttribute "cvouchtype", "11"
   eleHead.setAttribute "cmaker", mLogin.cUserName
   '取默认出入库类别
   If eleHead.getAttribute("csource") = "店内加工标准配方" Then
        eleHead.setAttribute "crdcode", oDefSet.getDefData("bzpfoutcode", m_conn, "ST")
        eleHead.setAttribute "cmemo", "店内加工标准配方出库"
   Else
        eleHead.setAttribute "crdcode", oDefSet.getDefData("shcyoutcode", m_conn, "ST")
        eleHead.setAttribute "cmemo", "店内加工补差出库"
   End If
  
   eleHead.setAttribute "csource", "零售"
   eleHead.setAttribute "beai", 1
   
   Dim sLsDate As String
   If Not IsNull(eleHead.getAttribute("ddate")) Then
      sLsDate = eleHead.getAttribute("ddate")
      sLsDate = Format(sLsDate, "yyyy-mm-dd")
      eleHead.setAttribute "ddate", sLsDate
   End If
   
   
   Dim sCode As String
    If IsNull(eleHead.getAttribute("ccode")) Then
       sCode = ""
    Else
       sCode = eleHead.getAttribute("ccode")
    End If
    If sCode = "" Then
        eleHead.setAttribute "ccode", SetBillSerial(oVoucherCo.Login, TypeToSys("11"), domHead, False)
    End If
   '设置表体数据,主要调用CO服务与销售提供服务设置数据
   '***************
   Dim iRow As Long
   Dim ele As IXMLDOMElement
   Dim tmpDomBody As DOMDocument
   Dim oInvVo As Object
   Dim sBatch As String
   Dim iMassDate As String
   Dim dMadedate As String
   Dim dDisdate As String
   Dim cMassunit As String
   Dim errMsg As String
   Dim eleTmp As IXMLDOMElement
   
   
   iRow = 0
   For Each ele In domBody.selectNodes("//z:row")
      iRow = iRow + 1
      Set tmpDomBody = GetLineDom(domBody, iRow)
      
      If Not oVoucherCo.CheckBody("11", nInsert, 1, "cinvcode", tmpDomBody, errMsg, domHead) Then
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      Set oInvVo = CreateObject("userpvo.Inventory")
      If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) Then
            Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
            If oInvVo.GroupType = 0 Then '0:无计量;1:固定
               eleTmp.setAttribute "cassunit", ""
               eleTmp.setAttribute "iinvexchrate", ""
               eleTmp.setAttribute "inum", ""
               
               eleTmp.setAttribute "iquantity", CDbl(ele.getAttribute("inum"))
               
               ele.setAttribute "cassunit", ""
               ele.setAttribute "iinvexchrate", ""
               ele.setAttribute "inum", ""
               
                              
               If Not oVoucherCo.CheckBody("11", nInsert, 1, "iquantity", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            ElseIf oInvVo.GroupType = 1 Then
               eleTmp.setAttribute "cassunit", ele.getAttribute("cassunit")
               If Not oVoucherCo.CheckBody("11", nInsert, 1, "cassunit", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               eleTmp.setAttribute "inum", ele.getAttribute("inum")
               If Not oVoucherCo.CheckBody("11", nInsert, 1, "inum", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            End If
            
      Else
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      
      End If
      '赋自由项
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      eleTmp.setAttribute "cfree1", ele.getAttribute("cfree1")
      eleTmp.setAttribute "cfree2", ele.getAttribute("cfree2")
      eleTmp.setAttribute "cfree3", ele.getAttribute("cfree3")
      eleTmp.setAttribute "cfree4", ele.getAttribute("cfree4")
      eleTmp.setAttribute "cfree5", ele.getAttribute("cfree5")
      eleTmp.setAttribute "cfree6", ele.getAttribute("cfree6")
      eleTmp.setAttribute "cfree7", ele.getAttribute("cfree7")
      eleTmp.setAttribute "cfree8", ele.getAttribute("cfree8")
      eleTmp.setAttribute "cfree9", ele.getAttribute("cfree9")
      eleTmp.setAttribute "cfree10", ele.getAttribute("cfree10")
      
       eleTmp.setAttribute "cposition", NullToStr(ele.getAttribute("cposition"))
      
      '取批次生产日期失效日期等
      
      sBatch = CStr(ele.getAttribute("cbatch"))
      
      If oInvVo.IsBatch Then
            '此服务中没有仓库信息，不正确，待修改
            oDefSet.getBatch NullToStr(eleHead.getAttribute("cwhcode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), _
                             NullToStr(ele.getAttribute("cfree2")), NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), _
                             NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), NullToStr(ele.getAttribute("cfree7")), _
                             NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), _
                             sBatch, cMassunit, iMassDate, dMadedate, dDisdate, m_conn
            
            eleTmp.setAttribute "cbatch", sBatch
            eleTmp.setAttribute "dmadedate", dMadedate
            eleTmp.setAttribute "dvdate", dDisdate
      Else
            eleTmp.setAttribute "cbatch", ""
      End If
      
      setNodeValue eleTmp, ele 'tmpDomBody.selectSingleNode("//z:row"), ele
   Next
   SetMaterialOutVouch = True
   Exit Function
errhandle:
   strErr = Err.Description
End Function

'处理产成品入库单
Private Function SetProductInVouch(ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, ByRef strErr As String) As Boolean
   Dim eleHead As IXMLDOMElement
   Dim eleBody As IXMLDOMElement
   Dim attr As IXMLDOMAttribute
   On Error GoTo errhandle
   SetProductInVouch = False
   Set eleHead = domHead.selectSingleNode("//z:row")
   If eleHead Is Nothing Then
      strErr = "无表头数据"
      Exit Function
   End If
   
   
   If eleHead.getAttribute("csource") <> "店内加工入库" Then  '非零售系统不处理
     SetProductInVouch = True
     Exit Function
   End If
   '设置表头数据
   '****************
   eleHead.setAttribute "vt_id", GetDefaultVtId("10")
   eleHead.setAttribute "csource", "零售"
   eleHead.setAttribute "cvouchtype", "10"
   eleHead.setAttribute "cmaker", mLogin.cUserName
   '取默认出入库类别
  
    eleHead.setAttribute "crdcode", oDefSet.getDefData("dnjgincode", m_conn, "ST")
    eleHead.setAttribute "cmemo", "店内加工入库"
    'eleHead.setAttribute "editprop", "A"
 
  
   
   eleHead.setAttribute "beai", 1
   
   Dim sLsDate As String
   If Not IsNull(eleHead.getAttribute("ddate")) Then
      sLsDate = eleHead.getAttribute("ddate")
      sLsDate = Format(sLsDate, "yyyy-mm-dd")
      eleHead.setAttribute "ddate", sLsDate
   End If
   
   
   Dim sCode As String
    If IsNull(eleHead.getAttribute("ccode")) Then
       sCode = ""
    Else
       sCode = eleHead.getAttribute("ccode")
    End If
    If sCode = "" Then
        eleHead.setAttribute "ccode", SetBillSerial(oVoucherCo.Login, TypeToSys("10"), domHead, False)
    End If
   '设置表体数据,主要调用CO服务与销售提供服务设置数据
   '***************
   Dim iRow As Long
   Dim ele As IXMLDOMElement
   Dim tmpDomBody As DOMDocument
   Dim oInvVo As Object
   Dim sBatch As String
   Dim iMassDate As String
   Dim dMadedate As String
   Dim dDisdate As String
   Dim cMassunit As String
   Dim errMsg As String
   Dim eleTmp As IXMLDOMElement
   
   
   iRow = 0
   For Each ele In domBody.selectNodes("//z:row")
      iRow = iRow + 1
      Set tmpDomBody = GetLineDom(domBody, iRow)
      
      If Not oVoucherCo.CheckBody("10", nInsert, 1, "cinvcode", tmpDomBody, errMsg, domHead) Then
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      Set oInvVo = CreateObject("userpvo.Inventory")
      If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) Then
            Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
            If oInvVo.GroupType = 0 Then '0:无计量;1:固定
               eleTmp.setAttribute "cassunit", ""
               eleTmp.setAttribute "iinvexchrate", ""
               eleTmp.setAttribute "inum", ""
               
               eleTmp.setAttribute "iquantity", CDbl(ele.getAttribute("inum"))
               
               ele.setAttribute "cassunit", ""
               ele.setAttribute "iinvexchrate", ""
               ele.setAttribute "inum", ""
               
                              
               If Not oVoucherCo.CheckBody("10", nInsert, 1, "iquantity", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            ElseIf oInvVo.GroupType = 1 Then
               eleTmp.setAttribute "cassunit", ele.getAttribute("cassunit")
               If Not oVoucherCo.CheckBody("10", nInsert, 1, "cassunit", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               eleTmp.setAttribute "inum", ele.getAttribute("inum")
               If Not oVoucherCo.CheckBody("10", nInsert, 1, "inum", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            End If
            
      Else
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      
      '赋自由项
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      eleTmp.setAttribute "cfree1", ele.getAttribute("cfree1")
      eleTmp.setAttribute "cfree2", ele.getAttribute("cfree2")
      eleTmp.setAttribute "cfree3", ele.getAttribute("cfree3")
      eleTmp.setAttribute "cfree4", ele.getAttribute("cfree4")
      eleTmp.setAttribute "cfree5", ele.getAttribute("cfree5")
      eleTmp.setAttribute "cfree6", ele.getAttribute("cfree6")
      eleTmp.setAttribute "cfree7", ele.getAttribute("cfree7")
      eleTmp.setAttribute "cfree8", ele.getAttribute("cfree8")
      eleTmp.setAttribute "cfree9", ele.getAttribute("cfree9")
      eleTmp.setAttribute "cfree10", ele.getAttribute("cfree10")
      
      eleTmp.setAttribute "cposition", NullToStr(ele.getAttribute("cposition"))
       
       
      '取批次生产日期失效日期等
      
      sBatch = CStr(ele.getAttribute("cbatch"))
      dDisdate = CStr(ele.getAttribute("dvdate"))
      
      If oInvVo.IsBatch Then
      
            If sBatch <> "" And dDisdate <> "" Then
               eleTmp.setAttribute "cbatch", ele.getAttribute("cbatch")
               eleTmp.setAttribute "dvdate", ele.getAttribute("dvdate")
               If Not oVoucherCo.CheckBody("10", nInsert, 1, "dvdate", tmpDomBody, errMsg, domHead) Then
                  Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            Else
                  '此服务中没有仓库信息，不正确，待修改
                  oDefSet.getBatch NullToStr(eleHead.getAttribute("cwhcode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), _
                                   NullToStr(ele.getAttribute("cfree2")), NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), _
                                   NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), NullToStr(ele.getAttribute("cfree7")), _
                                   NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), _
                                   sBatch, cMassunit, iMassDate, dMadedate, dDisdate, m_conn
                  
                  eleTmp.setAttribute "cbatch", sBatch
                  eleTmp.setAttribute "dmadedate", dMadedate
                  eleTmp.setAttribute "dvdate", dDisdate
            End If
      Else
           eleTmp.setAttribute "cbatch", ""
      End If
      
      setNodeValue eleTmp, ele 'tmpDomBody.selectSingleNode("//z:row"), ele
   Next
   SetProductInVouch = True
   Exit Function
errhandle:
   strErr = Err.Description
End Function


Private Sub Class_Initialize()
   Set oDefSet = CreateObject("U8SCMImpDefValSet.clsSCMImpDefValSet")
    
End Sub

Private Sub Class_Terminate()
  If Not (oDefSet Is Nothing) Then
     Set oDefSet = Nothing
  End If
End Sub


Private Sub SetExpiratDateInfo(ele As IXMLDOMElement, ByVal strvDate As String, ByVal sDateCalcu As String)
    
    strvDate = Format(strvDate, "yyyy-mm-dd")
    If sDateCalcu = "1" Then
       ele.setAttribute "dexpirationdate", DateAdd("D", -1, Left(strvDate, 7) & "-01")
       ele.setAttribute "cexpirationdate", Format(DateAdd("D", -1, Left(strvDate, 7) & "-01"), "YYYY-MM")
    ElseIf sDateCalcu = "2" Then
       ele.setAttribute "dexpirationdate", DateAdd("D", -1, strvDate)
       ele.setAttribute "cexpirationdate", Format(DateAdd("D", -1, strvDate), "YYYY-MM-DD")
    End If
End Sub


Public Function QueryAppTransVouch(ByVal eleList As IXMLDOMNodeList, ByRef sRetXml As String) As Boolean
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
    
    sql = " select *,convert(nvarchar(60),null) as yhrq  from transrequestm  " & GetQueryAppVouchCondition(eleList, m_conn)
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
        Call EXmlToRs.RStoXmlHead(el, "TransAppVouchXmlRs.Xml", rs)
        sql = "select b.*,(case when i.igrouptype = 0 then isnull(b.itvchkquantity,0)  "
        sql = sql & " when i.igrouptype=1 then (isnull(b.itvchkquantity,0)/unit.ichangrate) " & _
              "       when i.igrouptype=2 then ( case when i.ccomunitcode=isnull(i.cshopunit,N'') then isnull(b.itvchkquantity,0) else isnull(b.itvchknum,0) end) " & _
              " end ) as lsqty ,convert(nvarchar(60),null) as yhkc,convert(nvarchar(60),null) as yhje,convert(nvarchar(60),null) as xsqty,convert(nvarchar(60),null) as xsje "
        sql = sql & " from  transrequestd  b inner join inventory i with (nolock) on b.cinvcode = i.cinvcode "
        sql = sql & " left join ComputationUnit unit on i.cshopunit=unit.ccomunitcode "
        sql = sql & " where id= " & rs("id") & " and isnull(b.itvchkquantity,0)>0.000001 "
        rsDetail.Open sql, m_conn, adOpenStatic, adLockBatchOptimistic
        If rsDetail.RecordCount > 0 Then
           rsDetail.MoveFirst
           While Not rsDetail.EOF
                rsDetail.fields("itvchkquantity") = rsDetail.fields("lsqty")
                rsDetail.MoveNext
           Wend
           rsDetail.MoveFirst
        End If
        
        Call EXmlToRs.RStoXmlBody(el, "TransAppVouchXmlRs.Xml", rsDetail)
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
            m_conn.Execute "update st_apptransvouch set bIsLsQuery=1 where id= " & rs("id")
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

Private Function GetQueryAppVouchCondition(eleList As IXMLDOMNodeList, ByRef conn As Connection) As String
'================================================================================
On Error GoTo Error_General_Handler:
Const PROC_SIG As String = "GetQueryAppVouchCondition"
'Call TraceIn(PROC_SIG)
    Dim rs As New Recordset
    Dim ele As IXMLDOMElement
    Dim fld As ADODB.Field
    Dim where As String
    rs.Open "select * from transrequestm where 1>1", conn, adOpenForwardOnly, adLockReadOnly
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
  
    GetQueryAppVouchCondition = " where " & IIf(where <> "", " (" & where & ")", "1=1")
    '单据的EAI后台服务在拼条件时需要针对时间戳条件特殊处理——和其他条件用括号分离开，形式为：（时间戳条件） and（界面设置的其他条件）。
    If sUftsWhere <> "" Then
        GetQueryAppVouchCondition = GetQueryAppVouchCondition & " and (" & sUftsWhere & ")"
    End If
    GetQueryAppVouchCondition = GetQueryAppVouchCondition & " and isnull(cbustype,'')=N'退货申请' and isnull(bislsquery,0)=0 and isnull(cverifyperson,'')<>N'' and isnull(ccloser,'')=''"
    
    GetQueryAppVouchCondition = GetQueryAppVouchCondition & " and not exists (select autoid from st_apptransvouchs where id =transrequestm.id and isnull(cbcloser,'')<>'') "
    GetQueryAppVouchCondition = GetQueryAppVouchCondition & " and exists (select autoid from st_apptransvouchs where id =transrequestm.id and isnull(itvchkquantity,0)>0.000001) "
    
    Exit Function
'Call TraceOut(PROC_SIG)
ExitFunction:
  Exit Function
Error_General_Handler:
  GetQueryAppVouchCondition = ""
  GoTo ExitFunction
End Function


'设置货位调整单缺省值
Private Function SetAdjustPVouch(ByRef domHead As DOMDocument, ByRef domBody As DOMDocument, ByRef strErr As String) As Boolean
   Dim eleHead As IXMLDOMElement
   Dim eleBody As IXMLDOMElement
   Dim attr As IXMLDOMAttribute
   On Error GoTo errhandle
   SetAdjustPVouch = False
   Set eleHead = domHead.selectSingleNode("//z:row")
   If eleHead Is Nothing Then
      strErr = "无表头数据"
      Exit Function
   End If
    
   '设置表头数据
   '****************
   eleHead.setAttribute "vt_id", GetDefaultVtId("19")
   eleHead.setAttribute "csource", "2"
   eleHead.setAttribute "cmaker", mLogin.cUserName
   '取默认出入库类别
   eleHead.setAttribute "beai", 1
   Dim sCode As String
   sCode = ""
'    If IsNull(eleHead.getAttribute("cvouchcode")) Then
'       sCode = ""
'    Else
'       sCode = eleHead.getAttribute("cvouchcode")
'    End If
    If sCode = "" Then
        eleHead.setAttribute "cvouchcode", SetBillSerial(oVoucherCo.Login, TypeToSys("19"), domHead, False)
    End If
   '设置表体数据,主要调用CO服务与销售提供服务设置数据
   '***************
   Dim iRow As Long
   Dim ele As IXMLDOMElement
   Dim tmpDomBody As DOMDocument
   Dim oInvVo As Object
   Dim sBatch As String
   Dim iMassDate As String
   Dim dMadedate As String
   Dim dDisdate As String
   Dim cMassunit As String
   Dim errMsg As String
   Dim eleTmp As IXMLDOMElement
   
   
   iRow = 0
   For Each ele In domBody.selectNodes("//z:row")
      iRow = iRow + 1
      Set tmpDomBody = GetLineDom(domBody, iRow)
      
      If Not oVoucherCo.CheckBody("19", nInsert, 1, "cinvcode", tmpDomBody, errMsg, domHead) Then
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      Set oInvVo = CreateObject("userpvo.Inventory")
      If oInvObj.Load(ele.getAttribute("cinvcode"), oInvVo, errMsg) Then
            Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
            If oInvVo.GroupType = 0 Then '0:无计量;1:固定
               eleTmp.setAttribute "cassunit", ""
               eleTmp.setAttribute "iinvexchrate", ""
               eleTmp.setAttribute "inum", ""
               
               eleTmp.setAttribute "iquantity", CDbl(ele.getAttribute("inum"))
               
               ele.setAttribute "cassunit", ""
               ele.setAttribute "iinvexchrate", ""
               ele.setAttribute "inum", ""
               
                              
               If Not oVoucherCo.CheckBody("19", nInsert, 1, "iquantity", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            ElseIf oInvVo.GroupType = 1 Then
               eleTmp.setAttribute "cassunit", ele.getAttribute("cassunit")
               If Not oVoucherCo.CheckBody("19", nInsert, 1, "cassunit", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
               Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
               eleTmp.setAttribute "inum", ele.getAttribute("inum")
               If Not oVoucherCo.CheckBody("19", nInsert, 1, "inum", tmpDomBody, errMsg, domHead) Then
                   Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            End If
            
      Else
         Err.Raise vbObjectError + 100, , errMsg & vbCrLf
      End If
      
      '赋自由项
      Set eleTmp = tmpDomBody.selectSingleNode("//z:row")
      eleTmp.setAttribute "cfree1", ele.getAttribute("cfree1")
      eleTmp.setAttribute "cfree2", ele.getAttribute("cfree2")
      eleTmp.setAttribute "cfree3", ele.getAttribute("cfree3")
      eleTmp.setAttribute "cfree4", ele.getAttribute("cfree4")
      eleTmp.setAttribute "cfree5", ele.getAttribute("cfree5")
      eleTmp.setAttribute "cfree6", ele.getAttribute("cfree6")
      eleTmp.setAttribute "cfree7", ele.getAttribute("cfree7")
      eleTmp.setAttribute "cfree8", ele.getAttribute("cfree8")
      eleTmp.setAttribute "cfree9", ele.getAttribute("cfree9")
      eleTmp.setAttribute "cfree10", ele.getAttribute("cfree10")
      
      eleTmp.setAttribute "cbposcode", NullToStr(ele.getAttribute("cbposcode"))
      eleTmp.setAttribute "caposcode", NullToStr(ele.getAttribute("caposcode"))
      '取批次生产日期失效日期等
      
      sBatch = CStr(ele.getAttribute("cbatch"))
      dDisdate = CStr(ele.getAttribute("ddisdate"))
      
      If oInvVo.IsBatch Then
      
            If sBatch <> "" And dDisdate <> "" Then
               eleTmp.setAttribute "cbatch", ele.getAttribute("cbatch")
               eleTmp.setAttribute "ddisdate", ele.getAttribute("ddisdate")
               If Not oVoucherCo.CheckBody("19", nInsert, 1, "ddisdate", tmpDomBody, errMsg, domHead) Then
                  Err.Raise vbObjectError + 100, , errMsg & vbCrLf
               End If
            Else
                  '此服务中没有仓库信息，不正确，待修改
                  oDefSet.getBatch NullToStr(eleHead.getAttribute("cwhcode")), NullToStr(ele.getAttribute("cinvcode")), NullToStr(ele.getAttribute("cfree1")), _
                                   NullToStr(ele.getAttribute("cfree2")), NullToStr(ele.getAttribute("cfree3")), NullToStr(ele.getAttribute("cfree4")), _
                                   NullToStr(ele.getAttribute("cfree5")), NullToStr(ele.getAttribute("cfree6")), NullToStr(ele.getAttribute("cfree7")), _
                                   NullToStr(ele.getAttribute("cfree8")), NullToStr(ele.getAttribute("cfree9")), NullToStr(ele.getAttribute("cfree10")), _
                                   sBatch, cMassunit, iMassDate, dMadedate, dDisdate, m_conn
                  
                  eleTmp.setAttribute "cbatch", sBatch
                  eleTmp.setAttribute "dmadedate", dMadedate
                  eleTmp.setAttribute "ddisdate", dDisdate
            End If
      Else
           eleTmp.setAttribute "cbatch", ""
      End If
      
      setNodeValue eleTmp, ele 'tmpDomBody.selectSingleNode("//z:row"), ele
   Next
   SetAdjustPVouch = True
   Exit Function
errhandle:
   strErr = Err.Description
End Function

