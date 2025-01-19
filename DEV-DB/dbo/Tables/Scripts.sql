CREATE TABLE [dbo].[Scripts] (
    [ID]           INT            IDENTITY (100, 1) NOT NULL,
    [Name]         NVARCHAR (500) NULL,
    [PhySicalPath] NVARCHAR (MAX) NULL,
    [ServerPath]   NVARCHAR (MAX) NULL,
    [CreatedBY]    NVARCHAR (100) NULL,
    [CreatedAT]    DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAT]    DATETIME       NULL,
    [IsDeleted]    BIT            DEFAULT ((0)) NULL,
    [Query]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

