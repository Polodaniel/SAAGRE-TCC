CREATE TABLE [CheckListAnaliseCondBio] (
    [ID] int NOT NULL IDENTITY,
    [TipoCheckList] int NOT NULL,
    [ID_Boletim] int NOT NULL,
    [Questao01] nvarchar(3) NULL,
    [Questao02] nvarchar(3) NULL,
    [Questao03] nvarchar(3) NULL,
    [Questao04] nvarchar(3) NULL,
    [Questao05] nvarchar(3) NULL,
    [Questao06] nvarchar(3) NULL,
    [Questao07] nvarchar(3) NULL,
    [Questao08] nvarchar(3) NULL,
    [Questao09] nvarchar(3) NULL,
    [Questao10] nvarchar(3) NULL,
    [Questao11] nvarchar(3) NULL,
    [Questao12] nvarchar(3) NULL,
    [Questao13] nvarchar(3) NULL,
    [Questao14] nvarchar(3) NULL,
    [Questao15] nvarchar(3) NULL,
    [Questao16] nvarchar(3) NULL,
    [Questao17] nvarchar(3) NULL,
    [Questao18] nvarchar(3) NULL,
    [Questao19] nvarchar(3) NULL,
    [Questao20] nvarchar(3) NULL,
    [Questao21] nvarchar(3) NULL,
    [Questao22] nvarchar(3) NULL,
    [Questao23] nvarchar(3) NULL,
    [Questao24] nvarchar(3) NULL,
    [Questao25] nvarchar(3) NULL,
    [Questao26] nvarchar(3) NULL,
    [Questao27] nvarchar(3) NULL,
    [Questao28] nvarchar(3) NULL,
    [Questao29] nvarchar(3) NULL,
    [Questao30] nvarchar(3) NULL,
    CONSTRAINT [PK_CheckListAnaliseCondBio] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [CheckListAnaliseCondErg] (
    [ID] int NOT NULL IDENTITY,
    [TipoCheckList] int NOT NULL,
    [ID_Boletim] int NOT NULL,
    [Questao01] nvarchar(3) NULL,
    [Questao02] nvarchar(3) NULL,
    [Questao03] nvarchar(3) NULL,
    [Questao04] nvarchar(3) NULL,
    [Questao05] nvarchar(3) NULL,
    [Questao06] nvarchar(3) NULL,
    [Questao07] nvarchar(3) NULL,
    [Questao08] nvarchar(3) NULL,
    [Questao09] nvarchar(3) NULL,
    [Questao10] nvarchar(3) NULL,
    [Questao11] nvarchar(3) NULL,
    [Questao12] nvarchar(3) NULL,
    [Questao13] nvarchar(3) NULL,
    [Questao14] nvarchar(3) NULL,
    [Questao15] nvarchar(3) NULL,
    [Questao16] nvarchar(3) NULL,
    [Questao17] nvarchar(3) NULL,
    [Questao18] nvarchar(3) NULL,
    [Questao19] nvarchar(3) NULL,
    [Questao20] nvarchar(3) NULL,
    [Questao21] nvarchar(3) NULL,
    [Questao22] nvarchar(3) NULL,
    [Questao23] nvarchar(3) NULL,
    [Questao24] nvarchar(3) NULL,
    [Questao25] nvarchar(3) NULL,
    [Questao26] nvarchar(3) NULL,
    [Questao27] nvarchar(3) NULL,
    [Questao28] nvarchar(3) NULL,
    [Questao29] nvarchar(3) NULL,
    [Questao30] nvarchar(3) NULL,
    CONSTRAINT [PK_CheckListAnaliseCondErg] PRIMARY KEY ([ID])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190709144324_Add_Tabelas_CheckListAnalise', N'2.1.11-servicing-32099');

GO