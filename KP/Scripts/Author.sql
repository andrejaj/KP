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


