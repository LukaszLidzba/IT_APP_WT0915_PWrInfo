CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Title] VARCHAR(255) NOT NULL, 
    [Content] VARCHAR(4000) NULL, 
    [DepartmentId] VARCHAR(255) NOT NULL, 
    [UserId] INT NOT NULL, 
    [Important] BIT NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
