using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("HistoricoMateriais")]
    public class HistoricoMaterial
    {
        public int Id { get; set; }
        public string HistMatInformacoes { get; set; }
        
        public DateTime HistMatDataLanc { get; set; }
        public int MaterialID { get; set; }
        public string UsuarioLogisticaID { get; set; }

        public virtual Material Materiais { get; set; }
        public virtual  UsuarioLogistica UsuarioLogisticas { get; set; }


    }
}