using System.Collections.Generic;
using YogaMockUp.Data;
using YogaMockUp.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace YogaMockUp.Services
{
    public class GlobalServices : IGlobalServices
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _CustomerManager;

        public GlobalServices(ApplicationDbContext context,
            UserManager<ApplicationUser> CMM)
        {
            _db = context;
            _CustomerManager = CMM;
        }






        //--------------SETS--------------//
        public void CreateCourse(Course c)
        {
            _db.Courses.Add(c);
            _db.SaveChangesAsync(); // this function is made manually in alphablogging, maybe needed?

        }

        public void CreateCustomer(Customer c)
        {
            _db.Customers.Add(c);
            _db.SaveChangesAsync();
        }

        public void CreateSpecialEvent()
        {
            throw new System.NotImplementedException();
        }

        public void CreateTeacher(Teacher t)
        {
            _db.Teachers.Add(t);
            _db.SaveChangesAsync();
        }







        //--------------GETS--------------//
        public List<Course> GetAllCoursesForCustomer(int Id)
        {
            var coursesInUser = _db.Customers.Find(Id).Courses;
            return coursesInUser;
        }

        public List<Customer> GetAllCustomersForCourse(int Id)
        {
            var CustomersInCourse = _db.Courses.Find(Id).Customers;
            return CustomersInCourse;
        }

        public Course GetCourse(int Id)
        {
            var result = _db.Courses.Find(Id);

            return result;
        }

        public Customer GetCustomer(int Id)
        {
            var result = _db.Customers.Find(Id);
            return result;
        }

        //public Teacher GetTeacher(int Id)
        //{
        //    var result = _db.Teachers.Find(Id);
        //    return result;
        //}







        //temporary seeding

        public void SeedStuff() // do not use async here, or else it doesn't work
        {
            Customer cust = new Customer
            {
                FirstName = "Bob",
                LastName = "Bobsson",
                Address = "worldaddress",
                City = "worldCity",
                ZipCode = "12345",
                Email = "Bobbybob@email.com",
                UserName = "BobbytheBussySlayer"
            };
            
            

            Course c1 = new Course
            {
                CourseName = "course1",
                Description = "course1 description",
                Location = "theworld",
                Date = System.DateTime.Now,
                Price = 555
            };
            Course c2 = new Course
            {
                CourseName = "course2",
                Description = "course2 description",
                Location = "theworld",
                Date = System.DateTime.Now,
                Price = 555
            };

            CreateCourse(c1);
            CreateCourse(c2);
            CreateCustomer(cust);
            //await _CustomerManager.CreateAsync(cust, "123Asd");
            //await _CustomerManager.AddToRoleAsync(cust, "Customer");

            //cust.Courses.Add(c1);
            //cust.Courses.Add(c2);
            


            //var temp = _db.Customers.Find("d7500ba7-714b-4d53-80bd-0e2f21531218");
            //var temp2 = temp.Courses;

            //await _db.SaveChangesAsync();
        }

    }
}
