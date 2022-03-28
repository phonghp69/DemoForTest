using backend.DTO;

namespace backend.Interfaces
{
    public interface IAssetService
    {
        public Task AddAsset(AssetDTO asset);
        public Task UpdateAsset(AssetDTO asset, int id);
        public Task DeleteAsset(int id);
        public Task <AssetDTO> GetAsset(int id);
        public Task<List<AssetDTO>> GetAllAsset();
    }
}