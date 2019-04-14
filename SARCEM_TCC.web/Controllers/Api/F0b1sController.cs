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
    [Authorize(Roles = RoleName.F0b1)]
    public class F0b1sController : ApiController
    {
        private readonly ApplicationDbContext _contex;
        private IEnumerable<VF0b1> _vF0b1;

        public F0b1sController()
        {
            _contex = new ApplicationDbContext();
            _vF0b1 = _contex.Database.Connection.Query<VF0b1>("select * from VF0b1");

        }

        [HttpGet]
        [ActionName("ListaF0b1")]
        public IHttpActionResult GetF0b1([FromUri]F0b1DropDownDTO dto)
        {
            LimpaResultado(dto);

            try
            {
                var mat = (from x in _vF0b1
                           select new
                           {
                               materialID           = x.MaterialID,
                               materialCodSap       = x.MaterialCodSap,
                               materialDescricao    = x.MaterialDescricao,
                               materialClasse       = x.MaterialClasse,
                               materialUM           = x.MaterialUM,
                               classificacaoNome    = x.ClassificacaoNome,
                               familiaNome          = x.FamiliaNome,
                               mGCodeCodigoSap      = x.MGCodeCodigoSap,
                               mGCOdeDescricao      = x.MGCodeDescricao,
                               userName             = x.UserName,
                               lote                 =x.Lote,
                               estqQtde             =x.EstqQtde,
                               estqValor            =x.EstqValor,
                               consumoQtde          =x.ConsumoQtde,
                               consumoValor         =x.ConsumoValor,
                               valorDeReferencia    = x.ValorDeReferencia,
                               dataLanc             =x.DataLanc
                           }).ToList();

                return Ok(mat);


            }
            catch (Exception msg)
            {
                return BadRequest(msg.Message);

            }

        }


        [HttpGet]
        [ActionName("TrazDropDown")]
        public IHttpActionResult TrazDropDown([FromUri] F0b1DropDownDTO dto)
        {

            LimpaResultado(dto);

            var dtoRst = new F0b1DropDownDTORst()
            {


                Gestores = _vF0b1
                .OrderBy(c => c.UserName)
                .Select(d => d.UserName)
                .Distinct()
                .ToList(),

                Familias = _vF0b1
                .OrderBy(c => c.FamiliaNome)
                .Select(d => d.FamiliaNome)
                .Distinct()
                .ToList(),
                Materiais = _vF0b1
                .OrderBy(c => c.MaterialCodSap)
                .Select(d => d.MaterialCodSap.ToString())
                .Distinct()
                .ToList(),

            };
            return Ok(dtoRst);
        }



        [HttpGet]
        [ActionName("TrazResumo")]
        public IHttpActionResult TrazResumo([FromUri] F0b1DropDownDTO dto)
        {

            LimpaResultado(dto);

            try {
                var r = (from x in _vF0b1
                     group x by new
                     {
                         x.DataLanc,
                     } into g
                             select new
                             {
                                 estqValor = g.Sum(c => c.EstqValor),
                               
                                 consumoValor = g.Sum(c => c.ConsumoValor)   ,                              
                                
                                 dataLanc = g.Key.DataLanc,
                             }

                      ).SingleOrDefault();

                return Ok(r);
            }
            catch 
            {
                return BadRequest();
                
            }
        }


        private void LimpaResultado(F0b1DropDownDTO dto)
        {


            
            if (!(dto.Gestor == null || dto.Gestor == ""))
            {

                _vF0b1 = (from x in _vF0b1
                                  where x.UserName == dto.Gestor
                                  select x).Distinct().ToList();

            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {

                _vF0b1 = (from x in _vF0b1
                                  where x.FamiliaNome == dto.Familia
                                  select x).Distinct().ToList();

            }

            if (!(dto.Material == null || dto.Material == ""))
            {
              
                _vF0b1 = (from x in _vF0b1
                                  where x.MaterialCodSap == dto.Material
                                  select x).Distinct().ToList();

            }






        }
    }
}