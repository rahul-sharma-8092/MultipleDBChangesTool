-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE DeleteScriptFile
	@ID INT
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE Scripts SET IsDeleted = 1 WHERE ID = @ID;
END
GO
