using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.DTO;
using Hotel_System.Core.Helper;
using Hotel_System.Core.RepositoriyContracts;
using Hotel_System.Core.ServiceContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel_System.Core.Services
{
    public class VillaNumberServices : IVillaNumberServices
    {
        private readonly IVillaNumberRepository _villaNumberRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<VillaNumber> _logger;

        public VillaNumberServices(IVillaNumberRepository villaNumberRepository, IMapper mapper, ILogger<VillaNumber> logger)
        {
            _villaNumberRepository = villaNumberRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<VillaNumberResponse> CreateAsync(VillaNumberAddRequest? addRequest)
        {
            if (addRequest == null)
                throw new ArgumentNullException(nameof(addRequest));

            ValidationModel.ValidModel(addRequest);

            var villaNumber = _mapper.Map<VillaNumber>(addRequest);
            villaNumber.CreatedDate = DateTime.UtcNow;
            await _villaNumberRepository.CreateAsync(villaNumber);

            return _mapper.Map<VillaNumberResponse>(villaNumber);
        }

        public async Task<bool> DeleteAsync(int? villaNumberId)
        {
            if (villaNumberId == null)
                throw new ArgumentNullException(nameof(villaNumberId));

            var villa = await _villaNumberRepository.GetByAsync(x => x.VillaNum == villaNumberId);
            if (villa == null)
                return false;

            return await _villaNumberRepository.DeleteAsync(villa);
        }

        public async Task<IEnumerable<VillaNumberResponse>> GetAllAsync(Expression<Func<VillaNumber, bool>>? predict = null)
        {
            var villaList = await _villaNumberRepository.GetAllAsync(predict, includeProperties: "Villa");
            return _mapper.Map<IEnumerable<VillaNumberResponse>>(villaList);
        }

        public async Task<VillaNumberResponse> GetByAsync(Expression<Func<VillaNumber, bool>>? predict = null, bool isTracked = true)
        {
            var villaNumber = await _villaNumberRepository.GetByAsync(predict, isTracked, includeProperties: "Villa");
            return _mapper.Map<VillaNumberResponse>(villaNumber);
        }

        public async Task<VillaNumberResponse?> UpdateAsync(VillaNumberUpdateRequest? updateRequest)
        {
            if (updateRequest == null)
                throw new ArgumentNullException(nameof(updateRequest));

            var villa = await _villaNumberRepository.GetByAsync(x => x.VillaNum == updateRequest.VillaNum, includeProperties: "Villa");
            if (villa == null) return null;

            var villaNumber = _mapper.Map(updateRequest, villa);
            villaNumber.UpdatedDate = DateTime.UtcNow;

            await _villaNumberRepository.UpdateAsync(villaNumber);
            return _mapper.Map<VillaNumberResponse?>(villaNumber);
        }
    }
}