using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {

        public DAL.IContacts _IContacts = new DAL.ContactFunctions();
       
        [HttpPost]
        public ActionResult<DAL.Models.Contacts> Post([FromBody] DAL.Models.Contacts contact)
        {
            var result = _IContacts.AddContact(contact);
            if(result == null)
            {               
                return new BadRequestObjectResult("Contact Type Id is  not right!");              
            }
            return _IContacts.AddContact(contact);
        }
     

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _IContacts.DeleteContact(id);
        }

        [HttpGet("{id}")]
        public ActionResult<DAL.Models.Contacts> Get(int id)
        {
           return _IContacts.GetContact(id);
        }


        

        [HttpPut]
        public ActionResult<DAL.Models.Contacts> Put(int id, [FromBody] DAL.Models.Contacts contact)
        {
            return _IContacts.UpdateContact(id, contact);
        }

        /// <summary>
        /// direction == asc returns the record ascending \n
        /// direction == desc returns the record descending\n
        /// fnameOrLname == fname returns the record ordered by firstanme\n
        /// fnameOrLname == lname returns the record by lname\n
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="fnameOrLname"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DAL.Models.Contacts> GetOrderd(string direction, string fnameOrLname)
        {
            var result= _IContacts.GetOrderd(direction, fnameOrLname);

            return result;
        }


    }
}
