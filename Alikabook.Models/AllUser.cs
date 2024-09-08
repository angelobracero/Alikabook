using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Alikabook.Models
{
    public class AllUser
    {
        public List<CustomerInfo> allUser { get; set; }
        public string Roles { get; set; }


    }
}
