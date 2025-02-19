using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Purchase
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public DateTime PurchaseDateTime { get; set; }
    [Required]
    public Guid PurchaseNumber { get; set; }
    [Required]
    public decimal TotalPrice { get; set; }

    public Movie Movie { get; set; }
    public User User { get; set; }
}