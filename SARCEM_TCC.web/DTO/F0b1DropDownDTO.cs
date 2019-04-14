using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class F0b1DropDownDTO
    {

        public string Gestor { get; set; }
        public string Familia { get; set; }
        public string Material { get; set; }

    }

    public class F0b1DropDownDTORst
    {
        public List<string> Gestores { get; set; }
        public List<string> Familias { get; set; }
        public List<string> Materiais { get; set; }
    }

}