using System.Collections.Generic;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public interface IGlobalServices
    {
        public List<Course> GetAllCoursesForCustomer(int Id);
        public List<Course> GetAllCoursesForCustomer(Customer customer);
        public List<Customer> GetAllCustomersForCourse(int Id);
        public List<Customer> GetAllCustomersForCourse(Course course);
    }
}
