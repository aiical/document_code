--增加门户菜单
USE UFSystem
GO
ALTER TABLE  UFSystem.dbo.UA_Menu ALTER COLUMN CMenu_Id  NVARCHAR(50) --修改数据类型 

--增加idt对应记录
--  delete  ua_idt where id = 'ST020303'
if not exists(select * from UFSystem.dbo.ua_idt where id = 'SAM031105')
INSERT INTO [UFSystem].[dbo].[ua_idt]([id], [assembly], [catalogtype], [type], [class], [entrypoint], 
[parameter], [reserved])
VALUES('SAM031105','.\uap\runtime\U8_Sale.dll',0,2,'U8_Sale.LoginMsg',null,null,null)

if not exists(select * from UFSystem.dbo.ua_idt where id = 'SAM031106') --配货单列表
INSERT INTO [UFSystem].[dbo].[ua_idt]([id], [assembly], [catalogtype], [type], [class], [entrypoint], 
[parameter], [reserved])
VALUES('SAM031106','.\uap\runtime\U8_Sale.dll',0,2,'U8_Sale.LoginMsg',null,null,null)

if not exists(select * from UFSystem.dbo.ua_idt where id = 'SAM031107')
INSERT INTO [UFSystem].[dbo].[ua_idt]([id], [assembly], [catalogtype], [type], [class], [entrypoint], 
[parameter], [reserved])
VALUES('SAM031107','.\uap\runtime\U8_Sale.dll',0,2,'U8_Sale.LoginMsg',null,null,null)

if not exists(select * from UFSystem.dbo.ua_idt where id = 'SAM031108')
INSERT INTO [UFSystem].[dbo].[ua_idt]([id], [assembly], [catalogtype], [type], [class], [entrypoint], 
[parameter], [reserved])
VALUES('SAM031108','.\uap\runtime\U8_Sale.dll',0,2,'U8_Sale.LoginMsg',null,null,null)

GO


------添加菜单

-- delete from  [UFSystem].[dbo].[UA_Menu] where cMenu_Id='DBPHD'
-- select * from  UA_Menu where [cSupMenu_Id] ='ST020303'

if not exists(select * from  UFSystem.dbo.UA_Menu where cMenu_Id = 'SAM031105')
INSERT INTO [UFSystem].[dbo].[UA_Menu]([cMenu_Id], [cMenu_Name], [cMenu_Eng], [cSub_Id],[IGrade], [cSupMenu_Id], [bEndGrade], [cAuth_Id], [iOrder], [iImgIndex], 
[Paramters], [Depends], [Flag])
			    VALUES('SAM031105','系统参数设置',null,'SA',2,'SAM0311',1,'SA031105_01',264,4,NULL,NULL,NULL)

if not exists(select * from UFSystem.dbo.UA_Menu where cMenu_Id = 'SAM031106')
INSERT INTO [UFSystem].[dbo].[UA_Menu]([cMenu_Id], [cMenu_Name], [cMenu_Eng], [cSub_Id],[IGrade], [cSupMenu_Id], [bEndGrade], [cAuth_Id], [iOrder], [iImgIndex], 
[Paramters], [Depends], [Flag])
			    VALUES('SAM031106','参考值指数录入',null,'SA',2,'SAM0311',1,'SA031106_01',265,4,NULL,NULL,NULL)
			    
if not exists(select * from  UFSystem.dbo.UA_Menu where cMenu_Id = 'SAM031107')
INSERT INTO [UFSystem].[dbo].[UA_Menu]([cMenu_Id], [cMenu_Name], [cMenu_Eng], [cSub_Id],[IGrade], [cSupMenu_Id], [bEndGrade], [cAuth_Id], [iOrder], [iImgIndex], 
[Paramters], [Depends], [Flag])
			    VALUES('SAM031107','销售计划管理',null,'SA',2,'SAM0311',1,'SA031107_01',264,4,NULL,NULL,NULL)
			    
if not exists(select * from  UFSystem.dbo.UA_Menu where cMenu_Id = 'SAM031108')
INSERT INTO [UFSystem].[dbo].[UA_Menu]([cMenu_Id], [cMenu_Name], [cMenu_Eng], [cSub_Id],[IGrade], [cSupMenu_Id], [bEndGrade], [cAuth_Id], [iOrder], [iImgIndex], 
[Paramters], [Depends], [Flag])
			    VALUES('SAM031108','销售计划执行统计分析',null,'SA',2,'SAM0311',1,'SA031108_01',264,4,NULL,NULL,NULL)
GO
--产品菜单节点 【语言】
--- Delete UFSystem..ufmenu_business_lang WHERE MenuId='DBPHD'
IF NOT EXISTS(SELECT MenuId FROM UFSystem..ufmenu_business_lang WHERE MenuId='SAM031105')
BEGIN
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031105','系统参数设置','ZH-CN'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031105','系统参数设置','ZH-TW'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031105','系统参数设置','EN-US');
END

IF NOT EXISTS(SELECT MenuId FROM UFSystem..ufmenu_business_lang WHERE MenuId='SAM031106')
BEGIN
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031106','参考值指数录入','ZH-CN'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031106','参考值指数录入','ZH-TW'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031106','参考值指数录入','EN-US');
END

IF NOT EXISTS(SELECT MenuId FROM UFSystem..ufmenu_business_lang WHERE MenuId='SAM031107')
BEGIN
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031107','销售计划管理','ZH-CN'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031107','销售计划管理','ZH-TW'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031107','销售计划管理','EN-US');
END

IF NOT EXISTS(SELECT MenuId FROM UFSystem..ufmenu_business_lang WHERE MenuId='SAM031108')
BEGIN
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031108','销售计划执行统计分析','ZH-CN'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031108','销售计划执行统计分析','ZH-TW'); 
	insert into UFSystem..ufmenu_business_lang 
	values('SAM031108','销售计划执行统计分析','EN-US');
END

--select * from UA_Menu where [cSub_Id] ='ST' ORDER BY cSupMenu_Id  
 
--SELECT * FROM UFSystem.dbo.uA_auth WHERE cSub_Id = 'ST' and cAuth_Name like '调拨%'

---------------添加权限--------------
---- delete UFSystem.dbo.uA_auth WHERE cSupAuth_Id = 'ST020303' and   cAuth_Id = 'ST020303'
---  delete UFSystem.dbo.uA_auth WHERE cAuth_Id = 'ST011302'

IF NOT EXISTS(SELECT * FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'SAM031105')
INSERT INTO UFSystem.dbo.uA_auth (cAuth_Id, cAuth_Name, cSub_Id, iGrade, cSupAuth_Id, bEndGrade, iOrder, cAcc_Id, cAuthType)
	select 'SAM031105', '系统参数设置','SA', 3,  'SAM0311',         0,        275, NULL,   null
	
IF NOT EXISTS(SELECT * FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'SAM031106')
INSERT INTO UFSystem.dbo.uA_auth (cAuth_Id, cAuth_Name, cSub_Id, iGrade, cSupAuth_Id, bEndGrade, iOrder, cAcc_Id, cAuthType)
	select 'SAM031106', '参考值指数录入','SA', 3,  'SAM0311',         0,        275, NULL,   null
	
IF NOT EXISTS(SELECT * FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'SAM031107')
INSERT INTO UFSystem.dbo.uA_auth (cAuth_Id, cAuth_Name, cSub_Id, iGrade, cSupAuth_Id, bEndGrade, iOrder, cAcc_Id, cAuthType)
	select 'SAM031107', '销售计划管理','SA', 3,  'SAM0311',         0,        275, NULL,   null
	
IF NOT EXISTS(SELECT * FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'SAM031108')
INSERT INTO UFSystem.dbo.uA_auth (cAuth_Id, cAuth_Name, cSub_Id, iGrade, cSupAuth_Id, bEndGrade, iOrder, cAcc_Id, cAuthType)
	select 'SAM031108', '销售计划执行统计分析','SA', 3,  'SAM0311',         0,        275, NULL,   null
GO