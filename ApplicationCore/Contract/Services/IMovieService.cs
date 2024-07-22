using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contract.Services;

public interface IMovieService
{
    int AddMovie(MovieRequestModel model);
    int UpdateMovie(MovieRequestModel model, int id);
    int DeleteMovie(int id);
    MovieResponseModel GetMovieById(int id);

    MovieDetailResponseModel GetMovieDetailsById(int id);
    
    IEnumerable<MovieCardResponseModel> GetAllMovieCards();
    IEnumerable<MovieResponseModel> GetAllMovies();

    IEnumerable<MovieCardResponseModel> GetMoviesPaging(int pageNumber, int pageSize);

    IEnumerable<MovieCardResponseModel> GetMoviesByGenre(int pageNumber, int pageSize, int genreId);

    void PrintCasts();
}