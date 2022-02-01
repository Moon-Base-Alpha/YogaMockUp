using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class ApplicationUser
    {
        [Required, StringLength(32), Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, StringLength(32), Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required, StringLength(160)]
        public string Email { get; set; }

        [Required, StringLength(25)]
        public string Phone { get; set; }

        [Required, StringLength(160)]
        public string Address { get; set; }
    }
}
