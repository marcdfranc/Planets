using Domain;
namespace Persistence.Seeds;

public class Uranus
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Uranus",
            ImageIconPath = "/images/planet-icons/uranus.png",
            ImagePath = "/images/planets/uranus.png",
            Diameter = 51118M,
            DistanceFromTheSun = 2991957414M,
            Mass = 86810000000000000000000000M,
            Position = 5,
            Notes = "The mean apparent magnitude of Uranus is 5.68 with a standard deviation of 0.17, while the extremes are 5.38 and 6.03. This range of brightness is near the limit of naked eye visibility. Much of the variability is dependent upon the planetary latitudes being illuminated from the Sun and viewed from the Earth. Its angular diameter is between 3.4 and 3.7 arcseconds, compared with 16 to 20 arcseconds for Saturn and 32 to 45 arcseconds for Jupiter. At opposition, Uranus is visible to the naked eye in dark skies, and becomes an easy target even in urban conditions with binoculars. In larger amateur telescopes with an objective diameter of between 15 and 23 cm, Uranus appears as a pale cyan disk with distinct limb darkening. With a large telescope of 25 cm or wider, cloud patterns, as well as some of the larger satellites, such as Titania and Oberon, may be visible."
        };        
    }
}
