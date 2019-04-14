using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class Ajuste2015Config : EntityTypeConfiguration<Ajuste2015>
    {

        public Ajuste2015Config()
        {
            ToTable("Ajuste2015s");
            HasKey(c => c.ID);

            Property(c => c.ID                              ).HasColumnType("int"); //int     
            Property(c => c.CentroLogisticoID               ).HasColumnType("int"); //int     
            Property(c => c.MaterialID                      ).HasColumnType("int"); //int     
            Property(c => c.ClassificacaoID                 ).HasColumnType("int");    //int     
            Property(c => c.Ajuste2015QuantidadeConsumida   ).HasColumnType("money").IsOptional();    //decimal?
            Property(c => c.Ajuste2015MontanteConsumido     ).HasColumnType("money").IsOptional();    //decimal?
            Property(c => c.Ajuste2015QuantidadeEmEstoque   ).HasColumnType("money").IsOptional();  //decimal?
            Property(c => c.Ajuste2015MontanteEmEstoque     ).HasColumnType("money").IsOptional();  //decimal?
            Property(c => c.Ajuste2015CodigoPeriodo         ).HasColumnType("int").IsOptional();    //int?    
            Property(c => c.Ajuste2015Periodo               ).HasColumnType("int").IsOptional();    //int?    
            Property(c => c.Ajuste2015ADM                   ).HasColumnType("varchar").HasMaxLength(3);    //string  

        }

}

}

/*
public int      ID                              
public int      CentroLogisticoID               
public int      MaterialID                      
public int      ClassificacaoID                 
public decimal? Ajuste2015QuantidadeConsumida   
public decimal? Ajuste2015MontanteConsumido     
public decimal? Ajuste2015QuantidadeEmEstoque   
public decimal? Ajuste2015MontanteEmEstoque     
public int?     Ajuste2015CodigoPeriodo             
public int?     Ajuste2015Periodo                   
public string   Ajuste2015ADM                     

public virtual CentroLogistico CentroLogistico 
public virtual Material Material 
public virtual Classificacao Classificacao 

    */