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
    [Authorize(Roles = RoleName.Plm)]

    public class PlmMensalizadosController : ApiController
    {
        private ApplicationDbContext _context;
        IEnumerable<PlmMensalizadoFiltrado> _plmFiltrado;

        public PlmMensalizadosController()
        {
            // _context = new ApplicationDbContext();
            // _plmFiltrado = new List<PlmMensalizadoFiltrado>();


        }

        [HttpGet]
        [ActionName("ListaPlm")]
        public IHttpActionResult GetPlmMensalizados([FromUri] PlmMensalizadoDropDownDTO dto,
            [FromUri] TipoDeConsultaPLM tipoC,
            [FromUri] bool historico,
            [FromUri] bool historicoLY)

        {
            LimpaResultado(dto, historico, historicoLY);







            var tipoConsulta = (int)tipoC;

            try
            {


                switch (tipoConsulta)
                {
                    case 1:
                        {
                            var plm = (from x in _plmFiltrado
                                       orderby x.MaterialCodSap
                                       group x by new
                                       {
                                           x.MaterialCodSap,
                                           x.MaterialDescricao,
                                           x.MaterialUM,
                                           x.MaterialClasse,
                                           x.ClassificacaoNome,
                                           x.EmpresaNome,
                                           x.MGCodeCodigoSap,
                                           x.CentroLogisticoCodSap,
                                           x.UserName,
                                           x.PlmDataLanc,
                                           x.MaterialBloqueado,
                                           x.MaterialSubstituto,

                                       } into g

                                       select new
                                       {
                                           empresa = g.Key.EmpresaNome,
                                           centro = g.Key.CentroLogisticoCodSap,
                                           materia = g.Key.MaterialCodSap,
                                           descricao = g.Key.MaterialDescricao,
                                           um = g.Key.MaterialUM,
                                           classe = g.Key.MaterialClasse,
                                           classificacao = g.Key.ClassificacaoNome,
                                           mgCocde = g.Key.MGCodeCodigoSap,
                                           gestor = g.Key.UserName,
                                           plmDataLanc = g.Key.PlmDataLanc,
                                           media = g.Sum(c => c.Media),
                                           mediaEmReal = g.Sum(c => c.MediaEmReal),
                                           total = g.Sum(c => c.Total),
                                           totalEmReal = g.Sum(c => c.TotalEmReal),
                                           mes1 = g.Sum(c => c.Mes1),
                                           mes2 = g.Sum(c => c.Mes2),
                                           mes3 = g.Sum(c => c.Mes3),
                                           mes4 = g.Sum(c => c.Mes4),
                                           mes5 = g.Sum(c => c.Mes5),
                                           mes6 = g.Sum(c => c.Mes6),
                                           mes7 = g.Sum(c => c.Mes7),
                                           mes8 = g.Sum(c => c.Mes8),
                                           mes9 = g.Sum(c => c.Mes9),
                                           mes10 = g.Sum(c => c.Mes10),
                                           mes11 = g.Sum(c => c.Mes11),
                                           mes12 = g.Sum(c => c.Mes12),
                                           materialBloqueado = g.Key.MaterialBloqueado,
                                           materialSubstituto = g.Key.MaterialSubstituto,
                                       }
               ).ToList();

                            return Ok(plm);

                        }

                    case 2:
                        {
                            var plm = (from x in _plmFiltrado
                                       orderby x.MaterialCodSap
                                       group x by new
                                       {
                                           x.MaterialCodSap,
                                           x.MaterialDescricao,
                                           x.MaterialUM,
                                           x.MaterialClasse,
                                           x.ClassificacaoNome,
                                           x.EmpresaNome,
                                           x.MGCodeCodigoSap,
                                           x.CentroLogisticoCodSap,
                                           x.UserName,
                                           x.DiretoriaNome,
                                           x.PlmDataLanc,
                                           x.MaterialBloqueado,
                                           x.MaterialSubstituto,

                                       } into g

                                       select new
                                       {
                                           empresa = g.Key.EmpresaNome,
                                           centro = g.Key.CentroLogisticoCodSap,
                                           materia = g.Key.MaterialCodSap,
                                           descricao = g.Key.MaterialDescricao,
                                           um = g.Key.MaterialUM,
                                           classe = g.Key.MaterialClasse,
                                           classificacao = g.Key.ClassificacaoNome,
                                           mgCocde = g.Key.MGCodeCodigoSap,
                                           gestor = g.Key.UserName,
                                           diretoria = g.Key.DiretoriaNome,
                                           plmDataLanc = g.Key.PlmDataLanc,
                                           media = g.Sum(c => c.Media),
                                           mediaEmReal = g.Sum(c => c.MediaEmReal),
                                           total = g.Sum(c => c.Total),
                                           totalEmReal = g.Sum(c => c.TotalEmReal),
                                           mes1 = g.Sum(c => c.Mes1),
                                           mes2 = g.Sum(c => c.Mes2),
                                           mes3 = g.Sum(c => c.Mes3),
                                           mes4 = g.Sum(c => c.Mes4),
                                           mes5 = g.Sum(c => c.Mes5),
                                           mes6 = g.Sum(c => c.Mes6),
                                           mes7 = g.Sum(c => c.Mes7),
                                           mes8 = g.Sum(c => c.Mes8),
                                           mes9 = g.Sum(c => c.Mes9),
                                           mes10 = g.Sum(c => c.Mes10),
                                           mes11 = g.Sum(c => c.Mes11),
                                           mes12 = g.Sum(c => c.Mes12),
                                           materialBloqueado = g.Key.MaterialBloqueado,
                                           materialSubstituto = g.Key.MaterialSubstituto,
                                       }
               ).ToList();

                            return Ok(plm);
                        }

                    case 3:
                        {
                            var plm = (from x in _plmFiltrado
                                       orderby x.MaterialCodSap
                                       group x by new
                                       {
                                           x.MaterialCodSap,
                                           x.MaterialDescricao,
                                           x.MaterialUM,
                                           x.MaterialClasse,
                                           x.ClassificacaoNome,
                                           x.EmpresaNome,
                                           x.MGCodeCodigoSap,
                                           x.CentroLogisticoCodSap,
                                           x.UserName,
                                           x.DiretoriaNome,
                                           x.SubDiretoriaNome,
                                           x.PlmDataLanc,
                                           x.MaterialBloqueado,
                                           x.MaterialSubstituto,

                                       } into g

                                       select new
                                       {
                                           empresa = g.Key.EmpresaNome,
                                           centro = g.Key.CentroLogisticoCodSap,
                                           materia = g.Key.MaterialCodSap,
                                           descricao = g.Key.MaterialDescricao,
                                           um = g.Key.MaterialUM,
                                           classe = g.Key.MaterialClasse,
                                           classificacao = g.Key.ClassificacaoNome,
                                           mgCocde = g.Key.MGCodeCodigoSap,
                                           gestor = g.Key.UserName,
                                           diretoria = g.Key.DiretoriaNome,
                                           subDiretoria = g.Key.SubDiretoriaNome,
                                           plmDataLanc = g.Key.PlmDataLanc,
                                           media = g.Sum(c => c.Media),
                                           mediaEmReal = g.Sum(c => c.MediaEmReal),
                                           total = g.Sum(c => c.Total),
                                           totalEmReal = g.Sum(c => c.TotalEmReal),
                                           mes1 = g.Sum(c => c.Mes1),
                                           mes2 = g.Sum(c => c.Mes2),
                                           mes3 = g.Sum(c => c.Mes3),
                                           mes4 = g.Sum(c => c.Mes4),
                                           mes5 = g.Sum(c => c.Mes5),
                                           mes6 = g.Sum(c => c.Mes6),
                                           mes7 = g.Sum(c => c.Mes7),
                                           mes8 = g.Sum(c => c.Mes8),
                                           mes9 = g.Sum(c => c.Mes9),
                                           mes10 = g.Sum(c => c.Mes10),
                                           mes11 = g.Sum(c => c.Mes11),
                                           mes12 = g.Sum(c => c.Mes12),
                                           materialBloqueado = g.Key.MaterialBloqueado,
                                           materialSubstituto = g.Key.MaterialSubstituto,
                                       }
                ).ToList();

                            return Ok(plm);
                        }


                    case 4:
                        {
                            var plm = (from x in _plmFiltrado
                                       orderby x.MaterialCodSap
                                       group x by new
                                       {
                                           x.MaterialCodSap,
                                           x.MaterialDescricao,
                                           x.MaterialUM,
                                           x.MaterialClasse,
                                           x.ClassificacaoNome,
                                           x.EmpresaNome,
                                           x.MGCodeCodigoSap,
                                           x.CentroLogisticoCodSap,
                                           x.UserName,
                                           x.DiretoriaNome,
                                           x.SubDiretoriaNome,
                                           x.PlmProjeto,
                                           x.PlmInfoAdicional,
                                           x.PlmResponsavel,
                                           x.PlmDataLanc,
                                           x.MaterialBloqueado,
                                           x.MaterialSubstituto,

                                       } into g

                                       select new
                                       {
                                           empresa = g.Key.EmpresaNome,
                                           centro = g.Key.CentroLogisticoCodSap,
                                           materia = g.Key.MaterialCodSap,
                                           descricao = g.Key.MaterialDescricao,
                                           um = g.Key.MaterialUM,
                                           classe = g.Key.MaterialClasse,
                                           classificacao = g.Key.ClassificacaoNome,
                                           mgCocde = g.Key.MGCodeCodigoSap,
                                           gestor = g.Key.UserName,
                                           diretoria = g.Key.DiretoriaNome,
                                           subDiretoria = g.Key.SubDiretoriaNome,
                                           projeto = g.Key.PlmProjeto,
                                           infoAdicional = g.Key.PlmInfoAdicional,
                                           responsavel = g.Key.PlmResponsavel,
                                           plmDataLanc = g.Key.PlmDataLanc,
                                           media = g.Sum(c => c.Media),
                                           mediaEmReal = g.Sum(c => c.MediaEmReal),
                                           total = g.Sum(c => c.Total),
                                           totalEmReal = g.Sum(c => c.TotalEmReal),
                                           mes1 = g.Sum(c => c.Mes1),
                                           mes2 = g.Sum(c => c.Mes2),
                                           mes3 = g.Sum(c => c.Mes3),
                                           mes4 = g.Sum(c => c.Mes4),
                                           mes5 = g.Sum(c => c.Mes5),
                                           mes6 = g.Sum(c => c.Mes6),
                                           mes7 = g.Sum(c => c.Mes7),
                                           mes8 = g.Sum(c => c.Mes8),
                                           mes9 = g.Sum(c => c.Mes9),
                                           mes10 = g.Sum(c => c.Mes10),
                                           mes11 = g.Sum(c => c.Mes11),
                                           mes12 = g.Sum(c => c.Mes12),
                                           materialBloqueado = g.Key.MaterialBloqueado,
                                           materialSubstituto = g.Key.MaterialSubstituto,
                                       }
                ).ToList();

                            return Ok(plm);
                        }

                    case 5:
                        {

                            var plm = (from x in _plmFiltrado

                                       group x by new
                                       {


                                           x.SubDiretoriaNome

                                       } into g

                                       select new
                                       {
                                           subDiretoriaNome = g.Key.SubDiretoriaNome,
                                           mediaEmReal = g.Sum(c => c.MediaEmReal),
                                           totalEmReal = g.Sum(c => c.TotalEmReal),



                                       }
                               ).ToList();

                            return Ok(plm);
                        }

                    default:
                        {

                            var plm = (from x in _plmFiltrado
                                       orderby x.MaterialCodSap
                                       group x by new
                                       {
                                           x.MaterialCodSap,
                                           x.MaterialDescricao,
                                           x.MaterialUM,
                                           x.MaterialClasse,

                                           x.ClassificacaoNome,
                                           x.EmpresaNome,
                                           x.MGCodeCodigoSap,

                                           x.UserName,
                                           x.PlmDataLanc,
                                           x.MaterialBloqueado,
                                           x.MaterialSubstituto,


                                       } into g

                                       select new
                                       {
                                           empresa = g.Key.EmpresaNome,
                                           materia = g.Key.MaterialCodSap,
                                           descricao = g.Key.MaterialDescricao,
                                           um = g.Key.MaterialUM,
                                           classe = g.Key.MaterialClasse,
                                           classificacao = g.Key.ClassificacaoNome,
                                           mgCocde = g.Key.MGCodeCodigoSap,
                                           gestor = g.Key.UserName,
                                           plmDataLanc = g.Key.PlmDataLanc,
                                           media = g.Sum(c => c.Media),
                                           mediaEmReal = g.Sum(c => c.MediaEmReal),
                                           total = g.Sum(c => c.Total),
                                           totalEmReal = g.Sum(c => c.TotalEmReal),
                                           mes1 = g.Sum(c => c.Mes1),
                                           mes2 = g.Sum(c => c.Mes2),
                                           mes3 = g.Sum(c => c.Mes3),
                                           mes4 = g.Sum(c => c.Mes4),
                                           mes5 = g.Sum(c => c.Mes5),
                                           mes6 = g.Sum(c => c.Mes6),
                                           mes7 = g.Sum(c => c.Mes7),
                                           mes8 = g.Sum(c => c.Mes8),
                                           mes9 = g.Sum(c => c.Mes9),
                                           mes10 = g.Sum(c => c.Mes10),
                                           mes11 = g.Sum(c => c.Mes11),
                                           mes12 = g.Sum(c => c.Mes12),
                                           materialBloqueado = g.Key.MaterialBloqueado,
                                           materialSubstituto = g.Key.MaterialSubstituto
                                       }
                               ).ToList();

                            return Ok(plm);
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
        public IHttpActionResult TrazDropDown([FromUri] PlmMensalizadoDropDownDTO dto, [FromUri] bool historico,
            [FromUri] bool historicoLY)
        {

            LimpaResultado(dto, historico, historicoLY);

            var dtoRst = new PlmMensalizadoDropDownDTORst()
            {
                Empresas = (from x in _plmFiltrado
                            orderby x.EmpresaNome
                            select x.EmpresaNome)
                            .Distinct()
                            .ToList(),

                Centros = (from x in _plmFiltrado
                           orderby x.CentroLogisticoCodSap
                           select x.CentroLogisticoCodSap)
                           .Distinct()
                           .ToList(),

                Gestores = (from x in _plmFiltrado
                            orderby x.UserName
                            select x.UserName)
                            .Distinct()
                            .ToList(),

                Familias = (from x in _plmFiltrado
                            orderby x.FamiliaNome
                            select x.FamiliaNome)
                            .Distinct()
                            .ToList(),

                Materiais = (from x in _plmFiltrado
                             orderby x.MaterialCodSap
                             select x.MaterialCodSap.ToString())
                             .Distinct()
                             .ToList(),

                Diretorias = (from x in _plmFiltrado
                              orderby x.DiretoriaNome
                              select x.DiretoriaNome)
                              .Distinct()
                              .ToList(),

                SubDiretorias = (from x in _plmFiltrado
                                 orderby x.SubDiretoriaNome
                                 select x.SubDiretoriaNome)
                                 .Distinct()
                                 .ToList()
            };
            return Ok(dtoRst);
        }

        private void LimpaResultado(PlmMensalizadoDropDownDTO dto, bool historico,
             bool historicoLY)
        {

            BuscaPeloAcesso(historico, historicoLY);


            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _plmFiltrado = (from x in _plmFiltrado
                                where x.EmpresaNome == dto.Empresa
                                select x).Distinct().ToList();
            }

            if (!(dto.Centro == null || dto.Centro == ""))
            {
                _plmFiltrado = (from x in _plmFiltrado
                                where x.CentroLogisticoCodSap == dto.Centro
                                select x).Distinct().ToList();
            }

            if (!(dto.Gestor == null || dto.Gestor == ""))
            {
                _plmFiltrado = (from x in _plmFiltrado
                                where x.UserName == dto.Gestor
                                select x).Distinct().ToList();
            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {
                _plmFiltrado = (from x in _plmFiltrado
                                where x.FamiliaNome == dto.Familia
                                select x).Distinct().ToList();
            }

            if (!(dto.Material == null || dto.Material == ""))
            {
                _plmFiltrado = (from x in _plmFiltrado
                                where x.MaterialCodSap == dto.Material
                                select x).Distinct().ToList();
            }

            if (!(dto.Diretoria == null || dto.Diretoria == ""))
            {
                _plmFiltrado = (from x in _plmFiltrado
                                where x.DiretoriaNome == dto.Diretoria
                                select x).Distinct().ToList();
            }

            if (!(dto.SubDiretoria == null || dto.SubDiretoria == ""))
            {
                _plmFiltrado = (from x in _plmFiltrado
                                where x.SubDiretoriaNome == dto.SubDiretoria
                                select x).Distinct().ToList();
            }




        }

        private void BuscaPeloAcesso(
            bool historico,
            bool historicoLY)
        {
            _context = new ApplicationDbContext();
            if (historicoLY)

            {
               
                _plmFiltrado = Filtro.CastingPlmFiltro(
                    _context
                    .Database
                    .Connection
                    .Query<VPlmMensalizadoLastYear>("select * from VPlmMensalizadosLastYear"));
            }
            else
            {
                _plmFiltrado = Filtro.Plm12(_context.Database.Connection.Query<VPlmMensalizado>("select * from VPlmMensalizados"), historico);
            }


            string empresa;

            empresa = ControlaAcesso.TrazEmpresa(User);
            if (empresa != "brasil")
            {
                _plmFiltrado = _plmFiltrado
                .Where(c => c.EmpresaNome == empresa);
            }

            if (User.IsInRole(RoleName.Cliente))
            {
                var _temp = new List<PlmMensalizadoFiltrado>();
                foreach (var item in ControlaAcesso.TrazSubDiretoria(User))
                {
                    _temp.AddRange(
                    _plmFiltrado.Where(c=>c.SubDiretoriaNome.Contains(item))
                    );
                }
              _plmFiltrado = _temp;

            }
        }
    }

}
