using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Cidades")]
    public class Cidade
    {
        public int CidadeID { get; set; }
        public string CidadeNome { get; set; }
        public int EstadoID { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual List<CentroLogistico> CentroLogisticos { get; set; }
    }
}