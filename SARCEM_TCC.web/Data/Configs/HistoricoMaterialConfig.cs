using SARCEM_TCC.web.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class HistoricoMaterialConfig : EntityTypeConfiguration<HistoricoMaterial>
    {
        public HistoricoMaterialConfig()
        {
            ToTable("HistoricoMateriais");

            Property(r => r.UsuarioLogisticaID)
                .HasMaxLength(128);


            Property(t => t.Id)
    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



        }

        //public int Id { get; set; }
        //public string HistMatInformacoes { get; set; }

        //public DateTime HistMatDataLanc { get; set; }
        //public int MaterialId { get; set; }
        //public string UsuarioLogisticaId { get; set; }

        //public virtual Material Materiais { get; set; }
        //public virtual  Logistica UsuarioLogisticas { get; set; }

    }
}