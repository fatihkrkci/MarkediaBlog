using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
