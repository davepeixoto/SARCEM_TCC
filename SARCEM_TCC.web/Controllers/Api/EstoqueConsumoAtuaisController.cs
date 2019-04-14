using SARCEM_TCC.web.DTO;
using SARCEM_TCC.web.Helper;
using SARCEM_TCC.web.Models;
using SARCEM_TCC.web.Models.Domain.DataMass.Report;
using SARCEM_TCC.web.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using Dapper;

namespace SARCEM_TCC.web.Controllers
{
    [Authorize(Roles = RoleName.EstoqueConsumo)]

    public class EstoqueConsumoAtuaisController : ApiController
    {
        private ApplicationDbContext _context;
        private IEnumerable<VEstoqueConsumoAtual> _listaEstoqueConsumo;

        public EstoqueConsumoAtuaisController()
        {
           // _context = new ApplicationDbContext();
            //_listaEstoqueConsumo = _context.VEstoqueConsumoAtuais.ToList();
        }

        
        [HttpGet]
        [ActionName("ListaEstoqueConsumo")]
        public IHttpActionResult GetListaEstoqueConsumo([FromUri] MaterialCentroDropDownDTO dto,
                  [FromUri] TipoDeConsultaEstoqueConsumo tipoC)

        {
            LimpaResultado(dto);




            var tipoConsulta = (int)tipoC;

            try
            {


                switch (tipoConsulta)
                {
                    case 1:
                        {
                            var EstoqueConsumo = (from x in _listaEstoqueConsumo
                                                  group x by new
                                                  {
                                                      x.EmpresaNome,
                                                      x.CentroLogisticoCodSap,
                                                      x.MaterialCodSap,
                                                      x.MaterialDescricao,
                                                      x.MaterialClasse,
                                                      x.MaterialUM,
                                                      x.ClassificacaoNome,
                                                      x.UserName,
                                                      x.MGCodeCodigoSap,
                                                      x.MGCodeDescricao,
                                                      x.FamiliaNome,
                                                      x.TipoDoCentro,
                                                      x.DataLanc
                                                      ,
                                                      x.MaterialBloqueado,
                                                      x.MaterialSubstituto,





                                                  } into g

                                                  select new
                                                  {
                                                      empresaNome = g.Key.EmpresaNome,
                                                      centroLogisticoCodSap = g.Key.CentroLogisticoCodSap,
                                                      materialCodSap = g.Key.MaterialCodSap,
                                                      materialDescricao = g.Key.MaterialDescricao,
                                                      materialClasse = g.Key.MaterialClasse,
                                                      materialUM = g.Key.MaterialUM,
                                                      classificacaoNome = g.Key.ClassificacaoNome,
                                                      userName = g.Key.UserName,
                                                      mGCodeCodigoSap = g.Key.MGCodeCodigoSap,
                                                      mGCodeDescricao = g.Key.MGCodeDescricao,
                                                      familiaNome = g.Key.FamiliaNome,
                                                      sapQtde = g.Sum(c => c.SapQtde),
                                                      sapValor = g.Sum(c => c.SapValor),
                                                      fisicoQtde = g.Sum(c => c.FisicoQtde),
                                                      fisicoValor = g.Sum(c => c.FisicoValor),
                                                      admQtde = g.Sum(c => c.AdmQtde),
                                                      admValor = g.Sum(c => c.AdmValor),
                                                      consumoQtde = g.Sum(c => c.ConsumoQtde),
                                                      consumoValor = g.Sum(c => c.ConsumoValor),
                                                      entradaQtde = g.Sum(c => c.EntradaQtde),
                                                      entradaValor = g.Sum(c => c.EntradaValor),

                                                      tipoDoCentro = g.Key.TipoDoCentro,
                                                      dataLanc = g.Key.DataLanc,
                                                      materialBloqueado = g.Key.MaterialBloqueado,
                                                      materialSubstituto = g.Key.MaterialSubstituto,

                                                  }
               ).ToList();

                            return Ok(EstoqueConsumo);

                        }

                    case 2:
                        {
                            var EstoqueConsumo = (from x in _listaEstoqueConsumo
                                                  group x by new
                                                  {
                                                      x.EmpresaNome,
                                                      x.CentroLogisticoCodSap,
                                                      x.MaterialCodSap,
                                                      x.MaterialDescricao,
                                                      x.MaterialClasse,
                                                      x.MaterialUM,
                                                      x.ClassificacaoNome,
                                                      x.UserName,
                                                      x.MGCodeCodigoSap,
                                                      x.MGCodeDescricao,
                                                      x.FamiliaNome,
                                                      x.TipoDoCentro,
                                                      x.DataLanc,
                                                      x.Lote,
                                                      x.MaterialBloqueado,
                                                      x.MaterialSubstituto,





                                                  } into g

                                                  select new
                                                  {
                                                      empresaNome = g.Key.EmpresaNome,
                                                      centroLogisticoCodSap = g.Key.CentroLogisticoCodSap,
                                                      lote = g.Key.Lote,
                                                      materialCodSap = g.Key.MaterialCodSap,
                                                      materialDescricao = g.Key.MaterialDescricao,
                                                      materialClasse = g.Key.MaterialClasse,
                                                      materialUM = g.Key.MaterialUM,
                                                      classificacaoNome = g.Key.ClassificacaoNome,
                                                      userName = g.Key.UserName,
                                                      mGCodeCodigoSap = g.Key.MGCodeCodigoSap,
                                                      mGCodeDescricao = g.Key.MGCodeDescricao,
                                                      familiaNome = g.Key.FamiliaNome,
                                                      sapQtde = g.Sum(c => c.SapQtde),
                                                      sapValor = g.Sum(c => c.SapValor),
                                                      fisicoQtde = g.Sum(c => c.FisicoQtde),
                                                      fisicoValor = g.Sum(c => c.FisicoValor),
                                                      admQtde = g.Sum(c => c.AdmQtde),
                                                      admValor = g.Sum(c => c.AdmValor),
                                                      consumoQtde = g.Sum(c => c.ConsumoQtde),
                                                      consumoValor = g.Sum(c => c.ConsumoValor),
                                                      entradaQtde = g.Sum(c => c.EntradaQtde),
                                                      entradaValor = g.Sum(c => c.EntradaValor),

                                                      tipoDoCentro = g.Key.TipoDoCentro,
                                                      dataLanc = g.Key.DataLanc,
                                                      materialBloqueado = g.Key.MaterialBloqueado,
                                                      materialSubstituto = g.Key.MaterialSubstituto,

                                                  }
              ).ToList();

                            return Ok(EstoqueConsumo);
                        }


                    case 3:
                        {
                            var EstoqueConsumo = ((from x in _listaEstoqueConsumo
                                                   group x by new
                                                   {
                                                       x.DataLanc,
                                                       x.TipoDoCentro,
                                                   } into g
                                                   select new
                                                   {
                                                       sapValor = g.Sum(c => c.SapValor),
                                                       fisicoValor = g.Sum(c => c.FisicoValor),
                                                       admValor = g.Sum(c => c.AdmValor),
                                                       consumoValor = g.Sum(c => c.ConsumoValor),
                                                       entradaQtde = g.Sum(c => c.EntradaQtde),
                                                       entradaValor = g.Sum(c => c.EntradaValor),

                                                       tipoDoCentro = g.Key.TipoDoCentro,
                                                       dataLanc = g.Key.DataLanc,
                                                   })
                      .Union(from x in _listaEstoqueConsumo
                             group x by new
                             {
                                 x.DataLanc,
                             } into g
                             select new
                             {
                                 sapValor = g.Sum(c => c.SapValor),
                                 fisicoValor = g.Sum(c => c.FisicoValor),
                                 admValor = g.Sum(c => c.AdmValor),
                                 consumoValor = g.Sum(c => c.ConsumoValor),
                                 entradaQtde = g.Sum(c => c.EntradaQtde),
                                 entradaValor = g.Sum(c => c.EntradaValor),

                                 tipoDoCentro = "Total",
                                 dataLanc = g.Key.DataLanc,
                             })

                      ).ToList();

                            return Ok(EstoqueConsumo);
                        }


                    default:
                        {

                            var EstoqueConsumo = (from x in _listaEstoqueConsumo
                                                  orderby x.MaterialCodSap
                                                  group x by new
                                                  {
                                                      x.EmpresaNome,
                                                      x.MaterialCodSap,
                                                      x.MaterialDescricao,
                                                      x.MaterialClasse,
                                                      x.MaterialUM,
                                                      x.ClassificacaoNome,
                                                      x.UserName,
                                                      x.MGCodeCodigoSap,
                                                      x.MGCodeDescricao,
                                                      x.FamiliaNome,

                                                      x.DataLanc,
                                                      x.MaterialBloqueado,
                                                      x.MaterialSubstituto,




                                                  } into g

                                                  select new
                                                  {
                                                      empresaNome = g.Key.EmpresaNome,
                                                      materialCodSap = g.Key.MaterialCodSap,
                                                      materialDescricao = g.Key.MaterialDescricao,
                                                      materialClasse = g.Key.MaterialClasse,
                                                      materialUM = g.Key.MaterialUM,
                                                      classificacaoNome = g.Key.ClassificacaoNome,
                                                      userName = g.Key.UserName,
                                                      mGCodeCodigoSap = g.Key.MGCodeCodigoSap,
                                                      mGCodeDescricao = g.Key.MGCodeDescricao,
                                                      familiaNome = g.Key.FamiliaNome,
                                                      sapQtde = g.Sum(c => c.SapQtde),
                                                      sapValor = g.Sum(c => c.SapValor),
                                                      fisicoQtde = g.Sum(c => c.FisicoQtde),
                                                      fisicoValor = g.Sum(c => c.FisicoValor),
                                                      admQtde = g.Sum(c => c.AdmQtde),
                                                      admValor = g.Sum(c => c.AdmValor),
                                                      consumoQtde = g.Sum(c => c.ConsumoQtde),
                                                      consumoValor = g.Sum(c => c.ConsumoValor),
                                                      entradaQtde = g.Sum(c => c.EntradaQtde),
                                                      entradaValor = g.Sum(c => c.EntradaValor),
                                                      dataLanc = g.Key.DataLanc,
                                                      materialBloqueado = g.Key.MaterialBloqueado,
                                                      materialSubstituto = g.Key.MaterialSubstituto,


                                                  }
                               ).ToList();

                            return Ok(EstoqueConsumo);
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
        public IHttpActionResult TrazDropDown([FromUri] MaterialCentroDropDownDTO dto)
        {

            LimpaResultado(dto);

            var dtoRst = new MaterialCentroDropDownDTORst()
            {
                Empresas = (from x in _listaEstoqueConsumo
                            orderby x.EmpresaNome
                            select x.EmpresaNome)
                            .Distinct()
                            .ToList(),

                Gestores = (from x in _listaEstoqueConsumo
                            orderby x.UserName
                            select x.UserName)
                            .Distinct()
                            .ToList(),

                Familias = (from x in _listaEstoqueConsumo
                            orderby x.FamiliaNome
                            select x.FamiliaNome)
                            .Distinct()
                            .ToList(),

                Materiais = (from x in _listaEstoqueConsumo
                             orderby x.MaterialCodSap
                             select x.MaterialCodSap.ToString())
                             .Distinct()
                             .ToList(),

                Centros = (from x in _listaEstoqueConsumo
                              orderby x.CentroLogisticoCodSap
                              select x.CentroLogisticoCodSap)
                              .Distinct()
                              .ToList(),

                
            };
            return Ok(dtoRst);
        }

        private void LimpaResultado(MaterialCentroDropDownDTO dto)
        {
            BuscaPeloAcesso();
            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listaEstoqueConsumo = (from x in _listaEstoqueConsumo
                               where x.EmpresaNome == dto.Empresa
                               select x).Distinct().ToList();
            }

            if (!(dto.Gestor == null || dto.Gestor == ""))
            {
                _listaEstoqueConsumo = (from x in _listaEstoqueConsumo
                               where x.UserName == dto.Gestor
                               select x).Distinct().ToList();
            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {
                _listaEstoqueConsumo = (from x in _listaEstoqueConsumo
                               where x.FamiliaNome == dto.Familia
                               select x).Distinct().ToList();
            }

            if (!(dto.Material == null || dto.Material == ""))
            {
                _listaEstoqueConsumo = (from x in _listaEstoqueConsumo
                               where x.MaterialCodSap == dto.Material
                                        select x).ToList();
            }

            if (!(dto.Centro == null || dto.Centro == ""))
            {
                _listaEstoqueConsumo = (from x in _listaEstoqueConsumo
                               where x.CentroLogisticoCodSap == dto.Centro
                                        select x).Distinct().ToList();
            }
        }    

        [HttpGet]
        [ActionName("FamilaTop10")]
        public IHttpActionResult FamilaTop10([FromUri] int EmpresaID)
        {
            _context = new ApplicationDbContext();
            var z = _context.Database.SqlQuery<FamiliaTop10DTO>("exec Prc_FamiliaTop10 @empresa = "+ EmpresaID).ToList();
            var result = (from x in z

                          select new
                          {
                              familiaNome = x.FamiliaNome,
                              sapValor = x.SapValor,
                              consumoValor=x.ConsumoValor,
                              entradaValor=x.EntradaValor,
                              percentual = x.Percentual
                          }

                          ).ToList();

            return Ok(result);
        }

        private void BuscaPeloAcesso()
        {
            _context = new ApplicationDbContext();
            string empresa;

            empresa = ControlaAcesso.TrazEmpresa(User);
            if (empresa == "brasil")
            {
                _listaEstoqueConsumo = 
                    _context
                    .Database
                    .Connection
                    .Query<VEstoqueConsumoAtual>("select * from VEstoqueConsumoAtuais");
            }
            else
            {
                _listaEstoqueConsumo = 
                    _context
                    .Database
                    .Connection
                    .Query<VEstoqueConsumoAtual>("select * from VEstoqueConsumoAtuais where empresaNome= @empresa", new { empresa });
            }
        }

    }
}
