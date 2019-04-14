using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class GiroConfig : EntityTypeConfiguration<Giro>
    {
        public GiroConfig()
        {
            ToTable("Giros");
        }
       // public Guid Id                {get; set;}
       //public int CentroLogisticoId {get; set;}
       //public int MaterialId        {get; set;}
       //public decimal giroConsQtde      {get; set;}
       //public decimal giroConsValor { get; set;}
       //public decimal giroEstqQtde      {get; set;}
       //public decimal giroEstqValor { get; set;}
       //public int giroEquivalente   {get; set;}
       //public long giroPeriodo       {get; set;}
       //public int ClassificacaoId   {get; set;}

       //public virtual CentroLogistico CentroLogistico { get; set; }
       // public virtual Material Material { get; set; }
       // public virtual Classificacao Classificacao { get; set;}

}
}