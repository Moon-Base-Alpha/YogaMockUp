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
                await CreateRoleAsync("Admin");
                await CreateRoleAsync("User");

                //Seed users
                if (!_db.Users.Any())
                {
                    if (_userManager.FindByEmailAsync("rajesh@email.com").Result == null)
                    {
                        var user = new ApplicationUser
                        {
                            FirstName = "Rajesh",
                            LastName = "Dayakar",
                            Email = "rajesh@email.com",
                        };
                        await _userManager.CreateAsync(user, "123Asd@1");
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }
    }
}
