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
    public class CustomerController : ControllerBase
    {
        // GET: CustomerController
        ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {


            var customers = _customerRepository.Index();

            return new OkObjectResult(customers);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public ActionResult Details(int id)
        {
            var customer = _customerRepository.Details(id);
            return new OkObjectResult(customer);
        }
    }
}
