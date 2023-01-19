USE [KPProducts]
GO

/****** Object:  Table [dbo].[Offer]    Script Date: 19/01/2023 14:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemOffer](
	[Id] [uniqueidentifier] NOT NULL,
	[Sku] [bigint] NULL,
	[PriceCurrency] [nchar](4) NULL,
	[Price] [int] NULL,
	[Condition] [int] NULL,
	[SellerId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[PriceNote] [nvarchar](15) NULL,
	[Status] [int] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


