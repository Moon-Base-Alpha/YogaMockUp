using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required, StringLength(50)]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
