IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609151558_initial')
BEGIN
    CREATE TABLE [MetodRobs] (
        [Id] int NOT NULL IDENTITY,
        [EkspertDyplom] float NULL,
        [EkspertDyplomNRobit] float NULL,
        [PIB] nvarchar(max) NULL,
        [PerekladStat] float NULL,
        [PerekladStatNStor] float NULL,
        [PerevirkaOlimp] float NULL,
        [PerevirkaOlimpNRobit] float NULL,
        [PidgotovkaDopovidTaVistup] float NULL,
        [PidgotovkaDopovidTaVistupNVistup] float NULL,
        [PidgotovkaLabPrakt] float NULL,
        [PidgotovkaLekciiBakalavr] float NULL,
        [PidgotovkaLekciiBakalavrN] float NULL,
        [PidgotovkaLekciiMagistr] float NULL,
        [PidgotovkaLekciiMagistrN] float NULL,
        [PidgotovkaMater] float NULL,
        [PidgotovkaRecenzVidkr] float NULL,
        [PidgotovkaRecenzVidkrNZanat] float NULL,
        [PidvKval] float NULL,
        [RecenzPidruch] float NULL,
        [RecenzPidruchNStor] float NULL,
        [RecenzRozrobok] float NULL,
        [RecenzRozrobokNStor] float NULL,
        [RobotaNavchGrup] float NULL,
        [Rozrobka15] float NULL,
        [RozrobkaInterMet] float NULL,
        [RozrobkaInterMetNZanyat] float NULL,
        [RozrobkaLab] float NULL,
        [RozrobkaLabNRobit] float NULL,
        [RozrobkaNavchMat] float NULL,
        [RozrobkaNavchMatNZanyat] float NULL,
        [RozrobkaVNS] float NULL,
        [RozrobkaVNSNDisc] float NULL,
        [RozrobkaZavdan] float NULL,
        [RozrobkaZavdanNZavdan] float NULL,
        [SiteKafedra] float NULL,
        [StagBezVidr] float NULL,
        [StagBezVidrBool] bit NOT NULL,
        [StagZVidr] float NULL,
        [StagZVidrBool] bit NOT NULL,
        [Sum] float NULL,
        [UchastRobGrup] float NULL,
        [UchastRobGrupNDniv] float NULL,
        [User] nvarchar(max) NULL,
        [VidannyaPidruch] float NULL,
        [VidannyaRozrobok] float NULL,
        [VzaemVidvid] float NULL,
        CONSTRAINT [PK_MetodRobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609151558_initial')
BEGIN
    CREATE TABLE [NaukRobs] (
        [Id] int NOT NULL IDENTITY,
        [DopovidKafedra] float NULL,
        [DopovidMijnarod] float NULL,
        [DopovidUkr] float NULL,
        [KerivNaukStud] float NULL,
        [KerivNaukStudMijnarodUkr] float NULL,
        [KerivNaukStudMijnarodZaKordon] float NULL,
        [KerivNaukStudVseukrain] float NULL,
        [KerivStud] float NULL,
        [KerivStudKonkursN] float NULL,
        [KerivStudOhoronDocN] float NULL,
        [KerivStudStattyaN] float NULL,
        [KerivStudTezDopovidN] float NULL,
        [MijnarodDogovir] float NULL,
        [NaukEksped] float NULL,
        [NaukEkspedNDniv] float NULL,
        [OformlennyaKorMod] float NULL,
        [OformlennyaPatent] float NULL,
        [OponDesertDoktor] float NULL,
        [OponDesertDoktorN] float NULL,
        [OponDesertKandidat] float NULL,
        [OponDesertKandidatN] float NULL,
        [OtrymannyaKorMod] float NULL,
        [OtrymannyaPatent] float NULL,
        [PIB] nvarchar(max) NULL,
        [PidgotovkaMONGrant] float NULL,
        [PidgotovkaMijnarodGrant] float NULL,
        [PidgotovkaNDR] float NULL,
        [PidgotovkaSpilnProekt] float NULL,
        [PidgotovkaStud] float NULL,
        [PidgotovkaStudMijn] float NULL,
        [PidgotovkaStudMijnUkr] float NULL,
        [PidgotovkaStudMijnZaKordonom] float NULL,
        [RecenzDesertDoktor] float NULL,
        [RecenzDesertDoktorN] float NULL,
        [RecenzDesertKandidat] float NULL,
        [RecenzDesertKandidatN] float NULL,
        [RecenzMonografy] float NULL,
        [RecenzMonografyNStor] float NULL,
        [RecenzStattya] float NULL,
        [RecenzStattyaN] float NULL,
        [StajZakordonVNZ] float NULL,
        [StajZakordonVNZNDniv] float NULL,
        [StattyaMijnarodVitch] float NULL,
        [StattyaMijnarodZakordon] float NULL,
        [StattyaNeMignarod] float NULL,
        [StattyaScopusAngl] float NULL,
        [StattyaScopusUkr] float NULL,
        [Sum] float NULL,
        [User] nvarchar(max) NULL,
        [VidannyaFahUkr] float NULL,
        [VidannyaMonografy] float NULL,
        [VidannyaNeFahUkr] float NULL,
        [VistavkaNaukDosMijnarod] float NULL,
        [VistavkaNaukDosRegion] float NULL,
        [VistavkaNaukDosVseukrain] float NULL,
        [ZahistDoktor] float NULL,
        [ZahistDoktorBool] bit NOT NULL,
        [ZahistKandidat] float NULL,
        [ZahistKandidatBool] bit NOT NULL,
        CONSTRAINT [PK_NaukRobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609151558_initial')
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
        [User] nvarchar(max) NULL,
        [Vikladach] nvarchar(max) NULL,
        [Vsyogo] float NOT NULL,
        [Zalik] float NOT NULL,
        CONSTRAINT [PK_Navantagennyas] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609151558_initial')
BEGIN
    CREATE TABLE [NavchRobs] (
        [Id] int NOT NULL IDENTITY,
        [DyplomBakalavr] float NULL,
        [DyplomBakalavrNChlen] float NULL,
        [DyplomBakalavrNKeriv] float NULL,
        [DyplomBakalavrNKonsult] float NULL,
        [DyplomMagistr] float NULL,
        [DyplomMagistrNChlen] float NULL,
        [DyplomMagistrNKeriv] float NULL,
        [DyplomMagistrNKonsult] float NULL,
        [DyplomSpecialist] float NULL,
        [DyplomSpecialistNChlen] float NULL,
        [DyplomSpecialistNKeriv] float NULL,
        [DyplomSpecialistNKonsult] float NULL,
        [EkzamenAspirant] float NULL,
        [EkzamenAspirantNStud] float NULL,
        [EkzamenDerjavn] float NULL,
        [EkzamenDerjavnNStud] float NULL,
        [EkzamenInshiPred] float NULL,
        [EkzamenInshiPredNGrup] float NULL,
        [EkzamenInshiPredNRobit] float NULL,
        [EkzamenSluhach] float NULL,
        [EkzamenSluhachNChlen] float NULL,
        [EkzamenTest] float NULL,
        [EkzamenTestNGrup] float NULL,
        [EkzamenUkrMovaDyktant] float NULL,
        [EkzamenUkrMovaDyktantNGrup] float NULL,
        [EkzamenUkrMovaDyktantNRobit] float NULL,
        [EkzamenUkrMovaPerekaz] float NULL,
        [EkzamenUkrMovaPerekazNGrup] float NULL,
        [EkzamenUkrMovaPerekazNRobit] float NULL,
        [EkzamenUkrMovaTvir] float NULL,
        [EkzamenUkrMovaTvirNGrup] float NULL,
        [EkzamenUkrMovaTvirNRobit] float NULL,
        [EkzamenUsn] float NULL,
        [EkzamenUsnNStud] float NULL,
        [Individual] float NULL,
        [KerivnukAspirant] float NULL,
        [KerivnukAspirantN] float NULL,
        [KerivnukSluhach] float NULL,
        [KerivnukSluhachNChlen] float NULL,
        [KerivnukSluhachNKeriv] float NULL,
        [KerivnukSluhachNKonsult] float NULL,
        [KerivnukStajSluhach] float NULL,
        [KerivnukStajSluhachN] float NULL,
        [KerivnukStajVikladach] float NULL,
        [KerivnukZdobuvach] float NULL,
        [KerivnukZdobuvachN] float NULL,
        [KonsultDokrtor] float NULL,
        [KonsultDokrtorN] float NULL,
        [KonsultEkzamDerj] float NULL,
        [KonsultEkzamDerjNGrup] float NULL,
        [KonsultEkzamSemestr] float NULL,
        [KonsultEkzamSemestrNGrup] float NULL,
        [KonsultEkzamVstup] float NULL,
        [KonsultEkzamVstupNGrup] float NULL,
        [KonsultNavch] float NULL,
        [Laboratorni] float NULL,
        [Lekcii] float NULL,
        [PIB] nvarchar(max) NULL,
        [PerevirkaGraf] float NULL,
        [PerevirkaGrafN] float NULL,
        [PerevirkaKontr] float NULL,
        [PerevirkaKontrN] float NULL,
        [PerevirkaKursProjFah] float NULL,
        [PerevirkaKursProjFahNrobit] float NULL,
        [PerevirkaKursProjZagIng] float NULL,
        [PerevirkaKursProjZagIngNRobit] float NULL,
        [PerevirkaKursRobFah] float NULL,
        [PerevirkaKursRobFahNRobit] float NULL,
        [PerevirkaKursRobZagOsv] float NULL,
        [PerevirkaKursRobZagOsvNRobit] float NULL,
        [PerevirkaRefer] float NULL,
        [PerevirkaReferN] float NULL,
        [Prakticni] float NULL,
        [PraktikDiplomna] float NULL,
        [PraktikNavchalna] float NULL,
        [PraktikVirobn] float NULL,
        [RecenzReferat] float NULL,
        [RecenzReferatNRobit] float NULL,
        [SemestEkzPism] float NULL,
        [SemestEkzPismNGrup] float NULL,
        [SemestEkzPismNRobit] float NULL,
        [SemestEkzUsn] float NULL,
        [SemestEkzUsnNGrup] float NULL,
        [Seminar] float NULL,
        [Spivbesida] float NULL,
        [SpivbesidaNStud] float NULL,
        [Sum] float NULL,
        [TematDisc] float NULL,
        [User] nvarchar(max) NULL,
        [Zalik] float NULL,
        CONSTRAINT [PK_NavchRobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609151558_initial')
BEGIN
    CREATE TABLE [NormatKilkistBalivOrgRobs] (
        [Id] int NOT NULL IDENTITY,
        [AdminWebMerejKafedra] float NULL,
        [AdminWebMerejKafedraBool] bit NOT NULL,
        [CivilOboron] float NULL,
        [CivilOboronBool] bit NOT NULL,
        [EstetKaredra] float NULL,
        [FormIndividPlanStud] float NULL,
        [FormIndividPlanStudNStud] float NULL,
        [FormKontingentVstupMagistr] float NULL,
        [FormKontingentVstupMagistrNStud] float NULL,
        [KerivSudKlubSekciya] float NULL,
        [KerivSudKlubSekciyaBool] bit NOT NULL,
        [KontrolYakostiPidgFah] float NULL,
        [KontrolYakostiPidgFahIndividZavdNStud] float NULL,
        [KontrolYakostiPidgFahKontrRobNStud] float NULL,
        [KontrolYakostiPidgFahKontrRobZaochNStud] float NULL,
        [KontrolYakostiPidgFahRozrahGrafRobNStud] float NULL,
        [OcinRobVikladach] float NULL,
        [OcinRobVikladachBool] bit NOT NULL,
        [OhoronaPraci] float NULL,
        [OhoronaPraciBool] bit NOT NULL,
        [OrgDistancZahid] float NULL,
        [OrgMijnarodMobil] float NULL,
        [OrgMijnarodMobilNStud] float NULL,
        [OrgMijnarodZahid] float NULL,
        [OrgNaukSemNAN] float NULL,
        [OrgNaukSemNANGolovaBool] bit NOT NULL,
        [OrgNaukSemNANSekretarBool] bit NOT NULL,
        [OrgNavchDiscInozemMova] float NULL,
        [OrgNavchDiscInozemMovaNDisc] float NULL,
        [OrgOlimpDrugEtap] float NULL,
        [OrgOlimpPershEtap] float NULL,
        [OrgPislyaDiplomOsv] float NULL,
        [OrgPislyaDiplomOsvBool] bit NOT NULL,
        [OrgPodvDyplom] float NULL,
        [OrgPodvDyplomNStud] float NULL,
        [OrgTaProvKultZahid] float NULL,
        [OrgTaProvTematVechir] float NULL,
        [OrgTaSuprovidNaukMetRobKafedra] float NULL,
        [OrgTaSuprovidNaukMetRobKafedraBool] bit NOT NULL,
        [OrgUniverStudZahid] float NULL,
        [OrgVseUkrZahid] float NULL,
        [OrgZyazokZVipusk] float NULL,
        [OrgZyazokZVipuskBool] bit NOT NULL,
        [PIB] nvarchar(max) NULL,
        [PidOrgTaProvSvorchZahod] float NULL,
        [PidgotDyplomVseUkr] float NULL,
        [PidgotDyplomVseUkrNRobit] float NULL,
        [ProfOrientRob] float NULL,
        [ProfOrientRobNDniv] float NULL,
        [ProvedennyaEkskurs] float NULL,
        [ProvedennyaEkskursNZahid] float NULL,
        [RobotaEkspKonkursKomis] float NULL,
        [RobotaEkspKonkursKomisNNINZasid] float NULL,
        [RobotaEkspKonkursKomisUniverNZasid] float NULL,
        [RobotaEksperKomisDesertDoktor] float NULL,
        [RobotaEksperKomisDesertKandidat] float NULL,
        [RobotaFormNaukVidanMijnarod] float NULL,
        [RobotaFormNaukVidanScopus] float NULL,
        [RobotaFormNaukVidanUkr] float NULL,
        [RobotaIzPracevlashtuvannya] float NULL,
        [RobotaIzPracevlashtuvannyaBool] bit NOT NULL,
        [RobotaKomisPoperedZahistDyplom] float NULL,
        [RobotaKomisPoperedZahistDyplomBool] bit NOT NULL,
        [RobotaMetodRad] float NULL,
        [RobotaMetodRadNZasid] float NULL,
        [RobotaNaukMetodNaukTehRadah] float NULL,
        [RobotaNaukMetodNaukTehRadahNZasid] float NULL,
        [RobotaPrimKomis] float NULL,
        [RobotaPrimKomisOsobamBool] bit NOT NULL,
        [RobotaPrimKomisSekretarBool] bit NOT NULL,
        [RobotaRadaDesert] float NULL,
        [RobotaRadaDesertChlenNZasid] float NULL,
        [RobotaRadaDesertGolovaNZasid] float NULL,
        [RobotaRadaDesertSekretarNZasid] float NULL,
        [RobotaRedakNaukVidan] float NULL,
        [RobotaRedakNaukVidanNVipusk] float NULL,
        [RobotaRozvitokMijnarodZvyazok] float NULL,
        [RobotaRozvitokMijnarodZvyazokKafedraBool] bit NOT NULL,
        [RobotaRozvitokMijnarodZvyazokNNIBool] bit NOT NULL,
        [RobotaVKomisMON] float NULL,
        [RobotaVKomisMONNZasid] float NULL,
        [RobotaVchenaRadaUniver] float NULL,
        [RobotaVchenaRadaUniverClenNZasid] float NULL,
        [RobotaVchenaRadaUniverSekretarNNIBool] bit NOT NULL,
        [RobotaVchenaRadaUniverSekretarUniverBool] bit NOT NULL,
        [RobotaVikladachKurator] float NULL,
        [RobotaVikladachKuratorBool] bit NOT NULL,
        [RozpodilNavchNavant] float NULL,
        [RozpodilNavchNavantBool] bit NOT NULL,
        [RozrobSaitKafedra] float NULL,
        [RozrobkaDodatkivMijnarod] float NULL,
        [RozrobkaDodatkivMijnarodBool] bit NOT NULL,
        [SekretarEK] float NULL,
        [SekretarEKBool] bit NOT NULL,
        [SekretarKafedra] float NULL,
        [SekretarKafedraBool] bit NOT NULL,
        [StajVikladach] float NULL,
        [Sum] float NULL,
        [SuprovidVirtNavchSered] float NULL,
        [SuprovidVirtNavchSeredBool] bit NOT NULL,
        [SuprovidWebStorKafedra] float NULL,
        [UchastRadHimRozvidka] float NULL,
        [UchastRadHimRozvidkaBool] bit NOT NULL,
        [UchastTovarMolodVchen] float NULL,
        [UchastTovarMolodVchenBool] bit NOT NULL,
        [UchastURozrobSystemUniver] float NULL,
        [UchastURozrobSystemUniverBool] bit NOT NULL,
        [User] nvarchar(max) NULL,
        [VprovSystemVipuskPrac] float NULL,
        [VprovSystemVipuskPracBool] bit NOT NULL,
        [ZvyazokBiblioteka] float NULL,
        [ZvyazokBibliotekaBool] bit NOT NULL,
        [ZvyazokPidprPrakt] float NULL,
        [ZvyazokPidprPraktBool] bit NOT NULL,
        CONSTRAINT [PK_NormatKilkistBalivOrgRobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609151558_initial')
BEGIN
    CREATE TABLE [OrgRobs] (
        [Id] int NOT NULL IDENTITY,
        [EstetKaredra] float NULL,
        [EstetKaredraBool] bit NOT NULL,
        [KerivnukKafedra] float NULL,
        [KerivnukKafedraBool] bit NOT NULL,
        [ObovjazokKafedra] float NULL,
        [ObovjazokKafedraSekretarBool] bit NOT NULL,
        [ObovjazokKafedraZastupnikBool] bit NOT NULL,
        [OrgKafedraZahid] float NULL,
        [OrgKafedraZahidBool] bit NOT NULL,
        [OrgZagalUniverZahid] float NULL,
        [OrgZagalUniverZahidBool] bit NOT NULL,
        [OrganizaciaEkskurs] float NULL,
        [OrganizaciaEkskursBool] bit NOT NULL,
        [PIB] nvarchar(max) NULL,
        [PidtrumkaWEB] float NULL,
        [PidtrumkaWEBBool] bit NOT NULL,
        [ProvedennyaBesid] float NULL,
        [ProvedennyaBesidBool] bit NOT NULL,
        [RobotaRevizia] float NULL,
        [RobotaReviziaGolovaBool] bit NOT NULL,
        [RobotaReviziaSekretarBool] bit NOT NULL,
        [RobotaReviziaZastupnikBool] bit NOT NULL,
        [RobotaTrudKolektiv] float NULL,
        [RobotaTrudKolektivClenBool] bit NOT NULL,
        [RobotaTrudKolektivGolovaBool] bit NOT NULL,
        [RobotaTrudKolektivSekretarBool] bit NOT NULL,
        [RobotaTrudKolektivZastupnikBool] bit NOT NULL,
        [RobotaVchenaRada] float NULL,
        [RobotaVchenaRadaClenBool] bit NOT NULL,
        [RobotaVchenaRadaGolovaBool] bit NOT NULL,
        [RobotaVchenaRadaSekretarBool] bit NOT NULL,
        [RozrobkaMaterialivZahid] float NULL,
        [RozrobkaMaterialivZahidPhotoBool] bit NOT NULL,
        [RozrobkaMaterialivZahidPrezentaciaBool] bit NOT NULL,
        [RozrobkaMaterialivZahidVideoBool] bit NOT NULL,
        [SekretarNaukMetodSeminar] float NULL,
        [SekretarNaukMetodSeminarNZasid] float NULL,
        [SekretarPrijomKomis] float NULL,
        [SekretarPrijomKomisBool] bit NOT NULL,
        [Sum] float NULL,
        [UchastProfOrient] float NULL,
        [UchastProfOrientBool] bit NOT NULL,
        [User] nvarchar(max) NULL,
        [ZasidannyaKafedra] float NULL,
        [ZasidannyaKafedraNZasid] float NULL,
        CONSTRAINT [PK_OrgRobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609151558_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180609151558_initial', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    ALTER TABLE [NaukRobs] ADD [KerivSudNaukGurtok] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    ALTER TABLE [NaukRobs] ADD [KerivSudNaukGurtokBool] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    ALTER TABLE [NaukRobs] ADD [MaterialMijnNeScopus] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    ALTER TABLE [NaukRobs] ADD [MaterialScopus] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    ALTER TABLE [NaukRobs] ADD [MaterialUkrNeScopus] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    ALTER TABLE [NaukRobs] ADD [TezMijn] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    ALTER TABLE [NaukRobs] ADD [TezUkr] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180609205559_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180609205559_init', N'2.0.3-rtm-10026');
END;

GO

