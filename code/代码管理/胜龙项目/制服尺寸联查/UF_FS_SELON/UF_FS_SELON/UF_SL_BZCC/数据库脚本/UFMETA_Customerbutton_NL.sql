delete [AA_CustomerButton] where [cButtonKey]='UNSelect' and [cVoucherKey]='17'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UNSelect','default', 'U8CustDef', '17', '17','Refresh', '0', 'IEDIT','UF_FS_SELON.clsButtonLinkCc','�Ʒ��ߴ�����','zh-cn','bill','�Ʒ��ߴ�����','Ctrl

+U',1,'�Ʒ��ߴ�����','modify','Refresh')
go

delete VoucherPortalButtons where VoucherID='17' and ButtonKey='UNSelect'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UNSelect'  and [cVoucherKey]='17')
insert into VoucherPortalButtons values(@cButtonID,'17','UNSelect')

--select * from [AA_CustomerButton] where [cVoucherKey]='17'

--����Ʒ��ⵥ
delete [AA_CustomerButton] where [cButtonKey]='UN0411Select' and [cVoucherKey]='0411'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UN0411Select','default', 'U8CustDef', '0411', '0411','tlbFile', '0', 'IEDIT','UF_FS_SELON.clsButtonLinkCc','��������','zh-cn','bill','��������','Ctrl+U',1,'�Ʒ��ߴ�����','modify','tlbCheckStock')
go

delete VoucherPortalButtons where VoucherID='0411' and ButtonKey='UN0411Select'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UN0411Select'  and [cVoucherKey]='0411')
insert into VoucherPortalButtons values(@cButtonID,'0411','UN0411Select')


--��������
delete [AA_CustomerButton] where [cButtonKey]='UNMO21Select' and [cVoucherKey]='MO21'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UNMO21Select','default', 'U8CustDef', 'MO21', 'MO21','tlbAttached', '0', 'IEDIT','UF_FS_SELON.clsButtonLinkCc','�Ʒ��ߴ�����','zh-cn','bill','�Ʒ��ߴ�����','Ctrl+U',1,'�Ʒ��ߴ�����','modify','tlbLinkList')
go

delete VoucherPortalButtons where VoucherID='MO21' and ButtonKey='UNMO21Select'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UNMO21Select'  and [cVoucherKey]='MO21')
insert into VoucherPortalButtons values(@cButtonID,'MO21','UNMO21Select')


--��ʶ��
delete [AA_CustomerButton] where [cButtonKey]='UNMO21Sign' and [cVoucherKey]='MO21'
INSERT INTO [AA_CustomerButton]([cButtonID], [cButtonKey], [cButtonType], [cProjectNO], [cFormKey], [cVoucherKey], [cKeyBefore], [iOrder], [cGroup], 

[cCustomerObjectName], [cCaption], [cLocaleID], [cImage], [cToolTip], [cHotKey], [bInneralCommand], [cVariant], [cVisibleAsKey], [cEnableAsKey])
VALUES(newid(), 'UNMO21Sign','default', 'U8CustDef', 'MO21', 'MO21','tlbAttached', '0', 'IEDIT','UF_FS_SELON.clsPrintSignCard','��ʶ����ӡ','zh-cn','bill','��ʶ����ӡ','Ctrl+U',1,'��ʶ����ӡ','modify','tlbLinkList')
go

delete VoucherPortalButtons where VoucherID='MO21' and ButtonKey='UNMO21Sign'
declare @cButtonID nvarchar(40)
set @cButtonID =(select [cButtonID] from [AA_CustomerButton] where [cButtonKey]='UNMO21Sign'  and [cVoucherKey]='MO21')
insert into VoucherPortalButtons values(@cButtonID,'MO21','UNMO21Sign')
