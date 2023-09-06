using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class UserPicture
    {
        [Key]
        public int PictureID { get; set; }

        [Required]
        public string Path { get; set; }
        
        public virtual User User { get; set; }
    }
}