using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Giros")]
    public class Giro
    {
        public Guid Id                {get; set;}
       public int CentroLogisticoID {get; set;}
       public int MaterialID        {get; set;}
       public decimal giroConsQtde      {get; set;}
       public decimal giroConsValor { get; set;}
       public decimal giroEstqQtde      {get; set;}
       public decimal giroEstqValor { get; set;}
       public int giroEquivalente   {get; set;}
       public long giroPeriodo       {get; set;}
       public int ClassificacaoID   {get; set;}

       public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Material Material { get; set; }
        public virtual Classificacao Classificacao { get; set;}

}
}