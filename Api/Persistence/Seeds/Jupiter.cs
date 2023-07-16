using Domain;
namespace Persistence.Seeds;

public class Jupiter
{
    public static Planet GetPlanet()
    {
        return new Planet
        {
            Name = "Jupiter",
            ImageIconPath = "/images/planet-icons/jupiter.png",
            ImagePath = "/images/planets/jupiter.png",
            Diameter = 142984M,
            DistanceFromTheSun = 778000000M,
            Mass = 1898600000000000000000000000M,
            Position = 7,
            Notes = "Jupiter's rotation is the fastest of all the Solar System's planets, completing a rotation on its axis in slightly less than ten hours; this creates an equatorial bulge easily seen through an amateur telescope. Because Jupiter is not a solid body, its upper atmosphere undergoes differential rotation. The rotation of Jupiter's polar atmosphere is about 5 minutes longer than that of the equatorial atmosphere. The planet is an oblate spheroid, meaning that the diameter across its equator is longer than the diameter measured between its poles. On Jupiter, the equatorial diameter is 9,276 km (5,764 mi) longer than the polar diameter."
        };        
    }
}
