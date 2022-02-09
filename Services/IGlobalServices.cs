using System.Collections.Generic;
using System.Threading.Tasks;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public interface IGlobalServices
    {
        //GETS
        public List<Course> GetAllCoursesForUser(string Id);
        public List<ApplicationUser> GetAllUsersForCourse(int Id);
        public ApplicationUser GetUser(string Id);
        public Course GetCourse(int Id);
        public List<Course> GetAllCourses();
        Task<bool> SaveChangesAsync();
        public void DeleteCourse(int id);

        //SETS
        public bool CreateUser(ApplicationUser x);
        public bool CreateCourse(Course x);
        public bool CreateSpecialEvent();
        public void UpdateCourse(Course course);
        public void MatchCourseWithUser(Course course, ApplicationUser user);



    }
}
