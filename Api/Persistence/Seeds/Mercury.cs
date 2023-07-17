using Domain;
namespace Persistence.Seeds;

public class Mercury
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Mercury",
            ImageIconPath = "/images/planet-icons/mercury.png",
            ImagePath = "/images/planets/mercury.png",
            Diameter = 4879.4M,
            DistanceFromTheSun = 70000000M,
            Mass = 330110000000000000000000M,
            Position = 2,
            Notes = "Mercury has the most eccentric orbit of all the planets in the Solar System; its eccentricity is 0.21 with its distance from the Sun ranging from 46,000,000 to 70,000,000 km (29,000,000 to 43,000,000 mi)"
        };        
    }
}
