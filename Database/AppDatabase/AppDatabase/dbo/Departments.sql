CREATE TABLE [dbo].[Departments]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(255) NOT NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
