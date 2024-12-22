-- =============================================
-- Author:		<Rahul Sharma>
-- Create date: <'2024-12-22'>
-- Description:	<Add Script File>
-- =============================================
CREATE     PROCEDURE [dbo].[AddScriptFile]
	@Name NVARCHAR(500),
	@PhysicalPath NVARCHAR(MAX),
	@ServerPath NVARCHAR(MAX),
	@Query NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE Scripts SET IsDeleted = 1 WHERE [Name] = @Name AND IsDeleted = 0;
	
	SET NOCOUNT OFF;

	INSERT INTO Scripts([Name], PhySicalPath, ServerPath, Query)
	VALUES (@Name, @PhysicalPath, @ServerPath, @Query);

END