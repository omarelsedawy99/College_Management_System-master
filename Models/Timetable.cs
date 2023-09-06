using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Timetable
    {
        public Timetable()
        {
            Lectures = new HashSet<Lecture>();
        }

        [Key]
        public int TimetableID { get; set; }

        public int MajorDepID { get; set; }

        public int MinorDepID { get; set; }

        public int Lvl { get; set; }

        public virtual Level Level { get; set; }

        public virtual Department MajorDepartment { get; set; }

        public virtual Department MinorDepartment { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}