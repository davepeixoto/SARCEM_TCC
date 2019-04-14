using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("VContratos")]
    public class VContrato
    {
        public Guid Id { get; set; }
        public int MaterialId { get; set; }
        public string       EmpresaNome                         { get; set; }
        public string       ContratoNumero                      { get; set; }
        public int          ItemDoContratoItm                   { get; set; }
        public string MaterialCodSap { get; set; }
        public string       MaterialDescricao                   { get; set; }
        public string       FamiliaNome                         { get; set; }
        public string       UserName                            { get; set; }
        public DateTime?    ContratoDataDoc                     { get; set; }
        public DateTime?    ContratoIniPrazo                    { get; set; }
        public DateTime?    ContratoFimValidade                 { get; set; }
        public string       VigenciaMenorQue6Meses              { get; set; }
        public string       CentroLogisticoCodSap               { get; set; }
        public decimal?     ItemDoContratoQtdeContrato          { get; set; }
        public decimal?     ItemDoContratoQtdeDisp              { get; set; }
        public decimal?     PercentualConsumidoMaterial         { get; set; }
        public string       MaisDe75PercentDoItemConsumido      { get; set; }
        public string       BaseCotacaoSigla                    { get; set; }
        public decimal?     BaseCotacaoValor                    { get; set; }
        public decimal?     ContratoValFixado                   { get; set; } // Valor total do contrato
        public decimal?     ContratoValGlPend                   { get; set; } // Saldo total do contrato disponível
        public decimal?     ContratoValGlPendEmReal             { get; set; } // Saldo convertido em R$
        public decimal?     PercentualConsumidoContrato         { get; set; }
        public string       MaisDe75PercentDoContratoConsumido  { get; set; }
        public string       FornecedorNome                      { get; set; }
        public decimal?     ValorDeReferencia                   { get; set; } // Valor referente ao valor unitário dividido pela grandeza
        public DateTime?    ContratoDataAlteracao { get; set; }
        public string       StatusDoContrato                    { get; set; }
        public bool MaterialBloqueado { get; set; }
        public string MaterialSubstituto { get; set; }

    }
}