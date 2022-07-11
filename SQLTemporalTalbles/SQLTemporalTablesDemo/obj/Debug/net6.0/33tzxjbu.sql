BEGIN TRANSACTION;
GO

DELETE FROM [AspNetUserRoles]
WHERE [RoleId] = N'00dfe54e-9b8c-41b2-96a3-887df545f717' AND [UserId] = N'1a47f3ef-6991-4a9e-99d1-5bb5d1384764';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'00dfe54e-9b8c-41b2-96a3-887df545f717';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetUsers]
WHERE [Id] = N'1a47f3ef-6991-4a9e-99d1-5bb5d1384764';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] ON;
INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
VALUES (N'769c08a6-0564-42e3-aae3-b9351b8fb22d', 0, N'a9c200e1-4e9e-4dc4-8ba5-d09ef21b04a2', N'dali@mail.com', CAST(1 AS bit), CAST(0 AS bit), NULL, N'dali@mail.com', N'DALI', N'AQAAAAEAACcQAAAAEIKNPjOKI0tAakqATesDE1Ztvylqzks3a3oWugvr3WyIME/89J56pxJZbLXdwMPiqw==', NULL, CAST(0 AS bit), N'', CAST(0 AS bit), N'dali');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220711095539_Second', N'6.0.6');
GO

COMMIT;
GO

