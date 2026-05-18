using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogSubscriberComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
