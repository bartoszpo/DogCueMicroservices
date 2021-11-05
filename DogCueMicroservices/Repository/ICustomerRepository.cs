using DogCueMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogCueMicroservices.Repository
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> Index();

        public Customer Details(int? id);

        int Create(Customer cr);
        public int Delete(int? id);

        public int Update(Customer contact);

    }
}
