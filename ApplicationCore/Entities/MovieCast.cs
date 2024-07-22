using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class MovieCast
{
    [Required]
    public int CastId { get; set; }
    [Required, MaxLength(450)]
    public string Character { get; set; }
    [Required]
    public int MovieId { get; set; }

    public Cast Cast { get; set; }
    public Movie Movie { get; set; }
}