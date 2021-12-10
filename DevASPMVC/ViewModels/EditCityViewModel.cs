using System;
using System.Collections.Generic;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class EditCityViewModel
    {
        public City City { get; set; }
        public List<Country> AvailableCountries { get; set; }
    }
}
