using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository(MovieShopDbContext movieShopDbContext) : BaseRepository<User>(movieShopDbContext), IUserRepository
{
    
}