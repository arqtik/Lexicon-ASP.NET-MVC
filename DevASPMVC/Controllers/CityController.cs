using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
                Cities = _context.Cities.ToList(),
                CreateCity = new CreateCityViewModel { AvailableCountries = _context.Countries.ToList()}
            };

            foreach (var city in cvm.Cities)
            {
                city.Country = _context.Countries.FirstOrDefault(country => country.ID == city.CountryID);
            }

            return View(cvm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Remove(int cityId)
        {
            _context.Cities.Remove(_context.Cities.FirstOrDefault(c => c.ID == cityId));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CityViewModel cityViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Cities.Add(new City
                {
                    Name = cityViewModel.CreateCity.CityName,
                    CountryID = cityViewModel.CreateCity.CountryID
                });
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int cityId)
        {
            City city = _context.Cities.FirstOrDefault(c => c.ID == cityId);

            EditCityViewModel editCityViewModel = new EditCityViewModel
            {
                City = city,
                AvailableCountries = _context.Countries.ToList()
            };

            return View(editCityViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCityViewModel editCityViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Cities.Update(editCityViewModel.City);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
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
