using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Fornecedores")]
    public class Fornecedor
    {

        public long FornecedorID { get; set; }
        public string FornecedorNome { get; set; }

        public virtual List<Contrato> Contratos { get; set; }
        public virtual List<HistoricoDeCompra> HistoricoDeCompras { get; set; }
        public virtual List<Zmep> Zmeps { get; set; }
        public virtual List<Me2m> Me2ms { get; set; }
        public virtual List<PedidoDeCompra> PedidoDeCompras { get; set; }
    }

}