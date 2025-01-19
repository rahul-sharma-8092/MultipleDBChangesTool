CREATE TABLE [dbo].[LogTable] (
    [LogID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Message]        NVARCHAR (MAX) NULL,
    [StackTrace]     NVARCHAR (MAX) NULL,
    [InnerException] NVARCHAR (MAX) NULL,
    [LogType]        INT            NULL,
    [CreatedBY]      NVARCHAR (100) NULL,
    [CreatedAT]      DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAT]      DATETIME       NULL,
    [IsDeleted]      BIT            DEFAULT ((0)) NULL
);

