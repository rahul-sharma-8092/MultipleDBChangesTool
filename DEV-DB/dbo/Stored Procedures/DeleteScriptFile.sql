-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE DeleteScriptFile
	@ID INT
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE Scripts SET IsDeleted = 1 WHERE ID = @ID;
END
