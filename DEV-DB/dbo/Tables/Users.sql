CREATE TABLE [dbo].[Users] (
    [UserId]    INT             IDENTITY (1, 1) NOT NULL,
    [FullName]  NVARCHAR (255)  NULL,
    [Email]     NVARCHAR (255)  NULL,
    [Password]  NVARCHAR (MAX)  NULL,
    [GroupId]   INT             NULL,
    [Guid]      NVARCHAR (4000) NULL,
    [CreatedAT] DATETIME        DEFAULT (getdate()) NULL,
    [UpdatedAT] DATETIME        NULL,
    [IsDeleted] BIT             DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

