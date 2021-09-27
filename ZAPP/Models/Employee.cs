using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAPP.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Display(Name = "Naam")]
        public string Name { get; set; }    

        public ICollection<Visit>Visit { get; set; }
    }
}
