using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.DTO;
using SARCEM_TCC.web.Helper;
using SARCEM_TCC.web.Models;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SARCEM_TCC.web.Controllers.Api
{
    [Authorize(Roles = RoleName.Contrato)]

    public class ContratosController : ApiController
    {
        private ApplicationDbContext _context;
        private IEnumerable<VContrato> _listaContrato;

        public ContratosController()
        {
            _context = new ApplicationDbContext();
            //_listaContrato = _context.VContratos.ToList();
        }
       
        [HttpGet]
        [ActionName("ListaContrato")]
        public IHttpActionResult GetListaContrato([FromUri] ContratoDropDownDTO dto,
        [FromUri] TipoDeConsultaContrato tipoC)

        {
            LimpaResultado(dto);




            var tipoConsulta = (int)tipoC;

            try
            {


                switch (tipoConsulta)
                {
                    case 1:
                        {
                            var Contrato = (from x in _listaContrato
                                            orderby x.MaterialCodSap

                                            select new
                                            {
                                                empresaNome = x.EmpresaNome,
                                                contratoNumero = x.ContratoNumero,
                                                itemDoContratoItm = x.ItemDoContratoItm,
                                                materialCodSap = x.MaterialCodSap,
                                                materialDescricao = x.MaterialDescricao,
                                                familiaNome = x.FamiliaNome,
                                                userName = x.UserName,
                                                contratoDataDoc = x.ContratoDataDoc,
                                                contratoIniPrazo = x.ContratoIniPrazo,
                                                contratoFimValidade = x.ContratoFimValidade,
                                                vigenciaMenorQue6Meses = x.VigenciaMenorQue6Meses,
                                                centroLogisticoCodSap = x.CentroLogisticoCodSap,
                                                itemDoContratoQtdeContrato = x.ItemDoContratoQtdeContrato,
                                                itemDoContratoQtdeDisp = x.ItemDoContratoQtdeDisp,
                                                percentualConsumidoMaterial = x.PercentualConsumidoMaterial,
                                                maisDe75PercentDoItemConsumido = x.MaisDe75PercentDoItemConsumido,
                                                baseCotacaoSigla = x.BaseCotacaoSigla,
                                                baseCotacaoValor = x.BaseCotacaoValor,
                                                contratoValFixado = x.ContratoValFixado,
                                                contratoValGlPend = x.ContratoValGlPend,
                                                contratoValGlPendEmReal = x.ContratoValGlPendEmReal,
                                                percentualConsumidoContrato = x.PercentualConsumidoContrato,
                                                maisDe75PercentDoContratoConsumido = x.MaisDe75PercentDoContratoConsumido,
                                                fornecedorNome = x.FornecedorNome,
                                                valorDeReferencia = x.ValorDeReferencia,
                                                contratoDataAlteracao = x.ContratoDataAlteracao,
                                                statusDoContrato = x.StatusDoContrato
                                                ,
                                                materialBloqueado = x.MaterialBloqueado,
                                                materialSubstituto = x.MaterialSubstituto,

                                            }
               ).ToList();

                            return Ok(Contrato);

                        }


                    default:
                        {

                            var Contrato = (from x in _listaContrato
                                            orderby x.MaterialCodSap

                                            select new
                                            {
                                                empresaNome = x.EmpresaNome,
                                                contratoNumero = x.ContratoNumero,
                                                contratoDataDoc = x.ContratoDataDoc,
                                                contratoIniPrazo = x.ContratoIniPrazo,
                                                contratoFimValidade = x.ContratoFimValidade,
                                                vigenciaMenorQue6Meses = x.VigenciaMenorQue6Meses,
                                                baseCotacaoSigla = x.BaseCotacaoSigla,
                                                baseCotacaoValor = x.BaseCotacaoValor,
                                                contratoValFixado = x.ContratoValFixado,
                                                contratoValGlPend = x.ContratoValGlPend,
                                                contratoValGlPendEmReal = x.ContratoValGlPendEmReal,
                                                percentualConsumidoContrato = x.PercentualConsumidoContrato,
                                                maisDe75PercentDoContratoConsumido = x.MaisDe75PercentDoContratoConsumido,
                                                fornecedorNome = x.FornecedorNome,
                                                contratoDataAlteracao = x.ContratoDataAlteracao,
                                                //statusDoContrato = x.StatusDoContrato,

                                            }
                               ).Distinct().ToList();

                            return Ok(Contrato);
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
        public IHttpActionResult TrazDropDown([FromUri] ContratoDropDownDTO dto)
        {

            LimpaResultado(dto);

            var dtoRst = new ContratoDropDownDTORst()
            {
                Empresas = (from x in _listaContrato
                            orderby x.EmpresaNome
                            select x.EmpresaNome)
                            .Distinct()
                            .ToList(),

                Gestores = (from x in _listaContrato
                            orderby x.UserName
                            select x.UserName)
                            .Distinct()
                            .ToList(),

                Familias = (from x in _listaContrato
                            orderby x.FamiliaNome
                            select x.FamiliaNome)
                            .Distinct()
                            .ToList(),

                Materiais = (from x in _listaContrato
                             orderby x.MaterialCodSap
                             select x.MaterialCodSap.ToString())
                             .Distinct()
                             .ToList(),

                Contratos = (from x in _listaContrato
                              orderby x.ContratoNumero
                              select x.ContratoNumero)
                              .Distinct()
                              .ToList(),

                Fornecedores = (from x in _listaContrato
                                 orderby x.FornecedorNome
                                 select x.FornecedorNome)
                                 .Distinct()
                                 .ToList()
            };
            return Ok(dtoRst);
        }


        private void LimpaResultado(ContratoDropDownDTO dto)
        {
             BuscaPeloAcesso();
            if (!(dto.Empresa == null || dto.Empresa == ""))
            {
                _listaContrato = (from x in _listaContrato
                               where x.EmpresaNome == dto.Empresa
                               select x).Distinct().ToList();
            }


            if (!(dto.Gestor == null || dto.Gestor == ""))
            {

                _listaContrato = (from x in _listaContrato
                               where x.UserName == dto.Gestor
                               select x).Distinct().ToList();

            }

            if (!(dto.Familia == null || dto.Familia == ""))
            {

                _listaContrato = (from x in _listaContrato
                               where x.FamiliaNome == dto.Familia
                               select x).Distinct().ToList();

            }

            if (!(dto.Material == null || dto.Material == ""))
            {
               // var mat = Convert.ToInt32(dto.Material);

                _listaContrato = (from x in _listaContrato
                               where x.MaterialCodSap == dto.Material
                                  select x).ToList();

            }

            if (!(dto.Contrato == null || dto.Contrato == ""))
            {

                _listaContrato = (from x in _listaContrato
                               where x.ContratoNumero== dto.Contrato
                               select x).Distinct().ToList();

            }

            if (!(dto.Fornecedor == null || dto.Fornecedor == ""))
            {

                _listaContrato = (from x in _listaContrato
                               where x.FornecedorNome == dto.Fornecedor
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
                _listaContrato = _context.Database.Connection.Query<VContrato>("select * from VContratos");
            }
            else
            {
                _listaContrato = _context.Database.Connection.Query<VContrato>("select * from VContratos where empresaNome= @empresa", new { empresa });

            }         
        }

     
        [HttpGet]
        [ActionName("BuscaContratoPorId")]
        public IHttpActionResult GetContratoId([FromUri] int id)
        {

            var rst = (_context.Database.Connection.Query<ContratoResumo>("exec Prc_BuscaResumoContratoId @materialId= @id", new { id }));


            return 
                
                Ok(rst);
        }


    }
}
