VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Object = "{9ADF72AD-DDA9-11D1-9D4B-000021006D51}#1.31#0"; "UFSpGrid.ocx"
Object = "{5F8E85F7-32E2-43D8-A32E-BE8ED3DEFE32}#1.21#0"; "U8TabPages.ocx"
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Object = "{BF022F1C-E440-4790-987F-252926B9B602}#5.1#0"; "UFFrames.ocx"
Object = "{201FB79B-5556-47A4-AD9C-A46BA0C45A44}#6.26#0"; "UFToolBarCtrl.ocx"
Object = "{4C2F9AC0-6D40-468A-8389-518BB4F8C67D}#1.0#0"; "UFComboBox.ocx"
Object = "{A98B9C82-88D8-4F94-91BB-F2289111C59C}#1.0#0"; "UFCheckBox.ocx"
Object = "{005151D4-33F6-471B-B651-222D4E411832}#4.4#0"; "UFFormPartner.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Object = "{9DA60CE7-D0E4-495E-BDFB-1FA0DCBA014D}#3.4#0"; "U8Picture.ocx"
Object = "{5E4640D0-A415-404B-A457-72980C429D2F}#10.25#0"; "U8RefEdit.ocx"
Begin VB.Form FrmZAM 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Dialog Caption"
   ClientHeight    =   9150
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   11670
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   9150
   ScaleWidth      =   11670
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin U8TabPages.ShowKeyInfo ShowKeyInfo1 
      Height          =   330
      Left            =   45
      TabIndex        =   260
      Top             =   720
      Width           =   11595
      _ExtentX        =   20452
      _ExtentY        =   582
   End
   Begin UFFrames.UFFrame Frame6 
      Height          =   30
      Left            =   -240
      TabIndex        =   155
      Top             =   645
      Width           =   14145
      _ExtentX        =   24950
      _ExtentY        =   53
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin TabDlg.SSTab SSTab1 
      Height          =   7590
      Left            =   45
      TabIndex        =   125
      Top             =   1050
      Width           =   11580
      _ExtentX        =   20426
      _ExtentY        =   13388
      _Version        =   393216
      Style           =   1
      Tabs            =   13
      TabsPerRow      =   13
      TabHeight       =   520
      TabCaption(0)   =   "����"
      TabPicture(0)   =   "FrmZAM.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "UFFrameProperty"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "chkbSrvItem"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "ChkbSrvFittings"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "chkbPiece"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "ChkbATOModel"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "ChkbPTOModel"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "ChkbInvType"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "ChkbSelf"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "ChkbSale"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "ChkbCheckItem"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "ChkbAccessary"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "ChkbInvEntrust"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "ChkbPlanInv"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).Control(13)=   "ChkbProducing"
      Tab(0).Control(13).Enabled=   0   'False
      Tab(0).Control(14)=   "ChkbComsume"
      Tab(0).Control(14).Enabled=   0   'False
      Tab(0).Control(15)=   "ChkbService"
      Tab(0).Control(15).Enabled=   0   'False
      Tab(0).Control(16)=   "ChkbProxyForeign"
      Tab(0).Control(16).Enabled=   0   'False
      Tab(0).Control(17)=   "ChkbEquipment"
      Tab(0).Control(17).Enabled=   0   'False
      Tab(0).Control(18)=   "ChkbInvModel"
      Tab(0).Control(18).Enabled=   0   'False
      Tab(0).Control(19)=   "chkbExpSale"
      Tab(0).Control(19).Enabled=   0   'False
      Tab(0).Control(20)=   "ChkbPurchase"
      Tab(0).Control(20).Enabled=   0   'False
      Tab(0).Control(21)=   "chkbBondedInv"
      Tab(0).Control(21).Enabled=   0   'False
      Tab(0).Control(22)=   "UFFrame2"
      Tab(0).Control(22).Enabled=   0   'False
      Tab(0).Control(23)=   "chkbSrvProduct"
      Tab(0).Control(23).Enabled=   0   'False
      Tab(0).Control(24)=   "chkbInvAsset"
      Tab(0).Control(24).Enabled=   0   'False
      Tab(0).Control(25)=   "chkbPrjMat"
      Tab(0).Control(25).Enabled=   0   'False
      Tab(0).ControlCount=   26
      TabCaption(1)   =   "�ɱ�"
      TabPicture(1)   =   "FrmZAM.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "Frame1(1)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).ControlCount=   1
      TabCaption(2)   =   "����"
      TabPicture(2)   =   "FrmZAM.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "Frame1(2)"
      Tab(2).Control(0).Enabled=   0   'False
      Tab(2).ControlCount=   1
      TabCaption(3)   =   "����"
      TabPicture(3)   =   "FrmZAM.frx":0054
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "InvOther1"
      Tab(3).Control(0).Enabled=   0   'False
      Tab(3).ControlCount=   1
      TabCaption(4)   =   "�ƻ�"
      TabPicture(4)   =   "FrmZAM.frx":0070
      Tab(4).ControlEnabled=   0   'False
      Tab(4).Control(0)=   "InvPlan1"
      Tab(4).Control(0).Enabled=   0   'False
      Tab(4).Control(1)=   "Frame1(4)"
      Tab(4).Control(1).Enabled=   0   'False
      Tab(4).ControlCount=   2
      TabCaption(5)   =   "�Զ���"
      TabPicture(5)   =   "FrmZAM.frx":008C
      Tab(5).ControlEnabled=   0   'False
      Tab(5).Control(0)=   "Frame1(5)"
      Tab(5).Control(0).Enabled=   0   'False
      Tab(5).ControlCount=   1
      TabCaption(6)   =   "��������"
      TabPicture(6)   =   "FrmZAM.frx":00A8
      Tab(6).ControlEnabled=   0   'False
      Tab(6).Control(0)=   "InvBatchProperty1"
      Tab(6).Control(0).Enabled=   0   'False
      Tab(6).Control(1)=   "Frame1(6)"
      Tab(6).Control(1).Enabled=   0   'False
      Tab(6).ControlCount=   2
      TabCaption(7)   =   "����"
      TabPicture(7)   =   "FrmZAM.frx":00C4
      Tab(7).ControlEnabled=   0   'False
      Tab(7).Control(0)=   "Frame1(7)"
      Tab(7).Control(0).Enabled=   0   'False
      Tab(7).Control(1)=   "lblcDTPeriod"
      Tab(7).Control(1).Enabled=   0   'False
      Tab(7).Control(2)=   "ChkbPeriodDT"
      Tab(7).Control(2).Enabled=   0   'False
      Tab(7).Control(3)=   "EdtcDTPeriod"
      Tab(7).Control(3).Enabled=   0   'False
      Tab(7).Control(4)=   "ChkBPropertyCheck"
      Tab(7).Control(4).Enabled=   0   'False
      Tab(7).Control(5)=   "ChkbDTWarnInv"
      Tab(7).Control(5).Enabled=   0   'False
      Tab(7).ControlCount=   6
      TabCaption(8)   =   "������"
      TabPicture(8)   =   "FrmZAM.frx":00E0
      Tab(8).ControlEnabled=   0   'False
      Tab(8).Control(0)=   "InvFree1"
      Tab(8).Control(0).Enabled=   0   'False
      Tab(8).ControlCount=   1
      TabCaption(9)   =   "MPS/MRP"
      TabPicture(9)   =   "FrmZAM.frx":00FC
      Tab(9).ControlEnabled=   0   'False
      Tab(9).Control(0)=   "InvMPS1"
      Tab(9).Control(0).Enabled=   0   'False
      Tab(9).ControlCount=   1
      TabCaption(10)  =   "ͼƬ"
      TabPicture(10)  =   "FrmZAM.frx":0118
      Tab(10).ControlEnabled=   0   'False
      Tab(10).Control(0)=   "Pic"
      Tab(10).ControlCount=   1
      TabCaption(11)  =   "��ҵ"
      TabPicture(11)  =   "FrmZAM.frx":0134
      Tab(11).ControlEnabled=   0   'False
      Tab(11).Control(0)=   "FramePlubIn"
      Tab(11).Control(0).Enabled=   0   'False
      Tab(11).ControlCount=   1
      TabCaption(12)  =   "����"
      TabPicture(12)  =   "FrmZAM.frx":0150
      Tab(12).ControlEnabled=   0   'False
      Tab(12).Control(0)=   "InvAttachfile1"
      Tab(12).ControlCount=   1
      Begin UFCHECKBOXLib.UFCheckBox chkbPrjMat 
         Height          =   195
         Left            =   9030
         TabIndex        =   38
         Top             =   6270
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "��������"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbInvAsset 
         Height          =   195
         Left            =   6435
         TabIndex        =   37
         Top             =   6270
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�ʲ�"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbSrvProduct 
         Height          =   195
         Left            =   9030
         TabIndex        =   43
         Top             =   6690
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�����Ʒ"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFFrames.UFFrame UFFrame2 
         Height          =   4290
         Left            =   150
         TabIndex        =   231
         Top             =   720
         Width           =   11355
         _ExtentX        =   20029
         _ExtentY        =   7567
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BorderStyle     =   0
         Begin U8Ref.RefEdit Edtcinvcode 
            Height          =   285
            Left            =   1350
            TabIndex        =   274
            Top             =   165
            Width           =   2295
            _ExtentX        =   4048
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
            MaxLength       =   12
         End
         Begin U8Ref.RefEdit EdtcCIQCode 
            Height          =   285
            Left            =   5490
            TabIndex        =   15
            Top             =   2361
            Width           =   2295
            _ExtentX        =   4048
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
            MaxLength       =   12
            RefType         =   1
         End
         Begin U8Ref.RefEdit EdtcGroupCode 
            Height          =   285
            Left            =   1350
            TabIndex        =   5
            Top             =   893
            Width           =   2295
            _ExtentX        =   4048
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
         Begin U8Ref.RefEdit EdtcInvCCode 
            Height          =   285
            Left            =   1350
            TabIndex        =   2
            Top             =   529
            Width           =   2295
            _ExtentX        =   4048
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
            MaxLength       =   12
            RefType         =   1
         End
         Begin MsSuperGrid.SuperGrid GridUnit 
            Height          =   2955
            Left            =   7980
            TabIndex        =   233
            Top             =   1200
            Width           =   3135
            _ExtentX        =   5530
            _ExtentY        =   5212
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            EditBorderStyle =   0
            Redraw          =   1
            HighLight       =   2
            GridColorFixed  =   -2147483632
            GridColor       =   -2147483633
            ForeColorSel    =   -2147483634
            ForeColorFixed  =   -2147483630
            BackColorSel    =   -2147483635
            BackColorFixed  =   -2147483633
            BackColorBkg    =   -2147483643
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbiGroupType 
            Height          =   315
            Left            =   5490
            TabIndex        =   6
            Top             =   887
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   556
            _StockProps     =   196
            Enabled         =   0   'False
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin EDITLib.Edit EdtiTaxRate 
            Height          =   285
            Left            =   1350
            TabIndex        =   18
            Top             =   3077
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   5
         End
         Begin U8Ref.RefEdit EdtcCAComunitCode 
            Height          =   285
            Left            =   5490
            TabIndex        =   13
            Top             =   2000
            Width           =   2295
            _ExtentX        =   4048
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
            MaxLength       =   20
            RefType         =   1
         End
         Begin U8Ref.RefEdit EdtcSAComunitCode 
            Height          =   285
            Left            =   5490
            TabIndex        =   11
            Top             =   1639
            Width           =   2295
            _ExtentX        =   4048
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
         Begin U8Ref.RefEdit EdtcSTComunitCode 
            Height          =   285
            Left            =   1350
            TabIndex        =   12
            Top             =   1985
            Width           =   2295
            _ExtentX        =   4048
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
            MaxLength       =   20
            RefType         =   1
         End
         Begin EDITLib.Edit EdtcInvStd 
            Height          =   285
            Left            =   8805
            TabIndex        =   1
            Top             =   165
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4057
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtcInvName 
            Height          =   285
            Left            =   5490
            TabIndex        =   0
            Top             =   165
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            MaxLength       =   60
         End
         Begin EDITLib.Edit EdtcInvAddCode 
            Height          =   285
            Left            =   5490
            TabIndex        =   3
            Top             =   526
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            MaxLength       =   25
         End
         Begin U8Ref.RefEdit EdtcPUComunitCode 
            Height          =   285
            Left            =   1350
            TabIndex        =   10
            Top             =   1621
            Width           =   2295
            _ExtentX        =   4048
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
         Begin U8Ref.RefEdit EdtcProductUnit 
            Height          =   285
            Left            =   5490
            TabIndex        =   9
            Top             =   1278
            Width           =   2295
            _ExtentX        =   4048
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
         Begin U8Ref.RefEdit EdtcShopUnit 
            Height          =   285
            Left            =   1350
            TabIndex        =   14
            Top             =   2349
            Width           =   2295
            _ExtentX        =   4048
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
         Begin UFLABELLib.UFLabel LblcShopUnit 
            Height          =   195
            Left            =   90
            TabIndex        =   234
            Top             =   2385
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ۼ�����λ"
         End
         Begin UFLABELLib.UFLabel LabcPUComunitCode 
            Height          =   195
            Left            =   90
            TabIndex        =   235
            Top             =   1635
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ɹ�Ĭ�ϵ�λ"
         End
         Begin UFLABELLib.UFLabel LblcSTComunitCode 
            Height          =   195
            Left            =   90
            TabIndex        =   240
            Top             =   2010
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���Ĭ�ϵ�λ"
         End
         Begin UFLABELLib.UFLabel LblcGroupCode 
            Height          =   195
            Left            =   90
            TabIndex        =   242
            Tag             =   "1"
            Top             =   900
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "������λ��"
         End
         Begin UFLABELLib.UFLabel Labcinvcode 
            Height          =   195
            Left            =   90
            TabIndex        =   243
            Tag             =   "1"
            Top             =   165
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�������"
         End
         Begin UFLABELLib.UFLabel LabcInvAddCode 
            Height          =   195
            Left            =   3990
            TabIndex        =   244
            Top             =   540
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�������"
         End
         Begin UFLABELLib.UFLabel LabiTaxRate 
            Height          =   195
            Left            =   90
            TabIndex        =   247
            Top             =   3105
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����˰��%"
         End
         Begin EDITLib.Edit EdtCEnglishName 
            Height          =   270
            Left            =   8805
            TabIndex        =   4
            Top             =   525
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   476
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtCcurrencyName 
            Height          =   285
            Left            =   8805
            TabIndex        =   7
            Top             =   855
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtcProduceAddress 
            Height          =   285
            Left            =   1350
            TabIndex        =   22
            Top             =   3810
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4057
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtCproduceNation 
            Height          =   285
            Left            =   1350
            TabIndex        =   20
            Top             =   3441
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin U8Ref.RefEdit EdtcEnterprise 
            Height          =   285
            Left            =   5490
            TabIndex        =   21
            Top             =   3444
            Width           =   2295
            _ExtentX        =   4048
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
            MaxLength       =   20
            RefType         =   1
         End
         Begin UFLABELLib.UFLabel LblcEnterprise 
            Height          =   195
            Left            =   3990
            TabIndex        =   252
            Top             =   3480
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "������ҵ"
         End
         Begin UFLABELLib.UFLabel LblcAddress 
            Height          =   195
            Left            =   3990
            TabIndex        =   253
            Top             =   3855
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����[ ���� ]"
         End
         Begin EDITLib.Edit EdtcAddress 
            Height          =   285
            Left            =   5490
            TabIndex        =   23
            Top             =   3810
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            MaxLength       =   20
         End
         Begin EDITLib.Edit EdtiImpTaxRate 
            Height          =   285
            Left            =   5490
            TabIndex        =   19
            Top             =   3083
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   5
         End
         Begin U8Ref.RefEdit EdtcComunitCode 
            Height          =   285
            Left            =   1350
            TabIndex        =   8
            Top             =   1257
            Width           =   2295
            _ExtentX        =   4048
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
         Begin UFLABELLib.UFLabel LabcComunitCode 
            Height          =   195
            Left            =   90
            TabIndex        =   241
            Tag             =   "1"
            Top             =   1275
            Width           =   1320
            _Version        =   65536
            _ExtentX        =   2328
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��������λ"
         End
         Begin UFLABELLib.UFLabel LbliImpTaxRate 
            Height          =   195
            Left            =   3990
            TabIndex        =   255
            Top             =   3105
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����˰��%"
         End
         Begin UFLABELLib.UFLabel LblcCIQCode 
            Height          =   195
            Left            =   3990
            TabIndex        =   254
            Top             =   2415
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ر���"
         End
         Begin UFLABELLib.UFLabel LblcProduceAddress 
            Height          =   195
            Left            =   90
            TabIndex        =   250
            Top             =   3840
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�����ص�"
         End
         Begin UFLABELLib.UFLabel LblCproduceNation 
            Height          =   195
            Left            =   90
            TabIndex        =   249
            Top             =   3480
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��������"
         End
         Begin UFLABELLib.UFLabel LblCEnglishName 
            Height          =   195
            Left            =   7980
            TabIndex        =   248
            Top             =   540
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "Ӣ������"
         End
         Begin UFLABELLib.UFLabel LabcInvName 
            Height          =   195
            Left            =   3990
            TabIndex        =   245
            Tag             =   "1"
            Top             =   165
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�������"
         End
         Begin UFLABELLib.UFLabel LblcSAComunitCode 
            Height          =   195
            Left            =   3990
            TabIndex        =   239
            Top             =   1635
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����Ĭ�ϵ�λ"
         End
         Begin UFLABELLib.UFLabel LbliGroupType 
            Height          =   195
            Left            =   3990
            TabIndex        =   238
            Top             =   900
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "������λ�����"
         End
         Begin UFLABELLib.UFLabel LblcCAComunitCode 
            Height          =   195
            Left            =   3990
            TabIndex        =   237
            Top             =   2010
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ɱ�Ĭ�ϸ�����"
         End
         Begin UFLABELLib.UFLabel LblcProductUnit 
            Height          =   195
            Left            =   3990
            TabIndex        =   236
            Top             =   1275
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����������λ"
         End
         Begin UFLABELLib.UFLabel LabcInvCCode 
            Height          =   195
            Left            =   90
            TabIndex        =   232
            Tag             =   "1"
            Top             =   540
            Width           =   870
            _Version        =   65536
            _ExtentX        =   1535
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�������"
         End
         Begin UFLABELLib.UFLabel LblCcurrencyName 
            Height          =   195
            Left            =   8010
            TabIndex        =   251
            Top             =   870
            Width           =   870
            _Version        =   65536
            _ExtentX        =   1535
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "ͨ������"
         End
         Begin UFLABELLib.UFLabel LabcInvStd 
            Height          =   195
            Left            =   7980
            TabIndex        =   246
            Top             =   165
            Width           =   870
            _Version        =   65536
            _ExtentX        =   1535
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����ͺ�"
         End
         Begin EDITLib.Edit EdtcCIQUnitCode 
            Height          =   285
            Left            =   1350
            TabIndex        =   16
            Top             =   2713
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   14737632
            Enabled         =   0   'False
            Appearance      =   1
            BackColor       =   14737632
            Enabled         =   0   'False
         End
         Begin UFLABELLib.UFLabel LblcCIQUnitCode 
            Height          =   195
            Left            =   90
            TabIndex        =   264
            Top             =   2760
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ؼ�����λ"
         End
         Begin EDITLib.Edit EdtfInvCIQExch 
            Height          =   285
            Left            =   5490
            TabIndex        =   17
            Top             =   2722
            Width           =   2295
            _Version        =   65536
            _ExtentX        =   4048
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   5
         End
         Begin UFLABELLib.UFLabel LblfInvCIQExch 
            Height          =   195
            Left            =   3990
            TabIndex        =   265
            Top             =   2760
            Width           =   1530
            _Version        =   65536
            _ExtentX        =   2699
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ص�λ������"
         End
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbBondedInv 
         Height          =   225
         Left            =   6435
         TabIndex        =   47
         Top             =   7050
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   397
         _StockProps     =   15
         Caption         =   "��˰Ʒ"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin U8TabPages.InvBatchProperty InvBatchProperty1 
         Height          =   6975
         Left            =   -74820
         TabIndex        =   263
         Top             =   330
         Width           =   11295
         _ExtentX        =   19923
         _ExtentY        =   12303
      End
      Begin U8TabPages.InvAttachfile InvAttachfile1 
         Height          =   6780
         Left            =   -74925
         TabIndex        =   259
         Top             =   390
         Width           =   11415
         _ExtentX        =   20135
         _ExtentY        =   11959
      End
      Begin U8TabPages.InvMPS InvMPS1 
         Height          =   7155
         Left            =   -74940
         TabIndex        =   226
         Top             =   345
         Width           =   11295
         _ExtentX        =   19923
         _ExtentY        =   12462
      End
      Begin U8TabPages.InvOther InvOther1 
         Height          =   6705
         Left            =   -74820
         TabIndex        =   227
         Top             =   660
         Width           =   11295
         _ExtentX        =   19923
         _ExtentY        =   11827
      End
      Begin U8Picture.Picture Pic 
         Height          =   6855
         Left            =   -74925
         TabIndex        =   206
         Top             =   660
         Width           =   11415
         _ExtentX        =   20135
         _ExtentY        =   12091
      End
      Begin U8TabPages.InvFree InvFree1 
         Height          =   6105
         Left            =   -74880
         TabIndex        =   124
         Top             =   390
         Width           =   11265
         _ExtentX        =   19870
         _ExtentY        =   10769
      End
      Begin U8TabPages.InvPlan InvPlan1 
         Height          =   6105
         Left            =   -74820
         TabIndex        =   107
         Top             =   780
         Width           =   11295
         _ExtentX        =   19923
         _ExtentY        =   10769
      End
      Begin UFFrames.UFFrame Frame1 
         Height          =   4770
         Index           =   7
         Left            =   -74880
         TabIndex        =   184
         Top             =   1500
         Width           =   11235
         _ExtentX        =   19817
         _ExtentY        =   8414
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BorderStyle     =   0
         Begin VB.Frame Frame2 
            Height          =   35
            Left            =   -240
            TabIndex        =   277
            Top             =   0
            Width           =   11655
         End
         Begin U8Ref.RefEdit EdtcRuleCode 
            Height          =   270
            Left            =   1440
            TabIndex        =   196
            Top             =   1038
            Width           =   4005
            _ExtentX        =   7064
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
            RefType         =   1
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbiEndDTStyle 
            Height          =   315
            Left            =   6540
            TabIndex        =   211
            Top             =   6210
            Visible         =   0   'False
            Width           =   1905
            _Version        =   65536
            _ExtentX        =   3360
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbBackInvDT 
            Height          =   255
            Left            =   420
            TabIndex        =   212
            Top             =   6510
            Visible         =   0   'False
            Width           =   2325
            _Version        =   65536
            _ExtentX        =   4101
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "�Ƿ��˻�����"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbOutInvDT 
            Height          =   255
            Left            =   420
            TabIndex        =   213
            Top             =   6180
            Visible         =   0   'False
            Width           =   2895
            _Version        =   65536
            _ExtentX        =   5106
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "�Ƿ񷢻�����"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbiDTLevel 
            Height          =   315
            Left            =   7170
            TabIndex        =   203
            Top             =   1425
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbcDTAQL 
            Height          =   315
            Left            =   7170
            TabIndex        =   204
            Top             =   1875
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbiDTStyle 
            Height          =   315
            Left            =   7170
            TabIndex        =   202
            Top             =   990
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbiDTMethod 
            Height          =   315
            Left            =   1440
            TabIndex        =   195
            Top             =   594
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbiTestStyle 
            Height          =   315
            Left            =   1440
            TabIndex        =   194
            Top             =   150
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin U8Ref.RefEdit EdtiQTMethod 
            Height          =   285
            Left            =   1440
            TabIndex        =   198
            Top             =   1881
            Width           =   4005
            _ExtentX        =   7064
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
         Begin U8Ref.RefEdit EdtcDTUnit 
            Height          =   285
            Left            =   1440
            TabIndex        =   199
            Top             =   2295
            Width           =   4005
            _ExtentX        =   7064
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
         Begin EDITLib.Edit EdtfDTNum 
            Height          =   285
            Left            =   7170
            TabIndex        =   201
            Top             =   570
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtfDTRate 
            Height          =   285
            Left            =   7170
            TabIndex        =   200
            Top             =   150
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin UFLABELLib.UFLabel LbliEndDTStyle 
            Height          =   195
            Left            =   5100
            TabIndex        =   214
            Top             =   6255
            Visible         =   0   'False
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����Ʒ�����ϸ��"
         End
         Begin UFCOMBOBOXLib.UFComboBox cmbiTestRule 
            Height          =   315
            Left            =   1440
            TabIndex        =   197
            Top             =   1437
            Width           =   4005
            _Version        =   65536
            _ExtentX        =   7064
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFLABELLib.UFLabel LblcRuleCode 
            Height          =   195
            Left            =   150
            TabIndex        =   225
            Top             =   1032
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ��������"
         End
         Begin UFLABELLib.UFLabel LbliTestRule 
            Height          =   195
            Left            =   150
            TabIndex        =   224
            Top             =   1458
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�������"
         End
         Begin UFLABELLib.UFLabel LbliTestStyle 
            Height          =   195
            Left            =   150
            TabIndex        =   223
            Top             =   180
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���鷽ʽ"
         End
         Begin UFLABELLib.UFLabel LbliDTMethod 
            Height          =   195
            Left            =   150
            TabIndex        =   222
            Top             =   606
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "������"
         End
         Begin UFLABELLib.UFLabel LblfDTRate 
            Height          =   195
            Left            =   5730
            TabIndex        =   221
            Top             =   180
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�����%"
         End
         Begin UFLABELLib.UFLabel LblfDTNum 
            Height          =   195
            Left            =   5730
            TabIndex        =   220
            Top             =   606
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�����"
         End
         Begin UFLABELLib.UFLabel LblcDTUnit 
            Height          =   195
            Left            =   150
            TabIndex        =   219
            Top             =   2310
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���������λ"
         End
         Begin UFLABELLib.UFLabel LbliDTStyle 
            Height          =   195
            Left            =   5730
            TabIndex        =   218
            Top             =   1032
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�����ϸ��"
         End
         Begin UFLABELLib.UFLabel LbliQTMethod 
            Height          =   195
            Left            =   150
            TabIndex        =   217
            Top             =   1884
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�������鷽��"
         End
         Begin UFLABELLib.UFLabel LblcDTAQL 
            Height          =   225
            Left            =   5730
            TabIndex        =   216
            Top             =   1884
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   397
            _StockProps     =   111
            Caption         =   "AQL"
         End
         Begin UFLABELLib.UFLabel lbliDTLevel 
            Height          =   195
            Left            =   5730
            TabIndex        =   215
            Top             =   1458
            Width           =   1440
            _Version        =   65536
            _ExtentX        =   2540
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����ˮƽ"
         End
      End
      Begin UFFrames.UFFrame Frame1 
         Height          =   6165
         Index           =   5
         Left            =   -74955
         TabIndex        =   166
         Top             =   765
         Width           =   11325
         _ExtentX        =   19976
         _ExtentY        =   10874
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BorderStyle     =   0
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   0
            Left            =   1230
            TabIndex        =   108
            Top             =   210
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   1
            Left            =   1230
            TabIndex        =   109
            Top             =   540
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   2
            Left            =   1230
            TabIndex        =   110
            Top             =   915
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   3
            Left            =   1230
            TabIndex        =   111
            Top             =   1275
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   4
            Left            =   1230
            TabIndex        =   112
            Top             =   1635
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   5
            Left            =   1230
            TabIndex        =   113
            Top             =   1995
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   6
            Left            =   1230
            TabIndex        =   114
            Top             =   2370
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   7
            Left            =   1230
            TabIndex        =   115
            Top             =   2730
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   8
            Left            =   1215
            TabIndex        =   116
            Top             =   3105
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   9
            Left            =   1215
            TabIndex        =   117
            Top             =   3480
            Width           =   10065
            _ExtentX        =   17754
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
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   10
            Left            =   1215
            TabIndex        =   118
            Top             =   3840
            Width           =   4305
            _ExtentX        =   7594
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
            MaxLength       =   5
            Property        =   4
            RefType         =   3
         End
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   11
            Left            =   1215
            TabIndex        =   119
            Top             =   4215
            Width           =   4305
            _ExtentX        =   7594
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
            MaxLength       =   5
            Property        =   4
            RefType         =   3
         End
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   12
            Left            =   1215
            TabIndex        =   120
            Top             =   4575
            Width           =   4305
            _ExtentX        =   7594
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
            MaxLength       =   40
            NumPoint        =   6
            Property        =   4
            RefType         =   3
         End
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   13
            Left            =   1215
            TabIndex        =   121
            Top             =   4950
            Width           =   4305
            _ExtentX        =   7594
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
            MaxLength       =   40
            NumPoint        =   6
            Property        =   4
            RefType         =   3
         End
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   14
            Left            =   1215
            TabIndex        =   122
            Top             =   5310
            Width           =   4305
            _ExtentX        =   7594
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
            Property        =   5
            RefType         =   2
         End
         Begin U8Ref.RefEdit EdtU 
            Height          =   285
            Index           =   15
            Left            =   1215
            TabIndex        =   123
            Top             =   5685
            Width           =   4305
            _ExtentX        =   7594
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
            Property        =   5
            RefType         =   2
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   0
            Left            =   180
            TabIndex        =   182
            Top             =   210
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   1
            Left            =   180
            TabIndex        =   181
            Top             =   570
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   2
            Left            =   180
            TabIndex        =   180
            Top             =   945
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   3
            Left            =   180
            TabIndex        =   179
            Top             =   1305
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   4
            Left            =   180
            TabIndex        =   178
            Top             =   1680
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   5
            Left            =   180
            TabIndex        =   177
            Top             =   2040
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   6
            Left            =   180
            TabIndex        =   176
            Top             =   2400
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   7
            Left            =   180
            TabIndex        =   175
            Top             =   2775
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   8
            Left            =   165
            TabIndex        =   174
            Top             =   3165
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   9
            Left            =   165
            TabIndex        =   173
            Top             =   3525
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   10
            Left            =   165
            TabIndex        =   172
            Top             =   3900
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   11
            Left            =   165
            TabIndex        =   171
            Top             =   4260
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   12
            Left            =   165
            TabIndex        =   170
            Top             =   4635
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   13
            Left            =   165
            TabIndex        =   169
            Top             =   4995
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   14
            Left            =   165
            TabIndex        =   168
            Top             =   5355
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
         Begin UFLABELLib.UFLabel LblD1 
            Height          =   195
            Index           =   15
            Left            =   165
            TabIndex        =   167
            Top             =   5730
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Զ�����1"
         End
      End
      Begin UFFrames.UFFrame Frame1 
         Height          =   6180
         Index           =   1
         Left            =   -74820
         TabIndex        =   131
         Top             =   570
         Width           =   11355
         _ExtentX        =   20029
         _ExtentY        =   10901
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BorderStyle     =   0
         Begin EDITLib.Edit EdtfExpPrice 
            Height          =   285
            Left            =   4380
            TabIndex        =   69
            Top             =   6330
            Visible         =   0   'False
            Width           =   1995
            _Version        =   65536
            _ExtentX        =   3519
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtiHighPrice 
            Height          =   270
            Left            =   4410
            TabIndex        =   127
            Top             =   6780
            Visible         =   0   'False
            Width           =   1995
            _Version        =   65536
            _ExtentX        =   3519
            _ExtentY        =   476
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   6
            MaxLength       =   20
         End
         Begin EDITLib.Edit EdtiExpSaleRate 
            Height          =   285
            Left            =   1500
            TabIndex        =   60
            Top             =   2430
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   6
            MaxLength       =   20
         End
         Begin EDITLib.Edit EdtcPriceGroup 
            Height          =   270
            Left            =   1290
            TabIndex        =   126
            Top             =   6780
            Visible         =   0   'False
            Width           =   1995
            _Version        =   65536
            _ExtentX        =   3519
            _ExtentY        =   476
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtiOfferRate 
            Height          =   270
            Left            =   4410
            TabIndex        =   129
            Top             =   7095
            Visible         =   0   'False
            Width           =   1995
            _Version        =   65536
            _ExtentX        =   3519
            _ExtentY        =   476
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   6
            MaxLength       =   20
         End
         Begin EDITLib.Edit EdtcOfferGrade 
            Height          =   270
            Left            =   1290
            TabIndex        =   128
            Top             =   7095
            Visible         =   0   'False
            Width           =   1995
            _Version        =   65536
            _ExtentX        =   3519
            _ExtentY        =   476
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin UFCOMBOBOXLib.UFComboBox CbocValueType 
            Height          =   315
            Left            =   1500
            TabIndex        =   48
            Top             =   270
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin EDITLib.Edit EdtiInvMPCost 
            Height          =   285
            Left            =   6810
            TabIndex        =   51
            Top             =   630
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   5
            MaxLength       =   16
         End
         Begin U8Ref.RefEdit EdtcVenCode 
            Height          =   285
            Left            =   1500
            TabIndex        =   56
            Top             =   1725
            Width           =   4200
            _ExtentX        =   7408
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
            MaxLength       =   12
            NumPoint        =   4
            RefType         =   1
         End
         Begin EDITLib.Edit EdtiInvLSCost 
            Height          =   285
            Left            =   1500
            TabIndex        =   54
            Top             =   1365
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin EDITLib.Edit EdtiInvNCost 
            Height          =   285
            Left            =   6810
            TabIndex        =   53
            Top             =   990
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin EDITLib.Edit EdtiInvSCost 
            Height          =   285
            Left            =   6810
            TabIndex        =   55
            Top             =   1350
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   6
            MaxLength       =   14
         End
         Begin EDITLib.Edit EdtiInvSPrice 
            Height          =   285
            Left            =   1500
            TabIndex        =   52
            Top             =   1005
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin EDITLib.Edit EdtiInvRCost 
            Height          =   285
            Left            =   1500
            TabIndex        =   50
            Top             =   660
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin EDITLib.Edit EdtfExpensesExch 
            Height          =   285
            Left            =   6810
            TabIndex        =   49
            Top             =   270
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   6
            MaxLength       =   14
         End
         Begin EDITLib.Edit EdtfRetailPrice 
            Height          =   285
            Left            =   6810
            TabIndex        =   59
            Top             =   2070
            Width           =   4200
            _Version        =   65536
            _ExtentX        =   7408
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   6
            MaxLength       =   20
         End
         Begin U8Ref.RefEdit EdtcPurPersonCode 
            Height          =   285
            Left            =   6810
            TabIndex        =   57
            Top             =   1725
            Width           =   4200
            _ExtentX        =   7408
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
            MaxLength       =   12
            NumPoint        =   4
            RefType         =   1
         End
         Begin U8Ref.RefEdit EdtcDefWareHouse 
            Height          =   285
            Left            =   1500
            TabIndex        =   58
            Top             =   2070
            Width           =   4200
            _ExtentX        =   7408
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
         Begin UFLABELLib.UFLabel LblfExpPrice 
            Height          =   195
            Left            =   3540
            TabIndex        =   183
            Top             =   6345
            Visible         =   0   'False
            Width           =   720
            _Version        =   65536
            _ExtentX        =   1270
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���õ���"
            AutoSize        =   -1  'True
         End
         Begin UFLABELLib.UFLabel LbliOfferRate 
            Height          =   195
            Left            =   3480
            TabIndex        =   165
            Top             =   7110
            Visible         =   0   'False
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1588
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���۹�����"
            AutoSize        =   -1  'True
         End
         Begin UFLABELLib.UFLabel LblcOfferGrade 
            Height          =   195
            Left            =   60
            TabIndex        =   164
            Top             =   7110
            Visible         =   0   'False
            Width           =   1080
            _Version        =   65536
            _ExtentX        =   1905
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���۹��׵ȼ�"
            AutoSize        =   -1  'True
         End
         Begin UFLABELLib.UFLabel LblcPriceGroup 
            Height          =   195
            Left            =   360
            TabIndex        =   163
            Top             =   6825
            Visible         =   0   'False
            Width           =   540
            _Version        =   65536
            _ExtentX        =   953
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�۸���"
            AutoSize        =   -1  'True
         End
         Begin UFLABELLib.UFLabel LbliHighPrice 
            Height          =   195
            Left            =   3480
            TabIndex        =   161
            Top             =   6810
            Visible         =   0   'False
            Width           =   720
            _Version        =   65536
            _ExtentX        =   1270
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����ۼ�"
            AutoSize        =   -1  'True
         End
         Begin UFLABELLib.UFLabel LabcVenCode 
            Height          =   195
            Left            =   210
            TabIndex        =   133
            Top             =   1740
            Width           =   1275
            _Version        =   65536
            _ExtentX        =   2249
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��Ҫ������λ"
         End
         Begin UFLABELLib.UFLabel LabiInvLSCost 
            Height          =   195
            Left            =   210
            TabIndex        =   134
            Top             =   1380
            Width           =   1275
            _Version        =   65536
            _ExtentX        =   2249
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "����ۼ�"
         End
         Begin UFLABELLib.UFLabel LabiInvSPrice 
            Height          =   195
            Left            =   210
            TabIndex        =   136
            Top             =   1020
            Width           =   1275
            _Version        =   65536
            _ExtentX        =   2249
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ο��ɱ�"
         End
         Begin UFLABELLib.UFLabel LabiInvRCost 
            Height          =   195
            Left            =   210
            TabIndex        =   137
            Top             =   675
            Width           =   1275
            _Version        =   65536
            _ExtentX        =   2249
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ƻ�����/�ۼ�"
         End
         Begin UFLABELLib.UFLabel LblcValueType 
            Height          =   195
            Left            =   210
            TabIndex        =   147
            Top             =   315
            Width           =   1275
            _Version        =   65536
            _ExtentX        =   2249
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�Ƽ۷�ʽ"
         End
         Begin UFLABELLib.UFLabel LblcDefWareHouse 
            Height          =   195
            Left            =   210
            TabIndex        =   160
            Top             =   2130
            Width           =   1275
            _Version        =   65536
            _ExtentX        =   2249
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "Ĭ�ϲֿ�"
         End
         Begin UFLABELLib.UFLabel LbliExpSaleRate 
            Height          =   195
            Left            =   210
            TabIndex        =   162
            Top             =   2445
            Width           =   1275
            _Version        =   65536
            _ExtentX        =   2249
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ۼӳ���%"
         End
         Begin UFLABELLib.UFLabel LbliInvMPCost 
            Height          =   195
            Left            =   5850
            TabIndex        =   132
            Top             =   675
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1587
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��߽���"
         End
         Begin UFLABELLib.UFLabel LabiInvNCost 
            Height          =   195
            Left            =   5850
            TabIndex        =   135
            Top             =   1020
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1587
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���³ɱ�"
         End
         Begin UFLABELLib.UFLabel LbliInvSCost 
            Height          =   195
            Left            =   5850
            TabIndex        =   146
            Top             =   1380
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1587
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ο��ۼ�"
         End
         Begin UFLABELLib.UFLabel LblfExpensesExch 
            Height          =   195
            Left            =   5850
            TabIndex        =   148
            Top             =   315
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1587
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "������%"
         End
         Begin UFLABELLib.UFLabel LblfRetailPrice 
            Height          =   195
            Left            =   5850
            TabIndex        =   185
            Top             =   2130
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1587
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ۼ۸�"
         End
         Begin UFLABELLib.UFLabel LblcPurPersonCode 
            Height          =   195
            Left            =   5850
            TabIndex        =   205
            Top             =   1740
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1587
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ɹ�Ա"
         End
         Begin EDITLib.Edit EdtfCurLLaborCost 
            Height          =   285
            Left            =   2460
            TabIndex        =   61
            Top             =   2820
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfCurLLaborCost 
            Height          =   195
            Left            =   210
            TabIndex        =   266
            Top             =   2835
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ױ�׼�˹�����"
         End
         Begin EDITLib.Edit EdtfCurLVarManuCost 
            Height          =   285
            Left            =   7770
            TabIndex        =   62
            Top             =   2820
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfCurLVarManuCost 
            Height          =   195
            Left            =   5850
            TabIndex        =   267
            Top             =   2835
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ױ�׼�䶯�������"
         End
         Begin EDITLib.Edit EdtfCurLFixManuCost 
            Height          =   285
            Left            =   2460
            TabIndex        =   63
            Top             =   3200
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfCurLFixManuCost 
            Height          =   195
            Left            =   210
            TabIndex        =   268
            Top             =   3215
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ױ�׼�̶��������"
         End
         Begin EDITLib.Edit EdtfCurLOMCost 
            Height          =   285
            Left            =   7770
            TabIndex        =   64
            Top             =   3210
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfCurLOMCost 
            Height          =   195
            Left            =   5850
            TabIndex        =   269
            Top             =   3225
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ױ�׼ί��ӹ���"
         End
         Begin EDITLib.Edit EdtfNextLLaborCost 
            Height          =   285
            Left            =   2460
            TabIndex        =   65
            Top             =   3580
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfNextLLaborCost 
            Height          =   195
            Left            =   210
            TabIndex        =   270
            Top             =   3595
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "ǰ�ױ�׼�˹�����"
         End
         Begin EDITLib.Edit EdtfNextLVarManuCost 
            Height          =   285
            Left            =   7770
            TabIndex        =   66
            Top             =   3600
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfNextLVarManuCost 
            Height          =   195
            Left            =   5850
            TabIndex        =   271
            Top             =   3615
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "ǰ�ױ�׼�䶯�������"
         End
         Begin EDITLib.Edit EdtfNextLFixManuCost 
            Height          =   285
            Left            =   2460
            TabIndex        =   67
            Top             =   3960
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfNextLFixManuCost 
            Height          =   195
            Left            =   210
            TabIndex        =   272
            Top             =   3975
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "ǰ�ױ�׼�̶��������"
         End
         Begin EDITLib.Edit EdtfNextLOMCost 
            Height          =   285
            Left            =   7770
            TabIndex        =   68
            Top             =   3990
            Width           =   3240
            _Version        =   65536
            _ExtentX        =   5715
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   12
         End
         Begin UFLABELLib.UFLabel lblfNextLOMCost 
            Height          =   195
            Left            =   5850
            TabIndex        =   273
            Top             =   4005
            Width           =   1875
            _Version        =   65536
            _ExtentX        =   3307
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "ǰ�ױ�׼ί��ӹ���"
         End
      End
      Begin UFFrames.UFFrame Frame1 
         Height          =   375
         Index           =   4
         Left            =   -72810
         TabIndex        =   189
         Top             =   810
         Visible         =   0   'False
         Width           =   1095
         _ExtentX        =   0
         _ExtentY        =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Appearance      =   0
         BackColor       =   -2147483648
         BorderStyle     =   0
         ForeColor       =   -2147483640
      End
      Begin UFFrames.UFFrame Frame1 
         Height          =   375
         Index           =   3
         Left            =   -73410
         TabIndex        =   188
         Top             =   450
         Visible         =   0   'False
         Width           =   1095
         _ExtentX        =   0
         _ExtentY        =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Appearance      =   0
         BackColor       =   -2147483648
         BorderStyle     =   0
         ForeColor       =   -2147483640
      End
      Begin UFFrames.UFFrame Frame1 
         Height          =   1080
         Index           =   6
         Left            =   -72600
         TabIndex        =   209
         Top             =   1740
         Visible         =   0   'False
         Width           =   1950
         _ExtentX        =   3440
         _ExtentY        =   1905
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbPurchase 
         Height          =   195
         Left            =   4485
         TabIndex        =   26
         Top             =   5490
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�⹺"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbExpSale 
         Height          =   195
         Left            =   2520
         TabIndex        =   25
         Top             =   5490
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbInvModel 
         Height          =   195
         Left            =   4485
         TabIndex        =   36
         Top             =   6285
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "ģ��"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbEquipment 
         Height          =   195
         Left            =   9030
         TabIndex        =   33
         Top             =   5910
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbProxyForeign 
         Height          =   195
         Left            =   9030
         TabIndex        =   28
         Top             =   5520
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "ί��"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbService 
         Height          =   195
         Left            =   2520
         TabIndex        =   40
         Top             =   6690
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "Ӧ˰����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbComsume 
         Height          =   195
         Left            =   6435
         TabIndex        =   27
         Top             =   5490
         Width           =   2535
         _Version        =   65536
         _ExtentX        =   4471
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "��������"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbProducing 
         Height          =   195
         Left            =   2520
         TabIndex        =   30
         Top             =   5895
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbPlanInv 
         Height          =   195
         Left            =   4485
         TabIndex        =   31
         Top             =   5895
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�ƻ�Ʒ"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbInvEntrust 
         Height          =   225
         Left            =   2520
         TabIndex        =   45
         Top             =   7050
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   397
         _StockProps     =   15
         Caption         =   "�Ƿ����д���"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbAccessary 
         Height          =   225
         Left            =   4485
         TabIndex        =   46
         Top             =   7050
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   397
         _StockProps     =   15
         Caption         =   "�Ƿ���׼�"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbCheckItem 
         Height          =   195
         Left            =   6435
         TabIndex        =   32
         Top             =   5895
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�Ƿ�ѡ����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbSale 
         Height          =   195
         Left            =   570
         TabIndex        =   24
         Top             =   5490
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbSelf 
         Height          =   195
         Left            =   570
         TabIndex        =   29
         Top             =   5895
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbInvType 
         Height          =   225
         Left            =   570
         TabIndex        =   44
         Top             =   7050
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   397
         _StockProps     =   15
         Caption         =   "�Ƿ��ۿ�"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbPTOModel 
         Height          =   195
         Left            =   570
         TabIndex        =   34
         Top             =   6285
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "PTO"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbATOModel 
         Height          =   195
         Left            =   2520
         TabIndex        =   35
         Top             =   6285
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "ATO"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbPiece 
         Height          =   225
         Left            =   570
         TabIndex        =   39
         Top             =   6690
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
         _ExtentY        =   397
         _StockProps     =   15
         Caption         =   "�Ƽ�"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbSrvFittings 
         Height          =   195
         Left            =   6435
         TabIndex        =   42
         Top             =   6690
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�������"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox chkbSrvItem 
         Height          =   195
         Left            =   4485
         TabIndex        =   41
         Top             =   6690
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "������Ŀ"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFFrames.UFFrame Frame1 
         Height          =   6870
         Index           =   2
         Left            =   -74910
         TabIndex        =   138
         Top             =   660
         Width           =   11325
         _ExtentX        =   19976
         _ExtentY        =   12118
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BorderStyle     =   0
         Begin EDITLib.Edit EdtfBuyExcess 
            Height          =   285
            Left            =   1500
            TabIndex        =   76
            Top             =   1215
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin UFLABELLib.UFLabel LblfBuyExcess 
            Height          =   195
            Left            =   240
            TabIndex        =   258
            Top             =   1275
            Width           =   1170
            _Version        =   65536
            _ExtentX        =   2064
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�빺��������"
         End
         Begin UFCOMBOBOXLib.UFComboBox CmbcMassUnit 
            Height          =   315
            Left            =   2970
            TabIndex        =   93
            Top             =   4275
            Width           =   1095
            _Version        =   65536
            _ExtentX        =   1931
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFCOMBOBOXLib.UFComboBox CbocFrequency 
            Height          =   315
            Left            =   1500
            TabIndex        =   88
            Top             =   3405
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbTrack 
            Height          =   255
            Left            =   5895
            TabIndex        =   100
            Top             =   5010
            Width           =   5205
            _Version        =   65536
            _ExtentX        =   9181
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "�Ƿ����������"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbSerial 
            Height          =   255
            Left            =   5895
            TabIndex        =   102
            Top             =   5370
            Width           =   5205
            _Version        =   65536
            _ExtentX        =   9181
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "�Ƿ����кŹ���"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbInvOverStock 
            Height          =   195
            Left            =   240
            TabIndex        =   103
            Top             =   5730
            Width           =   5385
            _Version        =   65536
            _ExtentX        =   9499
            _ExtentY        =   344
            _StockProps     =   15
            Caption         =   "�Ƿ���ͻ�ѹ"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCOMBOBOXLib.UFComboBox Combo1 
            Height          =   315
            Left            =   1500
            TabIndex        =   82
            Top             =   2295
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin U8Ref.RefEdit EdtcPosition 
            Height          =   285
            Left            =   7185
            TabIndex        =   75
            Top             =   870
            Width           =   3900
            _ExtentX        =   6879
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
            MaxLength       =   16
            NumPoint        =   4
            RefType         =   1
         End
         Begin EDITLib.Edit EdtcReplaceItem 
            Height          =   285
            Left            =   1500
            TabIndex        =   74
            Top             =   855
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin EDITLib.Edit EdtiOverStock 
            Height          =   285
            Left            =   7185
            TabIndex        =   73
            Top             =   510
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin EDITLib.Edit EdtiLowSum 
            Height          =   285
            Left            =   7185
            TabIndex        =   71
            Top             =   150
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin EDITLib.Edit EdtiTopSum 
            Height          =   285
            Left            =   1500
            TabIndex        =   70
            Top             =   150
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin EDITLib.Edit EdtiSafeNum 
            Height          =   285
            Left            =   1500
            TabIndex        =   72
            Top             =   510
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   6
            MaxLength       =   12
         End
         Begin EDITLib.Edit EdtiMassDate 
            Height          =   285
            Left            =   4740
            TabIndex        =   94
            Top             =   4275
            Width           =   1095
            _Version        =   65536
            _ExtentX        =   1931
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   2
            MaxLength       =   5
         End
         Begin EDITLib.Edit EdtdWarnDays 
            Height          =   285
            Left            =   10005
            TabIndex        =   96
            Top             =   4260
            Width           =   1095
            _Version        =   65536
            _ExtentX        =   1931
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   2
            MaxLength       =   4
         End
         Begin EDITLib.Edit EdtcBarCode 
            Height          =   285
            Left            =   7170
            TabIndex        =   98
            Top             =   4620
            Width           =   3930
            _Version        =   65536
            _ExtentX        =   6932
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   1
            MaxLength       =   20
         End
         Begin EDITLib.Edit EdtiFrequency 
            Height          =   285
            Left            =   7185
            TabIndex        =   87
            Top             =   3045
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   2
            MaxLength       =   4
         End
         Begin EDITLib.Edit EdtfInExcess 
            Height          =   285
            Left            =   7185
            TabIndex        =   79
            Top             =   1590
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin EDITLib.Edit EdtiWastage 
            Height          =   285
            Left            =   1500
            TabIndex        =   84
            Top             =   2685
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   8
         End
         Begin U8Ref.RefEdit EdtdLastDate 
            Height          =   285
            Left            =   1500
            TabIndex        =   86
            Top             =   3045
            Width           =   3900
            _ExtentX        =   6879
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
            Property        =   5
            RefType         =   2
         End
         Begin EDITLib.Edit EdtfOutExcess 
            Height          =   285
            Left            =   1500
            TabIndex        =   78
            Top             =   1575
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin EDITLib.Edit EdtfOrderUpLimit 
            Height          =   285
            Left            =   7185
            TabIndex        =   81
            Top             =   1950
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin UFLABELLib.UFLabel LblCboiDays 
            Height          =   285
            Left            =   5940
            TabIndex        =   152
            Top             =   3510
            Width           =   1170
            _Version        =   65536
            _ExtentX        =   2064
            _ExtentY        =   503
            _StockProps     =   111
            Caption         =   "ÿ�µ�"
         End
         Begin UFLABELLib.UFLabel LblcBarCode 
            Height          =   255
            Left            =   5895
            TabIndex        =   151
            Top             =   4650
            Width           =   930
            _Version        =   65536
            _ExtentX        =   1640
            _ExtentY        =   450
            _StockProps     =   111
            Caption         =   "��Ӧ������"
         End
         Begin UFLABELLib.UFLabel LbliMassDate 
            Height          =   255
            Left            =   4185
            TabIndex        =   150
            Top             =   4305
            Width           =   690
            _Version        =   65536
            _ExtentX        =   1217
            _ExtentY        =   450
            _StockProps     =   111
            Caption         =   "������"
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbKCCutMantissa 
            Height          =   195
            Left            =   240
            TabIndex        =   101
            Top             =   5370
            Width           =   5385
            _Version        =   65536
            _ExtentX        =   9499
            _ExtentY        =   344
            _StockProps     =   15
            Caption         =   "�����Ƿ��г�β��"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbBarCode 
            Height          =   195
            Left            =   240
            TabIndex        =   97
            Top             =   4650
            Width           =   5385
            _Version        =   65536
            _ExtentX        =   9499
            _ExtentY        =   344
            _StockProps     =   15
            Caption         =   "�Ƿ����������"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbSolitude 
            Height          =   255
            Left            =   5895
            TabIndex        =   104
            Top             =   5730
            Width           =   5205
            _Version        =   65536
            _ExtentX        =   9181
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "�Ƿ񵥶����"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbInvQuality 
            Height          =   195
            Left            =   240
            TabIndex        =   92
            Top             =   4305
            Width           =   1695
            _Version        =   65536
            _ExtentX        =   2990
            _ExtentY        =   344
            _StockProps     =   15
            Caption         =   "�Ƿ����ڹ���"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbInvBatch 
            Height          =   195
            Left            =   240
            TabIndex        =   99
            Top             =   5010
            Width           =   5385
            _Version        =   65536
            _ExtentX        =   9499
            _ExtentY        =   344
            _StockProps     =   15
            Caption         =   "�Ƿ����ι���"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin EDITLib.Edit EdtiDrawBatch 
            Height          =   285
            Left            =   7185
            TabIndex        =   83
            Top             =   2319
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbReceiptByDT 
            Height          =   255
            Left            =   240
            TabIndex        =   105
            Top             =   6090
            Width           =   5205
            _Version        =   65536
            _ExtentX        =   9181
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "���������ݼ��������"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
            Picture         =   "FrmZAM.frx":016C
            DownPicture     =   "FrmZAM.frx":0188
            DisabledPicture =   "FrmZAM.frx":01A4
         End
         Begin EDITLib.Edit EdtfMinSplit 
            Height          =   285
            Left            =   7185
            TabIndex        =   85
            Top             =   2685
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin UFCOMBOBOXLib.UFComboBox CboiDays 
            Height          =   315
            Left            =   7200
            TabIndex        =   89
            Top             =   3450
            Width           =   915
            _Version        =   65536
            _ExtentX        =   1614
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFLABELLib.UFLabel LblCboiDays2 
            Height          =   195
            Left            =   8310
            TabIndex        =   229
            Top             =   3510
            Width           =   180
            _Version        =   65536
            _ExtentX        =   318
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��"
            AutoSize        =   -1  'True
         End
         Begin UFLABELLib.UFLabel LblfMinSplit 
            Height          =   195
            Left            =   5925
            TabIndex        =   228
            Top             =   2730
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��С�ָ���"
         End
         Begin UFLABELLib.UFLabel LabcReplaceItem 
            Height          =   195
            Left            =   240
            TabIndex        =   140
            Top             =   915
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�滻��"
         End
         Begin UFLABELLib.UFLabel LabiTopSum 
            Height          =   195
            Left            =   240
            TabIndex        =   143
            Top             =   195
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��߿��"
         End
         Begin UFLABELLib.UFLabel LabiSafeNum 
            Height          =   195
            Left            =   240
            TabIndex        =   144
            Top             =   555
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��ȫ���"
         End
         Begin UFLABELLib.UFLabel LabcInvABC 
            Height          =   195
            Left            =   240
            TabIndex        =   145
            Top             =   2370
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "ABC����"
         End
         Begin UFLABELLib.UFLabel LblfInExcess 
            Height          =   195
            Left            =   5925
            TabIndex        =   153
            Top             =   1650
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��ⳬ������"
         End
         Begin UFLABELLib.UFLabel LbliFrequency 
            Height          =   195
            Left            =   5925
            TabIndex        =   157
            Top             =   3090
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�̵�����"
         End
         Begin UFLABELLib.UFLabel LblfOrderUpLimit 
            Height          =   195
            Left            =   5925
            TabIndex        =   186
            Top             =   2010
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "������������"
         End
         Begin UFLABELLib.UFLabel LbliDrawBatch 
            Height          =   195
            Left            =   5925
            TabIndex        =   210
            Top             =   2370
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��������"
         End
         Begin UFLABELLib.UFLabel LbldLastDate 
            Height          =   195
            Left            =   240
            TabIndex        =   208
            Top             =   3090
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ϴ��̵�����"
         End
         Begin UFLABELLib.UFLabel LabcPosition 
            Height          =   195
            Left            =   5895
            TabIndex        =   139
            Top             =   915
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��λ"
         End
         Begin UFLABELLib.UFLabel LabiOverStock 
            Height          =   195
            Left            =   5895
            TabIndex        =   141
            Top             =   555
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��ѹ��׼"
         End
         Begin UFLABELLib.UFLabel LabiLowSum 
            Height          =   195
            Left            =   5895
            TabIndex        =   142
            Top             =   195
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��Ϳ��"
         End
         Begin UFLABELLib.UFLabel LbliWastage 
            Height          =   195
            Left            =   240
            TabIndex        =   154
            Top             =   2730
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���������%"
         End
         Begin UFLABELLib.UFLabel LblcFrequency 
            Height          =   195
            Left            =   240
            TabIndex        =   156
            Top             =   3450
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�̵����ڵ�λ"
         End
         Begin UFLABELLib.UFLabel LblfOutExcess 
            Height          =   195
            Left            =   240
            TabIndex        =   159
            Top             =   1650
            Width           =   1290
            _Version        =   65536
            _ExtentX        =   2275
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "���ⳬ������"
         End
         Begin UFLABELLib.UFLabel lblcMassUnit 
            Height          =   255
            Left            =   2055
            TabIndex        =   187
            Top             =   4305
            Width           =   900
            _Version        =   65536
            _ExtentX        =   1587
            _ExtentY        =   450
            _StockProps     =   111
            Caption         =   "�����ڵ�λ"
         End
         Begin UFLABELLib.UFLabel LbldWarnDays 
            Height          =   255
            Left            =   9240
            TabIndex        =   149
            Top             =   4305
            Width           =   810
            _Version        =   65536
            _ExtentX        =   1429
            _ExtentY        =   450
            _StockProps     =   111
            Caption         =   "Ԥ������"
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbInByProCheck 
            Height          =   255
            Left            =   5895
            TabIndex        =   106
            Top             =   6090
            Width           =   5205
            _Version        =   65536
            _ExtentX        =   9181
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "��Ʒ�����ݼ��������"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
            Picture         =   "FrmZAM.frx":01C0
            DownPicture     =   "FrmZAM.frx":01DC
            DisabledPicture =   "FrmZAM.frx":01F8
         End
         Begin UFCOMBOBOXLib.UFComboBox cmbiExpiratDateCalcu 
            Height          =   315
            Left            =   7170
            TabIndex        =   95
            Top             =   4260
            Width           =   1350
            _Version        =   65536
            _ExtentX        =   2381
            _ExtentY        =   556
            _StockProps     =   196
            Text            =   ""
            Style           =   2
            ForeColor       =   0
         End
         Begin UFLABELLib.UFLabel lbliExpiratDateCalcu 
            Height          =   255
            Left            =   5895
            TabIndex        =   261
            Top             =   4290
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   450
            _StockProps     =   111
            Caption         =   "��Ч�����㷽ʽ"
         End
         Begin EDITLib.Edit EdtfInvOutUpLimit 
            Height          =   285
            Left            =   1500
            TabIndex        =   80
            Top             =   1935
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            Property        =   4
            NumPoint        =   4
            MaxLength       =   16
         End
         Begin UFLABELLib.UFLabel lblfInvOutUpLimit 
            Height          =   195
            Left            =   240
            TabIndex        =   262
            Top             =   2010
            Width           =   1260
            _Version        =   65536
            _ExtentX        =   2222
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�����ʳ�����"
         End
         Begin UFCHECKBOXLib.UFCheckBox chkbInvROHS 
            Height          =   255
            Left            =   240
            TabIndex        =   90
            Top             =   3880
            Width           =   1245
            _Version        =   65536
            _ExtentX        =   2196
            _ExtentY        =   450
            _StockProps     =   15
            Caption         =   "ROHS����"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin EDITLib.Edit EdtfPrjMatLimit 
            Height          =   285
            Left            =   7185
            TabIndex        =   77
            Top             =   1215
            Width           =   3900
            _Version        =   65536
            _ExtentX        =   6879
            _ExtentY        =   503
            _StockProps     =   253
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
         End
         Begin UFLABELLib.UFLabel lblfPrjMatLimit 
            Height          =   195
            Left            =   5910
            TabIndex        =   275
            Top             =   1275
            Width           =   1170
            _Version        =   65536
            _ExtentX        =   2064
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "�ɹ���������"
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkBPropertyCheck2 
            Height          =   225
            Left            =   2040
            TabIndex        =   91
            Top             =   3885
            Width           =   1185
            _Version        =   65536
            _ExtentX        =   2090
            _ExtentY        =   397
            _StockProps     =   15
            Caption         =   "�Ƿ��ʼ�"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbDTWarnInv2 
            Height          =   195
            Left            =   240
            TabIndex        =   278
            Top             =   6480
            Width           =   2025
            _Version        =   65536
            _ExtentX        =   3572
            _ExtentY        =   344
            _StockProps     =   15
            Caption         =   "�����ڴ���Ƿ����"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
         Begin UFLABELLib.UFLabel lblcDTPeriod2 
            Height          =   195
            Left            =   5940
            TabIndex        =   279
            Top             =   3900
            Width           =   720
            _Version        =   65536
            _ExtentX        =   1270
            _ExtentY        =   344
            _StockProps     =   111
            Caption         =   "��������"
            AutoSize        =   -1  'True
         End
         Begin U8TabPages.InvPeriod EdtcDTPeriod2 
            Height          =   345
            Left            =   7170
            TabIndex        =   280
            Top             =   3840
            Width           =   3900
            _ExtentX        =   6879
            _ExtentY        =   609
         End
         Begin UFCHECKBOXLib.UFCheckBox ChkbPeriodDT2 
            Height          =   195
            Left            =   3840
            TabIndex        =   281
            Top             =   3880
            Width           =   1905
            _Version        =   65536
            _ExtentX        =   3360
            _ExtentY        =   344
            _StockProps     =   15
            Caption         =   "�Ƿ����ڼ���"
            ForeColor       =   0
            ForeColor       =   0
            BorderStyle     =   0
            ReadyState      =   0
         End
      End
      Begin UFFrames.UFFrame FramePlubIn 
         Height          =   7050
         Left            =   -74910
         TabIndex        =   256
         Top             =   420
         Width           =   11370
         _ExtentX        =   20055
         _ExtentY        =   12435
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   8.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
      End
      Begin UFFrames.UFFrame UFFrameProperty 
         Height          =   2175
         Left            =   240
         TabIndex        =   230
         Top             =   5190
         Width           =   11025
         _ExtentX        =   19447
         _ExtentY        =   3836
         Caption         =   "�������"
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
      End
      Begin UFLABELLib.UFLabel lblcDTPeriod 
         Height          =   195
         Left            =   -69120
         TabIndex        =   276
         Top             =   1125
         Width           =   720
         _Version        =   65536
         _ExtentX        =   1270
         _ExtentY        =   344
         _StockProps     =   111
         Caption         =   "��������"
         AutoSize        =   -1  'True
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbPeriodDT 
         Height          =   195
         Left            =   -74670
         TabIndex        =   192
         Top             =   1125
         Width           =   5385
         _Version        =   65536
         _ExtentX        =   9499
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�Ƿ����ڼ���"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin U8TabPages.InvPeriod EdtcDTPeriod 
         Height          =   345
         Left            =   -67710
         TabIndex        =   193
         Top             =   1065
         Width           =   4005
         _ExtentX        =   7064
         _ExtentY        =   609
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkBPropertyCheck 
         Height          =   225
         Left            =   -74670
         TabIndex        =   190
         Top             =   780
         Width           =   5145
         _Version        =   65536
         _ExtentX        =   9075
         _ExtentY        =   397
         _StockProps     =   15
         Caption         =   "�Ƿ��ʼ�"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
      Begin UFCHECKBOXLib.UFCheckBox ChkbDTWarnInv 
         Height          =   195
         Left            =   -69120
         TabIndex        =   191
         Top             =   780
         Width           =   5385
         _Version        =   65536
         _ExtentX        =   9499
         _ExtentY        =   344
         _StockProps     =   15
         Caption         =   "�����ڴ���Ƿ����"
         ForeColor       =   0
         ForeColor       =   0
         BorderStyle     =   0
         ReadyState      =   0
      End
   End
   Begin MSComctlLib.Toolbar Tlb 
      Align           =   1  'Align Top
      Height          =   555
      Left            =   0
      TabIndex        =   130
      Top             =   0
      Width           =   11670
      _ExtentX        =   20585
      _ExtentY        =   979
      ButtonWidth     =   820
      ButtonHeight    =   926
      AllowCustomize  =   0   'False
      Appearance      =   1
      Style           =   1
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   10
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
            Key             =   "SaveRs"
            Description     =   "����ӻ��޸ĵĿͻ���������"
            Object.ToolTipText     =   "����ͻ�����"
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "����"
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "��λ"
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "1"
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "2"
         EndProperty
         BeginProperty Button7 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "3"
         EndProperty
         BeginProperty Button8 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "4"
         EndProperty
         BeginProperty Button9 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button10 {66833FEA-8583-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
      Begin MSComctlLib.ImageList ImageList1 
         Left            =   5280
         Top             =   120
         _ExtentX        =   1005
         _ExtentY        =   1005
         BackColor       =   -2147483643
         MaskColor       =   12632256
         _Version        =   393216
      End
   End
   Begin UFLABELLib.UFLabel LblNote 
      Height          =   195
      Left            =   240
      TabIndex        =   158
      Top             =   8775
      Width           =   570
      _Version        =   65536
      _ExtentX        =   1005
      _ExtentY        =   344
      _StockProps     =   111
      Caption         =   "Label26"
      AutoSize        =   -1  'True
   End
   Begin UFToolBarCtrl.UFToolbar TLB2 
      Height          =   244
      Left            =   0
      TabIndex        =   207
      Top             =   0
      Width           =   8301
      _ExtentX        =   14631
      _ExtentY        =   423
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   570
      Top             =   540
      _ExtentX        =   1905
      _ExtentY        =   529
   End
   Begin UFFormPartner.UFFrmCaption UFFrmCaptionMgr 
      Left            =   0
      Top             =   510
      _ExtentX        =   926
      _ExtentY        =   661
      Caption         =   "Form1"
      DebugFlag       =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Label Label1 
      Caption         =   "Label1"
      Height          =   495
      Left            =   5280
      TabIndex        =   257
      Top             =   3840
      Width           =   1215
   End
End
Attribute VB_Name = "FrmZAM"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit
Dim opt As Integer  '��ʾ�������� 0:�޲�����1����ӣ�2���޸�
'Dim tOpt As Integer 'ˢ�±�־
Dim m_bAdd As Boolean '��ʾ��ӳɹ���
Dim iCol As Integer '��������
Dim lRow As Long '����
Dim bSave As Boolean '�Ƿ���Ա���
'Const STR_ROP = "ROP��"
'Dim strBATCHRULE(6) As String '��������
 
Dim m_iChangedAdvanceRW As Integer '�䶯��ǰ�ڶ�дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
Dim m_fAlterBaseNumRW As Integer '���䶯��������дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
Dim m_cInvcodeRW As Integer ''��������롿��дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
'Dim m_dSDateRW As Integer '���������ڡ���дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
Dim m_fDTRateRW As Integer '�������%����дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
Dim m_fDTNumRW As Integer '���������
Dim m_iDTStyleRW As Integer '�������ϸ�ȡ�
Dim m_iDaysRW As Integer '��ÿ�µ�X�졿
Dim m_fFixedBatchRW As Integer '���̶�������
Dim m_fVagQuantityRW As Integer '���վ�������
Dim m_fBatchIncrementRW As Integer '������������
'Dim m_iOrderIntervalDaysRW As Integer '���������������
Dim m_iAssureProvideDaysRW As Integer '����֤��Ӧ������
Dim m_iROPMethodRW As Integer '���ٶ����㷽����
Dim m_fSubscribePointRW As Integer '���ٶ����㡿
Dim m_bFilling As Boolean '�Ƿ�����д����
Dim m_EleUserDef As IXMLDOMElement '�Զ������Element
Dim m_CopycInvCode As String '���ƵĴ������
Public m_SaveXML As String '�����XML��ʽ��
Dim m_bFirstLoad As Boolean '�Ƿ��״μ���
Dim m_TradeTabCaption As String '��װ��ҵ���Tab��Caption
Dim m_oldExchRate As String       '�޸�ǰ�Ļ�����
Dim m_DefaultGroupCode As String  'Ĭ�ϼ�����λ�����
Dim m_SetingBillCode As Boolean   '�Ƿ��������õ��ݱ���
Dim m_bInvQualityVal As Integer   '�Ƿ����ڹ���ԭֵ
Dim m_bInvBatchVal As Integer     '�Ƿ����ι���ԭֵ
Dim m_bTrackVal As Integer        '�Ƿ����������ԭֵ

Enum optType
    enuNormal = 0 'һ�����
    enuAddOnly = 1 'ֻ�����ӽ���
    enuQuery = 2 'ֻ�ǲ�ѯ
End Enum

Dim m_optType As optType '��������

Dim m_plugins As New Collection '�������
Dim m_bPlugIns As Boolean '�Ƿ��в��
Dim cRelArchive(16), cRelField(16) As String
Dim Invcinvcode As String
Dim m_billFormat As String
Dim m_bCreateBillNum As Boolean '�Ƿ����¹������ݱ��
Dim m_bReadOnly As Boolean      '�����Ƿ�ֻ��
Dim m_bManualChangeCode As Boolean '�Ƿ��ֹ��Ĺ�����

Dim m_ObjRule  As Object            '����������Ŀ����ֶα���������
Dim m_bRule As Boolean              '�Ƿ�������������Ŀ����ֶα���

Public Property Get OperationType() As Integer
    OperationType = opt
End Property

'---------------------------------------
'���ܣ����õ���ά������ʱ����ʼ������
'������Status��1�����;2���޸�
'   tRsCard���������ݼ�
'   RowSel:����FrmInv.Grid��ѡ����
'---------------------------------------
Public Sub InitData(ByVal Status As Integer, ByVal tCol As Integer, ByVal RowSel As Long)
    Call RuleInit
    SSTab1.Enabled = False 'Ŀ�ģ��ڴ���޸Ľ����ڣ�˫���򿪴�������޸ģ�˫��λ�����ض�λ�û��Զ���ѡ�����Ӧ������
    m_optType = enuNormal
    opt = Status
    iCol = tCol
    lRow = RowSel
    m_bAdd = False
    InitGridUnit
    Select Case opt
        Case 1
            UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.addinv")) '"���Ӵ������" 'LoadResString(2002)
        Case 2
            m_CopycInvCode = ""
            
            Invcinvcode = FrmMain.Grid.TextMatrix(FrmMain.Grid.Row, 2)
            
            UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.modifyinv861")) ' "�޸Ĵ������" 'LoadResString(2003)
            If FrmMain.Grid.Rows = 2 Then
                Tlb.Buttons("First").Enabled = True
                Tlb.Buttons("Previous").Enabled = True
                Tlb.Buttons("Next").Enabled = False
                Tlb.Buttons("Last").Enabled = False
            End If
        Case Else
    End Select
    
End Sub

Public Function Init(tOpt As Integer, Ele As IXMLDOMElement, Optional objLog As Object) As Boolean
    
    Init = False
    opt = tOpt
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    InitAccSet '�����г�����ʼ�����ɵ���˳��
    ConstInit
    InitUserDef
    Call Initialize
    InitGridUnit
    Select Case tOpt
        Case 11
            m_optType = optType.enuAddOnly
            UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.addinv")) '"���Ӵ������" 'LoadResString(2002)
            Me.Tlb.Buttons(2).Visible = False '����
            Me.Tlb.Buttons(4).Visible = False
            Me.Tlb.Buttons(5).Visible = False
            Me.Tlb.Buttons(6).Visible = False
            Me.Tlb.Buttons(7).Visible = False
            Me.Tlb.Buttons(8).Visible = False
            If g_oPub.XMLToRs(SrvDB, "inventory", Rs, Ele) = False Then Exit Function
            Call FillAllFieldsByRs(Rs)
            Call InitDefaultParam
            opt = 1
        Case 13, 14
            m_optType = optType.enuQuery
            UFFrmCaptionMgr.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.inventoryarch") ' "�������"
            FrmMain.m_bEdit = False
            If tOpt = 13 Then
                Dim cInvCode As String
                Dim EleTemp As IXMLDOMElement
                Set EleTemp = Ele.selectSingleNode("cinvcode")
                If Not (EleTemp Is Nothing) Then
                    cInvCode = EleTemp.Text
                End If
                If Len(Trim(cInvCode)) = 0 Then
                    ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cinvcode_notnull") '"������벻��Ϊ�գ�"
                    Exit Function
                End If
                Set Rs = GetInvData(cInvCode)
                If Rs.RecordCount = 0 Then
                    ReDim g_arr(1 To 1)
                    g_arr(1) = cInvCode
                    ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.3470_1", g_arr) 'U8.AA.INVENTORY.FRMZAM.3470_1="������룺{0}���ܱ���������Աɾ����"
                    Exit Function
                End If
                Call FillAllFieldsByRs(Rs)
            Else
                Call FillAllFieldsByRs(objLog.RecordSets("Inventory"), CallType.enuBrowseLog, objLog)
            End If
            InvFree1.ReadOnly = True
            Tlb.Visible = False
            TLB2.Visible = False
            Frame6.Visible = False
            ShowKeyInfo1.Top = 0
            SSTab1.Top = 5 * Screen.TwipsPerPixelY + ShowKeyInfo1.Height
            Me.Height = SSTab1.Top + SSTab1.Height + 30 * Screen.TwipsPerPixelY
    End Select
    Call RuleInit '��ú���ʹ��m_optTypeֵ�����ú�
    Init = True
    Call g_oPub.ReRefreshUFTlb(Me)
End Function

Private Sub InitGridUnit()
    With GridUnit
        .Cols = 4
        .FixedCols = 2
        .TextMatrix(0, 0) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.code") '"����"
        .TextMatrix(0, 1) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.name") '"����"
        .TextMatrix(0, 2) = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.ichangrate") '"������"
        .TextMatrix(0, 3) = "" '"������"
        .FixedAlignment(0) = 4
        .FixedAlignment(1) = 4
        .FixedAlignment(2) = 4
        .ColAlignment(0) = 1
        .ColAlignment(1) = 1
        .ColAlignment(2) = 7
        .SetColProperty 2, , , EditDbl, g_iExchRateDecDgt
        .ColTextWidth(2) = 16
        .ColWidth(0) = .Width / 3 - 2 * Screen.TwipsPerPixelX
        .ColWidth(1) = .ColWidth(0)
        .ColWidth(2) = .ColWidth(0)
        .ColWidth(3) = 0
    End With
End Sub


'---------------------------------------
'���ܣ����ѡ�����Ķ�Ӧ���ݼ�
'���أ���Ӧ��������ݼ�
'---------------------------------------
Private Function GetRs() As ADODB.Recordset
    Static bFalg As Boolean
    If FrmMain.Grid.Rows <= 1 Then
        Tlb.Buttons("First").Enabled = False
        Tlb.Buttons("Previous").Enabled = False
        Tlb.Buttons("Next").Enabled = False
        Tlb.Buttons("Last").Enabled = False
    ElseIf lRow = 1 And FrmMain.Grid.Rows = 2 Then
        Tlb.Buttons("First").Enabled = Not Tlb.Buttons("First").Enabled
        Tlb.Buttons("Previous").Enabled = Not Tlb.Buttons("Previous").Enabled
        Tlb.Buttons("Next").Enabled = Not Tlb.Buttons("Next").Enabled
        Tlb.Buttons("Last").Enabled = Not Tlb.Buttons("Last").Enabled
        If Tlb.Buttons("First").Enabled = Tlb.Buttons("Last").Enabled Then
            Tlb.Buttons("First").Enabled = Not Tlb.Buttons("First").Enabled
            Tlb.Buttons("Previous").Enabled = Not Tlb.Buttons("Previous").Enabled
        End If
    ElseIf lRow = 1 Then
        Tlb.Buttons("First").Enabled = False
        Tlb.Buttons("Previous").Enabled = False
        Tlb.Buttons("Next").Enabled = True
        Tlb.Buttons("Last").Enabled = True
    ElseIf lRow = FrmMain.Grid.Rows - 1 Then
        Tlb.Buttons("First").Enabled = True
        Tlb.Buttons("Previous").Enabled = True
        Tlb.Buttons("Next").Enabled = False
        Tlb.Buttons("Last").Enabled = False
    Else
        Tlb.Buttons("First").Enabled = True
        Tlb.Buttons("Previous").Enabled = True
        Tlb.Buttons("Next").Enabled = True
        Tlb.Buttons("Last").Enabled = True
    End If
    If opt = 1 Then
        If FrmMain.Grid.Rows = 1 Then
            Set GetRs = Nothing
            Exit Function
        End If
        UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.modifyinv861")) ' LoadResString(2003)
        'lRow = 1
        opt = 2
    End If
    
    lRow = IIf(lRow < 1, 1, lRow)
    lRow = IIf(lRow > FrmMain.Grid.Rows - 1, FrmMain.Grid.Rows - 1, lRow)
    Set GetRs = GetInvData(FrmMain.Grid.TextMatrix(lRow, iCol))
End Function

Private Function GetInvData(cInvCode As String) As ADODB.Recordset
    Dim strSql As String
    strSql = "select top 1 * from Inventory left join Inventory_Sub on cInvCode=cInvSubcode where cInvcode='" + cInvCode + "'"
    Set GetInvData = SrvDB.OpenX(strSql)
End Function


'---------------------------------------
'���ܣ��������ڵ�λ��Ͽ���д��Ӧ��������Ͽ�
'---------------------------------------
Private Sub CbocFrequency_Click()
    Call ActiveSaveBtn
    Dim i As Integer
    Dim count As Integer
    CboiDays.Clear
    Select Case CbocFrequency.ListIndex
        Case 0
            count = 0
            If opt = 1 Then
                EdtdLastDate = g_CurDate
            End If
        Case 1
            count = 7
        Case 2
            count = 31
    End Select
    For i = 1 To count
    CboiDays.AddItem CStr(i), i - 1
    Next i
    ReDim g_arr(1 To 1)
    g_arr(1) = CbocFrequency.Text
    LblCboiDays.Caption = g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.135_1", g_arr) 'U8.AA.INVENTORY.FRMZAM.135_1="ÿ{0}��"

    
'    If CbocFrequency.ListIndex = 1 Then
'        CboiDays.AddItem "�µ�", count
'    End If
    If CbocFrequency.ListIndex <> -1 And count > 0 Then
        CboiDays.ListIndex = 0
        If m_iDaysRW = 2 Then
            CboiDays.Enabled = True
        End If
    Else
        CboiDays.ListIndex = -1
        CboiDays.Enabled = False
    End If
    WeekToolTip
End Sub

Private Sub WeekToolTip()
    Dim sTemp As String
    'If CbocFrequency.Text <> "��" Then
    If CbocFrequency.ListIndex <> 1 Or CbocFrequency.ListIndex = -1 Then
        sTemp = vbNullString
    Else
    On Error Resume Next '��ֹCboiDays.TextΪ�յ�
    sTemp = weekDay(CInt(CboiDays.Text))
'        Select Case CboiDays.Text
'            Case "1"
'                sTemp = "������"
'            Case "2"
'                sTemp = "����һ"
'            Case "3"
'                sTemp = "���ڶ�"
'            Case "4"
'                sTemp = "������"
'            Case "5"
'                sTemp = "������"
'            Case "6"
'                sTemp = "������"
'            Case "7"
'                sTemp = "������"
'        End Select
    End If
    CboiDays.UTooltipText = sTemp
End Sub


Private Sub CbocValueType_Click()
    Call ActiveSaveBtn
End Sub

Private Sub CboiDays_Click()
    Call ActiveSaveBtn
    WeekToolTip
End Sub

Private Sub ChkbAccessary_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbBondedInv_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbATOModel_Click()
    SetCheckbModelEnabled
    If m_bFilling = True Then Exit Sub
    Call ActiveSaveBtn
    
    If ChkbATOModel.Value = 1 And g_oPub.ExistSpecialVersionType(SrvDB, 2) Then   '��ͨ�Ǳ�ר��
        ChkbInvModel.Tag = "uncheck" '��ʱ����飬��ֹ���Ի����ֱ�ȡ��
        ChkbInvModel.Value = 1 '��������ΪATOʱ����ģ�͡�ӦΪĬ��Ϊ�ǿɸģ�
        ChkbInvModel.Tag = ""
    End If
    
    '����ATOʱ��ģ��Ĭ�ϲ�ѡ��2008-01-21 ��С��
'    If ChkbATOModel.Value = 1 Then
'        ChkbInvModel.Tag = "uncheck" '��ʱ����飬��ֹ���Ի����ֱ�ȡ��
'        ChkbInvModel.Value = 1 '��������ΪATOʱ����ģ�͡�ӦΪĬ��Ϊ�ǿɸģ�
'        ChkbInvModel.Tag = ""
'    End If
    If CheckProperty(ChkbATOModel) = False Then
        ChkbInvModel.Value = 0
        Exit Sub
    End If
'    If ChkbATOModel.Value = 1 Then
'        ChkbInvModel.Value = 1 '��������ΪATOʱ����ģ�͡�ӦΪĬ��Ϊ�ǿɸģ�
'    End If
    Call CheckbModel
    Call CheckbForeExpland
    Call CheckcSRPolicyText
    Call CheckbATOModel
    Call SetchkbBOMMainDefaultVal
    Call SetChkbBOMSubDefaultVal
End Sub

Private Sub CheckbATOModel()
    If m_bFilling = True Then Exit Sub
    
    '���ѡ��ATO���ԣ������Ϊ�������ԡ�
    If ChkbATOModel.Value = 1 And ChkbSelf.Value = 0 Then
        If Me.ActiveControl Is ChkbSelf Then
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.ato_must_bself") '"����ѡ��ATO�����ԣ������ѡ�����ơ����ԣ�"
        Else
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.ato_auto_bself") '"����ѡ��ATO�����ԣ���ϵͳ�Զ�ѡ�����ơ����ԣ�"
        End If
        ChkbSelf.Value = 1
    End If
End Sub

Private Sub CheckcSRPolicyText()
    If m_bFilling = False Then
        If ChkbATOModel.Value = 1 And ChkbInvModel.Value = 1 Then '
            If InvMPS1.cSRPolicyText <> "LP" Then
                If SSTab1.TabVisible(9) = True Then
                    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.201_1") 'U8.AA.INVENTORY.FRMZAM.201_1="����Ϊ��ATO��+��ģ�͡����򡾹������ߡ��Զ�ѡ��LP��"'ģ��
                End If
                InvMPS1.cSRPolicyText = "LP"
            End If
        End If
        'If ChkbATOModel.Value = 1 Then
            Call InvMPS1.CheckCmbcSRPolicy
        'End If
    End If
End Sub

Private Sub ChkbBackInvDT_Click()
    Call ActiveSaveBtn
End Sub

'---------------------------------------
'���ܣ������Ƿ����������󣬶�Ӧ������༭��仯
'---------------------------------------
Private Sub ChkbBarCode_Click()
    Call ActiveSaveBtn
    If ChkbBarCode.Value = 1 Then
        BarCodeEnable True
    Else
        BarCodeEnable False
        EdtcBarCode.Text = ""
    End If
End Sub
'---------------------------------------
'���ܣ�����������༭��״̬
'---------------------------------------
Private Sub BarCodeEnable(bFlag As Boolean)
    LblcBarCode.Enabled = bFlag
    EdtcBarCode.Enabled = IIf(EdtcBarCode.Locked = True, False, bFlag)
End Sub

Private Sub ChkbCheckItem_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbCheckItem)
    Call CheckbEquipment(ChkbCheckItem)
    Call CheckbForeExpland
    Call SetchkbBOMMainDefaultVal
    Call SetChkbBOMSubDefaultVal
End Sub












Private Sub ChkbSrvItem_Click()
    Call ActiveSaveBtn
    Call CheckProperty(chkbSrvItem)
End Sub

Private Sub ChkbPrjMat_Click()
    Call ActiveSaveBtn
    'Call CheckProperty(chkbPrjMat)
    If chkbPrjMat.Value = Checked Then
        EdtfPrjMatLimit.Enabled = True
    Else
        EdtfPrjMatLimit.Enabled = False
    End If
End Sub
Private Sub ChkbInvAsset_Click()
    Call ActiveSaveBtn
    Call CheckProperty(chkbInvAsset)
    Call SetcPlanMethod
    Call CheckbInvAssetMutex(chkbInvAsset)
End Sub
Private Sub ChkbSrvProduct_Click()
    Call ActiveSaveBtn
    Call CheckProperty(chkbSrvProduct)
End Sub

Private Sub ChkbSrvFittings_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbSrvFittings)
End Sub


Private Sub ChkbComsume_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbComsume)
    CheckbServiceMutex
    CheckbInvTypeMutex
End Sub

Private Sub ChkbGetInt_Click()
    ActiveSaveBtn
End Sub
'---------------------------------
'2010-1-12
'����ţ�200912150180 '���ڣ�����GSPʱ,����ҳǩ�ֶ�,�����ڴ������,���ڼ���,�������ڷŵ�����ҳǩ.
'---------------------------------
Private Sub ChkbDTWarnInv2_Click()
    Call ActiveSaveBtn
    If g_bGSP = True Then
        CheckbDTWarnInv2
        'ChkbDTWarnInv.Value = ChkbDTWarnInv2.Value
    End If
End Sub
'---------------------------------
'���ܣ��ж��Ƿ����ڼ���Ϸ���
'������
'2010-1-12
'����ţ�200912150180 '���ڣ�����GSPʱ,����ҳǩ�ֶ�,�����ڴ������,���ڼ���,�������ڷŵ�����ҳǩ.
'---------------------------------
Private Sub CheckbDTWarnInv2()
    If m_bFilling = True Then
        Exit Sub
    End If
    If ChkbDTWarnInv2.Value = 1 Then
        'A.ֻ�е���������Ļ���ҳ�С��Ƿ��ʼ족���ҡ��Ƿ����ڹ����ı�־Ϊ���ǡ�ʱ���������ڴ���Ƿ���顱������༭��
        'B.Ĭ��Ϊ���񡱡�
        If ChkbInvQuality.Value = 0 Or ChkBPropertyCheck2.Value = 0 Then
            If Me.ActiveControl.Name = ChkbDTWarnInv2.Name Then
                ReDim g_arr(1 To 2)
                g_arr(1) = ChkbInvQuality.Caption
                g_arr(2) = ChkBPropertyCheck.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.271_1", g_arr)    'ChkbInvQuality.Caption�ƺ��䶯'U8.AA.INVENTORY.FRMZAM.271_1="������ѡ��{0}���͡�{1}����"
            Else
                ReDim g_arr(1 To 1)
                g_arr(1) = ChkbDTWarnInv.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.275_1", g_arr) 'U8.AA.INVENTORY.FRMZAM.275_1="��{0}��ѡ���Զ�ȡ����"
            End If
            ChkbDTWarnInv2.Value = 0
        End If
    End If
End Sub
Private Sub ChkbDTWarnInv_Click()
    Call ActiveSaveBtn
    CheckbDTWarnInv
End Sub

'---------------------------------
'���ܣ��ж��Ƿ����ڼ���Ϸ���
'������
'---------------------------------
Private Sub CheckbDTWarnInv()
    If m_bFilling = True Then
        Exit Sub
    End If
    If ChkbDTWarnInv.Value = 1 Then
        'A.ֻ�е���������Ļ���ҳ�С��Ƿ��ʼ족���ҡ��Ƿ����ڹ����ı�־Ϊ���ǡ�ʱ���������ڴ���Ƿ���顱������༭��
        'B.Ĭ��Ϊ���񡱡�
        If ChkbInvQuality.Value = 0 Or ChkBPropertyCheck.Value = 0 Then
            If Me.ActiveControl.Name = ChkbDTWarnInv.Name Then
                ReDim g_arr(1 To 2)
                g_arr(1) = ChkbInvQuality.Caption
                g_arr(2) = ChkBPropertyCheck.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.271_1", g_arr)    'ChkbInvQuality.Caption�ƺ��䶯'U8.AA.INVENTORY.FRMZAM.271_1="������ѡ��{0}���͡�{1}����"
            Else
                ReDim g_arr(1 To 1)
                g_arr(1) = ChkbDTWarnInv.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.275_1", g_arr) 'U8.AA.INVENTORY.FRMZAM.275_1="��{0}��ѡ���Զ�ȡ����"
            End If
            ChkbDTWarnInv.Value = 0
        End If
    End If
End Sub

Private Sub ChkbEquipment_Click()
    Call ActiveSaveBtn
    Call CheckbEquipment(ChkbEquipment)
    Call CheckProperty(ChkbEquipment)
End Sub

Private Sub CheckbEquipment(chk As UFCHECKBOXLib.UFCheckBox)
    If m_bFilling = True Then Exit Sub
    '������ʶ��Ӧ˰���񣬼ƻ�Ʒ��PTO��ѡ���໥��
    Dim bEquipment As Integer
    Dim bService As Integer, bPlanInv As Integer, bPTOModel As Integer, bCheckItem As Integer
    bEquipment = ChkbEquipment.Value
    bService = ChkbService.Value
    bPlanInv = ChkbPlanInv.Value
    bPTOModel = ChkbPTOModel.Value
    bCheckItem = ChkbCheckItem.Value
    
    If bEquipment = 1 And (bService = 1 Or bPlanInv = 1 Or bPTOModel = 1 Or bCheckItem = 1) Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.299_1") 'U8.AA.INVENTORY.FRMZAM.299_1="������������������Ӧ˰���񡿣����ƻ�Ʒ������PTO������ѡ���ࡿ���Ի��⣡"
        chk.Value = 0
        Exit Sub
    End If
End Sub

Private Sub ChkbFirstBusiMedicine_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbImportMedicine_Click()
    Call ActiveSaveBtn
End Sub

'Private Sub ChkbFixExch_Click()
'    Tlb.Buttons("SaveRs").Enabled = True
'End Sub

'Private Sub ChkbFixCheck_Click()
'    If ChkbFixCheck.Value = 1 Then
'        Call FreqEnable(True)
'    Else
'        Call FreqEnable(False)
'    End If
'End Sub

'Private Sub FreqEnable(bFlag As Boolean)
'    LbliFrequency.Enabled = bFlag
'    EdtiFrequency.Enabled = bFlag
'    LblcFrequency.Enabled = bFlag
'    CbocFrequency.Enabled = bFlag
'    LblCboiDays.Enabled = bFlag
'    CboiDays.Enabled = bFlag
'    LblCboiDays2.Enabled = bFlag
'End Sub

'---------------------------------------
'���ܣ������Ƿ����ι���Check��
'---------------------------------------
Private Sub ChkbInvBatch_Click()
    '��������е���������ҳǩ��ֻ�д�����������ι���ʱ������ʾ��ҳǩ��������ʾ��
    If ChkbInvBatch.Value = Checked Then
        SSTab1.TabVisible(6) = True
    Else
        SSTab1.TabVisible(6) = False
    End If
    If m_bFilling = True Then Exit Sub
    Call AlarmCancelOption(ChkbInvBatch, m_bInvBatchVal)
'    If opt = 2 Then
'        If m_bInvBatchVal = 1 And ChkbInvBatch.Value = Unchecked Then
'            'U8.AA.ARCHIVE.COMMON.binvbatch_update_alarm=ע�⣺�����ѷ���ҵ��Ĵ���������ι����Ϊ�����ι���󣬽������ٴӷ����ι����Ϊ������\n��ȷ���Ƿ��޸ģ�
'            If g_oPub.MsgBox(g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.binvbatch_update_alarm"), vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbNo Then
'                ChkbInvBatch.Value = Checked
'            End If
'        End If
'    End If
    Call ActiveSaveBtn
    If ChkbInvQuality.Enabled = True And (ChkbInvQuality.Value = 1) Then
        ChkbInvQuality.Value = 0
        EdtiMassDate = ""
        EdtdWarnDays = ""
    End If
End Sub

Private Sub AlarmCancelOption(chk As UFCheckBox, realVal As Integer)
    If m_bFilling = True Then Exit Sub
'    �ڴ���������޸Ĵ������ʱ�������ǰ�������ҵ�񵥾���ʹ�ã����ҽ����Ƿ����ι��������Ƿ����ڹ������Ƿ���������⡱�����Ǹ�Ϊ��ʱ��Ҫ�ڴ������ʱ��ʾ�ֱ��û���
'    ���˴������ҵ�񵥾���ʹ�ã����ȡ�����ι������޷������ã���ȷ���Ƿ�������棿��
'    ���˴������ҵ�񵥾���ʹ�ã����ȡ�������ڹ������޷������ã���ȷ���Ƿ�������棿��
'    ���˴������ҵ�񵥾���ʹ�ã����ȡ�����������⣬���޷������ã���ȷ���Ƿ�������棿��
    If opt = 2 Then
        If chk.Value = Unchecked And realVal = 1 Then
            '���ȡ��[{0}]�����˴������ҵ�񵥾���ʹ�ã����޷������ã���ȷ���Ƿ�ȡ����ѡ�
            ReDim g_arr(0 To 3)
            g_arr(0) = chk.Caption
            g_arr(1) = g_arr(0)
            g_arr(2) = g_arr(0)
            g_arr(3) = g_arr(0)
            If g_oPub.MsgBox(g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.cancel_it_not_use_it_again", g_arr), vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbNo Then
                m_bFilling = True
                chk.Value = Checked
                m_bFilling = False
            End If
        End If
    End If
End Sub


Private Sub ChkbInvEntrust_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbPiece_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbInvModel_Click()
    If m_bFilling = True Or ChkbInvModel.Tag = "uncheck" Then Exit Sub
    Call ActiveSaveBtn
    Call CheckbModel
    Call CheckbForeExpland
    CheckcSRPolicyText
End Sub

Private Sub CheckbModel()
    If m_bFilling = True Then Exit Sub
    '���ѡ��PTO���ԣ������Ĭ��Ϊ�ǣ��������޸ģ�
    '���ѡ��ATO���ԣ������Ĭ��Ϊ�ǣ������޸ģ�
    '���ѡ������Բ�����PTO��ATO�������Ĭ��Ϊ�񣬲������޸ġ�
    If ChkbPTOModel.Value = 1 Then
        'ChkbInvModel.Value = 1
    ElseIf ChkbATOModel.Value = 1 Then
    Else
        ChkbInvModel.Value = 0
    End If
End Sub

'----------------------------------------------------
'���ܣ�����ChkbInvModel�״̬
'----------------------------------------------------
Private Sub SetCheckbModelEnabled()
'    If ChkbPTOModel.Value = 1 Then
'        ChkbInvModel.Enabled = False
'    ElseIf ChkbATOModel.Value = 1 Then
'        ChkbInvModel.Enabled = True
'    Else
'        ChkbInvModel.Enabled = False
'    End If
End Sub

Private Sub CheckbForeExpland()
    '��1��ѡ���ࡢPTO���ԵĴ��Ĭ��Ϊ"��"���ɸģ�
    'ATO+ģ�͡��ƻ�Ʒ���ԵĴ��Ĭ��Ϊ"��"�ɸģ�
    '�������ԵĴ��Ĭ��Ϊ"��"���ɸġ���2��ϵͳ����ʱ���˹���Ĭ�ϡ�
    If ChkbPTOModel.Value = 1 Or ChkbCheckItem.Value = 1 Then
        InvMPS1.Control_ChkbForeExpland.Enabled = False
    ElseIf (ChkbATOModel.Value = 1 And ChkbInvModel.Value = 1) Or ChkbPlanInv.Value = 1 Then
        InvMPS1.Control_ChkbForeExpland.Enabled = True
    Else
        InvMPS1.Control_ChkbForeExpland.Enabled = False
    End If
    If m_bFilling = True Then Exit Sub
    
    If ChkbPTOModel.Value = 1 Or ChkbCheckItem.Value = 1 Then
        InvMPS1.Control_ChkbForeExpland.Value = 1
    ElseIf (ChkbATOModel.Value = 1 And ChkbInvModel.Value = 1) Or ChkbPlanInv.Value = 1 Then
        InvMPS1.Control_ChkbForeExpland.Value = 1
    Else
        InvMPS1.Control_ChkbForeExpland.Value = 0
    End If
End Sub

Private Sub ChkbInvOverStock_Click()
    Call ActiveSaveBtn
End Sub

'---------------------------------------
'���ܣ������Ƿ����ڹ���Check��
'---------------------------------------
Private Sub ChkbInvQuality_Click()
    If m_bFilling = True Then Exit Sub
    Call ActiveSaveBtn
    If Not (Screen.ActiveForm Is Me) Then Exit Sub
    If ChkbInvBatch.Value = 0 And (ChkbInvQuality.Value = 1) Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.355_1") 'U8.AA.INVENTORY.FRMZAM.355_1="����ѡ���Ƿ����ι���"
        ChkbInvQuality = 0
        Exit Sub
    End If
    Call AlarmCancelOption(ChkbInvQuality, m_bInvQualityVal)
    If ChkbInvQuality.Value = 1 Then
        CmbcMassUnit.ListIndex = 3
        QuaEnable True
    Else
        QuaEnable False
        EdtiMassDate.Text = ""
        EdtdWarnDays.Text = ""
        CmbcMassUnit.ListIndex = -1
        cmbiExpiratDateCalcu.ListIndex = 0
    End If
    CheckbPeriodDT
    CheckbDTWarnInv
End Sub

'---------------------------------------
'���ܣ��Ե����Ƿ����ڹ���Check������ö�Ӧ�ؼ��ı༭�״̬
'---------------------------------------
Private Sub QuaEnable(bFlag As Boolean)
    lblcMassUnit.Enabled = bFlag
    CmbcMassUnit.Enabled = bFlag
    lbliExpiratDateCalcu.Enabled = bFlag
    cmbiExpiratDateCalcu.Enabled = bFlag
    LbliMassDate.Enabled = bFlag
    EdtiMassDate.Enabled = IIf(EdtiMassDate.Locked = True, False, bFlag)
    LbldWarnDays.Enabled = bFlag
    EdtdWarnDays.Enabled = IIf(EdtdWarnDays.Locked = True, False, bFlag)
'    CmdDate(5).Enabled = bFlag
End Sub

Private Sub ChkbOutInvDT_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbPeriodDT_Click()
    Call ActiveSaveBtn
    CheckbPeriodDT
    Dim bFlag As Boolean
    bFlag = IIf(ChkbPeriodDT.Value = 1, True, False)
    lblcDTPeriod.Enabled = bFlag
    EdtcDTPeriod.Enabled = bFlag
End Sub
'---------------------------------
'2010-1-12
'����ţ�200912150180 '���ڣ�����GSPʱ,����ҳǩ�ֶ�,�����ڴ������,���ڼ���,�������ڷŵ�����ҳǩ.
'---------------------------------
Private Sub ChkbPeriodDT2_Click()
    Call ActiveSaveBtn
    If g_bGSP = True Then
        CheckbPeriodDT2
        Dim bFlag As Boolean
        bFlag = IIf(ChkbPeriodDT2.Value = 1, True, False)
        lblcDTPeriod2.Enabled = bFlag
        EdtcDTPeriod2.Enabled = bFlag
        'ChkbPeriodDT.Value = ChkbPeriodDT2.Value
    End If
End Sub
'---------------------------------
'���ܣ��ж��Ƿ����ڼ���Ϸ���
'������
'2010-1-12
'����ţ�200912150180 '���ڣ�����GSPʱ,����ҳǩ�ֶ�,�����ڴ������,���ڼ���,�������ڷŵ�����ҳǩ.
'---------------------------------
Private Sub CheckbPeriodDT2()

    '2005-02-23 (Ver861)��������п���ҳǩ�µ�"�Ƿ����ڼ���"ѡ���ΪֻҪ���ʼ�Ĵ��"�Ƿ����ڼ���"�Ϳ�������Ϊ"��"��
    If ChkBPropertyCheck2.Enabled = True Then
        ChkbPeriodDT2.Enabled = True
    Else
        ChkbPeriodDT2.Enabled = False
        EdtcDTPeriod2.Enabled = False
        lblcDTPeriod2.Enabled = False
    End If
    
    If m_bFilling = True Then
        Exit Sub
    End If
    
    If ChkbPeriodDT2.Value = 1 Then
        '����GSP��ֻ���Ƿ��ʼ�Ϊ�����б����ڹ���Ҫ��Ĵ�����Ƿ����ڼ���ſ�ѡ��Ϊ�ǣ�������Ϊ�ң��������������ֻ�л���ҳǩ�е��Ƿ��ʼ�Ϊ��ʱ���Ƿ�������ڲſ�ѡ��Ϊ�ǣ�������Ϊ��
        'Ver861(2005-04-25)     ��������п���ҳǩ�µ�"�Ƿ����ڼ���"ѡ���ΪֻҪ���ʼ�Ĵ��"�Ƿ����ڼ���"�Ϳ�������Ϊ"��"��
        If g_bGSP = True Then
            If ChkBPropertyCheck2.Value = 0 Then 'ChkbInvQuality.Value = 0 Or
                If Me.ActiveControl.Name = ChkbPeriodDT2.Name Then
'                    ReDim g_arr(1 To 2)
'                    g_arr(1) = ChkbInvQuality.Caption
'                    g_arr(2) = ChkBPropertyCheck.Caption '���Ƿ��ʼ졿
'                    ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.271_1", g_arr)  'ChkbInvQuality.Caption�ƺ��䶯'U8.AA.INVENTORY.FRMZAM.271_1="������ѡ��{0}���͡�{1}����"
                    ReDim g_arr(1 To 1)
                    g_arr(1) = ChkBPropertyCheck.Caption '���Ƿ��ʼ졿
                    ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.first_sel_xx", g_arr)  'ChkbInvQuality.Caption�ƺ��䶯'"������ѡ��{0}��"
                Else
                    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.416_1") 'U8.AA.INVENTORY.FRMZAM.416_1="���Ƿ����ڼ��顿ѡ���Զ�ȡ����"
                End If
                ChkbPeriodDT2.Value = 0
            End If
        ElseIf g_bQM = True Then
            If ChkBPropertyCheck2.Value = 0 Then
                If Me.ActiveControl.Name = ChkbPeriodDT2.Name Then
                    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.423_1") 'U8.AA.INVENTORY.FRMZAM.423_1="������ѡ���Ƿ��ʼ졿��"
                Else
                    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.416_1") 'U8.AA.INVENTORY.FRMZAM.416_1="���Ƿ����ڼ��顿ѡ���Զ�ȡ����"
                End If
                ChkbPeriodDT2.Value = 0
            End If
        End If
    End If
    Call cDTPeriodEnabled2(IIf(ChkbPeriodDT2.Value = 1, True, False))
End Sub
'---------------------------------
'���ܣ��ж��Ƿ����ڼ���Ϸ���
'������
'---------------------------------
Private Sub CheckbPeriodDT()

    '2005-02-23 (Ver861)��������п���ҳǩ�µ�"�Ƿ����ڼ���"ѡ���ΪֻҪ���ʼ�Ĵ��"�Ƿ����ڼ���"�Ϳ�������Ϊ"��"��
    If ChkBPropertyCheck.Enabled = True Then
        ChkbPeriodDT.Enabled = True
    Else
        ChkbPeriodDT.Enabled = False
        EdtcDTPeriod.Enabled = False
        lblcDTPeriod.Enabled = False
    End If
    
    If m_bFilling = True Then
        Exit Sub
    End If
    
    If ChkbPeriodDT.Value = 1 Then
        '����GSP��ֻ���Ƿ��ʼ�Ϊ�����б����ڹ���Ҫ��Ĵ�����Ƿ����ڼ���ſ�ѡ��Ϊ�ǣ�������Ϊ�ң��������������ֻ�л���ҳǩ�е��Ƿ��ʼ�Ϊ��ʱ���Ƿ�������ڲſ�ѡ��Ϊ�ǣ�������Ϊ��
        'Ver861(2005-04-25)     ��������п���ҳǩ�µ�"�Ƿ����ڼ���"ѡ���ΪֻҪ���ʼ�Ĵ��"�Ƿ����ڼ���"�Ϳ�������Ϊ"��"��
        If g_bGSP = True Then
            If ChkBPropertyCheck.Value = 0 Then 'ChkbInvQuality.Value = 0 Or
                If Me.ActiveControl.Name = ChkbPeriodDT.Name Then
'                    ReDim g_arr(1 To 2)
'                    g_arr(1) = ChkbInvQuality.Caption
'                    g_arr(2) = ChkBPropertyCheck.Caption '���Ƿ��ʼ졿
'                    ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.271_1", g_arr)  'ChkbInvQuality.Caption�ƺ��䶯'U8.AA.INVENTORY.FRMZAM.271_1="������ѡ��{0}���͡�{1}����"
                    ReDim g_arr(1 To 1)
                    g_arr(1) = ChkBPropertyCheck.Caption '���Ƿ��ʼ졿
                    ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.first_sel_xx", g_arr)  'ChkbInvQuality.Caption�ƺ��䶯'"������ѡ��{0}��"
                Else
                    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.416_1") 'U8.AA.INVENTORY.FRMZAM.416_1="���Ƿ����ڼ��顿ѡ���Զ�ȡ����"
                End If
                ChkbPeriodDT.Value = 0
            End If
        ElseIf g_bQM = True Then
            If ChkBPropertyCheck.Value = 0 Then
                If Me.ActiveControl.Name = ChkbPeriodDT.Name Then
                    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.423_1") 'U8.AA.INVENTORY.FRMZAM.423_1="������ѡ���Ƿ��ʼ졿��"
                Else
                    ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.416_1") 'U8.AA.INVENTORY.FRMZAM.416_1="���Ƿ����ڼ��顿ѡ���Զ�ȡ����"
                End If
                ChkbPeriodDT.Value = 0
            End If
        End If
    End If
    Call cDTPeriodEnabled(IIf(ChkbPeriodDT.Value = 1, True, False))
End Sub
'----------------------------------------------------
'���ܣ�ʹ�������ڴ��ڻ��״̬
'�������״̬��־
'2010-1-12
'����ţ�200912150180 '���ڣ�����GSPʱ,����ҳǩ�ֶ�,�����ڴ������,���ڼ���,�������ڷŵ�����ҳǩ.
'----------------------------------------------------
Private Sub cDTPeriodEnabled2(bFlag As Boolean)
    lblcDTPeriod2.Enabled = bFlag
    EdtcDTPeriod2.Enabled = IIf(EdtcDTPeriod2.Locked = True, False, bFlag)
End Sub
'----------------------------------------------------
'���ܣ�ʹ�������ڴ��ڻ��״̬
'�������״̬��־
'----------------------------------------------------
Private Sub cDTPeriodEnabled(bFlag As Boolean)
    lblcDTPeriod.Enabled = bFlag
    EdtcDTPeriod.Enabled = IIf(EdtcDTPeriod.Locked = True, False, bFlag)
End Sub

Private Sub ChkbPlanInv_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbPlanInv)
    Call CheckbEquipment(ChkbPlanInv)
    Call CheckbForeExpland
    Call SetchkbBOMMainDefaultVal
    Call SetChkbBOMSubDefaultVal
End Sub

Private Sub ChkbProducing_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbProducing)
    CheckbServiceMutex
    CheckbInvTypeMutex
End Sub

'����BOMĸ��
'"�ƻ�Ʒ��ATO��PTO��ѡ���ࡢ���ơ�ί���"Ĭ��Ϊ"��"�ɸģ�"�⹺��"Ĭ��Ϊ"��"�ɸģ������������һ��Ϊ"��"���ɸġ�
Private Sub SetchkbBOMMainDefaultVal()
    If m_bFilling = True Then Exit Sub
    '�򣺼ƻ�Ʒ��ATO��PTO��ѡ���ࡢ���ơ�ί�����Ӧ�ñȡ��⹺���������ȼ���
    If ChkbPurchase.Value = 1 Then
        InvMPS1.bBOMMain = 0
    End If
    
    If ChkbPlanInv.Value = 1 Or ChkbATOModel.Value = 1 Or ChkbPTOModel.Value = 1 Or ChkbCheckItem.Value = 1 Or ChkbSelf.Value = 1 Or ChkbProxyForeign.Value = 1 Then
        InvMPS1.bBOMMain = 1
    ElseIf ChkbPlanInv.Value = 0 Or ChkbATOModel.Value = 0 Or ChkbPTOModel.Value = 0 Or ChkbCheckItem.Value = 0 Or ChkbSelf.Value = 0 Or ChkbProxyForeign.Value = 0 Then
        InvMPS1.bBOMMain = 0
    End If
    
End Sub

'����BOM�Ӽ�
'"�ƻ�Ʒ��ATO��PTO��ѡ���ࡢ���ơ�ί������⹺��"Ĭ��Ϊ"��"�ɸģ������������һ��Ϊ"��"���ɸġ�
Private Sub SetChkbBOMSubDefaultVal()
    If m_bFilling = True Then Exit Sub
    If ChkbPlanInv.Value = 1 Or ChkbATOModel.Value = 1 Or ChkbPTOModel.Value = 1 Or ChkbCheckItem.Value = 1 Or ChkbSelf.Value = 1 Or ChkbProxyForeign.Value = 1 Or ChkbPurchase.Value = 1 Then
        InvMPS1.bBOMSub = 1
    ElseIf ChkbPlanInv.Value = 0 Or ChkbATOModel.Value = 0 Or ChkbPTOModel.Value = 0 Or ChkbCheckItem.Value = 0 Or ChkbSelf.Value = 0 Or ChkbProxyForeign.Value = 0 Or ChkbPurchase.Value = 0 Then
        InvMPS1.bBOMSub = 0
    End If
End Sub

'������������
'"����"����Ĭ��Ϊ"��"�ɸģ�"ί�⡢�⹺"����Ĭ��Ϊ"��"�ɸģ������������һ��Ϊ"��"���ɸġ�����������
Private Sub SetChkbProductBillDefaultVal()
    If m_bFilling = True Then Exit Sub
    If ChkbPurchase.Value = 1 Or ChkbProxyForeign.Value = 1 Then
        InvMPS1.bProductBill = 0
    End If
    If ChkbSelf.Value = 1 Then
        InvMPS1.bProductBill = 1
    End If
End Sub

Private Sub CheckIsSalesServiceDiscount()
'    If Me.ActiveControl Is ChkbPromotSales Then
'        If ChkbPromotSales.Value = 1 Then
'            If ChkbService.Value = 1 Then
'                ChkbService.Value = 0
'                ShowMsg "���Ƿ����Ʒ���롾Ӧ˰���񡿺͡��Ƿ��ۿۡ�ѡ���!"
'            End If
'            If ChkbInvType.Value = 1 Then
'                ChkbInvType.Value = 0
'                ShowMsg "���Ƿ����Ʒ���롾Ӧ˰���񡿺͡��Ƿ��ۿۡ�ѡ���!"
'            End If
'        End If
'    ElseIf (ChkbInvType.Value = 1) Or (ChkbService.Value = 1) Then
'        If ChkbPromotSales.Value = 1 Then
'            ChkbPromotSales.Value = 0
'            ShowMsg "���Ƿ����Ʒ���롾Ӧ˰���񡿺͡��Ƿ��ۿۡ�ѡ���!"
'        End If
'    End If
End Sub

Private Sub ChkbPromotSales_Click()
    ActiveSaveBtn
    CheckIsSalesServiceDiscount
End Sub

Private Sub ChkBPropertyCheck_Click()
    Call ActiveSaveBtn
    CheckbPeriodDT
    CheckbDTWarnInv
    SetPropertyCheck
    If (g_bQM = True) Then
        Call SetEdtcDTUnitVal
    End If
    '�����������ã�"�Ƿ��ʼ�"���ܼ�����λ�����
    If (ChkBPropertyCheck.Value = 0) Or (g_bQM = True) Then
        Exit Sub
    End If
    SetChkBPropertyCheck
    
    
End Sub

Private Sub ChkBPropertyCheck2_Click()
    If g_bGSP = True Then
        Call ActiveSaveBtn
        CheckbPeriodDT2
        CheckbDTWarnInv2
        'SetPropertyCheck
'        If (g_bQM = True) Then
'            Call SetEdtcDTUnitVal
'        End If
        '�����������ã�"�Ƿ��ʼ�"���ܼ�����λ�����
        If (ChkBPropertyCheck.Value = 0) Then
            Exit Sub
        End If
        SetChkBPropertyCheck2
        'ChkBPropertyCheck.Value = ChkBPropertyCheck2.Value
    End If
End Sub

'-------------------------------------------
'���ܣ������Ƿ��ʼ����
'-------------------------------------------
Private Sub SetChkBPropertyCheck()
    '����ļ�����λ��Ļ�����Ϊ�̶������ʻ��޻����ʵĴ��Ϊ��ѡ����������λ�黻����Ϊ���������ʵĴ�����Ƿ��ʼ�Ϊ����ѡ����Ŀ��
    If g_bGSP = True And ChkBPropertyCheck.Value = 1 Then
        If CmbiGroupType.ListIndex = -1 Then
            ChkBPropertyCheck.Value = 0
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.firstselgroup") '"����ѡ�������λ�飡"
        ElseIf CmbiGroupType.ListIndex = 2 Then
            ChkBPropertyCheck.Value = 0
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.505_1") 'U8.AA.INVENTORY.FRMZAM.505_1="GSP������������ʱ���������������'�Ƿ��ʼ�'����ѡ��"
        Else
        End If
    End If
End Sub
'-------------------------------------------
'���ܣ������Ƿ��ʼ����
'-------------------------------------------
Private Sub SetChkBPropertyCheck2()
    '����ļ�����λ��Ļ�����Ϊ�̶������ʻ��޻����ʵĴ��Ϊ��ѡ����������λ�黻����Ϊ���������ʵĴ�����Ƿ��ʼ�Ϊ����ѡ����Ŀ��
    If g_bGSP = True And ChkBPropertyCheck2.Value = 1 Then
        If CmbiGroupType.ListIndex = -1 Then
            ChkBPropertyCheck2.Value = 0
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.firstselgroup") '"����ѡ�������λ�飡"
        ElseIf CmbiGroupType.ListIndex = 2 Then
            ChkBPropertyCheck2.Value = 0
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.505_1") 'U8.AA.INVENTORY.FRMZAM.505_1="GSP������������ʱ���������������'�Ƿ��ʼ�'����ѡ��"
        Else
        End If
    End If
End Sub

Private Sub ChkbProxyForeign_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbProxyForeign)
    Call SetChkbProductBillDefaultVal
    Call SetchkbBOMMainDefaultVal
    Call SetChkbBOMSubDefaultVal
End Sub

Private Sub ChkbPTOModel_Click()
    SetCheckbModelEnabled
    Call ActiveSaveBtn
    Call CheckProperty(ChkbPTOModel)
    ' V870 ����÷ 2006-06-05 PTO��PTO��ģ���ڴ�����ԵĿ�����ȡ��һ�£������������Ի���
    '����PTOʱ��ģ��Ĭ�ϲ�ѡ��2008-01-21 ��С��
'    If ChkbPTOModel.Value = 1 Then
'        ChkbInvModel.Value = 1
'    End If
    Call CheckbEquipment(ChkbPTOModel)
    Call CheckbModel
    Call CheckbForeExpland
    Call SetchkbBOMMainDefaultVal
    Call SetChkbBOMSubDefaultVal
End Sub

Private Sub ChkbPurchase_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbPurchase)
    Call SetChkbProductBillDefaultVal
    Call SetchkbBOMMainDefaultVal
    Call SetChkbBOMSubDefaultVal
End Sub

Private Sub ChkbReceiptByDT_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbInByProCheck_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbInvROHS_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbSale_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbSale)
End Sub

Private Sub ChkbExpSale_Click()
    Call ActiveSaveBtn
    Call CheckProperty(chkbExpSale)
End Sub

Private Sub ChkbSelf_Click()
    Call ActiveSaveBtn
    If CheckProperty(ChkbSelf) = False Then Exit Sub
    Call CheckbATOModel
    If m_bFilling = False Then
        Call InvMPS1.CheckRePlan
    End If
    If m_bFilling = False Then '��ֹ��дǰ���ֶ�ʱ���ܺ����ֶο���
        CheckbSelfbROP
    End If
    CheckbServiceMutex
    CheckbInvTypeMutex
    Call SetChkbProductBillDefaultVal
    Call SetchkbBOMMainDefaultVal
    Call SetChkbBOMSubDefaultVal
    
'''    If m_bFilling = False Then '��ֹ��дǰ���ֶ�ʱ���ܺ����ֶο���
'''        If ChkbSelf.Value = 1 Then
'''            If InvPlan1.IPlanPolicyText = STR_ROP Then
'''                ShowMsg ("�򡰼ƻ���ҳǩ�мƻ�����ѡ��Ϊ��" + STR_ROP + "�����ʲ���ѡ��á��������ԡ���")
'''                ChkbSelf.Value = 0
'''            End If
'''        End If
'''    End If
'''    InvPlan1.BSelfValue = ChkbSelf.Value
End Sub



'---------------------------------------
'���ܣ������Ƿ����кŹ���Check��
'---------------------------------------
Private Sub ChkbSerial_Click()
    Call ActiveSaveBtn
    'Version870  2006-5-15 ������Ҫ��ȥ������
'    If ChkbTrack.Value = 1 And ChkbSerial.Value = 1 Then
'        ChkbTrack.Value = 0
'    End If
    'If ChkbSerial.Enabled = True Then Call ChkUnique(ChkbSerial)
End Sub

Private Sub ChkbService_Click()
    Call ActiveSaveBtn
    Call CheckProperty(ChkbService)
    CheckIsSalesServiceDiscount
    CheckbServiceMutex
    Call CheckbEquipment(ChkbService)
End Sub

'-------------------------------------------
'���ܣ����Ӧ˰��������Ӧ�����ơ����ơ������������Ի���
'-------------------------------------------
Private Sub CheckbServiceMutex()
    On Error GoTo Err_Info
    If m_bFilling = False Then
        If ChkbService.Value = 1 Then
            ReDim g_arr(1 To 2)
            g_arr(1) = ChkbService.Caption
            If ChkbComsume.Value = 1 Then
                g_arr(2) = ChkbComsume.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.propertymutex", g_arr) '"��Ӧ˰���������롾�������á����Ի��⣡"
                Me.ActiveControl.Value = 0
            ElseIf ChkbSelf.Value = 1 Then
                g_arr(2) = ChkbSelf.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.propertymutex", g_arr) '"��Ӧ˰���������롾���ơ����Ի��⣡"
                Me.ActiveControl.Value = 0
            ElseIf ChkbProducing.Value = 1 Then
                g_arr(2) = ChkbProducing.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.propertymutex", g_arr) '"��Ӧ˰���������롾���ơ����Ի��⣡"
                Me.ActiveControl.Value = 0
            End If
        End If
    End If
    Exit Sub
Err_Info:
End Sub

'-------------------------------------------
'���ܣ�"�ʲ�"��"�������"������ѡ��Ĺ�ϵ�������߲���ͬʱѡ��
'-------------------------------------------
Public Sub CheckbInvAssetMutex(Con As UFCheckBox)
    On Error GoTo Err_Info
    If m_bFilling = False Then
        If chkbInvAsset.Value = 1 Then
            ReDim g_arr(1 To 2)
            g_arr(1) = chkbInvAsset.Caption
            If InvOther1.bPUQuota = 1 Then
                g_arr(2) = InvOther1.Caption_bPUQuota
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mutex_eachother", g_arr) '"���ʲ����롾���������⣡"
                Con.Value = 0
            End If
        End If
    End If
    Exit Sub
Err_Info:
End Sub

'-------------------------------------------
'���ܣ���顾�Ƿ��ۿۡ�����Ӧ�����ơ����ơ������������Ի��� 2005-06-10
'-------------------------------------------
Private Sub CheckbInvTypeMutex()
    On Error GoTo Err_Info
    If m_bFilling = False Then
        If ChkbInvType.Value = 1 Then
            ReDim g_arr(1 To 2)
            g_arr(1) = ChkbInvType.Caption
            If ChkbComsume.Value = 1 Then
                g_arr(2) = ChkbComsume.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.propertymutex", g_arr) '"���Ƿ��ۿۡ������롾�������á����Ի��⣡"
                Me.ActiveControl.Value = 0
            ElseIf ChkbSelf.Value = 1 Then
                g_arr(2) = ChkbSelf.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.propertymutex", g_arr) '"���Ƿ��ۿۡ������롾���ơ����Ի��⣡"
                Me.ActiveControl.Value = 0
            ElseIf ChkbProducing.Value = 1 Then
                g_arr(2) = ChkbProducing.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.propertymutex", g_arr) '"���Ƿ��ۿۡ������롾���ơ����Ի��⣡"
                Me.ActiveControl.Value = 0
            End If
        End If
    End If
    Exit Sub
Err_Info:
End Sub

'---------------------------------------
'���ܣ�ʹ����CheckBox�����ֻѡһ
'������con ��Ӧ��CheckBox��
'---------------------------------------
'Private Sub ChkUnique(Con As Control)
'    ChkbSerial.Enabled = False
'    ChkbInvBatch.Enabled = False
'    ChkbTrack.Enabled = False
'
'    If Con.Name = "ChkbSerial" Then
'        ChkbInvBatch.Value = 0
'        ChkbTrack.Value = 0
'    ElseIf Con.Name = "ChkbInvBatch" Then
'        ChkbSerial.Value = 0
'        ChkbTrack.Value = 0
'    ElseIf Con.Name = "ChkbTrack" Then
'        ChkbSerial.Value = 0
'        ChkbInvBatch.Value = 0
'    End If
'
'    ChkbSerial.Enabled = True
'    ChkbInvBatch.Enabled = True
'    ChkbTrack.Enabled = True
'End Sub

Private Sub ChkbService_KeyPress(KeyAscii As Integer)
    Call ActiveSaveBtn
End Sub

Private Sub ChkbSolitude_Click()
    Call ActiveSaveBtn
End Sub

Private Sub ChkbKCCutMantissa_Click()
    Call ActiveSaveBtn
    If ChkbKCCutMantissa.Value = Checked Then
        Call g_oPub.SetIntLen(EdtiDrawBatch)
    Else
        Call g_oPub.SetDblLen(EdtiDrawBatch, , g_iQuanDecDgt)
    End If
    If m_bFilling = False Then
        On Error Resume Next
        If Len(EdtiDrawBatch.Text) > 0 Then
            If Val(EdtiDrawBatch.Text) <> Val(CLng(EdtiDrawBatch.Text)) Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bkccutmantissa_idrawbatch_int") '"ѡ��[�����Ƿ��г�β��]ʱ��[��������]����Ϊ������"
                EdtiDrawBatch.SetFocus
                Exit Sub '��ǿ��ִ���¾��ʽ��
            End If
        End If
    End If
    Call g_oPub.FormatCon(EdtiDrawBatch)
End Sub

Private Sub ChkbSpecialties_Click()
    Call ActiveSaveBtn
End Sub

'---------------------------------------
'���ܣ������Ƿ����������Check��
'---------------------------------------
Private Sub ChkbTrack_Click()
    Call AlarmCancelOption(ChkbTrack, m_bTrackVal)
    Call ActiveSaveBtn
    'Version870  2006-5-15 ������Ҫ��ȥ������
'    If ChkbSerial.Value = 1 And ChkbTrack = 1 Then
'        ChkbSerial.Value = 0
'    End If
    'If ChkbTrack.Enabled = True Then Call ChkUnique(ChkbTrack)
End Sub

Private Sub ChkFree_Click(Index As Integer)
    Call ActiveSaveBtn
End Sub

Private Sub ChkFree_KeyPress(Index As Integer, KeyAscii As Integer)
    Call ActiveSaveBtn
End Sub

Private Sub ChkbInvType_Click()
    Call ActiveSaveBtn
    CheckIsSalesServiceDiscount
    CheckbInvTypeMutex
End Sub

Private Sub CmbcDTAQL_Click()
    Call ActiveSaveBtn
End Sub

Private Sub CmbcMassUnit_Click()
    On Error GoTo Err_Info
    Call ActiveSaveBtn
    EdtiMassDate.MaxLength = CmbcMassUnit.ListIndex + 1 '��ֻ������λ����ֻ������λ����ֻ������λ��
    EdtiMassDate.Text = Left(EdtiMassDate.Text, EdtiMassDate.MaxLength)
    If Len(CmbcMassUnit.Text) = 0 Then
        EdtiMassDate.Text = ""
    End If
    Exit Sub
Err_Info:
    
End Sub
Private Sub CmbiExpiratDateCalcu_Click()
    Call ActiveSaveBtn
End Sub

Private Sub CmbiDTLevel_Click()
    Call ActiveSaveBtn
End Sub

'Private Sub CmbiBatchRule_Click()
'    ActiveSaveBtn
'    If CmbiBatchRule.Text = strBATCHRULE(2) Then
'        If m_fFixedBatchRW = 2 Then
'            EdtfFixedBatch.Enabled = True
'        End If
'    Else
'        EdtfFixedBatch.Enabled = False
'        EdtfFixedBatch.Text = ""
'    End If
'    ControlEdtfVagQuantity
'End Sub

''-------------------------------------
''���ܣ����ơ��վ��������Ȼ״̬
''-------------------------------------
'Private Sub ControlEdtfVagQuantity()
'    If CmbiROPMethod.Text = "�Զ�" Or CmbiBatchRule.Text = strBATCHRULE(5) Then
'        If m_fVagQuantityRW = 2 Then
'            EdtfVagQuantity.Enabled = True
'        End If
'    Else
'        EdtfVagQuantity.Enabled = False
'        EdtfVagQuantity.Text = ""
'    End If
'
'    '1����"��������"Ϊ�̶�����ʱ�����ֶα��䣬Ĭ��Ϊ1��
'    '2��������ֵӦ�����㣻
'    '3����"��������"Ϊ����ѡ��ʱ���������롣
'    '�����ΪROP��ʱ������������������������롣2003.07.07
'    If CmbiBatchRule.Text = strBATCHRULE(2) And CmbiPlanPolicy.ListIndex <> 2 Then
'        If m_fBatchIncrementRW = 2 Then
'            EdtfBatchIncrement.Enabled = True
'        End If
'    Else
'        EdtfBatchIncrement.Enabled = False
'        EdtfBatchIncrement.Text = ""
'    End If
'
''    '1���������������������������Ϊ���ڼ�������ʱ���ֶο��ֹ����룬�������룬Ĭ��Ϊ1��
''    '2��������ֵӦ���ڵ���0������Ϊ������
''    '3�����򲻿����롣
''    If CmbiBatchRule.Text = strBATCHRULE(3) Then
''        If m_iOrderIntervalDaysRW = 2 Then
''            EdtiOrderIntervalDays.Enabled = True
''        End If
''    Else
''        EdtiOrderIntervalDays.Enabled = False
''        EdtiOrderIntervalDays.Text = ""
''    End If
'
'    '1������֤��Ӧ����������������Ϊ����ʷ��������ʱ���ֶο��ֹ����룬�������룬Ĭ��Ϊ1��
'    '2��������ֵӦ���ڵ���0������Ϊ������
'    '3�����򲻿����롣
'    If CmbiBatchRule.Text = strBATCHRULE(5) Then
'        If m_iAssureProvideDaysRW = 2 Then
'            EdtiAssureProvideDays.Enabled = True
'        End If
'    Else
'        EdtiAssureProvideDays.Enabled = False
'        EdtiAssureProvideDays.Text = ""
'    End If
'End Sub

Private Sub CmbiDTMethod_Click()
    ActiveSaveBtn
    
    EdtfDTRate.Enabled = False
    EdtfDTNum.Enabled = False
'    EdtcDTUnit.Enabled = False
'    Cmd(11).Enabled = False
    If m_bFilling = False Then
        EdtfDTNum.Text = ""
        If CmbiDTMethod.Tag <> "" Then
            CmbiDTMethod.Tag = "" '��ֵ������ȡ����ֵ
'        ElseIf CmbiDTMethod.ListIndex <> 1 Then '�ǹ̶���ȡ��
'            EdtcDTUnit.Text = ""
'            EdtcDTUnit.Tag = ""
'            EdtcDTUnit.UtooltipText = ""
        End If
        CmbiDTStyle.ListIndex = -1
        CmbiEndDTStyle.ListIndex = -1
        cmbiTestRule.ListIndex = 0
        CmbiDTLevel.ListIndex = -1
        CmbcDTAQL.ListIndex = -1
    End If
    CmbiDTStyle.Enabled = False
    CmbiEndDTStyle.Enabled = False
    'cmbiTestRule.Enabled = False
    CmbiDTLevel.Enabled = False
    CmbcDTAQL.Enabled = False
    'SSTabQuality.TabVisible(1) = False
    EdtcRuleCode.Enabled = False
    
    
    Select Case CmbiDTMethod.ListIndex
        Case 0: '���������
            If m_fDTRateRW = 2 Then
                EdtfDTRate.Enabled = True
            End If
        Case 1: '����
            If m_fDTNumRW = 2 Then
                EdtfDTNum.Enabled = True
            End If
        Case 2: '����
            If m_iDTStyleRW = 2 Then
                CmbiDTStyle.Enabled = True
            End If
            Call SetAuthCon(CmbiEndDTStyle, True)
            If CmbcDTAQL.ListCount = 27 Then
                Call CmbcDTAQL.ReMoveItem(26)
            End If
            If m_bFilling = False Then
                CmbiDTStyle.ListIndex = 0
                CmbiEndDTStyle.ListIndex = 0
                CmbiDTLevel.ListIndex = 1
                CmbcDTAQL.ListIndex = 0
            End If
            CmbiDTLevel.Enabled = True '�˴��ؼ�visible=false���򱻿�¡���������Ȩ���ж�
            CmbcDTAQL.Enabled = True
        Case 3: '�������ҳǩ�ĳ�����ѡ�񡰰��Զ���������족�����ѣ�ֵ�ɱ༭�����Բ���AQL����¼��AQLֵ����Ҳ�ɲ�¼�롣Ĭ�Ͽ� 2009-05-19
            'SSTabQuality.TabVisible(1) = True
            EdtcRuleCode.Enabled = True
            If CmbcDTAQL.ListCount = 26 Then
                    CmbcDTAQL.AddItem ""
                End If
            If m_bFilling = False Then
                CmbcDTAQL.ListIndex = 27
            End If
            CmbcDTAQL.Enabled = True
    End Select
    If CmbiDTMethod.ListIndex <> -1 Then
        EdtcDTUnit.Enabled = IIf(EdtcDTUnit.Locked = True, False, EdtcPUComunitCode.Enabled)
'        Cmd(11).Enabled = EdtcDTUnit.Enabled
        If EdtcDTUnit.Text = "" And CmbiGroupType.ListIndex = 0 Then '��ֹ���޸�ȫ��󱣴���ָĳ��ƻ��Լ���Ȼ�ԭ
            SetEdtcDTUnitVal
        End If
    End If
End Sub

Private Sub CmbiDTStyle_Click()
    If CmbiDTStyle.Enabled = True Then
        ActiveSaveBtn
    End If
End Sub

Private Sub CmbiEndDTStyle_Click()
    Call ActiveSaveBtn
End Sub

Private Sub CmbiTestRule_Click()
    Call ActiveSaveBtn
End Sub

Private Sub CmbiGroupType_Click()
    Call ActiveSaveBtn
End Sub



Private Sub CmbiPlanPolicy_GotFocus()
    '�������¼��ʱ��ȫ���̲�����ϵͳ�����У���������ĿΪ��������
    '����������ҳ��������ɺ󣬰��س�,Tab������û�о۽�������ҳ�棬
    '���Ǿ۽������ص�����ҳ���С�
    '��ʱ�����Ƿ�����ѡ�ϣ���ƻ�����ͨ���������°�ť��ѡ��ROP
    If SSTab1.Tab <> 4 Then
        SSTab1.SetFocus
    End If
End Sub



Private Sub CmbiTestStyle_Click()
    ActiveSaveBtn
    Dim bFlag As Boolean
    If CmbiTestStyle.ListIndex = 2 Or CmbiTestStyle.ListIndex = 3 Then
        bFlag = True
        If CmbiDTMethod.ListIndex = -1 Then
            CmbiDTMethod.ListIndex = 0
        End If
    Else
        bFlag = False
    End If
        
    Call SetAuthCon(CmbiDTMethod, bFlag)
    If bFlag = True Then
        CmbiDTMethod_Click 'ǿ��ִ��
    Else
        Call SetAuthCon(CmbiDTStyle, bFlag)
        Call SetAuthCon(EdtfDTRate, bFlag)
        Call SetAuthCon(EdtfDTNum, bFlag)
        Call SetAuthCon(EdtcDTUnit, bFlag)
        Call SetAuthCon(CmbiDTLevel, bFlag)
        Call SetAuthCon(CmbcDTAQL, bFlag)
        Call SetAuthCon(CmbiEndDTStyle, bFlag)
    End If
    If EdtcPUComunitCode.Enabled = False Then
        EdtcDTUnit.Enabled = False
    End If
'    Cmd(11).Enabled = EdtcDTUnit.Enabled
End Sub

'---------------------------------------
'���ܣ�Edt���յĸ�ֵ
'������Con:ָEdit �ؼ�
'      sCode������
'      sName������
'---------------------------------------
Private Sub SetRefEdtValue(ByRef Con As Control, ByVal sCode As String, ByVal sName As String)
    Con.Text = sName
    Con.Tag = sCode
    Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + sCode
End Sub

'---------------------------------------------------
'������󣺼�����λ��ز���
'���ܣ�ȡ�ò������ݣ���Ҫ�Ǳ�������ƣ�
'������sGroupCode:������λ�����
'---------------------------------------------------
Public Sub showOtherUnit(ByVal sGroupCode As String)
    Dim strSql As String
    Dim iType As Integer
    Dim Rs As New ADODB.Recordset
    Dim RsTemp As New ADODB.Recordset
    
    'If (Opt = 2) And (sGroupCode = sCode) Then Exit Sub '�޸�ʱ������򲻸�Ĭ��ֵ
    If Trim(sGroupCode) = "" Then
        Call SetUnitEnable(False)
        Exit Sub
    End If
    strSql = "select top 1 * from ComputationGroup where cGroupCode='" + sGroupCode + "'"
    Set Rs = SrvDB.OpenX(strSql)
    If Rs.RecordCount = 1 Then
        iType = Rs.Fields("iGroupType").Value
        CmbiGroupType.ListIndex = iType
        Select Case CmbiGroupType.ListIndex
            Case 0 '�޻���
                Call SetUnitEnable(False)
                ClearUnitEdt
                CmbiGroupType.ListIndex = iType
            Case 1 '�̶�
                Call SetUnitEnable(True)
            Case 2 '����
                Call SetUnitEnable(True)
        End Select
        Call FillUnitRate(sGroupCode)
        'ChkbFixExch.Value = IIf(CmbiGroupType.ListIndex = 1, 1, 0) '�̶�������
        strSql = "select  * from ComputationUnit where cGroupCode='" + sGroupCode + "' order by cGroupCode ,iNumber" 'bMainUnit=1 and
        Set Rs = SrvDB.OpenX(strSql)
        If Rs.RecordCount >= 1 Then
            Set RsTemp = Filter(Rs, "bMainUnit=1")
            If RsTemp.RecordCount > 0 Then
                EdtcComunitCode.Text = TxtValue(RsTemp.Fields("cComunitCode").Value) ' TxtValue(RsTemp.Fields("CComUnitName").Value)
'''                EdtcComunitCode.Tag = TxtValue(RsTemp.Fields("cComunitCode").Value)
'''                EdtcComunitCode.UTooltipText = g_oPub.getResstring("U8.AA.ARCHIVE.FIELD.codecolon") + EdtcComunitCode.Tag
                SetEdtcDTUnitVal
            End If
            If iType = 0 Then Exit Sub
            
            Set RsTemp = Filter(Rs, "bMainUnit=0")
            If RsTemp.RecordCount > 0 Then
                ' ѡ�������λ���,��Ĭ��Ϊ��һ��������λ��
                Dim sText As String
                Dim sTag As String
                Dim sTip As String
                sText = TxtValue(RsTemp.Fields("CComUnitName").Value)
                sTag = TxtValue(RsTemp.Fields("cComunitCode").Value)
                sTip = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + sTag
                                
                EdtcPUComunitCode.Text = sTag 'sText 'EdtcComunitCode.Text ' TxtValue(RsTemp.Fields("CComUnitName").Value)
                'EdtcDTUnit.Text = IIf(EdtcDTUnit.Enabled = True, sText, "") '��������ҳǩ�м��������λ
                EdtcSAComunitCode.Text = sTag 'sText 'EdtcComunitCode.Text 'TxtValue(RsTemp.Fields("CComUnitName").Value)
                EdtcProductUnit.Text = sTag ' sText
                
'''                EdtcPUComunitCode.Tag = sTag 'EdtcComunitCode.Tag 'TxtValue(RsTemp.Fields("cComunitCode").Value)
'''                'EdtcDTUnit.Tag = IIf(EdtcDTUnit.Enabled = True, sTag, "") '��������ҳǩ�м��������λ
'''                EdtcSAComunitCode.Tag = sTag 'EdtcComunitCode.Tag 'TxtValue(RsTemp.Fields("cComunitCode").Value)
'''                EdtcProductUnit.Tag = sTag
'''
'''                EdtcPUComunitCode.UTooltipText = sTip ' "���룺" + EdtcPUComunitCode.Tag
'''                'EdtcDTUnit.UtooltipText = IIf(EdtcDTUnit.Enabled = True, sTip, "") '��������ҳǩ�м��������λ
'''                EdtcSAComunitCode.UTooltipText = sTip '"���룺" + EdtcSAComunitCode.Tag
'''                EdtcProductUnit.UTooltipText = sTip
                
                EdtcSTComunitCode.Text = sTag ' sText
'''                EdtcSTComunitCode.Tag = sTag
'''                EdtcSTComunitCode.UTooltipText = sTip
                
                EdtcCAComunitCode.Text = sTag ' sText 'TxtValue(RsTemp.Fields("CComUnitName").Value)
'''                EdtcCAComunitCode.Tag = sTag 'TxtValue(RsTemp.Fields("cComunitCode").Value)
'''                EdtcCAComunitCode.UTooltipText = sTip ' "���룺" + EdtcCAComunitCode.Tag
                
                EdtcShopUnit.Text = sTag ' sText
'                EdtcShopUnit.Tag = sTag
'                EdtcShopUnit.UTooltipText = sTip
            End If
        Else
            'ClearUnitEdt
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.1199_1") 'U8.AA.INVENTORY.FRMZAM.1199_1="�ü�����λ��û�м�����λ��\n���ȶԸü�����λ����Ӽ�����λ��"
            Exit Sub
        End If
    Else
        Call SetUnitEnable(False)
    End If

End Sub

'---------------------------------------
'���ܣ����ü�����λ�ؼ��Ļ״̬
'������bFlag���
'---------------------------------------
Private Sub SetUnitEnable(ByVal bFlag As Boolean)
    EdtcPUComunitCode.Enabled = IIf(EdtcPUComunitCode.Locked = True, False, bFlag)
    EdtcDTUnit.Enabled = IIf(EdtcDTUnit.Locked = True, False, bFlag) '��������ҳǩ�м��������λIIf(CmbiDTMethod.ListIndex = 1, bFlag, False)
    EdtcSAComunitCode.Enabled = IIf(EdtcSAComunitCode.Locked = True, False, bFlag)
    EdtcSTComunitCode.Enabled = IIf(EdtcSTComunitCode.Locked = True, False, bFlag)
    EdtcCAComunitCode.Enabled = IIf(EdtcCAComunitCode.Locked = True, False, bFlag)
    EdtcProductUnit.Enabled = IIf(EdtcProductUnit.Locked = True, False, bFlag)
    EdtcShopUnit.Enabled = IIf(EdtcShopUnit.Locked = True, False, bFlag)
    
'    Cmd(6).Enabled = EdtcPUComunitCode.Enabled
'    Cmd(11).Enabled = EdtcDTUnit.Enabled
'    Cmd(7).Enabled = EdtcSAComunitCode.Enabled
'    Cmd(8).Enabled = EdtcSTComunitCode.Enabled
'    Cmd(9).Enabled = EdtcCAComunitCode.Enabled
'    Cmd(13).Enabled = EdtcProductUnit.Enabled
'    Cmd(14).Enabled = EdtcShopUnit.Enabled
End Sub

'---------------------------------------
'���ܣ���ռ�����λEdt
'---------------------------------------
Private Sub ClearUnitEdt()
    EdtcComunitCode = ""
    EdtcPUComunitCode = ""
    EdtcDTUnit.Text = "" '��������ҳǩ�м��������λ
    EdtcProductUnit.Text = ""
    EdtcShopUnit.Text = ""
    EdtcSAComunitCode = ""
    EdtcSTComunitCode = ""
    EdtcCAComunitCode = ""
    CmbiGroupType.ListIndex = -1
    
    GridUnit.Rows = 1
End Sub

''---------------------------------------
''���ܣ��Զ������
''������Index����Ӧ�ؼ������±�
''---------------------------------------
'Private Sub CmdU_Click(Index As Integer)
'    Call ActiveSaveBtn
'    Dim Rs As ADODB.Recordset
'    Dim strClass As String
'    Dim strGrid As String
'    Dim sValue As String
'    Dim bReturn As Boolean
'    bReturn = True
'    Call GetRef("cInvDefine" + CStr(Index + 1), sValue, "", bReturn, EdtU(Index), Me)
'    If bReturn = True Then
'        Call g_oPub.EdtSetVal(sValue, EdtU(Index))
''        EdtU(Index) = sValue
''        If Trim(EdtU(Index).Text) = "" And (sValue <> "") Then
''            ShowMsg Me.LblD1(Index).Caption + "������ַ�������Ϊ" + CStr(EdtU(Index).MaxLength) + "," + vbCrLf + "���������ݽϳ����޷����룬�����¶��峤�ȣ�"
''        End If
'    End If
'End Sub

Private Sub Combo1_Click()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcCIQCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    EdtcCIQUnitCode.Text = ""
    If Not (RstGrid Is Nothing) Then
        If RstGrid.RecordCount = 1 Then
            Call FillEdtcCIQUnitCode(RstGrid.Fields("cCIQCode").Value)
        End If
    End If
End Sub

Private Sub FillEdtcCIQUnitCode(cCIQCode As String)
    EdtcCIQUnitCode.Text = ""
    If Len(cCIQCode) > 0 Then
        Dim Rs As ADODB.Recordset
        Set Rs = SrvDB.OpenX("select ComputationUnit.ccomunitcode,ComputationUnit.ccomunitname from ex_ciqarchive left join ComputationUnit on  ex_ciqarchive.ccomunitcode=ComputationUnit.ccomunitcode where cCIQCode='" + cCIQCode + "'")
        If Rs.RecordCount = 1 Then
            EdtcCIQUnitCode.Text = Rs.Fields("ccomunitcode").Value + " - " + Rs.Fields("ccomunitName").Value
            EdtcCIQUnitCode.UTooltipText = Rs.Fields("ccomunitcode").Value + " - " + Rs.Fields("ccomunitName").Value
        End If
    End If
End Sub

Private Sub EdtcDefWareHouse_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    sSQL = "bWhAsset=" + IIf(chkbInvAsset.Value = Checked, "1", "0")
    If chkbBondedInv.Value = Unchecked Then
        ''����ô���ġ��Ƿ�˰Ʒ��=���񡱣�������Ӧ��Ĭ�ϲֿ�Ҳ�����ǷǱ�˰�֣������òֿ�ġ��Ƿ�˰�֡�=���񡱡�
        sSQL = sSQL + " and bBondedWh=0"
    End If
End Sub




Private Sub EdtcInvAddCode_LostFocus()
    Call SetBillCode
End Sub

Private Sub EdtcInvCCode_LostFocus()
    Call RuleMethod(Me, g_oLogin, EdtcInvCCode.Name, "LostFocus")
End Sub



Private Sub Edtcinvcode_Change()
    If m_bFilling = False Then
        m_bManualChangeCode = True
    End If
    Call SetKeyInfo
    Call RuleMethod(Me, g_oLogin, Edtcinvcode.Name, "Change")
End Sub

Private Sub Edtcinvcode_LostFocus()
    Call RuleMethod(Me, g_oLogin, Edtcinvcode.Name, "LostFocus")
    If opt <> 1 Then Exit Sub 'liuchhc ����Ӵ��жϣ�������������Ƭ����������ʱ�ᱨ��������Ѿ����ڵĴ���
    'zhaoyin3 ֧������ţ�201111300116 �Ϻ�-��Դ��ñ-�ӿ�-�������-����
    If IsExistFieldValue(Edtcinvcode.Text) = True Then
        ReDim g_arr(1 To 1)
        g_arr(1) = Edtcinvcode.Text
        Edtcinvcode.Text = ""
        ShowMsg g_oPub.GetResFormatString(g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcode") & g_oPub.GetResString("U8.AA.SRVTRANS.xx_exist"), g_arr) '"��������Ѿ����ڣ�"
    End If
End Sub

Private Function IsExistFieldValue(ByVal cInvCode As String) As Boolean
    '�ж��ֶ��Ƿ��ظ� zhaoyin3
    Dim Rs As ADODB.Recordset
    Set Rs = SrvDB.OpenX("select top 1 cInvCode  from Inventory with (nolock) where cInvCode=N'" + cInvCode + "'")
    If Rs.RecordCount = 1 Then
        IsExistFieldValue = True
    Else
        IsExistFieldValue = False
    End If
    If Rs.State = 1 Then Rs.Close
    Set Rs = Nothing
End Function

Private Sub Edtcinvcode_UserBrowse(sXML As String)
    Call RuleMethod(Me, g_oLogin, Edtcinvcode.Name, "UserBrowse")
End Sub

Private Sub EdtcInvName_Change()
    Call SetKeyInfo
End Sub

Private Sub SetKeyInfo()
    Call Me.ShowKeyInfo1.setValue(Edtcinvcode, EdtcInvName)
End Sub

Private Sub EdtcInvName_LostFocus()
    Call SetBillCode
    If m_bFilling = True Then Exit Sub
    If g_AutoCreatecInvAddCode = True And Len(Trim(EdtcInvAddCode.Text)) = 0 Then
        EdtcInvAddCode.Text = Left(g_oPub.GetFirstChar(EdtcInvName.Text), EdtcInvAddCode.MaxLength)
        Call ActiveSaveBtn
    End If
End Sub

Private Sub EdtcInvStd_LostFocus()
    Call SetBillCode
End Sub

Private Sub EdtfBuyExcess_LostFocus()
    Call g_oPub.FormatCon(EdtfBuyExcess)
End Sub

Private Sub EdtfPrjMatLimit_LostFocus()
    Call g_oPub.FormatCon(EdtfPrjMatLimit)
End Sub

Private Sub EdtcCAComunitCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcCAComunitCode_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcCAComunitCode, 0, sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcCAComunitCode_Change()
    Call WriteFirstGroup(EdtcCAComunitCode)
End Sub

Private Sub EdtcComunitCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcComunitCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    Call SetEdtcDTUnitVal
End Sub

Private Sub EdtcComunitCode_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcComunitCode, 1, sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcDefWareHouse_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcDefWareHouse_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "warehouse", RstGrid)
    Call SetBillCode
End Sub

Private Sub EdtcDTUnit_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcDTUnit_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcDTUnit, 2, sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcEnterprise_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcEnterprise_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    On Error GoTo Err_Info
    If Not (RstGrid Is Nothing) Then
        If RstGrid.RecordCount > 0 Then
            EdtcProduceAddress.Text = TxtValue(RstGrid.Fields("CVenAddress").Value)
        End If
    End If
    Exit Sub
Err_Info:
    '��������
End Sub

Private Sub EdtcGroupCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcGroupCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    If m_bFilling = True Then Exit Sub
    Call SetGroupCodeChange(RstGrid)
End Sub

Private Sub SetGroupCodeChange(RstGrid As ADODB.Recordset)
    Call showOtherUnit(EdtcGroupCode.Text)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "ComputationGroup", RstGrid)
    Call SetBillCode
End Sub

Private Sub EdtcInvCCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcCIQCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcInvCCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "inventoryClass", RstGrid)
    Call SetBillCode
    If g_oPub.IsClsAuthW(SrvDB, g_rowAuth, "Inventory", EdtcInvCCode.Text, LabcInvCCode.Caption, True) = False Then
        EdtcInvCCode.Clear
    End If
End Sub


Private Sub EdtcPosition_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcPosition_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "position", RstGrid)
End Sub

Private Sub EdtcProductUnit_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcProductUnit_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcProductUnit, IIf(CmbiGroupType.ListIndex = 2, 0, 2), sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcPUComunitCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcPUComunitCode_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcPUComunitCode, IIf(CmbiGroupType.ListIndex = 2, 0, 2), sXMLFilterPara, sSQL, Cancel)
End Sub

'--------------------------------------------------------------
'���ܣ�������λ��������
'������
'       iRetUnitType����Ҫ���ز��յ����ͣ�0�������� 1����������2����������
'--------------------------------------------------------------
Private Sub UnitBeforeBrowse(Con As Control, iRetUnitType As Integer, sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    If m_bFilling = True Then Exit Sub
    If Len(EdtcGroupCode.Text) = 0 Then
        Cancel = True
        Call WriteFirstGroup(Con)
        Exit Sub
    End If
    Dim sval As String
    Select Case iRetUnitType
        Case 0
            sval = "0"
        Case 1
            sval = "1"
        Case Else
    End Select
    sXMLFilterPara = "<RefConditions><Condition paramName='@cGroupCode' paramValue='" + EdtcGroupCode.Text + "' />"
    If Len(sval) > 0 Then
        sXMLFilterPara = sXMLFilterPara + "<Condition paramName='@bMainUnit' paramValue='" + sval + "' />"
        sSQL = "bMainUnit=@bMainUnit"
    End If
    sXMLFilterPara = sXMLFilterPara + "</RefConditions>"
End Sub


Private Sub EdtCComunitCode_Change()
    Call WriteFirstGroup(EdtcComunitCode)
'    If Me.ActiveControl Is EdtcComunitCode Then
'        EdtcComunitCode.Tag = ""
'        EdtcComunitCode.UTooltipText = ""
'        SetEdtcDTUnitVal
'    End If
End Sub

Private Sub EdtcDefWareHouse_Change()
    Call g_oPub.SetRefEdt(Me, EdtcDefWareHouse)
    If m_bFilling = False Then
        Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "warehouse", Nothing)
    End If
End Sub


Private Sub EdtcDTUnit_Change()
    Call WriteFirstGroup(EdtcDTUnit)
'''    If Me.ActiveControl Is EdtcDTUnit Then
'''        EdtcDTUnit.Tag = ""
'''        EdtcDTUnit.UTooltipText = ""
'''    End If
End Sub

'-----------------------------------------
'���ܣ�ʧȥ����ʱ���������λ
'-----------------------------------------
Private Sub EdtcDTUnit_LostFocus()
'    If Me.ActiveControl Is Cmd(11) Then Exit Sub
'    If EdtcDTUnit.Tag <> "" Then Exit Sub '��ʾ���񽹵㣬û���޸�
'    Dim sFilter As String
'    Dim sName As String
'    sFilter = "" ' IIf(CmbiGroupType.ListIndex = 2, " bMainUnit=0 ", "")
'    sName = g_oPub.getResstring("U8.AA.ARCHIVE.FIELD.dt_unit") 'U8.AA.ARCHIVE.FIELD.dt_unit="���������λ" 'IIf(CmbiGroupType.ListIndex = 2, "���鸨������λ", "���������λ")
'    Call EdtChk(EdtcDTUnit, sName, sFilter)
End Sub

Private Sub EdtcGroupCode_Change()
    If Me.ActiveControl Is EdtcGroupCode Then
'        EdtcGroupCode.Tag = ""
'        EdtcGroupCode.UTooltipText = ""
        Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "ComputationGroup", Nothing)
    End If
    ClearUnitEdt
End Sub

'---------------------------------------
'���ܣ�������λ��ʧȥ����ʱ�Ϸ��Լ��
'---------------------------------------
Private Sub EdtcGroupCode_LostFocus()
    SetChkBPropertyCheck
End Sub

'---------------------------------------
'���ܣ���д����ʹ�ò��գ���ȴ�����뷽ʽ������������Ƿ�Ϸ���
'������sCode����Ӧ�Ĵ�������ֵ�����磺����
'      strSql :��ѯ�ַ���
'      con����Ӧ���յĿؼ�
'---------------------------------------
Private Function IfExist(ByVal sCode As String, ByVal sName As String, strSql As String, ByRef Con As Control, Optional ByVal bmUnit As Boolean = False, Optional ByVal UserDefTable As String) As Boolean
    Dim Rs As New ADODB.Recordset
    Set Rs = SrvDB.OpenX(strSql)
    If Rs.RecordCount = 0 Then
        IfExist = False
        Con.Tag = ""
        Con.UTooltipText = ""
        '�¾������λ������
        If bmUnit = True Then CmbiGroupType.ListIndex = -1
    Else
        If g_oPub.FindMatch(Rs, sCode, sName, Con.Text) = True Then
            IfExist = True
            Con.Text = TxtValue(Rs.Fields(sName).Value)
            Con.Tag = TxtValue(Rs.Fields(sCode).Value)
            Con.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + TxtValue(Rs.Fields(sCode).Value)
            '�¾������λ������
            If bmUnit = True Then CmbiGroupType.ListIndex = CInt(TxtValue(Rs.Fields("iGroupType").Value))
            If Len(UserDefTable) > 0 Then
                Call g_oPub.SetUserDefVal(Me, m_EleUserDef, UserDefTable, Rs)
            End If
        End If
    End If
End Function

'--------------------------------------------------------
'���ܣ�������������Ƿ����
'����:  edtX��      ��Ҫ����Edit�ؼ�
'       cmdRef��    ��ӦEdit�Ĳ��հ�ť
'       TableName:  ���յı���
'--------------------------------------------------------
Private Sub CheckExist(EdtX As Edit, cmdRef As UFCOMMANDBUTTONLib.UFCommandButton, tableName As String)
    tableName = LCase(tableName)
    Dim sTip As String
    Dim sFilter As String '���˴�
    Dim fldCode As String
    Dim fldName As String
    Dim strSql As String
    Dim Rs As New ADODB.Recordset
    If EdtX.Tag <> "" Then Exit Sub '��ʾû���޸ģ�����ý������
    If (Me.ActiveControl Is cmdRef) Or (EdtX.Text = "") Then Exit Sub '
    Select Case tableName
        Case "person"
            fldCode = "cPersonCode"
            fldName = "cPersonName"
            sFilter = "(" + fldCode + "='" + EdtX.Text + "' or  " + fldName + "='" + EdtX.Text + "')"
            sTip = g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.1588_1") 'U8.AA.INVENTORY.FRMZAM.1588_1="�����ڸòɹ�Ա��"
        Case Else
    End Select
    strSql = "select  * from " + tableName
    If Len(sFilter) > 0 Then
        strSql = strSql + " where " + sFilter
    End If
    Set Rs = SrvDB.OpenX(strSql)
    If Rs.RecordCount = 0 Then
        ShowMsg sTip
        EdtX.Tag = ""
        EdtX.UTooltipText = ""
        EdtX.Text = ""
        EdtX.SetFocus
        bSave = False
    Else
        If g_oPub.FindMatch(Rs, fldCode, fldName, EdtX.Text) = True Then
            EdtX.Text = TxtValue(Rs.Fields(fldName).Value)
            EdtX.Tag = TxtValue(Rs.Fields(fldCode).Value)
            EdtX.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + EdtX.Tag
            Call g_oPub.SetUserDefVal(Me, m_EleUserDef, tableName, Rs)
        End If
    End If
End Sub

Private Sub EdtcInvCCode_Change()
    If Me.ActiveControl Is EdtcInvCCode Then
        Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "InventoryClass", Nothing)
    End If
    Call RuleMethod(Me, g_oLogin, EdtcInvCCode.Name, "Change")
End Sub

Private Sub EdtcPosition_Change()
    Call g_oPub.SetRefEdt(Me, EdtcPosition)
    If m_bFilling = False Then
        Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "Position", Nothing)
    End If
End Sub



Private Sub EdtcProductUnit_Change()
    Call WriteFirstGroup(EdtcProductUnit)
'''    If Me.ActiveControl Is EdtcProductUnit Then
'''        EdtcProductUnit.Tag = ""
'''        EdtcProductUnit.UTooltipText = ""
'''    End If
End Sub

Private Sub EdtcPUComunitCode_Change()
    Call WriteFirstGroup(EdtcPUComunitCode)
End Sub

'---------------------------------------
'���ܣ���������
'������Con��������λEdit
'---------------------------------------
Private Function WriteFirstGroup(Con As Control) As Boolean
    On Error Resume Next
    If Len(Con.Text) >= 2 Then
        Exit Function '����һ������������
    End If
    If Con.CheckMode = -1 Then Exit Function
    
    If Con.CheckMode = 1 Then
        If Len(Con.DisplayText) = 0 Then Exit Function
    End If
    If Trim(EdtcGroupCode.Text) = "" Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.firstselgroup") '"����ѡ�������λ�飡"
        EdtcGroupCode.SetFocus
        Con.Clear
    End If
End Function

Private Sub EdtChk(ByRef Con As Control, Optional sUnit As String, Optional sFilter As String = "")
    Dim sCode As String, sName As String
    Dim strSql As String
    If (EdtcGroupCode.Text = "") Then 'Or (Con.Text = "")
        ClearUnitEdt
        Exit Sub
    End If
    If Con.Text = "" Then
        Call ClearEdtTag(Con)
        Exit Sub
    End If
    sCode = "CComunitCode"
    sName = "CComUnitName"
    strSql = "select CComunitCode,CComUnitName from ComputationUnit where  cGroupCode='" + EdtcGroupCode.Tag + "'" + _
                " and (CComunitCode='" + Con.Text + "'" + _
                " or CComUnitName='" + Con.Text + "')"
    If Trim(sFilter) <> "" Then
        strSql = strSql + " and " + sFilter
    End If
    If IfExist(sCode, sName, strSql, Con) = False Then
        ReDim g_arr(1 To 2)
        g_arr(1) = EdtcGroupCode.Text
        g_arr(2) = sUnit
        ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.1789_1", g_arr)  '������λ'U8.AA.INVENTORY.FRMZAM.1789_1="������λ�顾{0}���в����ڸ� ��{1}�� ��"
        Con.Text = ""
        Con.SetFocus
        bSave = False
    End If
End Sub

Private Sub EdtcPurPersonCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcPurPersonCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "person", RstGrid)
End Sub

Private Sub EdtcPurPersonCode_Change()
    If Me.ActiveControl Is Nothing Then Exit Sub
    If Me.ActiveControl.Name = EdtcPurPersonCode.Name Then
        Call g_oPub.SetRefEdt(Me, EdtcPurPersonCode)
        If m_bFilling = False Then
            Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "person", Nothing)
        End If
    End If
End Sub

Private Sub EdtcRuleCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcSAComunitCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcSAComunitCode_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcSAComunitCode, IIf(CmbiGroupType.ListIndex = 2, 0, 2), sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcSAComunitCode_Change()
    Call WriteFirstGroup(EdtcSAComunitCode)
End Sub

Private Sub EdtcShopUnit_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcShopUnit_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcShopUnit, 2, sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcShopUnit_Change()
    Call WriteFirstGroup(EdtcShopUnit)
End Sub

Private Sub EdtcSTComunitCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcSTComunitCode_BeforeBrowse(sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Call UnitBeforeBrowse(EdtcSTComunitCode, IIf(CmbiGroupType.ListIndex = 2, 0, 2), sXMLFilterPara, sSQL, Cancel)
End Sub

Private Sub EdtcSTComunitCode_Change()
    Call WriteFirstGroup(EdtcSTComunitCode)
End Sub



Private Sub EdtcVenCode_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtcVenCode_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "vendor", RstGrid)
End Sub


Private Sub EdtcVenCode_Change()
    Call g_oPub.SetRefEdt(Me, EdtcVenCode)
    If m_bFilling = False Then
        Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "vendor", Nothing)
    End If
End Sub

'--------------------------------------------------------
'���ܣ����ɹ�ԱΪ��ʱ��Ĭ��Я����Ӧ�̷ֹ�ҵ��Ա
'������cVenCode :   ��Ӧ�̱���
'--------------------------------------------------------
Private Sub WriteEdtcPurPersonCode(cVenCode As String)
    If Len(cVenCode) = 0 Then Exit Sub
    If Len(Trim(EdtcPurPersonCode.Tag)) = 0 Then
        Dim strSql  As String
        Dim Rs As ADODB.Recordset
        strSql = "select top 1 cVenPPerson from vendor where cVenCode='" + cVenCode + "'"
        Set Rs = SrvDB.OpenX(strSql)
        If Rs.RecordCount = 1 Then
            Dim cPersonCode As String
            cPersonCode = TxtValue(Rs!cVenPPerson)
            If Len(cPersonCode) > 0 Then
                strSql = "select top 1 * from person where cpersonCode='" + cPersonCode + "'"
                Set Rs = SrvDB.OpenX(strSql)
                If Rs.RecordCount = 1 Then
                    EdtcPurPersonCode.Text = TxtValue(Rs!cPersonName)
                    EdtcPurPersonCode.Tag = TxtValue(Rs!cPersonCode)
                    EdtcPurPersonCode.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + EdtcPurPersonCode.Tag
                End If
            End If
        End If
    End If
End Sub



Private Sub EdtdLastDate_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

'Private Sub EdtfBackTaxRate_LostFocus()
'    Call g_oPub.FormatCon(EdtfBackTaxRate)
'End Sub

Private Sub EdtfDTNum_LostFocus()
    Call g_oPub.FormatCon(EdtfDTNum)
End Sub

Private Sub EdtfDTRate_Change()
    If IsNumeric(EdtfDTRate.Text) Then
        If Val(EdtfDTRate.Text) > 100 Then
            EdtfDTRate.Text = Mid(EdtfDTRate.Text, 1, 2)
            EdtfDTRate.SelStart = Len(EdtfDTRate.Text)
        End If
    Else
        EdtfDTRate.Text = ""
    End If
End Sub

Private Sub EdtfDTRate_LostFocus()
    Call g_oPub.FormatCon(EdtfDTRate)
End Sub

'----------------------------------------------------
'��ֹ����4��0�ȣ�����ǰ����1��
'----------------------------------------------------
Private Sub EdtfExpensesExch_Change()
    If Me.EdtfExpensesExch = "" Then Exit Sub
    If Val(Me.EdtfExpensesExch.Text) > 100 Or Val(Me.EdtfExpensesExch) < 0 Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.1958_1") 'U8.AA.INVENTORY.FRMZAM.1958_1="������%ֻ���Ǵ��ڵ���0С�ڵ���100������!"
        Me.EdtfExpensesExch.Text = ""
        Me.EdtfExpensesExch.SetFocus
    End If
End Sub

Private Sub EdtfExpensesExch_KeyPress(KeyAscii As Integer)
    If Val(Me.EdtfExpensesExch.Text + CStr(Chr(KeyAscii))) > 100 Or Val(Me.EdtfExpensesExch + CStr(Chr(KeyAscii))) < 0 Then
        KeyAscii = 0
        Me.EdtfExpensesExch.SetFocus
    End If
End Sub

Private Sub EdtfExpensesExch_LostFocus()
    Call g_oPub.FormatCon(EdtfExpensesExch)
End Sub

Private Sub EdtfExpPrice_LostFocus()
    Call g_oPub.FormatCon(EdtfExpPrice)
End Sub


Private Sub EdtfInExcess_LostFocus()
    Call g_oPub.FormatCon(EdtfInExcess)
End Sub

Private Sub EdtfOrderUpLimit_LostFocus()
    Call g_oPub.FormatCon(EdtfOrderUpLimit)
End Sub

Private Sub EdtfInvOutUpLimit_LostFocus()
    Call g_oPub.FormatCon(EdtfInvOutUpLimit)
End Sub

Private Sub EdtfMinSplit_LostFocus()
    Call g_oPub.FormatCon(EdtfMinSplit)
End Sub


Private Sub EdtfOutExcess_LostFocus()
    Call g_oPub.FormatCon(EdtfOutExcess)
End Sub

Private Sub EdtfRetailPrice_LostFocus()
    Call g_oPub.FormatCon(EdtfRetailPrice)
End Sub

Private Sub EdtiDrawBatch_LostFocus()
    If EdtiDrawBatch.Property = EditDbl Then '��Ϊ����ʱ����ǿ�Ƹ�ʽ��
        Call g_oPub.FormatCon(EdtiDrawBatch)
    End If
End Sub

Private Sub EdtiExpSaleRate_LostFocus()
    Call g_oPub.FormatCon(EdtiExpSaleRate)
End Sub

Private Sub EdtiInvLSCost_LostFocus()
    Call g_oPub.FormatCon(EdtiInvLSCost)
End Sub

Private Sub EdtiInvMPCost_LostFocus()
    Call g_oPub.FormatCon(EdtiInvMPCost)
End Sub

Private Sub EdtiInvNCost_LostFocus()
    Call g_oPub.FormatCon(EdtiInvNCost)
End Sub

Private Sub EdtiInvRCost_LostFocus()
    Call g_oPub.FormatCon(EdtiInvRCost)
End Sub

Private Sub EdtiInvSCost_LostFocus()
    Call g_oPub.FormatCon(EdtiInvSCost)
End Sub

Private Sub EdtiInvSPrice_LostFocus()
    Call g_oPub.FormatCon(EdtiInvSPrice)
End Sub

Private Sub EdtfCurLLaborCost_LostFocus()
    Call g_oPub.FormatCon(EdtfCurLLaborCost)
End Sub

Private Sub EdtfCurLVarManuCost_LostFocus()
    Call g_oPub.FormatCon(EdtfCurLVarManuCost)
End Sub

Private Sub EdtfCurLFixManuCost_LostFocus()
    Call g_oPub.FormatCon(EdtfCurLFixManuCost)
End Sub

Private Sub EdtfCurLOMCost_LostFocus()
    Call g_oPub.FormatCon(EdtfCurLOMCost)
End Sub

Private Sub EdtfNextLLaborCost_LostFocus()
    Call g_oPub.FormatCon(EdtfNextLLaborCost)
End Sub

Private Sub EdtfNextLVarManuCost_LostFocus()
    Call g_oPub.FormatCon(EdtfNextLVarManuCost)
End Sub

Private Sub EdtfNextLFixManuCost_LostFocus()
    Call g_oPub.FormatCon(EdtfNextLFixManuCost)
End Sub

Private Sub EdtfNextLOMCost_LostFocus()
    Call g_oPub.FormatCon(EdtfNextLOMCost)
End Sub

Private Sub EdtiLowSum_LostFocus()
    If CheckNum(EdtiLowSum, EdtiSafeNum, EdtiTopSum) = False Then
        EdtiLowSum.Text = ""
    End If
    Call g_oPub.FormatCon(EdtiLowSum)
End Sub

Private Sub EdtiMassDate_Change()
    If m_bFilling = False Then
        If Len(EdtiMassDate.Text) > 0 Then
            If Len(CmbcMassUnit.Text) = 0 Then
                EdtiMassDate.Text = ""
                ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.2053_1") 'U8.AA.INVENTORY.FRMZAM.2053_1="���뱣����֮ǰ������ѡ�����ڵ�λ��"
            End If
        End If
    End If
End Sub

Private Sub EdtiMassDate_LostFocus()
    If Len(EdtiMassDate.Text) > 0 Then
        If IsNumeric(EdtiMassDate.Text) = True Then
            If CInt(EdtiMassDate.Text) <= 0 Then
                ReDim g_arr(1 To 1)
                g_arr(1) = LbliMassDate.Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.thanzero", g_arr) '"{0}�������0��"
                EdtiMassDate.Text = 1
            End If
        End If
    End If
End Sub

Private Sub EdtiOverStock_LostFocus()
    Call g_oPub.FormatCon(EdtiOverStock)
End Sub

Private Sub EdtiQTMethod_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub EdtiQTMethod_AfterBrowse(RstClass As ADODB.Recordset, RstGrid As ADODB.Recordset, sXML As String)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "QMCHECKPROJECT", RstGrid)
End Sub

Private Sub EdtiQTMethod_Change()
    If Me.ActiveControl Is EdtiQTMethod Then
        EdtiQTMethod.Tag = ""
        EdtiQTMethod.UTooltipText = ""
        Call g_oPub.SetUserDefVal(Me, m_EleUserDef, "QMCHECKPROJECT", Nothing)
    End If
End Sub

Private Sub EdtiSafeNum_Change()
    InvPlan1.FSubscribePointTag = "changed"
    InvPlan1.iSafeNum = EdtiSafeNum
End Sub

Private Sub EdtiSafeNum_LostFocus()
    If CheckNum(EdtiLowSum, EdtiSafeNum, EdtiTopSum) = False Then
        EdtiSafeNum = ""
    End If
    Call g_oPub.FormatCon(EdtiSafeNum)
    InvPlan1.CalculateSubscribePoint
End Sub

Private Function CheckNum(ByVal ILowSum As String, ByVal iSafeNum As String, ByVal ITopSum As String) As Boolean
    CheckNum = False
    ReDim g_arr(1 To 1)
    If ILowSum <> "" Then
        If Not IsNumeric(ILowSum) Then
            g_arr(1) = Me.LabiLowSum.Caption
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"����Ϳ�桯����Ϊ��ֵ��"
            Exit Function
        End If
    End If
    If iSafeNum <> "" Then
        If Not IsNumeric(iSafeNum) Then
            g_arr(1) = Me.LabiSafeNum.Caption
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"����ȫ��桯����Ϊ��ֵ��"
            Exit Function
        End If
    End If
    If ITopSum <> "" Then
        If Not IsNumeric(ITopSum) Then
            g_arr(1) = Me.LabiTopSum.Caption
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mustbenumeric", g_arr) '"����߿�桯����Ϊ��ֵ��"
            Exit Function
        End If
    End If
    
    ReDim g_arr(1 To 2)
'    If ILowSum <> "" And iSafeNum <> "" Then
'        If Val(ILowSum) > Val(iSafeNum) Then
'            g_arr(1) = Me.LabiLowSum.Caption
'            g_arr(2) = Me.LabiSafeNum.Caption
'            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"����Ϳ�桯���ô��ڡ���ȫ��桯"
'            Exit Function
'        End If
'    End If
    If iSafeNum <> "" And ITopSum <> "" Then
         If Val(iSafeNum) > Val(ITopSum) Then
            g_arr(1) = Me.LabiSafeNum.Caption
            g_arr(2) = Me.LabiTopSum.Caption
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"����ȫ��桯���ô��ڡ���߿�桯"
            Exit Function
        End If
    End If
    If ILowSum <> "" And ITopSum <> "" Then
         If Val(ILowSum) > Val(ITopSum) Then
            g_arr(1) = Me.LabiLowSum.Caption
            g_arr(2) = Me.LabiTopSum.Caption
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.nobiger", g_arr) '"����Ϳ�桯���ô��ڡ���߿�桯"
            Exit Function
        End If
    End If
    CheckNum = True
End Function

Private Sub EdtiTaxRate_LostFocus()
    Call g_oPub.FormatCon(EdtiTaxRate)
End Sub

Private Sub EdtfInvCIQExch_LostFocus()
    Call g_oPub.FormatCon(EdtfInvCIQExch)
End Sub

Private Sub EdtiImpTaxRate_LostFocus()
    Call g_oPub.FormatCon(EdtiImpTaxRate)
End Sub

'Private Sub EdtiExpTaxRate_LostFocus()
'    Call g_oPub.FormatCon(EdtiExpTaxRate)
'End Sub

Private Sub EdtiTopSum_LostFocus()
    If CheckNum(EdtiLowSum, EdtiSafeNum, EdtiTopSum) = False Then
        EdtiTopSum = ""
    End If
    Call g_oPub.FormatCon(EdtiTopSum)
End Sub

'Private Sub EdtiVolume_LostFocus()
'    Call g_oPub.FormatCon(EdtiVolume)
'End Sub

Private Sub EdtiWastage_LostFocus()
    Call g_oPub.FormatCon(EdtiWastage)
End Sub

Private Sub EdtU_ActiveSaveBtn(Index As Integer)
    Call ActiveSaveBtn
End Sub

Private Sub EdtU_BeforeBrowse(Index As Integer, sXMLFilterPara As String, sSQL As String, Cancel As Boolean)
    Dim cId As String
    If Len(cRelArchive(Index)) = 0 Then
    Select Case Index
        Case 0, 1, 2
            cId = 17 + Index
        Case 3, 4, 5, 6, 7, 8, 9
            cId = 52 + Index - 3
    End Select
    If Len(cId) > 0 Then
        sXMLFilterPara = "<RefConditions>"
        sXMLFilterPara = sXMLFilterPara + "<Condition paramName='@cID' paramValue='" + cId + "' />"
        sXMLFilterPara = sXMLFilterPara + "</RefConditions>"
    End If
    End If
End Sub

'---------------------------------------
'���ܣ�����Զ�����ֵ�Ƿ�Ϸ�
'������Index����Ӧ�ؼ����±�
'---------------------------------------
Private Sub EdtU_LostFocus(Index As Integer)
    Dim strSql As String
    Dim tableName  As String '���ձ���
    Dim sField As String '�����ֶ���
    Dim Rs As New ADODB.Recordset
    Dim RsTemp As ADODB.Recordset
'    If Index > CmdU.UBound Then Exit Sub
    If (EdtU(Index) = "") Then Exit Sub ''Or (Me.ActiveControl Is CmdU(Index))
    strSql = "select * from Userdef where cClass='���'  and cItem='�Զ�����" + CStr(Index + 1) + "'" 'and bCheckVal=1
    Set Rs = SrvDB.OpenX(strSql)
    If Rs.RecordCount = 1 Then
        '����Ƿ񶨳�
        If TxtValue(Rs!bFixLength, False) = True Then
            If Len(EdtU(Index)) <> CInt(TxtValue(Rs!iLength)) Then 'LenB(StrConv(EdtU(index), vbFromUnicode))
                ReDim g_arr(1 To 2)
                g_arr(1) = Me.LblD1(Index).Caption
                g_arr(2) = CStr(TxtValue(Rs!iLength))
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.fixlen", g_arr) 'U8.AA.ARCHIVE.COMMON.fixlen="{0}���ȱ�����:{1}"
                'EdtU(Index).SetFocus'����2���Զ��������ʱ�ѡ����������򹴣�����20�����޸ĵ������ҵ��Զ�����������ݣ�֮��ѭ����ʾ2��������ġ����ȱ�����20��
                bSave = False
                Exit Sub
            End If
        End If
        '��������
        If LCase(CStr(TxtValue(Rs!bInput))) = "true" Then
            If EdtU(Index) = "" Then
                ReDim g_arr(1 To 1)
                g_arr(1) = Me.LblD1(Index).Caption
                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.notnull", g_arr) 'U8.AA.ARCHIVE.COMMON.notnull="{0}��׼Ϊ�գ�"
                EdtU(Index).SetFocus
                bSave = False
                Exit Sub
            End If
        End If
        '���Ϸ��Ե������������������Ϸ��ԣ�
        If LCase(TxtValue(Rs!bCheckVal)) = True And LCase(CStr(TxtValue(Rs!bArchive))) = "false" Then
            '�ȼ�鵵��
            tableName = TxtValue(Rs!cRelArchive)
            sField = TxtValue(Rs!cRelField)
            If tableName <> "" And sField <> "" Then
                strSql = "Select top 1 " + sField + " from " + tableName + " where " + sField + "='" + EdtU(Index) + "'" + " and " + g_oPub.GetEndDateFilter(tableName, g_CurDate)
                Set RsTemp = SrvDB.OpenX(strSql)
                If RsTemp.RecordCount = 0 Then '�ټ���Զ������
                    strSql = "select top 1 cValue from userdefine where cId='" + TxtValue(Rs!cId) + "'" + _
                    " and (cvalue='" + EdtU(Index) + "' or Calias='" + EdtU(Index) + "')"
                    Set Rs = SrvDB.OpenX(strSql)
                    If Rs.RecordCount = 0 Then
                        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_arch_define_val") '"ϵͳ�������Զ�������������ڸ�ֵ��" 'LblD1(Index).Caption + "ֵû�н���������"
                        EdtU(Index) = ""
                        EdtU(Index).SetFocus
                        bSave = False
                        Exit Sub
                    Else
                        EdtU(Index) = TxtValue(Rs!cValue)
                    End If
                End If
            Else
                strSql = "select top 1 cValue from userdefine where cId='" + TxtValue(Rs!cId) + "'" + _
                " and (cvalue='" + EdtU(Index) + "' or Calias='" + EdtU(Index) + "')"
                Set Rs = SrvDB.OpenX(strSql)
                If Rs.RecordCount = 0 Then
                    ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_define_val") '"�Զ�����������ڸ�ֵ��" 'LblD1(Index).Caption + "ֵû�н���������"
                    EdtU(Index) = ""
                    EdtU(Index).SetFocus
                    bSave = False
                    Exit Sub
                Else
                    EdtU(Index) = TxtValue(Rs!cValue)
                End If
            End If
        End If
'        strSql = "select top 1 cValue from userdefine where cId='" + TxtValue(Rs!cId) + "'" + _
'        " and (cvalue='" + EdtU(Index) + "' or  Calias='" + EdtU(Index) + "')"
'        Set Rs = SrvDB.OpenX(strSql)
'        If Rs.RecordCount = 0 Then
'            ShowMsg LblD1(Index).Caption + "ֵû�н���������"
'            EdtU(Index) = ""
'            EdtU(Index).SetFocus
'            bSave = False
'        Else
'            EdtU(Index) = TxtValue(Rs!cValue)
'        End If
    End If
'''    If Index = 12 Or Index = 13 Then
'''        Call g_oPub.FormatCon(EdtU(Index))
'''    End If
End Sub

'---------------------------------------
'���ܣ����弤��ʱһЩ����
'---------------------------------------
Private Sub Form_Activate()
    On Error Resume Next '��ֹ�մ򿪴��ڣ��͹رմ��嵼��.SetFocus����
    If m_bFirstLoad = True Then
        DoEvents
        If m_optType = enuNormal Then
            InitAccSet '��ʱ�������ײ���
            InitUserDef '������������Call Initialize֮ǰ����Ϊ�ú����޸�״̬���Զ����ֵ
            Call Initialize
        End If
        m_bFirstLoad = False
        Me.KeyPreview = False
        
        If opt = 2 Then
            m_bFilling = True '��ֹSetPropertyCheck��CmbiTestStyle_Click�������
        End If
        SetPropertyCheck 'ǿ��ִ��
        If opt = 2 Then
            CmbiTestStyle_Click 'ǿ��ִ��
        End If
        m_bFilling = False
        
        If LCase(g_oPub.m_LocaleID) <> "en-us" Then
            Dim iCount As Integer, i As Integer
            For i = 0 To SSTab1.Tabs - 1
                If SSTab1.TabVisible(i) = False Then
                    iCount = iCount + 1
                End If
            Next i
        Else
            ChkbInvQuality.UTooltipText = ChkbInvQuality.Caption
            ChkbInvQuality.Caption = Left(ChkbInvQuality.Caption, 8) + "..."
        End If

        If m_optType = enuAddOnly Then
        Else
            Tlb.Buttons("SaveRs").Enabled = False
            Call g_oPub.ReRefreshUFTlb(Me)
        End If
        'Call SetTabVisible(Me.SSTab1)
        Dim bReadOnly As Boolean
        m_billFormat = g_oPub.GetBillFormat(g_oLogin.UfDbName, "Inventory", m_bCreateBillNum, bReadOnly)
        Edtcinvcode.Locked = bReadOnly
        Call SetBillCode
    End If
    SSTab1.Enabled = True
End Sub

Private Sub Initialize()
    'g_oPub.Start
    Dim sXML As String
    sXML = "<Inventory>"
    sXML = sXML + "<g_cUserName>" + g_cUserName + "</g_cUserName>"
    sXML = sXML + "<UfDbName>" + g_UfDbName + "</UfDbName>"
    sXML = sXML + "<g_CurDate>" + g_CurDate + "</g_CurDate>"
    sXML = sXML + "<g_DbSrvDate>" + g_DbSrvDate + "</g_DbSrvDate>"
    sXML = sXML + "<g_iPriceDecDgt>" + CStr(g_iPriceDecDgt) + "</g_iPriceDecDgt>"
    sXML = sXML + "<g_iQuanDecDgt>" + CStr(g_iQuanDecDgt) + "</g_iQuanDecDgt>"
    sXML = sXML + "<g_iVolumeDecDgt>" + CStr(g_iVolumeDecDgt) + "</g_iVolumeDecDgt>"
    sXML = sXML + "<g_iWeightDecDgt>" + CStr(g_iWeightDecDgt) + "</g_iWeightDecDgt>"
    sXML = sXML + "<g_bFactory>" + CStr(g_bFactory) + "</g_bFactory>"
    sXML = sXML + "<g_sRowAuthDept>" + g_sRowAuthDept + "</g_sRowAuthDept>"
    sXML = sXML + "<g_sRowAuthPerson>" + g_sRowAuthPerson + "</g_sRowAuthPerson>"
    sXML = sXML + "<g_sRowAuthInv>" + g_sRowAuthInv + "</g_sRowAuthInv>"
    sXML = sXML + "<HelpContextId>" + CStr(Me.HelpContextID) + "</HelpContextId>"
    sXML = sXML + "<hwnd>" + CStr(ObjPtr(Me)) + "</hwnd>"
    sXML = sXML + "<url>" + CStr(g_URL) + "</url>"
    sXML = sXML + "<bweb>" + CStr(IIf(g_bIsWeb = True, "1", "0")) + "</bweb>"
    sXML = sXML + "<g_BShowMedicineTab870>" + CStr(IIf(g_BShowMedicineTab870 = True, "1", "0")) + "</g_BShowMedicineTab870>"
    sXML = sXML + "</Inventory>"
    
    Call InvOther1.Init870(g_oLogin, SrvDB, g_oPub, sXML)
    Call InvFree1.Init870(g_oLogin, SrvDB, g_oPub, sXML)
    Call InvBatchProperty1.Init(SrvDB, g_oPub, sXML)
    SSTab1.TabVisible(8) = InvFree1.bShow
    'SSTab1.TabVisible(6) = InvBatchProperty1.bShow

    Call InvPlan1.Init(SrvDB, g_oPub, sXML)
    Call InvMPS1.Init870(g_oLogin, SrvDB, g_oPub, sXML)
    If g_oPub.ExistSpecialVersionType(SrvDB, 5) Then '
        Call Pic.Init(g_oPub, "10000") '��ɽ������Ϣ�������޹�˾ ͼƬ��10M��Χ����
    Else
        Call Pic.Init(g_oPub)
    End If
    
    Call EdtcDTPeriod.Init(SrvDB, g_oPub, sXML)
    Call EdtcDTPeriod2.Init(SrvDB, g_oPub, sXML)
    
    Call InvAttachfile1.Init(g_oClient, SrvDB, g_oPub, Invcinvcode)

    
    'Call g_oPub.WriteTime("Init")
'    Call NDTSet1.Init(SrvDB, g_oPub, "Inventory", sXml)
    m_iChangedAdvanceRW = 2 '�䶯��ǰ�ڶ�дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
    m_fAlterBaseNumRW = 2 '���䶯��������дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
    m_cInvcodeRW = 2 ''��������롿��дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
'    m_dSDateRW = 2 '���������ڡ���дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
    m_fDTRateRW = 2 '�������%����дȨ�ޣ�0����д�ޣ�1����Ȩ�ޣ�2��дȨ��
    m_fDTNumRW = 2 '���������
    m_iDTStyleRW = 2 '�������ϸ�ȡ�
    m_iDaysRW = 2 '��ÿ�µ�X�졿
    m_fFixedBatchRW = 2 '���̶�������
    m_fVagQuantityRW = 2 '���վ�������
    m_fBatchIncrementRW = 2 '������������
    'm_iOrderIntervalDaysRW = 2 '���������������
    m_iAssureProvideDaysRW = 2 ''����֤��Ӧ������
    m_iROPMethodRW = 2 '���ٶ����㷽����
    m_fSubscribePointRW = 2 '���ٶ����㡿
    'On Error Resume Next
        
        'g_oPub.Start
    SetFieldLength
    
    InitValSet '������InitRWFld����ǰ����
    
    
    Call SetBadStrException
    
    If g_bQM = False Then
        ChkbDTWarnInv.Visible = False
    End If
    '���δ����GSP����������ϵͳ����"�Ƿ��ʼ�"ѡ���ûң��������GSP����������ϵͳ������"�Ƿ��ʼ�"Ϊ��ʱ����"GSP"ҳǩ��"����"ҳǩ�ûң�"����"ҳǩ��������Ϊ�գ�
    'If g_bGSP = False And g_bQM = False Then
    If g_BShowMedicineTab = False Then
        ChkBPropertyCheck.Enabled = False
        '����GSP��ֻ���Ƿ��ʼ�Ϊ�����б����ڹ���Ҫ��Ĵ�����Ƿ����ڼ���ſ�ѡ��Ϊ�ǣ�������Ϊ�ң��������������ֻ�л���ҳǩ�е��Ƿ��ʼ�Ϊ��ʱ���Ƿ�������ڲſ�ѡ��Ϊ�ǣ�������Ϊ��
        ChkbPeriodDT.Enabled = False
    End If
'    ChkbInvModel.Enabled = False
    '�Ƿ���ӪҩƷ:���������û����ɱ༭����GSPϵͳ������ӪƷ��������ʱ���룬���ҵ���ӪƷ�־�����һ�����պ󽫴˱�־�����
    '2005-12-21 ��ҽҩҳǩ�е��Ƿ���Ӫ��ҵ�ֶηſ������û���ʱ���޸� (����÷Ҫ����� ����ţ�77841)
    'ChkbFirstBusiMedicine.Enabled = False
    InvMPS1.Control_ChkbForeExpland.Enabled = False
    
    g_bShopSys = IIf(g_oPub.GetAccInformation("bShopSys", SrvDB) = "true", True, False)
    
    If g_bShopSys = False Then
        EdtcShopUnit.Enabled = False
        'Cmd(14).Enabled = False
    End If
    If g_bGSP = True Then
        EdtcDTPeriod.NoSmallVisible = False
    End If
    'Call g_oPub.WriteTime("Other")
    AddBadStr
    
    Call InitRWFld '�ȿ���Ȩ�ޣ��������޸�ʱ���򿪿�Ƭ˲����Կ�����Ȩ�޵��ֶ����ݣ�����ShowKeyInfo1����
    Select Case opt
        Case 1
            Emptyallfields
        Case 2
            FillAllFields
        Case Else
    End Select
End Sub

'---------------------------------------------------
'���ܣ���ʼ�����
'---------------------------------------------------
Private Sub InitArchPlugin()
    On Error GoTo Err_Info
    Dim service As Object
    Set service = CreateObject("UFSoft.U8.Framework.U8Plugin.PluginService")
    'service.Refresh
    Dim Container As Object ' PluginContainer
    Dim tableName As String
    tableName = "Inventory"
    Set Container = service.GetPluginContainer(tableName + "ClientContainer")
'    Call Container.Parameters.GetParameter("plugins").setValue(m_plugins)
'    Call Container.Parameters.GetParameter("Frm").setValue(Me)
'    Call Container.Parameters.GetParameter("Container").setValue(Me.FramePlubIn)
'    Call Container.Parameters.GetParameter("Caption").setValue(Caption)
    Call Container.SetParameterValue("plugins", m_plugins)
    Call Container.SetParameterValue("Frm", Me)
    Call Container.SetParameterValue("Container", Me.FramePlubIn)
    Call Container.SetParameterValue("Caption", Caption)
    Container.Execute
    'm_TradeTabCaption = Container.Parameters.GetParameter("Caption").getValue
    m_TradeTabCaption = Container.GetParameterValue("Caption")
    SSTab1.TabCaption(11) = m_TradeTabCaption
    m_bPlugIns = True
    Call PlubIn_Init
    Exit Sub
Err_Info:
    SSTab1.TabVisible(11) = False
    m_bPlugIns = False
    'Call g_oPub.WriteErrorLog("InventoryClient", "InitArchPlugin", Err.Number, "����"+Err.Description, False)
End Sub


'-------------------------------------------------
'���ܣ�
'-------------------------------------------------
Private Sub PlubIn_Init()
    If m_bPlugIns = False Then Exit Sub
    On Error GoTo Err_Info
    Dim Plugin As Variant
    Dim sXML As String
    sXML = "<Inventory>"
    sXML = sXML + "<RowRW>" & IIf(FrmMain.m_bEdit = True, "RW", "R") & "</RowRW>"
    sXML = sXML + "</Inventory>"
    For Each Plugin In m_plugins
        Call Plugin.object.Init(Me, g_oLogin, FramePlubIn, g_oPub, SrvDB, FrmMain.RefClient, sXML)
    Next
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

'-------------------------------------------------
'���ܣ�����������
'-------------------------------------------------
Private Sub PlubIn_Emptyallfields()
    On Error GoTo Err_Info
    If m_bPlugIns = False Then Exit Sub
    Dim Plugin As Variant
    For Each Plugin In m_plugins
        Plugin.object.Emptyallfields
    Next
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

'-------------------------------------------------
'���ܣ���ȡ��������
'-------------------------------------------------
Private Function PlubIn_GetSaveXml(Optional ByRef bFlag As Boolean = True)
    On Error GoTo Err_Info
    If m_bPlugIns = False Then Exit Function
    Dim Plugin As Variant
    Dim sXML As String
    For Each Plugin In m_plugins
         If bFlag = True Then
            sXML = sXML + Plugin.object.GetSaveXml(bFlag, opt)
         Else
            Exit For
         End If
    Next
    PlubIn_GetSaveXml = "<PlugIn>" + sXML + "</PlugIn>"
    Exit Function
Err_Info:
    ShowMsg Err.Description
End Function

'-------------------------------------------------
'���ܣ���д����
'-------------------------------------------------
Private Sub PlubIn_FillAllFields(RsCard As ADODB.Recordset)
    On Error GoTo Err_Info
    If m_bPlugIns = False Then Exit Sub
    Dim Plugin As Variant
    For Each Plugin In m_plugins
        Call Plugin.object.FillAllFields(RsCard)
    Next
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

Public Sub SetTabVisible(tb As SSTab)
    Dim i As Integer
    For i = 0 To tb.Tabs - 1
        tb.TabVisible(i) = True
    Next i
End Sub


Private Sub InvAttachfile1_ActiveSaveBtn()
     Call ActiveSaveBtn
End Sub

Private Sub InvMPS1_EdtKeyPress(fldName As String, KeyAscii As Integer)
    Select Case LCase(fldName)
        Case LCase("nextpage")
            SSTab1.Tab = GetTabVisible(SSTab1.Tab)
            SetEdtFocus
        Case Else
    End Select
End Sub

'----------------------------------
'���̹���: �趨���̿�ݷ�ʽ
'----------------------------------
Private Sub UFFrmKeyHook_ContainerKeyDown(KeyCode As Integer, ByVal Shift As Integer)
    If g_oPub.FrmKeyDown(Me, KeyCode, Shift) = True Then
        Call ActiveSaveBtn
    End If
    If KeyCode = vbKeyF1 Then
        If g_bIsWeb = False Then
            Select Case SSTab1.Tab
                Case 0
                    Call g_oPub.HelpX("InventoryBase", Me, g_oLogin, App, g_bIsWeb)
                Case 1
                    Call g_oPub.HelpX("InventoryCost", Me, g_oLogin, App, g_bIsWeb)
                Case 2
                    Call g_oPub.HelpX("InventoryControl", Me, g_oLogin, App, g_bIsWeb)
                Case 3
                    Call g_oPub.HelpX("InventoryOther", Me, g_oLogin, App, g_bIsWeb)
                Case 4
                    Call g_oPub.HelpX("InventoryPlan", Me, g_oLogin, App, g_bIsWeb)
                Case 5
                    If TypeOf Me.ActiveControl Is UFCHECKBOXLib.UFCheckBox Then
                        Call g_oPub.HelpX("InventoryUserFree", Me, g_oLogin, App, g_bIsWeb)
                    Else
                        Call g_oPub.HelpX("InventoryUserdef", Me, g_oLogin, App, g_bIsWeb)
                    End If
                Case 6
                    Call g_oPub.HelpX("InventoryGSP", Me, g_oLogin, App, g_bIsWeb)
                Case 7
                    Call g_oPub.HelpX("InventoryQuality", Me, g_oLogin, App, g_bIsWeb)
                Case 8
                    Call g_oPub.HelpX("InventoryFree", Me, g_oLogin, App, g_bIsWeb)
                Case 9
                    Call g_oPub.HelpX("InventoryMPS_MRP", Me, g_oLogin, App, g_bIsWeb)
                Case 10
                    Call g_oPub.HelpX("InventoryPicture", Me, g_oLogin, App, g_bIsWeb)
            End Select
            SendKeys "{F1}"
        End If
    ElseIf KeyCode = vbKeyPageUp Then
        If m_bFilling = False Then '��ֹʼ�հ�ס�ü���������ʾ�������Ϣ
            If m_optType = enuNormal Then
                If Shift = 4 Then
                    Operating "First"
                    Exit Sub
                Else
                    Operating "Previous"
                    KeyCode = 0
                    Exit Sub
                End If
            End If
        End If
    ElseIf KeyCode = vbKeyPageDown Then
        If m_bFilling = False Then '��ֹʼ�հ�ס�ü���������ʾ�������Ϣ
            If m_optType = enuNormal Then
                If Shift = 4 Then
                    Operating "Last"
                    Exit Sub
                Else
                    Operating "Next"
                    KeyCode = 0
                    Exit Sub
                End If
            End If
        End If
    ElseIf KeyCode = vbKeyEscape Then
        If Me.Tlb.Buttons("SaveRs").Enabled = False Then
            Unload Me
            Exit Sub
        End If
    ElseIf KeyCode = vbKeyF5 And Me.Tlb.Buttons("Copy").Enabled = True Then
        Operating "ClearField"
        Tlb.Buttons("SaveRs").Enabled = False
        Call g_oPub.ReRefreshUFTlb(Me)
        opt = 1 '���
        Exit Sub
    ElseIf KeyCode = vbKeyF6 And Me.Tlb.Buttons("SaveRs").Enabled = True Then
         Operating "SaveRs"
         KeyCode = 0
         Exit Sub
'    ElseIf KeyCode = vbKeyF4 And Me.Tlb.Buttons("Exit").Enabled = True Then
'        If Shift = 4 Then
'            Unload Me
'        End If
'    ElseIf Not (Me.ActiveControl Is Nothing) Then '��������
'        If (TypeOf Me.ActiveControl Is Edit) Or (TypeOf Me.ActiveControl Is UFCHECKBOXLib.UFCheckBox) Or (TypeOf Me.ActiveControl Is UFCOMBOBOXLib.UFComboBox) Then
'            Tlb.Buttons("SaveRs").Enabled = True
'        End If
'        Exit Sub
    End If
End Sub




Private Sub UFFrmKeyHook_ContainerKeyPress(KeyAscii As Integer)
    On Error GoTo Err_Info
    If KeyAscii = 13 Then
        If LCase(Left(Me.ActiveControl.Name, 3)) = "edt" Or TypeOf Me.ActiveControl Is UFCOMBOBOXLib.UFComboBox Or TypeOf Me.ActiveControl Is UFCHECKBOXLib.UFCheckBox Or TypeOf Me.ActiveControl Is MaskEdBox Then
            Select Case (Me.ActiveControl.Name)
                Case chkbBondedInv.Name
                    SSTab1.Tab = 1
'                Case ChkbInvEntrust.Name
'                    If ChkbAccessary.Enabled = False Then
'                        SSTab1.Tab = 1
'                    End If
'                Case ChkbInvType.Name
'                    If ChkbAccessary.Enabled = False Or ChkbInvEntrust.Enabled = False Then
'                        SSTab1.Tab = 1
'                    End If
                Case EdtfNextLOMCost.Name
                    SSTab1.Tab = 2
                Case ChkbInByProCheck.Name
                    SSTab1.Tab = 3
                    InvOther1.SetActiveFocus
                    Exit Sub '��ֹ�������ִ��SendKeys "{TAB}"���������һ����Ԫ��
'                Case ChkbSpecialties.Name  'EdtcQua.Name,'EdtfSubscribePoint.Name,
'                    SSTab1.Tab = GetTabVisible(SSTab1.Tab)
                Case ChkbInByProCheck.Name
                    SSTab1.Tab = GetTabVisible(SSTab1.Tab)
'                Case ChkFree(9).Name
'                    If Me.ActiveControl Is ChkFree(9) Then
'                        SSTab1.Tab = GetTabVisible(SSTab1.Tab)
'                    End If
            End Select
            SendKeys "{TAB}"
        End If
    Else
        If FrmMain.m_bEdit = False Then
            KeyAscii = 0
        End If
    End If
    Exit Sub
Err_Info:
    'need not deal with
End Sub

'---------------------------------------------
'���ý���
'---------------------------------------------
Private Sub SetEdtFocus()
    Dim i As Integer
    On Error GoTo Err_Info
    Select Case SSTab1.Tab
        Case 4
            InvPlan1.SetFocus
        Case 5
            InvBatchProperty1.SetFocus
        Case 6
            EdtCproduceNation.SetFocus
        Case 7
            CmbiTestStyle.SetFocus
            SendKeys "+{TAB}"
        Case 8
            InvFree1.SetFocus
        Case 9
            InvMPS1.SetFocus
    End Select
    Exit Sub
Err_Info:
    
End Sub

'-------------------------------------------------
'���ܣ� ��ÿ���ҳǩ
'������ CurTab:     ��ǰҳǩ
'-------------------------------------------------
Private Function GetTabVisible(CurTab As Integer) As Integer
    On Error GoTo Err_Info
    Dim i As Integer
    For i = CurTab + 1 To SSTab1.Tabs - 1
        If SSTab1.TabVisible(i) = True Then
            GetTabVisible = i
            Exit Function
        End If
    Next i
    GetTabVisible = CurTab
    Exit Function
Err_Info:
    GetTabVisible = CurTab
End Function



'---------------------------------------
'���ܣ��������ʱ��ʼ��
'---------------------------------------
Private Sub Form_Load()
        '2009-08-31 �ù���ͺ�֧��",������Ե��ݱ���û������
        EdtcInvStd.BadStrException = """"
    m_bFirstLoad = True
'Ϊ�����Ч�ʣ�ֹͣ����font����layoutͳһ���� 2005-07-09
    'g_oPub.Start
    Call g_oPub.FrmUniteFont(Me)
'    Call g_oPub.WriteTime("Font")
    'g_oPub.Start
'    Call g_oPub.FormLayout(Me, "INVENTORY")
    'Call g_oPub.WriteTime("Layout")

    'g_oPub.Start
    Call g_oPub.SetLabelCaption(SrvDB, Me.Controls, "Inventory")
    If g_bGSP = True Then
        ChkBPropertyCheck2.Caption = ChkBPropertyCheck.Caption '�Ƿ��ʼ�
        ChkbPeriodDT2.Caption = ChkbPeriodDT.Caption '�Ƿ����ڼ���
        lblcDTPeriod2.Caption = lblcDTPeriod.Caption '��������
        ChkbDTWarnInv2.Caption = ChkbDTWarnInv.Caption '�����ڴ���Ƿ����
    Else
        ChkBPropertyCheck2.Visible = False '�Ƿ��ʼ�
        ChkbPeriodDT2.Visible = False '�Ƿ����ڼ���
        lblcDTPeriod2.Visible = False '��������
        EdtcDTPeriod2.Visible = False '��������
        ChkbDTWarnInv2.Visible = False '�����ڴ���Ƿ����
    End If
    EdtfPrjMatLimit.Enabled = False '����޸ģ����ô��û��ѡ�д���Ĺ������ϣ���Ҫ����
    'Call g_oPub.WriteTime("labelcaption")

    'g_oPub.Start
    LoadRes
'    Call g_oPub.WriteTime("LoadRes")
    
    SSTab1.Tab = 0
    Call g_oPub.FrmOptInit(Me, 1)
    Call SetTab
    Call InitRef
    Tlb.Buttons(1).Enabled = False
    Call g_oPub.ReRefreshUFTlb(Me)
    Call InitClient
    'Call g_oPub.WriteTime("All")
End Sub

Private Sub InitRef()
    Dim sMetaXML As String
    Call EdtcGroupCode.Init(g_oLogin, g_URL + "ComputationGroup_AA", g_bIsWeb)
    Call EdtcComunitCode.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    Call EdtcPUComunitCode.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    Call EdtcSTComunitCode.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    Call EdtcShopUnit.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    Call EdtcProductUnit.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    Call EdtcSAComunitCode.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    Call EdtcCAComunitCode.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    
    Call EdtcInvCCode.Init(g_oLogin, g_URL + "InventoryClass_AA", g_bIsWeb)
    Call EdtcCIQCode.Init(g_oLogin, g_URL + "EX_REFER_CIQCODE_EX", g_bIsWeb)
    sMetaXML = "<Ref><RefSet   cRetFld='CVenName'  /></Ref>"
    Call EdtcEnterprise.Init(g_oLogin, g_URL + "Vendor_AA", g_bIsWeb, sMetaXML)
    EdtcEnterprise.AutoDisplayText = False
    EdtcEnterprise.RetStyle = Code_Code
    Call EdtcVenCode.Init(g_oLogin, g_URL + "Vendor_AA", g_bIsWeb)
    Call EdtcPurPersonCode.Init(g_oLogin, g_URL + "Person_AA", g_bIsWeb)
    Call EdtcDefWareHouse.Init(g_oLogin, g_URL + "Warehouse_AA", g_bIsWeb)
    Call EdtcPosition.Init(g_oLogin, g_URL + "Position_AA", g_bIsWeb)
    Call EdtcDTUnit.Init(g_oLogin, g_URL + "ComputationUnit_AA", g_bIsWeb)
    'ҵ�������û��ʵ��
    
    sMetaXML = "<Ref><RefSet   cRetFld='ID'  /></Ref>"
    Call EdtiQTMethod.Init(g_oLogin, g_URL + "QMCHECKPROJECT_QM", g_bIsWeb, sMetaXML)
    Call EdtcRuleCode.Init(g_oLogin, g_URL + "QMRANDORCHECK_QM", g_bIsWeb)
End Sub


Private Sub SetTab()
    On Error Resume Next
    'InitUserDef�ú󣬱�ѡ��־����Call g_oPub.FrmOptInit(Me, 1)
    'InitUserDef �����滻�¿ؼ������½���ؼ����µ���λ�ò���ȷ���ʽ��˺����ŵ�
    
    Dim i As Integer
'    For i = Frame1.UBound To 0 Step -1
'        Frame1(i).Left = 134
'        Frame1(i).Top = 360
'        Frame1(i).Height = Frame1(0).Height
'        Frame1(i).Width = Frame1(0).Width
'    Next i
    
    SSTab1.TabVisible(8) = InvFree1.bShow
    SSTab1.TabVisible(6) = False ' InvBatchProperty1.bShow
    
    'SSTab1.TabVisible(4) = g_bPP
    
    '��������е�ҽҩҳǩ��ʱ��ʾ������:
    '��ǰ�汾������ʱ����ҵ����=��ҽҩ������  ����������GSP������������������´�������е�ҽҩҳǩ�ͻ���ʾ��
    '861�ĵ�����ʱ����ҵ����=��ҽҩ����ҽԺ������ ����������GSP����������ʱ��������е�ҽҩҳǩ��ʾ��
'    If g_bMedicine = False And g_bGSP = False Then '
'        SSTab1.TabVisible(6) = False
'    End If
    'SSTab1.TabVisible(6) = False
    
    SSTab1.TabVisible(7) = g_bQM
    '���ǵ�ROP�����ڹ�����ҵ��Ӧ�ã���˽��йع�����Ϣ���ڼƻ�ҳǩ�У���Զ��ʾ��MPS/MRPֻ���ڹ�ҵ�����з�����ʾ
    SSTab1.TabVisible(9) = g_bFactory
'    SSTab1.TabVisible(10) = False
'    SSTabQuality.TabVisible(1) = False
    InitArchPlugin
End Sub

'---------------------------------------
'���ܣ����ƶ�д�ֶ�
'---------------------------------------
Private Sub InitRWFld()
    If g_bControlFldAuth = False Then Exit Sub
    If g_sNFldAuthInv = "" And (g_sRFldAuthInv = "" Or g_sRFldAuthInv = "*") Then Exit Sub   '�������ܻ�ӵ�������ֶ�Ȩ��
    
     '����
    m_cInvcodeRW = ConSet(Edtcinvcode, "cInvCode")
    Call ConSet(EdtcInvAddCode, "cInvAddCode")
    Call ConSet(EdtcInvName, "cInvName")
    Call ConSet(EdtcInvStd, "cInvStd")
    Call ConSet(EdtcInvCCode, "cInvCCode")
    Call ConSet(EdtcCIQCode, "cCIQCode")
'    Edtname.PasswordChar = EdtcInvCCode.PasswordChar
    Call ConSet(EdtfInvCIQExch, "fInvCIQExch")
    Call ConSet(EdtiTaxRate, "iTaxRate")
    Call ConSet(EdtiImpTaxRate, "iImpTaxRate")
'    Call ConSet(EdtiExpTaxRate, "iExpTaxRate")
    Call ConSet(EdtcGroupCode, "cGroupCode")
    If EdtcGroupCode.Enabled = False Then
        Call g_oPub.CloneComChk(Me, CmbiGroupType)
    End If
    Call ConSet(EdtcComunitCode, "cComunitCode")
    Call ConSet(EdtcPUComunitCode, "cPUComunitCode")
    Call ConSet(EdtcDTUnit, "cDTUnit")
    Call ConSet(EdtcSAComunitCode, "cSAComunitCode")
    Call ConSet(EdtcSTComunitCode, "cSTComunitCode")
    Call ConSet(EdtcCAComunitCode, "cCAComunitCode")
    Call ConSet(ChkbInvEntrust, "bInvEntrust")
    
    Call ConSet(chkbPiece, "bPiece")
    Call ConSet(ChkbSale, "bSale")
    Call ConSet(chkbExpSale, "bExpSale")
    Call ConSet(ChkbPurchase, "bPurchase")
    Call ConSet(ChkbSelf, "bSelf")
    Call ConSet(ChkbComsume, "bComsume")
    Call ConSet(ChkbProducing, "bProducing")
    Call ConSet(ChkbService, "bService")
    Call ConSet(ChkbAccessary, "bAccessary")
    Call ConSet(chkbBondedInv, "bBondedInv")
    Call ConSet(ChkbInvType, "bInvType")
    'Call ConSet(ChkbPromotSales, "bPromotSales")
    Call ConSet(ChkBPropertyCheck, "BPropertyCheck")
    Call ConSet(ChkBPropertyCheck2, "BPropertyCheck") 'ͬһ�ֿؼ�
    Call ConSet(EdtCEnglishName, "CEnglishName")
    Call ConSet(EdtcCIQCode, "cCIQCode")
    
    Call ConSet(EdtcProductUnit, "cProductUnit")
    Call ConSet(EdtcShopUnit, "cShopUnit")
    Call ConSet(ChkbPlanInv, "bPlanInv")
    Call ConSet(ChkbCheckItem, "bCheckItem")
    Call ConSet(chkbSrvItem, "bSrvItem")
    Call ConSet(chkbPrjMat, "bPrjMat")
    Call ConSet(chkbInvAsset, "bInvAsset")
    Call ConSet(chkbSrvProduct, "bSrvProduct")
    Call ConSet(ChkbSrvFittings, "bSrvFittings")
    Call ConSet(ChkbProxyForeign, "bProxyForeign")
    Call ConSet(ChkbATOModel, "bATOModel")
    Call ConSet(ChkbPTOModel, "bPTOModel")
    Call ConSet(ChkbInvModel, "bInvModel")
    Call ConSet(ChkbEquipment, "bEquipment")
    Call ConSet(EdtcEnterprise, "cEnterprise")
    Call ConSet(EdtcAddress, "cAddress")
    Call ConSet(EdtCproduceNation, "CproduceNation")
    Call ConSet(EdtcProduceAddress, "cProduceAddress")
    Call ConSet(EdtCcurrencyName, "CcurrencyName")
    
    '�ɱ�
    Call ConSet(CbocValueType, "cValueType")
    Call ConSet(EdtfExpensesExch, "fExpensesExch")
    Call ConSet(EdtiInvMPCost, "iInvMPCost")
    Call ConSet(EdtcVenCode, "CVenCode")
    Call ConSet(EdtcPurPersonCode, "cPurPersonCode")
    Call ConSet(EdtcDefWareHouse, "cDefWareHouse")
    Call ConSet(EdtiInvRCost, "iinvrcost")
    Call ConSet(EdtiInvSCost, "iinvscost")
    Call ConSet(EdtiInvLSCost, "iinvlscost")
    Call ConSet(EdtiInvNCost, "iinvncost")
    Call ConSet(EdtiInvSPrice, "iinvsprice")
    Call ConSet(EdtcPriceGroup, "cPriceGroup")
    Call ConSet(EdtcOfferGrade, "cOfferGrade")
    Call ConSet(EdtiHighPrice, "iHighPrice")
    Call ConSet(EdtiExpSaleRate, "iExpSaleRate")
    Call ConSet(EdtiOfferRate, "iOfferRate")
    'Call ConSet(EdtfExpPrice, "fExpPrice")
'    Call ConSet(EdtfBackTaxRate, "fBackTaxRate")
    Call ConSet(EdtfRetailPrice, "fRetailPrice")
    Call ConSet(EdtfCurLLaborCost, "fCurLLaborCost")
    Call ConSet(EdtfCurLVarManuCost, "fCurLVarManuCost")
    Call ConSet(EdtfCurLFixManuCost, "fCurLFixManuCost")
    Call ConSet(EdtfCurLOMCost, "fCurLOMCost")
    Call ConSet(EdtfNextLLaborCost, "fNextLLaborCost")
    Call ConSet(EdtfNextLVarManuCost, "fNextLVarManuCost")
    Call ConSet(EdtfNextLFixManuCost, "fNextLFixManuCost")
    Call ConSet(EdtfNextLOMCost, "fNextLOMCost")

    '����
    Call ConSet(Combo1, "cinvabc")
    Call ConSet(EdtiSafeNum, "iSafeNum")
    Call ConSet(EdtiTopSum, "ITopSum")
    Call ConSet(EdtiLowSum, "ILowSum")
    Call ConSet(EdtcReplaceItem, "creplaceitem")
    Call ConSet(EdtcPosition, "cposition")
    Call ConSet(EdtiOverStock, "ioverstock")
    Call ConSet(EdtfInExcess, "fInExcess")
    Call ConSet(EdtfOutExcess, "fOutExcess")
    Call ConSet(EdtfBuyExcess, "fBuyExcess")
    Call ConSet(EdtfPrjMatLimit, "fPrjMatLimit")
    Call ConSet(EdtiWastage, "iWastage")
    Call ConSet(EdtdLastDate, "dLastDate")
    Call ConSet(EdtiFrequency, "iFrequency")
    Call ConSet(EdtiDrawBatch, "iDrawBatch")
    Call ConSet(CbocFrequency, "cFrequency")
    m_iDaysRW = ConSet(CboiDays, "iDays")
    Call ConSet(ChkbInvBatch, "bInvBatch")
    Call ConSet(ChkbInvQuality, "bInvQuality")
    Call ConSet(EdtiMassDate, "iMassDate")
    Call ConSet(EdtdWarnDays, "iWarnDays")
    Call ConSet(ChkbBarCode, "bBarCode")
    Call ConSet(EdtcBarCode, "CbarCode")
    Call ConSet(ChkbSerial, "bSerial")
    Call ConSet(ChkbTrack, "bTrack")
    Call ConSet(ChkbInvOverStock, "bInvOverStock")
    Call ConSet(ChkbSolitude, "bSolitude")
    Call ConSet(ChkbKCCutMantissa, "bKCCutMantissa")
    Call ConSet(CmbcMassUnit, "cMassUnit")
    Call ConSet(cmbiExpiratDateCalcu, "iExpiratDateCalcu")
    
    Call ConSet(ChkbDTWarnInv, "bDTWarnInv")
    Call ConSet(ChkbDTWarnInv2, "bDTWarnInv") 'ͬһ�ֿؼ�
    
    Call ConSet(ChkbPeriodDT, "bPeriodDT")
    Call ConSet(ChkbPeriodDT2, "bPeriodDT") 'ͬһ�ֿؼ�
    
    Call ConSet(EdtcDTPeriod, "cDTPeriod")
    Call ConSet(EdtcDTPeriod2, "cDTPeriod") 'ͬһ�ֿؼ�
    
    Call ConSet(EdtfOrderUpLimit, "fOrderUpLimit")
    Call ConSet(EdtfInvOutUpLimit, "fInvOutUpLimit")
    Call ConSet(EdtfMinSplit, "fMinSplit")
    
    
     '����
     Call InvOther1.SetConAuth(g_sRFldAuthInv, g_sNFldAuthInv)
'    Call ConSet(EdtiInvWeight, "iinvweight")
'    m_dSDateRW = ConSet(EdtdSDate, "dSDate")
'    Call ConSet(EdtdEDate, "dEDate")
'    Call ConSet(EdtiVolume, "ivolume")
'    Call ConSet(EdtcQua, "cQuality")
'    Call ConSet(EdtCCreatePerson, "CCreatePerson")
'    Call ConSet(EdtiId, "iId")
'    Call ConSet(EdtcModifyPerson, "cModifyPerson")
'    Call ConSet(EdtDModifyDate, "dModifyDate")
    
    '�ƻ�
    Call InvPlan1.SetConAuth(g_sRFldAuthInv, g_sNFldAuthInv)
    'MPS/MRP
    Call InvMPS1.SetConAuth(g_sRFldAuthInv, g_sNFldAuthInv)
    
    '�Զ���/������
    Call InvFree1.SetConAuth(g_sRFldAuthInv, g_sNFldAuthInv)
    Call InvBatchProperty1.SetConAuth(g_sRFldAuthInv, g_sNFldAuthInv)
    Dim i As Integer
    Dim sField As String
    For i = 0 To EdtU.UBound
        sField = "cInvDefine" + CStr(i + 1)
        Call ConSet(EdtU(i), sField)
        If i < 14 Then
'            CmdU(i).Enabled = EdtU(i).Enabled
        End If
    Next i
'    CmdDate(3).Enabled = EdtU(14).Enabled
'    CmdDate(4).Enabled = EdtU(15).Enabled
'    Dim sDef As String
'    For i = 0 To ChkFree.UBound
'        sDef = "bFree" + CStr(i + 1)
'        Call ConSet(ChkFree(i), sDef)
'    Next i

    
    
    'GSPҳ��


    '����
    Call ConSet(CmbiTestStyle, "iTestStyle")
    Call ConSet(CmbiDTMethod, "iDTMethod")
    m_fDTRateRW = ConSet(EdtfDTRate, "fDTRate")
    m_fDTNumRW = ConSet(EdtfDTNum, "fDTNum")
    m_iDTStyleRW = ConSet(CmbiDTStyle, "iDTStyle")
    Call ConSet(EdtiQTMethod, "iQTMethod")
    Call ConSet(EdtcRuleCode, "cRuleCode")
    Call ConSet(CmbiDTLevel, "iDTLevel")
    Call ConSet(CmbcDTAQL, "cDTAQL")
    Call ConSet(CmbiEndDTStyle, "iEndDTStyle")
    Call ConSet(cmbiTestRule, "iTestRule")
    Call ConSet(ChkbOutInvDT, "bOutInvDT")
    Call ConSet(ChkbBackInvDT, "bBackInvDT")
    Call ConSet(ChkbReceiptByDT, "bReceiptByDT")
    Call ConSet(chkbInvROHS, "bInvROHS")
    Call ConSet(ChkbInByProCheck, "bInByProCheck")
    Dim rw As Integer
    rw = ConSet(Pic, "PictureGUID")
    Call Pic.SetRW(rw)
    If rw = 0 Then
        SSTab1.TabVisible(10) = False
    End If
    rw = ConSet(Pic, "bIsAttachFile")
    Call Me.InvAttachfile1.SetRW(rw)
    If rw = 0 Then
        SSTab1.TabVisible(12) = False
    End If
    
'''    Cmd(0).Enabled = EdtcInvCCode.Enabled
'''    Cmd(1).Enabled = EdtcVenCode.Enabled
'''    Cmd(2).Enabled = EdtcPosition.Enabled
'''    Cmd(3).Enabled = EdtcGroupCode.Enabled
'''    Cmd(4).Enabled = EdtcEnterprise.Enabled
'''    Cmd(5).Enabled = EdtcComunitCode.Enabled
'''    Cmd(6).Enabled = EdtcPUComunitCode.Enabled
'''    Cmd(7).Enabled = EdtcSAComunitCode.Enabled
'''    Cmd(8).Enabled = EdtcSTComunitCode.Enabled
'''    Cmd(9).Enabled = EdtcCAComunitCode.Enabled
'''    Cmd(10).Enabled = EdtcDefWareHouse.Enabled
'''    Cmd(11).Enabled = EdtcDTUnit.Enabled
'''    Cmd(12).Enabled = EdtiQTMethod.Enabled
'''    Cmd(13).Enabled = EdtcProductUnit.Enabled
'''    Cmd(14).Enabled = EdtcShopUnit.Enabled
'''    Cmd(15).Enabled = EdtcPurPersonCode.Enabled
'''
'''    CmdDate(0).Enabled = EdtdLastDate.Enabled
'    CmdDate(1).Enabled = EdtdSDate.Enabled
'    CmdDate(2).Enabled = EdtdEDate.Enabled
End Sub


'---------------------------------------
'���ܣ� �����ֶζ�дȨ�ޣ�������Ӧ�Ŀؼ�״̬
'������ Con��       �ؼ�����
'       FldName��   �ֶ�����
'���أ� 0���޶�дȨ�ޣ�1����Ȩ�ޣ�2��дȨ��
'---------------------------------------
Private Function ConSet(Con As Object, ByVal fldName As String) As Integer
    ConSet = g_oPub.ConAuthSet(Me, Con, fldName, g_sRFldAuthInv, g_sNFldAuthInv)
End Function
'----------------------------------------------
'���ܣ���һЩEdit�ؼ����¶���򲹳䲻�������ַ�
'----------------------------------------------
Private Sub AddBadStr()
    Edtcinvcode.BadStrEx = " "
    'ʹ����͹���������Ӣ��*��
    'Edtcinvcode.BadStr = Replace(Edtcinvcode.BadStr, "*", "")
    'EdtcInvStd.BadStr = Replace(EdtcInvStd.BadStr, "*", "")
    '2003.11.21 ver860
    'ʹ���ƿ�������Ӣ��*��
    'EdtcInvName.BadStr = Replace(EdtcInvName.BadStr, "*", "")
'    EdtiInvWeight.BadStr = EdtiInvWeight.BadStr + "-" '��λ��������С����!"
'    EdtiVolume.BadStr = EdtiVolume.BadStr + "-" '��λ�������С����!"
    EdtiInvRCost.BadStrEx = "-" '�ɱ�'��'�ƻ��ۻ��ۼ�'����С����"
    EdtiInvSPrice.BadStrEx = "-" '�ɱ�'��'�ο��ɱ�'����С����"
    EdtiInvSCost.BadStrEx = "-" '�ɱ�'��'�ο��ۼ�'
    EdtiInvNCost.BadStrEx = "-" '�ɱ�'��'���³ɱ�'
    EdtiInvLSCost.BadStrEx = "-" ''�ɱ�'��'����ۼ�'����С����"
    EdtiInvMPCost.BadStrEx = "-" ''�ɱ�'��'��߽���'����С����"
    EdtfCurLLaborCost.BadStrEx = "-"  '����С����"
    EdtfCurLVarManuCost.BadStrEx = "-"  '����С����"
    EdtfCurLFixManuCost.BadStrEx = "-"  '����С����"
    EdtfCurLOMCost.BadStrEx = "-"  '����С����"
    EdtfNextLLaborCost.BadStrEx = "-"  '����С����"
    EdtfNextLVarManuCost.BadStrEx = "-"  '����С����"
    EdtfNextLFixManuCost.BadStrEx = "-"  '����С����"
    EdtfNextLOMCost.BadStrEx = "-"  '����С����"
    EdtfInvCIQExch.BadStrEx = "-"
    EdtfInvOutUpLimit.BadStrEx = "-"
'    EdtfFixedBatch.BadStr = EdtfFixedBatch.BadStr + "-" '������ֵӦ������
'    EdtfMaxOrder.BadStr = EdtfMaxOrder.BadStr + "-"
'    EdtfMinOrder.BadStr = EdtfMinOrder.BadStr + "-"
'    EdtfBatchIncrement.BadStr = EdtfBatchIncrement.BadStr + "-" '��������
    'EdtiOrderIntervalDays.BadStr = EdtiOrderIntervalDays.BadStr + "-" '�����������
'    EdtiAssureProvideDays.BadStr = EdtiAssureProvideDays.BadStr + "-"  '��֤��Ӧ����
'    EdtfBackTaxRate.BadStrEx = "-"
    EdtiMassDate.BadStrEx = "-" '������
    EdtfMinSplit.BadStrEx = "-"
    EdtfPrjMatLimit.BadStrEx = "-"
End Sub

Private Sub SetBadStrException()
    Call g_oPub.SetBadStrException(EdtcInvName)
    Call g_oPub.SetBadStrException(EdtcInvStd)
    Call g_oPub.SetBadStrException(EdtCcurrencyName)
    Call g_oPub.SetBadStrException(EdtCEnglishName)
    '2009-08-31 �ù���ͺ�֧��",������Ե��ݱ���û������
    EdtcInvStd.BadStrException = EdtcInvStd.BadStrException & """"

    '2009-09-22 �ô�����롢������ơ�Ӣ�����ƺ�ͨ������֧��" zjtͬ�� ����ţ�909160122
    EdtcInvName.BadStrException = EdtcInvName.BadStrException & """"
    EdtCcurrencyName.BadStrException = EdtCcurrencyName.BadStrException & """"
    EdtCEnglishName.BadStrException = EdtCEnglishName.BadStrException & """"
    Edtcinvcode.BadStrException = Edtcinvcode.BadStrException & """"
    
    '����ͻ���Ҫ�����Ƕ������� 201010090034 2010-10-19
    EdtcInvName.BadStrException = EdtcInvName.BadStrException & ","
    EdtCEnglishName.BadStrException = EdtCEnglishName.BadStrException & ","
    EdtCcurrencyName.BadStrException = EdtCcurrencyName.BadStrException & ","
    EdtcInvAddCode.BadStrException = EdtcInvAddCode.BadStrException & ","
    EdtcInvStd.BadStrException = EdtcInvStd.BadStrException & ","
    
'    Call g_oPub.SetBadStrException(EdtcEnterprise)
'    Call g_oPub.SetBadStrException(EdtCproduceNation)
'    Call g_oPub.SetBadStrException(EdtcProduceAddress)
'
'    Call g_oPub.SetBadStrException(EdtcAddress)
'
'    Call g_oPub.SetBadStrException(EdtcPreparationType)
'    Call g_oPub.SetBadStrException(EdtCPackingType)
'    Call g_oPub.SetBadStrException(EdtcFile)
'    Call g_oPub.SetBadStrException(EdtcLabel)
'    Call g_oPub.SetBadStrException(EdtcCheckOut)
'    Call g_oPub.SetBadStrException(EdtcLicence)
'    Call g_oPub.SetBadStrException(EdtCEnterNo)
'    Call g_oPub.SetBadStrException(EdtCRegisterNo)
'    Call g_oPub.SetBadStrException(EdtCCommodity)
'    Call g_oPub.SetBadStrException(EdtCNotPatentName)
'    Dim i As Integer
'    For i = 0 To 10
'        Call g_oPub.SetBadStrException(EdtU(i))
'    Next i
'
'    Call g_oPub.SetBadStrException(EdtcGroupCode)
'    Call g_oPub.SetBadStrException(EdtcComunitCode)
'    Call g_oPub.SetBadStrException(EdtcPUComunitCode)
'    Call g_oPub.SetBadStrException(EdtcProductUnit)
'    Call g_oPub.SetBadStrException(EdtcSAComunitCode)
'    Call g_oPub.SetBadStrException(EdtcSTComunitCode)
'    Call g_oPub.SetBadStrException(EdtcCAComunitCode)
'    Call g_oPub.SetBadStrException(EdtcShopUnit)
'    Call g_oPub.SetBadStrException(EdtcInvCCode)
'    Call g_oPub.SetBadStrException(EdtcVenCode)
'    Call g_oPub.SetBadStrException(EdtcPurPersonCode)
'    Call g_oPub.SetBadStrException(EdtcDefWareHouse)
'    Call g_oPub.SetBadStrException(EdtcPosition)
'    Call g_oPub.SetBadStrException(EdtcDTUnit)
'    Call g_oPub.SetBadStrException(EdtiQTMethod)
End Sub

'---------------------------------------
'���ܣ����ñ༭���������볤�ȣ��Լ�С��λ����
'---------------------------------------
Private Sub SetFieldLength()
    Dim Rs As ADODB.Recordset
    On Error Resume Next
    Set Rs = SrvDB.OpenX("select * from Inventory, inventory_Sub computationUnit,ComputationGroup,Position,Vendor ,Warehouse,qmCheckProject,Department,Person,mps_timefence where 1=2")
    If Rs Is Nothing Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.2879_1") 'U8.AA.INVENTORY.FRMZAM.2879_1="���ݿ�û������,���Ժ��ٲ⣬лл������"
        Exit Sub
    End If
    '����ҳ��
    Edtcinvcode.MaxLength = Rs.Fields("cInvCode").DefinedSize
    EdtcInvAddCode.MaxLength = Rs.Fields("cInvAddCode").DefinedSize '25
    EdtcInvName.MaxLength = Rs.Fields("cInvName").DefinedSize '60
    EdtcInvStd.MaxLength = Rs.Fields("cInvStd").DefinedSize '30
    EdtcInvCCode.MaxLength = 0 ' Rs.Fields("cInvCCode").DefinedSize
    EdtcCIQCode.MaxLength = 0 'Rs.Fields("cCIQCode").DefinedSize
    Call g_oPub.SetDblLen(EdtfInvCIQExch, 3 + 2 + g_iQuanDecDgt, g_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtiTaxRate, 3 + 2 + g_iRateDecDgt, g_iRateDecDgt)
    Call g_oPub.SetDblLen(EdtiImpTaxRate, 3 + 2 + g_iRateDecDgt, g_iRateDecDgt)
'    Call g_oPub.SetDblLen(EdtiExpTaxRate, 3 + 2 + g_iRateDecDgt, g_iRateDecDgt)
    EdtcGroupCode.MaxLength = Rs.Fields("cGroupName").DefinedSize 'cGroupCode
    EdtcComunitCode.MaxLength = 0 'Rs.Fields("CComUnitName").DefinedSize 'cComunitCode
    EdtcPUComunitCode.MaxLength = 0 ' Rs.Fields("CComUnitName").DefinedSize 'cPUComunitCode
    EdtcDTUnit.MaxLength = 0 'Rs.Fields("cDTUnit").DefinedSize '��������ҳǩ�м��������λ
    EdtcSAComunitCode.MaxLength = 0 ' Rs.Fields("CComUnitName").DefinedSize 'cSAComunitCode
    EdtcSTComunitCode.MaxLength = 0 ' Rs.Fields("CComUnitName").DefinedSize 'cSTComunitCode
    EdtcCAComunitCode.MaxLength = 0 'Rs.Fields("CComUnitName").DefinedSize 'cCAComunitCode
    EdtcProductUnit.MaxLength = 0 'Rs.Fields("CComUnitName").DefinedSize
    EdtcShopUnit.MaxLength = 0 'Rs.Fields("CComUnitName").DefinedSize
    EdtCEnglishName.MaxLength = Rs.Fields("CEnglishName").DefinedSize
    EdtCproduceNation.MaxLength = Rs.Fields("CproduceNation").DefinedSize
    EdtcProduceAddress.MaxLength = Rs.Fields("cProduceAddress").DefinedSize
    EdtcEnterprise.MaxLength = 0 ' Rs.Fields("cEnterprise").DefinedSize '
    EdtcAddress.MaxLength = Rs.Fields("cAddress").DefinedSize '
    EdtCcurrencyName.MaxLength = Rs.Fields("CcurrencyName").DefinedSize
    
    '�ɱ�ҳ��
    Call g_oPub.SetDblLen(EdtiInvRCost, , g_iPriceDecDgt) '�ƻ��ۻ��ۼ�
    Call g_oPub.SetDblLen(EdtiInvSPrice, , g_iPriceDecDgt) '�ο��ɱ�
    Call g_oPub.SetDblLen(EdtiInvNCost, , g_iPriceDecDgt) '���³ɱ�
    Call g_oPub.SetDblLen(EdtiInvMPCost, , g_iPriceDecDgt) '��߽���iInvMPCost
    Call g_oPub.SetDblLen(EdtfExpensesExch, , g_iDecDgt6) 'g_iPriceDecDgt
    Call g_oPub.SetDblLen(EdtiInvSCost, , g_iBillPriceDecDgt) '�ο��ۼ�
    Call g_oPub.SetDblLen(EdtiInvLSCost, , g_iBillPriceDecDgt) '����ۼ�
    Call g_oPub.SetDblLen(EdtfCurLLaborCost, , g_iPriceDecDgt)
    Call g_oPub.SetDblLen(EdtfCurLVarManuCost, , g_iPriceDecDgt)
    Call g_oPub.SetDblLen(EdtfCurLFixManuCost, , g_iPriceDecDgt)
    Call g_oPub.SetDblLen(EdtfCurLOMCost, , g_iPriceDecDgt)
    Call g_oPub.SetDblLen(EdtfNextLLaborCost, , g_iPriceDecDgt)
    Call g_oPub.SetDblLen(EdtfNextLVarManuCost, , g_iPriceDecDgt)
    Call g_oPub.SetDblLen(EdtfNextLFixManuCost, , g_iPriceDecDgt)
    Call g_oPub.SetDblLen(EdtfNextLOMCost, , g_iPriceDecDgt)

    EdtcVenCode.MaxLength = 0 'Rs.Fields("cVenName").DefinedSize '60
    EdtcPurPersonCode.MaxLength = 0 ' Rs.Fields("cPersonName").DefinedSize
    EdtcDefWareHouse.MaxLength = 0 'Rs.Fields("cWhName").DefinedSize
    EdtcPriceGroup.MaxLength = Rs.Fields("cPriceGroup").DefinedSize
    EdtcOfferGrade.MaxLength = Rs.Fields("cOfferGrade").DefinedSize

    g_oPub.SetDblLen EdtiHighPrice, , g_iPriceDecDgt '����ۼ�
    g_oPub.SetDblLen EdtiExpSaleRate, , 4 '���ۼӳ���
    g_oPub.SetDblLen EdtiOfferRate, , 4 '���۹�����
'    Call g_oPub.SetDblLen(EdtfBackTaxRate, 2 + 2 + g_iRateDecDgt, g_iRateDecDgt)
    g_oPub.SetDblLen EdtfRetailPrice, , g_iPriceDecDgt
    
    'Call g_oPub.SetDblLen(EdtfExpPrice, , g_iBillPriceDecDgt) '���õ���
    
    '����ҳ��
    EdtcBarCode.MaxLength = Rs.Fields("cBarCode").DefinedSize
        
    g_oPub.SetDblLen EdtfInExcess, , g_iDecDgt6 'g_iQuanDecDgt
    g_oPub.SetDblLen EdtfOutExcess, , g_iDecDgt6 'g_iQuanDecDgt
    g_oPub.SetDblLen EdtfBuyExcess, , g_iDecDgt6 'g_iQuanDecDgt
    g_oPub.SetDblLen EdtfPrjMatLimit, , g_iDecDgt6 'g_iQuanDecDgt
    g_oPub.SetDblLen EdtiWastage, , g_iDecDgt6 'g_iQuanDecDgt
    
    
    g_oPub.SetDblLen EdtiOverStock, , g_iQuanDecDgt '4
    
    
    Call g_oPub.SetDblLen(EdtiLowSum, , g_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtiSafeNum, , g_iQuanDecDgt)
    Call g_oPub.SetDblLen(EdtiTopSum, , g_iQuanDecDgt)
    
    EdtcReplaceItem.MaxLength = Rs.Fields("cReplaceItem").DefinedSize
    EdtcPosition.MaxLength = 0 ' Rs.Fields("cPosName").DefinedSize 'cPosition
    Call g_oPub.SetIntLen(EdtiMassDate, 4)
    Call g_oPub.SetIntLen(EdtdWarnDays, 4)
    Call g_oPub.SetIntLen(EdtiFrequency, 4)
    '����¼��С��������>0���������ó��г�β����������¼��С���������г�β������������ʱҪ�໥У�飩
    'Call g_oPub.SetIntLen(EdtiDrawBatch)
    Call g_oPub.SetDblLen(EdtiDrawBatch, , g_iQuanDecDgt)
    g_oPub.SetDblLen EdtfOrderUpLimit, , g_iDecDgt6 'g_iQuanDecDgt
    g_oPub.SetDblLen EdtfInvOutUpLimit, , g_iDecDgt6 'g_iQuanDecDgt
    g_oPub.SetDblLen EdtfMinSplit, , g_iDecDgt6 'g_iQuanDecDgt
    
    
    '����ҳ��
    Call InvOther1.SetFldLength(Rs, g_iQuanDecDgt)
'    EdtcQua.MaxLength = Rs.Fields("cQuality").DefinedSize '100
'    g_oPub.SetDblLen EdtiInvWeight, , g_iQuanDecDgt '4
'    g_oPub.SetDblLen EdtiVolume, , g_iQuanDecDgt '4
'    EdtCEnglishName.MaxLength = Rs.Fields("CEnglishName").DefinedSize
    '�ƻ�
    Call InvPlan1.SetFldLength(Rs, g_iQuanDecDgt)
    'MPS/MRP
    Call InvMPS1.SetFldLength(Rs, g_iQuanDecDgt)
    
    
    '�Զ���ҳ��
    Call g_oPub.SetIntLen(EdtU(10))
    Call g_oPub.SetIntLen(EdtU(11))
    'Call g_oPub.SetDblLen(EdtU(12), , 6)
    'Call g_oPub.SetDblLen(EdtU(13), , 6)
    'GSPҳ��
    'If g_bGSP = True Then
        
    'End If
    '����
    Call g_oPub.SetDblLen(EdtfDTRate, 3 + 2 + g_iDecDgt6, g_iDecDgt6)
    Call g_oPub.SetDblLen(EdtfDTNum, , g_iQuanDecDgt)
    EdtcDTUnit.MaxLength = 0 ' Rs.Fields("CComUnitName").DefinedSize
    EdtiQTMethod.MaxLength = 0 ' Rs.Fields("cProjectName").DefinedSize
    EdtcRuleCode.MaxLength = 0 '
    
'    EdtdSDate.Text = Date
End Sub


'---------------------------------------
'���ܣ�ͼƬ����ͼƬ����������ʼ�������水ťͼ�����
'---------------------------------------
Private Sub LoadRes()
    On Error Resume Next
    With ImageList1.ListImages
        .Add 1, "pSave", LoadResPicture(111, 0)
        .Add 2, "Empty", LoadResPicture(110, 0) '���ֿ���
        .Add 3, "pClose", LoadResPicture(120, 0)
        .Add 4, "First", LoadResPicture(133, 0)
        .Add 5, "Previous", LoadResPicture(131, 0)
        .Add 6, "Next", LoadResPicture(132, 0)
        .Add 7, "Last", LoadResPicture(134, 0)
        .Add 8, "Unit", LoadResPicture(136, 0)
   End With
    With Tlb
        .ImageList = ImageList1
        
        '.Buttons(1).ToolTipText = LoadResString(65) & "( F6 )"
        .Buttons(1).Image = 1
        '.Buttons(1).Caption = LoadResString(65)
        .Buttons(1).Key = "SaveRs"
        .Buttons(2).Image = 2
        '.Buttons(2).Caption = "����" 'LoadResString(1109)
        '.Buttons(2).ToolTipText = "����" 'LoadResString(1110)
        .Buttons(2).Key = "Copy"
        .Buttons(3).Image = 8
        '.Buttons(3).Caption = "��λ"
        '.Buttons(3).ToolTipText = "������λ"
        .Buttons(3).Key = "Unit"
        .Buttons(3).Visible = False
        
        .Buttons(5).Image = 4
        '.Buttons(5).Caption = LoadResString(1101)
        '.Buttons(5).ToolTipText = LoadResString(1105)
        .Buttons(5).Key = "First"
        .Buttons(6).Image = 5
        '.Buttons(6).Caption = LoadResString(1102)
        '.Buttons(6).ToolTipText = LoadResString(1106)
        .Buttons(6).Key = "Previous"
        .Buttons(7).Image = 6
        '.Buttons(7).Caption = LoadResString(1103)
        '.Buttons(7).ToolTipText = LoadResString(1107)
        .Buttons(7).Key = "Next"
        .Buttons(8).Image = 7
        '.Buttons(8).Caption = LoadResString(1104)
        '.Buttons(8).ToolTipText = LoadResString(1108)
        .Buttons(8).Key = "Last"
        
        '.Buttons(10).ToolTipText = LoadResString(67)
        .Buttons(10).Image = 3
        '.Buttons(10).Caption = "�˳�"
        .Buttons(10).Key = "Exit"
    End With
    Call g_oPub.SetTlb(Tlb)
    Dim Cons As New Collection
    Cons.Add (Me.Controls(SSTab1.Name))
    Cons.Add (Me.Controls(LblNote.Name))
    
    Call g_oPub.SetUFTlbStyleNew(Me, False, Frame6, ShowKeyInfo1, Cons)
    
    Dim i As Integer

    
    Me.Icon = Nothing ' LoadResPicture(101, vbResIcon)
    Call g_oPub.SetTabCaption(Me, g_oPub.GetResString("U8.AA.INVENTORY.sstab1tabcaption"), SSTab1)
    If Len(m_TradeTabCaption) > 0 Then
        Call g_oPub.SetTabCaption(Me, m_TradeTabCaption, SSTab1, True, 11, Nothing)
    End If
    
    For i = 0 To SSTab1.Tabs - 1
        SSTab1.TabCaption(i) = "" '���ڽ��治�������ѿո�ȥ��
    Next i
    
    LblcGroupCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cgroupcode")
    LabcComunitCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.ccomunitcode")
    LblcProductUnit.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cproductunit")
    LabcPUComunitCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cpucomunitcode")
    LblcSAComunitCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.csacomunitcode")
    LblcSTComunitCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cstcomunitcode")
    LblcCAComunitCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.ccacomunitcode")
    LblcCIQUnitCode.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.ciq_unit")
    LabcInvCCode.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cinvcls")
    LblCboiDays2.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.day")
    LblcDTUnit.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cdtunit")
    UFFrameProperty.Caption = "  " + g_oPub.GetResString("U8.AA.INVENTORY.prop")
    LabcVenCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cvencode")
    LblcPurPersonCode.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cpurpersoncode")
    LblcDefWareHouse.Caption = g_oPub.GetResString("U8.AA.INVENTORY.cdefwarehouse")
    LabcPosition.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.ref_cposcode")
    LbliQTMethod.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.ref_cprojectcode")
    Call g_oPub.RemoveCodeCaption(LblcRuleCode)
    Call g_oPub.SetConPosition(Me.Controls)
    Me.ShowKeyInfo1.CodeCaption = Labcinvcode.Caption
    Me.ShowKeyInfo1.NameCaption = LabcInvName.Caption
End Sub


'-------------------------------------------
'���̹��ܣ������ñ�����ֵ������ĳЩ��Ŀ�Ƿ�ɱ༭����ʽ��
'-------------------------------------------
Private Sub InitValSet()
    ChkbInvEntrust.Enabled = CS1
    
    '���ڲ������в���ʵ�֣������ͷ���������Ʒ��Ҫ�õ����кŹ����������Թ��ڴ�������С��Ƿ����кŹ���ѡ��Ŀ��ƹ�����Ҫ��һЩ������Ĭ��Ϊ���񡱡���ʱ�ɸġ�
    'ChkbSerial.Enabled = g_bSerialEnabled
    ChkbTrack.Enabled = g_bInvSysStart
    ChkbBarCode.Enabled = g_bInvSysStart
    'ChkbSerial.Enabled = CS2
    ChkbInvBatch.Enabled = CS2
    'ChkbTrack.Enabled = CS2
    
    ChkbInvQuality.Enabled = CS3
'    '2005-02-23 (Ver861)��������п���ҳǩ�µ�"�Ƿ����ڼ���"ѡ���ΪֻҪ���ʼ�Ĵ��"�Ƿ����ڼ���"�Ϳ�������Ϊ"��"��
'    If CS3 = False And g_bGSP = True Then
        ChkbPeriodDT.Enabled = False
        EdtcDTPeriod.Enabled = False
        lblcDTPeriod.Enabled = False
        '---------------------------------
        '2010-1-12
        '����ţ�200912150180 '���ڣ�����GSPʱ,����ҳǩ�ֶ�,�����ڴ������,���ڼ���,�������ڷŵ�����ҳǩ.
        ChkbPeriodDT2.Enabled = False
        EdtcDTPeriod2.Enabled = False
        lblcDTPeriod2.Enabled = False
        '---------------------------------
'    End If

    
    Combo1.Clear
    Combo1.AddItem ""
    Combo1.AddItem "A"
    Combo1.AddItem "B"
    Combo1.AddItem "C"
    
    ChkbAccessary.Enabled = CS4
''''    EdtcInvA.Enabled = CS5
''''    EdtiInvExchRate.Enabled = CS5
''''    EdtiInvExchRate.Numpoint = g_iExchRateDecDgt
    Me.LblNote = ""
    
'    CbocFrequency.Clear
'    CbocFrequency.AddItem "��", 0
'    CbocFrequency.AddItem "��", 1
'    CbocFrequency.AddItem "��", 2
'    CbocFrequency.ListIndex = 0
    Call AddCmbItems(CbocFrequency, cFrequencyItems, 0)
    
'    CbocValueType.Clear
'    With CbocValueType
'        If g_bFactory = False Then ' "��ҵ"
'            .AddItem ""
'            .AddItem "�ۼ۷�"
'            .AddItem "ȫ��ƽ����"
'            .AddItem "�ƶ�ƽ����"
'            .AddItem "�Ƚ��ȳ���"
'            .AddItem "����ȳ���"
'            .AddItem "����Ƽ۷�"
'        Else '��ҵ
'            .AddItem ""
'            .AddItem "�ƻ��۷�"
'            .AddItem "ȫ��ƽ����"
'            .AddItem "�ƶ�ƽ����"
'            .AddItem "�Ƚ��ȳ���"
'            .AddItem "����ȳ���"
'            .AddItem "����Ƽ۷�"
'        End If
'    End With
    Call AddCmbItems(CbocValueType, cValueTypeItems)

'    CmbiGroupType.Clear
'    CmbiGroupType.AddItem "�޻���" ', 2
'    CmbiGroupType.AddItem "�̶�����" ', 0
'    CmbiGroupType.AddItem "��������" ', 1
    Call AddCmbItems(CmbiGroupType, iGroupTypeItems)
    
'    CmbiPlanPolicy.Clear '�ƻ�����
'    CmbiPlanPolicy.AddItem ""
'    CmbiPlanPolicy.AddItem "MRP��"
'    CmbiPlanPolicy.AddItem STR_ROP
'    'CmbiPlanPolicy.AddItem "�����"
'
'
'    CmbiROPMethod.Clear '�ٶ����㷽��
'    CmbiROPMethod.AddItem "�ֹ�"
'    CmbiROPMethod.AddItem "�Զ�"
'    CmbiPlanPolicy.ListIndex = 1 '��ֵ������CmbiROPMethodҪѡ���CmbiROPMethod��ֵ��ǰ
'    CmbiROPMethod.ListIndex = -1
'
'    strBATCHRULE(0) = ""
'    strBATCHRULE(1) = "ֱ������"
'    strBATCHRULE(2) = "�̶�����"
'    strBATCHRULE(3) = "�ڼ�����" '�����ÿգ�ͨ������ӷ�ʽ���Է���strBATCHRULE(0)����
'    strBATCHRULE(4) = "��������߿�"
'    strBATCHRULE(5) = "��ʷ������"
    
'    CmbiTestStyle.Clear '���鷽ʽ
'    CmbiTestStyle.AddItem "ȫ��"
'    CmbiTestStyle.AddItem "���"
'    CmbiTestStyle.AddItem "�ƻ��Գ��"
'    CmbiTestStyle.AddItem "���ƻ��Գ��"
'    CmbiTestStyle.ListIndex = 0
    Call AddCmbItems(CmbiTestStyle, iTestStyleItems, 0)
    
'    CmbiDTMethod.Clear '��췽��
'    CmbiDTMethod.AddItem "���������"
'    CmbiDTMethod.AddItem "�������"
'    CmbiDTMethod.AddItem "��������"
'    CmbiDTMethod.AddItem "����������"
'    CmbiDTMethod.ListIndex = 0
    Call AddCmbItems(CmbiDTMethod, iDTMethodItems, 0)
    
'    CmbiDTStyle.Clear '�����ϸ��
'    CmbiDTStyle.AddItem "����"
'    CmbiDTStyle.AddItem "����"
'    CmbiDTStyle.AddItem "�ſ�"
'    CmbiDTStyle.ListIndex = -1
    Call AddCmbItems(CmbiDTStyle, iDTStyleItems, -1)
    
    Dim i As Integer
    
'    CmbcMassUnit.Clear
'    For i = 0 To UBound(cMassUnitItems) - 1
'        CmbcMassUnit.AddItem cMassUnitItems(i)
'    Next i
    Call AddCmbItems(CmbcMassUnit, cMassUnitItems, -1)
    
    Call AddCmbItems(cmbiExpiratDateCalcu, iExpiratDateCalcuItems, 0)
'    CmbiDTLevel.Clear
'    For i = 0 To UBound(ciDTLevelItems) - 1
'        CmbiDTLevel.AddItem ciDTLevelItems(i)
'    Next i
'    CmbiDTLevel.ListIndex = -1
    Call AddCmbItems(CmbiDTLevel, ciDTLevelItems, -1)
'    CmbcDTAQL.Clear
'    For i = 0 To UBound(cAQLItems) - 1
'        CmbcDTAQL.AddItem cAQLItems(i)
'    Next i
'    CmbcDTAQL.ListIndex = -1
    Call AddCmbItems(CmbcDTAQL, cAQLItems, -1)
'    CmbiEndDTStyle.Clear
'    For i = 0 To UBound(iEndDTStyleItems) '- 1
'        CmbiEndDTStyle.AddItem iEndDTStyleItems(i)
'    Next i
'    CmbiEndDTStyle.ListIndex = -1
    Call AddCmbItems(CmbiEndDTStyle, iEndDTStyleItems, -1)
    Call AddCmbItems(cmbiTestRule, iTestRuleItems, 0)
    QuaEnable False
    BarCodeEnable False
    Call cDTPeriodEnabled(False)
    If (CS1 And CS2 And CS3 And CS4) = False Then 'And CS5
        Me.Height = Me.ScaleHeight + Screen.TwipsPerPixelY * 30
        Me.LblNote = Replace(g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.3205_1"), Chr(10), "") 'U8.AA.INVENTORY.FRMZAM.3205_1="�����޷����õ���Ŀ���������ײ����Ŀ��ƣ�\n���ȵ�����ϵͳ��ҵ��Χ�����á�"
    End If
    If g_bGSP = True Then
        LbliMassDate = g_oPub.GetResString("U8.AA.INVENTORY.imassdate_gsp") 'U8.AA.INVENTORY.imassdate_gsp="��Ч��"
        LbldWarnDays.Caption = g_oPub.GetResString("U8.AA.INVENTORY.iwarndays_gsp") 'U8.AA.INVENTORY.iwarndays_gsp="��Ч��" '"������"
        ChkbInvQuality.Caption = RemoveOrNot(g_oPub.GetResString("U8.AA.INVENTORY.binvquality_gsp")) ' "�Ƿ���Ч�ڹ���"
        'SSTab1.TabVisible(4) = True
    Else
        LbliMassDate = g_oPub.GetResString("U8.AA.INVENTORY.imassdate") '"������"
        LbldWarnDays.Caption = g_oPub.GetResString("U8.AA.INVENTORY.iwarndays") '"Ԥ������"
        ChkbInvQuality.Caption = RemoveOrNot(g_oPub.GetResString("U8.AA.INVENTORY.binvquality")) '"�Ƿ����ڹ���"
        'SSTab1.TabVisible(4) = False
    End If
End Sub

Private Function RemoveOrNot(sval As String) As String
    sval = Replace(sval, "�Ƿ�", "")
    sval = Replace(sval, "or not", "", , , vbTextCompare)
    sval = Trim(sval)
    RemoveOrNot = sval
End Function

'---------------------------------------
'���ܣ���ʼ���Զ����������
'---------------------------------------
Private Sub InitUserDef()
    Dim Rs As ADODB.Recordset
    Dim tRs As ADODB.Recordset
    Dim strSql As String
    Dim cId As String
    Dim i As Integer, j As Integer
    Dim bShow As Boolean
    bShow = False
    strSql = "select * from userdef where cClass='���'"
    Set Rs = SrvDB.OpenX(strSql)
    Call g_oPub.SetUserDefEle(Rs, m_EleUserDef)
    For i = 0 To LblD1.UBound
        Set tRs = Filter(Rs, "CItem='�Զ�����" + CStr(i + 1) + "'")
        If i < 10 Then
            cId = TxtValue(tRs!cId)
            EdtU(i).AutoDisplayText = False
            EdtU(i).IsUserDefArch = True
            Call EdtU(i).Init(g_oLogin, g_URL + cId, g_bIsWeb)
        End If
        If TxtValue(tRs!cItemName) <> "" Then
            Select Case i
                Case 12
                    Call g_oPub.SetDblLen(EdtU(12), , g_CInvDefine13Dec)
                Case 13
                    Call g_oPub.SetDblLen(EdtU(13), , g_CInvDefine14Dec)
                Case 14, 15
                If TxtValue(tRs!iDataSource, 0) = 1 And TxtValue(tRs!cRelArchive) <> "" And TxtValue(tRs!cRelField) <> "" Then
'                    CmdDate(i - 11).Tag = "ref"
                Else
'                    CmdDate(i - 11).Tag = "date"
                End If
            End Select
            bShow = True
            If TxtValue(tRs!iLength) <> "" Then
                EdtU(i).MaxLength = CInt(tRs!iLength)
                'EdtU(i).Text = TxtValue(tRs!cDefaultVal)
            End If
            LblD1(i).Caption = TxtValue(tRs!cItemName)
            cRelArchive(i) = TxtValue(tRs!cRelArchive)
            cRelField(i) = TxtValue(tRs!cRelField)
        Else
            LblD1(i).Visible = False
            LblD1(i).Tag = "hide"
            EdtU(i).Visible = False
            If i < 14 Then
'                CmdU(i).Visible = False
            ElseIf i = 14 Then
'                CmdDate(3).Visible = False
            ElseIf i = 15 Then
'                CmdDate(4).Visible = False
            End If
        End If
    Next i
    For i = 0 To LblD1.UBound
        'If LblD1(i).Visible = False Then
        If LblD1(i).Tag = "hide" Then '���ڲ���ͨ��visible�ж�
            For j = LblD1.UBound To i + 1 Step -1
                LblD1(j).Left = LblD1(j - 1).Left
                LblD1(j).Top = LblD1(j - 1).Top
                EdtU(j).Left = EdtU(j - 1).Left
                EdtU(j).Top = EdtU(j - 1).Top
                If j < 14 Then
'                    CmdU(j).Left = CmdU(j - 1).Left
'                    CmdU(j).Top = CmdU(j - 1).Top
                ElseIf j = 14 Then
'                    CmdDate(3).Left = CmdU(j - 1).Left
'                    CmdDate(3).Top = CmdU(j - 1).Top
                ElseIf j = 15 Then
'                    CmdDate(4).Left = CmdDate(3).Left
'                    CmdDate(4).Top = CmdDate(3).Top
                End If
            Next j
        End If
    Next i
    
'    For i = 0 To ChkFree.UBound
'        Set tRs = Filter(Rs, "CItem='������" + CStr(i + 1) + "'")
'        If TxtValue(tRs!cItemName) <> "" Then
'            ChkFree(i).Caption = TxtValue(tRs!cItemName)
'            bShow = True
'        Else
'            ChkFree(i).Visible = False
'            For j = ChkFree.UBound To i + 1 Step -1
'                ChkFree(j).Left = ChkFree(j - 1).Left
'                ChkFree(j).Top = ChkFree(j - 1).Top
'            Next j
'        End If
'    Next i
    SSTab1.TabVisible(5) = bShow
    Dim Con(16) As UFLABELLib.UFLabel
    For i = 0 To 15
        Set tRs = Filter(Rs, "CItem='�Զ�����" + CStr(i + 1) + "'")
        If TxtValue(tRs!cItemName) <> "" Then
            If LCase(TxtValue(tRs!bInput)) = "true" Then
                LblD1(i).ForeColor = Labcinvcode.ForeColor
'                Set Con(i) = Me.Controls.Add("UFLABELLib.UFLabel", "LabelHou" + CStr(i), Frame1(5))
'                Con(i).ForeColor = LblMustIn(0).ForeColor
'                Con(i).FontName = LblMustIn(0).FontName
'                Con(i).FontSize = LblMustIn(0).FontSize
'                Con(i).Font.Bold = LblMustIn(0).Font.Bold
'                Con(i).Caption = LblMustIn(0).Caption
'                Con(i).Visible = True
'                Con(i).AutoSize = True
'                Con(i).Top = EdtU(i).Top + 60
'                Con(i).Left = EdtU(i).Left - 100
            End If
        End If
    Next i
    For i = 0 To LblD1.UBound
        LblD1(i).UTooltipText = IIf(g_oPub.GetStrLen(LblD1(i).Caption, "", 0) > 5 * 2, LblD1(i).Caption, "")
    Next i
'    For i = 0 To ChkFree.UBound
'        ChkFree(i).UtooltipText = IIf(g_oPub.GetStrLen(ChkFree(i).Caption, "", 0) > 8 * 2, ChkFree(i).Caption, "")
'    Next i
End Sub

'---------------------------------------
'���ܣ��������ݼ�
'������rstTemp����Ҫ���˵����ݼ�
'     strFilter����������
'---------------------------------------
Private Function Filter(ByVal rstTemp As ADODB.Recordset, strFilter As String) As ADODB.Recordset
    rstTemp.Filter = strFilter
    Set Filter = rstTemp
End Function


'---------------------------------------
'���ܣ���ձ༭���CheckBox��comboBox���
'---------------------------------------
Private Sub Emptyallfields()
    On Error Resume Next '��ֹSetfocus�ȳ���ʱ����Ϊ����ĳ���ֶ�û��Ȩ�ޣ����޷�setfocus��
    m_bFilling = True
    Dim i As Long
    Dim Con As Control
    For Each Con In Controls
        If TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then Con.Value = 0
        If TypeOf Con Is UFCOMBOBOXLib.UFComboBox Then Con.ListIndex = -1
        If TypeOf Con Is Edit Then
            Con.Text = ""
            Con.UTooltipText = ""
            Con.Tag = ""
        ElseIf TypeOf Con Is U8Ref.RefEdit Then
            Con.Clear
        End If
    Next Con
    GridUnit.Rows = 1
    
    'Ĭ��ΪMRP�����δӱ����2003.7.11 ��
'    CmbiPlanPolicy.ListIndex = 1 '��ֵ������CmbiROPMethodҪѡ���CmbiROPMethod��ֵ��ǰ
'    CmbiROPMethod.ListIndex = -1
    'Ĭ�ϣ����ƻ��Գ�죻
    CmbiTestStyle.ListIndex = 3
    CmbiDTMethod.ListIndex = 0
    CmbiDTStyle.ListIndex = -1
    CmbiDTLevel.ListIndex = -1
    CmbcDTAQL.ListIndex = -1
    CmbiEndDTStyle.ListIndex = -1
    cmbiTestRule.ListIndex = -1
    cmbiExpiratDateCalcu.ListIndex = 0
'    CbocFrequency.ListIndex = 1
    Call InvOther1.Emptyallfields
    Call InvFree1.Emptyallfields
    Call InvBatchProperty1.Emptyallfields
    Call InvPlan1.Emptyallfields
    Call InvMPS1.Emptyallfields
    Pic.Emptyallfields
    Call PlubIn_Emptyallfields
    Call InvAttachfile1.Emptyallfields
'    Call NDTSet1.Emptyallfields
'    EdtDModifyDate = CStr(Date)
'    EdtdSDate = CStr(Date)
    Call SetEditAuth(Nothing)
    EdtfInvCIQExch = 1 'Ĭ��Ϊ1�����޸ģ�����С�ڵ���0��
    EdtiTaxRate = g_iTaxRateDefault ' "17"
    EdtiImpTaxRate.Text = g_iImpTaxRateDefault '"17"
'    EdtiExpTaxRate.Text = g_iExpTaxRateDefault ' "0"
    ChkbInByProCheck.Value = Checked '    Ĭ����
    Call g_oPub.FormatCon(EdtfInvCIQExch)
    Call g_oPub.FormatCon(EdtiTaxRate)
    Call g_oPub.FormatCon(EdtiImpTaxRate)
    EdtfPrjMatLimit.Enabled = False
'    Call g_oPub.FormatCon(EdtiExpTaxRate)
'    For i = 0 To ChkFree.UBound
'        ChkFree(i).Value = 0
'    Next i
    Dim Rs As New ADODB.Recordset
    Dim RsTemp As New ADODB.Recordset
    Dim strSql As String
    
    'If m_bFirstLoad = True Then
        strSql = "select top 1 * from computationGroup where bDefaultGroup=1"
        Set Rs = SrvDB.OpenX(strSql)
        If Rs.RecordCount = 1 Then
            m_DefaultGroupCode = TxtValue(Rs.Fields("cGroupCode").Value)
        End If
        If Len(m_DefaultGroupCode) > 0 Then
            EdtcGroupCode.Text = m_DefaultGroupCode
            Call SetGroupCodeChange(Rs)
        End If
    'End If
    
    
    
    strSql = "select  cItem,cDefaultVal  from userdef  where cClass='���' and cDefaultval<>'' and bArchive=0"
    Set Rs = SrvDB.OpenX(strSql)
    For i = 0 To EdtU.UBound
        Set RsTemp = Filter(Rs, "cItem='�Զ�����" + CStr(i + 1) + "'")
        If RsTemp.RecordCount = 1 Then
            EdtU(i).Text = TxtValue(RsTemp!cDefaultVal)
        Else
            EdtU(i).Text = ""
        End If
    Next i
    
    If m_optType = enuNormal Then
        If FrmMain.Trv.Nodes.count > 1 Then '��ֹ���ڵ㳬��32767��ֻ�и��ڵ�
            Dim sCode As String
            For i = FrmMain.Trv.SelectedItem.Index To FrmMain.Trv.Nodes.count
                FrmMain.Trv.Nodes(i).Expanded = True
                If FrmMain.Trv.Nodes(i).children = 0 Then
                    'FrmMain.Trv.Nodes(i).Selected = True '����ĩ��ѡ��
                    sCode = FrmMain.Trv.Nodes(i).Key
                    sCode = Trim(Right(sCode, Len(sCode) - 1))
                    EdtcInvCCode.AutoDisplayText = False
                    EdtcInvCCode.Text = sCode
                    EdtcInvCCode.DisplayText = Replace(FrmMain.Trv.Nodes(i).Text, "(" + sCode + ") ", "")
                    EdtcInvCCode.AutoDisplayText = True
                    If g_oPub.IsClsAuthW(SrvDB, g_rowAuth, "Inventory", EdtcInvCCode.Text, LabcInvCCode.Caption, False) = False Then
                        EdtcInvCCode.Clear
                    End If
                    Exit For
                End If
            Next i
'            If FrmMain.Trv.Nodes.count > 1 Then
'                sCode = FrmMain.Trv.SelectedItem.Key
'                sCode = Trim(Right(sCode, Len(sCode) - 1))
'                EdtcInvCCode.AutoDisplayText = False
'                EdtcInvCCode.Text = sCode
'                EdtcInvCCode.DisplayText = Replace(FrmMain.Trv.SelectedItem.Text, "(" + sCode + ") ", "")
'                EdtcInvCCode.AutoDisplayText = True
'            End If
        End If
'        If EdtcInvCCode <> "" Then
'            strSql = "select top 1 cInvCName from Inventoryclass where cInvCCode='" + EdtcInvCCode.Text + "'"
'            Set Rs = SrvDB.OpenX(strSql)
'            Edtname = TxtValue(Rs!cInvCName)
'        End If
    End If
    Tlb.Buttons("SaveRs").Enabled = False
    Call g_oPub.ReRefreshUFTlb(Me)
    Me.SSTab1.Tab = 0
    UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.addinv"))
    opt = 1
    
'    If EdtdSDate.Locked = False Then '�޸�״̬��Ϊ����״̬���ı�ؼ��״̬
'        EdtdSDate.Enabled = True
'        CmdDate(1).Visible = True
'    End If
'    CmdDate(1).Enabled = EdtdSDate.Enabled
'    tOpt = Opt
    Edtcinvcode.BackColor = EdtcInvName.BackColor
    If m_cInvcodeRW = 2 Then
        Edtcinvcode.Enabled = True
    End If
    If Screen.ActiveForm Is Me Then
        If Edtcinvcode.Enabled = True And Edtcinvcode.Locked = False Then
            Edtcinvcode.SetFocus
        ElseIf EdtcInvName.Enabled = True And EdtcInvName.Locked = False Then
            EdtcInvName.SetFocus
        End If
    End If
    m_bManualChangeCode = False
    m_bFilling = False
    Call SetBillCode
    Call RuleSetConState(1)
End Sub

'------------------------------------------------
'���ܣ���ʼ��һЩĬ�ϲ���
'------------------------------------------------
Private Sub InitDefaultParam()
    If CmbiTestStyle.ListIndex = -1 Then
        CmbiTestStyle.ListIndex = 3
    End If
    If CmbiDTMethod.ListIndex = -1 Then
        CmbiDTMethod.ListIndex = 0
    End If
'    Call InvOther1.Emptyallfields
'    Call InvFree1.Emptyallfields
'    Call InvPlan1.Emptyallfields
    Call InvMPS1.InitDefaultParam
    Pic.Emptyallfields
    If EdtiTaxRate.Text = "" Then
        EdtiTaxRate.Text = "17"
        EdtiImpTaxRate.Text = "17"
'        EdtiExpTaxRate.Text = "0"
        Call g_oPub.FormatCon(EdtiTaxRate)
        Call g_oPub.FormatCon(EdtiImpTaxRate)
'        Call g_oPub.FormatCon(EdtiExpTaxRate)
    End If
End Sub

'-----------------------------------------------
'�����������ֶ����ݵĹ���
'����Ĳ�������
'------------------------------------------------
Private Sub FillAllFields()
    On Error Resume Next
    Dim RsCard As ADODB.Recordset
    
    InitColAuthSet
    Set RsCard = GetRs
    If RsCard Is Nothing Then Exit Sub
    If RsCard.RecordCount = 0 Then
        If FrmMain.Grid.Rows >= 2 Then
            ReDim g_arr(1 To 1)
            g_arr(1) = FrmMain.Grid.TextMatrix(lRow, iCol)
            ShowMsg g_oPub.GetResFormatString("U8.AA.INVENTORY.FRMZAM.3470_1", g_arr) 'U8.AA.INVENTORY.FRMZAM.3470_1="������룺{0}���ܱ���������Աɾ����"
        End If
        FrmMain.DataRefresh
        Exit Sub
    End If
    UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.modifyinv861"))
    opt = 2
    Call FillAllFieldsByRs(RsCard)
    Call RuleSetConState(2)
    SetAddModify "FillAllFields"
    Tlb.Buttons("SaveRs").Enabled = False
End Sub

'-------------------------------------------------------
'���ܣ���д������λ
'-------------------------------------------------------
Private Sub FillUnitRate(cGroupCode As String)
    On Error GoTo Err_Info
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    strSql = "select cComunitCode,cComUnitName,iChangRate from computationUnit where bmainUnit=0 and  cGroupCode='" + cGroupCode + "'"
    Set Rs = SrvDB.OpenX(strSql)
    Dim lCount As Long
    Dim i As Long, j As Integer
    lCount = Rs.RecordCount
    GridUnit.Rows = lCount + 1
    For i = 1 To lCount
        GridUnit.TextMatrix(i, 0) = TxtValue(Rs.Fields(0).Value)
        GridUnit.TextMatrix(i, 1) = TxtValue(Rs.Fields(1).Value)
        GridUnit.TextMatrix(i, 2) = g_oPub.FormatNum(Rs.Fields(2).Value, g_iExchRateDecDgt)
        GridUnit.TextMatrix(i, 3) = GridUnit.TextMatrix(i, 2)
        Rs.MoveNext
    Next i
    If CmbiGroupType.ListIndex = 2 Then
        m_oldExchRate = GridUnit.TextMatrix(1, 2)
    End If
    Exit Sub
Err_Info:
    
End Sub

Private Function WriteUnitRate(ByRef bSaveFlag As Boolean) As String
    bSaveFlag = True
    Dim bUpdateRateOnly As Integer  'ֻ�޸Ļ�����
    Dim bChangeRate As Boolean '�Ƿ�Ĺ�������
    Dim i As Integer
    bUpdateRateOnly = 0
    bChangeRate = False
    For i = 1 To GridUnit.Rows - 1
        If Val(GridUnit.TextMatrix(i, 2)) <> Val(GridUnit.TextMatrix(i, 3)) Then
            bChangeRate = True
            '���޸��˸��������ʣ�ѡ'��'�����ԭ������λ�黻���ʣ�ѡ'��'�򴴽��¼�����λ�飿
            If g_oPub.MsgBox(g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.modify_rate_or_add_group"), vbYesNo + vbExclamation, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then
                bUpdateRateOnly = 1
            End If
            Exit For
        End If
    Next i
    
    Dim sXML As String
    If bChangeRate = True Then
        For i = 1 To GridUnit.Rows - 1
            If Val(GridUnit.TextMatrix(i, 2)) <> Val(GridUnit.TextMatrix(i, 3)) Then
                sXML = sXML + "<ComputationUnit ccomunitcode='" + GridUnit.TextMatrix(i, 0) + "'>"
                sXML = sXML + "<cComUnitCode>" + GridUnit.TextMatrix(i, 0) + "</cComUnitCode>"
                sXML = sXML + "<cComUnitName>" + GridUnit.TextMatrix(i, 1) + "</cComUnitName>"
                sXML = sXML + "<iChangRate>" + GridUnit.TextMatrix(i, 2) + "</iChangRate>"
                sXML = sXML + "<cGroupCode>" + EdtcGroupCode.Text + "</cGroupCode>"
                sXML = sXML + "</ComputationUnit>"
            End If
        Next i
        WriteUnitRate = "<ComputationUnitAll   iexchratedecdgt='" + CStr(g_iExchRateDecDgt) + "' bupdaterateonly='" + CStr(bUpdateRateOnly) + "'>" + sXML + "</ComputationUnitAll>"
    Else
        WriteUnitRate = ""
    End If
End Function


'-------------------------------------------------------
'���ܣ�ͨ���������ݼ�����дEdit��
'-------------------------------------------------------
Private Sub FillAllFieldsByRs(RsCard As ADODB.Recordset, Optional icallType As Integer = 0, Optional objLog As Object)
    On Error Resume Next
    Dim strSql As String
    Dim Rs As ADODB.Recordset
    Dim RsTemp As ADODB.Recordset
    Dim sIndex As String
    Dim sCode As String
    Dim sTemp As String
    Dim i As Integer
    
    m_bFilling = True
    'Emptyallfields '��ֹ��дǰ���ֶ�ʱ���ܺ����ֶο��� '���ֿ��Ʋ���
    '����
    Edtcinvcode = TxtValue(RsCard!cInvCode)
    m_bManualChangeCode = False
    EdtcInvAddCode = TxtValue(RsCard!cInvAddCode)
    EdtcInvName = TxtValue(RsCard!cInvName)
    EdtcInvStd = TxtValue(RsCard!cInvStd)
    EdtcInvCCode.Text = TxtValue(RsCard!cinvccode)
    EdtcCIQCode.Text = TxtValue(RsCard!cCIQCode)
    Call FillEdtcCIQUnitCode(EdtcCIQCode.Text)
    
'    If EdtcInvCCode <> "" Then
'        strSql = "select top 1 cInvCName from Inventoryclass where cInvCCode='" + EdtcInvCCode.Text + "'"
'        Set Rs = SrvDB.OpenX(strSql)
'        Edtname = TxtValue(Rs!cInvCName)
'    Else
'        Edtname = ""
'    End If
    EdtfInvCIQExch.Text = g_oPub.FormatNum(RsCard!fInvCIQExch, g_iQuanDecDgt)
    EdtiTaxRate.Text = g_oPub.FormatNum(RsCard!itaxrate, g_iRateDecDgt)
    EdtiImpTaxRate.Text = g_oPub.FormatNum(RsCard!iImpTaxRate, g_iRateDecDgt)
'    EdtiExpTaxRate.Text = g_oPub.FormatNum(RsCard!iExpTaxRate, g_iRateDecDgt)
    sCode = TxtValue(RsCard!cGroupCode)
    If sCode = "" Then
        EdtcGroupCode = ""
        EdtcComunitCode = ""
        EdtcProductUnit.Text = ""
        EdtcShopUnit.Text = ""
        EdtcPUComunitCode = ""
        EdtcDTUnit.Text = "" '��������ҳǩ�м��������λ
        EdtcSAComunitCode = ""
        EdtcSTComunitCode = ""
        EdtcCAComunitCode = ""
        CmbiGroupType.ListIndex = -1
    Else
        EdtcGroupCode.Text = sCode
        EdtcComunitCode.Text = TxtValue(RsCard!cComunitCode)
        EdtcProductUnit.Text = TxtValue(RsCard!cProductUnit)
        EdtcShopUnit.Text = TxtValue(RsCard!cShopUnit)
        EdtcPUComunitCode.Text = TxtValue(RsCard!cPUComunitCode)
        EdtcDTUnit.Text = TxtValue(RsCard!cDTUnit) '��������ҳǩ�м��������λ
        EdtcSAComunitCode.Text = TxtValue(RsCard!cSAComunitCode)
        EdtcSTComunitCode.Text = TxtValue(RsCard!cSTComunitCode)
        EdtcCAComunitCode.Text = TxtValue(RsCard!cCAComunitCode)
        
        
        sIndex = CStr(TxtValue(RsCard!iGroupType))
        sIndex = IIf((sIndex = "") Or (CInt(sIndex) < 0) Or (CInt(sIndex) > 2), "-1", sIndex)
        CmbiGroupType.ListIndex = CInt(sIndex)
        If CmbiGroupType.ListIndex = 0 Then '�޻���
            Call SetUnitEnable(False)
            EdtcPUComunitCode = ""
            'EdtcDTUnit.Text = "" '��������ҳǩ�м��������λ
            EdtcSAComunitCode = ""
            EdtcSTComunitCode = ""
            EdtcCAComunitCode = ""
            EdtcProductUnit = ""
            EdtcShopUnit.Text = ""
        Else
            Call SetUnitEnable(True)
        End If
    End If
    Call FillUnitRate(sCode)
    
    ChkbInvEntrust = ChkValue(RsCard!bInvEntrust)
    chkbPiece.Value = ChkValue(RsCard!bPiece)
    
    'ChkbFixExch.Value = ChkValue(RsCard!bFixExch)
    ChkbSale = ChkValue(RsCard!bSale)
    chkbExpSale = ChkValue(RsCard!bExpSale)
    ChkbPurchase = ChkValue(RsCard!bPurchase)
    ChkbSelf = ChkValue(RsCard!bSelf)
    ChkbComsume = ChkValue(RsCard!bComsume)
    ChkbProducing = ChkValue(RsCard!bProducing)
    ChkbService = ChkValue(RsCard!bService)
    ChkbAccessary = ChkValue(RsCard!bAccessary)
    chkbBondedInv = ChkValue(RsCard!bBondedInv)
    ChkbInvType.Value = ChkValue(RsCard!bInvType)
    
    'ChkbPromotSales.Value = ChkValue(RsCard!bPromotSales)
    ChkBPropertyCheck.Value = ChkValue(RsCard!BPropertyCheck)
    If g_bGSP = True Then
        ChkBPropertyCheck2.Value = ChkBPropertyCheck.Value
    End If
    
    ChkbPlanInv.Value = ChkValue(RsCard!bPlanInv)
    ChkbProxyForeign.Value = ChkValue(RsCard!bProxyForeign)
    ChkbPTOModel.Value = ChkValue(RsCard!bPTOModel)
    ChkbATOModel.Value = ChkValue(RsCard!bATOModel)
    ChkbInvModel.Value = ChkValue(RsCard!bInvModel)
    ChkbCheckItem.Value = ChkValue(RsCard!bCheckItem)
    chkbSrvItem.Value = ChkValue(RsCard!bSrvItem)
    chkbPrjMat.Value = ChkValue(RsCard!bPrjMat)
    chkbInvAsset.Value = ChkValue(RsCard!bInvAsset)
    chkbSrvProduct.Value = ChkValue(RsCard!bSrvProduct)
    ChkbSrvFittings.Value = ChkValue(RsCard!bSrvFittings)

    ChkbEquipment.Value = ChkValue(RsCard!bEquipment)
    EdtCEnglishName = TxtValue(RsCard.Fields("CEnglishName"))
    EdtcCIQCode.Text = TxtValue(RsCard!cCIQCode)
    
    EdtcEnterprise = TxtValue(RsCard!cEnterprise)
    EdtcAddress = TxtValue(RsCard!cAddress)
    EdtCproduceNation = TxtValue(RsCard.Fields("CproduceNation"))
    EdtcProduceAddress = TxtValue(RsCard.Fields("cProduceAddress"))
    EdtCcurrencyName = TxtValue(RsCard.Fields("CcurrencyName"))
    
    
'    EdtcInvM = TxtValue(RsCard!cInvM_Unit)
'    EdtcInvA = TxtValue(RsCard!cInvA_Unit)
'    EdtiInvExchRate = TxtValue(RsCard!iInvExchRate)
'    If Len(EdtiInvExchRate) > 0 Then
'        EdtiInvExchRate = FormatNum(RsCard!iInvExchRate, g_iExchRateDecDgt)
'    End If
    
    '�ɱ�
    
    Call g_oPub.SetComboBoxText(CbocValueType, TxtValue(RsCard!cValueType), cValueTypeDB, cValueTypeItems) '
'    sTemp = TxtValue(RsCard!cValueType)
'    CbocValueType.ListIndex = -1
'    For i = 0 To CbocValueType.ListCount - 1
'        If CbocValueType.List(i) = sTemp Then
'            CbocValueType.ListIndex = i
'            Exit For
'        End If
'    Next i

    
    EdtfExpensesExch.Text = g_oPub.FormatNum(RsCard!fExpensesExch, g_iDecDgt6) '������
    EdtiInvMPCost.Text = g_oPub.FormatNum(RsCard!iInvMPCost, g_iPriceDecDgt)
    EdtcVenCode.Text = TxtValue(RsCard!cVenCode)
    
    EdtcPurPersonCode.Text = TxtValue(RsCard!cPurPersonCode)
    EdtcDefWareHouse.Text = TxtValue(RsCard!cDefWareHouse)
    
    
    EdtiInvRCost = g_oPub.FormatNum(RsCard!iinvrcost, g_iPriceDecDgt)
    EdtiInvSCost = g_oPub.FormatNum(RsCard!iinvscost, g_iBillPriceDecDgt)
    EdtiInvLSCost = g_oPub.FormatNum(RsCard!iinvlscost, g_iBillPriceDecDgt)
    EdtiInvNCost = g_oPub.FormatNum(RsCard!iinvncost, g_iPriceDecDgt)
    EdtiInvSPrice = g_oPub.FormatNum(RsCard!iinvsprice, g_iPriceDecDgt)
    
    EdtcPriceGroup = TxtValue(RsCard!cPriceGroup)
    EdtcOfferGrade = TxtValue(RsCard!cOfferGrade)
    
    EdtiHighPrice = g_oPub.FormatNum(RsCard!iHighPrice, g_iPriceDecDgt)
    EdtiExpSaleRate = g_oPub.FormatNum(RsCard!iExpSaleRate, 4)
    EdtiOfferRate = g_oPub.FormatNum(RsCard!iOfferRate, 4)
    
'    EdtfBackTaxRate.Text = g_oPub.FormatNum(RsCard!fBackTaxRate, g_iRateDecDgt)
    EdtfRetailPrice.Text = g_oPub.FormatNum(RsCard!fRetailPrice, g_iPriceDecDgt)
    'EdtfExpPrice = g_oPub.FormatNum(RsCard!fExpPrice, g_iPriceDecDgt)
    EdtfCurLLaborCost = g_oPub.FormatNum(RsCard!fCurLLaborCost, g_iPriceDecDgt)
    EdtfCurLVarManuCost = g_oPub.FormatNum(RsCard!fCurLVarManuCost, g_iPriceDecDgt)
    EdtfCurLFixManuCost = g_oPub.FormatNum(RsCard!fCurLFixManuCost, g_iPriceDecDgt)
    EdtfCurLOMCost = g_oPub.FormatNum(RsCard!fCurLOMCost, g_iPriceDecDgt)
    EdtfNextLLaborCost = g_oPub.FormatNum(RsCard!fNextLLaborCost, g_iPriceDecDgt)
    EdtfNextLVarManuCost = g_oPub.FormatNum(RsCard!fNextLVarManuCost, g_iPriceDecDgt)
    EdtfNextLFixManuCost = g_oPub.FormatNum(RsCard!fNextLFixManuCost, g_iPriceDecDgt)
    EdtfNextLOMCost = g_oPub.FormatNum(RsCard!fNextLOMCost, g_iPriceDecDgt)
    
    '����
    sTemp = TxtValue(RsCard!cinvabc)
    Combo1.ListIndex = -1
    For i = 0 To Combo1.ListCount - 1
        If Combo1.List(i) = sTemp Then
            Combo1.ListIndex = i
            Exit For
        End If
    Next i
    
    EdtiSafeNum = g_oPub.FormatNum(RsCard!iSafeNum, g_iQuanDecDgt)
    EdtiTopSum = g_oPub.FormatNum(RsCard!ITopSum, g_iQuanDecDgt)
    EdtiLowSum = g_oPub.FormatNum(RsCard!ILowSum, g_iQuanDecDgt)
    EdtcReplaceItem = TxtValue(RsCard!creplaceitem)
    EdtcPosition.Text = TxtValue(RsCard!cposition)
    
    EdtiOverStock = g_oPub.FormatNum(RsCard!ioverstock, g_iQuanDecDgt) '4λС��
    EdtfInExcess = g_oPub.FormatNum((RsCard!fInExcess), g_iDecDgt6)
    EdtfOutExcess = g_oPub.FormatNum((RsCard!fOutExcess), g_iDecDgt6)
    EdtfBuyExcess = g_oPub.FormatNum(RsCard!fBuyExcess, g_iDecDgt6)
    EdtfPrjMatLimit = g_oPub.FormatNum(RsCard!fPrjMatLimit, g_iDecDgt6)
    EdtiWastage = g_oPub.FormatNum((RsCard!iWastage), g_iDecDgt6)
    
    EdtdLastDate = TxtValue(RsCard!dLastDate)
'    ChkbFixCheck = ChkValue(RsCard!bFixCheck)
'    If ChkbFixCheck.Value = 1 Then
'        FreqEnable True
'        EdtiFrequency = TxtValue(RsCard!iFrequency)
'        CbocFrequency = TxtValue(RsCard!cFrequency)
'        CboiDays = TxtValue()
'    Else
'        FreqEnable False
'        EdtiFrequency = ""
'        CbocFrequency.ListIndex = -1
'        CboiDays.ListIndex = -1
'    End If
    EdtiFrequency = TxtValue(RsCard!iFrequency)
    
    
    Call g_oPub.SetComboBoxText(CbocFrequency, TxtValue(RsCard!cFrequency), cFrequencyDB, cFrequencyItems) '
'    CbocFrequency.ListIndex = -1
'    For i = 0 To CbocFrequency.ListCount - 1
'        If CbocFrequency.List(i) = sTemp Then
'            CbocFrequency.ListIndex = i
'            Exit For
'        End If
'    Next i
    sTemp = TxtValue(RsCard!iDays)
    CboiDays.ListIndex = -1
    For i = 0 To CboiDays.ListCount - 1
        If CboiDays.List(i) = sTemp Then
            CboiDays.ListIndex = i
            Exit For
        End If
    Next i
    ChkbInvBatch.Value = ChkValue(RsCard!bInvBatch) '������д���Ƿ����ڹ�����������ǰ
    m_bInvBatchVal = ChkbInvBatch.Value
    EdtiDrawBatch = TxtValue(RsCard!iDrawBatch)
    Call g_oPub.FormatCon(EdtiDrawBatch)
    ChkbInvQuality.Value = ChkValue(RsCard!binvquality)
    m_bInvQualityVal = ChkbInvQuality.Value
    If ChkbInvQuality.Value = 1 Then
        QuaEnable True
        CmbcMassUnit.ListIndex = TxtValue(RsCard!cMassUnit, -1)
        cmbiExpiratDateCalcu.ListIndex = TxtValue(RsCard!iExpiratDateCalcu, 0)
        EdtiMassDate = TxtValue(RsCard!iMassDate) 'CmbcMassUnit�����ȸ�ֵ
        EdtdWarnDays = TxtValue(RsCard!iWarnDays)
    Else
        QuaEnable False
        EdtiMassDate = ""
        EdtdWarnDays = ""
        cmbiExpiratDateCalcu.ListIndex = 0
    End If
    ChkbBarCode.Value = ChkValue(RsCard!bBarCode)
    If ChkbBarCode.Value = 1 Then
        BarCodeEnable True
        EdtcBarCode = TxtValue(RsCard!CbarCode)
    Else
        BarCodeEnable False
        EdtcBarCode = ""
    End If
    ChkbSerial.Value = ChkValue(RsCard!bSerial)
    
    ChkbTrack.Value = ChkValue(RsCard!bTrack)
    m_bTrackVal = ChkbTrack.Value
    ChkbInvOverStock = ChkValue(RsCard!bInvOverStock)
    ChkbSolitude = ChkValue(RsCard!bSolitude)
    ChkbKCCutMantissa.Value = ChkValue(RsCard!bKCCutMantissa)
    
    EdtfOrderUpLimit.Text = g_oPub.FormatNum(RsCard!fOrderUpLimit, g_iDecDgt6) 'g_iQuanDecDgt
    EdtfInvOutUpLimit.Text = g_oPub.FormatNum(RsCard!fInvOutUpLimit, g_iDecDgt6) 'g_iQuanDecDgt
    EdtfMinSplit.Text = g_oPub.FormatNum(RsCard!fMinSplit, g_iDecDgt6) 'g_iQuanDecDgt
    
    ChkbDTWarnInv.Value = ChkValue(RsCard!bDTWarnInv)
    If g_bGSP = True Then
        ChkbDTWarnInv2.Value = ChkbDTWarnInv.Value
    End If
    
    ChkbPeriodDT.Value = ChkValue(RsCard!bPeriodDT)
    If g_bGSP = True Then
        ChkbPeriodDT2.Value = ChkbPeriodDT.Value
    End If
    
    Call cDTPeriodEnabled(IIf(ChkbPeriodDT.Value = 1, True, False))
    
    EdtcDTPeriod.Text = TxtValue(RsCard!cDTPeriod)
    If g_bGSP = True Then
        EdtcDTPeriod2.Text = EdtcDTPeriod.Text
    End If
    
    '����
    Call InvOther1.FillAllFields(RsCard)
'    EdtiInvWeight = g_oPub.FormatNum((RsCard!iinvweight), g_iQuanDecDgt)
'
'    EdtdSDate = Format(TxtValue(RsCard!dSDate), "yyyy-mm-dd")
'    EdtdEDate = Format(TxtValue(RsCard!dEDate), "yyyy-mm-dd")
'
'    EdtiVolume = g_oPub.FormatNum((RsCard!ivolume), g_iQuanDecDgt)
'
'    EdtcQua = TxtValue(RsCard!cQuality)
'
    Call SetEditAuth(RsCard)
'    EdtDModifyDate = TxtValue(RsCard!dModifyDate)
'    EdtCEnglishName = TxtValue(RsCard.Fields("CEnglishName"))
    
    '�ƻ�
    Call InvPlan1.FillAllFields(RsCard)
    'MPS/MRP
    Call InvMPS1.FillAllFields(RsCard)
    
    '�Զ���/������
    Dim sDef As String
'    For i = 0 To ChkFree.UBound
'        sDef = "bFree" + CStr(i + 1)
'        ChkFree(i) = ChkValue(RsCard.Fields(sDef).Value)
'    Next i
    Call InvFree1.FillAllFieldsEx(RsCard, icallType, objLog)
    Call InvBatchProperty1.FillAllFields(RsCard)
    For i = 0 To EdtU.UBound
        sDef = "cInvDefine" + CStr(i + 1)
        EdtU(i).Clear
        EdtU(i).Text = TxtValue(RsCard.Fields(sDef).Value)
    Next i
    
    EdtU(12) = g_oPub.FormatNum(RsCard.Fields("cInvDefine13").Value, g_CInvDefine13Dec)
    EdtU(13) = g_oPub.FormatNum(RsCard.Fields("cInvDefine14").Value, g_CInvDefine14Dec)
    
    
    'GSPҳ��
    
    
    '����
    CmbiTestStyle.ListIndex = TxtValue(RsCard!iTestStyle, -1)
    CmbiDTMethod.Tag = CStr(CmbiDTMethod.ListIndex) '�Ƿ񼤷�CmbiDTMethod_Click�¼�
    CmbiDTMethod.ListIndex = TxtValue(RsCard!iDTMethod, -1)
    If CStr(CmbiDTMethod.ListIndex) = CmbiDTMethod.Tag Then
        CmbiDTMethod_Click 'ǿ�Ƽ����¼�
    End If
    EdtfDTRate.Text = g_oPub.FormatNum(RsCard!fDTRate, g_iDecDgt6)
    EdtfDTNum.Text = g_oPub.FormatNum(RsCard!fDTNum, g_iQuanDecDgt)
    CmbiDTStyle.ListIndex = TxtValue(RsCard!iDTStyle, -1)
    EdtiQTMethod.Text = TxtValue(RsCard!iQTMethod)
    
    EdtcRuleCode.Text = TxtValue(RsCard!cRuleCode)
    
    CmbiDTLevel.ListIndex = TxtValue(RsCard!iDTLevel, -1)
    sTemp = TxtValue(RsCard!cDTAQL)
    If Len(sTemp) > 0 Then
        CmbcDTAQL.Text = sTemp
    Else
        CmbcDTAQL.ListIndex = -1
    End If
    CmbiEndDTStyle.ListIndex = TxtValue(RsCard!iEndDTStyle, -1)
    cmbiTestRule.ListIndex = TxtValue(RsCard!iTestRule, -1)
    ChkbOutInvDT.Value = ChkValue(RsCard!bOutInvDT)
    ChkbBackInvDT.Value = ChkValue(RsCard!bBackInvDT)
    ChkbReceiptByDT.Value = ChkValue(RsCard!bReceiptByDT)
    chkbInvROHS.Value = ChkValue(RsCard!bInvROHS)
    ChkbInByProCheck.Value = ChkValue(RsCard!bInByProCheck)
'    Call NDTSet1.FillAllFields(RsCard)
    
    
    'ͼƬ
    If icallType = CallType.enuBrowseLog Then
        Set Rs = objLog.GetRecordset("AA_Picture")
        If Not (Rs Is Nothing) Then
            Call Pic.LoadPicture_U8Pic(Rs)
        Else
            Pic.Emptyallfields
        End If
    Else
        sTemp = TxtValue(RsCard!PictureGUID)
        If Len(sTemp) > 0 Then
            strSql = "select top 1 Picture from AA_Picture where cGUID='" + sTemp + "'"
            Set Rs = SrvDB.OpenX(strSql)
            Call Pic.LoadPicture_U8Pic(Rs)
        Else
            Pic.Emptyallfields
        End If
    End If
    '���
    Call PlubIn_FillAllFields(RsCard)
    
    
    '���
    Call PlubIn_FillAllFields(RsCard)
    
    '����
    Call InvAttachfile1.FillAllFields(RsCard)
    m_bFilling = False
    
End Sub

'------------------------------------------
'���ܣ����ñ༭Ȩ��
'------------------------------------------
Private Sub SetEditAuth(RsCard As ADODB.Recordset)
    If FrmMain.m_bEdit = True Then '���й���Ȩ��ʱ����������
        If opt = 1 Or (RsCard Is Nothing) Then
            m_bReadOnly = False
        Else
            m_bReadOnly = Not g_oPub.CheckAuth(g_rowAuth, "Inventory", CStr(TxtValue(RsCard!iId)))
        End If
        If m_bReadOnly = True Then
            UFFrmCaptionMgr.Caption = UFFrmCaptionMgr.Caption + g_oPub.GetResString("U8.AA.GRADEDEF.FRMGRADEDEF.readonly")
        Else
            UFFrmCaptionMgr.Caption = Replace(UFFrmCaptionMgr.Caption, g_oPub.GetResString("U8.AA.GRADEDEF.FRMGRADEDEF.readonly"), "")
        End If
    End If
    Dim bEnabled As Boolean
    bEnabled = Tlb.Buttons("Copy").Enabled
    If m_bReadOnly = True Or FrmMain.m_bEdit = False Then
        Tlb.Buttons("Copy").Enabled = False
    Else
        Tlb.Buttons("Copy").Enabled = True
    End If
    If bEnabled <> Tlb.Buttons("Copy").Enabled Then
        Call g_oPub.ReRefreshUFTlb(Me)
    End If
End Sub

'---------------------------------
'���ܣ���д�в��յ�����
'������ EdtX��   ���տؼ�
'       tableName:���ձ���
'       codeVal:����ֵ
'       codeFld:�����ֶ���
'       nameFld�������ֶ���
'
'---------------------------------
Private Sub SetRefEdt(EdtX As Edit, tableName As String, codeVal As String, codeFld As String, nameFld As String)
    On Error GoTo Err_Info
    If Len(codeVal) > 0 Then
    Dim strSql As String
    Dim tRs As ADODB.Recordset
        strSql = "select top 1 " + nameFld + " from " + tableName + " where " + codeFld + "='" + codeVal + "'"
        Set tRs = SrvDB.OpenX(strSql)
        If tRs.RecordCount = 1 Then
            EdtX.Text = TxtValue(tRs.Fields(nameFld).Value)
            EdtX.Tag = codeVal
            EdtX.UTooltipText = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.codecolon") + codeVal
        End If
    Else
        EdtX.Text = ""
        EdtX.Tag = ""
        EdtX.UTooltipText = ""
    End If
    Exit Sub
Err_Info:
End Sub


'---------------------------------------
'���ܣ����˱������ֶ�ֵ��ΪNull
'������var����Ҫ���˵ı���
'���أ���Ӧ�ı���
'---------------------------------------
Private Function TxtValue(var As Variant, Optional ByVal vDefault As Variant = "") As Variant
    On Error GoTo Err_Info
    TxtValue = IIf(IsNull(var), vDefault, var)
    Exit Function
Err_Info:
    TxtValue = vDefault
End Function

'---------------------------------------
'���ܣ���bool�͵�ֵת��Ϊ����
'������var������
'���أ���var��true������1�����򷵻�0
'---------------------------------------
Private Function ChkValue(var As Variant) As Integer
    On Error Resume Next
    ChkValue = IIf(LCase(var) = True, 1, 0)
End Function

'-------------------------------------------------------
'���ܣ�ж�ش��壬ͬʱ����Ҫ����ļ�¼��Ϣ��ʾ
'-------------------------------------------------------
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    If m_bFilling = True Then
        Cancel = True
        Exit Sub
    End If
    Call g_oPub.isSaveRs(Me, Cancel, UnloadMode)
    Call InvAttachfile1.DeleteAddFile
End Sub

Private Sub Form_Resize()
    Call g_oPub.UFTlbResize(Me)
End Sub

Private Sub Form_Unload(Cancel As Integer)
    On Error Resume Next
    Pic.ClearPicResource
    Dim Plugin As Variant
    For Each Plugin In m_plugins
        Set Plugin.object = Nothing
    Next
'
'    Dim i As Integer
'    For i = (m_plugins.count) To 1 Step -1
'        Call m_plugins.Remove(i)
'    Next i
    Set m_plugins = Nothing
    Call g_oPub.FrmUnLoad
    Set m_ObjRule = Nothing
End Sub

Private Sub Frame1_Click(Index As Integer)
    If ChkBPropertyCheck.Value = 0 Then
        Select Case SSTab1.Tab '����SStab��͸���ʲ���frame1��index
'            Case 6
'                ShowMsg "����ҳǩ��'�Ƿ��ʼ�'û��ѡ�У�GSPҳǩ�����ã�"
            Case 7
                ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.3998_1") 'U8.AA.INVENTORY.FRMZAM.3998_1="����ҳǩ��'�Ƿ��ʼ�'û��ѡ�У�����ҳǩ�����ã�"
            Case Else
        End Select
    End If
End Sub

Private Sub InvOther1_Click()

End Sub

Private Sub InvFree1_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub InvBatchProperty1_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub InvFree1_GetNum(SafeQty As String, MinQty As String, MulQty As String, FixQty As String)
    SafeQty = EdtiSafeNum.Text
    Call InvPlan1.GetNum(FixQty)
    Call InvMPS1.GetNum(MinQty, MulQty)
End Sub

Private Sub InvFree1_GetInvData(sXML As String)
    sXML = "<SafeQty>" + EdtiSafeNum.Text + "</SafeQty>"
    sXML = sXML + "<cInvCode>" & Edtcinvcode.Text & "</cInvCode>"
    sXML = sXML + "<cInvName>" & EdtcInvName.Text & "</cInvName>"
    sXML = sXML + "<cInvStd>" & EdtcInvStd.Text & "</cInvStd>"
    sXML = sXML + "<cInvCCode>" & EdtcInvCCode.Text & "</cInvCCode>"
    sXML = sXML + "<CopycInvCode>" & m_CopycInvCode & "</CopycInvCode>"
    sXML = sXML + InvMPS1.GetMPSData
    sXML = sXML + InvPlan1.GetInvPlanData
End Sub

'Private Sub InvFree1_GetRef(tableName As String, RefFld As String, sCode As String, sName As String, bReturn As Boolean, edt As Object)
'    Call GetRef(RefFld, sCode, sName, bReturn, edt, Me)
'End Sub

Private Sub InvMPS1_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub InvMPS1_GetParentWndData(sXML As String)
    sXML = "<Inventory>"
    sXML = sXML + "<bSelf>" + CStr(ChkbSelf.Value) + "</bSelf>"
    sXML = sXML + "<bATOModel>" + CStr(ChkbATOModel.Value) + "</bATOModel>"
    sXML = sXML + "<bInvModel>" + CStr(ChkbInvModel.Value) + "</bInvModel>"
    sXML = sXML + "</Inventory>"
End Sub
'
'Private Sub InvMPS1_GetRef(tableName As String, RefFld As String, sCode As String, sName As String, bReturn As Boolean, edt As Object, sId As String)
'    Dim Rs As New ADODB.Recordset
'    Call GetRef(RefFld, sCode, sName, bReturn, edt, Me, sId, Rs)
'    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, tableName, Rs)
'End Sub

Private Sub InvMPS1_SetcPlanMethod()
    SetcPlanMethod
    CheckbSelfbROP
End Sub

Private Sub SetcPlanMethod()
    If m_bFilling = True Then Exit Sub
    If InvPlan1.ChkbROPValue = 1 And InvMPS1.CmbcPlanMethodText = "R" Then 'CmbcPlanMethod.Text="R"������ֹ��Ϣѭ��ִ�У����¶�ջ���
        If SSTab1.TabVisible(9) = True Then
            ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.4050_1") 'U8.AA.INVENTORY.FRMZAM.4050_1="��ѡ��ROP������ƻ���������ѡ��'N'��"
        End If
        InvMPS1.CmbcPlanMethodText = "N"
    End If
    '�ʲ����Դ�����ƻ�������MRPҳǩ��ֻ��ѡ��N����Ϊ�ʲ����Դ��������ƻ���
    If chkbInvAsset.Value = Checked And InvMPS1.CmbcPlanMethodText = "R" Then 'CmbcPlanMethod.Text="R"������ֹ��Ϣѭ��ִ�У����¶�ջ���
        InvMPS1.CmbcPlanMethodText = "N"
    End If
End Sub


Private Sub CheckbSelfbROP()
    'ȡ����������д��ROP���������������Ի���Ŀ��� ����ˣ���С�� 2004-09-30
'    On Error Resume Next
'    If m_bFilling = True Then Exit Sub
'    If InvPlan1.ChkbROPValue = 1 And ChkbSelf.Value = 1 Then
'        ShowMsg "���������ԡ��͡�ROP��������!"
'        If Me.ActiveControl Is ChkbSelf Then
'            ChkbSelf.Value = 0
'        Else
'            InvPlan1.ChkbROPValue = 0
'        End If
'    End If
End Sub

Private Sub InvMPS1_SetUserDefVal(UserDefTable As String, Rs As ADODB.Recordset)
    Call g_oPub.SetUserDefVal(Me, m_EleUserDef, UserDefTable, Rs)
End Sub

Private Sub InvOther1_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub InvOther1_EdtKeyPress(fldName As String, KeyAscii As Integer)
    Select Case LCase(fldName)
        Case LCase("nextpage")
            SSTab1.Tab = GetTabVisible(SSTab1.Tab)
            SetEdtFocus
        Case Else
    End Select
End Sub


Private Sub InvPeriod1_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub InvPlan1_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub InvPlan1_EdtKeyPress(fldName As String, KeyAscii As Integer)
    Select Case LCase(fldName)
        Case LCase("nextpage")
            SSTab1.Tab = GetTabVisible(SSTab1.Tab)
            SetEdtFocus
        Case Else
    End Select
End Sub


Private Sub InvPlan1_SetcPlanMethod()
    CheckbSelfbROP
    SetcPlanMethod
End Sub

Private Sub NDTSet1_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub Pic_ActiveSaveBtn()
    Call ActiveSaveBtn
End Sub

Private Sub SSTab1_Click(PreviousTab As Integer) '
'    If Frame1(4).Visible = False Then
'        Frame1(4).Visible = True
'    End If
    Select Case SSTab1.Tab
        Case 0
        Case 1
        Case 2
        Case 3
        Case 4
        Case 5
        Case 6
        Case 7
            '��ֹ������ҳǩ�п��Ե���ƻ�ҳǩ�е�combobox��
'            Frame1(4).Visible = False
    End Select
    
'    On Error Resume Next
'    '�������¼��ʱ��ȫ���̲�����ϵͳ�����У���������ĿΪ��������
'    '����������ҳ��������ɺ󣬰��س�����û�о۽�������ҳ�棬
'    '���Ǿ۽������ص�����ҳ���С�
'    '��ʱ�����Ƿ�����ѡ�ϣ���ƻ�����ͨ���������°�ť��ѡ��ROP
'    Select Case SSTab1.Tab
'        Case 4 '�ƻ�
'        Case Else
'            If Me.ActiveControl.Name = CmbiPlanPolicy.Name Then
'                SSTab1.SetFocus
'            End If
'    End Select
End Sub


'---------------------------------------
'���ܣ�������������ť
'---------------------------------------
Private Sub Tlb_ButtonClick(ByVal Button As MSComctlLib.Button)
    If Operating(Button.Key) = False Then Exit Sub '
    If LCase(Button.Key) <> "exit" Then
        SetAddModify Button.Key
    End If
End Sub

'---------------------------------------
'���ܣ����EdtTag
'������con :edt�ؼ�
'---------------------------------------
Private Sub ClearEdtTag(Con As Control)
    Con.Text = ""
    Con.Tag = ""
    Con.UTooltipText = ""
End Sub

'---------------------------------
'���̹��ܣ���������������ť��Ϣ,������������Ϣ
'---------------------------------
Public Function Operating(ByVal Key As String) As Boolean
    Select Case LCase(Key)
        Case LCase("SaveRs")
            Dim bFlag As Boolean '��־��ӻ��޸��Ƿ�ɹ�
            Dim sMsg As String '������������Ϣ
            bSave = True
            If opt = 1 And g_PermitAddInventory = False Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_add_arch_fun") '����ʹ�����ӱ��浵�����ܣ�
                Exit Function
            ElseIf opt = 2 And g_PermitModifyInventory = False Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_modify_arch_fun") '����ʹ���޸ı��浵�����ܣ�
                Exit Function
            End If
            If bSave = False Then Exit Function
            If CheckNameStd = False Then Exit Function
            'ר�洦�� ���⣺201008230144 zjtҪ��ͨ��ѡ���޸Ĵ����� ȡ������༭�Ĺ���Ȩ��
            If Not g_oPub.ExistSpecialVersionType(SrvDB, 15) Then
                If g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", 2) = True Then
                    Exit Function
                End If
            End If
            Screen.MousePointer = vbHourglass
            'g_oPub.Start
            If opt = 1 Then
                If WriteXML(m_SaveXML, opt) = False Then
                    Screen.MousePointer = vbDefault
                    Exit Function
                End If
                bFlag = SrvDB.Add(m_SaveXML, "Inventory", sMsg)
                'Call InvAttachfile1.DeleteFile
            Else
                If WriteXML(m_SaveXML, opt) = False Then
                    Screen.MousePointer = vbDefault
                    Exit Function
                End If
                bFlag = SrvDB.Modify(m_SaveXML, "Inventory", sMsg)
                
            End If
            'Call g_oPub.WriteTime("SaveInventory")
            
            Call InvAttachfile1.DeleteFile(Edtcinvcode.Text)  'ɾ����ѡ��ĸ���
            
            Screen.MousePointer = vbDefault
            If Not g_oPub.ExistSpecialVersionType(SrvDB, 15) Then
                Call g_oPub.IsLockFun(SrvDB, g_oLogin, "Inventory", -2)
            End If
            If bFlag = False Then
                ShowMsg sMsg
                Operating = False
                Exit Function
            Else
                g_bSaved = True
                If m_optType = enuNormal Then
                    Dim lastCode As String '�ձ���Ĵ������
                    If opt = 1 Then
                        m_bAdd = True
                        lastCode = Edtcinvcode.Text
                    End If
                    If Len(m_CopycInvCode) = 0 Then
                        Emptyallfields
                    Else
                        Dim Rs As ADODB.Recordset
                        Dim strSql As String
                        strSql = "select top 1 * from Inventory left join Inventory_Sub ON cinvcode=cInvSubCode where cInvcode='" + m_CopycInvCode + "'"
                        Set Rs = SrvDB.OpenX(strSql)
                        If Rs.RecordCount = 1 Then
                            Call FillAllFieldsByRs(Rs)
                        End If
                        Call Operating("copy")
                    End If
                    If m_bCreateBillNum = False Then '�����������
                        Edtcinvcode.Text = g_oPub.GetAutoCode(lastCode)
                    End If
                    SSTab1.Tab = 0
                Else
                    Me.Tlb.Buttons(1).Enabled = False '��ֹ�رմ�����ѯ�Ƿ񱣴�,��ʱ�ѱ������
                    Unload Me
                End If
            End If
        Case "copy"
            On Error Resume Next '˫��һ��������������Ϣ��û�д�������Ƭʱ������ƣ�������ʱ����
            m_CopycInvCode = Edtcinvcode.Text
            '�±�6�ֳ��ͻ�ά�������������������������ʱ���Խ�������롢������ơ�������븴�Ƶ�����������档
            If Not g_oPub.ExistSpecialVersionType(SrvDB, 4) Then
                EdtcInvAddCode = ""
                Edtcinvcode = ""
                EdtcInvName = ""
            End If
            Call InvFree1.CopyOpera
            Call InvOther1.CopyOpera
            Me.SSTab1.Tab = 0
            If m_cInvcodeRW = 2 Then
                Edtcinvcode.Enabled = True
            End If
            If Screen.ActiveForm Is Me Then
                If Edtcinvcode.Enabled = True And Edtcinvcode.Locked = False Then
                    Edtcinvcode.SetFocus
                ElseIf EdtcInvName.Enabled = True And EdtcInvName.Locked = False Then
                    EdtcInvName.SetFocus
                End If
            End If
            opt = 1
            Call RuleSetConState(1)
            Call SetBillCode
            Call SetEditAuth(Nothing)
        Case LCase("First")
            If g_oPub.isSaveRs(Me) = False Then Exit Function
            If Tlb.Buttons("First").Enabled = False Or Tlb.Buttons("First").Visible = False Then Exit Function
            lRow = 1
            FillAllFields
            m_CopycInvCode = ""
        Case LCase("Previous")
            If g_oPub.isSaveRs(Me) = False Then Exit Function
            If Tlb.Buttons("Previous").Enabled = False Or Tlb.Buttons("Previous").Visible = False Then Exit Function
            lRow = lRow - 1
            lRow = IIf(lRow = 0, 1, lRow)
            FillAllFields
            m_CopycInvCode = ""
        Case LCase("Next")
            If g_oPub.isSaveRs(Me) = False Then Exit Function
            If Tlb.Buttons("Next").Enabled = False Or Tlb.Buttons("Next").Visible = False Then Exit Function
            lRow = lRow + 1
            If lRow > FrmMain.Grid.Rows - 1 Then
                lRow = FrmMain.Grid.Rows - 1
            End If
            FillAllFields
            m_CopycInvCode = ""
        Case LCase("Last")
            If g_oPub.isSaveRs(Me) = False Then Exit Function
            If Tlb.Buttons("Last").Enabled = False Or Tlb.Buttons("Last").Visible = False Then Exit Function
            lRow = FrmMain.Grid.Rows - 1
            FillAllFields
            m_CopycInvCode = ""
        Case "exit"
            If m_bFilling = False Then
                Unload Me
                Operating = True
                Exit Function
            End If
        Case LCase("ClearField")
            UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.addinv"))  'LoadResString(2002)
            Emptyallfields
        Case Else
            Debug.Print "No Button Match!Check it Please!"
    End Select
    If g_bSaved = True Then '�Ը����ӵļ�¼ˢ��
        If (m_bAdd = True) And (LCase(Key) = LCase("First") Or LCase(Key) = LCase("Previous") Or LCase(Key) = LCase("Next") Or LCase(Key) = LCase("Last")) Then
            FrmMain.DataRefresh
            m_bAdd = False
            If FrmMain.Grid.Rows = 2 Then
                Tlb.Buttons("First").Enabled = True
                Tlb.Buttons("Previous").Enabled = True
            End If
            'tOpt = Opt
        End If
    End If
    Operating = True
    Call g_oPub.ReRefreshUFTlb(Me)
End Function


Private Sub SetBillCode()
    If m_SetingBillCode = True Then Exit Sub
    If opt <> 1 Then Exit Sub
    If m_bFilling = True Then Exit Sub
    If m_bCreateBillNum = False Then Exit Sub
    If m_bManualChangeCode = True And Len(Edtcinvcode.Text) > 0 Then Exit Sub
    m_SetingBillCode = True
    Call g_oPub.CheckValid(Me.ActiveControl)
    Dim sXML As String
    sXML = "<Inventory>"
    sXML = sXML + "<cinvname>" + EdtcInvName.Text + "</cinvname>"
    sXML = sXML + "<cinvaddcode>" + EdtcInvAddCode.Text + "</cinvaddcode>"
    sXML = sXML + "<cinvstd>" + EdtcInvStd.Text + "</cinvstd>"
    sXML = sXML + "<cinvccode>" + EdtcInvCCode.Text + "</cinvccode>"
    sXML = sXML + "<cgroupcode>" + EdtcGroupCode.Text + "</cgroupcode>"
    sXML = sXML + "<cdefwarehouse>" + EdtcDefWareHouse.Text + "</cdefwarehouse>"
    sXML = sXML + "<dmodifydate>" + g_oPub.GetSrvTime(SrvDB) + "</dmodifydate>" 'CStr(g_oLogin.CurDate)
    sXML = sXML + "<cmodifyperson>" + g_oLogin.cUserName + "</cmodifyperson>" '���ݱ��ʹ�ò���Ա���ƣ�Ȼ����ת��
    sXML = sXML + "</Inventory>"
    Edtcinvcode.Text = g_oPub.GetBillNumber(SrvDB, m_billFormat, sXML, "Inventory", "cInvcode", Edtcinvcode.Text, False)
    m_bManualChangeCode = False
    m_SetingBillCode = False
End Sub


'---------------------------------------
'���ܣ���������ƺ͹���ͺ��Ƿ��ظ�
'---------------------------------------
Private Function CheckNameStd() As Boolean
    Dim Rs As New ADODB.Recordset
    Dim strSql As String
    
    CheckNameStd = False
    If Edtcinvcode.Text = "" Then   '�����������
        Call SetBillCode
    End If
    
    If Edtcinvcode = "" Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cinvcode_notnull") '"������벻��Ϊ�գ�"
        Exit Function
    End If
    If m_bRule = True Then
        If RuleMethod(Me, g_oLogin, Edtcinvcode.Name, "LostFocus") = False Then Exit Function
    End If
    
    If EdtcInvName = "" Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cinvname_notnull") '"������Ʋ���Ϊ�գ�"
        Exit Function
    End If
    
    Dim cInvStdSql As String
    If Trim(EdtcInvStd.Text) <> "" Then
        cInvStdSql = "cInvStd='" + EdtcInvStd + "'"
    Else
        cInvStdSql = "(cInvStd='' or cInvStd is null)"
    End If
    Select Case opt
         Case 1
            strSql = "select top 1 cInvName,cInvStd from Inventory where " + cInvStdSql + _
                " and cInvName='" + EdtcInvName + "'"
        Case 2
            strSql = "select top 1 cInvName,cInvStd from Inventory where " + cInvStdSql + _
                " and cInvName='" + EdtcInvName + "' and cInvCode<>'" + Edtcinvcode.Text + "'"
    End Select
    Set Rs = SrvDB.OpenX(strSql)
    If Rs.RecordCount = 1 Then
        If g_oPub.MsgBox(g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.4399_1"), vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbNo Then 'U8.AA.INVENTORY.FRMZAM.4399_1="���ݿ��м���������ͬ�Ĵ�����ƺ͹���ͺţ�\n�����Ƿ񱣴浱ǰ���������"
            Exit Function
        End If
    End If
    
    
    CheckNameStd = True
End Function

'----------------------------------
'���̹��ܣ�����ǰ��ť����ʾ�޸ģ���������������ʾ���
'------------------------------------
Private Sub SetAddModify(ByVal Key As String)
    Select Case LCase(Key)
        Case "copy"
            If m_cInvcodeRW = 2 Then
                Edtcinvcode.Enabled = True
            End If
            UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.addinv"))  'LoadResString(2002)
            opt = 1 '��ʾ���
        Case LCase("FillAllFields"), "first", "previous", "next", "last"
            If Tlb.Buttons("SaveRs").Enabled = False Then '���Ӵ��������δ���������ƣ��㷭�水ť��ϵͳ��ʾ������Ʋ���Ϊ�գ����������ƣ��㱣�棬ϵͳ��ʾ�����޸ĵļ�¼���ܱ�ɾ����
                opt = 2 '��ʾ�޸�
                Edtcinvcode.Enabled = False
                If m_bReadOnly = False Then
                    UFFrmCaptionMgr.Caption = IIf(FrmMain.m_ReadOnlyCaption <> "", FrmMain.m_ReadOnlyCaption, g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.modifyinv861")) 'LoadResString(2003)
                End If
            End If
    End Select
End Sub



'------------------------------------------
'�������ܸ�ʽ������
'------------------------------------------
Private Function FormatNum(num As Double, Numpoint As Integer) As String
    If Len(CStr(num)) = 0 Then
        FormatNum = ""
    ElseIf Numpoint <= 0 Then
        FormatNum = Format(num, "##############0")
    Else
        FormatNum = Format(num, "0." & String(Numpoint, "0"))
    End If
End Function

'---------------------------------------
'���ܣ���д�����ӡ��޸ĵ�XMl��ʽ�ַ���
'������sXML���õ�XML��ʽ�ַ���
'      Opt���������ͣ�1����ӣ�2���޸�
'---------------------------------------
Private Function WriteXML(ByRef sXML As String, opt As Integer) As Boolean
    WriteXML = False
    Dim bSaveFlag As Boolean
    Dim i As Integer
    bSaveFlag = True
    Call g_oPub.CheckValid(Me.ActiveControl)
    If g_AutoCreatecInvAddCode = True And Len(EdtcInvAddCode.Text) = 0 Then
        Call EdtcInvName_LostFocus
    End If
    sXML = "<Inventory bCreateBillNum='" + IIf(m_bCreateBillNum, "1", "0") + "' bManualChangeCode='" + IIf(m_bManualChangeCode, "1", "0") + "' CopycInvCode='" + m_CopycInvCode + "'>"
    '����
    sXML = sXML + "<cInvCode>" + Edtcinvcode + "</cInvCode>" '<!-- �������,����Ϊ�� -->
    FrmMain.m_CodeVal = Edtcinvcode.Text
    sXML = sXML + "<cInvAddCode>" + EdtcInvAddCode + "</cInvAddCode>" '<!-- ������� -->
    sXML = sXML + "<cInvName>" + EdtcInvName + "</cInvName>" '<!-- �������,����Ϊ�� -->"
    sXML = sXML + "<cInvStd>" + EdtcInvStd + "</cInvStd>" '<!-- ����ͺ� -->"
    sXML = sXML + "<cInvCCode>" + EdtcInvCCode + "</cInvCCode>" '<!-- ���������� -->"
    sXML = sXML + "<cCIQCode>" + EdtcCIQCode + "</cCIQCode>"
    sXML = sXML + "<fInvCIQExch>" + EdtfInvCIQExch + "</fInvCIQExch>"
    sXML = sXML + "<iTaxRate>" + EdtiTaxRate + "</iTaxRate>"  '<!-- ˰��,����Ϊ�� -->"
    sXML = sXML + "<iImpTaxRate>" + EdtiImpTaxRate + "</iImpTaxRate>"
'    sXml = sXml + "<iExpTaxRate>" + EdtiExpTaxRate + "</iExpTaxRate>"
    sXML = sXML + "<cGroupCode>" + EdtcGroupCode.Text + "</cGroupCode>"
    Call EleXML(sXML, "bInvEntrust", ChkbInvEntrust)
    Call EleXML(sXML, "bPiece", chkbPiece)
    
    'Call EleXML(sXML, "bFixExch", ChkbFixExch)
    'sXml = sXml + "<bFixExch>" + CStr(ChkbFixExch.Value) + "</bFixExch>"
    Call EleXML(sXML, "bSale", ChkbSale)
    Call EleXML(sXML, "bExpSale", chkbExpSale)
    Call EleXML(sXML, "bPurchase", ChkbPurchase)
    Call EleXML(sXML, "bSelf", ChkbSelf)
    Call EleXML(sXML, "bComsume", ChkbComsume)
    Call EleXML(sXML, "bProducing", ChkbProducing)
    Call EleXML(sXML, "bService", ChkbService)
    Call EleXML(sXML, "bAccessary", ChkbAccessary)
    Call EleXML(sXML, "bBondedInv", chkbBondedInv)
    Call EleXML(sXML, "bInvType", ChkbInvType)
    sXML = sXML + "<cComunitCode>" + EdtcComunitCode.Text + "</cComunitCode>"
    sXML = sXML + "<cPUComunitCode>" + EdtcPUComunitCode.Text + "</cPUComunitCode>"
    'sXml = sXml + "<cDTUnit>" + EdtcDTUnit.text + "</cDTUnit>" '��������ҳǩ�м��������λ
    sXML = sXML + "<cSAComunitCode>" + EdtcSAComunitCode.Text + "</cSAComunitCode>"
    sXML = sXML + "<cSTComunitCode>" + EdtcSTComunitCode.Text + "</cSTComunitCode>"
    sXML = sXML + "<cCAComunitCode>" + EdtcCAComunitCode.Text + "</cCAComunitCode>"
    sXML = sXML + "<iGroupType>" + CStr(CmbiGroupType.ListIndex) + "</iGroupType>"
    
    'Call EleXML(sXml, "bPromotSales", ChkbPromotSales)
    sXML = sXML + "<cProductUnit>" + EdtcProductUnit.Text + "</cProductUnit>"
    sXML = sXML + "<cShopUnit>" + EdtcShopUnit.Text + "</cShopUnit>"
    Call EleXML(sXML, "bPlanInv", ChkbPlanInv)
    Call EleXML(sXML, "bCheckItem", ChkbCheckItem)
    Call EleXML(sXML, "bSrvItem", chkbSrvItem)
    Call EleXML(sXML, "bPrjMat", chkbPrjMat)
    Call EleXML(sXML, "bInvAsset", chkbInvAsset)
    Call EleXML(sXML, "bSrvProduct", chkbSrvProduct)
    Call EleXML(sXML, "bSrvFittings", ChkbSrvFittings)
    Call EleXML(sXML, "bATOModel", ChkbATOModel)
    Call EleXML(sXML, "bProxyForeign", ChkbProxyForeign)
    Call EleXML(sXML, "bPTOModel", ChkbPTOModel)
    Call EleXML(sXML, "bInvModel", ChkbInvModel)
    Call EleXML(sXML, "bEquipment", ChkbEquipment)
    Call EleXML(sXML, "CEnglishName", EdtCEnglishName)
    Call EleXML(sXML, "cCIQCode", EdtcCIQCode)
    Call EleXML(sXML, "cEnterprise", EdtcEnterprise)
    Call EleXML(sXML, "cAddress", EdtcAddress)
    Call EleXML(sXML, "CproduceNation", EdtCproduceNation)
    Call EleXML(sXML, "cProduceAddress", EdtcProduceAddress)
    Call EleXML(sXML, "CcurrencyName", EdtCcurrencyName)
    
    '�ɱ�
    sXML = sXML + "<cValueType>" + GetCmbDB(CbocValueType, cValueTypeDB) + "</cValueType>"
    Call EleXML(sXML, "fExpensesExch", EdtfExpensesExch)
    Call EleXML(sXML, "iInvMPCost", EdtiInvMPCost)
    sXML = sXML + "<cvencode>" + EdtcVenCode.Text + "</cvencode>" '<!-- ��Ҫ������λ -->"
    sXML = sXML + "<cPurPersonCode>" + EdtcPurPersonCode.Text + "</cPurPersonCode>"
    Call EleXML(sXML, "iinvrcost", EdtiInvRCost)
    Call EleXML(sXML, "iinvscost", EdtiInvSCost)
    Call EleXML(sXML, "iinvlscost", EdtiInvLSCost)
    Call EleXML(sXML, "iinvncost", EdtiInvNCost)
    Call EleXML(sXML, "iinvsprice", EdtiInvSPrice)
    sXML = sXML + "<cDefWareHouse>" + EdtcDefWareHouse.Text + "</cDefWareHouse>"
    Call EleXML(sXML, "iHighPrice", EdtiHighPrice)
    Call EleXML(sXML, "iExpSaleRate", EdtiExpSaleRate)
    Call EleXML(sXML, "cPriceGroup", EdtcPriceGroup)
    Call EleXML(sXML, "cOfferGrade", EdtcOfferGrade)
    Call EleXML(sXML, "iOfferRate", EdtiOfferRate)
    'Call EleXML(sXml, "fExpPrice", EdtfExpPrice)
'    Call EleXML(sXml, "fBackTaxRate", EdtfBackTaxRate)
    Call EleXML(sXML, "fRetailPrice", EdtfRetailPrice)
    Call EleXML(sXML, "fCurLLaborCost", EdtfCurLLaborCost)
    Call EleXML(sXML, "fCurLVarManuCost", EdtfCurLVarManuCost)
    Call EleXML(sXML, "fCurLFixManuCost", EdtfCurLFixManuCost)
    Call EleXML(sXML, "fCurLOMCost", EdtfCurLOMCost)
    Call EleXML(sXML, "fNextLLaborCost", EdtfNextLLaborCost)
    Call EleXML(sXML, "fNextLVarManuCost", EdtfNextLVarManuCost)
    Call EleXML(sXML, "fNextLFixManuCost", EdtfNextLFixManuCost)
    Call EleXML(sXML, "fNextLOMCost", EdtfNextLOMCost)
    
    '����
    Call EleXML(sXML, "cinvabc", Combo1)
    Call EleXML(sXML, "isafenum", EdtiSafeNum)
    Call EleXML(sXML, "itopsum", EdtiTopSum)
    Call EleXML(sXML, "ilowsum", EdtiLowSum)
    Call EleXML(sXML, "creplaceitem", EdtcReplaceItem)
    sXML = sXML + "<cposition>" + EdtcPosition.Text + "</cposition>"
    Call EleXML(sXML, "ioverstock", EdtiOverStock)
    Call EleXML(sXML, "fInExcess", EdtfInExcess)
    Call EleXML(sXML, "fOutExcess", EdtfOutExcess)
    Call EleXML(sXML, "fBuyExcess", EdtfBuyExcess)
    Call EleXML(sXML, "fPrjMatLimit", EdtfPrjMatLimit)
    Call EleXML(sXML, "iWastage", EdtiWastage)
    Call EleXML(sXML, "dLastDate", EdtdLastDate)
'    Call EleXML(sXML, "bFixCheck", ChkbFixCheck)
    Call EleXML(sXML, "iFrequency", EdtiFrequency)
    Call EleXML(sXML, "iDrawBatch", EdtiDrawBatch)
    
    
    sXML = sXML + "<cFrequency>" + GetCmbDB(CbocFrequency, cFrequencyDB) + "</cFrequency>"
    Call EleXML(sXML, "iDays", CboiDays)
    Call EleXML(sXML, "bInvQuality", ChkbInvQuality)
    sXML = sXML + "<iMassDate>" + EdtiMassDate + "</iMassDate>"
    sXML = sXML + "<iWarnDays>" + EdtdWarnDays + "</iWarnDays>"
    Call EleXML(sXML, "bBarCode", ChkbBarCode)
    Call EleXML(sXML, "cBarCode", EdtcBarCode)
    Call EleXML(sXML, "bSerial", ChkbSerial)
    Call EleXML(sXML, "bInvBatch", ChkbInvBatch)
    Call EleXML(sXML, "bTrack", ChkbTrack)
    Call EleXML(sXML, "bInvOverStock", ChkbInvOverStock)
    Call EleXML(sXML, "bSolitude", ChkbSolitude)
    Call EleXML(sXML, "bKCCutMantissa", ChkbKCCutMantissa)
    '---------------------------------
    '2010-1-12
    '����ţ�200912150180 '���ڣ�����GSPʱ,����ҳǩ�ֶ�,�����ڴ������,���ڼ���,�������ڷŵ�����ҳǩ.
    If g_bGSP = True Then
        Call EleXML(sXML, "BPropertyCheck", ChkBPropertyCheck2)
    Else
        Call EleXML(sXML, "BPropertyCheck", ChkBPropertyCheck)
    End If
    
    If g_bGSP = True Then
        Call EleXML(sXML, "bPeriodDT", ChkbPeriodDT2)
    Else
        Call EleXML(sXML, "bPeriodDT", ChkbPeriodDT)
    End If
    
    If g_bGSP = True Then
        sXML = sXML + "<cDTPeriod>" + EdtcDTPeriod2.Text + "</cDTPeriod>"
    Else
        sXML = sXML + "<cDTPeriod>" + EdtcDTPeriod.Text + "</cDTPeriod>"
    End If
    
    If g_bGSP = True Then
        Call EleXML(sXML, "bDTWarnInv", ChkbDTWarnInv2)
    Else
        Call EleXML(sXML, "bDTWarnInv", ChkbDTWarnInv)
    End If
    '---------------------------------
    
    Call EleXML(sXML, "fOrderUpLimit", EdtfOrderUpLimit)
    Call EleXML(sXML, "fInvOutUpLimit", EdtfInvOutUpLimit)
    Call EleXML(sXML, "fMinSplit", EdtfMinSplit)
    If CmbcMassUnit.ListIndex = -1 Then
        sXML = sXML + "<cMassUnit>0</cMassUnit>"
    Else
        sXML = sXML + "<cMassUnit>" + CStr(CmbcMassUnit.ListIndex) + "</cMassUnit>"
    End If
    sXML = sXML + "<iExpiratDateCalcu>" + CStr(cmbiExpiratDateCalcu.ListIndex) + "</iExpiratDateCalcu>"
    
    
    
    '����
    sXML = sXML + InvOther1.GetSaveXml()
    '�ƻ�
    sXML = sXML + InvPlan1.GetSaveXml()
    'MSP/MRP
    sXML = sXML + InvMPS1.GetSaveXml()
    'GSPҳ��
    'If g_bGSP = True Then
       
        
    'End If
    Dim srvTime As String
    srvTime = g_oPub.GetSrvTime(SrvDB)
    If opt = 1 Then
        sXML = sXML + "<CCreatePerson>" + g_cUserName + "</CCreatePerson>" 'Edt(34)
        sXML = sXML + "<dInvCreateDatetime>" + srvTime + "</dInvCreateDatetime>" 'Edt(34)
    End If
    sXML = sXML + "<cModifyPerson>" + g_cUserName + "</cModifyPerson>" 'Edt(36)
    sXML = sXML + "<dModifyDate>" + srvTime + "</dModifyDate>"
    
    '�Զ���/������
    For i = 1 To EdtU.UBound + 1
        Call EleXML(sXML, "CInvDefine" + CStr(i), EdtU(i - 1))
    Next i
'    For i = 1 To ChkFree.UBound + 1
'        Call EleXML(sXml, "bFree" + CStr(i), ChkFree(i - 1))
'    Next i
    sXML = sXML + InvFree1.GetSaveXml(bSaveFlag)
    If bSaveFlag = False Then GoTo ExitNormal
    sXML = sXML + InvBatchProperty1.GetSaveXml()
    sXML = sXML + "<cUserId>" + g_cUserId + "</cUserId>"
    
    '����
    sXML = sXML + "<iTestStyle>" + CStr(CmbiTestStyle.ListIndex) + "</iTestStyle>"
    sXML = sXML + "<iDTMethod>" + CStr(CmbiDTMethod.ListIndex) + "</iDTMethod>"
    Call EleXML(sXML, "fDTRate", EdtfDTRate)
    Call EleXML(sXML, "fDTNum", EdtfDTNum)
    sXML = sXML + "<iDTStyle>" + CStr(CmbiDTStyle.ListIndex) + "</iDTStyle>"
    sXML = sXML + "<cDTUnit>" + EdtcDTUnit.Text + "</cDTUnit>"
    sXML = sXML + "<iQTMethod>" + EdtiQTMethod.Text + "</iQTMethod>"
    sXML = sXML + "<cRuleCode>" + EdtcRuleCode.Text + "</cRuleCode>"
    sXML = sXML + "<iDTLevel>" + CStr(CmbiDTLevel.ListIndex) + "</iDTLevel>"
    sXML = sXML + "<cDTAQL>" + CmbcDTAQL.Text + "</cDTAQL>"
    sXML = sXML + "<iEndDTStyle>" + CStr(CmbiEndDTStyle.ListIndex) + "</iEndDTStyle>"
    sXML = sXML + "<iTestRule>" + CStr(cmbiTestRule.ListIndex) + "</iTestRule>"
    sXML = sXML + "<bOutInvDT>" + CStr(ChkbOutInvDT.Value) + "</bOutInvDT>"
    Call EleXML(sXML, "bBackInvDT", ChkbBackInvDT)
    Call EleXML(sXML, "bReceiptByDT", ChkbReceiptByDT)
    Call EleXML(sXML, "bInvROHS", chkbInvROHS)
    Call EleXML(sXML, "bInByProCheck", ChkbInByProCheck)
    'ͼƬ
    Dim picData As String
    If Pic.GetPicture(g_bIsWeb, picData) = False Then
        bSaveFlag = False
    End If
    If Pic.BSaveData = True Then
        sXML = sXML + "<PictureGUID bXML='" + CStr(g_bIsWeb) + "'>" + picData + "</PictureGUID>"
        sXML = sXML + "<cPictureType >" + Pic.PictureType + "</cPictureType>"
    End If
    
    '���
    If bSaveFlag = True Then
        sXML = sXML + PlubIn_GetSaveXml(bSaveFlag)
    End If
    
    sXML = sXML + InvAttachfile1.GetSaveXml()
    If bSaveFlag = True Then
        sXML = sXML + WriteUnitRate(bSaveFlag)
    End If
'    sXml = sXml + NDTSet1.GetSaveXml(bSaveFlag)
    sXML = sXML + "</Inventory>"
ExitNormal:
    WriteXML = bSaveFlag
End Function


'---------------------------------------
'���ܣ���CheckBox,Edit���дXML
'������sXML:�ַ�������
'      Con:CheckBox,Edit��ؼ�
'---------------------------------------
Private Sub EleXML(ByRef sXML As String, sAttr As String, Con As Control)
    Dim sText As String
    'If (Con.Visible = True) Then '(Con.Enabled = True) And,��ֹ�ؼ�����¡������
        If TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then
            sText = CStr(Con.Value)
        ElseIf (Left(LCase(Con.Name), 3) = "edt") Or (TypeOf Con Is UFCOMBOBOXLib.UFComboBox) Then ' Or (TypeOf Con Is MaskEdBox)
            sText = Con.Text
        Else
            ShowMsg Con.Name + " can't get the Text"
        End If
        sXML = sXML + "<" + sAttr + ">" + sText + "</" + sAttr + ">"
    'End If
End Sub

'------------------------------------------------
'��ȡcombox�����ݿⱣ������
'------------------------------------------------
Private Function GetCmbDB(Cmb As UFCOMBOBOXLib.UFComboBox, arr() As String) As String
    On Error GoTo Err_Info
    GetCmbDB = arr(Cmb.ListIndex)
    Exit Function
Err_Info:
    GetCmbDB = ""
End Function


'----------------------------------------
'���ܣ�����水ť
'----------------------------------------
Public Sub ActiveSaveBtn()
    If FrmMain.m_bEdit = False Then Exit Sub
    If opt = 2 And m_bReadOnly = True Then Exit Sub
    If m_bFilling = True Then Exit Sub
    Tlb.Buttons("SaveRs").Enabled = True
    Call g_oPub.ReRefreshUFTlb(Me)
End Sub

'-----------------------------------------------
'���ܣ����á��Ƿ��ʼ족����
'-----------------------------------------------
Private Sub SetPropertyCheck()
    Dim bFlag As Boolean
    bFlag = IIf(ChkBPropertyCheck.Value = 0, False, True)
    'Frame1(6).Enabled = bFlag
    Frame1(7).Enabled = bFlag
    'Call SetEnabledByParent(bFlag, Frame1(6))
    Call SetEnabledByParent(bFlag, Frame1(7))
    'Call TransQualityCon(bFlag)
'''    Cmd(4).Enabled = EdtcEnterprise.Enabled
    ' �ɡ��񡱸�Ϊ���ǡ�����ʱ�����޸ġ���Ϊ���ǡ�����Ӧ������ҳǩ�е�������ȡ��Ĭ��ֵ(���������ʱ��ͬ)
    '(hyb:�������ݣ��򲻱䣺����CmbiTestStyle.ListIndex = -1 �ű�)
    If bFlag = True And CmbiTestStyle.ListIndex = -1 Then
        CmbiTestStyle.ListIndex = 3
        CmbiDTMethod.ListIndex = 0
    End If
    If bFlag = True Then
        CmbiDTMethod_Click '���߲��ɵߵ�˳��
        CmbiTestStyle_Click
    End If
    If EdtcPUComunitCode.Enabled = False Then
        EdtcDTUnit.Enabled = False
    End If
''    Cmd(11).Enabled = EdtcDTUnit.Enabled
''    Cmd(12).Enabled = EdtiQTMethod.Enabled
End Sub

'-----------------------------------------------
'���ڿؼ��滻�������������⴦��Combox�ؼ���Enabled
'-----------------------------------------------
Private Sub TransQualityCon(bFlag As Boolean)
    If bFlag = True Then
        Call SetAuthCon(CmbiDTMethod, bFlag)
        Call SetAuthCon(CmbiDTStyle, bFlag)
        Call SetAuthCon(CmbiDTLevel, bFlag)
        Call SetAuthCon(CmbcDTAQL, bFlag)
        Call SetAuthCon(CmbiEndDTStyle, bFlag)
    End If
End Sub

'-----------------------------------------------
'���ܣ� ���á��Ƿ��ʼ족����ҳǩ
'������ bFlag:      �Ƿ�Ϊ�״̬
'       Container:  ������ҳǩ�е�Frame
'-----------------------------------------------
Private Sub SetEnabledByParent(bFlag As Boolean, Container As Object)
    On Error Resume Next
    Dim Con As Object
    For Each Con In Me.Controls
        If TypeOf Con Is ImageList Then
        Else
            If Con.Container Is Container Then
                If Right(Con.Name, Len("Clone")) = "Clone" Then
                    '��¡�ؼ���������
                Else
                    If bFlag = False Then
                        Con.Enabled = bFlag
                    Else
                        If (TypeOf Con Is Edit) Or (TypeOf Con Is UFCOMBOBOXLib.UFComboBox) Then
                            If Con.Locked = True Then
                            Else
                                Con.Enabled = bFlag
                            End If
                        ElseIf TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then
                            If Con.DataField = "r" Then 'ֻ��Ȩ��
                            Else
                                Con.Enabled = bFlag
                            End If
                        Else
                            Con.Enabled = bFlag '������Command�ؼ���
                        End If
                    End If
                End If
            End If
        End If
    Next
End Sub

'-----------------------------------
'���ܣ�������Ȩ�޿��ƿؼ�
'������ Con��   �ؼ�:ָEdit��combobox�ؼ�����Locked���ԵĿؼ�
'-----------------------------------
Private Sub SetAuthCon(Con As Object, ByVal bFlag As Boolean)
    On Error GoTo Err_Info
    If bFlag = False Then
        Con.Enabled = False
    Else
        If Con.Locked = True Then
        Else
            Con.Enabled = True
        End If
    End If
    Exit Sub
Err_Info:
End Sub

'----------------------------------------
'���ܣ����������λ��ֵ
'----------------------------------------
Private Sub SetEdtcDTUnitVal()
    If (CmbiTestStyle.ListIndex = 2 Or CmbiTestStyle.ListIndex = 3) And ChkBPropertyCheck.Value = 1 Then
        EdtcDTUnit.Text = EdtcComunitCode.Text
'''        EdtcDTUnit.Tag = EdtcComunitCode.Tag
'''        If EdtcDTUnit.Tag <> "" Then
'''            EdtcDTUnit.UTooltipText = g_oPub.getResstring("U8.AA.ARCHIVE.FIELD.codecolon") + EdtcDTUnit.Tag
'''        End If
    End If
End Sub

'----------------------------------------------
'���ܣ�������Ի���
'������con��    ��ǰ���Կؼ�
'----------------------------------------------
Public Function CheckProperty(Con As UFCHECKBOXLib.UFCheckBox) As Boolean
    CheckProperty = True
    If m_bFilling = True Then Exit Function
    CheckProperty = False
    Dim bSale As Integer, bExpSale As Integer, bPurchase As Integer, bComsume As Integer
    Dim bProxyForeign As Integer, bSelf As Integer, bProducing As Integer
    Dim bService As Integer, bATOModel As Integer, bPlanInv As Integer
    Dim bCheckItem As Integer, bPTOModel As Integer, bInvModel As Integer
    Dim bSrvItem   As Integer, bSrvFittings  As Integer, bSrvProduct As String
    Dim bBOMMain As Integer, bBOMSub As Integer, bProductBill As Integer
    Dim bEquipment As Integer
    Dim bInvAsset As Integer, bInvEntrust As Integer
    
    bSale = ChkbSale.Value
    bExpSale = chkbExpSale.Value
    bPurchase = ChkbPurchase.Value
    bComsume = ChkbComsume.Value
    bProxyForeign = ChkbProxyForeign.Value
    bSelf = ChkbSelf.Value
    bProducing = ChkbProducing.Value
    bService = ChkbService.Value
    bATOModel = ChkbATOModel.Value
    bPlanInv = ChkbPlanInv.Value
    bCheckItem = ChkbCheckItem.Value
    bPTOModel = ChkbPTOModel.Value
    bInvModel = ChkbInvModel.Value
    bSrvItem = chkbSrvItem.Value
    bSrvFittings = ChkbSrvFittings.Value
    bBOMMain = Me.InvMPS1.bBOMMain
    bBOMSub = Me.InvMPS1.bBOMSub
    bProductBill = Me.InvMPS1.bProductBill
    bEquipment = ChkbEquipment.Value
    bSrvProduct = chkbSrvProduct.Value
    bInvAsset = chkbInvAsset.Value
    bInvEntrust = ChkbInvEntrust.Value
    
    ReDim g_arr(1 To 1)
    If bPlanInv = 1 And (bSale = 1 Or bExpSale = 1 Or bPurchase = 1 Or bComsume = 1 Or bProxyForeign = 1 Or bSelf = 1 Or bProducing = 1 Or bService = 1 Or bATOModel = 1 Or bCheckItem = 1 Or bPTOModel = 1 Or bSrvItem = 1 Or bSrvFittings = 1 Or bSrvProduct = 1) Then
        g_arr(1) = Me.ChkbPlanInv.Caption
        ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.allpropertymutex", g_arr) '"���ƻ�Ʒ�����������������Ի��⣡"
        Con.Value = 0
        Exit Function
    End If
    If bCheckItem = 1 And (bSale = 1 Or bExpSale = 1 Or bPurchase = 1 Or bComsume = 1 Or bProxyForeign = 1 Or bSelf = 1 Or bProducing = 1 Or bService = 1 Or bATOModel = 1 Or bPlanInv = 1 Or bPTOModel = 1 Or bSrvItem = 1 Or bSrvFittings = 1 Or bSrvProduct = 1) Then
        g_arr(1) = Me.ChkbCheckItem.Caption
        ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.allpropertymutex", g_arr) '"��ѡ���ࡿ���������������Ի��⣡"
        Con.Value = 0
        Exit Function
    End If
    If bPTOModel = 1 And (bSale = 1 Or bExpSale = 1 Or bPurchase = 1 Or bComsume = 1 Or bProxyForeign = 1 Or bSelf = 1 Or bProducing = 1 Or bService = 1 Or bATOModel = 1 Or bCheckItem = 1 Or bPlanInv = 1 Or bSrvItem = 1 Or bSrvFittings = 1 Or bSrvProduct = 1) Then
        g_arr(1) = Me.ChkbPTOModel.Caption
        ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.allpropertymutex", g_arr) ' "��PTOģ�͡����������������Ի��⣡"
        Con.Value = 0
        Exit Function
    End If
    
    If bSrvItem = 1 And (bPurchase = 1 Or bComsume = 1 Or bProxyForeign = 1 Or bSelf = 1 Or bProducing = 1 Or bATOModel = 1 Or bCheckItem = 1 Or bPlanInv = 1 Or bPTOModel = 1 Or bSrvFittings = 1 Or bEquipment = 1) Then  'bSale = 1 Or bExpSale = 1  Or bService = 1 Or
        g_arr(1) = Me.chkbSrvItem.Caption
        'ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.allpropertymutex", g_arr) ' "��������Ŀ�����������������Ի��⣡"
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bsrvitem_mutex") '"��������Ŀ�����롾��������������������Ӧ˰���������⣬�����������Ծ����⣡"
        Con.Value = 0
        Exit Function
    End If
    
    If bSrvFittings = 1 And (bService = 1 Or bPlanInv = 1 Or bPTOModel = 1 Or bCheckItem = 1) Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bsrvfittings_mutex")  '"�������������������[Ӧ˰����]��[�ƻ�Ʒ]��[PTO]��[ѡ����]���Ի��⣡"
        Exit Function
    End If
    
    If bSrvProduct = 1 And (bService = 1 Or bPlanInv = 1 Or bPTOModel = 1 Or bCheckItem = 1) Then
        ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bsrvproduct_mutex")  '"�������Ʒ����������[Ӧ˰����]��[�ƻ�Ʒ]��[PTO]��[ѡ����]���Ի��⣡"
        Exit Function
    End If
    
    '��������е�����ATO���������ò�����? ���ԭ��:     ���������д�������ATO���޵�״��?Or bComsume = 1
    If bATOModel = 1 And (bPurchase = 1 Or bProducing = 1 Or bService = 1 Or bCheckItem = 1 Or bPlanInv = 1 Or bPTOModel = 1) Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.4868_1") 'U8.AA.INVENTORY.FRMZAM.4868_1="��ATOģ�͡����롾���ơ��������ۡ������������á����������������⣬�����������Ծ����⣡"
        Con.Value = 0
        Exit Function
    End If
    'V870 ί��Ӧ��ato������,��ί��Ӧ�롾ato��ģ�͡��Ի���
    If bATOModel = 1 And bInvModel = 1 And bProxyForeign = 1 Then
        ShowMsg g_oPub.GetResString("U8.AA.INVENTORY.FRMZAM.4868_1") 'U8.AA.INVENTORY.FRMZAM.4868_1="��ATOģ�͡����롾���ơ��������ۡ������������á����������������⣬�����������Ծ����⣡"
        Con.Value = 0
        Exit Function
    End If
    
    '����BOMĸ�� �ƻ�Ʒ��ATO��PTO��ѡ���ࡢ���ơ�ί���"Ĭ��Ϊ"��"�ɸģ�"�⹺��"Ĭ��Ϊ"��"�ɸģ������������һ��Ϊ"��"���ɸġ�
    '����BOM�Ӽ� "�ƻ�Ʒ��ATO��PTO��ѡ���ࡢ���ơ�ί������⹺��"Ĭ��Ϊ"��"�ɸģ������������һ��Ϊ"��"���ɸġ�
    If bBOMMain = 1 Then
        If (bPlanInv = 0 And bATOModel = 0 And bPTOModel = 0 And bCheckItem = 0 And bSelf = 0 And bProxyForeign = 0 And bPurchase = 0) Then
            If LCase(Con.Name) = LCase("chkbBOMMain") Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bbommain_rel_item") '"ѡ��[�ƻ�Ʒ]��[ATO]��[PTO]��[ѡ����]��[����]��[ί��]��[�⹺]���򷽿�ѡ��[����BOMĸ��]��"
                Me.InvMPS1.bBOMMain = 0
                Exit Function
            Else
'                ReDim g_arr(0 To 1)
'                g_arr(0) = InvMPS1.ChkbBOMMainCaptin
'                g_arr(1) = Con.Caption
'                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.sel_item1_sel_item2", g_arr) '"��ѡ����[����BOMĸ��]���򲻿�ȡ��[" + con.Caption + "]"
'                Con.Value = 1
                Me.InvMPS1.bBOMMain = 0 '����Ҫ��飬�ʴ˺󲻿ɼ�  Exit Function
            End If
        End If
    End If
    
    If bBOMSub = 1 Then
        If (bPlanInv = 0 And bATOModel = 0 And bPTOModel = 0 And bCheckItem = 0 And bSelf = 0 And bProxyForeign = 0 And bPurchase = 0) Then
            If LCase(Con.Name) = LCase("chkbBOMSub") Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bbomsub_rel_item") '"ѡ��[�ƻ�Ʒ]��[ATO]��[PTO]��[ѡ����]��[����]��[ί��]��[�⹺]���򷽿�ѡ��[����BOM�Ӽ�]��"
                Me.InvMPS1.bBOMSub = 0
                Exit Function
            Else
'                ReDim g_arr(0 To 1)
'                g_arr(0) = InvMPS1.ChkbBOMSubCaption
'                g_arr(1) = Con.Caption
'                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.sel_item1_sel_item2", g_arr) '"��ѡ����[����BOM�Ӽ�]���򲻿�ȡ��[" + con.Caption + "]"
'                Con.Value = 1
                Me.InvMPS1.bBOMSub = 0 '����Ҫ��飬�ʴ˺󲻿ɼ�  Exit Function
            End If
        End If
    End If
    
    '������������ "����"����Ĭ��Ϊ"��"�ɸģ�"ί�⡢�⹺"����Ĭ��Ϊ"��"�ɸģ������������һ��Ϊ"��"���ɸġ�
    If bProductBill = 1 Then
        If (bSelf = 0 And bProxyForeign = 0 And bPurchase = 0) Then
            If LCase(Con.Name) = LCase("chkbProductBill") Then
                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.bproductbill_rel_item") '"ѡ��[����]��[ί��]��[�⹺]���򷽿�ѡ��[������������]��"
                Me.InvMPS1.bProductBill = 0
                Exit Function
            Else
'                ReDim g_arr(0 To 1)
'                g_arr(0) = InvMPS1.ChkbProductBillCaption
'                g_arr(1) = Con.Caption
'                ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.sel_item1_sel_item2", g_arr) '"��ѡ����[������������]���򲻿�ȡ��[" + con.Caption + "]"
'                Con.Value = 1
                Me.InvMPS1.bProductBill = 0 '����Ҫ��飬�ʴ˺󲻿ɼ�  Exit Function
            End If
        End If
    End If
    
    If bInvAsset = 1 Then
        If bInvEntrust = 1 Then
            ReDim g_arr(0 To 1)
            g_arr(0) = ChkbInvEntrust.Caption
            g_arr(1) = chkbInvAsset.Caption
            ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.mutex_eachother", g_arr) '���д������ʲ����Ի���
            Con.Value = 0
            Exit Function
        End If
    End If
    
        
    CheckProperty = True
End Function

Private Sub TLB2_OnCommand(ByVal enumType As UFToolBarCtrl.ENUM_MENU_OR_BUTTON, ByVal cButtonId As String, ByVal cMenuId As String)
    Operating cButtonId
    If LCase(cButtonId) <> "exit" Then
        SetAddModify cButtonId
    End If
End Sub


'=============================(����������Ŀ����ֶα����� Begin)==========================================
Private Sub RuleInit()
    On Error GoTo Err_Info
    If m_optType = optType.enuQuery Then
        '��ѯ״̬��ֹ����ֶα������ٿؽ���ֵ
    Else
        If g_oPub.ExistSpecialVersionType(SrvDB, 3) Then
            Set m_ObjRule = CreateObject("InvCodeRuleLig.clsInterface")
            m_bRule = True
        End If
    End If
    Exit Sub
Err_Info:
    Call g_oPub.WriteErrorLog("InventoryClient", "RuleInit", Err.Number, Err.Description, False)
End Sub


Private Function RuleMethod(fFrm As Object, oLogin As Object, ConName As String, MethodName As String, Optional sXML As String) As Boolean
    On Error GoTo Err_Info
    If m_bRule = True Then RuleMethod = m_ObjRule.DllInterFace(Me, g_oLogin, ConName, MethodName)
    Exit Function
Err_Info:
    ShowMsg "RuleMethod:" & Err.Description
End Function

Private Sub RuleSetConState(opt As Integer)
    On Error GoTo Err_Info
    If m_bRule = True Then Call m_ObjRule.SetConState(Me, g_oLogin)
    Exit Sub
Err_Info:
    ShowMsg "RuleSetConState:" & Err.Description
End Sub
'=============================(����������Ŀ����ֶα����� End)==========================================


