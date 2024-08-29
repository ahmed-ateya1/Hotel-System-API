using Hotel_System.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.RepositoriyContracts
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateVillaAsync(Villa villa);
    }
}
