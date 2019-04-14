using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Ordens")]
    public class Ordem
    {
        public long OrdemID { get; set; }
        public string OrdemCodSap { get; set; }
        public string OrdemTexto { get; set; }
        public string OrdemPEP { get; set; }
        public long? CecoID { get; set; }
        public int? SubDiretoriaID { get; set; }
        public string OrdemProjeto { get; set; }
        public string OrdemVerba { get; set; }


        public virtual Ceco Ceco { get; set; }
        public virtual SubDiretoria SubDiretoria { get; set; }
        public virtual List<Zmov> Zmovs { get; set; }
        public virtual List<Mb51> Mb51s { get; set; }
        public virtual List<Reserva> Reservas { get; set; }
        public virtual List<Zpi04> Zpi04s { get; set; }


    }
}