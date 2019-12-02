USE [E-LEARNING]
GO

/****** Object:  StoredProcedure [dbo].[SP_PROFESSORS]    Script Date: 02/12/2019 10:25:58 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE  [dbo].[SP_PROFESSORS] (

	@professor_number as nvarchar(8) = '',
	@professor_password as nvarchar(300) = ''
)
AS
SET NOCOUNT ON
BEGIN
	BEGIN TRY
		IF EXISTS(select ID_professor from Professors where professor_number = @professor_number and professor_password = @professor_password)
		begin
		declare @idProfessor as int
			set @idProfessor = (SELECT  ID_professor from Professors where professor_number = @professor_number)
			SELECT  @idProfessor as 'ID_professor', 'OK' as 'Result'
		end
	END TRY
	BEGIN CATCH
		SELECT -1 AS ID, 'ERROR. ' + ERROR_MESSAGE() + ' SP: ' + ERROR_PROCEDURE() + ' ' + ERROR_LINE() AS Respuesta
	END CATCH
END
GO

