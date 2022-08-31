using Microsoft.AspNetCore.Mvc;

namespace JongBrabant.Kantinescherm.Controllers
{
    public class OverviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
