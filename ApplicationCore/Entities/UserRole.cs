using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class UserRole
{
    [Required]
    public int RoleId { get; set; }
    [Required]
    public int UserId { get; set; }

    public Role Role { get; set; }
    public User User { get; set; }
}