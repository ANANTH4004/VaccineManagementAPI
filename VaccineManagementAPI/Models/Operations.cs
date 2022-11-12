using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineManagementAPI.Models
{
    public class Operations
    {
        VaccineContext context = new VaccineContext();


        public List<Member> GetMember()
        {
            return context.Members.ToList();
        }
        public void PostMember(Member admin)
        {
            context.Members.Add(admin);
            context.SaveChanges();
        }



        public List<Admin> GetAdmin()
        {
            return context.Admins.ToList();
        }
        public Admin GetAdmin(string id)
        {
            return context.Admins.ToList().Find(x => x.AdminEmail == id);
        }
        public void PostAdmin(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
        }
        public void PutAdmin(string id, Admin admin)
        {
            var found = context.Admins.ToList().Find(x => x.AdminEmail == id);
            context.Admins.Remove(found);
            context.Admins.Add(admin);
            context.SaveChanges();
        }
        public void DeleteAdmin(string id)
        {
            var found = context.Admins.ToList().Find(x => x.AdminEmail == id);
            context.Admins.Remove(found);
            context.SaveChanges();
        }






        public List<User> GetUser()
        {
            return context.Users.ToList();
        } 
        public User GetUser(int id)
        {
            return context.Users.ToList().Find(x=>x.UserId==id);
        }
        public User GetUser(string PhoneNo)
        {
            var found = context.Users.ToList().Find(x => x.PhoneNo == PhoneNo);
            return found;
            // context.Users.Remove(found);
            //found.Password = user.Password;
            // context.Users.Add(user);
           // context.SaveChanges();
        }
        public void PostUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void PutUser(int id, User user)
        {
           var found =  context.Users.ToList().Find(x => x.UserId == id);
           // context.Users.Remove(found);
            found.PhoneNo = user.PhoneNo;
            found.AadhaarNo = user.AadhaarNo;
            found.UserId = user.UserId;
            found.Members = user.Members;
            found.Name = user.Name;
            found.Age = user.Age;
            found.Password = user.Password;
            found.Slots = user.Slots;
           // context.Users.Add(user);
            context.SaveChanges();
        }
        public void PutUser(string PhoneNo , User user)
        {
            var found = context.Users.ToList().Find(x => x.PhoneNo == PhoneNo);
            // context.Users.Remove(found);
            found.Password = user.Password;
            // context.Users.Add(user);
            context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var found = context.Users.ToList().Find(x => x.UserId == id);
            context.Users.Remove(found);
            context.SaveChanges();
        }
        public List<Slot> GetSlots()
        {
            return context.Slots.ToList();
        }
        public Slot GetSlot(int id)
        {
            return context.Slots.ToList().Find(x => x.SlotId == id);
        }
        public void PostSlot(Slot slot)
        {
            context.Slots.Add(slot);
            context.SaveChanges();
        }
        public void PutSlot(int id , Slot slot)
        {
            var found = context.Slots.ToList().Find(x => x.SlotId == id);
            context.Slots.Remove(found);
            context.Slots.Add(slot);
            context.SaveChanges();
        }
        public void DeleteSlot(int id)
        {
            var found = context.Slots.ToList().Find(x => x.SlotId == id);
            context.Slots.Remove(found);
            context.SaveChanges();
        }
        public List<Center> GetCenter()
        {
            return context.Centers.ToList();
        }
        public Center GetCenter(int id)
        {
            return context.Centers.ToList().Find(x => x.CenterId == id);
        }
        public void PostCenter(Center center)
        {
            context.Centers.Add(center);
            context.SaveChanges();
        }
        public void PutCenter(int id , Center center)
        {
            var found = context.Centers.ToList().Find(x => x.CenterId == id);
            context.Centers.Remove(found);
            context.Centers.Add(center);
            context.SaveChanges();
        }
        public void DeleteCenter(int id)
        {
            var found = context.Centers.ToList().Find(x => x.CenterId == id);
            context.Centers.Remove(found);
            context.SaveChanges();
        }
        public List<Vaccination> GetVaccination()
        {
            return context.Vaccinations.ToList();
        }
        public Vaccination GetVaccination(int id)
        {
            return context.Vaccinations.ToList().Find(x => x.VaccineId == id);
        }
        public void PostVaccination(Vaccination vaccination)
        {
            context.Vaccinations.Add(vaccination);
            context.SaveChanges();
        }
        public void PutVaccination(int id , Vaccination vaccination)
        {
            var found = context.Vaccinations.ToList().Find(x => x.VaccineId == id);
            context.Vaccinations.Remove(found);
            context.Vaccinations.Add(vaccination);
            context.SaveChanges();
        }
        public void DeleteVaccination(int id)
        {
            var found = context.Vaccinations.ToList().Find(x => x.VaccineId == id);
            context.Vaccinations.Remove(found);
            context.SaveChanges();
        }
        public List<VaccinationStock> GetVaccinationStocks()
        {
            return context.VaccinationStocks.ToList();
        }
        public VaccinationStock GetVaccinationStocks(int id)
        {
            return context.VaccinationStocks.ToList().Find(x => x.StockId == id);
        }
        public void PostVaccinationStocks(VaccinationStock stock)
        {
            context.VaccinationStocks.Add(stock);
            context.SaveChanges();
        }
        public void PutVaccinationStocks(int id , VaccinationStock stock)
        {
          var found = context.VaccinationStocks.ToList().Find(x => x.StockId == id);
            context.VaccinationStocks.Remove(found);
            context.VaccinationStocks.Add(stock);
            context.SaveChanges();
        }
        public void DeleteVaccinationStocks(int id)
        {
          var found = context.VaccinationStocks.ToList().Find(x => x.StockId == id);
            context.VaccinationStocks.Remove(found);
            context.SaveChanges();
        }
    }
}