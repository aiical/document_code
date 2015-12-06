IF EXISTS (SELECT * FROM sysobjects where id = OBJECT_ID(N'[ProcSalePlans]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)  
DROP PROC [ProcSalePlans]
IF EXISTS (SELECT * FROM sysobjects WHERE id=OBJECT_ID(N'SalePlans')  and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE SalePlans
GO
CREATE PROCEDURE ProcSalePlans
AS
CREATE TABLE SalePlans
(
	ID INT IDENTITY (1,1)  not null,
	iYear INT NULL,
	iMonth INT NULL,
	dDate DATETIME DEFAULT GETDATE() NULL,
	cDepCode VARCHAR(20) NULL,
	cRefs1 DECIMAL(18,2) NULL,
	cRefs2 DECIMAL(18,2) NULL,
	primary key (ID) 
)
DECLARE @isum AS DECIMAL(18,2)
DECLARE @cRefs1 DECIMAL(18,2)
DECLARE @cRefs2 DECIMAL(18,2)
DECLARE @LbLisum AS DECIMAL(18,2)
DECLARE @Lbisum AS DECIMAL(18,2)
DECLARE @Lisum AS DECIMAL(18,2)
DECLARE @LbLnRate AS FLOAT
DECLARE @LbnRate AS FLOAT
DECLARE @LnRate AS FLOAT
DECLARE @LbLSQL NVARCHAR(4000) /*��ǰ��*/
DECLARE @LbSQL NVARCHAR(4000) /*ǰ��*/
DECLARE @LSQL NVARCHAR(4000)  /*ȥ��*/
DECLARE @nRate1 NVARCHAR(4000)
DECLARE @nRate2 NVARCHAR(4000)
DECLARE @nRate3 NVARCHAR(4000)
DECLARE @LbLdatabase NVARCHAR(20) /*��ǰ�����ݿ�*/
DECLARE @Lbdatabase NVARCHAR(20) /*ǰ�����ݿ�*/
DECLARE @Ldatabase NVARCHAR(20) /*ȥ�����ݿ�*/
DECLARE @cRef1 NVARCHAR(200) /*�ο�ֵ1*/
DECLARE @cRef2 NVARCHAR(200) /*�ο�ֵ2*/
SELECT @LbLdatabase=NAME from master..sysdatabases WHERE NAME = 'ufdata_200_'+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''
SELECT @Lbdatabase=NAME from master..sysdatabases WHERE NAME = 'ufdata_200_'+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''
SELECT @Ldatabase=NAME from master..sysdatabases WHERE NAME = 'ufdata_200_'+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''
BEGIN
declare @cDepCode varchar(20)
DECLARE @iMonth NVARCHAR(2)

DECLARE MyCursor CURSOR FOR 
SELECT cDepCode FROM SL_P_DeptRef
OPEN MyCursor
fetch next from MyCursor into @cDepCode
 while @@fetch_status=0
 BEGIN
 	SELECT TOP 1 @cRef1 = SB.cDataValue FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId WHERE SD.cDepCode= @cDepCode
    SELECT TOP 1 @cRef2 = SB1.cDataValue FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId WHERE SD.cDepCode= @cDepCode
    SET @iMonth=1    
    WHILE @iMonth<13
     BEGIN
    IF @cRef1='���۶�'
    BEGIN
--    	  PRINT @iMonth
    	  set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iSum,0)),0) FROM '+@LbLdatabase+'..DispatchList d  left join '+@LbLdatabase+'..DispatchLists ds on d.DLID=ds.DLID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND d.cDepCode like '''+@cDepCode+'%'''	
          exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	  SET @LbLisum=ISNULL(@LbLisum,0)
    	  set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Lbdatabase+'..DispatchList d  left join '+@Lbdatabase+'..DispatchLists ds on d.DLID=ds.DLID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND d.cDepCode like '''+@cDepCode+'%'''
          exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
          SET @Lbisum=ISNULL(@Lbisum,0)
          set @LSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Ldatabase+'..DispatchList d  left join '+@Ldatabase+'..DispatchLists ds on d.DLID=ds.DLID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND d.cDepCode like '''+@cDepCode+'%'''
          exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
          SET @Lisum=ISNULL(@Lisum,0)
          IF @LbLisum=0
          BEGIN 
--          	PRINT '2011��ֵ'
            IF @Lbisum=0
               BEGIN
--               	PRINT '2012��ֵ'
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1=0 and nRate2=0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs1=isnull(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
--            	   PRINT '2012��ֵ'
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1=0 and nRate2<>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs1=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          BEGIN
--          	PRINT '2011��ֵ'
--          	PRINT @LbLisum
 --         	PRINT @Lbisum
--          	PRINT @Lisum
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
--                PRINT @nRate1
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
--                 PRINT @LbLnRate
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
 --              PRINT @nRate2
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
  --               PRINT @LbnRate
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
 --               PRINT @nRate3
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
  --               PRINT @LnRate
                SET @cRefs1=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
--                PRINT @cRefs1
          	END
 
 
 
        
       -- SET @cRefs1=isnull(@LbLisum,0)*isnull(@LbLnRate/100,0)+isnull(@Lbisum,0)*isnull(@LbnRate/100,0)+isnull(@Lisum,0)*isnull(@LnRate/100,0)
    	
    END
    IF @cRef1='��Ʊ��'
    BEGIN
    	
    	set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iSum,0)),0) FROM '+@LbLdatabase+'..SaleBillVouch s  left join '+@LbLdatabase+'..SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND s.cDepCode like '''+@cDepCode+'%'''
    	exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Lbdatabase+'..SaleBillVouch s  left join '+@Lbdatabase+'..SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND s.cDepCode like '''+@cDepCode+'%'''
        exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
        set @LSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Ldatabase+'..SaleBillVouch s  left join '+@Ldatabase+'..SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND s.cDepCode like '''+@cDepCode+'%'''
        exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
       IF @LbLisum=0
          BEGIN
            IF @Lbisum=0
               BEGIN
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 =0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
              
                SET @cRefs1=isnull(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
            	   
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs1=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          	BEGIN
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs1=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
          	END
    	
    END
    IF @cRef1='����'
    BEGIN
    	
    	set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iAmount_f,0)),0) FROM '+@LbLdatabase+'..Ap_CloseBill a  left join '+@LbLdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
    	exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Lbdatabase+'..Ap_CloseBill a  left join '+@Lbdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
        set @LSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Ldatabase+'..Ap_CloseBill a  left join '+@Ldatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
       IF @LbLisum=0
          BEGIN
            IF @Lbisum=0
               BEGIN
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 =0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs1=isnull(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
            	   
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs1=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          	BEGIN
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs1=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
          	END
    	
    END
    IF @cRef1='�տ��'
    BEGIN
    	
    	set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iAmount_f,0)),0) FROM '+@LbLdatabase+'..Ap_CloseBill a  left join '+@LbLdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
    	exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Lbdatabase+'..Ap_CloseBill a  left join '+@Lbdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
        set @LSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Ldatabase+'..Ap_CloseBill a  left join '+@Ldatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
        IF @LbLisum=0
          BEGIN
            IF @Lbisum=0
               BEGIN
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 =0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs1=isnull(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
            	   
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs1=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          	BEGIN
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs1=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
          	END
    	
    END
    IF @cRef2='���۶�'
    BEGIN
    	
    	set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iSum,0)),0) FROM '+@LbLdatabase+'..DispatchList d  left join '+@LbLdatabase+'..DispatchLists ds on d.DLID=ds.DLID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND d.cDepCode like '''+@cDepCode+'%'''
    	exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Lbdatabase+'..DispatchList d  left join '+@Lbdatabase+'..DispatchLists ds on d.DLID=ds.DLID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND d.cDepCode like '''+@cDepCode+'%'''
        exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
        set @LSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Ldatabase+'..DispatchList d  left join '+@Ldatabase+'..DispatchLists ds on d.DLID=ds.DLID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND d.cDepCode like '''+@cDepCode+'%'''
        exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
        IF @LbLisum=0
          BEGIN
            IF @Lbisum=0
               BEGIN
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 =0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=ISNULL(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
            	   
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs2=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          	BEGIN
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
          	END
    	
    END
    IF @cRef2='��Ʊ��'
    BEGIN
    	
    	set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iSum,0)),0) FROM '+@LbLdatabase+'..SaleBillVouch s  left join '+@LbLdatabase+'..SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND s.cDepCode like '''+@cDepCode+'%'''
    	exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Lbdatabase+'..SaleBillVouch s  left join '+@Lbdatabase+'..SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND s.cDepCode like '''+@cDepCode+'%'''
        exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
        set @LSQL = 'SELECT @isum=isnull(sum(isnull(iSum,0)),0) FROM '+@Ldatabase+'..SaleBillVouch s  left join '+@Ldatabase+'..SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE MONTH(dDate)='''+@iMonth+''' AND Year(dDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND s.cDepCode like '''+@cDepCode+'%'''
        exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
       IF @LbLisum=0
          BEGIN
            IF @Lbisum=0
               BEGIN
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 =0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=isnull(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
            	   
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs2=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          	BEGIN
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
          	END
    	
    END
    IF @cRef2='����'
    BEGIN
    	
    	set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iAmount_f,0)),0) FROM '+@LbLdatabase+'..Ap_CloseBill a  left join '+@LbLdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
    	exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Lbdatabase+'..Ap_CloseBill a  left join '+@Lbdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
        set @LSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Ldatabase+'..Ap_CloseBill a  left join '+@Ldatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
        IF @LbLisum=0
          BEGIN
            IF @Lbisum=0
               BEGIN
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 =0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=isnull(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
            	   
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs2=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          	BEGIN
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
          	END
    	
    END
    IF @cRef2='�տ��'
    BEGIN
    	
    	set @LbLSQL = 'SELECT @isum = isnull(sum(isnull(iAmount_f,0)),0) FROM '+@LbLdatabase+'..Ap_CloseBill a  left join '+@LbLdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-3))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
    	exec sp_executesql @LbLSQL,N'@isum DECIMAL(18,2) OUTPUT',@LbLisum OUTPUT
    	set @LbSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Lbdatabase+'..Ap_CloseBill a  left join '+@Lbdatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-2))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LbSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lbisum OUTPUT
        set @LSQL = 'SELECT @isum=isnull(sum(isnull(iAmount_f,0)),0) FROM '+@Ldatabase+'..Ap_CloseBill a  left join '+@Ldatabase+'..Ap_CloseBills ass on a.iID = ass.iID  WHERE MONTH(dVouchDate)='''+@iMonth+''' AND Year(dVouchDate)='''+CONVERT(VARCHAR(5),(year(GETDATE())-1))+''' AND a.cDeptCode like '''+@cDepCode+'%'''
        exec sp_executesql @LSQL,N'@isum DECIMAL(18,2) OUTPUT',@Lisum OUTPUT
        IF @LbLisum=0
          BEGIN
            IF @Lbisum=0
               BEGIN
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 =0 '
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=isnull(@Lisum*@LnRate/100,0)
               END
            ELSE
               BEGIN
            	   
                   SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0 '
                   exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                   SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 =0 and nRate2 <>0'
                   exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                   SET @cRefs2=isnull(@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
               END
          END
          ELSE
          	BEGIN
          		SET @nRate1= 'select @a=nRate1 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate1,N'@a DECIMAL(18,2) OUTPUT',@LbLnRate OUTPUT
                SET @nRate2= 'select @a=nRate2 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate2,N'@a DECIMAL(18,2) OUTPUT',@LbnRate OUTPUT
                SET @nRate3= 'select @a=nRate3 from SL_P_Refset where cDepCode='''+@cDepCode+''' and cRefType='''+@cRef1+''' and iMonth='''+@iMonth+'''and iYear='''+convert(Nvarchar(4),YEAR(GETDATE()))+''' and nRate1 <>0'
                exec sp_executesql @nRate3,N'@a DECIMAL(18,2) OUTPUT',@LnRate OUTPUT
                SET @cRefs2=isnull(@LbLisum*@LbLnRate/100+@Lbisum*@LbnRate/100+@Lisum*@LnRate/100,0)
          	END
    	
    END
    --PRINT @cRefs1
    --PRINT @cRefs2
    --SELECT @cRefs1 AS cRefs1 ,@cRefs2 AS cRefs2 
    INSERT INTO SalePlans
(
	-- ID -- this column value is auto-generated
	iYear,
	iMonth,
	dDate,
	cDepCode,
	cRefs1,
	cRefs2
)
VALUES
(
	YEAR(GETDATE()),
	@iMonth,
	GETDATE(),
	@cDepCode,
	@cRefs1,
	@cRefs2
	
)
SET @iMonth=@iMonth+1
    END
    
    fetch next from MyCursor into @cDepCode
END	
CLOSE MyCursor
DEALLOCATE MyCursor
END
GO

EXEC ProcSalePlans


--SELECT * FROM SalePlans
