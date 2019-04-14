using SARCEM_TCC.web.Models.Domain.DataMass.Report;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class ReportDesviosBaseMap: EntityTypeConfiguration<ReportDesviosBase>
    {
        public ReportDesviosBaseMap()
        {
            ToTable("ReportDesviosBases");

            HasKey(c => c.Id);

            Property(c => c.EmpresaNome).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.MaterialCodSap).HasColumnType("varchar").HasMaxLength(10);
            Property(c => c.FamiliaNome).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.DataLanc).HasColumnType("datetime");

        }
    }
}