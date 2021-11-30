using System.Collections.Generic;
using System.Linq;
using DevASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
    public class AjaxController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AjaxController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            return PartialView("_PeoplePartial", _dbContext.People);
        }

        [HttpPost]
        public IActionResult GetPersonById(int id)
        {
            Person person = _dbContext.People.Find(id);
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
            Person personToRemove = _dbContext.People.Find(id);

            if (personToRemove != null)
            {
                _dbContext.Remove(personToRemove);
                _dbContext.SaveChanges();

                return StatusCode(200);
            }

            return StatusCode(404);
        }
    }
}