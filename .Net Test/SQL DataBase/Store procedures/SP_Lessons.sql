USE [E-LEARNING]
GO

/****** Object:  StoredProcedure [dbo].[SP_LESSONS]    Script Date: 02/12/2019 10:24:39 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE  [dbo].[SP_LESSONS] (
	@Opcion int,
	@ID_course as int = 0,
	@ID_lesson as int = 0,
	@lesson_name as varchar (50) = '',
	@lesson_minPoints as int = 70,
	@lesson_order as int = 0
)
AS
SET NOCOUNT ON
BEGIN
	BEGIN TRY
		IF (@Opcion = 1) --Insertar leccion
			BEGIN
				declare @idLesson as int;
				insert into Lessons values (@ID_course, @lesson_name, @lesson_minPoints, @lesson_order, 'A')
				set @idLesson = SCOPE_IDENTITY();				
				SELECT @idLesson AS 'ID_lesson','OK' AS 'Result'
			END
		IF (@Opcion = 2) --Editar leccion
			BEGIN
				update Lessons set lesson_name = @lesson_name, lesson_minPoints = @lesson_minPoints where ID_lesson = @ID_lesson				
				SELECT 'OK' AS 'Result'
			END
		IF (@Opcion = 3) --Eliminar leccion
			BEGIN
				update Lessons SET [Status] ='E' where ID_lesson = @ID_lesson
				update Options SET [Status] ='E' where ID_question in (SELECT ID_question from questions where ID_lesson = @ID_lesson)
				update Questions SET [Status] ='E' where ID_lesson = @ID_lesson
				SELECT 'OK' AS 'Result'
			END
		IF (@Opcion = 4) --Consultar lecciones
			BEGIN
				SELECT ID_lesson, lesson_name, lesson_minPoints from lessons where [status] = 'A' and ID_course = @ID_course
			END		
		IF (@Opcion = 5) --Consultar lecciones
			BEGIN
				SELECT ID_lesson, lesson_name, lesson_minPoints from lessons where [status] = 'A' and ID_lesson = @ID_lesson
			END	
	END TRY
	BEGIN CATCH
		SELECT -1 AS ID, 'ERROR. ' + ERROR_MESSAGE() + ' SP: ' + ERROR_PROCEDURE() + ' ' + ERROR_LINE() AS Result
	END CATCH
END
GO


