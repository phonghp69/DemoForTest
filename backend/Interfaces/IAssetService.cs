using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.DB.DTO;

namespace Back_end.Interface
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