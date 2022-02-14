using System.Collections.Generic;
using System.Threading.Tasks;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public interface IContactServices
    {
        public bool CreateContact(Contact contact);
        public List<Contact> GetAllContacts();
        public Contact GetContact(int Id);
        public ApplicationUser GetUser(string Id);
        Task<bool> SaveChangesAsync();
        public void DeleteContact(int id);
    }
}