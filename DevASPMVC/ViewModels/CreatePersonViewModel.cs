using System.ComponentModel.DataAnnotations;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Enter first name")]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Enter last name")]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Select gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Select a country")]
        public int CountryID { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Select a city")]
        public int CityID { get; set; }
        
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Enter a valid E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}