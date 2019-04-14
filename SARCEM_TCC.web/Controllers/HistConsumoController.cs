using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using Dapper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    [Authorize(Roles = RoleName.Cpm)]
    public class HistConsumoController : Controller
    {
        private ApplicationDbContext _context;
       
        // GET: HistConsumo
        public ActionResult Index()
        {
            _context = new ApplicationDbContext();

            ViewBag.data = string.Format("{0:MMMM-yyyy}", (_context.Database.Connection.Query<DateTime>("SELECT MAX(DataLanc) FROM VCpmMaterialReports").FirstOrDefault()).AddMonths(-1));
            return View();
        }
    }
}