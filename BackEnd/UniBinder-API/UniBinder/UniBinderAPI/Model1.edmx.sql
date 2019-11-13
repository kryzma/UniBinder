
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2019 15:41:49
-- Generated from EDMX file: C:\projects\uniBinder\UniBinder\BackEnd\UniBinder-API\UniBinder\UniBinderAPI\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [studybuddy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[PersonSubjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSubjects];
GO
IF OBJECT_ID(N'[dbo].[Subjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subjects];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [ID] int  NOT NULL,
    [Name] varchar(255)  NULL,
    [Password] varchar(255)  NULL,
    [Email] varchar(255)  NULL,
    [Age] int  NULL,
    [HelpScore] int  NULL,
    [Likes] int  NULL,
    [Dislikes] int  NULL,
    [PeopleHelped] int  NULL,
    [Image] varchar(max)  NULL
);
GO

-- Creating table 'PersonSubjects'
CREATE TABLE [dbo].[PersonSubjects] (
    [ID] int  NOT NULL,
    [Name] varchar(255)  NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [Name] varchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PersonSubjects'
ALTER TABLE [dbo].[PersonSubjects]
ADD CONSTRAINT [PK_PersonSubjects]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Name] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------