using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class CoberturaDropDownDTO
    {
        public string Empresa           { get; set; }
        public string Material          { get; set; }
        public string MgCodeCodigoSap   { get; set; }
        public string Statuss            { get; set; }
    }

    public class CoberturaDropDownDTORst
    {
        public List<string> Empresas         { get; set; }
        public List<string> Materiais        { get; set; }
        public List<string> MgCodeCodigosSap { get; set; }
        public List<string> Status          { get; set; }

    }
}