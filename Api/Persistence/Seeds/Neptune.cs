using Domain;
namespace Persistence.Seeds;

public class Neptune
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Neptune",
            ImageIconPath = "/images/planet-icons/neptune.png",
            ImagePath = "/images/planets/neptune.png",
            Diameter = 49528M,
            DistanceFromTheSun = 4487936121M,
            Mass = 102430000000000000000000000M,
            Position = 4,
            Notes = "Neptune Notes"
        };        
    }
}
