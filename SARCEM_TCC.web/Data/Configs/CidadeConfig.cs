using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class CidadeConfig : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfig()
        {
            ToTable("Cidades");
        }
        //public int CidadeID { get; set; }
        //public string CidadeNome { get; set; }
        //public int EstadoId { get; set; }

        //public virtual Estado Estado { get; set; }

        //public virtual List<CentroLogistico> CentroLogisticos { get; set; }
    }
}