set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROCEDURE [dbo].[sp_GetAllDoctoranDepartment]
AS   SELECT DISTINCT 1 AS CHON,  idkhoa, khoa
        FROM tblHisLis_PatientInfo_VNIO v-- WHERE test_date='2012-02-14'     
      SELECT DISTINCT 1 chon ,bacSyDieuTri, idBacSyDieuTri
        FROM tblHisLis_PatientInfo_VNIO
        SELECT DISTINCT 1 CHON,dbo.ConvertNoiTru(T.noiTru)AS noitru,dbo.NOINGOAITRU(T.noiTru)AS NOINGOATRU
        FROM tblHisLis_PatientInfo_VNIO T


