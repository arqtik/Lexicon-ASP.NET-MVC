﻿using System.Collections.Generic;
using System.Linq;
using DevASPMVC.Models;
using DevASPMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevASPMVC.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            PeopleViewModel pvm = new PeopleViewModel();
            pvm.People = PeopleRepository.AllPeople;
            
            return View(pvm);
        }
        
        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            CreatePersonViewModel cpvm = peopleViewModel.CreatePerson;

            if (ModelState.IsValid)
            {
                PeopleRepository.AllPeople.Add( new Person()
                {
                    FirstName = cpvm.FirstName,
                    LastName = cpvm.LastName,
                    Gender = cpvm.Gender,
                    Address = cpvm.Address,
                    Email = cpvm.Email
                });
            }

            PeopleViewModel pvm = new PeopleViewModel()
            {
                People = PeopleRepository.AllPeople
            };
            
            return View(pvm);
        }

        public IActionResult Remove(Person person)
        {
            return null;
        }

        [HttpGet]
        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            PeopleViewModel pvm = new PeopleViewModel();
            
            if (ModelState.IsValid && !string.IsNullOrEmpty(peopleViewModel.SearchString))
            {
                string search = peopleViewModel.SearchString;
                pvm.People = PeopleRepository.AllPeople.Where(
                    p => p.FirstName.Contains(search) ||
                         p.LastName.Contains(search) ||
                         p.Address.Contains(search)
                ).ToList();
                return View("Index", pvm);
            }
            
            return View("Index", pvm);
        }
    }
}