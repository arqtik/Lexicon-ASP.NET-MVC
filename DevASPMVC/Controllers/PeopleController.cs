using System.Collections.Generic;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
    public class PeopleController : Controller
    {
        // GET
        public IActionResult Index()
        {
            PeopleViewModel pvm = new PeopleViewModel()
            {
                People = new List<Person>()
                {
                    new Person()
                    {
                        FirstName = "Mikael",
                        LastName = "Persson",
                        Gender = Gender.Male,
                        Address = "Götagatan 65E 763 21 Stockholm",
                        Email = "mikaelpersson@domain.com"
                    }
                }
            };
            
            return View(pvm);
        }
    }
}