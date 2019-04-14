using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using Dapper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    [Authorize(Roles = RoleName.EstoqueHistorico)]
    public class EstoqueHistoricoController : Controller
    {
        // GET: EstoqueHistorico
        public ActionResult Index()
        {
         var   _context = new ApplicationDbContext();

            var data = (_context.Database.Connection.Query<DateTime>("select max(DataLanc) from VEstoqueHistoricos").FirstOrDefault()).AddMonths(-1);
            ViewBag.labeldata = string.Format("{0:MMMM-yyyy}", data);
            ViewBag.data= string.Format("{0:yyyy-MM-dd}", data);
            return View();
            
        }
    }
}