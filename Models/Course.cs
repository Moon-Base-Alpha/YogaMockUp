using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        //[Required, StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = new DateTime();

        [Required]
        public decimal Price { get; set; }

        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public Course()
        {

        }

       
    }
}
