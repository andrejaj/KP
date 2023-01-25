USE [KPProducts]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 25/01/2023 16:09:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[Id] [uniqueidentifier] NOT NULL,
	[Sku] [bigint] NULL,
	[Description] [nchar](300) NULL,
	[CurrencyId] [smallint] NULL,
	[Price] [int] NULL,
	[PriceTypeId] [smallint] NULL,
	[ConditionId] [smallint] NULL,
	[SellerId] [uniqueidentifier] NOT NULL,
	[StatusId] [int] NULL,
	[PriceValidUntil] [datetime] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


