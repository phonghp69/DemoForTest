using backend.Interfaces;
using backend.Data;
using backend.DTO;
using Microsoft.EntityFrameworkCore;
using backend.Utilities;

namespace backend.Services
{
    public class AssetService : IAssetService
    {
        private MyDbContext _context;
        public AssetService(MyDbContext context)
        {
            _context = context;
        }
        public async Task AddAsset(AssetDTO asset)
        {
            await _context.Assets.AddAsync(asset.AssetDTOToEntity());
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsset(AssetDTO asset, int id)
        {
            var assetToUpdate = await _context.Assets.FindAsync(id);
            if (assetToUpdate != null)
            {
                assetToUpdate = asset.AssetDTOToEntity();
                assetToUpdate.AssetId = id;
                _context.Assets.Update(assetToUpdate);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsset(int id)
        {
            var assetToDelete = await _context.Assets.FindAsync(id);
            if (assetToDelete != null)
            {
                _context.Assets.Remove(assetToDelete);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<AssetDTO> GetAsset(int id)
        {
            var foundAsset = await _context.Assets.FindAsync(id);
            if (foundAsset != null)
                return foundAsset.AssetEntityToDTO();
            return null;
        }
        public async Task<List<AssetDTO>> GetAllAsset()
        {
            return await _context.Assets.Select(asset => asset.AssetEntityToDTO()).ToListAsync();
        }
    }
}