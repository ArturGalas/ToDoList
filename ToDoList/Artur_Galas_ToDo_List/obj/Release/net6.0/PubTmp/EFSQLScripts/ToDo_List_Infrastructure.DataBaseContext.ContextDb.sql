IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230131184655_first')
BEGIN
    CREATE TABLE [Users] (
        [id] uniqueidentifier NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        [name] nvarchar(max) NOT NULL,
        [state] int NOT NULL,
        [role] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230131184655_first')
BEGIN
    CREATE TABLE [tasks] (
        [id] uniqueidentifier NOT NULL,
        [UserID] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [UpdateDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [State] int NOT NULL,
        CONSTRAINT [PK_tasks] PRIMARY KEY ([id]),
        CONSTRAINT [FK_tasks_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230131184655_first')
BEGIN
    CREATE INDEX [IX_tasks_UserID] ON [tasks] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230131184655_first')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230131184655_first', N'7.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207174846_nextMigration')
BEGIN
    EXEC sp_rename N'[Users].[id]', N'Id', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207174846_nextMigration')
BEGIN
    EXEC sp_rename N'[tasks].[id]', N'Id', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207174846_nextMigration')
BEGIN
    EXEC sp_rename N'[tasks].[EndDate]', N'Data końcowa', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207174846_nextMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230207174846_nextMigration', N'7.0.2');
END;
GO

COMMIT;
GO

