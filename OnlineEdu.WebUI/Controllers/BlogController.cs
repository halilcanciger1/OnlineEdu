using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.DTOs.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscriber(CreateSubscriberDto createSubscriberDto)

        {
            await _client.PostAsJsonAsync("subscriber", createSubscriberDto);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> BlogDetails(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultBlogDto>($"blogs/{id}");
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> BlogsByCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<List<ResultAboutDto>>("blogs/GetBlogsByCategoryId" + id);
            return View(value);
        }
    }
}
