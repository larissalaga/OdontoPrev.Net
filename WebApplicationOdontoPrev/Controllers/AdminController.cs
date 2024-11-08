using Microsoft.AspNetCore.Mvc;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var model = new AdminViewModel();
            model.Name = "Macaquinho";
            return View(model);
        }
    }
}
