USE [ProgettoSQL]
GO
/****** Object:  Table [dbo].[Agenti]    Script Date: 01/03/2024 21:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenti](
	[IDAgente] [int] IDENTITY(1,1) NOT NULL,
	[NomeAgente] [nvarchar](50) NOT NULL,
	[CognomeAgente] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Agenti] PRIMARY KEY CLUSTERED 
(
	[IDAgente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Anagrafica]    Script Date: 01/03/2024 21:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anagrafica](
	[IDAnagrafica] [int] IDENTITY(1,1) NOT NULL,
	[Cognome] [nvarchar](50) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Indirizzo] [nvarchar](255) NOT NULL,
	[Citta] [nvarchar](255) NOT NULL,
	[CAP] [int] NOT NULL,
	[Cod_Fisc] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Anagrafica] PRIMARY KEY CLUSTERED 
(
	[IDAnagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Multe]    Script Date: 01/03/2024 21:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Multe](
	[IDMulta] [int] IDENTITY(1,1) NOT NULL,
	[IDAnagrafica] [int] NOT NULL,
	[IDVerbale] [int] NOT NULL,
	[IDViolazione] [int] NOT NULL,
 CONSTRAINT [PK_Multe] PRIMARY KEY CLUSTERED 
(
	[IDMulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verbali]    Script Date: 01/03/2024 21:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verbali](
	[IDVerbale] [int] IDENTITY(1,1) NOT NULL,
	[DataViolazione] [datetime] NOT NULL,
	[IndirizzoViolazione] [nvarchar](255) NOT NULL,
	[IDAgente] [int] NOT NULL,
	[DataTrascrizioneVerbale] [datetime] NOT NULL,
	[Importo] [decimal](18, 2) NULL,
	[DecurtamentoPunti] [int] NULL,
 CONSTRAINT [PK_Verbali] PRIMARY KEY CLUSTERED 
(
	[IDVerbale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Violazioni]    Script Date: 01/03/2024 21:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Violazioni](
	[IDViolazione] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](510) NOT NULL,
 CONSTRAINT [PK_Violazioni] PRIMARY KEY CLUSTERED 
(
	[IDViolazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Multe]  WITH CHECK ADD  CONSTRAINT [FK_Multe_Anagrafica1] FOREIGN KEY([IDAnagrafica])
REFERENCES [dbo].[Anagrafica] ([IDAnagrafica])
GO
ALTER TABLE [dbo].[Multe] CHECK CONSTRAINT [FK_Multe_Anagrafica1]
GO
ALTER TABLE [dbo].[Multe]  WITH CHECK ADD  CONSTRAINT [FK_Multe_Verbali1] FOREIGN KEY([IDVerbale])
REFERENCES [dbo].[Verbali] ([IDVerbale])
GO
ALTER TABLE [dbo].[Multe] CHECK CONSTRAINT [FK_Multe_Verbali1]
GO
ALTER TABLE [dbo].[Multe]  WITH CHECK ADD  CONSTRAINT [FK_Multe_Violazioni1] FOREIGN KEY([IDViolazione])
REFERENCES [dbo].[Violazioni] ([IDViolazione])
GO
ALTER TABLE [dbo].[Multe] CHECK CONSTRAINT [FK_Multe_Violazioni1]
GO
ALTER TABLE [dbo].[Verbali]  WITH CHECK ADD  CONSTRAINT [FK_Verbali_Agenti1] FOREIGN KEY([IDAgente])
REFERENCES [dbo].[Agenti] ([IDAgente])
GO
ALTER TABLE [dbo].[Verbali] CHECK CONSTRAINT [FK_Verbali_Agenti1]
GO
