using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using VaccineManagementAPI.Models;

namespace VaccineManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        //Uri baseAddress = new Uri("https://localhost:44387/api");
        //HttpClient client;
        public HomeController()
        {
        //    client = new HttpClient();
        //    client.BaseAddress = baseAddress;
        }
        //public ActionResult Register()
        //{

        //}
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Index()
        {
            //List<Admin> users = new List<Admin>();
            //HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/admin").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    string data = response.Content.ReadAsStringAsync().Result;
            //    users = JsonConvert.DeserializeObject<List<Admin>>(data);
            //}
            //return View(users);
            return View();
        }

        public ActionResult About()
        {
            //List<User> users = new List<User>();
            // HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user").Result;
            // if (response.IsSuccessStatusCode)
            // {
            //     string data = response.Content.ReadAsStringAsync().Result;
            //     users = JsonConvert.DeserializeObject<List<User>>(data);
            // }
            // var found = users.Find(x => x.Name == "anand");
            // var ans = found.Slots;
            // return View(ans);
            return View();

           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}