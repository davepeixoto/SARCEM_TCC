using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class ContratoDropDownDTO:MaterialDropDownDTO
    {
        
        public string Contrato { get; set; }
        public string Fornecedor { get; set; }
        
    }

    public class ContratoDropDownDTORst:MaterialDropDownDTORst
    {
        
        public List<string> Contratos { get; set; }
        public List<string> Fornecedores { get; set; }
       
    }
}