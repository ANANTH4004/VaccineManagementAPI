using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccineManagementMVC.Models
{
    public class Member
    {
        [Required]
        public string MemberName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string AadhaarNo { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public ICollection<Slot> mslots { get; set; }   

    }
}