using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [Display(Name = "Country Name")]
        [MaxLength(100)]
        public string CountryName { get; set; }
    }
}
