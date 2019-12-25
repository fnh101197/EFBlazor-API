IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Items] (
    [Id] int NOT NULL IDENTITY,
    [ItemName] nvarchar(max) NULL,
    [IdItemBrand] int NOT NULL,
    [IdItemGroup] int NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191224021010_Init', N'3.1.0');

GO

ALTER TABLE [Items] ADD [IdUserModified] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191224024550_AddIdUserModified', N'3.1.0');

GO

