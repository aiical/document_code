USE [SelonUinform]
GO

/****** Object:  View [dbo].[v_Tailordetail]    Script Date: 07/14/2012 16:42:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

if exists(select * from sysobjects where id=object_id('v_Tailordetail'))
drop view v_Tailordetail
go
CREATE VIEW [dbo].[v_Tailordetail]  
AS   
--SELECT b.cCusName,b.cMaker,b.dMakeDate,b.dDate,b.cCusCode,b.saCode, a.*  FROM  Tailordetail a  INNER JOIN   TailorMain b on a.id=b.id
--SELECT  
-- b.cCusName,b.cMaker,b.dMakeDate,b.dDate,b.cCusCode,b.saCode,  
-- a.*,c.cDepCode,c.cDepName,c.cName, case c.iSex when 1  then 'ÄÐ'  else 'Å®' end as isex,e.cCode   
 -- FROM  Tailordetail a  INNER JOIN   TailorMain b  on  a.id=b.id inner join CustomerPerson c on a.cId=c.id left join dbo.TailorDefine e on a.sId=e.Id   
  
  SELECT  
 b.cCusName,b.cMaker,b.dMakeDate,b.dDate,b.cCusCode,b.saCode,  
 a.*,c.cDepCode,c.cDepName,c.cName,right(c.cpid,4) AS cpid, case c.iSex when 1  then 'ÄÐ'  else 'Å®' end as isex,e.cCode   
  FROM  Tailordetail a  INNER JOIN   TailorMain b  
  on  a.id=b.id inner join CustomerPerson c 
  on a.cId=c.id left join dbo.TailorDefine e 
  on e.Id  in (select did from  StandardSize where id=a.sId)
  

 
GO


