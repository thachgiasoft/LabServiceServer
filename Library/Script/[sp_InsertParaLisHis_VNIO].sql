set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[sp_InsertParaLisHis_VNIO]
(
	@pMed_ParamId NVARCHAR(50),
	@pMed_ParaName NVARCHAR(100),
	@pLis_ParaName NVARCHAR(100),
	@pDevicesId int
)
AS
IF NOT EXISTS(SELECT * FROM tbl_ParamMapping tpm WHERE tpm.Med_ParamID=@pMed_ParamId)
INSERT INTO tbl_ParamMapping
(
	Med_ParamID,
	Med_ParaName,
	Lis_ParaName,
	Device_ID
)
VALUES
(
	@pMed_ParamId,
	@pMed_ParaName,
	@pLis_ParaName,
	@pDevicesId
	
)
ELSE UPDATE tbl_ParamMapping
     SET
     	Med_ParaName = @pMed_ParaName,
     	Lis_ParaName = @pLis_ParaName,
     	Device_ID = @pDevicesId 
     WHERE Med_ParamID=@pMed_ParamId

