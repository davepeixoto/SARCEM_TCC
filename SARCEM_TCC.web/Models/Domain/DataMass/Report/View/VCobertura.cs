using SARCEM_TCC.web.DTO;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    public class VCobertura
    {
        public int              MaterialID              { get; set; }
        public long             EmpresaID               { get; set; }
        public string           EmpresaNome             { get; set; }
        public string           MaterialCodSap          { get; set; }
        public string           MaterialDescricao       { get; set; }
        public string           MGCodeCodigoSap         { get; set; }
        public decimal          FisicoQtde              { get; set; }
        public decimal          ZmepCorte               { get; set; }
        public int              QtdeDeContratos         { get; set; }
        public decimal          ItemDoContratoQtdeDisp  { get; set; }
        public decimal          EstimativaMensal        { get; set; }
        public decimal          Autonomia               { get; set; } 
        public decimal          AutonomiaODC            { get; set; }
        public decimal          AutonomiaODCContrato    { get; set; }
        public CoberturaEnum    Statuss                 { get; set; }
       
    }
}


