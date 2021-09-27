using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAPP.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public int VisitID { get; set; } // Foreign Key

        [Display(Name = "Taak")]
        public string Title { get; set; }

        [Display(Name = "Opmerking")]
        public string Description { get; set; }
        public bool Status { get; set; }

        public Visit Visit { get; set; }
    }
}
