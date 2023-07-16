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

    [Required]
    [MaxLength(250)]
    public string? ImagePath { get; set; }

    [Required]
    [MaxLength(250)]
    public string? ImageIconPath { get; set; }

    [Required]
    public int Position { get; set; }

    [Required]
    public bool Circular { get; set; } = true;
}