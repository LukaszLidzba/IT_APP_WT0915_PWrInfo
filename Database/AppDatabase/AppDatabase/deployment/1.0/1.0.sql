
GO
USE [AppDatabase];


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [init]...';


GO
CREATE SCHEMA [init]
    AUTHORIZATION [dbo];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[DeansOffices]...';


GO
CREATE TABLE [dbo].[DeansOffices] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [DepartmentId]   INT           NOT NULL,
    [OpeningHours]   VARCHAR (255) NULL,
    [AdditionalInfo] VARCHAR (255) NULL,
    [Address]        VARCHAR (255) NULL,
    [UserId]         INT           NOT NULL,
    [Created]        DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Departments]...';


GO
CREATE TABLE [dbo].[Departments] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (255) NOT NULL,
    [Created] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Events]...';


GO
CREATE TABLE [dbo].[Events] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [DepartmentId]     INT            NOT NULL,
    [Title]            VARCHAR (255)  NOT NULL,
    [Content]          VARCHAR (4000) NULL,
    [Date]             DATETIME2 (7)  NOT NULL,
    [NotificationDate] DATETIME2 (7)  NULL,
    [UserId]           INT            NOT NULL,
    [Created]          DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Libraries]...';


GO
CREATE TABLE [dbo].[Libraries] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           varchar(255)    NULL,
    [Address]        varchar(255)    NULL,
    [OpeningHours]   varchar(255)   NULL,
    [AdditionalInfo] varchar(4000)   NULL,
    [UserId]         INT    NOT NULL,
    [Created]        DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Messages]...';


GO
CREATE TABLE [dbo].[Messages] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Title]        varchar(255)    NOT NULL,
    [Content]      varchar(4000)    NULL,
    [DepartmentId] varchar(255)    NOT NULL,
    [UserId]       INT    NOT NULL,
    [Important]    BIT           NULL,
    [Created]      DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Units]...';


GO
CREATE TABLE [dbo].[Units] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (255)  NOT NULL,
    [Description] VARCHAR (4000) NULL,
    [Created]     DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END

GO
PRINT N'Creating [dbo].[Tickets]...';


GO

CREATE TABLE [dbo].[Tickets]
(
	[TicketId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Created] DATETIME2 NOT NULL
);

GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END

GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (255) NOT NULL,
    [Surname] VARCHAR (255) NOT NULL,
	[Login]	  VARCHAR(255) NOT NULL,
    [Pass]    VARCHAR (255) NOT NULL,
    [UnitId]  INT           NOT NULL,
    [IsAdmin] BIT           NOT NULL,
    [Created] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating Default Constraint on [dbo].[DeansOffices]....';


GO
ALTER TABLE [dbo].[DeansOffices]
    ADD DEFAULT (sysdatetime()) FOR [Created];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating Default Constraint on [dbo].[Departments]....';


GO
ALTER TABLE [dbo].[Departments]
    ADD DEFAULT (sysdatetime()) FOR [Created];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating Default Constraint on [dbo].[Events]....';


GO
ALTER TABLE [dbo].[Events]
    ADD DEFAULT (sysdatetime()) FOR [Created];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating Default Constraint on [dbo].[Libraries]....';


GO
ALTER TABLE [dbo].[Libraries]
    ADD DEFAULT (sysdatetime()) FOR [Created];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating Default Constraint on [dbo].[Messages]....';


GO
ALTER TABLE [dbo].[Messages]
    ADD DEFAULT (sysdatetime()) FOR [Created];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating Default Constraint on [dbo].[Units]....';


GO
ALTER TABLE [dbo].[Units]
    ADD DEFAULT (sysdatetime()) FOR [Created];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating Default Constraint on [dbo].[Users]....';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (sysdatetime()) FOR [Created];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [init].[initUsers]...';


GO
CREATE PROCEDURE [init].[initUsers] AS

MERGE 
[Users] AS target
USING
( VALUES
	('admin','admin','admin', 'qwer','1',1)
) AS source ([name],[surname],[login],[pass],[unitId],[isAdmin])
ON
	(target.[name] = source.[name] AND target.[surname] = source.[surname])
WHEN MATCHED AND (source.pass != target.pass OR source.unitId != target.unitId OR source.isAdmin != target.isAdmin) THEN
	UPDATE
	SET [pass] = source.[pass],
	[login] = source.[login],
	 [unitId] = source.[unitId],
	 [isAdmin] = source.[isAdmin]
WHEN NOT MATCHED THEN
	INSERT ([name], [surname], [login], [pass], [unitId], [isAdmin]) values (source.[name],source.[surname], source.[login], source.[pass],source.[unitId],source.[isAdmin]);
GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [init].[initUnits]...';


GO
CREATE PROCEDURE [init].[initUnits] AS

MERGE 
[Units] AS target
USING
( VALUES
	('Admin special forces unit', '')
) AS source ([name],[description])
ON
	target.[name] = source.[name]
WHEN MATCHED AND source.[description] != target.[description]  THEN
	UPDATE
	SET [description] = source.[description]
WHEN NOT MATCHED THEN
	INSERT ([name], [description]) values (source.[name],source.[description]);
GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [init].[initDb]...';


GO
CREATE PROCEDURE [init].[initDb] AS
	exec init.initUnits
	exec init.initUsers
GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

/*
Uruchamiam Procedure inicjujaca baze danych 
*/
exec init.initDb
GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
DROP TABLE #tmpErrors
GO
PRINT N'Update complete.';


GO
