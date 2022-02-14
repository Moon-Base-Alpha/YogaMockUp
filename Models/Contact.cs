using System;
using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(100), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(500)]
        public string Subject { get; set; }

        [Required, StringLength(1000)]
        public string Message { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public Contact()
        {

        }

        public Contact(DateTime created)
        {
            Created = created;
        }

        public Contact(string firstName, string lastName, string email, string subject, string message)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Subject = subject;
            Message = message;
            Created = DateTime.Now;
        }
    }
}

