USE [E-LEARNING]
GO

/****** Object:  StoredProcedure [dbo].[SP_COURSES]    Script Date: 02/12/2019 10:24:05 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE  [dbo].[SP_COURSES] (
	@Opcion int,
	@ID_course as int = 0,
	@course_name as varchar (50) = '',
	@course_order as int = 0
)
AS
SET NOCOUNT ON
BEGIN
	BEGIN TRY
		IF (@Opcion = 1) --Insertar curso
			BEGIN
				declare @idCourse as int;
				insert into Courses values (@course_name,@course_order, 'A')
				set @idCourse = SCOPE_IDENTITY();
				SELECT @idCourse AS 'ID_course','OK' AS 'Result'
			END
		IF (@Opcion = 2) --Editar curso
			BEGIN
				update Courses set course_name = @course_name where ID_course = @ID_course				
				SELECT 'OK' AS 'Result'
			END
		IF (@Opcion = 3) --Eliminar curso
			BEGIN
				update Courses SET [Status] ='E' where ID_course = @ID_course
				update options SET [Status] ='E' where ID_question in (SELECT ID_question from Questions where ID_lesson in (select ID_lesson from lessons where ID_course = @ID_course))
				update questions set [Status] = 'E' where ID_lesson in (SELECT ID_lesson from lessons where ID_course = @ID_course)
				update lessons SET [Status] ='E' where ID_course = @ID_course
				SELECT 'OK' AS 'Result'
			END
		IF (@Opcion = 4) --Consultar cursos
			BEGIN
				SELECT ID_course, Course_name, course_order from courses where [status] = 'A'				
			END		
	END TRY
	BEGIN CATCH
		SELECT -1 AS ID, 'ERROR. ' + ERROR_MESSAGE() + ' SP: ' + ERROR_PROCEDURE() + ' ' + ERROR_LINE() AS Result
	END CATCH
END
GO


