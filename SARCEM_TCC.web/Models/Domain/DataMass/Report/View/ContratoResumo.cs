using System;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    public class ContratoResumo
    {
        public string       ContratoNumero              { get; set; }
        public decimal?     ItemDoContratoQtdeDisp      { get; set; }
        public decimal?     PercentualConsumidoContrato { get; set; }
        public decimal?     ContratoValGlPendEmReal     { get; set; } // Saldo convertido em R$
        public DateTime?    ContratoFimValidade         { get; set; }
        public string       FornecedorNome              { get; set; }
    }
}