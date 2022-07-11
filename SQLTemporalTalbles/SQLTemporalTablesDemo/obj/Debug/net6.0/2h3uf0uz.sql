BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Persons]') AND [c].[name] = N'LastModifiedBy');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Persons] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Persons] ALTER COLUMN [LastModifiedBy] nvarchar(max) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Persons]') AND [c].[name] = N'CreatedBy');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Persons] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Persons] ALTER COLUMN [CreatedBy] nvarchar(max) NOT NULL;
GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'e2e171e0-7968-4adb-bfa6-84eabfb58faf'
WHERE [Id] = N'321';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'5a45c40a-1353-4e7b-89c5-808f402e7107', [PasswordHash] = N'AQAAAAEAACcQAAAAEJsgyFoQsIux7g9JYvkVmXR/f15TFh/HS5sWzaZK+m8jzAGet5GLoa51egAXVqyxmg=='
WHERE [Id] = N'123';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220711105323_Second', N'6.0.6');
GO

COMMIT;
GO

