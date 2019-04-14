using System.Collections.Generic;

namespace SARCEM_TCC.web.DTO
{
    public class ZmepDropDownDTO: MaterialDropDownDTO
    {
        public string Pedido        { get; set; }
        public string Fornecedor    { get; set; }
        public string Status        { get; set; }
        public string Mes           { get; set; }
        public string Ano           { get; set; }
        
    }

    public class ZmepDropDownDTORst:MaterialDropDownDTORst
    {
        public List<string> Pedidos { get; set; }
        public List<string> Fornecedores { get; set; }
        public List<string> Statuss { get; set; }
        public List<string> Mess { get; set; }
        public List<string> Anos { get; set; }


    }
}









