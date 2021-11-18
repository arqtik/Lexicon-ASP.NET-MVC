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

        [HttpPost]
        public IActionResult GetPersonById(int id)
        {
            Person person = PeopleRepository.AllPeople.FirstOrDefault(p => p.ID == id);
            List<Person> people = new List<Person>();
            if (person != null)
            {
                people.Add(person);
            }
            return PartialView("_PeoplePartial", people);
        }

        [HttpPost]
        public IActionResult RemovePersonById(int id)
        {
            if (PeopleRepository.AllPeople.Exists(p => p.ID == id))
            {
                PeopleRepository.RemovePerson(id);
                
                return StatusCode(200);
            }

            return StatusCode(404);
        }
    }
}