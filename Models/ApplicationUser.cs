using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(32), Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, StringLength(32), Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
