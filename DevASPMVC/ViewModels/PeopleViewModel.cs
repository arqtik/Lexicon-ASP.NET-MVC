using System.Collections.Generic;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class PeopleViewModel
    {
        public IEnumerable<Person> People { get; set; }
    }
}