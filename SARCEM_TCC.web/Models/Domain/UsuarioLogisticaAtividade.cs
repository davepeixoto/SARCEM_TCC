using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain
{
        [Table("UsuarioLogisticaAtividades")]
    public class UsuarioLogisticaAtividade
    {
        public int UsuarioLogisticaAtividadeID { get; set; }
        public string UsuarioLogisticaAtividadeNome { get; set; }

        public virtual List<UsuarioLogistica> UsuarioLogisticas { get; set; }
    }
}