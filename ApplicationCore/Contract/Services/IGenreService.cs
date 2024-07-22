using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contract.Services;

public interface IGenreService
{
    int AddGenre(GenreRequestModel model);
    int UpdateGenre(GenreRequestModel model, int id);
    int DeleteGenre(int id);
    GenreResponseModel GetGenreById(int id);
    IEnumerable<GenreResponseModel> GetAllGenres();
}