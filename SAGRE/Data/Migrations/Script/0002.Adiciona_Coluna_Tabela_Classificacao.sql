ALTER TABLE [ClassificaoOWAS] ADD [NumCategoria] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190608173254_Adiciona_Coluna_Classificacao', N'2.1.11-servicing-32099');

GO

