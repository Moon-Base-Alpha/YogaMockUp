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
        private readonly UserManager<ApplicationUser> _UserManager;

        public GlobalServices(ApplicationDbContext context,
            UserManager<ApplicationUser> CMM)
        {
            _db = context;
            _UserManager = CMM;
        }






        //--------------SETS--------------//
        public bool CreateCourse(Course c)
        {
            _db.Courses.Add(c);
            _db.SaveChangesAsync(); // this function is made manually in alphablogging, maybe needed?
            return true;
        }

        public bool CreateUser(ApplicationUser c)
        {
            _db.Users.Add(c);
            _db.SaveChangesAsync();
            return true;

        }

        public bool CreateSpecialEvent()
        {
            throw new System.NotImplementedException();
        }







        //--------------GETS--------------//
        public List<Course> GetAllCoursesForUser(int Id)
        {
            var coursesInUser = _db.Users.Find(Id).Courses;
            return coursesInUser;
        }

        public List<ApplicationUser> GetAllUsersForCourse(int Id)
        {
            var UsersInCourse = _db.Courses.Find(Id).Users;
            return UsersInCourse;
        }

        public Course GetCourse(int Id)
        {
            var result = _db.Courses.Find(Id);

            return result;
        }
        public List<Course> GetAllCourses()
        {
            var result = _db.Courses.ToList();

            return result;
        }

        public ApplicationUser GetUser(int Id)
        {
            var result = _db.Users.Find(Id);
            return result;
        }

        //public Teacher GetTeacher(int Id)
        //{
        //    var result = _db.Teachers.Find(Id);
        //    return result;
        //}







        //temporary seeding

        public bool SeedStuff() // do not use async here, or else it doesn't work
        {
            //User cust = new User
            //{
            //    FirstName = "Bob",
            //    LastName = "Bobsson",
            //    Address = "worldaddress",
            //    City = "worldCity",
            //    ZipCode = "12345",
            //    Email = "Bobbybob@email.com",
            //    UserName = "BobbytheBussySlayer"
            //};
            
            

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
            //CreateUser(cust);
            //await _UserManager.CreateAsync(cust, "123Asd");
            //await _UserManager.AddToRoleAsync(cust, "User");

            //cust.Courses.Add(c1);
            //cust.Courses.Add(c2);



            //var temp = _db.Users.Find("d7500ba7-714b-4d53-80bd-0e2f21531218");
            //var temp2 = temp.Courses;

            //await _db.SaveChangesAsync();
            return true;

        }

    }
}
