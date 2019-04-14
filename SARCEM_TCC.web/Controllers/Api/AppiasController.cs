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
    [Authorize(Roles = RoleName.Appia)]
    public class AppiasController : ApiController
    {

        private ApplicationDbContext _context;
        private IEnumerable<VAppiaQuery> _listaAppia;
        private int ano;

        public AppiasController()
        {
           
           // _listaAppia = _context.VAppiaQuerys
               // .Where(c => c.AppiaDataLanc == (_context.Appias.Max(d => d.AppiaDataLanc)))
               // .ToList();
            ano = DateTime.Now.Year;
            
        }
        
        [HttpGet]
        [ActionName("ListaAppia")]
        public IHttpActionResult GetListaAppia([FromUri] AppiaDropDownDTO dto,
           [FromUri] TipoDeConsultaAppia tipoC)

        {
            LimpaResultado(dto);




            var tipoConsulta = (int)tipoC;

            try
            {


                switch (tipoConsulta)
                {
                    case 1:
                        {
                            var appia = (from x in _listaAppia
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
                                             x.DiretoriaNome,
                                             x.AppiaDataLanc,
                                             x.MGCodeDescricao,
                                             x.FamiliaNome,
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
                                             familiaNome = g.Key.FamiliaNome,
                                             mgCocde = g.Key.MGCodeCodigoSap,
                                             mgCodeDescricao = g.Key.MGCodeDescricao,
                                             gestor = g.Key.UserName,
                                             diretoria = g.Key.DiretoriaNome,
                                             appiaDataLanc = g.Key.AppiaDataLanc,
                                             medCurrYear =  g.Sum(c => c.MedCurrYear),
                                             totCurrYear = g.Sum(c => c.TotCurrYear),
                                             medAfterYear =  g.Sum(c => c.MedAfterYear),
                                             totAfterYear = g.Sum(c => c.TotAfterYear),
                                             medAfterYearPlusOne =  g.Sum(c => c.MedAfterYearPlusOne),
                                             totAfterYearPlusOne =  g.Sum(c => c.TotAfterYearPlusOne),
                                             medTrienio =  g.Sum(c => c.MedTrienio),
                                             totTrienio = g.Sum(c => c.TotTrienio),
                                             medCurrYearEmReal = g.Sum(c => c.MedCurrYearEmReal),
                                             totCurrYearEmReal = g.Sum(c => c.TotCurrYearEmReal),
                                             materialBloqueado = g.Key.MaterialBloqueado,
                                             materialSubstituto = g.Key.MaterialSubstituto,

                                         }
               ).ToList();

                            return Ok(appia);

                        }

                    case 2:
                        {
                            var appia = (from x in _listaAppia
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
                                             x.DiretoriaNome,
                                             x.SubDiretoriaNome,
                                             x.AppiaDataLanc,
                                             x.MGCodeDescricao,
                                             x.FamiliaNome
                                             ,
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
                                             familiaNome = g.Key.FamiliaNome,
                                             mgCocde = g.Key.MGCodeCodigoSap,
                                             mgCodeDescricao = g.Key.MGCodeDescricao,
                                             gestor = g.Key.UserName,
                                             diretoria = g.Key.DiretoriaNome,
                                             subDiretoria = g.Key.SubDiretoriaNome,
                                             appiaDataLanc = g.Key.AppiaDataLanc,
                                             medCurrYear = g.Sum(c => c.MedCurrYear),
                                             totCurrYear = g.Sum(c => c.TotCurrYear),
                                             medAfterYear = g.Sum(c => c.MedAfterYear),
                                             totAfterYear = g.Sum(c => c.TotAfterYear),
                                             medAfterYearPlusOne = g.Sum(c => c.MedAfterYearPlusOne),
                                             totAfterYearPlusOne = g.Sum(c => c.TotAfterYearPlusOne),
                                             medTrienio = g.Sum(c => c.MedTrienio),
                                             totTrienio = g.Sum(c => c.TotTrienio),
                                             medCurrYearEmReal = g.Sum(c => c.MedCurrYearEmReal),
                                             totCurrYearEmReal = g.Sum(c => c.TotCurrYearEmReal)
                                             ,
                                             materialBloqueado = g.Key.MaterialBloqueado,
                                             materialSubstituto = g.Key.MaterialSubstituto,

                                         }
               ).ToList();

                            return Ok(appia);
                        }

                    case 3:
                        {
                            var appia = (from x in _listaAppia
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
                                             x.DiretoriaNome,
                                             x.SubDiretoriaNome,
                                             x.AppiaProjeto,
                                             x.AppiaInfoAdicional,
                                             x.AppiaResponsavel,
                                             x.AppiaDataLanc,
                                             x.MGCodeDescricao,
                                             x.FamiliaNome
                                             ,
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
                                             familiaNome = g.Key.FamiliaNome,
                                             mgCocde = g.Key.MGCodeCodigoSap,
                                             mgCodeDescricao = g.Key.MGCodeDescricao,
                                             gestor = g.Key.UserName,
                                             diretoria = g.Key.DiretoriaNome,
                                             subDiretoria = g.Key.SubDiretoriaNome,
                                             projeto = g.Key.AppiaProjeto,
                                             infoAdicional = g.Key.AppiaInfoAdicional,
                                             responsavel = g.Key.AppiaResponsavel,
                                             appiaDataLanc = g.Key.AppiaDataLanc,
                                             medCurrYear = g.Sum(c => c.MedCurrYear),
                                             totCurrYear = g.Sum(c => c.TotCurrYear),
                                             medAfterYear = g.Sum(c => c.MedAfterYear),
                                             totAfterYear = g.Sum(c => c.TotAfterYear),
                                             medAfterYearPlusOne = g.Sum(c => c.MedAfterYearPlusOne),
                                             totAfterYearPlusOne = g.Sum(c => c.TotAfterYearPlusOne),
                                             medTrienio = g.Sum(c => c.MedTrienio),
                                             totTrienio = g.Sum(c => c.TotTrienio),
                                             medCurrYearEmReal = g.Sum(c => c.MedCurrYearEmReal),
                                             totCurrYearEmReal = g.Sum(c => c.TotCurrYearEmReal)
                                             ,
                                             materialBloqueado = g.Key.MaterialBloqueado,
                                             materialSubstituto = g.Key.MaterialSubstituto,

                                         }
               ).ToList();

                            return Ok(appia);
                        }


                    case 4:
                        {
                            var appia = (from x in _listaAppia
                                         group x by new
                                         {

                                             x.AppiaDataLanc,
                                             x.SubDiretoriaNome

                                         }
                                             into g

                                         select new
                                         {

                                             subDiretoria = g.Key.SubDiretoriaNome,
                                             medCurrYearEmReal = g.Sum(c => c.MedCurrYearEmReal),
                                             totCurrYearEmReal = g.Sum(c => c.TotCurrYearEmReal),
                                             medAfterYearEmReal = g.Sum(c => c.MedAfterYearEmReal),
                                             totAfterYearEmReal = g.Sum(c => c.TotAfterYearEmReal),
                                             medAfterYearPlusOneEmReal = g.Sum(c => c.MedAfterYearPlusOneEmReal),
                                             totAfterYearPlusOneEmReal = g.Sum(c => c.TotAfterYearPlusOneEmReal),
                                             medTrienioEmReal = g.Sum(c => c.MedTrienioEmReal),
                                             totTrienioEmReal = g.Sum(c => c.TotTrienioEmReal),
                                             appiaDataLanc = g.Key.AppiaDataLanc,
                                         }


                                         ).ToList();
                                                                                                        

                                
                            return Ok(appia);

                        }

                    default:
                        {

                            var appia = (from x in _listaAppia
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
                                             x.AppiaDataLanc,
                                             x.MGCodeDescricao,
                                             x.FamiliaNome
                                             ,
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
                                             familiaNome = g.Key.FamiliaNome,
                                             mgCocde = g.Key.MGCodeCodigoSap,
                                             mgCodeDescricao = g.Key.MGCodeDescricao,
                                             gestor = g.Key.UserName,
                                             appiaDataLanc = g.Key.AppiaDataLanc,
                                             medCurrYear = g.Sum(c => c.MedCurrYear),
                                             totCurrYear = g.Sum(c => c.TotCurrYear),
                                             medAfterYear = g.Sum(c => c.MedAfterYear),
                                             totAfterYear = g.Sum(c => c.TotAfterYear),
                                             medAfterYearPlusOne = g.Sum(c => c.MedAfterYearPlusOne),
                                             totAfterYearPlusOne = g.Sum(c => c.TotAfterYearPlusOne),
                                             medTrienio = g.Sum(c => c.MedTrienio),
                                             totTrienio = g.Sum(c => c.TotTrienio),
                                             medCurrYearEmReal = g.Sum(c => c.MedCurrYearEmReal),
                                             totCurrYearEmReal = g.Sum(c => c.TotCurrYearEmReal)
                                             ,
                                             materialBloqueado = g.Key.MaterialBloqueado,
                                             materialSubstituto = g.Key.MaterialSubstituto,

                                         }
                               ).ToList();

                            return Ok(appia);
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
        public IHttpActionResult TrazDropDown([FromUri] AppiaDropDownDTO dto)
        {

            LimpaResultado(dto);

            var dtoRst = new AppiaDropDownDTORst()
            {
                Empresas = (from x in _listaAppia
                            orderby x.EmpresaNome
                            select x.EmpresaNome)
                            .Distinct()
                            .ToList(),

                Gestores = (from x in _listaAppia
                            orderby x.UserName
                            select x.UserName)
                            .Distinct()
                            .ToList(),

                Familias = (from x in _listaAppia
                            orderby x.FamiliaNome
                            select x.FamiliaNome)
                            .Distinct()
                            .ToList(),

                Materiais = (from x in _listaAppia
                             orderby x.MaterialCodSap
                             select x.MaterialCodSap.ToString())
                             .Distinct()
                             .ToList(),

                Diretorias = (from x in _listaAppia
                              orderby x.DiretoriaNome
                              select x.DiretoriaNome)
                              .Distinct()
                              .ToList(),

                SubDiretorias = (from x in _listaAppia
                                 orderby x.SubDiretoriaNome
                                 select x.SubDiretoriaNome)
                                 .Distinct()
                                 .ToList()
            };
            return Ok(dtoRst);
        }


        private void LimpaResultado(AppiaDropDownDTO dto)
        {
            BuscaPeloAcesso();
            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listaAppia = (from x in _listaAppia
                               where x.EmpresaNome == dto.Empresa
                               select x).Distinct().ToList();
            }


            if (!(dto.Gestor == null || dto.Gestor == ""))
            {

                _listaAppia = (from x in _listaAppia
                               where x.UserName == dto.Gestor
                               select x).Distinct().ToList();

            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {

                _listaAppia = (from x in _listaAppia
                               where x.FamiliaNome == dto.Familia
                               select x).Distinct().ToList();

            }

            if (!(dto.Material == null || dto.Material == ""))
            {

                _listaAppia = (from x in _listaAppia
                               where x.MaterialCodSap == dto.Material
                               select x).ToList();

            }

            if (!(dto.Diretoria == null || dto.Diretoria == ""))
            {

                _listaAppia = (from x in _listaAppia
                               where x.DiretoriaNome == dto.Diretoria
                               select x).Distinct().ToList();

            }

            if (!(dto.SubDiretoria == null || dto.SubDiretoria == ""))
            {

                _listaAppia = (from x in _listaAppia
                               where x.SubDiretoriaNome == dto.SubDiretoria
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
                _listaAppia = _context.Database.Connection.Query<VAppiaQuery>("select * from vappiaQuerys") ;
            }
            else
            {
                _listaAppia = _context.Database.Connection.Query<VAppiaQuery>("select * from vappiaQuerys where empresaNome= @empresa", new { empresa });
            }

            if (User.IsInRole(RoleName.Cliente))
            {
           
                var _temp = new List<VAppiaQuery>();
                foreach (var item in ControlaAcesso.TrazSubDiretoria(User))
                {
                    _temp.AddRange(
                    _listaAppia.Where(c => c.SubDiretoriaNome.Contains(item))
                    );
                }


                _listaAppia = _temp;
            }          
        }
    }
}
