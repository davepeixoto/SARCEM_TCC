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
    [Authorize(Roles = RoleName.Cpm)]
    public class HistConsumosController : ApiController
    {
        private ApplicationDbContext _context;
        private IEnumerable<VCpmCentroMaterialReport> _listaHistConsumo;

        public HistConsumosController()
        {
         //   _context = new ApplicationDbContext();
           // _listaHistConsumo = new List<VCpmCentroMaterialReport>();
        }

        [HttpGet]
        [ActionName("ListaHistConsumo")]
        public IHttpActionResult GetListaHistConsumo([FromUri] MaterialCentroDropDownDTO dto,
               [FromUri] TipoDeConsultaHistConsumo tipoC)

        {
            LimpaResultado(dto, tipoC);




            var tipoConsulta = (int)tipoC;

            try
            {


                switch (tipoConsulta)
                {
                    case 1:
                        {
                            var HistConsumo = (from x in _listaHistConsumo
                                               select new
                                               {
                                                   empresaNome = x.EmpresaNome,
                                                   centroLogisticoCodSap = x.CentroLogisticoCodSap,
                                                   materialCodSap = x.MaterialCodSap,
                                                   materialDescricao = x.MaterialDescricao,
                                                   materialUM = x.MaterialUM,
                                                   materialClasse = x.MaterialClasse,
                                                   classificacaoNome = x.ClassificacaoNome,
                                                   familiaNome = x.FamiliaNome,
                                                   mGCodeCodigoSap = x.MGCodeCodigoSap,
                                                   mGCodeDescricao = x.MGCodeDescricao,
                                                   userName = x.UserName,
                                                   cpm3 = x.Cpm3,
                                                   cpm6 = x.Cpm6,
                                                   cpm9 = x.Cpm9,
                                                   cpm12 = x.Cpm12,
                                                   cpm15 = x.Cpm15,
                                                   cpm18 = x.Cpm18,
                                                   cpm21 = x.Cpm21,
                                                   cpm24 = x.Cpm24,

                                               }
               ).ToList();

                            return Ok(HistConsumo);

                        }





                    default:
                        {

                            var HistConsumo = (from x in _listaHistConsumo
                                               orderby x.MaterialCodSap
                                               select new
                                               {
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
                                                   cpm3 = x.Cpm3,
                                                   cpm6 = x.Cpm6,
                                                   cpm9 = x.Cpm9,
                                                   cpm12 = x.Cpm12,
                                                   cpm15 = x.Cpm15,
                                                   cpm18 = x.Cpm18,
                                                   cpm21 = x.Cpm21,
                                                   cpm24 = x.Cpm24,

                                               }
                               ).ToList();

                            return Ok(HistConsumo);
                        }


                }
            }
            catch (Exception msg)
            {
                return BadRequest(msg.Message);

            }

        }

     
        [HttpGet]
        [ActionName("TrazDropDown")]
        public IHttpActionResult TrazDropDown([FromUri] MaterialCentroDropDownDTO dto,
            [FromUri] TipoDeConsultaHistConsumo tipoC)
        {

            LimpaResultado(dto, tipoC);

            var dtoRst = new MaterialCentroDropDownDTORst()
            {
                Empresas = (from x in _listaHistConsumo
                            orderby x.EmpresaNome
                            select x.EmpresaNome)
                .Distinct()
                .ToList(),

                Gestores = (from x in _listaHistConsumo
                            orderby x.UserName
                            select x.UserName)
                .Distinct()
                .ToList(),

                Familias = (from x in _listaHistConsumo
                            orderby x.FamiliaNome
                            select x.FamiliaNome)
                .Distinct()
                .ToList(),

                Materiais = (from x in _listaHistConsumo
                             orderby x.MaterialCodSap
                             select x.MaterialCodSap.ToString())
                 .Distinct()
                 .ToList(),

                Centros = (from x in _listaHistConsumo
                           orderby x.CentroLogisticoCodSap
                           select x.CentroLogisticoCodSap)
                  .Distinct()
                  .ToList(),


            };

            return Ok(dtoRst);
        }

        private void LimpaResultado(MaterialCentroDropDownDTO dto, TipoDeConsultaHistConsumo tipoC)
        {


            BuscaPeloAcesso(tipoC);

            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listaHistConsumo = (from x in _listaHistConsumo
                                     where x.EmpresaNome == dto.Empresa
                                     select x).Distinct().ToList();
            }


            if (!(dto.Gestor == null || dto.Gestor == ""))
            {

                _listaHistConsumo = (from x in _listaHistConsumo
                                     where x.UserName == dto.Gestor
                                     select x).Distinct().ToList();

            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {

                _listaHistConsumo = (from x in _listaHistConsumo
                                     where x.FamiliaNome == dto.Familia
                                     select x).Distinct().ToList();

            }

            if (!(dto.Material == null || dto.Material == ""))
            {
              
                _listaHistConsumo = (from x in _listaHistConsumo
                                     where x.MaterialCodSap == dto.Material
                                     select x).ToList();

            }

            if (!(dto.Centro == null || dto.Centro == ""))
            {

                _listaHistConsumo = (from x in _listaHistConsumo
                                     where x.CentroLogisticoCodSap == dto.Centro
                                     select x).Distinct().ToList();

            }




        }

        private void BuscaPeloAcesso(TipoDeConsultaHistConsumo tipoC)
        {
            _context = new ApplicationDbContext();

            if (Convert.ToInt32(tipoC) == 1)
            {
                _listaHistConsumo = _context.Database.Connection.Query<VCpmCentroMaterialReport>("select * from VCpmCentroMaterialReports");
            }
            else
            {
                _listaHistConsumo = (from x in _context.Database.Connection.Query("select * from VCpmMaterialReports")

                                     select new
                                     {
                                         x.EmpresaNome,
                                         CentroLogisticoCodSap = "",
                                         x.MaterialCodSap,
                                         x.MaterialDescricao,
                                         x.MaterialUM,
                                         x.MaterialClasse,
                                         x.ClassificacaoNome,
                                         x.FamiliaNome,
                                         x.MGCodeCodigoSap,
                                         x.MGCodeDescricao,
                                         x.UserName,
                                         x.Cpm3,
                                         x.Cpm6,
                                         x.Cpm9,
                                         x.Cpm12,
                                         x.Cpm15,
                                         x.Cpm18,
                                         x.Cpm21,
                                         x.Cpm24,
                                     }

                                    ).AsEnumerable().Select(z => new VCpmCentroMaterialReport
                                    {
                                        EmpresaNome = z.EmpresaNome,
                                        CentroLogisticoCodSap = "",
                                        MaterialCodSap = z.MaterialCodSap,
                                        MaterialDescricao = z.MaterialDescricao,
                                        MaterialUM = z.MaterialUM,
                                        MaterialClasse = z.MaterialClasse,
                                        ClassificacaoNome = z.ClassificacaoNome,
                                        FamiliaNome = z.FamiliaNome,
                                        MGCodeCodigoSap = z.MGCodeCodigoSap,
                                        MGCodeDescricao = z.MGCodeDescricao,
                                        UserName = z.UserName,
                                        Cpm3 = z.Cpm3,
                                        Cpm6 = z.Cpm6,
                                        Cpm9 = z.Cpm9,
                                        Cpm12 = z.Cpm12,
                                        Cpm15 = z.Cpm15,
                                        Cpm18 = z.Cpm18,
                                        Cpm21 = z.Cpm21,
                                        Cpm24 = z.Cpm24,

                                    }).ToList();
            }

            string empresa;

            empresa = ControlaAcesso.TrazEmpresa(User);
            if (empresa != "brasil")
            {            
                _listaHistConsumo = _listaHistConsumo
                    .Where(c => c.EmpresaNome == empresa);
            }

        }

    }
}
