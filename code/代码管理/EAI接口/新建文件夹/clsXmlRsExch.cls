VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsXmlRsExch"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'******************************************************
'头部转换主表内容 sXml一张单据的Xml,sType:单据类型
'rs主表recordset,sXRFileName: XmlToRecordset 文件名
'******************************************************
Public Function XmlToRsHeader(ByVal sXml As String, ByVal sType As String, _
                    ByRef rs As ADODB.Recordset, ByVal sXRFilename As String)
    Dim dom As New DOMDocument  '单据的Dom
    Dim domXR As DOMDocument    'XMLToRecordset的Dom
    Dim EleXR As IXMLDOMElement 'XMLToRecordset的Element
    Dim ele As IXMLDOMElement   '单据的Element
    Dim eleTmp As IXMLDOMElement    '临时用Element
    Dim sFieldName As String        '数据库字段名

    If Not dom.loadXML(sXml) Then
        Err.Raise 3000, , "传入的xml有误"
        Exit Function
    End If
    
    Set domXR = New DOMDocument
    If Not domXR.Load(sXRFilename) Then
        Err.Raise 3001, , sXRFilename & "文件不存在"
        Exit Function
    End If
    
    Set EleXR = domXR.documentElement.selectSingleNode("header")
    If EleXR Is Nothing Then
        Err.Raise 3002, , sXRFilename & "没有header节点"
    End If
    
    Set ele = dom.documentElement.selectSingleNode("header")
    If ele Is Nothing Then
        Err.Raise 3002, , "传入的XML没有header节点"
    End If
    
    rs.AddNew
    For Each eleTmp In ele.childNodes
        Debug.Print eleTmp.nodeName
        sFieldName = GetXmlFieldName(EleXR, eleTmp.tagName)
        Call CheckType(rs, sFieldName, eleTmp)
        If eleTmp.Text <> "" Then rs(sFieldName) = Trim(eleTmp.Text)
        Debug.Print sFieldName
        
    Next
    
    Set dom = Nothing
    Set EleXR = Nothing
    Set domXR = Nothing
    Set ele = Nothing
    Set eleTmp = Nothing
End Function


'******************************************************
'体部转换子表内容 sXml一张单据的Xml,sType:单据类型
'rs主表recordset,sXRFileName: XmlToRecordset 文件名
'******************************************************
Public Function XmlToRsBody(ByVal sXml As String, ByVal sType As String, _
                    ByRef rs As ADODB.Recordset, ByVal sXRFilename As String)
                        Dim dom As New DOMDocument  '单据的Dom
    Dim domXR As DOMDocument    'XMLToRecordset的Dom
    Dim EleXR As IXMLDOMElement 'XMLToRecordset的Element
    Dim ele As IXMLDOMElement   '单据的Element
    Dim eleTmp As IXMLDOMElement    '临时用Element
    Dim sFieldName As String        '数据库字段名
    Dim eleEntrylst As IXMLDOMNodeList  '分录集
    Dim eleEntry As IXMLDOMElement      '分录

    If Not dom.loadXML(sXml) Then
        Err.Raise 3000, , "传入的xml有误"
        Exit Function
    End If
    
    Set domXR = New DOMDocument
    If Not domXR.Load(sXRFilename) Then
        Err.Raise 3001, , sXRFilename & "文件不存在"
        Exit Function
    End If
    
    Set EleXR = domXR.documentElement.selectSingleNode("body")
    If EleXR Is Nothing Then
        Err.Raise 3010, , sXRFilename & "没有body节点"
    End If
    
    Set ele = dom.documentElement.selectSingleNode("body")
    If ele Is Nothing Then
        Err.Raise 3011, , "传入的xml没有Body节点"
    End If
    Set eleEntrylst = ele.selectNodes("entry")
    If eleEntrylst.length = 0 Then
        Err.Raise 3012, , "传入的xml没有entry节点"
    End If
    
    
    
    For Each eleEntry In eleEntrylst
        rs.AddNew
        For Each eleTmp In eleEntry.childNodes
            sFieldName = GetXmlFieldName(EleXR, eleTmp.tagName)
            If sFieldName <> "" Then
                Call CheckType(rs, sFieldName, eleTmp)
                If eleTmp.Text <> "" Then rs(sFieldName) = Trim(eleTmp.Text)
            End If
        Next
    Next
    
    Set EleXR = Nothing
    Set domXR = Nothing
    Set ele = Nothing
    Set eleTmp = Nothing
    Set eleEntrylst = Nothing
    Set eleEntry = Nothing

End Function


'******************************************************
'头部转换主表内容 sXml一张单据的Xml,sType:单据类型
'rs主表recordset,sXRFileName: XmlToRecordset 文件名
'******************************************************
Public Function XmlToRsCommon(ByVal sXml As String, ByVal sType As String, _
                    ByRef rs As ADODB.Recordset, ByVal sXRFilename As String)
    Dim dom As New DOMDocument  '单据的Dom
    Dim domXR As DOMDocument    'XMLToRecordset的Dom
    Dim EleXR As IXMLDOMElement 'XMLToRecordset的Element
    Dim ele As IXMLDOMElement   '单据的Element
    Dim eleTmp As IXMLDOMElement    '临时用Element
    Dim sFieldName As String        '数据库字段名

    If Not dom.loadXML(sXml) Then
        Err.Raise 3000, , "传入的xml有误"
        Exit Function
    End If
    
    Set domXR = New DOMDocument
    If Not domXR.Load(App.Path & "\XRXml\" & sXRFilename) Then
        Err.Raise 3001, , sXRFilename & "文件不存在"
        Exit Function
    End If
    
    Set EleXR = domXR.documentElement.selectSingleNode("common")
    If EleXR Is Nothing Then
        Err.Raise 3002, , sXRFilename & "没有common节点"
    End If
    
    Set ele = dom.documentElement
    If ele Is Nothing Then
        Err.Raise 3002, , "传入的XML没有" & sType & "节点"
    End If
    
    rs.AddNew
    For Each eleTmp In ele.childNodes
        sFieldName = GetXmlFieldName(EleXR, eleTmp.tagName)
        Call CheckType(rs, sFieldName, eleTmp)
       If eleTmp.Text <> "" Then rs(sFieldName) = Trim(eleTmp.Text)
    Next
    
    Set dom = Nothing
    Set EleXR = Nothing
    Set domXR = Nothing
    Set ele = Nothing
    Set eleTmp = Nothing
End Function

Public Function RStoXmlHead(ByRef el As IXMLDOMElement, ByVal sXRFilename As String, ByRef rsHead As Recordset)
    Dim dom As New DOMDocument
    Dim elHead As IXMLDOMElement
    Dim elTemp As IXMLDOMElement
    Dim ele As IXMLDOMElement
    Dim node As IXMLDOMNode
    Dim fld As Field
    
    If Not dom.Load(sXRFilename) Then
        Err.Raise 3001, , sXRFilename & "文件不存在"
        Exit Function
    End If
    
    Set elHead = el.ownerDocument.createElement("header")
    el.appendChild elHead
    For Each node In dom.documentElement.selectSingleNode("//header").childNodes
        If node.nodeType = NODE_ELEMENT Then
            Set ele = node
            Set elTemp = ele.ownerDocument.createElement(ele.nodeName)
            elHead.appendChild elTemp
            
            If Len(Trim(ele.Text)) > 0 Then
                Set fld = rsHead(Trim(ele.Text))
                If Not IsNull(fld) And Not IsNull(fld.Value) And Not IsEmpty(fld.Value) Then
                    elTemp.Text = CStr(fld.Value)
                End If
            End If
        End If
    Next
    
    Set dom = Nothing
End Function
Public Function RStoXmlBody(ByRef el As IXMLDOMElement, ByVal sXRFilename As String, ByRef rsBody As Recordset)
    Dim dom As New DOMDocument
    Dim elTemp As IXMLDOMElement
    Dim elem As IXMLDOMElement
    Dim elBody As IXMLDOMElement
    Dim elEntry As IXMLDOMElement
    Dim node As IXMLDOMNode
    Dim fld As Field
    
    If Not dom.Load(sXRFilename) Then
        Err.Raise 3001, , sXRFilename & "文件不存在"
        Exit Function
    End If
    
    Set elBody = el.ownerDocument.createElement("body")
    
    el.appendChild elBody
    While Not rsBody.EOF
        Set elEntry = el.ownerDocument.createElement("entry")
        elBody.appendChild elEntry
        For Each node In dom.documentElement.selectSingleNode("//body").childNodes
            If node.nodeType = NODE_ELEMENT Then
                Set elem = node
                Set elTemp = el.ownerDocument.createElement(elem.nodeName)
                elEntry.appendChild elTemp
                If Len(Trim(elem.Text)) > 0 Then
                    Set fld = rsBody(Trim(elem.Text))
                    If Not IsNull(fld) And Not IsNull(fld.Value) And Not IsEmpty(fld.Value) Then
                        elTemp.Text = CStr(fld.Value)
                    End If
                End If
            End If
        Next
        rsBody.MoveNext
    Wend
    
    Set dom = Nothing
End Function
Public Function RStoXmlCommon(ByRef el As IXMLDOMElement, ByVal sXRFilename As String, ByRef rsCommon As Recordset)
    Dim dom As New DOMDocument
    Dim elCommon As IXMLDOMElement
    Dim elTemp As IXMLDOMElement
    Dim ele As IXMLDOMElement
    Dim node As IXMLDOMNode
    Dim fld As Field
    
    If Not dom.Load(App.Path & "\XRXml\" & sXRFilename) Then
        Err.Raise 3001, , sXRFilename & "文件不存在"
        Exit Function
    End If
    
    Set elCommon = el.ownerDocument.createElement("common")
    el.appendChild elCommon
    For Each node In dom.documentElement.selectSingleNode("//common").childNodes
        If node.nodeType = NODE_ELEMENT Then
            Set ele = node
            Set elTemp = ele.ownerDocument.createElement(ele.nodeName)
            elCommon.appendChild elTemp
            
            If Len(Trim(ele.Text)) > 0 Then
                Set fld = rsCommon(Trim(ele.Text))
                If Not IsNull(fld) And Not IsNull(fld.Value) And Not IsEmpty(fld.Value) Then
                    elTemp.Text = CStr(fld.Value)
                End If
            End If
        End If
    Next
    
    Set dom = Nothing

End Function



'***************************************************
'检查字段类型,长度
'rs 目的Recordset,eleTmp  字段对应的 Element
'**************************************************
Public Sub CheckType(ByVal rs As ADODB.Recordset, ByVal sFieldName As String, ByVal eleTmp As IXMLDOMElement)

        Select Case rs(sFieldName).Type
        Case adChar, adLongVarChar, adBSTR, adVarChar, adWChar
            If StrLen(Trim(eleTmp.Text)) > rs(sFieldName).DefinedSize Then
                Err.Raise 3005, , eleTmp.tagName & "字符长度超长"
                Exit Sub
            End If
        Case adDBTimeStamp, adDBDate, adDBTime
            If eleTmp.Text <> "" Then
                If Not IsDate(eleTmp.Text) Then
                    Err.Raise 3006, , eleTmp.tagName & "日期格式非法"
                    Exit Sub
                End If
            End If
        Case adDecimal, adDouble, adCurrency, adInteger, adNumeric, adSingle, adBigInt, adBoolean
            If eleTmp.Text = "" Then eleTmp.Text = 0
            If Not IsNumeric(eleTmp.Text) Then
                Err.Raise 3007, , eleTmp.Text & "数值非法"
                Exit Sub
            End If
        End Select
End Sub

'***********************************
'取的Xml对应的数据库字段名
'***********************************
Public Function GetXmlFieldName(ByVal EleXR As IXMLDOMElement, ByVal sTagName As String) As String
    Dim str As String
    Dim eleTmp As IXMLDOMElement
    
    If EleXR Is Nothing Then
        Err.Raise 3002, , "非法的Element"
        Exit Function
    End If
    
    Set eleTmp = EleXR.selectSingleNode(sTagName)
    If eleTmp Is Nothing Then
        GetXmlFieldName = ""
        Set eleTmp = Nothing
        Exit Function
    Else
        GetXmlFieldName = eleTmp.Text
    End If
    Set eleTmp = Nothing
End Function



