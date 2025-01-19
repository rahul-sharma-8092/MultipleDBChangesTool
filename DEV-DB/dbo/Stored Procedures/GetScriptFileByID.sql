-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE GetScriptFileByID
	@ID INT
AS
BEGIN
	
	DECLARE @mindate DATE = '1753-01-01';

	SELECT ID, [Name], ISNULL(PhysicalPath,'') AS PhysicalPath, ISNULL(ServerPath,'') AS ServerPath,
	ISNULL(Query, '') AS Query, ISNULL(CreatedAT, @mindate) AS CreatedAT FROM Scripts WITH (NOLOCK)
	WHERE IsDeleted = 0 AND ID = @ID

END
