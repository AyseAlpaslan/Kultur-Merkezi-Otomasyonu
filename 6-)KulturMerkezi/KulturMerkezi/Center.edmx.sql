
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/24/2022 20:51:06
-- Generated from EDMX file: C:\Users\Dell\Desktop\KulturMerkezi\KulturMerkezi\Center.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Merkez];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OgrencilerSubeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubelerSet] DROP CONSTRAINT [FK_OgrencilerSubeler];
GO
IF OBJECT_ID(N'[dbo].[FK_SubelerEgitimler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EgitimlerSet] DROP CONSTRAINT [FK_SubelerEgitimler];
GO
IF OBJECT_ID(N'[dbo].[FK_SubelerEgitmenler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EgitmenlerSet] DROP CONSTRAINT [FK_SubelerEgitmenler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EgitimlerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EgitimlerSet];
GO
IF OBJECT_ID(N'[dbo].[EgitmenlerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EgitmenlerSet];
GO
IF OBJECT_ID(N'[dbo].[SubelerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubelerSet];
GO
IF OBJECT_ID(N'[dbo].[OgrencilerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OgrencilerSet];
GO
IF OBJECT_ID(N'[dbo].[KullanicilarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KullanicilarSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EgitimlerSet'
CREATE TABLE [dbo].[EgitimlerSet] (
    [EgitimNo] int IDENTITY(1,1) NOT NULL,
    [EgitimAdi] nvarchar(max)  NOT NULL,
    [EgitimSaati] int  NOT NULL,
    [EgitimTuru] nvarchar(max)  NOT NULL,
    [EgitimUcreti] decimal(18,0)  NOT NULL,
    [EgitimGunu] nvarchar(max)  NOT NULL,
    [SubeNo] int  NOT NULL
);
GO

-- Creating table 'EgitmenlerSet'
CREATE TABLE [dbo].[EgitmenlerSet] (
    [EgitmenNo] int IDENTITY(1,1) NOT NULL,
    [EgitmenAdi] nvarchar(max)  NOT NULL,
    [EgitmenSifre] nvarchar(max)  NOT NULL,
    [EgitmenMail] nvarchar(max)  NOT NULL,
    [EgitmenTelefon] nvarchar(max)  NOT NULL,
    [EgitmenAlani] nvarchar(max)  NOT NULL,
    [SubeNo] int  NOT NULL
);
GO

-- Creating table 'SubelerSet'
CREATE TABLE [dbo].[SubelerSet] (
    [SubeNo] int IDENTITY(1,1) NOT NULL,
    [SubeAdi] nvarchar(max)  NOT NULL,
    [SubeAdresi] nvarchar(max)  NOT NULL,
    [EgitmenSayisi] int  NOT NULL,
    [ProgramSayisi] int  NOT NULL,
    [OgrenciNo] int  NOT NULL
);
GO

-- Creating table 'OgrencilerSet'
CREATE TABLE [dbo].[OgrencilerSet] (
    [OgrenciNo] int IDENTITY(1,1) NOT NULL,
    [OgrenciAdSoyad] nvarchar(max)  NOT NULL,
    [OgrenciSifre] nvarchar(max)  NOT NULL,
    [OgrenciMail] nvarchar(max)  NOT NULL,
    [OgrenciTelefon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KullanicilarSet'
CREATE TABLE [dbo].[KullanicilarSet] (
    [KullaniciNo] int IDENTITY(1,1) NOT NULL,
    [KullaniciAdi] nvarchar(max)  NOT NULL,
    [KullaniciSifre] nvarchar(max)  NOT NULL,
    [KullaniciMail] nvarchar(max)  NOT NULL,
    [KullaniciTelefon] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EgitimNo] in table 'EgitimlerSet'
ALTER TABLE [dbo].[EgitimlerSet]
ADD CONSTRAINT [PK_EgitimlerSet]
    PRIMARY KEY CLUSTERED ([EgitimNo] ASC);
GO

-- Creating primary key on [EgitmenNo] in table 'EgitmenlerSet'
ALTER TABLE [dbo].[EgitmenlerSet]
ADD CONSTRAINT [PK_EgitmenlerSet]
    PRIMARY KEY CLUSTERED ([EgitmenNo] ASC);
GO

-- Creating primary key on [SubeNo] in table 'SubelerSet'
ALTER TABLE [dbo].[SubelerSet]
ADD CONSTRAINT [PK_SubelerSet]
    PRIMARY KEY CLUSTERED ([SubeNo] ASC);
GO

-- Creating primary key on [OgrenciNo] in table 'OgrencilerSet'
ALTER TABLE [dbo].[OgrencilerSet]
ADD CONSTRAINT [PK_OgrencilerSet]
    PRIMARY KEY CLUSTERED ([OgrenciNo] ASC);
GO

-- Creating primary key on [KullaniciNo] in table 'KullanicilarSet'
ALTER TABLE [dbo].[KullanicilarSet]
ADD CONSTRAINT [PK_KullanicilarSet]
    PRIMARY KEY CLUSTERED ([KullaniciNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OgrenciNo] in table 'SubelerSet'
ALTER TABLE [dbo].[SubelerSet]
ADD CONSTRAINT [FK_OgrencilerSubeler]
    FOREIGN KEY ([OgrenciNo])
    REFERENCES [dbo].[OgrencilerSet]
        ([OgrenciNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OgrencilerSubeler'
CREATE INDEX [IX_FK_OgrencilerSubeler]
ON [dbo].[SubelerSet]
    ([OgrenciNo]);
GO

-- Creating foreign key on [SubeNo] in table 'EgitimlerSet'
ALTER TABLE [dbo].[EgitimlerSet]
ADD CONSTRAINT [FK_SubelerEgitimler]
    FOREIGN KEY ([SubeNo])
    REFERENCES [dbo].[SubelerSet]
        ([SubeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubelerEgitimler'
CREATE INDEX [IX_FK_SubelerEgitimler]
ON [dbo].[EgitimlerSet]
    ([SubeNo]);
GO

-- Creating foreign key on [SubeNo] in table 'EgitmenlerSet'
ALTER TABLE [dbo].[EgitmenlerSet]
ADD CONSTRAINT [FK_SubelerEgitmenler]
    FOREIGN KEY ([SubeNo])
    REFERENCES [dbo].[SubelerSet]
        ([SubeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubelerEgitmenler'
CREATE INDEX [IX_FK_SubelerEgitmenler]
ON [dbo].[EgitmenlerSet]
    ([SubeNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------