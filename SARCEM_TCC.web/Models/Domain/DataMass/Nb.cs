using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Nbs")]
    public class Nb
    {
        public int NbID { get; set; }
        public int? MaterialID { get; set; }
        public int? CentroLogisticoID { get; set; }

        public virtual Material Material { get; set; }
        public virtual CentroLogistico CentroLogistico { get; set; }
    }
}