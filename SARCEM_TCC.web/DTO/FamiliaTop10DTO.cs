using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.DTO
{
    public class FamiliaTop10DTO
    {
        public string FamiliaNome { get; set; }
        public decimal SapValor { get; set; }
        public decimal ConsumoValor { get; set; }
        public decimal EntradaValor { get; set; }
        public decimal Percentual { get; set; }
    }
}