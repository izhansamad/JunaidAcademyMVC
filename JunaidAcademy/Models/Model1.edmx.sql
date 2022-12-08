
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/03/2022 04:36:02
-- Generated from EDMX file: C:\Users\Izhan\source\repos\JunaidAcademyMVC\JunaidAcademy\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JunaidAcademy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Course_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_Course_User];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseAssign_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseAssigns] DROP CONSTRAINT [FK_CourseAssign_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseAssign_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseAssigns] DROP CONSTRAINT [FK_CourseAssign_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[CourseAssigns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseAssigns];
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

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [CourseID] int IDENTITY(1,1) NOT NULL,
    [CourseName] varchar(50)  NULL,
    [CourseDescription] varchar(500)  NULL,
    [CourseFee] varchar(50)  NULL,
    [CourseDuration] varchar(50)  NULL,
    [CourseImg] varchar(max)  NULL,
    [UserID] int  NULL,
    [CourseSeats] int  NULL
);
GO

-- Creating table 'CourseAssigns'
CREATE TABLE [dbo].[CourseAssigns] (
    [CourseAssignID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [CourseID] int  NULL
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
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Contact] int  NULL,
    [Email] varchar(50)  NULL,
    [Role] varchar(50)  NULL,
    [Image] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CourseID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([CourseID] ASC);
GO

-- Creating primary key on [CourseAssignID] in table 'CourseAssigns'
ALTER TABLE [dbo].[CourseAssigns]
ADD CONSTRAINT [PK_CourseAssigns]
    PRIMARY KEY CLUSTERED ([CourseAssignID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_Course_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_User'
CREATE INDEX [IX_FK_Course_User]
ON [dbo].[Courses]
    ([UserID]);
GO

-- Creating foreign key on [CourseID] in table 'CourseAssigns'
ALTER TABLE [dbo].[CourseAssigns]
ADD CONSTRAINT [FK_CourseAssign_Course]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Courses]
        ([CourseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseAssign_Course'
CREATE INDEX [IX_FK_CourseAssign_Course]
ON [dbo].[CourseAssigns]
    ([CourseID]);
GO

-- Creating foreign key on [UserID] in table 'CourseAssigns'
ALTER TABLE [dbo].[CourseAssigns]
ADD CONSTRAINT [FK_CourseAssign_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseAssign_User'
CREATE INDEX [IX_FK_CourseAssign_User]
ON [dbo].[CourseAssigns]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------