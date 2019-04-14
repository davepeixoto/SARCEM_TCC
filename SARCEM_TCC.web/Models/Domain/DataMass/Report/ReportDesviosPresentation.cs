using System;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report
{
    public class ReportDesviosPresentation
    {
        public int       Id                  { get; set; }
        public int       EmpresaId           { get; set; }
        public string    EmpresaNome         { get; set; }
        public int       MatId               { get; set; }
        public string    MaterialCodSap      { get; set; }
        public int       FamiliaId           { get; set; }
        public string    FamiliaNome         { get; set; }
        public string    Movimento           { get; set; }
        public DateTime? DataLanc            { get; set; }
        public decimal   Month11Before	     { get; set; }
        public decimal   Month10Before	     { get; set; }
        public decimal   Month9Before	     { get; set; }
        public decimal   Month8Before	     { get; set; }
        public decimal   Month7Before	     { get; set; }
        public decimal   Month6Before	     { get; set; }
        public decimal   Month5Before	     { get; set; }
        public decimal   Month4Before	     { get; set; }
        public decimal   Month3Before	     { get; set; }
        public decimal   Month2Before	     { get; set; }
        public decimal   Month1Before	     { get; set; }
        public decimal   MonthCurrent        { get; set; }
    }
}