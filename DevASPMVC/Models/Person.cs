using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevASPMVC.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int CityID { get; set; }
        public City City { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        public List<PersonLanguage> Languages { get; set; }
    }
}