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
        Uri baseAddress = new Uri("");
        HttpClient client;
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            List<Admin> users = new List<Admin>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user").Result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}