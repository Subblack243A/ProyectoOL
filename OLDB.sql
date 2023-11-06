USE [master]
GO
/****** Object:  Database [OLDB]    Script Date: 6/11/2023 12:26:35 ******/
CREATE DATABASE [OLDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OLDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.OPENLIBRARYDB\MSSQL\DATA\OLDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OLDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.OPENLIBRARYDB\MSSQL\DATA\OLDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OLDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OLDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OLDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OLDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OLDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OLDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OLDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OLDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OLDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OLDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OLDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OLDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OLDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OLDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OLDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OLDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OLDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OLDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OLDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OLDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OLDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OLDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OLDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OLDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OLDB] SET RECOVERY FULL 
GO
ALTER DATABASE [OLDB] SET  MULTI_USER 
GO
ALTER DATABASE [OLDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OLDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OLDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OLDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OLDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OLDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OLDB', N'ON'
GO
ALTER DATABASE [OLDB] SET QUERY_STORE = OFF
GO
USE [OLDB]
GO
/****** Object:  Table [dbo].[AUDITORIA]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUDITORIA](
	[ID_AUDITORIA] [int] IDENTITY(1,1) NOT NULL,
	[USUARIO] [varchar](20) NOT NULL,
	[ACCION] [varchar](50) NOT NULL,
	[TABLA] [varchar](15) NOT NULL,
	[CAMPO] [varchar](40) NOT NULL,
	[VALOR_ANTERIOR] [nvarchar](255) NULL,
	[VALOR_NUEVO] [nvarchar](255) NULL,
	[FECHA] [datetime] NOT NULL,
 CONSTRAINT [PK_AUDITORIA] PRIMARY KEY CLUSTERED 
(
	[ID_AUDITORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAT_ESTADO]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAT_ESTADO](
	[ID_ESTADO] [smallint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CAT_ESTADO] PRIMARY KEY CLUSTERED 
(
	[ID_ESTADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAT_GENERO]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAT_GENERO](
	[ID_GENERO] [smallint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CAT_GENERO] PRIMARY KEY CLUSTERED 
(
	[ID_GENERO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAT_LIBRO]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAT_LIBRO](
	[ID_LIBRO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_LIBRO] [varchar](30) NOT NULL,
	[AUTOR] [varchar](20) NULL,
	[FECHA] [date] NULL,
	[FK_GENERO] [smallint] NULL,
	[FK_ESTADO] [smallint] NOT NULL,
	[PRECIO] [int] NULL,
	[UBICACION] [varchar](4) NULL,
	[IMAGEN] [varchar](255) NOT NULL,
	[PDF] [varchar](255) NULL,
 CONSTRAINT [PK_CAT_LIBRO] PRIMARY KEY CLUSTERED 
(
	[ID_LIBRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAT_TIPO_DOCUMENTO]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAT_TIPO_DOCUMENTO](
	[ID_TIPO_DOCUMENTO] [smallint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CAT_TIPO_DOCUMENTO] PRIMARY KEY CLUSTERED 
(
	[ID_TIPO_DOCUMENTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAT_TIPO_USUARIO]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAT_TIPO_USUARIO](
	[ID_TIPO_USUARIO] [smallint] IDENTITY(1,1) NOT NULL,
	[DESCRPCION] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CAT_TIPO_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID_TIPO_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPRA]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPRA](
	[ID_COMPRA] [int] IDENTITY(1,1) NOT NULL,
	[FK_LIBRO] [int] NOT NULL,
	[FK_USUARIO] [int] NOT NULL,
	[FECHA_COMPRA] [datetime] NOT NULL,
 CONSTRAINT [PK_COMPRA] PRIMARY KEY CLUSTERED 
(
	[ID_COMPRA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MULTA]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MULTA](
	[ID_MULTA] [int] IDENTITY(1,1) NOT NULL,
	[FK_PRESTAMO] [int] NOT NULL,
	[FECHA_MULTA] [date] NOT NULL,
	[VALOR_MULTA] [int] NOT NULL,
 CONSTRAINT [PK_MULTA] PRIMARY KEY CLUSTERED 
(
	[ID_MULTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PANTALLA]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PANTALLA](
	[ID_PANTALLA] [int] IDENTITY(1,1) NOT NULL,
	[PANTALLA] [varchar](255) NOT NULL,
	[MONITOR] [varchar](255) NOT NULL,
	[FK_USUARIO] [int] NOT NULL,
 CONSTRAINT [PK_PANTALLA] PRIMARY KEY CLUSTERED 
(
	[ID_PANTALLA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESTAMO]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESTAMO](
	[ID_PRESTAMO] [int] IDENTITY(1,1) NOT NULL,
	[FK_USUARIO] [int] NOT NULL,
	[FK_LIBRO] [int] NOT NULL,
	[FECHA_PRESTAMO] [date] NOT NULL,
	[FECHA_ENTREGA] [date] NOT NULL,
 CONSTRAINT [PK_PRESTAMO] PRIMARY KEY CLUSTERED 
(
	[ID_PRESTAMO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 6/11/2023 12:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID_USUARIO] [int] NOT NULL,
	[NOMBRE_USUARIO] [varchar](20) NOT NULL,
	[FK_TIPO_DOCUMENTO] [smallint] NOT NULL,
	[FK_TIPO_USUARIO] [smallint] NOT NULL,
	[FK_ESTADO] [smallint] NOT NULL,
	[NOMBRE] [varchar](60) NOT NULL,
	[APELLIDO] [varchar](60) NOT NULL,
	[CONTRASENA] [varchar](255) NOT NULL,
	[CORREO_ELECTRONICO] [varchar](45) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CAT_LIBRO]  WITH CHECK ADD  CONSTRAINT [FK_CAT_LIBRO_CAT_ESTADO] FOREIGN KEY([FK_ESTADO])
REFERENCES [dbo].[CAT_ESTADO] ([ID_ESTADO])
GO
ALTER TABLE [dbo].[CAT_LIBRO] CHECK CONSTRAINT [FK_CAT_LIBRO_CAT_ESTADO]
GO
ALTER TABLE [dbo].[CAT_LIBRO]  WITH CHECK ADD  CONSTRAINT [FK_CAT_LIBRO_CAT_GENERO] FOREIGN KEY([FK_GENERO])
REFERENCES [dbo].[CAT_GENERO] ([ID_GENERO])
GO
ALTER TABLE [dbo].[CAT_LIBRO] CHECK CONSTRAINT [FK_CAT_LIBRO_CAT_GENERO]
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_COMPRA_CAT_LIBRO] FOREIGN KEY([FK_LIBRO])
REFERENCES [dbo].[CAT_LIBRO] ([ID_LIBRO])
GO
ALTER TABLE [dbo].[COMPRA] CHECK CONSTRAINT [FK_COMPRA_CAT_LIBRO]
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_COMPRA_USUARIO] FOREIGN KEY([FK_USUARIO])
REFERENCES [dbo].[USUARIO] ([ID_USUARIO])
GO
ALTER TABLE [dbo].[COMPRA] CHECK CONSTRAINT [FK_COMPRA_USUARIO]
GO
ALTER TABLE [dbo].[MULTA]  WITH CHECK ADD  CONSTRAINT [FK_MULTA_PRESTAMO] FOREIGN KEY([FK_PRESTAMO])
REFERENCES [dbo].[PRESTAMO] ([ID_PRESTAMO])
GO
ALTER TABLE [dbo].[MULTA] CHECK CONSTRAINT [FK_MULTA_PRESTAMO]
GO
ALTER TABLE [dbo].[PANTALLA]  WITH CHECK ADD  CONSTRAINT [FK_PANTALLA_USUARIO] FOREIGN KEY([FK_USUARIO])
REFERENCES [dbo].[USUARIO] ([ID_USUARIO])
GO
ALTER TABLE [dbo].[PANTALLA] CHECK CONSTRAINT [FK_PANTALLA_USUARIO]
GO
ALTER TABLE [dbo].[PRESTAMO]  WITH CHECK ADD  CONSTRAINT [FK_PRESTAMO_CAT_LIBRO] FOREIGN KEY([FK_LIBRO])
REFERENCES [dbo].[CAT_LIBRO] ([ID_LIBRO])
GO
ALTER TABLE [dbo].[PRESTAMO] CHECK CONSTRAINT [FK_PRESTAMO_CAT_LIBRO]
GO
ALTER TABLE [dbo].[PRESTAMO]  WITH CHECK ADD  CONSTRAINT [FK_PRESTAMO_USUARIO] FOREIGN KEY([FK_USUARIO])
REFERENCES [dbo].[USUARIO] ([ID_USUARIO])
GO
ALTER TABLE [dbo].[PRESTAMO] CHECK CONSTRAINT [FK_PRESTAMO_USUARIO]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_CAT_ESTADO] FOREIGN KEY([FK_ESTADO])
REFERENCES [dbo].[CAT_ESTADO] ([ID_ESTADO])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_CAT_ESTADO]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_CAT_TIPO_DOCUMENTO] FOREIGN KEY([FK_TIPO_DOCUMENTO])
REFERENCES [dbo].[CAT_TIPO_DOCUMENTO] ([ID_TIPO_DOCUMENTO])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_CAT_TIPO_DOCUMENTO]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_CAT_TIPO_USUARIO] FOREIGN KEY([FK_TIPO_USUARIO])
REFERENCES [dbo].[CAT_TIPO_USUARIO] ([ID_TIPO_USUARIO])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_CAT_TIPO_USUARIO]
GO
USE [master]
GO
ALTER DATABASE [OLDB] SET  READ_WRITE 
GO
