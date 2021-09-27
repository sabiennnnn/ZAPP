using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAPP.Models
{
    public class Visit
    {
        public int VisitID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

        public int TaskID { get; set; }

        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime VisitDate { get; set; }

        [Display(Name = "Voltooid")]
        public bool VisitDone { get; set; }

        //Navigation Properties

        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Task> Task { get; set; }

    }

    
}
