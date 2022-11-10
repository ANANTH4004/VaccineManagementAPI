using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class VaccineContext : DbContext
    {
        public VaccineContext() : base("name=VaccineManagement")
        {
            Database.SetInitializer<VaccineContext>(new VaccineInitialize());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Center> Centers { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<VaccinationStock> VaccinationStocks { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }
}