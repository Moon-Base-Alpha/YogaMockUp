using System.Collections.Generic;
using System.Threading.Tasks;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public interface IGlobalServices
    {
        //GETS
        public List<Course> GetAllCoursesForUser(int Id);
        public List<ApplicationUser> GetAllUsersForCourse(int Id);
        public ApplicationUser GetUser(int Id);
        public Course GetCourse(int Id);
        public List<Course> GetAllCourses();


        //SETS
        public bool CreateUser(ApplicationUser x);
        public bool CreateCourse(Course x);
        public bool CreateSpecialEvent();
        public bool SeedStuff();
    }
}
