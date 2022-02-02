using System.Collections.Generic;
using YogaMockUp.Data;
using YogaMockUp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace YogaMockUp.Services
{
    public class GlobalServices : IGlobalServices
    {
        private ApplicationDbContext _db;
        public GlobalServices(ApplicationDbContext context)
        {
            _db = context;
        }


        public List<Course> GetAllCoursesForCustomer(int Id)
        {
            var coursesInUser = _db.Customers.Find(Id).Courses;
            return coursesInUser.ToList();
        }

        public List<Course> GetAllCoursesForCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomersForCourse(int Id)
        {
            var CustomersInCourse = _db.Courses.Find(Id).Customers;
            _db.SaveChangesAsync();
            return CustomersInCourse;

        }

        public List<Customer> GetAllCustomersForCourse(Course course)
        {
            throw new System.NotImplementedException();
        }
    }
}
