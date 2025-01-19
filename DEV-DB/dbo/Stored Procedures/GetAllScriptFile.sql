-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE GetAllScriptFile
AS
BEGIN
	
	DECLARE @mindate DATE = '1753-01-01';

	SELECT ID, [Name], ISNULL(PhysicalPath,'') AS PhysicalPath, ISNULL(ServerPath,'') AS ServerPath,
	ISNULL(Query, '') AS Query, ISNULL(CreatedAT, @mindate) AS CreatedAT FROM Scripts WITH (NOLOCK)
	WHERE IsDeleted = 0 ORDER BY [Name]

END
