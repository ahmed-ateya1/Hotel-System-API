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
    public interface IVillaServices
    {
        Task<VillaResponse> CreateVillaAsync(VillaAddRequest? villaAdd);
        Task<VillaResponse> UpdateVillaAsync(VillaUpdateRequest? villaUpdate);
        Task<bool> DeleteVillaAsync(Guid? villaID);
        Task<IEnumerable<VillaResponse>> GetAllAysnc(Expression<Func<Villa , bool>>? predict=null);
        Task<VillaResponse> GetByAsync(Expression<Func<Villa, bool>>? predict= null, bool IsTracked = true);
    }
}
