using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Application.Core.Dtos;

public class PlanetResponse
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public decimal DistanceFromTheSun { get; set; }
    
    public decimal DecimalMass { get; set; }
    
    public string Mass { get => DecimalMass.ToString("00000.#E+0", CultureInfo.InvariantCulture) ; } 
    
    public decimal Diameter { get; set; }

    public string? Notes { get; set; }
}
