using System;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report
{
    public class ReportDesviosBase
    {

        public int          Id                      { get; set; }
        public int          EmpresaID               { get; set; }
        public string       EmpresaNome             { get; set; }
        public int          MatId                   { get; set; }
        public string       MaterialCodSap          { get; set; }
        public int          FamiliaID               { get; set; }
        public string       FamiliaNome             { get; set; }
        public decimal      ConsumoQtde             { get; set; }
        public decimal      ConsumoValor            { get; set; }
        public decimal      EstoqueQtde             { get; set; }
        public decimal      EstoqueValor            { get; set; }
        public decimal      EntradaQtde             { get; set; }
        public decimal      EntradaValor            { get; set; }
        public decimal      PlmQtde                 { get; set; }
        public decimal      PlmValor                { get; set; }
        public decimal      AppiaQtde               { get; set; }
        public decimal      AppiaValor              { get; set; }
        public long         Periodo                 { get; set; }
        public int          Equivalente             { get; set; }
        public DateTime?    DataLanc                { get; set; }

    }
}