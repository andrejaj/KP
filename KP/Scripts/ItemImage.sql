USE [KPProducts]
GO

/****** Object:  Table [dbo].[ProductImage]    Script Date: 19/01/2023 14:32:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemImage](
	[Id] [uniqueidentifier] NOT NULL,
	[url] [nvarchar](50) NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemImage] ADD  CONSTRAINT [DF_ItemImage_Id]  DEFAULT (newid()) FOR [Id]
GO


