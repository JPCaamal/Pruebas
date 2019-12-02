USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 02/12/2019 10:23:16 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[ID_student] [int] IDENTITY(1,1) NOT NULL,
	[student_name] [varchar](50) NOT NULL,
	[student_lastName] [varchar](50) NOT NULL,
	[student_number] [nvarchar](8) NOT NULL,
	[student_password] [nvarchar](300) NOT NULL,
	[student_status] [char](1) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


