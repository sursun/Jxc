
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_CommonCode_ParentCommonCode]') AND parent_object_id = OBJECT_ID('CommonCodes'))
alter table CommonCodes  drop constraint fk_CommonCode_ParentCommonCode


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE43F4B2F72A0B40]') AND parent_object_id = OBJECT_ID('Contacts'))
alter table Contacts  drop constraint FKE43F4B2F72A0B40


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9892D8CC22678E7B]') AND parent_object_id = OBJECT_ID('Departments'))
alter table Departments  drop constraint FK9892D8CC22678E7B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9892D8CC809A3AB2]') AND parent_object_id = OBJECT_ID('Departments'))
alter table Departments  drop constraint FK9892D8CC809A3AB2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8D89C18DFF143BD2]') AND parent_object_id = OBJECT_ID('Goods'))
alter table Goods  drop constraint FK8D89C18DFF143BD2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8D89C18D21A96534]') AND parent_object_id = OBJECT_ID('Goods'))
alter table Goods  drop constraint FK8D89C18D21A96534


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8D89C18DF1943E01]') AND parent_object_id = OBJECT_ID('Goods'))
alter table Goods  drop constraint FK8D89C18DF1943E01


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C7667BAC00C1785]') AND parent_object_id = OBJECT_ID('GoodsTypes'))
alter table GoodsTypes  drop constraint FK8C7667BAC00C1785


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C7667BAF63ED444]') AND parent_object_id = OBJECT_ID('GoodsTypes'))
alter table GoodsTypes  drop constraint FK8C7667BAF63ED444


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7683F2F3DAE3D55]') AND parent_object_id = OBJECT_ID('RelationPeople'))
alter table RelationPeople  drop constraint FK7683F2F3DAE3D55


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFE9A39C0F72A0B40]') AND parent_object_id = OBJECT_ID('Customer'))
alter table Customer  drop constraint FKFE9A39C0F72A0B40


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFE9A39C094516F67]') AND parent_object_id = OBJECT_ID('Customer'))
alter table Customer  drop constraint FKFE9A39C094516F67


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFE9A39C01B6DEBBD]') AND parent_object_id = OBJECT_ID('Customer'))
alter table Customer  drop constraint FKFE9A39C01B6DEBBD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA8958AEEF72A0B40]') AND parent_object_id = OBJECT_ID('Supplier'))
alter table Supplier  drop constraint FKA8958AEEF72A0B40


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA8958AEE23B64A01]') AND parent_object_id = OBJECT_ID('Supplier'))
alter table Supplier  drop constraint FKA8958AEE23B64A01


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB32FAD82431EAFFD]') AND parent_object_id = OBJECT_ID('SysLogs'))
alter table SysLogs  drop constraint FKB32FAD82431EAFFD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C1C7FE5809A3AB2]') AND parent_object_id = OBJECT_ID('Users'))
alter table Users  drop constraint FK2C1C7FE5809A3AB2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C1C7FE57BE59DBD]') AND parent_object_id = OBJECT_ID('Users'))
alter table Users  drop constraint FK2C1C7FE57BE59DBD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C1C7FE566F8BEC2]') AND parent_object_id = OBJECT_ID('Users'))
alter table Users  drop constraint FK2C1C7FE566F8BEC2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EF50328DAE3D55]') AND parent_object_id = OBJECT_ID('Charges'))
alter table Charges  drop constraint FK5EF50328DAE3D55


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EF5032845DDFECC]') AND parent_object_id = OBJECT_ID('Charges'))
alter table Charges  drop constraint FK5EF5032845DDFECC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EF50328431EAFFD]') AND parent_object_id = OBJECT_ID('Charges'))
alter table Charges  drop constraint FK5EF50328431EAFFD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EF50328CCC289EC]') AND parent_object_id = OBJECT_ID('Charges'))
alter table Charges  drop constraint FK5EF50328CCC289EC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EF50328E9450CB1]') AND parent_object_id = OBJECT_ID('Charges'))
alter table Charges  drop constraint FK5EF50328E9450CB1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK792B22F1B40C6F94]') AND parent_object_id = OBJECT_ID('ChargeSwaps'))
alter table ChargeSwaps  drop constraint FK792B22F1B40C6F94


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK792B22F1A1C9001D]') AND parent_object_id = OBJECT_ID('ChargeSwaps'))
alter table ChargeSwaps  drop constraint FK792B22F1A1C9001D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK792B22F1CCC289EC]') AND parent_object_id = OBJECT_ID('ChargeSwaps'))
alter table ChargeSwaps  drop constraint FK792B22F1CCC289EC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK792B22F1E9450CB1]') AND parent_object_id = OBJECT_ID('ChargeSwaps'))
alter table ChargeSwaps  drop constraint FK792B22F1E9450CB1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDE6B5D2EC00C1785]') AND parent_object_id = OBJECT_ID('GoodsPriceAlters'))
alter table GoodsPriceAlters  drop constraint FKDE6B5D2EC00C1785


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDE6B5D2ECCC289EC]') AND parent_object_id = OBJECT_ID('GoodsPriceAlters'))
alter table GoodsPriceAlters  drop constraint FKDE6B5D2ECCC289EC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDE6B5D2EE9450CB1]') AND parent_object_id = OBJECT_ID('GoodsPriceAlters'))
alter table GoodsPriceAlters  drop constraint FKDE6B5D2EE9450CB1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA571125AE162C59]') AND parent_object_id = OBJECT_ID('StoreInDetails'))
alter table StoreInDetails  drop constraint FKA571125AE162C59


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA571125C00C1785]') AND parent_object_id = OBJECT_ID('StoreInDetails'))
alter table StoreInDetails  drop constraint FKA571125C00C1785


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC802496A292D2C5E]') AND parent_object_id = OBJECT_ID('StoreOutDetails'))
alter table StoreOutDetails  drop constraint FKC802496A292D2C5E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC802496AC00C1785]') AND parent_object_id = OBJECT_ID('StoreOutDetails'))
alter table StoreOutDetails  drop constraint FKC802496AC00C1785


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK418BC1F8B2F9346]') AND parent_object_id = OBJECT_ID('StoreTransfers'))
alter table StoreTransfers  drop constraint FK418BC1F8B2F9346


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK418BC1FC2987E65]') AND parent_object_id = OBJECT_ID('StoreTransfers'))
alter table StoreTransfers  drop constraint FK418BC1FC2987E65


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK418BC1FCCC289EC]') AND parent_object_id = OBJECT_ID('StoreTransfers'))
alter table StoreTransfers  drop constraint FK418BC1FCCC289EC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK418BC1FE9450CB1]') AND parent_object_id = OBJECT_ID('StoreTransfers'))
alter table StoreTransfers  drop constraint FK418BC1FE9450CB1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5DDDDAAB888E2EC5]') AND parent_object_id = OBJECT_ID('StoreTransferDetails'))
alter table StoreTransferDetails  drop constraint FK5DDDDAAB888E2EC5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5DDDDAABC00C1785]') AND parent_object_id = OBJECT_ID('StoreTransferDetails'))
alter table StoreTransferDetails  drop constraint FK5DDDDAABC00C1785


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D751C1F2C7EDB5F]') AND parent_object_id = OBJECT_ID('StoreIns'))
alter table StoreIns  drop constraint FK5D751C1F2C7EDB5F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D751C1FEB4908C1]') AND parent_object_id = OBJECT_ID('StoreIns'))
alter table StoreIns  drop constraint FK5D751C1FEB4908C1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D751C1FB6BF4206]') AND parent_object_id = OBJECT_ID('StoreIns'))
alter table StoreIns  drop constraint FK5D751C1FB6BF4206


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D751C1F1A94EE5E]') AND parent_object_id = OBJECT_ID('StoreIns'))
alter table StoreIns  drop constraint FK5D751C1F1A94EE5E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D751C1FDAE3D55]') AND parent_object_id = OBJECT_ID('StoreIns'))
alter table StoreIns  drop constraint FK5D751C1FDAE3D55


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D751C1FCCC289EC]') AND parent_object_id = OBJECT_ID('StoreIns'))
alter table StoreIns  drop constraint FK5D751C1FCCC289EC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D751C1FE9450CB1]') AND parent_object_id = OBJECT_ID('StoreIns'))
alter table StoreIns  drop constraint FK5D751C1FE9450CB1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBA7E4A5F9F6F3D]') AND parent_object_id = OBJECT_ID('StoreOuts'))
alter table StoreOuts  drop constraint FKBBA7E4A5F9F6F3D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBA7E4A5BC383037]') AND parent_object_id = OBJECT_ID('StoreOuts'))
alter table StoreOuts  drop constraint FKBBA7E4A5BC383037


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBA7E4A5CC7854D8]') AND parent_object_id = OBJECT_ID('StoreOuts'))
alter table StoreOuts  drop constraint FKBBA7E4A5CC7854D8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBA7E4A51A94EE5E]') AND parent_object_id = OBJECT_ID('StoreOuts'))
alter table StoreOuts  drop constraint FKBBA7E4A51A94EE5E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBA7E4A5DAE3D55]') AND parent_object_id = OBJECT_ID('StoreOuts'))
alter table StoreOuts  drop constraint FKBBA7E4A5DAE3D55


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBA7E4A5CCC289EC]') AND parent_object_id = OBJECT_ID('StoreOuts'))
alter table StoreOuts  drop constraint FKBBA7E4A5CCC289EC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBA7E4A5E9450CB1]') AND parent_object_id = OBJECT_ID('StoreOuts'))
alter table StoreOuts  drop constraint FKBBA7E4A5E9450CB1


    if exists (select * from dbo.sysobjects where id = object_id(N'Accounts') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Accounts

    if exists (select * from dbo.sysobjects where id = object_id(N'CommonCodes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CommonCodes

    if exists (select * from dbo.sysobjects where id = object_id(N'Companies') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Companies

    if exists (select * from dbo.sysobjects where id = object_id(N'Contacts') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Contacts

    if exists (select * from dbo.sysobjects where id = object_id(N'Departments') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Departments

    if exists (select * from dbo.sysobjects where id = object_id(N'Goods') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Goods

    if exists (select * from dbo.sysobjects where id = object_id(N'GoodsTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GoodsTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'RelationPeople') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table RelationPeople

    if exists (select * from dbo.sysobjects where id = object_id(N'Customer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer

    if exists (select * from dbo.sysobjects where id = object_id(N'Supplier') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Supplier

    if exists (select * from dbo.sysobjects where id = object_id(N'SysLogs') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SysLogs

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    if exists (select * from dbo.sysobjects where id = object_id(N'Charges') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Charges

    if exists (select * from dbo.sysobjects where id = object_id(N'ChargeSwaps') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ChargeSwaps

    if exists (select * from dbo.sysobjects where id = object_id(N'GoodsPriceAlters') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GoodsPriceAlters

    if exists (select * from dbo.sysobjects where id = object_id(N'StoreInDetails') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreInDetails

    if exists (select * from dbo.sysobjects where id = object_id(N'StoreOutDetails') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreOutDetails

    if exists (select * from dbo.sysobjects where id = object_id(N'StoreTransfers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreTransfers

    if exists (select * from dbo.sysobjects where id = object_id(N'StoreTransferDetails') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreTransferDetails

    if exists (select * from dbo.sysobjects where id = object_id(N'StoreIns') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreIns

    if exists (select * from dbo.sysobjects where id = object_id(N'StoreOuts') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreOuts

    create table Accounts (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       CurAmount DECIMAL(19,5) null,
       BaseAmount DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       primary key (Id)
    )

    create table CommonCodes (
        Id INT IDENTITY NOT NULL,
       Type INT null,
       CodeNo NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       Level INT null,
       ParamString NVARCHAR(255) null,
       ParamFlag NVARCHAR(255) null,
       Note NVARCHAR(255) null,
       ParentFk INT null,
       primary key (Id)
    )

    create table Companies (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       Fax NVARCHAR(255) null,
       Telephone NVARCHAR(255) null,
       PostCode NVARCHAR(255) null,
       Address NVARCHAR(255) null,
       RegKey NVARCHAR(4000) null,
       LastCustomerCode NVARCHAR(255) null,
       LastSupplierCode NVARCHAR(255) null,
       Caigou BIT null,
       CaigouTh BIT null,
       Xiaoshou BIT null,
       XiaoshouTh BIT null,
       JizhangLiu BIT null,
       JizhangShou BIT null,
       JizhangZhi BIT null,
       Ruku BIT null,
       Chuku BIT null,
       Tiaojia BIT null,
       PriceAccuracy INT null,
       AmountAccuracy INT null,
       InventoryPricing INT null,
       PointBase DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       primary key (Id)
    )

    create table Contacts (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Gender INT null,
       CardNo NVARCHAR(255) null,
       Birthday DATETIME null,
       Mobile NVARCHAR(255) null,
       QQ NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       Address NVARCHAR(255) null,
       IsDefault INT null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       RelationPersonFk INT null,
       primary key (Id)
    )

    create table Departments (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       Level INT null,
       Note NVARCHAR(255) null,
       ParentFk INT null,
       DepartmentFk INT null,
       primary key (Id)
    )

    create table Goods (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       BarCode NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       Picture NVARCHAR(255) null,
       Model NVARCHAR(255) null,
       Quantity DECIMAL(19,5) null,
       MinQuantity DECIMAL(19,5) null,
       MaxQuantity DECIMAL(19,5) null,
       PurchasePrice DECIMAL(19,5) null,
       RetailPrice DECIMAL(19,5) null,
       MinPrice DECIMAL(19,5) null,
       IsBargin BIT null,
       BarginPrice DECIMAL(19,5) null,
       IsFreePrice BIT null,
       PointBase DECIMAL(19,5) null,
       GoodsStatus INT null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       UnitFk INT null,
       BrandFk INT null,
       DisplayStandsFk INT null,
       primary key (Id)
    )

    create table GoodsTypes (
        Id INT IDENTITY NOT NULL,
       GoodsFk INT null,
       TypeFk INT null,
       primary key (Id)
    )

    create table RelationPeople (
        Id INT IDENTITY NOT NULL,
       RelationType INT null,
       CodeNo NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       Pinyin NVARCHAR(255) null,
       BaseTime DATETIME null,
       Amount DECIMAL(19,5) null,
       CreateTime DATETIME null,
       Note NVARCHAR(255) null,
       AccountFk INT null,
       primary key (Id)
    )

    create table Customer (
        RelationPersonFk INT not null,
       ShoukuanQc DECIMAL(19,5) null,
       ShoukuanYing DECIMAL(19,5) null,
       ShoukuanYu DECIMAL(19,5) null,
       AllowDebt BIT null,
       Debt DECIMAL(19,5) null,
       Point INT null,
       CustomerTypeFk INT null,
       CustomerGradeFk INT null,
       primary key (RelationPersonFk)
    )

    create table Supplier (
        RelationPersonFk INT not null,
       ShuiHao NVARCHAR(255) null,
       CardNo NVARCHAR(255) null,
       TaxRate DECIMAL(19,5) null,
       FukuanQc DECIMAL(19,5) null,
       FukuanYing DECIMAL(19,5) null,
       FukuanYu DECIMAL(19,5) null,
       SupplierTypeFk INT null,
       primary key (RelationPersonFk)
    )

    create table SysLogs (
        Id INT IDENTITY NOT NULL,
       Content NVARCHAR(255) null,
       CreateTime DATETIME null,
       UserFk INT null,
       primary key (Id)
    )

    create table Users (
        Id INT IDENTITY NOT NULL,
       MemberShipId UNIQUEIDENTIFIER null,
       LoginName NVARCHAR(255) null,
       Duty NVARCHAR(255) null,
       RealName NVARCHAR(255) null,
       Pinyin NVARCHAR(255) null,
       NickName NVARCHAR(255) null,
       Gender INT null,
       IdCard NVARCHAR(255) null,
       Birthday DATETIME null,
       EntryDate DATETIME null,
       Mobile NVARCHAR(255) null,
       Address NVARCHAR(255) null,
       EmployeeType INT null,
       MenuRight NVARCHAR(255) null,
       BusinessRight NVARCHAR(255) null,
       EmployeeStatus INT null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       DepartmentFk INT null,
       NationFk INT null,
       DiplomaFk INT null,
       primary key (Id)
    )

    create table Charges (
        Id INT IDENTITY NOT NULL,
       OldAmount DECIMAL(19,5) null,
       Amount DECIMAL(19,5) null,
       AutoCreate BIT null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       AuditTime DATETIME null,
       AuditState INT null,
       AuditNote NVARCHAR(255) null,
       AccountFk INT null,
       ChargeTypeFk INT null,
       UserFk INT null,
       CreatorFk INT null,
       AuditorFk INT null,
       primary key (Id)
    )

    create table ChargeSwaps (
        Id INT IDENTITY NOT NULL,
       OrigAmount DECIMAL(19,5) null,
       DestAmount DECIMAL(19,5) null,
       Amount DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       AuditTime DATETIME null,
       AuditState INT null,
       AuditNote NVARCHAR(255) null,
       OrigAccountFk INT null,
       DestAccountFk INT null,
       CreatorFk INT null,
       AuditorFk INT null,
       primary key (Id)
    )

    create table GoodsPriceAlters (
        Id INT IDENTITY NOT NULL,
       OldPrice DECIMAL(19,5) null,
       NewPrice DECIMAL(19,5) null,
       Quantity DECIMAL(19,5) null,
       StartTime DATETIME null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       AuditTime DATETIME null,
       AuditState INT null,
       AuditNote NVARCHAR(255) null,
       GoodsFk INT null,
       CreatorFk INT null,
       AuditorFk INT null,
       primary key (Id)
    )

    create table StoreInDetails (
        Id INT IDENTITY NOT NULL,
       Quantity DECIMAL(19,5) null,
       Price DECIMAL(19,5) null,
       TotalAomount DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       StoreInFk INT null,
       GoodsFk INT null,
       primary key (Id)
    )

    create table StoreOutDetails (
        Id INT IDENTITY NOT NULL,
       Quantity DECIMAL(19,5) null,
       Price DECIMAL(19,5) null,
       TotalAomount DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       StoreOutFk INT null,
       GoodsFk INT null,
       primary key (Id)
    )

    create table StoreTransfers (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       OrderCode NVARCHAR(255) null,
       OrderTime DATETIME null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       AuditTime DATETIME null,
       AuditState INT null,
       AuditNote NVARCHAR(255) null,
       FromStoreFk INT null,
       ToStoreFk INT null,
       CreatorFk INT null,
       AuditorFk INT null,
       primary key (Id)
    )

    create table StoreTransferDetails (
        Id INT IDENTITY NOT NULL,
       Quantity DECIMAL(19,5) null,
       Price DECIMAL(19,5) null,
       TotalAomount DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       GoodsTransferFk INT null,
       GoodsFk INT null,
       primary key (Id)
    )

    create table StoreIns (
        Id INT IDENTITY NOT NULL,
       AmountPay DECIMAL(19,5) null,
       CodeNo NVARCHAR(255) null,
       OrderCode NVARCHAR(255) null,
       OrderTime DATETIME null,
       Amount DECIMAL(19,5) null,
       Debt DECIMAL(19,5) null,
       Payer NVARCHAR(255) null,
       Payee NVARCHAR(255) null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       AuditTime DATETIME null,
       AuditState INT null,
       AuditNote NVARCHAR(255) null,
       SupplierFk INT null,
       BuyerFk INT null,
       StoreInTypeFk INT null,
       StoreFk INT null,
       AccountFk INT null,
       CreatorFk INT null,
       AuditorFk INT null,
       primary key (Id)
    )

    create table StoreOuts (
        Id INT IDENTITY NOT NULL,
       AmountReceipt DECIMAL(19,5) null,
       CodeNo NVARCHAR(255) null,
       OrderCode NVARCHAR(255) null,
       OrderTime DATETIME null,
       Amount DECIMAL(19,5) null,
       Debt DECIMAL(19,5) null,
       Payer NVARCHAR(255) null,
       Payee NVARCHAR(255) null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       AuditTime DATETIME null,
       AuditState INT null,
       AuditNote NVARCHAR(255) null,
       CustomerFk INT null,
       SellerFk INT null,
       StoreOutTypeFk INT null,
       StoreFk INT null,
       AccountFk INT null,
       CreatorFk INT null,
       AuditorFk INT null,
       primary key (Id)
    )

    alter table CommonCodes 
        add constraint fk_CommonCode_ParentCommonCode 
        foreign key (ParentFk) 
        references CommonCodes

    alter table Contacts 
        add constraint FKE43F4B2F72A0B40 
        foreign key (RelationPersonFk) 
        references RelationPeople

    alter table Departments 
        add constraint FK9892D8CC22678E7B 
        foreign key (ParentFk) 
        references Departments

    alter table Departments 
        add constraint FK9892D8CC809A3AB2 
        foreign key (DepartmentFk) 
        references Departments

    alter table Goods 
        add constraint FK8D89C18DFF143BD2 
        foreign key (UnitFk) 
        references CommonCodes

    alter table Goods 
        add constraint FK8D89C18D21A96534 
        foreign key (BrandFk) 
        references CommonCodes

    alter table Goods 
        add constraint FK8D89C18DF1943E01 
        foreign key (DisplayStandsFk) 
        references CommonCodes

    alter table GoodsTypes 
        add constraint FK8C7667BAC00C1785 
        foreign key (GoodsFk) 
        references Goods

    alter table GoodsTypes 
        add constraint FK8C7667BAF63ED444 
        foreign key (TypeFk) 
        references CommonCodes

    alter table RelationPeople 
        add constraint FK7683F2F3DAE3D55 
        foreign key (AccountFk) 
        references Accounts

    alter table Customer 
        add constraint FKFE9A39C0F72A0B40 
        foreign key (RelationPersonFk) 
        references RelationPeople

    alter table Customer 
        add constraint FKFE9A39C094516F67 
        foreign key (CustomerTypeFk) 
        references CommonCodes

    alter table Customer 
        add constraint FKFE9A39C01B6DEBBD 
        foreign key (CustomerGradeFk) 
        references CommonCodes

    alter table Supplier 
        add constraint FKA8958AEEF72A0B40 
        foreign key (RelationPersonFk) 
        references RelationPeople

    alter table Supplier 
        add constraint FKA8958AEE23B64A01 
        foreign key (SupplierTypeFk) 
        references CommonCodes

    alter table SysLogs 
        add constraint FKB32FAD82431EAFFD 
        foreign key (UserFk) 
        references Users

    alter table Users 
        add constraint FK2C1C7FE5809A3AB2 
        foreign key (DepartmentFk) 
        references Departments

    alter table Users 
        add constraint FK2C1C7FE57BE59DBD 
        foreign key (NationFk) 
        references CommonCodes

    alter table Users 
        add constraint FK2C1C7FE566F8BEC2 
        foreign key (DiplomaFk) 
        references CommonCodes

    alter table Charges 
        add constraint FK5EF50328DAE3D55 
        foreign key (AccountFk) 
        references Accounts

    alter table Charges 
        add constraint FK5EF5032845DDFECC 
        foreign key (ChargeTypeFk) 
        references CommonCodes

    alter table Charges 
        add constraint FK5EF50328431EAFFD 
        foreign key (UserFk) 
        references Users

    alter table Charges 
        add constraint FK5EF50328CCC289EC 
        foreign key (CreatorFk) 
        references Users

    alter table Charges 
        add constraint FK5EF50328E9450CB1 
        foreign key (AuditorFk) 
        references Users

    alter table ChargeSwaps 
        add constraint FK792B22F1B40C6F94 
        foreign key (OrigAccountFk) 
        references Accounts

    alter table ChargeSwaps 
        add constraint FK792B22F1A1C9001D 
        foreign key (DestAccountFk) 
        references Accounts

    alter table ChargeSwaps 
        add constraint FK792B22F1CCC289EC 
        foreign key (CreatorFk) 
        references Users

    alter table ChargeSwaps 
        add constraint FK792B22F1E9450CB1 
        foreign key (AuditorFk) 
        references Users

    alter table GoodsPriceAlters 
        add constraint FKDE6B5D2EC00C1785 
        foreign key (GoodsFk) 
        references Goods

    alter table GoodsPriceAlters 
        add constraint FKDE6B5D2ECCC289EC 
        foreign key (CreatorFk) 
        references Users

    alter table GoodsPriceAlters 
        add constraint FKDE6B5D2EE9450CB1 
        foreign key (AuditorFk) 
        references Users

    alter table StoreInDetails 
        add constraint FKA571125AE162C59 
        foreign key (StoreInFk) 
        references StoreIns

    alter table StoreInDetails 
        add constraint FKA571125C00C1785 
        foreign key (GoodsFk) 
        references Goods

    alter table StoreOutDetails 
        add constraint FKC802496A292D2C5E 
        foreign key (StoreOutFk) 
        references StoreOuts

    alter table StoreOutDetails 
        add constraint FKC802496AC00C1785 
        foreign key (GoodsFk) 
        references Goods

    alter table StoreTransfers 
        add constraint FK418BC1F8B2F9346 
        foreign key (FromStoreFk) 
        references CommonCodes

    alter table StoreTransfers 
        add constraint FK418BC1FC2987E65 
        foreign key (ToStoreFk) 
        references CommonCodes

    alter table StoreTransfers 
        add constraint FK418BC1FCCC289EC 
        foreign key (CreatorFk) 
        references Users

    alter table StoreTransfers 
        add constraint FK418BC1FE9450CB1 
        foreign key (AuditorFk) 
        references Users

    alter table StoreTransferDetails 
        add constraint FK5DDDDAAB888E2EC5 
        foreign key (GoodsTransferFk) 
        references StoreTransfers

    alter table StoreTransferDetails 
        add constraint FK5DDDDAABC00C1785 
        foreign key (GoodsFk) 
        references Goods

    alter table StoreIns 
        add constraint FK5D751C1F2C7EDB5F 
        foreign key (SupplierFk) 
        references Supplier

    alter table StoreIns 
        add constraint FK5D751C1FEB4908C1 
        foreign key (BuyerFk) 
        references Users

    alter table StoreIns 
        add constraint FK5D751C1FB6BF4206 
        foreign key (StoreInTypeFk) 
        references CommonCodes

    alter table StoreIns 
        add constraint FK5D751C1F1A94EE5E 
        foreign key (StoreFk) 
        references CommonCodes

    alter table StoreIns 
        add constraint FK5D751C1FDAE3D55 
        foreign key (AccountFk) 
        references Accounts

    alter table StoreIns 
        add constraint FK5D751C1FCCC289EC 
        foreign key (CreatorFk) 
        references Users

    alter table StoreIns 
        add constraint FK5D751C1FE9450CB1 
        foreign key (AuditorFk) 
        references Users

    alter table StoreOuts 
        add constraint FKBBA7E4A5F9F6F3D 
        foreign key (CustomerFk) 
        references Customer

    alter table StoreOuts 
        add constraint FKBBA7E4A5BC383037 
        foreign key (SellerFk) 
        references Users

    alter table StoreOuts 
        add constraint FKBBA7E4A5CC7854D8 
        foreign key (StoreOutTypeFk) 
        references CommonCodes

    alter table StoreOuts 
        add constraint FKBBA7E4A51A94EE5E 
        foreign key (StoreFk) 
        references CommonCodes

    alter table StoreOuts 
        add constraint FKBBA7E4A5DAE3D55 
        foreign key (AccountFk) 
        references Accounts

    alter table StoreOuts 
        add constraint FKBBA7E4A5CCC289EC 
        foreign key (CreatorFk) 
        references Users

    alter table StoreOuts 
        add constraint FKBBA7E4A5E9450CB1 
        foreign key (AuditorFk) 
        references Users
