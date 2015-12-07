VERSION 5.00
Object = "{3F0B58C5-3543-42B3-BD11-43278DFACA02}#1.6#0"; "FindOCX.ocx"
Object = "{005151D4-33F6-471B-B651-222D4E411832}#4.4#0"; "UFFormPartner.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Begin VB.Form FrmZMulModify 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Dialog Caption"
   ClientHeight    =   6645
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   11580
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6553.471
   ScaleMode       =   0  'User
   ScaleWidth      =   11530.52
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin FindOCX.FindCtl Find 
      Height          =   6615
      Left            =   0
      TabIndex        =   0
      Top             =   30
      Width           =   11580
      _ExtentX        =   20346
      _ExtentY        =   11668
      EOptType        =   2
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   570
      Top             =   30
      _ExtentX        =   1905
      _ExtentY        =   529
   End
   Begin UFFormPartner.UFFrmCaption UFFrmCaptionMgr 
      Left            =   0
      Top             =   0
      _ExtentX        =   926
      _ExtentY        =   661
      Caption         =   "Form1"
      DebugFlag       =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
End
Attribute VB_Name = "FrmZMulModify"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit
Dim RstType As ADODB.Recordset '获得数据库字段数据类型
Dim m_bFirstLoad  As Boolean

''---------------------------------------
''功能：CmbItem控件内容变化，则CmbText或EdtText形式随之相应变化
''---------------------------------------
'Private Sub CmbItem_Change()
'    Call FindMatch(CmbItem.Text, CmbItem)
'    Dim i As Integer
'    CmbText.Clear
'    CmbText.Visible = False
'    EdtText.Visible = False
'    EdtText.Property = EditNormal
'    EdtText.MaxLength = 120
'    EdtText.Locked = False
'    EdtText.UTooltipText = ""
'    EdtText.Text = ""
'    CmdAll.Visible = False
'    If CmbItem.ListIndex = -1 Then
'        Exit Sub
'    End If
'    For i = 0 To UBound(ArrCHField)
'        If CmbItem.Text = ArrCHField(i) And ArrCHField(i) <> "" And (ArrField(i) <> "") Then
'            Dim tFieldName As String
'            Dim Pos As Integer
'            Pos = InStr(1, ArrField(i), ".")
'            If Pos <> 0 Then
'                tFieldName = Right(ArrField(i), Len(ArrField(i)) - Pos)
'            Else
'                tFieldName = ArrField(i)
'            End If
'            Call g_oPub.SetBadStrExceptionByFld(EdtText, tFieldName, "inventory")
'            Select Case RstType(tFieldName).Type
'                Case adBigInt, adInteger, adSmallInt, adTinyInt, adUnsignedBigInt, adUnsignedInt, adUnsignedSmallInt, adUnsignedTinyInt  'adGUID
'                    EdtText.Visible = True
'                    Call g_oPub.SetIntLen(EdtText)
'                Case adBinary, adBoolean, adLongVarBinary, adVarBinary
'                    CmbText.Visible = True
'                    CmbText.AddItem boolItems(1)  '"是"
'                    CmbText.AddItem boolItems(0)  '"否"
'                    CmbText.ListIndex = 0
'                    'CmbText.AddItem ""
'                    'CmbText.Style = 2 'list
'                Case adDate, adDBDate, adDBTime, adDBTimeStamp, adFileTime
'                    EdtText.Visible = True
'                    EdtText.Property = EditDate
'                    CmdAll.Picture = LoadResPicture(108, 0)
'                    CmdAll.Visible = True
'                    CmdAll.Tag = "date"
'                Case adCurrency, adDecimal, adDouble, adNumeric, adSingle, adVarNumeric
'                    EdtText.Visible = True
'                    Select Case LCase(tFieldName)
'                        Case LCase("iInvSCost"), LCase("iInvLSCost")
'                            Call g_oPub.SetDblLen(EdtText, , g_iBillPriceDecDgt)
'                        Case LCase("iInvNCost"), LCase("iInvRCost"), LCase("ZGJJ"), LCase("iInvSPrice") '                            , LCase("iInvMPCost"), LCase("iInvSCost"), LCase("iInvLSCost") '                            , LCase("iHighPrice")
'                            Call g_oPub.SetDblLen(EdtText, , g_iPriceDecDgt)
'                        Case LCase("iLowSum"), LCase("iInvBatch"), LCase("iSafeNum"), LCase("iTopSum") '                            , LCase("iInvWeight"), LCase("iOverStock"), LCase("iVolume")
'                            Call g_oPub.SetDblLen(EdtText, , g_iQuanDecDgt)
'                        Case LCase("FOutExcess"), LCase("FInExcess"), LCase("fExpensesExch"), LCase("iWastage")
'                            Call g_oPub.SetDblLen(EdtText, , g_iDecDgt6)
'                        Case LCase("iInvAdvance") '特殊处理固定提前期
'                            Call g_oPub.SetIntLen(EdtText, 8)
'                        Case LCase("iTaxRate") '税率特殊处理
'                            Call g_oPub.SetDblLen(EdtText, 3 + 2 + g_iRateDecDgt, g_iRateDecDgt)
'                        Case LCase("CInvDefine13"), LCase("CInvDefine13")
'                            Call g_oPub.SetDblLen(EdtText, , 6)
'                        Case Else
'                            Call g_oPub.SetDblLen(EdtText, , 4)
'                    End Select
'                Case Else
'                    EdtText.Visible = True
'                    EdtText.MaxLength = RstType(tFieldName).DefinedSize
'            End Select
'            Dim j As Integer
'            Select Case LCase(tFieldName)
'                Case "cvaluetype"
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    For j = LBound(cValueTypeItems) To UBound(cValueTypeItems)
'                        CmbText.AddItem cValueTypeItems(j)
'                    Next j
'                Case LCase("cBarCode") '对应条形码
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    CmbText.AddItem ""
'                    CmbText.AddItem g_oPub.GetResString("U8.AA.INVENTORY.FRMMULMODIFY.81_1") 'U8.AA.INVENTORY.FRMMULMODIFY.81_1="对应存货编码"
'                Case LCase("cInvABC")
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    CmbText.AddItem ""
'                    CmbText.AddItem "A"
'                    CmbText.AddItem "B"
'                    CmbText.AddItem "C"
'                Case LCase("IRecipeBatch")
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    CmbText.AddItem iRecipeBatchItems(0) 'U8.AA.INVENTORY.FRMMULMODIFY.92_1="都不是"
'                    CmbText.AddItem iRecipeBatchItems(1) 'U8.AA.INVENTORY.FRMMULMODIFY.93_1="处方药"
'                    CmbText.AddItem iRecipeBatchItems(2) 'U8.AA.INVENTORY.FRMMULMODIFY.94_1="非处方药"
'                    CmbText.AddItem iRecipeBatchItems(3)
'                Case LCase("iROPMethod")
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    CmbText.AddItem iROPMethodItems(1)
'                    CmbText.AddItem iROPMethodItems(2)
'                Case LCase("iBatchRule")
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    CmbText.AddItem iBatchRuleItems(0)
'                    CmbText.AddItem iBatchRuleItems(4)
'                    CmbText.AddItem iBatchRuleItems(2)
'                    CmbText.AddItem iBatchRuleItems(5)
'                Case LCase("cPlanMethod")
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    CmbText.AddItem "R"
'                    CmbText.AddItem "N"
'                Case LCase("cSRPolicy")
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    CmbText.AddItem "PE"
'                    CmbText.AddItem "LP"
'                Case LCase("iSupplyType")
'                    EdtText.Visible = False
'                    CmbText.Visible = True
'                    Call AddCmbItems(CmbText, iSupplyTypeItems, 0)
''                Case LCase("iTestStyle") '检验方式
''                    EdtText.Visible = False
''                    CmbText.Visible = True
''                    Call AddCmbItems(CmbText, iTestStyleItems, 0)
''                Case LCase("iDTMethod") '抽检方案
''                    EdtText.Visible = False
''                    CmbText.Visible = True
''                    Call AddCmbItems(CmbText, iDTMethodItems, 0)
''                Case LCase("iDTStyle") '检验严格度
''                    EdtText.Visible = False
''                    CmbText.Visible = True
''                    Call AddCmbItems(CmbText, iDTStyleItems, -1)
''                Case LCase("ciDTLevel") '检验水平
''                    EdtText.Visible = False
''                    CmbText.Visible = True
''                    Call AddCmbItems(CmbText, ciDTLevelItems, -1)
''                Case LCase("cDTAQL") 'AQL
''                    EdtText.Visible = False
''                    CmbText.Visible = True
''                    Call AddCmbItems(CmbText, cAQLItems, -1)
''                Case LCase("iEndDTStyle") '自制品检验严格度
''                    EdtText.Visible = False
''                    CmbText.Visible = True
''                    Call AddCmbItems(CmbText, iEndDTStyleItems, -1)
'                Case Else
'                    Select Case LCase(tFieldName)
'                        Case LCase("cInvCCode"), LCase("cVenCode"), LCase("cPosition"), LCase("cDefWareHouse"), LCase("cInvPersonCode"), LCase("cPurPersonCode"), LCase("cInvDepCode"), LCase("cInvPlanCode") 'LCase("Inventory.cPosition"), LCase("cEnterprise")，LCase("Inventory.cVenCode"),LCase("Inventory.cInvCCode"),
'                             'LCase("CUnitGroupCode"), LCase("cComunitCode"), '                             'LCase("cPUComunitCode"), LCase("cSAComunitCode"), LCase("cSTComunitCode"), LCase("cCAComunitCode")
'                            '存货大类编码,主要供货单位,货位编码,生产企业
'                            '计量单位组,主计量单位编码,
'                            '采购默认计量单位编码,销售默认计量单位编码,库存默认计量单位编码,成本默认计量单位编码
'                            CmdAll.Picture = g_oPub.GetRes(101) ' LoadResPicture(118, 0)
'                            CmdAll.Tag = tFieldName
'                            CmdAll.Visible = True
'                            EdtText.Visible = True
'                            CmbText.Visible = False
'                        Case LCase("cInvDefine1"), LCase("cInvDefine2"), LCase("cInvDefine3"), LCase("cInvDefine4"), LCase("cInvDefine5"), LCase("cInvDefine6"), LCase("cInvDefine7"), '                             LCase("cInvDefine8"), LCase("cInvDefine9"), LCase("cInvDefine10"), LCase("cInvDefine11"), LCase("cInvDefine12"), LCase("cInvDefine13"), LCase("cInvDefine14") '                             , LCase("cInvDefine15"), LCase("cInvDefine16")
'                            If Not (LCase(tFieldName) = LCase("cInvDefine15") Or LCase(tFieldName) = LCase("cInvDefine16")) Then
'                                CmdAll.Picture = g_oPub.GetRes(101) ' LoadResPicture(118, 0)
'                            End If
'                            CmdAll.Tag = tFieldName
'                            CmdAll.Visible = True
'                            EdtText.Visible = True
'                            CmbText.Visible = False
'                    End Select
'            End Select
'            Exit For
'        End If
'    Next i
'End Sub

''---------------------------------------
''功能：查找Combox框中对应的字符串
''参数：sText：Combox中的文本
''     Con:ComBox控件对象
''---------------------------------------
'Private Sub FindMatch(sText As String, Con As Control)
'    Dim iLen As Integer
'    iLen = Len(sText)
'    Dim i As Integer
'    For i = 0 To Con.ListCount - 1
'        If sText = Left(Con.List(i), iLen) And iLen <> 0 Then
'            Con.ListIndex = i
'            Exit For
'        End If
'    Next i
'    Con.SelStart = iLen
'    Con.SelLength = Len(Con.Text)
'End Sub
'
''---------------------------------------
''功能：在Combox框中输入数字，查找相应的combox.listIndex
''参数：Con：对应的Combox控件
''---------------------------------------
'Private Sub NumMatch(Con As Control)
'    If IsNumeric(Con.Text) = True Then
'        Dim iList As Integer
'        iList = CInt(Left(Con.Text, 3))
'        If iList > Con.ListCount Then
'            iList = Con.ListCount
'        End If
'        Con.ListIndex = iList - 1
'    End If
'End Sub
'
'Private Sub CmbItem_Click()
'    CmbItem_Change
'End Sub
'
''---------------------------------------
''功能：CmbItem框输入回车时控制操作
''---------------------------------------
'Private Sub CmbItem_KeyPress(KeyAscii As Integer)
'    If KeyAscii = 13 Then
'        NumMatch Me.CmbItem
'            If EdtText.Visible = True Then
'                EdtText.SetFocus
'            ElseIf CmbText.Visible = True Then
'                Me.CmbText.SetFocus
'            End If
'    End If
'End Sub
'
'
''-----------------------------------------
''功能：添加参照
''----------------------------------------
'Private Sub CmdAll_Click()
'    Dim Rs As New ADODB.Recordset
'    Dim AttrValue As String
'    Dim i As Integer
'    Dim strGrid As String
'    Dim strClass As String
'    Dim sCode As String
'    Dim sName As String
'    Dim bReturn As Boolean
'    For i = 0 To UBound(ArrCHField)
'        If CmbItem.Text = ArrCHField(i) Then
'            AttrValue = EdtText.Text
'
'            Select Case LCase(CmdAll.Tag)
'                Case LCase("cInvCCode"), LCase("Inventory.cInvCCode") '存货大类编码,
'                    Call GetRef(CmdAll.Tag, sCode, sName, bReturn, EdtText, Me)
'                    If bReturn = True Then
'                        EdtText = sCode
'                        EdtText.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcnamecolon") + sName '"分类名称："
'                    End If
'                Case LCase("cVenCode"), LCase("Inventory.cVenCode") '主要供货单位 ,
'                    Call GetRef(CmdAll.Tag, sCode, sName, bReturn, EdtText, Me)
'                    If bReturn = True Then
'                        EdtText = sCode
'                        EdtText.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cvennamecolon") + sName '"供货单位名称："
'                    End If
'                Case LCase("cDefWareHouse"), LCase("Inventory.cDefWareHouse")
'                    Call GetRef(CmdAll.Tag, sCode, sName, bReturn, EdtText, Me)
'                    If bReturn = True Then
'                        EdtText = sCode
'                        EdtText.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cwhnamecolon") + sName '"默认仓库名称："
'                    End If
'                Case LCase("cPosition"), LCase("Inventory.cPosition") '货位编码,
'                    Call GetRef(CmdAll.Tag, sCode, sName, bReturn, EdtText, Me)
'                    If bReturn = True Then
'                        EdtText = sCode
'                        EdtText.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cposnamecolon") + sName ' "货位名称："
'                    End If
'                Case LCase("Inventory.cGroupCode"), LCase("CUnitGroupCode"), LCase("cWGroupCode"), LCase("cVGroupCode"), LCase("Inventory.cWGroupCode"), LCase("Inventory.cVGroupCode")
'                    Call GetRef(CmdAll.Tag, sCode, sName, bReturn, EdtText, Me)
'                    If bReturn = True Then
'                        EdtText = sCode
'                        EdtText.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cgroupnamecolon") + sName '"组名称："
'                    End If
'                'Case LCase("cEnterprise") '生产企业
'                'LCase ("CUnitGroupCode"), LCase("cComunitCode"), '                'LCase("cPUComunitCode"), LCase("cSAComunitCode"), LCase("cSTComunitCode"), LCase("cCAComunitCode")
'                '计量单位组,主计量单位编码,
'                '采购默认计量单位编码,销售默认计量单位编码,库存默认计量单位编码,成本默认计量单位编码
'                Case LCase("cInvPersonCode"), LCase("cPurPersonCode"), LCase("cInvDepCode"), LCase("cInvPlanCode"), LCase("Inventory.cInvPersonCode"), LCase("Inventory.cPurPersonCode"), LCase("Inventory.cInvDepCode"), LCase("Inventory.cInvPlanCode")
'                    Call GetRef(CmdAll.Tag, sCode, sName, bReturn, EdtText, Me)
'                    If bReturn = True Then
'                        EdtText = sCode
'                        EdtText.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.namecolon") + sName '"名称："
'                    End If
'                Case LCase("cInvDefine1"), LCase("cInvDefine2"), LCase("cInvDefine3"), LCase("cInvDefine4"), LCase("cInvDefine5"), LCase("cInvDefine6"), LCase("cInvDefine7"), '                     LCase("cInvDefine8"), LCase("cInvDefine9"), LCase("cInvDefine10"), LCase("cInvDefine11"), LCase("cInvDefine12"), LCase("cInvDefine13"), LCase("cInvDefine14") '                     , LCase("cInvDefine15"), LCase("cInvDefine16")
'                    Call GetRef(CmdAll.Tag, sCode, sName, bReturn, EdtText, Me)
'                    If bReturn = True Then
'                        Call g_oPub.EdtSetVal(sCode, EdtText)
'                    End If
'                Case LCase("date")
'                    Cal.Left = EdtText.Left
'                    Cal.Top = EdtText.Top + EdtText.Height + 100
'                    If Cal.Top + Cal.Height + 1000 > Me.Height Then
'                        Cal.Top = EdtText.Top - Cal.Height
'                    End If
'                    Cal.DateDivideChar = "-"
'                    EdtText.Text = Cal.Calendar(Me.hWnd)
'            End Select
'            Exit For
'        End If
'    Next i
'End Sub


'Private Sub GetBit(ByVal sField As String, ByRef var As String)
'    Dim i As Integer
'    Select Case LCase(sField)
'        Case LCase("IRecipeBatch"), LCase("Inventory.IRecipeBatch")
'            var = CStr(CmbText.ListIndex)
'        Case LCase("iROPMethod"), LCase("Inventory.iROPMethod")
'            Select Case var
'                Case iROPMethodItems(1)
'                    var = "1"
'                Case iROPMethodItems(2)
'                    var = "2"
'                Case Else
'                    var = ""
'            End Select
'        Case LCase("iBatchRule"), LCase("Inventory.iBatchRule")
'            Select Case var
'                Case iBatchRuleItems(1)
'                    var = "1"
'                Case iBatchRuleItems(2)
'                    var = "2"
'                Case iBatchRuleItems(3)
'                    var = "3"
'                Case iBatchRuleItems(4)
'                    var = "4"
'                Case iBatchRuleItems(5)
'                    var = "5"
'                Case Else
'                    var = ""
'            End Select
'        Case LCase("iSupplyType"), LCase("Inventory.iSupplyType")
'            Select Case var
'                Case iSupplyTypeItems(1)
'                    var = "1"
'                Case iSupplyTypeItems(2)
'                    var = "2"
'                Case iSupplyTypeItems(3)
'                    var = "3"
'                Case Else
'                    var = "0"
'            End Select
'        Case "cvaluetype", "inventory.cvaluetype"
'            For i = LBound(cValueTypeItems) To UBound(cValueTypeItems)
'                If CmbText.Text = cValueTypeItems(i) Then
'                    var = cValueTypeDB(i)
'                    Exit For
'                End If
'            Next i
'        Case Else
'            If CmbText.ListCount = 2 Then
'                If CmbText.Text = boolItems(1) Then
'                    var = "1"
'                ElseIf CmbText.Text = boolItems(0) Then
'                    var = "0"
'                End If
'            End If
'            '其它不作任何处理
'    End Select
'End Sub

'---------------------------------------
'功能：检查是否修改的合法性
'参数：对应编码
'返回：true：可以批量修改，false：不可以批量修改
'---------------------------------------
Private Function CheckValid(FillCon As Object, ByRef sCon As String, chFld As String, dbFld As String, ByRef fldVal As String, ByRef modifyOtherFlds As String) As Boolean
    Dim Rs As New ADODB.Recordset
    Dim i As Integer
    Dim strSql As String
    
    Select Case LCase(dbFld)
        Case LCase("cInvCCode"), LCase("Inventory.cInvCCode") '存货大类编码,
            If fldVal = "" Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cinvccode_notnull") '"存货所属分类码不可为空！"
                Exit Function
            End If
           If fldVal <> "" Then
                strSql = "select top 1  cInvCCode from InventoryClass where bInvCEnd=1 and cInvCCode='" + fldVal + "'"
                Set Rs = SrvDB.OpenX(strSql)
                If Rs.RecordCount = 0 Then
                    ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_cinvccode_end") '"存货所属分类码不存在！"
                    Exit Function
                End If
                If g_oPub.IsClsAuthW(SrvDB, g_rowAuth, "Inventory", fldVal, chFld, True) = False Then Exit Function
            End If
        Case LCase("cVenCode"), LCase("Inventory.cVenCode")  '主要供货单位 ,
            If fldVal <> "" Then '为空不作检查
                strSql = "select top 1 CVenCode from  Vendor where  CVenCode= '" + fldVal + "' and " + g_sRowAuthVen
                Set Rs = SrvDB.OpenX(strSql)
                If Rs.RecordCount = 0 Then
                    ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_cvencode") '"供应商编码不存在！"
                    Exit Function
                End If
            End If
        Case LCase("cDefWareHouse"), LCase("Inventory.cDefWareHouse")
            If fldVal <> "" Then '为空不作检查
                strSql = "select top 1 cWhCode,bBondedWh,bWhAsset from  Warehouse where  cWhCode= '" + fldVal + "' and " + g_sRowAuthWare
                Set Rs = SrvDB.OpenX(strSql)
                If Rs.RecordCount = 0 Then
                    ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_cwhcode") '"默认仓库编码不存在！"
                    Exit Function
                Else
                    '如果该存货的“是否保税品”=“否”，则它对应的默认仓库也必须是非保税仓，即：该仓库的“是否保税仓”=“否”。
                    If Rs.Fields("bBondedWh").Value = True Then
                        sCon = sCon + "and (bBondedInv=1)"
                    End If
                    '“资产”存货，默认仓库只能录入和参照仓库档案中的资产仓;非“资产”存货，默认仓库只能录入和参照仓库档案中的非资产仓。
                    If Rs.Fields("bWhAsset").Value = True Then
                        sCon = sCon + " and bInvAsset=1"
                    Else
                        sCon = sCon + " and bInvAsset=0"
                    End If
                End If
            End If
        Case LCase("cPosition"), LCase("Inventory.cPosition")  '货位编码,
            If fldVal <> "" Then '为空不作检查
                strSql = "select top 1 cPosCode from Position where bPosEnd=1 and cPosCode = '" + fldVal + "' and " + g_sRowAuthPos
                Set Rs = SrvDB.OpenX(strSql)
                If Rs.RecordCount = 0 Then
                    ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_cposcode_end") '"货位编码不存在！"
                    Exit Function
                End If
            End If
        Case LCase("cInvPersonCode"), LCase("cPurPersonCode"), LCase("Inventory.cInvPersonCode"), LCase("Inventory.cPurPersonCode")
            If g_oPub.IFExists(SrvDB, "person", chFld, fldVal, False, "", g_sRowAuthPerson) = False Then Exit Function
        Case "cciqcode", "inventory.cciqcode"
            If g_oPub.IFExists(SrvDB, "ex_ciqarchive", chFld, fldVal, False, "", "") = False Then Exit Function
        Case "iinvatpid", "inventory.iinvatpid"
            If g_oPub.IFExists(SrvDB, "v_mps_atp", chFld, fldVal, False, "", "") = False Then Exit Function
            If Len(fldVal) > 0 Then
                sCon = sCon + "and iCheckATP=1 "
            End If
        Case LCase("cInvDepCode"), LCase("Inventory.cInvDepCode")
            If g_oPub.IFExists(SrvDB, "department", chFld, fldVal, False, "", g_sRowAuthDept) = False Then Exit Function
        Case LCase("cInvPlanCode"), LCase("Inventory.cInvPlanCode")
            If g_oPub.IFExists(SrvDB, "inventory", chFld, fldVal, False, "", g_sRowAuthInvW) = False Then Exit Function
        'Case LCase("cEnterprise") '生产企业
        Case LCase("Inventory.cBarCode")
            sCon = sCon + " and Inventory.bBarCode=1 and Inventory.cInvCode not in (select cBarCode from Inventory where not (" + sCon + "  or Inventory.cBarCode is null ))"
        Case LCase("dSdate"), LCase("Inventory.dSdate")
            sCon = sCon + "and ((dEdate is null )or(dEdate>='" + fldVal + "'))"
        Case LCase("dEdate"), LCase("Inventory.dEdate")
            If fldVal <> "" Then
'                If g_oPub.CheckDateStyle(EdtText, chFld) = False Then
'                    Exit Function
'                End If
                sCon = sCon + "and (dSdate<='" + fldVal + "')"
            End If
        Case LCase("iTopSum"), LCase("Inventory.iTopSum")
            sCon = sCon + "and (Inventory.iLowSum<=" + fldVal + " or Inventory.iLowSum is null) and (Inventory.iSafeNum<=" + fldVal + " or Inventory.iSafeNum is null)"
        Case LCase("iLowSum"), LCase("Inventory.iLowSum")
            sCon = sCon + "and (Inventory.iTopSum>=" + fldVal + " or Inventory.iTopSum is null) and (Inventory.iSafeNum>=" + fldVal + " or Inventory.iSafeNum is null)"
        Case LCase("iSafeNum"), LCase("Inventory.iSafeNum")
            sCon = sCon + "and (Inventory.iTopSum>=" + fldVal + " or Inventory.iTopSum is null) and (Inventory.iLowSum<=" + fldVal + " or Inventory.iLowSum is null)"
        '变更日期,上次盘点日期
        Case LCase("DModifyDate"), LCase("dLastDate"), LCase("Inventory.DModifyDate"), LCase("Inventory.dLastDate")
            If fldVal <> "" Then
'                If g_oPub.CheckDateStyle(EdtText, chFld) = False Then
'                    Exit Function
'                End If
            End If
        Case LCase("cInvDefine1"), LCase("cInvDefine2"), LCase("cInvDefine3"), LCase("cInvDefine4"), LCase("cInvDefine5"), LCase("cInvDefine6"), LCase("cInvDefine7"), _
             LCase("cInvDefine8"), LCase("cInvDefine9"), LCase("cInvDefine10"), LCase("cInvDefine11"), LCase("cInvDefine12"), LCase("cInvDefine13"), LCase("cInvDefine14") _
             , LCase("cInvDefine15"), LCase("cInvDefine16")
            If g_oPub.CheckUserDef(Me, FillCon, g_oPub.GetResString("U8.AA.INVENTORY.FRMMULMODIFY.344_1"), Mid(dbFld, 11, 2), chFld, SrvDB) = False Then 'U8.AA.INVENTORY.FRMMULMODIFY.344_1="存货"
                Exit Function
            End If
            If LCase(dbFld) = LCase("cInvDefine15") Or LCase(dbFld) = LCase("cInvDefine16") Then
'                If g_oPub.CheckDateStyle(EdtText, chFld) = False Then
'                    Exit Function
'                End If
            End If
        Case LCase("bInvType"), LCase("Inventory.bInvType") '是否折扣
            'If CmbText.Text = boolItems(1) Then
            If fldVal = 1 Then
                sCon = sCon + "and (bComsume=0 and bSelf=0 and bProducing=0)"
            End If
        Case LCase("bPlanInv"), LCase("Inventory.bPlanInv") '是否计划品
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bSale=0 and bPurchase=0 and bComsume=0 and bProxyForeign=0 and bSelf=0 and bProducing=0 and bService=0 and bATOModel=0 and bCheckItem=0 and bPTOModel=0)"
            End If
        Case LCase("bProxyForeign"), LCase("Inventory.bProxyForeign")
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bPlanInv=0 and bCheckItem=0 and bPTOModel=0 and bATOModel=0)"
            End If
        Case LCase("bATOModel"), LCase("Inventory.bATOModel")
            '批改ATO规则 20090928
        '由于自制属性与折扣属性互斥
        '所以批改ATO属性时，先检查存货“折扣”属性是否已经被选中，如果已经被选中，
        '则无法修改（即无法找到合适的存货），如果折扣属性没有被选中，则批改ATO属性时，
        '自制属性同时被修改为是。
            
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bPurchase =0 and bProxyForeign =0 and bProducing =0 and bService =0 and bCheckItem =0 and bPlanInv =0 and bPTOModel =0  and bInvType=0 ) "
            End If
        Case LCase("bPTOModel"), LCase("Inventory.bPTOModel")
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bInvModel=1) and ( bSale =0 and bPurchase =0 and bComsume =0 and bProxyForeign =0 and bSelf =0 and bProducing =0 and bService =0 and bATOModel =0 and bCheckItem =0 and bPlanInv =0)"
            Else
                sCon = sCon + "and (bInvModel=0)"
            End If
        Case LCase("bInvModel"), LCase("Inventory.bInvModel")
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bPTOModel = 1 or bATOModel=1)"
            End If
        Case LCase("bROP"), LCase("Inventory.bROP")
            If fldVal = 1 Then
                modifyOtherFlds = "iROPMethod=1,cPlanMethod=N'N',fSubscribePoint=0, "
                sCon = sCon + "and (bROP=0)"
            Else
                modifyOtherFlds = "iROPMethod=NULL,fSubscribePoint=NULL,iBatchRule=NULL,"
                sCon = sCon + "and (bROP=1)"
            End If
        Case LCase("bCheckItem"), LCase("Inventory.bCheckItem")
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bSale =0 Or bPurchase =0 Or bComsume =0 Or bProxyForeign =0 Or bSelf =0 Or bProducing =0 Or bService =0 Or bATOModel =0 Or bPlanInv =0 Or bPTOModel =0)"
            End If
        Case LCase("bEquipment"), LCase("Inventory.bEquipment")
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bService = 0 and bPlanInv = 0 and bPTOModel = 0 and bCheckItem = 0)"
            End If
        Case LCase("bSale"), LCase("Inventory.bSale") '是否销售
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bPlanInv=0 and bCheckItem=0 and bPTOModel=0)"
            End If
        Case LCase("bPurchase"), LCase("Inventory.bPurchase") '是否外购
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bPlanInv=0 and bCheckItem=0 and bPTOModel=0 and bATOModel=0)"
            End If
        Case LCase("bSelf"), LCase("Inventory.bSelf") '是否自制
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + " and (bService=0 and bInvType=0 and bPlanInv=0 and bCheckItem=0 and bPTOModel=0 )"
                modifyOtherFlds = "bProductBill = 1,bBOMMain = 1,bBOMSub = 1,"
            Else
                sCon = sCon + " and (bRePlan=0)"
            End If
        Case LCase("bComsume"), LCase("Inventory.bComsume") '是否生产耗用
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bPlanInv=0 and bCheckItem=0 and bPTOModel=0 and bService=0 and bInvType=0 and bATOModel=0)"
            End If
        Case LCase("bProducing"), LCase("Inventory.bProducing") '是否在制
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bPlanInv=0 and bCheckItem=0 and bPTOModel=0 and bService=0 and bInvType=0)"
            End If
        Case LCase("bService"), LCase("Inventory.bService") '是否应税劳务
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + "and (bComsume=0 and bSelf=0 and bProducing=0 and bPlanInv=0 and bCheckItem=0 and bPTOModel=0 and bATOModel=0 and bEquipment=0)"
            End If
        Case LCase("bForeExpland"), LCase("Invenotry.bForeExpland")
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + " and (bPTOModel=1 or bCheckItem=1) "
            Else
                sCon = sCon + "and (bPTOModel=0 and  bCheckItem=0)"
            End If
        Case LCase("bRePlan"), LCase("Inventory.bRePlan")
            If fldVal = 1 Then 'If CmbText.Text = boolItems(1) Then
                sCon = sCon + " and (bSelf=1 and bATOModel=0) "
            End If
        Case LCase("iROPMethod"), LCase("Inventory.iROPMethod")
            sCon = sCon + " and bROP=1 "
        Case LCase("iBatchRule"), LCase("Inventory.iBatchRule")
            sCon = sCon + " and bROP=1 " '其他与EdtiAssureProvideDays，EdtfVagQuantity相关不作控制
        Case LCase("iAssureProvideDays"), LCase("Inventory.iAssureProvideDays")
            sCon = sCon + " and (bROP=1 and iBatchRule=5) "
        Case LCase("fVagQuantity"), LCase("Inventory.fVagQuantity")
            sCon = sCon + " and (bROP=1 and ((iBatchRule=5 and iROPMethod=1)or iROPMethod=2)) "
        Case LCase("cPlanMethod"), LCase("Inventory.cPlanMethod")
            If fldVal = "R" Then
                sCon = sCon + "and (bROP=0 and bInvAsset=0) "
            Else
                If fldVal = "" Then fldVal = "R"
            End If
        '890sp增加销售跟单
        Case LCase("bTrackSaleBill"), LCase("Inventory.bTrackSaleBill")
            If bTrackSaleBill = True Then
                If fldVal = "1" Then
                     sCon = sCon + "and cSRPolicy = 'PE'"
                End If
            End If
        Case "csrpolicy", "inventory.csrpolicy"
            If UCase(fldVal) = "LP" Then
            '890sp增加销售跟单
                If bTrackSaleBill Then
                    sCon = sCon + "and bTrackSaleBill = 1 "
                Else
                    sCon = sCon '+ "and bTrackSaleBill = 1 "
                End If
            ElseIf UCase(fldVal) = "PE" Then
                sCon = sCon + " and (bATOModel=0 or bInvModel=0) "
            End If
        Case LCase("iSupplyType"), LCase("Inventory.iSupplyType")
            If fldVal = "" Then
                fldVal = "0"
            End If
        Case "binvbatch", "inventory.binvbatch"
            If fldVal = "0" Then
                'U8.AA.ARCHIVE.COMMON.binvbatch_update_alarm=注意：对于已发生业务的存货，从批次管理改为非批次管理后，将不能再从非批次管理改为批管理！\n请确认是否修改？
                If g_oPub.MsgBox(g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.binvbatch_update_alarm"), vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbNo Then
                    Exit Function
                End If
            End If
        Case "binvasset" '资产
            If fldVal = "1" Then
                sCon = sCon + " and (cPlanMethod = 'N' and bInvEntrust=0 and bPUQuota =0 and binvasset=0  and (isnull(cDefWareHouse,'')='' or cDefWareHouse in(select top 1 cWhCode from warehouse where cwhcode=cDefWareHouse and bWhAsset=1)) )"
            Else
                sCon = sCon + " and  binvasset=1 and  (isnull(cDefWareHouse,'')='' or cDefWareHouse in(select top 1 cWhCode from warehouse where cwhcode=cDefWareHouse and bWhAsset=0))"
            End If
        Case "bpuquota" '参与配额
            If fldVal = "1" Then
                sCon = sCon + " and ( bPUQuota =0 and binvasset=0)"
            Else
                sCon = sCon + " and  bpuquota=1 "
            End If
        Case "irequiretrackstyle" '需求跟踪方式
            '①PE件该项为空值，不可修改；②LP件默认为订单行号，对于非ATO物料可以修改为订单号或需求分类代号，对于ATO物料则不可以修改。
             sCon = sCon + "and (bATOModel=0 and csrpolicy='LP') "
        Case "bpropertycheck", "inventory.bpropertycheck" '是否质检
            If fldVal = "1" Then
                '质量页签默认设置：检验方式：全检；检验规则：按存货检验；检验剂量单位：主剂量单位
                modifyOtherFlds = "iTestStyle=0,iTestRule=0,cDTUnit =cComUnitCode, "
                '"GSP质量管理启用时，浮动换算率组的'是否质检'不可选！"
                sCon = sCon + "and (bpropertycheck=0 " + IIf(g_bGSP = True, "and iGroupType<>2", "") + ") "
            Else
                '批改不选择质检，则"检验周期"同时被取消，"保质期存货校验"自动被取消
                modifyOtherFlds = "bPeriodDT=0,bDTWarnInv=0,iTestStyle=NULL,iTestRule=NULL,cDTUnit =NULL, "
                sCon = sCon + "and (bpropertycheck=1) "
            End If
    End Select

    
    CheckValid = True
End Function


'Private Sub EdtText_KeyDown(KeyCode As Integer, Shift As Integer)
'    If KeyCode = vbKeyF2 And CmdAll.Visible = True Then
'        CmdAll_Click
'    End If
'End Sub

Private Sub EdtText_KeyPress(KeyAscii As Integer)
'    '计划价或售价,参考成本,参考售价
'    '最低售价,最新成本,零售单价
'    '最高售价,最高进价
''    Case LCase("iInvRCost"), LCase("iInvSPrice"), LCase("iInvSCost") _
''        , LCase("iInvLSCost"), LCase("iInvNCost"), LCase("iInvSaleCost") _
''        , LCase("iHighPrice"), LCase("iInvMPCost"), LCase("Inventory.iHighPrice")
'    Dim sTemp As String
'    sTemp = Right(Me.CmbItem.Text, 1)
'    If sTemp = "本" Or sTemp = "价" Then
'        If Asc("-") = KeyAscii Then
'            KeyAscii = 0
'        End If
'    End If
'
'    '保质期预警天数,保质期,盘点周期
'    '盘点日,,固定提前期
''    Case LCase("iWarnDays"), LCase("iMassDate"), LCase("iFrequency") _
''        , LCase("iDays"), LCase("IadvanceDate"), LCase("iInvAdvance") _
''        , LCase("Inventory.iWarnDays"), LCase("Inventory.iMassDate"), LCase("Inventory.iFrequency") _
''        , LCase("Inventory.iDays"), LCase("Inventory.IadvanceDate"), LCase("Inventory.iInvAdvance")
''        If EdtText <> "" And IsNumeric(EdtText.Text) Then
''            If CDbl(EdtText.Text) < 0 Then
''                ShowMsg "天数不可小于零！"
''                Exit Function
''            End If
''            If CDbl(EdtText.Text) <> CInt(EdtText.Text) Then
''                ShowMsg "天数不可为小数！"
''                EdtText.Text = CStr(CInt(EdtText.Text))
''                Exit Function
''            End If
''        End If
'    sTemp = Right(Me.CmbItem.Text, 2)
'    If sTemp = "天数" Or sTemp = "质期" Or sTemp = "周期" Or sTemp = "点日" Or sTemp = "前期" _
'        Or sTemp = "重量" Or sTemp = "体积" Or sTemp = "税率" _
'        Or sTemp = "库存" Then
'        If Asc("-") = KeyAscii Then
'            KeyAscii = 0
'        End If
'    End If
'    If EdtText.Property = EditDbl Or EdtText.Property = EditLng Then
'        If Asc("-") = KeyAscii Then
'            KeyAscii = 0
'        End If
'    End If
End Sub



'-----------------------------------------------------------
'功能：强制修改其他表
'-----------------------------------------------------------
Private Sub ModifyOtherData(ByVal fldName As String, sCondition As String)
    fldName = LCase(fldName)
    Dim arr() As String
    Dim strSql As String
    Dim bFlag As Boolean
    arr = Split(fldName, ".")
    Select Case LCase(arr(UBound(arr)))
        Case LCase("iSafeNum")
            strSql = "update bas_part set SafeQty=iSafeNum from bas_part left outer join  inventory on  invcode=cInvCode where bVirtual=1 and " + sCondition
            bFlag = SrvDB.ExecuteX(strSql)
        Case LCase("fMinSupply")
            strSql = "update bas_part set MinQty=fMinSupply from bas_part left outer join  inventory on  invcode=cInvCode where bVirtual=1 and " + sCondition
            bFlag = SrvDB.ExecuteX(strSql)
        Case LCase("fSupplyMulti")
            strSql = "update bas_part set Mulqty=fSupplyMulti from bas_part left outer join  inventory on  invcode=cInvCode where bVirtual=1 and " + sCondition
            bFlag = SrvDB.ExecuteX(strSql)
        Case LCase("iInvBatch")
            strSql = "update bas_part set FixQty=iInvBatch from bas_part left outer join  inventory on  invcode=cInvCode where bVirtual=1 and " + sCondition
            bFlag = SrvDB.ExecuteX(strSql)
        Case LCase("cengineerfigno")
            strSql = "update bas_part set cBasEngineerFigNo=cEngineerFigNo from bas_part left outer join  inventory on  invcode=cInvCode where bVirtual=1 and " + sCondition
            bFlag = SrvDB.ExecuteX(strSql)
        Case Else
    End Select
End Sub

'-------------------------------------------------
'功能：修改涉及存储过程
'参数：
'       sField:     修改字段名称
'       sCon:       选择条件
'返回：修改过true；没有修改：false
'-------------------------------------------------
Private Function HaveModifyProc(ByVal dbFld As String, ByVal sCon As String, ByVal Rs As ADODB.Recordset, fldVal As String) As Boolean
    HaveModifyProc = False
    Dim sMsg As String
    Dim sXML As String
    Dim sTemp As String
    Dim strSql As String
    Dim sCode As String
    Dim iSuccessCount As Long
    Dim i As Long
    Dim tFieldName As String
    Dim var As String
    Dim Pos As Integer
    Dim UpdateFlds As String
    Pos = InStr(1, dbFld, ".")
    If Pos <> 0 Then
        tFieldName = Right(dbFld, Len(dbFld) - Pos)
    Else
        tFieldName = dbFld
    End If
    Select Case LCase(tFieldName)
        Case LCase("bFree1"), LCase("bFree2"), LCase("bFree3"), LCase("bFree4"), LCase("bFree5") _
             , LCase("bFree6"), LCase("bFree7"), LCase("bFree8"), LCase("bFree9"), LCase("bFree10") _
             , LCase("bInvQuality"), LCase("BInvBatch"), LCase("BSerial"), LCase("BTrack") _
             , LCase("IInvRCost"), LCase("cInvCCode"), "cvaluetype", LCase("cSRPolicy"), "binvasset", LCase("bATOModel")
            ReDim g_arr(1 To 1)
            g_arr(1) = CStr(Rs.RecordCount)
            If g_oPub.MsgBox(g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMMULMODIFY.560_1", g_arr), vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbNo Then 'U8.AA.INVENTORY.FRMMULMODIFY.560_1="本次可能成批修改 {0} 条记录，\n请确信是否按选择的条件进行修改！"
                HaveModifyProc = True
                Exit Function
            End If
            sXML = "<Inventory Operating ='MultiModify' ModifyItem='" + tFieldName + "'>"
            iSuccessCount = 0
            Dim RstErrMsg As ADODB.Recordset
            Dim ShowFlds As String
            Dim arr(0 To 1) As String
            ShowFlds = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode") + "," + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.PUB.modifyfailreason") '"存货编码,修改失败原因"
            Call g_oPub.ModifyInitMsg(RstErrMsg, "cInvCode,cErrMsg", ShowFlds)
            Rs.MoveFirst
            For i = 0 To Rs.RecordCount - 1
                sCode = TxtValue(Rs!cinvcode)
                sTemp = "<cInvCode>" + sCode + "</cInvCode>"
                Select Case LCase(tFieldName)
                    Case LCase("IInvRCost"), LCase("cInvCCode")
                        var = fldVal 'EdtText.Text
                    Case LCase("cSRPolicy")
                        If fldVal = "" Then fldVal = "PE"
                        var = fldVal
                        If UCase(fldVal) = "LP" Then
                            UpdateFlds = "bSpecialOrder=1,"
                        Else
                            UpdateFlds = "bSpecialOrder=0,"
                        End If
                    Case LCase("bATOModel")
                        '批改ATO规则
                        '由于自制属性与折扣属性互斥
                        '所以批改ATO属性时，先检查存货“折扣”属性是否已经被选中，
                        '如果已经被选中，则无法修改（即无法找到合适的存货），
                        '如果折扣属性没有被选中，则批改ATO属性时，自制属性同时被修改为是。
                        If fldVal = "1" Then
                            UpdateFlds = "bSelf=1,"
                        End If
                        var = fldVal
                    Case Else
                        var = fldVal 'Call GetBit(tFieldName, var)
                End Select
'                If LCase(tFieldName) = LCase("IInvRCost") Then
'                    var = EdtText.Text
'                Else
'                    Call GetBit(tFieldName, var)
'                End If
                sTemp = sTemp + "<" + tFieldName + ">" + var + "</" + tFieldName + ">"
                Call g_oPub.LogArch(SrvDB, "Inventory", 4, sCode, g_cUserId, "0", Find.ShowCondition, "cInvCode=N'" + sCode + "'")
                If SrvDB.Modify(sXML + sTemp + "</Inventory>", "Inventory", sMsg) = False Then
                    arr(0) = sCode
                    arr(1) = sMsg
                    Call g_oPub.ModifyAddMsg(RstErrMsg, arr)
                Else
                    var = IIf(Trim(var) = "", "NULL", "'" + var + "'") '不可置上’因XML不好解释
                    If IsInventorySubFld(dbFld) = True Then
                        strSql = "update Inventory_Sub set  " + dbFld + "=" + var + " where cInvSubCode ='" + sCode + "'"
                        strSql = strSql + vbCrLf + "update Inventory set cModifyPerson='" + g_cUserName + "' ,DModifyDate=getdate() from  Inventory left join Inventory_sub on cinvcode=cInvSubCode where cInvCode='" + sCode + "' "
                    Else
                        strSql = " Update Inventory set Inventory.cModifyPerson='" + g_cUserName + "' ,Inventory.DModifyDate=getdate(), " + UpdateFlds + dbFld + "=" + var + "  where cInvCode='" + sCode + "' "
                    End If
                    
                    If SrvDB.ExecuteX(strSql) = True Then
                        iSuccessCount = iSuccessCount + 1
                    Else '不作处理
                    End If
                    Call g_oPub.LogArch(SrvDB, "Inventory", 4, sCode, g_cUserId, "1", Find.ShowCondition, "cInvCode=N'" + sCode + "'")
                    Call g_oPub.TransU8APIForMulModify(SrvDB, "Inventory", True, dbFld, fldVal, "cInvCode=N'" + sCode + "'", g_bIsWeb)
                    Call g_oPub.TransU8APIForMulModify(SrvDB, "Inventory", False, dbFld, fldVal, "cInvCode=N'" + sCode + "'", g_bIsWeb)
                End If
                Rs.MoveNext
            Next i
            g_bSaved = True
            If iSuccessCount = 0 Then
                ReDim g_arr(1 To 1)
                g_arr(1) = fldVal 'CmbItem.Text
                ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMMULMODIFY.597_1", g_arr) 'U8.AA.INVENTORY.FRMMULMODIFY.597_1="因符合条件的存货全部被引用，不可修改【{0}】内容！"
                Call g_oPub.ModifyShowMsg(Me, g_oLogin, SrvDB, RstErrMsg)
                g_bSaved = False
            ElseIf iSuccessCount = Rs.RecordCount Then
                ReDim g_arr(1 To 1)
                g_arr(1) = CStr(iSuccessCount)
                ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMMULMODIFY.602_1", g_arr) 'U8.AA.INVENTORY.FRMMULMODIFY.602_1="成功修改 {0} 条记录！"
            Else
                ReDim g_arr(1 To 2)
                g_arr(1) = CStr(iSuccessCount)
                g_arr(2) = CStr(Rs.RecordCount - iSuccessCount)
                sMsg = g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMMULMODIFY.607_1", g_arr) 'U8.AA.INVENTORY.FRMMULMODIFY.607_1="成功修改 {0} 条记录！\n其它存货(共 {1} 条)因被引用，不可修改！"
                ShowMsg sMsg
                Call g_oPub.ModifyShowMsg(Me, g_oLogin, SrvDB, RstErrMsg)
            End If
        Case Else
            Exit Function
    End Select
    HaveModifyProc = True
End Function

Private Sub Find_ModifyClickNew(FillCon As Object, ByVal sCon As String, chFld As String, dbFld As String, fldVal As String)
    'If g_oPub.CheckDateStyleByEdit(EdtText, CmbItem.Text) = False Then Exit Sub
    Dim Rs As ADODB.Recordset
    Dim str As String
'    Dim sField As String
    Dim var As String
    Dim i As Integer
    If sCon = "(1=1)" Then
        'ShowMsg "没有选择条件，不可修改！"
        'Exit Sub
    End If
    
'    For i = 0 To CmbItem.ListCount - 1
'        If CmbItem.Text = CmbItem.List(i) Then Exit For
'    Next i
'    If i = CmbItem.ListCount Then
'        ShowMsg g_oPub.getResstring("U8.AA.INVENTORY.FRMMULMODIFY.455_1") 'U8.AA.INVENTORY.FRMMULMODIFY.455_1="在修改项目中输入的内容必须是下拉列表框中的内容！"
'        Exit Sub
'    End If
    
'    For i = 0 To UBound(ArrCHField)
'        If CmbItem.Text = ArrCHField(i) And CmbItem <> "" Then Exit For
'    Next i
'    If (Trim(CmbItem.Text) <> "") And (i <= UBound(ArrCHField)) Then
'        sField = ArrField(i) '获得需要修改的字段名
'    End If
'    If sField = "" Then
'        ShowMsg g_oPub.getResstring("U8.AA.INVENTORY.FRMMULMODIFY.466_1") 'U8.AA.INVENTORY.FRMMULMODIFY.466_1="没有获得修改的字段名，不可修改！"
'        Exit Sub
'    End If
    Dim sCode As String '对应各种编码
    Dim sTemp As String '临时字符串
    Dim modifyOtherFlds As String
    On Error GoTo Err_Info
    If CheckValid(FillCon, sCon, chFld, dbFld, fldVal, modifyOtherFlds) = False Then Exit Sub
    
    str = "select cInvCode from   Inventory left join Inventory_sub on cinvcode=cInvSubCode  where " + sCon + " and " + g_sRowAuthInvW
    If LCase(Left(dbFld, 5)) = "bfree" Then
        'If CmbText.Text = boolItems(0) Then
        If fldVal = 0 Then
            '存货选定使用的自由项才可已选择是否是结构性自由项
            str = str + " and bConfigFree" + Mid(dbFld, 6, 2) + "=0"
	'问题号：201206140096  关于自由项批改
 	    str = str + " and bcheckFree" + Mid(dbFld, 6, 2) + "=0"

        End If
    End If
    Set Rs = SrvDB.OpenX(str)
    If Rs Is Nothing Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.conditionerror") 'U8.AA.ARCHIVE.COMMON.conditionerror="查询条件选择错误！"
        Exit Sub
    End If
    If (Rs.RecordCount) = 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMMULMODIFY.487_1") 'U8.AA.INVENTORY.FRMMULMODIFY.487_1="本次选择条件没有任何档案被修改，请重新选择条件！"
        Exit Sub
    End If
    If HaveModifyProc(dbFld, sCon, Rs, fldVal) = True Then Exit Sub
    ReDim g_arr(1 To 1)
    g_arr(1) = CStr(Rs.RecordCount)
    If g_oPub.MsgBox(g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMMULMODIFY.493_1", g_arr), vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbNo Then 'U8.AA.INVENTORY.FRMMULMODIFY.493_1="本次将成批修改 {0} 条记录,\n请确信是否按选择的条件进行修改！"
        Exit Sub
    Else
        
        Select Case LCase(dbFld)
            Case LCase("cBarCode"), LCase("Inventory.cBarCode")
                If fldVal <> "" Then
                    str = "update Inventory set cModifyPerson='" + g_cUserName + "' ,DModifyDate=getdate(), " + dbFld + "=cInvCode" + " from  Inventory left join Inventory_sub on cinvcode=cInvSubCode  where " + sCon + " and " + g_sRowAuthInvW
                Else
                    str = "update Inventory set cModifyPerson='" + g_cUserName + "' ,DModifyDate=getdate(), " + dbFld + "=NULL" + " from  Inventory left join Inventory_sub on cinvcode=cInvSubCode  where" + sCon + " and " + g_sRowAuthInvW
                End If
            Case Else
                If IsInventorySubFld(dbFld) = True Then
                    var = IIf(Trim(fldVal) = "", "NULL", "'" + fldVal + "'")
                    str = "update Inventory_Sub set  " + dbFld + "=" + var + " from  Inventory left join Inventory_sub on cinvcode=cInvSubCode where " + sCon + " and " + g_sRowAuthInvW
                    str = str + vbCrLf + "update Inventory set cModifyPerson='" + g_cUserName + "' ,DModifyDate=getdate() from  Inventory left join Inventory_sub on cinvcode=cInvSubCode where " + sCon + " and " + g_sRowAuthInvW
                Else
                    var = IIf(Trim(fldVal) = "", "NULL", "'" + fldVal + "'")
                    str = "update Inventory set " + modifyOtherFlds + " cModifyPerson='" + g_cUserName + "' ,DModifyDate=getdate(), " + dbFld + "=" + var + " from  Inventory left join Inventory_sub on cinvcode=cInvSubCode  where" + sCon + " and " + g_sRowAuthInvW
                End If
        End Select
        If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 7) = True Then
            Exit Sub
        End If
        Dim DbPatchSql As String
        DbPatchSql = sCon + " and " + g_sRowAuthInvW
        Call g_oPub.LogArch(SrvDB, "Inventory", 4, "", g_cUserId, "0", Find.ShowCondition, DbPatchSql)
        If SrvDB.ExecuteX(str) = False Then
            Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -7)
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMMULMODIFY.516_1") 'U8.AA.INVENTORY.FRMMULMODIFY.516_1="修改出现错误，请检查条件！"
        Else
            Call ModifyOtherData(dbFld, sCon)
            Call g_oPub.LogArch(SrvDB, "Inventory", 4, "", g_cUserId, "1", Find.ShowCondition, DbPatchSql)
            Call g_oPub.TransU8APIForMulModify(SrvDB, "Inventory", True, dbFld, fldVal, DbPatchSql, g_bIsWeb)
            Call g_oPub.TransU8APIForMulModify(SrvDB, "Inventory", False, dbFld, fldVal, DbPatchSql, g_bIsWeb)
            Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -7)
            ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.modifysuccess") '"修改成功！"
            g_bSaved = True
        End If
    End If
    Exit Sub
Err_Info:
    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMMULMODIFY.525_1") 'U8.AA.INVENTORY.FRMMULMODIFY.525_1="修改条件不正确或修改内容不合法！"
End Sub



'判断是否为Inventory_Sub字段
Private Function IsInventorySubFld(ByVal dbFld As String) As Boolean
    On Error GoTo Err_Info
    Dim arr() As String
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    arr = Split(dbFld, ".")
    strSql = "select top 1 * from syscolumns where id=(select top 1 id from sysobjects  where name='Inventory_Sub') and  name='" + arr(UBound(arr)) + "'"
    Set Rs = SrvDB.OpenX(strSql)
    If Rs.RecordCount = 1 Then
        IsInventorySubFld = True
    Else
        IsInventorySubFld = False
    End If
    Exit Function
Err_Info:
    
End Function



''---------------------------------------
''功能：实现控件的参照
''参数：sTag：选择何种参照
''       RetVal:返回值
''       Con:使用参照的控件
''---------------------------------------
'Private Sub Find_RefClick(ByVal sTag As String, RetVal As String, Con As Object)
'    Dim sCode As String, sName As String
'    Dim bReturn As Boolean
'    Call GetRef(sTag, sCode, sName, bReturn, Con, Me)
'    Select Case LCase(sTag)
'        Case LCase("cInvCode") '存货编码
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvnamecolon") + sName '"存货名称："
'            End If
'        Case LCase("cInvName") '存货名称
'            If bReturn = True Then
'                RetVal = sName
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcodecolon") + sCode '"存货编码："
'            End If
'        Case LCase("CVenCode"), LCase("Inventory.CVenCode")  '主要供货单位
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cvennamecolon") + sName '"供货单位名称："
'            End If
'        Case LCase("CEnterprise"), LCase("Inventory.CEnterprise") '生产企业名称和地址
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.INVENTORY.cvenaddresscolon") + sName '"生产企业地址："
'            End If
'        Case LCase("cDefWareHouse"), LCase("Inventory.cDefWareHouse")
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cwhnamecolon") + sName '"仓库名称："
'            End If
'        Case LCase("cInvCCode"), LCase("Inventory.cInvCCode") '所属分类码"''
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcnamecolon") + sName '"分类名称："
'            End If
'        Case LCase("cDCCode"), LCase("Inventory.cDCCode")  'Varchar    12          所属地区码
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cdcnamecolon") + sName ' "地区名称："
'            End If
'        Case LCase("cGroupCode"), LCase("cWGroupCode"), LCase("cVGroupCode"), LCase("Inventory.cGroupCode"), LCase("Inventory.cWGroupCode"), LCase("Inventory.cVGroupCode")
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cgroupnamecolon") + sName '"计量单位组名称："
'            End If
'        Case LCase("cInvDefine1"), LCase("cInvDefine2"), LCase("cInvDefine3"), LCase("cInvDefine4"), LCase("cInvDefine5"), LCase("cInvDefine6"), LCase("cInvDefine7"), _
'            LCase("cInvDefine8"), LCase("cInvDefine9"), LCase("cInvDefine10"), LCase("cInvDefine11"), LCase("cInvDefine12"), LCase("cInvDefine13"), LCase("cInvDefine14") _
'            , LCase("cInvDefine15"), LCase("cInvDefine16")
'            If bReturn = True Then
'                RetVal = sCode
'            End If
'        Case LCase("Inventory.cPosition"), LCase("cPosition")
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cposnamecolon") + sName '"货位名称："
'            End If
'        Case LCase("cInvPersonCode"), LCase("cPurPersonCode"), LCase("cInvDepCode"), LCase("cInvPlanCode"), LCase("Inventory.cInvPersonCode"), LCase("Inventory.cPurPersonCode"), LCase("Inventory.cInvDepCode"), LCase("Inventory.cInvPlanCode")
'            If bReturn = True Then
'                RetVal = sCode
'                Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.namecolon") + sName '"名称："
'            End If
'    End Select
'End Sub

Private Sub Find_UnLoad()
    Unload Me
End Sub

Private Sub Form_Activate()
    If m_bFirstLoad = True Then
        InitData
        m_bFirstLoad = False
    End If
End Sub

Private Sub Form_Resize()
    On Error Resume Next
    Find.Left = 0
    Find.Top = 0
    Me.Width = Find.Width + 10 * Screen.TwipsPerPixelX
    Me.Height = Find.Height + 34 * Screen.TwipsPerPixelY
End Sub

Private Sub UFFrmKeyHook_ContainerKeyDown(KeyCode As Integer, ByVal Shift As Integer)
    If KeyCode = vbKeyEscape Then
        Unload Me
    End If
End Sub

'---------------------------------------
'功能：窗体加载
'---------------------------------------
Private Sub Form_Load()
    'Call g_oPub.FormLayout(Me, "INVENTORY")
    Call g_oPub.FrmUniteFont(Me)
    '调用主窗体的总帮助
    Me.HelpContextID = FrmMain.HelpContextID
    m_bFirstLoad = True
    LoadRes
    ComInit
    'Me.EdtText.BadStr = g_oPub.BadStr
    Find.EOptType = OperationType.enuModifyNew
    Me.KeyPreview = False
End Sub
'---------------------------------------
'功能：装载资源
'---------------------------------------
Private Sub LoadRes()
    Me.Icon = Nothing ' LoadResPicture(101, vbResIcon)
    UFFrmCaptionMgr.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.mulmodify")
'    Me.CmbText.Visible = False
'    CmdAll.Visible = False
'    Me.FrameSelect.Caption = g_oPub.getResstring("U8.AAARCHIVE.COMMON.modifyselect")
'    Me.LblItem.Caption = g_oPub.getResstring("U8.AAARCHIVE.COMMON.modifyitem861")
'    Me.LblContent.Caption = g_oPub.getResstring("U8.AAARCHIVE.COMMON.modifycontent861")
End Sub

'---------------------------------------
'功能：ComBox,List控件初始化
'---------------------------------------
Private Sub ComInit()
    Exit Sub
'''    Dim i As Integer
'''    Me.CmbItem.Clear
'''    Dim j As Integer
'''    j = 0
'''    InitAccSet '随时更新帐套参数
''''    For i = 27 To UBound(ArrCHField)
''''        If ArrCHField(i) <> "" Then
''''        Me.CmbItem.AddItem ArrCHField(i), j
''''        j = j + 1
''''        End If
''''    Next i
'''    For i = 0 To UBound(ArrMCHField)
'''        If ArrMCHField(i) <> "" Then
'''            If GetWAuth(ArrMField(i), g_sWFldAuthInv) = True Then
'''                Me.CmbItem.AddItem ArrMCHField(i)
'''            End If
'''        End If
'''    Next i
''''    With Me.CmbItem
''''        If CS1 = False Then
''''            Call ReMoveItem(Me.CmbItem, "是否受托代销")
''''        End If
''''        If CS2 = False Then
''''            Call ReMoveItem(Me.CmbItem, "是否批次管理")
''''        End If
''''        If CS3 = False Then
''''            If g_bGSP = False Then
''''                Call ReMoveItem(Me.CmbItem, "是否保质期管理")
''''                Call ReMoveItem(Me.CmbItem, "保质期")
''''                Call ReMoveItem(Me.CmbItem, "预警天数")
''''            Else
''''                Call ReMoveItem(Me.CmbItem, "是否有效期管理")
''''                Call ReMoveItem(Me.CmbItem, "有效期")
''''                Call ReMoveItem(Me.CmbItem, "近效期")
''''            End If
''''        End If
''''        If CS4 = False Then
''''            Call ReMoveItem(Me.CmbItem, "是否成套件")
''''        End If
'''''        If CS5 = False Then
'''''            Call ReMoveItem(Me.CmbItem, "")
'''''        End If
''''    End With
'''    Me.CmbText.Clear
End Sub

'-----------------------------------------------------
'功能： 获取是否具有修改的字段权限
'参数： FldName：   英文字段名
'       WFldsAuth:  可编辑的字段权限
'-----------------------------------------------------
Private Function GetWAuth(ByVal fldName As String, ByVal WFldsAuth As String) As Boolean
    If WFldsAuth = "" Or WFldsAuth = "*" Then
        GetWAuth = True
    ElseIf InStr(1, WFldsAuth, LCase(Right(fldName, (Len(fldName) - InStr(1, fldName, "."))))) > 0 Then
        GetWAuth = True
    Else
        GetWAuth = False
    End If
End Function

Private Sub ReMoveItem(ByRef Cmb As UFCOMBOBOXLib.UFComboBox, ByVal ItemText As String)
    Dim i As Long
    For i = 0 To Cmb.ListCount - 1
        If LCase(Cmb.List(i)) = LCase(ItemText) Then
            Cmb.ReMoveItem i
        End If
    Next i
End Sub


'---------------------------------------
'功能：初始化空数据集，目的获得数据类型
'---------------------------------------
Private Sub InitData()
    Dim sMsg As String
    Dim strSql As String
    strSql = "select * from Inventory,inventory_Sub,InventoryClass,Vendor,Position,computationGroup,ComputationUnit,Warehouse where 1=2"
    Set RstType = SrvDB.OpenX(strSql)
    'If Find.Init(ArrField, ArrCHField, ArrRefField, RstType, sMsg, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.modify"), "(F8)") = False Then
    If Find.InitByXMLNew(g_oLogin, g_sXMLMulModify, RstType, sMsg, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.modify"), "(F8)") = False Then
        ShowMsg sMsg
        Unload Me
    End If
End Sub

'---------------------------------
'功能：对修改成功的记录刷新
'---------------------------------
Private Sub Form_Unload(Cancel As Integer)
    If g_bSaved = True Then
        g_bSaved = False
        Call FrmMain.Operating("Refresh")
    End If
    Call g_oPub.FrmUnLoad
End Sub


