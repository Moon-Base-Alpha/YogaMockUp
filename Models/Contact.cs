using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(500)]
        public string Subject { get; set; }

        [Required, StringLength(1000)]
        public string Message { get; set; }

        public Contact()
        {

        }
    }
}
