using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [Display(Name = "City Name")]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryID { get; set; }

        public List<Country> AvailableCountries { get; set; }
    }
}
