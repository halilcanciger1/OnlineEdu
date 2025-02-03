using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task CategoryDropdown()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("categories");
            List<SelectListItem> categories = new SelectList(from x in categoryList
                                                             select new SelectListItem
                                                             {
                                                                 Text = x.Name,
                                                                 Value = x.BlogCategoryId.ToString()
                                                             }).ToList();
            ViewBag.Categories = categories;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View();
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync("blogs/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await CategoryDropdown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            await _client.PostAsJsonAsync("blogs", createBlogDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            await _client.PutAsJsonAsync("blogs", updateBlogDto);
            return RedirectToAction("Index");
        }
    }
}
