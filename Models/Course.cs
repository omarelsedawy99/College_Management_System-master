using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Course
    {
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int CourseID { get; set; }

        public int DoctorID { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        public int DepID { get; set; }

        [Required, DefaultValue(3)]
        public int Credits { get; set; }

        public int Lvl { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Department Department { get; set; }

        public virtual Level Level { get; set; }

        public virtual Course PrerequestCourse { get; set; }

        public virtual Lecture Lecture { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}