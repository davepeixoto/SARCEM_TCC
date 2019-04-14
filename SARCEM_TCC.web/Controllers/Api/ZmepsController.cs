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
    [Authorize(Roles = RoleName.Zmep)]

    public class ZmepsController : ApiController
    {
        private ApplicationDbContext _context;
        private IEnumerable<VZmep> _listZmep;

        public ZmepsController()
        {
            //_context = new ApplicationDbContext();
           // _listZmep = _context.VZmeps.ToList();
        }

        [Authorize(Roles = RoleName.Logistica)]
        [HttpGet]
        [ActionName("ListaZmep")]
        public IHttpActionResult GetZmeps([FromUri] ZmepDropDownDTO dto)
        {
            LimpaResultado(dto);

            try
            {
                var zmep = (from x in _listZmep
                            orderby x.MaterialCodSap
                            select new
                            {
                                EmpresaNome = x.EmpresaNome,
                                ZmepPedido = x.ZmepPedido,
                                Posicao = x.Posicao,
                                MaterialCodSap = x.MaterialCodSap,
                                MaterialDescricao = x.MaterialDescricao,
                                MaterialUM = x.MaterialUM,
                                MaterialClasse = x.MaterialClasse,
                                ClassificacaoNome = x.ClassificacaoNome,
                                FamiliaNome = x.FamiliaNome,
                                MGCodeCodigoSap = x.MGCodeCodigoSap,
                                MGCodeDescricao = x.MGCodeDescricao,
                                UserName = x.UserName,
                                ZmepDataEntrg = x.ZmepDataEntrg,
                                Status = x.Status,
                                Mes = x.Mes,
                                Ano = x.Ano,
                                ZmepQtdePedido = x.ZmepQtdePedido,
                                ZmepQtdeEmPend = x.ZmepQtdeEmPend,
                                ZmepImpPedido = x.ZmepImpPedido,
                                ZmepImpEmPend = x.ZmepImpEmPend,
                                MontantePendenteEntregaEmReal = x.MontantePendenteEntregaEmReal,
                                BaseCotacaoSigla = x.BaseCotacaoSigla,
                                BaseCotacaoValor = x.BaseCotacaoValor,
                                FornecedorNome = x.FornecedorNome,
                                ContratoNumero = x.ContratoNumero,
                                ZmepDataDaCompra = x.ZmepDataDaCompra,
                                CondicaoDePagamentoCodSap = x.CondicaoDePagamentoCodSap,
                                CondicaoDePagamentoDescricao = x.CondicaoDePagamentoDescricao,
                                ZmepDataLanc = x.ZmepDataLanc,
                                zmepCentroImputado = x.ZmepCentroImputado,
                                materialBloqueado = x.MaterialBloqueado,
                                materialSubstituto = x.MaterialSubstituto,



                            }
                    ).ToList();

                return Ok(zmep);
            }
            catch (Exception msg)
            {
                return BadRequest(msg.Message);
            }


        }

        [Authorize(Roles = RoleName.Logistica)]
        [HttpGet]
        [ActionName("TrazDropDown")]
        public IHttpActionResult TrazDropDown([FromUri] ZmepDropDownDTO dto)
        {

            LimpaResultado(dto);

            var dtoRst = new ZmepDropDownDTORst()
            {

                Empresas = _listZmep
                .OrderBy(c => c.EmpresaNome)
                .Select(d => d.EmpresaNome)
                .Distinct()
                .ToList(),

                Pedidos = _listZmep
                .OrderBy(c => c.ZmepPedido)
                .Select(d => d.ZmepPedido.ToString())
                .Distinct()
                .ToList(),

                Materiais = _listZmep
                .OrderBy(c => c.MaterialCodSap)
                .Select(d => d.MaterialCodSap.ToString())
                .Distinct()
                .ToList(),

                Familias = _listZmep
                .OrderBy(c => c.FamiliaNome)
                .Select(d => d.FamiliaNome)
                .Distinct()
                .ToList(),


                Gestores = _listZmep
                .OrderBy(c => c.UserName)
                .Select(d => d.UserName)
                .Distinct()
                .ToList(),

                Fornecedores = _listZmep
                .OrderBy(c => c.FornecedorNome)
                .Select(d => d.FornecedorNome)
                .Distinct()
                .ToList(),


                Statuss = _listZmep
                .OrderBy(c => c.Status)
                .Select(d => d.Status)
                .Distinct()
                .ToList(),

                Mess = _listZmep
                .OrderBy(c => c.Mes)
                .Select(d => d.Mes.ToString())
                .Distinct()
                .ToList(),

                Anos = _listZmep
                .OrderBy(c => c.Ano)
                .Select(d => d.Ano.ToString())
                .Distinct()
                .ToList(),


            };
            return Ok(dtoRst);
        }

        private void LimpaResultado(ZmepDropDownDTO dto)
        {
            BuscaPeloAcesso();


            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listZmep = (from x in _listZmep
                                  where x.EmpresaNome == dto.Empresa
                                  select x).Distinct().ToList();
            }

            if (!(dto.Pedido == null || dto.Pedido == ""))
            {
                _listZmep = (from x in _listZmep
                             where x.ZmepPedido == dto.Pedido
                             select x).Distinct().ToList();
            }
            if (!(dto.Material == null || dto.Material == ""))
            {
             //   var mat = Convert.ToInt32(dto.Material);

                _listZmep = (from x in _listZmep
                             where x.MaterialCodSap == dto.Material
                             select x).Distinct().ToList();

            }
            if (!(dto.Familia == null || dto.Familia == ""))
            {

                _listZmep = (from x in _listZmep
                             where x.FamiliaNome == dto.Familia
                             select x).Distinct().ToList();

            }


            if (!(dto.Gestor == null || dto.Gestor == ""))
            {

                _listZmep = (from x in _listZmep
                                  where x.UserName == dto.Gestor
                                  select x).Distinct().ToList();

            }


            if (!(dto.Fornecedor == null || dto.Fornecedor == ""))
            {

                _listZmep = (from x in _listZmep
                             where x.FornecedorNome == dto.Fornecedor
                             select x).Distinct().ToList();

            }

            if (!(dto.Status == null || dto.Status == ""))
            {

                _listZmep = (from x in _listZmep
                             where x.Status == dto.Status
                             select x).Distinct().ToList();

            }

            if (!(dto.Mes == null || dto.Mes == ""))
            {
                var mes = Convert.ToInt32(dto.Mes);
                _listZmep = (from x in _listZmep
                             where x.Mes == mes
                             select x).Distinct().ToList();

            }

            if (!(dto.Ano == null || dto.Ano == ""))
            {
                var ano = Convert.ToInt32(dto.Ano);
                _listZmep = (from x in _listZmep
                             where x.Ano == ano
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
                _listZmep = _context.Database.Connection.Query<VZmep>("select * from VZmeps");
            }
            else
            {
                _listZmep = 
                    _context
                    .Database
                    .Connection
                    .Query<VZmep>("select * from VZmeps where EmpresaNome = @empresa",new { empresa});
            }
        }
    }
}
