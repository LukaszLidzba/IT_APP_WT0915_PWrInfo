CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(255) NOT NULL, 
    [Surname] VARCHAR(255) NOT NULL, 
    [Pass] VARCHAR(255) NOT NULL, 
    [UnitId] INT NOT NULL, 
    [IsAdmin] BIT NOT NULL, 
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())  
)

