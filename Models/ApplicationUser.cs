using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(32), Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(32), Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string City { get; set; } = string.Empty;

        [Required, StringLength(20), Display(Name = "Zip code")]
        public string ZipCode { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new List<Course>();

        public ApplicationUser()
        {

        }
    }
}
