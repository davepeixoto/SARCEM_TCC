using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class DiretoriaConfig : EntityTypeConfiguration<Diretoria>
    {

        public DiretoriaConfig()
        {
            ToTable("Diretorias");
        }
        //public int DiretoriaId { get; set; }
        //public string DiretoriaNome { get; set; }
        //public long EmpresaId { get; set; }

        //public virtual Empresa Empresa { get; set; }
        //public virtual List<SubDiretoria> SubDiretorias { get; set; }
        //public virtual List<Cliente> Clientes { get; set; }
        //public virtual List<Appia> Appias { get; set; }
        //public virtual List<Plm> Plms { get; set; }
        //public virtual List<HistoricoPlm> HistoricoPlms { get; set; }
    }
}