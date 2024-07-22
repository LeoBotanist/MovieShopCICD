namespace MVC.Models;

public class MovieCardPageModel(int pageNumber, int pageSize)
{
    public List<MovieCardViewModel> MovieCardViewModels { get; set; } = [];
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
}