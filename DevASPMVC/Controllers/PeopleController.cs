using System.Collections.Generic;
using System.Linq;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevASPMVC.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class PeopleController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PeopleController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            PeopleViewModel pvm = new PeopleViewModel();
            pvm.CityViewModel = new CityViewModel() { Cities = _dbContext.Cities.ToList() };

            pvm.People = _dbContext.People.ToList();

            foreach (var person in pvm.People)
            {
                person.City = pvm.CityViewModel.Cities.FirstOrDefault(c => c.ID == person.CityID);
            }

            pvm.CountryViewModel = new CountryViewModel() {
                Countries = _dbContext.Countries
            };
            
            return View(pvm);
        }
        
        [HttpPost]
        public IActionResult Create(PeopleViewModel peopleViewModel)
        {
            CreatePersonViewModel cpvm = peopleViewModel.CreatePerson;

            if (ModelState.IsValid)
            {
                _dbContext.People.Add(
                    new Person()
                    {
                        FirstName = cpvm.FirstName,
                        LastName = cpvm.LastName,
                        Gender = cpvm.Gender,
                        CityID = cpvm.CityID,
                        Email = cpvm.Email
                    }
                );
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveById(int id)
        {
            _dbContext.People.Remove(_dbContext.People.Find(id));
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            PeopleViewModel pvm = new PeopleViewModel();
            
            if (ModelState.IsValid && !string.IsNullOrEmpty(peopleViewModel.SearchString))
            {
                string search = peopleViewModel.SearchString;
                pvm.People = _dbContext.People.Where(
                    p => p.FirstName.Contains(search) ||
                         p.LastName.Contains(search) ||
                         p.City.Name.Contains(search)
                ).ToList();
            }
            
            return View("Index", pvm);
        }
    }
}