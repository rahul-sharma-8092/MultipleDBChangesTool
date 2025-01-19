CREATE     PROCEDURE [dbo].[CreateDatabaseAndUser]
    @DBName NVARCHAR(400),
    @UserName NVARCHAR(20),
    @Password NVARCHAR(20)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    BEGIN TRY
		DECLARE @DBName_Private NVARCHAR(400) = CONCAT(@UserName, '_', @DBName);


        IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = @DBName_Private)
        BEGIN
            SET @SQL = N'CREATE DATABASE ' + QUOTENAME(@DBName_Private);
            EXEC sp_executesql @SQL;
        END
        
		BEGIN TRANSACTION;
        
		SET @SQL = N'CREATE LOGIN ' + QUOTENAME(@UserName) + N' WITH PASSWORD = ''' + @Password + N''';';
        EXEC sp_executesql @SQL;

        
		SET @SQL = N'USE ' + QUOTENAME(@DBName_Private) + N';
                    CREATE USER ' + QUOTENAME(@UserName) + N' FOR LOGIN ' + QUOTENAME(@UserName) + N';';
        EXEC sp_executesql @SQL;

        
        SET @SQL = N'USE ' + QUOTENAME(@DBName_Private) + N';
                    EXEC sp_addrolemember ''db_owner'', ' + QUOTENAME(@UserName) + N';';
        EXEC sp_executesql @SQL;

        
        SET @SQL = N'ALTER LOGIN ' + QUOTENAME(@UserName) +
                   N' WITH DEFAULT_DATABASE = ' + QUOTENAME(@DBName_Private) + N';';
        EXEC sp_executesql @SQL;

        
		INSERT INTO DBDetails([DBName], [UserName], [Password]) VALUES(@DBName, @UserName, @Password);

        COMMIT TRANSACTION;

        SELECT 'Database, login, and user created successfully.' AS [Result];

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

		INSERT INTO LogTable([Message], [StackTrace], [InnerException], LogType, [CreatedBY])
		VALUES('Error occurred: ' + ERROR_MESSAGE(), 'Error Procedure: [CreateDatabaseAndUser]', ERROR_LINE(), 1, 'SQL Server')

        PRINT 'Error occurred: ' + ERROR_MESSAGE();
        SELECT 'Error occurred: ' + ERROR_MESSAGE() AS [Result];
        THROW;
    END CATCH
END
