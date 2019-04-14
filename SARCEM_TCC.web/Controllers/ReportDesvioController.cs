using SARCEM_TCC.web.Data.Context;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    public class ReportDesvioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportDesvioController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ReportDesvio

        public ActionResult Index()
        {


            return View();

        }


    }
}