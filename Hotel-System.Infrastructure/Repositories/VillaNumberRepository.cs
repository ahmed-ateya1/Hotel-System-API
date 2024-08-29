using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.RepositoriyContracts;
using Hotel_System.Infrastructure.Data;


namespace Hotel_System.Infrastructure.Repositories
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VillaNumberRepository(ApplicationDbContext db , IMapper mapper):base(db) 
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber villanumber)
        {
            var oldVillaNumber = await GetByAsync(x=>x.VillaNum == villanumber.VillaNum);
            if (oldVillaNumber == null)
                return null;
            villanumber.UpdatedDate = DateTime.UtcNow;
            _mapper.Map(villanumber, oldVillaNumber);
            await SaveAsync();
            return oldVillaNumber;
        }
    }
}
