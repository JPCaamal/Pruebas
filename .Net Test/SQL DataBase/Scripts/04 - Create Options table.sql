USE [E-LEARNING]
GO

/****** Object:  Table [dbo].[Options]    Script Date: 02/12/2019 10:21:34 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Options](
	[ID_option] [int] IDENTITY(1,1) NOT NULL,
	[ID_question] [int] NOT NULL,
	[option_description] [varchar](100) NOT NULL,
	[option_value] [bit] NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[ID_option] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


