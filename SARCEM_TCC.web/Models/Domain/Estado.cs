using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Estados")]
    public class Estado
    {
        public int EstadoID { get; set; }
        public string EstadoNome { get; set; }
        [StringLength(2)]
        public string EstadoSiga { get; set; }
        public int PaisID { get; set; }

        public virtual Pais Pais { get; set; }

        public virtual List<Cidade> Cidades { get; set; }
    }
}