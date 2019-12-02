USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Student_Lessons]    Script Date: 02/12/2019 10:22:54 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student_Lessons](
	[ID_student_lesson] [int] IDENTITY(1,1) NOT NULL,
	[ID_student] [int] NOT NULL,
	[ID_lesson] [int] NOT NULL,
	[lesson_points] [int] NOT NULL,
	[lesson_status] [char](1) NOT NULL,
 CONSTRAINT [PK_Student_Lessons] PRIMARY KEY CLUSTERED 
(
	[ID_student_lesson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


