using DogCueMicroservices.DBContexts;
using DogCueMicroservices.Models;
using System.Collections.Generic;
using System.Linq;

namespace DogCueMicroservices.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DogCueDBEntities _db;

        public ContactRepository(DogCueDBEntities db)
        {
            _db = db;
        }

        public int Create(Contact contact)
        {
            _db.Contact.Add(contact);
            _db.SaveChanges();
            return 0;
        }

        public int Delete(int? id)
        {
            Contact contact = _db.Contact.Find(id);
            if (contact != null)
            {
                _db.Contact.Remove(contact);
                _db.SaveChanges();
                return 0;
            }
            return -1;
        }

        public Contact Details(int? id)
        {
            Contact contact = _db.Contact.Find(id);


            return contact;
        }

        public int Update(Contact contact)
        {
            Contact contact1 = _db.Contact.Find(contact.Id);
            if (contact1 != null)
            {
                _db.Contact.Update(contact);
                _db.SaveChanges();
                return 0;
            }
            return -1;
        }
    
public IEnumerable<Contact> Index()
        {
            return _db.Contact.ToList();
            
        }
    }
}