using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class Center
    {
        [Key]
        public int CenterId { get; set; }
        [Required]
        public string CenterAddress { get; set; }
        public int Pin { get; set; }
        public string City { get; set; }
       // public virtual ICollection<VaccinationStock> VaccinationStocks { get; set; }
      //  public virtual ICollection<Slot> Slots { get; set; }


    }
}