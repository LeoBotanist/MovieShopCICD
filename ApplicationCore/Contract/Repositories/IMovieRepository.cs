using ApplicationCore.Entities;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contract.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    Movie? GetHighestGrossingMovie();

    void PrintCasts();
    Movie GetMovieDetailsById(int id);

    IEnumerable<Movie> GetMoviePaging(int pageNumber, int pageSize);

    IEnumerable<Movie> GetMoviesByGenre(int pageNumber, int pageSize, int genreId);

}