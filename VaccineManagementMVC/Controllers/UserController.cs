using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VaccineManagementAPI.Models;

namespace VaccineManagementMVC.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44387/api");
        HttpClient client;
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Register()
        {
            return View();
        }
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
                    TempData["UserId"] = found.UserId;
                    TempData["PhoneNo"] = found.PhoneNo;
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
            int id = Convert.ToInt32(TempData["UserId"]);
            User user = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(data);
            }
            return View(user.Slots);
        }
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            member.UserId = Convert.ToInt32(TempData["UserId"]);
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
            return View(ans.Where(x=>x.Status == "Available"));
        }
    }
}