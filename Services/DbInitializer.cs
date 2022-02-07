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
                    await _userManager.AddToRoleAsync(user, "User");
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
                    await _userManager.AddToRoleAsync(user, "User");
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

            if(!(_db.Courses.Count() > 0))
            {
                var course = new Course // seeding a course becasue I can't figure out how to do it in DBinitialize
                {
                    CourseName = "Course1",
                    Description = "Desc1",
                    Location = "theworld",
                    Date = System.DateTime.Now,
                    Price = 555
                };
                _db.Courses.Add(course);

                course = new Course // seeding a course becasue I can't figure out how to do it in DBinitialize
                {
                    CourseName = "Course2",
                    Description = "Desc2",
                    Location = "theworld",
                    Date = System.DateTime.Now,
                    Price = 555
                };
                _db.Courses.Add(course);

                course = new Course // seeding a course becasue I can't figure out how to do it in DBinitialize
                {
                    CourseName = "Course3",
                    Description = "Desc3",
                    Location = "theworld",
                    Date = System.DateTime.Now,
                    Price = 555
                };
                _db.Courses.Add(course);

                _db.SaveChanges();
            }


        }
    }
}
