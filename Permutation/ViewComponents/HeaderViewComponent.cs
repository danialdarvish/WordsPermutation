using Microsoft.AspNetCore.Mvc;

namespace Permutation.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
