using DogCueWriteMicroservices.DBContexts;
using DogCueWriteMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogCueWriteMicroservices.Repository
{
    public interface IContactRepository
    {
        int Create(Contact cr);
        public int Delete(int? id);
        public Contact Details(int? id);

        public int Update(Contact contact);

    }
}
