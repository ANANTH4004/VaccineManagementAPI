using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class Vaccination
    {
        [Key]
        public int VaccineId { get; set; }
        public string VaccineName { get; set; }
        public double Price { get; set; }
        //public virtual ICollection<VaccinationStock> VaccinationStocks { get; set; }
        //public virtual ICollection<Slot> Slots { get; set; }

    }
}