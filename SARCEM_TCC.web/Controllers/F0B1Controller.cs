using SARCEM_TCC.web.Models;
using System.Web.Mvc;

namespace SARCEM_TCC.web.Controllers
{
    [Authorize(Roles = RoleName.F0b1)]
    public class F0B1Controller : Controller
    {
        // GET: F0B1
       
        public ActionResult Index()
        {
            return View();
        }
    }
}