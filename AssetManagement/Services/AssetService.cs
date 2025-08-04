using AssetManagement.Contexts;
using AssetManagement.Exceptions;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTOs;
using AutoMapper;

namespace AssetManagement.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;

        public AssetService(
            IAssetRepository assetRepository,
            AssetManagementDbContext context,
            IMapper mapper)
        {
            _assetRepository = assetRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Asset> AddAsync(Asset entity)
        {
            return await _assetRepository.AddAsync(entity);
        }

        public async Task<Asset> UpdateAsync(int id, Asset entity)
        {
            var existing = await _assetRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException(nameof(Asset), id);

            return await _assetRepository.UpdateAsync(id, entity);
        }

        public async Task<Asset> DeleteAsync(int id)
        {
            var existing = await _assetRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException(nameof(Asset), id);

            return await _assetRepository.DeleteAsync(id);
        }

        public async Task<Asset?> GetByIdAsync(int id)
        {
            return await _assetRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _assetRepository.GetAllAsync();
        }
    }
}