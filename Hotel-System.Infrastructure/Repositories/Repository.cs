using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.RepositoriyContracts;
using Hotel_System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }

        public async Task<T> CreateAsync(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            await _dbSet.AddAsync(model);
            await SaveAsync();
            return model;
        }

        public async Task<bool> DeleteAsync(T model)
        {
            if (model == null) return false;
            _dbSet.Remove(model);
            await SaveAsync();
            return true; 
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query =  _dbSet;

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> filter = null, bool isTracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!isTracked)
                query = query.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
