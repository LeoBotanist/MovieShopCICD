using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class User
{
    [Required]
    public int Id { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [Required, MaxLength(256)]
    public string Email { get; set; }
    [Required, MaxLength(128)]
    public string FirstName { get; set; }
    [Required, MaxLength(1024)]
    public string HashedPassword { get; set; }
    public Boolean? IsLocked { get; set; }
    [Required, MaxLength(128)]
    public string LastName { get; set; }
    [MaxLength(16)]
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    [Required, MaxLength(1024)]
    public string Salt { get; set; }
    
}