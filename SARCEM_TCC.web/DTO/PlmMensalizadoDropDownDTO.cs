using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class PlmMensalizadoDropDownDTO:MaterialCentroDropDownDTO
    {
        
        public string Diretoria { get; set; }
        public string SubDiretoria { get; set; }


       

    }

    public class PlmMensalizadoDropDownDTORst: MaterialCentroDropDownDTORst
    {
        public List<string> Diretorias { get; set; }
        public List<string> SubDiretorias { get; set; }
    }
}