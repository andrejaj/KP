USE master 
GO

ALTER database KPProducts set single_user with rollback immediate
GO

DROP DATABASE KPProducts;

GO

CREATE DATABASE KPProducts;

GO

/****** Authors table  ******/
USE [KPProducts]
GO

/****** Object:  Table [dbo].[Author]    Script Date: 25/01/2023 15:26:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Author](
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Nickname] [nvarchar](15) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

/*** insert authors****/
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Stanislav','Belozanski', 'Stasa')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milos','Sobajic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milos','Golubovic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zora','Petrovic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zora','Popovic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ivan','Radović',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zivan','Vulic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Nikola','Besevic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milica','Besevic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Uros','Toskovic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Uros','Predic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Boris','Rumjancev',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Sava','Stojkov',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Beta','Vukanovic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Mica','Popovic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Svetislav','Vukovic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Stojan','Trumic',NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milena','Pavlovic', 'Barili')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Stojan','Celic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Spomenka', 'Pavlovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Petar', 'Tijesic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Svetolik', 'Lukic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Marko', 'Stupar', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Nikola', 'Graovac', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Jovan', 'Krizek', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Sergej', 'Aparin', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Petar', 'Omcikus', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Vladimir', 'Zelinski', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ljubica', 'Sokic', 'Cuca')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Stepan', 'Kolesnikov', 'Fedor')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Pasko', 'Vucetic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milos', 'Vuskovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milan', 'Cetic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Vinko', 'Grdan', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ante', 'Abramovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Petar', 'Markovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Paja', 'Jovanovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Kosta', 'Hakman', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milos', 'Gvozdenovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Sinisa', 'Vukovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Jelisaveta', 'Petrovic', NULL)
GO
--additional authors
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Pero', 'Popovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Branko', 'Radulovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Todor', 'Svrakic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Mihailo', 'Milovanovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Jovan', 'Bijelic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Stojan', 'Aralica', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Stevan', 'Calic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Borislav', 'Bogdanovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ljubisa', 'Valic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Branko', 'Jevtic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milan', 'Arsic', 'Daskalo')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milenko', 'Duric', 'D')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Bosiljka', 'Valic', 'Jovancic')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Dusan', 'Adamovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Lukijan', 'Bibic', 'Borislav')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Majda', 'Kurnik', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Đorđe', 'Andrejević', 'Kun')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Antun', 'Augustincic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Marko', 'Celebonovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Avgust', 'Cernigoja', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Marijan', 'Detoni', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Petar', 'Dobrovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Lozje', 'Dolinar', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Vilko', 'Gecan', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Krsto', 'Hegedusic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Rihard', 'Jakopič', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ignjat', 'Job', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milan', 'Konjović', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('France', 'Kralj', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Tone', 'Kralj', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Frano', 'Kršinić', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Mirko', 'Kujacic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milo', 'Milunovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Petar', 'Palavicini', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Mihajlo', 'Petrov', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Vasa', 'Pomorišac', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Marko', 'Ristić', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Toma', 'Rosandić', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Eduard', 'Stepančič', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Sreten', 'Stojanović', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zlatko', 'Šulentić', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Sava', 'Šumanović', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ivan', 'Tabaković', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Stevan', 'Živadinović', 'Vane')
GO
--additional possibly famous
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Dragoslav', 'Vasiljevic', 'Figa')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Dragomir', 'Glisic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Malisa', 'Glisic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Viktor', 'Zivkovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ljubomir', 'Ivanovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Danica', 'Jovanovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Kosta', 'Josipovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Vidosava', 'Kovacevic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Aleksandar', 'Lazarevic', 'Saca')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zorica', 'Simeonovic', 'Lazic')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ana', 'Marinkovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Kosta', 'Milicevic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milan', 'Milovanovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zivorad', 'Nastasijevic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Dragoljub', 'Pavlovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Miodrag', 'Petrovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Pavle', 'Predragovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Veljko', 'Stanojević', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Borivoje', 'Stevanovic', 'Bora')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Natalija', 'Cvetkovic', NULL)
GO
--additional authors
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Vladimir', 'Novosel', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Vladimir', 'Jankovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Mirjana', 'Maodus', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Djordje', 'Bosan', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Nadezda', 'Petrovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zoran', 'Mandic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Tomislav', 'Bozovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ljiljana', 'Drezga', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Perisa', 'Milic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Dusan', 'Rajsic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Dusan', 'Miskovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Venija', 'Vucinic', 'Turinski')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Safet', 'Zec', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Miodrag', 'Rogic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Dusan', 'Mikonjic', 'Maher')
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Zivojin', 'Turinski', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Bogosav', 'Zivkovic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Ivo', 'Kalina', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Slavko', 'Krunic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Branko', 'Miljus', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Milan', 'Besarabic', NULL)
GO
INSERT INTO [dbo].[Author] (FirstName, LastName, Nickname) VALUES ('Kristian', 'Krekovic', NULL)
GO

/****** Item table  ******/
USE [KPProducts]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 25/01/2023 16:09:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[Id] [uniqueidentifier] NOT NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
	[Title] [nchar](100) NULL,
	[Description] [varchar](4000) NULL,
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

/****** Object:  Table [dbo].[ItemOffer]    Script Date: 25/01/2023 16:09:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemOffer](
	[Id] [uniqueidentifier] NOT NULL,
	[Sku] [bigint] NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[CurrencyId] [smallint] NULL,
	[Price] [int] NULL,
	[PriceTypeId] [smallint] NULL,
	[ConditionId] [smallint] NULL,
	[SellerId] [uniqueidentifier] NOT NULL,
	[StatusId] [int] NULL,
	[ValidUntil] [datetime] NOT NULL,
	[Url] [nchar](300) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_ItemOffer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemOffer] ADD  CONSTRAINT [DF_ItemOffer_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[ItemOffer] ADD  CONSTRAINT [DF_ItemOffer_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[ItemOffer] ADD  CONSTRAINT [DF_ItemOffer_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

/****** ItemAvailability table  ******/
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

/****** ItemCondition table  ******/
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

/****** ItemImage table  ******/
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

/****** PriceType table  ******/
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

INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (0, 'Cena')
GO
INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (1, 'Kontakt')
GO
INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (2, 'Dogovor')
GO
INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (3, 'Pozvati')
GO
INSERT INTO [dbo].[PriceType] (PriceTypeId, Description) VALUES (4, 'Kupujem')
GO


/****** Seller table  ******/
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

/****** Currency table  ******/
USE [KPProducts]
GO

/****** Object:  Table [dbo].[Currency]    Script Date: 23/01/2023 17:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Currency](
	[Id] [smallint] NOT NULL,
	[Description] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Currency] (Id, Description) VALUES (1, 'Euro')
GO
INSERT INTO [dbo].[Currency] (Id, Description) VALUES (2, 'RSD')
GO

/****** Status table  ******/
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

USE [KPProducts]
GO

/****** Object:  Table [dbo].[VisitedOffers]    Script Date: 01/02/2023 18:34:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VisitedOffers](
	[Id] [uniqueidentifier] NOT NULL,
	[Sku] [bigint] NOT NULL,
	[Url] [nchar](300) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_VisitedOffers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VisitedOffers] ADD  CONSTRAINT [DF_VisitedOffers_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[VisitedOffers] ADD  CONSTRAINT [DF_VisitedOffers_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VisitedOffers] ADD  CONSTRAINT [DF_VisitedOffers_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

/****** Object:  Table [dbo].[RefreshSettings]    Script Date: 06/02/2023 14:35:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RefreshSettings](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[Refresh] [datetime] NOT NULL,
 CONSTRAINT [PK_RefreshSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RefreshSettings] ADD  CONSTRAINT [DF_RefreshSettings_Id]  DEFAULT (newid()) FOR [Id]
GO

INSERT INTO [dbo].[RefreshSettings] (Name, Refresh) VALUES ('KPDataConsume', getdate())
GO

/****** Object:  Table [dbo].[RefreshSettings]    Script Date: 06/02/2023 14:35:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PartialAuthorRecognition](
	[ItemId] [uniqueidentifier] NOT NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_PartialAuthorRecognition] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PartialAuthorRecognition] ADD  CONSTRAINT [DF_PartialAuthorRecognition_ItemId]  DEFAULT (newid()) FOR [ItemId]
GO

ALTER TABLE [dbo].[PartialAuthorRecognition] ADD  CONSTRAINT [DF_PartialAuthorRecognition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[PartialAuthorRecognition] ADD  CONSTRAINT [DF_PartialAuthorRecognition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO