--drop proc [Get_v_Tailorsizes]     

if exists(select * from sysobjects where id=object_id('Get_v_Tailorsizes'))
begin
drop proc Get_v_Tailorsizes
end
go
create procedure [Get_v_Tailorsizes]      
@cSocode nvarchar(60) 

AS      
BEGIN  
SET NOCOUNT ON;  

select s.dname+'('+s.iname+')' as BxMc,t.* from SelonUinform.DBO.StandardSize s inner join SelonUinform.DBO.TailorDefine t  
 on s.dID=t.id where  t.bdefine=1 and (convert(nvarchar(36),s.Id)+s.iName) in (  
select distinct (convert(nvarchar(36),sId)+iName)  from SelonUinform.dbo.v_Tailordetail  where sacode=@cSocode  
)
  
end  
  
  
  