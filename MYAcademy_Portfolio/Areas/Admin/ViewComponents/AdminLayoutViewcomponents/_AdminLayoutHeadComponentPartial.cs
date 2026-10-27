using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_Portfolio.Areas.Admin.ViewComponents.AdminLayoutViewcomponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
