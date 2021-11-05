using DogCueMicroservices.DBContexts;
using DogCueMicroservices.Models;
using System.Collections.Generic;
using System.Linq;

namespace DogCueMicroservices.Repository
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

        public Customer Details(int? id)
        {
            Customer Customer = _db.Customer.Find(id);


            return Customer;
        }

        public int Update(Customer Customer)
        {
            Customer Customer1 = _db.Customer.Find(Customer.Id);
            if (Customer1 != null)
            {
                _db.Customer.Update(Customer);
                _db.SaveChanges();
                return 0;
            }
            return -1;
        }
    
public IEnumerable<Customer> Index()
        {
            var query = from b in _db.Customer
                        select b;

            return query.ToList();

            //return _db.Customer.ToList();
            
        }
    }
}