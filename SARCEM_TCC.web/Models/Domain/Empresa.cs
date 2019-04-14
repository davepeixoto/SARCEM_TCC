using SARCEM_TCC.web.Models.Domain.DataMass;
using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Empresas")]
    public class Empresa
    {
        public long EmpresaID { get; set; }
        public string EmpresaNome { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
        public virtual List<Familia> Familias { get; set; }
        public virtual List<Diretoria> Diretorias { get; set; }
        public virtual List<Ceco> Cecos { get; set; }
        public virtual List<BaseGiro> BaseGiros { get; set; }
        public virtual List<PedidoDeCompra> PedidoDeCompras { get; set; }

    }
}