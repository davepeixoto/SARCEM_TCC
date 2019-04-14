using SARCEM_TCC.web.Models.Domain.DataMass;
using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("CentroLogisticos")]
    public class CentroLogistico
    {
        public int CentroLogisticoID { get; set; }
        public string CentroLogisticoCodSap { get; set; }
        public string CentroLogisticoNome { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public int CidadeID { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual List<Ajuste2015> Ajuste2015 { get; set; }
        public virtual List<Estoque> Estoques { get; set; }
        public virtual List<Mb51> Mb51s { get; set; }
        public virtual List<Mb52> Mb52s { get; set; }
        public virtual List<Me2m> Me2mOrigem { get; set; }
        public virtual List<Me2m> Me2mRecebedor { get; set; }
        public virtual List<Mm60> Mm60s { get; set; }
        public virtual List<Nb> Nbs { get; set; }
        public virtual List<Plm> Plms { get; set; }
       
        public virtual List<HistoricoPlm> HistoricoPlms { get; set; }
        public virtual List<Reserva> Reservas { get; set; }
        public virtual List<Zmov> Zmovs { get; set; }
        public virtual List<Zpi04> Zpi04s { get; set; }
        public virtual List<BaseGiro> BaseGiros { get; set; }
        public virtual List<Giro> Giros { get; set; }
       

        public virtual List<ItemPedidoDeCompra> ItemPedidoDeCompras { get; set; }

    }
}