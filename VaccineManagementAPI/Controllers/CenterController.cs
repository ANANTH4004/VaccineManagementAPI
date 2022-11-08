using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaccineManagementAPI.Models;

namespace VaccineManagementAPI.Controllers
{
    public class CenterController : ApiController
    {
        Operations op = new Operations();
        // GET api/<controller>
        public IEnumerable<Center> Get()
        {
            return op.GetCenter();
        }

        // GET api/<controller>/5
        public Center Get(int id)
        {
            return op.GetCenter(id);
        }

        // POST api/<controller>
        public void Post([FromBody] Center value)
        {
            op.PostCenter(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Center value)
        {
            op.PutCenter(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            op.DeleteCenter(id);    
        }
    }
}