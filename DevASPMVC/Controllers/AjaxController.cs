using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}