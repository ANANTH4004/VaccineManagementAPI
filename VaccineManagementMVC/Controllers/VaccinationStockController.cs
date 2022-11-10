using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VaccineManagementMVC.Models;
using VaccineManagementAPI;
using VaccineManagementAPI.Models;

namespace VaccineManagementMVC.Controllers
{
    public class VaccinationStockController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44387/api");
        HttpClient client;
        public VaccinationStockController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: User
        public ActionResult Index()
        {
            List<VaccinationStock> vs = new List<VaccinationStock>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/vaccinationstocks").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                vs = JsonConvert.DeserializeObject<List<VaccinationStock>>(data);
            }

            return View(vs);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(VaccinationStock Vaccinestock)
        {
            string data = JsonConvert.SerializeObject(Vaccinestock);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/vaccinationstocks", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            VaccinationStock vs = new VaccinationStock();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/vaccinationstocks/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                vs = JsonConvert.DeserializeObject<VaccinationStock>(Data);
            }
            return View(vs);
        }
        [HttpPost]
        public ActionResult Edit(VaccinationStock model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(baseAddress + "/vaccinationstocks/" + model.StockId, Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            Vaccination l = new Vaccination();
            HttpResponseMessage response = client.DeleteAsync(baseAddress + "/vaccinationStocks/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}