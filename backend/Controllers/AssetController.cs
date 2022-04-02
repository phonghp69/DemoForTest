using backend.Interfaces;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;
using backend.Entities;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private IAssetService _service;
        public AssetController(IAssetService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddAsset([FromBody] AssetDTO asset, int categoryId)
        {
            await _service.AddAsset(asset, categoryId);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsset(int id, [FromBody] AssetDTO asset)
        {
            await _service.UpdateAsset(asset, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsset(int id)
        {
            await _service.DeleteAsset(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDTO>> GetAsset(int id)
        {
            return await _service.GetAsset(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<AssetDTO>>> GetAllAsset()
        {
            return await _service.GetAllAsset();
        }
        
    }
}