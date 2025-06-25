using Microsoft.AspNetCore.Mvc;

namespace AlgorithmatENMMVCCore.Controllers
{
    public class MOController : Controller
    {
        public IActionResult Index()
        {
            return View("MOSearch");
        }
    }
}
