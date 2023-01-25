USE [KPProducts]
GO

/****** Object:  Table [dbo].[Status]    Script Date: 25/01/2023 16:10:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Status](
	[Id] [smallint] NOT NULL,
	[Description] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Status] (Id, Description) VALUES (1, 'Active')
GO
INSERT INTO [dbo].[Status] (Id, Description) VALUES (2, 'Deactive')
GO
INSERT INTO [dbo].[Status] (Id, Description) VALUES (3, 'OnHold')
GO

