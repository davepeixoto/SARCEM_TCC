using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Familias")]
    public class Familia
    {
        public int FamiliaID { get; set; }
        public string  FamiliaNome { get; set; }
        public string UsuarioLogisticaID { get; set; }
        public long EmpresaID { get; set; }

        public virtual UsuarioLogistica UsuarioLogisticas { get; set; }
        public virtual Empresa Empresa { get; set; }

        public virtual List<Material> Materiais { get; set; }
    }
}