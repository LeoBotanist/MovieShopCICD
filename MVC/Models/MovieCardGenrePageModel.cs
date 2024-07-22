namespace MVC.Models;

public class MovieCardGenrePageModel(int pageNumber, int pageSize, int genreId, string genreName)
{
    public List<MovieCardViewModel> MovieCardViewModels { get; set; } = [];
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int GenreId { get; set; } = genreId;

    public string GenreName { get; set; } = genreName;
}