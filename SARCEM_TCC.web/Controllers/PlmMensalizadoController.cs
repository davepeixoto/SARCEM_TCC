using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using Dapper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    [Authorize(Roles = RoleName.Plm)]
    public class PlmMensalizadoController : Controller
    {
        private ApplicationDbContext _context;
       // PlmMensalizadoDropDownDTO dto;

        // GET: PlmMensalizado
        public ActionResult Index()
        {
            _context = new ApplicationDbContext();
            ViewBag.data = string.Format("{0:d}", 
                _context
                .Database
                .Connection
                .Query<DateTime>("select max(PlmDataLanc) from VPlmMensalizados")
                .FirstOrDefault());
            return View();
        }

        [Authorize(Roles = RoleName.Brazil)]
        public ActionResult CoberturaPlm()
        {
            _context = new ApplicationDbContext();

            ViewBag.data = string.Format("{0:d}",
                _context
                .Database
                .Connection
                .Query<DateTime>("select max(DataLanc) from VEstoqueConsumoAtuais")
                .FirstOrDefault()); ;

            return View();
        }
       


       
      
    }
}
