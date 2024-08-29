using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.ServiceContracts
{
    public interface IVillaNumberServices
    {
        Task<VillaNumberResponse> CreateAsync(VillaNumberAddRequest? addRequest);
        Task<VillaNumberResponse?> UpdateAsync(VillaNumberUpdateRequest? updateRequest);
        Task<bool> DeleteAsync(int? villaNumberId);
        Task<IEnumerable<VillaNumberResponse>> GetAllAsync(Expression<Func<VillaNumber,bool>>?predict=null);
        Task<VillaNumberResponse> GetByAsync(Expression<Func<VillaNumber, bool>>? predict = null, bool isTracked = true);
    }
}
