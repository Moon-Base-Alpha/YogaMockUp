using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaMockUp.Models
{
    public class Customer : ApplicationUser
    {

        [Required, StringLength(100)]
        public string Address { get; set; }


        [Required, StringLength(50)]
        public string City { get; set; }


        [Required, StringLength(20), Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        public List<Course> Courses { get; set; }

    }
}
