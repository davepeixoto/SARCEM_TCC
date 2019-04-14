using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class OrdemConfig : EntityTypeConfiguration<Ordem>
    {
        public OrdemConfig()
        {
            ToTable("Ordens");

            Property(c => c.OrdemCodSap).HasMaxLength(20);

            Property(c => c.OrdemPEP).HasMaxLength(20);
        }
        //public long OrdemId { get; set; }
        //public string OrdemCodSap { get; set; }
        //public string OrdemTexto { get; set; }
        //public string OrdemPEP { get; set; }
        //public long? CecoId { get; set; }
        //public int? SubDiretoriaId { get; set; }
        //public string OrdemProjeto { get; set; }
        //public string OrdemVerba { get; set; }


        //public virtual Ceco Ceco { get; set; }
        //public virtual SubDiretoria SubDiretoria { get; set; }
        //public virtual List<Zmov> Zmovs { get; set; }
        //public virtual List<Mb51> Mb51s { get; set; }
        //public virtual List<Reserva> Reservas { get; set; }
        //public virtual List<Zpi04> Zpi04s { get; set; }


    }
}