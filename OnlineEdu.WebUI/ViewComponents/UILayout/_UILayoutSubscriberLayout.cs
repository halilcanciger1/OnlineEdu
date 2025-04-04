using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
    public class _UILayoutSubscriberLayout : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    
}
