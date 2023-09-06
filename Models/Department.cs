using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Department
    {
        public Department()
        {
            Doctors = new HashSet<Doctor>();
            Employees = new HashSet<Employee>();
            MajorDepStudents = new HashSet<Student>();
            MinorDepStudents = new HashSet<Student>();
            MajorDepTimetables = new HashSet<Timetable>();
            MinorDepTimetables = new HashSet<Timetable>();
            Courses = new HashSet<Course>();
        }

        [Key]
        public int DepartmentID { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Student> MajorDepStudents { get; set; }

        public virtual ICollection<Student> MinorDepStudents { get; set; }

        public virtual ICollection<Timetable> MajorDepTimetables { get; set; }

        public virtual ICollection<Timetable> MinorDepTimetables { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}