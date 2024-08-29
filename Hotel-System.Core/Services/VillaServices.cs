using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.DTO;
using Hotel_System.Core.Helper;
using Hotel_System.Core.RepositoriyContracts;
using Hotel_System.Core.ServiceContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel_System.Core.Services
{
    public class VillaServices : IVillaServices
    {
        private readonly IVillaRepository _villaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<VillaServices> _logger;

        public VillaServices(IVillaRepository villaRepository, IMapper mapper, ILogger<VillaServices> logger)
        {
            _villaRepository = villaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<VillaResponse> CreateVillaAsync(VillaAddRequest? villaAdd)
        {
            if (villaAdd == null)
            {
                _logger.LogError("VillaAddRequest is null");
                throw new ArgumentNullException(nameof(villaAdd));
            }

            ValidationModel.ValidModel(villaAdd); 

            var villa = _mapper.Map<Villa>(villaAdd);
            villa.VillaID = Guid.NewGuid();

            await _villaRepository.CreateAsync(villa);

            _logger.LogInformation("Villa created successfully with ID: {VillaID}", villa.VillaID);

            return _mapper.Map<VillaResponse>(villa);
        }

        public async Task<bool> DeleteVillaAsync(Guid? villaID)
        {
            if (villaID == null)
            {
                _logger.LogError("villaID is null");
                throw new ArgumentNullException(nameof(villaID));
            }

            var villa = await _villaRepository.GetByAsync(x => x.VillaID == villaID.Value);

            if (villa == null)
            {
                _logger.LogWarning("Villa not found with ID: {VillaID}", villaID);
                return false;
            }

            var result = await _villaRepository.DeleteAsync(villa);

            if (result)
                _logger.LogInformation("Villa deleted successfully with ID: {VillaID}", villaID);

            return result;
        }

        public async Task<IEnumerable<VillaResponse>> GetAllAysnc(Expression<Func<Villa, bool>>? predict = null)
        {
            var villaList = await _villaRepository.GetAllAsync(predict);

            _logger.LogInformation("Retrieved {Count} villas", villaList.Count());

            return _mapper.Map<IEnumerable<VillaResponse>>(villaList);
        }

        public async Task<VillaResponse> GetByAsync(Expression<Func<Villa, bool>>? predict = null, bool IsTracked = true)
        {
            var villa = await _villaRepository.GetByAsync(predict, IsTracked);

            if (villa == null)
            {
                _logger.LogWarning("Villa not found with specified criteria");
                return null;
            }

            return _mapper.Map<VillaResponse>(villa);
        }

        public async Task<VillaResponse> UpdateVillaAsync(VillaUpdateRequest? villaUpdate)
        {
            if (villaUpdate == null)
            {
                _logger.LogError("VillaUpdateRequest is null");
                throw new ArgumentNullException(nameof(villaUpdate));
            }

            ValidationModel.ValidModel(villaUpdate);

            var existingVilla = await _villaRepository.GetByAsync(x => x.VillaID == villaUpdate.VillaID);

            if (existingVilla == null)
            {
                _logger.LogWarning("Villa not found for update with ID: {VillaID}", villaUpdate.VillaID);
                return null; 
            }

            var updatedVilla = _mapper.Map(villaUpdate, existingVilla);

            await _villaRepository.UpdateVillaAsync(updatedVilla);

            _logger.LogInformation("Villa updated successfully with ID: {VillaID}", updatedVilla.VillaID);

            return _mapper.Map<VillaResponse>(updatedVilla);
        }
    }
}
