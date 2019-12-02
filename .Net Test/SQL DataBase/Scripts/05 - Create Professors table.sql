USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Professors]    Script Date: 02/12/2019 10:21:50 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Professors](
	[ID_professor] [int] IDENTITY(1,1) NOT NULL,
	[professor_name] [varchar](50) NOT NULL,
	[professor_lastName] [varchar](50) NOT NULL,
	[professor_number] [nvarchar](8) NOT NULL,
	[professor_password] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ID_professor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


