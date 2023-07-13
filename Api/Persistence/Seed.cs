using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any() && !context.Planets.Any())
        {
            var users = new List<AppUser>
            {
                new AppUser
                {
                    DisplayName = "Marcelo",
                    UserName = "marc",
                    Email = "marc@test.com"
                },
                new AppUser
                {
                    DisplayName = "Will",
                    UserName = "will",
                    Email = "will@test.com"
                },
                new AppUser
                {
                    DisplayName = "Chris",
                    UserName = "Chris",
                    Email = "Chris@test.com"
                },
            };
            
            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "WebWeb2023!");
            }
        }

    }
}
