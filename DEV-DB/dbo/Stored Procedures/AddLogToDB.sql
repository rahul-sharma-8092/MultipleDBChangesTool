-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE AddLogToDB
	@LogType INT,
	@Message NVARCHAR(MAX),
	@StackTrace NVARCHAR(MAX),
	@InnerException NVARCHAR(MAX)
AS
BEGIN
	
	SET NOCOUNT OFF;

    INSERT INTO LogTable(LogType, [Message], StackTrace, InnerException)
	VALUES (@LogType, @Message, @StackTrace, @InnerException);
END
