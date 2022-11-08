using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class Admin
    {
        [Key]
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }

    }
}