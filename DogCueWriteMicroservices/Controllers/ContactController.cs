using DogCueWriteMicroservices.Models;
using DogCueWriteMicroservices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DogCueMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: ContactController
        public IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        [HttpPost]
        public IActionResult PostContact([FromBody] Contact contact)
        {
            var _contact = _contactRepository.Create(contact);
            return new OkObjectResult(_contact);
        }


        [HttpPut]
        public IActionResult PutContact([FromBody] Contact contact)
        {
            if (contact != null)
            {
                using (var scope = new TransactionScope())
                {
                    _contactRepository.Update(contact);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            var contact = _contactRepository.Details(id);
            if (contact != null)
            {
                _contactRepository.Delete(id);
                return new OkResult();
            }
            return new NotFoundResult();
        }



    }
}
