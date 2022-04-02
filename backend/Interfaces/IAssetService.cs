using backend.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IAssetService
    {
        public Task AddAsset(AssetDTO asset);
        public Task UpdateAsset(AssetDTO asset, int id);
        public Task DeleteAsset(int id);
        public Task<ActionResult<AssetDTO>> GetAsset(int id);
        public Task<ActionResult<List<AssetDTO>>> GetAllAsset();
    }
}