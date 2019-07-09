
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190627001234_Cria_Tabela_Local_Empresa', N'2.1.11-servicing-32099');

GO

CREATE TABLE [TmpCheckList] (
    [ID] int NOT NULL IDENTITY,
    [TipoCheckList] int NOT NULL,
    [ID_Boletim] int NOT NULL,
    [Questao01] bit NOT NULL,
    [Questao02] bit NOT NULL,
    [Questao03] bit NOT NULL,
    [Questao04] bit NOT NULL,
    [Questao05] bit NOT NULL,
    [Questao06] bit NOT NULL,
    [Questao07] bit NOT NULL,
    [Questao08] bit NOT NULL,
    [Questao09] bit NOT NULL,
    [Questao10] bit NOT NULL,
    [Questao11] bit NOT NULL,
    [Questao12] bit NOT NULL,
    [Questao13] bit NOT NULL,
    [Questao14] bit NOT NULL,
    [Questao15] bit NOT NULL,
    [Questao16] bit NOT NULL,
    [Questao17] bit NOT NULL,
    [Questao18] bit NOT NULL,
    [Questao19] bit NOT NULL,
    [Questao20] bit NOT NULL,
    CONSTRAINT [PK_TmpCheckList] PRIMARY KEY ([ID])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190630234016_Cria_Tabela_TmpCheckList', N'2.1.11-servicing-32099');

GO