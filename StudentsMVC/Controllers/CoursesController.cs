using Microsoft.AspNetCore.Mvc;

namespace StudentsMVC.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
