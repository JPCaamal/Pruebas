USE [E-LEARNING]
GO

/****** Object:  StoredProcedure [dbo].[SP_QUESTIONS]    Script Date: 02/12/2019 10:26:09 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE  [dbo].[SP_QUESTIONS] (
	@Opcion int,
	@ID_lesson as int = 0,

	@ID_question as int = 0,
	@question_description as varchar(300)='',
	@question_order as int = 0,
	@question_type as char(1) = '1',
	@question_points as int = 0,
	@ID_option as int = 0,
	@option_description as varchar(100) = '',
	@option_value as bit = 0
)
AS
SET NOCOUNT ON
BEGIN
	BEGIN TRY		
		IF (@Opcion = 1) --Insertar pregunta
			BEGIN
				declare @idQuestion as int;
				insert into Questions values (@ID_lesson, @question_description,
				@question_order, @question_type, @question_points, 'A')
				set @idQuestion = SCOPE_IDENTITY();
				
				SELECT @idQuestion AS 'ID_Question','OK' AS 'Result'
			END
		IF (@Opcion = 2) --Editar pregunta
			BEGIN
				update Questions set
				question_description =  @question_description,
				question_points = @question_points,
				question_type = @question_type
				where ID_question = @ID_question				
				SELECT 'OK' AS 'Result'
			END
		IF (@Opcion = 3) --Eliminar pregunta
			BEGIN
				update Questions SET [Status] ='E' where ID_question = @ID_question
				update Options SET [Status] = 'E' where  ID_question = @ID_question
				SELECT 'OK' AS 'Result'
			END
		IF (@Opcion = 4) --Conusltar preguntas
			BEGIN
			SELECT q.ID_question, q.question_description,q.question_type,q.question_points, o.ID_option,
				   o.option_description, o.option_value
			FROM Questions as q
			left join Options as o on o.ID_question=q.ID_question
			WHERE ID_lesson = @ID_lesson and q.[Status] = 'A' and o.[Status] = 'A'
			END
		IF (@Opcion = 5) --Insertar opciones
			BEGIN
				declare @idOption as int;
				insert into Options values (@ID_question,@option_description,@option_value,'A')
				set @idOption = SCOPE_IDENTITY();
				
				SELECT @idOption AS 'ID_option','OK' AS 'Result'
			END
		IF (@Opcion = 6) --Editar opciones
			BEGIN
				update Options set
				@option_description =  @question_description,
				@option_value = @question_points		
				where ID_option = @ID_option				
				SELECT 'OK' AS 'Result'
			END
		IF (@Opcion = 7) --Eliminar opciones
			BEGIN
				update Options SET [Status] ='E' where ID_option = @ID_option
				SELECT 'OK' AS 'Result'
			END
	END TRY
	BEGIN CATCH
		SELECT -1 AS ID, 'ERROR. ' + ERROR_MESSAGE() + ' SP: ' + ERROR_PROCEDURE() + ' ' + ERROR_LINE() AS Respuesta
	END CATCH
END
GO

