using Domain;
namespace Persistence.Seeds;

public class Venus
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Venus",
            ImageIconPath = "/images/planet-icons/venus.png",
            ImagePath = "/images/planets/venus.png",
            Diameter = 12103.6M,
            DistanceFromTheSun = 108000000M,
            Mass = 4868500000000000000000000M,
            Position = 1,
            Notes = "Venus Notes"
        };        
    }
}
