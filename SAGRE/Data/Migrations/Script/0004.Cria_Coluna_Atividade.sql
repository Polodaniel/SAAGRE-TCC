ALTER TABLE [BoletimModel] ADD [Atividade] nvarchar(max) NOT NULL DEFAULT N'';

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AnalisePosturaModel]') AND [c].[name] = N'IP');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AnalisePosturaModel] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [AnalisePosturaModel] ALTER COLUMN [IP] nvarchar(max) NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AnalisePosturaModel]') AND [c].[name] = N'IE');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AnalisePosturaModel] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [AnalisePosturaModel] ALTER COLUMN [IE] nvarchar(max) NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AnalisePosturaModel]') AND [c].[name] = N'IC');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AnalisePosturaModel] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [AnalisePosturaModel] ALTER COLUMN [IC] nvarchar(max) NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AnalisePosturaModel]') AND [c].[name] = N'IB');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AnalisePosturaModel] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [AnalisePosturaModel] ALTER COLUMN [IB] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190612221947_Cria_Coluna_Atividade', N'2.1.11-servicing-32099');

GO