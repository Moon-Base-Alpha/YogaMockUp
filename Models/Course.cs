using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaMockUp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Course Name")]
        public string CourseName { get; set; } = string.Empty;

        //[Required, StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = new DateTime();

        [Required, DataType(DataType.Currency), Column(TypeName = "decimal(10,0)")]
        public decimal Price { get; set; }

        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public Course()
        {

        }

       
    }
}
