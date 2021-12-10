using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            CountryViewModel cvm = new CountryViewModel(){
                Countries = _context.Countries
            };

            return View(cvm);
        }

        [HttpGet]
        public IActionResult Remove(int countryId)
        {
            _context.Countries.Remove(_context.Countries.FirstOrDefault(c => c.ID == countryId));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(new Country
                {
                    Name = countryViewModel.CreateCountry.CountryName
                });
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int countryId)
        {
            Country country = _context.Countries.FirstOrDefault(c => c.ID == countryId);

            return View(country);
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(country);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}