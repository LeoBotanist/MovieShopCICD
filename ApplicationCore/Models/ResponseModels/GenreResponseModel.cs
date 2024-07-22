using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.ResponseModels;

public class GenreResponseModel
{
    public int Id { get; set; }
    [Required, MaxLength(24)]
    public string Name { get; set; }
}