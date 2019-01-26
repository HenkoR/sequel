USE [master]
GO

/****** Object:  Database [sql101.tafara.vurayayi]    Script Date: 1/21/2019 9:11:50 PM ******/
CREATE DATABASE [sql101.tafara.vurayayi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sql101.tafara.vurayayi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\sql101.tafara.vurayayi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sql101.tafara.vurayayi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\sql101.tafara.vurayayi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sql101.tafara.vurayayi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET ARITHABORT OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET  DISABLE_BROKER 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET RECOVERY FULL 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET  MULTI_USER 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET DB_CHAINING OFF 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET QUERY_STORE = OFF
GO

USE [sql101.tafara.vurayayi]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [sql101.tafara.vurayayi] SET  READ_WRITE 
GO


