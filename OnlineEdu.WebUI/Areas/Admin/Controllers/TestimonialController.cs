using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TestimonialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonial");
            return View(values);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _client.DeleteAsync($"testimonial/{id}");
            return RedirectToAction(nameof(Index));
        }


        public IActionResult CreateTestimonial()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createtestimonialDto)
        {
            await _client.PostAsJsonAsync("testimonial", createtestimonialDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateTestimonialDto>($"testimonial/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Updatetestimonial(UpdateTestimonialDto updatetestimonialDto)
        {
            await _client.PutAsJsonAsync("testimonial", updatetestimonialDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
