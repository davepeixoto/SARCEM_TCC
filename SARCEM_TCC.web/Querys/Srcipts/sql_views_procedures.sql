USE logistica
GO
/****** Object:  View [dbo].[VMaterial]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VMaterial]
AS
SELECT        dbo.Materiais.MaterialID, dbo.Empresas.EmpresaID, dbo.Empresas.EmpresaNome, dbo.Materiais.MaterialCodSap, dbo.Materiais.MaterialDescricao, dbo.Materiais.MaterialClasse, dbo.Materiais.MaterialUM, 
                         dbo.Classificacoes.ClassificacaoID, dbo.Classificacoes.ClassificacaoNome, dbo.Familias.FamiliaID, dbo.Familias.FamiliaNome, dbo.AspNetUsers.Id AS UserId, dbo.AspNetUsers.UserName, dbo.MGCodes.MGCodeID, 
                         dbo.MGCodes.MGCodeCodigoSap, dbo.MGCodes.MGCodeDescricao, dbo.Materiais.MaterialDataInclusao, dbo.Materiais.MaterialSubId, dbo.Materiais.MaterialBloqueado, CASE WHEN MaterialSubId = 0 OR
                         MaterialSubId IS NULL THEN 'Sem Material Substituto' ELSE MaterialSubCodSap END AS MaterialSubstituto
FROM            dbo.Materiais INNER JOIN
                         dbo.Classificacoes ON dbo.Materiais.ClassificacaoID = dbo.Classificacoes.ClassificacaoID INNER JOIN
                         dbo.Familias ON dbo.Materiais.FamiliaID = dbo.Familias.FamiliaID INNER JOIN
                         dbo.Empresas ON dbo.Familias.EmpresaID = dbo.Empresas.EmpresaID INNER JOIN
                         dbo.AspNetUsers ON dbo.Familias.UsuarioLogisticaID = dbo.AspNetUsers.Id INNER JOIN
                         dbo.MGCodes ON dbo.Materiais.MGCodeID = dbo.MGCodes.MGCodeID LEFT OUTER JOIN
                             (SELECT        MaterialID AS MatId, MaterialCodSap AS MaterialSubCodSap
                               FROM            dbo.Materiais AS Materiais_1) AS mat ON dbo.Materiais.MaterialSubId = mat.MatId
WHERE        (dbo.Materiais.MaterialID > 0)
GO
/****** Object:  View [dbo].[ValorReferencias]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ValorReferencias]
AS
SELECT        EmpresaID, MaterialID, FamiliaID, MGCodeID, ClassificacaoID, EmpresaNome, MaterialCodSap, MaterialDescricao, MaterialUM, MaterialClasse, ClassificacaoNome, FamiliaNome, MGCodeCodigoSap, MGCodeDescricao, 
                         UserName, ValorDeReferencia, Origem, MaterialSubId, MaterialBloqueado, MaterialSubstituto, UserId, MaterialDataInclusao
FROM            (SELECT        NEWID() AS Id, dbo.VMaterial.EmpresaID, dbo.VMaterial.MaterialID, dbo.VMaterial.FamiliaID, dbo.VMaterial.MGCodeID, dbo.VMaterial.ClassificacaoID, dbo.VMaterial.EmpresaNome, dbo.VMaterial.MaterialCodSap, 
                                                    dbo.VMaterial.MaterialDescricao, dbo.VMaterial.MaterialUM, dbo.VMaterial.MaterialClasse, dbo.VMaterial.ClassificacaoNome, dbo.VMaterial.FamiliaNome, dbo.VMaterial.MGCodeCodigoSap, 
                                                    dbo.VMaterial.MGCodeDescricao, dbo.VMaterial.UserName, ISNULL(Preco.ValRef, 0) AS ValorDeReferencia, CASE WHEN Origem IS NULL 
                                                    THEN 'Sem informação' WHEN Origem = 'HTC' THEN 'Histórico de Compras' ELSE origem END AS Origem, dbo.VMaterial.MaterialSubId, dbo.VMaterial.MaterialBloqueado, dbo.VMaterial.MaterialSubstituto, 
                                                    dbo.VMaterial.UserId, dbo.VMaterial.MaterialDataInclusao
                          FROM            (SELECT        ISNULL(MatOperacao, MatEstCompMM.Material) AS Material, ISNULL(OpLogis.ValRefOpercao, MatEstCompMM.ValRef) AS ValRef, ISNULL(OpLogis.Origem, MatEstCompMM.Origem) AS Origem
                                                    FROM            (SELECT        ISNULL(EstqComp.Material, mmm60.MaterialID) AS Material, ISNULL(EstqComp.ValRef, mmm60.Mm60Valor) AS ValRef, ISNULL(EstqComp.Origem, mmm60.origem) AS Origem
                                                                              FROM            (SELECT        ISNULL(FromEstoque.MatEstoque, Comp.MatComp) AS Material, ISNULL(FromEstoque.ValRefEstoque, Comp.valRefComp) AS ValRef, ISNULL(FromEstoque.Origem, Comp.Origem) 
                                                                                                                                  AS Origem
                                                                                                        FROM            (SELECT DISTINCT 
                                                                                                                                                            dbo.ItemPedidoDeCompras.MaterialID AS MatComp, MAX(dbo.ItemPedidoDeCompras.ItemPedidoDeCompraValorReferencia * dbo.BaseCotacoes.BaseCotacaoValor) 
                                                                                                                                                            AS valRefComp, 'HTC' AS Origem
                                                                                                                                  FROM            dbo.ItemPedidoDeCompras INNER JOIN
                                                                                                                                                            dbo.PedidoDeCompras ON dbo.ItemPedidoDeCompras.PedidoDeCompraId = dbo.PedidoDeCompras.PedidoDeCompraId INNER JOIN
                                                                                                                                                            dbo.BaseCotacoes ON dbo.PedidoDeCompras.BaseCotacaoID = dbo.BaseCotacoes.BaseCotacaoID INNER JOIN
                                                                                                                                                                (SELECT        ItemPedidoDeCompras_1.MaterialID AS MatComp, MAX(PedidoDeCompras_1.DataCriacao) AS dtCriacao
                                                                                                                                                                  FROM            dbo.ItemPedidoDeCompras AS ItemPedidoDeCompras_1 INNER JOIN
                                                                                                                                                                                            dbo.PedidoDeCompras AS PedidoDeCompras_1 ON ItemPedidoDeCompras_1.PedidoDeCompraId = PedidoDeCompras_1.PedidoDeCompraId
                                                                                                                                                                  GROUP BY ItemPedidoDeCompras_1.MaterialID) AS z ON dbo.ItemPedidoDeCompras.MaterialID = z.MatComp AND 
                                                                                                                                                            dbo.PedidoDeCompras.DataCriacao = z.dtCriacao
                                                                                                                                  GROUP BY dbo.ItemPedidoDeCompras.MaterialID) AS Comp FULL OUTER JOIN
                                                                                                                                      (SELECT        MatEstoque, ValRefEstoque, Origem
                                                                                                                                        FROM            (SELECT        MaterialID AS MatEstoque, SUM(SapValor) / SUM(SapQtde) AS ValRefEstoque, 'Estoque Atual' AS Origem
                                                                                                                                                                  FROM            dbo.EstoqueConsumoAtuais
                                                                                                                                                                  WHERE        (SapQtde > 0)
                                                                                                                                                                  GROUP BY MaterialID) AS z_2
                                                                                                                                        WHERE        (ValRefEstoque > 0)) AS FromEstoque ON FromEstoque.MatEstoque = Comp.MatComp) AS EstqComp FULL OUTER JOIN
                                                                                                            (SELECT        MaterialID, Mm60Valor, 'Extrato MM60' AS origem
                                                                                                              FROM            dbo.Mm60s
                                                                                                              WHERE        (Mm60Equivalente =
                                                                                                                                            (SELECT        MAX(Mm60Equivalente) AS Expr1
                                                                                                                                              FROM            dbo.Mm60s AS Mm60s_1))) AS mmm60 ON EstqComp.Material = mmm60.MaterialID) AS MatEstCompMM FULL OUTER JOIN
                                                                                  (SELECT        MaterialID AS MatOperacao, PrecoValor AS ValRefOpercao, 'Logística' AS Origem
                                                                                    FROM            (SELECT        MaterialID, MAX(PrecoDataLanc) AS MaxPrecoDataLanc, PrecoValor
                                                                                                              FROM            dbo.ReferenciaDePrecos
                                                                                                              GROUP BY MaterialID, PrecoValor) AS z_1) AS OpLogis ON OpLogis.MatOperacao = MatEstCompMM.Material) AS Preco RIGHT OUTER JOIN
                                                    dbo.VMaterial ON Preco.Material = dbo.VMaterial.MaterialID) AS VR
GO
/****** Object:  View [dbo].[VF0b1]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VF0b1]
AS
SELECT        dbo.ValorReferencias.MaterialID, dbo.F0b1.Lote, dbo.ValorReferencias.MaterialCodSap, dbo.ValorReferencias.MaterialDescricao, dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.MaterialUM, 
                         dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.UserName, dbo.ValorReferencias.MGCodeCodigoSap, dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.FamiliaNome, CONVERT(money, 
                         dbo.F0b1.Qtde) AS EstqQtde, dbo.F0b1.Qtde * dbo.ValorReferencias.ValorDeReferencia AS EstqValor, dbo.F0b1.zmovQtde AS ConsumoQtde, dbo.F0b1.zmovQtde * dbo.ValorReferencias.ValorDeReferencia AS ConsumoValor, 
                         dbo.ValorReferencias.ValorDeReferencia, dbo.F0b1.DataLanc
FROM            dbo.F0b1 INNER JOIN
                         dbo.ValorReferencias ON dbo.F0b1.MaterialID = dbo.ValorReferencias.MaterialID
GO
/****** Object:  View [dbo].[VAppiaQuerys]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VAppiaQuerys] as  SELECT       																																																			dbo.AppiaQuerys.Id, dbo.AppiaQuerys.MaterialId, dbo.ValorReferencias.EmpresaNome, dbo.ValorReferencias.MaterialCodSap, dbo.ValorReferencias.MaterialDescricao, dbo.ValorReferencias.MaterialClasse, 					dbo.ValorReferencias.MaterialUM, dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.UserName, dbo.ValorReferencias.MGCodeCodigoSap, dbo.ValorReferencias.MGCodeDescricao, 									dbo.ValorReferencias.FamiliaNome, dbo.AppiaQuerys.DiretoriaNome, dbo.AppiaQuerys.SubDiretoriaNome, dbo.AppiaQuerys.AppiaProjeto, dbo.AppiaQuerys.AppiaInfoAdicional, dbo.AppiaQuerys.AppiaResponsavel, 					dbo.AppiaQuerys.AppiaDataLanc, dbo.AppiaQuerys.MedCurrYear, dbo.AppiaQuerys.TotCurrYear, dbo.AppiaQuerys.MedAfterYear, dbo.AppiaQuerys.TotAfterYear, dbo.AppiaQuerys.MedAfterYearPlusOne, 								dbo.AppiaQuerys.TotAfterYearPlusOne, dbo.AppiaQuerys.TotTrienio, dbo.AppiaQuerys.MedTrienio, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) AS ValorDeReferencia, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) 	* dbo.AppiaQuerys.MedCurrYear AS MedCurrYearEmReal, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) * dbo.AppiaQuerys.TotCurrYear AS TotCurrYearEmReal, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) 			* dbo.AppiaQuerys.MedAfterYear AS MedAfterYearEmReal, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) * dbo.AppiaQuerys.TotAfterYear AS TotAfterYearEmReal, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) 		* dbo.AppiaQuerys.MedAfterYearPlusOne AS MedAfterYearPlusOneEmReal, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) * dbo.AppiaQuerys.TotAfterYearPlusOne AS TotAfterYearPlusOneEmReal, 								ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) * dbo.AppiaQuerys.TotTrienio AS TotTrienioEmReal, ISNULL(dbo.ValorReferencias.ValorDeReferencia, 0) * dbo.AppiaQuerys.MedTrienio AS MedTrienioEmReal, 				dbo.ValorReferencias.MaterialSubstituto, dbo.ValorReferencias.MaterialBloqueado																																			FROM            dbo.AppiaQuerys INNER JOIN																																												dbo.ValorReferencias ON dbo.AppiaQuerys.MaterialId = dbo.ValorReferencias.MaterialID	
GO
/****** Object:  View [dbo].[VEstoqueConsumoAtuais]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VEstoqueConsumoAtuais] as  SELECT        NEWID() AS Id, dbo.ValorReferencias.EmpresaID, dbo.EstoqueConsumoAtuais.CentroLogisticoID, dbo.ValorReferencias.MaterialID, dbo.ValorReferencias.EmpresaNome, dbo.EstoqueConsumoAtuais.CentroLogisticoCodSap, 	                         dbo.EstoqueConsumoAtuais.Lote, dbo.ValorReferencias.MaterialCodSap, dbo.ValorReferencias.MaterialDescricao, dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.MaterialUM, 						                         dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.UserName, dbo.ValorReferencias.MGCodeCodigoSap, dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.FamiliaNome, 					                         dbo.EstoqueConsumoAtuais.SapQtde, dbo.EstoqueConsumoAtuais.SapValor, dbo.EstoqueConsumoAtuais.FisicoQtde, dbo.EstoqueConsumoAtuais.FisicoValor, dbo.EstoqueConsumoAtuais.AdmQtde, 						                         dbo.EstoqueConsumoAtuais.AdmValor, dbo.EstoqueConsumoAtuais.ConsumoQtde, dbo.EstoqueConsumoAtuais.ConsumoValor, dbo.EstoqueConsumoAtuais.EntradaQtde, dbo.EstoqueConsumoAtuais.EntradaValor, 			                         dbo.EstoqueConsumoAtuais.TipoDoCentro, dbo.EstoqueConsumoAtuais.DataLanc, dbo.ValorReferencias.MaterialBloqueado, dbo.ValorReferencias.MaterialSubstituto												FROM            dbo.EstoqueConsumoAtuais INNER JOIN																																												                         dbo.ValorReferencias ON dbo.EstoqueConsumoAtuais.MaterialID = dbo.ValorReferencias.MaterialID																											
GO
/****** Object:  View [dbo].[VCpmCentroMaterialReports]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VCpmCentroMaterialReports]  as  SELECT        NEWID() AS Id, dbo.ValorReferencias.EmpresaID, dbo.ValorReferencias.MaterialID, dbo.ValorReferencias.EmpresaNome, dbo.CpmCentroMaterialReports.CentroLogisticoCodSap, dbo.ValorReferencias.MaterialCodSap, 				                         dbo.ValorReferencias.MaterialDescricao, dbo.ValorReferencias.MaterialUM, dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.FamiliaNome, 						                         dbo.ValorReferencias.MGCodeCodigoSap, dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.UserName, dbo.CpmCentroMaterialReports.Cpm3, dbo.CpmCentroMaterialReports.Cpm6, 								                         dbo.CpmCentroMaterialReports.Cpm9, dbo.CpmCentroMaterialReports.Cpm12, dbo.CpmCentroMaterialReports.Cpm15, dbo.CpmCentroMaterialReports.Cpm18, dbo.CpmCentroMaterialReports.Cpm21, 							                         dbo.CpmCentroMaterialReports.Cpm24, dbo.CpmCentroMaterialReports.DataLanc, dbo.ValorReferencias.MaterialBloqueado, dbo.ValorReferencias.MaterialSubstituto														FROM            dbo.ValorReferencias INNER JOIN																																															                         dbo.CpmCentroMaterialReports ON dbo.ValorReferencias.MaterialID = dbo.CpmCentroMaterialReports.MaterialID																										
GO
/****** Object:  View [dbo].[VCpmMaterialReports]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VCpmMaterialReports] as  SELECT        NEWID() AS Id, dbo.ValorReferencias.EmpresaID, dbo.ValorReferencias.MaterialID, dbo.ValorReferencias.EmpresaNome, dbo.ValorReferencias.MaterialCodSap, dbo.ValorReferencias.MaterialDescricao, 				                         dbo.ValorReferencias.MaterialUM, dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.FamiliaNome, dbo.ValorReferencias.MGCodeCodigoSap, 				                         dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.UserName, dbo.CpmMaterialReports.Cpm3, dbo.CpmMaterialReports.Cpm6, dbo.CpmMaterialReports.Cpm9, dbo.CpmMaterialReports.Cpm12, 			                         dbo.CpmMaterialReports.Cpm15, dbo.CpmMaterialReports.Cpm18, dbo.CpmMaterialReports.Cpm21, dbo.CpmMaterialReports.Cpm24, dbo.CpmMaterialReports.DataLanc, dbo.ValorReferencias.MaterialBloqueado, 	                         dbo.ValorReferencias.MaterialSubstituto																																							FROM            dbo.ValorReferencias INNER JOIN																																												                         dbo.CpmMaterialReports ON dbo.ValorReferencias.MaterialID = dbo.CpmMaterialReports.MaterialID																										
GO
/****** Object:  View [dbo].[VEstoqueHistoricos]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VEstoqueHistoricos] as  SELECT        NEWID() AS Id, dbo.ValorReferencias.EmpresaID, dbo.ValorReferencias.MaterialID, dbo.ValorReferencias.EmpresaNome, dbo.EstoqueHistoricos.CentroLogisticoCodSap, dbo.ValorReferencias.MaterialCodSap, 							                         dbo.ValorReferencias.MaterialDescricao, dbo.ValorReferencias.MaterialUM, dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.FamiliaNome, 							                         dbo.ValorReferencias.MGCodeCodigoSap, dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.UserName, dbo.EstoqueHistoricos.TipoDaInfo, dbo.EstoqueHistoricos.M1, dbo.EstoqueHistoricos.M2, 					                         dbo.EstoqueHistoricos.M3, dbo.EstoqueHistoricos.M4, dbo.EstoqueHistoricos.M5, dbo.EstoqueHistoricos.M6, dbo.EstoqueHistoricos.M7, dbo.EstoqueHistoricos.M8, dbo.EstoqueHistoricos.M9, dbo.EstoqueHistoricos.M10, 	                         dbo.EstoqueHistoricos.M11, dbo.EstoqueHistoricos.M12, dbo.EstoqueHistoricos.DataLanc, dbo.EstoqueHistoricos.AdmVersion, dbo.ValorReferencias.MaterialBloqueado, dbo.ValorReferencias.MaterialSubstituto			FROM            dbo.EstoqueHistoricos INNER JOIN																																															                         dbo.ValorReferencias ON dbo.EstoqueHistoricos.MaterialID = dbo.ValorReferencias.MaterialID																															
GO
/****** Object:  View [dbo].[VPlmMensalizados]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE view[dbo].[VPlmMensalizados] as  SELECT        dbo.PlmMensalizados.Id, dbo.PlmMensalizados.MaterialId, dbo.ValorReferencias.EmpresaNome, dbo.PlmMensalizados.CentroLogisticoCodSap, dbo.ValorReferencias.MaterialCodSap, dbo.ValorReferencias.MaterialDescricao, 		                         dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.MaterialUM, dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.UserName, dbo.ValorReferencias.MGCodeCodigoSap, 							                         dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.FamiliaNome, dbo.PlmMensalizados.Sigla, dbo.PlmMensalizados.DiretoriaNome, dbo.PlmMensalizados.SubDiretoriaNome, dbo.PlmMensalizados.PlmProjeto, 	                         dbo.PlmMensalizados.PlmInfoAdicional, dbo.PlmMensalizados.PlmResponsavel, dbo.PlmMensalizados.PlmDataLanc, dbo.ValorReferencias.ValorDeReferencia, dbo.PlmMensalizados.Mes1CurrYear, 							                         dbo.PlmMensalizados.Mes2CurrYear, dbo.PlmMensalizados.Mes3CurrYear, dbo.PlmMensalizados.Mes4CurrYear, dbo.PlmMensalizados.Mes5CurrYear, dbo.PlmMensalizados.Mes6CurrYear, 										                         dbo.PlmMensalizados.Mes7CurrYear, dbo.PlmMensalizados.Mes8CurrYear, dbo.PlmMensalizados.Mes9CurrYear, dbo.PlmMensalizados.Mes10CurrYear, dbo.PlmMensalizados.Mes11CurrYear, 									                         dbo.PlmMensalizados.Mes12CurrYear, dbo.PlmMensalizados.Mes1AfterYear, dbo.PlmMensalizados.Mes2AfterYear, dbo.PlmMensalizados.Mes3AfterYear, dbo.PlmMensalizados.Mes4AfterYear, 								                         dbo.PlmMensalizados.Mes5AfterYear, dbo.PlmMensalizados.Mes6AfterYear, dbo.PlmMensalizados.Mes7AfterYear, dbo.PlmMensalizados.Mes8AfterYear, dbo.PlmMensalizados.Mes9AfterYear, 								                         dbo.PlmMensalizados.Mes10AfterYear, dbo.PlmMensalizados.Mes11AfterYear, dbo.PlmMensalizados.Mes12AfterYear, dbo.ValorReferencias.MaterialSubstituto, dbo.ValorReferencias.MaterialBloqueado					FROM            dbo.PlmMensalizados INNER JOIN																																															                         dbo.ValorReferencias ON dbo.PlmMensalizados.MaterialId = dbo.ValorReferencias.MaterialID																														
GO
/****** Object:  View [dbo].[VZmeps]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VZmeps] as  SELECT        NEWID() AS ZmepId, dbo.ValorReferencias.MaterialID, dbo.ValorReferencias.EmpresaNome, dbo.Zmeps.ZmepPedido, dbo.Zmeps.ZmepPos AS Posicao, dbo.ValorReferencias.MaterialCodSap, dbo.ValorReferencias.MaterialDescricao, 													                         dbo.ValorReferencias.MaterialUM, dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.FamiliaNome, dbo.ValorReferencias.MGCodeCodigoSap, dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.UserName, 	                         dbo.Zmeps.ZmepDataEntrg, CASE WHEN ZmepDataEntrg < CAST(GETDATE() AS date) THEN 'Atrasado' ELSE 'Futuro' END AS Status, MONTH(dbo.Zmeps.ZmepDataEntrg) AS Mes, YEAR(dbo.Zmeps.ZmepDataEntrg) AS Ano, 															                         dbo.Zmeps.ZmepQtdePedido, dbo.Zmeps.ZmepQtdeEmPend, dbo.Zmeps.ZmepImpPedido, dbo.Zmeps.ZmepImpEmPend, 																																							                         dbo.Zmeps.ZmepImpEmPend * dbo.BaseCotacoes.BaseCotacaoValor AS MontantePendenteEntregaEmReal, dbo.BaseCotacoes.BaseCotacaoSigla, dbo.BaseCotacoes.BaseCotacaoValor, dbo.Fornecedores.FornecedorNome, 															                         dbo.Contratos.ContratoNumero, dbo.Zmeps.ZmepDataDaCompra, dbo.CondicaoDePagamentos.CondicaoDePagamentoCodSap, dbo.CondicaoDePagamentos.CondicaoDePagamentoDescricao, dbo.Zmeps.ZmepDataLanc, 																	                         dbo.Zmeps.ZmepCentroImputado,  dbo.ValorReferencias.MaterialBloqueado, dbo.ValorReferencias.MaterialSubstituto																																					FROM            dbo.Zmeps INNER JOIN																																																													                         dbo.ValorReferencias ON dbo.Zmeps.MaterialID = dbo.ValorReferencias.MaterialID INNER JOIN																																										                         dbo.BaseCotacoes ON dbo.Zmeps.BaseCotacaoID = dbo.BaseCotacoes.BaseCotacaoID INNER JOIN																																										                         dbo.Fornecedores ON dbo.Zmeps.FornecedorID = dbo.Fornecedores.FornecedorID INNER JOIN																																											                         dbo.Contratos ON dbo.Zmeps.ContratoID = dbo.Contratos.ContratoID INNER JOIN																																													                         dbo.CondicaoDePagamentos ON dbo.Zmeps.CondicaoDePagamentoID = dbo.CondicaoDePagamentos.CondicaoDePagamentoID																																					
GO
/****** Object:  View [dbo].[VPlmMensalizadosLastYear]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VPlmMensalizadosLastYear]  as  SELECT        dbo.PlmMensalizadosLastYear.Id, dbo.PlmMensalizadosLastYear.MaterialId, dbo.ValorReferencias.EmpresaNome, dbo.PlmMensalizadosLastYear.CentroLogisticoCodSap, dbo.ValorReferencias.MaterialCodSap, 					                         dbo.ValorReferencias.MaterialDescricao, dbo.ValorReferencias.MaterialClasse, dbo.ValorReferencias.MaterialUM, dbo.ValorReferencias.ClassificacaoNome, dbo.ValorReferencias.UserName, 						                         dbo.ValorReferencias.MGCodeCodigoSap, dbo.ValorReferencias.MGCodeDescricao, dbo.ValorReferencias.FamiliaNome, dbo.PlmMensalizadosLastYear.Sigla, dbo.PlmMensalizadosLastYear.DiretoriaNome, 				                         dbo.PlmMensalizadosLastYear.SubDiretoriaNome, dbo.PlmMensalizadosLastYear.PlmProjeto, dbo.PlmMensalizadosLastYear.PlmInfoAdicional, dbo.PlmMensalizadosLastYear.PlmResponsavel, 							                         dbo.PlmMensalizadosLastYear.PlmDataLanc, dbo.ValorReferencias.ValorDeReferencia, dbo.PlmMensalizadosLastYear.Mes1LastYear AS Mes1, dbo.PlmMensalizadosLastYear.Mes2LastYear AS Mes2, 						                         dbo.PlmMensalizadosLastYear.Mes3LastYear AS Mes3, dbo.PlmMensalizadosLastYear.Mes4LastYear AS Mes4, dbo.PlmMensalizadosLastYear.Mes5LastYear AS Mes5, 														                         dbo.PlmMensalizadosLastYear.Mes6LastYear AS Mes6, dbo.PlmMensalizadosLastYear.Mes7LastYear AS Mes7, dbo.PlmMensalizadosLastYear.Mes8LastYear AS Mes8, 														                         dbo.PlmMensalizadosLastYear.Mes9LastYear AS Mes9, dbo.PlmMensalizadosLastYear.Mes10LastYear AS Mes10, dbo.PlmMensalizadosLastYear.Mes11LastYear AS Mes11, 													                         dbo.PlmMensalizadosLastYear.Mes12LastYear AS Mes12, dbo.PlmMensalizadosLastYear.TotLastYear AS Total, dbo.PlmMensalizadosLastYear.TotLastYear * dbo.ValorReferencias.ValorDeReferencia AS TotalEmReal, 	                         dbo.PlmMensalizadosLastYear.MedLastYear AS Media, dbo.PlmMensalizadosLastYear.MedLastYear * dbo.ValorReferencias.ValorDeReferencia AS MediaEmReal, dbo.ValorReferencias.MaterialBloqueado, 				                         dbo.ValorReferencias.MaterialSubstituto																																									FROM            dbo.PlmMensalizadosLastYear INNER JOIN																																												                         dbo.ValorReferencias ON dbo.PlmMensalizadosLastYear.MaterialId = dbo.ValorReferencias.MaterialID																											
GO
/****** Object:  View [dbo].[VContratos]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VContratos] as  SELECT        NEWID() AS Id, MaterialID, EmpresaNome, ContratoNumero, ItemDoContratoItm, MaterialCodSap, MaterialDescricao, FamiliaNome, UserName, ContratoDataDoc, ContratoIniPrazo, ContratoFimValidade,
VigenciaMenorQue6Meses, CentroLogisticoCodSap, ItemDoContratoQtdeContrato, ItemDoContratoQtdeDisp, PercentualConsumidoMaterial,
CASE WHEN PercentualConsumidoMaterial > 0.75 THEN 'Sim' ELSE 'Não' END AS MaisDe75PercentDoItemConsumido, BaseCotacaoSigla, BaseCotacaoValor, ContratoValFixado, ContratoValGlPend, ContratoValGlPendEmReal,
PercentualConsumidoContrato, CASE WHEN PercentualConsumidoContrato > 0.75 THEN 'Sim' ELSE 'Não' END AS MaisDe75PercentDoContratoConsumido, FornecedorNome, ValorDeReferencia, ContratoDataAlteracao, 																												                         CASE WHEN ItemDoContratoElim IS NULL OR																																																																			                         ItemDoContratoElim = '' THEN 'Liberado' ELSE CASE WHEN ItemDoContratoElim = 'S' THEN 'Bloqueado' ELSE 'Em verificação' END END AS StatusDoContrato,																																														 MaterialSubstituto, MaterialBloqueado																																																																																																																																																							FROM																																																																																		(SELECT   N1.MaterialSubstituto, N1.MaterialBloqueado,     N1.EmpresaNome, N1.ContratoNumero, 																																																												N1.ItemDoContratoItm, N1.MaterialID, N1.MaterialCodSap, N1.MaterialDescricao, 																																																																N1.FamiliaNome, N1.UserName, N1.ContratoDataDoc, N1.ContratoTipo, N1.ContratoIniPrazo, 																																																														N1.ContratoFimValidade, CASE WHEN ContratoFimValidade <= DATEADD(month, 6, CAST(GETDATE() AS DATE)) THEN 'Sim' ELSE 'Não' END AS VigenciaMenorQue6Meses, N1.ContratoGCm AS GCm, 																																							                                                    ISNULL(dbo.CentrosLogisticos.CentroLogisticoCodSap, '') AS CentroLogisticoCodSap, N1.ItemDoContratoQtdeContrato, N1.ItemDoContratoQtdeDisp, 																																				                                                    CASE WHEN N1.ItemDoContratoQtdeContrato <= 0 THEN 1 WHEN N1.ItemDoContratoQtdeDisp <= 0 THEN 1 ELSE 1 - N1.ItemDoContratoQtdeDisp / N1.ItemDoContratoQtdeContrato END AS PercentualConsumidoMaterial,																					                                                     N1.BaseCotacaoSigla, N1.BaseCotacaoValor, N1.ContratoValFixado, N1.ContratoValGlPend, N1.ContratoValGlPendEmReal, 																																										                                                    CASE WHEN N1.contratoValFixado <= 0 THEN 1 WHEN N1.contratoValGlPend <= 0 THEN 1 ELSE 1 - (N1.contratoValGlPend / N1.contratoValFixado) END AS PercentualConsumidoContrato, N1.FornecedorNome, 																							                                                    N1.ValorDeReferencia, N1.ContratoDataAlteracao, N1.ItemDoContratoElim																																																					 FROM																																																																																		 (SELECT   dbo.ValorReferencias.MaterialSubstituto, dbo.ValorReferencias.MaterialBloqueado,dbo.ValorReferencias.EmpresaNome, Contrato_1.ContratoNumero, dbo.ItemDoContratos.ItemDoContratoItm, dbo.ValorReferencias.MaterialID, dbo.ValorReferencias.MaterialCodSap, Contrato_1.ContratoDataDoc, 											 Contrato_1.ContratoTipo, Contrato_1.ContratoIniPrazo, Contrato_1.ContratoFimValidade, Contrato_1.ContratoGCm, dbo.ValorReferencias.MaterialDescricao, dbo.ValorReferencias.FamiliaNome, dbo.ValorReferencias.UserId, 																														 dbo.ValorReferencias.UserName, dbo.ItemDoContratos.CentroLogisticoID, dbo.ItemDoContratos.ItemDoContratoQtdeContrato, dbo.ItemDoContratos.ItemDoContratoQtdeDisp, 																																											 dbo.BaseCotacoes.BaseCotacaoSigla, dbo.BaseCotacoes.BaseCotacaoValor, ISNULL(dbo.BaseCotacoes.BaseCotacaoDataDaCotacao, CAST(GETDATE() AS DATE)) AS bcDataCotacao, 																																										 Contrato_1.ContratoValFixado, Contrato_1.ContratoValGlPend, Contrato_1.ContratoValGlPend * dbo.BaseCotacoes.BaseCotacaoValor AS ContratoValGlPendEmReal, dbo.Fornecedores.FornecedorNome,																																					 (SELECT        MAX(ContratoDataAlteracao) AS Expr1																																																																							 FROM            dbo.Contratos) AS ContratoDataAlteracao, dbo.ItemDoContratos.ItemDoContratoValRef / dbo.BaseCotacoes.BaseCotacaoValor AS ValorDeReferencia, 																																												 dbo.ItemDoContratos.ItemDoContratoElim																																																																										 FROM            dbo.Contratos AS Contrato_1 INNER JOIN																																																																						 dbo.ItemDoContratos ON Contrato_1.ContratoID = dbo.ItemDoContratos.ContratoID INNER JOIN																																																													 dbo.ValorReferencias ON dbo.ItemDoContratos.MaterialID = dbo.ValorReferencias.MaterialID INNER JOIN																																																										 dbo.Fornecedores ON Contrato_1.FornecedorID = dbo.Fornecedores.FornecedorID INNER JOIN																																																														 dbo.BaseCotacoes ON Contrato_1.BaseCotacaoID = dbo.BaseCotacoes.BaseCotacaoID																																																																 WHERE        (Contrato_1.ContratoFimValidade >= CAST(GETDATE() AS DATE))) AS N1 LEFT OUTER JOIN																																																											 dbo.CentrosLogisticos ON N1.CentroLogisticoID = dbo.CentrosLogisticos.CentroLogisticoID) AS N2																																																												
GO
/****** Object:  View [dbo].[nValorReferencias]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[nValorReferencias] as
SELECT        Id, EmpresaID, MaterialID, FamiliaID, MGCodeID, EmpresaNome, MaterialCodSap, MaterialDescricao, MaterialUM, MaterialClasse, ClassificacaoNome, FamiliaNome, MGCodeCodigoSap, MGCodeDescricao, UserName, 
                         ValorDeReferencia, Origem
FROM            
(SELECT
NEWID() AS Id, 
dbo.VMaterial.EmpresaID, 
dbo.VMaterial.MaterialID, 
dbo.VMaterial.FamiliaID, 
dbo.VMaterial.MGCodeID, 
dbo.VMaterial.EmpresaNome, 
dbo.VMaterial.MaterialCodSap, 
dbo.VMaterial.MaterialDescricao, 
dbo.VMaterial.MaterialUM, 
dbo.VMaterial.MaterialClasse, 
dbo.VMaterial.ClassificacaoNome, 
dbo.VMaterial.FamiliaNome, 
dbo.VMaterial.MGCodeCodigoSap, 
dbo.VMaterial.MGCodeDescricao, 
dbo.VMaterial.UserName, 
ISNULL(Preco.ValRef, 0) AS ValorDeReferencia, 
CASE WHEN Origem IS NULL THEN 'Sem informação' 
WHEN Origem = 'HTC' THEN 'Histórico de Compras' 
ELSE origem END AS Origem
FROM
(SELECT        
ISNULL(MatOperacao,MatEstCompMM.Material) AS Material, 
ISNULL(MatEstCompMM.ValRef,ValRefOpercao) AS ValRef, 
ISNULL(OpLogis.Origem,MatEstCompMM.Origem) AS Origem
FROM
(SELECT        ISNULL(EstqComp.Material, mmm60.MaterialID) AS Material, ISNULL(EstqComp.ValRef, mmm60.Mm60Valor) AS ValRef, ISNULL(EstqComp.Origem, mmm60.origem) AS Origem
                                                                              FROM            (SELECT        ISNULL(FromEstoque.MatEstoque, Comp.MatComp) AS Material, ISNULL(FromEstoque.ValRefEstoque, Comp.valRefComp) AS ValRef, ISNULL(FromEstoque.Origem, Comp.Origem) 
                                                                                                                                  AS Origem
                                                                                                        FROM            (SELECT DISTINCT 
                                                                                                                                                            dbo.ItemPedidoDeCompras.MaterialID AS MatComp, MAX(dbo.ItemPedidoDeCompras.ItemPedidoDeCompraValorReferencia * dbo.BaseCotacoes.BaseCotacaoValor) 
                                                                                                                                                            AS valRefComp, 'HTC' AS Origem
                                                                                                                                  FROM            dbo.ItemPedidoDeCompras INNER JOIN
                                                                                                                                                            dbo.PedidoDeCompras ON dbo.ItemPedidoDeCompras.PedidoDeCompraId = dbo.PedidoDeCompras.PedidoDeCompraId INNER JOIN
                                                                                                                                                            dbo.BaseCotacoes ON dbo.PedidoDeCompras.BaseCotacaoID = dbo.BaseCotacoes.BaseCotacaoID INNER JOIN
                                                                                                                                                                (SELECT        dbo.ItemPedidoDeCompras.MaterialID AS MatComp, MAX(dbo.PedidoDeCompras.DataCriacao) AS dtCriacao
                                                                                                                                                                  FROM            dbo.ItemPedidoDeCompras INNER JOIN
                                                                                                                                                                                            dbo.PedidoDeCompras ON dbo.ItemPedidoDeCompras.PedidoDeCompraId = dbo.PedidoDeCompras.PedidoDeCompraId
                                                                                                                                                                  GROUP BY dbo.ItemPedidoDeCompras.MaterialID) AS z ON dbo.ItemPedidoDeCompras.MaterialID = z.MatComp AND 
                                                                                                                                                            dbo.PedidoDeCompras.DataCriacao = z.dtCriacao
                                                                                                                                  GROUP BY dbo.ItemPedidoDeCompras.MaterialID) AS Comp FULL OUTER JOIN
                                                                                                                                      (SELECT        MatEstoque, ValRefEstoque, Origem
                                                                                                                                        FROM            (SELECT        MaterialID AS MatEstoque, SUM(FisicoValor) / SUM(FisicoQtde) AS ValRefEstoque, 'Estoque Atual' AS Origem
                                                                                                                                                                  FROM            dbo.EstoqueConsumoAtuais
                                                                                                                                                                  WHERE        (FisicoQtde > 0)
                                                                                                                                                                  GROUP BY MaterialID) AS z
                                                                                                                                        WHERE        (ValRefEstoque > 0.01)) AS FromEstoque ON FromEstoque.MatEstoque = Comp.MatComp) AS EstqComp FULL OUTER JOIN
                                                                                                            (SELECT        MaterialID, Mm60Valor, 'Extrato MM60' AS origem
                                                                                                              FROM            dbo.Mm60s
                                                                                                              WHERE        (Mm60Equivalente =
                                                                                                                                            (SELECT        MAX(Mm60Equivalente) AS Expr1
                                                                                                                                              FROM            dbo.Mm60s))) AS mmm60 ON EstqComp.Material = mmm60.MaterialID) AS MatEstCompMM FULL OUTER JOIN
                                                                                  (SELECT        MaterialID AS MatOperacao, PrecoValor AS ValRefOpercao, 'Gestão Logística' AS Origem
                                                                                    FROM            (SELECT        MaterialID, MAX(PrecoDataLanc) AS MaxPrecoDataLanc, PrecoValor
                                                                                                              FROM            dbo.ReferenciaDePrecos
                                                                                                              GROUP BY MaterialID, PrecoValor) AS z) AS OpLogis ON OpLogis.MatOperacao = MatEstCompMM.Material) AS Preco RIGHT OUTER JOIN
                                                    dbo.VMaterial ON Preco.Material = dbo.VMaterial.MaterialID) AS VR
GO
/****** Object:  View [dbo].[View_Giro]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[View_Giro] as
SELECT        NEWID() AS id, CentroLogisticoID, MaterialID, giroConsQtde, giroConsValor, giroEstqQtde, 
giroEstqValor, giroEquivalente, giroPeriodo, ISNULL(zmovClass, estoqueClass) AS ClassificacaoID
FROM           
(SELECT    
    ISNULL(zmovCodCentro, estoqueCodCentro) AS CentroLogisticoID, ISNULL(zmovCodMat, estoqueCodMat) AS MaterialID, ISNULL(zmovQtde, 0) AS giroConsQtde, 
	ISNULL(zmovValor, 0) AS giroConsValor, ISNULL(estoqueQtde, 0) AS giroEstqQtde, ISNULL(estoqueValor, 0) AS giroEstqValor, 
	ISNULL(ZmovEquivalente, EstoqueEquivalente) AS giroEquivalente, ISNULL(ZmovPeriodo, EstoquePeriodo) AS giroPeriodo, 
    CASE WHEN zmovClass <> estoqueClass THEN 'Verificar' ELSE 'iguais' END AS Verificacao, zmovClass, estoqueClass
    FROM
	(SELECT n1_ZMOV.CentroLogisticoID AS zmovCodCentro, n1_ZMOV.MaterialID AS zmovCodMat, n1_ESTOQUE.CentroLogisticoID AS estoqueCodCentro, 
	n1_ESTOQUE.MaterialID AS estoqueCodMat, SUM(n1_ZMOV.zmovQtde) AS zmovQtde, SUM(n1_ZMOV.zmovValor) AS zmovValor, 
	SUM(n1_ESTOQUE.estoqueQtde) AS estoqueQtde, SUM(n1_ESTOQUE.estoqueValor) AS estoqueValor, 
   n1_ZMOV.ZmovEquivalente, n1_ZMOV.ZmovPeriodo, n1_ZMOV.ClassificacaoID AS zmovClass, n1_ESTOQUE.EstoqueEquivalente, 
   n1_ESTOQUE.EstoquePeriodo,n1_ESTOQUE.ClassificacaoID AS estoqueClass
      FROM
	  (SELECT CentroLogisticoID, MaterialID, SUM(ZmovQtde) AS zmovQtde, SUM(ZmovValor) AS zmovValor, ZmovEquivalente, ZmovPeriodo, ClassificacaoID
       FROM dbo.Zmovs
	   WHERE (ZmovExpurgado IS NULL) AND (OrdemID > 0 OR OrdemID IS NULL)
       GROUP BY CentroLogisticoID, MaterialID, ZmovEquivalente, ZmovPeriodo, ClassificacaoID) 
	   AS n1_ZMOV 
	   FULL OUTER JOIN
      (SELECT        CentroLogisticoID, MaterialID, SUM(estoqueQtde) AS estoqueQtde, SUM(estoqueValor) AS estoqueValor, 
	  EstoqueEquivalente, EstoquePeriodo, ClassificacaoID 
	  FROM
	  (SELECT CentroLogisticoID, MaterialID, SUM(EstoqueQtde) AS estoqueQtde, SUM(EstoqueValor) AS estoqueValor, 
	  EstoquePeriodo, EstoqueEquivalente, ClassificacaoID, EstoqueExpurgado
		FROM            dbo.Estoques
        GROUP BY CentroLogisticoID, MaterialID, EstoquePeriodo, EstoqueEquivalente, ClassificacaoID, EstoqueExpurgado
        UNION
        SELECT
		BaseEstqCodCentro, BaseEstqCodMat, qtde, valor, Periodo, Equivalente, BaseEstqClass, Expurgado
         FROM 
		 (SELECT    BaseEstoque.BaseEstqCodCentro, BaseEstoque.BaseEstqCodMat, 
		 SUM(BaseEstoque.BaseEstqQtde) AS qtde, SUM(BaseEstoque.BaseEstqValor) AS valor, 
		 CONVERT(int, CONVERT(varchar, YEAR(BaseEstoque.BaseEstqDtLanc)) + 
		 CASE WHEN month(BaseEstqDtLanc) < 10 THEN '0' + 
		 CONVERT(varchar,month(BaseEstqDtLanc)) ELSE CONVERT(varchar, month(BaseEstqDtLanc)) END) AS Periodo, 
		 (YEAR(BaseEstoque.BaseEstqDtLanc) - 2013)* 12 + MONTH(BaseEstoque.BaseEstqDtLanc) AS Equivalente, 
		 dbo.Materiais.ClassificacaoID AS BaseEstqClass, 
		 CASE WHEN BaseEstqCodCentro IN (3, 36, 63,86) THEN 'x' END AS Expurgado
        FROM
		(SELECT  CentroLogisticoID AS BaseEstqCodCentro, MaterialID AS BaseEstqCodMat, 
		SUM(Mb52UtLivre + Mb52EmTrans + Mb52EmCQ + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS BaseEstqQtde, 
        SUM(Mb52ValorUtLivre + Mb52ValorEmTrans + Mb52ValorEmCQ + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes) AS BaseEstqValor, Mb52DataLanc AS BaseEstqDtLanc
			FROM            dbo.Mb52s
			WHERE        (Mb52DataLanc = (SELECT  MAX(Mb52DataLanc) AS Expr1
			FROM  dbo.Mb52s))
			GROUP BY CentroLogisticoID, MaterialID, Mb52DataLanc) AS BaseEstoque INNER JOIN dbo.Materiais 
			ON BaseEstoque.BaseEstqCodMat = dbo.Materiais.MaterialID
            GROUP BY BaseEstoque.BaseEstqCodCentro, BaseEstoque.BaseEstqCodMat, BaseEstoque.BaseEstqDtLanc, dbo.Materiais.ClassificacaoID) AS N2_BaseEstoque
            WHERE
			(Equivalente >(SELECT  MAX(EstoqueEquivalente) AS Expr1 FROM  dbo.Estoques))) AS estoqueView
            WHERE  
			(EstoqueExpurgado IS NULL)
            GROUP BY CentroLogisticoID, MaterialID, EstoqueEquivalente, EstoquePeriodo, ClassificacaoID) 
			AS n1_ESTOQUE 
			ON 
			n1_ZMOV.CentroLogisticoID = n1_ESTOQUE.CentroLogisticoID AND 
            n1_ZMOV.MaterialID = n1_ESTOQUE.MaterialID AND 
			n1_ZMOV.ZmovEquivalente = n1_ESTOQUE.EstoqueEquivalente
            GROUP BY n1_ZMOV.CentroLogisticoID, n1_ZMOV.MaterialID, n1_ESTOQUE.CentroLogisticoID, 
			n1_ESTOQUE.MaterialID, n1_ZMOV.ZmovEquivalente, n1_ZMOV.ZmovPeriodo, n1_ZMOV.ClassificacaoID, 
            n1_ESTOQUE.EstoqueEquivalente, n1_ESTOQUE.EstoquePeriodo, n1_ESTOQUE.ClassificacaoID) 
			AS n2_ZMOV_ESTOQUE) 
		AS n3_ZMOV_ESTOQUE
GO
/****** Object:  StoredProcedure [dbo].[Prc_FamiliaTop10]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_FamiliaTop10]
@empresa as bigint

as


--set @empresa = 2003

if @empresa!=0

begin

select top 10
Familia as FamiliaNome,
SapValor/1000000 as SapValor,
ConsumoValor/1000000 as ConsumoValor,
EntradaValor/1000000 as EntradaValor,
SapValor/ (select sum(Convert (money,VEstoqueConsumoAtuais.SapValor))
from VEstoqueConsumoAtuais where VEstoqueConsumoAtuais.EmpresaID = @empresa ) as Percentual
from
(select
VEstoqueConsumoAtuais.FamiliaNome as Familia, 
sum(Convert (money,VEstoqueConsumoAtuais.SapValor)) SapValor,
sum(Convert (money,VEstoqueConsumoAtuais.ConsumoValor)) ConsumoValor,
sum(Convert (money,VEstoqueConsumoAtuais.EntradaValor)) EntradaValor
from 
VEstoqueConsumoAtuais 
where
VEstoqueConsumoAtuais.EmpresaID = @empresa 
group by
VEstoqueConsumoAtuais.FamiliaNome ) as f

order by SapValor desc
end
else

select top 10
Familia as FamiliaNome,
SapValor/1000000 as SapValor,
ConsumoValor/1000000  as ConsumoValor,
EntradaValor/1000000  as EntradaValor,
SapValor/ (select sum(Convert (money,VEstoqueConsumoAtuais.SapValor))from	VEstoqueConsumoAtuais) as Percentual
from
(select
VEstoqueConsumoAtuais.FamiliaNome as Familia, 
sum(Convert (money,vEstoqueConsumoAtuais.SapValor)) SapValor,
sum(Convert (money,vEstoqueConsumoAtuais.ConsumoValor)) ConsumoValor,
sum(Convert (money,VEstoqueConsumoAtuais.EntradaValor)) EntradaValor
from 
VEstoqueConsumoAtuais 
--where
--EstoqueConsumoAtuais.EmpresaID = 2005 
group by
	VEstoqueConsumoAtuais.FamiliaNome ) as f
order by SapValor desc

GO
/****** Object:  StoredProcedure [dbo].[Prc_FamiliaTop15]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_FamiliaTop15]
@empresa as bigint

as


--set @empresa = 2003

if @empresa=2005 or @empresa=2003

begin

select top 15
Familia as FamiliaNome,
SapValor/1000000 as SapValor,
ConsumoValor/1000000 as ConsumoValor,
EntradaValor/1000000 as EntradaValor,
SapValor/ (select sum(Convert (money,VEstoqueConsumoAtuais.SapValor))
from VEstoqueConsumoAtuais where VEstoqueConsumoAtuais.EmpresaID = @empresa ) as Percentual
from
(select
VEstoqueConsumoAtuais.FamiliaNome as Familia, 
sum(Convert (money,VEstoqueConsumoAtuais.SapValor)) SapValor,
sum(Convert (money,VEstoqueConsumoAtuais.ConsumoValor)) ConsumoValor,
sum(Convert (money,VEstoqueConsumoAtuais.EntradaValor)) EntradaValor
from 
VEstoqueConsumoAtuais 
where
VEstoqueConsumoAtuais.EmpresaID = @empresa 
group by
VEstoqueConsumoAtuais.FamiliaNome ) as f

order by SapValor desc
end
else

select top 15
Familia as FamiliaNome,
SapValor/1000000 as SapValor,
ConsumoValor/1000000  as ConsumoValor,
EntradaValor/1000000  as EntradaValor,
SapValor/ (select sum(Convert (money,VEstoqueConsumoAtuais.SapValor))from	VEstoqueConsumoAtuais) as Percentual
from
(select
VEstoqueConsumoAtuais.FamiliaNome as Familia, 
sum(Convert (money,vEstoqueConsumoAtuais.SapValor)) SapValor,
sum(Convert (money,vEstoqueConsumoAtuais.ConsumoValor)) ConsumoValor,
sum(Convert (money,VEstoqueConsumoAtuais.EntradaValor)) EntradaValor
from 
VEstoqueConsumoAtuais 
--where
--EstoqueConsumoAtuais.EmpresaID = 2005 
group by
	VEstoqueConsumoAtuais.FamiliaNome ) as f
order by SapValor desc

GO
/****** Object:  StoredProcedure [dbo].[Prc_MiniImpaq]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_MiniImpaq] as																																																																																		
																																																																																												
declare @tbPlm as table(																																																																																						
MatID int,																																																																																										
M1  money,																																																																																										
M2  money,																																																																																										
M3  money,																																																																																										
M4  money,																																																																																										
M5  money,																																																																																										
M6  money,																																																																																										
M7  money,																																																																																										
M8  money,																																																																																										
M9  money,																																																																																										
M10 money,																																																																																										
M11 money,																																																																																										
M12 money,																																																																																										
Med money,																																																																																										
Tot money																																																																																										
)																																																																																												
																																																																																												
insert into @tbPlm																																																																																								
exec Prc_Plm12Meses	

--delete from dbo.RMiniImpaqs 

--insert into dbo.RMiniImpaqs 
																																																																																						
select																																																																																											
Id,																																																																																											
 Vr.EmpresaID, 																																																																																								
 Vr.MaterialID, 																																																																																								
 Vr.EmpresaNome, 																																																																																								
 Vr.MaterialCodSap, 																																																																																							
 Vr.MaterialDescricao, 																																																																																						
 Vr.MaterialUM, 																																																																																								
 Vr.MaterialClasse, 																																																																																							
 Vr.ClassificacaoNome, 																																																																																						
 Vr.FamiliaNome,																																																																																								
 Vr.MGCodeCodigoSap, 																																																																																							
 Vr.MgCodeDescricao, 																																																																																							
 Vr.UserName,																																																																																									
 AutonomiaAppia,																																																																																								
 AutonomiaCpm12,																																																																																								
 AutonomiaPLM,																																																																																									
 AutonomiaAppiaODC,																																																																																							
 AutonomiaCpm12ODC,																																																																																							
 AutonomiaPLMODC,																																																																																								
 QtdeDeContratos,																																																																																								
 ItemDoContratoQtdeDisp,																																																																																						
 TotalAppiaAnoAtual,																																																																																							
 MediaAppiaAnoAtual,																																																																																							
 Cpm12,																																																																																										
 MediaPLM,																																																																																										
 TotalPLM,																																																																																										
 ZmepAtrasado,																																																																																									
 ZmepFuturo,																																																																																									
 ZmepCorte,																																																																																									
 FisicoQtde,																																																																																									
 FisicoValor,																																																																																									
 ConsumoQtde,																																																																																									
 ConsumoValor,																																																																																									
 EntradaQtde, 																																																																																									
 EntradaValor, 																																																																																								
 DataLanc,																																																																																										
 isnull(ValorDeReferencia,0) ValorDeReferencia	,																																																																																
 convert(bit,vr.MaterialBloqueado)MaterialBloqueado,
 vr.MaterialSubstituto																																																																																	
from																																																																																											
(SELECT        Id = newid(), EmpresaID, MaterialID, EmpresaNome, MaterialCodSap, MaterialDescricao, MaterialUM, MaterialClasse, 																																																												
ClassificacaoNome, FamiliaNome, MGCodeCodigoSap, MgCodeDescricao, UserName, 																																																																									
                         isnull(AutonomiaAppia, 'Não Calculado') AS AutonomiaAppia, isnull(AutonomiaCpm12, 'Não Calculado') AS AutonomiaCpm12, 																																																								
						 isnull(AutonomiaPLM, 'Não Calculado') AS AutonomiaPLM, isnull(AutonomiaAppiaODC, 'Não Calculado') 																																																														
                         AS AutonomiaAppiaODC, isnull(AutonomiaCpm12ODC, 'Não Calculado') AS AutonomiaCpm12ODC, 																																																																
						 isnull(AutonomiaPLMODC, 'Não Calculado') AS AutonomiaPLMODC, isnull(QtdeCtr, 0) AS QtdeDeContratos, 																																																													
                         isnull(ItemDoContratoQtdeDisp, 0) AS ItemDoContratoQtdeDisp, isnull(TAp, 0) AS TotalAppiaAnoAtual, 																																																													
						 isnull(MAp, 0) AS MediaAppiaAnoAtual, isnull(Cpm12, 0) AS Cpm12, isnull(MediaTot, 0) AS MediaPLM, isnull(TotalTot, 0) 																																																									
                         AS TotalPLM, isnull(A, 0) AS ZmepAtrasado, isnull(F, 0) AS ZmepFuturo, ISNULL(ZmepQtdeCrit, 0) AS ZmepCorte, 																																																											
						 isnull(F_Qtde, 0) AS FisicoQtde, isnull(F_Valor, 0) AS FisicoValor, 																																																																					
						 isnull(ConsumoQtde, 0) AS ConsumoQtde, 																																																																												
                         isnull(ConsumoValor, 0) AS ConsumoValor, 																																																																												
						 isnull(EntradaQtde, 0) AS  EntradaQtde, 																																																																												
                         isnull(EntradaValor, 0) AS EntradaValor, 																																																																												
						 																																																																																						
						 DataLanc =																																																																																				
                             (SELECT        max(DataLanc)																																																																														
                               FROM            EstoqueConsumoAtuais)																																																																											
FROM            (SELECT        CodMat, QtdeCtr, ItemDoContratoQtdeDisp, A, F, ZmepQtdeCrit, AutonomiaAppia, AutonomiaCpm12, AutonomiaPLM, 																																																										
CASE WHEN MAp > 0 THEN CONVERT(varchar, (F_Qtde + isnull(ZmepQtdeCrit, 0)) / MAp) ELSE 'Não Calculado' END AutonomiaAppiaODC, 																																																													
CASE WHEN Cpm12 > 0 THEN CONVERT(varchar, (F_Qtde + isnull(ZmepQtdeCrit, 0)) / Cpm12) ELSE 'Não Calculado' END AutonomiaCpm12ODC, 																																																												
CASE WHEN MediaTot > 0 THEN CONVERT(varchar, (F_Qtde + isnull(ZmepQtdeCrit, 0)) / MediaTot) ELSE 'Não Calculado' END AutonomiaPLMODC, 																																																											
Cpm12, MAp, TAp, MediaTot, TotaLTot, F_Qtde, F_Valor, 																																																																															
ConsumoQtde, ConsumoValor, EntradaQtde, EntradaValor																																																																															
FROM            (SELECT        CodMat, QtdeCtr, ItemDoContratoQtdeDisp, A, F, 																																																																									
CASE WHEN MAp > 0 THEN CONVERT(varchar, F_Qtde / MAp) ELSE 'Não Calculado' END AutonomiaAppia, 																																																																				
CASE WHEN Cpm12 > 0 THEN CONVERT(varchar,F_Qtde / Cpm12) ELSE 'Não Calculado' END AutonomiaCpm12, 																																																																				
CASE WHEN MediaTot > 0 THEN CONVERT(varchar, F_Qtde / MediaTot) ELSE 'Não Calculado' END AutonomiaPLM, Cpm12, MAp, TAp, 																																																														
MediaTot, TotaLTot, F_Qtde, F_Valor, ConsumoQtde, ConsumoValor, EntradaQtde, EntradaValor																																																																						
FROM            (SELECT        isnull(CodMat, MaterialID) AS CodMat, QtdeCtr, ItemDoContratoQtdeDisp, A, F, 																																																																	
MAp, TAp, MediaTot, TotaLTot, F_Qtde, F_Valor, ConsumoQtde, ConsumoValor, EntradaQtde, EntradaValor																																																																			
FROM            (SELECT        isnull(CodMat, MaterialID) AS CodMat, A, F, MAp, TAp, 																																																																							
MediaTot, TotaLTot, F_Qtde, F_Valor, ConsumoQtde, ConsumoValor, EntradaQtde, EntradaValor																																																																						
FROM            (SELECT        isnull(CodMat, MaterialID) AS CodMat, A, F, MediaTot, TotaLTot, F_Qtde, F_Valor, ConsumoQtde, ConsumoValor, EntradaQtde, EntradaValor																																																			
FROM            (SELECT        isnull(EstCpm.MaterialID, plm.MaterialId) AS CodMat, MediaTot, TotaLTot, F_Qtde, F_Valor, ConsumoQtde, ConsumoValor, EntradaQtde, EntradaValor																																																	
FROM            (SELECT        MaterialID, SUM(FisicoQtde) F_Qtde, SUM(FisicoValor) F_Valor, SUM(ConsumoQtde) ConsumoQtde, SUM(ConsumoValor) ConsumoValor, SUM(EntradaQtde) EntradaQtde, SUM(EntradaValor) EntradaValor																																						
FROM            EstoqueConsumoAtuais																																																																																			
GROUP BY MaterialId) AS EstCpm FULL OUTER JOIN																																																																																	
(SELECT        MatID as MaterialId, sum(Med) MediaTot, sum(Tot) TotaLTot																																																																										
FROM            @tbPlm																																																																																							
GROUP BY MatID) AS Plm ON plm.MaterialId = EstCpm.MaterialID) AS EstPLM FULL JOIN																																																																								
(SELECT        MaterialID, isnull([A], 0) AS A, isnull([F], 0) AS F																																																																											
FROM            (SELECT        MaterialID, CASE WHEN ZmepDataEntrg < CAST(GETDATE() AS date) THEN 'A' ELSE 'F' END AS Statuss, 																																																												
sum(ZmepQtdeEmPend) AS qtde																																																																																					
FROM            Zmeps																																																																																							
WHERE        ZmepCentroImputado != 'x'																																																																																			
GROUP BY MaterialID, CASE WHEN ZmepDataEntrg < CAST(GETDATE() AS date) THEN 'A' ELSE 'F' END) AS zm PIVOT (sum(qtde) FOR Statuss IN ([A], 																																																										
[F])) AS P) AS Zmp ON CodMat = MaterialID) AS EstZm FULL OUTER JOIN																																																																											
(SELECT        MaterialID, sum(TotCurrYear) AS TAp, sum(MedCurrYear) AS MAp																																																																									
  FROM            AppiaQuerys																																																																																					
GROUP BY MaterialID) AS appiah ON CodMat = MaterialID) AS EstAp LEFT JOIN																																																																										
(SELECT        qtdC.MaterialID, QtdeCtr, ItemDoContratoQtdeDisp																																																																												
FROM            (SELECT        MaterialID, sum(QtdeCtr) AS QtdeCtr																																																																												
FROM            (SELECT        MaterialID, count(*) AS QtdeCtr																																																																													
FROM            (SELECT DISTINCT MaterialID, ContratoID																																																																														
FROM            ItemDoContratos																																																																																				
/* foi Adicionado esta linha para trazer apenas os contratos liberados*/																																																																										
 WHERE ItemDoContratoElim IS NULL OR																																																																																			
ItemDoContratoElim = '') AS ctr																																																																																				
GROUP BY ctr.MaterialID, ContratoID) AS c																																																																																		
GROUP BY MaterialID) AS qtdC,																																																																																					
(SELECT        MaterialID, sum(ItemDoContratoQtdeDisp) ItemDoContratoQtdeDisp																																																																									
  FROM            ItemDoContratos																																																																																				
  WHERE        ItemDoContratoElim IS NULL OR																																																																																	
                            ItemDoContratoElim = ''																																																																															
  GROUP BY MaterialID) qtdeDis																																																																																					
WHERE        qtdC.MaterialID = qtdeDis.MaterialID) AS ct ON CodMat = MaterialID) AS est LEFT OUTER JOIN																																																																		
CpmMaterialReports ON CodMat = CpmMaterialReports.MaterialID) AS EstCt LEFT JOIN																																																																								
(SELECT        MaterialID, sum(ZmepQtdeEmPend) AS ZmepQtdeCrit																																																																													
FROM            Zmeps																																																																																							
WHERE        ZmepDataEntrg >= DATEADD(m, - 6, GETDATE()) AND ZmepCentroImputado != 'x'																																																																							
GROUP BY MaterialID) AS ZmepCriterio ON CodMat = MaterialID) AS EstZmeCrit, vMaterial																																																																							
WHERE        CodMat = MaterialID) as v left join (select * from ValorReferencias) as vr																																																																						
on																																																																																												
v.MaterialID = vr.MaterialID	
GO
/****** Object:  StoredProcedure [dbo].[Prc_Plm12Meses]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_Plm12Meses] as

declare @M1 as varchar(20)
declare @M2 as varchar(20)
declare @M3 as varchar(20)
declare @M4 as varchar(20)
declare @M5 as varchar(20)
declare @M6 as varchar(20)
declare @M7 as varchar(20)
declare @M8 as varchar(20)
declare @M9 as varchar(20)
declare @M10 as varchar(20)
declare @M11 as varchar(20)
declare @M12 as varchar(20)

declare @mes as int

set @mes = month(getdate())


 

if( @mes = 1 )
begin
set @M1  = 'Mes1CurrYear'
set @M2  = 'Mes2CurrYear'
set @M3  = 'Mes3CurrYear'
set @M4  = 'Mes4CurrYear'
set @M5  = 'Mes5CurrYear'
set @M6  = 'Mes6CurrYear'
set @M7  = 'Mes7CurrYear'
set @M8  = 'Mes8CurrYear'
set @M9  = 'Mes9CurrYear'
set @M10 = 'Mes10CurrYear'
set @M11 = 'Mes11CurrYear'
set @M12 = 'Mes12CurrYear'
end

if( @mes = 2 )
begin
set @M1  = 'Mes2CurrYear'
set @M2  = 'Mes3CurrYear'
set @M3  = 'Mes4CurrYear'
set @M4  = 'Mes5CurrYear'
set @M5  = 'Mes6CurrYear'
set @M6  = 'Mes7CurrYear'
set @M7  = 'Mes8CurrYear'
set @M8  = 'Mes9CurrYear'
set @M9  = 'Mes10CurrYear'
set @M10 = 'Mes11CurrYear'
set @M11 = 'Mes12CurrYear'
set @M12 = 'Mes1AfterYear'
end

if( @mes = 3 )
begin
set @M1  = 'Mes3CurrYear'
set @M2  = 'Mes4CurrYear'
set @M3  = 'Mes5CurrYear'
set @M4  = 'Mes6CurrYear'
set @M5  = 'Mes7CurrYear'
set @M6  = 'Mes8CurrYear'
set @M7  = 'Mes9CurrYear'
set @M8  = 'Mes10CurrYear'
set @M9  = 'Mes11CurrYear'
set @M10 = 'Mes12CurrYear'
set @M11 = 'Mes1AfterYear'
set @M12 = 'Mes2AfterYear'
end

if( @mes = 4 )
begin
set @M1  = 'Mes4CurrYear'
set @M2  = 'Mes5CurrYear'
set @M3  = 'Mes6CurrYear'
set @M4  = 'Mes7CurrYear'
set @M5  = 'Mes8CurrYear'
set @M6  = 'Mes9CurrYear'
set @M7  = 'Mes10CurrYear'
set @M8  = 'Mes11CurrYear'
set @M9  = 'Mes12CurrYear'
set @M10 = 'Mes1AfterYear'
set @M11 = 'Mes2AfterYear'
set @M12 = 'Mes3AfterYear'
end

if( @mes = 5 )
begin
set @M1  = 'Mes5CurrYear'
set @M2  = 'Mes6CurrYear'
set @M3  = 'Mes7CurrYear'
set @M4  = 'Mes8CurrYear'
set @M5  = 'Mes9CurrYear'
set @M6  = 'Mes10CurrYear'
set @M7  = 'Mes11CurrYear'
set @M8  = 'Mes12CurrYear'
set @M9  = 'Mes1AfterYear'
set @M10 = 'Mes2AfterYear'
set @M11 = 'Mes3AfterYear'
set @M12 = 'Mes4AfterYear'
end

if( @mes = 6 )
begin
set @M1  = 'Mes6CurrYear'
set @M2  = 'Mes7CurrYear'
set @M3  = 'Mes8CurrYear'
set @M4  = 'Mes9CurrYear'
set @M5  = 'Mes10CurrYear'
set @M6  = 'Mes11CurrYear'
set @M7  = 'Mes12CurrYear'
set @M8  = 'Mes1AfterYear'
set @M9  = 'Mes2AfterYear'
set @M10 = 'Mes3AfterYear'
set @M11 = 'Mes4AfterYear'
set @M12 = 'Mes5AfterYear'
end

if( @mes = 7 )
begin
set @M1  = 'Mes7CurrYear'
set @M2  = 'Mes8CurrYear'
set @M3  = 'Mes9CurrYear'
set @M4  = 'Mes10CurrYear'
set @M5  = 'Mes11CurrYear'
set @M6  = 'Mes12CurrYear'
set @M7  = 'Mes1AfterYear'
set @M8  = 'Mes2AfterYear'
set @M9  = 'Mes3AfterYear'
set @M10 = 'Mes4AfterYear'
set @M11 = 'Mes5AfterYear'
set @M12 = 'Mes6AfterYear'
end

if( @mes = 8 )
begin
set @M1  = 'Mes8CurrYear'
set @M2  = 'Mes9CurrYear'
set @M3  = 'Mes10CurrYear'
set @M4  = 'Mes11CurrYear'
set @M5  = 'Mes12CurrYear'
set @M6  = 'Mes1AfterYear'
set @M7  = 'Mes2AfterYear'
set @M8  = 'Mes3AfterYear'
set @M9  = 'Mes4AfterYear'
set @M10 = 'Mes5AfterYear'
set @M11 = 'Mes6AfterYear'
set @M12 = 'Mes7AfterYear'
end

if( @mes = 9 )
begin
set @M1  = 'Mes9CurrYear'
set @M2  = 'Mes10CurrYear'
set @M3  = 'Mes11CurrYear'
set @M4  = 'Mes12CurrYear'
set @M5  = 'Mes1AfterYear'
set @M6  = 'Mes2AfterYear'
set @M7  = 'Mes3AfterYear'
set @M8  = 'Mes4AfterYear'
set @M9  = 'Mes5AfterYear'
set @M10 = 'Mes6AfterYear'
set @M11 = 'Mes7AfterYear'
set @M12 = 'Mes8AfterYear'
end

if( @mes = 10 )
begin
set @M1  = 'Mes10CurrYear'
set @M2  = 'Mes11CurrYear'
set @M3  = 'Mes12CurrYear'
set @M4  = 'Mes1AfterYear'
set @M5  = 'Mes2AfterYear'
set @M6  = 'Mes3AfterYear'
set @M7  = 'Mes4AfterYear'
set @M8  = 'Mes5AfterYear'
set @M9  = 'Mes6AfterYear'
set @M10 = 'Mes7AfterYear'
set @M11 = 'Mes8AfterYear'
set @M12 = 'Mes9AfterYear'
end

if( @mes = 11 )
begin
set @M1  = 'Mes11CurrYear'
set @M2  = 'Mes12CurrYear'
set @M3  = 'Mes1AfterYear'
set @M4  = 'Mes2AfterYear'
set @M5  = 'Mes3AfterYear'
set @M6  = 'Mes4AfterYear'
set @M7  = 'Mes5AfterYear'
set @M8  = 'Mes6AfterYear'
set @M9  = 'Mes7AfterYear'
set @M10 = 'Mes8AfterYear'
set @M11 = 'Mes9AfterYear'
set @M12 = 'Mes10AfterYear'
end

if( @mes = 12 )
begin
set @M1  = 'Mes12CurrYear'
set @M2  = 'Mes1AfterYear'
set @M3  = 'Mes2AfterYear'
set @M4  = 'Mes3AfterYear'
set @M5  = 'Mes4AfterYear'
set @M6  = 'Mes5AfterYear'
set @M7  = 'Mes6AfterYear'
set @M8  = 'Mes7AfterYear'
set @M9  = 'Mes8AfterYear'
set @M10 = 'Mes9AfterYear'
set @M11 = 'Mes10AfterYear'
set @M12 = 'Mes11AfterYear'
end

declare @query nvarchar(max)

set @query = '
select MaterialId as MatID,
convert(money,sum('+@M1 +')) as M1 ,
convert(money,sum('+@M2 +'))as  M2 ,
convert(money,sum('+@M3 +')) as M3 ,
convert(money,sum('+@M4 +')) as M4 ,
convert(money,sum('+@M5 +')) as M5 ,
convert(money,sum('+@M6 +')) as M6 ,
convert(money,sum('+@M7 +')) as M7 ,
convert(money,sum('+@M8 +')) as M8 ,
convert(money,sum('+@M9 +')) as M9 ,
convert(money,sum('+@M10+')) as M10,
convert(money,sum('+@M11+')) as M11,
convert(money,sum('+@M12+')) as M12,

(convert(money,sum('+@M1 +')) +
convert(money,sum('+@M2 +'))  +
convert(money,sum('+@M3 +'))  +
convert(money,sum('+@M4 +'))  +
convert(money,sum('+@M5 +'))  +
convert(money,sum('+@M6 +'))  +
convert(money,sum('+@M7 +'))  +
convert(money,sum('+@M8 +'))  +
convert(money,sum('+@M9 +'))  +
convert(money,sum('+@M10+'))  +
convert(money,sum('+@M11+'))  +
convert(money,sum('+@M12+')))/12 as Med ,

(convert(money,sum('+@M1 +')) +
convert(money,sum('+@M2 +'))  +
convert(money,sum('+@M3 +'))  +
convert(money,sum('+@M4 +'))  +
convert(money,sum('+@M5 +'))  +
convert(money,sum('+@M6 +'))  +
convert(money,sum('+@M7 +'))  +
convert(money,sum('+@M8 +'))  +
convert(money,sum('+@M9 +'))  +
convert(money,sum('+@M10+'))  +
convert(money,sum('+@M11+'))  +
convert(money,sum('+@M12+'))) as Tot 


 from PlmMensalizados
 group by MaterialId
 '

 exec (@query)
GO
/****** Object:  StoredProcedure [dbo].[prc_PlmMensalizado]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[prc_PlmMensalizado] as



declare @M1		as nvarchar(10)
declare @M2		as nvarchar(10)
declare @M3		as nvarchar(10)
declare @M4		as nvarchar(10)
declare @M5		as nvarchar(10)
declare @M6		as nvarchar(10)
declare @M7		as nvarchar(10)
declare @M8		as nvarchar(10)
declare @M9		as nvarchar(10)
declare @M10	as nvarchar(10)
declare @M11	as nvarchar(10)
declare @M12	as nvarchar(10) 
declare @M13		as nvarchar(10)
declare @M14		as nvarchar(10)
declare @M15		as nvarchar(10)
declare @M16		as nvarchar(10)
declare @M17		as nvarchar(10)
declare @M18		as nvarchar(10)
declare @M19		as nvarchar(10)
declare @M20	as nvarchar(10)
declare @M21	as nvarchar(10)
declare @M22	as nvarchar(10) 
declare @M23	as nvarchar(10) 
declare @M24	as nvarchar(10) 



declare @equivalente as int
declare @maxEqui as int

declare @ano as int
declare @cols as nvarchar(max) 
declare @query as nvarchar(max) 
declare @DataLanc as date
set @ano= (select year(getdate()))
set @DataLanc = (select  max(PlmDataLanc)from HistoricoPlms)

set @equivalente = (((@ano) -2013) *12)+1
set @maxEqui =  @equivalente+24


delete from Plms WHERE SUbDiretoriaID  IN(6,4)

while @equivalente < @maxEqui
begin
insert into Plms
select *
FROM HistoricoPlms
where
[PlmEquivalente] = @equivalente and
[PlmDataLanc] = (select max([PlmDataLanc]) from HistoricoPlms where [PlmEquivalente] = @equivalente )

set @equivalente = @equivalente +1
end

set @M1	 ='['+	convert(varchar,@ano) +'01]'
set @M2	 ='['+	convert(varchar,@ano) +'02]'
set @M3	 ='['+	convert(varchar,@ano) +'03]'
set @M4	 ='['+	convert(varchar,@ano) +'04]'
set @M5	 ='['+	convert(varchar,@ano) +'05]'
set @M6	 ='['+	convert(varchar,@ano) +'06]'
set @M7	 ='['+	convert(varchar,@ano) +'07]'
set @M8	 ='['+	convert(varchar,@ano) +'08]'
set @M9	 ='['+	convert(varchar,@ano) +'09]'
set @M10 ='['+	convert(varchar,@ano) +'10]'
set @M11 ='['+	convert(varchar,@ano) +'11]'
set @M12 ='['+	convert(varchar,@ano) +'12]'
set @M13 ='['+	convert(varchar,@ano + 1 ) +'01]'
set @M14 ='['+	convert(varchar,@ano + 1 ) +'02]'
set @M15 ='['+	convert(varchar,@ano + 1 ) +'03]'
set @M16 ='['+	convert(varchar,@ano + 1 ) +'04]'
set @M17 ='['+	convert(varchar,@ano + 1 ) +'05]'
set @M18 ='['+	convert(varchar,@ano + 1 ) +'06]'
set @M19 ='['+	convert(varchar,@ano + 1 ) +'07]'
set @M20 ='['+	convert(varchar,@ano + 1 ) +'08]'
set @M21 ='['+	convert(varchar,@ano + 1 ) +'09]'
set @M22 ='['+	convert(varchar,@ano + 1 ) +'10]'
set @M23 ='['+	convert(varchar,@ano + 1 ) +'11]'
set @M24 ='['+	convert(varchar,@ano + 1 ) +'12]'











set @cols = 

@M1	+','+
@M2	+','+
@M3	+','+
@M4	+','+
@M5	+','+
@M6	+','+
@M7	+','+
@M8	+','+
@M9	+','+
@M10+','+
@M11+','+
@M12+','+
@M13+','+
@M14+','+
@M15+','+
@M16+','+
@M17+','+
@M18+','+
@M19+','+
@M20+','+
@M21+','+
@M22+','+
@M23+','+
@M24

delete from PlmMensalizados

 set @query= 'insert into PlmMensalizados
 select 
newid(),
matId,
CtCdSap, 
Sigla,
dirNom,
subNom, 
proj, 
infAd, 
respo, 
null as datalan,
isnull(	'+@M1  +',	0)	as M1C,
isnull(	'+@M2  +',	0)	as M2C,
isnull(	'+@M3  +',	0)	as M3C,
isnull(	'+@M4  +',	0)	as M4C,
isnull(	'+@M5  +',	0)	as M5C,
isnull(	'+@M6  +',	0)	as M6C,
isnull(	'+@M7  +',	0)	as M7C,
isnull(	'+@M8  +',	0)	as M8C,
isnull(	'+@M9  +',	0)	as M9C,
isnull(	'+@M10 +',	0)	as M10C, 
isnull(	'+@M11 +',	0)	as M11C, 
isnull(	'+@M12 +',	0)	as M12C, 
isnull(	'+@M13 +',	0)	as M1A,
isnull(	'+@M14 +',	0)	as M2A,
isnull(	'+@M15 +',	0)	as M3A,
isnull(	'+@M16 +',	0)	as M4A,
isnull(	'+@M17 +',	0)	as M5A,
isnull(	'+@M18 +',	0)	as M6A,
isnull(	'+@M19 +',	0)	as M7A,
isnull(	'+@M20 +',	0)	as M8A,
isnull(	'+@M21 +',	0)	as M9A,
isnull(	'+@M22 +',	0)	as M10A,
isnull(	'+@M23 +',	0)	as M11A,
isnull(	'+@M24 +',	0)	as M12A

from 
(select  
matId,
CentroLogisticoCodSap CtCdSap, 
dirNom,
subNom, 
left(subSigla,2) as Sigla,
proj, 
infAd, 
respo, 
qtde, 
 peri
from
 (SELECT 

MaterialID matId,
Plms.CentroLogisticoID ctId, 
DiretoriaNome dirNom,
SubDiretoriaNome subNom, 
SubDiretorias.SubDiretoriaSigla subSigla,
PlmProjeto proj, 
PlmInfoAdicional infAd, 
PlmResponsavel respo, 
PlmQuantidade qtde, 
PlmPeriodo peri
  FROM SubDiretorias, Diretorias , Plms 
  where
  
  Plms.SubDiretoriaID = SubDiretorias.SubDiretoriaID and
  SubDiretorias.DiretoriaID = Diretorias.DiretoriaID  ) plmN1 
  left join CentroLogisticos
  on
  CentroLogisticos.CentroLogisticoID = plmN1.ctId)as z 
  
  PIVOT (
   sum(qtde)
    FOR peri IN ( '+@cols +')
) as P 

';

exec(@query) 

UPDATE PlmMensalizados SET PlmDataLanc = @DataLanc

delete from rprod5.logisticaProducao.dbo.PlmMensalizados

--insert into rprod5.logisticaProducao.dbo.PlmMensalizados

--select * from PlmMensalizados
GO
/****** Object:  StoredProcedure [dbo].[Prc_PlmMensalizadoLastYear]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[Prc_PlmMensalizadoLastYear] as



declare @M1		as nvarchar(10)
declare @M2		as nvarchar(10)
declare @M3		as nvarchar(10)
declare @M4		as nvarchar(10)
declare @M5		as nvarchar(10)
declare @M6		as nvarchar(10)
declare @M7		as nvarchar(10)
declare @M8		as nvarchar(10)
declare @M9		as nvarchar(10)
declare @M10	as nvarchar(10)
declare @M11	as nvarchar(10)
declare @M12	as nvarchar(10) 




declare @equivalente as int
declare @maxEqui as int

declare @ano as int
declare @cols as nvarchar(max) 
declare @query as nvarchar(max) 
declare @DataLanc as date
set @ano= (select year(getdate())-1)
set @DataLanc = (select  max(PlmDataLanc)from HistoricoPlms where PlmEquivalente< (year(getdate())-2013)*12)

select @DataLanc
UPDATE PlmMensalizadosLastYear SET PlmDataLanc = @DataLanc

set @equivalente = (((@ano) -2013) *12)+1
set @maxEqui =  @equivalente+12


--select @equivalente,@maxEqui

delete from [PlmLastYear]

while @equivalente < @maxEqui
begin
insert into [PlmLastYear]
select *
FROM HistoricoPlms
where
[PlmEquivalente] = @equivalente and
[PlmDataLanc] = (select max([PlmDataLanc]) from HistoricoPlms where [PlmEquivalente] = @equivalente )

set @equivalente = @equivalente +1
end




set @M1	 ='['+	convert(varchar,@ano) +'01]'
set @M2	 ='['+	convert(varchar,@ano) +'02]'
set @M3	 ='['+	convert(varchar,@ano) +'03]'
set @M4	 ='['+	convert(varchar,@ano) +'04]'
set @M5	 ='['+	convert(varchar,@ano) +'05]'
set @M6	 ='['+	convert(varchar,@ano) +'06]'
set @M7	 ='['+	convert(varchar,@ano) +'07]'
set @M8	 ='['+	convert(varchar,@ano) +'08]'
set @M9	 ='['+	convert(varchar,@ano) +'09]'
set @M10 ='['+	convert(varchar,@ano) +'10]'
set @M11 ='['+	convert(varchar,@ano) +'11]'
set @M12 ='['+	convert(varchar,@ano) +'12]'









declare @mes as int

set @mes = month(getdate())


 


set @cols = 

@M1	+','+
@M2	+','+
@M3	+','+
@M4	+','+
@M5	+','+
@M6	+','+
@M7	+','+
@M8	+','+
@M9	+','+
@M10+','+
@M11+','+
@M12

delete from PlmMensalizadosLastYear

 set @query= 'insert into PlmMensalizadosLastYear
select 
NEWID() Id,
matId,
CtCdSap, 
Sigla,
dirNom,
subNom, 
proj, 
infAd, 
respo, 
null dateLanc,
isnull(	'+@M1  +',	0)	as M1C,
isnull(	'+@M2  +',	0)	as M2C,
isnull(	'+@M3  +',	0)	as M3C,
isnull(	'+@M4  +',	0)	as M4C,
isnull(	'+@M5  +',	0)	as M5C,
isnull(	'+@M6  +',	0)	as M6C,
isnull(	'+@M7  +',	0)	as M7C,
isnull(	'+@M8  +',	0)	as M8C,
isnull(	'+@M9  +',	0)	as M9C,
isnull(	'+@M10 +',	0)	as M10C, 
isnull(	'+@M11 +',	0)	as M11C, 
isnull(	'+@M12 +',	0)	as M12C, 

isnull('+@M1+',0)+
isnull('+@M2+',0)+
isnull('+@M3+',0)+
isnull('+@M4+',0)+
isnull('+@M5+',0)+
isnull('+@M6+',0)+
isnull('+@M7+',0)+
isnull('+@M8+',0)+
isnull('+@M9+',0)+
isnull('+@M10+',0)+
isnull('+@M11+',0)+
isnull('+@M12+' ,0) as TC,
(isnull( '+@M1+',0)+
 isnull( '+@M2+',0)+
 isnull( '+@M3+',0)+
 isnull( '+@M4+',0)+
 isnull( '+@M5+',0)+
 isnull( '+@M6+',0)+
 isnull( '+@M7+',0)+
 isnull( '+@M8+',0)+
 isnull( '+@M9+',0)+
 isnull( '+@M10+',0)+
 isnull( '+@M11+',0)+
 isnull( '+@M12+',0))/12 as MC

from 
(select  
matId,
CentroLogisticoCodSap CtCdSap, 
dirNom,
subNom, 
left(subSigla,2) as Sigla,
proj, 
infAd, 
respo, 
qtde, 
 peri
from
 (SELECT 
MaterialID matId,
PlmLastYear.CentroLogisticoID ctId, 
DiretoriaNome dirNom,
SubDiretoriaNome subNom, 
SubDiretorias.SubDiretoriaSigla subSigla,
PlmProjeto proj, 
PlmInfoAdicional infAd, 
PlmResponsavel respo, 
PlmQuantidade qtde, 
PlmPeriodo peri
  FROM SubDiretorias, Diretorias , [PlmLastYear] 
  where
  
  [PlmLastYear].SubDiretoriaID = SubDiretorias.SubDiretoriaID and
  SubDiretorias.DiretoriaID = Diretorias.DiretoriaID  ) plmN1 
  left join CentroLogisticos
  on
  CentroLogisticos.CentroLogisticoID = plmN1.ctId)as z 
  
  PIVOT (
   sum(qtde)
    FOR peri IN ( '+@cols +')
) as P 
';

exec(@query) 

UPDATE PlmMensalizadosLastYear SET PlmDataLanc = @DataLanc

GO
/****** Object:  StoredProcedure [dbo].[Prc_Update_ReportDesviosPresentations]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Prc_Update_ReportDesviosPresentations]
as

declare @m1		as varchar(10)
declare @m2		as varchar(10)
declare @m3		as varchar(10)
declare @m4		as varchar(10)
declare @m5		as varchar(10)
declare @m6		as varchar(10)
declare @m7		as varchar(10)
declare @m8		as varchar(10)
declare @m9		as varchar(10)
declare @m10	as varchar(10)
declare @m11	as varchar(10)
declare @m12	as varchar(10)
declare @dataLanc as date
declare @query as varchar(max)

set @dataLanc = (select max(datalanc) from ReportDesviosBases )
set @m1 = '['+ convert(varchar,FORMAT(DATEADD(M,-11,@dataLanc),'yyyyMM'))+']'
set @m2 = '['+ convert(varchar,FORMAT(DATEADD(M,-10,@dataLanc),'yyyyMM'))+']'
set @m3 = '['+ convert(varchar,FORMAT(DATEADD(M,-9,@dataLanc),'yyyyMM')) +']'
set @m4 = '['+ convert(varchar,FORMAT(DATEADD(M,-8,@dataLanc),'yyyyMM')) +']'
set @m5 = '['+ convert(varchar,FORMAT(DATEADD(M,-7,@dataLanc),'yyyyMM')) +']'
set @m6 = '['+ convert(varchar,FORMAT(DATEADD(M,-6,@dataLanc),'yyyyMM')) +']'
set @m7 = '['+ convert(varchar,FORMAT(DATEADD(M,-5,@dataLanc),'yyyyMM')) +']'
set @m8 = '['+ convert(varchar,FORMAT(DATEADD(M,-4,@dataLanc),'yyyyMM')) +']'
set @m9 = '['+ convert(varchar,FORMAT(DATEADD(M,-3,@dataLanc),'yyyyMM')) +']'
set @m10 ='['+ convert(varchar,FORMAT(DATEADD(M,-2,@dataLanc),'yyyyMM')) +']'
set @m11 ='['+ convert(varchar,FORMAT(DATEADD(M,-1,@dataLanc),'yyyyMM')) +']'
set @m12 ='['+ convert(varchar,FORMAT(@dataLanc,'yyyyMM'))				 +']'



set @query =
'
delete from ReportDesviosPresentations
insert into ReportDesviosPresentations
select 
EmpresaID,
EmpresaNome,
MatId,
MaterialCodSap,
FamiliaID,
FamiliaNome,
Movimento,
DataLanc,
isnull('+@m1	+',0) as M11Before	,
isnull('+@m2	+',0) as M10Before	,
isnull('+@m3	+',0) as M9Before	,
isnull('+@m4	+',0) as M8Before	,
isnull('+@m5	+',0) as M7Before	,
isnull('+@m6	+',0) as M6Before	,
isnull('+@m7	+',0) as M5Before	,
isnull('+@m8	+',0) as M4Before	,
isnull('+@m9	+',0) as M3Before	,
isnull('+@m10	+',0) as M2Before	,
isnull('+@m11	+',0) as M1Before	,
isnull('+@m12	+',0) as MCurrent


from
(select 
EmpresaID,
EmpresaNome,
MatId,
MaterialCodSap,
FamiliaID,
FamiliaNome,
Periodo,
DataLanc,
Movimento, 
Valor

 from 
 
 (
 select EmpresaID,
EmpresaNome,
MatId,
MaterialCodSap,
FamiliaID,
FamiliaNome,
Periodo,
EstoqueValor,
ConsumoValor,
EntradaValor,
PlmValor,
AppiaValor,
DataLanc
from ReportDesviosBases 
 )p
 unpivot
 (Valor for Movimento in
 (EstoqueValor,
ConsumoValor,
EntradaValor,
PlmValor,
AppiaValor
)
 )upvt
 )unPivo
 pivot (
 sum(valor)
 for Periodo in
 (
'+@m1		+',
'+@m2		+',
'+@m3		+',
'+@m4		+',
'+@m5		+',
'+@m6		+',
'+@m7		+',
'+@m8		+',
'+@m9		+',
'+@m10		+',
'+@m11		+',
'+@m12		+'
 )
 )piv
 '
 exec(@query)
GO
/****** Object:  StoredProcedure [dbo].[Prc_ZmepMensalizado]    Script Date: 24/03/2019 19:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_ZmepMensalizado] as
begin


declare @m1  as varchar(5)
declare @m2  as varchar(5)
declare @m3  as varchar(5)
declare @m4  as varchar(5)
declare @m5  as varchar(5)
declare @m6  as varchar(5)
declare @m7  as varchar(5)
declare @m8  as varchar(5)
declare @m9  as varchar(5)
declare @m10 as varchar(5)
declare @m11 as varchar(5)
declare @m12 as varchar(5)

declare @query as nvarchar(max)
set @m1  =dbo.EquivalenteAtual()
set @m2  =dbo.EquivalenteAtual()+1
set @m3  =dbo.EquivalenteAtual()+2
set @m4  =dbo.EquivalenteAtual()+3
set @m5  =dbo.EquivalenteAtual()+4
set @m6  =dbo.EquivalenteAtual()+5
set @m7  =dbo.EquivalenteAtual()+6
set @m8  =dbo.EquivalenteAtual()+7
set @m9  =dbo.EquivalenteAtual()+8
set @m10 =dbo.EquivalenteAtual()+9
set @m11 =dbo.EquivalenteAtual()+10
set @m12 =dbo.EquivalenteAtual()+11


set @query = 
'	
select 
MaterialID,
isnull([0],		  0) Atraso,
isnull(['+@m1 +'],0) M1,
isnull(['+@m2 +'],0) M2 ,
isnull(['+@m3 +'],0) M3 ,
isnull(['+@m4 +'],0) M4 ,
isnull(['+@m5 +'],0) M5 ,
isnull(['+@m6 +'],0) M6 ,
isnull(['+@m7 +'],0) M7 ,
isnull(['+@m8 +'],0) M8 ,
isnull(['+@m9 +'],0) M9 ,
isnull(['+@m10+'],0) M10,
isnull(['+@m11+'],0) M11,
isnull(['+@m12+'],0) M12

 from

(select 
MaterialID,
case
when ZmepDataEntrg < getdate() then 0
else
((year(ZmepDataEntrg) -2013)*12)+ month(ZmepDataEntrg)
end as zmepEquivalente,

CONVERT(MONEY,sum(ZmepQtdeEmPend)) ZmepQtdeEmPend

 from Zmeps 
 where
 ZmepCentroImputado !=''x'' and
 ZmepDataEntrg > DATEADD(MONTH,-6,convert(date,getdate())) and
 ZmepPedido not in (

''1400546204'',     
''1400546266'',     
''1400546338'',     
''1400539711'',     
''1400539805'',     
''1400539846'',     
''1400539863''     
) 
 group by
 MaterialID,
case
when ZmepDataEntrg < getdate() then 0
else
((year(ZmepDataEntrg) -2013)*12)+ month(ZmepDataEntrg)
end) as tz
pivot (
sum(ZmepQtdeEmPend)
for zmepEquivalente in (
[0],
['+@m1 +'],
['+@m2 +'],
['+@m3 +'],
['+@m4 +'],
['+@m5 +'],
['+@m6 +'],
['+@m7 +'],
['+@m8 +'],
['+@m9 +'],
['+@m10+'],
['+@m11+'],
['+@m12+']

)
) as pvy';


exec (@query)


end


GO
/****** Object:  StoredProcedure [dbo].[Prc_EstoqueConsumoAtuaisV3]    Script Date: 24/03/2019 19:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_EstoqueConsumoAtuaisV3]
as

declare @MaxDate as date

declare @CentralRJ as table(centro int)
declare @CentralCE as table(centro int)
declare @CentralGO as table(centro int)
declare @CentralBR as table(centro int)

declare @ATRJ as table(centro int)
declare @ATCE as table(centro int)
declare @ATGO as table(centro int)
declare @ATBR as table(centro int)

declare @ProcSistemicoRJ as table(centro int)
declare @ProcSistemicoCE as table(centro int)
declare @ProcSistemicoGO as table(centro int)
declare @ProcSistemicoBR as table(centro int)

declare @AdmRJ as table(dep int)
declare @AdmCE as table(dep int)
declare @AdmGO as table(dep int)

declare @ExpurgadoRJ as table(dep int)
declare @ExpurgadoCE as table(dep int)
declare @ExpurgadoGO as table(dep int)

declare @materialCE as table(materialId  bigint)
declare @materialRJ as table(materialId  bigint)
declare @materialGO as table(materialId  bigint)


declare @mb52 as table(
--Mb52ID					bigint, 
MaterialID				int, 
CentroLogisticoID		int, 
Mb52Dep					nvarchar(150), 
Mb52Lote				nvarchar(150), 
Mb52UtLivre				decimal(18,4), 
Mb52ValorUtLivre		decimal(18,4), 
Mb52EmTrans				decimal(18,4), 
Mb52ValorEmTrans		decimal(18,4), 
Mb52EmCQ				decimal(18,4), 
Mb52ValorEmCQ			decimal(18,4), 
Mb52Restrito			decimal(18,4), 
Mb52ValorRestrito		decimal(18,4), 
Mb52Bloqueados			decimal(18,4), 
Mb52ValorBloqueados		decimal(18,4), 
Mb52Devolucoes			decimal(18,4), 
Mb52ValorDevolucoes		decimal(18,4) 
--Mb52DataLanc			date
)




set @MaxDate = (select max(Mb52DataLanc) d from Mb52s)


insert @materialRJ select MaterialID from VMaterial where EmpresaID	= 2005
insert @materialCE select MaterialID from VMaterial where EmpresaID = 2003
insert @materialGO select MaterialID from VMaterial where EmpresaID = 2018

insert @CentralRJ values 
(28), --K0B0
(32), --K0B4
(35), --K0B7
(41)  --K1B4

insert @CentralCE values
(7), --F0B6
(9)  --F0B8

insert @CentralGO values 
(218) --50B0

insert @CentralBR 
select * from @CentralRJ 
union 
select * from @CentralCE
union 
select * from @CentralGO


-- Centos Logistisco cedidos a AT
insert @ATRJ values 
(96),	--	K5B7
(101)	--	K5B8

insert @ATCE values
(2) --	F0B1

--insert @ATGO values 

insert @ATBR 
select * from @ATRJ 
union 
select * from @ATCE
union 
select * from @ATGO


-- Valor Administrativo atualmente é sinalizado pelos depósitos SAP
insert @AdmRJ values (1)
--insert @AdmCE values ()
--insert @AdmGO values ()

--Depositos SAP que devem serem desconsiderados para o Estoque Físico
insert @ExpurgadoRJ values (1),(2),(3),(4),(6),(10)
insert @ExpurgadoCE values (1),(2),(3),(4),(5),(6),(11),(12),(13),(15)


-- Centros Logísticos que devem serem desconsiderados
insert @ProcSistemicoRJ values 
(34),--	K0B6
(36),--	K0B8
(88),--	K0B9
(81),--	K2B6
(63),-- K4B2
(86) -- K5B0

insert @ProcSistemicoCE values (3)--	F0B2

insert @ProcSistemicoGO values (227) --50B9


insert @ProcSistemicoBR 
select * from @ProcSistemicoRJ
union
select * from @ProcSistemicoCE
union
select * from @ProcSistemicoGO



update zmovs set ZmovExpurgado = 'x'
where
zmovEquivalente = dbo.EquivalenteAtual() and
CentroLogisticoID in (select * from @ProcSistemicoBR)


insert into @mb52 
select 
MaterialID			,
CentroLogisticoID	,
Mb52Dep				,
Mb52Lote			,
Mb52UtLivre			,
Mb52ValorUtLivre	,
Mb52EmTrans			,
Mb52ValorEmTrans	,
Mb52EmCQ			,
Mb52ValorEmCQ		,
Mb52Restrito		,
Mb52ValorRestrito	,
Mb52Bloqueados		,
Mb52ValorBloqueados	,
Mb52Devolucoes		,
Mb52ValorDevolucoes	
--Mb52DataLanc		
from Mb52s
where
Mb52DataLanc =@MaxDate
--(select max(Mb52DataLanc) d from Mb52s)


delete from EstoqueConsumoAtuais 

insert into EstoqueConsumoAtuais 

select 
newid() as[ID], 
ece.[CentroLogisticoID], 
[MaterialID], 
[CentroLogisticoCodSap], 
[Lote], 
[SapQtde], 
[SapValor], 
[FisicoQtde], 
[FisicoValor], 
[AdmQtde], 
[AdmValor], 
[ConsumoQtde], 
[ConsumoValor], 

case 
when ece.[CentroLogisticoID] in (select * from @CentralBR) then 'FIRST LAYER - Central'
when ece.[CentroLogisticoID] in (select * from @ATBR) then 'HV LAYER - AT'
else 'SECOND LAYER - Parceira'
end as[TipoDoCentro],
 
@MaxDate as [DataLanc], 
[EntradaQtde], 
[EntradaValor]


from

(select 
isnull(ec.CentroLogisticoID , entr.CentroLogisticoID	)	CentroLogisticoID	,
isnull(ec.MaterialID		, entr.MaterialID			)	MaterialID			,		
isnull(ec.Lote				, entr.Mb51Lote				)	Lote				,
isnull(QtdeSap,	0)											[SapQtde]				,
isnull(ValorSap,0)											[SapValor]			,
isnull(QtdeFis,	0)											[FisicoQtde]				,
isnull(ValorFis,0)											[FisicoValor]			,
isnull(QtdeAdm,	0)											[AdmQtde]				,
isnull(ValorAdm,0)											[AdmValor]			,
isnull(zmovQtde	,0)											[ConsumoQtde]			, 
isnull(zmovValor,0)											[ConsumoValor]  			,
isnull(qtdeEntr ,0)											[EntradaQtde]			,
isnull(valorEntr,0)											[EntradaValor]

 from

(select 

isnull(SapCentroLogisticoID , CentroLogisticoID	)CentroLogisticoID	,
isnull(SapMaterialID		, MaterialID		)MaterialID		,		
isnull(SapMb52Lote			, ZmovLote			)Lote			,
isnull(QtdeSap,	0)	QtdeSap		,
isnull(ValorSap,0)	ValorSap	,
isnull(QtdeFis,	0)	QtdeFis		,
isnull(ValorFis,0)	ValorFis	,
isnull(QtdeAdm,	0)	QtdeAdm		,
isnull(ValorAdm,0)	ValorAdm	,
isnull(zmovQtde	,0)	zmovQtde	, 
isnull(zmovValor,0)	zmovValor  	

 from


		(select 
		SapCentroLogisticoID,	
		SapMaterialID		,
		SapMb52Lote			,
		QtdeSap,
		ValorSap,
		QtdeFis,
		ValorFis,
		isnull(QtdeAdm,	0)QtdeAdm,
		isnull(ValorAdm,0)ValorAdm
		
		from
		
		(select 
		SapCentroLogisticoID,	
		SapMaterialID		,
		SapMb52Lote			,
		isnull(QtdeSap,	0)QtdeSap,
		isnull(ValorSap,0)ValorSap,
		isnull(QtdeFis,	0)QtdeFis,
		isnull(ValorFis,0)ValorFis
		
		from
--##################### Bloco Estoque Sap início  #############################################
					(SELECT     
					CentroLogisticoID	as SapCentroLogisticoID	, 
					MaterialID			as SapMaterialID			, 
					isnull(Mb52Lote,'')			as SapMb52Lote			, 
					SUM(Mb52UtLivre + Mb52EmTrans + Mb52EmCQ + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes)								 AS QtdeSap, 
                    SUM(Mb52ValorUtLivre + Mb52ValorEmTrans + Mb52ValorEmCQ + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes) AS ValorSap 
                    --Mb52DataLanc AS DataDaInformacao
                    
					   FROM          @mb52
                       WHERE
					         
							 (CentroLogisticoID NOT IN (select * from @ProcSistemicoBR))
                       
					   GROUP BY CentroLogisticoID, MaterialID, Mb52Lote--, Mb52DataLanc
					   HAVING SUM(Mb52UtLivre + Mb52EmTrans + Mb52EmCQ + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes)>0
					   
					   ) AS Sa
--##################### Bloco Estoque Sap Fim  #############################################

					   left join

--##################### Bloco Estoque Físico início  #############################################
					    (SELECT     
							CentroLogisticoID as FisCentroLogisticoID	, 
							MaterialID		as FisMaterialID			, 
							isnull(Mb52Lote,'')			as FisMb52Lote			, 
                            SUM(Mb52UtLivre + Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS QtdeFis, 
                            SUM(Mb52ValorUtLivre + Mb52ValorEmTrans + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes)AS ValorFis						
                          					
							FROM          
							@mb52 AS Mb52_2005 
                            WHERE      
							MaterialID in (select * from @materialRJ)and
							(CentroLogisticoID NOT IN (select * from @ProcSistemicoRJ)) AND   
							(CentroLogisticoID NOT IN (select * from @ATRJ)) AND                           
							(Mb52Dep NOT IN (select * from @ExpurgadoRJ) or Mb52Dep is null) 
							
                            GROUP BY CentroLogisticoID, MaterialID, Mb52Lote 
							having SUM(Mb52UtLivre + Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes)>0
                            
							UNION
                            
							SELECT     
							CentroLogisticoID as FisCentroLogisticoID , 
							MaterialID		as FisMaterialID		, 
							isnull(Mb52Lote,'')			as FisMb52Lote			, 
                            SUM(Mb52UtLivre + Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS QtdeFis, 
                            SUM(Mb52ValorUtLivre + Mb52ValorEmTrans + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes)AS ValorFis						
							                            
							FROM         
							@mb52 AS Mb52_2003 
                            WHERE
							 MaterialID in (select * from @materialCE)and
							 (CentroLogisticoID NOT IN (select * from @ProcSistemicoCE)) AND               
							 (CentroLogisticoID NOT IN (select * from @ATCE)) AND                                         
							 (Mb52Dep NOT IN (select * from @ExpurgadoCE) or Mb52Dep is null) 
							 
							 
                            GROUP BY CentroLogisticoID, MaterialID, Mb52Lote 
							having SUM(Mb52UtLivre + Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes)>0

							UNION
                            
							SELECT     
							CentroLogisticoID as FisCentroLogisticoID , 
							MaterialID		as FisMaterialID		, 
							isnull(Mb52Lote,'')			as FisMb52Lote			, 
                            SUM(Mb52UtLivre + Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS QtdeFis, 
                            SUM(Mb52ValorUtLivre + Mb52ValorEmTrans + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes)AS ValorFis						
							                            
							FROM         
							@mb52 AS Mb52_2018 
                            WHERE
							 MaterialID in (select * from @materialGO)and
							 CentroLogisticoID NOT IN (select * from @ProcSistemicoGO) AND                             
							 (CentroLogisticoID NOT IN (select * from @ATGO)) AND                           
							 (Mb52Dep NOT IN (select * from @ExpurgadoGO) or Mb52Dep is null)
							 
							 
                            GROUP BY CentroLogisticoID, MaterialID, Mb52Lote
							having SUM(Mb52UtLivre + Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes)>0     
							) as Fisico
--##################### Bloco Estoque Fisico fim  #############################################

							on
							SapCentroLogisticoID =	FisCentroLogisticoID and
							SapMaterialID		 =	FisMaterialID		 and
							SapMb52Lote			 =	FisMb52Lote			
							) as EstqSapFis
							left join

--##################### Bloco Estoque Adm início  #############################################
							(SELECT     
							Mb52_2005.CentroLogisticoID as AdmCentroLogisticoID , 
							Mb52_2005.MaterialID		as AdmMaterialID		, 
							isnull(Mb52Lote,'')		as AdmMb52Lote			, 
                            SUM(Mb52UtLivre +Mb52EmCQ +Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS QtdeAdm, 
                            SUM(Mb52ValorUtLivre +Mb52ValorEmCQ +Mb52ValorEmTrans + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes)AS ValorAdm
							                            
							FROM          
							@mb52 AS Mb52_2005 
                            WHERE      
							Mb52_2005.MaterialID in (select * from @materialRJ)and
							(Mb52_2005.CentroLogisticoID NOT IN (select * from @ProcSistemicoRJ)) AND  
							Mb52_2005.Mb52Dep NOT IN (select * from @ATRJ) and                         
							(Mb52_2005.Mb52Dep IN (select * from @AdmRJ)) 
                            GROUP BY Mb52_2005.CentroLogisticoID, Mb52_2005.MaterialID, Mb52_2005.Mb52Lote 
							having SUM(Mb52UtLivre +Mb52EmCQ +Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) >0
                            
							UNION
                            
							SELECT     
							Mb52_2003.CentroLogisticoID, 
							Mb52_2003.MaterialID, 
							isnull(Mb52Lote,'') Mb52Lote, 
                            SUM(Mb52UtLivre +Mb52EmCQ +Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS QtdeAdm, 
                            SUM(Mb52ValorUtLivre +Mb52ValorEmCQ +Mb52ValorEmTrans + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes)AS ValorAdm
							
                            
							FROM         
							@mb52 AS Mb52_2003 
                            WHERE
							 Mb52_2003.MaterialID in (select * from @materialCE)and
							 (Mb52_2003.CentroLogisticoID NOT IN (select * from @ProcSistemicoCE)) AND   
							 Mb52_2003.Mb52Dep NOT IN (select * from @ATCE) and                          
							 (Mb52_2003.Mb52Dep IN (select * from @AdmCE)) 
							 
                            GROUP BY Mb52_2003.CentroLogisticoID, Mb52_2003.MaterialID, Mb52_2003.Mb52Lote 
							having SUM(Mb52UtLivre +Mb52EmCQ +Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) >0
														UNION
                            
							SELECT     
							Mb52_2018.CentroLogisticoID, 
							Mb52_2018.MaterialID, 
							isnull(Mb52Lote,'') Mb52Lote, 
                            SUM(Mb52UtLivre +Mb52EmCQ +Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS QtdeAdm, 
                            SUM(Mb52ValorUtLivre +Mb52ValorEmCQ +Mb52ValorEmTrans + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes)AS ValorAdm
							                            
							FROM         
							@mb52 AS Mb52_2018 
                            WHERE
							Mb52_2018.MaterialID in (select * from @materialGO)and
							(Mb52_2018.CentroLogisticoID NOT IN (select * from @ProcSistemicoGO)) AND   
							Mb52_2018.Mb52Dep NOT IN (select * from @ATGO) and                          
							 (Mb52_2018.Mb52Dep IN (select * from @AdmGO)) and
							 Mb52_2018.Mb52Dep is not null
                            GROUP BY Mb52_2018.CentroLogisticoID, Mb52_2018.MaterialID, Mb52_2018.Mb52Lote
							having SUM(Mb52UtLivre +Mb52EmCQ +Mb52EmTrans + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) >0
							)  as ADM
--##################### Bloco Estoque Adm fim  #############################################

							on
							SapCentroLogisticoID =	admCentroLogisticoID and
							SapMaterialID		 =	admMaterialID		 and
							SapMb52Lote			 =	admMb52Lote		
							)as Estq	

							full join

							-- ################################## Início do código para gerar o Consumo Atual Impaq ##########################################################################						

	(					
select 
CentroLogisticoID	, 
MaterialID			, 
isnull(ZmovLote,'')ZmovLote			, 
sum(ZmovQtde) as  zmovQtde, 
sum(ZmovValor) as zmovValor  
--ZmovDataLanc 
from Zmovs 
where 
ZmovEquivalente = dbo.EquivalenteAtual() and 
CentroLogisticoID NOT IN ((select * from @ProcSistemicoBR)) and
CentroLogisticoID NOT IN ((select * from @ATBR)) and
OrdemID>0
group by  CentroLogisticoID, MaterialID, zmovLote --, zmovDataLanc
	)					
as	ConsumoAtualImpaq 

-- ################################## Fim do código para gerar o Consumo Atual ##########################################################################						
on
SapCentroLogisticoID = CentroLogisticoID	and
SapMaterialID		 = MaterialID			and	
SapMb52Lote			 = ZmovLote		
)	as ec

-- ################################## Inicio do código para gerar o Entradas Atual ##########################################################################						

full join

(select 
mb51s.CentroLogisticoID, 
mb51s.MaterialID, 
isnull(Mb51Lote,'') Mb51Lote, 
sum(Mb51QtdUMReg)	qtdeEntr , 
sum(Mb51MontanteMI) valorEntr 
from Mb51s
where
Mb51Equivalente = dbo.EquivalenteAtual()and
mb51montanteMI !=0 and
MovSapN1ID in (
1,	--101
2	--102
) and
mb51s.CentroLogisticoID in (select * from @CentralBR)

group by
mb51s.CentroLogisticoID, 
mb51s.MaterialID, 
Mb51Lote
) as entr
-- ################################## Fim do código para gerar o Entradas Atual ##########################################################################						
on
ec.CentroLogisticoID	=entr.CentroLogisticoID	and
ec.MaterialID			=entr.MaterialID		and
Lote					=Mb51Lote
) ece, CentroLogisticos
where
ece.CentroLogisticoID = CentroLogisticos.CentroLogisticoID


exec [dbo].[Prc_Update_ReportDesviosBases]
exec Prc_Update_ReportDesviosPresentations



GO
/****** Object:  StoredProcedure [dbo].[Prc_Update_BaseEstoqueConsumoPlmEntradaAppia]    Script Date: 24/03/2019 19:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Prc_Update_BaseEstoqueConsumoPlmEntradaAppia]
as

declare @DataLanc as Date
declare @PlmAppia as table(
MatId			int,
PlmQuantidade	money,
AppiaQuantidade money,
Periodo			bigInt,
Equivalente		int

)

Set @DataLanc = (select MAX(dataLanc) from EstoqueConsumoAtuais)
insert into  @PlmAppia
select 
MatId			,		
PlmQuantidade	,
AppiaQuantidade ,
Periodo			,
Equivalente		
from BaseEstoqueConsumoPlmEntradaAppia
where
Equivalente = ((year(@DataLanc)-2013)*12) + MONTH(@DataLanc)

delete from BaseEstoqueConsumoPlmEntradaAppia where Equivalente = ((year(@DataLanc)-2013)*12) + MONTH(@DataLanc)

insert into BaseEstoqueConsumoPlmEntradaAppia
select 
ISNULL(MatId, MaterialID) as				MatId			,
ISNULL(periodo,EPeriodo)				Periodo			,
ISNULL(equivalente, Eequivalente)		Equivalente		,
Isnull(ConsumoQtde,0)						GiroConsQtde	,
Isnull(ConsumoValor,0)						GiroConsValor	,
Isnull(SapQtde,0)						GiroEstqQtde	,
Isnull(SapValor,0)						GiroEstqValor	,
Isnull(PlmQuantidade,0)						PlmQuantidade	,
isnull(EntradaQtde	 ,0)							EntrQtde		,
isnull(EntradaValor	 ,0)							EntrMont		,
isnull(AppiaQuantidade,0)					AppiaQuantidade	,
null


 from 


@PlmAppia full join
(select 
MaterialID,
sum(SapQtde		)SapQtde		,
sum(SapValor	)SapValor	,
sum(ConsumoQtde	)ConsumoQtde	,
sum(ConsumoValor)ConsumoValor,
sum(EntradaQtde	)EntradaQtde	,
sum(EntradaValor)EntradaValor	,
 convert(bigint,format(@DataLanc,'yyyy')+ format(@DataLanc,'MM')) as EPeriodo,
 ((year(@DataLanc)-2013)*12) + MONTH(@DataLanc) as EEquivalente
 from EstoqueConsumoAtuais

 group by
 MaterialID,DataLanc) CurrEstq
 on
 MatId = MaterialID and
 Equivalente = EEquivalente


 update BaseEstoqueConsumoPlmEntradaAppia set DataLanc = @DataLanc


 USE logistica
GO
/****** Object:  StoredProcedure [dbo].[Prc_Update_ReportDesviosBases]    Script Date: 24/03/2019 19:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Prc_Update_ReportDesviosBases] as

exec [Prc_Update_BaseEstoqueConsumoPlmEntradaAppia]

delete from ReportDesviosBases

insert into ReportDesviosBases 

select
EmpresaID		,
EmpresaNome		,
MatId			, 
MaterialCodSap	,
FamiliaID		,
FamiliaNome		,
ConsumoQtde		, 
ConsumoValor	, 
EstoqueQtde		, 
EstoqueValor	, 
EntradaQtde		, 
EntradaValor	, 
PlmQuantidade as PlmQtde,
PlmQuantidade * ValorDeReferencia as PlmValor ,
AppiaQuantidade as AppiaQtde,
AppiaQuantidade * ValorDeReferencia as AppiaValor,
Periodo		, 
Equivalente ,
DataLanc
from
[dbo].[BaseEstoqueConsumoPlmEntradaAppia], RelacaoDeMateriais
where
[MatId] = MaterialID


delete from ReportDesviosHeaders 
insert into ReportDesviosHeaders 

select 
distinct
EmpresaId		,
EmpresaNome		,
MatId			,
MaterialCodSap	,
FamiliaId		,
FamiliaNome
 from ReportDesviosBases


 USE [logistica]
GO
/****** Object:  StoredProcedure [dbo].[Prc_GeraF0B1]    Script Date: 24/03/2019 20:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Prc_GeraF0B1]
as

declare @mb52 as table(
Mb52ID bigint, 
MaterialID int, 
CentroLogisticoID int, 
Mb52Dep nvarchar(150), 
Mb52Lote nvarchar(150), 
Mb52UtLivre decimal(18,4), 
Mb52ValorUtLivre decimal(18,4), 
Mb52EmTrans decimal(18,4), 
Mb52ValorEmTrans decimal(18,4), 
Mb52EmCQ decimal(18,4), 
Mb52ValorEmCQ decimal(18,4), 
Mb52Restrito decimal(18,4), 
Mb52ValorRestrito decimal(18,4), 
Mb52Bloqueados decimal(18,4), 
Mb52ValorBloqueados decimal(18,4), 
Mb52Devolucoes decimal(18,4), 
Mb52ValorDevolucoes decimal(18,4), 
Mb52DataLanc date
)

declare @MaxDate as date
set @MaxDate = (SELECT     MAX(Mb52DataLanc) AS maxDate FROM Mb52s AS mb52_1)

insert into @mb52
select * from Mb52s where Mb52DataLanc = @MaxDate

DELETE FROM F0b1  
INSERT into F0b1  

select *

from
(select

2 as CentroLogisticoID, 
isnull(e.MaterialID ,z.MaterialID) MaterialID, 
isnull(e.Mb52Lote ,z.ZmovLote) as Lote, 
isnull(Qtde			,0) Qtde		,		
isnull(Valor		,0) Valor		,
isnull(zmovQtde		,0) zmovQtde	, 
isnull(zmovValor	,0) zmovValor	,
@MaxDate as DataLance

from


(
SELECT     
		--			CentroLogisticoID, 
					MaterialID, 
					Mb52Lote, 
					SUM(Mb52UtLivre + Mb52EmTrans + Mb52EmCQ + Mb52Restrito + Mb52Bloqueados + Mb52Devolucoes) AS Qtde, 
                    SUM(Mb52ValorUtLivre + Mb52ValorEmTrans + Mb52ValorEmCQ + Mb52ValorRestrito + Mb52ValorBloqueados + Mb52ValorDevolucoes) AS Valor 
                    --Mb52DataLanc AS DataDaInformacao
                    
					   FROM          @mb52
                       WHERE
					         (Mb52DataLanc =@MaxDate) AND 
							 CentroLogisticoID = 2

							   GROUP BY 
							   --CentroLogisticoID, 
							   MaterialID, Mb52Lote) as e
							   --, Mb52DataLanc)


							   full outer join
(					
select 
--CentroLogisticoID, 
MaterialID, 
ZmovLote, 
sum(ZmovQtde) as  zmovQtde, 
sum(ZmovValor) as zmovValor 
--, ZmovDataLanc 
from Zmovs 
where 
ZmovEquivalente = (select max(ZmovEquivalente) from Zmovs) and 
CentroLogisticoID = 2 and
ZmovExpurgado is null and
OrdemID>0
group by  
--CentroLogisticoID, 
MaterialID, zmovLote ) as Z
--, zmovDataLanc
				
on
--e.CentroLogisticoID = z.CentroLogisticoID and
e.MaterialID = z.MaterialID and
e.Mb52Lote = z.ZmovLote	
) f

where
Qtde > 0 or
zmovQtde !=0

--select * from F0b1


USE [logistica]
GO
/****** Object:  StoredProcedure [dbo].[Prc_AtualizaDiario3]    Script Date: 24/03/2019 20:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Prc_AtualizaDiario3] as

exec [Prc_EstoqueConsumoAtuaisV3]
exec [dbo].[Prc_GeraF0B1]



INSERT INTO rprod5.logisticaproducao.DBO.Fornecedores
SELECT * FROM Fornecedores
WHERE
FornecedorID NOT IN (SELECT FornecedorID FROM rprod5.logisticaproducao.DBO.Fornecedores)

INSERT INTO rprod5.logisticaproducao.DBO.PedidoDeCompras
SELECT * FROM PedidoDeCompras
WHERE
PedidoDeCompraId NOT IN (SELECT PedidoDeCompraId FROM rprod5.logisticaproducao.DBO.PedidoDeCompras)


delete from rprod5.logisticaproducao.DBO.zmeps

delete from rprod5.logisticaproducao.DBO.ItemDoContratos

delete from rprod5.logisticaproducao.DBO.ItemPedidoDeCompras

delete from rprod5.logisticaproducao.DBO.Contratos

delete from rprod5.logisticaproducao.DBO.F0b1

delete from rprod5.logisticaproducao.DBO.EstoqueConsumoAtuais



GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "VR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ValorReferencias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ValorReferencias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "F0b1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ValorReferencias"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 136
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VF0b1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VF0b1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Materiais"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Classificacoes"
            Begin Extent = 
               Top = 6
               Left = 276
               Bottom = 102
               Right = 466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Familias"
            Begin Extent = 
               Top = 102
               Left = 276
               Bottom = 232
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Empresas"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 234
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AspNetUsers"
            Begin Extent = 
               Top = 234
               Left = 38
               Bottom = 364
               Right = 275
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MGCodes"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 479
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mat"
            Begin Extent = 
               Top = 6
               Left = 504
               Bottom = 102
               Right = 697
            End
            DisplayFlag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VMaterial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N's = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VMaterial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VMaterial'
GO
