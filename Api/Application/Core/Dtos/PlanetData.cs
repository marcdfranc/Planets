using System.ComponentModel.DataAnnotations;

namespace Application.Core.Dtos;

public class PlanetData
{
    [Required]
    [MaxLength(30)]
    public string? Name { get; set; }

    [Required]
    public decimal DistanceFromTheSun { get; set; }

    [Required]
    public decimal Mass { get; set; }

    [Required]
    public decimal Diameter { get; set; }
        
    public string? Notes { get; set; }

    [Required]
    public string? ImagePath { get; set; }

    [Required]
    public string? ImageIconPath { get; set; }

    [Required]    
    public int Position { get; set; }

    [Required]
    public bool Circular { get; set; }
}
