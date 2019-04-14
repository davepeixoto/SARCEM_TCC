using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Appias")]
    public class Appia
    {
        public long AppiaID { get; set; }
        public int? MaterialID { get; set; }
        public int? DiretoriaID { get; set; }


        public int? SubDiretoriaID { get; set; }
        public string AppiaProjeto { get; set; }
        public string AppiaInfoAdicional { get; set; }
        public string AppiaResponsavel { get; set; }
       
        public string UsuarioClienteId { get; set; }
        public decimal? AppiaQuantidade { get; set; }
        public int? AppiaAno { get; set; }
        public System.DateTime? AppiaDataLanc { get; set; }

        public virtual SubDiretoria SubDiretoria { get; set; }
        public virtual Diretoria Diretoria { get; set; }
        public virtual Material Material { get; set; }
        public virtual UsuarioCliente UsuarioClientes { get; set; }
    }
}