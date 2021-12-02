using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
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
    }
}