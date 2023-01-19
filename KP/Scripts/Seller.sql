USE [KPProducts]
GO

/****** Object:  Table [dbo].[Seller]    Script Date: 19/01/2023 14:56:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Seller](
	[Name] [nvarchar](50) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Phone] [nchar](12) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Seller_Id]  DEFAULT (newid()) FOR [Id]
GO


