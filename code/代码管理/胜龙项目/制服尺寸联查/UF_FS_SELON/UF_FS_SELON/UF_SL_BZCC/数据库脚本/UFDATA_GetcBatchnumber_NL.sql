--drop proc [GetcBatchnumber]       

if exists(select * from sysobjects where id=object_id('GetcBatchnumber'))
begin
drop proc GetcBatchnumber
end

go
create procedure [GetcBatchnumber]        
@cbatchstr varchar(120),        
@cfree1 varchar(40),
@cInvcode varchar(40),
@Year varchar(4),
@Month varchar(2),        
@ncBatch int OUTPUT,
@Return int OUTPUT        
AS        
BEGIN    
SET NOCOUNT ON;    
SET @Return=0
SET @ncBatch=0   --recordinlist  
if exists(Select * from recordinlist where year(ddate)=@Year AND MONTH(ddate)=@Month AND  CHARINDEX(@cbatchstr,cbatch)>0 AND cInvCode=@cInvcode AND  cfree1=@cfree1)    
 begin    
 set @ncBatch=(select convert(int ,substring(MAX(cbatch),len(MAX(cbatch))-2,3)) from recordinlist WHERE year(ddate)=@Year AND MONTH(ddate)=@Month AND  CHARINDEX(@cbatchstr,cbatch)>0 AND cInvCode=@cInvcode AND cfree1=@cfree1)
 SET @Return=1    
 end        
else  
 begin  
 if exists(Select * from recordinlist where year(ddate)=@Year AND MONTH(ddate)=@Month AND CHARINDEX(@cbatchstr,cbatch)>0 and (cfree1<>@cfree1 OR  cInvCode<>@cInvcode ))    
  begin  
  set @ncBatch=(select convert(int ,substring(MAX(cbatch),len(MAX(cbatch))-2,3)) from recordinlist WHERE year(ddate)=@Year AND MONTH(ddate)=@Month AND  CHARINDEX(@cbatchstr,cbatch)>0 )    
  set @ncBatch=@ncBatch+1  
  SET @Return=1   
  end  
 end  
    
    
IF(@ncBatch=0)    
SET @ncBatch=1    
    
    
end    
    
    