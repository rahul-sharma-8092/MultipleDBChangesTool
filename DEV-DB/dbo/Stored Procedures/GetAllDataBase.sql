-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[GetAllDataBase]
AS
BEGIN
	
	SELECT DBName, CONCAT(UserName, '_', DBName) DBCredentials FROM DBDetails Where IsDeleted = 0 ORDER BY DBName;

END
