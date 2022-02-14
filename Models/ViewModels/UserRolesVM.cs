using System.Collections.Generic;

namespace YogaMockUp.Models.ViewModels
{
    public class UserRolesVM
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
