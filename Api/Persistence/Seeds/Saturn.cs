using Domain;
namespace Persistence.Seeds;

public class Saturn
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Saturn",
            ImageIconPath = "/images/planet-icons/saturn.png",
            ImagePath = "/images/planets/saturn.png",
            Diameter = 120536M,
            DistanceFromTheSun = 1436140000M,
            Mass = 568460000000000000000000000M,
            Position = 6,
            Notes = "Saturn Notes",
            Circular = false
        };
    }
}
