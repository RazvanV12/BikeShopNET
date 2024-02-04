using Microsoft.EntityFrameworkCore;

namespace BikeShopNET.Services.GenericService
{
    public class GenericService<T> : IGenericService<T> where T : class

    {
        protected readonly BikeShopContext _db;

        public GenericService (BikeShopContext db)
        {
           this._db = db;
        }
        public async Task Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task<List<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
    }
}
