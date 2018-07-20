﻿CREATE TABLE [dbo].[Product] (
    [ProductId]   BIGINT          IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250)  NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

