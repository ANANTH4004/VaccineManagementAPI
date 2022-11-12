using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VaccineManagementAPI.Models;
//using VaccineManagementMVC.Models;
//using Member = VaccineManagementAPI.Models.Member;
//using Slot = VaccineManagementAPI.Models.Slot;
//using User = VaccineManagementAPI.Models.User;

namespace VaccineManagementMVC.Controllers
{
    public class UserController : Controller
    {
      //  static User loginUser = new User();
        Uri baseAddress = new Uri("https://localhost:44387/api");
        HttpClient client;
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        /// <summary>
        /// /// Register Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            List<User> l = new List<User>();
            HttpResponseMessage response1 = client.GetAsync(client.BaseAddress + "/user").Result;
            if (response1.IsSuccessStatusCode)
            {
                String Data = response1.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<List<User>>(Data);
            }
            u.UserId = l.Count + 1;
            u.Name = Request["Name"].ToString();
            u.PhoneNo = Request["PhoneNumber"].ToString();
            var found = l.Find(x => x.PhoneNo == u.PhoneNo);
            if (found != null)
            {
                TempData["msg"] = "User Already Register with this Mobile Number";
                return RedirectToAction("Register");
            }
            else
            {
                u.Password = Request["Password"].ToString();
                TempData["Cpassword"] = Request["ConformPassword"].ToString();
                u.Age = Convert.ToInt32(Request["Age"]);
              
                u.AadhaarNo = Request["AadharNo"].ToString();
                string data = JsonConvert.SerializeObject(u);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/user", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (u.Password == TempData["Cpassword"].ToString())
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        TempData["msg"] = "Password and confirm  password not Matched Please check password and confirm password while Entering";
                    }
                }
                return RedirectToAction("Register");
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(FormCollection collection)
        {
            List<User> l = new List<User>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user").Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<List<User>>(Data);
            }
            string name = Request["Name"].ToString();
            string phoneNumber = Request["PhoneNumber"].ToString();
            string password = Request["Password"].ToString();
            string confirmpassword = Request["Cpassword"].ToString();
            var found = l.Find(x => (x.PhoneNo == phoneNumber) && (x.Name==name));
            if (found != null)
            {
                if ( password == confirmpassword)
                {
                    User user = new User();
                    HttpResponseMessage response2 = client.GetAsync(client.BaseAddress + "/user/" + found.UserId).Result;
                    if (response2.IsSuccessStatusCode)
                    {
                        String Data = response2.Content.ReadAsStringAsync().Result;
                        user = JsonConvert.DeserializeObject<User>(Data);
                    }
                    user.Password = confirmpassword;
                    string data = JsonConvert.SerializeObject(user);
                    StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response3 = client.PutAsync(baseAddress + "/user?PhoneNo=" + user.PhoneNo, Content).Result;
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Msg = "Incorrect password";
                }
            }
            else
            {
                ViewBag.Msg = "User not Found";
            }
            return View();

        }
        /// <summary>
        /// Register End
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            List<User> l = new List<User>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user").Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<List<User>>(Data);
            }
            string username = Request["email"].ToString();
            string password = Request["password"].ToString();
            var found = l.Find(x => x.PhoneNo == username);
            if (found != null)
            {
                if (found.Password == password)
                {
                    TempData["userid"] = found.UserId;
                    TempData["PhoneNo"] = found.PhoneNo;
                   // loginUser = found;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Msg = "Incorrect password";
                }
            }
            else
            {
                ViewBag.Msg = "User not Found";
            }
            return View();
        }
        // GET: User
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Index()
        {
            int id = Convert.ToInt32(TempData["userid"]);
            User user = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(data);
            }
            return View(user);
        }
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            member.UserId = Convert.ToInt32(TempData["userid"]);
            member.PhoneNo = TempData["PhoneNo"].ToString();
            string data = JsonConvert.SerializeObject(member);
            StringContent content = new StringContent(data,Encoding.UTF8 , "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/member" , content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult VaccinationDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VaccinationDetails(FormCollection collection)
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult SearchBy(string city)
        {
            List<Slot> s = new List<Slot>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/slot").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<List<Slot>>(data);
            }
            var ans = s.Where(x => x.Center.City.Contains(city) || city == null).ToList();
            var found = ans.Where(x => x.Status == "Available").ToList();
            return View(found);
        }
        public ActionResult MySlots()
        {
            int userid = Convert.ToInt32(TempData["UserId"]);
            User user = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user/" + userid).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(Data);
            }
            return View(user.Slots);
        }
        public ActionResult Book1(int id)
        {
            Slot s = new Slot();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/slot/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<Slot>(Data);
            }
            int userid =Convert.ToInt32(TempData["userid"]);
            User user = new User();
            HttpResponseMessage response2 = client.GetAsync(client.BaseAddress + "/user/" + userid).Result;
            if (response2.IsSuccessStatusCode)
            {
                String Data = response2.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(Data);
            }
            if (user.Slots.Count == 0)
            {
                s.UserId = Convert.ToInt32(TempData["userid"]);
                s.Status = "Booked";
                //s.Count--;
                string data = JsonConvert.SerializeObject(s);
                StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response1 = client.PutAsync(baseAddress + "/slot/" + s.SlotId, Content).Result;
                return RedirectToAction("MySlots");
            }
            else
            {
                ViewBag.msg = "Already Booked";
            }
            return RedirectToAction("Dashboard");
        }
        public ActionResult Reshedule(int id)
        {
            Slot s = new Slot();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/slot/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<Slot>(Data);
            }
            var userid = s.UserId;
            TempData["userid"] = s.UserId;
            s.UserId = null;
            s.Status = "Available";
            //int userid = Convert.ToInt32(TempData["UserId"]);
            string data1 = JsonConvert.SerializeObject(s);
            StringContent Content1 = new StringContent(data1, Encoding.UTF8, "application/json");
            HttpResponseMessage response1 = client.PutAsync(baseAddress + "/slot/" + s.SlotId, Content1).Result;
            User user = new User();
            HttpResponseMessage response2 = client.GetAsync(client.BaseAddress + "/user/" + userid).Result;
            if (response2.IsSuccessStatusCode)
            {
                String Data = response2.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(Data);
            }
            user.Slots.Clear();
            string data = JsonConvert.SerializeObject(user);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response3 = client.PutAsync(baseAddress + "/user/" + user.UserId, Content).Result;
            return RedirectToAction("Search");
        }
       

    }
}