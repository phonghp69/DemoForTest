using backend.DTO;
using backend.Models.Assets;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IAssetService
    {
        public Task AddAsset(AssetCreateModel asset, string Location);
        public Task UpdateAsset(AssetDTO asset, int id);
        public Task DeleteAsset(int id);
        public Task<ActionResult<AssetDTO>> GetAsset(int id);
        public Task<ActionResult<List<AssetDTO>>> GetAllAsset();
    }
}