--�����Ż��˵�
USE UFSystem
GO
--ALTER TABLE  UFSystem.dbo.UA_Menu ALTER COLUMN CMenu_Id  NVARCHAR(50) --�޸��������� 

--����idt��Ӧ��¼
--  delete  ua_idt where id = 'ST020303'
if not exists(select * from UFSystem.dbo.ua_idt where id = 'ST0824')
INSERT INTO [UFSystem].[dbo].[ua_idt]([id], [assembly], [catalogtype], [type], [class], [entrypoint], 
[parameter], [reserved])
VALUES('ST0824','.\uap\runtime\U8.Report.Twodimension.dll',0,2,'U8.Report.Twodimension.LoginMsg',null,null,null)
GO


------��Ӳ˵�
--select * from  UFSystem.dbo.UA_Menu where cMenu_Id LIKE 'ST%'
-- delete from  [UFSystem].[dbo].[UA_Menu] where cMenu_Id='DBPHD'
-- select * from  UA_Menu where [cSupMenu_Id] ='ST020303'

if exists(select * from  UFSystem.dbo.UA_Menu where cMenu_Id = 'ST0824')
DELETE from  UFSystem.dbo.UA_Menu where cMenu_Id = 'ST0824'
GO
INSERT INTO [UFSystem].[dbo].[UA_Menu]([cMenu_Id], [cMenu_Name], [cMenu_Eng], [cSub_Id],[IGrade], [cSupMenu_Id], [bEndGrade], [cAuth_Id], [iOrder], [iImgIndex], [Paramters], [Depends], [Flag])
			    VALUES('ST0824','�����������',3,'ST',2,'ST08',1,'ST0824',277,1,NULL,NULL,NULL)
GO
--��Ʒ�˵��ڵ� �����ԡ�
--- Delete UFSystem..ufmenu_business_lang WHERE MenuId='DBPHD'
IF NOT EXISTS(SELECT MenuId FROM UFSystem..ufmenu_business_lang WHERE MenuId='SAZTZG')
BEGIN
	insert into UFSystem..ufmenu_business_lang 
	values('ST0824','�����������','ZH-CN'); 
	insert into UFSystem..ufmenu_business_lang 
	values('ST0824','�����������','ZH-TW'); 
	insert into UFSystem..ufmenu_business_lang 
	values('ST0824','�����������','EN-US');
END

--select * from UA_Menu where [cSub_Id] ='ST' ORDER BY cSupMenu_Id  
 
--SELECT * FROM UFSystem.dbo.uA_auth WHERE cSub_Id = 'ST' and cAuth_Name like '����%'

---------------���Ȩ��--------------
---- delete UFSystem.dbo.uA_auth WHERE cSupAuth_Id = 'ST020303' and   cAuth_Id = 'ST020303'
---  delete UFSystem.dbo.uA_auth WHERE cAuth_Id = 'ST011302'

IF EXISTS(SELECT * FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'ST0824')
DELETE FROM UFSystem.dbo.uA_auth WHERE cAuth_Id = 'ST0824'
GO
INSERT INTO UFSystem.dbo.uA_auth (cAuth_Id, cAuth_Name, cSub_Id, iGrade, cSupAuth_Id, bEndGrade, iOrder, cAcc_Id, cAuthType)
	select 'ST0824','�����������','ST',3,'ST08',1,277,NULL,null
	/* union
	select									               
		'STDBPHD001','����','ST',4,'STDBPHD',1,270,Null,Null
	*/
GO

EXEC sp_CalculateSupAuth