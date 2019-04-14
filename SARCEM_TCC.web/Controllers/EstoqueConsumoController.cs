using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using Dapper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    [Authorize(Roles = RoleName.EstoqueConsumo)]
    public class EstoqueConsumoController : Controller
    {
        private ApplicationDbContext _context;
        // GET: EstoqueConsumo
        public ActionResult Index()
        {
            _context = new ApplicationDbContext();

            ViewBag.data = string.Format("{0:d}", _context.Database.Connection.Query<DateTime>("select max(DataLanc) from VEstoqueConsumoAtuais").FirstOrDefault());

            return View();
        }

        public ActionResult EstoqueTop10()
        {
            return View();
        }
    }
}