USE [KPProducts]
GO

/****** Object:  Table [dbo].[PriceType]    Script Date: 25/01/2023 15:54:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PriceType](
	[PriceTypeId] [smallint] NOT NULL,
	[Description] [nchar](10) NOT NULL,
 CONSTRAINT [PK_PriceType] PRIMARY KEY CLUSTERED 
(
	[PriceTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (1, 'Kontakt')
GO
INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (2, 'Dogovor')
GO
INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (3, 'Pozvati')
GO
INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (4, 'Kupujem')
GO


