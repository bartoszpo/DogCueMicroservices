using DogCueWriteMicroservices.DBContexts;
using DogCueWriteMicroservices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DogCueWriteMicroservices.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DogCueDBEntities _db;

        public CustomerRepository(DogCueDBEntities db)
        {
            _db = db;
        }

        public int Create(Customer Customer)
        {
            _db.Customer.Add(Customer);
            _db.SaveChanges();
            return 0;
        }

        public Customer Details(int? id)
        {
            Customer Customer = _db.Customer.Find(id);


            return Customer;
        }

        public int Delete(int? id)
        {
            Customer Customer = _db.Customer.Find(id);
            if (Customer != null)
            {
                _db.Customer.Remove(Customer);
                _db.SaveChanges();
                return 0;
            }
            return -1;
        }

        public int Update(Customer Customer)
        {
            var local = _db.Set<Customer>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(Customer.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _db.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _db.Entry(Customer).State = EntityState.Modified;

            Customer Customer1 = _db.Customer.Find(Customer.Id);
            if (Customer1 != null)
            {
                _db.Customer.Update(Customer);
                _db.SaveChanges();
                return 0;
            }
            return -1;
        }
    
    }
}