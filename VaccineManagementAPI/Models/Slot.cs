using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SlotId { get; set; }
        public int DoseNo { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        // public int Count { get; set; }
        public int? MemberId { get; set; }
       // [ForeignKey("User")]
        public virtual int? UserId { get; set; }
       // public virtual User User { get; set; }
        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public virtual Center Center { get; set; }
        public virtual int VaccineId { get; set; }
        [ForeignKey("VaccineId")]
        public virtual Vaccination Vaccination { get; set; }
        

    }
}