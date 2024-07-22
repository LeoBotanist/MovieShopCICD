using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Review
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public decimal Rating { get; set; }
    [Required]
    public string ReviewText { get; set; }

    public Movie Movie { get; set; }
    public User User { get; set; }
    
}