using iTextSharp.text.pdf;
using iTextSharp.text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using VaccineManagementAPI.Models;
using iTextSharp.tool.xml;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using PdfDocument = Syncfusion.Pdf.PdfDocument;
using PdfPage = Syncfusion.Pdf.PdfPage;
using PdfFont = Syncfusion.Pdf.Graphics.PdfFont;
using Antlr.Runtime.Misc;


namespace VaccineManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44387/api");
        HttpClient client;
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
     
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
        //public ActionResult PrintDetails()
        //{
        //    User u = new User();
        //    u.AadhaarNo = "23123445";
        //    u.PhoneNo = "9787799646";
        //    u.Age = 16;
        //    u.Name = "ANAND";

        //    return View(u);
        //}
        //[HttpPost]
        //[ValidateInput(false)]
        //public FileResult Export(string ExportData)
        //{
        //    using (MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        StringReader reader = new StringReader(ExportData);
        //        Document PdfFile = new Document(PageSize.A4);
        //        PdfWriter writer = PdfWriter.GetInstance(PdfFile, stream);
        //        PdfFile.Open();
        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfFile, reader);
        //        PdfFile.Close();
        //        return File(stream.ToArray(), "application/pdf", "ExportData.pdf");
        //    }
        //}
        public void CreatePDFDocument(string PhoneNo)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman,20);
                User user = new User();
                
                HttpResponseMessage response2 = client.GetAsync(client.BaseAddress + "/user?PhoneNo=" + PhoneNo).Result;
                if (response2.IsSuccessStatusCode)
                {
                    String Data = response2.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(Data);
                }
               
                if(user == null)
                {

                     RedirectToAction("SearchBy" , new {city= "a"});
                }
                else
                {
                    var slots = user.Slots;
                    Slot s = slots.First();
                    graphics.DrawString($"Name : {user.Name} \n Age : {user.Age} \n Phone Number : {PhoneNo} \n" +
                   $"Status : {s.Status} \n Date : {s.DateTime.Date.ToShortDateString()} \n City : {s.Center.City} \n Vaccine {s.Vaccination.VaccineName} \n Time : {s.DateTime.TimeOfDay}", font, PdfBrushes.Black, new PointF(10, 10));

                    // Open the document in browser after saving it
                    document.Save("Certificate.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);
                    
                }
                //Draw the text
               
            }
        }
    }
}