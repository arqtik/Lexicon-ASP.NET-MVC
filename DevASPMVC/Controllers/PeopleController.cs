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
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            PeopleViewModel pvm = new PeopleViewModel();
            pvm.CityViewModel = new CityViewModel() { Cities = _context.Cities.ToList() };

            pvm.People = _context.People.ToList();

            foreach (var person in pvm.People)
            {
                person.City = pvm.CityViewModel.Cities.FirstOrDefault(c => c.ID == person.CityID);
            }

            pvm.CountryViewModel = new CountryViewModel() {
                Countries = _context.Countries
            };
            
            return View(pvm);
        }
        
        [HttpPost]
        public IActionResult Create(PeopleViewModel peopleViewModel)
        {
            CreatePersonViewModel cpvm = peopleViewModel.CreatePerson;

            if (ModelState.IsValid)
            {
                _context.People.Add(
                    new Person()
                    {
                        FirstName = cpvm.FirstName,
                        LastName = cpvm.LastName,
                        Gender = cpvm.Gender,
                        CityID = cpvm.CityID,
                        Email = cpvm.Email
                    }
                );
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int personId)
        {
            Person person = _context.People.FirstOrDefault(p => p.ID == personId);

            EditPersonViewModel editPersonViewModel = new EditPersonViewModel
            {
                Person = person,
                Cities = _context.Cities.ToList(),
                Countries = _context.Countries.ToList(),
                PersonCountryID = _context.Countries.FirstOrDefault(c => c.ID == person.City.CountryID).ID
            };

            return View(editPersonViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditPersonViewModel editPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.People.Update(editPersonViewModel.Person);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveById(int id)
        {
            _context.People.Remove(_context.People.Find(id));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            PeopleViewModel pvm = new PeopleViewModel();
            
            if (ModelState.IsValid && !string.IsNullOrEmpty(peopleViewModel.SearchString))
            {
                string search = peopleViewModel.SearchString;
                pvm.People = _context.People.Where(
                    p => p.FirstName.Contains(search) ||
                         p.LastName.Contains(search) ||
                         p.City.Name.Contains(search)
                ).ToList();
            }
            
            return View("Index", pvm);
        }
    }
}