using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.RequestModels;

public class CastRequestModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required, MaxLength(128)]
    public string Name { get; set; }
    [Required, MaxLength(2084)]
    public string ProfilePath { get; set; }
    [Required]
    public string TmdbUrl { get; set; }
}