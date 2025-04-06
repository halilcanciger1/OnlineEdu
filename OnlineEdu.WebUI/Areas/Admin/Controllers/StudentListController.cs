using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentListController(UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var students = await userManager.GetUsersInRoleAsync("Student");
            return View(students);
        }
    }
}
