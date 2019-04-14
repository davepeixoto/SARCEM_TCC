using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain
{
    public class BaseCotacao
    {
        public int BaseCotacaoID { get; set; }
        public string BaseCotacaoNome { get; set; }
        public string BaseCotacaoSigla { get; set; }
        public decimal BaseCotacaoValor { get; set; }
        public DateTime BaseCotacaoDataDaCotacao { get; set; }

        public virtual List<PedidoDeCompra> PedidoDeCompras { get; set; }
        public virtual List<Zmep> Zmeps { get; set; }
    }
}