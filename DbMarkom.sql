USE [master]
GO
/****** Object:  Database [Markom_IDLEEntities]    Script Date: 21/09/2020 16:15:11 ******/
CREATE DATABASE [Markom_IDLEEntities]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Markom_IDLEEntities', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Markom_IDLEEntities.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Markom_IDLEEntities_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Markom_IDLEEntities_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Markom_IDLEEntities] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Markom_IDLEEntities].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Markom_IDLEEntities] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET ARITHABORT OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Markom_IDLEEntities] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Markom_IDLEEntities] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Markom_IDLEEntities] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Markom_IDLEEntities] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Markom_IDLEEntities] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Markom_IDLEEntities] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Markom_IDLEEntities] SET  MULTI_USER 
GO
ALTER DATABASE [Markom_IDLEEntities] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Markom_IDLEEntities] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Markom_IDLEEntities] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Markom_IDLEEntities] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Markom_IDLEEntities] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Markom_IDLEEntities]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 21/09/2020 16:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_employee]    Script Date: 21/09/2020 16:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employee_number] [nvarchar](max) NOT NULL,
	[first_name] [nvarchar](max) NOT NULL,
	[last_name] [nvarchar](max) NULL,
	[m_company_id] [int] NULL,
	[email] [nvarchar](max) NULL,
	[is_delete] [bit] NOT NULL,
	[created_by] [nvarchar](max) NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](max) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.m_employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_menu]    Script Date: 21/09/2020 16:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[controller] [nvarchar](max) NULL,
	[parent_id] [int] NULL,
	[is_delete] [bit] NOT NULL,
	[created_by] [nvarchar](max) NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](max) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.m_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_product]    Script Date: 21/09/2020 16:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[is_delete] [bit] NOT NULL,
	[created_by] [nvarchar](max) NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](max) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.m_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_role]    Script Date: 21/09/2020 16:15:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[is_delete] [bit] NOT NULL,
	[created_by] [nvarchar](max) NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](max) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.m_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Markom_IDLEEntities] SET  READ_WRITE 
GO
