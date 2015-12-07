VERSION 5.00
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Object = "{4C2F9AC0-6D40-468A-8389-518BB4F8C67D}#1.0#0"; "UFComboBox.ocx"
Object = "{A98B9C82-88D8-4F94-91BB-F2289111C59C}#1.0#0"; "UFCheckBox.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Object = "{5E4640D0-A415-404B-A457-72980C429D2F}#10.25#0"; "U8RefEdit.ocx"
Begin VB.UserControl InvMPS 
   ClientHeight    =   7320
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11295
   ScaleHeight     =   7320
   ScaleMode       =   0  'User
   ScaleWidth      =   11295
   Begin EDITLib.Edit EdtiPercentumSum 
      Height          =   285
      Left            =   7485
      TabIndex        =   37
      Top             =   6090
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliPercentumSum 
      Height          =   195
      Left            =   5970
      TabIndex        =   67
      Top             =   6135
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "百分比"
   End
   Begin EDITLib.Edit EdtiBestrowSum 
      Height          =   285
      Left            =   1755
      TabIndex        =   36
      Top             =   6105
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliBestrowSum 
      Height          =   195
      Left            =   300
      TabIndex        =   66
      Top             =   6120
      Width           =   1035
      _Version        =   65536
      _ExtentX        =   1826
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "覆盖天数"
   End
   Begin UFLABELLib.UFLabel LbliDynamicSurenessType 
      Height          =   195
      Left            =   5970
      TabIndex        =   65
      Top             =   5805
      Width           =   1455
      _Version        =   65536
      _ExtentX        =   2566
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "动态安全库存方法"
   End
   Begin EDITLib.Edit EdtiDateSum 
      Height          =   285
      Left            =   1755
      TabIndex        =   34
      Top             =   5775
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliDateSum 
      Height          =   195
      Left            =   300
      TabIndex        =   64
      Top             =   5790
      Width           =   1005
      _Version        =   65536
      _ExtentX        =   1773
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "期间数"
   End
   Begin UFLABELLib.UFLabel LbliDateType 
      Height          =   195
      Left            =   5970
      TabIndex        =   63
      Top             =   5475
      Width           =   1005
      _Version        =   65536
      _ExtentX        =   1773
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "期间类型"
   End
   Begin UFLABELLib.UFLabel LbliSurenessType 
      Height          =   195
      Left            =   300
      TabIndex        =   62
      Top             =   5460
      Width           =   1125
      _Version        =   65536
      _ExtentX        =   1984
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "安全库存方法"
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   10080
      Top             =   6660
      _ExtentX        =   1905
      _ExtentY        =   529
      ManualAttach    =   -1  'True
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbForeExpland 
      Height          =   195
      Left            =   5970
      TabIndex        =   5
      Top             =   810
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "预测展开"
      ForeColor       =   943208504
      ForeColor       =   943208504
      BorderStyle     =   11307
      ReadyState      =   943208504
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbcPlanMethod 
      Height          =   315
      Left            =   1755
      TabIndex        =   12
      Top             =   2100
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiSupplyType 
      Height          =   315
      Left            =   1755
      TabIndex        =   26
      Top             =   4425
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbRePlan 
      Height          =   195
      Left            =   5970
      TabIndex        =   3
      Top             =   480
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "是否重复计划"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbBillUnite 
      Height          =   195
      Left            =   300
      TabIndex        =   2
      Top             =   480
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "是否令单合并"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbcSRPolicy 
      Height          =   315
      Left            =   1755
      TabIndex        =   16
      Top             =   2775
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbMPS 
      Height          =   195
      Left            =   300
      TabIndex        =   4
      Top             =   810
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "MPS件"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbCutMantissa 
      Height          =   195
      Left            =   5970
      TabIndex        =   1
      Top             =   150
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "是否切除尾数"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbInTotalCost 
      Height          =   195
      Left            =   300
      TabIndex        =   0
      Top             =   150
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "成本相关"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin U8Ref.RefEdit EdtcInvDepCode 
      Height          =   285
      Left            =   1755
      TabIndex        =   10
      Top             =   1785
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxLength       =   8
      RefType         =   1
   End
   Begin U8Ref.RefEdit EdtcInvPersonCode 
      Height          =   285
      Left            =   7485
      TabIndex        =   11
      Top             =   1785
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxLength       =   8
      RefType         =   1
   End
   Begin U8Ref.RefEdit EdtiInvTfId 
      Height          =   285
      Left            =   7485
      TabIndex        =   13
      Top             =   2115
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxLength       =   8
      RefType         =   1
   End
   Begin EDITLib.Edit EdtcEngineerFigNo 
      Height          =   285
      Left            =   7485
      TabIndex        =   25
      Top             =   4065
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   1
      MaxLength       =   8
   End
   Begin EDITLib.Edit EdtiAlterAdvance 
      Height          =   285
      Left            =   1755
      TabIndex        =   24
      Top             =   4095
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtfAlterBaseNum 
      Height          =   285
      Left            =   7485
      TabIndex        =   23
      Top             =   3735
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtiSupplyDay 
      Height          =   285
      Left            =   7485
      TabIndex        =   17
      Top             =   2760
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtfSupplyMulti 
      Height          =   285
      Left            =   1755
      TabIndex        =   22
      Top             =   3780
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtfMinSupply 
      Height          =   285
      Left            =   7485
      TabIndex        =   21
      Top             =   3420
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtiLevel 
      Height          =   285
      Left            =   7485
      TabIndex        =   27
      Top             =   4395
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Enabled         =   0   'False
      Appearance      =   1
      MaxLength       =   100
      Enabled         =   0   'False
   End
   Begin U8Ref.RefEdit EdtcInvPlanCode 
      Height          =   285
      Left            =   1755
      TabIndex        =   28
      Top             =   4770
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxLength       =   8
      RefType         =   1
   End
   Begin EDITLib.Edit EdtfConvertRate 
      Height          =   285
      Left            =   7485
      TabIndex        =   29
      Top             =   4725
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   1
      MaxLength       =   8
   End
   Begin U8Ref.RefEdit EdtdReplaceDate 
      Height          =   285
      Left            =   7485
      TabIndex        =   19
      Top             =   3090
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxLength       =   30
      NumPoint        =   4
      Property        =   5
      RefType         =   2
   End
   Begin UFCHECKBOXLib.UFCheckBox chkbBOMMain 
      Height          =   195
      Left            =   300
      TabIndex        =   6
      Top             =   1140
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "允许BOM母件"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbBOMSub 
      Height          =   195
      Left            =   5970
      TabIndex        =   7
      Top             =   1140
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "允许BOM子件"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCHECKBOXLib.UFCheckBox ChkbProductBill 
      Height          =   195
      Left            =   300
      TabIndex        =   8
      Top             =   1470
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "允许生产订单"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiCheckATP 
      Height          =   315
      Left            =   1755
      TabIndex        =   30
      Top             =   5085
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin U8Ref.RefEdit EdtiInvATPId 
      Height          =   285
      Left            =   7485
      TabIndex        =   31
      Top             =   5040
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      RefType         =   1
   End
   Begin EDITLib.Edit EdtiPlanTfDay 
      Height          =   285
      Left            =   1755
      TabIndex        =   14
      Top             =   2445
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtiOverlapDay 
      Height          =   285
      Left            =   7485
      TabIndex        =   15
      Top             =   2430
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtfMaxSupply 
      Height          =   285
      Left            =   1755
      TabIndex        =   20
      Top             =   3465
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliOverlapDay 
      Height          =   195
      Left            =   5970
      TabIndex        =   60
      Top             =   2490
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "重叠天数"
   End
   Begin UFLABELLib.UFLabel LblATPCode 
      Height          =   195
      Left            =   5970
      TabIndex        =   58
      Top             =   5145
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "ATP规则"
   End
   Begin UFLABELLib.UFLabel LlbiSupplyDay 
      Height          =   195
      Left            =   5970
      TabIndex        =   56
      Top             =   2820
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "供应期间"
   End
   Begin UFLABELLib.UFLabel LblfAlterBaseNum 
      Height          =   195
      Left            =   5970
      TabIndex        =   52
      Top             =   3810
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "变动基数"
   End
   Begin UFLABELLib.UFLabel LblTfCode 
      Height          =   195
      Left            =   5970
      TabIndex        =   50
      Top             =   2160
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "需求时栅"
   End
   Begin UFLABELLib.UFLabel LblcEngineerFigNo 
      Height          =   195
      Left            =   5970
      TabIndex        =   49
      Top             =   4140
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "工程图号"
   End
   Begin UFLABELLib.UFLabel LblcInvPersonCode 
      Height          =   195
      Left            =   5970
      TabIndex        =   47
      Top             =   1830
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "计划员"
   End
   Begin UFLABELLib.UFLabel LblfMinSupply 
      Height          =   195
      Left            =   5970
      TabIndex        =   46
      Top             =   3480
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "最低供应量"
   End
   Begin UFLABELLib.UFLabel LbliLevel 
      Height          =   195
      Left            =   5970
      TabIndex        =   44
      Top             =   4485
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "低阶码"
   End
   Begin UFLABELLib.UFLabel LblfConvertRate 
      Height          =   195
      Left            =   5970
      TabIndex        =   42
      Top             =   4815
      Width           =   1050
      _Version        =   65536
      _ExtentX        =   1852
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "转换因子"
   End
   Begin UFLABELLib.UFLabel LbldReplaceDate 
      Height          =   195
      Left            =   5970
      TabIndex        =   41
      Top             =   3150
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "替换日期"
   End
   Begin UFLABELLib.UFLabel LblcInvPlanCode 
      Height          =   195
      Left            =   300
      TabIndex        =   43
      Top             =   4800
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "计划品"
   End
   Begin UFLABELLib.UFLabel LblfSupplyMulti 
      Height          =   195
      Left            =   300
      TabIndex        =   45
      Top             =   3810
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "供应倍数"
   End
   Begin UFLABELLib.UFLabel LblcInvDepCode 
      Height          =   195
      Left            =   300
      TabIndex        =   48
      Top             =   1830
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "生产部门"
   End
   Begin UFLABELLib.UFLabel LbliAlterAdvance 
      Height          =   195
      Left            =   300
      TabIndex        =   51
      Top             =   4140
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "变动提前期"
   End
   Begin UFLABELLib.UFLabel LblcPlanMethod 
      Height          =   195
      Left            =   300
      TabIndex        =   53
      Top             =   2160
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "计划方法"
   End
   Begin UFLABELLib.UFLabel LbliSupplyType 
      Height          =   195
      Left            =   300
      TabIndex        =   54
      Top             =   4470
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "供应类型"
   End
   Begin UFLABELLib.UFLabel LblcSRPolicy 
      Height          =   195
      Left            =   300
      TabIndex        =   55
      Top             =   2820
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "供需政策"
   End
   Begin UFLABELLib.UFLabel LbliCheckATP 
      Height          =   195
      Left            =   300
      TabIndex        =   57
      Top             =   5130
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "检查ATP"
   End
   Begin UFLABELLib.UFLabel LbliPlanTfDay 
      Height          =   195
      Left            =   300
      TabIndex        =   59
      Top             =   2490
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "计划时栅天数"
   End
   Begin UFLABELLib.UFLabel LblfMaxSupply 
      Height          =   195
      Left            =   300
      TabIndex        =   61
      Top             =   3480
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "最高供应量"
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiSurenessType 
      Height          =   315
      Left            =   1755
      TabIndex        =   32
      Top             =   5430
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   1996768968
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiDateType 
      Height          =   315
      Left            =   7485
      TabIndex        =   33
      Top             =   5370
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiDynamicSurenessType 
      Height          =   315
      Left            =   7485
      TabIndex        =   35
      Top             =   5730
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiRequireTrackStyle 
      Height          =   315
      Left            =   1755
      TabIndex        =   18
      Top             =   3120
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   0
   End
   Begin UFLABELLib.UFLabel lbliRequireTrackStyle 
      Height          =   195
      Left            =   300
      TabIndex        =   68
      Top             =   3150
      Width           =   1320
      _Version        =   65536
      _ExtentX        =   2328
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "需求跟踪方式"
   End
   Begin UFLABELLib.UFLabel lbliBOMExpandUnitType 
      Height          =   195
      Left            =   300
      TabIndex        =   69
      Top             =   6465
      Width           =   1125
      _Version        =   65536
      _ExtentX        =   1984
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "BOM展开单位"
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiBOMExpandUnitType 
      Height          =   315
      Left            =   1755
      TabIndex        =   38
      Top             =   6420
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   1996768968
   End
   Begin UFCHECKBOXLib.UFCheckBox chkbInvKeyPart 
      Height          =   195
      Left            =   5970
      TabIndex        =   9
      Top             =   1470
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "是否关键物料"
      ForeColor       =   0
      Value           =   1
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin EDITLib.Edit EdtiAcceptEarlyDays 
      Height          =   285
      Left            =   7485
      TabIndex        =   39
      Top             =   6420
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliAcceptEarlyDays 
      Height          =   195
      Left            =   5970
      TabIndex        =   70
      Top             =   6465
      Width           =   1410
      _Version        =   65536
      _ExtentX        =   2487
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "允许提前天数"
   End
   Begin EDITLib.Edit EdtiAcceptDelayDays 
      Height          =   285
      Left            =   1755
      TabIndex        =   40
      Top             =   6780
      Width           =   3495
      _Version        =   65536
      _ExtentX        =   6165
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliAcceptDelayDays 
      Height          =   195
      Left            =   300
      TabIndex        =   71
      Top             =   6825
      Width           =   1410
      _Version        =   65536
      _ExtentX        =   2487
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "允许提前天数"
   End
   Begin UFCHECKBOXLib.UFCheckBox chkbTrackSaleBill 
      Height          =   195
      Left            =   5970
      TabIndex        =   72
      Top             =   6840
      Width           =   5115
      _Version        =   65536
      _ExtentX        =   9022
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "销售跟单"
      ForeColor       =   0
      Value           =   1
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
End
Attribute VB_Name = "InvMPS"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'用于翻页(规定接口)
Public Event EdtKeyPress(fldName As String, KeyAscii As Integer)
'用于激活保存按钮(规定接口)
Public Event ActiveSaveBtn()
Public Event GetRef(TableName As String, RefFld As String, sCode As String, sName As String, bReturn As Boolean, Edt As Object, sID As String)
'
Public Event SetUserDefVal(UserDefTable As String, Rs As ADODB.Recordset)

'获取父窗体数据
Public Event GetParentWndData(sXml As String)

Public Event SetcPlanMethod()


Dim m_Dom As New DOMDocument
Dim m_Ele As IXMLDOMElement

Dim m_SrvDB As Object

Dim m_cUserName As String '用户名

Dim m_sRFldAuthInv As String  '只读权限字段名
Dim m_sNFldAuthInv As String  '无权限字段名
Dim m_iQuanDecDgt As Integer  '存货数量小数位
Dim m_bFilling As Boolean '是否在填写数据
Dim m_oLogin As Object

Dim m_ISafeNum As String '安全库存
Dim m_sRowAuthDept As String '部门档案权限字符串
Dim m_sRowAuthPerson As String  '职员档案权限字符串
Dim m_sRowAuthInv As String '存货权限字符串
Dim m_CurDate As String 'Login登陆日期
Dim m_bSave As Boolean '是否可以保存
Dim m_frmMainhWnd As Long '主窗体的hwnd
Dim m_URL As String
Dim m_bWeb As Boolean



Public Function Init870(oLogin As Object, SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Set m_oLogin = oLogin
    Init870 = Init(SrvDB, oPub, sXml)
    Call InitRef
End Function


Private Sub InitRef()
    Dim sMetaXML As String
    Call EdtcInvDepCode.Init(m_oLogin, m_URL + "Department_AA", m_bWeb)
    Call EdtcInvPersonCode.Init(m_oLogin, m_URL + "Person_AA", m_bWeb)
    sMetaXML = "<Ref><RefSet  cRetFld='TfCode' cShowFld='Description' iRetStyle='1' bAutoCheck='1' /></Ref>"
    Call EdtiInvTfId.Init(m_oLogin, m_URL + "TimeFence_MM", m_bWeb, sMetaXML)
    sMetaXML = "<Ref><RefSet  cRefFilterSql=""bPlanInv=1 and bForeExpland=0  ""/></Ref>"
    Call EdtcInvPlanCode.Init(m_oLogin, m_URL + "Inventory_AA", m_bWeb, sMetaXML)
    sMetaXML = "<Ref><RefSet  cRetFld='ATPId' cShowFld='Description'  cCheckFlds='ATPID,ATPCode,Description' iRetStyle='1' bAutoCheck='1' /></Ref>"
    Call EdtiInvATPId.Init(m_oLogin, m_URL + "ATPRule_MM", m_bWeb, sMetaXML)
End Sub
'
'--------------------------------
'功能：根据数据初始化界面(规定接口)
'参数：
'   SrvDb:      数据服务对象
'   oPub:       公共函数对象
'   sXml:       各种数据
'--------------------------------
Public Function Init(SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Init = False
    On Error GoTo Err_Info
    Set g_oPub = oPub
    Set m_SrvDB = SrvDB
    Call g_oPub.UtoLCase(sXml)
    'Call g_oPub.UCtrlLayout(GetControls, "U8.AA.ARCHIVE.TABPAGES.InvMPS")
    Call UserControl_Resize
    Call g_oPub.SetLabelCaption(m_SrvDB, UserControl.Controls, "Inventory")
    Call g_oPub.SetConPosition(UserControl.Controls)
    LblcInvDepCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cinvdepcode") '
    LblcInvPersonCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cinvpersoncode") '
    LbliLevel.Caption = g_oPub.GetResString("U8.AA.INVENTORY.ilevel") '
    Call g_oPub.RemoveCodeCaption(LblATPCode)

    m_sRowAuthDept = GetParaVal(sXml, "g_sRowAuthDept")
    m_sRowAuthPerson = GetParaVal(sXml, "g_sRowAuthPerson")
    m_sRowAuthInv = GetParaVal(sXml, "g_sRowAuthInv")
    m_CurDate = GetParaVal(sXml, "g_CurDate")
    
    Call InitFace(CLng(GetParaVal(sXml, "HelpContextId", "0")))
    m_frmMainhWnd = CLng(GetParaVal(sXml, "hwnd", "0"))
    m_URL = GetParaVal(sXml, "url")
    m_bWeb = IIf(GetParaVal(sXml, "bweb") = "1", True, False)
    If m_frmMainhWnd = 0 Then
        ShowMsg "no main hwnd!" '基本不会出现该消息，但防止出现错误，以便自己测试使用
    End If
    
    CmbcPlanMethod.Clear
    CmbcPlanMethod.AddItem "R"
    CmbcPlanMethod.AddItem "N"
    CmbcPlanMethod.ListIndex = 0
    
    CmbcSRPolicy.Clear
    CmbcSRPolicy.AddItem "PE"
    CmbcSRPolicy.AddItem "LP"
    CmbcSRPolicy.ListIndex = 0
    
    CmbiRequireTrackStyle.Clear
    CmbiRequireTrackStyle.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irequiretrackstyle0")  '""
    CmbiRequireTrackStyle.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irequiretrackstyle1")  '订单号
    CmbiRequireTrackStyle.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irequiretrackstyle2")  '订单行号
    CmbiRequireTrackStyle.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irequiretrackstyle3")  '需求分类代号
    CmbiRequireTrackStyle.ListIndex = 0
    
    CmbiBOMExpandUnitType.Clear
    CmbiBOMExpandUnitType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibomexpandunittype1")  '主计量单位
    CmbiBOMExpandUnitType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.ibomexpandunittype2")  '辅计量单位
    CmbiBOMExpandUnitType.ListIndex = 0
    
    CmbiSupplyType.Clear
    CmbiSupplyType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype0") '"领用"
    CmbiSupplyType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype1") '"入库倒冲"
    CmbiSupplyType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype2") '"工序倒冲"
    CmbiSupplyType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype3") '"虚拟件"
    CmbiSupplyType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isupplytype4") ' "直接供应"
    CmbiSupplyType.ListIndex = 0

    CmbiCheckATP.Clear
    CmbiCheckATP.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.icheckatp0") '"不检查"
    CmbiCheckATP.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.icheckatp1") '"检查物料"
    CmbiCheckATP.ListIndex = 0
    
    CmbiSurenessType.Clear
    CmbiSurenessType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") '"静态"
    CmbiSurenessType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") '"动态"
    CmbiSurenessType.ListIndex = 0
    
    
    CmbiDateType.AddItem ""
    CmbiDateType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0") '"天"
    CmbiDateType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1") '"周"
    CmbiDateType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2") '"月"
    CmbiDateType.ListIndex = 1
    
    CmbiDynamicSurenessType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") '"覆盖天数"
    CmbiDynamicSurenessType.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1") '"百分比"
    CmbiDynamicSurenessType.ListIndex = 0
    
    
    EdtiAlterAdvance.BadStrEx = "-"
    EdtiPlanTfDay.BadStrEx = "-"
    EdtiDateSum.BadStrEx = "-"
    EdtiBestrowSum.BadStrEx = "-"
    EdtiPercentumSum.BadStrEx = "-"
    
    If Not g_oPub.ExistSpecialVersionType(m_SrvDB, 11) Then
        chkbTrackSaleBill.Visible = False
        
    Else
        chkbTrackSaleBill.Visible = True
        
    End If
    
    Init = True
    Exit Function
Err_Info:
    Init = False
End Function


Private Sub ChkbForeExpland_Click()
    RaiseEvent ActiveSaveBtn
End Sub

'Private Sub chkbSpecialOrder_Click()
'    RaiseEvent ActiveSaveBtn
'End Sub

Private Sub chkbTrackSaleBill_Click()
    RaiseEvent ActiveSaveBtn
    CheckCmbcSRPolicy
'    If CmbcSRPolicy.Text = "PE" Then
'        CmbiRequireTrackStyle.Enabled = False
'        If chkbTrackSaleBill.value = Checked Then
'                CmbiRequireTrackStyle.ListIndex = 2
'            Else
'                CmbiRequireTrackStyle.ListIndex = 0
'        End If
'    End If
End Sub

Private Sub chkbInvKeyPart_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub CmbiDateType_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub CmbiDynamicSurenessType_Click()
    RaiseEvent ActiveSaveBtn
    EdtiBestrowSum.Text = ""
    EdtiPercentumSum.Text = ""
    
    If CmbiDynamicSurenessType.ListIndex = 0 Then
        EdtiBestrowSum.Enabled = True
        EdtiPercentumSum.Enabled = False
    Else
        EdtiBestrowSum.Enabled = False
        EdtiPercentumSum.Enabled = True
    End If
End Sub

Private Sub CmbiSurenessType_Click()
    Call SetiSurenessTypeState(IIf(CmbiSurenessType.ListIndex = 1, True, False))
    If m_bFilling = True Then Exit Sub
    RaiseEvent ActiveSaveBtn
    '若[安全库存方法]选择为"动态"时必须输入[动态安全库存方法]
    If CmbiSurenessType.ListIndex = 1 And CmbiDynamicSurenessType.ListIndex < 0 Then
        CmbiDynamicSurenessType.ListIndex = 0
    End If
End Sub

Private Sub SetiSurenessTypeState(bFlag As Boolean)
    On Error Resume Next
    If CmbiDateType.Locked = False Then CmbiDateType.Enabled = bFlag
    If EdtiDateSum.Locked = False Then EdtiDateSum.Enabled = bFlag
    If CmbiDynamicSurenessType.Locked = False Then CmbiDynamicSurenessType.Enabled = bFlag
    If EdtiBestrowSum.Locked = False Then EdtiBestrowSum.Enabled = bFlag
    If EdtiPercentumSum.Locked = False Then EdtiPercentumSum.Enabled = bFlag
End Sub

Private Sub EdtcInvDepCode_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcInvDepCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXml As String)
    If Not (RstGrid Is Nothing) Then
        RaiseEvent SetUserDefVal("Department", RstGrid)
    End If
End Sub

Private Sub EdtcInvDepCode_Change()
'    If UserControl.ActiveControl Is EdtcInvDepCode Then
'        Call ClearTip(EdtcInvDepCode)
'    End If
    If m_bFilling = False Then
        RaiseEvent SetUserDefVal("Department", Nothing)
    End If
End Sub

Private Sub EdtcInvPersonCode_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcInvPersonCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXml As String)
    If Not (RstGrid Is Nothing) Then
        RaiseEvent SetUserDefVal("person", RstGrid)
    End If
End Sub

Private Sub EdtcInvPersonCode_Change()
'    If UserControl.ActiveControl Is EdtcInvPersonCode Then
'        Call ClearTip(EdtcInvPersonCode)
'    End If
    If m_bFilling = False Then
        RaiseEvent SetUserDefVal("person", Nothing)
    End If
End Sub

Private Sub EdtcInvPlanCode_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcInvPlanCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXml As String)
    If Not (RstGrid Is Nothing) Then
        RaiseEvent SetUserDefVal("Inventory", RstGrid)
    End If
End Sub

Private Sub EdtcInvPlanCode_Change()
'    If UserControl.ActiveControl Is EdtcInvPlanCode Then
'        Call ClearTip(EdtcInvPlanCode)
'    End If
    If m_bFilling = False Then
        RaiseEvent SetUserDefVal("Inventory", Nothing)
    End If
End Sub

Private Sub EdtdReplaceDate_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtiInvATPId_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub


Private Sub EdtiInvTfId_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtfMinSupply_LostFocus()
    Call g_oPub.FormatCon(EdtfMinSupply)
End Sub

Private Sub EdtfMaxSupply_LostFocus()
    Call g_oPub.FormatCon(EdtfMaxSupply)
End Sub

Private Sub EdtfSupplyMulti_LostFocus()
    Call g_oPub.FormatCon(EdtfSupplyMulti)
End Sub


Private Sub EdtiOverlapDay_Change()
    If Left(EdtiOverlapDay.Text, 1) = "-" Then
        Call g_oPub.SetIntLen(EdtiOverlapDay, 4)
    Else
        Call g_oPub.SetIntLen(EdtiOverlapDay, 3)
        If Len(EdtiOverlapDay.Text) > 3 Then
            EdtiOverlapDay.Text = Left(EdtiOverlapDay.Text, 3)
        End If
    End If
End Sub

Private Sub EdtiPercentumSum_LostFocus()
    Call g_oPub.FormatCon(EdtiPercentumSum)
End Sub

Private Sub UserControl_Initialize()
    UserControl.KeyPreview = False
'    chkbSpecialOrder.Visible = False
End Sub

Private Sub UFFrmKeyHook_ContainerKeyDown(KeyCode As Integer, ByVal Shift As Integer)
    On Error Resume Next
    If g_oPub.ConKeyDown(UserControl.ActiveControl, KeyCode, Shift) = True Then
        RaiseEvent ActiveSaveBtn
    End If
    If KeyCode = vbKeyF2 Then
'        RefClick
    End If
End Sub


Private Sub UFFrmKeyHook_ContainerKeyPress(KeyAscii As Integer)
    
    On Error Resume Next
    If UserControl.ActiveControl Is Nothing Then Exit Sub
    If KeyAscii = 13 Then
        If LCase(Left(UserControl.ActiveControl.name, 3)) = "edt" Or TypeOf UserControl.ActiveControl Is UFCOMBOBOXLib.UFComboBox Or TypeOf UserControl.ActiveControl Is UFCHECKBOXLib.UFCheckBox Then
            Select Case (UserControl.ActiveControl.name)
                Case EdtiAcceptDelayDays.name
                    RaiseEvent EdtKeyPress("nextpage", KeyAscii)
                    Exit Sub
                Case Else
            End Select
            SendKeys "{TAB}"
        End If
    End If
End Sub

Private Sub UserControl_Resize()
'    On Error Resume Next
'    If Not (g_oPub Is Nothing) Then
'        If LCase(g_oPub.m_LocaleID) = "en-us" Then
'            UserControl.width = g_frameWidthEn
'            UserControl.Height = g_frameHeightEn
'        End If
'    Else
'        UserControl.width = g_frameWidth
'        UserControl.Height = g_frameHeight
'    End If
End Sub


'---------------------------------------
'功能： 根据字段读写权限，控制相应的控件状态
'参数： Con：       控件对象
'       FldName：   字段名称
'返回： 0：无读写权限；1：读权限；2：写权限
'---------------------------------------
Private Function ConSet(Con As Object, ByVal fldName As String) As Integer
    ConSet = g_oPub.ConAuthSet(UserControl.Controls, Con, fldName, m_sRFldAuthInv, m_sNFldAuthInv)
End Function


'------------------------------------------------------------
'功能：设置字段读写权限(规定接口)
'参数： sRFldAuthInv：   读权限字符串
'       sNFldAuthInv:   无权限字符串
'------------------------------------------------------------
Public Sub SetConAuth(sRFldAuthInv As String, sNFldAuthInv As String)
    m_sRFldAuthInv = sRFldAuthInv
    m_sNFldAuthInv = sNFldAuthInv
    
    Call ConSet(EdtcInvDepCode, "cInvDepCode")
    Call ConSet(EdtcInvPersonCode, "cInvPersonCode")
    Call ConSet(EdtiInvTfId, "TfCode") 'iInvTfId
    Call ConSet(EdtiInvATPId, "ATPCode") 'iInvATPId
    Call ConSet(EdtcEngineerFigNo, "cEngineerFigNo")
'    Call ConSet(CmbiPlanPolicy, "iPlanPolicy")
'    Call ConSet(CmbiBatchRule, "iBatchRule")
    Call ConSet(CmbcSRPolicy, "cSRPolicy")
    Call ConSet(CmbiRequireTrackStyle, "iRequireTrackStyle")
    Call ConSet(CmbiBOMExpandUnitType, "iBOMExpandUnitType")
    Call ConSet(CmbcPlanMethod, "cPlanMethod")
    Call ConSet(CmbiSupplyType, "iSupplyType")
    Call ConSet(CmbiCheckATP, "iCheckATP")
    Call ConSet(EdtiSupplyDay, "iSupplyDay")
    Call ConSet(EdtfSupplyMulti, "fSupplyMulti")
    Call ConSet(EdtfMinSupply, "fMinSupply")
    Call ConSet(EdtfMaxSupply, "fMaxSupply")
    'Call ConSet(EdtfFixSupply, "fFixSupply")
    Call ConSet(ChkbMPS, "bMPS")
    Call ConSet(chkbBOMMain, "bBOMMain")
    Call ConSet(ChkbBOMSub, "bBOMSub")
    Call ConSet(ChkbProductBill, "bProductBill")
'    Call ConSet(chkbSpecialOrder, "bSpecialOrder")
    '890sp专版处理销售跟单
    Call ConSet(chkbTrackSaleBill, "bTrackSaleBill")
    Call ConSet(chkbInvKeyPart, "bInvKeyPart")

    Call ConSet(ChkbCutMantissa, "bCutMantissa")
    Call ConSet(ChkbInTotalCost, "bInTotalCost")
    Call ConSet(ChkbBillUnite, "bBillUnite")
    Call ConSet(ChkbRePlan, "bRePlan")
    
    'Call ConSet(EdtfFixedBatch, "fFixedBatch") 'm_fFixedBatchRW =
    'm_iOrderIntervalDaysRW = ConSet(EdtiOrderIntervalDays, "iOrderIntervalDays")
    Call ConSet(EdtiAlterAdvance, "iAlterAdvance") 'm_iChangedAdvanceRW =
    Call ConSet(EdtiPlanTfDay, "iPlanTfDay")
    Call ConSet(EdtiOverlapDay, "iOverlapDay")
    Call ConSet(EdtfAlterBaseNum, "fAlterBaseNum") 'm_fAlterBaseNumRW =
    
    Call ConSet(ChkbForeExpland, "bForeExpland")
    Call ConSet(EdtcInvPlanCode, "cInvPlanCode")
    Call ConSet(EdtfConvertRate, "fConvertRate")
    Call ConSet(EdtdReplaceDate, "dReplaceDate")
    Call ConSet(CmbiSurenessType, "iSurenessType")
    Call ConSet(CmbiDateType, "iDateType")
    Call ConSet(EdtiDateSum, "iDateSum")
    Call ConSet(CmbiDynamicSurenessType, "iDynamicSurenessType")
    Call ConSet(EdtiBestrowSum, "iBestrowSum")
    Call ConSet(EdtiPercentumSum, "iPercentumSum")
    Call ConSet(EdtiAcceptEarlyDays, "iAcceptEarlyDays")
    Call ConSet(EdtiAcceptDelayDays, "iAcceptDelayDays")
    
'    Cmd(0).Enabled = EdtcInvDepCode.Enabled
'    Cmd(1).Enabled = EdtcInvPersonCode.Enabled
'    Cmd(2).Enabled = EdtiInvTfId.Enabled
'    Cmd(3).Enabled = EdtcInvPlanCode.Enabled
'    CmdDate(0).Enabled = EdtdReplaceDate.Enabled
End Sub


'------------------------------------------
'功能：设置字段编辑长度(规定接口)
'参数： Rs：            数据结构数据集
'       iQuanDecDgt：   数量数据精度
'------------------------------------------
Public Sub SetFldLength(Rs As ADODB.Recordset, iQuanDecDgt As Integer)
    m_iQuanDecDgt = iQuanDecDgt
    Call g_oPub.SetIntLen(EdtiAlterAdvance)
    Call g_oPub.SetIntLen(EdtiPlanTfDay, 3)
    Call g_oPub.SetIntLen(EdtiOverlapDay, 4)
    Call g_oPub.SetIntLen(EdtiAcceptEarlyDays, 3) '0---999
    Call g_oPub.SetIntLen(EdtiAcceptDelayDays, 3) '0---999
    EdtcInvDepCode.MaxLength = Rs.fields("cDepName").DefinedSize
    EdtcInvPersonCode.MaxLength = Rs.fields("cPersonName").DefinedSize
    EdtiInvTfId.MaxLength = Rs.fields("Description").DefinedSize
    EdtiInvATPId.MaxLength = 200
    EdtcEngineerFigNo.MaxLength = Rs.fields("cEngineerFigNo").DefinedSize
    EdtcInvPlanCode.MaxLength = Rs.fields("cInvName").DefinedSize
    Call g_oPub.SetDblLen(EdtfConvertRate, , 4)
    EdtfConvertRate.BadStrEx = "-"
    EdtiAcceptEarlyDays.BadStrEx = "-"
    EdtiAcceptDelayDays.BadStrEx = "-"
    Call g_oPub.SetIntLen(EdtiSupplyDay)
    Call g_oPub.SetDblLen(EdtfSupplyMulti, , m_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtfMinSupply, , m_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtfMaxSupply, , m_iQuanDecDgt)
    'Call g_oPub.SetDblLen(EdtfFixSupply, , m_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtfAlterBaseNum, , m_iQuanDecDgt)
    Call g_oPub.SetIntLen(EdtiDateSum, 3)
    Call g_oPub.SetDblLen(EdtiBestrowSum, 3 + 1 + 3, 3)
    Call g_oPub.SetDblLen(EdtiPercentumSum, 3 + 1 + 3, 3)
End Sub


'---------------------------------------
'功能：清空编辑框和CheckBox、comboBox框等(规定接口)
'---------------------------------------
Public Sub EmptyAllFields()
    Dim i As Long
    Dim Con As Control
    For Each Con In Controls
        If TypeOf Con Is Edit Then
            Con.Text = ""
            Con.UToolTipText = ""
            Con.Tag = ""
        ElseIf TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then
            Con.value = 0
        ElseIf TypeOf Con Is UFCOMBOBOXLib.UFComboBox Then
            Con.ListIndex = -1
        ElseIf TypeOf Con Is RefEdit Then
            Con.Clear
        End If
        
    Next Con
'    CmbiPlanPolicy.ListIndex = 1 '因赋值，导致CmbiROPMethod要选项，故CmbiROPMethod赋值在前
    CmbcPlanMethod.ListIndex = 0
    CmbcSRPolicy.ListIndex = 0
    CmbiRequireTrackStyle.ListIndex = 0
    CmbiBOMExpandUnitType.ListIndex = 0
    CmbiSupplyType.ListIndex = 0
    CmbiCheckATP.ListIndex = 0
    CmbiSurenessType.ListIndex = 0
    '存货档案中MPR/MRP页签里的成本累计否栏位的默认值改为是 生产制造开发部 万健 2004-07-12
    ChkbInTotalCost.value = 1
    chkbInvKeyPart.value = 1 '默认是
    EdtfConvertRate.Text = g_oPub.FormatNum(1, 4)
    '存货档案MRP/MPS页中的“允许提前天数”栏目的默认值请改为999。  万健2008-08-25
    EdtiAcceptEarlyDays.Text = 999
    EdtiAcceptDelayDays.Text = 0 '默认为０
End Sub

'------------------------------------------------
'功能：初始化一些默认参数
'------------------------------------------------
Public Sub InitDefaultParam()
    If CmbcPlanMethod.ListIndex = -1 Then
        CmbcPlanMethod.ListIndex = 0
    End If
    If CmbcSRPolicy.ListIndex = -1 Then
        CmbcSRPolicy.ListIndex = 0
    End If
    If CmbiSupplyType.ListIndex = -1 Then
        CmbiSupplyType.ListIndex = 0
    End If
    If CmbiCheckATP.ListIndex = -1 Then
        CmbiCheckATP.ListIndex = 0
    End If
    '存货档案中MPR/MRP页签里的成本累计否栏位的默认值改为是 生产制造开发部 万健 2004-07-12
    ChkbInTotalCost.value = 1
    If EdtfConvertRate.Text = "" Then
        EdtfConvertRate.Text = g_oPub.FormatNum(1, 4)
    End If
    If CmbiSurenessType.ListIndex = -1 Then
        CmbiSurenessType.ListIndex = 0
    End If
End Sub



'-----------------------------------------------
'功能：完成填充所有字段内容的过程(规定接口)
'传入的参数：RsCard：需求填写的数据源（数据集）
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    m_bFilling = True
    Dim sTemp As String
        
    Call WriteName(m_SrvDB, EdtiLevel, RsCard, "cInvCode", "PP_LowLevel", "cInvCode", "iLevel")
    'Call WriteName(m_SrvDB, EdtcInvDepCode, RsCard, "cInvDepCode", "Department", "cDepCode", "cDepName")
    EdtcInvDepCode.Text = TxtValue(RsCard!cInvDepCode)
'    Call WriteName(m_SrvDB, EdtcInvPersonCode, RsCard, "cInvPersonCode", "Person", "cpersonCode", "cpersonName")
    EdtcInvPersonCode.Text = TxtValue(RsCard!cInvPersonCode)
'    Call WriteName(m_SrvDB, EdtcInvPlanCode, RsCard, "cInvPlanCode", "Inventory", "cInvCode", "cInvName")
    EdtcInvPlanCode.Text = TxtValue(RsCard!cInvPlanCode)
    'Call WriteMPSName(TxtValue(RsCard!iInvTfId))
    EdtiInvTfId.Text = GetMpsTfCode(TxtValue(RsCard!iInvTfId))
    EdtiInvATPId.Text = TxtValue(RsCard!iInvATPId)
    EdtcEngineerFigNo.Text = TxtValue(RsCard!cEngineerFigNo)
    sTemp = TxtValue(RsCard!cSRPolicy)
    If Len(sTemp) > 0 Then
        CmbcSRPolicy.Text = sTemp
    Else
        CmbcSRPolicy.ListIndex = -1
    End If
    CmbiRequireTrackStyle.ListIndex = TxtValue(RsCard!iRequireTrackStyle, 0)
    CmbiBOMExpandUnitType.ListIndex = TxtValue((RsCard!iBOMExpandUnitType) - 1, 0)
    
    sTemp = TxtValue(RsCard!cPlanMethod)
    If Len(sTemp) > 0 Then
        CmbcPlanMethod.Text = sTemp
    Else
        CmbcPlanMethod.ListIndex = -1
    End If
    
    CmbiSupplyType.ListIndex = TxtValue(RsCard!iSupplyType, -1)
    CmbiCheckATP.ListIndex = TxtValue(RsCard!iCheckATP, -1)
    EdtiSupplyDay.Text = TxtValue(RsCard!iSupplyDay)
    EdtfSupplyMulti.Text = g_oPub.FormatNum(RsCard!fSupplyMulti, m_iQuanDecDgt)
    EdtfSupplyMulti.Text = g_oPub.FormatNum(RsCard!fSupplyMulti, m_iQuanDecDgt)
    EdtfMinSupply.Text = g_oPub.FormatNum(RsCard!fMinSupply, m_iQuanDecDgt)
    EdtfMaxSupply.Text = g_oPub.FormatNum(RsCard!fMaxSupply, m_iQuanDecDgt)
    
    ChkbMPS.value = ChkValue(RsCard!bMPS)
    chkbBOMMain.value = ChkValue(RsCard!bBOMMain)
    ChkbBOMSub.value = ChkValue(RsCard!bBOMSub)
    ChkbProductBill.value = ChkValue(RsCard!bProductBill)
'    chkbSpecialOrder.value = ChkValue(RsCard!bSpecialOrder)

    '890sp专版处理销售跟单
    chkbTrackSaleBill.value = ChkValue(RsCard!bTrackSaleBill)
    
    chkbInvKeyPart.value = ChkValue(RsCard!bInvKeyPart)

    ChkbForeExpland.value = ChkValue(RsCard!bForeExpland)
    ChkbCutMantissa.value = ChkValue(RsCard!bCutMantissa)
    ChkbInTotalCost.value = ChkValue(RsCard!bInTotalCost)
    ChkbBillUnite.value = ChkValue(RsCard!bBillUnite)
    ChkbRePlan.value = ChkValue(RsCard!bRePlan)
    ChkbForeExpland.value = ChkValue(RsCard!bForeExpland)
    
    EdtiAlterAdvance.Text = TxtValue(RsCard!iAlterAdvance)
    EdtiPlanTfDay.Text = TxtValue(RsCard!iPlanTfDay)
    EdtiOverlapDay.Text = TxtValue(RsCard!iOverlapDay)

    EdtfAlterBaseNum.Text = g_oPub.FormatNum(RsCard!fAlterBaseNum, m_iQuanDecDgt)
    
    EdtfConvertRate.Text = g_oPub.FormatNum(RsCard!fConvertRate, 4)
    EdtdReplaceDate.Text = Format(TxtValue(RsCard!dReplaceDate), "yyyy-mm-dd")
    
    CmbiSurenessType.ListIndex = TxtValue(RsCard!iSurenessType, 0) - 1
    CmbiDateType.ListIndex = TxtValue(RsCard!iDateType, 0)
    EdtiDateSum.Text = TxtValue(RsCard!iDateSum)
    CmbiDynamicSurenessType.ListIndex = TxtValue(RsCard!iDynamicSurenessType, 0) - 1
    EdtiBestrowSum.Text = TxtValue(RsCard!iBestrowSum)
    Call g_oPub.FormatCon(EdtiBestrowSum)
    EdtiPercentumSum.Text = TxtValue(RsCard!iPercentumSum)
    Call g_oPub.FormatCon(EdtiPercentumSum)
    EdtiAcceptEarlyDays.Text = TxtValue(RsCard!iAcceptEarlyDays)
    EdtiAcceptDelayDays.Text = TxtValue(RsCard!iAcceptDelayDays)
    
    CheckCmbcSRPolicy
    
    m_bFilling = False
    
    
End Sub


'-------------------------------------------
'功能：填写相关信息
'参数：
'-------------------------------------------
Public Sub WriteMPSName(sID As String)
    Dim strSql As String
    Dim RsTemp As ADODB.Recordset
    If Len(sID) > 0 Then
        strSql = "select top 1 * from mps_timefence where TfId=" + sID
        Set RsTemp = m_SrvDB.OpenX(strSql)
        If RsTemp.RecordCount = 1 Then
            EdtiInvTfId.Text = TxtValue(RsTemp.fields("Description").value)
            EdtiInvTfId.Tag = sID
            EdtiInvTfId.UToolTipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + TxtValue(RsTemp.fields("TfCode").value)
        End If
    Else
        EdtiInvTfId.Text = ""
        EdtiInvTfId.Tag = ""
        EdtiInvTfId.UToolTipText = ""
    End If
End Sub
Public Function GetMpsTfId(TfCode As String) As String
    Dim strSql As String
    Dim RsTemp As ADODB.Recordset
    If Trim(TfCode) <> "" Then
        strSql = "select top 1 TfId from mps_timefence where TfCode='" + TfCode + "'"
        Set RsTemp = m_SrvDB.OpenX(strSql)
        If RsTemp.RecordCount = 1 Then
            GetMpsTfId = TxtValue(RsTemp!TfId)
            Else
            GetMpsTfId = ""
        End If
    Else
        GetMpsTfId = ""
    End If
End Function
Public Function GetMpsTfCode(TfId As String) As String
    Dim strSql As String
    Dim RsTemp As ADODB.Recordset
    If Trim(TfId) <> "" Then
        strSql = "select top 1 TfCode from mps_timefence where TfId=" + TfId
        Set RsTemp = m_SrvDB.OpenX(strSql)
        If RsTemp.RecordCount = 1 Then
            GetMpsTfCode = TxtValue(RsTemp!TfCode)
            Else
            GetMpsTfCode = ""
        End If
    Else
        GetMpsTfCode = ""
    End If
End Function
'-----------------------------------------
'功能：获得保存的字符串(规定接口)
'参数： bFlag： 是否正确
'返回： 保存的Xml字符串
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim sXml As String
    Dim i As Integer
    Call g_oPub.CheckValid(UserControl.ActiveControl)
    Call EleXML(sXml, "iAlterAdvance", EdtiAlterAdvance)
    Call EleXML(sXml, "iPlanTfDay", EdtiPlanTfDay)
    Call EleXML(sXml, "iOverlapDay", EdtiOverlapDay)
    Call EleXML(sXml, "fAlterBaseNum", EdtfAlterBaseNum)
    
    sXml = sXml + "<cInvDepCode>" + EdtcInvDepCode.Text + "</cInvDepCode>"
    sXml = sXml + "<cInvPersonCode>" + EdtcInvPersonCode.Text + "</cInvPersonCode>"
    sXml = sXml + "<cInvPlanCode>" + EdtcInvPlanCode.Text + "</cInvPlanCode>"
    sXml = sXml + "<iInvTfId>" + GetMpsTfId(EdtiInvTfId.Text) + "</iInvTfId>"
    sXml = sXml + "<iInvATPId>" + EdtiInvATPId.Text + "</iInvATPId>"
    Call EleXML(sXml, "cEngineerFigNo", EdtcEngineerFigNo)
    sXml = sXml + "<cSRPolicy>" + CmbcSRPolicy.Text + "</cSRPolicy>"
    sXml = sXml + "<iRequireTrackStyle>" + CStr(CmbiRequireTrackStyle.ListIndex) + "</iRequireTrackStyle>"
    sXml = sXml + "<iBOMExpandUnitType>" + CStr(CmbiBOMExpandUnitType.ListIndex + 1) + "</iBOMExpandUnitType>"
    sXml = sXml + "<cPlanMethod>" + CmbcPlanMethod.Text + "</cPlanMethod>"
    sXml = sXml + "<iSupplyType>" + CStr(CmbiSupplyType.ListIndex) + "</iSupplyType>"
    sXml = sXml + "<iCheckATP>" + CStr(CmbiCheckATP.ListIndex) + "</iCheckATP>"
    Call EleXML(sXml, "iSupplyDay", EdtiSupplyDay)
    Call EleXML(sXml, "fSupplyMulti", EdtfSupplyMulti)
    Call EleXML(sXml, "fMinSupply", EdtfMinSupply)
    Call EleXML(sXml, "fMaxSupply", EdtfMaxSupply)
    Call EleXML(sXml, "bMPS", ChkbMPS)
    Call EleXML(sXml, "bBOMMain", chkbBOMMain)
    Call EleXML(sXml, "bBOMSub", ChkbBOMSub)
    Call EleXML(sXml, "bProductBill", ChkbProductBill)
'    Call EleXML(sXml, "bSpecialOrder", chkbSpecialOrder)
    '890sp专版处理销售跟单
'    If g_oPub.GetSpecialVersionType(m_SrvDB) = 11 Then
        Call EleXML(sXml, "bTrackSaleBill", chkbTrackSaleBill)
'    End If
    Call EleXML(sXml, "bInvKeyPart", chkbInvKeyPart)

    Call EleXML(sXml, "bForeExpland", ChkbForeExpland)
    Call EleXML(sXml, "fConvertRate", EdtfConvertRate)
    Call EleXML(sXml, "dReplaceDate", EdtdReplaceDate)
    
    Call EleXML(sXml, "bCutMantissa", ChkbCutMantissa)
    Call EleXML(sXml, "bInTotalCost", ChkbInTotalCost)
    Call EleXML(sXml, "bBillUnite", ChkbBillUnite)
    Call EleXML(sXml, "bRePlan", ChkbRePlan)
    
    'Call EleXML(sXml, "iSupplyDay", EdtiSupplyDay)
    
    sXml = sXml + "<iSurenessType>" + CStr(CmbiSurenessType.ListIndex + 1) + "</iSurenessType>"
    sXml = sXml + "<iDateType>" + CStr(CmbiDateType.ListIndex) + "</iDateType>"
    Call EleXML(sXml, "iDateSum", EdtiDateSum)
    sXml = sXml + "<iDynamicSurenessType>" + CStr(CmbiDynamicSurenessType.ListIndex + 1) + "</iDynamicSurenessType>"
    Call EleXML(sXml, "iBestrowSum", EdtiBestrowSum)
    Call EleXML(sXml, "iPercentumSum", EdtiPercentumSum)
    Call EleXML(sXml, "iAcceptEarlyDays", EdtiAcceptEarlyDays)
    Call EleXML(sXml, "iAcceptDelayDays", EdtiAcceptDelayDays)
    GetSaveXml = sXml
End Function

Private Sub CmbcPlanMethod_Click()
    RaiseEvent ActiveSaveBtn
    RaiseEvent SetcPlanMethod
End Sub


Private Sub EdtfAlterBaseNum_LostFocus()
    Call g_oPub.FormatCon(EdtfAlterBaseNum)
End Sub

'------------------------------------------
'功能：离开参照编辑筐检查(规定接口)
'------------------------------------------
Public Function CheckLostFocus() As Boolean
    m_bSave = True
'    If UserControl.ActiveControl Is Nothing Then
'        CheckLostFocus = True
'        Exit Function
'    End If
'    Select Case UserControl.ActiveControl.Name
'        Case EdtcInvDepCode.Name
'            EdtcInvDepCode_LostFocus
'        Case EdtcInvPersonCode.Name
'            EdtcInvPersonCode_LostFocus
'        Case EdtiInvTfId.Name
'            EdtiInvTfId_LostFocus
'        Case EdtcInvPlanCode.Name
'            EdtcInvPlanCode_LostFocus
'    End Select
    CheckLostFocus = m_bSave
End Function

Public Sub GetNum(MinQty As String, MulQty As String)
    MinQty = EdtfMinSupply.Text
    MulQty = EdtfSupplyMulti.Text
End Sub

Public Function GetMPSData() As String
    Dim sXml As String
    sXml = "<MinQty>" + EdtfMinSupply.Text + "</MinQty>"
    sXml = sXml + "<MaxQty>" + EdtfMaxSupply.Text + "</MaxQty>"
    sXml = sXml + "<MulQty>" + EdtfSupplyMulti.Text + "</MulQty>"
    
    sXml = sXml + "<iSurenessType>" + CStr(CmbiSurenessType.ListIndex + 1) + "</iSurenessType>"
    sXml = sXml + "<iDateType>" + CStr(CmbiDateType.ListIndex) + "</iDateType>"
    sXml = sXml + "<iDateSum>" + EdtiDateSum.Text + "</iDateSum>"
    sXml = sXml + "<iDynamicSurenessType>" + CStr(CmbiDynamicSurenessType.ListIndex + 1) + "</iDynamicSurenessType>"
    sXml = sXml + "<iBestrowSum>" + EdtiBestrowSum.Text + "</iBestrowSum>"
    sXml = sXml + "<iPercentumSum>" + EdtiPercentumSum.Text + "</iPercentumSum>"
    GetMPSData = sXml + "<cEngineerFigNo>" + EdtcEngineerFigNo.Text + "</cEngineerFigNo>"
End Function

'---------------------------------------------
'功能：初始化界面：字体、禁用字符
'参数：无
'---------------------------------------------
Private Sub InitFace(HelpContextId As Long)
    Dim Con As Control
    On Error Resume Next
    With UserControl
        For Each Con In .Controls
                Con.Font.name = g_oPub.FontName ' "宋体" '"MS Sans Serif" '
                Con.Font.Size = g_oPub.FontSize ' 9 '小五号字
                Con.Font.Charset = g_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            
            
            If TypeOf Con Is Edit Or LCase(Left(Con.name, 3)) = "edt" Then
                'Con.BadStr = g_oPub.BadStr
                If Con.Property = EditStr Then
                   Con.Property = EditNormal '允许输入空格
                End If
                Con.HelpContextId = HelpContextId
            ElseIf TypeOf Con Is SuperGrid Then
                'Con.SetFilterString (g_oPub.BadStr)
            End If
        Next
    End With
End Sub

Private Sub ChkbBillUnite_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbCutMantissa_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbInTotalCost_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbMPS_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbBOMMain_Click()
    RaiseEvent ActiveSaveBtn
    Call CheckProperty(chkbBOMMain)
End Sub

Private Sub CheckProperty(Con As UFCheckBox)
    On Error Resume Next
    If Con.value = 1 Then
        Dim obj As Object
        Set obj = GetFrmMain(m_frmMainhWnd)
        Call obj.CheckProperty(Con)
    End If
End Sub


Private Sub ChkbBOMSub_Click()
    RaiseEvent ActiveSaveBtn
    Call CheckProperty(ChkbBOMSub)
End Sub

Private Sub ChkbProductBill_Click()
    RaiseEvent ActiveSaveBtn
    Call CheckProperty(ChkbProductBill)
End Sub

Private Sub ChkbRePlan_Click()
    RaiseEvent ActiveSaveBtn
    CheckRePlan
End Sub

Public Sub CheckRePlan()
    If m_bFilling = True Then Exit Sub
    Dim sXml As String
    Dim bSelf As String '是否自制
    Dim bATOModel As String '是否ATO模型
    RaiseEvent GetParentWndData(sXml)
    Call g_oPub.UtoLCase(sXml)
    bSelf = GetParaVal(sXml, "bSelf")
    bATOModel = GetParaVal(sXml, "bATOModel")
    If ChkbRePlan.value = 1 Then
        If bSelf = "0" Then
            ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.MPS.569_1") 'U8.AA.U8TABPAGES.MPS.569_1="【重复计划】选择[是]，则必须先选择【自制】属性！"
            ChkbRePlan.value = 0
            Exit Sub
        End If
        
        If bATOModel = "1" Then
            ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.MPS.575_1") 'U8.AA.U8TABPAGES.MPS.575_1="属性为【ATO模型】的存货，不可选择【重复计划】！"
            ChkbRePlan.value = 0
            Exit Sub
        End If
    End If
        
End Sub

Private Sub CmbcSRPolicy_Click()
    RaiseEvent ActiveSaveBtn
    CheckCmbcSRPolicy
End Sub

Private Sub CmbiRequireTrackStyle_Click()
    RaiseEvent ActiveSaveBtn
    If CmbiRequireTrackStyle.Enabled = True Then
        If CmbiRequireTrackStyle.ListIndex = 0 Then
            CmbiRequireTrackStyle.ListIndex = 1
        End If
    End If
End Sub

Private Sub CmbiBOMExpandUnitType_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Public Sub CheckCmbcSRPolicy()
    Dim sXml As String
    Dim bATOModel As String '是否ATO模型
    Dim bInvModel As String '是否模型

    RaiseEvent GetParentWndData(sXml)
    Call g_oPub.UtoLCase(sXml)
    bATOModel = GetParaVal(sXml, "bATOModel")
    If m_bFilling = True Then
        If CmbcSRPolicy.Text = "LP" Then
'            chkbSpecialOrder.Enabled = True
            '890sp专版处理销售跟单
            
            chkbTrackSaleBill.Enabled = False
            
            If bATOModel = "1" Then
                CmbiRequireTrackStyle.Enabled = False
            Else
                CmbiRequireTrackStyle.Enabled = True
            End If
        Else
'            chkbSpecialOrder.Enabled = False
            '890sp专版处理销售跟单
            
            chkbTrackSaleBill.Enabled = True
            
            CmbiRequireTrackStyle.Enabled = False
        End If
        Exit Sub
    End If
    
    bInvModel = GetParaVal(sXml, "bInvModel")
        
    If bATOModel = "1" And CmbcSRPolicy.Text <> "LP" And bInvModel = "1" Then '
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.201_1") 'U8.AA.INVENTORY.FRMZAM.201_1="属性为【ATO】的存货，【供需政策】一定为[LP]！"
        CmbcSRPolicy.Text = "LP"
    End If
    
    '“销售跟单”
    '（1）放在MPS/MRP页签下；
    '（2）供需政策=LP时，置灰不可编辑（LP不用它）；
    '（3）供需政策=PE时，默认为“否”可改为“是”。
    '需求跟踪方式:
    '①PE件该项为空值，不可修改；②LP件默认为订单行号，对于非ATO物料可以修改为订单号或需求分类代号，对于ATO物料则不可以修改。
    If CmbcSRPolicy.Text = "LP" Then
'        chkbSpecialOrder.Enabled = True
'        chkbSpecialOrder.value = 1
        '890sp专版处理销售跟单
        chkbTrackSaleBill.Enabled = False
        '段红缨 2006-10-21“销售跟单”：当“供需政策”为LP时，其一定为“是”。
        If g_oPub.ExistSpecialVersionType(m_SrvDB, 11) Then
            chkbTrackSaleBill.value = 1
        End If
        
        CmbiRequireTrackStyle.ListIndex = 2
        If bATOModel = "1" Then
            CmbiRequireTrackStyle.Enabled = False
        Else
            CmbiRequireTrackStyle.Enabled = True
        End If
    Else
'        chkbSpecialOrder.Enabled = False
'        chkbSpecialOrder.value = 0
        '890sp专版处理销售跟单
        
        chkbTrackSaleBill.Enabled = True
        'chkbTrackSaleBill.value = 0
        CmbiRequireTrackStyle.Enabled = False
        
        If Not g_oPub.ExistSpecialVersionType(m_SrvDB, 11) Then
            CmbiRequireTrackStyle.ListIndex = 0
        Else
            If chkbTrackSaleBill.value = Checked Then
                CmbiRequireTrackStyle.ListIndex = 2
                Else
                CmbiRequireTrackStyle.ListIndex = 0
            End If
        End If
        
        
    End If
End Sub

Private Sub CmbiSupplyType_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub CmbiCheckATP_Click()
    RaiseEvent ActiveSaveBtn
    If CmbiCheckATP.ListIndex = 0 Then
        EdtiInvATPId.Enabled = False
    Else
        EdtiInvATPId.Enabled = True
    End If
End Sub

Private Sub UserControl_GotFocus()
    On Error GoTo Err_Info
        ChkbMPS.SetFocus
    Exit Sub
Err_Info:
End Sub


Public Property Get CmbcPlanMethodText() As String
    CmbcPlanMethodText = CmbcPlanMethod.Text
End Property

Public Property Let CmbcPlanMethodText(ByVal vNewValue As String)
    On Error Resume Next
    CmbcPlanMethod.Text = vNewValue
End Property

Public Property Get cSRPolicyText() As String
    cSRPolicyText = CmbcSRPolicy.Text
End Property

Public Property Let cSRPolicyText(ByVal vNewValue As String)
    On Error GoTo Err_Info
    CmbcSRPolicy.Text = vNewValue
    Exit Property
Err_Info:
    ShowMsg Err.Description
End Property

Public Property Get Control_ChkbForeExpland() As Variant
    Set Control_ChkbForeExpland = ChkbForeExpland
End Property

'============================================================================================================================================
'分析：
'       目前平台现有服务之所以无法满足控件内部的元素自动布局，那么我的想法就是想办法把控件内部的元素主动得到传给平台，那么问题基本也就解决了。
'结论：
'       在每个控件内部加入此函数，取出本控件内部的所有元素，并返回元素集合。
'       在调用平台布局服务的时候把已经得到的内部元素作为集合传给平台布局服务。（已经协商好，平台会针对此问题增加新的接口）
'============================================================================================================================================
Private Function GetControls() As Collection
    Dim iCount As Integer
    Dim objCollection As New Collection
    For iCount = 0 To UserControl.Controls.Count - 1
        objCollection.Add UserControl.Controls(iCount)
    Next iCount
    
    Set GetControls = objCollection
End Function

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
   If UserControl.Ambient.UserMode = True Then
      UFFrmKeyHook.Attach
   End If
End Sub


Public Property Get bBOMMain() As Integer
    bBOMMain = chkbBOMMain.value
End Property

Public Property Let bBOMMain(value As Integer)
    chkbBOMMain.value = value
End Property

Public Property Get ChkbBOMMainCaptin() As String
    ChkbBOMMainCaptin = chkbBOMMain.Caption
End Property

Public Property Get bBOMSub() As Integer
    bBOMSub = ChkbBOMSub.value
End Property

Public Property Let bBOMSub(value As Integer)
    ChkbBOMSub.value = value
End Property

Public Property Get ChkbBOMSubCaption() As String
    ChkbBOMSubCaption = ChkbBOMSub.Caption
End Property

Public Property Get bProductBill() As Integer
    bProductBill = ChkbProductBill.value
End Property

Public Property Let bProductBill(value As Integer)
    ChkbProductBill.value = value
End Property

Public Property Get ChkbProductBillCaption() As String
    ChkbProductBillCaption = ChkbProductBill.Caption
End Property

'Public Function CheckStd() As Boolean
'    If CmbiSurenessType.ListIndex = 1 Then
'        If EdtiDateSum.Text = "" Then
'            ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.datesum_notnull") '"期间数不能为空！"
'            CheckStd = False
'            Exit Function
'        End If
'        If CmbiDynamicSurenessType.ListIndex = 0 Then
'            If EdtiBestrowSum.Text = "" Then
'                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bestrowsum_notnull") '"覆盖天数不能为空！"
'                CheckStd = False
'                Exit Function
'            End If
'        Else
'            If EdtiPercentumSum.Text = "" Then
'                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.percentumsum_notnull") '"百分比不能为空！"
'                CheckStd = False
'                Exit Function
'            End If
'        End If
'    End If
'    CheckStd = True
'End Function
