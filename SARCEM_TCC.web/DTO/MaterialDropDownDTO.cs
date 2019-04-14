using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class MaterialDropDownDTO: F0b1DropDownDTO
    {
        public string Empresa { get; set; }      




    }

    public class MaterialDropDownDTORst: F0b1DropDownDTORst
    {
        public List<string> Empresas { get; set; }
    }

}