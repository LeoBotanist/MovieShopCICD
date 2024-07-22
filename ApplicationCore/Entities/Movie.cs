using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Movie
{
    [Required]
    public int Id { get; set; }
    [MaxLength(2084)]
    public string? BackdropUrl { get; set; }
    public decimal? Budget { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    [MaxLength(2084)]
    public string? ImdbUrl { get; set; }
    [MaxLength(64)]
    public string? OriginalLanguage { get; set; }
    public string? Overview { get; set; }
    [MaxLength(2084)]
    public string? PosterUrl { get; set; }
    public decimal? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public decimal? Revenue { get; set; }
    public int? RunTime { get; set; }
    [MaxLength(512)]
    public string? Tagline { get; set; }
    [MaxLength(256)]
    public string? Title { get; set; }
    [MaxLength(2084)]
    public string? TmdbUrl { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public ICollection<MovieGenre> MovieGenres { get; set; }
    public ICollection<Genre> Genres { get; set; }
    
    public ICollection<Favorite> Favorites { get; set; }
    public ICollection<MovieCast> MovieCasts { get; set; }
    public ICollection<Cast> Casts { get; set; }
    
    public ICollection<Trailer> Trailers { get; set; }

    public ICollection<Review> Reviews { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}