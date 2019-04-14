using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain
{
    public  class Usuario: ApplicationUser
    {
        public string UserBR { get; set; }

        public long EmpresaID { get; set; }
      
        public virtual Empresa Empresa { get; set; }

    }
  
}