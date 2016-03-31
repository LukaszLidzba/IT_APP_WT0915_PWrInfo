CREATE TABLE [dbo].[Units]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(255) NOT NULL, 
    [Description] VARCHAR(4000) NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
