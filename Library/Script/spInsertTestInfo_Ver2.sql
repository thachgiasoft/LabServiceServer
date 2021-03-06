SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE spInsertTestInfo_Ver2
    (
      @TestType_ID SMALLINT ,
      @Patient_ID INT ,
      @Barcode NVARCHAR(50) ,
      @Test_Date DATETIME ,
      @TestStatus SMALLINT,
      @TestId NUMERIC(18) OUTPUT
    )
AS 
    INSERT  INTO T_TEST_INFO
            ( TestType_ID ,
              Patient_ID ,
              Barcode ,
              Test_Date ,
              Require_Date ,
              Test_Status
                
            )
    VALUES  ( @TestType_ID ,
              @Patient_ID ,
              @Barcode ,
              @Test_Date ,
              @Test_Date ,
              @TestStatus                
            )
	SET @TestId= SCOPE_IDENTITY()