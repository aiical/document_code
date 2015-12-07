--增加门户菜单
USE UFSystem
GO
--ALTER TABLE  UFSystem.dbo.UA_Menu ALTER COLUMN CMenu_Id  NVARCHAR(50) --修改数据类型 

--增加idt对应记录
 delete  UFSystem.dbo.ua_idt where id = 'ST131010'
if not exists(select * from UFSystem.dbo.ua_idt where id = 'ST131010')
INSERT INTO [UFSystem].[dbo].[ua_idt]([id], [assembly], [catalogtype], [type], [class], [entrypoint], 
[parameter], [reserved])
VALUES('ST131010','.\uap\runtime\SL_U8Framework.dll',0,2,'SL_U8Framework.LoginMsg',null,null,null)
GO


------添加菜单
--select * from  UFSystem.dbo.UA_Menu where cMenu_Id LIKE 'ST%'
-- delete from  [UFSystem].[dbo].[UA_Menu] where cMenu_Id='WH0801'
-- select * from  UA_Menu where [cSupMenu_Id] ='ST020303'

if exists(select * from  UFSystem.dbo.UA_Menu where cMenu_Id = 'ST131010')
DELETE from  UFSystem.dbo.UA_Menu where cMenu_Id = 'ST131010'
GO
INSERT INTO [UFSystem].[dbo].[UA_Menu]([cMenu_Id], [cMenu_Name], [cMenu_Eng], [cSub_Id],[IGrade], [cSupMenu_Id], [bEndGrade], [cAuth_Id], [iOrder], [iImgIndex], [Paramters], [Depends], [Flag])
			    VALUES('ST131010','存货分类及价格段维护',3,'ST',2,'ST0203',1,'ST131010',277,1,NULL,NULL,NULL)
GO
--产品菜单节点 【语言】
--- Delete UFSystem..ufmenu_business_lang WHERE MenuId='DBPHD'
delete UFSystem..ufmenu_business_lang WHERE MenuId='ST131010'
IF NOT EXISTS(SELECT MenuId FROM UFSystem..ufmenu_business_lang WHERE MenuId='ST131010')
BEGIN
	insert into UFSystem..ufmenu_business_lang 
	values('ST131010','存货分类及价格段维护','ZH-CN'); 
	insert into UFSystem..ufmenu_business_lang 
	values('ST131010','存货分类及价格段维护','ZH-TW'); 
	insert into UFSystem..ufmenu_business_lang 
	values('ST131010','存货分类及价格段维护','EN-US');
END

--select * from UA_Menu where [cSub_Id] ='ST' ORDER BY cSupMenu_Id  
 
--SELECT * FROM UFSystem.dbo.uA_auth WHERE cSub_Id = 'ST' and cAuth_Name like '调拨%'

---------------添加权限--------------
---- delete UFSystem.dbo.uA_auth WHERE cSupAuth_Id = 'ST020303' and   cAuth_Id = 'ST020303'
---  delete UFSystem.dbo.uA_auth WHERE cAuth_Id = 'ST011302'
--SELECT * FROM UFSystem.dbo.uA_auth where cSupAuth_Id = 'ST0203' ORDER BY cSupAuth_Id
IF EXISTS(SELECT * FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'ST131010')
DELETE FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'ST131010'
GO
INSERT INTO UFSystem.dbo.uA_auth (cAuth_Id, cAuth_Name, cSub_Id, iGrade, cSupAuth_Id, bEndGrade, iOrder, cAcc_Id, cAuthType)
	select 'ST131010','存货分类及价格段维护','ST',3,'ST0203',1,277,NULL,null
	/* union
	select									               
		'STDBPHD001','生单','ST',4,'STDBPHD',1,270,Null,Null
	*/
GO

EXEC sp_CalculateSupAuth

