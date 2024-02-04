using Microsoft.EntityFrameworkCore;

namespace BikeShopNET.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly BikeShopContext _dbContext;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(BikeShopContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<TEntity>();
        }

        // Get all
        public List<TEntity> GetAll()
        {
            return _table.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        // Create
        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // Update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        // Delete
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        // Find
        public TEntity FindById(string id)
        {
            return _table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(string id)
        {
            return await _table.FindAsync(id);
        }

        // Save
        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }
        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

    }
}
