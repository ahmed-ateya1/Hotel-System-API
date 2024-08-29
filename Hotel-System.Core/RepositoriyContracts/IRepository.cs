using Hotel_System.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.RepositoriyContracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByAsync(Expression<Func<T, bool>> filter = null, bool isTracked = true);
        Task<T> CreateAsync(T model);
        Task<bool> DeleteAsync(T model);
        Task SaveAsync();
    }
}
