using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Favorite
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public int UserId { get; set; }
    
    public Movie Movie { get; set; }
    public User User { get; set; }
}