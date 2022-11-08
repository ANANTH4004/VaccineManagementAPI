using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaccineManagementAPI.Models;

namespace VaccineManagementAPI.Controllers
{
    public class VaccinationController : ApiController
    {
        Operations op = new Operations();
        // GET api/<controller>
        public IEnumerable<Vaccination> Get()
        {
            return op.GetVaccination();
        }

        // GET api/<controller>/5
        public Vaccination Get(int id)
        {
            return op.GetVaccination(id);
        }

        // POST api/<controller>
        public void Post([FromBody] Vaccination value)
        {
             op.PostVaccination(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Vaccination value)
        {
            op.PutVaccination(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            op.DeleteVaccination(id);
        }
    }
}