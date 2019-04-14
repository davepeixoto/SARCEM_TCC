using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Zpi04s")]
    public class Zpi04
    {
        public long Zpi04ID { get; set; }
        public string Zpi04DocumentoDeVendas { get; set; }
        public System.DateTime? Zpi04DataCriacao { get; set; }
        public string Zpi04CentroDeCusto { get; set; }
        public int? Zpi04Posicao { get; set; }
        public int? MaterialID { get; set; }
        public decimal? Zpi04QuantidadeSolicitad { get; set; }
        public decimal? Zpi04QuantidadDespachada { get; set; }
        public decimal? Zpi04QuantidadeDeclive { get; set; }
        public System.DateTime? Zpi04DataDespacho { get; set; }
        public string Zpi04GuiaDespacho { get; set; }
        public string Zpi04NumeroEntrega { get; set; }
        public int? CentroLogisticoID { get; set; }
        [ForeignKey("Ordem")]
        public long? OrdemID { get; set; }
        public int? Zpi04CodContratista { get; set; }
        public string Zpi04MaiorAlocacaoConta { get; set; }
        public string Zpi04UsuarioDigitador { get; set; }
        public string Zpi04NumeroDoProjeto { get; set; }
        public decimal? Zpi04QuantiaEntregue { get; set; }
        public string Zpi04Moeda { get; set; }
        public decimal? Zpi04ValorUnitario { get; set; }
        public int? Zpi04Periodo { get; set; }
        public int? Zpi04Equivalente { get; set; }
        public string Zpi04Expurgado { get; set; }
        public System.DateTime? Zpi04DataLanc { get; set; }

        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Material Material { get; set; }
        public virtual Ordem Ordem { get; set; }

        
    }
}