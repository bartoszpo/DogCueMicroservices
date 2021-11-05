using DogCueMicroservices.Models;
using DogCueMicroservices.Repository;
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

        [HttpGet]
        public ActionResult IndexContact()
        {
            var contacts = _contactRepository.Index();

            return new OkObjectResult(contacts);
        }

        [HttpGet("{id}", Name = "GetDetailsContact")]
        public ActionResult DetailsContact(int id)
        {
            var contact = _contactRepository.Details(id);
            return new OkObjectResult(contact);
        }

    }
}
