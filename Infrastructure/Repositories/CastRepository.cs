using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CastRepository(MovieShopDbContext movieShopDbContext): BaseRepository<Cast>(movieShopDbContext), ICastRepository
{
    public new Cast GetById(int id)
    {
        // var result = movieShopDbContext.MovieCasts.
        return movieShopDbContext
                .Set<Cast>()
                .Include(c => c.MovieCasts)
                .ThenInclude(mc => mc.Movie)
                .FirstOrDefault(c => c.Id == id);

    }
}