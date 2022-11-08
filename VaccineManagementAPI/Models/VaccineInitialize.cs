using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class VaccineInitialize : DropCreateDatabaseIfModelChanges<VaccineContext>
    {
        protected override void Seed(VaccineContext context)
        {
            List<Admin> admin = new List<Admin>();
            admin.Add(new Admin() { AdminEmail = "anand@gmail.com", AdminPassword = "anand" });
            context.Admins.AddRange(admin);
            List<User> users = new List<User>();
            users.Add(new User() {UserId =1,Name= "anand" , PhoneNo = "9787799646" , Age =21 , AadhaarNo = "2335424" , Password = "anand" });
            users.Add(new User() { UserId=2,Name= "varun" , PhoneNo = "8300807546" , Age =22 , AadhaarNo = "2335424" , Password = "varun" });
            context.Users.AddRange(users);
           List<Center> center = new List<Center>();
            center.Add(new Center() { CenterAddress = "17 , east street", City = "mutlur", Pin = 608501 });
            center.Add(new Center() { CenterAddress = "17 , east street", City = "chennai", Pin = 608502 });
            center.Add(new Center() { CenterAddress = "17 , east street", City = "pune", Pin = 608503 });
            context.Centers.AddRange(center);
            List<Vaccination> vaccination = new List<Vaccination>();
            vaccination.Add(new Vaccination() { VaccineName = "Covaxin", Price = 100 });
            vaccination.Add(new Vaccination() { VaccineName = "Covishield", Price = 120 });
            context.Vaccinations.AddRange(vaccination);
            List<VaccinationStock> vaccinationStock = new List<VaccinationStock>();
            vaccinationStock.Add(new VaccinationStock() { CenterId = 1, DoseNo = 1, Quantity = 100, VaccineId = 1 });
            vaccinationStock.Add(new VaccinationStock() { CenterId = 3, DoseNo = 3, Quantity = 10, VaccineId = 2 });
            context.VaccinationStocks.AddRange(vaccinationStock);
            //List<Slot> slots = new List<Slot>();
            //slots.Add(new Slot() { VaccineId = 1, CenterId = 1, DoseNo = 1, Status = "Available", DateTime = new DateTime(2022, 05, 11), UserId = 1 });
            //slots.Add(new Slot() { VaccineId = 1, CenterId = 1, DoseNo = 2, Status = "Available", DateTime = new DateTime(2022, 05, 11, 09, 00, 00), UserId = 2 });
            //slots.Add(new Slot() { VaccineId = 1, CenterId = 2, DoseNo = 2, Status = "Available", DateTime = new DateTime(2022, 05, 11, 10, 00, 00), UserId = 1 });
            //slots.Add(new Slot() { VaccineId = 2, CenterId = 2, DoseNo = 2, Status = "Available", DateTime = new DateTime(2022, 05, 11, 11, 00, 00), UserId = 1 });
            //slots.Add(new Slot() { VaccineId = 2, CenterId = 3, DoseNo = 1, Status = "Available", DateTime = new DateTime(2022, 05, 11), UserId = 1 });
            //context.Slots.AddRange(slots);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}