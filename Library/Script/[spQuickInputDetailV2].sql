USE [LABLink_VNIO]
GO
/****** Object:  StoredProcedure [dbo].[spQuickInputDetailV2]    Script Date: 11/22/2011 09:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[spQuickInputDetailV2]
(
@pPatient_ID int,
@TestTypeID int
--@pTestDate nvarchar(10)
)
AS
SELECT T.* ,
( SELECT TOP 1 Test_ID 
                  FROM T_TEST_INFO 
                  WHERE TESTTYPE_ID=T.TESTTYPE_ID
                  AND Patient_ID=@pPatient_ID
                  AND (@TestTypeID=-3 OR TESTTYPE_ID=@TestTypeID)
                  --AND convert(nvarchar(10),TEST_DATE,103)=@pTestDate
) AS Test_ID,
( SELECT TOP 1  Barcode 
                  FROM T_TEST_INFO 
                  WHERE TESTTYPE_ID=T.TESTTYPE_ID
                  AND Patient_ID=@pPatient_ID
	    AND (@TestTypeID=-3 OR TESTTYPE_ID=@TestTypeID)
             --   AND convert(nvarchar(10),TEST_DATE,103)=@pTestDate
) AS Barcode
FROM
(
SELECT 1 as CHON,DATACONTROL_ID,DATA_NAME as Para_Name, ' ' as Test_Result,
ALIAS_NAME,DATA_NAME ,DEVICE_ID,Data_Sequence,Measure_Unit,Normal_Level,Normal_LevelW,Data_Print,
ISNULL((SELECT  TOP 1 TESTTYPE_ID 
FROM D_DEVICE_LIST
WHERE DEVICE_ID=D.DEVICE_ID
AND (@TestTypeID=-3 OR TESTTYPE_ID=@TestTypeID)
),N'') AS TESTTYPE_ID,
ISNULL((SELECT  TOP 1 TESTTYPE_NAME FROM T_TEST_TYPE_LIST WHERE TESTTYPE_ID=
(SELECT TESTTYPE_ID 
FROM D_DEVICE_LIST
WHERE DEVICE_ID=D.DEVICE_ID
AND (@TestTypeID=-3 OR TESTTYPE_ID=@TestTypeID))
),N'') AS TESTTYPE_NAME
FROM D_DATA_CONTROL  D
) T
WHERE  
NOT EXISTS (SELECT TEST_RESULT FROM T_RESULT_DETAIL WHERE TESTTYPE_ID=T.TESTTYPE_ID
AND PATIENT_ID=@pPatient_ID
AND upper(PARA_NAME)=upper(T.Para_Name)
--AND convert(nvarchar(10),TEST_DATE,103)=@pTestDate
AND (@TestTypeID=-3 OR TESTTYPE_ID=@TestTypeID)
)
AND EXISTS (SELECT * FROM T_TEST_INFO WHERE TESTTYPE_ID=T.TESTTYPE_ID
AND PATIENT_ID=@pPatient_ID
--AND upper(PARA_NAME)=upper(T.Para_Name)
--AND convert(nvarchar(10),TEST_DATE,103)=@pTestDate
AND (@TestTypeID=-3 OR TESTTYPE_ID=@TestTypeID)
)
ORDER BY T.DATACONTROL_ID ASC


