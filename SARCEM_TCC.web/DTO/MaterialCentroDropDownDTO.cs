using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class MaterialCentroDropDownDTO:MaterialDropDownDTO
    {
        public string Centro { get; set; }
    }

    public class MaterialCentroDropDownDTORst : MaterialDropDownDTORst
    {
        public List<string> Centros { get; set; }
        
    }



}