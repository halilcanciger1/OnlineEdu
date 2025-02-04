using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategory");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"courseCategory/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCourseCategory()
        {
            return View();
        }

        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto createCourseCategoryDto)
        {
            await _client.PostAsJsonAsync("courseCategory", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"courseCategory/{id}");
            return View(values);
        }

        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _client.PutAsJsonAsync("courseCategory", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
