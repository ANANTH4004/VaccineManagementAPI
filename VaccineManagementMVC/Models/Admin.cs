using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccineManagementMVC.Models
{
    public class Admin
    {
        
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }

    }
}