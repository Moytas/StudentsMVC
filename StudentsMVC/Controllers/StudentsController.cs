using Microsoft.AspNetCore.Mvc;

namespace StudentsMVC.Controllers
{
  public class StudentsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult StudentList()
    {
      return View();
    }

    public IActionResult StudentInfo(int id)
    {
      ViewBag.ID = id;
      return View();
    }
  }
}
