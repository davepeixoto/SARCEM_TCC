using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class ItemDoContratoConfig : EntityTypeConfiguration<ItemDoContrato>
    {
        public ItemDoContratoConfig()
        {
            ToTable("ItemDoContratos");

            Property(c => c.ItemDoContratoElim).HasMaxLength(10);

            
        }
       
    }
}