using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Lecture
    {
        [Key]
        public int LectureID { get; set; }
        
        public int TimetableID { get; set; }

        public string Day { get; set; }

        public TimeSpan Time { get; set; }

        public virtual Course Course { get; set; }

        public virtual Timetable Timetable { get; set; }
    }
}