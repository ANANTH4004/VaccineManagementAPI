using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class Member
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int Age { get; set; }
        [Required]
        public int UserId { get; set; }
        public string AadhaarNo { get; set; }
          public string PhoneNo { get; set; }
        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }
        public virtual ICollection<Slot> mslots { get; set; } 

    }
}