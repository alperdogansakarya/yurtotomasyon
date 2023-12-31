USE [master]
GO
/****** Object:  Database [yurtveritabanı]    Script Date: 12.10.2023 03:46:18 ******/
CREATE DATABASE [yurtveritabanı]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'yurtveritabanı', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\yurtveritabanı.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'yurtveritabanı_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\yurtveritabanı_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [yurtveritabanı] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [yurtveritabanı].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [yurtveritabanı] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [yurtveritabanı] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [yurtveritabanı] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [yurtveritabanı] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [yurtveritabanı] SET ARITHABORT OFF 
GO
ALTER DATABASE [yurtveritabanı] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [yurtveritabanı] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [yurtveritabanı] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [yurtveritabanı] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [yurtveritabanı] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [yurtveritabanı] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [yurtveritabanı] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [yurtveritabanı] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [yurtveritabanı] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [yurtveritabanı] SET  DISABLE_BROKER 
GO
ALTER DATABASE [yurtveritabanı] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [yurtveritabanı] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [yurtveritabanı] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [yurtveritabanı] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [yurtveritabanı] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [yurtveritabanı] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [yurtveritabanı] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [yurtveritabanı] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [yurtveritabanı] SET  MULTI_USER 
GO
ALTER DATABASE [yurtveritabanı] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [yurtveritabanı] SET DB_CHAINING OFF 
GO
ALTER DATABASE [yurtveritabanı] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [yurtveritabanı] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [yurtveritabanı] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [yurtveritabanı] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [yurtveritabanı] SET QUERY_STORE = ON
GO
ALTER DATABASE [yurtveritabanı] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [yurtveritabanı]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Yoneticiid] [tinyint] IDENTITY(1,1) NOT NULL,
	[YoneticiAd] [varchar](20) NULL,
	[YoneticiSifre] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bolumler]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolumler](
	[Bolumid] [tinyint] IDENTITY(1,1) NOT NULL,
	[BolumAd] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borclar]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borclar](
	[Ogrid] [int] NOT NULL,
	[OgrAd] [varchar](50) NULL,
	[OgrSoyad] [varchar](50) NULL,
	[OgrKalanBorc] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giderler]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giderler](
	[Odemeid] [smallint] IDENTITY(1,1) NOT NULL,
	[Elektrik] [money] NULL,
	[Su] [money] NULL,
	[Dogalgaz] [money] NULL,
	[Internet] [money] NULL,
	[Gıda] [money] NULL,
	[Personel] [money] NULL,
	[Diger] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kasa]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kasa](
	[OdemeAy] [varchar](20) NULL,
	[OdemeMiktar] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odalar]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odalar](
	[Odaid] [tinyint] IDENTITY(1,1) NOT NULL,
	[OdaNo] [char](3) NULL,
	[OdaKapasite] [char](1) NULL,
	[OdaAktif] [char](1) NULL,
	[OdaDurumu] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[Ogrid] [int] IDENTITY(1,1) NOT NULL,
	[OgrAd] [varchar](50) NULL,
	[OgrSoyad] [varchar](30) NULL,
	[OgrTC] [varchar](15) NULL,
	[OgrTelefon] [varchar](30) NULL,
	[OgrDogum] [varchar](30) NULL,
	[OgrBolum] [varchar](80) NULL,
	[OgrMail] [varchar](80) NULL,
	[OgrOdaNo] [char](3) NULL,
	[OgrVeliAdSoyad] [varchar](100) NULL,
	[OgrVeliTelefon] [varchar](30) NULL,
	[OgrVeliAdres] [varchar](350) NULL,
 CONSTRAINT [PK_Ogrenci1] PRIMARY KEY CLUSTERED 
(
	[Ogrid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 12.10.2023 03:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Personelid] [tinyint] IDENTITY(1,1) NOT NULL,
	[PersonelAdSoyad] [varchar](50) NULL,
	[PersonelDepartman] [varchar](30) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Borclar] ADD  CONSTRAINT [DF_Borclar_OgrKalanBorc]  DEFAULT ((100000)) FOR [OgrKalanBorc]
GO
ALTER TABLE [dbo].[Odalar] ADD  CONSTRAINT [DF_Odalar_OdaAktif]  DEFAULT ((0)) FOR [OdaAktif]
GO
ALTER TABLE [dbo].[Odalar] ADD  CONSTRAINT [DF_Odalar_OdaDurumu]  DEFAULT ((1)) FOR [OdaDurumu]
GO
USE [master]
GO
ALTER DATABASE [yurtveritabanı] SET  READ_WRITE 
GO
