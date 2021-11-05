using DogCueWriteMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogCueWriteMicroservices.Repository
{
    public interface ICustomerRepository
    {
        int Create(Customer cr);
        public int Delete(int? id);
        public Customer Details(int? id);
        public int Update(Customer contact);

    }
}
