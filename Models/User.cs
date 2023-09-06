using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class User
    {
        public User()
        {
            ReceivedMails = new HashSet<Mail>();
            SendedMails = new HashSet<Mail>();
        }

        [Key]
        public int UserId { get; set; }

        [Required, Column(TypeName = "char"), StringLength(14), Index(IsUnique = true)]
        public string SSN { get; set; }

        public int RoleID { get; set; }

        [Required, StringLength(60)]
        public string FullName { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required, Column(TypeName = "char"), StringLength(11)]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

        [Required, StringLength(25)]
        public string Street { get; set; }

        [Required, StringLength(15)]
        public string City { get; set; }

        [Required, StringLength(25)]
        public string Country { get; set; }

        public virtual UserPicture UserPicture { get; set; }

        public virtual Role Role { get; set; }

        public virtual Student Student { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Mail> ReceivedMails { get; set; }

        public virtual ICollection<Mail> SendedMails { get; set; }
    }
}