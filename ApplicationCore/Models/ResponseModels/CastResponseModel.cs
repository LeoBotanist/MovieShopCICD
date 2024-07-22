using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;

namespace ApplicationCore.Models.ResponseModels;

public class CastResponseModel
{
    [Required]
    public string Gender { get; set; }
    [Required, MaxLength(128)]
    public string Name { get; set; }
    [Required, MaxLength(2084)]
    public string ProfilePath { get; set; }
    [Required]
    public string TmdbUrl { get; set; }
    
    public ICollection<Movie> Movies { get; set; }
    public ICollection<MovieCast> MovieCasts { get; set; }
}