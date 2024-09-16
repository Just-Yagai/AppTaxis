using Microsoft.AspNetCore.Mvc;

namespace proTaxi.Api.Controllers
{
    public class DeparmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
