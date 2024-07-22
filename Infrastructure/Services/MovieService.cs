using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        this._movieRepository = movieRepository;
    }
    
    public int AddMovie(MovieRequestModel model)
    {
        Movie entity = new Movie();
        entity.Id = model.Id;
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.Overview = model.Overview;
        entity.Tagline = model.Tagline;
        entity.Price = model.Price;
        entity.Revenue = model.Revenue;
        entity.Title = model.Title;
        entity.CreatedBy = model.CreatedBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.OriginalLanguage = model.OriginalLanguage;
        entity.PosterUrl = model.PosterUrl;
        entity.ReleaseDate = model.ReleaseDate;
        entity.RunTime = model.RunTime;
        entity.TmdbUrl = model.TmdbUrl;
        entity.UpdatedDate = model.UpdatedDate;
        entity.UpdatedBy = model.UpdatedBy;

        return _movieRepository.Insert(entity);
    }

    public int UpdateMovie(MovieRequestModel model, int id)
    {
        Movie entity = new Movie();
        entity.Id = id;
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.Overview = model.Overview;
        entity.Tagline = model.Tagline;
        entity.Price = model.Price;
        entity.Revenue = model.Revenue;
        entity.Title = model.Title;
        entity.CreatedBy = model.CreatedBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.OriginalLanguage = model.OriginalLanguage;
        entity.PosterUrl = model.PosterUrl;
        entity.ReleaseDate = model.ReleaseDate;
        entity.RunTime = model.RunTime;
        entity.TmdbUrl = model.TmdbUrl;
        entity.UpdatedDate = model.UpdatedDate;
        entity.UpdatedBy = model.UpdatedBy;
        return _movieRepository.Update(entity);

    }

    public int DeleteMovie(int id)
    {
        return _movieRepository.DeleteById(id);
    }

    public MovieResponseModel GetMovieById(int id)
    {
        MovieResponseModel entity = new MovieResponseModel();
        Movie model = _movieRepository.GetById(id);
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.Overview = model.Overview;
        entity.Tagline = model.Tagline;
        entity.Price = model.Price;
        entity.Revenue = model.Revenue;
        entity.Title = model.Title;
        entity.CreatedBy = model.CreatedBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.OriginalLanguage = model.OriginalLanguage;
        entity.PosterUrl = model.PosterUrl;
        entity.ReleaseDate = model.ReleaseDate;
        entity.RunTime = model.RunTime;
        entity.TmdbUrl = model.TmdbUrl;
        entity.UpdatedDate = model.UpdatedDate;
        entity.UpdatedBy = model.UpdatedBy;
        return entity;
    }

    public MovieDetailResponseModel GetMovieDetailsById(int id)
    {
        var model = _movieRepository.GetMovieDetailsById(id);
        MovieDetailResponseModel entity = new MovieDetailResponseModel();
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
        entity.Genres = model.MovieGenres.Select(mg => mg.Genre).ToList();
        entity.Reviews = model.Reviews.ToList();
        entity.Purchases = model.Purchases.ToList();
        entity.Trailers = model.Trailers.ToList();
        return entity;
    }

    public MovieResponseModel GetHighestGrossingMovie()
    {
        MovieResponseModel entity = new MovieResponseModel();
        Movie model = _movieRepository.GetHighestGrossingMovie();
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.Overview = model.Overview;
        entity.Tagline = model.Tagline;
        entity.Price = model.Price;
        entity.Revenue = model.Revenue;
        entity.Title = model.Title;
        entity.CreatedBy = model.CreatedBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.OriginalLanguage = model.OriginalLanguage;
        entity.PosterUrl = model.PosterUrl;
        entity.ReleaseDate = model.ReleaseDate;
        entity.RunTime = model.RunTime;
        entity.TmdbUrl = model.TmdbUrl;
        entity.UpdatedDate = model.UpdatedDate;
        entity.UpdatedBy = model.UpdatedBy;
        return entity;

    }

    public IEnumerable<MovieCardResponseModel> GetAllMovieCards()
    {
        var result = _movieRepository.GetAll();
        List<MovieCardResponseModel> movieCardResponseModels = new List<MovieCardResponseModel>();
        foreach (var model in result)
        {
            MovieCardResponseModel entity = new MovieCardResponseModel();
            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.PosterUrl = model.PosterUrl;
            movieCardResponseModels.Add(entity);
        }

        return movieCardResponseModels;
    }
    
    public IEnumerable<MovieResponseModel> GetAllMovies()
    {
        var result = _movieRepository.GetAll();
        List<MovieResponseModel> movieResponseModels = new List<MovieResponseModel>();
        foreach (var model in result)
        {
            MovieResponseModel entity = new MovieResponseModel();
            entity.BackdropUrl = model.BackdropUrl;
            entity.Budget = model.Budget;
            entity.Overview = model.Overview;
            entity.Tagline = model.Tagline;
            entity.Price = model.Price;
            entity.Revenue = model.Revenue;
            entity.Title = model.Title;
            entity.CreatedBy = model.CreatedBy;
            entity.CreatedDate = model.CreatedDate;
            entity.ImdbUrl = model.ImdbUrl;
            entity.OriginalLanguage = model.OriginalLanguage;
            entity.PosterUrl = model.PosterUrl;
            entity.ReleaseDate = model.ReleaseDate;
            entity.RunTime = model.RunTime;
            entity.TmdbUrl = model.TmdbUrl;
            entity.UpdatedDate = model.UpdatedDate;
            entity.UpdatedBy = model.UpdatedBy;
            movieResponseModels.Add(entity);
        }

        return movieResponseModels;
    }

    public IEnumerable<MovieCardResponseModel> GetMoviesPaging(int pageNumber, int pageSize)
    {
        var result = _movieRepository.GetMoviePaging(pageNumber, pageSize);
        List<MovieCardResponseModel> movieCardResponseModels = new List<MovieCardResponseModel>();
        foreach (var model in result)
        {
            MovieCardResponseModel entity = new MovieCardResponseModel();
            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.PosterUrl = model.PosterUrl;
            movieCardResponseModels.Add(entity);
        }

        return movieCardResponseModels;
    }

    public IEnumerable<MovieCardResponseModel> GetMoviesByGenre(int pageNumber, int pageSize, int genreId)
    {
        var result = _movieRepository.GetMoviesByGenre(pageNumber, pageSize, genreId);
        List<MovieCardResponseModel> movieCardResponseModels = new List<MovieCardResponseModel>();
        foreach (var model in result)
        {
            MovieCardResponseModel entity = new MovieCardResponseModel();
            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.PosterUrl = model.PosterUrl;
            movieCardResponseModels.Add(entity);
        }

        return movieCardResponseModels;
    }

    public void PrintCasts()
    {
        _movieRepository.PrintCasts();
    }
}