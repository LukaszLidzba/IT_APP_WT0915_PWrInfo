CREATE TABLE [dbo].[Libraries]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(255) NULL, 
    [Address] VARCHAR(255) NULL, 
    [OpeningHours] VARCHAR(255) NULL, 
    [AdditionalInfo] VARCHAR(255) NULL, 
    [UserId] INT NOT NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
