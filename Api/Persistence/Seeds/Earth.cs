using Domain;
namespace Persistence.Seeds;

public class Earth
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Earth",
            ImageIconPath = "/images/planet-icons/earth.png",
            ImagePath = "/images/planets/earth.png",
            Diameter = 12756.2M,
            DistanceFromTheSun = 150000000M,
            Mass = 5973600000000000000000000M,
            Position = 9,
            Notes = "Earth Notes"
        };        
    }
}
