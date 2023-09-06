using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        [Required]
        public string Path { get; set; }

        [DefaultValue(0)]
        public int Grade { get; set; }

        public bool Status { get; set; }

        public int StudentID { get; set; }

        public int AssignmentID { get; set; }

        public virtual Student Student { get; set; }

        public virtual Assignment Assignment { get; set; }
    }
}