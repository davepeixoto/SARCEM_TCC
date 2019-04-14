using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.DTO;
using SARCEM_TCC.web.Models;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SARCEM_TCC.web.Controllers.Api
{
    [Authorize(Roles = RoleName.Brazil)]
    public class CoberturasController : ApiController
    {
        private ApplicationDbContext _context;

        private IEnumerable<VCobertura> _listCobertura;
        private TipoCoberturaEnum tipoCobertura;



        [HttpGet]
        [ActionName("ListaCobertura")]
        public IHttpActionResult GetCoberturaPlm([FromUri] CoberturaDropDownDTO dto, 
            [FromUri]TipoCoberturaEnum tipoC)
        {

           tipoCobertura = tipoC;
            LimpaResultado(dto);

            try
            {

             

                return Ok(
                    (from x in _listCobertura
                     select new
                     {
                         materialID                 =x.MaterialID            ,
                         empresaID                  =x.EmpresaID             ,
                         empresaNome                =x.EmpresaNome           ,
                         materialCodSap             =x.MaterialCodSap        ,
                         materialDescricao          =x.MaterialDescricao     ,
                         mGCodeCodigoSap            =x.MGCodeCodigoSap       ,
                         fisicoQtde                 =x.FisicoQtde            ,
                         zmepCorte                  =x.ZmepCorte             ,
                         qtdeDeContratos            =x.QtdeDeContratos       ,
                         itemDoContratoQtdeDisp     =x.ItemDoContratoQtdeDisp,
                         estimativaMensal           =x.EstimativaMensal      ,
                         autonomia                  =x.Autonomia             ,
                         autonomiaODC               =x.AutonomiaODC          ,
                         autonomiaODCContrato       =x.AutonomiaODCContrato  ,
                         statuss                    =x.Statuss.ToString()    ,
                         farol                      =x.Statuss    ,
                     }
                    ).ToList()                    
                    );
            }
            catch (Exception msg)
            {
                return BadRequest(msg.Message);
            }


        }

        [HttpGet]
        [ActionName("TrazDropDown")]
        public IHttpActionResult TrazDropDown([FromUri] CoberturaDropDownDTO dto,
              [FromUri]TipoCoberturaEnum tipoC)
        {

                     tipoCobertura = tipoC;

            LimpaResultado(dto);

             var dtoRst = new CoberturaDropDownDTORst()
            {

                Empresas = _listCobertura
                .OrderBy(c => c.EmpresaNome)
                .Select(d => d.EmpresaNome)
                .Distinct()
                .ToList(),

                
                Materiais = _listCobertura
                .OrderBy(c => c.MaterialCodSap)
                .Select(d => d.MaterialCodSap.ToString())
                .Distinct()
                .ToList(),


                MgCodeCodigosSap = _listCobertura
                .OrderBy(c => c.MGCodeCodigoSap)
                .Select(d => d.MGCodeCodigoSap.ToString())
                .Distinct()
                .ToList(),


                Status = _listCobertura
                .OrderBy(c => c.Statuss)
                .Select(d => d.Statuss.ToString())
                .Distinct()
                .ToList(),

            };
            return Ok(dtoRst);
        }

        private void LimpaResultado(CoberturaDropDownDTO dto)
        {

            BuscaPeloAcesso();


            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listCobertura = (from x in _listCobertura
                                  where x.EmpresaNome == dto.Empresa
                                  select x).Distinct().ToList();
            }


            if (!(dto.Material == null || dto.Material == ""))
            {
                _listCobertura = (from x in _listCobertura
                                  where x.MaterialCodSap == dto.Material
                                  select x).Distinct().ToList();
            }

            if (!(dto.MgCodeCodigoSap == null || dto.MgCodeCodigoSap == ""))
            {
                _listCobertura = (from x in _listCobertura
                                  where x.MGCodeCodigoSap == dto.MgCodeCodigoSap
                                  select x).Distinct().ToList();
            }


            if (!(dto.Statuss == null || dto.Statuss == ""))
            {
                _listCobertura = (from x in _listCobertura
                                  where x.Statuss.ToString() == dto.Statuss
                                  select x).Distinct().ToList();
            }





        }

        private void BuscaPeloAcesso()
        {
            _context = new ApplicationDbContext();
            //string empresa;

            //empresa = ControlaAcesso.TrazEmpresa(User);
            //if (empresa == "brasil")
            //{
                if(tipoCobertura == TipoCoberturaEnum.Appia)
                {
                    _listCobertura = _context
                    .Database
                    .Connection
                    .Query<VCobertura>("exec Prc_AppiaCobertura ");
                return;
                }

                _listCobertura = _context
                    .Database
                    .Connection
                    .Query<VCobertura>("exec Prc_PlmCobertura ");
            //}
            //else
            //{
            //    _listCobertura = _context
            //        .Database
            //        .Connection
            //        .Query<VCoberturaPlm>("exec Prc_CoberturaPlm ")
            //        .Where(c => c.EmpresaNome == empresa);
            //}


        }
    }
}
