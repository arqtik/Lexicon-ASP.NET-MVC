using System;
using System.ComponentModel.DataAnnotations;

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
