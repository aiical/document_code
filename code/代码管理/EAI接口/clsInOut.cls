VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsInOut"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Description = "请输入模块的功能和目的,以及依赖的外部条件"
Attribute VB_Ext_KEY = "clsInOutModHeaded" ,"True"
Attribute VB_Ext_KEY = "GetQueryConditionFunctionScripted" ,"True"
Attribute VB_Ext_KEY = "AddSingleFunctionScripted" ,"True"
'*********************************************************************************
'模块: clsInOut
'文件: clsInOut.cls
'版权: 北京用友软件股份有限公司
'作者: 李亮
'审核:
'日期: 2002-05-16
'说明:EAI专用接口类模块
'
'
'修改:
'
'
'*********************************************************************************
Option Explicit

'错误处理的Domdocument
Dim oLogin As U8Login.clsLogin
Dim m_errDom As DOMDocument
Dim sRootTag As String
Dim m_conn As New ADODB.Connection

Dim m_bCustomQry As Boolean

'处理EAI多页导出功能
Public gObjRef As Object


Public Function AddObjectReference(Caller As Object) As Boolean
  On Error GoTo AddObjectReferenceError
  Set gObjRef = Caller
  AddObjectReference = True
  Exit Function
AddObjectReferenceError:
  AddObjectReference = False
  Exit Function
End Function

Public Function DropObjectReference(Caller As Object) As Boolean
   On Error GoTo DropObjReferenceError
      If gObjRef Is Caller Then
        DropObjectReference = True
      Else
        DropObjectReference = False
      End If
    Exit Function
DropObjReferenceError:
      DropObjectReference = False
      Exit Function
End Function




Public Function Transact(ByVal sXML As String, ByRef Login As U8Login.clsLogin) As Variant
    On Error GoTo Err_log
    Dim dom As New DOMDocument
    Dim retDom As New DOMDocument
    Dim ele As IXMLDOMElement
    Dim EleLst As IXMLDOMNodeList
    Dim docid As String
    Dim proc As String
    Dim rs As New ADODB.Recordset
    Dim sproc As String
    Dim sRetXml As String
    Set m_errDom = New DOMDocument
    Dim sErr As String
    Dim clsAppTrans As clsAppTransEai
    
   
    '********************
'    Dim tmpdom As New DOMDocument
'    tmpdom.Load "c:\零售产成品入库.xml"
'
'    sXML = tmpdom.xml
'
    '********************
    
    Dim clsOtherIn As clsOtherInEai
    Dim clsSaleOut As clsSaleOutEai
    If Login Is Nothing Then
        Transact = ReturnXml("100", "login传入错误")
        Exit Function
        'm_conn.Open "PROVIDER=SQLOLEDB;data source=jxq2003;user id=SA;password=;initial catalog=UFDATA_019_2007;Connect Timeout=30;Current Language=Simplified Chinese;"
    Else
        m_conn.Open Login.UfDbName
    End If
    Set oLogin = Login
    If Not dom.loadXML(sXML) Then   '如果不能Load
'Result:Row=57  Col=35  Content="解析XML时发生错误,请你检查XML参数格式" ID=7a67b609-a4a8-464b-9cb4-74c9ab6b1f9b
        Transact = ReturnXml("100", GetResString("U8.ST.EaiStoreInOut.clsinout.00001"))
        Exit Function
    End If
    
    '此代码为调试时调试工具使用,
    Dim sFileName As String
'    sFileName = Now()
'    sFileName = Replace(sFileName, " ", "")
'    sFileName = Replace(sFileName, ":", "")
'    sFileName = Replace(sFileName, "-", "")
'    sFileName = sFileName & "STEai.xml"
'    dom.save "c:\" & sFileName
    
    sRootTag = GetAttrValue(dom.documentElement, "roottag")
    Set ele = dom.documentElement
    
    m_bCustomQry = False
    
    If ele Is Nothing Then
'Result:Row=64  Col=35  Content="ufinterface结点不存在" ID=1c64f095-85de-4822-ae8e-902aedb96e45
        Transact = ReturnXml("101", GetResString("U8.ST.EaiStoreInOut.clsinout.00002"))
        Exit Function
    End If
    docid = GetAttrValue(dom.documentElement, "docid")
    proc = GetAttrValue(dom.documentElement, "proc")
    m_errDom.loadXML (GetErrorTemplate(docid, proc))
    '取得操作类型
    
    Dim oTypeEle As IXMLDOMElement
    
    sproc = GetAttrValue(ele, "proc")
        Select Case UCase(sproc)
        Case "ADD"    '导入添加
            If LCase(sRootTag) = "storequantity" Then
'Result:Row=76  Col=43  Content="库存量不支持导入功能!" ID=f4c5c0ed-d6f0-4441-9ce2-6905fd8351db
                Transact = ReturnXml("888", GetResString("U8.ST.EaiStoreInOut.clsinout.00003"))
                Exit Function
            ElseIf LCase(sRootTag) = "storeqc" Then '库存期初导入
                Set EleLst = ele.selectNodes(sRootTag)
                Call AddProcQc(EleLst, sRetXml)
            ElseIf LCase(sRootTag) = "qcscrapvouch" Then
                Set EleLst = ele.selectNodes(sRootTag)
                Call AddProcQcScrapVouch(EleLst, sRetXml)
            ElseIf LCase(sRootTag) = "apptransvouch" Or LCase(sRootTag) = "transvouch" _
                   Or LCase(sRootTag) = "checkvouch" Or LCase(sRootTag) = "stotheroutvouch" _
                   Or LCase(sRootTag) = "materialoutvouch" Or LCase(sRootTag) = "productinvouch" Or LCase(sRootTag) = "adjustposition" Then   '零售接口,材料出库，产成品入库,货位调整单
                   
                Set EleLst = ele.selectNodes(sRootTag)
                Call AddLsProc(sRootTag, EleLst, sRetXml)
            ElseIf LCase(sRootTag) = "stapptransvouch" Then '库存调拨申请单,与零售系统不同
                Set EleLst = ele.selectNodes(sRootTag)
                Set clsAppTrans = New clsAppTransEai
                clsAppTrans.Init oLogin, m_conn, m_errDom, sRootTag, sErr
                Set clsAppTrans.gObjRef = gObjRef
                Call clsAppTrans.AddProc(EleLst, sRetXml, sRootTag)
                Set clsAppTrans = Nothing
            ElseIf LCase(sRootTag) = "stotherinvouch" Then '导入库存其他入库单
               Set EleLst = ele.selectNodes(sRootTag)
               Set clsOtherIn = New clsOtherInEai
               clsOtherIn.Init oLogin, m_conn, m_errDom, sRootTag, sErr
               Set clsOtherIn.gObjRef = gObjRef
               Call clsOtherIn.AddProc(EleLst, sRetXml, sRootTag)
               Set clsOtherIn = Nothing
            ElseIf LCase(sRootTag) = "storein" Or LCase(sRootTag) = "storeout" Then
                Set EleLst = ele.selectNodes(sRootTag)
                Call AddProc(EleLst, sRetXml, LCase(sRootTag))
            ElseIf LCase(sRootTag) = "stmodifyqueryflag" Then '上传零售接受标识
               Call ModifyLsQueryFlag(ele, sRetXml, sRootTag)
            Else
               Transact = ReturnXml("888", "库存EAI不支持" & sRootTag & "类型的导入功能!")
               Exit Function
            End If
        Case "QUERY"    '导出参照查询
            If LCase(sRootTag) = "storequantity" Then
                '库存展望
                sRetXml = KCZWTable(oLogin, dom, sRetXml)
            ElseIf LCase(sRootTag) = "transvouch" Then
                sRetXml = dom.xml
                
                 Set oTypeEle = ele.selectSingleNode(sRootTag)
                
                If Not (oTypeEle Is Nothing) Then
                    If Not IsNull(oTypeEle.getAttribute("type")) Then
                       If LCase(oTypeEle.getAttribute("type")) = "custom" Then
                            m_bCustomQry = True
                       End If
                    End If
                End If
                
                If m_bCustomQry = False Then
                    Set EleLst = ele.selectNodes(sRootTag & "/field")
                Else
                    Set EleLst = ele.selectNodes(sRootTag & "/sql")
                End If
                
                'Set EleLst = ele.selectNodes(sRootTag & "/field")
                Call QueryProcT(EleLst, sRetXml)
            ElseIf LCase(sRootTag) = "storeqc" Then '库存期初导入
'Result:Row=95  Col=43  Content="库存期初只支持导入的功能,请查看Proc的值！"     ID=770a6d63-0fa8-4051-a62b-ad1418422536
                Transact = ReturnXml("710", GetResString("U8.ST.EaiStoreInOut.clsinout.00004"))
                Exit Function
            ElseIf LCase(sRootTag) = "qcscrapvouch" Then
                Transact = ReturnXml("710", GetResString("U8.ST.EaiStoreInOut.clsinout.00004"))
                Exit Function
            ElseIf LCase(sRootTag) = "currentstock" Then
                sRetXml = dom.xml
                Dim bQueryPos As Boolean
                bQueryPos = False
               
                Dim oCur  As IXMLDOMElement
                Set oCur = ele.selectSingleNode("//currentstock")
                If Not oCur Is Nothing Then
                  If Not IsNull(oCur.getAttribute("bquerypos")) Then
                     If oCur.getAttribute("bquerypos") = "1" Then
                        bQueryPos = True
                     End If
                  End If
                End If
               
               Set EleLst = ele.selectNodes(sRootTag & "/field")
               
                If bQueryPos Then
                    Call QueryProcCurrentStock(EleLst, sRetXml)
               Else
                    Call QueryProcCurrentStockNoPos(EleLst, sRetXml)
               End If
               
               'Call QueryProcCurrentStock(EleLst, sRetXml)
            ElseIf LCase(sRootTag) = "stapptransvouch" Then '导出库存调拨申请单
               sRetXml = dom.xml
               Set clsAppTrans = New clsAppTransEai
               clsAppTrans.Init oLogin, m_conn, m_errDom, sRootTag, sErr
               Set clsAppTrans.gObjRef = gObjRef
               Set EleLst = ele.selectNodes(sRootTag & "/field")
               Call clsAppTrans.QueryProc(EleLst, sRetXml)
               Set clsAppTrans = Nothing
            ElseIf LCase(sRootTag) = "stotherinvouch" Then '导出库存其他入库单
               sRetXml = dom.xml
               Set clsOtherIn = New clsOtherInEai
               clsOtherIn.Init oLogin, m_conn, m_errDom, sRootTag, sErr
               Set clsOtherIn.gObjRef = gObjRef
               Set EleLst = ele.selectNodes(sRootTag & "/field")
               Call clsOtherIn.QueryProc(EleLst, sRetXml)
               Set clsOtherIn = Nothing
            ElseIf LCase(sRootTag) = "stsaleoutvouch" Then '导出库存销售出库单
               sRetXml = dom.xml
               Set clsSaleOut = New clsSaleOutEai
               clsSaleOut.Init oLogin, m_conn, m_errDom, sRootTag, sErr
               Set clsSaleOut.gObjRef = gObjRef
               Set EleLst = ele.selectNodes(sRootTag & "/field")
               Call clsSaleOut.QueryProc(EleLst, sRetXml)
               Set clsSaleOut = Nothing
            ElseIf LCase(sRootTag) = "currentstockst" Then '移动查询现存量
                sRetXml = DoQueryCurrentStock(sXML, GetAttrValue(dom.selectSingleNode("//csubid "), "cquerysubid"))
            ElseIf LCase(sRootTag) = "adjustposition" Then '导出货位调整单
                sRetXml = dom.xml
                Set EleLst = ele.selectNodes(sRootTag & "/field")
                QueryAdjustPosProc EleLst, sRetXml
           ElseIf LCase(sRootTag) = "apptransvouch" Then
                sRetXml = dom.xml
                Set EleLst = ele.selectNodes(sRootTag & "/field")
                Dim oLsClass As New clsLsKcEai
                
                Set oLsClass.gObjRef = gObjRef
                oLsClass.SetLogin oLogin, m_conn, sErr
                oLsClass.QueryAppTransVouch EleLst, sRetXml
                Set oLsClass = Nothing
            ElseIf LCase(sRootTag) = "storein" Or LCase(sRootTag) = "storeout" Then
                sRetXml = dom.xml
                
                Set oTypeEle = ele.selectSingleNode(sRootTag)
                
                If Not (oTypeEle Is Nothing) Then
                    If Not IsNull(oTypeEle.getAttribute("type")) Then
                       If LCase(oTypeEle.getAttribute("type")) = "custom" Then
                            m_bCustomQry = True
                       End If
                    End If
                End If
                
                If m_bCustomQry = False Then
                    Set EleLst = ele.selectNodes(sRootTag & "/field")
                Else
                    Set EleLst = ele.selectNodes(sRootTag & "/sql")
                End If
                'Set EleLst = ele.selectNodes(sRootTag & "/field")
                
                Call QueryProc(EleLst, sRetXml, LCase(sRootTag))
            Else
                Transact = ReturnXml("710", "库存EAI不支持" & sRootTag & "类型的导出功能!")
                Exit Function
            End If
        Case "EMPTY"    '清空
           
            If LCase(sRootTag) = "storeqc" Then '库存期初导入
                
                Call EmptyQc(sRetXml)
            ElseIf LCase(sRootTag) = "qcscrapvouch" Then
                Call EmptyQcscrap(sRetXml)
            
            End If
        Case Else       '其它错误处理
'Result:Row=104 Col=39  Content="出入库单只支持导出和添加的功能，库存量只支持导出功能。请查看Proc的值！"        ID=57169fee-ea41-4739-93ed-7d54a40268d7
            Transact = ReturnXml("710", GetResString("U8.ST.EaiStoreInOut.clsinout.00005"))
            Exit Function
    End Select
    Set dom = Nothing
    Transact = sRetXml
    Exit Function
Err_log:
  Transact = ReturnXml(CStr(Err.Number), Err.Description)
    Err.Clear
End Function

'*****************************************
'添加操作 Elelst 订单集,sRetXml返回描述
'****************************************
Private Sub AddProc(ByVal EleLst As IXMLDOMNodeList, ByRef sRetXml As String, ByVal sRoot As String)
    On Error GoTo Err_log
    Dim TmpEle As IXMLDOMElement
    'TmpEle为一张定单的内容
    For Each TmpEle In EleLst
        Call AddSingle(TmpEle, sRoot)
    Next
    sRetXml = m_errDom.xml
    Exit Sub
Err_log:
    Call ErrDomAppendChild(m_errDom, "", 999, Err.Description)
    sRetXml = m_errDom.xml
End Sub
'库存期初导入
Private Sub AddProcQc(ByVal EleLst As IXMLDOMNodeList, ByRef sRetXml As String)
    On Error GoTo Err_log
    Dim TmpEle As IXMLDOMElement
    'TmpEle为一张定单的内容
    For Each TmpEle In EleLst
        Call AddQc(TmpEle)
    Next
    sRetXml = m_errDom.xml
    Exit Sub
Err_log:
    Call ErrDomAppendChild(m_errDom, "", 999, Err.Description)
    sRetXml = m_errDom.xml
End Sub

'库存期初不合格品单导入
Private Sub AddProcQcScrapVouch(ByVal EleLst As IXMLDOMNodeList, ByRef sRetXml As String)
    On Error GoTo Err_log
    Dim TmpEle As IXMLDOMElement
    'TmpEle为一张定单的内容
    For Each TmpEle In EleLst
        Call AddQcScrapVouch(TmpEle)
    Next
    sRetXml = m_errDom.xml
    Exit Sub
Err_log:
    Call ErrDomAppendChild(m_errDom, "", 999, Err.Description)
    sRetXml = m_errDom.xml
End Sub

Private Function AddSingle(ByVal ele As IXMLDOMElement, ByVal sRoot As String) As Boolean
'Result:Row=179 Col=36  Content="'' 处理单张订单"       ID=f066b7ff-6b8b-4143-9142-3fa2d055cd7b
'================================================================================
'模块: clsInOut   Function: AddSingle
'作者:
'日期: 2002-05-16
'--------------------------------------------------------------------------------
'说明: 处理单张单据
'
'--------------------------------------------------------------------------------
'参数:
'   输入 ele:一张单据的内容
'   输出
'依赖:
'--------------------------------------------------------------------------------
'修改:
'
'================================================================================
'On Error GoTo Error_General_Handler:
'Const PROC_SIG As String = "clsInOut:AddSingle"
'Call TraceIn(PROC_SIG)
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
    Dim rs As New Recordset
    Dim attr As IXMLDOMAttribute
    Dim bBegin As Boolean
    bBegin = False
    
    '是否特殊采购订单入库，专项开发，csource =采购订单入库
    Dim bPurInWithOrder As Boolean
    
    bPurInWithOrder = False
    
    
    Dim bOmFirst As Boolean
    Dim bPuFirst As Boolean
    
    'csl-------------------------

    Set eleHeader = ele.selectSingleNode("header")
    If eleHeader Is Nothing Then
'Result:Row=222 Col=14  Content="没有header节点"        ID=281a3cad-1097-4579-8833-97f050e77a75
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00007")
        GoTo csl
    End If
    
    sSOCode = GetElementValue(eleHeader, "code")
    Set eleBody = ele.selectSingleNode("body")
    If eleBody Is Nothing Then
'Result:Row=230 Col=14  Content="没有body节点"  ID=37648d46-7b24-4561-9480-5a8e300c40cf
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00008")
        GoTo csl
    End If
    
    Dim elVouch As IXMLDOMElement
    
    Dim eTmpEle As IXMLDOMElement
    
    Dim sQueryH As String
    Dim sQueryB As String
    
    Set elVouch = ele.selectSingleNode("header/vouchtype")
    bOmFirst = False
    bPuFirst = False
    
    If elVouch Is Nothing Then
'Result:Row=241 Col=14  Content="单据号为"      ID=6167205b-3b15-44f8-8178-cd5042737dbf
'Result:Row=242 Col=33  Content="vouchtype单据类型节点不存在!"  ID=77a0bfc8-4baf-4262-8dfd-dcb85ef8b66e
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00116", Array(sSOCode))
        GoTo csl
    Else
        Select Case elVouch.Text
            Case "01"
                sQueryH = "zpurRkdHead"
                sQueryB = "zpurRkdTail"
                
                Set eTmpEle = ele.selectSingleNode("header/bomfirst")
                If Not eTmpEle Is Nothing Then
                   If eTmpEle.Text = "1" Then
                       Set eTmpEle = ele.selectSingleNode("header/businesstype")
                       If Not eTmpEle Is Nothing Then
                           If eTmpEle.Text = "委外加工" Then
                              bOmFirst = True
                           End If
                       End If
                   End If
                End If
                
                Set eTmpEle = ele.selectSingleNode("header/source")
                If Not eTmpEle Is Nothing Then
                    If eTmpEle.Text = "采购订单入库" Then
                       bPurInWithOrder = True
                    End If
                End If
                
                
                Set eTmpEle = ele.selectSingleNode("header/bpufirst")
                If Not eTmpEle Is Nothing Then
                   If eTmpEle.Text = "1" Then
                        bPuFirst = True
                   End If
                End If
                
            Case "10"
                sQueryH = "RecordInQ"
                sQueryB = "RecordInSQ"
            Case "08"
                sQueryH = "KCOtherInH"
                sQueryB = "KCOtherInB"
                
            Case "32"
                sQueryH = "KCSaleOutH"
                sQueryB = "KCSaleOutB"
            Case "11"
                sQueryH = "RecordOutQ"
                sQueryB = "RecordOutSQ"
            Case "09"
                sQueryH = "KCOtherOutH"
                sQueryB = "KCOtherOutB"
            Case Else
'Result:Row=267 Col=22  Content="单据号为"      ID=2e162be5-a1bd-41c0-b337-a572456bd75b
'Result:Row=268 Col=41  Content="vouchtype单据类型节点值非法!"  ID=06f161fd-777f-40da-a829-22020d5cbe15
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00009", Array(sSOCode))
                GoTo csl
        End Select
        
    End If
    '01：采购入库单08：其他入库单09：其他出库单10：产成品入库单11：材料出库单32：销售出库单
    
    Set nd = Nothing
    
    For Each nd In ele.selectNodes("header/purchasetypecode")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/saletypecode")
        If elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/customercode")
        If elVouch.Text <> "32" And elVouch.Text <> "09" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/chandler")
        eleHeader.removeChild nd
        
    Next
    For Each nd In ele.selectNodes("header/handler")
        
       eleHeader.removeChild nd
       
    Next
    
    
    For Each nd In ele.selectNodes("header/vendorcode")
        If elVouch.Text <> "01" And elVouch.Text <> "08" Then
            eleHeader.removeChild nd
        End If
    Next
    '*************************
    ' add by tianxl 2004-05-10
    For Each nd In ele.selectNodes("header/exchname")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    For Each nd In ele.selectNodes("header/discounttaxtype")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    '**************************
    For Each nd In ele.selectNodes("header/ordercode")
        If elVouch.Text <> "01" And elVouch.Text <> "10" And elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/arrivecode")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/bomfirst")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/bpufirst")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
     For Each nd In ele.selectNodes("header/cvenpuomprotocol")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/dcreditstart")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/icreditperiod")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/dgatheringdate")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/bcredit")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/billcode")
        If elVouch.Text <> "01" And elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        Else
            nd.Text = "" '包辉测试提议
        End If
    Next
    
    For Each nd In ele.selectNodes("header/consignmentcode")
        If elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    '*****************add by tianxl 2005-10-18 南孚支持问题
    For Each nd In ele.selectNodes("header/contact")
       eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/id")
       eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/phone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/mobile")
        eleHeader.removeChild nd
    Next
   
    For Each nd In ele.selectNodes("header/address")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/conphone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/conmobile")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/deliverunit")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/contactname")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/officephone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/mobilephone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/psnophone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/psnmobilephone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/addcode")
        eleHeader.removeChild nd
    Next
    
    For Each nd In ele.selectNodes("header/customerccode")
        eleHeader.removeChild nd
    Next
    
    For Each nd In ele.selectNodes("header/cacauthcode")
        eleHeader.removeChild nd
    Next
    
    '**************************
    'add by liaonb 2005-4-18 销售出库单增加发货地址
    For Each nd In ele.selectNodes("header/shipaddress")
        If elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    '**************************
    
    For Each nd In ele.selectNodes("header/serial")
        If elVouch.Text <> "10" And elVouch.Text <> "11" Then  'elVouch.Text <> "32"
            eleHeader.removeChild nd
        End If
    Next
  
   '不是材料出库单,清除补料标识 tianxl
    For Each nd In ele.selectNodes("header/iscomplement")
        If elVouch.Text <> "11" Then
            eleHeader.removeChild nd
        End If
    Next
    
    
    Dim entry As IXMLDOMElement
    For Each entry In ele.selectNodes("body/entry")
        For Each nd In entry.selectNodes("transitionid")
            If elVouch.Text <> "08" And elVouch.Text <> "09" Then
                entry.removeChild nd
            End If
        Next
          
        For Each nd In entry.selectNodes("subbillcode")
            If elVouch.Text <> "32" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("subpurchaseid")
            If elVouch.Text <> "01" Then
                entry.removeChild nd
            End If
        Next
        
        
        For Each nd In entry.selectNodes("subconsignmentid")
            If elVouch.Text <> "32" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("subproducingid")
            If elVouch.Text <> "11" And elVouch.Text <> "10" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("subcheckid")
            If elVouch.Text <> "01" Then
                entry.removeChild nd
            End If
        Next
        'add by tianxl 2004-05-10
        '去掉税率
        For Each nd In entry.selectNodes("taxrate")
            If elVouch.Text <> "01" Then
                entry.removeChild nd
            End If
        Next
        '材料出库单库管员
        For Each nd In entry.selectNodes("whpersoncode")
            If elVouch.Text <> "11" Then
                entry.removeChild nd
            End If
        Next
        For Each nd In entry.selectNodes("whpersonname")
            If elVouch.Text <> "11" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("vmivencode")
            If elVouch.Text = "10" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("materialfee")
            If bOmFirst = False Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("processcost")
            If bOmFirst = False Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("processfee")
            'If elVouch.Text <> "01" Then
            If bOmFirst = False Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("dmsdate")
            'If elVouch.Text <> "01" Then
            If bOmFirst = False Then
                entry.removeChild nd
            End If
        Next
        
       '*************************
       For Each nd In entry.selectNodes("id")
          entry.removeChild nd
       Next
    Next
    rsHeader.CursorLocation = adUseClient
    rsBody.CursorLocation = adUseClient

    rsHeader.Open "Select 'A' as editprop ,*,convert(nvarchar(100),'') as cwhname,convert(nvarchar(100),'') as cdepname,convert(nvarchar(100),'') as cpersonname,convert(nvarchar(100),'') as ccusname,convert(nvarchar(100),'') as ccusabbname,convert(nvarchar(100),'') as cvenname,convert(nvarchar(100),'') as cvenabbname,convert(nvarchar(30),'') as crdname,convert(nvarchar(30),'') as cptname,convert(nvarchar(60),'') as cstname,convert(nvarchar(40),'') as cflowname ,1 as bEai From rdrecord Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    'rsBody.Open "Select * From zpurrkdtail Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    rsBody.Open "Select 'A' as editprop,* From " & sQueryB & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    
    Dim oDomH As DOMDocument
    Dim oDomB As DOMDocument
    Set oDomH = New DOMDocument
    Set oDomB = New DOMDocument
    rsHeader.save oDomH, adPersistXML
    rsBody.save oDomB, adPersistXML
'    Set eleHeader = ele.selectSingleNode("header")
'    sSOCode = GetElementValue(eleHeader, "code")
    'Call EXmlToRs.XmlToDomHeader(ele.xml, sRootTag, oDomH, rsHeader, "StoreInOutXmlRs.Xml")
    'Call EXmlToRs.XmlToDomBody(ele.xml, sRootTag, oDomB, rsBody, "StoreInOutXmlRs.Xml")
    Call EXmlToRs.XmlToDomHeader(ele.xml, sRootTag, oDomH, rsHeader, IIf(sRoot = "storein", "StoreInXmlRs.Xml", "StoreOutXmlRs.Xml"))
    Call EXmlToRs.XmlToDomBody(ele.xml, sRootTag, oDomB, rsBody, IIf(sRoot = "storein", "StoreInXmlRs.Xml", "StoreOutXmlRs.Xml"))
    '调用CO接口：INSERT导入单据
    Dim oVoucher As USERPCO.VoucherCO
    Dim oInvObj As USERPCO.InventoryCO
    Set oInvObj = New USERPCO.InventoryCO
    Set oVoucher = New USERPCO.VoucherCO
    Dim eleTmp As IXMLDOMElement
    Set eleTmp = oDomH.selectSingleNode("//z:row")
    eleTmp.setAttribute "bEai", 1
    '清除审核人和审核日期
    eleTmp.setAttribute "cHandler", ""
    eleTmp.setAttribute "dVeriDate", ""
    'If eleTmp.getAttribute("cVouchType") = "11" Or eleTmp.getAttribute("cVouchType") = "10" Or eleTmp.getAttribute("cVouchType") = "08" Or eleTmp.getAttribute("cVouchType") = "09" Then
        'eleTmp.getAttribute("cSource") = "库存"
     '   eleTmp.setAttribute "cSource", "库存"
    'End If
    
    'zcy 2003-01-21
    '单据来源全部为库存,因为采购判断的是起用日期,与来源无关,
    '销售自己只能生成出库单,不能录入修改
    
'Result:Row=426 Col=34  Content="库存"  ID=800546c8-f39b-4d08-a20c-04db5879ea4e
    If bPurInWithOrder = False Then
        'eleTmp.setAttribute "cSource", "库存" 'GetResString("U8.ST.EaiStoreInOut.clsinout.00013")
        If elVouch.Text = "09" And (Not IsNull(eleTmp.getAttribute("cSource"))) Then
           
           If UCase(eleTmp.getAttribute("cSource")) <> "CRM" Then
               eleTmp.setAttribute "cSource", "库存"
           End If
        Else
            eleTmp.setAttribute "cSource", "库存" 'GetResString("U8.ST.EaiStoreInOut.clsinout.00013")
        End If
    Else
        eleTmp.setAttribute "cSource", "采购订单"
    End If
    
    If elVouch.Text = "01" Or elVouch.Text = "10" Or elVouch.Text = "08" Or elVouch.Text = "34" Then
       eleTmp.setAttribute "bRdFlag", 1
    Else
       eleTmp.setAttribute "bRdFlag", 0
    End If
    
    
    '导入单据时，要将单据上的累计出库数量、累计出库件数、结算日期、累计结算数量、累计结算件数、累计结算金额清空。
    '材料出库单的单据来源为库存；产成品入库单的单据来源为库存；其他入库单、其他出库单的单据来源为库存
    
    'csl-----------------------
    
    If Not oVoucher.IniLogin(oLogin, sRet) Then
        GoTo csl
    End If
    
    Dim sCardNumber As String
    Dim sVTID As String
    Dim svouchtype As String
    '-----------------------
    
    'csl modified 2002-11-29
    For Each nd In oDomH.selectNodes("//z:row")
    
        nd.setAttribute "dVeriDate", ""
        nd.setAttribute "cChkCode", ""
        nd.setAttribute "dChkDate", ""
        nd.setAttribute "cChkPerson", ""
        nd.setAttribute "cDLCode", ""
        nd.setAttribute "cARVCode", ""
        nd.setAttribute "cChkCode", ""
        nd.setAttribute "cBusCode", ""
        If bPurInWithOrder = False Then
            nd.setAttribute "cOrderCode", ""
        End If
        nd.setAttribute "cBillCode", ""
        nd.setAttribute "cHandler", ""
       ' nd.setAttribute "dVeriDate", ""
        
'Result:Row=456 Col=14  Content="单据号为"      ID=720537ab-d0bc-40ef-873b-8c56acb9e0a0
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00011", Array(sSOCode))
        
         svouchtype = ""
        sCardNumber = ""
        sVTID = ""
        If Not IsNull(nd.getAttribute("VT_ID")) Then
            sVTID = nd.getAttribute("VT_ID")
        End If
        If Not IsNull(nd.getAttribute("cVouchType")) Then
            svouchtype = nd.getAttribute("cVouchType")
        End If
        
        If svouchtype <> "" Then
            sCardNumber = TypeToSys(svouchtype)
        End If
        
        If IsValidVTID(m_conn, sVTID, sCardNumber) = False Then
        
            If oVoucher.GetVT_ID(nd.getAttribute("cVouchType"), rs, sRet, 0) Then
                If rs.EOF And rs.BOF Then
    'Result:Row=461 Col=29  Content="的取缺省模板时失败！"  ID=0a23b92e-6c08-4c5f-836a-06ac66bb97f5
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00016", Array(sRet))
                    GoTo csl
                Else
                    nd.setAttribute "VT_ID", rs("VT_ID")
                End If
            Else
    'Result:Row=468 Col=25  Content="的取缺省模板时失败！"  ID=88ba8353-7543-4f01-9df7-f2e8b4354b8c
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00016", Array(sRet))
                GoTo csl
            End If
        End If

        Set attr = nd.selectSingleNode("@cMaker")
        If attr Is Nothing Then
'Result:Row=476 Col=25  Content="的制单人cMaker节点不存在！"    ID=f023d01d-9522-4892-addf-ccd936c8d6fe
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00017", Array(sRet))
            GoTo csl
        Else
            If attr.Value = "" Then
'Result:Row=481 Col=29  Content="的制单人cMaker节点不能为空！"  ID=630eeca5-41a6-4db2-ba7b-f1420aa28308
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00018", Array(sRet))
                GoTo csl
            End If
        End If
        
        Set attr = nd.selectSingleNode("@dDate")
        If Not attr Is Nothing Then
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=490 Col=29  Content="的单据日期不是合法的日期！"    ID=231f94af-09e2-4a41-bdec-e5bbfc54d930
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00019", Array(sRet))
                GoTo csl
            End If
        Else
'Result:Row=495 Col=25  Content="的单据日期dDate节点不存在！"   ID=66d28d92-620d-4a90-b4ea-ce5b5f0e6053
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00020", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@dARVDate")
        If Not attr Is Nothing Then
            If attr.Value <> "" Then
                If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=504 Col=33  Content="的到货日期不是合法的日期！"    ID=35a6809c-d265-4a14-987a-3c96648598a3
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00021", Array(sRet))
                    GoTo csl
                End If
            End If
        End If
                Set attr = nd.selectSingleNode("@dChkDate")
        If Not attr Is Nothing Then
            If attr.Value <> "" Then
                If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=514 Col=33  Content="的检验日期不是合法的日期！"    ID=7e7e6d42-c77e-4777-a59e-430e29465bac
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00022", Array(sRet))
                    GoTo csl
                End If
            End If
        End If
                
        Set attr = nd.selectSingleNode("@cVouchType")
        If attr Is Nothing Then
'Result:Row=523 Col=25  Content="vouchtype单据类型节点不存在！" ID=e30f4aa9-28d1-463a-8068-3edaed4d0d62
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00023", Array(sRet))
            GoTo csl
        Else
            If attr.Value <> "01" And attr.Value <> "08" And attr.Value <> "09" And attr.Value <> "10" And attr.Value <> "11" And attr.Value <> "32" Then
'Result:Row=528 Col=29  Content="vouchtype单据类型不合法！"     ID=97b4c917-6b2b-4dac-b56d-72d445ef3aa5
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00024", Array(sRet))
                GoTo csl
            End If
        End If
        
        ' csl 2002-12-3
        '采购入库单?其他入库单用?必须是供应商档案中已有的供应商
        If attr.Value = "01" Or attr.Value = "08" Then 'Or attr.Value = "10"
            Set attr = nd.selectSingleNode("@cCusCode")
            If Not attr Is Nothing Then
                attr.Value = "" '入库没有客户
            End If
        ElseIf attr.Value = "32" Or attr.Value = "09" Then 'Or attr.Value = "11"
        '销售出库单?其他出库单用?必须是客户档案中已有的客户
            Set attr = nd.selectSingleNode("@cVenCode")
            If Not attr Is Nothing Then
                attr.Value = "" '出库没有客户
            End If
        Else
            Set attr = nd.selectSingleNode("@cVenCode")
            If Not attr Is Nothing Then
                attr.Value = ""
            End If
            Set attr = nd.selectSingleNode("@cCusCode")
            If Not attr Is Nothing Then
                attr.Value = ""
            End If
        End If
        '采购入库单用，必须是采购类型档案中已有的类型
        
        Set attr = nd.selectSingleNode("@cVouchType")
        
        If attr.Value <> "01" Then
            Set attr = nd.selectSingleNode("@cPTCode")
            If Not attr Is Nothing Then
                attr.Value = ""
            End If
        End If
        '销售出库单用，必须是销售类型档案中已有的类型
        
        Set attr = nd.selectSingleNode("@cVouchType")

        If attr.Value <> "32" Then
            Set attr = nd.selectSingleNode("@cSTCode")
            If Not attr Is Nothing Then
                attr.Value = ""
            End If
        End If
    '----------------------
' edit by tianxl 2004-05-17  经需求确认不能导入的业务类型检查
'本版新增业务类型：生产倒冲、生产盘点补差、委外倒冲、委外盘点补差、
'委外加工、委外发料、降级入库；以上新增业务类型都判断为非法，不导入。
        Set attr = nd.selectSingleNode("@cBusType")
        Select Case nd.getAttribute("cVouchType")
            Case "01"
             '

                If oVoucher.Login.Account.SysVersion = "工业" Then 'GetResString("U8.ST.EaiStoreInOut.clsinout.00025") Then '-------------------------???????

                    If attr.Value <> "普通采购" And attr.Value <> "代管采购" Then  'GetResString("U8.ST.EaiStoreInOut.clsinout.00026") Then
'                       If (attr.Value = "委外加工" And oVoucher.login.Account.OMStartDate = "") Then
'Result:Row=590 Col=39  Content="业务类型非法！"        ID=5d63de60-56a8-4014-af3b-028f01d4114c
                        If attr.Value <> "委外加工" Then
                            sRet = "此账套为工业账套," & GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                            GoTo csl
                        Else
                            If IIf(IsNull(nd.getAttribute("bomfirst")), "0", nd.getAttribute("bomfirst")) <> "1" Then
                                sRet = "此账套为工业账套," & GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                                GoTo csl
                            End If
                        End If
'                       End If
                    End If
                Else
'Result:Row=596 Col=36  Content="普通采购"      ID=82b7f038-4342-4277-ac43-5f33ae3c47f9 GetResString("U8.ST.EaiStoreInOut.clsinout.00026")
'Result:Row=597 Col=61  Content="受托代销"      ID=c72c35cb-c27b-42c5-a798-27572bb30e43 GetResString("U8.ST.EaiStoreInOut.clsinout.00029")
                    If attr.Value <> "普通采购" And attr.Value <> "受托代销" And attr.Value <> "代管采购" Then
'Result:Row=599 Col=37  Content="业务类型非法！"        ID=57dc8305-3d6f-47ff-9c4c-27a1b3f8c8d4
                        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                        GoTo csl
                    End If
                End If
            Case "08"
              
                If attr.Value <> "调拨入库" And attr.Value <> "盘盈入库" And attr.Value <> "组装入库" And attr.Value <> "拆卸入库" And attr.Value <> "转换入库" And _
                            attr.Value <> "其他入库" Then
'Result:Row=613 Col=33  Content="业务类型非法！"        ID=81df7721-8dc3-4315-9738-5518930a0396
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                    GoTo csl
                End If
            Case "09"

                If attr.Value <> "调拨出库" And attr.Value <> "盘亏出库" And attr.Value <> "组装出库" And attr.Value <> "拆卸出库" _
                            And attr.Value <> "转换出库" And attr.Value <> "其他出库" And attr.Value <> "不合格品" Then
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                    GoTo csl
                End If
            Case "10"

                If attr.Value <> "成品入库" And attr.Value <> "生产订单" Then
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                    GoTo csl
                End If
            '本版新增业务类型：生产倒冲、生产盘点补差、委外倒冲、委外盘点补差、
            '委外加工、委外发料、降级入库；以上新增业务类型都判断为非法，不导入。
    
            Case "11"
'Result:Row=642 Col=32  Content="限额领料"      ID=b57ce733-9b59-45d2-a46f-9da87f80fc1e
'Result:Row=643 Col=57  Content="配比出库"      ID=78d62489-0100-4e1c-9db8-ff2624212150
'Result:Row=644 Col=82  Content="领料"  ID=14fd3c48-0aec-42d1-bbc4-bd3d93b11569
'Result:Row=646 Col=36  Content="生产订单"      ID=8cc75a25-22f0-48e0-96ba-3484e793eae1
                If attr.Value <> "限额领料" And attr.Value <> "配比出库" And attr.Value <> "领料" And attr.Value <> "生产订单" Then
                  ' And attr.Value <> "委外发料" and attr.Value <> "生产倒冲" And attr.Value <> "委外倒冲" And attr.Value <> "委外盘点补差" And attr.Value <> "生产盘点补差" Then
'Result:Row=649 Col=33  Content="业务类型非法！"        ID=7e9e1e6e-3863-4ad7-8861-1a6c617f2d79
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                    GoTo csl
                End If
            Case "32"
                If attr.Value <> "普通销售" And attr.Value <> "委托代销" And attr.Value <> "分期收款" Then
'Result:Row=658 Col=33  Content="业务类型非法！"        ID=c02015f1-045a-41d5-aac1-92758a117296
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00027", Array(sRet))
                    GoTo csl
                End If
        End Select

        
    Next
    '--------------------------------------
    
    If Not oInvObj.IniLogin(oLogin, sRet) Then
'Result:Row=669 Col=14  Content="单据号为"      ID=0d0cb7a3-8abc-440b-88f4-07ba285fbccc
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00117", Array(sSOCode + sRet))
        GoTo csl
    End If
    
    Dim oInvVo As Object

    For Each nd In oDomB.selectNodes("//z:row")
    
        Set attr = nd.selectSingleNode("@cInvCode")
        If attr Is Nothing Then
'Result:Row=680 Col=18  Content="单据号为"      ID=7277217f-fbf9-44af-a456-c1af3965222c
'Result:Row=681 Col=37  Content="没有存货节点!" ID=ac7fd5cd-e3c4-4fd7-80b2-138db4976fc9
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00010", Array(sSOCode))
            GoTo csl
        ElseIf attr.Value = "" Then
'Result:Row=685 Col=18  Content="单据号为"      ID=bc3c04bb-dd16-48d4-9673-e445ebc4bec2
'Result:Row=686 Col=37  Content="存货节点值为空!"       ID=0a724750-0998-482c-979e-4365ac94a93a
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00010", Array(sSOCode))
            GoTo csl
        End If
        
        '采购期初入库单不能录入货位
        If bPuFirst = True Then
          nd.setAttribute "cPosition", ""
        End If
            
        nd.setAttribute "dSDate", ""            '结算日期
        nd.setAttribute "iSQuantity", ""        '累计结算数量
        nd.setAttribute "iSNum", ""             '累计结算件数
        nd.setAttribute "iMoney", ""            '累计结算金额
        nd.setAttribute "iSOutQuantity", ""     '累计出库数量
        nd.setAttribute "iSOutNum", ""          '累计出库件数
        
        'csl-----------------------------------------
        nd.setAttribute "autoid", ""
        nd.setAttribute "iTrIds", ""
        nd.setAttribute "iSBsID", ""
        If bPurInWithOrder = False Then
            nd.setAttribute "iPOsID", ""
        End If
        nd.setAttribute "iDLsID", ""
        nd.setAttribute "iEnsID", ""
        nd.setAttribute "iMPoIds", ""
        nd.setAttribute "iCheckIds", ""
        nd.setAttribute "cVouchCode", ""
        'csl-----------------------------------------
        
        '==================================================================================
        '修改原因 :EAI对单据表体(Rdrecords )新增字段的相应处理:
        '修改范围 :采购入库单/产成品入库单
        '修改日期与修改人 :李亮 2003-06-11
        
        '表体增加 Rdrecords (采购入库单?产成品入库单)
        '检验单号 cCheckCode
        '检验单子表ID iCheckIdBaks (为了不与U850原有字段产生数据冲突，所以重新命名为：iCheckIdBaks)
        '不良品处理单号 cRejectCode
        '不良品处理单ID iRejectIds
        '检验员 cCheckPersonCode
        '检验日期 dCheckDate
'        nd.setAttribute "cCheckCode", ""
'       edit by tianxl 2004-05-08 检验日期、检验单号、检验员、处理单号,EAI都清空
        nd.setAttribute "cCheckCode", ""
        nd.setAttribute "iCheckIdBaks", ""
        nd.setAttribute "cRejectCode", ""
'        nd.setAttribute "cRejectCode", ""
        nd.setAttribute "iRejectIds", ""
        nd.setAttribute "cCheckPersonCode", ""
        nd.setAttribute "dCheckDate", ""
'        nd.setAttribute "cCheckPersonCode", ""
'        nd.setAttribute "dCheckDate", ""
        '==================================================================================
        
        
'Result:Row=735 Col=14  Content="单据号为"      ID=91436a55-89f9-4041-99e8-b8ae6ddeee45
'Result:Row=736 Col=33  Content="的存货编码为"  ID=44a6ba97-974d-423e-8a08-ed39548dfc97
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00064", Array(sSOCode, nd.getAttribute("cInvCode")))

        num = 0
        quantity = 0
                
        Set attr = nd.selectSingleNode("@iNNum")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=745 Col=29  Content="iNNum应收（发）件数节点值不合法！"     ID=2fb43866-0256-428d-a218-0cdae61af32a
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00065", Array(sRet))
                GoTo csl
            Else
                num = Val(attr.Value)
            End If
        End If
        
        
        Set attr = nd.selectSingleNode("@iNQuantity")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=757 Col=29  Content="iNQuantity应收（发）数量节点值不合法！"        ID=46f808be-f173-40cd-af5e-b688c76e104a
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00066", Array(sRet))
                GoTo csl
            Else
                quantity = Val(attr.Value)
            End If
        End If
        
        If Not nd.selectSingleNode("@iNQuantity") Is Nothing And Not nd.selectSingleNode("@iNNum") Is Nothing Then
            If num * quantity < 0 Then
'Result:Row=767 Col=29  Content="的存货的应收（发）件数和应收（发）数量不能一个为正，一个为负！"        ID=3abfcf9b-d6bf-46b1-8436-e1274392e4a4
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00067", Array(sRet))
                GoTo csl
            End If
        End If
        
        num = 0
        quantity = 0
        
        Set attr = nd.selectSingleNode("@iNum")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=779 Col=29  Content="iNum件数节点值不合法！"        ID=871ad66d-c7f0-4ea8-be9f-9307fbca55a8
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00068", Array(sRet))
                GoTo csl
            Else
                num = Val(attr.Value)
            End If
        End If
        
        Set attr = nd.selectSingleNode("@iQuantity")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=790 Col=29  Content="iQuantity数量节点值不合法！"   ID=c2980332-1fb3-4dc9-8f10-61f385a80bdd
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00069", Array(sRet))
                GoTo csl
            Else
                quantity = Val(attr.Value)
            End If
        End If
        Set oInvVo = CreateObject("userpvo.Inventory")
        If oInvObj.Load(nd.getAttribute("cInvCode"), oInvVo, sRet) Then
            If oInvVo.GroupType = 1 Then
                If Not IsCostPriceProper2(num, quantity, oInvVo.ExchRate) Then
'Result:Row=801 Col=26  Content="单据号为"      ID=209929eb-60bd-45c1-9631-141ae8be85c5
'Result:Row=802 Col=45  Content="的存货编码为"  ID=1e6540e4-7e3a-45e7-9b6b-95007198eb77
'Result:Row=803 Col=86  Content=" 的数量和件数不匹配!"  ID=cce07094-47b0-4f35-8207-f4a947a78071
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00072", Array(sSOCode, nd.getAttribute("cInvCode")))
                    GoTo csl
                End If
            End If
            If oInvVo.GroupType = 0 Then
               nd.setAttribute "iinvexchrate", ""
            End If
            
        Else
'Result:Row=809 Col=18  Content="单据号为"      ID=06418c36-c1cb-4514-a6c3-662a2420229b
'Result:Row=810 Col=37  Content="的存货编码为"  ID=54e24a47-503c-4948-b328-f459797af9b7
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00064", Array(sSOCode, nd.getAttribute("cInvCode") + sRet))
            GoTo csl
        End If
                
        If Not nd.selectSingleNode("@iNum") Is Nothing And Not nd.selectSingleNode("@iQuantity") Is Nothing Then
            If num * quantity < 0 Then
'Result:Row=817 Col=29  Content="的存货的件数和数量不能一个为正，一个为负！"    ID=62f1b730-9d8f-4666-85f9-5caa4081da45
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00075", Array(sRet))
                GoTo csl
            End If
        End If
                
        Set attr = nd.selectSingleNode("@iUnitCost")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=826 Col=29  Content="iUnitCost单价节点值不合法！"   ID=1d6f4af7-f10a-42a9-8d5d-f696c8449086
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00076", Array(sRet))
                GoTo csl
            Else
                price = Val(attr.Value)
            End If
        End If
        
        If price < 0 Then
'Result:Row=835 Col=25  Content="的单价不能小于0"       ID=b9b66cb5-252a-4ef6-a881-6af29a206f95
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00077", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@iPrice")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=843 Col=29  Content="iPrice金额节点值不合法！"      ID=6d3e9dd1-8b24-4ebb-ba8f-58530f08e6ed
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00078", Array(sRet))
                GoTo csl
            Else
                cost = Val(attr.Value)
            End If
        End If

        If Not IsCostPriceProper(price, cost, quantity) Then
'Result:Row=852 Col=25  Content="的数量*单价不等于金额" ID=9dce166c-c8c7-4256-bb42-fec369a82264
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00079", Array(sRet))
            GoTo csl
        End If
        
        
        Set attr = nd.selectSingleNode("@iPUnitCost")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=861 Col=29  Content="iUnitCost单价节点值不合法！"   ID=85130b69-7f32-4ea8-9204-1447ddb7d4d0
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00076", Array(sRet))
                GoTo csl
            Else
                price = Val(attr.Value)
            End If
        End If
        
        If price < 0 Then
'Result:Row=870 Col=25  Content="的计划单价不能小于0"   ID=4cd000ef-0ec7-4d96-86f4-80d7ef147c69
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00081", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@iPPrice")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=878 Col=29  Content="iPPrice计划金额节点值不合法！" ID=6e8307f9-74dc-4354-9218-fe9c99cf9a50
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00082", Array(sRet))
                GoTo csl
            Else
                cost = Val(attr.Value)
            End If
        End If
        
        If Not IsCostPriceProper(price, cost, quantity) Then
'Result:Row=887 Col=25  Content="的数量*计划单价不等于计划金额" ID=7bdd2b65-aeb3-4033-bb02-cd9bcbc2eb85
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00079", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@dMadeDate")
        If Not attr Is Nothing Then
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=895 Col=29  Content="的生产日期不是合法的日期！"    ID=1281666a-7b18-45ca-8f6e-212471d250dd
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00084", Array(sRet))
                GoTo csl
            End If
        End If
        
        Set attr = nd.selectSingleNode("@dVDate")
        If Not attr Is Nothing Then
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=904 Col=29  Content="的失效日期不是合法的日期！"    ID=8434a7c7-fc5a-4419-b238-8f242dbd301c
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00085", Array(sRet))
                GoTo csl
            End If
        End If
        
        '-----------------------------------------------------------
    Next
        
    sRet = ""
    m_conn.BeginTrans
    bBegin = True
    
    Dim sVouchID As String
    Dim sUpdateSql As String
    Dim oDomMsg As DOMDocument
    Set oDomMsg = New DOMDocument
    sVouchID = ""
    Call oVoucher.Insert(eleTmp.getAttribute("cVouchType"), oDomH, oDomB, Nothing, sRet, m_conn, sVouchID, oDomMsg, , False)
    
    If sRet = "" Then
        sRet = GetRetString(oDomMsg)
    End If
    
    If sRet = "" And sVouchID <> "" Then
         '修改单据的订单号订单行号 tianxl
         sUpdateSql = " update rdrecords  set csocode = (case when isnull(a.isotype,0)=1 then so_sodetails.csocode when isnull(a.isotype,0)=3  then ex_order.ccode else null end ), " & _
                  " isoseq  = (case when isnull(a.isotype,0)=1 then so_sodetails.irowno when isnull(a.isotype,0)=3   then ex_orderdetail.irowno else null end ) " & _
                  " from rdrecords a   left join so_sodetails with (nolock)  ON a .isodid = so_sodetails.isosid and a .isotype=1 " & _
                  " left join ex_orderdetail with (nolock) on a .isodid = ex_orderdetail.autoid and a .isotype=3 " & _
                  " left join ex_order with (nolock) on ex_orderdetail.id=ex_order.id " & _
                  " where a.id = " & sVouchID
                  
         m_conn.Execute sUpdateSql
         sUpdateSql = " update rdrecord set bredvouch = 1  where exists (select top 1 * from rdrecords where id = rdrecord.id and (isnull(iquantity,0)< 0 or isnull(inum,0) <0  or isnull(inquantity,0)< 0 or isnull(innum,0)< 0)) and cvouchtype ='01' and id = " & sVouchID
         m_conn.Execute sUpdateSql
         sUpdateSql = "update rdrecords  set irowno =(select count(id) from rdrecords where a.id = id and autoid <a.autoid)  + 1 from rdrecords a  where a.id =" & sVouchID
         m_conn.Execute sUpdateSql
    End If
    
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

'csl -----------------------------------

Public Function GetRetString(dom As DOMDocument) As String
    
    On Error GoTo errhandler
    
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
    
    Exit Function
    
errhandler:
   sRet = "检查存量失败!"
   GetRetString = sRet
   
   
End Function

Public Function VerifyDomH(DomH As DOMDocument, oVouch As Object)

End Function

Public Function QueryProc(ByVal eleList As IXMLDOMNodeList, ByRef sRetXml As String, ByVal sRoot As String) As Boolean
    Dim rs As New Recordset
    Dim rsDetail As New Recordset
    Dim dom As New DOMDocument
    Dim sql As String
    Dim el As IXMLDOMElement
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    
    Dim oDom As DOMDocument
    Set oDom = New DOMDocument
    
    Dim sExchRate As String
   
    oDom.loadXML sRetXml
    dom.loadXML sRetXml
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
    
    sExchRate = GetExchRate(m_conn)
    sql = " if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RdRecordView]') and OBJECTPROPERTY(id, N'IsView') = 1)" & _
             " drop view [dbo].[RdRecordView] "
    m_conn.Execute sql
    sql = " create  View RdRecordView AS " & _
           " select   isnull(a.bomfirst,0) as bomfirst,isnull(a.bpufirst,0) as bpufirst,A.ID, bRdFlag,cVouchType,cBusType,cSource,cBusCode,cWhCode,dDate,cCode,cRdCode,cDepCode,cPersonCode,cPTCode,cSTCode,A.cCusCode,cVenCode,cOrderCode," & _
           "  cARVCode,cBillCode,cDLCode,cProBatch,cHandler,A.cMemo,A.iTaxRate,A.cExch_Name,A.iExchRate,A.idiscounttaxtype,bTransFlag,cAccounter,cMaker,iNetLock,dKeepdate,dVeriDate,biafirst,iMQuantity," & _
           "  dARVDate,cChkCode,dChkDate,cChkPerson,VT_ID,bIsSTQc,cPsPCode,cMPoCode,cshipaddress,gspcheck,ipurorderid,ipurarriveid,iproorderid,iarriveid,isalebillid, " & _
           "  convert(char, convert(money,A.ufts), 2) as ufts,cDefine1,cDefine2,cDefine3,cDefine4,cDefine5,cDefine6,cDefine7,cDefine8,cDefine9,cDefine10,cDefine11,cDefine12,cDefine13,cDefine14,cDefine15,cDefine16," & _
           "  B.cCusAddress ,B.ccusperson, B.ccusphone, B.ccushand,Con.cofficephone as contactphone,Con.cMobilePhone as contactmobile, hr_hi_person.cpsnophone,hr_hi_person.cpsnmobilephone, " & _
           "  cusdeliveradd.cdeliverunit,cusdeliveradd.caddcode,Crm_Contact.ccontactname,Crm_Contact.cmobilephone,Crm_Contact.cofficephone,A.biscomplement, " & _
           "  isnull(AA_AuthClass.caccode,'') as caccode ,isnull(CustomerClass.ccccode,'') as ccccode,A.cvenpuomprotocol,A.dcreditstart,A.icreditperiod,A.dgatheringdate,A.bcredit,csourcecodels " & _
           "  from rdrecord  A left join Customer B  on   A.cCusCode=B.cCusCode left join " & _
           "  dbo.hr_hi_person on A.cpersoncode = hr_hi_person.cPsn_Num " & _
           "  left join cusdeliveradd on A.ccuscode=CusDeliverAdd.ccuscode  and A.cshipaddress = CusDeliverAdd.cdeliveradd " & _
           "  left join  Crm_Contact ON CusDeliverAdd.cLinkPerson = Crm_Contact.cContactCode " & _
           "  left join (select ccontactname, max(cOfficePhone) as cOfficePhone,max(cMobilePhone) as cMobilePhone from Crm_Contact group by ccontactname) Con on con.ccontactname = B.ccusperson " & _
           "  left join CustomerClass on CustomerClass.ccccode = B.ccccode " & _
           "  left join AA_AuthClass on AA_AuthClass.id = B.iid  and AA_AuthClass.cbusobid =N'customer' "
           
    '以上修改南孚EAI导入导出问题.
    m_conn.Execute sql
    Dim sFlag As String
    sFlag = IIf(sRoot = "storein", "//storein", "//storeout")
    'sql = "select * from rdrecordView " & GetQueryCondition(eleList, m_conn, oDom.selectSingleNode("//storeinout").Attributes(0).nodeValue)
    sql = "select * from rdrecordView " & GetQueryCondition(eleList, m_conn, IIf(sRoot = "storein", "入库单", "出库单"))
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
        'Call EXmlToRs.RStoXmlHead(el, "StoreInOutXmlRs.Xml", rs)
        Call EXmlToRs.RStoXmlHead(el, IIf(sRoot = "storein", "StoreInXmlRs.Xml", "StoreOutXmlRs.Xml"), rs)
        'sql = "select * from rdrecords where id=" & rs("id")
        sql = " select Rds.*,CU.cComUnitName as cinva_unit,CU2.cComUnitName as cinvm_unit," & _
              " convert(decimal(10," + sExchRate + "), (case when I.igrouptype=1 then CU.iChangRate else " & _
              " (case when I.igrouptype=0 then null else (case when (Rds.inum = 0 or Rds.inum is null ) or (Rds.iquantity = 0 or " & _
              " Rds.iquantity is null ) then null  else Rds.iquantity / Rds.inum end) end) end )) as iinvexchrate,i.cinvname " & _
              " from rdrecords Rds left join Inventory I on Rds.cInvcode=I.cInvCode left join computationunit CU on Rds.cAssUnit=CU.ccomunitcode left join computationunit CU2 on I.cComUnitCode=CU2.ccomunitcode  where id=" & rs("id")
              
             ' "convert(decimal(10," + sExchRate + "),case when isnull(rds.iNum,0)<>0 then round(isnull(rds.iQuantity,0)/rds.iNum,6) else Null end) as iinvexchrate
        rsDetail.Open sql, m_conn, adOpenStatic, adLockReadOnly
        'Call EXmlToRs.RStoXmlBody(el, "StoreInOutXmlRs.Xml", rsDetail)
        Call EXmlToRs.RStoXmlBody(el, IIf(sRoot = "storein", "StoreInXmlRs.Xml", "StoreOutXmlRs.Xml"), rsDetail)
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
        rs.MoveNext
    Wend
    rs.Close
    Set rs = Nothing
    Set rsDetail = Nothing
    sRetXml = dom.xml
End Function
Public Function QueryProcT(ByVal eleList As IXMLDOMNodeList, ByRef sRetXml As String) As Boolean
    Dim rs As New Recordset
    Dim rsDetail As New Recordset
    Dim dom As New DOMDocument
    Dim sql As String
    Dim el As IXMLDOMElement
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    Dim sExchRate As String
    dom.loadXML sRetXml
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
    
    
    sExchRate = GetExchRate(m_conn)
    sql = " select '12' as cVouchType, out.cwhaddress as coutwhaddress ,out.cwhphone as coutwhphone,out.cwhperson as coutwhperson," & _
          " I.cwhaddress as cinwhaddress ,I.cwhphone as cinwhphone,I.cwhperson as cinwhperson , transm.* from transm " & _
          " left join warehouse I on I.cwhcode= transm.ciwhcode " & _
          " left join warehouse out on out.cwhcode= transm.cowhcode " & _
          GetQueryConditionT(eleList, m_conn)
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
        Call EXmlToRs.RStoXmlHead(el, "TransVouchXmlRs.Xml", rs)
        'sql = "select * from transvouchs where id=" & rs("id")
        sql = "select trs.*,CU.cComUnitName as cinva_unit,CU2.cComUnitName as cinvm_unit," & _
              " convert(decimal(10," + sExchRate + "),(case when I.igrouptype=1 then CU.iChangRate else  (case when I.igrouptype=0 then null " & _
              " else (case when (trs.iTVNum = 0 or trs.iTVNum is null ) or (trs.iTVQuantity = 0 or  trs.iTVQuantity is null ) then null " & _
              " else trs.iTVQuantity / trs.iTVNum end) end) end )) as iinvexchrate " & _
              " from transvouchs trs left join Inventory I on trs.cInvcode=I.cInvCode left join computationunit CU on trs.cAssUnit=CU.ccomunitcode left join computationunit CU2 on I.cComUnitCode=CU2.ccomunitcode where id= " & rs("id")
              'convert(decimal(10," + sExchRate + "),case when isnull(trs.iTVNum,0)<>0 then round(isnull(trs.iTVQuantity,0)/trs.iTVNum,6) else Null end) as iinvexchrate
        
        rsDetail.Open sql, m_conn, adOpenStatic, adLockReadOnly
        Call EXmlToRs.RStoXmlBody(el, "TransVouchXmlRs.Xml", rsDetail)
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
        
        rs.MoveNext
    Wend
    rs.Close
    Set rs = Nothing
    Set rsDetail = Nothing
    sRetXml = dom.xml
End Function

Private Function GetQueryCondition(eleList As IXMLDOMNodeList, ByRef conn As Connection, Optional ByVal sInOut As String = "") As String
'Result:Row=1053        Col=44  Content="'获得用户在界面上输入的查询条件，xml文件的格式参见各种查询条件文件"    ID=74b666d1-2f65-4fd6-8b6c-3480ce1c230c
'================================================================================
'模块: clsInOut   Function: GetQueryCondition
'作者:李亮
'日期: 2002-05-16
'--------------------------------------------------------------------------------
'说明: '获得用户在界面上输入的查询条件，xml文件的格式参见各种查询条件文件
'
'--------------------------------------------------------------------------------
'参数:
'   输入
'   输出
'依赖:
'--------------------------------------------------------------------------------
'修改:
'
'================================================================================
On Error GoTo Error_General_Handler:
Const PROC_SIG As String = "clsInOut:GetQueryCondition"
'Call TraceIn(PROC_SIG)
    Dim rs As New Recordset
    Dim ele As IXMLDOMElement
    Dim fld As ADODB.Field
    Dim where As String
    Dim sUftsWhere As String
    
    rs.Open "select * from Rdrecord where 1>1", conn, adOpenForwardOnly, adLockReadOnly
    where = ""
    sUftsWhere = ""
    Dim i As Integer
    Dim j As Integer
    Dim lEleLen As Long
    i = 1
    j = 1
    lEleLen = 0
    
    If m_bCustomQry = True Then
        For Each ele In eleList
           If Not IsNull(ele.getAttribute("value")) Then
              If Trim(ele.getAttribute("value")) <> "" Then
                 If where = "" Then
                    where = Trim(ele.getAttribute("value"))
                 Else
                    where = where & " and " & Trim(ele.getAttribute("value"))
                 End If
              End If
           End If
        Next
    Else
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
                    If i < eleList.length Then  ' - lEleLen Then
                        where = where & " " & GetAttrValue(ele, "logic") & " "
                    End If
                    i = i + 1
                Else
                    where = where & fld.Name & GetAttrValue(ele, "operation") & " convert(Char, convert(Money, " & GetAttrValue(ele, "value") & "), 2)"
                    If i < eleList.length Then
                        where = where & " " & GetAttrValue(ele, "logic") & " "
                    End If
                    i = i + 1
    '                sUftsWhere = sUftsWhere & fld.Name & GetAttrValue(ele, "operation") & " convert(Char, convert(Money, " & GetAttrValue(ele, "value") & "), 2)"
    '                If j < lEleLen Then
    '                    sUftsWhere = sUftsWhere & " " & GetAttrValue(ele, "logic") & " "
    '                End If
    '                j = j + 1
                End If
            End If
        Next
    End If
    
    Set rs = Nothing
'    GetQueryCondition = IIf(Len(where) > 0, "where " + where, where)
    'GetQueryCondition = IIf(Len(where) > 0, " where bIsSTQc=0 and bPuFirst<>1 and bIAFirst<>1 and " + where, "  where bIsSTQc=0 and bPuFirst<>1 and bIAFirst<>1 ")
    'GetQueryCondition = IIf(Len(where) > 0, " where isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bIAFirst,0)<>1 and " + where, "  where isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bIAFirst,0)<>1")
    
'    GetQueryCondition = IIf(Len(where) > 0, " isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bIAFirst,0)<>1 and " + where, "  isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bIAFirst,0)<>1")
'Result:Row=1126        Col=15  Content="出库单"        ID=f8fd7d84-7c06-4a5e-b3a5-1809bcc5aab1
    If sInOut = "出库单" Then  'GetResString("U8.ST.EaiStoreInOut.clsinout.00091") Then
        GetQueryCondition = " where (isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bOMFirst,0)<>1 and isnull(bIAFirst,0)<>1 and brdflag=0)" & IIf(where <> "", " and (" & where & ")", "")
'Result:Row=1129        Col=19  Content="入库单"        ID=537783a3-716f-4755-88e5-c2d644ae9d31
    ElseIf sInOut = "入库单" Then 'GetResString("U8.ST.EaiStoreInOut.clsinout.00092") Then
        GetQueryCondition = " where (isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bOMFirst,0)<>1 and isnull(bIAFirst,0)<>1 and brdflag=1)" & IIf(where <> "", " and (" & where & ")", "")
    End If
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

Private Function GetQueryConditionT(eleList As IXMLDOMNodeList, ByRef conn As Connection) As String
'================================================================================
'模块: clsInOut   Function: GetQueryConditionT
'作者:李亮
'日期: 2002-05-16
'--------------------------------------------------------------------------------
'说明: '获得用户在界面上输入的查询条件，xml文件的格式参见各种查询条件文件
'
'--------------------------------------------------------------------------------
'参数:
'   输入
'   输出
'依赖:
'--------------------------------------------------------------------------------
'修改:
'
'================================================================================
On Error GoTo Error_General_Handler:
Const PROC_SIG As String = "clsInOut:GetQueryConditionT"
'Call TraceIn(PROC_SIG)
    Dim rs As New Recordset
    Dim ele As IXMLDOMElement
    Dim fld As ADODB.Field
    Dim where As String
    rs.Open "select * from transvouch where 1>1", conn, adOpenForwardOnly, adLockReadOnly
    where = ""
    Dim i As Integer
    i = 1
    Dim sUftsWhere As String
    sUftsWhere = ""
    Dim j As Integer
    Dim lEleLen As Long
    j = 1
    lEleLen = 0
    
    If m_bCustomQry = True Then
       For Each ele In eleList
          If Not IsNull(ele.getAttribute("value")) Then
             If Trim(ele.getAttribute("value")) <> "" Then
                If where = "" Then
                   where = Trim(ele.getAttribute("value"))
                Else
                   where = where & " and " & Trim(ele.getAttribute("value"))
                End If
             End If
          End If
       Next
    Else
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
    '                sUftsWhere = sUftsWhere & fld.Name & GetAttrValue(ele, "operation") & " convert(Char, convert(Money, " & GetAttrValue(ele, "value") & "), 2)"
    '                If j < lEleLen Then
    '                    sUftsWhere = sUftsWhere & " " & GetAttrValue(ele, "logic") & " "
    '                End If
    '                j = j + 1
                End If
            End If
        Next
    End If
    
    Set rs = Nothing
    'GetQueryConditionT = IIf(Len(where) > 0, "where " + where, where)
    'GetQueryConditionT = IIf(Len(where) > 0, " where bIsSTQc=0 and bPuFirst<>1 and bIAFirst<>1 and " + where, "  where bIsSTQc=0 and bPuFirst<>1 and bIAFirst<>1 ")
'    GetQueryConditionT = IIf(Len(where) > 0, " where isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bIAFirst,0)<>1 and " + where, "  where isnull(bIsSTQc,0)<>1 and isnull(bPuFirst,0)<>1 and isnull(bIAFirst,0)<>1")

    GetQueryConditionT = " where " & IIf(where <> "", " (" & where & ")", "1=1")
    '单据的EAI后台服务在拼条件时需要针对时间戳条件特殊处理——和其他条件用括号分离开，形式为：（时间戳条件） and（界面设置的其他条件）。
    If sUftsWhere <> "" Then
        GetQueryConditionT = GetQueryConditionT & " and (" & sUftsWhere & ")"
    End If
    
    Exit Function
'Call TraceOut(PROC_SIG)
ExitFunction:
  Exit Function
Error_General_Handler:
  GetQueryConditionT = ""
  GoTo ExitFunction
End Function

'库存展望
Private Function KCZWTable(ByVal oLogin As clsLogin, ByVal oDom As DOMDocument, ByRef errMsg As String) As String
    Dim i As Long
    Dim sErrStr As String
    'Dim lDays As Integer
    Dim ddate As String
    Dim cInvCode As String
    Dim cInvCCode As String
    Dim cWhCode As String
    Dim sSql As String
    Dim oRs As Recordset
    Dim oCon As Connection
    Dim oTmpDom As DOMDocument
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    Dim oKczw As New UfSTKcView.clsKcView
    Dim oEle As IXMLDOMNode
    Dim oAttris As IXMLDOMElement
    Dim el As IXMLDOMElement
    Dim oNodes As IXMLDOMNodeList
    Dim oNode As IXMLDOMElement
    Set oEle = oDom.selectSingleNode("//storequantity")
    If Not oEle Is Nothing Then
'        '展望天数
'        Set oAttris = oEle.selectSingleNode("*[@display='展望天数']")
'        If oAttris Is Nothing Then
'            lDays = 0
'        Else
'            lDays = Val(oAttris.getAttribute("value"))
'        End If
        '展望到日期
'Result:Row=1262        Col=43  Content="*[@display='展望到日期']"      ID=ddfdde7a-bae8-440a-b97b-b0222c4356cd
                'U861多语:XML文件中的中文串不需要多语化处理
        Set oAttris = oEle.selectSingleNode("*[@display='展望到日期']")
        If oAttris Is Nothing Then
            ddate = oLogin.CurDate
        Else
            ddate = Val(oAttris.getAttribute("value"))
        End If

        '存货编码
'Result:Row=1271        Col=37  Content="*[@display='存货编码']"        ID=11de9862-4d5e-46e5-836f-c0ba07c2fd46
        Set oNodes = oEle.selectNodes("*[@display='存货编码']")
        If oNodes.length > 0 Then
            For Each oNode In oNodes
                'cInvCode = cInvCode & " T.cInvCode " & oNode.getAttribute("operation") & " '" & oNode.getAttribute("value") & "' and "
                cInvCCode = cInvCCode & "Inventory.cInvCCode " & oNode.getAttribute("operation") & " N'" & oNode.getAttribute("value") & "' " & oNode.getAttribute("logic") & " "
            Next
            'cInvCode = Left(cInvCode, Len(cInvCode) - 5)
        Else
            cInvCode = ""
        End If
        '存货分类
'Result:Row=1283        Col=37  Content="*[@display='存货分类']"        ID=7682bf86-1744-4d4c-97b5-4e372cc0244c
        Set oNodes = oEle.selectNodes("*[@display='存货分类']")
        If oNodes.length > 0 Then
            For Each oNode In oNodes
                'cInvCCode = cInvCCode & " Inventory.cInvCCode " & oNode.getAttribute("operation") & " '" & oNode.getAttribute("value") & "' and "
                cInvCCode = cInvCCode & "Inventory.cInvCCode " & oNode.getAttribute("operation") & " N'" & oNode.getAttribute("value") & "' " & oNode.getAttribute("logic") & " "
            Next
            'cInvCCode = Left(cInvCCode, Len(cInvCCode) - 5)
        Else
            cInvCCode = ""
        End If
        '仓库编码
'Result:Row=1295        Col=37  Content="*[@display='仓库编码']"        ID=fd6132b0-c455-4834-bc10-bc723273186b
        Set oNodes = oEle.selectNodes("*[@display='仓库编码']")
        If oNodes.length > 0 Then
            For Each oNode In oNodes
                'cWhCode = cWhCode & " cWhCode " & oNode.getAttribute("operation") & " '" & oNode.getAttribute("value") & "' and "
                cWhCode = cWhCode & "cWhCode " & oNode.getAttribute("operation") & " N'" & oNode.getAttribute("value") & "' " & oNode.getAttribute("logic") & " "
            Next
            'cWhCode = Left(cWhCode, Len(cWhCode) - 5)
            sSql = "Select cWhCode from warehouse where " & cWhCode
            Set oRs = New Recordset
            Set oCon = New Connection
            oRs.CursorLocation = adUseClient
            oCon.Open oLogin.UfDbName
            oRs.Open sSql, oLogin.UfDbName, adOpenDynamic, adLockBatchOptimistic
            cWhCode = ""
            Do While Not oRs.EOF
                cWhCode = cWhCode & "N'" & oRs("cwhcode") & "',"
                oRs.MoveNext
            Loop
            cWhCode = IIf(cWhCode <> "", Left(cWhCode, Len(cWhCode) - 1), cWhCode)
        Else
            cWhCode = ""
        End If
          
          
        '临时保存DOM用
        Dim tempDom As New DOMDocument
        tempDom.loadXML oDom.xml
        tempDom.documentElement.Text = ""
        '首先判断是否需要分页
        Dim paginate As Long
        Dim counter As Long '计数器
        Dim lIndex As Long  '导出第几页
        Dim sumCount As Long '记录的总数
        
        paginate = CLng(GetAttrValue(oDom.documentElement, "paginate"))
    
        If oKczw.InitClass(oLogin, "", sErrStr) Then
            Set oRs = New Recordset
            If oKczw.KCViewQueryLoad(cWhCode, cInvCode, cInvCCode, "", ddate, oRs, True, sErrStr) Then
                oDom.documentElement.Text = ""
                
                
                If oRs.State = 1 Then
                
                    If oRs.RecordCount > 0 Then
                        If paginate > 0 Then
                            '取得页的总数
                            Dim sumSql As String
                            Dim lPageCount As Long
                           
                            If Not oRs.EOF Then
                               sumCount = oRs.RecordCount
                            End If
                            If sumCount Mod paginate = 0 Then
                                lPageCount = sumCount / paginate
                            Else
                                 lPageCount = Int(sumCount / paginate) + 1
                            End If
                            '定义计数器
                            counter = 1
                            lIndex = 1
                            oRs.MoveFirst
                        End If
                    End If
                    
                    Do While Not oRs.EOF
                        Set el = oDom.createElement(oDom.documentElement.getAttribute("roottag"))
'Result:Row=1326        Col=45  Content="工业"  ID=b35d52eb-19b9-4fe0-9300-1977b194db98
                        If oKczw.SysVersion = "工业" Then  'GetResString("U8.ST.EaiStoreInOut.clsinout.00025") Then
                           Call EXmlToRs.RStoXmlCommon(el, "StoreQuantityXmlRs2.Xml", oRs)
                        Else
                           Call EXmlToRs.RStoXmlCommon(el, "StoreQuantityXmlRs3.Xml", oRs)
                        End If
                        oDom.documentElement.appendChild el
                        
                        '****************************
                        '处理多页导出
                        If paginate > 0 Then
                            If counter = paginate Then
                                gObjRef.ProcessExport oDom.xml, lIndex, lPageCount
                                '清空Dom
                                Set oDom = Nothing
                                Set oDom = New DOMDocument
                                oDom.loadXML tempDom.xml
                                
                                lIndex = lIndex + 1
                                counter = 0
                            Else
                                If (lIndex = lPageCount) And (counter = sumCount Mod paginate) Then
                                    gObjRef.ProcessExport oDom.xml, lIndex, lPageCount
                                End If
                            End If
                            counter = counter + 1
                        End If
                        '*****************************
                        oRs.MoveNext
                    Loop
                End If
                KCZWTable = oDom.xml
            End If
        End If
        If sErrStr <> "" Then
            errMsg = sErrStr
        End If
    End If
End Function

Public Function IsCostPriceProper(price As Double, cost As Double, quantity As Double) As Boolean
    '****************修改zcy quantity*price<>cost******************
    IsCostPriceProper = True
    Exit Function
    
    
    If CCur(cost) = CCur(price * quantity) Then
        IsCostPriceProper = True
        Exit Function
    End If
    
    Dim tmp As Double
    
    If quantity <> 0 Then
        tmp = cost / quantity
        If Round(tmp, GetDecDigit(price)) = price Then
            IsCostPriceProper = True
            Exit Function
        End If
    End If
End Function

Public Function IsCostPriceProper2(price As Double, cost As Double, quantity As Double) As Boolean
    '******************zcy Modify price*Quantity<>cost**************
    IsCostPriceProper2 = True
    Exit Function
    
    If cost = price * quantity Then
        IsCostPriceProper2 = True
        Exit Function
    End If
    
    Dim tmp As Double
    
    If quantity <> 0 Then
        tmp = cost / quantity
        If Round(tmp, GetDecDigit(price)) = price Then
            IsCostPriceProper2 = True
            Exit Function
        End If
    End If
End Function

Public Function GetDecDigit(price As Double) As Long
    Dim tmp As String
    Dim nLen As Integer
    
    tmp = CStr(price)
    
    If InStrRev(tmp, ".") = 0 Then
        nLen = 0
    Else
        nLen = Len(tmp) - InStrRev(tmp, ".")
    End If
    
    GetDecDigit = nLen
End Function

Private Function AddQc(ByVal ele As IXMLDOMElement) As Boolean
'================================================================================
'模块: clsInOut   Function: AddQc

'--------------------------------------------------------------------------------
'说明: 库存期初导入
'
'--------------------------------------------------------------------------------
'参数:
'   输入 期初库存数据列表
'   输出
'依赖:
'--------------------------------------------------------------------------------
'修改:
'
'================================================================================
'On Error GoTo Error_General_Handler:
'Const PROC_SIG As String = "clsInOut:AddSingle"
'Call TraceIn(PROC_SIG)
    
    Dim rsBody As New ADODB.Recordset
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
    Dim rs As New Recordset
    Dim attr As IXMLDOMAttribute
    Dim bBegin As Boolean
    bBegin = False
    'sSOCode = GetElementValue(eleHeader, "code")
    Set eleBody = ele.selectSingleNode("body")
    If eleBody Is Nothing Then
'Result:Row=1442        Col=14  Content="没有body节点"  ID=de30976f-cca3-4c6e-9bf9-43234d4aa5e4
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00008")
        GoTo csl
    End If
    
    Dim elVouch As IXMLDOMElement
    Dim sQueryH As String
    Dim sQueryB As String
   
    Dim entry As IXMLDOMElement
   
    
    rsBody.CursorLocation = adUseClient

    
    rsBody.Open "Select *,0 as id_1 ,'A' as editprop  From kcinit   Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    
    
    Dim oDomB As DOMDocument
    Dim oDomsingle As DOMDocument
    Set oDomB = New DOMDocument
    
    rsBody.save oDomB, adPersistXML

    Call EXmlToRs.XmlToDomBody(ele.xml, sRootTag, oDomB, rsBody, "StoreQcXmlRs.Xml")
    '调用CO接口：INSERT导入单据
    Dim oVoucher As USERPCO.VoucherCO
    
    Dim oInvObj As USERPCO.InventoryCO
    Set oInvObj = New USERPCO.InventoryCO
    Set oVoucher = New USERPCO.VoucherCO
    Dim eleTmp As IXMLDOMElement
    
    If oDomB.selectNodes("//z:row") Is Nothing Then
'Result:Row=1476        Col=13  Content="没有要导入的数据!"     ID=4ab7dd20-b83a-4eaa-b706-eb2ed7857a8c
       sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00099")
       GoTo csl
    End If
    If oDomB.selectNodes("//z:row").length <= 0 Then
'Result:Row=1481        Col=13  Content="没有要导入的数据!"     ID=cc4f2137-b557-4866-b88c-ec88fc300e13
       sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00099")
       GoTo csl
    End If
    Dim oInvVo As Object
    
    Dim i As Long
    Set oVoucher = New USERPCO.VoucherCO
    If Not oVoucher.IniLogin(oLogin, sRet) Then
        GoTo csl
    End If
    
    If Not oInvObj.IniLogin(oLogin, sRet) Then
        
        GoTo csl
    End If
    Dim sDate As String
    
    Set oDomB = RecordSetToDom(DomToRecordSet(oDomB))
    For i = 1 To oDomB.selectNodes("//z:row").length
        Set oDomsingle = GetLineDom(oDomB, i)
        Set nd = oDomsingle.selectSingleNode("//z:row")
        
        Set attr = nd.selectSingleNode("@cinvcode")
        If attr Is Nothing Then
'Result:Row=1505        Col=18  Content="没有存货节点!" ID=df416a1e-7252-4fc3-bf93-555da96b96a4
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00060")
            GoTo csl
        ElseIf attr.Value = "" Then
'Result:Row=1509        Col=18  Content="存货节点值为空!"       ID=e89eb1c9-017f-499b-9587-0d9a9c5d7aed
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00062")
            GoTo csl
        End If
    
        nd.setAttribute "cmaker", oLogin.cUserName
'Result:Row=1515        Col=34  Content="库存"  ID=1cf7553e-0f17-414c-8092-7e53aa3b9cd0
        nd.setAttribute "csource", "库存" ' GetResString("U8.ST.EaiStoreInOut.clsinout.00013")
        nd.setAttribute "brdflag", "1"
        
        '取库存期初日期
        If IsNull(nd.getAttribute("ddate")) Then
            sDate = Format(DateAdd("D", -1, oVoucher.Login.Account.Period(Month((oVoucher.Login.Account.STStartDate))).BeginDate), "YYYY-MM-DD")
        Else
            sDate = nd.getAttribute("ddate")
            sDate = Mid(Format(sDate, "YYYY-MM-DD"), 1, 10)
            If IsDate(sDate) Then
                
                If DateDiff("D", Format(DateAdd("D", -1, oVoucher.Login.Account.Period(Month((oVoucher.Login.Account.STStartDate))).BeginDate), "YYYY-MM-DD"), sDate) > 0 Then
                   sDate = Format(DateAdd("D", -1, oVoucher.Login.Account.Period(Month((oVoucher.Login.Account.STStartDate))).BeginDate), "YYYY-MM-DD")
                End If
            Else
                sDate = Format(DateAdd("D", -1, oVoucher.Login.Account.Period(Month((oVoucher.Login.Account.STStartDate))).BeginDate), "YYYY-MM-DD")
            End If
            
        End If
        
        'nd.setAttribute "ddate", Format(DateAdd(MassChEn(""), -1, oVoucher.Login.Account.Period(Month((oVoucher.Login.Account.STStartDate))).BeginDate), "YYYY-MM-DD")        '默认当前日期
        nd.setAttribute "ddate", sDate
        nd.setAttribute "cbusType", ""
        nd.setAttribute "csource", ""
        nd.setAttribute "bpufirst", "0"
        nd.setAttribute "bomfirst", "0"
        nd.setAttribute "biafirst", "0"
        'csl-----------------------------------------
        nd.setAttribute "cvouchtype", "34"
        nd.setAttribute "bisstqc", "1"
        nd.setAttribute "editprop", "A"
        num = 0
        quantity = 0
        
        
        
        Set attr = nd.selectSingleNode("@inum")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=1535        Col=29  Content="inum件数节点值不合法！"        ID=85da8f0b-5042-4a5a-aa37-8030ad8930d0
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00104", Array(sRet))
                GoTo csl
            Else
                num = Val(attr.Value)
            End If
        End If
        Set attr = nd.selectSingleNode("@cwhcode")
        If attr Is Nothing Then
'Result:Row=1544        Col=24  Content="仓库不能为空！"        ID=0e5f90b1-531c-4ab3-9d66-aeafc38c7d69
           sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00105", Array(sRet))
           GoTo csl
        End If
        Set attr = nd.selectSingleNode("@iquantity")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=1551        Col=29  Content="iquantity数量节点值不合法！"   ID=ca5d20de-fb20-473f-86a3-2ef7c9f9f7ba
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00106", Array(sRet))
                GoTo csl
            Else
                quantity = Val(attr.Value)
            End If
        End If
        Set oInvVo = CreateObject("userpvo.Inventory")
        
        If oInvObj.Load(nd.getAttribute("cinvcode"), oInvVo, sRet) Then
            If oInvVo.GroupType = 1 Then
                If Not IsCostPriceProper2(num, quantity, oInvVo.ExchRate) Then
'Result:Row=1563        Col=26  Content="存货编码为"    ID=cf0ba4ea-9622-4c97-97a4-3bb52fcf6f01
'Result:Row=1564        Col=66  Content=" 的数量和件数不匹配!"  ID=3b594dc2-1c43-46b1-87a9-1080050168f9
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00107", Array(nd.getAttribute("cinvcode")))
                    GoTo csl
                End If
            End If
            If oInvVo.GroupType = 0 Then
                nd.setAttribute "iinvexchrate", ""
            End If
            'nd.setAttribute "iexpiratdatecalcu", oInvVo.ExpiratDateCalcu
        Else
'Result:Row=1570        Col=18  Content="存货编码为"    ID=ce58bf8f-f48a-4fec-b8ea-cd22d3a592a1
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00108", Array(nd.getAttribute("cinvcode") + sRet))
            GoTo csl
        End If
                
        If Not nd.selectSingleNode("@inum") Is Nothing And Not nd.selectSingleNode("@iquantity") Is Nothing Then
            If num * quantity < 0 Then
'Result:Row=1577        Col=29  Content="的存货的件数和数量不能一个为正，一个为负！"    ID=25f9b4ea-74d0-43a2-9188-0c8aa862d424
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00075", Array(sRet))
                GoTo csl
            End If
        End If
                
        Set attr = nd.selectSingleNode("@iunitcost")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=1586        Col=29  Content="iunitCost单价节点值不合法！"   ID=b6d22ced-720c-4d71-926e-2eb399e3f610
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00111", Array(sRet))
                GoTo csl
            Else
                price = Val(attr.Value)
            End If
        End If
        
        If price < 0 Then
'Result:Row=1595        Col=25  Content="的单价不能小于0"       ID=e223cfaa-eb26-4789-a040-b2a9814736ef
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00077", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@iprice")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=1603        Col=29  Content="iprice金额节点值不合法！"      ID=4ed9847a-a5c5-4146-b19b-cad7d26ca991
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00113", Array(sRet))
                GoTo csl
            Else
                cost = Val(attr.Value)
            End If
        End If

        If Not IsCostPriceProper(price, cost, quantity) Then
'Result:Row=1612        Col=25  Content="的数量*单价不等于金额" ID=ecd15838-e52f-4593-9be3-0a9e4f13cecc
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00079", Array(sRet))
            GoTo csl
        End If
        
        
        Set attr = nd.selectSingleNode("@ipunitcost")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=1621        Col=29  Content="ipunitcost单价节点值不合法！"  ID=b6b41e47-d80a-4dbb-a9d8-2aa21b54c74e
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00115", Array(sRet))
                GoTo csl
            Else
                price = Val(attr.Value)
            End If
        End If
        
        If price < 0 Then
'Result:Row=1630        Col=25  Content="的计划单价不能小于0"   ID=7f94247a-b234-4215-b929-0200a14d3d7f
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00081", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@ipprice")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=1638        Col=29  Content="iPPrice计划金额节点值不合法！" ID=b30d0a8e-18c1-4ed1-9d35-85c7ab9c3821
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00082", Array(sRet))
                GoTo csl
            Else
                cost = Val(attr.Value)
            End If
        End If
        
       
        Set attr = nd.selectSingleNode("@dmadedate")
        If Not attr Is Nothing Then
            attr.Value = Mid(attr.Value, 1, 10)
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=1651        Col=29  Content="的生产日期不是合法的日期！"    ID=ea6b5496-d1be-4fec-9de7-7d647c6e4fe7
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00084", Array(sRet))
                GoTo csl
            End If
        End If
        
        Set attr = nd.selectSingleNode("@dvdate")
        If Not attr Is Nothing Then
            attr.Value = Mid(attr.Value, 1, 10)
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=1661        Col=29  Content="的失效日期不是合法的日期！"    ID=8724eafa-05de-4d17-a1c3-10499ea712a5
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00085", Array(sRet))
                GoTo csl
            End If
        End If
       '************************
       sRet = ""
       m_conn.BeginTrans
       bBegin = True
       Dim oDomMsg As DOMDocument
       Set oDomMsg = New DOMDocument
    
       Call oVoucher.Insert("34", oDomsingle, oDomsingle, Nothing, sRet, m_conn, , oDomMsg, , False)
    
       If sRet = "" Then
          sRet = GetRetString(oDomMsg)
       End If
csl:
       If sRet = "" Then
         If bBegin Then
            m_conn.CommitTrans
         End If
         Call ErrDomAppendChild(m_errDom, "", 0, "ok")
        
       Else
        If bBegin Then
            m_conn.RollbackTrans
        End If
        Call ErrDomAppendChild(m_errDom, sSOCode, 101, sRet)
        
       End If
    Next
        

    AddQc = True
'Call TraceOut(PROC_SIG)
ExitFunction:
  Exit Function
Error_General_Handler:
  AddQc = False
  GoTo ExitFunction
End Function

'**********************
Private Function AddQcScrapVouch(ByVal ele As IXMLDOMElement) As Boolean
'Result:Row=179 Col=36  Content="'' 处理单张订单"       ID=f066b7ff-6b8b-4143-9142-3fa2d055cd7b
'================================================================================
'模块: clsInOut   Function: AddSingle
'作者:
'日期: 2002-05-16
'--------------------------------------------------------------------------------
'说明: 处理单张单据
'
'--------------------------------------------------------------------------------
'参数:
'   输入 ele:一张单据的内容
'   输出
'依赖:
'--------------------------------------------------------------------------------
'修改:
'
'================================================================================
'On Error GoTo Error_General_Handler:
'Const PROC_SIG As String = "clsInOut:AddSingle"
'Call TraceIn(PROC_SIG)
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
    Dim rs As New Recordset
    Dim attr As IXMLDOMAttribute
    Dim bBegin As Boolean
    bBegin = False
    'csl-------------------------

    Set eleHeader = ele.selectSingleNode("header")
    If eleHeader Is Nothing Then
'Result:Row=222 Col=14  Content="没有header节点"        ID=281a3cad-1097-4579-8833-97f050e77a75
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00007")
        GoTo csl
    End If
    
    sSOCode = GetElementValue(eleHeader, "code")
    Set eleBody = ele.selectSingleNode("body")
    If eleBody Is Nothing Then
'Result:Row=230 Col=14  Content="没有body节点"  ID=37648d46-7b24-4561-9480-5a8e300c40cf
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00008")
        GoTo csl
    End If
    
   
    Dim sQueryH As String
    Dim sQueryB As String
    sQueryH = "qcbhghead"
    sQueryB = "qcbhgbody"
    
    Set nd = Nothing

    Dim entry As IXMLDOMElement
    
    rsHeader.CursorLocation = adUseClient
    rsBody.CursorLocation = adUseClient

    rsHeader.Open "Select * ,1 as bEai from " & sQueryH & " where 1=2 ", m_conn, adOpenStatic, adLockOptimistic
   
    rsBody.Open "Select * From " & sQueryB & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    
    Dim oDomH As DOMDocument
    Dim oDomB As DOMDocument
    Set oDomH = New DOMDocument
    Set oDomB = New DOMDocument
    rsHeader.save oDomH, adPersistXML
    rsBody.save oDomB, adPersistXML
'    Set eleHeader = ele.selectSingleNode("header")
'    sSOCode = GetElementValue(eleHeader, "code")
    Call EXmlToRs.XmlToDomHeader(ele.xml, sRootTag, oDomH, rsHeader, "QcScrapVouchXmlRs.Xml")
    Call EXmlToRs.XmlToDomBody(ele.xml, sRootTag, oDomB, rsBody, "QcScrapVouchXmlRs.Xml")
    '调用CO接口：INSERT导入单据
    Dim oVoucher As USERPCO.VoucherCO
    Dim oInvObj As USERPCO.InventoryCO
    Set oInvObj = New USERPCO.InventoryCO
    Set oVoucher = New USERPCO.VoucherCO
    Dim eleTmp As IXMLDOMElement
    Set eleTmp = oDomH.selectSingleNode("//z:row")
'    eleTmp.setAttribute "bEai", 1
'
'    eleTmp.setAttribute "cvouchtype", "55"
'    eleTmp.setAttribute "csource", "库存"
'
   
    'eleTmp.setAttribute "cSource", GetResString("U8.ST.EaiStoreInOut.clsinout.00013")
    
    If Not oVoucher.IniLogin(oLogin, sRet) Then
        GoTo csl
    End If
    eleTmp.setAttribute "bEai", 1
    eleTmp.setAttribute "cvouchtype", "55"
    eleTmp.setAttribute "csource", "库存"
    eleTmp.setAttribute "ddate", Format(DateAdd(MassChEn(""), -1, oVoucher.Login.Account.Period(Month((oVoucher.Login.Account.STStartDate))).BeginDate), "YYYY-MM-DD")        '默认当前日期


    '-----------------------
    
    'csl modified 2002-11-29
    For Each nd In oDomH.selectNodes("//z:row")
    
        
        
        Set attr = nd.selectSingleNode("@vt_id")
'Result:Row=456 Col=14  Content="单据号为"      ID=720537ab-d0bc-40ef-873b-8c56acb9e0a0
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00011", Array(sSOCode))
        If attr.Value = "" Then '模板为空时取默认模板
          If oVoucher.GetVT_ID(nd.getAttribute("cvouchtype"), rs, sRet, 0) Then
              If rs.EOF And rs.BOF Then
                'Result:Row=461 Col=29  Content="的取缺省模板时失败！"  ID=0a23b92e-6c08-4c5f-836a-06ac66bb97f5
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00016", Array(sRet))
                GoTo csl
              Else
                nd.setAttribute "vt_id", rs("VT_ID")
              End If
          Else
'Result:Row=468 Col=25  Content="的取缺省模板时失败！"  ID=88ba8353-7543-4f01-9df7-f2e8b4354b8c
              sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00016", Array(sRet))
             GoTo csl
          End If
        End If
        

        Set attr = nd.selectSingleNode("@cmaker")
        If attr Is Nothing Then
'Result:Row=476 Col=25  Content="的制单人cMaker节点不存在！"    ID=f023d01d-9522-4892-addf-ccd936c8d6fe
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00017", Array(sRet))
            GoTo csl
        Else
            If attr.Value = "" Then
'Result:Row=481 Col=29  Content="的制单人cMaker节点不能为空！"  ID=630eeca5-41a6-4db2-ba7b-f1420aa28308
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00018", Array(sRet))
                GoTo csl
            End If
        End If
        
        Set attr = nd.selectSingleNode("@ddate")
        If Not attr Is Nothing Then
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=490 Col=29  Content="的单据日期不是合法的日期！"    ID=231f94af-09e2-4a41-bdec-e5bbfc54d930
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00019", Array(sRet))
                GoTo csl
            End If
        Else
'Result:Row=495 Col=25  Content="的单据日期dDate节点不存在！"   ID=66d28d92-620d-4a90-b4ea-ce5b5f0e6053
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00020", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@dchkdate")
        If Not attr Is Nothing Then
            If attr.Value <> "" Then
                If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=514 Col=33  Content="的检验日期不是合法的日期！"    ID=7e7e6d42-c77e-4777-a59e-430e29465bac
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00022", Array(sRet))
                    GoTo csl
                End If
            End If
        End If
    Next
    '--------------------------------------
    
    If Not oInvObj.IniLogin(oLogin, sRet) Then
'Result:Row=669 Col=14  Content="单据号为"      ID=0d0cb7a3-8abc-440b-88f4-07ba285fbccc
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00117", Array(sSOCode + sRet))
        GoTo csl
    End If
    
    Dim oInvVo As Object

    For Each nd In oDomB.selectNodes("//z:row")
    
        Set attr = nd.selectSingleNode("@cinvcode")
        If attr Is Nothing Then
'Result:Row=680 Col=18  Content="单据号为"      ID=7277217f-fbf9-44af-a456-c1af3965222c
'Result:Row=681 Col=37  Content="没有存货节点!" ID=ac7fd5cd-e3c4-4fd7-80b2-138db4976fc9
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00010", Array(sSOCode))
            GoTo csl
        ElseIf attr.Value = "" Then
'Result:Row=685 Col=18  Content="单据号为"      ID=bc3c04bb-dd16-48d4-9673-e445ebc4bec2
'Result:Row=686 Col=37  Content="存货节点值为空!"       ID=0a724750-0998-482c-979e-4365ac94a93a
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00010", Array(sSOCode))
            GoTo csl
        End If
    
        
        
'Result:Row=735 Col=14  Content="单据号为"      ID=91436a55-89f9-4041-99e8-b8ae6ddeee45
'Result:Row=736 Col=33  Content="的存货编码为"  ID=44a6ba97-974d-423e-8a08-ed39548dfc97
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00064", Array(sSOCode, nd.getAttribute("cInvCode")))

        num = 0
        quantity = 0
        
        Set attr = nd.selectSingleNode("@inum")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=779 Col=29  Content="iNum件数节点值不合法！"        ID=871ad66d-c7f0-4ea8-be9f-9307fbca55a8
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00068", Array(sRet))
                GoTo csl
            Else
                num = Val(attr.Value)
            End If
        End If
        
        Set attr = nd.selectSingleNode("@iquantity")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=790 Col=29  Content="iQuantity数量节点值不合法！"   ID=c2980332-1fb3-4dc9-8f10-61f385a80bdd
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00069", Array(sRet))
                GoTo csl
            Else
                quantity = Val(attr.Value)
            End If
        End If
        Set oInvVo = CreateObject("userpvo.Inventory")
        If oInvObj.Load(nd.getAttribute("cinvcode"), oInvVo, sRet) Then
            If oInvVo.GroupType = 1 Then
                If Not IsCostPriceProper2(num, quantity, oInvVo.ExchRate) Then
'Result:Row=801 Col=26  Content="单据号为"      ID=209929eb-60bd-45c1-9631-141ae8be85c5
'Result:Row=802 Col=45  Content="的存货编码为"  ID=1e6540e4-7e3a-45e7-9b6b-95007198eb77
'Result:Row=803 Col=86  Content=" 的数量和件数不匹配!"  ID=cce07094-47b0-4f35-8207-f4a947a78071
                    sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00072", Array(sSOCode, nd.getAttribute("cinvcode")))
                    GoTo csl
                End If
            End If
        Else
'Result:Row=809 Col=18  Content="单据号为"      ID=06418c36-c1cb-4514-a6c3-662a2420229b
'Result:Row=810 Col=37  Content="的存货编码为"  ID=54e24a47-503c-4948-b328-f459797af9b7
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00064", Array(sSOCode, nd.getAttribute("cinvcode") + sRet))
            GoTo csl
        End If
        If oInvVo.GroupType <> 0 Then
            If nd.selectSingleNode("@cAssUnit") Is Nothing Then
                sRet = "辅计量单位不能为空！"
                GoTo csl
            End If
        End If
        
        If Not nd.selectSingleNode("@inum") Is Nothing And Not nd.selectSingleNode("@iquantity") Is Nothing Then
            If num * quantity < 0 Then
'Result:Row=817 Col=29  Content="的存货的件数和数量不能一个为正，一个为负！"    ID=62f1b730-9d8f-4666-85f9-5caa4081da45
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00075", Array(sRet))
                GoTo csl
            End If
        End If
                
        Set attr = nd.selectSingleNode("@iunitcost")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=826 Col=29  Content="iUnitCost单价节点值不合法！"   ID=1d6f4af7-f10a-42a9-8d5d-f696c8449086
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00076", Array(sRet))
                GoTo csl
            Else
                price = Val(attr.Value)
            End If
        End If
        
        If price < 0 Then
'Result:Row=835 Col=25  Content="的单价不能小于0"       ID=b9b66cb5-252a-4ef6-a881-6af29a206f95
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00077", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@iprice")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=843 Col=29  Content="iPrice金额节点值不合法！"      ID=6d3e9dd1-8b24-4ebb-ba8f-58530f08e6ed
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00078", Array(sRet))
                GoTo csl
            Else
                cost = Val(attr.Value)
            End If
        End If

        If Not IsCostPriceProper(price, cost, quantity) Then
'Result:Row=852 Col=25  Content="的数量*单价不等于金额" ID=9dce166c-c8c7-4256-bb42-fec369a82264
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00079", Array(sRet))
            GoTo csl
        End If
        
        
        Set attr = nd.selectSingleNode("@ipunitcost")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=861 Col=29  Content="iUnitCost单价节点值不合法！"   ID=85130b69-7f32-4ea8-9204-1447ddb7d4d0
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00076", Array(sRet))
                GoTo csl
            Else
                price = Val(attr.Value)
            End If
        End If
        
        If price < 0 Then
'Result:Row=870 Col=25  Content="的计划单价不能小于0"   ID=4cd000ef-0ec7-4d96-86f4-80d7ef147c69
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00081", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@ipprice")
        If Not attr Is Nothing Then
            If Not (IsNumeric(attr.Value) Or attr.Value = "") Then
'Result:Row=878 Col=29  Content="iPPrice计划金额节点值不合法！" ID=6e8307f9-74dc-4354-9218-fe9c99cf9a50
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00082", Array(sRet))
                GoTo csl
            Else
                cost = Val(attr.Value)
            End If
        End If
        
        If Not IsCostPriceProper(price, cost, quantity) Then
'Result:Row=887 Col=25  Content="的数量*计划单价不等于计划金额" ID=7bdd2b65-aeb3-4033-bb02-cd9bcbc2eb85
            sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00079", Array(sRet))
            GoTo csl
        End If
        
        Set attr = nd.selectSingleNode("@dmadedate")
        If Not attr Is Nothing Then
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=895 Col=29  Content="的生产日期不是合法的日期！"    ID=1281666a-7b18-45ca-8f6e-212471d250dd
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00084", Array(sRet))
                GoTo csl
            End If
        End If
        
        Set attr = nd.selectSingleNode("@dvdate")
        If Not attr Is Nothing Then
            If Not (IsDate(attr.Value) Or attr.Value = "") Then
'Result:Row=904 Col=29  Content="的失效日期不是合法的日期！"    ID=8434a7c7-fc5a-4419-b238-8f242dbd301c
                sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00085", Array(sRet))
                GoTo csl
            End If
        End If
        
        '-----------------------------------------------------------
    Next
        
    sRet = ""
    m_conn.BeginTrans
    bBegin = True
    Dim oDomMsg As DOMDocument
    Set oDomMsg = New DOMDocument
    
    Call oVoucher.Insert(eleTmp.getAttribute("cvouchtype"), oDomH, oDomB, Nothing, sRet, m_conn, , oDomMsg, , False)
    
    If sRet = "" Then
        sRet = GetRetString(oDomMsg)
    End If
    
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
    AddQcScrapVouch = True
'Call TraceOut(PROC_SIG)
ExitFunction:
  Exit Function
Error_General_Handler:
  AddQcScrapVouch = False
  GoTo ExitFunction
End Function
'sRootTag: 标识何种单据
'与零售接口
Private Sub AddLsProc(ByVal sRootTag As String, ByVal EleLst As IXMLDOMNodeList, ByRef sRetXml As String)
  On Error GoTo Err_log
    Dim TmpEle As IXMLDOMElement
    'TmpEle为一张定单的内容
    For Each TmpEle In EleLst
        Call AddLsSingle(sRootTag, TmpEle)
    Next
    sRetXml = m_errDom.xml
    Exit Sub
Err_log:
    Call ErrDomAppendChild(m_errDom, "", 999, Err.Description)
    sRetXml = m_errDom.xml
End Sub
'零售单张单据保存
Private Function AddLsSingle(ByVal sRootTag As String, ByVal ele As IXMLDOMElement) As Boolean
'Result:Row=179 Col=36  Content="'' 处理单张订单"
'================================================================================

'说明: 处理单张单据
'
'--------------------------------------------------------------------------------
'参数:
'   输入 ele:一张单据的内容
'   输出
'依赖:
'--------------------------------------------------------------------------------
'修改:
'
'================================================================================
'On Error GoTo Error_General_Handler:
'Const PROC_SIG As String = "clsInOut:AddSingle"
'Call TraceIn(PROC_SIG)
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
    Dim rs As New Recordset
    Dim attr As IXMLDOMAttribute
    
    Dim bBegin As Boolean
    bBegin = False
    Dim svouchcode As String
    
    Dim bVerifyErr As Boolean
    
    bVerifyErr = False
    
   
    'csl-------------------------

    Set eleHeader = ele.selectSingleNode("header")
    If eleHeader Is Nothing Then
'Result:Row=222 Col=14  Content="没有header节点"        ID=281a3cad-1097-4579-8833-97f050e77a75
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00007")
        GoTo csl
    End If
    
'    sSOCode = GetElementValue(eleHeader, "code")
    Set eleBody = ele.selectSingleNode("body")
    If eleBody Is Nothing Then
'Result:Row=230 Col=14  Content="没有body节点"  ID=37648d46-7b24-4561-9480-5a8e300c40cf
        sRet = GetResString("U8.ST.EaiStoreInOut.clsinout.00008")
        GoTo csl
    End If
    '********************
    Set nd = Nothing
    For Each nd In ele.selectNodes("header/id")
        eleHeader.removeChild nd
    Next
    Dim entry As IXMLDOMElement
    For Each entry In ele.selectNodes("body/entry")
        
        For Each nd In entry.selectNodes("subconsignmentid")
            entry.removeChild nd
        Next
       '*************************
       For Each nd In entry.selectNodes("id")
          entry.removeChild nd
        Next
    Next
    
    '********************
    Dim sQueryH As String
    Dim sQueryB As String
    Dim sXmlFile As String
    Dim svouchtype As String
    
   
    Select Case LCase(sRootTag)
           Case "apptransvouch"
                sQueryH = "TransRequestM"
                sQueryB = "TransRequestD"
                svouchtype = "62"
                sXmlFile = "TransAppVouchXmlRs.Xml"
                sSOCode = "ctvcode"
           Case "transvouch"
                sQueryH = "TransM"
                sQueryB = "TransD"
                svouchtype = "12"
                sXmlFile = "TransVouchXmlRs.Xml"
                sSOCode = "ctvcode"
           Case "checkvouch"
                sQueryH = "CheckM"
                sQueryB = "CheckD"
                svouchtype = "18"
                sXmlFile = "CheckVouchXmlRs.Xml"
                sSOCode = "ccvcode"
           Case "stotheroutvouch"
                sQueryH = "KCOtherOutH"
                sQueryB = "KCOtherOutB"
                svouchtype = "09"
                sXmlFile = "stotheroutxmlrs.Xml"
                sSOCode = "ccode"
           Case "materialoutvouch"
                sQueryH = "RecordOutQ"
                sQueryB = "RecordOutSQ"
                svouchtype = "11"
                sXmlFile = "LsInOutXmlRs.Xml"
                sSOCode = "ccode"
          Case "productinvouch"
                sQueryH = "RecordInQ"
                sQueryB = "RecordInSQ"
                svouchtype = "10"
                sXmlFile = "LsInOutXmlRs.Xml"
                sSOCode = "ccode"
          Case "adjustposition"
                sQueryH = "AdjustPM"
                sQueryB = "AdjustPD"
                svouchtype = "19"
                sXmlFile = "adjustpvouchxmlrs.Xml"
                sSOCode = "cvouchcode"
     End Select
    If svouchtype = "12" Then '南孚问题,新增仓库相关信息
       For Each nd In ele.selectNodes("header/outwhaddress")
            eleHeader.removeChild nd
       Next
       For Each nd In ele.selectNodes("header/inwhaddress")
            eleHeader.removeChild nd
       Next
       For Each nd In ele.selectNodes("header/outwhphone")
            eleHeader.removeChild nd
       Next
       For Each nd In ele.selectNodes("header/inwhphone")
            eleHeader.removeChild nd
       Next
       For Each nd In ele.selectNodes("header/outwhperson")
           eleHeader.removeChild nd
       Next
       For Each nd In ele.selectNodes("header/inwhperson")
            eleHeader.removeChild nd
       Next
       
    End If
    
'    If svouchtype = "11" Or svouchtype = "10" Then
'       '  ClearLsNode ele, sRootTag
'    End If
    
    rsHeader.CursorLocation = adUseClient
    rsBody.CursorLocation = adUseClient
    
    If LCase(sRootTag) = "apptransvouch" Then
        rsHeader.Open "select 'A' as editprop, * ,1 as beai,convert(nvarchar(60),null) as yhrq  from " & sQueryH & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    ElseIf LCase(sRootTag) = "materialoutvouch" Or LCase(sRootTag) = "productinvouch" Then
        rsHeader.Open "Select 'A' as editprop ,*,convert(nvarchar(100),'') as cwhname,convert(nvarchar(100),'') as cdepname,convert(nvarchar(100),'') as cpersonname,convert(nvarchar(30),'') as crdname,convert(nvarchar(30),'') as cptname,convert(nvarchar(60),'') as cstname,convert(nvarchar(40),'') as cflowname ,1 as bEai From rdrecord Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    Else
       rsHeader.Open "select 'A' as editprop, * ,1 as beai from " & sQueryH & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    End If
   
    'rsBody.Open "Select * From " & sQueryB & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    If LCase(sRootTag) = "apptransvouch" Then
        rsBody.Open "Select 'A' as editprop,*,convert(nvarchar(60),null) as yhkc,convert(nvarchar(60),null) as yhje,convert(nvarchar(60),null) as xsqty,convert(nvarchar(60),null) as xsje  From " & sQueryB & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    Else
        rsBody.Open "Select 'A' as editprop,* From " & sQueryB & " Where 1=2", m_conn, adOpenStatic, adLockOptimistic
    End If
    
    Dim oDomH As DOMDocument
    Dim oDomB As DOMDocument
    Set oDomH = New DOMDocument
    Set oDomB = New DOMDocument
    rsHeader.save oDomH, adPersistXML
    rsBody.save oDomB, adPersistXML
    Call EXmlToRs.XmlToDomHeader(ele.xml, sRootTag, oDomH, rsHeader, sXmlFile)
    Call EXmlToRs.XmlToDomBody(ele.xml, sRootTag, oDomB, rsBody, sXmlFile)
    
'    oDomH.Load "c:\lshead.xml"
'    oDomB.Load "c:\lsbody.xml"
    
    '调用CO接口：INSERT导入单据
    Dim oVoucher As USERPCO.VoucherCO
    Dim oInvObj As USERPCO.InventoryCO
    Set oInvObj = New USERPCO.InventoryCO
    Set oVoucher = New USERPCO.VoucherCO
    Dim eleTmp As IXMLDOMElement
    
    If Not oVoucher.IniLogin(oLogin, sRet) Then
        GoTo csl
    End If
    
    Dim bBatchAllowZeroOut As Boolean
    Dim bAllowZeroOut As Boolean
    
    bBatchAllowZeroOut = oVoucher.Login.Account.BatchAllowZeroOut
    bAllowZeroOut = oVoucher.Login.Account.AllowZeroOut
    
    
    'u891零售接口
    oVoucher.Login.Account.CheckInvPos = False
    '零售允许超货位出库
    oVoucher.Login.Account.PosZeroOut = True
     '零售生成单据审核时不检查货位
    oVoucher.Login.Account.VerifyCheckPos = False
    
    
   '调用自定义接口
    Dim oServeInterface As Dictionary
    Dim oInterface As Object
    Dim sErrStr As String
    Dim oOptionCol As Dictionary
    Dim i As Integer
    Set oServeInterface = GetInterfaceCol(m_conn, oLogin)
    If oServeInterface.Count > 0 Then
       For i = 0 To oServeInterface.Count - 1
           Set oInterface = oServeInterface.Items(i)
           If IsFunctionExits(m_conn, oServeInterface.Keys(i), "SetUserDefineAdd") Then
              sErrStr = ""
              If Not oInterface.SetUserDefineAdd(svouchtype, oDomH, oDomB, sRet) Then
                 GoTo csl
              End If
           End If
           If IsFunctionExits(m_conn, oServeInterface.Keys(i), "GetCheckOption") Then
              sErrStr = ""
              If oInterface.GetCheckOption(svouchtype, oOptionCol) Then
                 If oOptionCol.Exists("AllowZeroOut") Then
                    oVoucher.Login.Account.AllowZeroOut = CBool(oOptionCol.Item("AllowZeroOut"))
                 End If
                 If oOptionCol.Exists("BatchAllowZeroOut") Then
                    oVoucher.Login.Account.BatchAllowZeroOut = CBool(oOptionCol.Item("BatchAllowZeroOut"))
                 End If
                 If oOptionCol.Exists("InOutCheck") Then
                    oVoucher.Login.Account.InOutCheck = CBool(oOptionCol.Item("InOutCheck"))
                 End If
              End If
           End If
       Next
    End If
    
    oVoucher.Login.Account.BatchAllowZeroOut = True
    oVoucher.Login.Account.AllowZeroOut = True
    
    sRet = ""
    m_conn.BeginTrans
    bBegin = True
    Dim oDomMsg As DOMDocument
    Set oDomMsg = New DOMDocument
    Dim sVouchID As String
    Call oVoucher.Insert(svouchtype, oDomH, oDomB, Nothing, sRet, m_conn, sVouchID, oDomMsg, False, False)
    
    Dim strSql As String
    
    If sRet = "" Then
        If LCase(sRootTag) = "transvouch" Then
            strSql = " update transvouchs set cBatchProperty1 = AB.cBatchProperty1,cBatchProperty2 = AB.cBatchProperty2,cBatchProperty3 = AB.cBatchProperty3,"
            strSql = strSql & " cBatchProperty4 = AB.cBatchProperty4,cBatchProperty5 = AB.cBatchProperty5,cBatchProperty6 = AB.cBatchProperty6,"
            strSql = strSql & " cBatchProperty7 = AB.cBatchProperty7,cBatchProperty8 = AB.cBatchProperty8,cBatchProperty9 = AB.cBatchProperty9,cBatchProperty10 = AB.cBatchProperty10"
            strSql = strSql & " from transvouchs c  left join AA_BatchProperty AB with (nolock) on isnull(AB.cinvcode,N'')=isnull(C.cinvcode,N'') and isnull(AB.cbatch,N'')=isnull(C.ctvbatch,N'') "
            strSql = strSql & " and isnull(AB.cfree1,N'')=isnull(C.cfree1,N'') and isnull(AB.cfree2,N'')=isnull(C.cfree2,N'') "
            strSql = strSql & " and isnull(AB.cfree3,N'')=isnull(C.cfree3,N'') and isnull(AB.cfree4,N'')=isnull(C.cfree4,N'') "
            strSql = strSql & " and isnull(AB.cfree5,N'')=isnull(C.cfree5,N'') and isnull(AB.cfree6,N'')=isnull(C.cfree6,N'') "
            strSql = strSql & " and isnull(AB.cfree7,N'')=isnull(C.cfree7,N'') and isnull(AB.cfree8,N'')=isnull(C.cfree8,N'') "
            strSql = strSql & " and isnull(AB.cfree9,N'')=isnull(C.cfree9,N'') and isnull(AB.cfree10,N'')=isnull(C.cfree10,N'') "
            strSql = strSql & " where isnull(c.ctvbatch,'') <> '' and c.id=" & sVouchID
            m_conn.Execute strSql
            strSql = " update transvouchs  set irowno =(select count(id) from transvouchs where a.id = id and autoid <a.autoid)  + 1 from transvouchs a  where a.id =" & sVouchID
            m_conn.Execute strSql
        ElseIf LCase(sRootTag) = "checkvouch" Then
            strSql = " update checkvouchs set cBatchProperty1 = AB.cBatchProperty1,cBatchProperty2 = AB.cBatchProperty2,cBatchProperty3 = AB.cBatchProperty3,"
            strSql = strSql & " cBatchProperty4 = AB.cBatchProperty4,cBatchProperty5 = AB.cBatchProperty5,cBatchProperty6 = AB.cBatchProperty6,"
            strSql = strSql & " cBatchProperty7 = AB.cBatchProperty7,cBatchProperty8 = AB.cBatchProperty8,cBatchProperty9 = AB.cBatchProperty9,cBatchProperty10 = AB.cBatchProperty10"
            strSql = strSql & " from checkvouchs c  left join AA_BatchProperty AB with (nolock) on isnull(AB.cinvcode,N'')=isnull(C.cinvcode,N'') and isnull(AB.cbatch,N'')=isnull(C.ccvbatch,N'') "
            strSql = strSql & " and isnull(AB.cfree1,N'')=isnull(C.cfree1,N'') and isnull(AB.cfree2,N'')=isnull(C.cfree2,N'') "
            strSql = strSql & " and isnull(AB.cfree3,N'')=isnull(C.cfree3,N'') and isnull(AB.cfree4,N'')=isnull(C.cfree4,N'') "
            strSql = strSql & " and isnull(AB.cfree5,N'')=isnull(C.cfree5,N'') and isnull(AB.cfree6,N'')=isnull(C.cfree6,N'') "
            strSql = strSql & " and isnull(AB.cfree7,N'')=isnull(C.cfree7,N'') and isnull(AB.cfree8,N'')=isnull(C.cfree8,N'') "
            strSql = strSql & " and isnull(AB.cfree9,N'')=isnull(C.cfree9,N'') and isnull(AB.cfree10,N'')=isnull(C.cfree10,N'') "
            strSql = strSql & " where isnull(c.ccvbatch,'') <> '' and c.id=" & sVouchID
            m_conn.Execute strSql
            strSql = " update checkvouchs  set irowno =(select count(id) from checkvouchs where a.id = id and autoid <a.autoid)  + 1 from checkvouchs a  where a.id =" & sVouchID
            m_conn.Execute strSql
            
        ElseIf LCase(sRootTag) = "stotheroutvouch" Or LCase(sRootTag) = "materialoutvouch" Or LCase(sRootTag) = "productinvouch" Then
            strSql = " update rdrecords set cBatchProperty1 = AB.cBatchProperty1,cBatchProperty2 = AB.cBatchProperty2,cBatchProperty3 = AB.cBatchProperty3,"
            strSql = strSql & " cBatchProperty4 = AB.cBatchProperty4,cBatchProperty5 = AB.cBatchProperty5,cBatchProperty6 = AB.cBatchProperty6,"
            strSql = strSql & " cBatchProperty7 = AB.cBatchProperty7,cBatchProperty8 = AB.cBatchProperty8,cBatchProperty9 = AB.cBatchProperty9,cBatchProperty10 = AB.cBatchProperty10"
            strSql = strSql & " from rdrecords c  left join AA_BatchProperty AB with (nolock) on isnull(AB.cinvcode,N'')=isnull(C.cinvcode,N'') and isnull(AB.cbatch,N'')=isnull(C.cbatch,N'') "
            strSql = strSql & " and isnull(AB.cfree1,N'')=isnull(C.cfree1,N'') and isnull(AB.cfree2,N'')=isnull(C.cfree2,N'') "
            strSql = strSql & " and isnull(AB.cfree3,N'')=isnull(C.cfree3,N'') and isnull(AB.cfree4,N'')=isnull(C.cfree4,N'') "
            strSql = strSql & " and isnull(AB.cfree5,N'')=isnull(C.cfree5,N'') and isnull(AB.cfree6,N'')=isnull(C.cfree6,N'') "
            strSql = strSql & " and isnull(AB.cfree7,N'')=isnull(C.cfree7,N'') and isnull(AB.cfree8,N'')=isnull(C.cfree8,N'') "
            strSql = strSql & " and isnull(AB.cfree9,N'')=isnull(C.cfree9,N'') and isnull(AB.cfree10,N'')=isnull(C.cfree10,N'') "
            strSql = strSql & " where isnull(c.cbatch,'') <> '' and c.id=" & sVouchID
            m_conn.Execute strSql
            
            strSql = " update rdrecords  set irowno =(select count(id) from rdrecords where a.id = id and autoid <a.autoid)  + 1 from rdrecords a  where a.id =" & sVouchID
            m_conn.Execute strSql
       ElseIf LCase(sRootTag) = "adjustposition" Then
            strSql = " update adjustpvouchs set cBatchProperty1 = AB.cBatchProperty1,cBatchProperty2 = AB.cBatchProperty2,cBatchProperty3 = AB.cBatchProperty3,"
            strSql = strSql & " cBatchProperty4 = AB.cBatchProperty4,cBatchProperty5 = AB.cBatchProperty5,cBatchProperty6 = AB.cBatchProperty6,"
            strSql = strSql & " cBatchProperty7 = AB.cBatchProperty7,cBatchProperty8 = AB.cBatchProperty8,cBatchProperty9 = AB.cBatchProperty9,cBatchProperty10 = AB.cBatchProperty10"
            strSql = strSql & " from adjustpvouchs c  left join AA_BatchProperty AB with (nolock) on isnull(AB.cinvcode,N'')=isnull(C.cinvcode,N'') and isnull(AB.cbatch,N'')=isnull(C.cbatch,N'') "
            strSql = strSql & " and isnull(AB.cfree1,N'')=isnull(C.cfree1,N'') and isnull(AB.cfree2,N'')=isnull(C.cfree2,N'') "
            strSql = strSql & " and isnull(AB.cfree3,N'')=isnull(C.cfree3,N'') and isnull(AB.cfree4,N'')=isnull(C.cfree4,N'') "
            strSql = strSql & " and isnull(AB.cfree5,N'')=isnull(C.cfree5,N'') and isnull(AB.cfree6,N'')=isnull(C.cfree6,N'') "
            strSql = strSql & " and isnull(AB.cfree7,N'')=isnull(C.cfree7,N'') and isnull(AB.cfree8,N'')=isnull(C.cfree8,N'') "
            strSql = strSql & " and isnull(AB.cfree9,N'')=isnull(C.cfree9,N'') and isnull(AB.cfree10,N'')=isnull(C.cfree10,N'') "
            strSql = strSql & " where isnull(c.cbatch,'') <> '' and c.id=" & sVouchID
            m_conn.Execute strSql
            strSql = " update adjustpvouchs  set irowno =(select count(id) from adjustpvouchs where a.id = id and autoid <a.autoid)  + 1 from adjustpvouchs a  where a.id =" & sVouchID
            m_conn.Execute strSql
        
        End If
        
        sRet = GetRetString(oDomMsg)
        
        If sRet <> "" Then
            m_conn.RollbackTrans
            GoTo csl
        End If
'        m_conn.CommitTrans
        If LCase(sRootTag) = "stotheroutvouch" Or LCase(sRootTag) = "materialoutvouch" Or LCase(sRootTag) = "productinvouch" Then
            Call oVoucher.Verify(svouchtype, sVouchID, sRet, m_conn, , , False, False)
            If sRet <> "" Then
                m_conn.RollbackTrans
                GoTo csl
            Else
                m_conn.CommitTrans
            End If
        Else
            'sRet = GetRetString(oDomMsg)
            
            m_conn.CommitTrans
            
        End If
    Else
        m_conn.RollbackTrans
        
        GoTo csl
    End If
    '自动审核生成的单据
    Dim oGenVouchIds As New Dictionary
    Dim iVouchLength As Long
    If svouchtype = "12" And IsLsMakeVouch(oDomH) Then '调拨
        
       Call oVoucher.Verify("12", sVouchID, sRet, , , , False, False, , , , oGenVouchIds)
       If sRet <> "" Then
         sRet = "上传生成的调拨单(id=" & sVouchID & ")已保存成功," & "自动审核时失败:" & sRet & "  请手工审核!"
         bVerifyErr = True
         GoTo csl
       End If
       '自动审核生成的其他出入库单,根据需求去掉带调拨单的其它出入库单的自动审核
       If oGenVouchIds.Count > 0 Then
          For iVouchLength = 0 To oGenVouchIds.Count - 1
             If CStr(oGenVouchIds.Items(iVouchLength)) = "09" Then
                Call oVoucher.Verify(CStr(oGenVouchIds.Items(iVouchLength)), oGenVouchIds.Keys(iVouchLength), sRet, , , , False, False)
                If sRet <> "" Then
                   GoTo csl
                End If
             End If
          Next
       End If
    End If
    
    If svouchtype = "18" Then '盘点
       Call oVoucher.Verify("18", sVouchID, sRet, , , , False, False, , , , oGenVouchIds)
       If sRet <> "" Then
         sRet = "零售系统数据上传生成的盘点单(id=" & sVouchID & ")已保存成功," & "自动审核失败:" & sRet & "  请手工审核!"
         bVerifyErr = True
         GoTo csl
       End If
       '自动审核生成的其他出入库单
       If oGenVouchIds.Count > 0 Then
          For iVouchLength = 0 To oGenVouchIds.Count - 1
             Call oVoucher.Verify(CStr(oGenVouchIds.Items(iVouchLength)), oGenVouchIds.Keys(iVouchLength), sRet, , , , False, False)
             If sRet <> "" Then
                sRet = "零售系统数据上传生成的盘点单生成的出入库单自动审核失败:" & sRet & "  请手工审核!"
                bVerifyErr = True
                GoTo csl
             End If
          Next
       End If
    End If
    
csl:
    If sRet = "" Then
        If bBegin Then
           ' m_conn.CommitTrans
        End If
        Call ErrDomAppendChild(m_errDom, "", 0, "数据上传成功!")
        Exit Function
    Else
       If bVerifyErr = True Then
           Call ErrDomAppendChild(m_errDom, "", 0, sRet)
           Exit Function
       Else
          If bBegin Then
             ' m_conn.RollbackTrans
          End If
          Call ErrDomAppendChild(m_errDom, "", 101, sRet)
          Exit Function
       End If
    End If
    AddLsSingle = True
'Call TraceOut(PROC_SIG)
ExitFunction:
  Exit Function
Error_General_Handler:
  AddLsSingle = False
  GoTo ExitFunction
End Function
'下发现存量表
Public Function QueryProcCurrentStock(ByVal eleList As IXMLDOMNodeList, ByRef sRetXml As String) As Boolean
    Dim rs As New Recordset
    Dim rsDetail As New Recordset
    Dim dom As New DOMDocument
    Dim sql As String
    Dim el As IXMLDOMElement
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    Dim sFilter As String
    QueryProcCurrentStock = True
    dom.loadXML sRetXml
    
    
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
    
    
    sFilter = ""
    '**********取条件
    For Each el In eleList
       If LCase(GetAttrValue(el, "name")) <> "isotype" And LCase(GetAttrValue(el, "name")) <> "isodid" Then
         sFilter = sFilter & " (" & GetAttrValue(el, "name") & GetAttrValue(el, "operation") & "N'" & GetAttrValue(el, "value") & "'" & ") " & GetAttrValue(el, "logic")
       End If
    Next
    '**********
    dom.documentElement.Text = ""
    DropTable m_conn, "#curstock"
    DropTable m_conn, "#posstock"
    
    sql = " select cwhcode,cinvcode,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbatch," & _
           " iquantity,dvdate,dmdate into #curstock  from currentstock with (nolock) where 1=0 "
           
    m_conn.Execute sql
    
    sql = " select cwhcode,cinvcode,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbatch," & _
           " iquantity,cposcode,dvdate,dmadedate as dmdate into #posstock  from invposition with (nolock) where 1=0 "
    m_conn.Execute sql
    
    sql = " insert into #curstock (cwhcode,cinvcode,cbatch,iquantity,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,dvdate,dmdate )" & _
           " select cur.cwhcode,cur.cinvcode,isnull(cur.cbatch,''),sum(isnull(cur.iquantity,0)),isnull(cur.cfree1,''),isnull(cur.cfree2,''),isnull(cur.cfree3,'')," & _
           " isnull(cur.cfree4,''),isnull(cur.cfree5,''),isnull(cur.cfree6,''),isnull(cur.cfree7,''),isnull(cur.cfree8,''),isnull(cur.cfree9,''),isnull(cur.cfree10,'')," & _
           " max(cur.dvdate),max(cur.dmdate ) " & _
           " from currentstock cur  with (nolock) inner join inventory on cur.cinvcode=inventory.cinvcode and inventory.igrouptype<=1 "
    sql = sql & " where (isnull(isotype,0)=0 and isnull(isodid,'')='') "
    If sFilter <> "" Then
       sql = sql & " and " & sFilter
    End If
    
    sql = sql + " group by  cur.cwhcode,cur.cinvcode,isnull(cur.cbatch,''),isnull(cur.cfree1,''),isnull(cur.cfree2,''),isnull(cur.cfree3,'')," & _
           " isnull(cur.cfree4,''),isnull(cur.cfree5,''),isnull(cur.cfree6,''),isnull(cur.cfree7,''),isnull(cur.cfree8,''),isnull(cur.cfree9,''),isnull(cur.cfree10,'') "
    m_conn.Execute sql
    
    
    
     
     Dim bOtherInCheck As Boolean
     Dim bPurRkdCheck As Boolean
     Dim bSaleOutCheck As Boolean
     Dim bMaterialOutCheck As Boolean
     Dim bProductInCheck As Boolean
     
     bOtherInCheck = getSTOption(m_conn, "bOtherInCheck")
     bPurRkdCheck = getSTOption(m_conn, "bPurchaseInCheck")
     bSaleOutCheck = getSTOption(m_conn, "bSaleOutCheck")
     bMaterialOutCheck = getSTOption(m_conn, "bMaterialOutCheck")
     bProductInCheck = getSTOption(m_conn, "bProductInCheck")
     
     
     sql = " insert into #posstock (cwhcode,cinvcode,cbatch,iquantity,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cposcode,dvdate,dmdate)"
     
     sql = sql & " select pos.cwhcode,pos.cinvcode,pos.cbatch,pos.iquantity,pos.cfree1,pos.cfree2,pos.cfree3,pos.cfree4,pos.cfree5,pos.cfree6,pos.cfree7,pos.cfree8,pos.cfree9,pos.cfree10,pos.cposcode,pos.dvdate,pos.dmdate "
     sql = sql & " From"
     sql = sql & " (select cposcode,cwhcode ,cinvcode,isnull(cbatch,N'') as cbatch,isnull(cfree1,N'') as cfree1,isnull(cfree2,N'') as cfree2,"
     sql = sql & " isnull(cfree3,N'') as cfree3,isnull(cfree4,N'') as cfree4,isnull(cfree5,N'') as cfree5,isnull(cfree6,N'') as cfree6,"
     sql = sql & " isnull(cfree7,N'') as cfree7,isnull(cfree8,N'') as cfree8,isnull(cfree9,N'') as cfree9,isnull(cfree10,N'') as cfree10,"
     sql = sql & " convert(decimal(38,6),sum(case when brdflag=1 then iquantity else -iquantity end)) as iquantity,max(dvdate) as dvdate,max(dmadedate) as dmdate  "
     sql = sql & " From invposition a with (nolock) left join (select id,cvouchtype,chandler from rdrecord with (nolock)) h "
     sql = sql & "                    on isnull(a.csource,'')='' and a.rdid = h.id "
     sql = sql & " where (isnull(a.csource,'')<>'' or ( isnull(a.csource,'')='' and ( "
     sql = sql & "  (h.cvouchtype='34' and isnull(h.chandler,'')<>'') or "
     sql = sql & "  (h.cvouchtype ='01' " & IIf(bPurRkdCheck = True, " and isnull(h.chandler,'') <>''", "") & ") or "
     sql = sql & "  (h.cvouchtype ='08' " & IIf(bOtherInCheck = True, " and isnull(h.chandler,'') <>''", "") & ") or "
     sql = sql & "  (h.cvouchtype ='09' " & IIf(bOtherInCheck = True, " and isnull(h.chandler,'') <>''", "") & ") or "
     sql = sql & "  (h.cvouchtype ='11' " & IIf(bMaterialOutCheck = True, " and isnull(h.chandler,'') <>''", "") & ") or "
     sql = sql & "  (h.cvouchtype ='32' " & IIf(bSaleOutCheck = True, " and isnull(h.chandler,'') <>''", "") & ") or "
     sql = sql & "  (h.cvouchtype ='10' " & IIf(bProductInCheck = True, " and isnull(h.chandler,'') <>''", "") & ")  "
     sql = sql & "   ) ) ) "
     
     If sFilter <> "" Then
       sql = sql & " and " & sFilter
     End If
     
     sql = sql & " Group By  cposcode,cwhcode ,cinvcode,isnull(cbatch,N'') , isnull(cfree1,N'') ,isnull(cfree2,N'') ,"
     sql = sql & " isnull(cfree3,N'') , isnull(cfree4,N''),isnull(cfree5,N'') ,isnull(cfree6,N'') ,isnull(cfree7,N'') ,"
     sql = sql & " isnull(cfree8,N''),isnull(cfree9,N'') ,isnull(cfree10,N'') "
     sql = sql & " ) pos "
     sql = sql & " left join inventory I with (nolock) on I.cinvcode = pos.cinvcode "
     'sql = sql & "  where i.igrouptype <=1 and convert(decimal(38, 5), pos.iquantity) > 0"
     m_conn.Execute sql
     
     sql = "select cur.cwhcode,cur.cinvcode,cur.cfree1,cur.cfree2,cur.cfree3,cur.cfree4,cur.cfree5,cur.cfree6,cur.cfree7,cur.cfree8,cur.cfree9,cur.cfree10,cur.cbatch,"
     sql = sql & "  (isnull(cur.iquantity,0)-isnull(pos.iquantity,0)) as iquantity ,'' as cposcode,cur.dvdate,cur.dmdate as dmdate  "
     sql = sql & " from #curstock cur left join "
     sql = sql & " ( select cwhcode,cinvcode,isnull(cbatch,'') as cbatch,isnull(cfree1,N'') as cfree1,isnull(cfree2,N'') as cfree2, isnull(cfree3,N'') as cfree3,"
     sql = sql & "          isnull(cfree4,N'') as cfree4, isnull(cfree5,N'') as cfree5,isnull(cfree6,N'') as cfree6, isnull(cfree7,N'') as cfree7,isnull(cfree8,N'') as cfree8,isnull(cfree9,N'') as cfree9,"
     sql = sql & "          isnull(cfree10,N'') as cfree10, sum(isnull(iquantity,0)) as iquantity "
     sql = sql & "   from  #posstock "
     sql = sql & "   group by cwhcode,cinvcode,isnull(cbatch,''),isnull(cfree1,N''),isnull(cfree2,N''),isnull(cfree3,N''),isnull(cfree4,N''),isnull(cfree5,N''),"
     sql = sql & "            isnull(cfree6,N''), isnull(cfree7,N''),isnull(cfree8,N''),isnull(cfree9,N''),isnull(cfree10,N'') "
     sql = sql & "  ) pos  on cur.cwhcode =pos.cwhcode and cur.cinvcode = pos.cinvcode and isnull(cur.cfree1,'')= isnull(pos.cfree1,'') and isnull(cur.cfree2,'')= isnull(pos.cfree2,'') and "
     sql = sql & " isnull(cur.cfree3,'')= isnull(pos.cfree3,'') and isnull(cur.cfree4,'')= isnull(pos.cfree4,'') and isnull(cur.cfree5,'')= isnull(pos.cfree5,'') and isnull(cur.cfree6,'')= isnull(pos.cfree6,'') and "
     sql = sql & " isnull(cur.cfree7,'')= isnull(pos.cfree7,'') and isnull(cur.cfree8,'')= isnull(pos.cfree8,'') and isnull(cur.cfree9,'')= isnull(pos.cfree9,'')  and isnull(cur.cfree10,'')= isnull(pos.cfree10,'') and "
     sql = sql & " isnull(cur.cbatch,'')= isnull(pos.cbatch,'') "
     'sql = sql & " where convert(decimal(38,6),(isnull(cur.iquantity,0)-isnull(pos.iquantity,0))) <> 0 "
     sql = sql & " union all "
     sql = sql & " select pos.cwhcode,pos.cinvcode,pos.cfree1,pos.cfree2,pos.cfree3,pos.cfree4,pos.cfree5,pos.cfree6,pos.cfree7,pos.cfree8,pos.cfree9,pos.cfree10,pos.cbatch,"
     sql = sql & "  isnull(pos.iquantity,0) as iquantity ,pos.cposcode,pos.dvdate,pos.dmdate "
     sql = sql & " from  #posstock pos "
     'sql = sql & " where convert(decimal(38,6),isnull(pos.iquantity,0) ) <> 0  "
     

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
    
    Dim sXML As String
    While Not rs.EOF
        Set el = dom.createElement(dom.documentElement.getAttribute("roottag"))
        Call EXmlToRs.RStoXmlCommon(el, "CurrentStockXmlRs.Xml", rs)
        dom.documentElement.appendChild el
        
        '****************************
        '处理多页导出
        If paginate > 0 Then
           If counter = paginate Then
                sXML = dom.xml
                ConvertCurStock sXML
                gObjRef.ProcessExport sXML, lIndex, lPageCount
                'gObjRef.ProcessExport dom.xml, lIndex, lPageCount
                '清空Dom
                Set dom = Nothing
                Set dom = New DOMDocument
                dom.loadXML tempDom.xml
                
                lIndex = lIndex + 1
                counter = 0
            Else
                If (lIndex = lPageCount) And (counter = sumCount Mod paginate) Then
                    sXML = dom.xml
                    ConvertCurStock sXML
                    gObjRef.ProcessExport sXML, lIndex, lPageCount
                End If
            End If
            counter = counter + 1
        End If
        '*****************************
        
        rs.MoveNext
    Wend
    rs.Close
    Set rs = Nothing
    DropTable m_conn, "#curstock"
    DropTable m_conn, "#posstock"
    sRetXml = dom.xml
    '****************
'    Dim sErr As String
'    Dim oServeInterface As Dictionary
'    Dim oInterface As Object
'    Dim sErrStr As String
'    Dim oOptionCol As Dictionary
'    Dim i As Integer
'    Set oServeInterface = GetInterfaceCol(m_conn, oLogin)
'    If oServeInterface.Count > 0 Then
'       For i = 0 To oServeInterface.Count - 1
'           Set oInterface = oServeInterface.Items(i)
'
'           If IsFunctionExits(m_conn, oServeInterface.Keys(i), "SetUserDefineQuery") Then
'              sErr = ""
'              If Not oInterface.SetUserDefineQuery("currentstock", sRetXml, sErr) Then
'                 Err.Raise vbObjectError + 100, , sErr & vbCrLf
'              End If
'           End If
'       Next
'    End If
    ConvertCurStock sRetXml
    Exit Function

    
End Function

'下发现存量表
Public Function QueryProcCurrentStockNoPos(ByVal eleList As IXMLDOMNodeList, ByRef sRetXml As String) As Boolean
    Dim rs As New Recordset
    Dim rsDetail As New Recordset
    Dim dom As New DOMDocument
    Dim sql As String
    Dim el As IXMLDOMElement
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    Dim sFilter As String
    QueryProcCurrentStockNoPos = True
    dom.loadXML sRetXml
    
    
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
    
    
    sFilter = ""
    '**********取条件
    For Each el In eleList
       sFilter = sFilter & " (" & GetAttrValue(el, "name") & GetAttrValue(el, "operation") & "N'" & GetAttrValue(el, "value") & "'" & ") " & GetAttrValue(el, "logic")
    Next
    '**********
    dom.documentElement.Text = ""
    sql = " select currentstock.cwhcode,currentstock.cinvcode,currentstock.cbatch,'' as cposcode,currentstock.iquantity,currentstock.cfree1,currentstock.cfree2,currentstock.cfree3," & _
          " currentstock.cfree4,currentstock.cfree5,currentstock.cfree6,currentstock.cfree7,currentstock.cfree8,currentstock.cfree9,currentstock.cfree10,currentstock.dvdate,currentstock.dmdate  " & _
          " from currentstock  with (nolock) inner join inventory on currentstock.cinvcode=inventory.cinvcode and inventory.igrouptype<=1 "
    If sFilter <> "" Then
       sql = sql & " where " & sFilter
    End If
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
    
    Dim sXML As String
    While Not rs.EOF
        Set el = dom.createElement(dom.documentElement.getAttribute("roottag"))
        Call EXmlToRs.RStoXmlCommon(el, "CurrentStockXmlRs.Xml", rs)
        dom.documentElement.appendChild el
        
        '****************************
        '处理多页导出
        If paginate > 0 Then
           If counter = paginate Then
                sXML = dom.xml
                ConvertCurStock sXML
                gObjRef.ProcessExport sXML, lIndex, lPageCount
                'gObjRef.ProcessExport dom.xml, lIndex, lPageCount
                '清空Dom
                Set dom = Nothing
                Set dom = New DOMDocument
                dom.loadXML tempDom.xml
                
                lIndex = lIndex + 1
                counter = 0
            Else
                If (lIndex = lPageCount) And (counter = sumCount Mod paginate) Then
                    sXML = dom.xml
                    ConvertCurStock sXML
                    gObjRef.ProcessExport sXML, lIndex, lPageCount
                End If
            End If
            counter = counter + 1
        End If
        '*****************************
        
        rs.MoveNext
    Wend
    rs.Close
    Set rs = Nothing
   
    sRetXml = dom.xml
    '****************
'    Dim sErr As String
'    Dim oServeInterface As Dictionary
'    Dim oInterface As Object
'    Dim sErrStr As String
'    Dim oOptionCol As Dictionary
'    Dim i As Integer
'    Set oServeInterface = GetInterfaceCol(m_conn, oLogin)
'    If oServeInterface.Count > 0 Then
'       For i = 0 To oServeInterface.Count - 1
'           Set oInterface = oServeInterface.Items(i)
'
'           If IsFunctionExits(m_conn, oServeInterface.Keys(i), "SetUserDefineQuery") Then
'              sErr = ""
'              If Not oInterface.SetUserDefineQuery("currentstock", sRetXml, sErr) Then
'                 Err.Raise vbObjectError + 100, , sErr & vbCrLf
'              End If
'           End If
'       Next
'    End If
    ConvertCurStock sRetXml
    Exit Function

    
End Function



Private Sub ConvertCurStock(ByRef sXML)
    Dim sErr As String
    Dim oServeInterface As Dictionary
    Dim oInterface As Object
    Dim sErrStr As String
    Dim oOptionCol As Dictionary
    Dim i As Integer
    Set oServeInterface = GetInterfaceCol(m_conn, oLogin)
    If oServeInterface.Count > 0 Then
       For i = 0 To oServeInterface.Count - 1
           Set oInterface = oServeInterface.Items(i)
           If IsFunctionExits(m_conn, oServeInterface.Keys(i), "SetUserDefineQuery") Then
              sErr = ""
              If Not oInterface.SetUserDefineQuery("currentstock", sXML, sErr) Then
                 Err.Raise vbObjectError + 100, , sErr & vbCrLf
              End If
           End If
       Next
    End If
End Sub

Private Function GetExchRate(conn As ADODB.Connection) As String
  On Error GoTo errhandle
  Dim rs As New ADODB.Recordset
  rs.CursorLocation = adUseClient
  GetExchRate = "0"
  rs.Open "select  isnull(cvalue,'0') as value  from accinformation  where csysid='AA' and cname='iExchRateDecDgt'", conn, adOpenStatic, adLockReadOnly
  If Not rs.EOF And Not rs.BOF Then
     GetExchRate = rs.fields("value")
     If GetExchRate = "" Then
        GetExchRate = "0"
     End If
  End If
  rs.Close
  Set rs = Nothing
  Exit Function
  
errhandle:
 
End Function
'**********

Private Function EmptyQc(ByRef sRetXml As String) As Boolean
'================================================================================


'--------------------------------------------------------------------------------
'说明: 库存期初清除
'
'--------------------------------------------------------------------------------
  
   
    Dim sSOCode As String
    Dim sRet As String
    
    Dim rs As New ADODB.Recordset
    
    Dim bBegin As Boolean
    bBegin = False
    
    Dim oDomMsg As DOMDocument
  
    Dim oVoucher As USERPCO.VoucherCO
   
    Set oVoucher = New USERPCO.VoucherCO
    
    rs.CursorLocation = adUseClient
    
    If Not oVoucher.IniLogin(oLogin, sRet) Then
        sRet = "userpco初始化错误!"
        Call ErrDomAppendChild(m_errDom, "", 101, sRet)
        GoTo ExitFunction
    End If
   
    '只清除未审核期初单据
    rs.Open "select * from kcinit where isnull(chandler,'') =''", m_conn.ConnectionString, adOpenDynamic, adLockOptimistic
    
    If rs.RecordCount < 1 Then
       Call ErrDomAppendChild(m_errDom, "", 0, "ok")
       
       GoTo ExitFunction
    End If
    
    rs.MoveFirst
    While Not rs.EOF
       sRet = ""
       m_conn.BeginTrans
       sSOCode = rs.fields("ccode")
       
       Set oDomMsg = New DOMDocument
    
       Call oVoucher.Delete("34", rs.fields("id"), sRet, m_conn, rs.fields("ufts"), oDomMsg)
    
       If sRet = "" Then
          sRet = GetRetString(oDomMsg)
         
       End If
       
       If Not oDomMsg Is Nothing Then Set oDomMsg = Nothing
       
       If sRet = "" Then
         
         m_conn.CommitTrans
        
         Call ErrDomAppendChild(m_errDom, sSOCode, 0, "ok")
        
       Else
        
         m_conn.RollbackTrans
        
         Call ErrDomAppendChild(m_errDom, sSOCode, 101, sRet)
       End If
       rs.MoveNext
    Wend
  
ExitFunction:
    
    If Not rs Is Nothing Then Set rs = Nothing
    If Not oVoucher Is Nothing Then Set oVoucher = Nothing

    EmptyQc = True

    sRetXml = m_errDom.xml
  

End Function

Private Function EmptyQcscrap(ByRef sRetXml As String) As Boolean
'================================================================================


'--------------------------------------------------------------------------------
'说明: 库存期初清除
'
'--------------------------------------------------------------------------------
  
   
    Dim sSOCode As String
    Dim sRet As String
    
    Dim rs As New ADODB.Recordset
    
    Dim bBegin As Boolean
    bBegin = False
    
    Dim oDomMsg As DOMDocument
  
    Dim oVoucher As USERPCO.VoucherCO
   
    Set oVoucher = New USERPCO.VoucherCO
    
    rs.CursorLocation = adUseClient
    
    If Not oVoucher.IniLogin(oLogin, sRet) Then
        sRet = "userpco初始化错误!"
        Call ErrDomAppendChild(m_errDom, "", 101, sRet)
        GoTo ExitFunction
    End If
   
    '只清除未审核期初单据
    rs.Open "select id,cspcode,ufts from qcbhghead where isnull(cverifyperson,'')=''", m_conn.ConnectionString, adOpenDynamic, adLockOptimistic
    
    If rs.RecordCount < 1 Then
       Call ErrDomAppendChild(m_errDom, "", 0, "ok")
       
       GoTo ExitFunction
    End If
    
    rs.MoveFirst
    While Not rs.EOF
       sRet = ""
       m_conn.BeginTrans
       sSOCode = rs.fields("cspcode")
       
       Set oDomMsg = New DOMDocument
    
       Call oVoucher.Delete("55", rs.fields("id"), sRet, m_conn, rs.fields("ufts"), oDomMsg)
    
       If sRet = "" Then
          sRet = GetRetString(oDomMsg)
         
       End If
       
       If Not oDomMsg Is Nothing Then Set oDomMsg = Nothing
       
       If sRet = "" Then
         
         m_conn.CommitTrans
        
         Call ErrDomAppendChild(m_errDom, sSOCode, 0, "ok")
        
       Else
        
         m_conn.RollbackTrans
        
         Call ErrDomAppendChild(m_errDom, sSOCode, 101, sRet)
       End If
       rs.MoveNext
    Wend
  
ExitFunction:
    
    If Not rs Is Nothing Then Set rs = Nothing
    If Not oVoucher Is Nothing Then Set oVoucher = Nothing

    EmptyQcscrap = True

    sRetXml = m_errDom.xml
  

End Function
'增加移动取存量接口
Private Function DoQueryCurrentStock(sXML As String, sSubID As String) As String
    Dim sSel As String, sWhere As String, sGroup As String, sorder As String
    Dim sStr1 As String, sStr2 As String
    Dim rst As New ADODB.Recordset
    Dim strSql As String
    Dim oDom As New DOMDocument
    If GetMobileCondition(sXML, sSel, sWhere, sGroup, sorder, "") = False Then Exit Function
    rst.CursorLocation = adUseClient
    sSel = Replace(sSel, "'", "''")
    sWhere = Replace(sWhere, "'", "''")
    sGroup = Replace(sGroup, "'", "''")
    sorder = Replace(sorder, "'", "''")
    
    
    If Len(sWhere) > 3800 Then
        sStr1 = Left(sWhere, 3800)
        sStr2 = Mid(sWhere, 3801)
    Else
        sStr1 = sWhere
    End If
    If sSubID = "" Then sSubID = "ST"
    strSql = "prc_SCM_GetCurrentStockForVouch_All N'" + sSubID + "',N'" + sSel + "',N'" + sGroup + "',N'" + sStr1 + "',N'" + sStr2 + "',N'" + sorder + "'"
    rst.Open strSql, m_conn, adOpenForwardOnly, adLockReadOnly
    rst.save oDom, adPersistXML
    rst.Close
    Dim sXMLTmp As String
    sXMLTmp = "<?xml version='1.0' encoding='utf-8'?>" + vbCrLf

    sXMLTmp = sXMLTmp + "<ufinterface codeexchanged='n' display='' docid='' exportneedexch='n'" + vbCrLf

    sXMLTmp = sXMLTmp + " family='' proc='Query' receiver='u8' roottag='currentstockst' " + vbCrLf

    sXMLTmp = sXMLTmp + " sender='merp' paginate='0'> " + vbCrLf

    sXMLTmp = sXMLTmp + "<currentstockst> " + vbCrLf

    sXMLTmp = sXMLTmp + oDom.xml

    sXMLTmp = sXMLTmp + " </currentstockst>"

    sXMLTmp = sXMLTmp + "</ufinterface>"

    DoQueryCurrentStock = sXMLTmp
    'oDom.save "c:\result.xml"
    Set oDom = Nothing
End Function

Private Function GetMobileCondition(sXML As String, sSel As String, sWhere As String, sGroup As String, sorder As String, errMsg As String) As Boolean
    Dim oDom As New DOMDocument
    Dim oEle As IXMLDOMElement
    Dim oDic As New Scripting.Dictionary
    Dim sNormalSel As String, sGroupSel As String
    Dim sValue As String, sOperate As String, sLogic As String, sName As String
    Dim bSpecilWhere As Boolean
    sSel = ""
    sWhere = ""
    sGroup = ""
    sorder = ""
    If oDom.loadXML(sXML) = False Then Exit Function
    '先处理group
    For Each oEle In oDom.selectNodes("//group/field")
        If Not oDic.Exists("G:" + LCase(oEle.getAttribute("name"))) Then
            oDic.Add "G:" + LCase(oEle.getAttribute("name")), LCase(oEle.getAttribute("name"))
            sGroup = sGroup + oEle.getAttribute("name") + ","
        End If
    Next
    If sGroup <> "" Then sGroup = Left(sGroup, Len(sGroup) - 1)
    '处理select 要特殊处理group中的字段以及group中没有的 select 中的重复字段由于sqlserver可以处理 先不予处理
    For Each oEle In oDom.selectNodes("//select/field")
        sNormalSel = oEle.getAttribute("name")
        If IsNull(oEle.getAttribute("grouptype")) Then
            sGroupSel = "max"
        Else
            sGroupSel = oEle.getAttribute("grouptype")
        End If
        If sGroupSel <> "" Then
            sGroupSel = sGroupSel + "(" + sNormalSel + ") as " + sNormalSel
        Else
            sGroupSel = " max (" + sNormalSel + ") as " + sNormalSel
        End If
        If oDic.Exists("G:" + LCase(oEle.getAttribute("name"))) Then
            sSel = sSel + sNormalSel + ","
        Else
            sSel = sSel + sGroupSel + ","
        End If
    Next
    If sSel <> "" Then sSel = Left(sSel, Len(sSel) - 1)
    '处理where
    For Each oEle In oDom.selectNodes("//where/field")
        sName = oEle.getAttribute("name")
        sValue = oEle.getAttribute("value")
        sOperate = Trim(oEle.getAttribute("operation"))
        sLogic = oEle.getAttribute("logic")
        bSpecilWhere = False
        If Not IsNull(oEle.getAttribute("bspecial")) Then
            bSpecilWhere = CBool(oEle.getAttribute("bspecial"))
        End If
        If sName = "(" Or sName = ")" Then
            sValue = ""
            sOperate = ""
            sLogic = ""
        End If
        If sWhere = "" Then
            sWhere = " and "
            sLogic = ""
        End If
        '需要处理 is null 和 is not null
        If Trim(LCase(sOperate)) = "is null" Or Trim(LCase(sOperate)) = "is not null" Or bSpecilWhere Then
            sWhere = sWhere + " " + sLogic + " " + sName + sOperate
        Else
            If LCase(sOperate) <> "in" And Replace(LCase(sOperate), " ", "") <> "notin" Then
                sWhere = sWhere + " " + sLogic + " " + sName + "  " + sOperate + "  N'" + sValue + "' "
            Else
                sWhere = sWhere + " " + sLogic + " " + sName + "  " + sOperate + " ( " + sValue + ") "
            End If
        End If
    Next
    '处理order by
    For Each oEle In oDom.selectNodes("//order/field")
        sorder = sorder + oEle.getAttribute("name") + ","
    Next
    If sorder <> "" Then sorder = Left(sorder, Len(sorder) - 1)
    GetMobileCondition = True
End Function



Private Function ClearLsNode(ByVal ele As IXMLDOMElement, ByVal sRoot As String) As Boolean


    Dim eleHeader As IXMLDOMElement
    Dim eleBody As IXMLDOMElement
   
    Dim nd As IXMLDOMElement


    Dim attr As IXMLDOMAttribute


    Set eleHeader = ele.selectSingleNode("header")
  
   
    Set eleBody = ele.selectSingleNode("body")
     
    Dim elVouch As IXMLDOMElement
    
    Dim eTmpEle As IXMLDOMElement

    
    Set elVouch = ele.selectSingleNode("header/vouchtype")

   
    '01：采购入库单08：其他入库单09：其他出库单10：产成品入库单11：材料出库单32：销售出库单
    
    Set nd = Nothing
    
    For Each nd In ele.selectNodes("header/purchasetypecode")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/saletypecode")
        If elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/customercode")
        If elVouch.Text <> "32" And elVouch.Text <> "09" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/chandler")
        eleHeader.removeChild nd
        
    Next
    For Each nd In ele.selectNodes("header/handler")
        
       eleHeader.removeChild nd
       
    Next
    
    
    For Each nd In ele.selectNodes("header/vendorcode")
        If elVouch.Text <> "01" And elVouch.Text <> "08" Then
            eleHeader.removeChild nd
        End If
    Next
    '*************************
    ' add by tianxl 2004-05-10
    For Each nd In ele.selectNodes("header/exchname")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    For Each nd In ele.selectNodes("header/discounttaxtype")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    '**************************
    For Each nd In ele.selectNodes("header/ordercode")
        If elVouch.Text <> "01" And elVouch.Text <> "10" And elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/arrivecode")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/bomfirst")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/bpufirst")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
     For Each nd In ele.selectNodes("header/cvenpuomprotocol")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/dcreditstart")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/icreditperiod")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/dgatheringdate")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
     For Each nd In ele.selectNodes("header/bcredit")
        If elVouch.Text <> "01" Then
            eleHeader.removeChild nd
        End If
    Next
    
    For Each nd In ele.selectNodes("header/billcode")
        If elVouch.Text <> "01" And elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        Else
            nd.Text = "" '包辉测试提议
        End If
    Next
    
    For Each nd In ele.selectNodes("header/consignmentcode")
        If elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    '*****************add by tianxl 2005-10-18 南孚支持问题
    For Each nd In ele.selectNodes("header/contact")
       eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/id")
       eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/phone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/mobile")
        eleHeader.removeChild nd
    Next
   
    For Each nd In ele.selectNodes("header/address")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/conphone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/conmobile")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/deliverunit")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/contactname")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/officephone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/mobilephone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/psnophone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/psnmobilephone")
        eleHeader.removeChild nd
    Next
    For Each nd In ele.selectNodes("header/addcode")
        eleHeader.removeChild nd
    Next
    
    For Each nd In ele.selectNodes("header/customerccode")
        eleHeader.removeChild nd
    Next
    
    For Each nd In ele.selectNodes("header/cacauthcode")
        eleHeader.removeChild nd
    Next
    
    '**************************
    'add by liaonb 2005-4-18 销售出库单增加发货地址
    For Each nd In ele.selectNodes("header/shipaddress")
        If elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
    '**************************
    
    For Each nd In ele.selectNodes("header/serial")
        If elVouch.Text <> "10" And elVouch.Text <> "32" Then
            eleHeader.removeChild nd
        End If
    Next
  
   '不是材料出库单,清除补料标识 tianxl
    For Each nd In ele.selectNodes("header/iscomplement")
        If elVouch.Text <> "11" Then
            eleHeader.removeChild nd
        End If
    Next
    
    
    Dim entry As IXMLDOMElement
    For Each entry In ele.selectNodes("body/entry")
        For Each nd In entry.selectNodes("transitionid")
            If elVouch.Text <> "08" And elVouch.Text <> "09" Then
                entry.removeChild nd
            End If
        Next
          
        For Each nd In entry.selectNodes("subbillcode")
            If elVouch.Text <> "32" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("subpurchaseid")
            If elVouch.Text <> "01" Then
                entry.removeChild nd
            End If
        Next
        
        
        For Each nd In entry.selectNodes("subconsignmentid")
            If elVouch.Text <> "32" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("subproducingid")
            If elVouch.Text <> "11" And elVouch.Text <> "10" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("subcheckid")
            If elVouch.Text <> "01" Then
                entry.removeChild nd
            End If
        Next
        'add by tianxl 2004-05-10
        '去掉税率
        For Each nd In entry.selectNodes("taxrate")
            If elVouch.Text <> "01" Then
                entry.removeChild nd
            End If
        Next
        '材料出库单库管员
        For Each nd In entry.selectNodes("whpersoncode")
            If elVouch.Text <> "11" Then
                entry.removeChild nd
            End If
        Next
        For Each nd In entry.selectNodes("whpersonname")
            If elVouch.Text <> "11" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("vmivencode")
            If elVouch.Text = "10" Then
                entry.removeChild nd
            End If
        Next
        
        For Each nd In entry.selectNodes("materialfee")
           
            entry.removeChild nd
           
        Next
        
        For Each nd In entry.selectNodes("processcost")
           
             entry.removeChild nd
           
        Next
        
        For Each nd In entry.selectNodes("processfee")
             entry.removeChild nd
        Next
        
        For Each nd In entry.selectNodes("dmsdate")
            entry.removeChild nd
        Next
        
       '*************************
       For Each nd In entry.selectNodes("id")
          entry.removeChild nd
       Next
    Next
   
   End Function
'********************
'导出货位调整单
Public Function QueryAdjustPosProc(ByVal eleList As IXMLDOMNodeList, ByRef sRetXml As String) As Boolean
    Dim rs As New Recordset
    Dim rsDetail As New Recordset
    Dim dom As New DOMDocument
    Dim sql As String
    Dim el As IXMLDOMElement
    Dim EXmlToRs As New EaiXMLRSExch20.clsXmlRsExch
    Dim sExchRate As String
    dom.loadXML sRetXml
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
    
    
    sql = " select *  from AdjustPM "
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
        Call EXmlToRs.RStoXmlHead(el, "adjustpvouchxmlrs.Xml", rs)
        
        sql = "select * from AdjustPd where id= " & rs("id")
        rsDetail.Open sql, m_conn, adOpenStatic, adLockBatchOptimistic
                
        Call EXmlToRs.RStoXmlBody(el, "adjustpvouchxmlrs.Xml", rsDetail)
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
        rs.MoveNext
    Wend
    rs.Close
    Set rs = Nothing
    Set rsDetail = Nothing
    sRetXml = dom.xml
End Function

Private Function getSTOption(conn As ADODB.Connection, ByVal sOptional As String) As Boolean
    
    On Error GoTo errhandle
    
    getSTOption = False
    
    Dim oRd As New ADODB.Recordset
    oRd.CursorLocation = adUseClient
    
    Dim sSql As String
    sSql = "select isnull(cvalue,'') as cvalue from accinformation with (nolock) where csysid=N'st' and cname =N'" & sOptional & "'"
    oRd.Open sSql, conn, adOpenDynamic, adLockReadOnly
    If Not oRd.EOF Then
        If LCase(vFieldVal(oRd.fields("cvalue"))) = "true" Then
           getSTOption = True
        End If
    End If
    oRd.Close
    Set oRd = Nothing
    Exit Function
    
errhandle:
    getSTOption = False
End Function


Private Function IsValidVTID(conn As ADODB.Connection, ByVal sVTID As String, ByVal sCardNumber As String) As Boolean
    
    IsValidVTID = False
    
    If sVTID = "" Or sVTID = "0" Or sCardNumber = "" Then
        Exit Function
    End If
    
    Dim oRd As ADODB.Recordset
    Set oRd = New ADODB.Recordset
    oRd.CursorLocation = adUseClient
    
    Dim sSql As String
    
    sSql = " select vt_id  from vouchertemplates with (nolock) where vt_id =" & sVTID & " And vt_cardnumber = N'" & sCardNumber & "' and vt_templatemode = 0 "
    oRd.Open sSql, conn, adOpenDynamic, adLockReadOnly
    
    If oRd.RecordCount > 0 Then
       IsValidVTID = True
    End If
    
    Set oRd = Nothing
   
    
End Function

Private Sub ModifyLsQueryFlag(ByVal oEle As IXMLDOMElement, ByRef sRetXml As String, ByVal sRoot As String)
    On Error Resume Next
    Dim TmpEle As IXMLDOMElement
    Dim oValue As IXMLDOMElement
    
    
    '<voucher cvouchtype="apptransvouch"  id ="1"  ccode ="00000001"/>
    'TmpEle为一张定单的内容
    
    Dim cCode As String
    Dim sSql As String
    Dim iCount  As Integer
    Dim sId As String
    Dim svouchtype As String
    Dim sErr As String
    iCount = 0
    
    sSql = ""
    
    For Each TmpEle In oEle.selectNodes("//voucher")
        sId = GetAttrValue(TmpEle, "id")
        svouchtype = LCase(GetAttrValue(TmpEle, "cvouchtype"))
        'cCode = GetAttrValue(TmpEle, "ccode")
        sSql = ""
        
        If svouchtype = "stotherinvouch" Then
           sSql = sSql & " update rdrecord  set bislsquery = 1 where cvouchtype ='08' and id =" & sId
        ElseIf svouchtype = "stsaleoutvouch" Then
           sSql = sSql & " update rdrecord  set bislsquery = 1 where cvouchtype ='32' and id =" & sId
        ElseIf svouchtype = "apptransvouch" Then
           sSql = sSql & " update st_apptransvouch  set bislsquery = 1 where id =" & sId
        End If
        
        If sSql <> "" Then
            m_conn.Execute sSql
            
            If VBA.Err.Number = 0 Then
                Call ErrDomAppendChild(m_errDom, sId, 0, "ok")
            Else
                Call ErrDomAppendChild(m_errDom, "", 999, sId & VBA.Err.Description)
            End If
            
        End If
        
        VBA.Err.Clear
    Next

    sRetXml = m_errDom.xml
    VBA.Err.Clear
    
End Sub

