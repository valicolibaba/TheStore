using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenericError()
        {
            return View();
        }
    }
}