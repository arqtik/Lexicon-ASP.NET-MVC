using System;
using System.Collections.Generic;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class CountryViewModel
    {
        public IEnumerable<Country> Countries { get; set; }

        public CreateCountryViewModel CreateCountry { get; set; }
    }
}
