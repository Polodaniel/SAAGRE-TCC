INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190627000834_Cria_Tabela_Local', N'2.1.11-servicing-32099');

GO

CREATE TABLE [Local] (
    [ID_Local] int NOT NULL IDENTITY,
    [ID] int NOT NULL,
    [Sigla] nvarchar(max) NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [Inativo] bit NOT NULL,
    CONSTRAINT [PK_Local] PRIMARY KEY ([ID_Local]),
    CONSTRAINT [FK_Local_SetorModel_ID] FOREIGN KEY ([ID]) REFERENCES [SetorModel] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Local_ID] ON [Local] ([ID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190627001234_Cria_Tabela_Local_Empresa', N'2.1.11-servicing-32099');

GO

