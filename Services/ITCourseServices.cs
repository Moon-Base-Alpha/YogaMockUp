using System.Collections.Generic;
using System.Threading.Tasks;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public interface ITCourseServices
    {

        Task<bool> Savechangesasync();
        void AddTeacherTraining(TCourse ttCourse);

        public List<TCourse> TCoursesList();
        public TCourse GetTCourse(int Id);
        void Create(Course course);
        void UpdateCourse(TCourse c);
    }
}
