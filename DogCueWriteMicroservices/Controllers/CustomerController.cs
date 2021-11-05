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
    public class CustomerController : ControllerBase
    {
        // GET: CustomerController
        ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var _customer = _customerRepository.Create(customer);
            return new OkObjectResult(_customer);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (customer != null)
            {
                using (var scope = new TransactionScope())
                {
                    _customerRepository.Update(customer);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.Details(id);
            if (customer != null)
            {
                _customerRepository.Delete(id);
                return new OkResult();
            }
            return new NotFoundResult();
        }


    }
}
