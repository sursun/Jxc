
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_CommonCode_ParentCommonCode]') AND parent_object_id = OBJECT_ID('CommonCodes'))
alter table CommonCodes  drop constraint fk_CommonCode_ParentCommonCode


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF10316C48F400552]') AND parent_object_id = OBJECT_ID('CureProcess_CureTypes'))
alter table CureProcess_CureTypes  drop constraint FKF10316C48F400552


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF10316C492A1C77F]') AND parent_object_id = OBJECT_ID('CureProcess_CureTypes'))
alter table CureProcess_CureTypes  drop constraint FKF10316C492A1C77F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAA639BD8A949D86B]') AND parent_object_id = OBJECT_ID('EquiIns'))
alter table EquiIns  drop constraint FKAA639BD8A949D86B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAA639BD8747246EF]') AND parent_object_id = OBJECT_ID('EquiIns'))
alter table EquiIns  drop constraint FKAA639BD8747246EF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB6262743CFDA9D72]') AND parent_object_id = OBJECT_ID('EquiOuts'))
alter table EquiOuts  drop constraint FKB6262743CFDA9D72


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB6262743747246EF]') AND parent_object_id = OBJECT_ID('EquiOuts'))
alter table EquiOuts  drop constraint FKB6262743747246EF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK58954903EB2B99B2]') AND parent_object_id = OBJECT_ID('Equipment'))
alter table Equipment  drop constraint FK58954903EB2B99B2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9510855896D8C9FD]') AND parent_object_id = OBJECT_ID('EquiPriceChanges'))
alter table EquiPriceChanges  drop constraint FK9510855896D8C9FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95108558431EAFFD]') AND parent_object_id = OBJECT_ID('EquiPriceChanges'))
alter table EquiPriceChanges  drop constraint FK95108558431EAFFD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDA3CA1BE14759CB]') AND parent_object_id = OBJECT_ID('EquiStoreIns'))
alter table EquiStoreIns  drop constraint FKDA3CA1BE14759CB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDA3CA1BE431EAFFD]') AND parent_object_id = OBJECT_ID('EquiStoreIns'))
alter table EquiStoreIns  drop constraint FKDA3CA1BE431EAFFD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8CAF8043CB7DBD94]') AND parent_object_id = OBJECT_ID('EquiStoreOuts'))
alter table EquiStoreOuts  drop constraint FK8CAF8043CB7DBD94


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8CAF8043431EAFFD]') AND parent_object_id = OBJECT_ID('EquiStoreOuts'))
alter table EquiStoreOuts  drop constraint FK8CAF8043431EAFFD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK167B2FF9715DD629]') AND parent_object_id = OBJECT_ID('GlassStores'))
alter table GlassStores  drop constraint FK167B2FF9715DD629


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK318A099BF9F6F3D]') AND parent_object_id = OBJECT_ID('Orders'))
alter table Orders  drop constraint FK318A099BF9F6F3D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK318A099B92A1C77F]') AND parent_object_id = OBJECT_ID('Orders'))
alter table Orders  drop constraint FK318A099B92A1C77F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK318A099B88445FC0]') AND parent_object_id = OBJECT_ID('Orders'))
alter table Orders  drop constraint FK318A099B88445FC0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK318A099B5F9ECD0E]') AND parent_object_id = OBJECT_ID('Orders'))
alter table Orders  drop constraint FK318A099B5F9ECD0E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A7FD86A644B833B]') AND parent_object_id = OBJECT_ID('Products'))
alter table Products  drop constraint FK4A7FD86A644B833B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A7FD86A715DD629]') AND parent_object_id = OBJECT_ID('Products'))
alter table Products  drop constraint FK4A7FD86A715DD629


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK87F286AD644B833B]') AND parent_object_id = OBJECT_ID('ProductCures'))
alter table ProductCures  drop constraint FK87F286AD644B833B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK87F286AD71192347]') AND parent_object_id = OBJECT_ID('ProductCures'))
alter table ProductCures  drop constraint FK87F286AD71192347


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK87F286AD431EAFFD]') AND parent_object_id = OBJECT_ID('ProductCures'))
alter table ProductCures  drop constraint FK87F286AD431EAFFD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK87F286AD5F9ECD0E]') AND parent_object_id = OBJECT_ID('ProductCures'))
alter table ProductCures  drop constraint FK87F286AD5F9ECD0E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6A59D9B89900F54E]') AND parent_object_id = OBJECT_ID('StoreChanges'))
alter table StoreChanges  drop constraint FK6A59D9B89900F54E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6A59D9B8644B833B]') AND parent_object_id = OBJECT_ID('StoreChanges'))
alter table StoreChanges  drop constraint FK6A59D9B8644B833B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6A59D9B888445FC0]') AND parent_object_id = OBJECT_ID('StoreChanges'))
alter table StoreChanges  drop constraint FK6A59D9B888445FC0


    if exists (select * from dbo.sysobjects where id = object_id(N'CommonCodes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CommonCodes

    if exists (select * from dbo.sysobjects where id = object_id(N'Companies') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Companies

    if exists (select * from dbo.sysobjects where id = object_id(N'CureProcesses') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CureProcesses

    if exists (select * from dbo.sysobjects where id = object_id(N'CureProcess_CureTypes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CureProcess_CureTypes

    if exists (select * from dbo.sysobjects where id = object_id(N'Customers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customers

    if exists (select * from dbo.sysobjects where id = object_id(N'EquiIns') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table EquiIns

    if exists (select * from dbo.sysobjects where id = object_id(N'EquiOuts') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table EquiOuts

    if exists (select * from dbo.sysobjects where id = object_id(N'Equipment') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Equipment

    if exists (select * from dbo.sysobjects where id = object_id(N'EquiPriceChanges') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table EquiPriceChanges

    if exists (select * from dbo.sysobjects where id = object_id(N'EquiStoreIns') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table EquiStoreIns

    if exists (select * from dbo.sysobjects where id = object_id(N'EquiStoreOuts') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table EquiStoreOuts

    if exists (select * from dbo.sysobjects where id = object_id(N'GlassStores') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GlassStores

    if exists (select * from dbo.sysobjects where id = object_id(N'Orders') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Orders

    if exists (select * from dbo.sysobjects where id = object_id(N'Products') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Products

    if exists (select * from dbo.sysobjects where id = object_id(N'ProductCures') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ProductCures

    if exists (select * from dbo.sysobjects where id = object_id(N'RoleAuths') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table RoleAuths

    if exists (select * from dbo.sysobjects where id = object_id(N'StoreChanges') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreChanges

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    create table CommonCodes (
        Id INT IDENTITY NOT NULL,
       Type INT null,
       Name NVARCHAR(255) null,
       Param NVARCHAR(255) null,
       Note NVARCHAR(255) null,
       ParentFk INT null,
       primary key (Id)
    )

    create table Companies (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       RegKey NVARCHAR(4000) null,
       Note NVARCHAR(255) null,
       primary key (Id)
    )

    create table CureProcesses (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       DescString NVARCHAR(255) null,
       AreaPrice DECIMAL(19,5) null,
       EdgePrice DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       primary key (Id)
    )

    create table CureProcess_CureTypes (
        CureProcessFk INT not null,
       CommonCodeFk INT not null
    )

    create table Customers (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Mobile NVARCHAR(255) null,
       Company NVARCHAR(255) null,
       Address NVARCHAR(255) null,
       Note NVARCHAR(255) null,
       primary key (Id)
    )

    create table EquiIns (
        Id INT IDENTITY NOT NULL,
       Quantity INT null,
       Price DECIMAL(19,5) null,
       EquiStoreInFk INT null,
       EquipmentFk INT null,
       primary key (Id)
    )

    create table EquiOuts (
        Id INT IDENTITY NOT NULL,
       Quantity INT null,
       Price DECIMAL(19,5) null,
       EquiStoreOutFk INT null,
       EquipmentFk INT null,
       primary key (Id)
    )

    create table Equipment (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Model NVARCHAR(255) null,
       Unit NVARCHAR(255) null,
       Quantity INT null,
       MinQuantity INT null,
       Price DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       EquiTypeFk INT null,
       primary key (Id)
    )

    create table EquiPriceChanges (
        Id INT IDENTITY NOT NULL,
       Quantity INT null,
       OldPrice DECIMAL(19,5) null,
       NewPrice DECIMAL(19,5) null,
       CreateDateTime DATETIME null,
       EquiInFk INT null,
       UserFk INT null,
       primary key (Id)
    )

    create table EquiStoreIns (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       Price DECIMAL(19,5) null,
       CreateDateTime DATETIME null,
       Note NVARCHAR(255) null,
       EquiFromFk INT null,
       UserFk INT null,
       primary key (Id)
    )

    create table EquiStoreOuts (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       Price DECIMAL(19,5) null,
       CreateDateTime DATETIME null,
       Note NVARCHAR(255) null,
       EquiToFk INT null,
       UserFk INT null,
       primary key (Id)
    )

    create table GlassStores (
        Id INT IDENTITY NOT NULL,
       Thickness INT null,
       LongEdge INT null,
       ShortEdge INT null,
       Amount INT null,
       Area INT null,
       Note NVARCHAR(255) null,
       GlassTypeFk INT null,
       primary key (Id)
    )

    create table Orders (
        Id INT IDENTITY NOT NULL,
       CodeNo NVARCHAR(255) null,
       Addtions NVARCHAR(255) null,
       OrderState INT null,
       DeliveryDate DATETIME null,
       TotalPrice DECIMAL(19,5) null,
       RealTotalPrice DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       ModifyTime DATETIME null,
       CreateTime DATETIME null,
       CustomerFk INT null,
       CureProcessFk INT null,
       CreateUserFk INT null,
       CheckUserFk INT null,
       primary key (Id)
    )

    create table Products (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Thickness INT null,
       LongEdge INT null,
       ShortEdge INT null,
       EdgeLength INT null,
       Area INT null,
       Amount INT null,
       Price DECIMAL(19,5) null,
       Note NVARCHAR(255) null,
       OrderFk INT null,
       GlassTypeFk INT null,
       primary key (Id)
    )

    create table ProductCures (
        Id INT IDENTITY NOT NULL,
       StartTime DATETIME null,
       EndTime DATETIME null,
       Note NVARCHAR(255) null,
       OrderFk INT null,
       CureTypeFk INT null,
       UserFk INT null,
       CheckUserFk INT null,
       primary key (Id)
    )

    create table RoleAuths (
        Id INT IDENTITY NOT NULL,
       Role NVARCHAR(255) null,
       AuthType INT null,
       Auths INT null,
       primary key (Id)
    )

    create table StoreChanges (
        Id INT IDENTITY NOT NULL,
       GlassUsage INT null,
       Amount INT null,
       CreateTime DATETIME null,
       Note NVARCHAR(255) null,
       GlassStoreFk INT null,
       OrderFk INT null,
       CreateUserFk INT null,
       primary key (Id)
    )

    create table Users (
        Id INT IDENTITY NOT NULL,
       MemberShipId UNIQUEIDENTIFIER null,
       LoginName NVARCHAR(255) null,
       RealName NVARCHAR(255) null,
       NickName NVARCHAR(255) null,
       Gender INT null,
       Mobile NVARCHAR(255) null,
       Note NVARCHAR(255) null,
       primary key (Id)
    )

    alter table CommonCodes 
        add constraint fk_CommonCode_ParentCommonCode 
        foreign key (ParentFk) 
        references CommonCodes

    alter table CureProcess_CureTypes 
        add constraint FKF10316C48F400552 
        foreign key (CommonCodeFk) 
        references CommonCodes

    alter table CureProcess_CureTypes 
        add constraint FKF10316C492A1C77F 
        foreign key (CureProcessFk) 
        references CureProcesses

    alter table EquiIns 
        add constraint FKAA639BD8A949D86B 
        foreign key (EquiStoreInFk) 
        references EquiStoreIns

    alter table EquiIns 
        add constraint FKAA639BD8747246EF 
        foreign key (EquipmentFk) 
        references Equipment

    alter table EquiOuts 
        add constraint FKB6262743CFDA9D72 
        foreign key (EquiStoreOutFk) 
        references EquiStoreOuts

    alter table EquiOuts 
        add constraint FKB6262743747246EF 
        foreign key (EquipmentFk) 
        references Equipment

    alter table Equipment 
        add constraint FK58954903EB2B99B2 
        foreign key (EquiTypeFk) 
        references CommonCodes

    alter table EquiPriceChanges 
        add constraint FK9510855896D8C9FD 
        foreign key (EquiInFk) 
        references EquiIns

    alter table EquiPriceChanges 
        add constraint FK95108558431EAFFD 
        foreign key (UserFk) 
        references Users

    alter table EquiStoreIns 
        add constraint FKDA3CA1BE14759CB 
        foreign key (EquiFromFk) 
        references CommonCodes

    alter table EquiStoreIns 
        add constraint FKDA3CA1BE431EAFFD 
        foreign key (UserFk) 
        references Users

    alter table EquiStoreOuts 
        add constraint FK8CAF8043CB7DBD94 
        foreign key (EquiToFk) 
        references CommonCodes

    alter table EquiStoreOuts 
        add constraint FK8CAF8043431EAFFD 
        foreign key (UserFk) 
        references Users

    alter table GlassStores 
        add constraint FK167B2FF9715DD629 
        foreign key (GlassTypeFk) 
        references CommonCodes

    alter table Orders 
        add constraint FK318A099BF9F6F3D 
        foreign key (CustomerFk) 
        references Customers

    alter table Orders 
        add constraint FK318A099B92A1C77F 
        foreign key (CureProcessFk) 
        references CureProcesses

    alter table Orders 
        add constraint FK318A099B88445FC0 
        foreign key (CreateUserFk) 
        references Users

    alter table Orders 
        add constraint FK318A099B5F9ECD0E 
        foreign key (CheckUserFk) 
        references Users

    alter table Products 
        add constraint FK4A7FD86A644B833B 
        foreign key (OrderFk) 
        references Orders

    alter table Products 
        add constraint FK4A7FD86A715DD629 
        foreign key (GlassTypeFk) 
        references CommonCodes

    alter table ProductCures 
        add constraint FK87F286AD644B833B 
        foreign key (OrderFk) 
        references Orders

    alter table ProductCures 
        add constraint FK87F286AD71192347 
        foreign key (CureTypeFk) 
        references CommonCodes

    alter table ProductCures 
        add constraint FK87F286AD431EAFFD 
        foreign key (UserFk) 
        references Users

    alter table ProductCures 
        add constraint FK87F286AD5F9ECD0E 
        foreign key (CheckUserFk) 
        references Users

    alter table StoreChanges 
        add constraint FK6A59D9B89900F54E 
        foreign key (GlassStoreFk) 
        references GlassStores

    alter table StoreChanges 
        add constraint FK6A59D9B8644B833B 
        foreign key (OrderFk) 
        references Orders

    alter table StoreChanges 
        add constraint FK6A59D9B888445FC0 
        foreign key (CreateUserFk) 
        references Users
