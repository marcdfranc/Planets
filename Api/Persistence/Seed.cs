using Domain;
using Persistence.Seeds;

namespace Persistence;

public class Seed
{
    // public static async Task SeedData(DataContext context, UserManager<AppUser> userManager) TO DO register user for back-end
    public static async Task SeedData(DataContext context)
    {
        var hasChanges = false;

        // TO DO register user for back-end
        if (1 != 1)
        {
            hasChanges = true;
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
            
            /*foreach (var user in users)
            {
                await userManager.CreateAsync(user, "WebWeb2023!");
            }*/
        }

        if (!context.Planets.Any())
        {
            hasChanges = true;
            await context.Planets.AddAsync(Mercury.GetPlanet());
            await context.Planets.AddAsync(Venus.GetPlanet());
            await context.Planets.AddAsync(Earth.GetPlanet());
            await context.Planets.AddAsync(Mars.GetPlanet());
            await context.Planets.AddAsync(Jupiter.GetPlanet());
            await context.Planets.AddAsync(Saturn.GetPlanet());
            await context.Planets.AddAsync(Uranus.GetPlanet());
            await context.Planets.AddAsync(Neptune.GetPlanet());
        }
        
        if (hasChanges) await context.SaveChangesAsync();
    }
}
