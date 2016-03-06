CREATE PROCEDURE [init].[initUser] AS
	insert into [dbo].[User](name, surname) values ('admin','admin')

