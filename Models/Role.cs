using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int RoleID { get; set; }

        [StringLength(20)]
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}