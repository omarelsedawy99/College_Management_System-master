using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public partial class Mail
    {
        [Key]
        public int MailID { get; set; }

        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public string MailSubject { get; set; }

        public string MailMessage { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public bool Inbox { get; set; }

        [Required]
        public bool Sent { get; set; }

        [Required]
        public bool Draft { get; set; }

        [Required]
        public bool Trash { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }

    }
}