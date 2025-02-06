using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.MessageDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMessageDto>>("message");
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _client.DeleteAsync($"message/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetailMessage(int id)
        {
            var values = await _client.GetFromJsonAsync<ResultMessageDto>($"message/{id}");
            return View(values);
        }
    }
}
