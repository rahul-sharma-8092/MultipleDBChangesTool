CREATE TABLE [dbo].[DBDetails] (
    [DBId]       INT            IDENTITY (1, 1) NOT NULL,
    [DBName]     NVARCHAR (200) NOT NULL,
    [UserName]   NVARCHAR (10)  NOT NULL,
    [Password]   NVARCHAR (10)  NOT NULL,
    [PublicIP]   NVARCHAR (20)  NULL,
    [PrivateIP]  NVARCHAR (20)  NULL,
    [CreatedAT]  DATETIME       DEFAULT (getdate()) NULL,
    [ModifiedAT] DATETIME       NULL,
    [IsDeleted]  BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([DBId] ASC)
);

