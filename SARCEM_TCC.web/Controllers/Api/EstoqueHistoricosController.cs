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
    [Authorize(Roles = RoleName.EstoqueHistorico)]
    public class EstoqueHistoricosController : ApiController
    {
        private ApplicationDbContext _context;
        private IEnumerable<VEstoqueHistorico> _listaEstoqueHistorico;
        public EstoqueHistoricosController()
        {
           // _context = new ApplicationDbContext();
           // _listaEstoqueHistorico = new List<VEstoqueHistorico>();
        }

        [HttpGet]
        [ActionName("ListaEstoqueHistorico")]
        public IHttpActionResult GetListaEstoqueHistorico(
            [FromUri] MaterialCentroDropDownDTO dto,
            [FromUri] TipoDaInfo tipoC, 
            [FromUri] bool ctLogis,
            [FromUri] bool adm)

        {
            LimpaResultado(dto, tipoC, adm);


            var _EstHIstFiltrado = Filtro.EstHist(_listaEstoqueHistorico.ToList());
            string TipoDaInforamcao = null;
            var tipoConsulta = (int)tipoC;

             try
                {


                switch (tipoConsulta)
                {
                    case 1:
                        {
                            TipoDaInforamcao = "Consumo por Valor";
                            break;
                        }
                    case 2:
                        {
                            TipoDaInforamcao = "Estoque por Quantidade";
                            break;
                        }
                    case 3:
                        {
                            TipoDaInforamcao = "Estoque por Valor";
                            break;

                        }
                    case 4:
                        {
                            TipoDaInforamcao = "Entrada por Quantidade";
                            break;

                        }
                    case 5:
                        {
                            TipoDaInforamcao = "Entrada por Valor";
                            break;

                        }
                    case 6:
                        
                            {


                            var Resumo = (from x in _EstHIstFiltrado

                                          group x by x.DataLanc into g
                                          select new
                                          {
                                              data = g.Key,
                                              tipoDaInforamcao = "Estoque",

                                              m1 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M1),
                                              m2 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M2),
                                              m3 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M3),
                                              m4 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M4),
                                              m5 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M5),
                                              m6 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M6),
                                              m7 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M7),
                                              m8 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M8),
                                              m9 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M9),
                                              m10 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M10),
                                              m11 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M11),
                                              m12 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.M12),
                                              acumulado = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 3).Sum(c => c.Media),

                                          }).ToList().Union(
                                (from x in _EstHIstFiltrado

                                 group x by x.DataLanc into g
                                 select new
                                 {
                                     data = g.Key,
                                     tipoDaInforamcao = "Entrada",

                                     m1 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M1),
                                     m2 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M2),
                                     m3 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M3),
                                     m4 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M4),
                                     m5 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M5),
                                     m6 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M6),
                                     m7 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M7),
                                     m8 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M8),
                                     m9 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M9),
                                     m10 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M10),
                                     m11 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M11),
                                     m12 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.M12),
                                     acumulado = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 5).Sum(c => c.Acumulado),

                                 }).ToList()
                                ).Union(
                                (from x in _EstHIstFiltrado

                                 group x by x.DataLanc into g
                                 select new
                                 {
                                     data = g.Key,
                                     tipoDaInforamcao = "Consumo",

                                     m1 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M1),
                                     m2 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M2),
                                     m3 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M3),
                                     m4 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M4),
                                     m5 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M5),
                                     m6 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M6),
                                     m7 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M7),
                                     m8 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M8),
                                     m9 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M9),
                                     m10 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M10),
                                     m11 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M11),
                                     m12 = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.M12),
                                     acumulado = g.Where(d => Convert.ToInt16(d.TipoDaInfo) == 1).Sum(c => c.Acumulado),

                                 }).ToList()
                                );



                            return Ok(Resumo);

                            

                        }

                    default:
                        {
                            TipoDaInforamcao = "Consumo por Quantidade";
                            break;
                        }


                }
                if (ctLogis)
                {


                    if(tipoConsulta==2 || tipoConsulta==3)
                    {
                        var eHistConsumo = (from x in _EstHIstFiltrado
                                            group x by new
                                            {
                                                x.EmpresaNome,
                                                x.CentroLogisticoCodSap,
                                                x.MaterialCodSap,
                                                x.MaterialDescricao,
                                                x.MaterialUM,
                                                x.MaterialClasse,
                                                x.ClassificacaoNome,
                                                x.FamiliaNome,
                                                x.MGCodeCodigoSap,
                                                x.MGCodeDescricao,
                                                x.UserName,

                                            }
                                                          into g

                                            select new
                                            {
                                                empresaNome = g.Key.EmpresaNome,
                                                centroLogisticoCodSap = g.Key.CentroLogisticoCodSap,
                                                materialCodSap = g.Key.MaterialCodSap,
                                                materialDescricao = g.Key.MaterialDescricao,
                                                materialUM = g.Key.MaterialUM,
                                                materialClasse = g.Key.MaterialClasse,
                                                classificacaoNome = g.Key.ClassificacaoNome,
                                                familiaNome = g.Key.FamiliaNome,
                                                mGCodeCodigoSap = g.Key.MGCodeCodigoSap,
                                                mGCodeDescricao = g.Key.MGCodeDescricao,
                                                userName = g.Key.UserName,
                                                tipoDaInforamcao = TipoDaInforamcao,
                                                m1 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M1),
                                                m2 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M2),
                                                m3 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M3),
                                                m4 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M4),
                                                m5 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M5),
                                                m6 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M6),
                                                m7 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M7),
                                                m8 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M8),
                                                m9 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M9),
                                                m10 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M10),
                                                m11 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M11),
                                                m12 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M12),
                                                acumulado = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.Media),
                                            }).ToList();

                        return Ok(eHistConsumo);
                    }

                    var zHistConsumo = (from x in _EstHIstFiltrado
                                       group x by new
                                       {
                                           x.EmpresaNome,
                                           x.CentroLogisticoCodSap,
                                           x.MaterialCodSap,
                                           x.MaterialDescricao,
                                           x.MaterialUM,
                                           x.MaterialClasse,
                                           x.ClassificacaoNome,
                                           x.FamiliaNome,
                                           x.MGCodeCodigoSap,
                                           x.MGCodeDescricao,
                                           x.UserName,

                                       }
                                    into g

                                       select new
                                       {
                                           empresaNome              = g.Key.EmpresaNome,
                                           centroLogisticoCodSap    = g.Key.CentroLogisticoCodSap,
                                           materialCodSap           = g.Key.MaterialCodSap,
                                           materialDescricao        = g.Key.MaterialDescricao,
                                           materialUM               = g.Key.MaterialUM,
                                           materialClasse           = g.Key.MaterialClasse,
                                           classificacaoNome        = g.Key.ClassificacaoNome,
                                           familiaNome              = g.Key.FamiliaNome,
                                           mGCodeCodigoSap          = g.Key.MGCodeCodigoSap,
                                           mGCodeDescricao          = g.Key.MGCodeDescricao,
                                           userName                 = g.Key.UserName,
                                           tipoDaInforamcao         = TipoDaInforamcao,
                                           m1                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M1),
                                           m2                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M2),
                                           m3                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M3),
                                           m4                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M4),
                                           m5                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M5),
                                           m6                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M6),
                                           m7                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M7),
                                           m8                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M8),
                                           m9                       = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M9),
                                           m10                      = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M10),
                                           m11                      = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M11),
                                           m12                      = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M12),
                                           acumulado                = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.Acumulado),
                                       }).ToList();

                    return Ok(zHistConsumo);
                }

                if (tipoConsulta == 2 || tipoConsulta == 3)
                {
                    var eHistConsumo = (from x in _EstHIstFiltrado
                                       group x by new
                                       {
                                           x.EmpresaNome,
                                           x.MaterialCodSap,
                                           x.MaterialDescricao,
                                           x.MaterialUM,
                                           x.MaterialClasse,
                                           x.ClassificacaoNome,
                                           x.FamiliaNome,
                                           x.MGCodeCodigoSap,
                                           x.MGCodeDescricao,
                                           x.UserName,

                                       }
                             into g

                                       select new
                                       {
                                           empresaNome = g.Key.EmpresaNome,
                                           materialCodSap = g.Key.MaterialCodSap,
                                           materialDescricao = g.Key.MaterialDescricao,
                                           materialUM = g.Key.MaterialUM,
                                           materialClasse = g.Key.MaterialClasse,
                                           classificacaoNome = g.Key.ClassificacaoNome,
                                           familiaNome = g.Key.FamiliaNome,
                                           mGCodeCodigoSap = g.Key.MGCodeCodigoSap,
                                           mGCodeDescricao = g.Key.MGCodeDescricao,
                                           userName = g.Key.UserName,
                                           tipoDaInforamcao = TipoDaInforamcao,
                                           m1 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M1),
                                           m2 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M2),
                                           m3 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M3),
                                           m4 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M4),
                                           m5 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M5),
                                           m6 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M6),
                                           m7 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M7),
                                           m8 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M8),
                                           m9 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M9),
                                           m10 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M10),
                                           m11 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M11),
                                           m12 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M12),
                                           acumulado = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.Media),
                                       }).ToList();

                    return Ok(eHistConsumo);
                }


                    var HistConsumo = (from x in _EstHIstFiltrado
                                   group x by new
                                   {
                                       x.EmpresaNome,
                                       x.MaterialCodSap,
                                       x.MaterialDescricao,
                                       x.MaterialUM,
                                       x.MaterialClasse,
                                       x.ClassificacaoNome,
                                       x.FamiliaNome,
                                       x.MGCodeCodigoSap,
                                       x.MGCodeDescricao,
                                       x.UserName,

                                   }
                                into g

                                   select new
                                   {
                                       empresaNome = g.Key.EmpresaNome,
                                       materialCodSap = g.Key.MaterialCodSap,
                                       materialDescricao = g.Key.MaterialDescricao,
                                       materialUM = g.Key.MaterialUM,
                                       materialClasse = g.Key.MaterialClasse,
                                       classificacaoNome = g.Key.ClassificacaoNome,
                                       familiaNome = g.Key.FamiliaNome,
                                       mGCodeCodigoSap = g.Key.MGCodeCodigoSap,
                                       mGCodeDescricao = g.Key.MGCodeDescricao,
                                       userName = g.Key.UserName,
                                       tipoDaInforamcao = TipoDaInforamcao,
                                       m1 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M1),
                                       m2 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M2),
                                       m3 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M3),
                                       m4 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M4),
                                       m5 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M5),
                                       m6 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M6),
                                       m7 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M7),
                                       m8 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M8),
                                       m9 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M9),
                                       m10 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M10),
                                       m11 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M11),
                                       m12 = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.M12),
                                       acumulado = g.Where(d => d.TipoDaInfo == tipoC).Sum(c => c.Acumulado),
                                   }).ToList();

                return Ok(HistConsumo);
            }
                catch (Exception msg)
                {
                    return BadRequest(msg.Message);

                }

            }

        [HttpGet]
        [ActionName("TrazDropDown")]
        public IHttpActionResult TrazDropDown(
            [FromUri] MaterialCentroDropDownDTO dto,
            [FromUri] TipoDaInfo tipoC,
            [FromUri] bool ctLogis,
            [FromUri] bool adm
            )
        {

            LimpaResultado(dto, tipoC, adm);

            var dtoRst = new MaterialCentroDropDownDTORst()
            {
                Empresas = (from x in _listaEstoqueHistorico
                            orderby x.EmpresaNome
                            select x.EmpresaNome)
                .Distinct()
                .ToList(),

                Gestores = (from x in _listaEstoqueHistorico
                            orderby x.UserName
                            select x.UserName)
                .Distinct()
                .ToList(),

                Familias = (from x in _listaEstoqueHistorico
                            orderby x.FamiliaNome
                            select x.FamiliaNome)
                .Distinct()
                .ToList(),

                Materiais = (from x in _listaEstoqueHistorico
                             orderby x.MaterialCodSap
                             select x.MaterialCodSap.ToString())
                 .Distinct()
                 .ToList(),

                Centros = (from x in _listaEstoqueHistorico
                           orderby x.CentroLogisticoCodSap
                           select x.CentroLogisticoCodSap)
                  .Distinct()
                  .ToList(),


        };

            //if(ctLogis)
            //{
            //    dtoRst.Centros = (from x in _listaEstoqueHistorico
            //                      orderby x.CentroLogisticoCodSap
            //                      select x.CentroLogisticoCodSap)
            //      .Distinct()
            //      .ToList();


            //}





            return Ok(dtoRst);
        }

        private void LimpaResultado(MaterialCentroDropDownDTO dto, TipoDaInfo tipoC, bool adm)
        {
          BuscaPeloAcesso();

                var indice = Convert.ToInt32(tipoC);
                if (indice != 6)
            {
                _listaEstoqueHistorico = _listaEstoqueHistorico
                    .Where(c => c.TipoDaInfo == tipoC)
                    .Where(d => d.AdmVersion==adm)
                        .ToList();
            }

            
            else
                _listaEstoqueHistorico = (from x in _listaEstoqueHistorico
                                          where
                                         ( x.TipoDaInfo==TipoDaInfo.ConsumoValor  ||
                                          x.TipoDaInfo == TipoDaInfo.EntradaValor ||
                                          x.TipoDaInfo == TipoDaInfo.EstoqueValor) &&
                                          x.AdmVersion==adm

                                          select x
                                          
                                          ).ToList();


            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listaEstoqueHistorico = (from x in _listaEstoqueHistorico
                                     where x.EmpresaNome == dto.Empresa
                                     select x).Distinct().ToList();
            }


            if (!(dto.Gestor == null || dto.Gestor == ""))
            {

                _listaEstoqueHistorico = (from x in _listaEstoqueHistorico
                                     where x.UserName == dto.Gestor
                                     select x).Distinct().ToList();

            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {

                _listaEstoqueHistorico = (from x in _listaEstoqueHistorico
                                     where x.FamiliaNome == dto.Familia
                                     select x).Distinct().ToList();

            }

            if (!(dto.Material == null || dto.Material == ""))
            {

                _listaEstoqueHistorico = (from x in _listaEstoqueHistorico
                                     where x.MaterialCodSap == dto.Material
                                     select x).ToList();

            }

            if (!(dto.Centro == null || dto.Centro == ""))
            {

                _listaEstoqueHistorico = (from x in _listaEstoqueHistorico
                                          where x.CentroLogisticoCodSap == dto.Centro
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
                _listaEstoqueHistorico = 
                    _context
                    .Database
                    .Connection.Query<VEstoqueHistorico>("select * from VEstoqueHistoricos");
            }
            else
            {
                _listaEstoqueHistorico = 
                    _context
                    .Database
                    .Connection
                    .Query<VEstoqueHistorico>("select * from VEstoqueHistoricos where empresaNome= @empresa", new { empresa });
            }

          
        }

    }
}

