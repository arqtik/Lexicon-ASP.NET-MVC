using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class PeopleViewModel
    {
        public IEnumerable<Person> People { get; set; }
        
        [DataType(DataType.Text)]
        public string SearchString { get; set; }
        
        public CreatePersonViewModel CreatePerson { get; set; }
    }
}