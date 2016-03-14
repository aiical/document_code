delete [AA_CustomerButton] where [cButtonKey]='UNSelect' and [cVoucherKey]='17'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UNSelect','default', 'U8CustDef', '17', '17','Refresh', '0', 'IEDIT','UF_FS_SELON.clsButtonLinkCc','制服尺寸联查','zh-cn','bill','制服尺寸联查','Ctrl

+U',1,'制服尺寸联查','modify','Refresh')
go

delete VoucherPortalButtons where VoucherID='17' and ButtonKey='UNSelect'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UNSelect'  and [cVoucherKey]='17')
insert into VoucherPortalButtons values(@cButtonID,'17','UNSelect')

--select * from [AA_CustomerButton] where [cVoucherKey]='17'

--产成品入库单
delete [AA_CustomerButton] where [cButtonKey]='UN0411Select' and [cVoucherKey]='0411'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UN0411Select','default', 'U8CustDef', '0411', '0411','tlbFile', '0', 'IEDIT','UF_FS_SELON.clsButtonLinkCc','整单联查','zh-cn','bill','整单联查','Ctrl+U',1,'制服尺寸联查','modify','tlbCheckStock')
go

delete VoucherPortalButtons where VoucherID='0411' and ButtonKey='UN0411Select'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UN0411Select'  and [cVoucherKey]='0411')
insert into VoucherPortalButtons values(@cButtonID,'0411','UN0411Select')


--生产订单
delete [AA_CustomerButton] where [cButtonKey]='UNMO21Select' and [cVoucherKey]='MO21'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UNMO21Select','default', 'U8CustDef', 'MO21', 'MO21','tlbAttached', '0', 'IEDIT','UF_FS_SELON.clsButtonLinkCc','制服尺寸联查','zh-cn','bill','制服尺寸联查','Ctrl+U',1,'制服尺寸联查','modify','tlbLinkList')
go

delete VoucherPortalButtons where VoucherID='MO21' and ButtonKey='UNMO21Select'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UNMO21Select'  and [cVoucherKey]='MO21')
insert into VoucherPortalButtons values(@cButtonID,'MO21','UNMO21Select')


--标识卡
delete [AA_CustomerButton] where [cButtonKey]='UNMO21Sign' and [cVoucherKey]='MO21'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UNMO21Sign','default', 'U8CustDef', 'MO21', 'MO21','tlbAttached', '0', 'IEDIT','UF_FS_SELON.clsPrintSignCard','标识卡打印','zh-cn','bill','标识卡打印','Ctrl+U',1,'标识卡打印','modify','tlbLinkList')
go

delete VoucherPortalButtons where VoucherID='MO21' and ButtonKey='UNMO21Sign'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UNMO21Sign'  and [cVoucherKey]='MO21')
insert into VoucherPortalButtons values(@cButtonID,'MO21','UNMO21Sign')
