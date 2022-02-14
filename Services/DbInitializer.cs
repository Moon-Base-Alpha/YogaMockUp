using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using YogaMockUp.Data;
using YogaMockUp.Models;

namespace YogaMockUp.Services
{
    public class DbInitializer : IAsyncInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // CreateRole Method
        private async Task CreateRoleAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };
                await _roleManager.CreateAsync(role);
            }
        }

        public async Task InitializeAsync()
        {
            //Creates the database if it does not exit and applies any pending migrations
            await _db.Database.MigrateAsync();

            //if true, initializes the database with some sample data
            if (!_db.Roles.Any())
            {
                await CreateRoleAsync("Superadmin");
                await CreateRoleAsync("Admin");
                await CreateRoleAsync("User");
                await CreateRoleAsync("Teacher");
                await CreateRoleAsync("Customer");
                await CreateRoleAsync("Student");
            }
            //Seed users
            if (_userManager.FindByEmailAsync("rajesh@email.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Rajesh",
                    LastName = "Dayakar",
                    UserName = "rajesh@email.com",
                    Email = "rajesh@email.com",
                    Address = "WorldstreetAddress",
                    City = "WorldCity",
                    ZipCode = "12345",

                };
                var result = await _userManager.CreateAsync(user, "123Asd@1");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Superadmin");
                }
            }
            if (_userManager.FindByEmailAsync("admin@email.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "adminson",
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    Address = "Lexicon",
                    City = "Linkoping",
                    ZipCode = "12345",
                };
                var result = await _userManager.CreateAsync(user, "123Asd@1");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }
            if (_userManager.FindByEmailAsync("user@email.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "User",
                    LastName = "userson",
                    UserName = "user@email.com",
                    Email = "user@email.com",
                    Address = "WorldstreetAddress",
                    City = "WorldCity",
                    ZipCode = "12345",
                };
                var result = await _userManager.CreateAsync(user, "123Asd@1");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                }
            }
            if (_userManager.FindByEmailAsync("teacher@email.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Teacher",
                    LastName = "Andersson",
                    UserName = "teacher@email.com",
                    Email = "teacher@email.com",
                    Address = "WorldstreetAddress",
                    City = "WorldCity",
                    ZipCode = "12345",
                };
                var result = await _userManager.CreateAsync(user, "123Asd@1");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Teacher");
                }
            }
            if (_userManager.FindByEmailAsync("neo@email.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Neo",
                    LastName = "Andersson",
                    UserName = "neo@email.com",
                    Email = "neo@email.com",
                    Address = "WorldstreetAddress",
                    City = "WorldCity",
                    ZipCode = "12345",
                };
                var result = await _userManager.CreateAsync(user, "123Asd@1");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
            if (_userManager.FindByEmailAsync("lisa@email.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Lisa",
                    LastName = "Lisa",
                    UserName = "lisa@email.com",
                    Email = "lisa@email.com",
                    Address = "WorldstreetAddress",
                    City = "WorldCity",
                    ZipCode = "12345",
                };
                var result = await _userManager.CreateAsync(user, "123Asd@1");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                }

            }
            if (_userManager.FindByEmailAsync("peter@email.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    UserName = "peter@email.com",
                    Email = "peter@email.com",
                    Address = "WorldstreetAddress",
                    City = "WorldCity",
                    ZipCode = "12345",
                };
                var result = await _userManager.CreateAsync(user, "123Asd@1");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
            // End seed users //

            // Seed courses //
            if (!(_db.Courses.Count() > 0))
            {
                var course = new Course
                {
                    CourseName = "Beginner’s level 1",
                    Description = "For you who are completely new to hatha yoga or wish to gain a clear knowledge of the " +
                    "fundamental principles of hatha yoga. We will have an extra focus on gentle stretching and relaxation " +
                    "for body and mind. During the course, you will be introduced to new asanas and yogic breathing techniques " +
                    "along with their benefits, counter-indications and proper technique. After the course, you will know the " +
                    "basic asanas of a Sivananda class, Surya Namaskar, Pranayama (breathing techniques) and proper relaxation.",
                    Location = "Storgatan 70, Linköping",
                    Date = System.DateTime.Now,
                    Price = 2400
                };
                _db.Courses.Add(course);

                course = new Course
                {
                    CourseName = "Beginner’s level-2",
                    Description = "For you who have completed a Beginners’ course or already have some understanding of yoga. " +
                    "During the course, you will gain a clear knowledge of the fundamental principles of hatha yoga and be " +
                    "introduced to new asanas and yogic breathing techniques along with their benefits, counter-indications " +
                    "and proper technique. After the course, you will know the basic asanas of a Sivananda class, Surya Namaskar, " +
                    "Pranayama (breathing techniques) and proper relaxation. In this course, you will be given the opportunity " +
                    "to start practising the headstand – Sirshasana",
                    Location = "Storgatan 70, Linköping",
                    Date = System.DateTime.Now,
                    Price = 2400
                };
                _db.Courses.Add(course);

                course = new Course
                {
                    CourseName = "Intermediate level",
                    Description = "For you who have completed the beginners level 2′ course or already have practising yoga " +
                    "for some time. You will learn new variations and new asanas along with deepening your practice of the basic " +
                    "postures. We will continue to practice the headstand – Sirhasana. More focus on holding the postures " +
                    "comfortably for a long time while being aware of your thoughts and breathing. ",
                    Location = "Storgatan 70, Linköping",
                    Date = System.DateTime.Now,
                    Price = 2400
                };
                _db.Courses.Add(course);

                course = new Course
                {
                    CourseName = "Lunchtime yoga",
                    Description = "These classes are suitable for beginners to intermediates. This one-hour classes will help " +
                    "to reduce stress, alleviate pain and tension in the neck and lower back areas, ease out stiff joints, " +
                    "stretch out tight muscles, reduce fatigue and induce relaxation process.",
                    Location = "Storgatan 70, Linköping",
                    Date = System.DateTime.Now,
                    Price = 1950
                };
                _db.Courses.Add(course);

                var eventvar = new Event
                {
                    CourseName = "EventName",
                    Description = "This is a description for the event",
                    Location = "the world",
                    Price = 444
                };
                _db.Events.Add(eventvar);

                eventvar = new Event
                {
                    CourseName = "EventName2",
                    Description = "This is another description for the event",
                    Location = "the world",
                    Price = 445
                };
                _db.Events.Add(eventvar);
                _db.SaveChanges();
            }
            // End seed courses//

            //Seed messages//
            if (!(_db.Contacts.Count() > 0))
            {
                var contact = new Contact
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "peter@email.com",
                    Subject = "How to apply for the yoga course?",
                    Message = "Hi, can you tell me how to apply for the summmer yoga course, thank!",
                    Created = System.DateTime.Now,
                };
                _db.Contacts.Add(contact);

                contact = new Contact
                {
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    Email = "lisa@email.com",
                    Subject = "How to apply online yoga course?",
                    Message = "Hi, can you tell me how to apply for the online yoga course, thank!",
                    Created = System.DateTime.Now,
                };
                _db.Contacts.Add(contact);

                contact = new Contact
                {
                    FirstName = "Mary",
                    LastName = "Watson",
                    Email = "mary@email.com",
                    Subject = "How much for the event on next year?",
                    Message = "Hi, can you tell me the price for the event on 2023, thank!",
                    Created = System.DateTime.Now,
                };
                _db.Contacts.Add(contact);
                _db.SaveChanges();
            }
            //End Seed messages//
        }
    }
}
