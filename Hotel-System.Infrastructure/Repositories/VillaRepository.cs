using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.RepositoriyContracts;
using Hotel_System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel_System.Infrastructure.Repositories
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VillaRepository(ApplicationDbContext db, IMapper mapper): base(db)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Villa> UpdateAsync(Villa villa)
        {
            var oldVilla = await GetByAsync(x=>x.VillaID == villa.VillaID);

            if (oldVilla == null) return null;

            villa.UpdatedDate = DateTime.UtcNow;
            _mapper.Map(villa, oldVilla);

            await SaveAsync();
            return oldVilla;
        }        
    }
}
