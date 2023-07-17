using Domain;
namespace Persistence.Seeds;

public class Pluto
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Pluto",
            ImageIconPath = "/images/planet-icons/pluto.png",
            ImagePath = "/images/planets/pluto.png",
            Diameter = 2376.6M,
            DistanceFromTheSun = 4835003000M,
            Mass = 13050000000000000000000M,
            Position = 3,
            Notes = "Pluto Notes"
        };        
    }
}
