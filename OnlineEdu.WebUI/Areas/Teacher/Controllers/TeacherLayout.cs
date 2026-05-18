using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeacherLayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
