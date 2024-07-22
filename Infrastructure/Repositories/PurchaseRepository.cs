using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PurchaseRepository(MovieShopDbContext movieShopDbContext): BaseRepository<Purchase>(movieShopDbContext), IPurchaseRepository
{
    
}