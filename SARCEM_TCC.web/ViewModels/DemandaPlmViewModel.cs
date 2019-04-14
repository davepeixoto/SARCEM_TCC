using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.ViewModels
{
    public class DemandaPlmViewModel
    {

        [Required(ErrorMessage = "...")]
        [Display(Name = "Dados a serem carregados.")]
        public string Clipboard { get; set; }
    }
}