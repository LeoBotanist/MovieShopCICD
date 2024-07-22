using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Role
{
    [Required]
    public int Id { get; set; }
    [Required, MaxLength(20)]
    public string Name { get; set; }
    
}