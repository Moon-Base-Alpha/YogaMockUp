using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaMockUp.Data;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public class ContactServices : IContactServices
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _UserManager;

        public ContactServices(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _UserManager = userManager;
        }

        public bool CreateContact(Contact contact)
        {
            _db.Contacts.Add(contact);
            return true;
        }

        public List<Contact> GetAllContacts()
        {
            var result = _db.Contacts.ToList();

            return result;
        }

        public Contact GetContact(int Id)
        {
            var result = _db.Contacts.Find(Id);

            return result;
        }

        public void DeleteContact(int id)
        {
            _db.Contacts.Remove(GetContact(id));
        }

        public ApplicationUser GetUser(string Id)
        {
            var result = _db.Users.Find(Id);
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }


    }
}
