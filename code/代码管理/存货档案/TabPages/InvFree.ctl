VERSION 5.00
Object = "{9ADF72AD-DDA9-11D1-9D4B-000021006D51}#1.31#0"; "UFSpGrid.ocx"
Object = "{A0C292A3-118E-11D2-AFDF-000021730160}#1.0#0"; "UFEDIT.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{9FD12F62-6922-47E1-B1AC-3615BBD3D7A5}#1.0#0"; "UFLabel.ocx"
Object = "{BF022F1C-E440-4790-987F-252926B9B602}#5.1#0"; "UFFrames.ocx"
Object = "{A98B9C82-88D8-4F94-91BB-F2289111C59C}#1.0#0"; "UFCheckBox.ocx"
Object = "{8C7C777D-4D83-4DE8-947E-098E2343A400}#1.0#0"; "CommandButton.ocx"
Object = "{AF8BBBB7-94C6-4772-B826-624478C37D6A}#1.5#0"; "UFKEYHOOK.ocx"
Begin VB.UserControl InvFree 
   ClientHeight    =   7320
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11295
   LockControls    =   -1  'True
   ScaleHeight     =   7320
   ScaleMode       =   0  'User
   ScaleWidth      =   11295
   Begin VB.PictureBox PicTab 
      Height          =   240
      Left            =   2910
      ScaleHeight     =   180
      ScaleWidth      =   285
      TabIndex        =   31
      Top             =   7020
      Width           =   345
   End
   Begin UFFrames.UFFrame Frame1 
      Height          =   6030
      Left            =   0
      TabIndex        =   21
      Top             =   30
      Width           =   11250
      _ExtentX        =   19844
      _ExtentY        =   10636
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   8.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Begin VB.PictureBox Picture1 
         Height          =   5985
         Left            =   0
         ScaleHeight     =   4242.371
         ScaleMode       =   0  'User
         ScaleWidth      =   8691.668
         TabIndex        =   22
         Top             =   0
         Width           =   11235
         Begin TabDlg.SSTab SSTabBasPart 
            Height          =   6675
            Left            =   -30
            TabIndex        =   23
            Top             =   0
            Width           =   12420
            _ExtentX        =   21908
            _ExtentY        =   11774
            _Version        =   393216
            Style           =   1
            Tab             =   2
            TabHeight       =   520
            TabCaption(0)   =   "自由项"
            TabPicture(0)   =   "InvFree.ctx":0000
            Tab(0).ControlEnabled=   0   'False
            Tab(0).Control(0)=   "Line1"
            Tab(0).Control(0).Enabled=   0   'False
            Tab(0).Control(1)=   "LineLevel(0)"
            Tab(0).Control(1).Enabled=   0   'False
            Tab(0).Control(2)=   "Line4"
            Tab(0).Control(2).Enabled=   0   'False
            Tab(0).Control(3)=   "LineLevel(1)"
            Tab(0).Control(3).Enabled=   0   'False
            Tab(0).Control(4)=   "LineLevel(2)"
            Tab(0).Control(4).Enabled=   0   'False
            Tab(0).Control(5)=   "LineLevel(3)"
            Tab(0).Control(5).Enabled=   0   'False
            Tab(0).Control(6)=   "LineLevel(4)"
            Tab(0).Control(6).Enabled=   0   'False
            Tab(0).Control(7)=   "LineLevel(5)"
            Tab(0).Control(7).Enabled=   0   'False
            Tab(0).Control(8)=   "LineLevel(6)"
            Tab(0).Control(8).Enabled=   0   'False
            Tab(0).Control(9)=   "LineLevel(7)"
            Tab(0).Control(9).Enabled=   0   'False
            Tab(0).Control(10)=   "LineLevel(8)"
            Tab(0).Control(10).Enabled=   0   'False
            Tab(0).Control(11)=   "LineLevel(9)"
            Tab(0).Control(11).Enabled=   0   'False
            Tab(0).Control(12)=   "CmdSetFreeItem(9)"
            Tab(0).Control(12).Enabled=   0   'False
            Tab(0).Control(13)=   "CmdSetFreeItem(8)"
            Tab(0).Control(13).Enabled=   0   'False
            Tab(0).Control(14)=   "CmdSetFreeItem(7)"
            Tab(0).Control(14).Enabled=   0   'False
            Tab(0).Control(15)=   "CmdSetFreeItem(6)"
            Tab(0).Control(15).Enabled=   0   'False
            Tab(0).Control(16)=   "CmdSetFreeItem(5)"
            Tab(0).Control(16).Enabled=   0   'False
            Tab(0).Control(17)=   "CmdSetFreeItem(4)"
            Tab(0).Control(17).Enabled=   0   'False
            Tab(0).Control(18)=   "CmdSetFreeItem(3)"
            Tab(0).Control(18).Enabled=   0   'False
            Tab(0).Control(19)=   "CmdSetFreeItem(2)"
            Tab(0).Control(19).Enabled=   0   'False
            Tab(0).Control(20)=   "CmdSetFreeItem(1)"
            Tab(0).Control(20).Enabled=   0   'False
            Tab(0).Control(21)=   "ChkbControlFreeRange(9)"
            Tab(0).Control(21).Enabled=   0   'False
            Tab(0).Control(22)=   "ChkbControlFreeRange(8)"
            Tab(0).Control(22).Enabled=   0   'False
            Tab(0).Control(23)=   "ChkbControlFreeRange(7)"
            Tab(0).Control(23).Enabled=   0   'False
            Tab(0).Control(24)=   "ChkbControlFreeRange(6)"
            Tab(0).Control(24).Enabled=   0   'False
            Tab(0).Control(25)=   "ChkbControlFreeRange(5)"
            Tab(0).Control(25).Enabled=   0   'False
            Tab(0).Control(26)=   "ChkbControlFreeRange(4)"
            Tab(0).Control(26).Enabled=   0   'False
            Tab(0).Control(27)=   "ChkbControlFreeRange(3)"
            Tab(0).Control(27).Enabled=   0   'False
            Tab(0).Control(28)=   "ChkbControlFreeRange(2)"
            Tab(0).Control(28).Enabled=   0   'False
            Tab(0).Control(29)=   "ChkbControlFreeRange(1)"
            Tab(0).Control(29).Enabled=   0   'False
            Tab(0).Control(30)=   "ChkbControlFreeRange(0)"
            Tab(0).Control(30).Enabled=   0   'False
            Tab(0).Control(31)=   "LblbControlFreeRange"
            Tab(0).Control(31).Enabled=   0   'False
            Tab(0).Control(32)=   "ChkbOMPriceFree(9)"
            Tab(0).Control(32).Enabled=   0   'False
            Tab(0).Control(33)=   "ChkbOMPriceFree(8)"
            Tab(0).Control(33).Enabled=   0   'False
            Tab(0).Control(34)=   "ChkbOMPriceFree(7)"
            Tab(0).Control(34).Enabled=   0   'False
            Tab(0).Control(35)=   "ChkbOMPriceFree(6)"
            Tab(0).Control(35).Enabled=   0   'False
            Tab(0).Control(36)=   "ChkbOMPriceFree(5)"
            Tab(0).Control(36).Enabled=   0   'False
            Tab(0).Control(37)=   "ChkbOMPriceFree(4)"
            Tab(0).Control(37).Enabled=   0   'False
            Tab(0).Control(38)=   "ChkbOMPriceFree(3)"
            Tab(0).Control(38).Enabled=   0   'False
            Tab(0).Control(39)=   "ChkbOMPriceFree(2)"
            Tab(0).Control(39).Enabled=   0   'False
            Tab(0).Control(40)=   "ChkbOMPriceFree(1)"
            Tab(0).Control(40).Enabled=   0   'False
            Tab(0).Control(41)=   "ChkbOMPriceFree(0)"
            Tab(0).Control(41).Enabled=   0   'False
            Tab(0).Control(42)=   "ChkbSalePriceFree(9)"
            Tab(0).Control(42).Enabled=   0   'False
            Tab(0).Control(43)=   "ChkbSalePriceFree(8)"
            Tab(0).Control(43).Enabled=   0   'False
            Tab(0).Control(44)=   "ChkbSalePriceFree(7)"
            Tab(0).Control(44).Enabled=   0   'False
            Tab(0).Control(45)=   "ChkbSalePriceFree(6)"
            Tab(0).Control(45).Enabled=   0   'False
            Tab(0).Control(46)=   "ChkbSalePriceFree(5)"
            Tab(0).Control(46).Enabled=   0   'False
            Tab(0).Control(47)=   "ChkbSalePriceFree(4)"
            Tab(0).Control(47).Enabled=   0   'False
            Tab(0).Control(48)=   "ChkbSalePriceFree(3)"
            Tab(0).Control(48).Enabled=   0   'False
            Tab(0).Control(49)=   "ChkbSalePriceFree(2)"
            Tab(0).Control(49).Enabled=   0   'False
            Tab(0).Control(50)=   "ChkbSalePriceFree(1)"
            Tab(0).Control(50).Enabled=   0   'False
            Tab(0).Control(51)=   "ChkbSalePriceFree(0)"
            Tab(0).Control(51).Enabled=   0   'False
            Tab(0).Control(52)=   "ChkbPurPriceFree(9)"
            Tab(0).Control(52).Enabled=   0   'False
            Tab(0).Control(53)=   "ChkbPurPriceFree(8)"
            Tab(0).Control(53).Enabled=   0   'False
            Tab(0).Control(54)=   "ChkbPurPriceFree(7)"
            Tab(0).Control(54).Enabled=   0   'False
            Tab(0).Control(55)=   "ChkbPurPriceFree(6)"
            Tab(0).Control(55).Enabled=   0   'False
            Tab(0).Control(56)=   "ChkbPurPriceFree(5)"
            Tab(0).Control(56).Enabled=   0   'False
            Tab(0).Control(57)=   "ChkbPurPriceFree(4)"
            Tab(0).Control(57).Enabled=   0   'False
            Tab(0).Control(58)=   "ChkbPurPriceFree(3)"
            Tab(0).Control(58).Enabled=   0   'False
            Tab(0).Control(59)=   "ChkbPurPriceFree(2)"
            Tab(0).Control(59).Enabled=   0   'False
            Tab(0).Control(60)=   "ChkbPurPriceFree(1)"
            Tab(0).Control(60).Enabled=   0   'False
            Tab(0).Control(61)=   "ChkbPurPriceFree(0)"
            Tab(0).Control(61).Enabled=   0   'False
            Tab(0).Control(62)=   "LblbOMPriceFree"
            Tab(0).Control(62).Enabled=   0   'False
            Tab(0).Control(63)=   "lblbSalePriceFree"
            Tab(0).Control(63).Enabled=   0   'False
            Tab(0).Control(64)=   "lblbPurPriceFree"
            Tab(0).Control(64).Enabled=   0   'False
            Tab(0).Control(65)=   "ChkbCheckFree(9)"
            Tab(0).Control(65).Enabled=   0   'False
            Tab(0).Control(66)=   "ChkbCheckFree(8)"
            Tab(0).Control(66).Enabled=   0   'False
            Tab(0).Control(67)=   "ChkbCheckFree(7)"
            Tab(0).Control(67).Enabled=   0   'False
            Tab(0).Control(68)=   "ChkbCheckFree(6)"
            Tab(0).Control(68).Enabled=   0   'False
            Tab(0).Control(69)=   "ChkbCheckFree(5)"
            Tab(0).Control(69).Enabled=   0   'False
            Tab(0).Control(70)=   "ChkbCheckFree(4)"
            Tab(0).Control(70).Enabled=   0   'False
            Tab(0).Control(71)=   "ChkbCheckFree(3)"
            Tab(0).Control(71).Enabled=   0   'False
            Tab(0).Control(72)=   "ChkbCheckFree(2)"
            Tab(0).Control(72).Enabled=   0   'False
            Tab(0).Control(73)=   "ChkbCheckFree(1)"
            Tab(0).Control(73).Enabled=   0   'False
            Tab(0).Control(74)=   "ChkbCheckFree(0)"
            Tab(0).Control(74).Enabled=   0   'False
            Tab(0).Control(75)=   "lblAccoutingFree"
            Tab(0).Control(75).Enabled=   0   'False
            Tab(0).Control(76)=   "LblConfigFree"
            Tab(0).Control(76).Enabled=   0   'False
            Tab(0).Control(77)=   "LblFree"
            Tab(0).Control(77).Enabled=   0   'False
            Tab(0).Control(78)=   "ChkbConfigFree(9)"
            Tab(0).Control(78).Enabled=   0   'False
            Tab(0).Control(79)=   "ChkbConfigFree(8)"
            Tab(0).Control(79).Enabled=   0   'False
            Tab(0).Control(80)=   "ChkbConfigFree(7)"
            Tab(0).Control(80).Enabled=   0   'False
            Tab(0).Control(81)=   "ChkbConfigFree(6)"
            Tab(0).Control(81).Enabled=   0   'False
            Tab(0).Control(82)=   "ChkbConfigFree(5)"
            Tab(0).Control(82).Enabled=   0   'False
            Tab(0).Control(83)=   "ChkbConfigFree(4)"
            Tab(0).Control(83).Enabled=   0   'False
            Tab(0).Control(84)=   "ChkbConfigFree(3)"
            Tab(0).Control(84).Enabled=   0   'False
            Tab(0).Control(85)=   "ChkbConfigFree(2)"
            Tab(0).Control(85).Enabled=   0   'False
            Tab(0).Control(86)=   "ChkbConfigFree(1)"
            Tab(0).Control(86).Enabled=   0   'False
            Tab(0).Control(87)=   "ChkbConfigFree(0)"
            Tab(0).Control(87).Enabled=   0   'False
            Tab(0).Control(88)=   "ChkFree(0)"
            Tab(0).Control(88).Enabled=   0   'False
            Tab(0).Control(89)=   "ChkFree(1)"
            Tab(0).Control(89).Enabled=   0   'False
            Tab(0).Control(90)=   "ChkFree(2)"
            Tab(0).Control(90).Enabled=   0   'False
            Tab(0).Control(91)=   "ChkFree(3)"
            Tab(0).Control(91).Enabled=   0   'False
            Tab(0).Control(92)=   "ChkFree(4)"
            Tab(0).Control(92).Enabled=   0   'False
            Tab(0).Control(93)=   "ChkFree(5)"
            Tab(0).Control(93).Enabled=   0   'False
            Tab(0).Control(94)=   "ChkFree(6)"
            Tab(0).Control(94).Enabled=   0   'False
            Tab(0).Control(95)=   "ChkFree(7)"
            Tab(0).Control(95).Enabled=   0   'False
            Tab(0).Control(96)=   "ChkFree(8)"
            Tab(0).Control(96).Enabled=   0   'False
            Tab(0).Control(97)=   "ChkFree(9)"
            Tab(0).Control(97).Enabled=   0   'False
            Tab(0).Control(98)=   "CmdSetFreeItem(0)"
            Tab(0).Control(98).Enabled=   0   'False
            Tab(0).ControlCount=   99
            TabCaption(1)   =   "物料"
            TabPicture(1)   =   "InvFree.ctx":001C
            Tab(1).ControlEnabled=   0   'False
            Tab(1).Control(0)=   "FrameTlb"
            Tab(1).Control(0).Enabled=   0   'False
            Tab(1).Control(1)=   "grid"
            Tab(1).Control(1).Enabled=   0   'False
            Tab(1).ControlCount=   2
            TabCaption(2)   =   "核算"
            TabPicture(2)   =   "InvFree.ctx":0038
            Tab(2).ControlEnabled=   -1  'True
            Tab(2).Control(0)=   "GridCheck"
            Tab(2).Control(0).Enabled=   0   'False
            Tab(2).Control(1)=   "UFFrameTlb2"
            Tab(2).Control(1).Enabled=   0   'False
            Tab(2).ControlCount=   2
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   0
               Left            =   -72300
               TabIndex        =   94
               Top             =   870
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   9
               Left            =   -74520
               TabIndex        =   18
               Top             =   3720
               Width           =   1905
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   8
               Left            =   -74520
               TabIndex        =   16
               Top             =   3410
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   -1
               ForeColor       =   -1
               BorderStyle     =   -1
               ReadyState      =   -1
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   7
               Left            =   -74520
               TabIndex        =   14
               Top             =   3100
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   24920
               ForeColor       =   24920
               BorderStyle     =   19472
               ReadyState      =   6230
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   6
               Left            =   -74520
               TabIndex        =   12
               Top             =   2790
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   5
               Left            =   -74520
               TabIndex        =   10
               Top             =   2480
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   -65536
               ForeColor       =   -65536
               BorderStyle     =   18120
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   4
               Left            =   -74520
               TabIndex        =   8
               Top             =   2170
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   400
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   3
               Left            =   -74520
               TabIndex        =   6
               Top             =   1860
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   1996595444
               ForeColor       =   1996595444
               BorderStyle     =   0
               ReadyState      =   1996536096
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   2
               Left            =   -74520
               TabIndex        =   4
               Top             =   1550
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   1
               Left            =   -74520
               TabIndex        =   2
               Top             =   1240
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   352
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkFree 
               Height          =   195
               Index           =   0
               Left            =   -74520
               TabIndex        =   0
               Top             =   930
               Width           =   1900
               _Version        =   65536
               _ExtentX        =   3351
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   1996595444
               ForeColor       =   1996595444
               BorderStyle     =   0
               ReadyState      =   1996536096
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   0
               Left            =   -70710
               TabIndex        =   1
               Top             =   930
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   1
               Left            =   -70710
               TabIndex        =   3
               Top             =   1245
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   2
               Left            =   -70710
               TabIndex        =   5
               Top             =   1545
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   3
               Left            =   -70710
               TabIndex        =   7
               Top             =   1860
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   943208504
               ForeColor       =   943208504
               BorderStyle     =   14392
               ReadyState      =   16777016
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   4
               Left            =   -70710
               TabIndex        =   9
               Top             =   2175
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   3
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   5
               Left            =   -70710
               TabIndex        =   11
               Top             =   2475
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   1996593560
               ForeColor       =   1996593560
               BorderStyle     =   -26196
               ReadyState      =   1996593528
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   6
               Left            =   -70710
               TabIndex        =   13
               Top             =   2790
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   1996593880
               ForeColor       =   1996593880
               BorderStyle     =   -25796
               ReadyState      =   1996593816
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   7
               Left            =   -70710
               TabIndex        =   15
               Top             =   3105
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   76
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   8
               Left            =   -70710
               TabIndex        =   17
               Top             =   3405
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   1996558337
               ForeColor       =   1996558337
               BorderStyle     =   2194
               ReadyState      =   23921016
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbConfigFree 
               Height          =   195
               Index           =   9
               Left            =   -70710
               TabIndex        =   19
               Top             =   3720
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   1996593880
               ForeColor       =   1996593880
               BorderStyle     =   -25796
               ReadyState      =   1996593816
            End
            Begin UFFrames.UFFrame FrameTlb 
               Height          =   495
               Left            =   -74970
               TabIndex        =   24
               Top             =   360
               Width           =   11295
               _ExtentX        =   19923
               _ExtentY        =   873
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "宋体"
                  Size            =   8.25
                  Charset         =   134
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdRefresh 
                  Height          =   345
                  Left            =   930
                  TabIndex        =   30
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "还原"
                  UToolTipText    =   ""
                  Cursor          =   30464
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
               Begin EDITLib.Edit EdtFreeProxy 
                  Height          =   30
                  Left            =   5040
                  TabIndex        =   29
                  Top             =   240
                  Visible         =   0   'False
                  Width           =   1215
                  _Version        =   65536
                  _ExtentX        =   2143
                  _ExtentY        =   53
                  _StockProps     =   253
                  ForeColor       =   0
                  BackColor       =   16777215
                  Appearance      =   1
                  MaxLength       =   200
               End
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdAdd 
                  Height          =   345
                  Left            =   1755
                  TabIndex        =   26
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "增行"
                  UToolTipText    =   ""
                  Cursor          =   0
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDel 
                  Height          =   345
                  Left            =   2580
                  TabIndex        =   25
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "删行"
                  UToolTipText    =   ""
                  Cursor          =   0
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdPosBasPart 
                  Height          =   345
                  Left            =   90
                  TabIndex        =   48
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "定位"
                  UToolTipText    =   ""
                  Cursor          =   0
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
            End
            Begin MsSuperGrid.SuperGrid grid 
               Height          =   5085
               Left            =   -74970
               TabIndex        =   20
               Top             =   870
               Width           =   11205
               _ExtentX        =   19764
               _ExtentY        =   8969
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "宋体"
                  Size            =   9
                  Charset         =   134
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               EditBorderStyle =   0
               Redraw          =   1
               MouseIcon       =   "InvFree.ctx":0054
               ForeColorSel    =   -2147483634
               ForeColorFixed  =   -2147483630
               FixedCols       =   0
               BackColorSel    =   -2147483635
               BackColorFixed  =   -2147483633
               AllowUserResizing=   1
               AllowBigSelection=   0   'False
            End
            Begin UFLABELLib.UFLabel LblFree 
               Height          =   255
               Left            =   -74550
               TabIndex        =   28
               Top             =   570
               Width           =   1035
               _Version        =   65536
               _ExtentX        =   1826
               _ExtentY        =   450
               _StockProps     =   111
               Caption         =   "自由项"
            End
            Begin UFLABELLib.UFLabel LblConfigFree 
               Height          =   255
               Left            =   -70860
               TabIndex        =   27
               Top             =   570
               Width           =   1395
               _Version        =   65536
               _ExtentX        =   2461
               _ExtentY        =   450
               _StockProps     =   111
               Caption         =   "是否结构性"
            End
            Begin UFLABELLib.UFLabel lblAccoutingFree 
               Height          =   255
               Left            =   -69420
               TabIndex        =   32
               Top             =   570
               Width           =   1395
               _Version        =   65536
               _ExtentX        =   2461
               _ExtentY        =   450
               _StockProps     =   111
               Caption         =   "是否核算"
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   0
               Left            =   -69180
               TabIndex        =   33
               Top             =   930
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   1
               Left            =   -69180
               TabIndex        =   34
               Top             =   1245
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   2
               Left            =   -69180
               TabIndex        =   35
               Top             =   1545
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   3
               Left            =   -69180
               TabIndex        =   36
               Top             =   1860
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   4
               Left            =   -69180
               TabIndex        =   37
               Top             =   2175
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   5
               Left            =   -69180
               TabIndex        =   38
               Top             =   2475
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   6
               Left            =   -69180
               TabIndex        =   39
               Top             =   2790
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   7
               Left            =   -69180
               TabIndex        =   40
               Top             =   3105
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   8
               Left            =   -69180
               TabIndex        =   41
               Top             =   3405
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbCheckFree 
               Height          =   195
               Index           =   9
               Left            =   -69180
               TabIndex        =   42
               Top             =   3720
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFFrames.UFFrame UFFrameTlb2 
               Height          =   495
               Left            =   30
               TabIndex        =   43
               Top             =   360
               Width           =   11505
               _ExtentX        =   20294
               _ExtentY        =   873
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "宋体"
                  Size            =   8.25
                  Charset         =   134
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdBackCheck 
                  Height          =   345
                  Left            =   930
                  TabIndex        =   44
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "还原"
                  UToolTipText    =   ""
                  Cursor          =   30464
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdAddCheck 
                  Height          =   345
                  Left            =   1755
                  TabIndex        =   45
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "增行"
                  UToolTipText    =   ""
                  Cursor          =   0
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdDelCheck 
                  Height          =   345
                  Left            =   2580
                  TabIndex        =   46
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "删行"
                  UToolTipText    =   ""
                  Cursor          =   0
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
               Begin UFCOMMANDBUTTONLib.UFCommandButton CmdPosCheck 
                  Height          =   345
                  Left            =   90
                  TabIndex        =   49
                  Top             =   90
                  Width           =   825
                  _Version        =   65536
                  _ExtentX        =   1455
                  _ExtentY        =   609
                  _StockProps     =   41
                  Caption         =   "定位"
                  UToolTipText    =   ""
                  Cursor          =   0
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "MS Sans Serif"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Flat            =   0   'False
                  Enabled         =   -1  'True
                  Style           =   0   'False
                  Value           =   0   'False
               End
            End
            Begin MsSuperGrid.SuperGrid GridCheck 
               Height          =   5085
               Left            =   30
               TabIndex        =   47
               Top             =   870
               Width           =   11385
               _ExtentX        =   20082
               _ExtentY        =   8969
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "宋体"
                  Size            =   9
                  Charset         =   134
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               EditBorderStyle =   0
               Redraw          =   1
               MouseIcon       =   "InvFree.ctx":0070
               ForeColorSel    =   -2147483634
               ForeColorFixed  =   -2147483630
               FixedCols       =   0
               BackColorSel    =   -2147483635
               BackColorFixed  =   -2147483633
               AllowUserResizing=   1
               AllowBigSelection=   0   'False
            End
            Begin UFLABELLib.UFLabel lblbPurPriceFree 
               Height          =   255
               Left            =   -68010
               TabIndex        =   50
               Top             =   570
               Width           =   1395
               _Version        =   65536
               _ExtentX        =   2461
               _ExtentY        =   450
               _StockProps     =   111
               Caption         =   "采购定价"
            End
            Begin UFLABELLib.UFLabel lblbSalePriceFree 
               Height          =   255
               Left            =   -66600
               TabIndex        =   51
               Top             =   570
               Width           =   1395
               _Version        =   65536
               _ExtentX        =   2461
               _ExtentY        =   450
               _StockProps     =   111
               Caption         =   "销售定价"
            End
            Begin UFLABELLib.UFLabel LblbOMPriceFree 
               Height          =   255
               Left            =   -65190
               TabIndex        =   52
               Top             =   570
               Width           =   1395
               _Version        =   65536
               _ExtentX        =   2461
               _ExtentY        =   450
               _StockProps     =   111
               Caption         =   "委外定价"
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   0
               Left            =   -67740
               TabIndex        =   53
               Top             =   930
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   1
               Left            =   -67740
               TabIndex        =   54
               Top             =   1245
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   2
               Left            =   -67740
               TabIndex        =   55
               Top             =   1545
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   3
               Left            =   -67740
               TabIndex        =   56
               Top             =   1860
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   4
               Left            =   -67740
               TabIndex        =   57
               Top             =   2175
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   5
               Left            =   -67740
               TabIndex        =   58
               Top             =   2475
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   6
               Left            =   -67740
               TabIndex        =   59
               Top             =   2790
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   7
               Left            =   -67740
               TabIndex        =   60
               Top             =   3105
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   8
               Left            =   -67740
               TabIndex        =   61
               Top             =   3405
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbPurPriceFree 
               Height          =   195
               Index           =   9
               Left            =   -67740
               TabIndex        =   62
               Top             =   3720
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   0
               Left            =   -66390
               TabIndex        =   63
               Top             =   930
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   1
               Left            =   -66390
               TabIndex        =   64
               Top             =   1245
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   2
               Left            =   -66390
               TabIndex        =   65
               Top             =   1545
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   3
               Left            =   -66390
               TabIndex        =   66
               Top             =   1860
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   4
               Left            =   -66390
               TabIndex        =   67
               Top             =   2175
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   5
               Left            =   -66390
               TabIndex        =   68
               Top             =   2475
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   6
               Left            =   -66390
               TabIndex        =   69
               Top             =   2790
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   7
               Left            =   -66390
               TabIndex        =   70
               Top             =   3105
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   8
               Left            =   -66390
               TabIndex        =   71
               Top             =   3405
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbSalePriceFree 
               Height          =   195
               Index           =   9
               Left            =   -66390
               TabIndex        =   72
               Top             =   3720
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   0
               Left            =   -64980
               TabIndex        =   73
               Top             =   930
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   1
               Left            =   -64980
               TabIndex        =   74
               Top             =   1245
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   2
               Left            =   -64980
               TabIndex        =   75
               Top             =   1545
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   3
               Left            =   -64980
               TabIndex        =   76
               Top             =   1860
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   4
               Left            =   -64980
               TabIndex        =   77
               Top             =   2175
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   5
               Left            =   -64980
               TabIndex        =   78
               Top             =   2475
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   6
               Left            =   -64980
               TabIndex        =   79
               Top             =   2790
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   7
               Left            =   -64980
               TabIndex        =   80
               Top             =   3105
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   8
               Left            =   -64980
               TabIndex        =   81
               Top             =   3405
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbOMPriceFree 
               Height          =   195
               Index           =   9
               Left            =   -64980
               TabIndex        =   82
               Top             =   3720
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFLABELLib.UFLabel LblbControlFreeRange 
               Height          =   255
               Left            =   -72780
               TabIndex        =   83
               Top             =   570
               Width           =   1845
               _Version        =   65536
               _ExtentX        =   3254
               _ExtentY        =   450
               _StockProps     =   111
               Caption         =   "控制自由项取值范围"
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   0
               Left            =   -72570
               TabIndex        =   84
               Top             =   930
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   1
               Left            =   -72570
               TabIndex        =   85
               Top             =   1240
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   2
               Left            =   -72570
               TabIndex        =   86
               Top             =   1550
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   3
               Left            =   -72570
               TabIndex        =   87
               Top             =   1860
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   4
               Left            =   -72570
               TabIndex        =   88
               Top             =   2170
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   5
               Left            =   -72570
               TabIndex        =   89
               Top             =   2480
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   6
               Left            =   -72570
               TabIndex        =   90
               Top             =   2790
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   7
               Left            =   -72570
               TabIndex        =   91
               Top             =   3100
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   8
               Left            =   -72570
               TabIndex        =   92
               Top             =   3410
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCHECKBOXLib.UFCheckBox ChkbControlFreeRange 
               Height          =   195
               Index           =   9
               Left            =   -72570
               TabIndex        =   93
               Top             =   3720
               Width           =   195
               _Version        =   65536
               _ExtentX        =   344
               _ExtentY        =   344
               _StockProps     =   15
               ForeColor       =   0
               ForeColor       =   0
               BorderStyle     =   0
               ReadyState      =   0
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   1
               Left            =   -72300
               TabIndex        =   95
               Top             =   1183
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   2
               Left            =   -72300
               TabIndex        =   96
               Top             =   1496
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   3
               Left            =   -72300
               TabIndex        =   97
               Top             =   1809
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   4
               Left            =   -72300
               TabIndex        =   98
               Top             =   2122
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   5
               Left            =   -72300
               TabIndex        =   99
               Top             =   2435
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   6
               Left            =   -72300
               TabIndex        =   100
               Top             =   2748
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   7
               Left            =   -72300
               TabIndex        =   101
               Top             =   3061
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   8
               Left            =   -72300
               TabIndex        =   102
               Top             =   3374
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin UFCOMMANDBUTTONLib.UFCommandButton CmdSetFreeItem 
               Height          =   285
               Index           =   9
               Left            =   -72300
               TabIndex        =   103
               Top             =   3690
               Width           =   825
               _Version        =   65536
               _ExtentX        =   1455
               _ExtentY        =   503
               _StockProps     =   41
               Caption         =   "取值"
               UToolTipText    =   ""
               Cursor          =   0
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "MS Sans Serif"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Flat            =   0   'False
               Enabled         =   -1  'True
               Style           =   0   'False
               Value           =   0   'False
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00FFFFC0&
               BorderStyle     =   6  'Inside Solid
               Index           =   9
               X1              =   -74850
               X2              =   -63990
               Y1              =   3990
               Y2              =   3990
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00C0C0C0&
               BorderStyle     =   6  'Inside Solid
               Index           =   8
               X1              =   -74850
               X2              =   -63990
               Y1              =   3660
               Y2              =   3660
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00FFFFC0&
               BorderStyle     =   6  'Inside Solid
               Index           =   7
               X1              =   -74850
               X2              =   -63990
               Y1              =   3360
               Y2              =   3360
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00C0C0C0&
               BorderStyle     =   6  'Inside Solid
               Index           =   6
               X1              =   -74850
               X2              =   -63990
               Y1              =   3030
               Y2              =   3030
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00FFFFC0&
               BorderStyle     =   6  'Inside Solid
               Index           =   5
               X1              =   -74850
               X2              =   -63990
               Y1              =   2700
               Y2              =   2700
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00C0C0C0&
               BorderStyle     =   6  'Inside Solid
               Index           =   4
               X1              =   -74850
               X2              =   -63990
               Y1              =   2430
               Y2              =   2430
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00FFFFC0&
               BorderStyle     =   6  'Inside Solid
               Index           =   3
               X1              =   -74850
               X2              =   -63990
               Y1              =   2100
               Y2              =   2100
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00C0C0C0&
               BorderStyle     =   6  'Inside Solid
               Index           =   2
               X1              =   -74850
               X2              =   -63990
               Y1              =   1800
               Y2              =   1800
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00FFFFC0&
               BorderStyle     =   6  'Inside Solid
               Index           =   1
               X1              =   -74850
               X2              =   -63990
               Y1              =   1470
               Y2              =   1470
            End
            Begin VB.Line Line4 
               BorderColor     =   &H00C0C0C0&
               BorderStyle     =   6  'Inside Solid
               X1              =   -75000
               X2              =   -64140
               Y1              =   0
               Y2              =   0
            End
            Begin VB.Line LineLevel 
               BorderColor     =   &H00C0C0C0&
               BorderStyle     =   6  'Inside Solid
               Index           =   0
               X1              =   -74850
               X2              =   -63990
               Y1              =   1170
               Y2              =   1170
            End
            Begin VB.Line Line1 
               X1              =   -74850
               X2              =   -63990
               Y1              =   840
               Y2              =   840
            End
         End
      End
   End
   Begin UFKeyHook.UFKeyHookCtrl UFFrmKeyHook 
      Left            =   90
      Top             =   1020
      _ExtentX        =   1905
      _ExtentY        =   529
      ManualAttach    =   -1  'True
   End
   Begin VB.Menu mOrder 
      Caption         =   "排序"
      Begin VB.Menu mAsc 
         Caption         =   "升序"
      End
      Begin VB.Menu mDesc 
         Caption         =   "降序"
      End
   End
End
Attribute VB_Name = "InvFree"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'用于翻页(规定接口)
Public Event EdtKeyPress(fldName As String, KeyAscii As Integer)
'用于激活保存按钮(规定接口)
Public Event ActiveSaveBtn()
Public Event GetRef(TableName As String, RefFld As String, sCode As String, sName As String, bReturn As Boolean, Edt As Object)
Public Event GetNum(SafeQty As String, MinQty As String, MulQty As String, FixQty As String)
Public Event GetInvData(sXml As String)


Dim m_Dom As New DOMDocument
Dim m_Ele As IXMLDOMElement
Dim m_EleStyle As IXMLDOMElement

Dim m_arrConfigFlds() As String '物料字段
Dim m_arrConfigAuthFlds() As String '物料对应的存货权限字段
Dim m_arrConfigAuthTypeFlds() As String '没有分配权限(空)；只读权限(R);写权限(W);无权限(N)
Dim m_arrChkFreeFlds() As String '核算自由项字段
Dim m_arrChkFreeAuthFlds() As String '核算自由项对应的存货权限字段
Dim m_arrChkFreeAuthTypeFlds() As String '没有分配权限(空)；只读权限(R);写权限(W);无权限(N)
'Dim m_arrfldCol As Integer '字段所在列
Dim sBaspartFlds As String
Dim sCheckFreeFlds As String
Dim m_iPriceDecDgt As Integer '单价小数位数
Dim m_iQuanDecDgt As Integer ''存货数量小数位
Dim m_FreeColIndex As Integer '自由项重Grid何列开始

Dim beforeEditText As String
Dim deleteXml As DOMDocument


Dim m_SrvDB As Object
Dim m_oLogin  As Object
Dim m_bShow As Boolean '是否显示该页签

Dim m_sRFldAuthInv As String  '只读权限字段名
Dim m_sNFldAuthInv As String  '无权限字段名
Dim m_sCode As String '存货编码
Dim m_CopycInvCode As String '需要复制的存货编码
Dim m_URL As String
Dim m_bWeb As Boolean
Dim m_UfDbName As String
Dim WithEvents GridFree As VBControlExtender
Attribute GridFree.VB_VarHelpID = -1
Dim WithEvents GridCheckFree As VBControlExtender
Attribute GridCheckFree.VB_VarHelpID = -1
Dim m_bFilling As Boolean       '是否正在填充数据
Dim m_opt As Integer            '操作类型
Dim m_arrFreeDataXml(0 To 9) As String '对应10个自由项取值范围
Dim m_objRef As U8RefService.IService
Dim m_bClicking As Boolean          '是否正点击了自由项取值按钮
Dim m_RefValue As String           '参照返回内容
Dim m_oldArrbControlFreeRangeVal(0 To 9) As Integer


Private Sub ChkbCheckFree_Click(Index As Integer)
    On Error Resume Next '防止gridcheck.colwidth(index)中Index超出范围
    If CheckConfigFree(Index) = False Then Exit Sub
    RaiseEvent ActiveSaveBtn
    If ChkbCheckFree(Index).Value = 1 Then
        If m_arrChkFreeAuthTypeFlds(Index + GridCheck.FixedCols) = "N" Then ' 无权限(N)
            GridCheck.ColWidth(Index + GridCheck.FixedCols) = 0
         Else
            GridCheck.ColWidth(Index + GridCheck.FixedCols) = 1000
        End If
        GridCheck.FixedAlignment(Index + GridCheck.FixedCols) = 4
    Else
        GridCheck.ColWidth(Index + GridCheck.FixedCols) = 0
        GridCheck.FixedAlignment(Index + GridCheck.FixedCols) = 1
    End If
    If ChkbCheckFree(Index).Value = 1 Then
        SSTabBasPart.TabVisible(2) = True
    Else
        Dim i As Integer
        For i = 0 To 9
            If ChkbCheckFree(i).Value = 1 Then
                Exit For
            End If
        Next i
        If i = 10 Then
            SSTabBasPart.TabVisible(2) = False
        End If
    End If
End Sub

Private Sub ChkbPurPriceFree_Click(Index As Integer)
    On Error Resume Next
    If CheckConfigFree(Index) = False Then Exit Sub
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbSalePriceFree_Click(Index As Integer)
    On Error Resume Next
    If CheckConfigFree(Index) = False Then Exit Sub
    RaiseEvent ActiveSaveBtn
End Sub


Private Sub ChkbOMPriceFree_Click(Index As Integer)
    On Error Resume Next
    If CheckConfigFree(Index) = False Then Exit Sub
    RaiseEvent ActiveSaveBtn
End Sub

Private Sub ChkbControlFreeRange_Click(Index As Integer)
    On Error Resume Next
    If CheckConfigFree(Index) = False Then Exit Sub
    RaiseEvent ActiveSaveBtn
    If CmdSetFreeItem(Index).Tag = "readonly" Then
    Else
        CmdSetFreeItem(Index).Enabled = IIf(ChkbControlFreeRange(Index).Value = Checked, True, False)
    End If
End Sub

Private Sub CmdAddCheck_Click()
    Call AddLine(GridCheck)
    Call SetGridColReadOnly(GridCheck, m_arrChkFreeAuthTypeFlds)
End Sub

Private Sub CmdBackCheck_Click()
    Call CancelData(GridCheck)
End Sub

Private Sub CmdDelCheck_Click()
    Call DelLine(GridCheck)
End Sub

Private Sub CmdPosBasPart_Click()
    Call g_oPub.FindPos(Me, grid)
End Sub

Private Sub CmdPosCheck_Click()
    Call g_oPub.FindPos(Me, GridCheck)
End Sub

Private Sub CmdSetFreeItem_Click(Index As Integer)
    On Error GoTo Err_Info
    If m_bClicking = True Then Exit Sub
    m_bClicking = True
    Dim obj As Object
    Set obj = CreateObject("U8InvFreeContrapose.IInvFreeContrapose")
    Dim bSaveData  As Boolean
    Dim sInvDataXml As String
    Dim sFreeDataXml As String
    RaiseEvent GetInvData(sInvDataXml)
    sInvDataXml = "<Inventory>" & sInvDataXml & "</Inventory>"
    sFreeDataXml = m_arrFreeDataXml(Index)
    Call obj.InitObj(g_oPub, m_SrvDB, Nothing)
    Call obj.Operation(m_oLogin, m_opt, m_sCode, Index + 1, bSaveData, sInvDataXml, sFreeDataXml)
    m_arrFreeDataXml(Index) = sFreeDataXml
    Set obj = Nothing
    m_bClicking = False
    Exit Sub
Err_Info:
    Set obj = Nothing
    m_bClicking = False
End Sub
Private Sub Grid_BeforeEdit(Cancel As Boolean, sReturnText As String)
beforeEditText = grid.TextMatrix(grid.Row, grid.Col)
End Sub

Private Sub grid_FillList(ByVal R As Long, ByVal C As Long, pCom As Object)
    Select Case C
        Case 17 + m_FreeColIndex
            pCom.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") '静态
            pCom.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") '动态
        Case 18 + m_FreeColIndex
            pCom.AddItem ""
            pCom.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0")  '天
            pCom.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1")  '周
            pCom.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2")  '月
        Case 20 + m_FreeColIndex
            pCom.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") '覆盖天数
            pCom.AddItem g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1")  '百分比
    End Select
End Sub

Private Sub GridCheck_BrowUser(RetValue As String, ByVal R As Long, ByVal C As Long)
    Call InitRef(0, GridCheck, RetValue, R, C)
End Sub

Private Sub GridCheck_CellDataCheck(RetValue As String, RetState As MsSuperGrid.OpType, ByVal R As Long, ByVal C As Long)
    Call GridCellDataCheck(GridCheck, RetValue, RetState, R, C)
End Sub

Private Sub GridCheck_OnEdit(Editing As Boolean)
    RaiseEvent ActiveSaveBtn
End Sub


Private Sub GridFree_ObjectEvent(Info As EventInfo)
    On Error GoTo Err_Info
    Select Case Info.name
        Case "AfterSort"
            Call WriteGrid(grid)
    End Select
    Exit Sub
Err_Info:
    '不作处理
End Sub

Private Sub GridCheckFree_ObjectEvent(Info As EventInfo)
    On Error GoTo Err_Info
    Select Case Info.name
        Case "AfterSort"
            Call WriteGrid(GridCheck)
    End Select
    Exit Sub
Err_Info:
    '不作处理
End Sub

Private Sub SSTabBasPart_Click(PreviousTab As Integer)
    '防止先选择自由项2，然后选后在Grid或GridCheck参照自由项2，然后选择自由项1，此时Grid增加一项
    '自由项1一列，但自由项2参照按钮仍然在第一列，没有刷新
    If SSTabBasPart.Tab = 1 Then
        grid.Redraw = True
        grid.ProtectUnload
    Else
        GridCheck.ProtectUnload
    End If
End Sub

Private Sub UserControl_Initialize()
    On Error Resume Next
    UserControl.KeyPreview = False
    Dim i As Integer
    For i = 0 To CmdSetFreeItem.UBound
        CmdSetFreeItem(i).Enabled = False
    Next i
End Sub

''---------------------------------------
''功能：弹出浮动菜单，选择排序
''---------------------------------------
'Private Sub GridCheck_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    If GridCheck.MouseCol = 0 Then Exit Sub
'    If Button = 2 Then
'        Call UserControl.Controls("PopMenuMgr").ShowPopupMenu(GridCheck, mOrder.Name, X, Y)
'    End If
'End Sub
'
'Private Sub PopMenuMgr_MenuClick(sMenuKey As String)
'    GridCheck.Col = GridCheck.MouseCol
'    GridCheck.ColSel = GridCheck.MouseCol
'     Select Case LCase(sMenuKey)
'        Case "masc"
'            GridCheck.Sort = 7
'        Case "mdesc"
'            GridCheck.Sort = 8
'    End Select
'End Sub


Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
   If UserControl.Ambient.UserMode = True Then
      UFFrmKeyHook.Attach
   End If
End Sub

Private Sub ChkbConfigFree_Click(Index As Integer)
    On Error Resume Next '防止grid.colwidth(index)中Index超出范围
    If CheckConfigFree(Index) = False Then Exit Sub
    RaiseEvent ActiveSaveBtn
    If ChkbConfigFree(Index).Value = 1 Then
        If m_arrConfigAuthTypeFlds(Index + m_FreeColIndex) = "N" Then ' 无权限(N)
            grid.ColWidth(Index + m_FreeColIndex) = 0
        Else
            grid.ColWidth(Index + m_FreeColIndex) = 1000
        End If
        grid.FixedAlignment(Index + m_FreeColIndex) = 4
    Else
        grid.ColWidth(Index + m_FreeColIndex) = 0
        grid.FixedAlignment(Index + m_FreeColIndex) = 1
    End If
    If ChkbConfigFree(Index).Value = 1 Then
        SSTabBasPart.TabVisible(1) = True
    Else
        Dim i As Integer
        For i = 0 To 9
            If ChkbConfigFree(i).Value = 1 Then
                Exit For
            End If
        Next i
        If i = 10 Then
            SSTabBasPart.TabVisible(1) = False
        End If
    End If
End Sub

'---------------------------------------
'功能：检查结构性自由项
'参数：index：  结构性自由项控件的index
'---------------------------------------
Private Function CheckConfigFree(Index As Integer) As Boolean
    On Error GoTo Err_Info
    If m_bFilling = True Then
        CheckConfigFree = True
        Exit Function
    End If
    If UserControl.ActiveControl Is Nothing Then
        CheckConfigFree = True
        Exit Function
    End If
    CheckConfigFree = False
    m_bFilling = True
    If ChkFree(Index).Value = 0 And (ChkbConfigFree(Index).Value = 1 Or ChkbCheckFree(Index).Value = 1 Or ChkbPurPriceFree(Index).Value = 1 Or ChkbSalePriceFree(Index).Value = 1 Or ChkbOMPriceFree(Index).Value = 1 Or ChkbControlFreeRange(Index).Value = 1) Then
        If UserControl.ActiveControl.name = ChkFree(Index).name Then
            ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cancel_all_free") '"对应的自由项全部被自动取消！"
            ChkbConfigFree(Index).Value = 0
            ChkbCheckFree(Index).Value = 0
            ChkbPurPriceFree(Index).Value = 0
            ChkbSalePriceFree(Index).Value = 0
            ChkbOMPriceFree(Index).Value = 0
            ChkbControlFreeRange(Index).Value = 0
'            If (ChkbConfigFree(index).value = 1) Then
'                ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.66_1") 'U8.AA.U8TABPAGES.FREE.66_1="对应的结构性自由项被自动取消！"
'                ChkbConfigFree(index).value = 0
'            End If
'            If ChkbCheckFree(index).value = 1 Then
'                ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.cancel_check_free") '"对应的核算自由项被自动取消！"
'                ChkbCheckFree(index).value = 0
'            End If
        Else
            ShowMsg g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.68_1") 'U8.AA.U8TABPAGES.FREE.68_1="必须先选择对应的自由项！"
            ChkbConfigFree(Index).Value = 0
            ChkbCheckFree(Index).Value = 0
            ChkbPurPriceFree(Index).Value = 0
            ChkbSalePriceFree(Index).Value = 0
            ChkbOMPriceFree(Index).Value = 0
            ChkbControlFreeRange(Index).Value = 0
        End If
        m_bFilling = False
        Exit Function
    End If
    CheckConfigFree = True
    m_bFilling = False
    Exit Function
Err_Info:
    CheckConfigFree = False
End Function

Private Sub ChkFree_Click(Index As Integer)
    If CheckConfigFree(Index) = False Then Exit Sub
    RaiseEvent ActiveSaveBtn
End Sub

'---------------------------------------
'功能：增加一行
'---------------------------------------
Private Sub CmdAdd_Click()
    Call AddLine(grid)
    Call SetGridColReadOnly(grid, m_arrConfigAuthTypeFlds)
End Sub

'------------------------------------------
'功能：增加一行
'------------------------------------------
Private Sub AddLine(GridCon As SuperGrid, Optional bCopy As Boolean = False)
    Dim i As Integer
    Dim BFree As Boolean '是否有自由项
    Dim R As Long
    BFree = False
    With GridCon
        If bCopy = False Then
            For i = 0 + GridCon.FixedCols To 9 + GridCon.FixedCols
                If .ColWidth(i) > 0 Then
                    BFree = True
                    If .TextMatrix(.Rows - 1, i) = "" Then
                        ReDim g_arr(1 To 1)
                        g_arr(1) = .TextMatrix(0, i)
                        ShowMsg g_oPub.GetResFormatString("U8.AA.ARCHIVE.COMMON.notnull", g_arr) '"不可为空！"
                        Exit Sub
                    End If
                End If
            Next i
        Else
            BFree = True
        End If
        If BFree = False Then
            Exit Sub
        End If
        .Rows = GridCon.Rows + 1
        GridCon.TextMatrix(GridCon.Rows - 1, GridCon.cols - 1) = "insert"
        .Row = GridCon.Rows - 1
        GridCon.TextMatrix(GridCon.Rows - 1, 0) = CStr(GridCon.Rows - 1)
        For i = 0 To GridCon.cols - 1
            If GridCon.ColWidth(i) > 0 Then
                .Col = i
                .LeftCol = 0 'i
                Exit For
            End If
        Next i
        If (.Rows + 1) * .RowHeight(0) >= .Height Then
            .TopRow = 2 + .Rows - (.Height \ .RowHeight(0))
        End If
        R = .Row
        If GridCon.name = grid.name Then '物料档案特殊处理
            If R = 1 Then
                '获取数量数值，待写
                Dim SafeQty As String
                Dim MinQty As String
                Dim MulQty As String
                Dim FixQty As String
                Dim iSurenessType As String
                Dim iDateType As String
                Dim iDynamicSurenessType As String
                Dim sXml As String
                
                'RaiseEvent GetNum(SafeQty, MinQty, MulQty, FixQty)
                RaiseEvent GetInvData(sXml)
                sXml = "<Inventory>" + sXml + "</Inventory>"
                Dim dom As New DOMDocument
                If dom.loadXML(sXml) = True Then
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "MulQty")) = dom.selectSingleNode("Inventory/MulQty").Text ' MulQty
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "SafeQty")) = dom.selectSingleNode("Inventory/SafeQty").Text ' SafeQty
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "fBasMaxSupply")) = dom.selectSingleNode("Inventory/MaxQty").Text ' MinQty
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "MinQty")) = dom.selectSingleNode("Inventory/MinQty").Text ' MinQty
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "FixQty")) = dom.selectSingleNode("Inventory/FixQty").Text 'FixQty
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "cBasEngineerFigNo")) = dom.selectSingleNode("Inventory/cEngineerFigNo").Text
                    
                    If dom.selectSingleNode("Inventory/iSurenessType").Text = 1 Then
                        iSurenessType = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") '"静态"
                    ElseIf dom.selectSingleNode("Inventory/iSurenessType").Text = 2 Then
                        iSurenessType = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") '动态
                    End If
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "iSurenessType")) = iSurenessType ' iSurenessType
                    
                    If dom.selectSingleNode("Inventory/iDateType").Text = 1 Then
                        iDateType = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0") '天
                    ElseIf dom.selectSingleNode("Inventory/iDateType").Text = 2 Then
                        iDateType = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1") '周
                    ElseIf dom.selectSingleNode("Inventory/iDateType").Text = 3 Then
                        iDateType = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2") '月
                    End If
                    
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "iDateType")) = iDateType ' iDateType
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "iDateSum")) = dom.selectSingleNode("Inventory/iDateSum").Text ' iDateSum
                    
                    If dom.selectSingleNode("Inventory/iDynamicSurenessType").Text = 1 Then
                        iDynamicSurenessType = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") '覆盖天数
                    ElseIf dom.selectSingleNode("Inventory/iDynamicSurenessType").Text = 2 Then
                        iDynamicSurenessType = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1") '百分比
                    End If
                    
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "iDynamicSurenessType")) = iDynamicSurenessType ' iDynamicSurenessType
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "iBestrowSum")) = dom.selectSingleNode("Inventory/iBestrowSum").Text 'iBestrowSum
                    .TextMatrix(R, GetCol(m_arrConfigFlds, "iPercentumSum")) = dom.selectSingleNode("Inventory/iPercentumSum").Text 'iPercentumSum
                    
                    
                End If
            ElseIf R > 1 Then
                '制造倍数等信息缺省从存货携带,可以修改.增行时,自动携带上一行的值.
                i = GetCol(m_arrConfigFlds, "MulQty")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "SafeQty")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "fBasMaxSupply")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "MinQty")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "FixQty")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "cBasEngineerFigNo")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                
                i = GetCol(m_arrConfigFlds, "iSurenessType")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "iDateType")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "iDateSum")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "iDynamicSurenessType")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "iBestrowSum")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                i = GetCol(m_arrConfigFlds, "iPercentumSum")
                .TextMatrix(R, i) = .TextMatrix(R - 1, i)
                
            End If
        End If
    End With
End Sub

Private Function GetCol(ArrFlds() As String, fldName As String) As Integer
    Dim i As Integer
    For i = 0 To UBound(ArrFlds)
        If LCase(fldName) = LCase(ArrFlds(i)) Then
            GetCol = i
            Exit Function
        End If
    Next i
    If i = UBound(ArrFlds) + 1 Then
        ReDim g_arr(1 To 1)
        g_arr(1) = fldName
        ShowMsg g_oPub.GetResFormatString("U8.AA.U8TABPAGES.FREE.163_1", g_arr) 'U8.AA.U8TABPAGES.FREE.163_1="查找列{0}不存在！"
    End If
End Function

'---------------------------------------
'功能：删除一行
'---------------------------------------
Private Sub DelLine(GridCon As SuperGrid)
    If GridCon.Row > 0 Then
        ReDim g_arr(1 To 1)
        g_arr(1) = CStr(GridCon.Row)
        
        If g_oPub.MsgBox(g_oPub.GetResFormatString("U8.AA.U8TABPAGES.FREE.174_1", g_arr), vbYesNo + vbExclamation, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then 'U8.AA.U8TABPAGES.FREE.174_1="删除第{0}行？"
            If GridCon.TextMatrix(GridCon.Row, GridCon.cols - 1) <> "insert" Then
                If GridCon.name = "grid" Then
                    Call deleteXmlInsert(True, -1, "")
                Else
                    Call deleteXmlInsert(False, -1, "")
                End If
            End If
            Call GridCon.RemoveItem(GridCon.Row)
            RaiseEvent ActiveSaveBtn
        End If
    End If
    Call WriteGrid(GridCon)
End Sub

Private Sub CmdDel_Click()
    Dim reMsg As String
    Dim i As Integer
    If m_opt = 2 Then
        For i = 0 + grid.FixedCols To grid.cols - 1
            If (LCase(grid.TextMatrix(0, i)) = "partid") Then
                If grid.TextMatrix(grid.Row, i) <> "" Then
                    If CheckRefBasPart(m_SrvDB, grid.TextMatrix(grid.Row, i), 3, reMsg) = False Then
                        ShowMsg reMsg
                        Exit Sub
                        Else
                        Exit For
                    End If
                End If
            End If
        Next i
    End If
    Call DelLine(grid)
End Sub


Private Sub CmdRefresh_Click()
    Call CancelData(grid)
End Sub

'------------------------------------------------
'功能：取消数据
'------------------------------------------------
Private Sub CancelData(GridCon As SuperGrid)
    If Len(m_sCode) = 0 Then
        If grid.Rows > 1 Then
            If g_oPub.MsgBox(g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.191_1"), vbYesNo + vbQuestion, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.exclamation")) = vbYes Then 'U8.AA.U8TABPAGES.FREE.191_1="请问是否删除的所有行数据？"
                grid.Rows = 1
            End If
        End If
    Else
        Call FillAllGrid(GridCon.name)
    End If
End Sub

Private Sub grid_BrowUser(RetValue As String, ByVal R As Long, ByVal C As Long)
    Call InitRef(0, grid, RetValue, R, C)
End Sub

'--------------------------------------------------------------
'功能：初始化参照
'参数:iMode:0：点击参照Btn的Click事件；1：填写的的数据，然后看看是否唯一；
'--------------------------------------------------------------
Private Sub InitRef(iMode As Integer, GridCon As SuperGrid, RetValue As String, ByVal R As Long, ByVal C As Long, Optional RstGrid As ADODB.Recordset)
    On Error GoTo Err_Info
    Dim sCode As String
    Dim sName As String
    Dim bReturn As Boolean
    Dim strClass As String
    Dim strGrid As String
    Dim RstClass As ADODB.Recordset
    Dim sField As ADODB.Field
    Dim cID As String
    Select Case C
        Case 1, 2
            cID = CStr(19 + C)
        Case Else
            cID = CStr(27 + C - 2)
    End Select
    If m_objRef Is Nothing Then
        Set m_objRef = New U8RefService.IService
    End If
'    Dim sXMLFilterPara As String
'    sXMLFilterPara = "<RefConditions>"
'    sXMLFilterPara = sXMLFilterPara + "<Condition paramName='@cID' paramValue='" + cID + "' />"
'    sXMLFilterPara = sXMLFilterPara + "</RefConditions>"
    Dim sMetaXML As String
    Dim cRefFilterSql As String
    If m_opt = 1 Then
        If Len(m_arrFreeDataXml(C - 1)) > 0 Then
            cRefFilterSql = "cValue in " + GetcRefFilterSql(m_arrFreeDataXml(C - 1))
        End If
    End If
    sMetaXML = "<Ref><RefSet bMultiSel= '" + IIf(iMode = 0, "1", "0") + "'  /></Ref>"
    
    Dim sXml As String
    
    Dim sErrMsg As String
'    sXml = "<refclient>" & vbCrLf & _
'            "<refid>" + m_URL + "UserdefFreeRef_AA</refid>" & vbCrLf & _
'            "<parammeta>" + sMetaXML + "</parammeta>" & vbCrLf & _
'            "<imode>" + CStr(iMode) + "</imode>" & vbCrLf & _
'            "<bweb>" + IIf(m_bWeb = True, "1", "0") + "</bweb>" & vbCrLf & _
'            "<filltext>" + gridCon.TextMatrix(R, C) + "</filltext>" & vbCrLf & _
'            "<filterxml>" + sXMLFilterPara + "</filterxml>" & vbCrLf & _
'        "</refclient>"
    
    m_objRef.MetaXML = sMetaXML
    m_objRef.RefID = m_URL + cID
    m_objRef.IsUserDefArch = True
    m_objRef.Mode = iMode
    m_objRef.Web = m_bWeb
    m_objRef.FillText = GridCon.TextMatrix(R, C)
    m_objRef.FilterSQL = ""
    m_objRef.FilterXMLPara = ""
    If m_opt = 2 Then
        If ChkbControlFreeRange(C - 1).Value = Checked And m_oldArrbControlFreeRangeVal(C - 1) = 1 Then
            m_objRef.FilterXMLPara = "<RefConditions><Condition paramName='@@cInvCode'  paramValue='" + m_sCode + "'/></RefConditions>"
        ElseIf ChkbControlFreeRange(C - 1).Value = Checked And m_oldArrbControlFreeRangeVal(C - 1) = 0 Then
            m_objRef.FilterSQL = "cValue in (select cUDValue from AA_InvFreeContrapose where cUDId=N'" + cID + "' and cInvcode=N'" + m_sCode + "')"
        Else
            '不作处理，直接调用自定义项参照
        End If
    Else
        If Len(m_CopycInvCode) > 0 And Len(cRefFilterSql) = 0 Then '点击存货复制按钮,且没有修改自由项取值范围
            If ChkbControlFreeRange(C - 1).Value = Checked Then
                m_objRef.FilterSQL = "cValue in (select cUDValue from AA_InvFreeContrapose where cUDId=N'" + cID + "' and cInvcode=N'" + m_CopycInvCode + "')"
            Else
                '不作处理，直接调用自定义项参照
            End If
        Else
            m_objRef.FilterSQL = cRefFilterSql
        End If
    End If

'    If showRef(m_oLogin, sXml, RstGrid, sErrMsg) = False Then
'        ShowMsg sErrMsg
    If m_objRef.ShowRef(m_oLogin, RstClass, RstGrid, sErrMsg) = False Then
        If iMode = 0 Then
            ShowMsg sErrMsg
        End If
    Else
        If Not (RstGrid Is Nothing) Then
            If RstGrid.RecordCount > 0 Then
                RetValue = TxtValue(RstGrid.fields("cValue").Value)
                GridCon.TextMatrix(R, C) = RetValue
                m_RefValue = RetValue
                If iMode = 0 Then
                    RstGrid.MoveNext
                End If
            End If
            If iMode = 0 Then
            Dim NewRow As Long
                While Not RstGrid.EOF
                    Call CopyRow(GridCon, R, NewRow)
                    GridCon.TextMatrix(NewRow, C) = TxtValue(RstGrid.fields("cValue").Value)
                    RstGrid.MoveNext
                Wend
            End If
        End If
    End If
    Exit Sub
Err_Info:
    ShowMsg Err.Description
End Sub

Private Function GetcRefFilterSql(ByVal sXml As String) As String
    On Error GoTo Err_Info
    sXml = "<data>" + sXml + "</data>"
    Dim dom As New DOMDocument
    Dim NdLst As IXMLDOMNodeList
    Dim ele As IXMLDOMElement
    Dim sFreeRange As String
    If dom.loadXML(sXml) = True Then
        Set NdLst = dom.selectNodes("data/AA_InvFreeContrapose") '注意存货自由项给出的XML大小写不能随意更改
        For Each ele In NdLst
            sFreeRange = sFreeRange & "'" & ele.selectSingleNode("cUDValue").Text & "',"
        Next
        If Len(sFreeRange) > 0 Then
            sFreeRange = "(" & Left(sFreeRange, Len(sFreeRange) - 1) & ")"
        End If
    End If
    GetcRefFilterSql = sFreeRange
    Set dom = Nothing
    Exit Function
Err_Info:
    '不做处理
End Function

''--------------------------------------------------------
''功能：显示参照
''--------------------------------------------------------
'Private Function showRef(oLogin As Variant, sXml As String, retRst As ADODB.Recordset, Optional ByRef sErrMsg As String) As Boolean
'    Dim var As Object
'    Dim obj As Object
'    Set obj = CreateObject("U8RefC.RefClient")
'    If obj.Show(oLogin, sXml, var) = True Then
'        Set retRst = var.m_retRstGrid
'        showRef = True
'    Else
'        sErrMsg = var.m_ErrDescription
'    End If
'End Function

Private Sub CopyRow(oGrid As Object, ByRef oRow As Long, ByRef NewRow As Long)
    On Error GoTo Err_Info
        Call AddLine(oGrid, True)
        Dim i As Integer
        NewRow = oGrid.Rows - 1
        For i = 0 + oGrid.FixedCols To oGrid.cols - 1
            Select Case LCase(oGrid.TextMatrix(0, i))
                Case "partid", "invchkfreeguid"
                    'partid不能拷贝，否则该条记录不断被修改
                Case Else
                    oGrid.TextMatrix(NewRow, i) = oGrid.TextMatrix(oRow, i)
            End Select
        Next i
    Exit Sub
Err_Info:
    
End Sub

Private Sub grid_CellDataCheck(RetValue As String, RetState As MsSuperGrid.OpType, ByVal R As Long, ByVal C As Long)
    Call GridCellDataCheck(grid, RetValue, RetState, R, C)
End Sub

Private Sub GridCellDataCheck(GridCon As SuperGrid, RetValue As String, RetState As MsSuperGrid.OpType, ByVal R As Long, ByVal C As Long)
    Dim RstGrid As ADODB.Recordset
    Select Case C
        Case m_FreeColIndex To m_FreeColIndex + 9
            RetValue = Trim(RetValue)
            If Len(RetValue) > 0 And m_RefValue <> RetValue Then
                Dim Index As Integer
                Index = C - m_FreeColIndex + 1
                Dim bArchive As Boolean '是否建档
                Dim strSql As String
                Dim Rs As New ADODB.Recordset
                strSql = "select cID,bCheckVal,bArchive from Userdef where cClass='存货' and cItem='自由项" + CStr(Index) + "'"  'and bArchive=0
                Set Rs = m_SrvDB.OpenX(strSql)
                If Rs.RecordCount = 1 Then
                    bArchive = IIf(TxtValue(Rs!bArchive, False), True, False)
'                    strSql = "select top 1 cValue from userdefine where cId='" + TxtValue(Rs!cID) + "'" + _
'                    " and (cvalue='" + RetValue + "' or  Calias='" + RetValue + "')"
'                    Set Rs = m_SrvDB.OpenX(strSql)
                    '
                    If bArchive = False Then '建档无需检查
                        Call InitRef(1, GridCon, "", R, C, RstGrid)
                    End If
                    Dim bExist As Boolean
                    bExist = True
                    If RstGrid Is Nothing Then
                        bExist = False
                    ElseIf RstGrid.RecordCount = 0 Then
                        bExist = False
                    Else
                    End If
                    If bExist = False Then
                        If bArchive = False Then
                            ShowMsg g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.no_define_val") 'grid.TextMatrix(0, C) + "档案没有该值！"
                            RetState = dbRetry
                        End If
                    Else
                        If bArchive = False Then
                            RetValue = TxtValue(RstGrid!cValue)
                        End If
                    End If
                End If
            End If
            If beforeEditText <> "" Then
                If (GridCon.TextMatrix(R, GridCon.cols - 1) <> "insert") Then
                    If RetState <> dbRetry And beforeEditText <> RetValue Then
                        '设置更新update
                        GridCon.TextMatrix(R, GridCon.cols - 1) = "update"
                    End If
                End If
            End If
        Case Else
    End Select
    With GridCon
        If .ColDataType(C) = EditDbl Then
            If GridCon.name = grid.name Then
                RetValue = g_oPub.FormatNum(.TextMatrix(R, C), grid.ColPoint(C))
            Else
                RetValue = g_oPub.FormatNum(.TextMatrix(R, C), grid.ColPoint(C))
            End If
            .TextMatrix(R, C) = RetValue
            If (.TextMatrix(R, .cols - 1) <> "insert") Then
                .TextMatrix(R, .cols - 1) = "update"
            End If

        End If
        If C > m_FreeColIndex + 9 And (.ColDataType(C) = EditNormal Or .ColDataType(C) = EditLng) Then
            .TextMatrix(R, C) = RetValue
            If (.TextMatrix(R, .cols - 1) <> "insert") Then
                .TextMatrix(R, .cols - 1) = "update"
            End If

        End If
    End With
End Sub

Private Sub Grid_Click()
    SetGridReadOnly
End Sub

Private Sub SetGridReadOnly()
    On Error GoTo Err_Info
    If UserControl.ActiveControl.name = grid.name Then
        If LCase(grid.TextMatrix(0, grid.Col)) = "partid" Then
            grid.ReadOnly = True
        Else
            grid.ReadOnly = False
        End If
    End If
    Exit Sub
Err_Info:
    
End Sub

Private Sub grid_OnEdit(Editing As Boolean)
    RaiseEvent ActiveSaveBtn
    m_RefValue = ""
End Sub



Private Sub UFFrmKeyHook_ContainerKeyDown(KeyCode As Integer, ByVal Shift As Integer)
    On Error Resume Next
    
    If UserControl.ActiveControl Is Nothing Then Exit Sub
    If g_oPub.ConKeyDown(UserControl.ActiveControl, KeyCode, Shift) = True Then
        RaiseEvent ActiveSaveBtn
    End If
    If UserControl.ActiveControl Is grid Or UserControl.ActiveControl Is GridCheck Then
        If (KeyCode = vbKeyI And Shift = 2) Then  ' 不要KeyCode = vbKeyF5 Or
            Call AddLine(UserControl.ActiveControl)
        ElseIf (KeyCode = vbKeyD And Shift = 2) Then 'KeyCode = vbKeyDelete
            Call DelLine(UserControl.ActiveControl)
        ElseIf KeyCode = vbKeyReturn Then
            If (grid.Col = grid.cols - 1) Then
                Call AddLine(UserControl.ActiveControl)
                SendKeys "{LEFT}"
            End If
        End If
    End If
End Sub

Private Sub UFFrmKeyHook_ContainerKeyPress(KeyAscii As Integer)
    On Error Resume Next
    
    If UserControl.ActiveControl Is Nothing Then Exit Sub
    If KeyAscii = 13 Then
        If TypeOf UserControl.ActiveControl Is Edit Or TypeOf UserControl.ActiveControl Is EDITLib.Edit Or TypeOf UserControl.ActiveControl Is UFCOMBOBOXLib.UFComboBox Or TypeOf UserControl.ActiveControl Is UFCHECKBOXLib.UFCheckBox Then
            SendKeys "{TAB}"
        End If
    Else
        SetGridReadOnly
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

Public Function Init870(oLogin As Object, SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Set m_oLogin = oLogin
    Init870 = Init(SrvDB, oPub, sXml)
End Function

'--------------------------------
'功能：根据数据初始化界面(规定接口)
'参数：
'   SrvDb:      数据服务对象
'   oPub:       公共函数对象
'   sXml:       各种数据
'--------------------------------
Public Function Init(SrvDB As Object, oPub As Object, sXml As String) As Boolean
    Init = False
    Dim i As Integer
    Dim sTemp As String
    
    On Error GoTo Err_Info
    Set g_oPub = oPub
    Set m_SrvDB = SrvDB
    Call g_oPub.UtoLCase(sXml)
    m_iQuanDecDgt = CInt(GetParaVal(sXml, "g_iQuanDecDgt", "2"))
    m_iPriceDecDgt = CInt(GetParaVal(sXml, "g_iPriceDecDgt", "2"))
    m_URL = GetParaVal(sXml, "url")
    m_bWeb = IIf(GetParaVal(sXml, "bweb") = "1", True, False)
    m_UfDbName = GetParaVal(sXml, "ufdbname")
    'Call g_oPub.UCtrlLayout(GetControls, "U8.AA.ARCHIVE.TABPAGES.InvFree")
    '下面英文取消，否则界面乱
'    If LCase(g_oPub.m_LocaleID) = "en-us" Then
'        Call UserControl_Resize
'        SSTabBasPart.width = 30000
'        SSTabBasPart.Height = 30000
'    End If
    
    InitFace
    InitSelf '必须放到InitFace之后
    
    SSTabBasPart.TabCaption(0) = g_oPub.SetTabCaption(Nothing, g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.free"), SSTabBasPart, True, 0, PicTab)  '
    SSTabBasPart.TabCaption(1) = g_oPub.SetTabCaption(Nothing, g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.baspart"), SSTabBasPart, True, 1, PicTab)  '
    SSTabBasPart.TabCaption(2) = g_oPub.SetTabCaption(Nothing, g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.accounting"), SSTabBasPart, True, 2, PicTab)  '
    
    LblFree.Caption = g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.free") '
    LblConfigFree.Caption = g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.bconfigfree") '
    lblAccoutingFree.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.is_accounting") '
    lblbPurPriceFree.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.bpurpricefree")
    lblbSalePriceFree.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.bsalepricefree")
    LblbOMPriceFree.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.bompricefree")
    LblbControlFreeRange.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.bcontrolfreerange")

    
    CmdRefresh.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.undo") '
    CmdAdd.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.addrow") '
    CmdDel.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.delrow") '
    CmdBackCheck.Caption = CmdRefresh.Caption
    CmdAddCheck.Caption = CmdAdd.Caption
    CmdDelCheck.Caption = CmdDel.Caption
    CmdPosBasPart.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.TOOLBAR.pos") '
    CmdPosCheck.Caption = g_oPub.GetResString("U8.AA.ARCHIVE.TOOLBAR.pos") '
    sTemp = g_oPub.GetResString("U8.AA.ARCHIVE.BUTTON.getvalue") '
    For i = 0 To 9
        CmdSetFreeItem(i).Caption = sTemp
    Next
    
'    index = 0
'    If InitAcc() = False Then Exit Function
    
    Init = True
    Exit Function
Err_Info:
    Init = False
End Function

'---------------------------------------------
'功能：初始化界面：字体、禁用字符
'参数：无
'---------------------------------------------
Private Sub InitFace()
    Dim Con As Control
    On Error Resume Next
    SSTabBasPart.Tab = 0
    SSTabBasPart.TabVisible(1) = False
    SSTabBasPart.TabVisible(2) = False
    With UserControl
        For Each Con In .Controls
            If Not (TypeOf Con Is Line) Then
                Con.Font.name = g_oPub.FontName ' "宋体" '"MS Sans Serif" '
                Con.Font.Size = g_oPub.FontSize ' 9 '小五号字
                Con.Font.Charset = g_oPub.FontCharSet ' 134
                'Con.Font.Weight = 400
            End If
            If TypeOf Con Is Edit Or LCase(Left(Con.name, 3)) = "edt" Then
                'Con.BadStr = g_oPub.BadStr
                If Con.Property = EditStr Then
                   Con.Property = EditNormal '允许输入空格
                End If
            ElseIf TypeOf Con Is SuperGrid Then
                'Con.SetFilterString (g_oPub.BadStr)
            End If
        Next
    End With
    
    Dim strSql As String
    Dim i As Integer
    Dim j As Integer
    
    Dim Rs As ADODB.Recordset
    Dim tRs As ADODB.Recordset
    m_bShow = False
    strSql = "select * from userdef where cClass='存货'"
    Set Rs = m_SrvDB.OpenX(strSql)
        For i = 0 To ChkFree.UBound
        Set tRs = Filter(Rs, "CItem='自由项" + CStr(i + 1) + "'")
        If TxtValue(tRs!cItemName) <> "" Then
            ChkFree(i).Caption = TxtValue(tRs!cItemName)
            m_bShow = True
        Else
            ChkFree(i).Visible = False
            For j = ChkFree.UBound To i + 1 Step -1
                ChkFree(j).Left = ChkFree(j - 1).Left
                ChkFree(j).Top = ChkFree(j - 1).Top
                LineLevel(j).Y1 = LineLevel(j - 1).Y1
                LineLevel(j).Y2 = LineLevel(j).Y1
            Next j
            ChkbConfigFree(i).Visible = False
            ChkbCheckFree(i).Visible = False
            ChkbPurPriceFree(i).Visible = False
            ChkbSalePriceFree(i).Visible = False
            ChkbOMPriceFree(i).Visible = False
            ChkbControlFreeRange(i).Visible = False
            CmdSetFreeItem(i).Visible = False
            LineLevel(i).Visible = False
        End If
        ChkbConfigFree(i).Top = ChkFree(i).Top
        ChkbCheckFree(i).Top = ChkFree(i).Top
        ChkbPurPriceFree(i).Top = ChkFree(i).Top
        ChkbSalePriceFree(i).Top = ChkFree(i).Top
        ChkbOMPriceFree(i).Top = ChkFree(i).Top
        ChkbControlFreeRange(i).Top = ChkFree(i).Top
        CmdSetFreeItem(i).Top = ChkFree(i).Top - 4 * Screen.TwipsPerPixelY
        'test
        'ChkbConfigFree(i).UToolTipText = g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.405_1") + "(" + CStr(i) + ")" 'U8.AA.U8TABPAGES.FREE.405_1="结构性"
    Next i
    For i = 0 To ChkFree.UBound
        ChkFree(i).UToolTipText = IIf(g_oPub.GetStrLen(ChkFree(i).Caption, "", 0) > 8 * 2, ChkFree(i).Caption, "")
    Next i
    If g_oPub.GetSysStart("ia", m_UfDbName, m_SrvDB) = False Then
        For i = 0 To ChkbCheckFree.UBound
            ChkbCheckFree(i).Visible = False
        Next i
        lblAccoutingFree.Visible = False
    End If
'    Call UserControl.Controls.Add("cPopMenu6.PopMenu", "PopMenuMgr")
'    Call UserControl.Controls("PopMenuMgr").SubClassMenu(Me)
'    UserControl.Controls("PopMenuMgr").Caption("morder") = g_oPub.GetResString("U8.AA.ARCHIVE.MENU.morder")
'    UserControl.Controls("PopMenuMgr").Caption("masc") = g_oPub.GetResString("U8.AA.ARCHIVE.MENU.masc")
'    UserControl.Controls("PopMenuMgr").Caption("mdesc") = g_oPub.GetResString("U8.AA.ARCHIVE.MENU.mdesc")
End Sub


'-----------------------------------------
'功能：自身初始化
'
'-----------------------------------------
Private Function InitSelf() As Boolean
    InitSelf = False
    On Error GoTo Err_Info
    Dim i As Integer
    Dim sXml As String
    Dim ele As IXMLDOMElement
    Dim Width As String
    Dim sTemp As String
    
    
    sXml = "<DecDgtStyle>"
    sXml = sXml + "<MulQty>" + CStr(m_iQuanDecDgt) + "</MulQty>"
    sXml = sXml + "<SafeQty>" + CStr(m_iQuanDecDgt) + "</SafeQty>"
    sXml = sXml + "<fBasMaxSupply>" + CStr(m_iQuanDecDgt) + "</fBasMaxSupply>"
    sXml = sXml + "<MinQty>" + CStr(m_iQuanDecDgt) + "</MinQty>"
    sXml = sXml + "<FixQty>" + CStr(m_iQuanDecDgt) + "</FixQty>"
    sXml = sXml + "<fInvRCost>" + CStr(m_iPriceDecDgt) + "</fInvRCost>"
    sXml = sXml + "<iBestrowSum>3</iBestrowSum>"
    sXml = sXml + "<iPercentumSum>3</iPercentumSum>"
    sXml = sXml + "</DecDgtStyle>"
    Call g_oPub.UtoLCase(sXml)
    If m_Dom.loadXML(sXml) = False Then
        g_oPub.GetResString ("U8.AA.ARCHIVE.COMMON.xmlloaderror") 'XML加载错误！
    Else
        Set m_EleStyle = m_Dom.documentElement
    End If
    
    sXml = "<Inventory>"
    'ColDataType='0' 字符串 ;1：Double;2:long
    m_FreeColIndex = 1
    sXml = sXml + "<iNo  Width='500' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.serialnumber") + "' ColDataType='2' ColTextWidth='16' ColPoint='' bRef='0'/>"
    For i = 0 To 9
        sXml = sXml + "<Free" + CStr(i + 1) + " AuthFld='bConfigFree" + CStr(i + 1) + "' Width='" + IIf(ChkbConfigFree(i).Value = 1, "1000", "0") + "' Value='' ChName='" + ChkFree(i).Caption + "' ColDataType='0' ColTextWidth='20' bRef='1' MustInput='1' BadStrException='&amp;""|' />"
    Next i
    sXml = sXml + "<PartID  Width='0' Value='' ChName='PartID' ColDataType='2' ColTextWidth='16' ColPoint='' bRef='0'/>"
    '供应倍数
    '安全库存
    '最低供应量
    '固定供应量
    sXml = sXml + "<MulQty AuthFld='fSupplyMulti' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.mulqty") + "' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
    sXml = sXml + "<SafeQty AuthFld='iSafeNum' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.safeqty") + "' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
    sXml = sXml + "<fBasMaxSupply AuthFld='fMaxSupply' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.fmaxsupply") + "' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
    sXml = sXml + "<MinQty AuthFld='fMinSupply' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.minqty") + "' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
    sXml = sXml + "<FixQty AuthFld='iInvBatch' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.U8TABPAGES.FREE.fixqty") + "' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iQuanDecDgt) + "' bRef='0'/>"
    sXml = sXml + "<cBasEngineerFigNo AuthFld='cEngineerFigNo' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.cengineerfigno") + "' ColDataType='0' ColTextWidth='60'  BadStrException='&amp;""|' />"
    
    sXml = sXml + "<iSurenessType AuthFld='iSurenessType' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.isurenesstype") + "' ColDataType='0' ColTextWidth='60'  BadStrException='&amp;""|' bRef='2'/>"
    sXml = sXml + "<iDateType AuthFld='iDateType' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.idatetype") + "' ColDataType='0' ColTextWidth='60'  BadStrException='&amp;""|' bRef='2' />"
    sXml = sXml + "<iDateSum  AuthFld='iDateSum' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.idatesum") + "' ColDataType='2' ColTextWidth='3' ColPoint='0' bRef='0'/>"
    sXml = sXml + "<iDynamicSurenessType AuthFld='iDynamicSurenessType' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.idynamicsurenesstype") + "' ColDataType='0' ColTextWidth='60'  BadStrException='&amp;""|' bRef='2' />"
    sXml = sXml + "<iBestrowSum AuthFld='iBestrowSum' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.ibestrowsum") + "' ColDataType='1' ColTextWidth='7' ColPoint='3' bRef='0'/>"
    sXml = sXml + "<iPercentumSum AuthFld='iPercentumSum' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.ipercentumsum") + "' ColDataType='1' ColTextWidth='7' ColPoint='3' bRef='0'/>"
    
    sXml = sXml + "</Inventory>"
    Call InitGrid(g_oPub, grid, sXml, m_arrConfigFlds, m_arrConfigAuthFlds, sBaspartFlds)
    ReDim m_arrConfigAuthTypeFlds(0 To UBound(m_arrConfigAuthFlds))
    sBaspartFlds = Right(sBaspartFlds, Len(sBaspartFlds) - 4) '去掉序号iNO，
    '注意：此处若修改变量字段sBaspartFlds顺序、增减,必须同时修改服务段端clsCommon.cls文件sBaspartFlds变量保持一致，否则日志无法还原
    grid.AddDisColor g_oPub.UnEditedColor
    grid.FixedCols = 1
    
    Set GridFree = grid.GetGridBody
    GridFree.ExplorerBar = 5 'flexExSortShow
    
    sXml = "<Inventory>"
    'ColDataType='0' 字符串 ;1：Double;2:long
    sXml = sXml + "<iNo  Width='500' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.serialnumber") + "' ColDataType='2' ColTextWidth='16' ColPoint='' bRef='0'/>"
    For i = 0 To 9
        sXml = sXml + "<cFree" + CStr(i + 1) + "  AuthFld='bCheckFree" + CStr(i + 1) + "' Width='" + IIf(ChkbCheckFree(i).Value = 1, "1000", "0") + "' Value='' ChName='" + ChkFree(i).Caption + "' ColDataType='0' ColTextWidth='20' bRef='1' MustInput='1' BadStrException='&amp;""|' />"
    Next i
    sXml = sXml + "<InvChkFreeGUID  Width='0' Value='' ChName='InvChkFreeGUID' ColDataType='0' ColTextWidth='200' ColPoint='' bRef='0'/>"
    sXml = sXml + "<fInvRCost   AuthFld='iInvRCost' Width='' Value='' ChName='" + g_oPub.GetResString("U8.AA.ARCHIVE.FIELD.iinvrcost") + "' ColDataType='1' ColTextWidth='16' ColPoint='" + CStr(m_iPriceDecDgt) + "' bRef='0'/>"
    sXml = sXml + "</Inventory>"
    Call InitGrid(g_oPub, GridCheck, sXml, m_arrChkFreeFlds, m_arrChkFreeAuthFlds, sCheckFreeFlds)
    ReDim m_arrChkFreeAuthTypeFlds(0 To UBound(m_arrChkFreeAuthFlds))
    sCheckFreeFlds = Right(sCheckFreeFlds, Len(sCheckFreeFlds) - 4) '去掉序号iNO，
    '注意：此处若修改变量字段sCheckFreeFlds顺序、增减,必须同时修改服务段端clsCommon.cls文件sCheckFreeFlds变量保持一致，否则日志无法还原
    GridCheck.AddDisColor g_oPub.UnEditedColor
    GridCheck.FixedCols = 1
    Set GridCheckFree = GridCheck.GetGridBody
    GridCheckFree.ExplorerBar = 5 'flexExSortShow
    InitSelf = True
    Exit Function
Err_Info:
    InitSelf = False
    ShowMsg Err.Description
End Function




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
    Dim sDef As String
    Dim i As Integer
    For i = 0 To ChkFree.UBound
        sDef = "bFree" + CStr(i + 1)
        Call ConSet(ChkFree(i), sDef)
        sDef = "bConfigFree" + CStr(i + 1)
        Call ConSet(ChkbConfigFree(i), sDef)
        sDef = "bCheckFree" + CStr(i + 1)
        Call ConSet(ChkbCheckFree(i), sDef)
        sDef = "bPurPriceFree" + CStr(i + 1)
        Call ConSet(ChkbPurPriceFree(i), sDef)
        sDef = "bSalePriceFree" + CStr(i + 1)
        Call ConSet(ChkbSalePriceFree(i), sDef)
        sDef = "bOMPriceFree" + CStr(i + 1)
        Call ConSet(ChkbOMPriceFree(i), sDef)
        sDef = "bControlFreeRange" + CStr(i + 1)
        Call ConSet(ChkbControlFreeRange(i), sDef)
    Next i
    Call SetGridConSet(grid, m_arrConfigAuthFlds, m_arrConfigAuthTypeFlds, sRFldAuthInv, sNFldAuthInv)
    Call SetGridConSet(GridCheck, m_arrChkFreeAuthFlds, m_arrChkFreeAuthTypeFlds, sRFldAuthInv, sNFldAuthInv)
End Sub

'设置GridCon权限
Private Sub SetGridConSet(GridCon As SuperGrid, ArrAuthFlds() As String, ArrAuthTypeFlds() As String, ByVal sRFldAuthInv As String, ByVal sNFldAuthInv As String)
    Dim i As Integer
    sRFldAuthInv = sRFldAuthInv + ","
    sNFldAuthInv = sNFldAuthInv + ","
    For i = 0 To UBound(ArrAuthFlds)
        If Len(ArrAuthFlds(i)) > 0 Then
            If InStr(1, sNFldAuthInv, LCase(ArrAuthFlds(i))) > 0 Then
                GridCon.ColWidth(i) = 0
                ArrAuthTypeFlds(i) = "N"
            ElseIf InStr(1, sRFldAuthInv, LCase(ArrAuthFlds(i))) > 0 Then
                ArrAuthTypeFlds(i) = "R"
            End If
        End If
    Next i
End Sub

'设置Grid只读权限列
Private Sub SetGridColReadOnly(GridCon As SuperGrid, arrAuthType() As String)
    Dim i As Long
    Dim j As Integer
    For j = 1 To GridCon.cols - 2
        If arrAuthType(j) = "R" Then
            GridCon.Col = j
            For i = 1 To GridCon.Rows - 1
                GridCon.Row = i
                GridCon.CellBackColor = g_oPub.UnEditedColor
            Next i
        End If
    Next j
End Sub


'---------------------------------------
'功能：清空编辑框和CheckBox、comboBox框等(规定接口)
'---------------------------------------
Public Sub EmptyAllFields()
    m_CopycInvCode = ""
    ClearFirstConfig
    Dim Con As Control
    For Each Con In Controls
        If TypeOf Con Is Edit Then
            Con.Text = ""
            Con.UToolTipText = ""
            Con.Tag = ""
        ElseIf TypeOf Con Is UFCHECKBOXLib.UFCheckBox Then
            Con.Value = 0
        ElseIf TypeOf Con Is UFCOMBOBOXLib.UFComboBox Then
            Con.ListIndex = -1
        ElseIf TypeOf Con Is RefEdit Then
            Con.Clear
        End If
        If TypeOf Con Is SuperGrid Then Con.Rows = 1
    Next Con
    Call ClearFreeDataXml
End Sub

'-----------------------------------------
'功能：拷贝时部分字段内容操作
'-----------------------------------------
Public Sub CopyOpera()
    m_CopycInvCode = m_sCode
    Call ClearFreeDataXml
    Call SetGridInsertState
End Sub

Private Sub ClearFreeDataXml()
    m_opt = 1
    m_sCode = ""
    Dim i As Integer
    For i = 0 To 9
        m_arrFreeDataXml(i) = ""
    Next i
End Sub

'-----------------------------------
'功能：清除结构性自由项
'-----------------------------------
Private Sub ClearFirstConfig()
    Dim i As Long
    For i = 0 To 9
        ChkbCheckFree(i).Value = 0
        ChkbConfigFree(i).Value = 0 '防止先清除自由项导致ChkbFree消息提示
        ChkbCheckFree(i).Value = 0
        ChkbPurPriceFree(i).Value = 0
        ChkbSalePriceFree(i).Value = 0
        ChkbOMPriceFree(i).Value = 0
        ChkbControlFreeRange(i).Value = 0
    Next i
End Sub

Public Sub FillAllFieldsEx(RsCard As ADODB.Recordset, Optional icallType As Integer = 0, Optional objLog As Object)
    On Error Resume Next
    m_bFilling = True
    m_CopycInvCode = ""
    ClearFirstConfig
    Dim i As Long
    Dim sDef As String
    
    For i = 0 To ChkFree.UBound
        sDef = "bFree" + CStr(i + 1)
        ChkFree(i).Value = ChkValue(RsCard.fields(sDef).Value)
        sDef = "bConfigFree" + CStr(i + 1)
        ChkbConfigFree(i).Value = ChkValue(RsCard.fields(sDef).Value)
        sDef = "bCheckFree" + CStr(i + 1)
        ChkbCheckFree(i).Value = ChkValue(RsCard.fields(sDef).Value)
        sDef = "bPurPriceFree" + CStr(i + 1)
        ChkbPurPriceFree(i).Value = ChkValue(RsCard.fields(sDef).Value)
        sDef = "bSalePriceFree" + CStr(i + 1)
        ChkbSalePriceFree(i).Value = ChkValue(RsCard.fields(sDef).Value)
        sDef = "bOMPriceFree" + CStr(i + 1)
        ChkbOMPriceFree(i).Value = ChkValue(RsCard.fields(sDef).Value)
        sDef = "bControlFreeRange" + CStr(i + 1)
        ChkbControlFreeRange(i).Value = ChkValue(RsCard.fields(sDef).Value)
        m_oldArrbControlFreeRangeVal(i) = ChkbControlFreeRange(i).Value
    Next i
    m_sCode = TxtValue(RsCard!cinvcode)
    m_opt = 2
    Call FillAllGrid("", icallType, objLog)
    m_bFilling = False
    Call SetGridColReadOnly(grid, m_arrConfigAuthTypeFlds)
    Call SetGridColReadOnly(GridCheck, m_arrChkFreeAuthTypeFlds)
End Sub
'-----------------------------------------------
'功能：完成填充所有字段内容的过程(规定接口)
'传入的参数：RsCard：需求填写的数据源（数据集）
'------------------------------------------------
Public Sub FillAllFields(RsCard As ADODB.Recordset)
    Call FillAllFieldsEx(RsCard)
End Sub


Private Sub FillAllGrid(Optional ByVal conName As String, Optional icallType As Integer, Optional objLog As Object)
    Dim strSql As String
    Dim i As Integer
    Dim lCount As Integer
    Dim Rs As ADODB.Recordset
    If conName = grid.name Or Len(conName) = 0 Then
        If icallType = 4 Then
            Set Rs = objLog.GetRecordset("bas_part")
        Else
            strSql = "select " + sBaspartFlds + " from bas_part where InvCode ='" + m_sCode + "' and  bVirtual=0"
            Set Rs = m_SrvDB.OpenX(strSql)
        End If
        Call FillGridCon(grid, Rs)
    End If
    If conName = GridCheck.name Or Len(conName) = 0 Then
        If icallType = 4 Then
            Set Rs = objLog.GetRecordset("InvCheckFree")
        Else
            strSql = "select " + sCheckFreeFlds + " from InvCheckFree where cInvCode ='" + m_sCode + "'"
            Set Rs = m_SrvDB.OpenX(strSql)
        End If
        Call FillGridCon(GridCheck, Rs)
    End If
End Sub



'---------------------------------------------------
'功能：对Grid控件加载数据
'---------------------------------------------------
Private Sub FillGridCon(GridCon As SuperGrid, Rs As ADODB.Recordset)
    Dim i As Long
    Dim j As Integer
    Dim nFldCount  As Integer
    Dim sValue As String
    
    GridCon.Redraw = False  ' 消除抖动。
    GridCon.Rows = 1 '先清空上次数据
    If Rs.RecordCount > 0 Then
        GridCon.Rows = Rs.RecordCount + 1
        GridCon.FixedRows = 1
        Rs.MoveFirst
        nFldCount = Rs.fields.Count
        For i = 1 To Rs.RecordCount '填充数据
            For j = 0 To nFldCount - 1
                'sValue = IIf(Rs.Fields(j).value Is Not Null, , "")
                
                If j = 17 Then
                    If Rs.fields(j).Value = 1 Then
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") '静态
                    ElseIf Rs.fields(j).Value = 2 Then
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") '动态
                    End If
                ElseIf j = 18 Then
                    If Rs.fields(j).Value = 1 Then
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0") '天
                    ElseIf Rs.fields(j).Value = 2 Then
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1") '周
                    ElseIf Rs.fields(j).Value = 3 Then
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2") '月
                    Else
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = ""
                    End If
                ElseIf j = 20 Then
                    If Rs.fields(j).Value = 1 Then
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") '覆盖天数
                    ElseIf Rs.fields(j).Value = 2 Then
                        GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1") '百分比
                    End If
                Else
                    GridCon.TextMatrix(i, j + m_FreeColIndex) = g_oPub.FormatGridTxt(Rs.fields(j).Value, Rs.fields(j).name, m_EleStyle)
                End If
            Next j
            Rs.MoveNext
            If i Mod 200 = 0 Then
                GridCon.Redraw = True
                DoEvents ' 如果循环已完成了200条记录，将执行让给操作系统
                GridCon.Redraw = False
            End If
        Next i
        GridCon.Col = 0
        GridCon.Row = 1
    Else
        GridCon.Rows = 1
    End If
    Call WriteGrid(GridCon)
    GridCon.Redraw = True
    Set deleteXml = Nothing
End Sub

'-------------------------------------
'功能：重写序号
'-------------------------------------
Private Sub WriteGrid(GridCon As SuperGrid)
    GridCon.Redraw = False
    Dim i As Long
    For i = 1 To GridCon.Rows - 1 '写序号
        GridCon.TextMatrix(i, 0) = CStr(i)
    Next i
    GridCon.Redraw = True
End Sub


'-----------------------------------------
'功能：获得保存的字符串(规定接口)
'参数： bFlag： 是否正确
'返回： 保存的Xml字符串
'-----------------------------------------
Public Function GetSaveXml(Optional ByRef bFlag As Boolean = True) As String
    Dim i As Integer
    'Dim sXml As String
    Dim sXml As Object
    Set sXml = CreateObject("U8Pub.StringBuilder")
    sXml.ChunkSize = 1600000
    
    For i = 1 To ChkFree.UBound + 1
        Call EleXML2(sXml, "bFree" + CStr(i), ChkFree(i - 1))
    Next i
    For i = 1 To ChkbConfigFree.UBound + 1
        Call EleXML2(sXml, "bConfigFree" + CStr(i), ChkbConfigFree(i - 1))
    Next i
    For i = 1 To ChkbCheckFree.UBound + 1
        Call EleXML2(sXml, "bCheckFree" + CStr(i), ChkbCheckFree(i - 1))
    Next i
    For i = 1 To ChkbPurPriceFree.UBound + 1
        Call EleXML2(sXml, "bPurPriceFree" + CStr(i), ChkbPurPriceFree(i - 1))
    Next i
    For i = 1 To ChkbSalePriceFree.UBound + 1
        Call EleXML2(sXml, "bSalePriceFree" + CStr(i), ChkbSalePriceFree(i - 1))
    Next i
    For i = 1 To ChkbOMPriceFree.UBound + 1
        Call EleXML2(sXml, "bOMPriceFree" + CStr(i), ChkbOMPriceFree(i - 1))
    Next i
    For i = 1 To ChkbControlFreeRange.UBound + 1
        Call EleXML2(sXml, "bControlFreeRange" + CStr(i), ChkbControlFreeRange(i - 1))
    Next i
    Call sXml.Append(GetGridXml(bFlag))
    
    For i = 0 To 9
        Dim sTemp As String
        If Len(m_arrFreeDataXml(i)) > 0 Then
            sTemp = sTemp + m_arrFreeDataXml(i)
        End If
    Next i
    If Len(sTemp) > 0 Then
        Call sXml.Append("<AA_InvFreeContraposes>" + sTemp + "</AA_InvFreeContraposes>")
    End If
    
    GetSaveXml = sXml.ToString
End Function


'-----------------------------------------------
'功能：填写物料档案/核算自由项档案（存货结构性自由项组合）的保存Xml字符串
'返回：返回Xml串
'-----------------------------------------------
Private Function GetGridXml(Optional ByRef bFlag As Boolean = True)
    Dim i As Long
    Dim j As Integer
    Dim k As Integer
    Dim lCount As Long
    Dim sLast As String
    'Dim sXml As String
    Dim sXml As Object
    Set sXml = CreateObject("U8Pub.StringBuilder")
    sXml.ChunkSize = 1600000
    Dim node As IXMLDOMNode
    Dim xls As IXMLDOMNodeList

    If grid.ProtectUnload = dbRetry Then
        bFlag = False
        Exit Function
    End If
    Call sXml.Append("<bas_partAll  savetype='local'>")
    With grid
        lCount = .Rows - 1
        For k = m_FreeColIndex To m_FreeColIndex + 9
            sLast = sLast + .TextMatrix(lCount, k)
        Next k
        If Len(Trim(sLast)) = 0 Then '空行，不作处理
            lCount = lCount - 1
        End If
        For i = 1 To lCount
            If (.TextMatrix(i, .cols - 1) = "insert" Or .TextMatrix(i, .cols - 1) = "update") Then
                Call sXml.Append("<bas_part state='" & .TextMatrix(i, .cols - 1) & "'>")
                Else
                Call sXml.Append("<bas_part>")
            End If

            For j = m_FreeColIndex To .cols - 2
                If j = 18 Then
                    If .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") Then '静态
                        Call sXml.Append("<" + m_arrConfigFlds(j) + ">1</" + m_arrConfigFlds(j) + ">")
                    ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") Then '动态
                        Call sXml.Append("<" + m_arrConfigFlds(j) + ">2</" + m_arrConfigFlds(j) + ">")
                    End If
                ElseIf j = 19 Then
                    If .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0") Then '天
                        Call sXml.Append("<" + m_arrConfigFlds(j) + ">1</" + m_arrConfigFlds(j) + ">")
                    ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1") Then '周
                        Call sXml.Append("<" + m_arrConfigFlds(j) + ">2</" + m_arrConfigFlds(j) + ">")
                    ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2") Then ' 月
                        Call sXml.Append("<" + m_arrConfigFlds(j) + ">3</" + m_arrConfigFlds(j) + ">")
                    Else
                        Call sXml.Append("<" + m_arrConfigFlds(j) + "></" + m_arrConfigFlds(j) + ">")
                    End If
                ElseIf j = 21 Then
                    If .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") Then '覆盖天数
                        Call sXml.Append("<" + m_arrConfigFlds(j) + ">1</" + m_arrConfigFlds(j) + ">")
                    ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1") Then '百分比
                        Call sXml.Append("<" + m_arrConfigFlds(j) + ">2</" + m_arrConfigFlds(j) + ">")
                    End If
                Else
                    Call sXml.Append("<" + m_arrConfigFlds(j) + ">" + .TextMatrix(i, j) + "</" + m_arrConfigFlds(j) + ">")
                End If
            Next j
            Call sXml.Append("</bas_part>")
        Next i
    End With
    'sXml = "<bas_partAll>" + sXml + "</bas_partAll>"
    If Not (deleteXml Is Nothing) Then
        If deleteXml.xml <> "" Then
            Set xls = deleteXml.selectNodes("root/bas_partAll/bas_part")
            If xls.length > 0 Then
                For Each node In xls
                    Call sXml.Append(node.xml)
                Next
            End If
        End If
    End If

    Call sXml.Append("</bas_partAll>")
    If GridCheck.ProtectUnload = dbRetry Then
        bFlag = False
        Exit Function
    End If
    'Dim chkXML As String
    
    Dim chkXML As Object
    Set chkXML = CreateObject("U8Pub.StringBuilder")
    chkXML.ChunkSize = 1600000
    Call chkXML.Append("<InvCheckFreeAll  savetype='local'>")
    With GridCheck
        lCount = .Rows - 1
        For k = m_FreeColIndex To m_FreeColIndex + 9
            sLast = sLast + .TextMatrix(lCount, k)
        Next k
        If Len(Trim(sLast)) = 0 Then '空行，不作处理
            lCount = lCount - 1
        End If
        For i = 1 To lCount
            If (.TextMatrix(i, .cols - 1) = "insert" Or .TextMatrix(i, .cols - 1) = "update") Then
                Call chkXML.Append("<InvCheckFree state='" & .TextMatrix(i, .cols - 1) & "'>")
                Else
                Call chkXML.Append("<InvCheckFree>")
            End If

            For j = m_FreeColIndex To .cols - 2
                Call chkXML.Append("<" + m_arrChkFreeFlds(j) + ">" + .TextMatrix(i, j) + "</" + m_arrChkFreeFlds(j) + ">")
            Next j
            Call chkXML.Append("</InvCheckFree>")
        Next i
    End With
    'chkXML = "<InvCheckFreeAll>" + chkXML + "</InvCheckFreeAll>"
    If Not (deleteXml Is Nothing) Then
        If deleteXml.xml <> "" Then
            Set xls = deleteXml.selectNodes("root/InvCheckFreeAll/InvCheckFree")
            If xls.length > 0 Then
                For Each node In xls
                    Call chkXML.Append(node.xml)
                Next
            End If
        End If
    End If

    Call chkXML.Append("</InvCheckFreeAll>")
    Call sXml.Append(chkXML.ToString)
    GetGridXml = sXml.ToString
End Function


'---------------------------------------
'属性：是否显示
'---------------------------------------
Public Property Get BShow() As Boolean
    BShow = m_bShow
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


Public Property Let ReadOnly(ByVal vNewValue As Boolean)
    FrameTlb.Enabled = Not vNewValue
    UFFrameTlb2.Enabled = Not vNewValue
    Dim i As Integer
    For i = 0 To 9
        CmdSetFreeItem(i).Enabled = Not vNewValue
        If vNewValue = True Then
            CmdSetFreeItem(i).Tag = "readonly"
        Else
            CmdSetFreeItem(i).Tag = ""
        End If
    Next i
End Property

Private Sub UserControl_Terminate()
    On Error Resume Next
    Set m_objRef = Nothing
End Sub
Private Sub deleteXmlInsert(IsBas_part As Boolean, cols As Long, Value As String)
    If deleteXml Is Nothing Then
        Set deleteXml = New DOMDocument
        deleteXml.loadXML ("<root><InvCheckFreeAll/><bas_partAll/></root>")
    Else
        If deleteXml.xml = "" Then
            Set deleteXml = New DOMDocument
            deleteXml.loadXML ("<root><InvCheckFreeAll/><bas_partAll/></root>")
        End If
    End If
    
    Dim i As Long
    Dim j As Integer
    Dim k As Integer
    Dim lCount As Long
    Dim sLast As String
    Dim node As IXMLDOMNode
    'Dim sXml As String
'    Dim sXml As Object
'    Set sXml = CreateObject("U8Pub.StringBuilder")
'    sXml.ChunkSize = 1600000
'
'    If grid.ProtectUnload = dbRetry Then
'        bFlag = False
'        Exit Sub
'    End If
'    Call sXml.Append("<bas_partAll>")
    If IsBas_part Then
        With grid
        
'            lCount = .Rows - 1
'            For k = m_FreeColIndex To m_FreeColIndex + 9
'                sLast = sLast + .TextMatrix(lCount, k)
'            Next k
'            If Len(Trim(sLast)) = 0 Then '空行，不作处理
'                lCount = lCount - 1
'            End If
            
            
            Set node = CreateNode(deleteXml.selectSingleNode("root/bas_partAll"), "bas_part", "")
            Call CreateAttribute(node, "state", "delete")
            'For i = 1 To lCount
                'Call sXml.Append("<bas_part>")
                For j = m_FreeColIndex To .cols - 2
                    If cols = j Then
                        Call CreateNode(node, m_arrConfigFlds(j), Value)
                    ElseIf j = 18 Then
                        If .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype0") Then '静态
                            Call CreateNode(node, m_arrConfigFlds(j), "1")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + ">1</" + m_arrConfigFlds(j) + ">")
                        ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.isurenesstype1") Then '动态
                            Call CreateNode(node, m_arrConfigFlds(j), "2")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + ">2</" + m_arrConfigFlds(j) + ">")
                        End If
                    ElseIf j = 19 Then
                        If .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype0") Then '天
                            Call CreateNode(node, m_arrConfigFlds(j), "1")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + ">1</" + m_arrConfigFlds(j) + ">")
                        ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype1") Then '周
                            Call CreateNode(node, m_arrConfigFlds(j), "2")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + ">2</" + m_arrConfigFlds(j) + ">")
                        ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idatetype2") Then ' 月
                            Call CreateNode(node, m_arrConfigFlds(j), "3")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + ">3</" + m_arrConfigFlds(j) + ">")
                        Else
                            Call CreateNode(node, m_arrConfigFlds(j), "")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + "></" + m_arrConfigFlds(j) + ">")
                        End If
                    ElseIf j = 21 Then
                        If .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype0") Then '覆盖天数
                            Call CreateNode(node, m_arrConfigFlds(j), "1")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + ">1</" + m_arrConfigFlds(j) + ">")
                        ElseIf .TextMatrix(i, j) = g_oPub.GetResString("U8.AA.ARCHIVE.COMMON.idynamicsurenesstype1") Then '百分比
                            Call CreateNode(node, m_arrConfigFlds(j), "2")
                            'Call sXml.Append("<" + m_arrConfigFlds(j) + ">2</" + m_arrConfigFlds(j) + ">")
                        End If
                    Else
                        Call CreateNode(node, m_arrConfigFlds(j), .TextMatrix(.Row, j))
                        'Call sXml.Append("<" + m_arrConfigFlds(j) + ">" + .TextMatrix(i, j) + "</" + m_arrConfigFlds(j) + ">")
                    End If
                Next j
        End With
    Else
    
        Set node = CreateNode(deleteXml.selectSingleNode("root/InvCheckFreeAll"), "InvCheckFree", "")
        Call CreateAttribute(node, "state", "delete")
        With GridCheck
'            lCount = .Rows - 1
'            For k = m_FreeColIndex To m_FreeColIndex + 9
'                sLast = sLast + .TextMatrix(lCount, k)
'            Next k
'            If Len(Trim(sLast)) = 0 Then '空行，不作处理
'                lCount = lCount - 1
'            End If
            
                
            For j = m_FreeColIndex To .cols - 2
                If cols = j Then
                    Call CreateNode(node, m_arrChkFreeFlds(j), Value)
                Else
                    Call CreateNode(node, m_arrChkFreeFlds(j), .TextMatrix(GridCheck.Row, j))
                'Call chkXML.Append("<" + m_arrChkFreeFlds(j) + ">" + .TextMatrix(GridCheck.Col, j) + "</" + m_arrChkFreeFlds(j) + ">")
                End If
            Next j
                
            
        End With
    'chkXML = "<InvCheckFreeAll>" + chkXML + "</InvCheckFreeAll>"
        'Call chkXML.Append("</InvCheckFreeAll>")
    End If
    
    
End Sub
Private Sub SetGridInsertState()
Dim i As Integer
For i = 1 To grid.Rows - 1
    grid.TextMatrix(i, grid.cols - 1) = "insert"
Next
For i = 1 To GridCheck.Rows - 1
    GridCheck.TextMatrix(i, GridCheck.cols - 1) = "insert"
Next
End Sub
