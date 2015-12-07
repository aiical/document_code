VERSION 5.00
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Object = "{4C2F9AC0-6D40-468A-8389-518BB4F8C67D}#1.0#0"; "UFComboBox.ocx"
Object = "{A98B9C82-88D8-4F94-91BB-F2289111C59C}#1.0#0"; "UFCheckBox.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Object = "{5E4640D0-A415-404B-A457-72980C429D2F}#10.25#0"; "U8RefEdit.ocx"
Begin VB.UserControl InvOther 
   ClientHeight    =   6480
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11295
   KeyPreview      =   -1  'True
   LockControls    =   -1  'True
   ScaleHeight     =   6480
   ScaleWidth      =   11295
   Begin VB.PictureBox PicMedicine 
      Appearance      =   0  'Flat
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   1275
      Left            =   180
      ScaleHeight     =   1275
      ScaleWidth      =   11025
      TabIndex        =   66
      Top             =   5160
      Width           =   11025
      Begin EDITLib.Edit EdtCRegisterNo 
         Height          =   285
         Left            =   6930
         TabIndex        =   33
         Top             =   45
         Width           =   3855
         _Version        =   65536
         _ExtentX        =   6800
         _ExtentY        =   503
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
      End
      Begin EDITLib.Edit EdtcPreparationType 
         Height          =   270
         Left            =   1245
         TabIndex        =   32
         Top             =   30
         Width           =   3855
         _Version        =   65536
         _ExtentX        =   6791
         _ExtentY        =   476
         _StockProps     =   253
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkIRecipeBatch 
         Height          =   195
         Index           =   2
         Left            =   5355
         TabIndex        =   39
         Top             =   1035
         Width           =   5130
         _Version        =   65536
         _ExtentX        =   9049
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "乙类非处方药"
         ForeColor       =   943208504
         ForeColor       =   943208504
         BorderStyle     =   6404
         ReadyState      =   943208504
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkIRecipeBatch 
         Height          =   195
         Index           =   1
         Left            =   0
         TabIndex        =   38
         Top             =   1035
         Width           =   5130
         _Version        =   65536
         _ExtentX        =   9049
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "甲类非处方药"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   11
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkIRecipeBatch 
         Height          =   195
         Index           =   0
         Left            =   5355
         TabIndex        =   37
         Top             =   720
         Width           =   5130
         _Version        =   65536
         _ExtentX        =   9049
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "处方药"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbFirstBusiMedicine 
         Height          =   195
         Left            =   5355
         TabIndex        =   35
         Top             =   390
         Width           =   5130
         _Version        =   65536
         _ExtentX        =   9049
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "是否首营药品"
         ForeColor       =   -1
         ForeColor       =   -1
         BorderStyle     =   -1
         ReadyState      =   -1
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbImportMedicine 
         Height          =   195
         Left            =   0
         TabIndex        =   34
         Top             =   390
         Width           =   5130
         _Version        =   65536
         _ExtentX        =   9049
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "是否进口药品"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbSpecialties 
         Height          =   195
         Left            =   0
         TabIndex        =   36
         Top             =   720
         Width           =   5130
         _Version        =   65536
         _ExtentX        =   9049
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "特殊药品"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFLABELLib.UFLabel LblCRegisterNo 
         Height          =   195
         Left            =   5370
         TabIndex        =   67
         Top             =   75
         Width           =   1590
         _Version        =   65536
         _ExtentX        =   2805
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "进口药品注册证号"
      End
      Begin UFLABELLib.UFLabel LblcPreparationType 
         Height          =   195
         Left            =   0
         TabIndex        =   68
         Top             =   60
         Width           =   1260
         _Version        =   65536
         _ExtentX        =   2222
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "剂型"
      End
   End
   Begin U8Ref.RefEdit EdtcInvProjectCode 
      Height          =   285
      Left            =   7125
      TabIndex        =   24
      Top             =   3547
      Width           =   3855
      _ExtentX        =   6800
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
   Begin EDITLib.Edit EdtiVolume 
      Height          =   285
      Left            =   7125
      TabIndex        =   9
      Top             =   1298
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   4
      NumPoint        =   4
      MaxLength       =   12
   End
   Begin EDITLib.Edit EdtiInvWeight 
      Height          =   270
      Left            =   1440
      TabIndex        =   2
      Top             =   350
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   4
      NumPoint        =   4
      MaxLength       =   12
   End
   Begin EDITLib.Edit EdtCCreatePerson 
      Height          =   270
      Left            =   1440
      TabIndex        =   27
      Top             =   4190
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Enabled         =   0   'False
      Appearance      =   1
      Enabled         =   0   'False
   End
   Begin EDITLib.Edit EdtiId 
      Height          =   285
      Left            =   7125
      TabIndex        =   28
      Top             =   4181
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Enabled         =   0   'False
      Appearance      =   1
      Enabled         =   0   'False
   End
   Begin EDITLib.Edit EdtcModifyPerson 
      Height          =   270
      Left            =   1440
      TabIndex        =   29
      Top             =   4510
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Enabled         =   0   'False
      Appearance      =   1
      Enabled         =   0   'False
   End
   Begin EDITLib.Edit EdtcQuality 
      Height          =   270
      Left            =   1440
      TabIndex        =   25
      Top             =   3870
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   1
      NumPoint        =   4
      MaxLength       =   8
   End
   Begin U8Ref.RefEdit EdtdSDate 
      Height          =   270
      Left            =   1440
      TabIndex        =   10
      Top             =   1630
      Width           =   3855
      _ExtentX        =   6800
      _ExtentY        =   476
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
   Begin U8Ref.RefEdit EdtdEDate 
      Height          =   285
      Left            =   7125
      TabIndex        =   11
      Top             =   1615
      Width           =   3855
      _ExtentX        =   6800
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
   Begin U8Ref.RefEdit EdtcWGroupCode 
      Height          =   270
      Left            =   1440
      TabIndex        =   0
      Top             =   30
      Width           =   3855
      _ExtentX        =   6800
      _ExtentY        =   476
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
      MaxLength       =   20
      RefType         =   1
   End
   Begin U8Ref.RefEdit EdtcWUnit 
      Height          =   285
      Left            =   7125
      TabIndex        =   1
      Top             =   30
      Width           =   3855
      _ExtentX        =   6800
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
   Begin EDITLib.Edit EdtfGrossW 
      Height          =   285
      Left            =   7125
      TabIndex        =   3
      Top             =   347
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   4
      NumPoint        =   4
      MaxLength       =   12
   End
   Begin U8Ref.RefEdit EdtcVGroupCode 
      Height          =   270
      Left            =   1440
      TabIndex        =   4
      Top             =   670
      Width           =   3855
      _ExtentX        =   6800
      _ExtentY        =   476
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
      MaxLength       =   20
      RefType         =   1
   End
   Begin U8Ref.RefEdit EdtcVUnit 
      Height          =   285
      Left            =   7125
      TabIndex        =   5
      Top             =   664
      Width           =   3855
      _ExtentX        =   6800
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
   Begin EDITLib.Edit EdtfLength 
      Height          =   270
      Left            =   1440
      TabIndex        =   6
      Top             =   990
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   4
      NumPoint        =   4
      MaxLength       =   12
   End
   Begin EDITLib.Edit EdtfWidth 
      Height          =   285
      Left            =   7125
      TabIndex        =   7
      Top             =   981
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   4
      NumPoint        =   4
      MaxLength       =   12
   End
   Begin EDITLib.Edit EdtfHeight 
      Height          =   270
      Left            =   1440
      TabIndex        =   8
      Top             =   1310
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   4
      NumPoint        =   4
      MaxLength       =   12
   End
   Begin EDITLib.Edit EdtCEnterNo 
      Height          =   270
      Left            =   1440
      TabIndex        =   16
      Top             =   2590
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtCPackingType 
      Height          =   285
      Left            =   7125
      TabIndex        =   13
      Top             =   1932
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtcCheckOut 
      Height          =   270
      Left            =   1440
      TabIndex        =   14
      Top             =   2270
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      MaxLength       =   60
   End
   Begin EDITLib.Edit EdtcFile 
      Height          =   270
      Left            =   1440
      TabIndex        =   12
      Top             =   1950
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   1
      MaxLength       =   25
   End
   Begin EDITLib.Edit EdtcLicence 
      Height          =   285
      Left            =   7125
      TabIndex        =   17
      Top             =   2566
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      MaxLength       =   60
   End
   Begin EDITLib.Edit EdtcLabel 
      Height          =   285
      Left            =   7125
      TabIndex        =   15
      Top             =   2249
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
      Property        =   1
      MaxLength       =   25
   End
   Begin EDITLib.Edit EdtCCommodity 
      Height          =   270
      Left            =   1440
      TabIndex        =   18
      Top             =   2910
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin EDITLib.Edit EdtCNotPatentName 
      Height          =   285
      Left            =   7125
      TabIndex        =   19
      Top             =   2883
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   503
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFCHECKBOXLib.UFCheckBox chkbCheckBSATP 
      Height          =   270
      Left            =   2925
      TabIndex        =   23
      Top             =   3550
      Width           =   2370
      _Version        =   65536
      _ExtentX        =   4180
      _ExtentY        =   476
      _StockProps     =   15
      Caption         =   "检查售前ATP"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   -30
      Top             =   5670
      _ExtentX        =   1905
      _ExtentY        =   529
      ManualAttach    =   -1  'True
   End
   Begin UFLABELLib.UFLabel LblcInvProjectCode 
      Height          =   195
      Left            =   5550
      TabIndex        =   40
      Top             =   3617
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "售前ATP方案"
   End
   Begin UFLABELLib.UFLabel LlbfWidth 
      Height          =   195
      Left            =   5565
      TabIndex        =   57
      Top             =   1041
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "宽(cm)"
   End
   Begin UFLABELLib.UFLabel LblCNotPatentName 
      Height          =   195
      Left            =   5565
      TabIndex        =   56
      Top             =   2973
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "国际非专利名"
   End
   Begin UFLABELLib.UFLabel LblcLabel 
      Height          =   195
      Left            =   5565
      TabIndex        =   55
      Top             =   2329
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "注册商标"
   End
   Begin UFLABELLib.UFLabel LblcLicence 
      Height          =   195
      Left            =   5565
      TabIndex        =   54
      Top             =   2651
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "许可证号"
   End
   Begin UFLABELLib.UFLabel LblCPackingType 
      Height          =   195
      Left            =   5565
      TabIndex        =   53
      Top             =   2007
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "包装规格"
   End
   Begin UFLABELLib.UFLabel LblcVUnit 
      Height          =   195
      Left            =   5565
      TabIndex        =   41
      Top             =   719
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "体积单位"
   End
   Begin UFLABELLib.UFLabel LblfGrossW 
      Height          =   195
      Left            =   5565
      TabIndex        =   42
      Top             =   397
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "毛重"
   End
   Begin UFLABELLib.UFLabel LblcWUnit 
      Height          =   195
      Left            =   5565
      TabIndex        =   43
      Top             =   75
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "重量单位"
   End
   Begin UFLABELLib.UFLabel LbldModifyDate 
      Height          =   195
      Left            =   5550
      TabIndex        =   44
      Top             =   4583
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "变更日期"
   End
   Begin UFLABELLib.UFLabel LbliId 
      Height          =   195
      Left            =   5550
      TabIndex        =   46
      Top             =   4261
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "所属权限组"
   End
   Begin UFLABELLib.UFLabel LabiVolume 
      Height          =   195
      Left            =   5565
      TabIndex        =   49
      Top             =   1363
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "单位体积"
   End
   Begin UFLABELLib.UFLabel LabdEDate 
      Height          =   195
      Left            =   5565
      TabIndex        =   50
      Top             =   1685
      Width           =   1590
      _Version        =   65536
      _ExtentX        =   2805
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "停用日期"
   End
   Begin UFLABELLib.UFLabel LblCCommodity 
      Height          =   195
      Left            =   195
      TabIndex        =   65
      Top             =   2973
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "注册商品批件"
   End
   Begin UFLABELLib.UFLabel LblcFile 
      Height          =   195
      Left            =   195
      TabIndex        =   64
      Top             =   2007
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "批准文号"
   End
   Begin UFLABELLib.UFLabel LblcCheckOut 
      Height          =   195
      Left            =   195
      TabIndex        =   63
      Top             =   2329
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "合格证号"
   End
   Begin UFLABELLib.UFLabel LblCEnterNo 
      Height          =   195
      Left            =   195
      TabIndex        =   62
      Top             =   2651
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "入关证号"
   End
   Begin UFLABELLib.UFLabel LblcVGroupCode 
      Height          =   195
      Left            =   195
      TabIndex        =   61
      Top             =   719
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "体积计量组"
   End
   Begin UFLABELLib.UFLabel LblcWGroupCode 
      Height          =   195
      Left            =   195
      TabIndex        =   60
      Top             =   75
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "重量计量组"
   End
   Begin UFLABELLib.UFLabel LabiInvWeight 
      Height          =   195
      Left            =   195
      TabIndex        =   59
      Top             =   397
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "净重"
   End
   Begin UFLABELLib.UFLabel LabdSDate 
      Height          =   195
      Left            =   195
      TabIndex        =   58
      Top             =   1685
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "启用日期"
   End
   Begin UFLABELLib.UFLabel LabcQuality 
      Height          =   195
      Left            =   195
      TabIndex        =   45
      Top             =   3939
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "质量要求"
   End
   Begin UFLABELLib.UFLabel lblcModifyPerson 
      Height          =   195
      Left            =   195
      TabIndex        =   47
      Top             =   4583
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "变更人"
   End
   Begin UFLABELLib.UFLabel LblCCreatePerson 
      Height          =   195
      Left            =   195
      TabIndex        =   48
      Top             =   4261
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "建档人"
   End
   Begin UFLABELLib.UFLabel LblfLength 
      Height          =   195
      Left            =   195
      TabIndex        =   51
      Top             =   1041
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "长(cm)"
   End
   Begin UFLABELLib.UFLabel LblfHeight 
      Height          =   195
      Left            =   195
      TabIndex        =   52
      Top             =   1363
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "高(cm)"
   End
   Begin EDITLib.Edit EdtiWarrantyPeriod 
      Height          =   270
      Left            =   1440
      TabIndex        =   20
      Top             =   3230
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Appearance      =   1
   End
   Begin UFLABELLib.UFLabel LbliWarrantyPeriod 
      Height          =   195
      Left            =   195
      TabIndex        =   69
      Top             =   3295
      Width           =   1230
      _Version        =   65536
      _ExtentX        =   2170
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "保修期限"
   End
   Begin UFLABELLib.UFLabel lbliWarrantyUnit 
      Height          =   195
      Left            =   5565
      TabIndex        =   70
      Top             =   3295
      Width           =   1545
      _Version        =   65536
      _ExtentX        =   2725
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "保修期单位"
   End
   Begin UFCOMBOBOXLib.UFComboBox CmbiWarrantyUnit 
      Height          =   315
      Left            =   7125
      TabIndex        =   21
      Top             =   3200
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   556
      _StockProps     =   196
      Text            =   ""
      Style           =   2
      ForeColor       =   1996768968
   End
   Begin UFLABELLib.UFLabel lbldInvCreateDatetime 
      Height          =   195
      Left            =   5550
      TabIndex        =   71
      Top             =   3939
      Width           =   720
      _Version        =   65536
      _ExtentX        =   1270
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "建档日期"
      AutoSize        =   -1  'True
   End
   Begin U8Ref.RefEdit EdtdInvCreateDatetime 
      Height          =   285
      Left            =   7125
      TabIndex        =   26
      Top             =   3864
      Width           =   3855
      _ExtentX        =   6800
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      Enabled         =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxLength       =   30
      Property        =   5
      RefType         =   2
   End
   Begin U8Ref.RefEdit EdtDModifyDate 
      Height          =   285
      Left            =   7125
      TabIndex        =   30
      Top             =   4510
      Width           =   3855
      _ExtentX        =   6800
      _ExtentY        =   503
      BadStr          =   "<>'""|&,"
      Enabled         =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxLength       =   30
      Property        =   5
      RefType         =   2
   End
   Begin UFCHECKBOXLib.UFCheckBox chkbPUQuota 
      Height          =   195
      Left            =   195
      TabIndex        =   22
      Top             =   3617
      Width           =   2370
      _Version        =   65536
      _ExtentX        =   4180
      _ExtentY        =   344
      _StockProps     =   15
      Caption         =   "参与配额"
      ForeColor       =   0
      ForeColor       =   0
      BorderStyle     =   0
      ReadyState      =   0
   End
   Begin EDITLib.Edit EdtcInvAppDocNo 
      Height          =   270
      Left            =   1440
      TabIndex        =   31
      Top             =   4830
      Width           =   3855
      _Version        =   65536
      _ExtentX        =   6800
      _ExtentY        =   476
      _StockProps     =   253
      ForeColor       =   0
      BackColor       =   16777215
      Enabled         =   0   'False
      Appearance      =   1
      Enabled         =   0   'False
   End
   Begin UFLABELLib.UFLabel lblcInvAppDocNo 
      Height          =   195
      Left            =   195
      TabIndex        =   72
      Top             =   4905
      Width           =   1260
      _Version        =   65536
      _ExtentX        =   2222
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "变更申请编号"
   End
End
Attribute VB_Name = "InvOther"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'用于翻页(规定接口)
Public Event EdtKeyPress(fldName As String, KeyAscii As Integer)
'用于激活保存按钮(规定接口)
Public Event ActiveSaveBtn()
Public Event GetRef(TableName As String, RefFld As String, sCode As String, sName As String, bReturn As Boolean, Edt As Object, sGroupCode As String, sFilter As String)



Dim m_Dom As New DOMDocument
Dim m_Ele As IXMLDOMElement

Dim m_SrvDB As Object
Dim m_oLogin As Object

Dim m_dSDateRW As Integer '【启用日期】读写权限：0：读写无；1：读权限；2：写权限
Dim m_cUserName As String '用户名
Dim m_CurDate As String '登录日期
Dim m_DbSrvDate As String '数据库日期
Dim m_URL As String
Dim m_bWeb As Boolean
Dim m_iWeightDecDgt As Integer
Dim m_iVolumeDecDgt As Integer
Dim m_bFilling As Boolean

Dim m_sRFldAuthInv As String  '只读权限字段名
Dim m_sNFldAuthInv As String  '无权限字段名
Dim m_iQuanDecDgt As Integer  '存货数量小数位
Dim m_bSave As Boolean '是否可以保存
Dim iRecipeBatchItems() As String '处方药类型
Dim m_frmMainhWnd As Long '主窗体的hwnd

'



'Private Sub Cmd_Click(Index As Integer)
'    RaiseEvent ActiveSaveBtn
'    Dim sCode As String
'    Dim sName As String
'    Dim sGroupCode As String
'    Dim bReturn  As Boolean
'    Select Case Index
'        Case 0
'            RaiseEvent GetRef("", "cWGroupCode", sCode, sName, bReturn, EdtcWGroupCode, "", "")
'        Case 1
'            RaiseEvent GetRef("", "cWUnit", sCode, sName, bReturn, EdtcWUnit, EdtcWGroupCode.Tag, "")
'        Case 2
'            RaiseEvent GetRef("", "cVGroupCode", sCode, sName, bReturn, EdtcVGroupCode, "", "")
'        Case 3
'            RaiseEvent GetRef("", "cVUnit", sCode, sName, bReturn, EdtcVUnit, EdtcVGroupCode.Tag, "")
'    End Select
'
'    If bReturn = True Then
'        Cmd(Index).Tag = "Refed"
'        Select Case Index
'            Case 0
'                Call SetRefEdtValue(EdtcWGroupCode, sCode, sName)
'                Call ShowOtherUnit(sCode, EdtcWUnit)
'            Case 1
'                Call SetRefEdtValue(EdtcWUnit, sCode, sName)
'            Case 2
'                Call SetRefEdtValue(EdtcVGroupCode, sCode, sName)
'                Call ShowOtherUnit(sCode, EdtcVUnit)
'            Case 3
'                Call SetRefEdtValue(EdtcVUnit, sCode, sName)
'        End Select
'    End If
'
'End Sub

'Private Sub CmdDate_Click(Index As Integer)
'    RaiseEvent ActiveSaveBtn
'    Select Case Index
'        Case 0
'            Call Calendar(EdtdSDate, Frame1)
'        Case 1
'            Call Calendar(EdtdEDate, Frame1)
'    End Select
'End Sub

Private Sub chkbCheckBSATP_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub chkbPUQuota_Click()
    RaiseEvent ActiveSaveBtn
    'OutputDebugString "1"
    If m_bFilling = False And chkbPUQuota.value = 1 Then
        Dim obj As Object
        'OutputDebugString "m_frmMainhWnd:" & CStr(m_frmMainhWnd)
        Set obj = GetFrmMain(m_frmMainhWnd)
        'OutputDebugString "obj:" & IIf(obj Is Nothing, "nothing", "not nothing")
        'OutputDebugString "2"
        Call obj.CheckbInvAssetMutex(chkbPUQuota)
        'OutputDebugString "3"
    End If
End Sub

Private Sub ChkbFirstBusiMedicine_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbImportMedicine_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbSpecialties_Click()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub CmbiWarrantyUnit_Click()
    RaiseEvent ActiveSaveBtn
    Call EdtiWarrantyPeriod_Change
End Sub

Private Sub EdtcInvProjectCode_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcVGroupCode_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcVGroupCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXml As String)
    Call ShowOtherUnit(EdtcVGroupCode.Text, EdtcVUnit)
End Sub

Private Sub EdtcVGroupCode_Change()
    If UserControl.ActiveControl Is EdtcVGroupCode Then
'        Call ClearTip(EdtcVGroupCode)
'        Call ClearAll(EdtcVUnit)
        EdtcVUnit.Clear
    End If
End Sub

Private Sub EdtcVGroupCode_LostFocus()
'    If (EdtcVGroupCode.Text = "") Or (UserControl.ActiveControl Is Cmd(2)) Then Exit Sub '
'    Call CheckGroup(EdtcVGroupCode, EdtcVUnit)
End Sub

Private Sub EdtcVUnit_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcVUnit_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcVGroupCode, EdtcVUnit, 0, sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcVUnit_Change()
    Call WriteFirstGroup(EdtcVGroupCode, EdtcVUnit, False)
'    If UserControl.ActiveControl Is EdtcVUnit Then
'        Call ClearTip(EdtcVUnit)
'    End If
End Sub


Private Sub EdtcVUnit_LostFocus()
'    If (UserControl.ActiveControl Is Cmd(3)) Then Exit Sub
'    Call CheckUnit(EdtcVGroupCode, EdtcVUnit)
End Sub

Private Sub EdtcWGroupCode_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcWGroupCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXml As String)
    Call ShowOtherUnit(EdtcWGroupCode.Text, EdtcWUnit)
End Sub

Private Sub EdtcWGroupCode_Change()
    If UserControl.ActiveControl Is EdtcWGroupCode Then
'        Call ClearTip(EdtcWGroupCode)
'        Call ClearAll(EdtcWUnit)
        EdtcWUnit.Clear
    End If
End Sub

Private Sub EdtcWGroupCode_LostFocus()
'    If (EdtcWGroupCode = "") Or (UserControl.ActiveControl Is Cmd(0)) Then Exit Sub '
'    Call CheckGroup(EdtcWGroupCode, EdtcWUnit)
End Sub

'Private Sub CheckGroup(EdtGroup As Edit, EdtUnit As Edit)
'    If EdtGroup.Tag <> "" Then Exit Sub '表示仅获焦点，没有修改
'    Dim sCode As String, sName As String
'    Dim strSql As String
'    sCode = "cGroupCode"
'    strSql = "select  cGroupCode,cGroupName,iGroupType from ComputationGroup where (cGroupCode='" + EdtGroup.Text + "'" _
'            + " or cGroupName='" + EdtGroup.Text + "') "
'    sName = "cGroupName"
'    If IfExist(m_SrvDB, g_oPub, sCode, sName, strSql, EdtGroup, True) = False Then
'        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_cgroupcode_name") '"不存在计量单位组编码或名称！"
'        Call ClearAll(EdtGroup)
'        EdtGroup.SetFocus
'        m_bSave = False
'    Else
'        Call ShowOtherUnit(EdtGroup.Tag, EdtUnit)
'    End If
'End Sub

'---------------------------------------------------
'服务对象：计量单位相关参照
'功能：取得参照数据（主要是编码和名称）
'参数：sGroupCode:计量单位组编码
'---------------------------------------------------
Private Sub ShowOtherUnit(ByVal sGroupCode As String, EdtUnit As U8Ref.RefEdit)
    Dim strSql As String
    Dim Rs As New ADODB.Recordset
    Dim RsTemp As New ADODB.Recordset
        
    If Trim(sGroupCode) = "" Then
        Exit Sub
    End If
    strSql = "select  * from ComputationUnit where cGroupCode='" + sGroupCode + "' order by cGroupCode ,iNumber" 'bMainUnit=1 and
    Set Rs = m_SrvDB.OpenX(strSql)
    If Rs.RecordCount >= 1 Then
        Set RsTemp = Filter(Rs, "bMainUnit=1")
        If RsTemp.RecordCount > 0 Then
            EdtUnit.Text = TxtValue(RsTemp.fields("cComunitCode").value) 'TxtValue(RsTemp.Fields("CComUnitName").value)
'            EdtUnit.Tag = TxtValue(RsTemp.Fields("cComunitCode").value)
'            EdtUnit.UToolTipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + EdtUnit.Tag
        End If
    End If
End Sub

Private Sub EdtcWUnit_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtcWUnit_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcWGroupCode, EdtcWUnit, 0, sXMLFilterPara, sSQL, Cancel)
End Sub

'--------------------------------------------------------------
'功能：计量单位参照条件
'参数：
'       iRetUnitType：需要返回参照的类型：0：辅计量 1：主计量；2：主辅计量
'--------------------------------------------------------------
Private Sub UnitBeforeBrowse(GroupCon As Control, UnitCon As Control, iRetUnitType As Integer, sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    If m_bFilling = True Then Exit Sub
    If WriteFirstGroup(GroupCon, UnitCon, True) = False Then
        Cancel = True
        Exit Sub
    End If
    sXMLFilterPara = "<RefConditions><Condition paramName='@cGroupCode' paramValue='" + GroupCon.Text + "' />"
    sXMLFilterPara = sXMLFilterPara + "</RefConditions>"
End Sub

Private Sub EdtcWUnit_Change()
    Call WriteFirstGroup(EdtcWGroupCode, EdtcWUnit, False)
'    If UserControl.ActiveControl Is EdtcWUnit Then
'        Call ClearTip(EdtcWUnit)
'    End If
End Sub

'---------------------------------------
'功能：先添加组号
'参数：Unitcon：计量单位Edit
'---------------------------------------
Private Function WriteFirstGroup(GroupCon, UnitCon As Control, bRefing As Boolean) As Boolean
    On Error Resume Next
    WriteFirstGroup = True
    If bRefing = False Then '点击参照时不检查
        If Len(UnitCon.Text) >= 2 Then
            Exit Function '控制一次输入多个汉字
        End If
        If UnitCon.DisplayText = "" Then Exit Function
    End If
    If Trim(GroupCon.Text) = "" Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.firstselgroup") '"请先添加计量单位组！"
        GroupCon.SetFocus
        UnitCon.Clear
        WriteFirstGroup = False
    End If
End Function

Private Sub EdtcWUnit_LostFocus()
'    If (UserControl.ActiveControl Is Cmd(1)) Then Exit Sub
'    Call CheckUnit(EdtcWGroupCode, EdtcWUnit)
End Sub

Private Sub CheckUnit(EdtGroup As Edit, EdtUnit As Edit)
    On Error GoTo Err_Info
    Dim sCode As String
    Dim sName As String
    Dim strSql As String
    If EdtUnit.Tag <> "" Then Exit Sub '表示仅获焦点，没有修改
    If (EdtGroup.Text = "") Or (EdtUnit = "") Then  '
        EdtUnit = ""
        Exit Sub
    End If
    sCode = "CComunitCode"
    strSql = "select CComunitCode,CComUnitName from ComputationUnit where  cGroupCode='" + EdtGroup.Tag + "'" + _
                " and (CComunitCode='" + EdtUnit.Text + "'" + _
                " or CComUnitName='" + EdtUnit.Text + "')" 'bMainUnit=1 and
    sName = "CComUnitName"
    If IfExist(m_SrvDB, g_oPub, sCode, sName, strSql, EdtUnit) = False Then
        ReDim g_arr(1)
        g_arr(1) = EdtGroup.Text
        ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.grp_no_unit", g_arr) '"计量单位组({0})中不存在该计量单位！"
        'Call ClearAll(EdtUnit)
        EdtUnit.SetFocus
        m_bSave = False
    End If
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub



Private Sub EdtdEDate_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtdSDate_ActiveSaveBtn()
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub EdtfGrossW_LostFocus()
    Call CheckWeight(EdtfGrossW)
    Call g_oPub.FormatCon(EdtfGrossW)
End Sub

Private Sub EdtfHeight_LostFocus()
    Call g_oPub.FormatCon(EdtfHeight)
    Call ComputeVolume
End Sub

'-------------------------------------
'功能：单位体积默认=长*宽*高
'-------------------------------------
Private Sub ComputeVolume()
    If Len(EdtiVolume.Text) = 0 Then
        If Len(EdtfLength.Text) > 0 And Len(EdtfWidth.Text) > 0 And Len(EdtfHeight.Text) > 0 Then
            EdtiVolume.Text = val(EdtfLength.Text) * val(EdtfWidth.Text) * val(EdtfHeight.Text)
            Call g_oPub.FormatCon(EdtiVolume)
        End If
    End If
End Sub

Private Sub EdtfLength_LostFocus()
    Call g_oPub.FormatCon(EdtfLength)
    Call ComputeVolume
End Sub

Private Sub EdtfWidth_LostFocus()
    Call g_oPub.FormatCon(EdtfWidth)
    Call ComputeVolume
End Sub

Private Sub EdtiInvWeight_LostFocus()
    Call CheckWeight(EdtiInvWeight)
    Call g_oPub.FormatCon(EdtiInvWeight)
End Sub

Private Sub CheckWeight(Con As Edit)
    On Error GoTo Err_Info
    If Len(Con.Text) > 0 And Len(EdtcWUnit.Text) = 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.OTHER.239_1") 'U8.AA.U8TABPAGES.OTHER.239_1="没有输入重量单位！"
    End If
    If Len(EdtiInvWeight.Text) > 0 And Len(EdtfGrossW.Text) > 0 Then
        If CDbl(EdtiInvWeight.Text) > CDbl(EdtfGrossW.Text) Then
            ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.OTHER.243_1") 'U8.AA.U8TABPAGES.OTHER.243_1="净重不得大于毛重！"
            Con.Text = "" ' 防止循环
            Con.SetFocus
        End If
    End If
    Exit Sub
Err_Info:
    
End Sub

Public Function Init870(oLogin As Object, SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Set m_oLogin = oLogin
    Init870 = Init(SrvDB, oPub, sXml)
    Call InitRef
End Function

Private Sub InitRef()
    Call EdtcWGroupCode.Init(m_oLogin, m_URL + "ComputationGroup_AA", m_bWeb)
    Call EdtcWUnit.Init(m_oLogin, m_URL + "ComputationUnit_AA", m_bWeb)
    Call EdtcVGroupCode.Init(m_oLogin, m_URL + "ComputationGroup_AA", m_bWeb)
    Call EdtcVUnit.Init(m_oLogin, m_URL + "ComputationUnit_AA", m_bWeb)
    Call EdtcInvProjectCode.Init(m_oLogin, m_URL + "PA_REF_ATP_PA", m_bWeb)
End Sub

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
    'Call g_oPub.UCtrlLayout(GetControls, "U8.AA.ARCHIVE.TABPAGES.InvOther")
    Call UserControl_Resize
    
    Call g_oPub.SetLabelCaption(m_SrvDB, UserControl.Controls, "Inventory")
    Call g_oPub.SetConPosition(UserControl.Controls)
    LblcWGroupCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cwgroupcode")
    LblcWUnit.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cwunit")
    LblcVGroupCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cvgroupcode")
    LblcVUnit.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cvunit")
    Call g_oPub.RemoveCodeCaption(LblcInvProjectCode)
    
    ReDim iRecipeBatchItems(0 To 3)
    iRecipeBatchItems(0) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch0") ' "都不是"
    iRecipeBatchItems(1) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch1") ' "处方药"
    iRecipeBatchItems(2) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch2_861") ' "甲类非处方药"
    iRecipeBatchItems(3) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.irecipebatch3") ' "乙类非处方药"


    ChkIRecipeBatch(0).Caption = iRecipeBatchItems(1)
    ChkIRecipeBatch(1).Caption = iRecipeBatchItems(2)
    ChkIRecipeBatch(2).Caption = iRecipeBatchItems(3)
    
    CmbiWarrantyUnit.AddItem ""
    CmbiWarrantyUnit.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cmassunit1") '"年"
    CmbiWarrantyUnit.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cmassunit2") '"月"
    CmbiWarrantyUnit.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cmassunit3") '"日"
    CmbiWarrantyUnit.ListIndex = 0
    
    Call g_oPub.UtoLCase(sXml)
    m_cUserName = GetParaVal(sXml, "g_cUserName")
    m_CurDate = GetParaVal(sXml, "g_CurDate")
    m_DbSrvDate = GetParaVal(sXml, "g_DbSrvDate")
    m_iWeightDecDgt = GetParaVal(sXml, "g_iWeightDecDgt", "6")
    m_iVolumeDecDgt = GetParaVal(sXml, "g_iVolumeDecDgt", "6")
    m_URL = GetParaVal(sXml, "url")
    m_bWeb = IIf(GetParaVal(sXml, "bweb") = "1", True, False)
    m_frmMainhWnd = CLng(GetParaVal(sXml, "hwnd", "0"))
    If m_frmMainhWnd = 0 Then
        ShowMsg "no main hwnd!" '基本不会出现该消息，但防止出现错误，以便自己测试使用
    End If
    Call InitFace(CLng(GetParaVal(sXml, "HelpContextId", "0")))
    
    m_dSDateRW = 2 '【启用日期】读写权限：0：读写无；1：读权限；2：写权限
    
    EdtiInvWeight.BadStrEx = "-" '单位重量不能小于零!"
    EdtiVolume.BadStrEx = "-" '单位体积不能小于零!"
    LabdSDate.ForeColor = g_oPub.MustInputColor
    
    PicMedicine.Visible = IIf(GetParaVal(sXml, "g_BShowMedicineTab870") = "1", True, False)
    
    
    
    
'    Call g_oPub.SetBadStrException(EdtcWGroupCode)
'    Call g_oPub.SetBadStrException(EdtcWUnit)
'    Call g_oPub.SetBadStrException(EdtcVGroupCode)
'    Call g_oPub.SetBadStrException(EdtcVUnit)
    
    'EdtdSDate.Text = Date
    
    Init = True
    Exit Function
Err_Info:
    Init = False
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
                Con.Font.Name = g_oPub.FontName ' "宋体" '"MS Sans Serif" '
                Con.Font.Size = g_oPub.FontSize ' 9 '小五号字
                Con.Font.Charset = g_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            
            If TypeOf Con Is Edit Or LCase(Left(Con.Name, 3)) = "edt" Then
                'Con.BadStr = g_oPub.BadStr
                If Con.Property = EditStr Then
                   Con.Property = EditNormal '允许输入空格
                End If
                Con.HelpContextId = HelpContextId
            ElseIf TypeOf Con Is SuperGrid Then
                Con.SetFilterString (g_oPub.BadStr)
            End If
        Next
    End With
'    Dim i As Integer
'    For i = 0 To CmdDate.UBound
'        CmdDate(i).Picture = LoadResPicture(108, 0)
'    Next i
'    For i = 0 To Cmd.UBound
'        Cmd(i).Picture = g_oPub.GetRes(101) 'LoadResPicture(118, 0)
'    Next i
End Sub


Private Sub EdtiVolume_LostFocus()
    Call g_oPub.FormatCon(EdtiVolume)
    If Len(EdtiVolume.Text) > 0 And Len(EdtcVUnit.Text) = 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.OTHER.324_1") 'U8.AA.U8TABPAGES.OTHER.324_1="没有录入体积单位！"
    End If
End Sub

Private Sub EdtiWarrantyPeriod_Change()
    If Len(EdtiWarrantyPeriod.Text) > 0 And Len(CmbiWarrantyUnit.Text) = 0 Then
        '保修期输入，则保修期单位不可空，默认日
        CmbiWarrantyUnit.ListIndex = 3
    End If
End Sub

Private Sub UserControl_Initialize()
    
    UserControl.KeyPreview = False
End Sub

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
   If UserControl.Ambient.UserMode = True Then
      UFFrmKeyHook.Attach
   End If
End Sub

''---------------------------------------
''功能：调用相应的参照
''---------------------------------------
'Private Sub RefClick()
'    On Error Resume Next '防止UserControl.ActiveControl is Nothing
'    Select Case UserControl.ActiveControl.Name
'        Case EdtdSDate.Name
'            Call CmdDate_Click(0)
'        Case EdtdEDate.Name
'            Call CmdDate_Click(1)
'        Case EdtcWGroupCode.Name
'            Call Cmd_Click(0)
'        Case EdtcWUnit.Name
'            Call Cmd_Click(1)
'        Case EdtcVGroupCode.Name
'            Call Cmd_Click(2)
'        Case EdtcVUnit.Name
'            Call Cmd_Click(3)
'    End Select
'End Sub

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
        If LCase(Left(UserControl.ActiveControl.Name, 3)) = "edt" Or TypeOf UserControl.ActiveControl Is UFCOMBOBOXLib.UFComboBox Or TypeOf UserControl.ActiveControl Is UFCHECKBOXLib.UFCheckBox Then
            Select Case (UserControl.ActiveControl.Name)
                Case EdtcQuality.Name
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
    m_dSDateRW = 2 '【启用日期】读写权限：0：读写无；1：读权限；2：写权限
    m_sRFldAuthInv = sRFldAuthInv
    m_sNFldAuthInv = sNFldAuthInv
    '其它
    Call ConSet(EdtcWGroupCode, "cWGroupCode")
    Call ConSet(EdtcWUnit, "cWUnit")
    Call ConSet(EdtiInvWeight, "iInvWeight")
    Call ConSet(EdtfGrossW, "fGrossW")
    Call ConSet(EdtcVGroupCode, "cVGroupCode")
    Call ConSet(EdtcVUnit, "cVUnit")
    Call ConSet(EdtiVolume, "iVolume")
    Call ConSet(EdtfLength, "fLength")
    Call ConSet(EdtfWidth, "fWidth")
    Call ConSet(EdtfHeight, "fHeight")
    m_dSDateRW = ConSet(EdtdSDate, "dSDate")
    Call ConSet(EdtdEDate, "dEDate")
    Call ConSet(EdtcQuality, "cQuality")
    Call ConSet(EdtcInvAppDocNo, "cInvAppDocNo")
    Call ConSet(EdtCCreatePerson, "CCreatePerson")
    Call ConSet(EdtiId, "iId")
    Call ConSet(EdtcModifyPerson, "cModifyPerson")
    Call ConSet(EdtDModifyDate, "dModifyDate")
    Call ConSet(EdtdInvCreateDatetime, "dInvCreateDatetime")
    Call ConSet(EdtcInvProjectCode, "cInvProjectCode")
    
    Call ConSet(ChkbImportMedicine, "bImportMedicine")
    Call ConSet(chkbCheckBSATP, "bCheckBSATP")
    Call ConSet(chkbPUQuota, "bPUQuota")
    Call ConSet(ChkbFirstBusiMedicine, "bFirstBusiMedicine")
    Call ConSet(ChkbSpecialties, "bSpecialties")
    Call ConSet(ChkIRecipeBatch(0), "iRecipeBatch")
    Call ConSet(ChkIRecipeBatch(1), "iRecipeBatch")
    Call ConSet(ChkIRecipeBatch(2), "iRecipeBatch")
    Call ConSet(EdtcFile, "cFile")
    Call ConSet(EdtcLabel, "cLabel")
    Call ConSet(EdtcCheckOut, "cCheckOut")
    Call ConSet(EdtcLicence, "cLicence")
'    Call ConSet(EdtCEnglishName, "CEnglishName")
    Call ConSet(EdtcPreparationType, "cPreparationType")
    Call ConSet(EdtCPackingType, "CPackingType")
    Call ConSet(EdtCEnterNo, "CEnterNo")
    Call ConSet(EdtCRegisterNo, "CRegisterNo")
    Call ConSet(EdtCCommodity, "CCommodity")
    Call ConSet(EdtCNotPatentName, "CNotPatentName")
    Call ConSet(EdtiWarrantyPeriod, "iWarrantyPeriod")
    Call ConSet(CmbiWarrantyUnit, "iWarrantyUnit")
'
'    CmdDate(0).Enabled = EdtdSDate.Enabled
'    CmdDate(1).Enabled = EdtdEDate.Enabled
'
'    Cmd(0).Enabled = EdtcWGroupCode.Enabled
'    Cmd(1).Enabled = EdtcWUnit.Enabled
'    Cmd(2).Enabled = EdtcVGroupCode.Enabled
'    Cmd(3).Enabled = EdtcVUnit.Enabled

End Sub

'------------------------------------------
'功能：设置字段编辑长度(规定接口)
'参数： Rs：            数据结构数据集
'       iQuanDecDgt：   数量数据精度
'------------------------------------------
Public Sub SetFldLength(Rs As ADODB.Recordset, iQuanDecDgt As Integer)
    m_iQuanDecDgt = iQuanDecDgt
    
    EdtcQuality.MaxLength = Rs.fields("cQuality").DefinedSize '100
    
    
    EdtcWGroupCode.MaxLength = 0 ' Rs.fields("cGroupName").DefinedSize
    EdtcWUnit.MaxLength = 0 ' Rs.fields("CComUnitName").DefinedSize
    
    EdtcVGroupCode.MaxLength = 0 ' Rs.fields("cGroupName").DefinedSize
    EdtcVUnit.MaxLength = 0 ' Rs.fields("CComUnitName").DefinedSize
    EdtcInvProjectCode.MaxLength = 200
    
    g_oPub.SetDblLen EdtiInvWeight, , m_iWeightDecDgt ' 6 'iQuanDecDgt
    g_oPub.SetDblLen EdtfGrossW, , m_iWeightDecDgt '6 'iQuanDecDgt
    
    g_oPub.SetDblLen EdtiVolume, , m_iVolumeDecDgt '6 'iQuanDecDgt
    g_oPub.SetDblLen EdtfLength, , m_iVolumeDecDgt  '6 ' iQuanDecDgt
    g_oPub.SetDblLen EdtfWidth, , m_iVolumeDecDgt   '6'iQuanDecDgt
    g_oPub.SetDblLen EdtfHeight, , m_iVolumeDecDgt  '6 'iQuanDecDgt
        
            
    EdtcFile.MaxLength = Rs.fields("cFile").DefinedSize '
    EdtcLabel.MaxLength = Rs.fields("cLabel").DefinedSize '
    EdtcCheckOut.MaxLength = Rs.fields("cCheckOut").DefinedSize '
    EdtcLicence.MaxLength = Rs.fields("cLicence").DefinedSize '
    
    
    EdtcPreparationType.MaxLength = Rs.fields("cPreparationType").DefinedSize
    EdtCPackingType.MaxLength = Rs.fields("CPackingType").DefinedSize
    EdtCEnterNo.MaxLength = Rs.fields("CEnterNo").DefinedSize
    EdtCRegisterNo.MaxLength = Rs.fields("CRegisterNo").DefinedSize
    EdtCCommodity.MaxLength = Rs.fields("CCommodity").DefinedSize
    EdtCNotPatentName.MaxLength = Rs.fields("CNotPatentName").DefinedSize
    Call g_oPub.SetIntLen(EdtiWarrantyPeriod)
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
    EdtDModifyDate.Text = m_DbSrvDate ' CStr(Date)
    EdtdInvCreateDatetime.Text = m_DbSrvDate
    EdtdSDate.Text = m_CurDate ' CStr(Date)
    If EdtdSDate.Locked = False Then '修改状态改为增加状态，改变控件活动状态
        EdtdSDate.Enabled = True
'        CmdDate(1).Visible = True
    End If
'    CmdDate(1).Enabled = EdtdSDate.Enabled
    Call AuthShow(Nothing, 1)
End Sub

'-----------------------------------------
'功能：拷贝时部分字段内容操作
'-----------------------------------------
Public Sub CopyOpera()
    EdtiId = ""
    EdtCCreatePerson = m_cUserName
    EdtcModifyPerson = m_cUserName
    EdtDModifyDate.Text = m_DbSrvDate ' CStr(Date)
    EdtdInvCreateDatetime.Text = m_DbSrvDate
    If m_dSDateRW = 2 Then
        EdtdSDate.Enabled = True
'        CmdDate(0).Visible = True
    End If
End Sub

'-----------------------------------------------
'功能：完成填充所有字段内容的过程(规定接口)
'传入的参数：RsCard：需求填写的数据源（数据集）
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    m_bFilling = True
    
    
    EdtdSDate = Format(TxtValue(RsCard!dSDate), "yyyy-mm-dd")
    EdtdEDate = Format(TxtValue(RsCard!dEDate), "yyyy-mm-dd")
    
    EdtiInvWeight = g_oPub.FormatNum((RsCard!iinvweight), m_iWeightDecDgt) 'm_iQuanDecDgt
    EdtfGrossW.Text = g_oPub.FormatNum((RsCard!fGrossW), m_iWeightDecDgt) 'm_iQuanDecDgt
    
    EdtiVolume = g_oPub.FormatNum((RsCard!iVolume), m_iVolumeDecDgt) 'm_iQuanDecDgt
    EdtfLength.Text = g_oPub.FormatNum((RsCard!fLength), m_iVolumeDecDgt) 'm_iQuanDecDgt
    EdtfWidth.Text = g_oPub.FormatNum((RsCard!fWidth), m_iVolumeDecDgt) 'm_iQuanDecDgt
    EdtfHeight.Text = g_oPub.FormatNum((RsCard!fHeight), m_iVolumeDecDgt) 'm_iQuanDecDgt
    
    EdtcQuality = TxtValue(RsCard!cQuality)
    EdtcInvAppDocNo.Text = TxtValue(RsCard!cInvAppDocNo)
        
    Call AuthShow(RsCard, 2)
    EdtDModifyDate.Text = TxtValue(RsCard!dModifyDate)
    EdtdInvCreateDatetime.Text = TxtValue(RsCard!dInvCreateDatetime)
    
    Dim sGroupCode As String
    Dim sUnitCode As String
'    sGroupCode = TxtValue(RsCard!cWGroupCode)
'    Call WriteGroup(m_SrvDB, EdtcWGroupCode, sGroupCode)
    EdtcWGroupCode.Text = TxtValue(RsCard!cWGroupCode)
    EdtcWUnit.Text = TxtValue(RsCard!cWUnit)
'    sUnitCode = TxtValue(RsCard!cWUnit)
'    Call WriteUnit(m_SrvDB, EdtcWUnit, sUnitCode)
    
    
    EdtcVGroupCode.Text = TxtValue(RsCard!cVGroupCode)
    EdtcVUnit.Text = TxtValue(RsCard!cVUnit)
'    sGroupCode = TxtValue(RsCard!cVGroupCode)
'    Call WriteGroup(m_SrvDB, EdtcVGroupCode, sGroupCode)
'    sUnitCode = TxtValue(RsCard!cVUnit)
'    Call WriteUnit(m_SrvDB, EdtcVUnit, sUnitCode)
    
    EdtcInvProjectCode.Text = TxtValue(RsCard!cInvProjectCode)
    
    ChkbImportMedicine.value = ChkValue(RsCard!bImportMedicine)
    chkbCheckBSATP.value = ChkValue(RsCard!bCheckBSATP)
    chkbPUQuota.value = ChkValue(RsCard!bPUQuota)
    ChkbFirstBusiMedicine.value = ChkValue(RsCard!bFirstBusiMedicine)
    ChkbSpecialties.value = ChkValue(RsCard!bSpecialties)
    
    ChkIRecipeBatch(0).value = 0
    ChkIRecipeBatch(1).value = 0
    ChkIRecipeBatch(2).value = 0
    Select Case TxtValue(RsCard!iRecipeBatch)
        Case 1
            ChkIRecipeBatch(0).value = 1
        Case 2
            ChkIRecipeBatch(1).value = 1
        Case 3
            ChkIRecipeBatch(2).value = 1
    End Select
    
    
    
    EdtcFile = TxtValue(RsCard!cFile)
    EdtcLabel = TxtValue(RsCard!cLabel)
    EdtcCheckOut = TxtValue(RsCard!cCheckOut)
    EdtcLicence = TxtValue(RsCard!cLicence)
    EdtcPreparationType = TxtValue(RsCard.fields("cPreparationType"))
    EdtCPackingType = TxtValue(RsCard.fields("CPackingType"))
    EdtCEnterNo = TxtValue(RsCard.fields("CEnterNo"))
    EdtCRegisterNo = TxtValue(RsCard.fields("CRegisterNo"))
    EdtCCommodity = TxtValue(RsCard.fields("CCommodity"))
    EdtCNotPatentName = TxtValue(RsCard.fields("CNotPatentName"))
    EdtiWarrantyPeriod = TxtValue(RsCard.fields("iWarrantyPeriod"))
    CmbiWarrantyUnit.ListIndex = TxtValue(RsCard.fields("iWarrantyUnit").value, 0)
    
    If Len(EdtdSDate.Text) > 0 Then '由于业务组传部分数据，然后增加数据，暂时采用此方案
        EdtdSDate.Enabled = False
    End If
    m_bFilling = False
'    CmdDate(0).Visible = False
End Sub

'---------------------------------------
'服务对象：用于读取,修改,添加（OPt＝1）
'功能：显示权限相关的内容
'---------------------------------------
Private Sub AuthShow(RsCard As ADODB.Recordset, opt As Integer)
    Dim sCode As String
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    If opt = 1 Or (RsCard Is Nothing) Then
        EdtCCreatePerson = CStr(m_cUserName)
    Else
        EdtCCreatePerson.Text = TxtValue(RsCard!CCreatePerson)
    End If
    
    If opt = 1 Or (RsCard Is Nothing) Then
        EdtiId = ""
    Else
        sCode = CStr(TxtValue(RsCard!iId))
        If sCode = "" Then
            EdtiId = ""
        Else
            strSql = "select top 1 cACName from aa_authclass where cBusObId='Inventory' and Id=" + sCode
            Set Rs = m_SrvDB.OpenX(strSql)
            
            EdtiId = TxtValue(Rs!cACName) 'TxtValue(RsCard!iId) 'CAuthCCode
        End If
    End If
    If opt = 1 Or (RsCard Is Nothing) Then
        EdtcModifyPerson = m_cUserName
    Else
        EdtcModifyPerson.Text = TxtValue(RsCard!cModifyPerson)
    End If
End Sub

'-----------------------------------------
'功能：获得保存的字符串(规定接口)
'参数： bFlag： 是否正确
'返回： 保存的Xml字符串
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim sXml As String
    Call g_oPub.CheckValid(UserControl.ActiveControl)
    sXml = sXml + "<cWGroupCode>" + EdtcWGroupCode.Text + "</cWGroupCode>"
    sXml = sXml + "<cWUnit>" + EdtcWUnit.Text + "</cWUnit>"
    Call EleXML(sXml, "iinvweight", EdtiInvWeight)
    Call EleXML(sXml, "fGrossW", EdtfGrossW)
    sXml = sXml + "<cVGroupCode>" + EdtcVGroupCode.Text + "</cVGroupCode>"
    sXml = sXml + "<cVUnit>" + EdtcVUnit.Text + "</cVUnit>"
    Call EleXML(sXml, "ivolume", EdtiVolume)
    Call EleXML(sXml, "fLength", EdtfLength)
    Call EleXML(sXml, "fWidth", EdtfWidth)
    Call EleXML(sXml, "fHeight", EdtfHeight)
    sXml = sXml + "<dSDate>" + EdtdSDate.Text + "</dSDate>"
    Call EleXML(sXml, "dEDate", EdtdEDate)
    
    Call EleXML(sXml, "cQuality", EdtcQuality)
    
    Call EleXML(sXml, "cFile", EdtcFile)
    Call EleXML(sXml, "cLabel", EdtcLabel)
    Call EleXML(sXml, "cCheckOut", EdtcCheckOut)
    Call EleXML(sXml, "cLicence", EdtcLicence)
                
    
    Call EleXML(sXml, "cPreparationType", EdtcPreparationType)
    Call EleXML(sXml, "CPackingType", EdtCPackingType)
    Call EleXML(sXml, "CEnterNo", EdtCEnterNo)
    Call EleXML(sXml, "CRegisterNo", EdtCRegisterNo)
    Call EleXML(sXml, "CCommodity", EdtCCommodity)
    Call EleXML(sXml, "CNotPatentName", EdtCNotPatentName)
    Call EleXML(sXml, "iWarrantyPeriod", EdtiWarrantyPeriod)
    sXml = sXml + "<iWarrantyUnit>" + CStr(CmbiWarrantyUnit.ListIndex) + "</iWarrantyUnit>"
    sXml = sXml + "<cInvProjectCode>" + EdtcInvProjectCode.Text + "</cInvProjectCode>"
    
    Call EleXML(sXml, "bSpecialties", ChkbSpecialties)
    Call EleXML(sXml, "bImportMedicine", ChkbImportMedicine)
    Call EleXML(sXml, "bCheckBSATP", chkbCheckBSATP)
    Call EleXML(sXml, "bPUQuota", chkbPUQuota)
    Call EleXML(sXml, "bFirstBusiMedicine", ChkbFirstBusiMedicine)
    Dim i As Integer
    If ChkIRecipeBatch(0).value = 1 Then
        i = 1
    ElseIf ChkIRecipeBatch(1).value = 1 Then
        i = 2
    ElseIf ChkIRecipeBatch(2).value = 1 Then
        i = 3
    Else
        i = 0
    End If
    sXml = sXml + "<IRecipeBatch>" + CStr(i) + "</IRecipeBatch>"
    
    
    GetSaveXml = sXml
End Function

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
'        Case EdtcWGroupCode.Name
'            EdtcWGroupCode_LostFocus
'        Case EdtcWUnit.Name
'            EdtcWUnit_LostFocus
'        Case EdtcVGroupCode.Name
'            EdtcVGroupCode_LostFocus
'        Case EdtcVUnit.Name
'            EdtcVUnit_LostFocus
'    End Select
    CheckLostFocus = m_bSave
End Function
    
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


Private Sub ChkIRecipeBatch_Click(Index As Integer)
    If ChkIRecipeBatch(Index).value = 1 Then
       If Index <> 0 Then ChkIRecipeBatch(0).value = 0
       If Index <> 1 Then ChkIRecipeBatch(1).value = 0
       If Index <> 2 Then ChkIRecipeBatch(2).value = 0
    End If
    RaiseEvent ActiveSaveBtn
End Sub

Public Sub SetActiveFocus()
    On Error Resume Next
    UserControl.SetFocus
End Sub

Public Property Get bPUQuota() As Integer
    bPUQuota = chkbPUQuota.value
End Property

Public Property Let bPUQuota(value As Integer)
    chkbPUQuota.value = value
End Property

Public Property Get Caption_bPUQuota() As String
    Caption_bPUQuota = chkbPUQuota.Caption
End Property



