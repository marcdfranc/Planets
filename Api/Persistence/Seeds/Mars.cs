using Domain;
namespace Persistence.Seeds;

public class Mars
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Mars",
            ImageIconPath = "/images/planet-icons/mars.png",
            ImagePath = "/images/planets/mars.png",
            Diameter = 6792.4M,
            DistanceFromTheSun = 230000000M,
            Mass = 641740000000000000000000M,
            Position = 8,
            Notes = "Mars Notes"
        };        
    }
}
