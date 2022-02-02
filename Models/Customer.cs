﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaMockUp.Models
{
    public class Customer : ApplicationUser
    {
        [Required, StringLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string City { get; set; } = string.Empty;

        [Required, StringLength(20), Display(Name = "Zip code")]
        public string ZipCode { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();

        public Customer()
        {

        }
    }
}
