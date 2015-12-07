
--SELECT * FROM  TFERP_DYRC..[TF_NavItem] WHERE Code LIKE '%S02-08%' OR  Code LIKE '%S02-10%' 
--SELECT * FROM TFERP_DYRC..TF_ExecObject WHERE EOCode LIKE '%CC_DS%' OR EOCode LIKE '%CC_XC%'

--SELECT [BOCode], [BOName], [BOType], [Description] 
--FROM TFERP_DYRC..TF_BusinessObject
--WHERE BOType LIKE   '%S02-08%' OR  BOType LIKE '%S02-10%' 

--SELECT * FROM TFERP_DYRC..TF_BOEO WHERE EOCode IN (
--SELECT EOCode FROM dbo.TF_NavItem WHERE code LIKE 'S02-08%' OR code LIKE 'S02-10%')

--SELECT * FROM TFERP_DYRC..TF_BOAuth 
--WHERE BOCode IN (SELECT EOCode FROM dbo.TF_NavItem WHERE code LIKE 'S02-08%' OR code LIKE 'S02-10%')




--SELECT * FROM  [TF_NavItem] WHERE Code LIKE '%DS001%'
--SELECT * FROM TF_ExecObject  WHERE EOCode IN ('DS001','DS002','DS003','DS004','DS005','DS006','DS007','DS008','DS009','DS010',
--'DS011','DS012','DS013','DS014','DS015','DS016','DS017','DS018','DS019','DS020','DS021','DS022','DS023','DS024','DS025','DS026',
--'DS027','DS028','DS029','DS030','DS031')
--SELECT * FROM dbo.TF_BOEO WHERE EOCode IN (
--SELECT EOCode FROM dbo.TF_NavItem WHERE Code LIKE '%DS001%')

--SELECT * FROM dbo.TF_BOAuth 
--WHERE BOCode IN (SELECT EOCode FROM dbo.TF_NavItem WHERE Code LIKE '%DS001%')

--SELECT [BOCode], [BOName], [BOType], [Description] 
--FROM TF_BusinessObject
--WHERE BOType LIKE   '%DS001%' 




--DELETE FROM dbo.TF_BOEO WHERE EOCode IN (SELECT EOCode FROM dbo.TF_NavItem WHERE Code LIKE '%DS001%')
--DELETE FROM dbo.TF_BOAuth WHERE BOCode IN (SELECT EOCode FROM dbo.TF_NavItem WHERE Code LIKE '%DS001%')
--DELETE FROM TF_BusinessObject WHERE BOType LIKE   '%DS001%' 
--DELETE FROM TF_BusinessObject WHERE BOType LIKE   '%S02-08%' OR  BOType LIKE '%S02-10%' 
--DELETE FROM  [TF_NavItem] WHERE Code LIKE '%DS001%'
--DELETE FROM TF_ExecObject  WHERE EOCode IN ('DS001','DS002','DS003','DS004','DS005','DS006','DS007','DS008','DS009','DS010',
--'DS011','DS012','DS013','DS014','DS015','DS016','DS017','DS018','DS019','DS020','DS021','DS022','DS023','DS024','DS025','DS026',
--'DS027','DS028','DS029','DS030','DS031')



INSERT INTO [TF_SubSystem]
        ([SubSysCode], [SubSysName], [SubSysSign])
Select [SubSysCode], [SubSysName], [SubSysSign] 
 From TFERP_DYRC..TF_SubSystem WHERE SubSysCode LIKE '%S02-10%' OR SubSysCode LIKE '%S02-08%'  




INSERT INTO [TF_ExecObject]
        ([EOCode], [EOName], [EOType], [Path], [IsDialog], [ConstructorArgs], 
         [Description])
SELECT [EOCode], [EOName], [EOType], [Path], [IsDialog], [ConstructorArgs], 
         [Description] FROM TFERP_DYRC..TF_ExecObject
WHERE EOCode LIKE '%CC_DS%' OR EOCode LIKE '%CC_XC%'

INSERT INTO [TF_NavItem]
        ([Code], [Name], [SequenceNo], [Sign], [Icon], [ParentCode], 
         [Level], [EOCode], [ConstructorArgs], [IsSystem], [IsDialog], [Description])
SELECT [Code], [Name], [SequenceNo], [Sign], [Icon], [ParentCode], 
         [Level], [EOCode], [ConstructorArgs], [IsSystem], [IsDialog], [Description]
          FROM TFERP_DYRC..TF_NavItem
 WHERE Code LIKE '%S02-08%' OR  Code LIKE '%S02-10%' 
 
 
INSERT INTO [TF_BOEO]
        ([BOCode], [EOCode])
SELECT [BOCode], [EOCode]
FROM TFERP_DYRC..TF_BOEO
 WHERE EOCode IN (
SELECT EOCode FROM dbo.TF_NavItem WHERE code LIKE 'S02-08%' OR code LIKE 'S02-10%')

INSERT INTO [TF_BOAuth]
        ([BOCode], [AuthCode], [Index], [AuthName], [AuthMask], [Description])
SELECT [BOCode], [AuthCode], [Index], [AuthName], [AuthMask], [Description]
FROM TFERP_DYRC..TF_BOAuth
WHERE BOCode IN (SELECT EOCode FROM dbo.TF_NavItem WHERE code LIKE 'S02-08%' OR code LIKE 'S02-10%')
 
INSERT INTO [TF_BusinessObject]
        ([BOCode], [BOName], [BOType], [Description])
SELECT [BOCode], [BOName], [BOType], [Description] 
FROM TFERP_DYRC..TF_BusinessObject
WHERE BOType LIKE   '%S02-08%' OR  BOType LIKE '%S02-10%' 

 