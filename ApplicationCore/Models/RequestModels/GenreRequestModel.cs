using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.RequestModels;

public class GenreRequestModel
{
    [Required]
    public int Id { get; set; }
    [Required, MaxLength(24)]
    public string Name { get; set; }
}