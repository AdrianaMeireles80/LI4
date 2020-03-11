USE [master]
GO
/****** Object:  Database [cookBoard]    Script Date: 01/05/2019 16:34:04 ******/
CREATE DATABASE [cookBoard]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cookBoard', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cookBoard.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cookBoard_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cookBoard_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [cookBoard] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cookBoard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cookBoard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cookBoard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cookBoard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cookBoard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cookBoard] SET ARITHABORT OFF 
GO
ALTER DATABASE [cookBoard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cookBoard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cookBoard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cookBoard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cookBoard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cookBoard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cookBoard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cookBoard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cookBoard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cookBoard] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cookBoard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cookBoard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cookBoard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cookBoard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cookBoard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cookBoard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cookBoard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cookBoard] SET RECOVERY FULL 
GO
ALTER DATABASE [cookBoard] SET  MULTI_USER 
GO
ALTER DATABASE [cookBoard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cookBoard] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cookBoard] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cookBoard] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cookBoard] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'cookBoard', N'ON'
GO
ALTER DATABASE [cookBoard] SET QUERY_STORE = OFF
GO
USE [cookBoard]
GO
/****** Object:  Table [dbo].[EmentaSemanal]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmentaSemanal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UtilizadorUsername] [varchar](45) NOT NULL,
	[DataLancamento] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DataLancamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmentaSemanal_Receita]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmentaSemanal_Receita](
	[EmentaSemanalId] [int] NOT NULL,
	[ReceitaId] [int] NOT NULL,
	[Dia] [varchar](45) NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[EmentaSemanalId] ,
	[ReceitaId] 
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente_Local]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente_Supermercado](
	[IngredienteId] [int] NOT NULL,
	[SupermercadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IngredienteId] ASC,
	[SupermercadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[Rua] [varchar](45) NOT NULL,
	[CodigoPostal] [varchar](45) NOT NULL,
	[Localidade] [varchar](45) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avaliacao]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avaliacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Estrela] [int] NOT NULL,
	[Comentario] [varchar](255) NOT NULL,
	[ReceitaId] [int] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Id] 
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receita]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receita](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](45) NOT NULL,
	[Porcao] [int] NOT NULL,
	[Imagem] [varchar](256) NOT NULL,
	[InfoNutricional] [varchar](256) NOT NULL,
	[Dificuldade] [varchar](45) NOT NULL,
	[Descricao] [text] NOT NULL,
	[TempoConfecao] [varchar](45) NOT NULL,
	[UtilizadorUsername] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Imagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receita_Ingrediente]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receita_Ingrediente](
	[ReceitaId] [int] NOT NULL,
	[IngredienteId] [int] NOT NULL,
	[Quantidade] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceitaId] ASC,
	[IngredienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Receita_ReceitaAuxiliar]    Script Date: 04/05/2019 15:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receita_ReceitaAuxiliar](
	[ReceitaId] [int] NOT NULL,
	[ReceitaAuxiliarId] [int] NOT NULL,
	[Passo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceitaId] ASC,
	[ReceitaAuxiliarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceitaAuxiliar]    Script Date: 04/05/2019 15:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceitaAuxiliar](
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supermercado]    Script Date: 04/05/2019 15:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supermercado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supermercado_Local]    Script Date: 04/05/2019 15:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supermercado_Local](
	[SupermercadoId] [int] NOT NULL,
	[LocalId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupermercadoId] ASC,
	[LocalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizador]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizador](
	[Username] [varchar](45) NOT NULL,
	[Password] [varchar](45) NOT NULL,
	[Email] [varchar](45) NOT NULL,
	[Nome] [varchar](45) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Tipo] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizador_Receita]    Script Date: 01/05/2019 16:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizador_Receita](
	[UtilizadorUsername] [varchar](45) NOT NULL,
	[ReceitaId] [int] NOT NULL,
	[Favorito] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UtilizadorUsername] ASC,
	[ReceitaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmentaSemanal]  WITH CHECK ADD  CONSTRAINT [FK_EmentaSemanal_Utilizador] FOREIGN KEY([UtilizadorUsername])
REFERENCES [dbo].[Utilizador] ([Username])
GO
ALTER TABLE [dbo].[EmentaSemanal] CHECK CONSTRAINT [FK_EmentaSemanal_Utilizador]
GO
ALTER TABLE [dbo].[EmentaSemanal_Receita]  WITH CHECK ADD  CONSTRAINT [FK_EmentaSemal_Receita_EmentaSemanal] FOREIGN KEY([EmentaSemanalId])
REFERENCES [dbo].[EmentaSemanal] ([Id])
GO
ALTER TABLE [dbo].[EmentaSemanal_Receita] CHECK CONSTRAINT [FK_EmentaSemal_Receita_EmentaSemanal]
GO
ALTER TABLE [dbo].[EmentaSemanal_Receita]  WITH CHECK ADD  CONSTRAINT [FK_EmentaSemal_Receita_Receita] FOREIGN KEY([ReceitaId])
REFERENCES [dbo].[Receita] ([Id])
GO
ALTER TABLE [dbo].[EmentaSemanal_Receita] CHECK CONSTRAINT [FK_EmentaSemal_Receita_Receita]
GO
ALTER TABLE [dbo].[Ingrediente_Supermercado]  WITH CHECK ADD  CONSTRAINT [FK_Ingrediente_Supermercado_Supermercado] FOREIGN KEY([SupermercadoId])
REFERENCES [dbo].[Supermercado] ([Id])
GO
ALTER TABLE [dbo].[Ingrediente_Supermercado] CHECK CONSTRAINT [FK_Ingrediente_Supermercado_Supermercado]
GO
ALTER TABLE [dbo].[Ingrediente_Supermercado]  WITH CHECK ADD  CONSTRAINT [FK_Ingrediente_Supermercado_Ingrediente] FOREIGN KEY([IngredienteId])
REFERENCES [dbo].[Ingrediente] ([Id])
GO
ALTER TABLE [dbo].[Ingrediente_Supermercado] CHECK CONSTRAINT [FK_Ingrediente_Supermercado_Ingrediente]
GO
ALTER TABLE [dbo].[Receita]  WITH CHECK ADD  CONSTRAINT [FK_Receita_Utilizador] FOREIGN KEY([UtilizadorUsername])
REFERENCES [dbo].[Utilizador] ([Username])
GO
ALTER TABLE [dbo].[Receita] CHECK CONSTRAINT [FK_Receita_Utilizador]
GO
ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_Avaliacao_Receita] FOREIGN KEY([ReceitaId])
REFERENCES [dbo].[Receita] ([Id])
GO
ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK_Avaliacao_Receita]
GO
ALTER TABLE [dbo].[Receita_Ingrediente]  WITH CHECK ADD  CONSTRAINT [FK_Receita_Ingrediente_Receita] FOREIGN KEY([ReceitaId])
REFERENCES [dbo].[Receita] ([Id])
GO
ALTER TABLE [dbo].[Receita_Ingrediente] CHECK CONSTRAINT [FK_Receita_Ingrediente_Receita]
GO
ALTER TABLE [dbo].[Receita_Ingrediente]  WITH CHECK ADD  CONSTRAINT [FK_Receita_Ingrediente_Ingrediente] FOREIGN KEY([IngredienteId])
REFERENCES [dbo].[Ingrediente] ([Id])
GO
ALTER TABLE [dbo].[Receita_Ingrediente] CHECK CONSTRAINT [FK_Receita_Ingrediente_Ingrediente]
GO
ALTER TABLE [dbo].[Receita_ReceitaAuxiliar]  WITH CHECK ADD  CONSTRAINT [FK_Receita_ReceitaAuxiliar_ReceitaAuxiliar] FOREIGN KEY([ReceitaAuxiliarId])
REFERENCES [dbo].[ReceitaAuxiliar] ([Id])
GO
ALTER TABLE [dbo].[Receita_ReceitaAuxiliar] CHECK CONSTRAINT [FK_Receita_ReceitaAuxiliar_ReceitaAuxiliar]
GO
ALTER TABLE [dbo].[Receita_ReceitaAuxiliar]  WITH CHECK ADD  CONSTRAINT [FK_Receita_ReceitaAuxiliar_Receita] FOREIGN KEY([ReceitaId])
REFERENCES [dbo].[Receita] ([Id])
GO
ALTER TABLE [dbo].[Receita_ReceitaAuxiliar] CHECK CONSTRAINT [FK_Receita_ReceitaAuxiliar_Receita]
GO
ALTER TABLE [dbo].[Supermercado_Local]  WITH CHECK ADD  CONSTRAINT [FK_Supermercado_Local_Supermercado] FOREIGN KEY([SupermercadoId])
REFERENCES [dbo].[Supermercado] ([Id])
GO
ALTER TABLE [dbo].[Supermercado_Local] CHECK CONSTRAINT [FK_Supermercado_Local_Supermercado]
GO
ALTER TABLE [dbo].[Supermercado_Local]  WITH CHECK ADD  CONSTRAINT [FK_Supermercado_Local_Local] FOREIGN KEY([LocalId])
REFERENCES [dbo].[Local] ([Id])
GO
ALTER TABLE [dbo].[Supermercado_Local] CHECK CONSTRAINT [FK_Supermercado_Local_Local]
GO
ALTER TABLE [dbo].[Utilizador_Receita]  WITH CHECK ADD  CONSTRAINT [FK_Utilizador_Receita_Utilizador] FOREIGN KEY([UtilizadorUsername])
REFERENCES [dbo].[Utilizador] ([Username])
GO
ALTER TABLE [dbo].[Utilizador_Receita] CHECK CONSTRAINT [FK_Utilizador_Receita_Utilizador]
GO
ALTER TABLE [dbo].[Utilizador_Receita]  WITH CHECK ADD  CONSTRAINT [FK_Utilizador_Receita_Receita] FOREIGN KEY([ReceitaId])
REFERENCES [dbo].[Receita] ([Id])
GO
ALTER TABLE [dbo].[Utilizador_Receita] CHECK CONSTRAINT [FK_Utilizador_Receita_Receita]
GO
USE [master]
GO
ALTER DATABASE [cookBoard] SET  READ_WRITE 
GO
