using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Level
    {
        public Level()
        {
            Students = new HashSet<Student>();
            Courses = new HashSet<Course>();
            Timetables = new HashSet<Timetable>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int level { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}