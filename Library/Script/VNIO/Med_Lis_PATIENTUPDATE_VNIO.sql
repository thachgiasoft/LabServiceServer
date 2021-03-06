/************************************************************
 * Code formatted by SoftTree SQL Assistant © v6.0.70
 * Time: 23/04/2012 17:14:59
 ************************************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Med_Lis_PATIENTUPDATE]
(
    @PID        NVARCHAR(50),
    @Name       NVARCHAR(100),
    @Diachi     NVARCHAR(200),
    @bed        NVARCHAR(300),
    @khoa       NVARCHAR(200),
    @Age        INT,
    @Year       INT,
    @sex        BIT,
    @test_date  DATETIME,
    @dichVu     INT,
    @chandoan   NVARCHAR(300)
)
AS
	IF EXISTS(
	       SELECT 1
	       FROM   L_PATIENT_INFO
	       WHERE  PID = @PID
	   )
	BEGIN
	    UPDATE L_PATIENT_INFO
	    SET    PATIENT_NAME  = @Name,
	           [Address]     = @Diachi,
	           Bed           = @bed,
	           Room          = @khoa,
	           AGE           = @Age,
	           YEAR_BIRTH    = @Year,
	           SEX           = @sex,
	           DATEUPDATE    = @test_date,
	           ObjectType    = @dichVu,
	           Diagnostic    = @chandoan
	    WHERE  PID           = @PID
	END
	ELSE
	BEGIN
	    INSERT INTO L_PATIENT_INFO
	      (
	        PID,
	        PATIENT_NAME,
	        [Address],
	        Bed,
	        Room,
	        AGE,
	        YEAR_BIRTH,
	        SEX,
	        DATEUPDATE,
	        ObjectType,
	        Diagnostic
	      )
	    VALUES
	      (
	        @PID,
	        @Name,
	        @Diachi,
	        @bed,
	        @khoa,
	        @Age,
	        @Year,
	        @sex,
	        dbo.trunc(@test_date),
	        @dichVu,
	        @chandoan
	      )
	END
