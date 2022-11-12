using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaccineManagementAPI.Models;

namespace VaccineManagementAPI.Controllers
{
    public class UserController : ApiController
    {
        Operations op = new Operations();
        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            return op.GetUser();
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            return op.GetUser(id);
        }
        public User Get(string PhoneNo)
        {
            return op.GetUser(PhoneNo);
        }

        // POST api/<controller>
        public void Post([FromBody] User value)
        {
            op.PostUser(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] User value)
        {
            op.PutUser(id, value);
        }
        public void Put(string PhoneNo, [FromBody] User value)
        {
            op.PutUser(PhoneNo, value);
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            op.DeleteUser(id);
        }
    }
}