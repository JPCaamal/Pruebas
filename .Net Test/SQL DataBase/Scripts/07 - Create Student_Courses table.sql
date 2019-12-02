USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Student_Courses]    Script Date: 02/12/2019 10:22:35 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student_Courses](
	[ID_student_courses] [int] IDENTITY(1,1) NOT NULL,
	[ID_student] [int] NOT NULL,
	[ID_course] [int] NOT NULL,
	[course_status] [char](1) NOT NULL,
 CONSTRAINT [PK_Student_Courses] PRIMARY KEY CLUSTERED 
(
	[ID_student_courses] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


