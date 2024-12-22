-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE GetAllDataBase
AS
BEGIN
	
	SELECT [name] AS [DBName] FROM sys.databases 
	WHERE state_desc = 'ONLINE' AND name NOT IN ('master', 'model', 'msdb', 'tempdb');

END