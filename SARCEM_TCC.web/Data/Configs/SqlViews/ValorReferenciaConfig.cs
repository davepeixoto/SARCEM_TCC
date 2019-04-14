using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs.SqlViews
{
    public class ValorReferenciaConfig : EntityTypeConfiguration<ValorReferencia>
    {
        public ValorReferenciaConfig()
        {
            ToTable("ValorReferencias");
            HasKey(c => c.MaterialID);
            


        }
        //[Key]
        //public Guid Id { get; set; }
        //public long EmpresaId { get; set; }
        //public int MaterialId { get; set; }
        //public int FamiliaId { get; set; }
        //public int MGCodeId { get; set; }
        //public string   EmpresaNome         { get; set; }
        //[StringLength(10)]
        //public string MaterialCodSap { get; set; }
        //public string   MaterialDescricao   { get; set; }
        //[StringLength(5)]
        //public string MaterialUM { get; set; }
        //[StringLength(2)]
        //public string MaterialClasse    { get; set; }
        //public string ClassificacaoNome { get; set; }
        //public string FamiliaNome       { get; set; }
        //[StringLength(10)]
        //public string   MGCodeCodigoSap       { get; set; }
        //public string   MGCodeDescricao       { get; set; }
        //public string   UserName              { get; set; }
        //public decimal  ValorDeReferencia { get; set; }
        //[StringLength(30)]
        //public string Origem { get; set; }


    }
}