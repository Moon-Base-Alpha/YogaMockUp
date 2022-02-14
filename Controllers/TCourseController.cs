using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaMockUp.Data;
using YogaMockUp.Models;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    [Authorize(Roles = "Superadmin, Admin")]
    public class TCourseController : Controller
    {
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ILogger<HomeController> _logger;
        //private readonly IGlobalServices _globalServices;
        private readonly ITCourseServices _ttServices;
        private ApplicationDbContext _db;


        public TCourseController(ApplicationDbContext DB, ITCourseServices ttservice, ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IGlobalServices IGS)
        {
            _ttServices = ttservice;
            _db = DB;

        }
        public IActionResult Index()
        {
            return View(_db.TeachersCourse.ToList());
        }

         
        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TCourse tcourse)
        {
            //Teachertraining ttCourse = new Teachertraining();
            TCourse ttCourse = new TCourse(tcourse.CourseName, tcourse.Description, tcourse.Location,
                                        tcourse.Date, tcourse.Price);

            _ttServices.AddTeacherTraining(ttCourse);

            if (await _ttServices.Savechangesasync())
            //if (User.IsInRole("Admin") || User.IsInRole("Superadmin"))
            //           {
            //               return RedirectToAction("ttCourseList");
            //           }
            { return RedirectToAction("index"); }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //if (Id == null)
            //{
            //    return NotFound();
            //}

            var a = _ttServices.GetTCourse(Id);
            if (a == null)
            {
                return NotFound();
            }
            return View(a);
        }        
       
        [HttpPost]
        public ActionResult Edit(int Id, TCourse c)
        {
            //if (Id != c.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _db.Update(c);
            //        _db.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!TCourseExists(c.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            _ttServices.UpdateCourse(c);
            ViewBag.Message = "Course info has been updated successfully.";
            return View(c);
        }

        // GET: TCourses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCourse = _db.TeachersCourse
                .FirstOrDefault(m => m.Id == id);
            if (tCourse == null)
            {
                return NotFound();
            }

            return View(tCourse);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var tCourse = _db.TeachersCourse
                .FirstOrDefault(m => m.Id == Id);
            if (tCourse == null)
            {
                return NotFound();
            }

            return View(tCourse);
        }

        // POST: TCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tCourse = _db.TeachersCourse.Find(id);
            _db.TeachersCourse.Remove(tCourse);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private bool TCourseExists(object id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult TCoursesList()
        {
            List<TCourse> c = new List<TCourse>();
            c = _ttServices.TCoursesList();
            return View(c);
        }
        [HttpPost]
        public ActionResult TCoursesList(List<TCourse> c)
        {
            return View(c);
        }
    }
}

