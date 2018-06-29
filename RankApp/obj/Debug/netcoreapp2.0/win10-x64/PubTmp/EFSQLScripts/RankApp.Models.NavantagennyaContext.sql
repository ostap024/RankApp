IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180521182144_Initial')
BEGIN
    CREATE TABLE [Navantagennyas] (
        [Id] int NOT NULL IDENTITY,
        [Aspiranty] float NOT NULL,
        [Consultant] float NOT NULL,
        [DEK] float NOT NULL,
        [Dyplom] float NOT NULL,
        [Grup] int NOT NULL,
        [Grupa] nvarchar(max) NULL,
        [Isput] float NOT NULL,
        [Kontrolny] float NOT NULL,
        [Kurs] int NOT NULL,
        [Kursovi] float NOT NULL,
        [Laborant] float NOT NULL,
        [Lekcii] float NOT NULL,
        [Modul] float NOT NULL,
        [Nazva] nvarchar(max) NULL,
        [NumberDisc] int NOT NULL,
        [NumberPP] int NOT NULL,
        [Pidgrup] int NOT NULL,
        [Praktuchni] float NOT NULL,
        [Praktyka] float NOT NULL,
        [Primitka] nvarchar(max) NULL,
        [Semestr] nvarchar(max) NULL,
        [Studentiv] int NOT NULL,
        [Vikladach] nvarchar(max) NULL,
        [Vsyogo] float NOT NULL,
        [Zalik] float NOT NULL,
        CONSTRAINT [PK_Navantagennyas] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180521182144_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180521182144_Initial', N'2.0.3-rtm-10026');
END;

GO

