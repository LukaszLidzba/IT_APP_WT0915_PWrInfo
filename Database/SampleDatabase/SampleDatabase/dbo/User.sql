CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(128) NULL, 
    [Surname] VARCHAR(128) NULL, 
    [Created] DATETIME NULL DEFAULT (sysdatetime())
)

