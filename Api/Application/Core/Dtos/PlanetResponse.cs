using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Application.Core.Dtos;

public class PlanetResponse
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public decimal DecimalDistanceFromTheSun { get; set; }
    public string DistanceFromTheSun { get => DecimalDistanceFromTheSun.ToString("000.#E+0", CultureInfo.InvariantCulture); }
    
    public decimal DecimalMass { get; set; }
    
    public string Mass { get => DecimalMass.ToString("00000.#E+0", CultureInfo.InvariantCulture) ; } 
    
    public decimal Diameter { get; set; }

    public string? Notes { get; set; }
    
    public string? ImagePath { get; set; }
    
    public string? ImageIconPath { get; set; }
   
    public int Position { get; set; }
    
    public bool Circular { get; set; }
}
