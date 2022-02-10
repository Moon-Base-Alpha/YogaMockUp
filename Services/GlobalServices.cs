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
            //_db.SaveChangesAsync(); // this function is made manually in alphablogging, maybe needed?
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

        public void UpdateCourse(Course CfromForm)
        {
            // CfromForm is the new data from the form, not yet stored in the DB

            var CfromDB = _db.Courses.Find(CfromForm.Id);
            //Fetches the current stored data from the database

            CfromDB.Id = CfromForm.Id;
            CfromDB.CourseName = CfromForm.CourseName;
            CfromDB.Description = CfromForm.Description;
            CfromDB.Location = CfromForm.Location;
            CfromDB.Date = CfromForm.Date;
            CfromDB.Price = CfromForm.Price;
            //the above just replaces the old values with
            //the new ones from the form, regardless if
            //they're identical or not

            _db.Update(CfromDB);
            _db.SaveChangesAsync();
        }

        public void DeleteCourse(int id)
        {
            _db.Courses.Remove(GetCourse(id));
        }

        public void MatchCourseWithUser(Course course, ApplicationUser user)
        {
            course.Users.Add(user);
            user.Courses.Add(course);
            _db.SaveChangesAsync();
        }

        //--------------GETS--------------//
        public List<Course> GetAllCoursesForUser(string Id)
        {
            var user = _db.Users.Find(Id);
            List<Course> courses = new List<Course>();

            foreach (var item in user.Courses)
            {
                courses.Add(item);
            }
            return courses;
        }

        public List<ApplicationUser> GetAllUsersForCourse(int Id)
        {
            var course = _db.Courses.Find(Id);
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var item in course.Users)
            {
                users.Add(item);
            }
            return users;
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
        public List<Event> GetAllEvents()
        {
            var result = _db.Events.ToList();

            return result;
        }
        public ApplicationUser GetUser(string Id)
        {
            var result = _db.Users.Find(Id);
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
