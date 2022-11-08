using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaccineManagementAPI.Models;

namespace VaccineManagementAPI.Controllers
{
    public class VaccinationStocksController : ApiController
    {
        Operations op = new Operations();
        // GET api/<controller>
        public IEnumerable<VaccinationStock> Get()
        {
            return op.GetVaccinationStocks();
        }

        // GET api/<controller>/5
        public VaccinationStock Get(int id)
        {
            return op.GetVaccinationStocks(id);
        }

        // POST api/<controller>
        public void Post([FromBody] VaccinationStock value)
        {
            op.PostVaccinationStocks(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] VaccinationStock value)
        {
            op.PutVaccinationStocks(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            op.DeleteVaccinationStocks(id);
        }
    }
}