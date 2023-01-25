USE [KPProducts]
GO

/****** Object:  Table [dbo].[Currency]    Script Date: 23/01/2023 17:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Currency](
	[Id] [smallint] NOT NULL,
	[Description] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Currency] (Id, Description) VALUES (1, 'Euro')
GO
INSERT INTO [dbo].[Currency] (Id, Description) VALUES (2, 'RSD')
GO

