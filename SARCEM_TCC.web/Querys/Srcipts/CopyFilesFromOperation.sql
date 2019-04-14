

CREATE TABLE [dbo].[AppiaQuerys] (
[Id] uniqueidentifier NOT NULL,
[MaterialId] int NOT NULL,
[DiretoriaNome] varchar(50),
[SubDiretoriaNome] varchar(50),
[AppiaProjeto] varchar(200),
[AppiaInfoAdicional] varchar(200),
[AppiaResponsavel] varchar(200),
[AppiaDataLanc] datetime,
[MedCurrYear]			money NOT NULL,
[TotCurrYear]			money NOT NULL,
[MedAfterYear]			money NOT NULL,
[TotAfterYear]			money NOT NULL,
[MedAfterYearPlusOne]	money NOT NULL,
[TotAfterYearPlusOne]	money NOT NULL,
[TotTrienio]			money NOT NULL,
[MedTrienio]			money NOT NULL
)

CREATE TABLE [dbo].[CpmCentroMaterialReports] (
[CpmId] uniqueidentifier NOT NULL,
[EmpresaID] bigint NOT NULL,
[MaterialID] int NOT NULL,
[EmpresaNome] varchar(50),
[CentroLogisticoCodSap] varchar(8),
[MaterialCodSap] varchar(10),
[MaterialDescricao] varchar(200),
[MaterialUM] varchar(5),
[MaterialClasse] varchar(5),
[ClassificacaoNome] varchar(50),
[FamiliaNome] varchar(150),
[MGCodeCodigoSap] varchar(10),
[MGCodeDescricao] varchar(100),
[UserName] varchar(200),
[Cpm3] money NOT NULL,
[Cpm6] money NOT NULL,
[Cpm9] money NOT NULL,
[Cpm12] money NOT NULL,
[Cpm15] money NOT NULL,
[Cpm18] money NOT NULL,
[Cpm21] money NOT NULL,
[Cpm24] money NOT NULL,
[DataLanc] datetime NOT NULL
)

CREATE TABLE [dbo].[CpmMaterialReports] (
[CpmId] uniqueidentifier NOT NULL,
[EmpresaID] bigint NOT NULL,
[MaterialID] int NOT NULL,
[EmpresaNome] varchar(50),
[MaterialCodSap] varchar(10),
[MaterialDescricao] varchar(200),
[MaterialUM] varchar(5),
[MaterialClasse] varchar(5),
[ClassificacaoNome] varchar(50),
[FamiliaNome] varchar(150),
[MGCodeCodigoSap] varchar(10),
[MGCodeDescricao] varchar(100),
[UserName] varchar(200),
[Cpm3] money NOT NULL,
[Cpm6] money NOT NULL,
[Cpm9] money NOT NULL,
[Cpm12] money NOT NULL,
[Cpm15] money NOT NULL,
[Cpm18] money NOT NULL,
[Cpm21] money NOT NULL,
[Cpm24] money NOT NULL,
[DataLanc] datetime NOT NULL
)


CREATE TABLE [dbo].[EstoqueConsumoAtuais] (
[ID] uniqueidentifier,
[CentroLogisticoID] int,
[MaterialID] int,
[CentroLogisticoCodSap] varchar(8),
[Lote] varchar(150),
[SapQtde] money NOT NULL,
[SapValor] money NOT NULL,
[FisicoQtde] money NOT NULL,
[FisicoValor] money NOT NULL,
[AdmQtde] money NOT NULL,
[AdmValor] money NOT NULL,
[ConsumoQtde] money NOT NULL,
[ConsumoValor] money NOT NULL,
[TipoDoCentro] varchar(25) NOT NULL,
[DataLanc] date,
[EntradaQtde] money NOT NULL,
[EntradaValor] money NOT NULL
)


CREATE TABLE [dbo].[EstoqueHistoricos] (
[Id] uniqueidentifier NOT NULL,
[EmpresaID] bigint NOT NULL,
[MaterialID] int NOT NULL,
[EmpresaNome] varchar(50),
[CentroLogisticoCodSap] varchar(8),
[MaterialCodSap] varchar(10),
[MaterialDescricao] varchar(200),
[MaterialUM] varchar(5),
[MaterialClasse] varchar(5),
[ClassificacaoNome] varchar(20),
[FamiliaNome] varchar(50),
[MGCodeCodigoSap] varchar(20),
[MGCodeDescricao] varchar(100),
[UserName] varchar(200),
[TipoDaInfo] int NOT NULL,
[M1] money NOT NULL,
[M2] money NOT NULL,
[M3] money NOT NULL,
[M4] money NOT NULL,
[M5] money NOT NULL,
[M6] money NOT NULL,
[M7] money NOT NULL,
[M8] money NOT NULL,
[M9] money NOT NULL,
[M10] money NOT NULL,
[M11] money NOT NULL,
[M12] money NOT NULL,
[DataLanc] datetime NOT NULL,
[AdmVersion] bit NOT NULL
)





