using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ReviewRepository(MovieShopDbContext movieShopDbContext): BaseRepository<Review>(movieShopDbContext), IReviewRepository
{
    
}