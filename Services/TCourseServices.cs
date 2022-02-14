using System.Collections.Generic;
using YogaMockUp.Data;
using YogaMockUp.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace YogaMockUp.Services
{
    public class TCourseServices:ITCourseServices
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _UserManager;

        public TCourseServices(ApplicationDbContext context,
            UserManager<ApplicationUser> CMM)
        {
            _db = context;
            _UserManager = CMM;
        }

        public async Task<bool> Savechangesasync()
        {
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
        
        

        public void AddTeacherTraining(TCourse ttCourse)
        {
            _db.TeachersCourse.Add(ttCourse);
            //throw new System.NotImplementedException();
        }

        public List<TCourse> TCoursesList()
        {
            var result = _db.TeachersCourse.ToList();

            return result;
        }

        public TCourse GetTCourse(int Id)
        {
            var result = _db.TeachersCourse.Find(Id);

            return result;
        }        

        public void Create(Course course)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCourse(TCourse c)
        {
            var CfromDB = _db.TeachersCourse.Find(c.Id);
            //Fetches the current stored data from the database

            CfromDB.Id = c.Id;
            CfromDB.CourseName = c.CourseName;
            CfromDB.Description = c.Description;
            CfromDB.Location = c.Location;
            CfromDB.Date = c.Date;
            CfromDB.Price = c.Price;
            //the above just replaces the old values with
            //the new ones from the form, regardless if
            //they're identical or not

            _db.Update(CfromDB);
            _db.SaveChangesAsync();
        }
    }
}
