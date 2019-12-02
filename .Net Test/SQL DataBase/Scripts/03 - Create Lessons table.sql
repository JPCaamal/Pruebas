USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Lessons]    Script Date: 02/12/2019 10:21:13 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lessons](
	[ID_lesson] [int] IDENTITY(1,1) NOT NULL,
	[ID_course] [int] NOT NULL,
	[lesson_name] [varchar](50) NOT NULL,
	[lesson_minPoints] [int] NOT NULL,
	[lesson_order] [int] NOT NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[ID_lesson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


