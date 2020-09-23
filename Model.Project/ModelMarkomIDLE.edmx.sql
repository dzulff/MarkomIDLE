
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/01/2019 13:10:40
-- Generated from EDMX file: C:\Users\ASUS\Desktop\Bootcamp\Logic02\Batch212\Minimart212\Model.Minimart212\ModelMinimart212.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Markom_IDLE];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[m_menu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[m_menu];
GO
IF OBJECT_ID(N'[dbo].[m_product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[m_product];
GO
IF OBJECT_ID(N'[dbo].[m_role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[m_role];
GO
IF OBJECT_ID(N'[dbo].[m_employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[m_employee];
GO
IF OBJECT_ID(N'[dbo].[t_souvenir]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_souvenir];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'm_menu'
CREATE TABLE [dbo].[m_menu] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] varchar(50)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [controller] varchar(150)  NOT NULL,
    [parent_id] int NULL,
    [is_delete] bit NOT NULL,
    [created_by] varchar(50) NOT NULL,
    [created_date] datetime NOT NULL,
    [updated_by] varchar(50)  NULL,
    [updated_date] datetime  NULL
);
GO

CREATE TABLE [dbo].[m_product] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] varchar(50)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [description] varchar(150) NULL,
    [is_delete] bit NOT NULL,
    [created_by] varchar(50) NOT NULL,
    [created_date] datetime NOT NULL,
    [updated_by] varchar(50)  NULL,
    [updated_date] datetime  NULL
);
GO

CREATE TABLE [dbo].[m_role] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] varchar(50)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [description] varchar(150) NOT NULL,
    [is_delete] bit NOT NULL,
    [created_by] varchar(50) NOT NULL,
    [created_date] datetime NOT NULL,
    [updated_by] varchar(50)  NULL,
    [updated_date] datetime  NULL
);
GO

--CREATE TABLE [dbo].[m_employee](
--	[id] [int] IDENTITY(1,1) NOT NULL,
--	[employee_number] [nvarchar](max) NOT NULL,
--	[first_name] [nvarchar](max) NOT NULL,
--	[last_name] [nvarchar](max) NULL,
--	[m_company_id] [int] NULL,
--	[email] [nvarchar](max) NULL,
--	[is_delete] [bit] NOT NULL,
--	[created_by] [nvarchar](max) NULL,
--	[created_date] [datetime] NOT NULL,
--	[updated_by] [nvarchar](max) NULL,
--	[updated_date] [datetime] NULL
--);
--GO


--CREATE TABLE [dbo].[t_souvenir](
--	[id] [int] IDENTITY(1,1) NOT NULL,
--	[code] [nvarchar](max) NOT NULL,
--	[type] [nvarchar](max) NOT NULL,
--	[t_event_id] [nvarchar](max) NULL,
--	[request_by] [int] NOT NULL,
--	[request_date] [datetime] NULL,
--	[request_due_date] [datetime] NULL,
--	[approved_by][int] NULL,
--	[approved_date] [datetime] NULL,
--	[received_by] [int] NULL,
--	[received_date] [datetime] NULL,
--	[settlement_by] [int] NULL,
--	[settlement_date] [datetime] NULL,
--	[settlement_approved_by] [int] NULL,
--	[settlement_approved_date] [datetime] NULL,
--	[status] [int] NULL,
--	[note] [nvarchar](max) NULL,
--	[reject_reason][nvarchar](max) NULL,
--	[is_delete] bit NOT NULL,
--	[created_by] [nvarchar](max) NULL,
--	[created_date] [datetime] NOT NULL,
--	[updated_by] [nvarchar](max) NULL,
--	[updated_date] [datetime] NULL
--);
--GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'm_menu'
ALTER TABLE [dbo].[m_menu]
ADD CONSTRAINT [PK_m_menu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'm_product'
ALTER TABLE [dbo].[m_product]
ADD CONSTRAINT [PK_m_product]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'm_role'
ALTER TABLE [dbo].[m_role]
ADD CONSTRAINT [PK_m_role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

--ALTER TABLE [dbo].[m_employee]
--ADD CONSTRAINT [PK_m_employee]
--    PRIMARY KEY CLUSTERED ([ID] ASC);
--GO

--ALTER TABLE [dbo].[t_souvenir]
--ADD CONSTRAINT [PK_t_souvenir]
--    PRIMARY KEY CLUSTERED ([ID] ASC);
--GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------