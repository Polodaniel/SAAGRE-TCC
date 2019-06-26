
ALTER TABLE [BoletimModel] ADD [HoraInicio] nvarchar(max) NULL;

GO

ALTER TABLE [BoletimModel] ADD [HoraTermino] nvarchar(max) NULL;

GO

ALTER TABLE [BoletimModel] ADD [Local] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [BoletimModel] ADD [TempoDuracao] nvarchar(max) NULL;

GO

CREATE UNIQUE INDEX [IX_AnaliseNASATLXModel_ID] ON [AnaliseNASATLXModel] ([ID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190626225548_Add_Colunas_Tempo_Local', N'2.1.11-servicing-32099');

GO