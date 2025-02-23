using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.DTOs.CourseRegisterDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CourseRegisterController(UserManager<AppUser> userManager) : Controller
    {
        private readonly HttpClient client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var values = await client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegisters/GetMyCourses/" + user.Id);

            return View(values);
        }

        public async Task<IActionResult> RegisterCourse()
        {
            var courseList = await client.GetFromJsonAsync<List<ResultCourseDto>>("course");

            List<SelectListItem> courses = (from x in courseList
                                            select new SelectListItem
                                            {
                                                Text = x.CourseName,
                                                Value = x.CourseId.ToString()
                                            }).ToList();
            ViewBag.courses = courses;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> RegisterCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var courseList = await client.GetFromJsonAsync<List<ResultCourseDto>>("course");

            List<SelectListItem> courses = (from x in courseList
                                            select new SelectListItem
                                            {
                                                Text = x.CourseName,
                                                Value = x.CourseId.ToString()
                                            }).ToList();
            ViewBag.courses = courses;

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            createCourseRegisterDto.AppUserId = user.Id;

            var response = await client.PostAsJsonAsync("courseRegisters", createCourseRegisterDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createCourseRegisterDto);

        }
    }
}
