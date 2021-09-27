using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAPP.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Straat")]
        public string Street { get; set; }
        [Required]
        [MaxLength(6)]
        [Display(Name = "Postcode")]
        public string ZipCode { get; set; }
        [Required]
        [Display(Name = "Woonplaats")]
        public string City { get; set; }

        public ICollection<Visit> Visit { get; set; }
    }
}
