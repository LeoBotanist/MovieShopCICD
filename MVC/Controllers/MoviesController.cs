using ApplicationCore.Contract.Services;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class MoviesController: Controller
{
    private readonly IMovieService _movieService;
    private readonly IGenreService _genreService;
    private IEnumerable<GenreResponseModel> _genres;
    
    public MoviesController(IMovieService service, IGenreService genreService)
    {
        this._movieService = service;
        this._genreService = genreService;
        this._genres = _genreService.GetAllGenres();
    }
    

    public IActionResult Index(int pageNumber = 1, int pageSize = 12)
    {
        
        var items = _movieService.GetMoviesPaging(pageNumber, pageSize);
        
        MovieCardPageModel movieCardPageModel = new MovieCardPageModel(pageNumber, pageSize);
        
        foreach (var item in items)
        {
            MovieCardViewModel model = new MovieCardViewModel();
            model.Id = item.Id;
            model.PosterUrl = item.PosterUrl;
            model.Title = item.Title;
            movieCardPageModel.MovieCardViewModels.Add(model);
        }

        ViewBag.Genres = this._genres;
        return View(movieCardPageModel);
    }

    public IActionResult Genre(string genreName, int genreId, int pageNumber = 1, int pageSize = 12)
    {
        var items = _movieService.GetMoviesByGenre(pageNumber, pageSize, genreId);
        
        MovieCardGenrePageModel movieCardGenrePageModel = new MovieCardGenrePageModel(pageNumber, pageSize, genreId, genreName);
        
        foreach (var item in items)
        {
            MovieCardViewModel model = new MovieCardViewModel();
            model.Id = item.Id;
            model.PosterUrl = item.PosterUrl;
            model.Title = item.Title;
            movieCardGenrePageModel.MovieCardViewModels.Add(model);
        }

        ViewBag.Genres = this._genres;
        ViewBag.CurrentGenre = genreName;
        return View(movieCardGenrePageModel);
    }

    public IActionResult Details(int id)
    {
        var model = _movieService.GetMovieDetailsById(id);
        
        MovieDetailPageModel entity = new MovieDetailPageModel();
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.Tagline = model.Tagline;
        entity.Price = model.Price;
        entity.Revenue = model.Revenue;
        entity.Title = model.Title;
        entity.CreatedBy = model.CreatedBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.Overview = model.Overview;
        entity.OriginalLanguage = model.OriginalLanguage;
        entity.PosterUrl = model.PosterUrl;
        entity.ReleaseDate = model.ReleaseDate;
        entity.RunTime = model.RunTime;
        entity.TmdbUrl = model.TmdbUrl;
        entity.UpdatedDate = model.UpdatedDate;
        entity.UpdatedBy = model.UpdatedBy;
        entity.MovieCasts = model.MovieCasts;
        entity.Genres = model.Genres;
        entity.Reviews = model.Reviews;
        entity.Purchases = model.Purchases;
        entity.Trailers = model.Trailers;

        Random random = new Random();
        entity.Rating = random.NextDouble() * 10;
        
        return View(entity);
    }
    
    public IActionResult Create()
    {
        return View();
    }
}