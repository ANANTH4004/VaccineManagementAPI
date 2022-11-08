using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaccineManagementAPI.Models;

namespace VaccineManagementAPI.Controllers
{
    public class SlotController : ApiController
    {
        Operations op = new Operations();
        // GET api/<controller>
        public IEnumerable<Slot> Get()
        {
            return op.GetSlots();
        }

        // GET api/<controller>/5
        public Slot Get(int id)
        {
            return op.GetSlot(id);
        }

        // POST api/<controller>
        public void Post([FromBody] Slot value)
        {
            op.PostSlot(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Slot value)
        {
            op.PutSlot(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
             op.DeleteSlot(id);
        }
    }
}