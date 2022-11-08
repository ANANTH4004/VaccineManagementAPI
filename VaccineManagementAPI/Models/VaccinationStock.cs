using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class VaccinationStock
    {
        [Key]
        public int StockId { get; set; }
        public int? DoseNo { get; set; }
        public int Quantity { get; set; }
        
      
        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public virtual Center Center { get; set; }

        public int VaccineId { get; set; }
        [ForeignKey("VaccineId")]
        public virtual Vaccination Vaccination { get; set; }
      


    }
}