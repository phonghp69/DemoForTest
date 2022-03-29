using backend.Interfaces;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;
using backend.Authorization;
using backend.Enums;

namespace backend.Controllers
{
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private IAssetService _service;
        public AssetController(IAssetService service)
        {
            _service = service;
        }
        [Authorize(Role.Admin)]
        [HttpPost]
        public async Task AddAsset([FromBody] AssetDTO asset)
        {
            await _service.AddAsset(asset);
        }
        [Authorize(Role.Admin)]
        [HttpPut("{id}")]
        public async Task UpdateAsset(int id, [FromBody] AssetDTO asset)
        {
            await _service.UpdateAsset(asset, id);
        }
        [Authorize(Role.Admin)]
        [HttpDelete("{id}")]
        public async Task DeleteAsset(int id)
        {
            await _service.DeleteAsset(id);
        }
        [Authorize(Role.Admin)]
        [HttpGet("{id}")]
        public async Task<AssetDTO> GetAsset(int id)
        {
            return await _service.GetAsset(id);
        }
        [Authorize(Role.Admin)]
        [HttpGet("all")]
        public async Task<List<AssetDTO>> GetAllAsset()
        {
            return await _service.GetAllAsset();
        }
    }
}