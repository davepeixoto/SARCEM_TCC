--exec Prc_AppiaCobertura

create procedure Prc_AppiaCobertura
as
select
MaterialID															--MaterialID             
,EmpresaID															--EmpresaID              
,EmpresaNome														--EmpresaNome            
,MaterialCodSap														--MaterialCodSap         
,MaterialDescricao													--MaterialDescricao      
,MGCodeCodigoSap													--MGCodeCodigoSap        
,isnull(F_Qtde,0)FisicoQtde											--FisicoQtde             
,isnull(ZmepQtdeCrit,0)ZmepCorte									--ZmepCorte              
,isnull(QtdeCtr,0)QtdeDeContratos									--QtdeDeContratos        
,isnull(ItemDoContratoQtdeDisp,0)ItemDoContratoQtdeDisp				--ItemDoContratoQtdeDisp 
,isnull(MAp,0)EstimativaMensal										--EstimativaMensal       
,isnull(AutonomiaAppia,0)Autonomia									--Autonomia              
,isnull(AutonomiaAppiaODC,0)AutonomiaODC							--AutonomiaODC           
,isnull(AutonomiaAppiaODCContrato,0)AutonomiaODCContrato			--AutonomiaODCContrato   
,isnull(Statuss,0)Statuss											--Statuss                

from

(select
MatId 
,MAp
,ItemDoContratoQtdeDisp
,QtdeCtr
,ZmepQtdeCrit
,F_Qtde
,AutonomiaAppia
,AutonomiaAppiaODC
,AutonomiaAppiaODCContrato
,case 
when AutonomiaAppiaODCContrato >6 then 2
when AutonomiaAppiaODCContrato >3 and AutonomiaAppiaODCContrato  <=6 then 1
else 0 end Statuss

from
(select

MatId
,MAp
,ItemDoContratoQtdeDisp
,QtdeCtr
,ZmepQtdeCrit
,F_Qtde
,CASE WHEN MAp > 0 THEN convert(money, F_Qtde / MAp) ELSE -1																	END AutonomiaAppia
,CASE WHEN MAp > 0 THEN convert(money, (F_Qtde + isnull(ZmepQtdeCrit, 0)) / MAp) ELSE -1										END AutonomiaAppiaODC
,CASE WHEN MAp > 0 THEN convert(money, (F_Qtde + isnull(ZmepQtdeCrit, 0) + isnull(ItemDoContratoQtdeDisp,0))/ MAp) ELSE -1	END AutonomiaAppiaODCContrato


from

(select 
isnull(MaterialID, matid) as MatId,
MAp,
ItemDoContratoQtdeDisp,
QtdeCtr,
ZmepQtdeCrit,
F_Qtde


from
--appia
(SELECT MaterialID, sum(MedCurrYear) AS MAp																																																																									
  FROM            AppiaQuerys																																																																																					
GROUP BY MaterialID) appi
--appia

full join
(select 
isnull(MaterialID, matid) as MatId,
ItemDoContratoQtdeDisp,
QtdeCtr,
ZmepQtdeCrit,
F_Qtde
from
--QtdeItemDecontrato
(SELECT        MaterialID, sum(ItemDoContratoQtdeDisp) ItemDoContratoQtdeDisp																																																																									
  FROM            ItemDoContratos																																																																																				
  WHERE        ItemDoContratoElim IS NULL OR																																																																																	
                            ItemDoContratoElim = ''																																																																															
  GROUP BY MaterialID) iQtd
--QtdeItemDecontrato

full join

-- Estoque, Zmep, Contrato
(select  

isnull(MaterialID, MatId)MatId, 
QtdeCtr,
ZmepQtdeCrit,
F_Qtde

from


-- Contratos
(SELECT        MaterialID, sum(QtdeCtr) AS QtdeCtr																																																																												
FROM            
(SELECT        MaterialID, count(*) AS QtdeCtr																																																																													
FROM            
(SELECT DISTINCT MaterialID, ContratoID																																																																														
FROM            ItemDoContratos																																																																																				
/* foi Adicionado esta linha para trazer apenas os contratos liberados*/																																																																										
 WHERE ItemDoContratoElim IS NULL OR																																																																																			
ItemDoContratoElim = '') AS ctr																																																																																				
GROUP BY ctr.MaterialID, ContratoID) AS c																																																																																		
GROUP BY MaterialID) as ctr
  -- Contratos 

  full join

-- Estoque E Zmep 
 (
 select
 isnull(emat,zmat) MatId,
 ZmepQtdeCrit,
 F_Qtde

 from
--zmep
(SELECT  MaterialID as ZMat, sum(ZmepQtdeEmPend) AS ZmepQtdeCrit																																																																													
FROM            Zmeps																																																																																							
WHERE        ZmepDataEntrg >= DATEADD(m, - 6, GETDATE()) AND ZmepCentroImputado != 'x'																																																																							
GROUP BY MaterialID) as Zmp
-- fim zmep
full join

--Estoque
(SELECT        
MaterialID as EMAt, SUM(FisicoQtde) F_Qtde, 
SUM(ConsumoQtde) ConsumoQtde, 
SUM(EntradaQtde) EntradaQtde
FROM            EstoqueConsumoAtuais																																																																																			
GROUP BY MaterialId) as Estq
--Esotque
on 
ZMat = Emat
)EstqZmep

-- Estoque E Zmep

on
MatId = MaterialID
) EstqZmepContrato

-- Estoque, Zmep e Contrato

on
MaterialID = MatId
)  EstqContr

on
MaterialID = MatId
)base
where
MAp >0
) base_n1
) base_n2, ValorReferencias
where
MaterialID = MatId

