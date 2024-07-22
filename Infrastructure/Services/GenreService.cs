using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services;

public class GenreService: IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        this._genreRepository = genreRepository;
    }
    public int AddGenre(GenreRequestModel model)
    {
        Genre entity = new Genre();
        entity.Id = model.Id;
        entity.Name = model.Name;
        return _genreRepository.Insert(entity);
    }

    public int UpdateGenre(GenreRequestModel model, int id)
    {
        Genre entity = new Genre();
        entity.Id = id;
        entity.Name = model.Name;
        return _genreRepository.Update(entity);
    }

    public int DeleteGenre(int id)
    {
        return _genreRepository.DeleteById(id);
    }

    public GenreResponseModel GetGenreById(int id)
    {
        GenreResponseModel genreResponseModel = new GenreResponseModel();
        Genre entity = _genreRepository.GetById(id);
        genreResponseModel.Id = entity.Id;
        genreResponseModel.Name = entity.Name;
        return genreResponseModel;
    }

    public IEnumerable<GenreResponseModel> GetAllGenres()
    {
        var result = _genreRepository.GetAll();
        List<GenreResponseModel> genreResponseModels = new List<GenreResponseModel>();
        foreach (var entity in result)
        {
            GenreResponseModel model = new GenreResponseModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            genreResponseModels.Add(model);
        }

        return genreResponseModels;
    }
}