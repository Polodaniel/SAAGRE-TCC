
DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao20');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao20] nvarchar(max) NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao19');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao19] nvarchar(max) NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao18');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao18] nvarchar(max) NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao17');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao17] nvarchar(max) NULL;

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao16');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao16] nvarchar(max) NULL;

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao15');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao15] nvarchar(max) NULL;

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao14');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao14] nvarchar(max) NULL;

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao13');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao13] nvarchar(max) NULL;

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao12');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao12] nvarchar(max) NULL;

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao11');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao11] nvarchar(max) NULL;

GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao10');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao10] nvarchar(max) NULL;

GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao09');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao09] nvarchar(max) NULL;

GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao08');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao08] nvarchar(max) NULL;

GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao07');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao07] nvarchar(max) NULL;

GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao06');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao06] nvarchar(max) NULL;

GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao05');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao05] nvarchar(max) NULL;

GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao04');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao04] nvarchar(max) NULL;

GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao03');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao03] nvarchar(max) NULL;

GO

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao02');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao02] nvarchar(max) NULL;

GO

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao01');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao01] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190702234256_Troca_Tipo_Coluna_TmpCheckList', N'2.1.11-servicing-32099');

GO