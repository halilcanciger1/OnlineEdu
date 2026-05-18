using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeTeacherComponent(IUserService userService) : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await userService.Get4TeachersAsync();
            return View(values);
        }
    }
}
