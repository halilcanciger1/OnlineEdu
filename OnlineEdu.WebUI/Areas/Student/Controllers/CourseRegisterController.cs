using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.DTOs.CourseRegisterDtos;
using OnlineEdu.WebUI.DTOs.CourseVideoDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CourseRegisterController(ITokenService _tokenService) : Controller
    {
        private readonly HttpClient client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId; 

            var values = await client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegisters/GetMyCourses/" + userId);

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

            var userId = _tokenService.GetUserId;
            createCourseRegisterDto.AppUserId = userId;

            var response = await client.PostAsJsonAsync("courseRegisters", createCourseRegisterDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createCourseRegisterDto);

        }
        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await client.GetFromJsonAsync<List<ResultCourseVideoDto>>("courseVideos/GetCourseVideosByCourseId/" + id);

            ViewBag.courseName = values.Select(x => x.Course.CourseName).FirstOrDefault();
            return View(values);
        }

    }
}
