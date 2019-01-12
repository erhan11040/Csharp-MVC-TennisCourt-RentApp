
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/23/2018 17:04:38
-- Generated from EDMX file: E:\TumProjeler\TenisWeb\TenisKortProjesi\TenisKortProjesi\Models\TenisKort.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TenisKortuUygulama];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Bills_Rezervation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bills] DROP CONSTRAINT [FK_Bills_Rezervation];
GO
IF OBJECT_ID(N'[dbo].[FK_Queue_Fields]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Queue] DROP CONSTRAINT [FK_Queue_Fields];
GO
IF OBJECT_ID(N'[dbo].[FK_Queue_Hours]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Queue] DROP CONSTRAINT [FK_Queue_Hours];
GO
IF OBJECT_ID(N'[dbo].[FK_Queue_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Queue] DROP CONSTRAINT [FK_Queue_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Rezervation_Fields]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervation] DROP CONSTRAINT [FK_Rezervation_Fields];
GO
IF OBJECT_ID(N'[dbo].[FK_Rezervation_Hours]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervation] DROP CONSTRAINT [FK_Rezervation_Hours];
GO
IF OBJECT_ID(N'[dbo].[FK_Rezervation_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervation] DROP CONSTRAINT [FK_Rezervation_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bills];
GO
IF OBJECT_ID(N'[dbo].[Fields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fields];
GO
IF OBJECT_ID(N'[dbo].[Hours]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hours];
GO
IF OBJECT_ID(N'[dbo].[Queue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Queue];
GO
IF OBJECT_ID(N'[dbo].[Rezervation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rezervation];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bills'
CREATE TABLE [dbo].[Bills] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Rezervation] int  NULL,
    [Amount] float  NULL,
    [isPaid] bit  NULL
);
GO

-- Creating table 'Fields'
CREATE TABLE [dbo].[Fields] (
    [id] int IDENTITY(1,1) NOT NULL,
    [length] float  NULL,
    [width] float  NULL
);
GO

-- Creating table 'Hours'
CREATE TABLE [dbo].[Hours] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Hour] nvarchar(10)  NULL
);
GO

-- Creating table 'Queue'
CREATE TABLE [dbo].[Queue] (
    [id] int IDENTITY(1,1) NOT NULL,
    [UsersId] int  NULL,
    [QueueDate] datetime  NULL,
    [HoursId] int  NULL,
    [FieldsId] int  NULL,
    [IsComplated] bit  NULL
);
GO

-- Creating table 'Rezervation'
CREATE TABLE [dbo].[Rezervation] (
    [id] int IDENTITY(1,1) NOT NULL,
    [UsersId] int  NULL,
    [FieldsId] int  NULL,
    [Date] datetime  NULL,
    [HoursId] int  NULL,
    [IsComplated] bit  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Surname] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [isMember] bit  NULL,
    [Password] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [PK_Bills]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Fields'
ALTER TABLE [dbo].[Fields]
ADD CONSTRAINT [PK_Fields]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Hours'
ALTER TABLE [dbo].[Hours]
ADD CONSTRAINT [PK_Hours]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Queue'
ALTER TABLE [dbo].[Queue]
ADD CONSTRAINT [PK_Queue]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rezervation'
ALTER TABLE [dbo].[Rezervation]
ADD CONSTRAINT [PK_Rezervation]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Rezervation] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_Bills_Rezervation]
    FOREIGN KEY ([Rezervation])
    REFERENCES [dbo].[Rezervation]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bills_Rezervation'
CREATE INDEX [IX_FK_Bills_Rezervation]
ON [dbo].[Bills]
    ([Rezervation]);
GO

-- Creating foreign key on [FieldsId] in table 'Rezervation'
ALTER TABLE [dbo].[Rezervation]
ADD CONSTRAINT [FK_Rezervation_Fields]
    FOREIGN KEY ([FieldsId])
    REFERENCES [dbo].[Fields]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rezervation_Fields'
CREATE INDEX [IX_FK_Rezervation_Fields]
ON [dbo].[Rezervation]
    ([FieldsId]);
GO

-- Creating foreign key on [HoursId] in table 'Rezervation'
ALTER TABLE [dbo].[Rezervation]
ADD CONSTRAINT [FK_Rezervation_Hours]
    FOREIGN KEY ([HoursId])
    REFERENCES [dbo].[Hours]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rezervation_Hours'
CREATE INDEX [IX_FK_Rezervation_Hours]
ON [dbo].[Rezervation]
    ([HoursId]);
GO

-- Creating foreign key on [UsersId] in table 'Queue'
ALTER TABLE [dbo].[Queue]
ADD CONSTRAINT [FK_Queue_Users]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Queue_Users'
CREATE INDEX [IX_FK_Queue_Users]
ON [dbo].[Queue]
    ([UsersId]);
GO

-- Creating foreign key on [UsersId] in table 'Rezervation'
ALTER TABLE [dbo].[Rezervation]
ADD CONSTRAINT [FK_Rezervation_Users]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rezervation_Users'
CREATE INDEX [IX_FK_Rezervation_Users]
ON [dbo].[Rezervation]
    ([UsersId]);
GO

-- Creating foreign key on [FieldsId] in table 'Queue'
ALTER TABLE [dbo].[Queue]
ADD CONSTRAINT [FK_Queue_Fields]
    FOREIGN KEY ([FieldsId])
    REFERENCES [dbo].[Fields]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Queue_Fields'
CREATE INDEX [IX_FK_Queue_Fields]
ON [dbo].[Queue]
    ([FieldsId]);
GO

-- Creating foreign key on [HoursId] in table 'Queue'
ALTER TABLE [dbo].[Queue]
ADD CONSTRAINT [FK_Queue_Hours]
    FOREIGN KEY ([HoursId])
    REFERENCES [dbo].[Hours]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Queue_Hours'
CREATE INDEX [IX_FK_Queue_Hours]
ON [dbo].[Queue]
    ([HoursId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------