CREATE TABLE [AnaliseNASATLXModel] (
    [ID_Analise] int NOT NULL IDENTITY,
    [ID] int NOT NULL,
    [rangeDM] nvarchar(max) NULL,
    [rangeDF] nvarchar(max) NULL,
    [rangeDT] nvarchar(max) NULL,
    [rangeDE] nvarchar(max) NULL,
    [rangePE] nvarchar(max) NULL,
    [rangeFR] nvarchar(max) NULL,
    [escalaFisica] nvarchar(max) NULL,
    [escalaTemporal] nvarchar(max) NULL,
    [escalaMental] nvarchar(max) NULL,
    [escalaPerformace] nvarchar(max) NULL,
    [escalaEsforco] nvarchar(max) NULL,
    [escalaFrustacao] nvarchar(max) NULL,
    CONSTRAINT [PK_AnaliseNASATLXModel] PRIMARY KEY ([ID_Analise]),
    CONSTRAINT [FK_AnaliseNASATLXModel_BoletimModel_ID] FOREIGN KEY ([ID]) REFERENCES [BoletimModel] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AnaliseNASATLXModel_ID] ON [AnaliseNASATLXModel] ([ID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190622133940_Cria_Tabela_Analise_NASATLX', N'2.1.11-servicing-32099');

GO