using SARCEM_TCC.web.Models.Domain.DataMass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain
{
    public class DemandaPlm:Plm
    {
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        [StringLength(4)]
        public string CentroLogisticoCodSap { get; set; }
        public DateTime DataParaAtendimento { get; set; }
    }
}