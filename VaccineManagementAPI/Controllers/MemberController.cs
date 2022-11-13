using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaccineManagementAPI.Models;

namespace VaccineManagementAPI.Controllers
{
    public class MemberController : ApiController
    {
        Operations op = new Operations();
        // GET api/<controller>
       

        // GET api/<controller>/5
        public List<Member> Get()
        {
            return op.GetMember();
        }
        public Member Get(int id)
        {
            return op.GetMember(id);
        }

        // POST api/<controller>
        public void Post([FromBody] Member value)
        {
            op.PostMember(value);

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}