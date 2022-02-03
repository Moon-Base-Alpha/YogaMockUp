using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        [Required, StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = new DateTime();

        [Required]
        public decimal Price { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public Course()
        {

        }
    }
}
