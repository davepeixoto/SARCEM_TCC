using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Cecos")]
    public class Ceco
    {

        public long CecoID { get; set; }
        [StringLength(10)]
        public string CecoCodSap { get; set; }
        [StringLength(10)]
        public string CecoSigla { get; set; }
        public string CecoGerencia { get; set; }
        public string CecoDescricao { get; set; }
        public long? EmpresaID { get; set; }
        public string CecoProjeto { get; set; }


        public virtual Empresa Empresa { get; set; }
        public virtual List<Ordem> Ordens { get; set; }
        public virtual List<Reserva> Reservas { get; set; }

    }
}