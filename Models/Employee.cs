using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        
        [Required]
        public int Salary { get; set; }

        public int DepID { get; set; }

        public virtual User User { get; set; }

        public virtual Department Department { get; set; }
    }
}