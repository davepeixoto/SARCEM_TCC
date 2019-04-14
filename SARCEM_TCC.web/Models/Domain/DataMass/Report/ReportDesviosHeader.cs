namespace SARCEM_TCC.web.Models.Domain.DataMass.Report
{
    public class ReportDesviosHeader
    {
        public int      Id              { get; set; }
        public int      EmpresaId		{ get; set; }
        public string   EmpresaNome		{ get; set; }
        public int      MatId			{ get; set; }
        public string   MaterialCodSap	{ get; set; }
        public int      FamiliaId       { get; set; }
        public string   FamiliaNome     { get; set; }
    }
}