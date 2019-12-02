USE [E-LEARNING]
GO

/****** Object:  StoredProcedure [dbo].[SP_STUDENTS]    Script Date: 02/12/2019 10:26:20 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE  [dbo].[SP_STUDENTS] (
	@Opcion int,
	@ID_student as int = 0,
	@ID_course as int = 0,
	@lesson_points as int = 0,
	@ID_lesson as int = 0,
	@student_name as varchar(50) = '',
	@student_lastName as varchar(50) = '',
	@student_number as nvarchar(8) = '',
	@student_password as nvarchar(300) = ''
)
AS
SET NOCOUNT ON
BEGIN
	BEGIN TRY

	IF(@Opcion = 0)
	BEGIN
		IF EXISTS(select ID_student from Students where student_number = @student_number and student_password = @student_password)
		begin
		declare @idStudent as int
			set @idStudent = (SELECT  ID_student from Students where student_number = @student_number)
			SELECT  @idStudent as 'ID_student', 'OK' as 'Result'
		end
	END

	IF (@Opcion = 1) --agregar student
			BEGIN
				
				insert into Students values (@student_name, @student_lastName,@student_number,@student_password,'A') 
				set @idStudent = SCOPE_IDENTITY();
				SELECT @idStudent AS 'ID_student'
			END
	IF (@Opcion = 2) --Asignar curso
		BEGIN
			IF NOT EXISTS(select @ID_student from Student_Courses where ID_student = ID_student and ID_course = @ID_course)
			BEGIN
			declare @minCourseID as int;
			set @minCourseID = (select MIN(ID_course) from courses where ID_course not in (select id_course from Student_Courses where ID_student=@idStudent and course_status = 'A'))
			if(@ID_course = @minCourseID)
			begin
				insert into Student_Courses values (@ID_student, @ID_course, 'A') --status A - asignado
				declare @idLesson as int;
				set @idLesson = (select top 1 ID_lesson from courses as c
									left join lessons as l on l.ID_course = c.ID_course
									where c.ID_course = @ID_course AND l.[status] = 'A' order by l.ID_lesson )

				insert into Student_Lessons values (@ID_student,@idLesson, 0,'A') --status A - asignado
				SELECT 'OK' AS 'Result'
			end
			else
			begin
			SELECT 'No se permite asignar este curso' AS 'Result'
			end				
			END
			else
			begin
			SELECT 'Ya se ha asignado este curso' AS 'Result'
			end
		END
	IF (@Opcion = 3) --Calificar lección
		BEGIN
			declare @countLessons as int;
			declare @countLessonsPassed as int;
			declare @countCourses as int;
			declare @countCoursesPassed as int;

			set @countCourses = (SELECT COUNT(ID_Course) from Courses where [status] = 'A')
			set @countCoursesPassed = (SELECT COUNT(ID_Course) 
										from Student_Courses 
										where course_status = 'P' and ID_student = @ID_student)

			IF(@countCoursesPassed <@countCourses)
			BEGIN
				update Student_Lessons set lesson_points = @lesson_points, lesson_status = 'P' 
										where ID_lesson = @ID_lesson AND ID_student = @ID_student
								
			set @countLessons = (SELECT COUNT(ID_lesson) from lessons where ID_course = (select ID_course from Student_Courses where ID_student = @ID_student and course_status = 'A'))
			set @countLessonsPassed = (SELECT COUNT(ID_lesson) 
										from Student_Lessons 
										where lesson_status = 'P' AND ID_student = @ID_student and ID_lesson in (select ID_lesson 
																													from lessons 
																													where ID_course  = (select ID_course 
																																		from Student_Courses 
																																		where ID_student = @ID_student and course_status = 'A')))

				if(@countLessonsPassed < @countLessons)
					BEGIN
						set @idLesson = (select top 1 ID_lesson from Student_Courses as sc 
										inner join lessons as l on l.ID_course = sc.ID_course 
										where l.[status] = 'A' and sc.ID_student = @ID_student and 
											ID_lesson not in (Select ID_lesson from Student_Lessons 
																where ID_student = @ID_student and lesson_status = 'P'))

						insert into Student_Lessons values (@ID_student,@idLesson, 0,'A') --status A - asignado
					END
			--	else if(@countLessonsPassed = @countLessons)
			--	BEGIN
			--		update Student_Courses set course_status = 'P' 
			--							where ID_student = @ID_student and course_status = 'A'

			--	declare @idCourse as int;
			--	set @idCourse = (select top 1 ID_Course 
			--						    from Courses 
			--							where [Status] = 'A' and ID_course not in (SELECT ID_course from Student_Courses where course_status = 'P' and ID_student = @ID_student))


			--							insert into Student_Courses values (@ID_student, @idCourse, 'A') --status A - asignado
			 
			--set @idLesson = (select top 1 ID_lesson from courses as c
			--				    left join lessons as l on l.ID_course = c.ID_course
			--					where c.ID_course = @idCourse AND l.[status] = 'A' order by l.ID_lesson )

			--insert into Student_Lessons values (@ID_student,@idLesson, 0,'A') --status A - asignado
			--	END
			END					
			SELECT 'OK' AS 'Result'
		END
	IF (@Opcion = 4) --Estatus studiante
	BEGIN
		SELECT sc.ID_course, c.course_name, sl.ID_lesson, l.lesson_name 
		FROM Student_Courses as sc
		left join Student_Lessons as sl on sl.ID_student = sc.ID_student
		left join courses as c on c.ID_course = sc.ID_course and c.[Status]='A'
		left join lessons as l on l.ID_lesson = sl.ID_lesson and l.[Status]='A'
		WHERE sc.ID_student = @ID_student and course_status = 'A' and lesson_status = 'A' 
	END
	IF (@Opcion = 5) --Cursos
	BEGIN
		select c.ID_course, course_name, course_status from Courses as c
		left join Student_Courses as sc on sc.ID_course = c.ID_course and sc.ID_student = @ID_student
		where 
		 c.[Status] = 'A'
	END
	IF (@Opcion = 6) --lecciones
	BEGIN
	--	set @idCourse = (SELECT ID_course from Student_Courses where ID_student = @ID_student and course_status = 'A')

		select l.ID_lesson, lesson_name, lesson_minPoints, lesson_status from lessons as l
		left join Student_Lessons as sl on sl.ID_lesson = l.ID_lesson and sl.ID_student = @ID_student
		where ID_course = @ID_course and l.[Status] = 'A'
	END
	END TRY
	BEGIN CATCH
		SELECT -1 AS ID, 'ERROR. ' + ERROR_MESSAGE() + ' SP: ' + ERROR_PROCEDURE() + ' ' + ERROR_LINE() AS Respuesta
	END CATCH
END
GO

