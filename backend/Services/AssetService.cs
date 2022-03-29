using backend.Interfaces;
using backend.Data;
using backend.DTO;
using Microsoft.EntityFrameworkCore;
using backend.Utilities;

namespace backend.Services
{
    public class AssetService : IAssetService
    {
        private MyDbContext _service;
        public AssetService(MyDbContext service)
        {
            _service = service;
        }
        public async Task AddAsset(AssetDTO asset)
        {
            await _service.Assets.AddAsync(asset.AssetDTOToEntity());
            await _service.SaveChangesAsync();
        }
        public async Task UpdateAsset(AssetDTO asset, int id)
        {
            var assetToUpdate = await _service.Assets.FindAsync(id);
            if (assetToUpdate != null)
            {
                assetToUpdate = asset.AssetDTOToEntity();
                assetToUpdate.AssetId = id;
                _service.Assets.Update(assetToUpdate);
                await _service.SaveChangesAsync();
            }
        }
        public async Task DeleteAsset(int id)
        {
            var assetToDelete = await _service.Assets.FindAsync(id);
            if (assetToDelete != null)
            {
                _service.Assets.Remove(assetToDelete);
                await _service.SaveChangesAsync();
            }
        }
        public async Task<AssetDTO> GetAsset(int id)
        {
            var foundAsset = await _service.Assets.FindAsync(id);
            if (foundAsset != null)
                return foundAsset.AssetEntityToDTO();
            return null;
        }
        public async Task<List<AssetDTO>> GetAllAsset()
        {
            return await _service.Assets.Select(asset => asset.AssetEntityToDTO()).ToListAsync();
        }
    }
}