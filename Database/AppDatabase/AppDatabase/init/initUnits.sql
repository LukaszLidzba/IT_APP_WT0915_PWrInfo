CREATE PROCEDURE [init].[initUnits] AS

MERGE 
[Units] AS target
USING
( VALUES
	('Admin special forces unit', '')
) AS source ([name],[description])
ON
	target.[name] = source.[name]
WHEN MATCHED AND source.[description] != target.[description]  THEN
	UPDATE
	SET [description] = source.[description]
WHEN NOT MATCHED THEN
	INSERT ([name], [description]) values (source.[name],source.[description]);
GO



