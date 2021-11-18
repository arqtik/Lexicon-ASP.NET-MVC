using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public IActionResult GetPersonById(int id)
        {
            Person person = PeopleRepository.AllPeople.FirstOrDefault(p => p.ID == id);
            return PartialView("_PersonPartial", person);
        }
    }
}