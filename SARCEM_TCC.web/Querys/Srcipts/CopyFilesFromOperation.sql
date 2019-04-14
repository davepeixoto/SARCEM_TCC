insert into rprod5.logistica.dbo.Paises

select * from logisticaProducao.dbo.Paises

insert into rprod5.logistica.dbo.Estados

select * from logisticaProducao.dbo.Estados

insert into Cidades

select * from logisticaProducao.dbo.Cidades

insert into Empresas

select * from logisticaProducao.dbo.Empresas

insert into Diretorias

select * from logisticaProducao.dbo.Diretorias

insert into [logisticaPreProd].[dbo].[SubDiretorias]

  SELECT  [SubDiretoriaID]
      ,[SubDiretoriaNome]
      ,[SubDiretoriaSigla]
      ,[DiretoriaID]
  FROM [logisticaProducao].[dbo].[SubDiretorias]


Insert into UsuarioLogisticaAtividades

select * from logisticaProducao.dbo.UsuarioLogisticaAtividades


use logisticaProducao;
insert into [logisticaPreProd].dbo.AspNetUsers 
([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserBR], [EmpresaID], [DiretoriaID], [UsuarioLogisticaAtividadeID], [Discriminator])
select 
 [Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserBR], [EmpresaID], [DiretoriaID], [UsuarioLogisticaAtividadeID], [Discriminator]

from rprod5.logisticaproducao.dbo.aspnetusers

use logisticaPreProd;
insert into MGCodes

select * from logisticaProducao.dbo.MGCodes


insert into Familias

select * from logisticaProducao.dbo.Familias



--insert into logisticaDeveloperDDD3.dbo.Familias

--select * from logisticaDeveloper5.dbo.Familias
--where
--FamiliaId not in (select FamiliaId from logisticaDeveloperDDD3.dbo.Familias)


insert into Classificacoes

select * from logisticaProducao.dbo.Classificacoes


insert into ClasseAvaliacoes

select * from logisticaProducao.dbo.ClasseAvaliacoes 


insert into logisticaPreProd.dbo.[CentrosLogisticos]
([CentroLogisticoID], [CentroLogisticoCodSap], [CentroLogisticoNome], [Endereco], [CEP], [Complemento], [CidadeID])
select 
[CentroLogisticoID], [CentroLogisticoCodSap], [CentroLogisticoNome], [Endereco], [CEP], [Complemento], [CidadeID]
 from logisticaProducao.dbo.CentroLogisticos


insert into BaseCotacoes

select * from logisticaProducao.dbo.BaseCotacoes


insert into CondicaoDePagamentos

select * from logisticaProducao.dbo.CondicaoDePagamentos



--insert into UnidadeDeMedidas
--select * from logisticaDeveloperDDD2.dbo.UnidadeDeMedidas




use logisticaProducao
 insert into  [logisticaPreProd].[dbo].[Materiais]

SELECT  [MaterialID]
      ,[MaterialCodSap]
      ,[MaterialDescricao]
      ,[MaterialClasse]
      ,[MaterialUM]
      ,[ClassificacaoID]
      ,[FamiliaID]
      ,[MGCodeID]
      ,[MaterialDataInclusao]
      ,[MaterialSubId]
      ,[MaterialBloqueado]
  FROM rprod5.[logisticaProducao].[dbo].[Materiais]

use logisticaProducao;
insert into [logisticaPreProd].dbo.AspNetRoles
select * from rprod5.logisticaproducao.dbo.AspNetRoles



use logisticaProducao;
insert into [logisticaPreProd].dbo.AspNetUserRoles
select * from rprod5.logisticaproducao.dbo.AspNetUserRoles


--use logisticaPreProd;
--insert into EstoqueConsumoAtuais (
--[Id], [CentroLogisticoId], [MaterialId], [CentroLogisticoCodSap], [Lote], [SapQtde], [SapValor], [FisicoQtde], [FisicoValor], [AdmQtde], [AdmValor], [ConsumoQtde], [ConsumoValor], [EntradaQtde], [EntradaValor], [TipoDoCentro], [DataLanc]
--)
--select 
--[ID], [CentroLogisticoID], [MaterialID], [CentroLogisticoCodSap], [Lote], [SapQtde], [SapValor], [FisicoQtde], [FisicoValor], [AdmQtde], [AdmValor], [ConsumoQtde], [ConsumoValor], [EntradaQtde], [EntradaValor], [TipoDoCentro], [DataLanc]
--from logisticaProducao.dbo.EstoqueConsumoAtuais

use logisticaPreProd
insert into Fornecedores
SELECT  [FornecedorID],
      [FornecedorNome]
  FROM [logisticaProducao].[dbo].[Fornecedores]


use logisticaPreProd
insert into Contratos
select * from logisticaProducao.dbo.Contratos


--insert into Contratos
--select * from logisticaDeveloper5.dbo.Contratos
--where
--[ContratoId] not in (select [ContratoId] from logisticaDeveloperDDD3.dbo.Contratos )


insert into [ItemDoContratos]
SELECT [ItemDoContratoID]
      ,[ContratoID]
      ,[ItemDoContratoItm]
      ,[MaterialID]
      ,[ItemDoContratoElim]
      ,[CentroLogisticoID]
      ,[ItemDoContratoQtdeDisp]
      ,[ItemDoContratoQtdeContrato]
      ,[ItemDoContratoValRef]
      ,[ItemDoContratoDataLanc]
      ,[ItemDoContratoDataAlteracao]
  FROM [logisticaProducao].[dbo].[ItemDoContratos]

insert into PedidoDeCompras

SELECT [PedidoDeCompraId]
      ,[EmpresaId]
      ,[Pedido]
      ,[DataCriacao]
      ,[Tipo]
      ,[OrgDeCompra]
      ,[FornecedorId]
      ,[Criador]
      ,[CondicaoDePagamentoID]
      ,[BaseCotacaoID]
  FROM [logisticaProducao].[dbo].[PedidoDeCompras]


insert into ItemPedidoDeCompras
select 
*
from logisticaProducao.dbo.ItemPedidoDeCompras

insert into Zmeps
select 
[ZmepPedido], [ZmepPos], [MaterialID], [ZmepDataEntrg], [ZmepQtdePedido], [ZmepQtdeEmPend], [ZmepImpPedido], [ZmepImpEmPend], [BaseCotacaoID], [FornecedorID], [ContratoID], [ZmepDataDaCompra], [CondicaoDePagamentoID], [ZmepDataLanc], [ZmepCentroImputado]
from logisticaProducao.dbo.Zmeps



insert into MovimentoSapN1s
select * from logisticaProducao.dbo.MovimentoSapN1s

insert into MovimentoSapN2s
select * from logisticaProducao.dbo.MovimentoSapN2s



insert into MovimentoEstoques
select * from logisticaProducao.dbo.MovimentoEstoques


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

insert into AppiaQuerys
select * from logisticaProducao.dbo.AppiaQuerys

insert into PlmMensalizados
select * from logisticaProducao.dbo.PlmMensalizados

CREATE TABLE [dbo].[CpmCentroMaterialReports] (
[CpmId] uniqueidentifier NOT NULL,
[EmpresaID] bigint NOT NULL,
[MaterialID] int NOT NULL,
[EmpresaNome] varchar(50),
[CentroLogisticoCodSap] varchar(5),
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

insert into [CpmMaterialReports]
select * from [CpmMaterialReports]

CREATE TABLE [dbo].[EstoqueConsumoAtuais] (
[ID] uniqueidentifier,
[CentroLogisticoID] int,
[MaterialID] int,
[CentroLogisticoCodSap] varchar(5),
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

insert into EstoqueConsumoAtuais
select * from logisticaProducao.dbo.EstoqueConsumoAtuais



CREATE TABLE [dbo].[EstoqueHistoricos] (
[Id] uniqueidentifier NOT NULL,
[EmpresaID] bigint NOT NULL,
[MaterialID] int NOT NULL,
[EmpresaNome] varchar(50),
[CentroLogisticoCodSap] varchar(5),
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

insert into [EstoqueHistoricos]
select * from logisticaProducao.dbo.[EstoqueHistoricos]



CREATE TABLE [dbo].[F0b1] (
[CentroLogisticoID] int NOT NULL,
[MaterialID] int,
[Lote] varchar(150),
[Qtde] money NOT NULL,
[Valor] money NOT NULL,
[zmovQtde] money NOT NULL,
[zmovValor] money NOT NULL,
[DataLanc] date
)

insert into [F0b1]
select * from logisticaProducao.dbo.[F0b1]


CREATE TABLE [dbo].[BaseEstoqueConsumoPlmEntradaAppia](
	[MatId] [int] NULL,
	[Periodo] [bigint] NULL,
	[Equivalente] [int] NULL,
	[ConsumoQtde]   MONEY NOT NULL,
	[ConsumoValor]  MONEY NOT NULL,
	[EstoqueQtde]   MONEY NOT NULL,
	[EstoqueValor]  MONEY NOT NULL,
	[PlmQuantidade] MONEY NOT NULL,
	[EntradaQtde]	MONEY NOT NULL,
	[EntradaValor]	MONEY NOT NULL,
	[AppiaQuantidade] MONEY NOT NULL,
	[DataLanc] [date] NULL
) ON [PRIMARY]