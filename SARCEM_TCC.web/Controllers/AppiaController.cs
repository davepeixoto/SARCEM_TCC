using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using Dapper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    [Authorize(Roles = RoleName.Appia)]

    public class AppiaController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Appia
        public ActionResult Index()
        {
            _context = new ApplicationDbContext();

            ViewBag.data = string.Format("{0:d}", _context.Database.Connection.Query<DateTime>("select max(AppiaDataLanc) from VAppiaQuerys").FirstOrDefault());


                
            return View();
        }
    }
}