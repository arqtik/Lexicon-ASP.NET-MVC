using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevASPMVC.Controllers
{
    public class CityController : Controller
    {
        private readonly AppDbContext _context;

        public CityController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            CityViewModel cvm = new CityViewModel()
            {
                Cities = _context.Cities.ToList()
            };

            foreach (var city in cvm.Cities)
            {
                city.Country = _context.Countries.FirstOrDefault(country => country.ID == city.CountryID);
            }

            return View(cvm);
        }
        

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetCities(int countryId)
        {
            CityViewModel cvm = new CityViewModel()
            {
                Cities = _context.Cities.Where(
                    city => city.CountryID == countryId).ToList()
            };

            return PartialView("_CityOptionsPartial", cvm);
        }
    }
}
