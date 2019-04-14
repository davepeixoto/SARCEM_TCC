using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    public class CobeturaController : Controller
    {
        private ApplicationDbContext _context;
        // GET: PlmCobetura
        [Authorize(Roles = RoleName.Brazil)]
        public ActionResult Index()
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