using System;
using System.Collections.Generic;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class EditPersonViewModel
    {
        public Person Person { get; set; }
        public int PersonCountryID { get; set; }
        public List<City> Cities { get; set; }
        public List<Country> Countries { get; set; }
    }
}
