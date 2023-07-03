using Microsoft.AspNetCore.Identity;
using EatEasy.Domain.Models;
using EatEasy.Domain.Enums;

namespace EatEasy.Infra.Data.Seed
{
    public static class SeedIdentity
    {
        public static async Task SeedIdentityData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in UserRoles.ROLES)
            {
                var roleCheck = await roleManager.RoleExistsAsync(role);
                if (roleCheck) continue;

                await roleManager.CreateAsync(new IdentityRole(role));
            }

            var user = await userManager.FindByNameAsync("11111111111");
            if (user == null)
            {
                user = new User {
                    UserName = "11111111111",
                    CPF = "11111111111",
                    Email = "pabloalves.ti@gmail.com",
                    EmailConfirmed = true,
                    Name = "Admin User",
                    PhoneNumber = "995319638"
                };

                await CreateUser(userManager, user, "admin123", UserRoles.ADMIN);
            }
        }

        private static async Task CreateUser(UserManager<User> userManager, User user, string password, string role)
        {
            if (userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var response = userManager.CreateAsync(user, password).Result;

                if (response.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
