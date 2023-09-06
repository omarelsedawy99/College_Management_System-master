using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Courses = new HashSet<Course>();
            Assignments = new HashSet<Assignment>();
        }

        [Key]
        public int DoctorID { get; set; }

        public int DepID { get; set; }

        [Required]
        public int Salary { get; set; }

        public virtual User User { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}