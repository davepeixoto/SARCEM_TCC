using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.DTO;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SARCEM_TCC.web.Controllers.Api
{
    public class MateriaisController : ApiController
    {
        private ApplicationDbContext _context;
        private List<ValorReferencia> _listMateriais;

        public MateriaisController()
        {

            _context = new ApplicationDbContext();
            _listMateriais = _context.ValorReferencias.ToList();
            //_listPrecos = _context.ValorReferencias.ToList();
        }

       // Get Material
        [HttpGet]
        [ActionName("ListaMateriais")]
        public IHttpActionResult GetMateriais([FromUri] MaterialDropDownDTO dto)

        {
            LimpaResultado(dto);
                       
            try
            {
                var mat = (from x in _listMateriais
                           select new
                           {
                               materialID = x.MaterialID,
                               classificacaoID = x.ClassificacaoID,
                               familiaID = x.FamiliaID,
                               mGCodeID = x.MGCodeID,
                               empresaNome = x.EmpresaNome,
                               materialCodSap = x.MaterialCodSap,
                               materialDescricao = x.MaterialDescricao,
                               materialClasse = x.MaterialClasse,
                               materialUM = x.MaterialUM,
                               classificacaoNome = x.ClassificacaoNome,
                               familiaNome = x.FamiliaNome,
                               mGCodeCodigoSap = x.MGCodeCodigoSap,
                               mGCOdeDescricao = x.MGCodeDescricao,
                               userName = x.UserName,
                               valorDeReferencia = x.ValorDeReferencia,
                               origem = x.Origem,
                               materialBloqueado = x.MaterialBloqueado,
                               materialSubstituto= x.MaterialSubstituto,    
                           }).ToList();

                return Ok(mat);


            }
            catch (Exception msg)
            {
                return BadRequest(msg.Message);

            }

        }



        //public IHttpActionResult GetMaterial([FromUri] MaterialDropDownDTO dto, int MatId)
        //{


        //    return Ok();
        //}




        [HttpGet]
        [ActionName("TrazDropDown")]
        public IHttpActionResult TrazDropDown([FromUri] MaterialDropDownDTO dto)
        {

            LimpaResultado(dto);

            var dtoRst = new MaterialDropDownDTORst()
            {
                
                Empresas = _listMateriais
                .OrderBy(c => c.EmpresaNome)
                .Select(d => d.EmpresaNome)
                .Distinct()
                .ToList(),
                
                Gestores = _listMateriais
                .OrderBy(c => c.UserName)
                .Select(d => d.UserName)
                .Distinct()
                .ToList(),

                Familias = _listMateriais
                .OrderBy(c => c.FamiliaNome)
                .Select(d => d.FamiliaNome)
                .Distinct()
                .ToList(),
                Materiais = _listMateriais
                .OrderBy(c => c.MaterialCodSap)
                .Select(d => d.MaterialCodSap.ToString())
                .Distinct()
                .ToList(),

            };
            return Ok(dtoRst);
        }


        private void LimpaResultado(MaterialDropDownDTO dto)
        {
                                

            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listMateriais = (from x in _listMateriais
                                   where x.EmpresaNome == dto.Empresa
                                   select x).Distinct().ToList();
            }
                      

            if (!(dto.Gestor == null || dto.Gestor == ""))
            {
               
                    _listMateriais = (from x in _listMateriais
                                       where x.UserName == dto.Gestor
                                       select x).Distinct().ToList();
                
            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {
               
                    _listMateriais = (from x in _listMateriais
                                       where x.FamiliaNome == dto.Familia
                                       select x).Distinct().ToList();
               
            }

            if (!(dto.Material == null || dto.Material == ""))
            {
               // var mat = Convert.ToInt32(dto.Material);
                
                    _listMateriais = (from x in _listMateriais
                                       where x.MaterialCodSap == dto.Material
                                      select x).Distinct().ToList();
               
            }

          

           


        }
    }


}

