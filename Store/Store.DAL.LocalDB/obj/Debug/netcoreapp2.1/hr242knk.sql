IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Author] nvarchar(max) NULL,
    [PlacedDate] datetime2 NOT NULL,
    [Count] int NOT NULL,
    [Price] int NOT NULL,
    [Type] nvarchar(max) NULL,
    [Sale] bit NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [ClientName] nvarchar(max) NULL,
    [BookId] int NULL,
    [Count] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Orders_BookId] ON [Orders] ([BookId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190613072527_Initial', N'2.1.11-servicing-32099');

GO

