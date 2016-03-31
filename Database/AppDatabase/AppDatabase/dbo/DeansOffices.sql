CREATE TABLE [dbo].[DeansOffices]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [DepartmentId] INT NOT NULL, 
    [OpeningHours] VARCHAR(255) NULL, 
    [AdditionalInfo] VARCHAR(255) NULL, 
    [Address] VARCHAR(255) NULL, 
    [UserId] INT NOT NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
