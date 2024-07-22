using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T:class
{
    protected readonly MovieShopDbContext _movieShopDbContext;

    public BaseRepository(MovieShopDbContext movieShopDbContext)
    {
        this._movieShopDbContext = movieShopDbContext;
    }
    
    public int Insert(T obj)
    {
        _movieShopDbContext.Set<T>().Add(obj);
        return _movieShopDbContext.SaveChanges();
    }

    public int DeleteById(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _movieShopDbContext.Set<T>().Remove(entity);
            return _movieShopDbContext.SaveChanges();
        }

        return 0;
    }

    public int Update(T obj)
    {
        _movieShopDbContext.Entry(obj).State = EntityState.Modified;
        return _movieShopDbContext.SaveChanges();
    }

    public T GetById(int id)
    {
        return _movieShopDbContext.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _movieShopDbContext.Set<T>().ToList();
    }
}