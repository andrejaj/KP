USE [KPProducts]
GO

/****** Object:  Table [dbo].[ItemCondition]    Script Date: 25/01/2023 15:59:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemCondition](
	[Id] [smallint] NOT NULL,
	[Description] [nchar](20) NOT NULL,
 CONSTRAINT [PK_ItemCondition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[ItemCondition] (Id, Description) VALUES (1, 'DamagedCondition')
GO
INSERT INTO [dbo].[ItemCondition] (Id, Description) VALUES (2, 'NewCondition')
GO
INSERT INTO [dbo].[ItemCondition] (Id, Description) VALUES (3, 'RefurbishedCondition')
GO
INSERT INTO [dbo].[ItemCondition] (Id, Description) VALUES (4, 'UsedCondition')
GO