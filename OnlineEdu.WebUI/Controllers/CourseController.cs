using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient client = HttpClientInstance.CreateClient();

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var values = await client.GetFromJsonAsync<List<ResultCourseDto>>("course/GetCoursesByCategoryId/" + id);
            var category = (from x in values
                            select x.CourseCategory.Name).FirstOrDefault();
            ViewBag.category = category;
            return View(values);
        }
    }
}
