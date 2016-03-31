CREATE PROCEDURE [init].[initUsers] AS

MERGE 
[Users] AS target
USING
( VALUES
	('admin','admin', 'qwer','1',1)
) AS source ([name],[surname],[pass],[unitId],[isAdmin])
ON
	(target.[name] = source.[name] AND target.[surname] = source.[surname])
WHEN MATCHED AND (source.pass != target.pass OR source.unitId != target.unitId OR source.isAdmin != target.isAdmin) THEN
	UPDATE
	SET [pass] = source.[pass],
	 [unitId] = source.[unitId],
	 [isAdmin] = source.[isAdmin]
WHEN NOT MATCHED THEN
	INSERT ([name], [surname], [pass], [unitId], [isAdmin]) values (source.[name],source.[surname], source.[pass],source.[unitId],source.[isAdmin]);
GO


