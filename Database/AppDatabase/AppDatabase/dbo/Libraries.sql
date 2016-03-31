CREATE TABLE [dbo].[Libraries]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NCHAR(10) NULL, 
    [Address] NCHAR(10) NULL, 
    [OpeningHours] NCHAR(10) NULL, 
    [AdditionalInfo] NCHAR(10) NULL, 
    [UserId] NCHAR(10) NOT NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
