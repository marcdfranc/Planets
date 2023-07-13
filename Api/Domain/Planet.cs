using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Planet
{
    public Guid Id { get; set; }

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
}