using System;
using System.Collections.Generic;
using System.Linq;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevASPMVC.Controllers
{
    public class ReactController : Controller
    {
        private readonly AppDbContext _context;

        public ReactController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult People()
        {
            return Json(_context.People);
        }

        [HttpGet]
        public IActionResult Person(int id)
        {
            Person person = _context.People
                .Where(p => p.ID == id)
                .Include(p => p.City)
                .Include(p => p.Languages)
                .FirstOrDefault();

            if (person != null)
            {
                foreach (PersonLanguage personLanguage in person.Languages)
                {
                    personLanguage.Language = _context.Languages.Find(personLanguage.LanguageID);
                }

            }
            
            return Json(person);
        }

        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            _context.People.Remove(_context.People.Find(id));
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetCitiesInCountry(int id)
        {
            List<City> cities = _context.Cities.Where(city => city.CountryID == id).ToList();
            
            return Json(cities);
        }

        [HttpGet]
        public IActionResult GetFormData()
        {
            var data = new
            {
                genders = Enum.GetNames(typeof(Gender)),
                countries = _context.Countries.ToList(),
                cities = _context.Cities.ToList()
            };
            
            return Json(data);
        }
        

        [HttpPut]
        public IActionResult CreatePerson(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(new Person()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    CityID = person.CityID,
                    Email = person.Email
                });
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}