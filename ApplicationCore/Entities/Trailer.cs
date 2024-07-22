using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Trailer
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int MovieId { get; set; }
    [Required, MaxLength(2084)]
    public string Name { get; set; }
    [Required, MaxLength(2084)]
    public string TrailerUrl { get; set; }
    
    public Movie Movie { get; set; }
}