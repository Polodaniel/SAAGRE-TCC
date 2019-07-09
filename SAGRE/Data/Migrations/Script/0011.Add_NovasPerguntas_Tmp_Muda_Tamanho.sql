
DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao20');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao20] nvarchar(3) NULL;

GO

DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao19');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao19] nvarchar(3) NULL;

GO

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao18');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao18] nvarchar(3) NULL;

GO

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao17');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao17] nvarchar(3) NULL;

GO

DECLARE @var28 sysname;
SELECT @var28 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao16');
IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var28 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao16] nvarchar(3) NULL;

GO

DECLARE @var29 sysname;
SELECT @var29 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao15');
IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var29 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao15] nvarchar(3) NULL;

GO

DECLARE @var30 sysname;
SELECT @var30 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao14');
IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var30 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao14] nvarchar(3) NULL;

GO

DECLARE @var31 sysname;
SELECT @var31 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao13');
IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var31 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao13] nvarchar(3) NULL;

GO

DECLARE @var32 sysname;
SELECT @var32 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao12');
IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var32 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao12] nvarchar(3) NULL;

GO

DECLARE @var33 sysname;
SELECT @var33 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao11');
IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var33 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao11] nvarchar(3) NULL;

GO

DECLARE @var34 sysname;
SELECT @var34 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao10');
IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var34 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao10] nvarchar(3) NULL;

GO

DECLARE @var35 sysname;
SELECT @var35 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao09');
IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var35 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao09] nvarchar(3) NULL;

GO

DECLARE @var36 sysname;
SELECT @var36 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao08');
IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var36 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao08] nvarchar(3) NULL;

GO

DECLARE @var37 sysname;
SELECT @var37 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao07');
IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var37 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao07] nvarchar(3) NULL;

GO

DECLARE @var38 sysname;
SELECT @var38 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao06');
IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var38 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao06] nvarchar(3) NULL;

GO

DECLARE @var39 sysname;
SELECT @var39 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao05');
IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var39 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao05] nvarchar(3) NULL;

GO

DECLARE @var40 sysname;
SELECT @var40 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao04');
IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var40 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao04] nvarchar(3) NULL;

GO

DECLARE @var41 sysname;
SELECT @var41 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao03');
IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var41 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao03] nvarchar(3) NULL;

GO

DECLARE @var42 sysname;
SELECT @var42 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao02');
IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var42 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao02] nvarchar(3) NULL;

GO

DECLARE @var43 sysname;
SELECT @var43 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TmpCheckList]') AND [c].[name] = N'Questao01');
IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [TmpCheckList] DROP CONSTRAINT [' + @var43 + '];');
ALTER TABLE [TmpCheckList] ALTER COLUMN [Questao01] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao21] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao22] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao23] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao24] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao25] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao26] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao27] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao28] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao29] nvarchar(3) NULL;

GO

ALTER TABLE [TmpCheckList] ADD [Questao30] nvarchar(3) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190705215804_Add_NovasPerguntas_Tmp_Muda_Tamanho', N'2.1.11-servicing-32099');

GO