CREATE PROCEDURE [init].[initDb] AS
	exec init.initUnits
	exec init.initUsers
