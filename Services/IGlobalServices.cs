using System.Collections.Generic;
using System.Threading.Tasks;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public interface IGlobalServices
    {
        //GETS
        public List<Course> GetAllCoursesForCustomer(int Id);
        public List<Customer> GetAllCustomersForCourse(int Id);
        public Customer GetCustomer(int Id);
        public Course GetCourse(int Id);
        //public Teacher GetTeacher(int Id);

        //SETS
        public void CreateCustomer(Customer x);
        public void CreateCourse(Course x);
        public void CreateTeacher(Teacher x);
        public void CreateSpecialEvent();
        public void SeedStuff();
    }
}
