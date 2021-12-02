using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevASPMVC.Controllers
{
    public class LanguageController : Controller
    {
        private readonly AppDbContext _context;

        public LanguageController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            LanguageViewModel lvm = new LanguageViewModel()
            {
                Languages = _context.Languages.ToList()
            };

            return View(lvm);
        }

        [HttpGet]
        public IActionResult PeopleByLanguage(int languageId)
        {
            LanguageViewModel lvm = new LanguageViewModel()
            {
                Language = _context.Languages.FirstOrDefault(l => l.ID == languageId),
                People = _context.People.Where(p => p.Languages.Any(l => l.LanguageID == languageId)).ToList()
            };

            return View(lvm);
        }

        [HttpGet]
        public IActionResult PersonLanguage(int personId)
        {
            LanguageViewModel lvm = new LanguageViewModel()
            {
                Person = _context.People.FirstOrDefault(p => p.ID == personId),
                PersonLanguages = _context.Languages.Where(l => l.People.Any(p => p.PersonID == personId)).ToList(),
                Languages = _context.Languages.ToList()
            };

            return View(lvm);
        }

        [HttpPost]
        public IActionResult AddLanguageToPerson(LanguageViewModel languageViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.PersonLanguage.Add(new PersonLanguage()
                {
                    PersonID = languageViewModel.PersonId,
                    LanguageID = languageViewModel.LanguageId
                });

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    
                }
            }

            return RedirectToAction(nameof(PersonLanguage), new { personId = languageViewModel.PersonId });
        }
    }
}
