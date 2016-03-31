CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [DepartmentId] INT NOT NULL, 
    [Title] VARCHAR(255) NOT NULL, 
    [Content] VARCHAR(4000) NULL, 
    [Date] DATETIME2 NOT NULL, 
    [NotificationDate] DATETIME2 NULL, 
    [UserId] INT NOT NULL,
	[Created] DATETIME2 NULL DEFAULT (sysdatetime())
)
