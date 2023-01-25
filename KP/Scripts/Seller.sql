USE [KPProducts]
GO

/****** Object:  Table [dbo].[Seller]    Script Date: 25/01/2023 16:21:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Seller](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[Phone] [nchar](15) NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Seller_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Seller_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Seller_Modified]  DEFAULT (getdate()) FOR [Modified]
GO