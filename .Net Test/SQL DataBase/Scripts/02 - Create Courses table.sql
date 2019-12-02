USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 02/12/2019 09:08:45 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Courses](
	[ID_course] [int] IDENTITY(1,1) NOT NULL,
	[course_name] [varchar](50) NOT NULL,
	[course_order] [int] NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[ID_course] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


