using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            Answers = new HashSet<Answer>();
        }

        [Key]
        public int AssignmentID { get; set; }

        public int CourseID { get; set; }

        public int DoctorID { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public string FilePath { get; set; }

        public virtual Course Course { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}