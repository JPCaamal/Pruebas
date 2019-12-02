USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Questions]    Script Date: 02/12/2019 10:22:08 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Questions](
	[ID_question] [int] IDENTITY(1,1) NOT NULL,
	[ID_lesson] [int] NOT NULL,
	[question_description] [varchar](300) NOT NULL,
	[question_order] [int] NOT NULL,
	[question_type] [char](1) NOT NULL,
	[question_points] [int] NOT NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[ID_question] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


