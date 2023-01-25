USE [KPProducts]
GO

/****** Object:  Table [dbo].[ItemAvailability]    Script Date: 25/01/2023 15:59:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemAvailability](
	[Id] [smallint] NOT NULL,
	[Description] [nchar](20) NULL,
 CONSTRAINT [PK_ItemAvailability] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (1, 'BackOrder')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (2, 'Discontinued')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (3, 'InStock')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (4, 'InStoreOnly')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (5, 'LimitedAvailability')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (6, 'OnlineOnly')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (7, 'OutOfStock')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (8, 'PreOrder')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (9, 'PreSale')
GO
INSERT INTO [dbo].[ItemAvailability] (Id, Description) VALUES (10, 'SoldOut')
GO