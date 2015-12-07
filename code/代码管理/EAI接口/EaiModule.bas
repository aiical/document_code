Attribute VB_Name = "EaiModule"
Option Explicit
Dim colInterface As Dictionary

Public Function GetInterfaceCol(ByVal conn As ADODB.Connection, oLogin As Object) As Dictionary
   Dim strSql As String
   Dim recd As New ADODB.Recordset
   Dim oInterface As Object
   Dim sErr As String
   recd.CursorLocation = adUseClient
   On Error GoTo errhandle
   strSql = "select * from UserDefineDLL where cSub_ID=N'ST'"
   recd.Open strSql, conn, adOpenDynamic, adLockOptimistic
   If colInterface Is Nothing Then
      Set colInterface = New Dictionary
   End If
   colInterface.removeAll
   If Not recd.EOF Then
      recd.MoveFirst
      While Not recd.EOF
         If Not colInterface.Exists(recd.fields("cDll_Name").Value) Then
            Set oInterface = CreateObject(recd.fields("cDll_Name"))
            colInterface.Add recd.fields("cDll_Name").Value, oInterface
            If IsFunctionExits(conn, recd.fields("cDll_Name").Value, "SetLogin") Then
               oInterface.SetLogin oLogin, conn, sErr
            End If
         
         End If
         recd.MoveNext
      Wend
   
   End If
   If recd.State = adStateOpen Then
      recd.Close
   End If
   Set recd = Nothing
   Set GetInterfaceCol = colInterface
   Exit Function
errhandle:
   Set GetInterfaceCol = colInterface
End Function

Public Function IsFunctionExits(conn As ADODB.Connection, ByVal sClassName As String, ByVal sFunctionName As String) As Boolean
   Dim strSql As String
   Dim recd As New ADODB.Recordset
   On Error GoTo errhandle
   IsFunctionExits = False
   recd.CursorLocation = adUseClient
   strSql = "select * from userdefinedll where cSub_id=N'ST'" & " and cdll_name=N'" & sClassName & "' and cFun_Name=N'" & sFunctionName & "'"
   recd.Open strSql, conn, adOpenDynamic, adLockOptimistic
   If recd.RecordCount > 0 Then
      IsFunctionExits = True
   
   End If
   If recd.State = adStateOpen Then
      recd.Close
   End If
   Set recd = Nothing
   Exit Function
errhandle:
   IsFunctionExits = False
   
End Function

Public Sub setNodeValue(ByVal sourceNode As IXMLDOMElement, ByRef desNode As IXMLDOMElement)
   Dim attr As IXMLDOMAttribute
   Dim attrs As IXMLDOMNamedNodeMap
  
   Dim i As Long
   For i = 0 To sourceNode.Attributes.length - 1
       desNode.setAttribute sourceNode.Attributes(i).nodeName, sourceNode.getAttribute(sourceNode.Attributes(i).nodeName)
   
   Next
   
   
   
End Sub

Public Function NullToStr(ByVal a As Variant) As String
    NullToStr = IIf(IsNull(a), "", a)
End Function

Public Function IsLsMakeVouch(oDom As DOMDocument) As Boolean
    
    On Error Resume Next
    
    IsLsMakeVouch = False
    If oDom Is Nothing Then Exit Function
    Dim eleHead As IXMLDOMElement
   
    Set eleHead = oDom.selectSingleNode("//z:row")
    If eleHead Is Nothing Then
        Exit Function
    End If
    
    If NullToStr(eleHead.getAttribute("csource")) = "2" Then '零售系统生成单据
       IsLsMakeVouch = True
    End If
    
    Err.Clear
End Function

Public Sub DropTable(conn As ADODB.Connection, sTable As String)

    On Error Resume Next
    conn.Execute "drop table " & sTable
    VBA.Err.Clear
End Sub
