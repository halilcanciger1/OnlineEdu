using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("SocialMedia");
            return View(values);
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync($"SocialMedia/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            await _client.PostAsJsonAsync("SocialMedia", createSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSocialMediaDto>($"SocialMedia/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _client.PutAsJsonAsync("SocialMedia", updateSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
