using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Alikabook.Models
{
    public class CustomerInfo : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? House { get; set; }
        public string? Barangay { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? ZipCode { get; set; }
        public DateTime? Birthday { get; set; }

        public string? ProfileImage { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
    }
}
