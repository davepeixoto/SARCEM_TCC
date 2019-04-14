using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using Dapper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers

{
    [Authorize(Roles = RoleName.Zmep)]
    public class ZmepController : Controller
    {
        private ApplicationDbContext _context;

        // GET: Zmep
        public ActionResult Index()
        {
            _context = new ApplicationDbContext();

            ViewBag.data = string.Format("{0:d}", 
                _context
                .Database
                .Connection
                .Query<DateTime>("select max(ZmepDataLanc) from VZmeps")
                .FirstOrDefault());
            return View();
        }
    }
}