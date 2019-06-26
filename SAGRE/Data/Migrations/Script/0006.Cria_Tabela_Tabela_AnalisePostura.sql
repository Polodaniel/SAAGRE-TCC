CREATE TABLE [AnalisePosturaModel] (
    [ID_Analise] int NOT NULL IDENTITY,
    [ID] int NOT NULL,
    [IB] int NOT NULL,
    [IP] int NOT NULL,
    [IE] int NOT NULL,
    [IC] int NOT NULL,
    [Index] int NOT NULL,
    [IBDescricao] nvarchar(max) NULL,
    [IPDescricao] nvarchar(max) NULL,
    [IEDescricao] nvarchar(max) NULL,
    [ICDescricao] nvarchar(max) NULL,
    [AcaoDescricao] nvarchar(max) NULL,
    CONSTRAINT [PK_AnalisePosturaModel] PRIMARY KEY ([ID_Analise]),
    CONSTRAINT [FK_AnalisePosturaModel_BoletimModel_ID] FOREIGN KEY ([ID]) REFERENCES [BoletimModel] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AnalisePosturaModel_ID] ON [AnalisePosturaModel] ([ID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190611012043_Cria_Tabela_AnalisePostura', N'2.1.11-servicing-32099');

GO