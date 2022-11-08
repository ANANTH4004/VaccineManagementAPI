using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaccineManagementAPI.Models;

namespace VaccineManagementAPI.Controllers
{
    public class AdminController : ApiController
    {
        Operations op = new Operations();
        // GET api/<controller>
        public IEnumerable<Admin> Get()
        {
            return op.GetAdmin();
        }

        // GET api/<controller>/5
        public Admin Get(string id)
        {
            return op.GetAdmin(id);
        }

        // POST api/<controller>
        public void Post([FromBody] Admin value)
        {
            op.PostAdmin(value);
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody] Admin value)
        {
            op.PutAdmin(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            op.DeleteAdmin(id);
        }
    }
}