

GO
/****** Object:  StoredProcedure [dbo].[Prc_PlmCobertura]    Script Date: 31/03/2019 20:06:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
																																																																																	

ALTER procedure [dbo].[Prc_PlmCobertura] as
																																																																																												
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
		
		
		select  * from
																																																																																						
(select																																																																																											
 Vr.MaterialID, 																																																																																								
 Vr.EmpresaID, 																																																																																								
 Vr.EmpresaNome, 																																																																																								
 Vr.MaterialCodSap, 																																																																																							
 Vr.MaterialDescricao, 																																																																																						
 Vr.MGCodeCodigoSap, 																																																																																							
 FisicoQtde,																																																																																									
 ZmepCorte,																																																																																									
 QtdeDeContratos,																																																																																								
 ItemDoContratoQtdeDisp,																																																																																						
 MediaPLM as EstimativaMensal,																																																																																										
 AutonomiaPLM				as Autonomia				,	
 AutonomiaPLMODC			as AutonomiaODC			,
 AutonomiaPLMODCContrato 	as AutonomiaODCContrato,
 
	case
		when convert(money,AutonomiaPlmODCContrato) >6 then 2
		when convert(money,AutonomiaPlmODCContrato) >3 and convert(money,AutonomiaPLMODCContrato)  <=6 then 1
		else 0 
	
end Statuss
 																																																																																								
from																																																																																											
(SELECT         EmpresaID, MaterialID, EmpresaNome, MaterialCodSap, MaterialDescricao, MaterialUM, MaterialClasse, 																																																												
ClassificacaoNome, FamiliaNome, MGCodeCodigoSap, MgCodeDescricao, UserName, 																																																																									
						 isnull(AutonomiaPLM, 0) AS AutonomiaPLM, 
						 isnull(AutonomiaPLMODC, 0) AS AutonomiaPLMODC, 
						 isnull(AutonomiaPLMODCContrato, 0) AS AutonomiaPLMODCContrato, 
						 isnull(QtdeCtr, 0) AS QtdeDeContratos, 																																																													
                         isnull(ItemDoContratoQtdeDisp, 0) AS ItemDoContratoQtdeDisp, 
						 isnull(TAp, 0) AS TotalAppiaAnoAtual, 																																																													
						 isnull(MAp, 0) AS MediaAppiaAnoAtual, 
						 isnull(Cpm12, 0) AS Cpm12, 
						 isnull(MediaTot, 0) AS MediaPLM, 
						 isnull(TotalTot, 0) AS TotalPLM, 
						 isnull(A, 0) AS ZmepAtrasado, 
						 isnull(F, 0) AS ZmepFuturo, 
						 ISNULL(ZmepQtdeCrit, 0) AS ZmepCorte, 																																																											
						 isnull(F_Qtde, 0) AS FisicoQtde, 
						 isnull(F_Valor, 0) AS FisicoValor, 																																																																					
						 isnull(ConsumoQtde, 0) AS ConsumoQtde, 																																																																												
                         isnull(ConsumoValor, 0) AS ConsumoValor, 																																																																												
						 isnull(EntradaQtde, 0) AS  EntradaQtde, 																																																																												
                         isnull(EntradaValor, 0) AS EntradaValor, 																																																																												
						 																																																																																						
						 DataLanc =																																																																																				
                             (SELECT        max(DataLanc)																																																																														
                               FROM            EstoqueConsumoAtuais)																																																																											
FROM            (SELECT        CodMat, QtdeCtr, ItemDoContratoQtdeDisp, A, F, ZmepQtdeCrit,  AutonomiaPLM, 																																																										
CASE WHEN MediaTot > 0 THEN CONVERT(MONEY, (F_Qtde + isnull(ZmepQtdeCrit, 0)) / MediaTot) ELSE 0 END AutonomiaPLMODC,
CASE WHEN MediaTot > 0 THEN CONVERT(money, (F_Qtde + isnull(ZmepQtdeCrit, 0)+ isnull(ItemDoContratoQtdeDisp,0)) / MediaTot) ELSE 0 END AutonomiaPLMODCContrato,


CASE WHEN MediaTot > 0 THEN CONVERT(MONEY, (F_Qtde + isnull(ItemDoContratoQtdeDisp,0)) / MediaTot) ELSE 0 END AutonomiaPLMContrato,
Cpm12, MAp, TAp, MediaTot, TotaLTot, F_Qtde, F_Valor, 																																																																															
ConsumoQtde, ConsumoValor, EntradaQtde, EntradaValor																																																																															
FROM            (SELECT        CodMat, QtdeCtr, ItemDoContratoQtdeDisp, A, F, 																																																																									
CASE WHEN MediaTot > 0 THEN CONVERT(MONEY, F_Qtde / MediaTot) ELSE 0 END AutonomiaPLM, Cpm12, MAp, TAp, 																																																														
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
)temp
where
EstimativaMensal >0