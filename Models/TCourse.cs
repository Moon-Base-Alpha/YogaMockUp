using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YogaMockUp.Models
{
    public class TCourse
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        //[Required, StringLength(1500)]
        public string Description { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = new DateTime();

        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        public TCourse ()
            {
            }
        public TCourse(string courseName, string description, string location, DateTime date, decimal price)
        {
            CourseName = courseName;
            Description = description;
            Location = location;
            Date = date;
            Price = price;
        }
    }
}

