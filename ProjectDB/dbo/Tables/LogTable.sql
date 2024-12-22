CREATE TABLE [dbo].[LogTable] (
    [LogID]          INT            IDENTITY (100, 1) NOT NULL,
    [Message]        NVARCHAR (MAX) NULL,
    [StackTrace]     NVARCHAR (MAX) NULL,
    [InnerException] NVARCHAR (MAX) NULL,
    [LogType]        INT            NULL,
    [CreatedBY]      NVARCHAR (100) NULL,
    [CreatedAT]      DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAT]      DATETIME       NULL,
    [IsDeleted]      BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([LogID] ASC)
);

