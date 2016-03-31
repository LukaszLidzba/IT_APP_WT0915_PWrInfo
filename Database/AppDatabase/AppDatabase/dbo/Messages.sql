CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Title] NCHAR(10) NOT NULL, 
    [Content] NCHAR(10) NULL, 
    [DepartmentId] NCHAR(10) NOT NULL, 
    [UserId] NCHAR(10) NOT NULL, 
    [Important] BIT NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
