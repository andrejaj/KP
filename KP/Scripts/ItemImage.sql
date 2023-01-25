USE [KPProducts]
GO

/****** Object:  Table [dbo].[ItemImage]    Script Date: 25/01/2023 15:59:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemImage](
	[Id] [uniqueidentifier] NOT NULL,
	[url] [nchar](300) NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemImage] ADD  CONSTRAINT [DF_ItemImage_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[ItemImage] ADD  CONSTRAINT [DF_ItemImage_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[ItemImage] ADD  CONSTRAINT [DF_ItemImage_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


