using BookApp.Foundation.Entities;
using BookApp.Foundation.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Foundation.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(AuthorizationModel.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(AuthorizationModel.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(AuthorizationModel.Roles.User.ToString()));
            
            //Seed Default User
            var defaultUser = new ApplicationUser { UserName = AuthorizationModel.default_username, Email = AuthorizationModel.default_email, EmailConfirmed = true, PhoneNumberConfirmed = true };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, AuthorizationModel.default_password);
                await userManager.AddToRoleAsync(defaultUser, AuthorizationModel.default_role.ToString());
            }

            //Seed Admin User
            var adminUser = new ApplicationUser { UserName = AuthorizationModel.admin_username, Email = AuthorizationModel.admin_email, EmailConfirmed = true, PhoneNumberConfirmed = true };
            if (userManager.Users.All(u => u.Id != adminUser.Id))
            {
                await userManager.CreateAsync(adminUser, AuthorizationModel.default_password);
                await userManager.AddToRoleAsync(adminUser, AuthorizationModel.default_role.ToString());
                await userManager.AddToRoleAsync(adminUser, AuthorizationModel.admin_role.ToString());
            }
        }
    }
}
