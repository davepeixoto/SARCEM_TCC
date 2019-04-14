using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class AppiaDropDownDTO:MaterialDropDownDTO
    {
        
        public string Diretoria { get; set; }
        public string SubDiretoria { get; set; }
    }
    
    public class AppiaDropDownDTORst:MaterialDropDownDTORst
    {
        public List<string> Diretorias { get; set; }
        public List<string> SubDiretorias { get; set; }
    }
}