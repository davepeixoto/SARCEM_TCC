using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("VZmeps")]
    public class VZmep
    {
        [Key]
        public Guid ZmepId { get; set; }
        public int MaterialID { get; set; }
        public string   EmpresaNome                 { get; set; }
        public string   ZmepPedido                  { get; set; }
        public int      Posicao                     { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        public string   MaterialDescricao           { get; set; }
        [StringLength(5)]
        public string MaterialUM { get; set; }
        [StringLength(2)]
        public string MaterialClasse    { get; set; }
        public string ClassificacaoNome { get; set; }
        public string FamiliaNome       { get; set; }
        [StringLength(10)]
        public string   MGCodeCodigoSap     { get; set; }
        public string   MGCodeDescricao     { get; set; }
        public string   UserName            { get; set; }
        public DateTime ZmepDataEntrg       { get; set; }
        [StringLength(20)]
        public string   Status                          { get; set; }
        public int      Mes                             { get; set; }
        public int      Ano                             { get; set; }
        public decimal  ZmepQtdePedido                  { get; set; }
        public decimal  ZmepQtdeEmPend                  { get; set; }
        public decimal  ZmepImpPedido                   { get; set; }
        public decimal  ZmepImpEmPend                   { get; set; }
        public decimal  MontantePendenteEntregaEmReal   { get; set; }
        public string   BaseCotacaoSigla                { get; set; }
        public decimal  BaseCotacaoValor                { get; set; }
        public string   FornecedorNome                  { get; set; }
        public string   ContratoNumero                  { get; set; }
        public DateTime ZmepDataDaCompra                { get; set; }
        public string   CondicaoDePagamentoCodSap       { get; set; }
        public string   CondicaoDePagamentoDescricao    { get; set; }
        public DateTime ZmepDataLanc                    { get; set; }
        [StringLength(1)]
        public string ZmepCentroImputado { get; set; }
        public bool MaterialBloqueado { get; set; }
        public string MaterialSubstituto { get; set; }



































    }
}