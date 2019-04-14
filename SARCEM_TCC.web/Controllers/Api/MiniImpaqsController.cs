using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.DTO;
using SARCEM_TCC.web.Helper;
using SARCEM_TCC.web.Models;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SARCEM_TCC.web.Controllers.Api
{
    [Authorize(Roles = RoleName.MiniImpaq)]

    public class MiniImpaqsController : ApiController
    {
        private ApplicationDbContext _context;

        private IEnumerable<VMiniImpaq> _listMiniImpaq;

        public MiniImpaqsController()
        {
          //  _context = new ApplicationDbContext();

        }

        [HttpGet]
        [ActionName("ListaMiniImpaq")]
        public IHttpActionResult GetMiniImpaq([FromUri] MaterialDropDownDTO dto)
        {
            LimpaResultado(dto);

            try
            {
                var impaq = (from x in _listMiniImpaq
                             orderby x.MaterialCodSap
                             select new
                             {
                                 materialID = x.MaterialID,
                                 empresaNome = x.EmpresaNome,
                                 materialCodSap = x.MaterialCodSap,
                                 materialDescricao = x.MaterialDescricao,
                                 materialUM = x.MaterialUM,
                                 materialClasse = x.MaterialClasse,
                                 classificacaoNome = x.ClassificacaoNome,
                                 familiaNome = x.FamiliaNome,
                                 mGCodeCodigoSap = x.MGCodeCodigoSap,
                                 mGCodeDescricao = x.MGCodeDescricao,
                                 userName = x.UserName,
                                 autonomiaAppia= x.AutonomiaAppia,
                                 autonomiaCPM12 = x.AutonomiaCPM12,
                                 autonomiaPLM = x.AutonomiaPLM,
                                 autonomiaAppiaODC= x.AutonomiaAppiaODC,
                                 autonomiaCPM12ODC = x.AutonomiaCPM12ODC,
                                 autonomiaPLMODC = x.AutonomiaPLMODC,
                                 qtdeDeContratos = x.QtdeDeContratos,
                                 itemDoContratoQtdeDisp = x.ItemDoContratoQtdeDisp,
                                 totalAppiaAnoAtual = x.TotalAppiaAnoAtual,
                                 mediaAppiaAnoAtual = x.MediaAppiaAnoAtual,
                                 cpm12 = x.Cpm12,
                                 mediaPLM = x.MediaPLM,
                                 totalPLM = x.TotalPLM,
                                 zmepAtrasado = x.ZmepAtrasado,
                                 zmepFuturo = x.ZmepFuturo,
                                 zmepCorte = x.ZmepCorte,
                                 fisicoQtde = x.FisicoQtde,
                                 fisicoValor = x.FisicoValor,
                                 consumoQtde = x.ConsumoQtde,
                                 consumoValor = x.ConsumoValor,
                                 entradaQtde =x.EntradaQtde,
                                 entradaValor = x.EntradaValor,
                                 valorDeReferencia = x.ValorDeReferencia,
                                 dataLanc = x.DataLanc,
                                 materialBloqueado = x.MaterialBloqueado,
                                 materialSubstituto= x.MaterialSubstituto,


                             }
                    ).ToList();

                return Ok(impaq);
            }
            catch (Exception msg)
            {
                return BadRequest(msg.Message);
            }


        }

        [HttpGet]
        [ActionName("TrazDropDown")]
        public IHttpActionResult TrazDropDown([FromUri] MaterialDropDownDTO dto)
        {

            LimpaResultado(dto);

            var dtoRst = new MaterialDropDownDTORst()
            {

                Empresas = _listMiniImpaq
                .OrderBy(c => c.EmpresaNome)
                .Select(d => d.EmpresaNome)
                .Distinct()
                .ToList(),

                Gestores = _listMiniImpaq
                .OrderBy(c => c.UserName)
                .Select(d => d.UserName)
                .Distinct()
                .ToList(),

                Familias = _listMiniImpaq
                .OrderBy(c => c.FamiliaNome)
                .Select(d => d.FamiliaNome)
                .Distinct()
                .ToList(),
                Materiais = _listMiniImpaq
                .OrderBy(c => c.MaterialCodSap)
                .Select(d => d.MaterialCodSap.ToString())
                .Distinct()
                .ToList(),

            };
            return Ok(dtoRst);
        }

        private void LimpaResultado(MaterialDropDownDTO dto)
        {

            BuscaPeloAcesso();
                                         

            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listMiniImpaq = (from x in _listMiniImpaq
                                  where x.EmpresaNome == dto.Empresa
                                  select x).Distinct().ToList();
            }


            if (!(dto.Gestor == null || dto.Gestor == ""))
            {

                _listMiniImpaq = (from x in _listMiniImpaq
                                  where x.UserName == dto.Gestor
                                  select x).Distinct().ToList();

            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {

                _listMiniImpaq = (from x in _listMiniImpaq
                                  where x.FamiliaNome == dto.Familia
                                  select x).Distinct().ToList();

            }

            if (!(dto.Material == null || dto.Material == ""))
            {
              //  var mat = Convert.ToInt32(dto.Material);

                _listMiniImpaq = (from x in _listMiniImpaq
                                  where x.MaterialCodSap == dto.Material
                                  select x).Distinct().ToList();

            }






        }

        private void BuscaPeloAcesso()
        {
            _context = new ApplicationDbContext();
            string empresa;

            empresa = ControlaAcesso.TrazEmpresa(User);
            if (empresa == "brasil")
            {
                _listMiniImpaq = _context
                    .Database
                    .Connection
                    .Query<VMiniImpaq>("exec Prc_MiniImpaq ");
            }
            else
            {
                _listMiniImpaq = _context
                    .Database
                    .Connection
                    .Query<VMiniImpaq>("exec Prc_MiniImpaq ")
                    .Where(c => c.EmpresaNome == empresa);
            }


        }
    }
}
