using SARCEM_TCC.web.Models.Domain.DataMass;
using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Materiais")]
    public class Material
    {
        public int      MaterialID          { get; set; }
        public string   MaterialCodSap      { get; set; }
        public string   MaterialDescricao   { get; set; }
        public string   MaterialClasse { get; set; }
        public string   MaterialUM          { get; set; }
        public int      ClassificacaoID     { get; set; }
        public int      FamiliaID           { get; set; }
        public int      MGCodeID            { get; set; }
        public DateTime MaterialDataInclusao { get; set; }
        public int?     MaterialSubId { get; set; }
        public bool     MaterialBloqueado { get; set; }

        public virtual Material         MaterialSub     { get; set; }
        public virtual Classificacao    Classificacao   { get; set; }
        public virtual Familia          Familia         { get; set; }
        public virtual MGCode           MGCode          { get; set; }


        public virtual List<Ajuste2015> Ajuste2015 { get; set; }
        public virtual List<Appia> Appias { get; set; }
        public virtual List<Estoque> Estoques { get; set; }
        public virtual List<Mb51> Mb51s { get; set; }
        public virtual List<Mb52> Mb52s { get; set; }
        public virtual List<Me2m> Me2ms { get; set; }
        public virtual List<Mm60> Mm60s { get; set; }
        public virtual List<Nb> Nbs { get; set; }
        public virtual List<Plm> Plms { get; set; }
        public virtual List<Reserva> Reservas { get; set; }
        public virtual List<Zmov> Zmovs { get; set; }
        public virtual List<Zpi04> Zpi04s { get; set; }
        public virtual List<HistoricoDeCompra> HistoricoDeCompras { get; set; }
        public virtual List<BaseGiro> BaseGiros { get; set; }
        public virtual List<Zmep> Zmeps { get; set; }
        public virtual List<ItemDoContrato> ItemDoContratos { get; set; }
        public virtual List<ItemPedidoDeCompra> ItemPedidoDeCompras { get; set; }
        public virtual List<Giro> Giros { get; set; }
        public virtual List<ReferenciaDePreco> ReferenciaDePrecoFromOperacoes { get; set; }
        public virtual List<HistoricoPlm> HistoricoPlms { get; set; }
        public virtual List<HistoricoMaterial> HistoricoMateriais { get; set; }





    }


    
}