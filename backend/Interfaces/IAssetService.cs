using backend.DTO;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IAssetService
    {
        public Task<AssetInforDTO> GetAssetInfor(int id);
        // public Task<ActionResult<List<AssetInforDTO>>> GetListAssetInfor();
        public Task AddAsset(int categoryId, AssetDTO assetDTO);
        public Task<ActionResult> UpdateAsset(AssetDTO asset, int id);
        public Task<ActionResult> DeleteAsset(int id);
        public Task<ActionResult<AssetDTO>> GetAsset(int id);
        public Task<ActionResult<List<AssetDTO>>> GetAllAsset();
    }
}