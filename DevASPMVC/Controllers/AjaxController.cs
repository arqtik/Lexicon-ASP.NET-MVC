using DevASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            return PartialView("_PeoplePartial", PeopleRepository.AllPeople);
        }
        
        
    }
}