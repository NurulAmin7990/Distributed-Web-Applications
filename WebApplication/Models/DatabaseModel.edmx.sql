
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2020 17:37:16
-- Generated from EDMX file: C:\Users\Nurul Amin\Documents\Project\Distributed-Web-Applications\WebApplication\Models\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Event_Meet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_Meet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Archives]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Archives];
GO
IF OBJECT_ID(N'[dbo].[Children]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Children];
GO
IF OBJECT_ID(N'[dbo].[Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Families]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Families];
GO
IF OBJECT_ID(N'[dbo].[Meet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Meet];
GO
IF OBJECT_ID(N'[dbo].[Meets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Meets];
GO
IF OBJECT_ID(N'[dbo].[Parents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parents];
GO
IF OBJECT_ID(N'[dbo].[Participants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Participants];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Children'
CREATE TABLE [dbo].[Children] (
    [ChildrenId] int IDENTITY(1,1) NOT NULL,
    [FamilyId] int  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Gender] char(1)  NOT NULL,
    [Permission] bit  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [MeetId] int  NOT NULL,
    [AgeRange] int  NOT NULL,
    [Gender] char(1)  NOT NULL,
    [Distance] int  NOT NULL,
    [Stroke] nvarchar(max)  NOT NULL,
    [Round] int  NOT NULL
);
GO

-- Creating table 'Families'
CREATE TABLE [dbo].[Families] (
    [FamilyId] int IDENTITY(1,1) NOT NULL,
    [ContactNumber] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [AddressLine] nvarchar(max)  NULL,
    [AddressArea] nvarchar(max)  NULL,
    [AddressPostcode] nvarchar(max)  NULL
);
GO

-- Creating table 'Meets'
CREATE TABLE [dbo].[Meets] (
    [MeetId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(1)  NOT NULL,
    [Venue] nvarchar(1)  NOT NULL,
    [Date] datetime  NOT NULL,
    [PoolLength] int  NOT NULL
);
GO

-- Creating table 'Parents'
CREATE TABLE [dbo].[Parents] (
    [ParentId] int IDENTITY(1,1) NOT NULL,
    [FamilyId] int  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Gender] char(1)  NOT NULL
);
GO

-- Creating table 'Participants'
CREATE TABLE [dbo].[Participants] (
    [ParticipantId] int IDENTITY(1,1) NOT NULL,
    [EventId] int  NOT NULL,
    [ChildrenId] int  NOT NULL,
    [Lane] int  NOT NULL,
    [Time] time  NOT NULL
);
GO

-- Creating table 'Archives'
CREATE TABLE [dbo].[Archives] (
    [ArchiveId] int IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Gender] char(1)  NOT NULL,
    [Permission] bit  NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Event1'
CREATE TABLE [dbo].[Event1] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [MeetId] int  NOT NULL,
    [AgeRange] int  NOT NULL,
    [Gender] char(1)  NOT NULL,
    [Distance] int  NOT NULL,
    [Stroke] nvarchar(max)  NOT NULL,
    [Round] int  NOT NULL
);
GO

-- Creating table 'Meet1'
CREATE TABLE [dbo].[Meet1] (
    [MeetId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(1)  NOT NULL,
    [Venue] nvarchar(1)  NOT NULL,
    [Date] datetime  NOT NULL,
    [PoolLength] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ChildrenId] in table 'Children'
ALTER TABLE [dbo].[Children]
ADD CONSTRAINT [PK_Children]
    PRIMARY KEY CLUSTERED ([ChildrenId] ASC);
GO

-- Creating primary key on [EventId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [FamilyId] in table 'Families'
ALTER TABLE [dbo].[Families]
ADD CONSTRAINT [PK_Families]
    PRIMARY KEY CLUSTERED ([FamilyId] ASC);
GO

-- Creating primary key on [MeetId] in table 'Meets'
ALTER TABLE [dbo].[Meets]
ADD CONSTRAINT [PK_Meets]
    PRIMARY KEY CLUSTERED ([MeetId] ASC);
GO

-- Creating primary key on [ParentId] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [PK_Parents]
    PRIMARY KEY CLUSTERED ([ParentId] ASC);
GO

-- Creating primary key on [ParticipantId] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [PK_Participants]
    PRIMARY KEY CLUSTERED ([ParticipantId] ASC);
GO

-- Creating primary key on [ArchiveId] in table 'Archives'
ALTER TABLE [dbo].[Archives]
ADD CONSTRAINT [PK_Archives]
    PRIMARY KEY CLUSTERED ([ArchiveId] ASC);
GO

-- Creating primary key on [EventId] in table 'Event1'
ALTER TABLE [dbo].[Event1]
ADD CONSTRAINT [PK_Event1]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [MeetId] in table 'Meet1'
ALTER TABLE [dbo].[Meet1]
ADD CONSTRAINT [PK_Meet1]
    PRIMARY KEY CLUSTERED ([MeetId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FamilyId] in table 'Children'
ALTER TABLE [dbo].[Children]
ADD CONSTRAINT [FK_Children_Family]
    FOREIGN KEY ([FamilyId])
    REFERENCES [dbo].[Families]
        ([FamilyId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Children_Family'
CREATE INDEX [IX_FK_Children_Family]
ON [dbo].[Children]
    ([FamilyId]);
GO

-- Creating foreign key on [ChildrenId] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [FK_Participant_Children]
    FOREIGN KEY ([ChildrenId])
    REFERENCES [dbo].[Children]
        ([ChildrenId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Participant_Children'
CREATE INDEX [IX_FK_Participant_Children]
ON [dbo].[Participants]
    ([ChildrenId]);
GO

-- Creating foreign key on [MeetId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_Meet]
    FOREIGN KEY ([MeetId])
    REFERENCES [dbo].[Meets]
        ([MeetId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_Meet'
CREATE INDEX [IX_FK_Event_Meet]
ON [dbo].[Events]
    ([MeetId]);
GO

-- Creating foreign key on [EventId] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [FK_Participant_Event]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Participant_Event'
CREATE INDEX [IX_FK_Participant_Event]
ON [dbo].[Participants]
    ([EventId]);
GO

-- Creating foreign key on [FamilyId] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [FK_Parent_Family]
    FOREIGN KEY ([FamilyId])
    REFERENCES [dbo].[Families]
        ([FamilyId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Parent_Family'
CREATE INDEX [IX_FK_Parent_Family]
ON [dbo].[Parents]
    ([FamilyId]);
GO

-- Creating foreign key on [MeetId] in table 'Event1'
ALTER TABLE [dbo].[Event1]
ADD CONSTRAINT [FK_Event_Meet1]
    FOREIGN KEY ([MeetId])
    REFERENCES [dbo].[Meet1]
        ([MeetId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_Meet1'
CREATE INDEX [IX_FK_Event_Meet1]
ON [dbo].[Event1]
    ([MeetId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------