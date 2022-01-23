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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[Owner] (
        [OwnerId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] varchar(50) NOT NULL,
        [Address] nvarchar(150) NOT NULL,
        [Photo] varbinary(max) NULL,
        [Birthday] datetime2 NOT NULL,
        CONSTRAINT [PK_Owner] PRIMARY KEY ([OwnerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[Property] (
        [PropertyId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [OwnerId] uniqueidentifier NOT NULL,
        [Name] varchar(50) NOT NULL,
        [Address] nvarchar(150) NOT NULL,
        [Price] decimal(12,2) NOT NULL,
        [CodeInternal] int NOT NULL,
        [Year] int NOT NULL,
        CONSTRAINT [PK_Property] PRIMARY KEY ([PropertyId]),
        CONSTRAINT [FK_Property_Owner_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Owner] ([OwnerId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[PropertyImage] (
        [PropertyId] uniqueidentifier NOT NULL,
        [PropertyImageId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [File] varbinary(max) NOT NULL,
        [Enabled] bit NOT NULL,
        CONSTRAINT [PK_PropertyImage] PRIMARY KEY ([PropertyId]),
        CONSTRAINT [FK_PropertyImage_Property_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [dbo].[Property] ([PropertyId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[PropertyTrace] (
        [PropertyTraceId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [PropertyId] uniqueidentifier NOT NULL,
        [DateSale] datetime2 NOT NULL,
        [Name] varchar(50) NOT NULL,
        [Value] decimal(12,2) NOT NULL,
        [Tax] decimal(12,2) NOT NULL,
        CONSTRAINT [PK_PropertyTrace] PRIMARY KEY ([PropertyTraceId]),
        CONSTRAINT [FK_PropertyTrace_Property_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [dbo].[Property] ([PropertyId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OwnerId', N'Address', N'Birthday', N'Name', N'Photo') AND [object_id] = OBJECT_ID(N'[dbo].[Owner]'))
        SET IDENTITY_INSERT [dbo].[Owner] ON;
    EXEC(N'INSERT INTO [dbo].[Owner] ([OwnerId], [Address], [Birthday], [Name], [Photo])
    VALUES (''5691eab3-50ce-4280-8659-ce208326fd97'', N''Cl. 20A Sur # 10-31'', ''1995-08-11T00:00:00.0000000'', ''Cristian Bonilla'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OwnerId', N'Address', N'Birthday', N'Name', N'Photo') AND [object_id] = OBJECT_ID(N'[dbo].[Owner]'))
        SET IDENTITY_INSERT [dbo].[Owner] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OwnerId', N'Address', N'Birthday', N'Name', N'Photo') AND [object_id] = OBJECT_ID(N'[dbo].[Owner]'))
        SET IDENTITY_INSERT [dbo].[Owner] ON;
    EXEC(N'INSERT INTO [dbo].[Owner] ([OwnerId], [Address], [Birthday], [Name], [Photo])
    VALUES (''dcbe29f5-aa35-40c3-adc8-5e3b718a6000'', N''Cl. 138 # 20-57'', ''1987-05-23T00:00:00.0000000'', ''Natalia Guzman'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OwnerId', N'Address', N'Birthday', N'Name', N'Photo') AND [object_id] = OBJECT_ID(N'[dbo].[Owner]'))
        SET IDENTITY_INSERT [dbo].[Owner] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PropertyId', N'Address', N'CodeInternal', N'Name', N'OwnerId', N'Price', N'Year') AND [object_id] = OBJECT_ID(N'[dbo].[Property]'))
        SET IDENTITY_INSERT [dbo].[Property] ON;
    EXEC(N'INSERT INTO [dbo].[Property] ([PropertyId], [Address], [CodeInternal], [Name], [OwnerId], [Price], [Year])
    VALUES (''488148ae-7bbc-4186-8e36-c3bd1c0bfe34'', N''6677 Schroeder Avenue'', 34432111, ''Headland Waters Mount Martha'', ''5691eab3-50ce-4280-8659-ce208326fd97'', 1358000000.0, 2018),
    (''12ba0df8-cf55-4ccb-a109-c582906e6b12'', N''Moussaouidreef 8'', 98801123, ''Luyary Jeddo'', ''5691eab3-50ce-4280-8659-ce208326fd97'', 1297566000.0, 2021),
    (''39cd6b37-9f59-4e34-bbff-34d3963ba558'', N''8098 Yundt Mission'', 11983367, ''Runneymede'', ''5691eab3-50ce-4280-8659-ce208326fd97'', 1188954000.0, 2020),
    (''0ca10f96-364a-4d8e-b870-baddb7a9acbf'', N''701, avenue de Guilbert'', 87711809, ''Zuburnano Up'', ''dcbe29f5-aa35-40c3-adc8-5e3b718a6000'', 1877544000.0, 2021),
    (''cb9ec42f-3c07-4ca1-8ba8-59e09c504860'', N''193 Kshlerin Spring'', 43309922, ''The Kingfisher'', ''dcbe29f5-aa35-40c3-adc8-5e3b718a6000'', 1988411000.0, 2020)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PropertyId', N'Address', N'CodeInternal', N'Name', N'OwnerId', N'Price', N'Year') AND [object_id] = OBJECT_ID(N'[dbo].[Property]'))
        SET IDENTITY_INSERT [dbo].[Property] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PropertyTraceId', N'DateSale', N'Name', N'PropertyId', N'Tax', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[PropertyTrace]'))
        SET IDENTITY_INSERT [dbo].[PropertyTrace] ON;
    EXEC(N'INSERT INTO [dbo].[PropertyTrace] ([PropertyTraceId], [DateSale], [Name], [PropertyId], [Tax], [Value])
    VALUES (''c4c42999-a4fc-40fb-b10b-6a14fc588fab'', ''2018-02-11T00:00:00.0000000'', ''Headland Waters Mount Martha Trace'', ''488148ae-7bbc-4186-8e36-c3bd1c0bfe34'', 5430000.0, 1058000000.0),
    (''529bbf7d-880a-4bb8-80fc-f605b3df0344'', ''2021-05-20T00:00:00.0000000'', ''Luyary Jeddo Trace'', ''12ba0df8-cf55-4ccb-a109-c582906e6b12'', 6132000.0, 1117566000.0),
    (''ae699884-d68a-486d-877d-55bd62046d66'', ''2020-12-11T00:00:00.0000000'', ''Runneymede Trace'', ''39cd6b37-9f59-4e34-bbff-34d3963ba558'', 5011000.0, 1008954000.0),
    (''774c3477-c8d5-49c5-9281-addb60d175b0'', ''2021-07-25T00:00:00.0000000'', ''Zuburnano Up Trace'', ''0ca10f96-364a-4d8e-b870-baddb7a9acbf'', 6234000.0, 1417844000.0),
    (''c82d1ac6-215f-4c21-aa2f-2140fe532a6b'', ''2021-08-22T00:00:00.0000000'', ''The Kingfisher Trace'', ''cb9ec42f-3c07-4ca1-8ba8-59e09c504860'', 8950000.0, 1122910000.0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PropertyTraceId', N'DateSale', N'Name', N'PropertyId', N'Tax', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[PropertyTrace]'))
        SET IDENTITY_INSERT [dbo].[PropertyTrace] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    CREATE INDEX [IX_Property_OwnerId] ON [dbo].[Property] ([OwnerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    CREATE INDEX [IX_PropertyTrace_PropertyId] ON [dbo].[PropertyTrace] ([PropertyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220123064449_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220123064449_InitialCreate', N'5.0.13');
END;
GO

COMMIT;
GO

