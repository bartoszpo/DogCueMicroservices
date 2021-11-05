using DogCueMicroservices.DBContexts;
using DogCueMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogCueMicroservices.Repository
{
    public interface IContactRepository
    {
        public IEnumerable<Contact> Index();

        public Contact Details(int? id);

        int Create(Contact cr);
        public int Delete(int? id);

        public int Update(Contact contact);

    }
}
