using SARCEM_TCC.web.Models.Domain.DataMass.Report.TempTable;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class GiroFechamentoMensalConfig : EntityTypeConfiguration<GiroFechamentoMensal>
   {
        public GiroFechamentoMensalConfig()
        {
            ToTable("GiroFechamentosMensais");


            HasKey(c => c.GiroID);

            Property(c => c.ClassificacaoNome).HasMaxLength(20);

            Property(c => c.TipoDoCentro).HasMaxLength(30);

            Property(c => c.Adm).HasMaxLength(2);

        }
        //[Key]
 //ClassificacaoN        public Guid GiroId { get; set; }
 //       public long EmpresaId { get; set; }
 //       public int CentroLogisticoId { get; set; }
 //       public int MaterialId { get; set; }
 //       public int ClassificacaoId { get; set; }
 //       public int FamiliaId { get; set; }
 //       public int MGCodeId { get; set; }
 //       public string UserId { get; set; }
 //       public int GiroEquivalente { get; set; }
 //       public string EmpresaNome { get; set; }
 //       [StringLength(4)]
 //       public string CentroLogisticoCodSap { get; set; }
 //       [StringLength(10)]
 //       public string MaterialCodSap { get; set; }
 //       public string MaterialDescricao { get; set; }
 //       [StringLength(5)]
 //       public string MaterialUM { get; set; }
 //       [StringLength(2)]
 //       public string MaterialClasse { get; set; }
 //       [StringLength(30)]
 //       public stringome { get; set; }
 //       public string FamiliaNome { get; set; }
 //       [StringLength(10)]
 //       public string MGCodeCodigoSap { get; set; }
 //       public string MGCodeDescricao { get; set; }
 //       public string UserName { get; set; }
 //       public decimal GiroConsQtde { get; set; }
 //       public decimal GiroConsValor { get; set; }
 //       public decimal GiroEstqQtde { get; set; }
 //       public decimal GiroEstqValor { get; set; }
 //       public long GiroPeriodo { get; set; }
 //       public int Ano { get; set; }
 //       public int Mes { get; set; }
 //       [StringLength(20)]
 //       public string TipoDoCentro { get; set; }
 //       [StringLength(1)]
 //       public string Adm { get; set; }
        
    }
}