using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services;

public class CastService: ICastService
{
    private ICastRepository _castRepository;

    public CastService(ICastRepository castRepository)
    {
        this._castRepository = castRepository;
    }
    public int AddCast(CastRequestModel model)
    {
        Cast entity = new Cast();
        entity.Id = model.Id;
        entity.Gender = model.Gender;
        entity.Name = model.Name;
        entity.ProfilePath = model.ProfilePath;
        entity.TmdbUrl = model.TmdbUrl;
        return _castRepository.Insert(entity);
    }
    

    public int UpdateCast(CastRequestModel model)
    {
        Cast entity = new Cast();
        entity.Id = model.Id;
        entity.Gender = model.Gender;
        entity.Name = model.Name;
        entity.ProfilePath = model.ProfilePath;
        entity.TmdbUrl = model.TmdbUrl;

        return _castRepository.Update(entity);
    }

    public int DeleteCast(int id)
    {
        return _castRepository.DeleteById(id);
    }

    public CastResponseModel GetCastById(int id)
    {
        Cast model = _castRepository.GetById(id);
        CastResponseModel castResponseModel = new CastResponseModel();
        castResponseModel.Gender = model.Gender;
        castResponseModel.Name = model.Name;
        castResponseModel.TmdbUrl = model.TmdbUrl;
        castResponseModel.ProfilePath = model.ProfilePath;
        castResponseModel.MovieCasts = model.MovieCasts;
        castResponseModel.Movies = model.Movies;
        return castResponseModel;
    }

    public IEnumerable<CastResponseModel> GetAllCasts()
    {
        var result = _castRepository.GetAll();
        List<CastResponseModel> castResponseModels = new List<CastResponseModel>();
        foreach (var cast in result)
        {
            CastResponseModel model = new CastResponseModel();
            model.Gender = cast.Gender;
            model.TmdbUrl = cast.TmdbUrl;
            model.ProfilePath = cast.ProfilePath;
            model.Name = cast.Name;
            castResponseModels.Add(model);
        }

        return castResponseModels;
    }
}