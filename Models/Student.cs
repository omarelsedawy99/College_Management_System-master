using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    
    public partial class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
            Answers = new HashSet<Answer>();
        }

        [Key]
        public int StudentID { get; set; }

        public int Lvl { get; set; }

        public int MajorDepID { get; set; }

        public int MinorDepID { get; set; }

        [Required, DefaultValue(false)]
        public bool PaymentStatus { get; set; }

        public virtual User User { get; set; }

        public virtual Level Level { get; set; }

        public virtual Department StudentMajorDepartment { get; set; }

        public virtual Department StudentMinorDepartment { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

    }
}