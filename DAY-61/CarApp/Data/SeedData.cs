using Microsoft.AspNetCore.Identity;

namespace CarApp.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "Customer", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            await CreateUser(userManager, "admin@test.com", "Admin123!", "Admin");
            await CreateUser(userManager, "customer@test.com", "Customer123!", "Customer");
            await CreateUser(userManager, "user@test.com", "User123!", "User");
        }

        private static async Task CreateUser(UserManager<IdentityUser> userManager,
            string email, string password, string role)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser { UserName = email, Email = email };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}